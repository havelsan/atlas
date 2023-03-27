
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
    /// Sağlık Kurulu Muvazzaf Üç İmza Raporu
    /// </summary>
    public partial class HCRegularThreeSpecialistReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("35E0EB8B-B386-44BB-A25E-AC95ED7C9F2C");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HCRegularThreeSpecialistReport MyParentReport
            {
                get { return (HCRegularThreeSpecialistReport)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField RAPOR { get {return Header().RAPOR;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField SNO { get {return Header().SNO;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportField NewField41 { get {return Header().NewField41;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportShape NewLine9 { get {return Header().NewLine9;} }
            public TTReportShape NewLine10 { get {return Header().NewLine10;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField46 { get {return Header().NewField46;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField NewField48 { get {return Header().NewField48;} }
            public TTReportField NewField52 { get {return Header().NewField52;} }
            public TTReportField NewField62 { get {return Header().NewField62;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField GIRIS { get {return Header().GIRIS;} }
            public TTReportField CIKIS { get {return Header().CIKIS;} }
            public TTReportField KNO { get {return Header().KNO;} }
            public TTReportField SERVIS { get {return Header().SERVIS;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField NewField53 { get {return Header().NewField53;} }
            public TTReportField NewField43 { get {return Header().NewField43;} }
            public TTReportField NewField34 { get {return Header().NewField34;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportField NewField64 { get {return Header().NewField64;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField NewField49 { get {return Header().NewField49;} }
            public TTReportField NewField94 { get {return Header().NewField94;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportField EMIR { get {return Header().EMIR;} }
            public TTReportField MAKSAT { get {return Header().MAKSAT;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportField MUAYENESAYI { get {return Header().MUAYENESAYI;} }
            public TTReportShape NewLine19 { get {return Header().NewLine19;} }
            public TTReportShape NewLine20 { get {return Header().NewLine20;} }
            public TTReportField KILO { get {return Header().KILO;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportShape NewLine21 { get {return Header().NewLine21;} }
            public TTReportField RAPORTARIH { get {return Header().RAPORTARIH;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField DOCNUMBER { get {return Header().DOCNUMBER;} }
            public TTReportField DOCDATE { get {return Header().DOCDATE;} }
            public TTReportField AD { get {return Header().AD;} }
            public TTReportField SOYAD { get {return Header().SOYAD;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField344 { get {return Footer().NewField344;} }
            public TTReportField NewField446 { get {return Footer().NewField446;} }
            public TTReportField NewField54 { get {return Footer().NewField54;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField DIPLOMASICIL { get {return Footer().DIPLOMASICIL;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField EKYAZI1 { get {return Footer().EKYAZI1;} }
            public TTReportField EKYAZI2 { get {return Footer().EKYAZI2;} }
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
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField RAPOR;
                public TTReportField XXXXXXBASLIK;
                public TTReportField ADISOYADI;
                public TTReportField NewField14;
                public TTReportField SNO;
                public TTReportField RAPORNO;
                public TTReportField NewField144;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportField ACTIONID;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportField NewField41;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportShape NewLine9;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportField NewField46;
                public TTReportField NewField15;
                public TTReportField NewField26;
                public TTReportField NewField48;
                public TTReportField NewField52;
                public TTReportField NewField62;
                public TTReportField MAKAM;
                public TTReportField GIRIS;
                public TTReportField CIKIS;
                public TTReportField KNO;
                public TTReportField SERVIS;
                public TTReportField NewField51;
                public TTReportField BABAADI;
                public TTReportField NewField53;
                public TTReportField NewField43;
                public TTReportField NewField34;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportField NewField64;
                public TTReportField NewField44;
                public TTReportField NewField45;
                public TTReportField NewField49;
                public TTReportField NewField94;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportField EMIR;
                public TTReportField MAKSAT;
                public TTReportShape NewLine18;
                public TTReportField MUAYENESAYI;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportField KILO;
                public TTReportField BOY;
                public TTReportShape NewLine21;
                public TTReportField RAPORTARIH;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField DOCNUMBER;
                public TTReportField DOCDATE;
                public TTReportField AD;
                public TTReportField SOYAD; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 101;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 26, 193, 31, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR.NoClip = EvetHayirEnum.ehEvet;
                    RAPOR.TextFont.Name = "Arial Narrow";
                    RAPOR.TextFont.Size = 11;
                    RAPOR.TextFont.Bold = true;
                    RAPOR.Value = @"RAPOR (MUVAZZAF)";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 193, 26, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"{%SITENAME%}
{%SITECITY%}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 42, 169, 46, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial Narrow";
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{%AD%} {%SOYAD%}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 39, 27, 47, false);
                    NewField14.Name = "NewField14";
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.NoClip = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"SERVİS RAP.NU VE TARİHİ";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 48, 71, 52, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.NoClip = EvetHayirEnum.ehEvet;
                    SNO.TextFont.Name = "Arial Narrow";
                    SNO.TextFont.Size = 8;
                    SNO.Value = @"{#SKNO#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 39, 71, 43, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 48, 27, 52, false);
                    NewField144.Name = "NewField144";
                    NewField144.NoClip = EvetHayirEnum.ehEvet;
                    NewField144.TextFont.Name = "Arial Narrow";
                    NewField144.TextFont.Size = 8;
                    NewField144.TextFont.Bold = true;
                    NewField144.Value = @"SĞ.KRL.RP.NU.";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 91, 192, 91, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 32, 192, 32, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 32, 4, 68, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 192, 32, 192, 101, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 224, 192, 229, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextColor = System.Drawing.Color.White;
                    ACTIONID.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 8;
                    ACTIONID.Value = @"";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 38, 170, 38, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 47, 170, 47, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 59, 170, 59, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 81, 192, 81, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 33, 27, 37, false);
                    NewField41.Name = "NewField41";
                    NewField41.NoClip = EvetHayirEnum.ehEvet;
                    NewField41.TextFont.Name = "Arial Narrow";
                    NewField41.TextFont.Size = 8;
                    NewField41.TextFont.Bold = true;
                    NewField41.Value = @"SERVİS";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 60, 27, 64, false);
                    NewField24.Name = "NewField24";
                    NewField24.NoClip = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 8;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"HAST. GİRİŞ";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 54, 27, 58, false);
                    NewField25.Name = "NewField25";
                    NewField25.NoClip = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.TextFont.Size = 8;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"KARANTİNA NU";

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 28, 32, 28, 101, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 32, 72, 101, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 32, 170, 65, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField46 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 66, 94, 70, false);
                    NewField46.Name = "NewField46";
                    NewField46.NoClip = EvetHayirEnum.ehEvet;
                    NewField46.TextFont.Name = "Arial Narrow";
                    NewField46.TextFont.Size = 8;
                    NewField46.TextFont.Bold = true;
                    NewField46.Value = @"DOĞ.YER/TARİH";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 42, 94, 46, false);
                    NewField15.Name = "NewField15";
                    NewField15.NoClip = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"ADI SOYADI";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 72, 27, 80, false);
                    NewField26.Name = "NewField26";
                    NewField26.MultiLine = EvetHayirEnum.ehEvet;
                    NewField26.NoClip = EvetHayirEnum.ehEvet;
                    NewField26.WordBreak = EvetHayirEnum.ehEvet;
                    NewField26.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 8;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"MUAY. GÖND.     MAKAM";

                    NewField48 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 66, 27, 70, false);
                    NewField48.Name = "NewField48";
                    NewField48.NoClip = EvetHayirEnum.ehEvet;
                    NewField48.TextFont.Name = "Arial Narrow";
                    NewField48.TextFont.Size = 8;
                    NewField48.TextFont.Bold = true;
                    NewField48.Value = @"HAST. ÇIKIŞ";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 92, 94, 99, false);
                    NewField52.Name = "NewField52";
                    NewField52.NoClip = EvetHayirEnum.ehEvet;
                    NewField52.TextFont.Name = "Arial Narrow";
                    NewField52.TextFont.Size = 8;
                    NewField52.TextFont.Bold = true;
                    NewField52.Value = @"DEVAMLI ADRESİ";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 45, 188, 49, false);
                    NewField62.Name = "NewField62";
                    NewField62.NoClip = EvetHayirEnum.ehEvet;
                    NewField62.TextFont.Name = "Arial Narrow";
                    NewField62.TextFont.Size = 8;
                    NewField62.Value = @"FOTOĞRAF";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 73, 71, 80, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.NoClip = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    GIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 60, 71, 64, false);
                    GIRIS.Name = "GIRIS";
                    GIRIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIRIS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    GIRIS.TextFormat = @"Short Date";
                    GIRIS.NoClip = EvetHayirEnum.ehEvet;
                    GIRIS.TextFont.Name = "Arial Narrow";
                    GIRIS.TextFont.Size = 8;
                    GIRIS.Value = @"{#HGIRISTARIHI#}";

                    CIKIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 66, 71, 70, false);
                    CIKIS.Name = "CIKIS";
                    CIKIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKIS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CIKIS.TextFormat = @"Short Date";
                    CIKIS.NoClip = EvetHayirEnum.ehEvet;
                    CIKIS.TextFont.Name = "Arial Narrow";
                    CIKIS.TextFont.Size = 8;
                    CIKIS.Value = @"{#HCIKISTARIHI#}";

                    KNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 54, 71, 58, false);
                    KNO.Name = "KNO";
                    KNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KNO.MultiLine = EvetHayirEnum.ehEvet;
                    KNO.WordBreak = EvetHayirEnum.ehEvet;
                    KNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KNO.TextFont.Name = "Arial Narrow";
                    KNO.TextFont.Size = 8;
                    KNO.Value = @"{#KARANTINANO#}";

                    SERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 33, 71, 37, false);
                    SERVIS.Name = "SERVIS";
                    SERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SERVIS.NoClip = EvetHayirEnum.ehEvet;
                    SERVIS.ObjectDefName = "Resource";
                    SERVIS.DataMember = "NAME";
                    SERVIS.TextFont.Name = "Arial Narrow";
                    SERVIS.TextFont.Size = 8;
                    SERVIS.Value = @"{#BOLUMID#}";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 33, 94, 37, false);
                    NewField51.Name = "NewField51";
                    NewField51.NoClip = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.TextFont.Size = 8;
                    NewField51.TextFont.Bold = true;
                    NewField51.Value = @"BİRLİK";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 48, 169, 52, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.MultiLine = EvetHayirEnum.ehEvet;
                    BABAADI.NoClip = EvetHayirEnum.ehEvet;
                    BABAADI.WordBreak = EvetHayirEnum.ehEvet;
                    BABAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BABAADI.ObjectDefName = "Patient";
                    BABAADI.DataMember = "FATHERNAME";
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#PATIENTID#}";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 48, 94, 52, false);
                    NewField53.Name = "NewField53";
                    NewField53.NoClip = EvetHayirEnum.ehEvet;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.TextFont.Size = 8;
                    NewField53.TextFont.Bold = true;
                    NewField53.Value = @"BABA ADI";

                    NewField43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 72, 94, 76, false);
                    NewField43.Name = "NewField43";
                    NewField43.MultiLine = EvetHayirEnum.ehEvet;
                    NewField43.NoClip = EvetHayirEnum.ehEvet;
                    NewField43.WordBreak = EvetHayirEnum.ehEvet;
                    NewField43.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField43.TextFont.Name = "Arial Narrow";
                    NewField43.TextFont.Size = 8;
                    NewField43.TextFont.Bold = true;
                    NewField43.Value = @"BAĞ.BUL.";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 76, 94, 80, false);
                    NewField34.Name = "NewField34";
                    NewField34.MultiLine = EvetHayirEnum.ehEvet;
                    NewField34.NoClip = EvetHayirEnum.ehEvet;
                    NewField34.WordBreak = EvetHayirEnum.ehEvet;
                    NewField34.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField34.TextFont.Name = "Arial Narrow";
                    NewField34.TextFont.Size = 8;
                    NewField34.TextFont.Bold = true;
                    NewField34.Value = @"AS.Ş.BŞK.LIĞI";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 53, 170, 53, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 65, 192, 65, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 71, 192, 71, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 82, 27, 90, false);
                    NewField64.Name = "NewField64";
                    NewField64.MultiLine = EvetHayirEnum.ehEvet;
                    NewField64.NoClip = EvetHayirEnum.ehEvet;
                    NewField64.WordBreak = EvetHayirEnum.ehEvet;
                    NewField64.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField64.TextFont.Name = "Arial Narrow";
                    NewField64.TextFont.Size = 8;
                    NewField64.TextFont.Bold = true;
                    NewField64.Value = @"EMİR TARİHİ VE NO.SU";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 86, 81, 90, false);
                    NewField44.Name = "NewField44";
                    NewField44.NoClip = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.TextFont.Size = 8;
                    NewField44.TextFont.Bold = true;
                    NewField44.Value = @"BOY";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 86, 104, 90, false);
                    NewField45.Name = "NewField45";
                    NewField45.NoClip = EvetHayirEnum.ehEvet;
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.TextFont.Size = 8;
                    NewField45.TextFont.Bold = true;
                    NewField45.Value = @"KİLO";

                    NewField49 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 92, 27, 100, false);
                    NewField49.Name = "NewField49";
                    NewField49.MultiLine = EvetHayirEnum.ehEvet;
                    NewField49.NoClip = EvetHayirEnum.ehEvet;
                    NewField49.WordBreak = EvetHayirEnum.ehEvet;
                    NewField49.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField49.TextFont.Name = "Arial Narrow";
                    NewField49.TextFont.Size = 8;
                    NewField49.TextFont.Bold = true;
                    NewField49.Value = @"NE MAKSATLA MUAY. EDİLDİĞİ";

                    NewField94 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 82, 142, 90, false);
                    NewField94.Name = "NewField94";
                    NewField94.MultiLine = EvetHayirEnum.ehEvet;
                    NewField94.NoClip = EvetHayirEnum.ehEvet;
                    NewField94.WordBreak = EvetHayirEnum.ehEvet;
                    NewField94.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField94.TextFont.Name = "Arial Narrow";
                    NewField94.TextFont.Size = 8;
                    NewField94.TextFont.Bold = true;
                    NewField94.Value = @"SAĞ.CÜZ.GÖRE KAÇ. MUAYENESİ";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 82, 81, 82, 91, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 105, 81, 105, 91, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 95, 32, 95, 101, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    EMIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 83, 71, 90, false);
                    EMIR.Name = "EMIR";
                    EMIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIR.MultiLine = EvetHayirEnum.ehEvet;
                    EMIR.NoClip = EvetHayirEnum.ehEvet;
                    EMIR.WordBreak = EvetHayirEnum.ehEvet;
                    EMIR.ExpandTabs = EvetHayirEnum.ehEvet;
                    EMIR.TextFont.Name = "Arial Narrow";
                    EMIR.TextFont.Size = 8;
                    EMIR.Value = @"{%DOCNUMBER%}-{%DOCDATE%}";

                    MAKSAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 92, 71, 99, false);
                    MAKSAT.Name = "MAKSAT";
                    MAKSAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKSAT.MultiLine = EvetHayirEnum.ehEvet;
                    MAKSAT.NoClip = EvetHayirEnum.ehEvet;
                    MAKSAT.WordBreak = EvetHayirEnum.ehEvet;
                    MAKSAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAKSAT.TextFont.Name = "Arial Narrow";
                    MAKSAT.TextFont.Size = 8;
                    MAKSAT.Value = @"{#MAKSAT#}";

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 118, 81, 118, 91, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    MUAYENESAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 86, 163, 90, false);
                    MUAYENESAYI.Name = "MUAYENESAYI";
                    MUAYENESAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENESAYI.NoClip = EvetHayirEnum.ehEvet;
                    MUAYENESAYI.TextFont.Name = "Arial Narrow";
                    MUAYENESAYI.TextFont.Size = 8;
                    MUAYENESAYI.Value = @"{#KACINCIMUAYENESI#}";

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 101, 192, 101, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 81, 144, 91, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 86, 114, 90, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.NoClip = EvetHayirEnum.ehEvet;
                    KILO.TextFont.Name = "Arial Narrow";
                    KILO.TextFont.Size = 8;
                    KILO.Value = @"{#KILO#}";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 86, 91, 90, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.NoClip = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 8;
                    BOY.Value = @"{#BOY#}";

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 32, 4, 101, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 42, 71, 46, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"Short Date";
                    RAPORTARIH.TextFont.Name = "Arial Narrow";
                    RAPORTARIH.TextFont.Size = 8;
                    RAPORTARIH.Value = @"{#RAPORTARIHI#}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 18, 235, 23, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 23, 235, 28, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    DOCNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 28, 235, 33, false);
                    DOCNUMBER.Name = "DOCNUMBER";
                    DOCNUMBER.Visible = EvetHayirEnum.ehHayir;
                    DOCNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCNUMBER.Value = @"{#EVRAKNO#}";

                    DOCDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 33, 235, 38, false);
                    DOCDATE.Name = "DOCDATE";
                    DOCDATE.Visible = EvetHayirEnum.ehHayir;
                    DOCDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCDATE.Value = @"{#EVRAKTARIHI#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 45, 227, 49, false);
                    AD.Name = "AD";
                    AD.Visible = EvetHayirEnum.ehHayir;
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.MultiLine = EvetHayirEnum.ehEvet;
                    AD.NoClip = EvetHayirEnum.ehEvet;
                    AD.WordBreak = EvetHayirEnum.ehEvet;
                    AD.ExpandTabs = EvetHayirEnum.ehEvet;
                    AD.ObjectDefName = "Patient";
                    AD.DataMember = "NAME";
                    AD.TextFont.Name = "Arial Narrow";
                    AD.TextFont.Size = 8;
                    AD.Value = @"{#PATIENTID#}";

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 42, 227, 46, false);
                    SOYAD.Name = "SOYAD";
                    SOYAD.Visible = EvetHayirEnum.ehHayir;
                    SOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    SOYAD.NoClip = EvetHayirEnum.ehEvet;
                    SOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    SOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    SOYAD.ObjectDefName = "Patient";
                    SOYAD.DataMember = "SURNAME";
                    SOYAD.TextFont.Name = "Arial Narrow";
                    SOYAD.TextFont.Size = 8;
                    SOYAD.Value = @"{#PATIENTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    RAPOR.CalcValue = RAPOR.Value;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    XXXXXXBASLIK.CalcValue = MyParentReport.TANI.SITENAME.CalcValue + @"
" + MyParentReport.TANI.SITECITY.CalcValue;
                    AD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    AD.PostFieldValueCalculation();
                    SOYAD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    SOYAD.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = MyParentReport.TANI.AD.CalcValue + @" " + MyParentReport.TANI.SOYAD.CalcValue;
                    NewField14.CalcValue = NewField14.Value;
                    SNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Skno) : "");
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    NewField144.CalcValue = NewField144.Value;
                    ACTIONID.CalcValue = @"";
                    NewField41.CalcValue = NewField41.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField46.CalcValue = NewField46.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField48.CalcValue = NewField48.Value;
                    NewField52.CalcValue = NewField52.Value;
                    NewField62.CalcValue = NewField62.Value;
                    MAKAM.CalcValue = @"";
                    GIRIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hgiristarihi) : "");
                    CIKIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hcikistarihi) : "");
                    KNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Karantinano) : "");
                    SERVIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Bolumid) : "");
                    SERVIS.PostFieldValueCalculation();
                    NewField51.CalcValue = NewField51.Value;
                    BABAADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    BABAADI.PostFieldValueCalculation();
                    NewField53.CalcValue = NewField53.Value;
                    NewField43.CalcValue = NewField43.Value;
                    NewField34.CalcValue = NewField34.Value;
                    NewField64.CalcValue = NewField64.Value;
                    NewField44.CalcValue = NewField44.Value;
                    NewField45.CalcValue = NewField45.Value;
                    NewField49.CalcValue = NewField49.Value;
                    NewField94.CalcValue = NewField94.Value;
                    DOCNUMBER.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Evrakno) : "");
                    DOCDATE.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Evraktarihi) : "");
                    EMIR.CalcValue = MyParentReport.TANI.DOCNUMBER.CalcValue + @"-" + MyParentReport.TANI.DOCDATE.CalcValue;
                    MAKSAT.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Maksat) : "");
                    MUAYENESAYI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Kacincimuayenesi) : "");
                    KILO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Kilo) : "");
                    BOY.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Boy) : "");
                    RAPORTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    return new TTReportObject[] { RAPOR,SITENAME,SITECITY,XXXXXXBASLIK,AD,SOYAD,ADISOYADI,NewField14,SNO,RAPORNO,NewField144,ACTIONID,NewField41,NewField24,NewField25,NewField46,NewField15,NewField26,NewField48,NewField52,NewField62,MAKAM,GIRIS,CIKIS,KNO,SERVIS,NewField51,BABAADI,NewField53,NewField43,NewField34,NewField64,NewField44,NewField45,NewField49,NewField94,DOCNUMBER,DOCDATE,EMIR,MAKSAT,MUAYENESAYI,KILO,BOY,RAPORTARIH};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    /* TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCRegularThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcwts = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
            
            if(hcwts == null)
                throw new Exception("Rapor Sağlık Kurulu Üç İmza işlemi üzerinden alınmalıdır.\r\nReason:HealthCommitteeWithThreeSpecialist  is null");
            
            MilitaryClassDefinitions pMilClass = hcwts.Episode.MyMilitaryClass();
            RankDefinitions pRank = hcwts.Episode.MyRank();
            this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
            
            MilitaryUnit pSenderChair = hcwts.Episode.MySenderChair();
            this.MAKAM.CalcValue = pSenderChair == null ? "" : pSenderChair.Name;
            
            MilitaryUnit pUnit = hcwts.Episode.MyMilitaryUnit();
            this.BIRLIK.CalcValue = pUnit == null ? "" : pUnit.Name;
            
            this.SICILNO.CalcValue = hcwts.Episode.MyEmploymentRecordID();
            
            MilitaryOffice pMilOffice = hcwts.Episode.MyMilitaryOffice();
            this.BAGLISUBE.CalcValue = pMilOffice == null ? "" : pMilOffice.Name;*/
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField344;
                public TTReportField NewField446;
                public TTReportField NewField54;
                public TTReportField UZ;
                public TTReportField DIPLOMASICIL;
                public TTReportField ADSOYADDOC;
                public TTReportField SINRUT;
                public TTReportField EKYAZI1;
                public TTReportField EKYAZI2; 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 71;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 43, 45, 48, false);
                    NewField2.Name = "NewField2";
                    NewField2.NoClip = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.Underline = true;
                    NewField2.Value = @"DÜZENLEYEN TABİP";

                    NewField344 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 43, 80, 48, false);
                    NewField344.Name = "NewField344";
                    NewField344.NoClip = EvetHayirEnum.ehEvet;
                    NewField344.TextFont.Name = "Arial Narrow";
                    NewField344.TextFont.Bold = true;
                    NewField344.TextFont.Underline = true;
                    NewField344.Value = @"İMZA";

                    NewField446 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 43, 142, 48, false);
                    NewField446.Name = "NewField446";
                    NewField446.NoClip = EvetHayirEnum.ehEvet;
                    NewField446.TextFont.Name = "Arial Narrow";
                    NewField446.TextFont.Bold = true;
                    NewField446.TextFont.Underline = true;
                    NewField446.Value = @"İMZA";

                    NewField54 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 65, 115, 70, false);
                    NewField54.Name = "NewField54";
                    NewField54.NoClip = EvetHayirEnum.ehEvet;
                    NewField54.TextFont.Name = "Arial Narrow";
                    NewField54.TextFont.Bold = true;
                    NewField54.TextFont.Underline = true;
                    NewField54.Value = @"ONAY";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 60, 66, 64, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 8;
                    UZ.Value = @"";

                    DIPLOMASICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 56, 66, 60, false);
                    DIPLOMASICIL.Name = "DIPLOMASICIL";
                    DIPLOMASICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMASICIL.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMASICIL.TextFont.Name = "Arial Narrow";
                    DIPLOMASICIL.TextFont.Size = 8;
                    DIPLOMASICIL.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 48, 66, 52, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 52, 66, 56, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.NoClip = EvetHayirEnum.ehEvet;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 8;
                    SINRUT.Value = @"";

                    EKYAZI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 25, 182, 33, false);
                    EKYAZI1.Name = "EKYAZI1";
                    EKYAZI1.Visible = EvetHayirEnum.ehHayir;
                    EKYAZI1.MultiLine = EvetHayirEnum.ehEvet;
                    EKYAZI1.NoClip = EvetHayirEnum.ehEvet;
                    EKYAZI1.WordBreak = EvetHayirEnum.ehEvet;
                    EKYAZI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    EKYAZI1.Value = @"1. BU RAPOR XXXXXX AKADEMİ KURULUNUN 24.11.1992 GÜN VE 19 SAYILI OTURUMUNDA ALINAN KARAR GEREĞİNCE HEYET RAPORU YERİNE GEÇERLİDİR.                    ";

                    EKYAZI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 34, 182, 42, false);
                    EKYAZI2.Name = "EKYAZI2";
                    EKYAZI2.Visible = EvetHayirEnum.ehHayir;
                    EKYAZI2.MultiLine = EvetHayirEnum.ehEvet;
                    EKYAZI2.NoClip = EvetHayirEnum.ehEvet;
                    EKYAZI2.WordBreak = EvetHayirEnum.ehEvet;
                    EKYAZI2.ExpandTabs = EvetHayirEnum.ehEvet;
                    EKYAZI2.Value = @"2. KURUMLARINCA ÖDEME YAPILABİLMESİ İÇİN İLAÇ VE MALZEME KULLANILDI BELGESİNİN EKLENMESİ ZORUNLUDUR.                ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField344.CalcValue = NewField344.Value;
                    NewField446.CalcValue = NewField446.Value;
                    NewField54.CalcValue = NewField54.Value;
                    UZ.CalcValue = @"";
                    DIPLOMASICIL.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    EKYAZI1.CalcValue = EKYAZI1.Value;
                    EKYAZI2.CalcValue = EKYAZI2.Value;
                    return new TTReportObject[] { NewField2,NewField344,NewField446,NewField54,UZ,DIPLOMASICIL,ADSOYADDOC,SINRUT,EKYAZI1,EKYAZI2};
                }

                public override void RunScript()
                {
#region TANI FOOTER_Script
                    string sObjectID = ((HCRegularThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BindingList<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class> pSpecialists = null;
            pSpecialists = HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent(sObjectID);
            
            if(pSpecialists.Count > 0)
            {
                foreach(HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class pGrid in pSpecialists)
                {
                    this.ADSOYADDOC.CalcValue = pGrid.Uzmanadi1;
                    this.SINRUT.CalcValue = pGrid.Sinif1 + " " + pGrid.Rutbe1;
                    this.DIPLOMASICIL.CalcValue = pGrid.Sicil1;
                    this.UZ.CalcValue = pGrid.Unvan1.ToString();
                    
                    break;//bu yapı değişebilir tek bir satır gelmeli, bu yanlış...YY
                }
            }
#endregion TANI FOOTER_Script
                }
            }

        }

        public TANIGroup TANI;

        public partial class TANILARGroup : TTReportGroup
        {
            public HCRegularThreeSpecialistReport MyParentReport
            {
                get { return (HCRegularThreeSpecialistReport)ParentReport; }
            }

            new public TANILARGroupHeader Header()
            {
                return (TANILARGroupHeader)_header;
            }

            new public TANILARGroupFooter Footer()
            {
                return (TANILARGroupFooter)_footer;
            }

            public TTReportField NewField74 { get {return Header().NewField74;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine456 { get {return Header().NewLine456;} }
            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField CODE { get {return Header().CODE;} }
            public TTReportField DIAGNOSENAME { get {return Header().DIAGNOSENAME;} }
            public TANILARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANILARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class>("GetPreDiagnosisByEpisodeAction2", DiagnosisGrid.GetPreDiagnosisByEpisodeAction((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANILARGroupHeader(this);
                _footer = new TANILARGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANILARGroupHeader : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField74;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine456;
                public TTReportField TANI;
                public TTReportField CODE;
                public TTReportField DIAGNOSENAME; 
                public TANILARGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 15, 5, false);
                    NewField74.Name = "NewField74";
                    NewField74.NoClip = EvetHayirEnum.ehEvet;
                    NewField74.TextFont.Name = "Arial Narrow";
                    NewField74.TextFont.Size = 9;
                    NewField74.TextFont.Bold = true;
                    NewField74.Value = @"TANI   :";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 4, 8, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 192, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine456 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 192, 0, 192, 8, false);
                    NewLine456.Name = "NewLine456";
                    NewLine456.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine456.ExtendTo = ExtendToEnum.extSectionHeight;

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 191, 6, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"{%CODE%} {%DIAGNOSENAME%}";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 2, 236, 7, false);
                    CODE.Name = "CODE";
                    CODE.Visible = EvetHayirEnum.ehHayir;
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.Value = @"{#CODE#}";

                    DIAGNOSENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 2, 265, 7, false);
                    DIAGNOSENAME.Name = "DIAGNOSENAME";
                    DIAGNOSENAME.Visible = EvetHayirEnum.ehHayir;
                    DIAGNOSENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSENAME.Value = @"{#DIAGNOSENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class dataset_GetPreDiagnosisByEpisodeAction2 = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class>(0);
                    NewField74.CalcValue = NewField74.Value;
                    CODE.CalcValue = (dataset_GetPreDiagnosisByEpisodeAction2 != null ? Globals.ToStringCore(dataset_GetPreDiagnosisByEpisodeAction2.Code) : "");
                    DIAGNOSENAME.CalcValue = (dataset_GetPreDiagnosisByEpisodeAction2 != null ? Globals.ToStringCore(dataset_GetPreDiagnosisByEpisodeAction2.Diagnosename) : "");
                    TANI.CalcValue = MyParentReport.TANILAR.CODE.CalcValue + @" " + MyParentReport.TANILAR.DIAGNOSENAME.CalcValue;
                    return new TTReportObject[] { NewField74,CODE,DIAGNOSENAME,TANI};
                }
            }
            public partial class TANILARGroupFooter : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                 
                public TANILARGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TANILARGroup TANILAR;

        public partial class RAPORGroup : TTReportGroup
        {
            public HCRegularThreeSpecialistReport MyParentReport
            {
                get { return (HCRegularThreeSpecialistReport)ParentReport; }
            }

            new public RAPORGroupHeader Header()
            {
                return (RAPORGroupHeader)_header;
            }

            new public RAPORGroupFooter Footer()
            {
                return (RAPORGroupFooter)_footer;
            }

            public TTReportField NewField47 { get {return Header().NewField47;} }
            public TTReportShape DNewLine11 { get {return Header().DNewLine11;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine42 { get {return Header().NewLine42;} }
            public TTReportField RAPOR { get {return Header().RAPOR;} }
            public RAPORGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RAPORGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[0];
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new RAPORGroupHeader(this);
                _footer = new RAPORGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class RAPORGroupHeader : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField47;
                public TTReportShape DNewLine11;
                public TTReportShape NewLine;
                public TTReportShape NewLine42;
                public TTReportField RAPOR; 
                public RAPORGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField47 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 15, 5, false);
                    NewField47.Name = "NewField47";
                    NewField47.NoClip = EvetHayirEnum.ehEvet;
                    NewField47.TextFont.Name = "Arial Narrow";
                    NewField47.TextFont.Size = 9;
                    NewField47.TextFont.Bold = true;
                    NewField47.Value = @"RAPOR :";

                    DNewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 192, 0, false);
                    DNewLine11.Name = "DNewLine11";
                    DNewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 4, 9, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine42 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 192, 0, 192, 8, false);
                    NewLine42.Name = "NewLine42";
                    NewLine42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine42.ExtendTo = ExtendToEnum.extSectionHeight;

                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 191, 6, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    RAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    RAPOR.NoClip = EvetHayirEnum.ehEvet;
                    RAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    RAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPOR.TextFont.Name = "Arial Narrow";
                    RAPOR.TextFont.Size = 8;
                    RAPOR.Value = @"{#TANI.RAPOR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = MyParentReport.TANI.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    NewField47.CalcValue = NewField47.Value;
                    RAPOR.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Rapor) : "");
                    return new TTReportObject[] { NewField47,RAPOR};
                }
            }
            public partial class RAPORGroupFooter : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                 
                public RAPORGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public RAPORGroup RAPOR;

        public partial class KARARGroup : TTReportGroup
        {
            public HCRegularThreeSpecialistReport MyParentReport
            {
                get { return (HCRegularThreeSpecialistReport)ParentReport; }
            }

            new public KARARGroupHeader Header()
            {
                return (KARARGroupHeader)_header;
            }

            new public KARARGroupFooter Footer()
            {
                return (KARARGroupFooter)_footer;
            }

            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportShape WNewLine2 { get {return Header().WNewLine2;} }
            public TTReportShape NewLine567 { get {return Header().NewLine567;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportField KARAR { get {return Header().KARAR;} }
            public TTReportShape NewLine788 { get {return Footer().NewLine788;} }
            public KARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[0];
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KARARGroupHeader(this);
                _footer = new KARARGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class KARARGroupHeader : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportShape WNewLine2;
                public TTReportShape NewLine567;
                public TTReportShape NewLine;
                public TTReportField KARAR; 
                public KARARGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 15, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.NoClip = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"KARAR :";

                    WNewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 192, 0, false);
                    WNewLine2.Name = "WNewLine2";
                    WNewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine567 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 192, 0, 192, 8, false);
                    NewLine567.Name = "NewLine567";
                    NewLine567.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine567.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 4, 8, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.ExtendTo = ExtendToEnum.extSectionHeight;

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 191, 6, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial Narrow";
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"{#TANI.KARAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = MyParentReport.TANI.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    KARAR.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Karar) : "");
                    return new TTReportObject[] { NewField12,KARAR};
                }
            }
            public partial class KARARGroupFooter : TTReportSection
            {
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportShape NewLine788; 
                public KARARGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                    NewLine788 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 0, 192, 0, false);
                    NewLine788.Name = "NewLine788";
                    NewLine788.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public KARARGroup KARAR;

        public partial class MAINGroup : TTReportGroup
        {
            public HCRegularThreeSpecialistReport MyParentReport
            {
                get { return (HCRegularThreeSpecialistReport)ParentReport; }
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
                public HCRegularThreeSpecialistReport MyParentReport
                {
                    get { return (HCRegularThreeSpecialistReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
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

        public HCRegularThreeSpecialistReport()
        {
            TANI = new TANIGroup(this,"TANI");
            TANILAR = new TANILARGroup(TANI,"TANILAR");
            RAPOR = new RAPORGroup(TANILAR,"RAPOR");
            KARAR = new KARARGroup(RAPOR,"KARAR");
            MAIN = new MAINGroup(KARAR,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "35E0EB8B-B386-44BB-A25E-AC95ED7C9F2C", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCREGULARTHREESPECIALISTREPORT";
            Caption = "Sağlık Kurulu Muvazzaf Üç İmza Raporu";
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