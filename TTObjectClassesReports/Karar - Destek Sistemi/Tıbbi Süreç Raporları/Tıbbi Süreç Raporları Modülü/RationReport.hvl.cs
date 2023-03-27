
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
    /// İstihkak İlmuhaberi
    /// </summary>
    public partial class RationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("28EB27BF-E3E8-449C-B0DF-037338707DAD");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public RationReport MyParentReport
            {
                get { return (RationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

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
                public RationReport MyParentReport
                {
                    get { return (RationReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public RationReport MyParentReport
                {
                    get { return (RationReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public RationReport MyParentReport
            {
                get { return (RationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField0 { get {return Body().NewField0;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportShape shape1 { get {return Body().shape1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField SUBE { get {return Body().SUBE;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField ONAY { get {return Body().ONAY;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField27 { get {return Body().NewField27;} }
            public TTReportField NewField28 { get {return Body().NewField28;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportField NewField39 { get {return Body().NewField39;} }
            public TTReportField BABAAD { get {return Body().BABAAD;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField MADDEKARAR { get {return Body().MADDEKARAR;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField DATEYAZI { get {return Body().DATEYAZI;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField DOGUMYERI { get {return Body().DOGUMYERI;} }
            public TTReportField DOGUMTARIHI { get {return Body().DOGUMTARIHI;} }
            public TTReportField SKFISHEADER { get {return Body().SKFISHEADER;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField ONAYTITLE { get {return Body().ONAYTITLE;} }
            public TTReportField BASTABIP { get {return Body().BASTABIP;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
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
                public RationReport MyParentReport
                {
                    get { return (RationReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField BASLIK;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField10;
                public TTReportField NewField9;
                public TTReportShape shape1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField SUBE;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NOT;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField ONAY;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportField NewField39;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField MADDEKARAR;
                public TTReportField DATE;
                public TTReportField DATEYAZI;
                public TTReportField ACTIONDATE;
                public TTReportField DOGUMYERI;
                public TTReportField DOGUMTARIHI;
                public TTReportField SKFISHEADER;
                public TTReportField RAPORTARIHI;
                public TTReportField ONAYTITLE;
                public TTReportField BASTABIP;
                public TTReportField MADDE;
                public TTReportField KARAR;
                public TTReportField DECISIONTIME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 269;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 57, 17, false);
                    NewField0.Name = "NewField0";
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.Value = @"Örnek:B-105-11
Madde:15































































































































































































































































































Madde:15";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 9, 168, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Cilt No:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 14, 168, 19, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Sıra No:";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 22, 204, 27, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İSTİHKAK İLMUHABERİ";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 41, 204, 46, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"") + "" - "" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 46, 89, 52, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.Value = @"Üzerindeki Eşyanın";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 46, 204, 52, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.Value = @"İstihkak Sahipleri ve Sayılar";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 52, 204, 58, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.Value = @"ER";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 58, 204, 93, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField8.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.Value = @"Yalnız (1) Bir Erdir.";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 52, 89, 93, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField10.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField10.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 54, 52, 59, false);
                    NewField9.Name = "NewField9";
                    NewField9.Value = @"Hastanın Kimliği:";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 58, 43, 58, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 60, 37, 65, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 9;
                    NewField12.Value = @"Adı Soyadı:";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 65, 37, 70, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 9;
                    NewField13.Value = @"Baba Adı:";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 75, 37, 80, false);
                    NewField14.Name = "NewField14";
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Size = 9;
                    NewField14.Value = @"Doğum Tarihi:";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 70, 37, 75, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Size = 9;
                    NewField15.Value = @"Doğum Yeri:";

                    SUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 93, 204, 99, false);
                    SUBE.Name = "SUBE";
                    SUBE.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    SUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBE.Value = @"Ne için nereye hangi emirle gideceği: ";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 99, 89, 157, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField17.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField17.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 104, 69, 117, false);
                    NewField18.Name = "NewField18";
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.NoClip = EvetHayirEnum.ehEvet;
                    NewField18.WordBreak = EvetHayirEnum.ehEvet;
                    NewField18.Value = @"Hangi tarihten itibaren müstehak olduğu































































































































































































































































































müstehak olduğu";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 99, 204, 157, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField19.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField19.Value = @"";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 102, 197, 112, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.NoClip = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.Value = @"{%MAIN.SKFISHEADER%}Sağlık Kurulunun {%RAPORTARIHI%} tarih ve {#RAPORNO#} sayılı raporu:";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 157, 204, 206, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.Value = @"";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 157, 89, 206, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField22.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22.Value = @"";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 161, 65, 165, false);
                    NewField23.Name = "NewField23";
                    NewField23.Value = @"Tasdik Yeri ve Tarihi";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 166, 74, 175, false);
                    NewField24.Name = "NewField24";
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.NoClip = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.Value = @"Birlik K. veya Müessese A.";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 186, 86, 191, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.Value = @"";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 166, 158, 170, false);
                    NewField26.Name = "NewField26";
                    NewField26.Value = @"Görevi:            Mal Saymanı";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 170, 124, 174, false);
                    NewField27.Name = "NewField27";
                    NewField27.Value = @"Rütbesi:";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 174, 124, 179, false);
                    NewField28.Name = "NewField28";
                    NewField28.Value = @"Adı Soyadı:";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 178, 124, 182, false);
                    NewField29.Name = "NewField29";
                    NewField29.Value = @"Sicil No:";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 182, 124, 186, false);
                    NewField30.Name = "NewField30";
                    NewField30.Value = @"İmzası:";

                    NewField39 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 166, 198, 170, false);
                    NewField39.Name = "NewField39";
                    NewField39.Value = @"Hesap Sorumlusu";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 65, 88, 70, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.Value = @"{#FATHERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 60, 88, 65, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.Value = @"{#PNAME#} {#PSURNAME#}";

                    MADDEKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 117, 197, 156, false);
                    MADDEKARAR.Name = "MADDEKARAR";
                    MADDEKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEKARAR.NoClip = EvetHayirEnum.ehEvet;
                    MADDEKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEKARAR.Value = @"";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 121, 66, 125, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.Value = @"{#RAPORTARIHI#}";

                    DATEYAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 126, 77, 135, false);
                    DATEYAZI.Name = "DATEYAZI";
                    DATEYAZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEYAZI.TextFormat = @"DATETEXT";
                    DATEYAZI.MultiLine = EvetHayirEnum.ehEvet;
                    DATEYAZI.NoClip = EvetHayirEnum.ehEvet;
                    DATEYAZI.WordBreak = EvetHayirEnum.ehEvet;
                    DATEYAZI.Value = @"{#RAPORTARIHI#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 177, 59, 183, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"Short Date";
                    ACTIONDATE.Value = @"{#ADATE#}";

                    DOGUMYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 70, 88, 75, false);
                    DOGUMYERI.Name = "DOGUMYERI";
                    DOGUMYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERI.Value = @"{#DOGUMYERI#}";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 75, 88, 80, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"Short Date";
                    DOGUMTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    DOGUMTARIHI.Value = @"{#DTARIHI#}";

                    SKFISHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 44, 240, 49, false);
                    SKFISHEADER.Name = "SKFISHEADER";
                    SKFISHEADER.Visible = EvetHayirEnum.ehHayir;
                    SKFISHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKFISHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKFISHEADER"","""")";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 53, 240, 58, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    ONAYTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 191, 86, 196, false);
                    ONAYTITLE.Name = "ONAYTITLE";
                    ONAYTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAYTITLE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ONAYTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYTITLE.Value = @"";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 196, 86, 201, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP.Value = @"BAŞTABİP";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 61, 240, 66, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 69, 240, 74, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 79, 240, 84, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.TextFont.Name = "Arial Narrow";
                    DECISIONTIME.TextFont.CharSet = 1;
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    SUBE.CalcValue = @"Ne için nereye hangi emirle gideceği: ";
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    NOT.CalcValue = MyParentReport.MAIN.SKFISHEADER.CalcValue + @"Sağlık Kurulunun " + MyParentReport.MAIN.RAPORTARIHI.FormattedValue + @" tarih ve " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "") + @" sayılı raporu:";
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    ONAY.CalcValue = @"";
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField39.CalcValue = NewField39.Value;
                    BABAAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    ADSOYAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    MADDEKARAR.CalcValue = @"";
                    DATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    DATEYAZI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    ACTIONDATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adate) : "");
                    DOGUMYERI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    DOGUMTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    ONAYTITLE.CalcValue = @"";
                    BASTABIP.CalcValue = BASTABIP.Value;
                    MADDE.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    DECISIONTIME.CalcValue = @"";
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX") + " - " + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    SKFISHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKFISHEADER","");
                    return new TTReportObject[] { NewField0,NewField1,NewField2,NewField3,NewField5,NewField6,NewField7,NewField8,NewField10,NewField9,NewField12,NewField13,NewField14,NewField15,SUBE,NewField17,NewField18,NewField19,RAPORTARIHI,NOT,NewField21,NewField22,NewField23,NewField24,ONAY,NewField26,NewField27,NewField28,NewField29,NewField30,NewField39,BABAAD,ADSOYAD,MADDEKARAR,DATE,DATEYAZI,ACTIONDATE,DOGUMYERI,DOGUMTARIHI,ONAYTITLE,BASTABIP,MADDE,KARAR,DECISIONTIME,BASLIK,SKFISHEADER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sObjectID = ((RationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext context = new TTObjectContext(true);
            HealthCommittee hcp = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if(theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Madde + "/" + theAnectode.Dilim + "/" + theAnectode.Fikra + "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]";
            }
            
            if(hcp.HealthCommitteeDecision != null )
            {
                if(hcp.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hcp.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hcp.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hcp.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hcp.HealthCommitteeDecision.ToString()) + "\r\n";
            }
            
            
            this.MADDEKARAR.CalcValue = this.MADDE.CalcValue + "\r\n" + this.KARAR.CalcValue;
            
            //Baştabip
            foreach (MemberOfHealthCommiittee member in hcp.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.ChiefOfMedicine)
                {
                    string sTitle = "";

                    if (member.MemberDoctor.Title.HasValue)
                        sTitle += TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);

                    sTitle += " " + (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);
                    this.ONAY.CalcValue = member.MemberDoctor.Name;
                    this.ONAYTITLE.CalcValue = sTitle;
                }
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

        public RationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "28EB27BF-E3E8-449C-B0DF-037338707DAD", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RATIONREPORT";
            Caption = "İstihkak İlmuhaberi";
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