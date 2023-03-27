
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
    /// Sağlık Kurulu Emekli Üç İmza Raporu
    /// </summary>
    public partial class HCRetiredThreeSpecialistReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HCRetiredThreeSpecialistReport MyParentReport
            {
                get { return (HCRetiredThreeSpecialistReport)ParentReport; }
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
            public TTReportField NewFieldo141 { get {return Header().NewFieldo141;} }
            public TTReportField SKRAPORTARIH { get {return Header().SKRAPORTARIH;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField ACTIONID1 { get {return Header().ACTIONID1;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField124 { get {return Header().NewField124;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportShape NewLine19 { get {return Header().NewLine19;} }
            public TTReportShape NewLine101 { get {return Header().NewLine101;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField164 { get {return Header().NewField164;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField LABELMAKAM1 { get {return Header().LABELMAKAM1;} }
            public TTReportField NewField184 { get {return Header().NewField184;} }
            public TTReportField NewField125 { get {return Header().NewField125;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField MAKAMKURUM { get {return Header().MAKAMKURUM;} }
            public TTReportField GIRIS { get {return Header().GIRIS;} }
            public TTReportField CIKIS { get {return Header().CIKIS;} }
            public TTReportField KNO { get {return Header().KNO;} }
            public TTReportField SERVIS { get {return Header().SERVIS;} }
            public TTReportField PID13 { get {return Header().PID13;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLined123 { get {return Header().NewLined123;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField DOCNUMBER { get {return Header().DOCNUMBER;} }
            public TTReportField DOCDATE { get {return Header().DOCDATE;} }
            public TTReportField AD { get {return Header().AD;} }
            public TTReportField SOYAD { get {return Header().SOYAD;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField1243 { get {return Footer().NewField1243;} }
            public TTReportField NewField1244 { get {return Footer().NewField1244;} }
            public TTReportField NewField145 { get {return Footer().NewField145;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField EKYAZI11 { get {return Footer().EKYAZI11;} }
            public TTReportField EKYAZI12 { get {return Footer().EKYAZI12;} }
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
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField RAPOR;
                public TTReportField XXXXXXBASLIK;
                public TTReportField ADISOYADI;
                public TTReportField NewFieldo141;
                public TTReportField SKRAPORTARIH;
                public TTReportField RAPORNO;
                public TTReportField NewField141;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportField ACTIONID1;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportField NewField114;
                public TTReportField NewField124;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportShape NewLine19;
                public TTReportShape NewLine101;
                public TTReportShape NewLine111;
                public TTReportField NewField164;
                public TTReportField NewField151;
                public TTReportField LABELMAKAM1;
                public TTReportField NewField184;
                public TTReportField NewField125;
                public TTReportField NewField26;
                public TTReportShape NewLine121;
                public TTReportField MAKAMKURUM;
                public TTReportField GIRIS;
                public TTReportField CIKIS;
                public TTReportField KNO;
                public TTReportField SERVIS;
                public TTReportField PID13;
                public TTReportShape NewLine131;
                public TTReportShape NewLined123;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField DOCNUMBER;
                public TTReportField DOCDATE;
                public TTReportField AD;
                public TTReportField SOYAD; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 81;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 35, 200, 40, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR.NoClip = EvetHayirEnum.ehEvet;
                    RAPOR.TextFont.Name = "Arial Narrow";
                    RAPOR.TextFont.Size = 11;
                    RAPOR.TextFont.Bold = true;
                    RAPOR.Value = @"RAPOR (EMEKLİ VE SİVİL SEVKLİ)";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 10, 200, 35, false);
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

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 42, 159, 46, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial Narrow";
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{%AD%} {%SOYAD%}";

                    NewFieldo141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 48, 35, 52, false);
                    NewFieldo141.Name = "NewFieldo141";
                    NewFieldo141.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldo141.TextFont.Name = "Arial Narrow";
                    NewFieldo141.TextFont.Size = 8;
                    NewFieldo141.TextFont.Bold = true;
                    NewFieldo141.Value = @"RAPOR NU   ";

                    SKRAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 54, 71, 58, false);
                    SKRAPORTARIH.Name = "SKRAPORTARIH";
                    SKRAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKRAPORTARIH.TextFormat = @"Short Date";
                    SKRAPORTARIH.NoClip = EvetHayirEnum.ehEvet;
                    SKRAPORTARIH.TextFont.Name = "Arial Narrow";
                    SKRAPORTARIH.TextFont.Size = 8;
                    SKRAPORTARIH.Value = @"{#RAPORTARIHI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 48, 71, 52, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.NoClip = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 54, 35, 58, false);
                    NewField141.Name = "NewField141";
                    NewField141.NoClip = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @"SAĞ.KRL.RAP.TAR.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 77, 200, 77, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 41, 200, 41, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 41, 11, 77, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    ACTIONID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 233, 199, 238, false);
                    ACTIONID1.Name = "ACTIONID1";
                    ACTIONID1.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTIONID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID1.TextColor = System.Drawing.Color.White;
                    ACTIONID1.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONID1.TextFont.Name = "Arial Narrow";
                    ACTIONID1.TextFont.Size = 8;
                    ACTIONID1.Value = @"";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 47, 173, 47, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 53, 72, 53, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 59, 72, 59, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 65, 173, 65, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 71, 200, 71, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 42, 34, 46, false);
                    NewField114.Name = "NewField114";
                    NewField114.NoClip = EvetHayirEnum.ehEvet;
                    NewField114.TextFont.Name = "Arial Narrow";
                    NewField114.TextFont.Size = 8;
                    NewField114.TextFont.Bold = true;
                    NewField114.Value = @"SERVİS";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 60, 35, 64, false);
                    NewField124.Name = "NewField124";
                    NewField124.NoClip = EvetHayirEnum.ehEvet;
                    NewField124.TextFont.Name = "Arial Narrow";
                    NewField124.TextFont.Size = 8;
                    NewField124.TextFont.Bold = true;
                    NewField124.Value = @"SAĞ.KRL.RAP.NU";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 66, 35, 70, false);
                    NewField142.Name = "NewField142";
                    NewField142.NoClip = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.Size = 8;
                    NewField142.TextFont.Bold = true;
                    NewField142.Value = @"XXXXXXYE GİRİŞ";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 72, 35, 76, false);
                    NewField152.Name = "NewField152";
                    NewField152.NoClip = EvetHayirEnum.ehEvet;
                    NewField152.TextFont.Name = "Arial Narrow";
                    NewField152.TextFont.Size = 8;
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @"KARANTİNA NU";

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 35, 41, 35, 77, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine101 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 41, 72, 77, false);
                    NewLine101.Name = "NewLine101";
                    NewLine101.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 173, 41, 173, 71, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 48, 97, 56, false);
                    NewField164.Name = "NewField164";
                    NewField164.MultiLine = EvetHayirEnum.ehEvet;
                    NewField164.NoClip = EvetHayirEnum.ehEvet;
                    NewField164.WordBreak = EvetHayirEnum.ehEvet;
                    NewField164.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField164.TextFont.Name = "Arial Narrow";
                    NewField164.TextFont.Size = 8;
                    NewField164.TextFont.Bold = true;
                    NewField164.Value = @"DOĞUM YERİ VE TARİHİ ";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 42, 97, 46, false);
                    NewField151.Name = "NewField151";
                    NewField151.NoClip = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Name = "Arial Narrow";
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @"ADI SOYADI";

                    LABELMAKAM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 60, 97, 64, false);
                    LABELMAKAM1.Name = "LABELMAKAM1";
                    LABELMAKAM1.NoClip = EvetHayirEnum.ehEvet;
                    LABELMAKAM1.TextFont.Name = "Arial Narrow";
                    LABELMAKAM1.TextFont.Size = 8;
                    LABELMAKAM1.TextFont.Bold = true;
                    LABELMAKAM1.Value = @"GÖNDEREN MAKAM";

                    NewField184 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 66, 97, 70, false);
                    NewField184.Name = "NewField184";
                    NewField184.NoClip = EvetHayirEnum.ehEvet;
                    NewField184.TextFont.Name = "Arial Narrow";
                    NewField184.TextFont.Size = 8;
                    NewField184.TextFont.Bold = true;
                    NewField184.Value = @"XXXXXXDEN ÇIKIŞ";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 72, 97, 76, false);
                    NewField125.Name = "NewField125";
                    NewField125.NoClip = EvetHayirEnum.ehEvet;
                    NewField125.TextFont.Name = "Arial Narrow";
                    NewField125.TextFont.Size = 8;
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @"ADRESİ";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 50, 193, 54, false);
                    NewField26.Name = "NewField26";
                    NewField26.NoClip = EvetHayirEnum.ehEvet;
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 8;
                    NewField26.Value = @"FOTOĞRAF";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 41, 98, 77, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    MAKAMKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 58, 172, 64, false);
                    MAKAMKURUM.Name = "MAKAMKURUM";
                    MAKAMKURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAMKURUM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MAKAMKURUM.NoClip = EvetHayirEnum.ehEvet;
                    MAKAMKURUM.TextFont.Name = "Arial Narrow";
                    MAKAMKURUM.TextFont.Size = 8;
                    MAKAMKURUM.Value = @"";

                    GIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 66, 71, 70, false);
                    GIRIS.Name = "GIRIS";
                    GIRIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIRIS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    GIRIS.TextFormat = @"Short Date";
                    GIRIS.NoClip = EvetHayirEnum.ehEvet;
                    GIRIS.TextFont.Name = "Arial Narrow";
                    GIRIS.TextFont.Size = 8;
                    GIRIS.Value = @"{#HGIRISTARIHI#}";

                    CIKIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 66, 172, 70, false);
                    CIKIS.Name = "CIKIS";
                    CIKIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKIS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CIKIS.TextFormat = @"DD/MM/YYYY";
                    CIKIS.NoClip = EvetHayirEnum.ehEvet;
                    CIKIS.TextFont.Name = "Arial Narrow";
                    CIKIS.TextFont.Size = 8;
                    CIKIS.Value = @"{#HCIKISTARIHI#}";

                    KNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 72, 71, 76, false);
                    KNO.Name = "KNO";
                    KNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KNO.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KNO.NoClip = EvetHayirEnum.ehEvet;
                    KNO.TextFont.Name = "Arial Narrow";
                    KNO.TextFont.Size = 8;
                    KNO.Value = @"{#KARANTINANO#}";

                    SERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 42, 71, 46, false);
                    SERVIS.Name = "SERVIS";
                    SERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SERVIS.NoClip = EvetHayirEnum.ehEvet;
                    SERVIS.ObjectDefName = "Resource";
                    SERVIS.DataMember = "NAME";
                    SERVIS.TextFont.Name = "Arial Narrow";
                    SERVIS.TextFont.Size = 8;
                    SERVIS.Value = @"{#BOLUMID#}";

                    PID13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 35, 151, 40, false);
                    PID13.Name = "PID13";
                    PID13.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID13.MultiLine = EvetHayirEnum.ehEvet;
                    PID13.NoClip = EvetHayirEnum.ehEvet;
                    PID13.WordBreak = EvetHayirEnum.ehEvet;
                    PID13.ExpandTabs = EvetHayirEnum.ehEvet;
                    PID13.ObjectDefName = "Patient";
                    PID13.DataMember = "ID";
                    PID13.TextFont.Name = "Arial Narrow";
                    PID13.TextFont.Size = 11;
                    PID13.TextFont.Bold = true;
                    PID13.Value = @"{#PATIENTID#}";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 57, 173, 57, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLined123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 41, 200, 77, false);
                    NewLined123.Name = "NewLined123";
                    NewLined123.DrawStyle = DrawStyleConstants.vbSolid;

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 24, 245, 29, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 29, 245, 34, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    DOCNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 34, 245, 39, false);
                    DOCNUMBER.Name = "DOCNUMBER";
                    DOCNUMBER.Visible = EvetHayirEnum.ehHayir;
                    DOCNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCNUMBER.Value = @"{#EVRAKNO#}";

                    DOCDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 39, 245, 44, false);
                    DOCDATE.Name = "DOCDATE";
                    DOCDATE.Visible = EvetHayirEnum.ehHayir;
                    DOCDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCDATE.Value = @"{#EVRAKTARIHI#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 51, 237, 55, false);
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

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 48, 237, 52, false);
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
                    NewFieldo141.CalcValue = NewFieldo141.Value;
                    SKRAPORTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    NewField141.CalcValue = NewField141.Value;
                    ACTIONID1.CalcValue = @"";
                    NewField114.CalcValue = NewField114.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField151.CalcValue = NewField151.Value;
                    LABELMAKAM1.CalcValue = LABELMAKAM1.Value;
                    NewField184.CalcValue = NewField184.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField26.CalcValue = NewField26.Value;
                    MAKAMKURUM.CalcValue = @"";
                    GIRIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hgiristarihi) : "");
                    CIKIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hcikistarihi) : "");
                    KNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Karantinano) : "");
                    SERVIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Bolumid) : "");
                    SERVIS.PostFieldValueCalculation();
                    PID13.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    PID13.PostFieldValueCalculation();
                    DOCNUMBER.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Evrakno) : "");
                    DOCDATE.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Evraktarihi) : "");
                    return new TTReportObject[] { RAPOR,SITENAME,SITECITY,XXXXXXBASLIK,AD,SOYAD,ADISOYADI,NewFieldo141,SKRAPORTARIH,RAPORNO,NewField141,ACTIONID1,NewField114,NewField124,NewField142,NewField152,NewField164,NewField151,LABELMAKAM1,NewField184,NewField125,NewField26,MAKAMKURUM,GIRIS,CIKIS,KNO,SERVIS,PID13,DOCNUMBER,DOCDATE};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    //                                       TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((HCRetiredThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            HealthCommitteeWithThreeSpecialist hcwts = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
//            
//            if(hcwts == null)
//                throw new Exception("Rapor Sağlık Kurulu Üç İmza işlemi üzerinden alınmalıdır.\r\nReason:HealthCommitteeWithThreeSpecialist  is null");
////            
//            MilitaryUnit pSenderChair = hcwts.Episode.MySenderChair();
//            this.MAKAMKURUM.CalcValue = pSenderChair == null ? "" : pSenderChair.Name;
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField1243;
                public TTReportField NewField1244;
                public TTReportField NewField145;
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField EKYAZI11;
                public TTReportField EKYAZI12; 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 67;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 19, 47, 24, false);
                    NewField12.Name = "NewField12";
                    NewField12.NoClip = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.Underline = true;
                    NewField12.Value = @"DÜZENLEYEN TABİP";

                    NewField1243 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 19, 82, 24, false);
                    NewField1243.Name = "NewField1243";
                    NewField1243.NoClip = EvetHayirEnum.ehEvet;
                    NewField1243.TextFont.Name = "Arial Narrow";
                    NewField1243.TextFont.Bold = true;
                    NewField1243.TextFont.Underline = true;
                    NewField1243.Value = @"İMZA";

                    NewField1244 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 19, 144, 24, false);
                    NewField1244.Name = "NewField1244";
                    NewField1244.NoClip = EvetHayirEnum.ehEvet;
                    NewField1244.TextFont.Name = "Arial Narrow";
                    NewField1244.TextFont.Bold = true;
                    NewField1244.TextFont.Underline = true;
                    NewField1244.Value = @"İMZA";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 43, 112, 48, false);
                    NewField145.Name = "NewField145";
                    NewField145.NoClip = EvetHayirEnum.ehEvet;
                    NewField145.TextFont.Name = "Arial Narrow";
                    NewField145.TextFont.Bold = true;
                    NewField145.TextFont.Underline = true;
                    NewField145.Value = @"ONAY";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 36, 68, 40, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 8;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 24, 68, 28, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.Value = @"";

                    EKYAZI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 184, 9, false);
                    EKYAZI11.Name = "EKYAZI11";
                    EKYAZI11.Visible = EvetHayirEnum.ehHayir;
                    EKYAZI11.MultiLine = EvetHayirEnum.ehEvet;
                    EKYAZI11.NoClip = EvetHayirEnum.ehEvet;
                    EKYAZI11.WordBreak = EvetHayirEnum.ehEvet;
                    EKYAZI11.ExpandTabs = EvetHayirEnum.ehEvet;
                    EKYAZI11.Value = @"1. BU RAPOR XXXXXX AKADEMİ KURULUNUN 24.11.1992 GÜN VE 19 SAYILI OTURUMUNDA ALINAN KARAR GEREĞİNCE HEYET RAPORU YERİNE GEÇERLİDİR.                    ";

                    EKYAZI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 184, 18, false);
                    EKYAZI12.Name = "EKYAZI12";
                    EKYAZI12.Visible = EvetHayirEnum.ehHayir;
                    EKYAZI12.MultiLine = EvetHayirEnum.ehEvet;
                    EKYAZI12.NoClip = EvetHayirEnum.ehEvet;
                    EKYAZI12.WordBreak = EvetHayirEnum.ehEvet;
                    EKYAZI12.ExpandTabs = EvetHayirEnum.ehEvet;
                    EKYAZI12.Value = @"2. KURUMLARINCA ÖDEME YAPILABİLMESİ İÇİN İLAÇ VE MALZEME KULLANILDI BELGESİNİN EKLENMESİ ZORUNLUDUR.                ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    NewField1243.CalcValue = NewField1243.Value;
                    NewField1244.CalcValue = NewField1244.Value;
                    NewField145.CalcValue = NewField145.Value;
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    EKYAZI11.CalcValue = EKYAZI11.Value;
                    EKYAZI12.CalcValue = EKYAZI12.Value;
                    return new TTReportObject[] { NewField12,NewField1243,NewField1244,NewField145,UZ,ADSOYADDOC,EKYAZI11,EKYAZI12};
                }

                public override void RunScript()
                {
#region TANI FOOTER_Script
                    //                             string sObjectID = ((HCRetiredThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            BindingList<HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class> pSpecialists = null;
//            pSpecialists = HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent(sObjectID);
//            
//            if(pSpecialists.Count > 0)
//            {
//                foreach(HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid.GetHCWTS_ThreeSpecialistGridByParent_Class pGrid in pSpecialists)
//                {
//                    this.ADSOYADDOC.CalcValue = pGrid.Uzmanadi1;
//                    this.SINRUT.CalcValue = pGrid.Sinif1 + " " + pGrid.Rutbe1;
//                    this.DIPLOMASICIL.CalcValue = pGrid.Sicil1;
//                    this.UZ.CalcValue = pGrid.Unvan1.ToString();
//                    
//                    break;//bu yapı değişebilir tek bir satır gelmeli, bu yanlış...YY
//                }
         //   }
#endregion TANI FOOTER_Script
                }
            }

        }

        public TANIGroup TANI;

        public partial class MDFGroup : TTReportGroup
        {
            public HCRetiredThreeSpecialistReport MyParentReport
            {
                get { return (HCRetiredThreeSpecialistReport)ParentReport; }
            }

            new public MDFGroupHeader Header()
            {
                return (MDFGroupHeader)_header;
            }

            new public MDFGroupFooter Footer()
            {
                return (MDFGroupFooter)_footer;
            }

            public TTReportField NewField157 { get {return Header().NewField157;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLineoo1 { get {return Header().NewLineoo1;} }
            public TTReportField TANI2 { get {return Header().TANI2;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public MDFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MDFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class>("GetHCWTS_MatterSliceAnectodeGridByParent", HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MDFGroupHeader(this);
                _footer = new MDFGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MDFGroupHeader : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField157;
                public TTReportShape NewLine1;
                public TTReportShape NewLineoo1;
                public TTReportField TANI2;
                public TTReportShape NewLine12; 
                public MDFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField157 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 24, 5, false);
                    NewField157.Name = "NewField157";
                    NewField157.NoClip = EvetHayirEnum.ehEvet;
                    NewField157.TextFont.Name = "Arial Narrow";
                    NewField157.TextFont.Size = 9;
                    NewField157.TextFont.Bold = true;
                    NewField157.Value = @"M/D/F    :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 0, 11, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLineoo1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 14, false);
                    NewLineoo1.Name = "NewLineoo1";
                    NewLineoo1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLineoo1.ExtendTo = ExtendToEnum.extSectionHeight;

                    TANI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 1, 198, 6, false);
                    TANI2.Name = "TANI2";
                    TANI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TANI2.MultiLine = EvetHayirEnum.ehEvet;
                    TANI2.NoClip = EvetHayirEnum.ehEvet;
                    TANI2.WordBreak = EvetHayirEnum.ehEvet;
                    TANI2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI2.TextFont.Name = "Arial Narrow";
                    TANI2.TextFont.Size = 8;
                    TANI2.Value = @"{#MATTER#}/{#SLICE#}/{#ANECTODE#}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 0, 200, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class dataset_GetHCWTS_MatterSliceAnectodeGridByParent = ParentGroup.rsGroup.GetCurrentRecord<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class>(0);
                    NewField157.CalcValue = NewField157.Value;
                    TANI2.CalcValue = (dataset_GetHCWTS_MatterSliceAnectodeGridByParent != null ? Globals.ToStringCore(dataset_GetHCWTS_MatterSliceAnectodeGridByParent.Matter) : "") + @"/" + (dataset_GetHCWTS_MatterSliceAnectodeGridByParent != null ? Globals.ToStringCore(dataset_GetHCWTS_MatterSliceAnectodeGridByParent.Slice) : "") + @"/" + (dataset_GetHCWTS_MatterSliceAnectodeGridByParent != null ? Globals.ToStringCore(dataset_GetHCWTS_MatterSliceAnectodeGridByParent.Anectode) : "");
                    return new TTReportObject[] { NewField157,TANI2};
                }
            }
            public partial class MDFGroupFooter : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                 
                public MDFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MDFGroup MDF;

        public partial class TANILARGroup : TTReportGroup
        {
            public HCRetiredThreeSpecialistReport MyParentReport
            {
                get { return (HCRetiredThreeSpecialistReport)ParentReport; }
            }

            new public TANILARGroupHeader Header()
            {
                return (TANILARGroupHeader)_header;
            }

            new public TANILARGroupFooter Footer()
            {
                return (TANILARGroupFooter)_footer;
            }

            public TTReportField NewField147 { get {return Header().NewField147;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLinet16 { get {return Header().NewLinet16;} }
            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
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
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField147;
                public TTReportShape NewLine1;
                public TTReportShape NewLinet16;
                public TTReportField TANI;
                public TTReportShape NewLine12;
                public TTReportField CODE;
                public TTReportField DIAGNOSENAME; 
                public TANILARGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField147 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 24, 5, false);
                    NewField147.Name = "NewField147";
                    NewField147.NoClip = EvetHayirEnum.ehEvet;
                    NewField147.TextFont.Name = "Arial Narrow";
                    NewField147.TextFont.Size = 9;
                    NewField147.TextFont.Bold = true;
                    NewField147.Value = @"TANI     :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, -2, 11, 30, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLinet16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -2, 200, 30, false);
                    NewLinet16.Name = "NewLinet16";
                    NewLinet16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLinet16.ExtendTo = ExtendToEnum.extSectionHeight;

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 1, 198, 6, false);
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

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 0, 200, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 3, 237, 8, false);
                    CODE.Name = "CODE";
                    CODE.Visible = EvetHayirEnum.ehHayir;
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.Value = @"{#CODE#}";

                    DIAGNOSENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 1, 269, 6, false);
                    DIAGNOSENAME.Name = "DIAGNOSENAME";
                    DIAGNOSENAME.Visible = EvetHayirEnum.ehHayir;
                    DIAGNOSENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSENAME.Value = @"{#DIAGNOSENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class dataset_GetPreDiagnosisByEpisodeAction2 = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class>(0);
                    NewField147.CalcValue = NewField147.Value;
                    CODE.CalcValue = (dataset_GetPreDiagnosisByEpisodeAction2 != null ? Globals.ToStringCore(dataset_GetPreDiagnosisByEpisodeAction2.Code) : "");
                    DIAGNOSENAME.CalcValue = (dataset_GetPreDiagnosisByEpisodeAction2 != null ? Globals.ToStringCore(dataset_GetPreDiagnosisByEpisodeAction2.Diagnosename) : "");
                    TANI.CalcValue = MyParentReport.TANILAR.CODE.CalcValue + @" " + MyParentReport.TANILAR.DIAGNOSENAME.CalcValue;
                    return new TTReportObject[] { NewField147,CODE,DIAGNOSENAME,TANI};
                }

                public override void RunScript()
                {
#region TANILAR HEADER_Script
                    //                          HealthCommitteeWithThreeSpecialist hcp = (HealthCommitteeWithThreeSpecialist)this.MyParentReport.ReportObjectContext.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString()), typeof(HealthCommitteeWithThreeSpecialist));
//            this.TANI.CalcValue = hcp.GetMyOrEpisodeDiagnosis();
#endregion TANILAR HEADER_Script
                }
            }
            public partial class TANILARGroupFooter : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                 
                public TANILARGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TANILARGroup TANILAR;

        public partial class KARARGroup : TTReportGroup
        {
            public HCRetiredThreeSpecialistReport MyParentReport
            {
                get { return (HCRetiredThreeSpecialistReport)ParentReport; }
            }

            new public KARARGroupHeader Header()
            {
                return (KARARGroupHeader)_header;
            }

            new public KARARGroupFooter Footer()
            {
                return (KARARGroupFooter)_footer;
            }

            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1112311 { get {return Header().NewLine1112311;} }
            public TTReportShape NewLinef11211 { get {return Header().NewLinef11211;} }
            public TTReportField KARAR111 { get {return Header().KARAR111;} }
            public TTReportShape NewLinef1112111 { get {return Footer().NewLinef1112111;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
            public TTReportShape NewLine12111111 { get {return Footer().NewLine12111111;} }
            public KARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new KARARGroupHeader(this);
                _footer = new KARARGroupFooter(this);

            }

            public partial class KARARGroupHeader : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1112311;
                public TTReportShape NewLinef11211;
                public TTReportField KARAR111; 
                public KARARGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 23, 6, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.NoClip = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial Narrow";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.Value = @"KARAR :";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, -1, 11, 30, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1112311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -3, 200, 21, false);
                    NewLine1112311.Name = "NewLine1112311";
                    NewLine1112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112311.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLinef11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLinef11211.Name = "NewLinef11211";
                    NewLinef11211.DrawStyle = DrawStyleConstants.vbSolid;

                    KARAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 2, 198, 7, false);
                    KARAR111.Name = "KARAR111";
                    KARAR111.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR111.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KARAR111.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR111.NoClip = EvetHayirEnum.ehEvet;
                    KARAR111.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR111.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR111.TextFont.Name = "Arial Narrow";
                    KARAR111.TextFont.Size = 8;
                    KARAR111.Value = @"{#TANI.KARAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = MyParentReport.TANI.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    NewField111211.CalcValue = NewField111211.Value;
                    KARAR111.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Karar) : "");
                    return new TTReportObject[] { NewField111211,KARAR111};
                }
            }
            public partial class KARARGroupFooter : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportShape NewLinef1112111;
                public TTReportShape NewLine1111111;
                public TTReportShape NewLine12111111; 
                public KARARGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLinef1112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 200, 3, false);
                    NewLinef1112111.Name = "NewLinef1112111";
                    NewLinef1112111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, -5, 11, 3, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -5, 200, 3, false);
                    NewLine12111111.Name = "NewLine12111111";
                    NewLine12111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12111111.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public KARARGroup KARAR;

        public partial class RAPGroup : TTReportGroup
        {
            public HCRetiredThreeSpecialistReport MyParentReport
            {
                get { return (HCRetiredThreeSpecialistReport)ParentReport; }
            }

            new public RAPGroupBody Body()
            {
                return (RAPGroupBody)_body;
            }
            public TTReportShape NewLinew111311 { get {return Body().NewLinew111311;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine11154211 { get {return Body().NewLine11154211;} }
            public TTReportRTF RAPOR { get {return Body().RAPOR;} }
            public TTReportField NewField11194111 { get {return Body().NewField11194111;} }
            public RAPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RAPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RAPGroupBody(this);
            }

            public partial class RAPGroupBody : TTReportSection
            {
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportShape NewLinew111311;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine11154211;
                public TTReportRTF RAPOR;
                public TTReportField NewField11194111; 
                public RAPGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewLinew111311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -2, 200, 25, false);
                    NewLinew111311.Name = "NewLinew111311";
                    NewLinew111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLinew111311.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, -2, 11, 25, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11154211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 200, 1, false);
                    NewLine11154211.Name = "NewLine11154211";
                    NewLine11154211.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPOR = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 26, 2, 198, 10, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.Value = @"";

                    NewField11194111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 25, 6, false);
                    NewField11194111.Name = "NewField11194111";
                    NewField11194111.NoClip = EvetHayirEnum.ehEvet;
                    NewField11194111.TextFont.Name = "Arial Narrow";
                    NewField11194111.TextFont.Size = 9;
                    NewField11194111.TextFont.Bold = true;
                    NewField11194111.Value = @"RAPOR :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RAPOR.CalcValue = RAPOR.Value;
                    NewField11194111.CalcValue = NewField11194111.Value;
                    return new TTReportObject[] { RAPOR,NewField11194111};
                }
                public override void RunPreScript()
                {
#region RAP BODY_PreScript
                    //                                                                                    
//                    TTObjectContext context = this.ParentReport.ReportObjectContext;
//         
//           string sObjectID = ((HCRetiredThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            HealthCommitteeWithThreeSpecialist healthCommitteeWithThreeSpecialist = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
//            //this.RAPOR.Value = TTObjectClasses.Common.GetRTFOfTextString(rapor);
//            if(healthCommitteeWithThreeSpecialist.Report != null)
//            {
//               
//                     this.RAPOR.Value = healthCommitteeWithThreeSpecialist.Report.ToString();
//                   
//            }
#endregion RAP BODY_PreScript
                }
            }

        }

        public RAPGroup RAP;

        public partial class MAINGroup : TTReportGroup
        {
            public HCRetiredThreeSpecialistReport MyParentReport
            {
                get { return (HCRetiredThreeSpecialistReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine11111111 { get {return Body().NewLine11111111;} }
            public TTReportShape NewLine111111121 { get {return Body().NewLine111111121;} }
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
                public HCRetiredThreeSpecialistReport MyParentReport
                {
                    get { return (HCRetiredThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111111;
                public TTReportShape NewLine111111121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, -15, 11, 5, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine111111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -15, 200, 5, false);
                    NewLine111111121.Name = "NewLine111111121";
                    NewLine111111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111121.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HCRetiredThreeSpecialistReport()
        {
            TANI = new TANIGroup(this,"TANI");
            MDF = new MDFGroup(TANI,"MDF");
            TANILAR = new TANILARGroup(MDF,"TANILAR");
            KARAR = new KARARGroup(TANILAR,"KARAR");
            RAP = new RAPGroup(KARAR,"RAP");
            MAIN = new MAINGroup(KARAR,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCRETIREDTHREESPECIALISTREPORT";
            Caption = "Sağlık Kurulu Emekli Üç İmza Raporu";
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