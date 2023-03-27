
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
    /// Uçucu Sağlık Kurulu Ön Bildirim Belgesi
    /// </summary>
    public partial class HCPreDeclarationDocumentFlierReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("C7203EFB-0742-4709-9E32-6D3608F9C34F");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentFlierReport MyParentReport
            {
                get { return (HCPreDeclarationDocumentFlierReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public HCPreDeclarationDocumentFlierReport MyParentReport
                {
                    get { return (HCPreDeclarationDocumentFlierReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public HCPreDeclarationDocumentFlierReport MyParentReport
                {
                    get { return (HCPreDeclarationDocumentFlierReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public HCPreDeclarationDocumentFlierReport MyParentReport
            {
                get { return (HCPreDeclarationDocumentFlierReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField NewFieldA3 { get {return Body().NewFieldA3;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField EVRAKNO { get {return Body().EVRAKNO;} }
            public TTReportField RAPORSEBEP { get {return Body().RAPORSEBEP;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField ADI { get {return Body().ADI;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField NewField79 { get {return Body().NewField79;} }
            public TTReportField S5 { get {return Body().S5;} }
            public TTReportField S8 { get {return Body().S8;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField XXXXXXSEHIR { get {return Body().XXXXXXSEHIR;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField154 { get {return Body().NewField154;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField155 { get {return Body().NewField155;} }
            public TTReportField NewField111212 { get {return Body().NewField111212;} }
            public TTReportField NewField156 { get {return Body().NewField156;} }
            public TTReportField NewField111213 { get {return Body().NewField111213;} }
            public TTReportField NewField1451 { get {return Body().NewField1451;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public TTReportField NewField1651 { get {return Body().NewField1651;} }
            public TTReportField NewField1312111 { get {return Body().NewField1312111;} }
            public TTReportField NewField11541 { get {return Body().NewField11541;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField NewField157 { get {return Body().NewField157;} }
            public TTReportField NewField111214 { get {return Body().NewField111214;} }
            public TTReportField NewField1452 { get {return Body().NewField1452;} }
            public TTReportField NewField1112112 { get {return Body().NewField1112112;} }
            public TTReportField NewField1652 { get {return Body().NewField1652;} }
            public TTReportField NewField1312112 { get {return Body().NewField1312112;} }
            public TTReportField NewField11542 { get {return Body().NewField11542;} }
            public TTReportField NewField11112112 { get {return Body().NewField11112112;} }
            public TTReportField SOYADI { get {return Body().SOYADI;} }
            public TTReportField SICILNO { get {return Body().SICILNO;} }
            public TTReportField MUAYENEAMACI { get {return Body().MUAYENEAMACI;} }
            public TTReportField SKBASKANI { get {return Body().SKBASKANI;} }
            public TTReportField NewField1653 { get {return Body().NewField1653;} }
            public TTReportField NewField1312113 { get {return Body().NewField1312113;} }
            public TTReportField KUVVET { get {return Body().KUVVET;} }
            public TTReportField TCKIMLIKNOBARKOD { get {return Body().TCKIMLIKNOBARKOD;} }
            public TTReportField FOTOGRAF { get {return Body().FOTOGRAF;} }
            public TTReportField FOTOGRAF1 { get {return Body().FOTOGRAF1;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField NewField111215 { get {return Body().NewField111215;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
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
                public HCPreDeclarationDocumentFlierReport MyParentReport
                {
                    get { return (HCPreDeclarationDocumentFlierReport)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewFieldA3;
                public TTReportField NewField14;
                public TTReportField EVRAKNO;
                public TTReportField RAPORSEBEP;
                public TTReportField RAPORNO;
                public TTReportField RAPORTARIHI;
                public TTReportField TANI;
                public TTReportField ADI;
                public TTReportField BABAADI;
                public TTReportField NewField25;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField79;
                public TTReportField S5;
                public TTReportField S8;
                public TTReportField NewField6;
                public TTReportField TARIH;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField BASLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField BIRLIK;
                public TTReportField XXXXXXSEHIR;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField154;
                public TTReportField NewField111211;
                public TTReportField NewField155;
                public TTReportField NewField111212;
                public TTReportField NewField156;
                public TTReportField NewField111213;
                public TTReportField NewField1451;
                public TTReportField NewField1112111;
                public TTReportField NewField1651;
                public TTReportField NewField1312111;
                public TTReportField NewField11541;
                public TTReportField NewField11112111;
                public TTReportField NewField157;
                public TTReportField NewField111214;
                public TTReportField NewField1452;
                public TTReportField NewField1112112;
                public TTReportField NewField1652;
                public TTReportField NewField1312112;
                public TTReportField NewField11542;
                public TTReportField NewField11112112;
                public TTReportField SOYADI;
                public TTReportField SICILNO;
                public TTReportField MUAYENEAMACI;
                public TTReportField SKBASKANI;
                public TTReportField NewField1653;
                public TTReportField NewField1312113;
                public TTReportField KUVVET;
                public TTReportField TCKIMLIKNOBARKOD;
                public TTReportField FOTOGRAF;
                public TTReportField FOTOGRAF1;
                public TTReportField TCNO;
                public TTReportField NewField152;
                public TTReportField NewField111215;
                public TTReportField DECISIONTIME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 284;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 192, 201, 230, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial";
                    KARAR.Value = @"";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 21, 201, 45, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCPREDECLARATIONFLIERREPORTCAPTION"","""")";

                    NewFieldA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 53, 166, 58, false);
                    NewFieldA3.Name = "NewFieldA3";
                    NewFieldA3.TextFont.Name = "Arial";
                    NewFieldA3.Value = @"Uçucu Sağlık Kurulu Muayene Ön Raporu";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 47, 30, 51, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.Value = @"SAĞ.KRL:";

                    EVRAKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 47, 166, 52, false);
                    EVRAKNO.Name = "EVRAKNO";
                    EVRAKNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    EVRAKNO.TextFont.Name = "Arial";
                    EVRAKNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCPDFLIERREPORTDOCUMENTNUMBER"","""")";

                    RAPORSEBEP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 12, 297, 16, false);
                    RAPORSEBEP.Name = "RAPORSEBEP";
                    RAPORSEBEP.Visible = EvetHayirEnum.ehHayir;
                    RAPORSEBEP.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORSEBEP.CaseFormat = CaseFormatEnum.fcSentenceCase;
                    RAPORSEBEP.TextFont.Name = "Arial";
                    RAPORSEBEP.Value = @"";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 115, 201, 120, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    RAPORNO.TextFont.Name = "Arial";
                    RAPORNO.Value = @"{#HEADER.RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 120, 201, 125, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.TextFont.Name = "Arial";
                    RAPORTARIHI.Value = @"{#HEADER.RAPORTARIHI#}";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 125, 201, 191, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial";
                    TANI.Value = @"";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 70, 166, 75, false);
                    ADI.Name = "ADI";
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADI.TextFont.Name = "Arial";
                    ADI.Value = @"{#HEADER.PNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 91, 201, 96, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BABAADI.TextFont.Name = "Arial";
                    BABAADI.Value = @"{#HEADER.FATHERNAME#}";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 70, 44, 75, false);
                    NewField25.Name = "NewField25";
                    NewField25.TextFont.Name = "Arial";
                    NewField25.Value = @"ADI";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 42, 244, 46, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.Value = @"{#HEADER.TCNO#}";

                    NewField79 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 236, 201, 249, false);
                    NewField79.Name = "NewField79";
                    NewField79.MultiLine = EvetHayirEnum.ehEvet;
                    NewField79.NoClip = EvetHayirEnum.ehEvet;
                    NewField79.WordBreak = EvetHayirEnum.ehEvet;
                    NewField79.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField79.TextFont.Name = "Arial";
                    NewField79.TextFont.Size = 9;
                    NewField79.Value = @"Yukarıda kimliği yazılı personel hakkında Hv.Shh.Mua.Mrk.Bşk.lığının Sağlık Kurulu'nca verilen karar neticesini bildirir ön rapordur. 
Bu belge ile kesin işlem yapılamaz. Personele ait esas rapor olan ""XXXXXX Sağlık Raporu"" onay işlemleri tamamlandıktan sonra gönderilecektir.";

                    S5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 103, 451, 117, false);
                    S5.Name = "S5";
                    S5.Visible = EvetHayirEnum.ehHayir;
                    S5.FieldType = ReportFieldTypeEnum.ftVariable;
                    S5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S5.MultiLine = EvetHayirEnum.ehEvet;
                    S5.WordBreak = EvetHayirEnum.ehEvet;
                    S5.ExpandTabs = EvetHayirEnum.ehEvet;
                    S5.TextFont.Name = "Arial";
                    S5.Value = @"";

                    S8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 121, 451, 135, false);
                    S8.Name = "S8";
                    S8.Visible = EvetHayirEnum.ehHayir;
                    S8.FieldType = ReportFieldTypeEnum.ftVariable;
                    S8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    S8.MultiLine = EvetHayirEnum.ehEvet;
                    S8.WordBreak = EvetHayirEnum.ehEvet;
                    S8.ExpandTabs = EvetHayirEnum.ehEvet;
                    S8.TextFont.Name = "Arial";
                    S8.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 47, 30, 51, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial";
                    NewField6.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 47, 201, 52, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.Value = @"{@printdate@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 53, 44, 58, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.Value = @"KONU";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 47, 44, 52, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.Value = @"SAĞ.KRL.";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 25, 244, 30, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.TextFont.Name = "Arial";
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"","""")";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 80, 166, 85, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SINIFRUTBE.TextFont.Name = "Arial";
                    SINIFRUTBE.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 101, 201, 110, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.NoClip = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial";
                    BIRLIK.Value = @"";

                    XXXXXXSEHIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 33, 244, 38, false);
                    XXXXXXSEHIR.Name = "XXXXXXSEHIR";
                    XXXXXXSEHIR.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXSEHIR.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXSEHIR.TextFont.Name = "Arial";
                    XXXXXXSEHIR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"","""")";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 47, 47, 52, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 53, 47, 58, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 70, 47, 75, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.Value = @":";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 75, 44, 80, false);
                    NewField154.Name = "NewField154";
                    NewField154.TextFont.Name = "Arial";
                    NewField154.Value = @"SOYADI";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 75, 47, 80, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.Value = @":";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 110, 44, 115, false);
                    NewField155.Name = "NewField155";
                    NewField155.TextFont.Name = "Arial";
                    NewField155.Value = @"MUAYENE AMACI";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 110, 47, 115, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.TextFont.Name = "Arial";
                    NewField111212.Value = @":";

                    NewField156 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 80, 44, 85, false);
                    NewField156.Name = "NewField156";
                    NewField156.TextFont.Name = "Arial";
                    NewField156.Value = @"SINIF - RÜTBE";

                    NewField111213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 80, 47, 85, false);
                    NewField111213.Name = "NewField111213";
                    NewField111213.TextFont.Name = "Arial";
                    NewField111213.Value = @":";

                    NewField1451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 91, 44, 96, false);
                    NewField1451.Name = "NewField1451";
                    NewField1451.TextFont.Name = "Arial";
                    NewField1451.Value = @"BABA ADI";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 91, 47, 96, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Name = "Arial";
                    NewField1112111.Value = @":";

                    NewField1651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 96, 44, 101, false);
                    NewField1651.Name = "NewField1651";
                    NewField1651.TextFont.Name = "Arial";
                    NewField1651.Value = @"SİCİL NO";

                    NewField1312111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 96, 47, 101, false);
                    NewField1312111.Name = "NewField1312111";
                    NewField1312111.TextFont.Name = "Arial";
                    NewField1312111.Value = @":";

                    NewField11541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 101, 44, 106, false);
                    NewField11541.Name = "NewField11541";
                    NewField11541.TextFont.Name = "Arial";
                    NewField11541.Value = @"BİRLİĞİ";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 101, 47, 106, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Name = "Arial";
                    NewField11112111.Value = @":";

                    NewField157 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 115, 44, 120, false);
                    NewField157.Name = "NewField157";
                    NewField157.TextFont.Name = "Arial";
                    NewField157.Value = @"RAPOR NO";

                    NewField111214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 115, 47, 120, false);
                    NewField111214.Name = "NewField111214";
                    NewField111214.TextFont.Name = "Arial";
                    NewField111214.Value = @":";

                    NewField1452 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 120, 44, 125, false);
                    NewField1452.Name = "NewField1452";
                    NewField1452.TextFont.Name = "Arial";
                    NewField1452.Value = @"RAPOR TARİHİ";

                    NewField1112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 120, 47, 125, false);
                    NewField1112112.Name = "NewField1112112";
                    NewField1112112.TextFont.Name = "Arial";
                    NewField1112112.Value = @":";

                    NewField1652 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 125, 44, 130, false);
                    NewField1652.Name = "NewField1652";
                    NewField1652.TextFont.Name = "Arial";
                    NewField1652.Value = @"TANI";

                    NewField1312112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 125, 47, 130, false);
                    NewField1312112.Name = "NewField1312112";
                    NewField1312112.TextFont.Name = "Arial";
                    NewField1312112.Value = @":";

                    NewField11542 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 192, 44, 197, false);
                    NewField11542.Name = "NewField11542";
                    NewField11542.TextFont.Name = "Arial";
                    NewField11542.Value = @"KARAR";

                    NewField11112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 192, 47, 197, false);
                    NewField11112112.Name = "NewField11112112";
                    NewField11112112.TextFont.Name = "Arial";
                    NewField11112112.Value = @":";

                    SOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 75, 166, 80, false);
                    SOYADI.Name = "SOYADI";
                    SOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SOYADI.TextFont.Name = "Arial";
                    SOYADI.Value = @"{#HEADER.PSURNAME#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 96, 201, 101, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SICILNO.TextFont.Name = "Arial";
                    SICILNO.Value = @"";

                    MUAYENEAMACI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 110, 201, 115, false);
                    MUAYENEAMACI.Name = "MUAYENEAMACI";
                    MUAYENEAMACI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEAMACI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MUAYENEAMACI.TextFont.Name = "Arial";
                    MUAYENEAMACI.Value = @"{#HEADER.SKSEBEBI#}";

                    SKBASKANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 256, 201, 277, false);
                    SKBASKANI.Name = "SKBASKANI";
                    SKBASKANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKBASKANI.MultiLine = EvetHayirEnum.ehEvet;
                    SKBASKANI.NoClip = EvetHayirEnum.ehEvet;
                    SKBASKANI.WordBreak = EvetHayirEnum.ehEvet;
                    SKBASKANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SKBASKANI.TextFont.Name = "Arial";
                    SKBASKANI.Value = @"";

                    NewField1653 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 86, 44, 91, false);
                    NewField1653.Name = "NewField1653";
                    NewField1653.TextFont.Name = "Arial";
                    NewField1653.Value = @"KUVVET";

                    NewField1312113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 86, 47, 91, false);
                    NewField1312113.Name = "NewField1312113";
                    NewField1312113.TextFont.Name = "Arial";
                    NewField1312113.Value = @":";

                    KUVVET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 86, 201, 91, false);
                    KUVVET.Name = "KUVVET";
                    KUVVET.FieldType = ReportFieldTypeEnum.ftVariable;
                    KUVVET.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KUVVET.TextFont.Name = "Arial";
                    KUVVET.Value = @"";

                    TCKIMLIKNOBARKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 9, 201, 19, false);
                    TCKIMLIKNOBARKOD.Name = "TCKIMLIKNOBARKOD";
                    TCKIMLIKNOBARKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNOBARKOD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNOBARKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNOBARKOD.TextFont.Name = "FFontCode39H3";
                    TCKIMLIKNOBARKOD.TextFont.Size = 12;
                    TCKIMLIKNOBARKOD.TextFont.CharSet = 0;
                    TCKIMLIKNOBARKOD.Value = @"";

                    FOTOGRAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 56, 200, 84, false);
                    FOTOGRAF.Name = "FOTOGRAF";
                    FOTOGRAF.Visible = EvetHayirEnum.ehHayir;
                    FOTOGRAF.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTOGRAF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF.WordBreak = EvetHayirEnum.ehEvet;
                    FOTOGRAF.TextFont.Size = 8;
                    FOTOGRAF.Value = @"";

                    FOTOGRAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 56, 200, 84, false);
                    FOTOGRAF1.Name = "FOTOGRAF1";
                    FOTOGRAF1.DrawStyle = DrawStyleConstants.vbSolid;
                    FOTOGRAF1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTOGRAF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTOGRAF1.TextFont.Size = 8;
                    FOTOGRAF1.Value = @"FOTOGRAF";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 65, 166, 70, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TCNO.TextFont.Name = "Arial";
                    TCNO.Value = @"{%TCKIMLIKNO%}";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 65, 44, 70, false);
                    NewField152.Name = "NewField152";
                    NewField152.TextFont.Name = "Arial";
                    NewField152.Value = @"TC KIMLIK NO";

                    NewField111215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 65, 47, 70, false);
                    NewField111215.Name = "NewField111215";
                    NewField111215.TextFont.Name = "Arial";
                    NewField111215.Value = @":";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 193, 249, 198, false);
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
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.HEADER.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    KARAR.CalcValue = @"";
                    NewFieldA3.CalcValue = NewFieldA3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    RAPORSEBEP.CalcValue = @"";
                    RAPORNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    TANI.CalcValue = @"";
                    ADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    NewField25.CalcValue = NewField25.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField79.CalcValue = NewField79.Value;
                    S5.CalcValue = @"";
                    S8.CalcValue = @"";
                    NewField6.CalcValue = NewField6.Value;
                    TARIH.CalcValue = DateTime.Now.ToShortDateString();
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    SINIFRUTBE.CalcValue = @"";
                    BIRLIK.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField154.CalcValue = NewField154.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField155.CalcValue = NewField155.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField156.CalcValue = NewField156.Value;
                    NewField111213.CalcValue = NewField111213.Value;
                    NewField1451.CalcValue = NewField1451.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1651.CalcValue = NewField1651.Value;
                    NewField1312111.CalcValue = NewField1312111.Value;
                    NewField11541.CalcValue = NewField11541.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField157.CalcValue = NewField157.Value;
                    NewField111214.CalcValue = NewField111214.Value;
                    NewField1452.CalcValue = NewField1452.Value;
                    NewField1112112.CalcValue = NewField1112112.Value;
                    NewField1652.CalcValue = NewField1652.Value;
                    NewField1312112.CalcValue = NewField1312112.Value;
                    NewField11542.CalcValue = NewField11542.Value;
                    NewField11112112.CalcValue = NewField11112112.Value;
                    SOYADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    SICILNO.CalcValue = @"";
                    MUAYENEAMACI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    SKBASKANI.CalcValue = @"";
                    NewField1653.CalcValue = NewField1653.Value;
                    NewField1312113.CalcValue = NewField1312113.Value;
                    KUVVET.CalcValue = @"";
                    TCKIMLIKNOBARKOD.CalcValue = @"";
                    FOTOGRAF.CalcValue = @"";
                    FOTOGRAF1.CalcValue = FOTOGRAF1.Value;
                    TCNO.CalcValue = MyParentReport.MAIN.TCKIMLIKNO.CalcValue;
                    NewField152.CalcValue = NewField152.Value;
                    NewField111215.CalcValue = NewField111215.Value;
                    DECISIONTIME.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCPREDECLARATIONFLIERREPORTCAPTION","");
                    EVRAKNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCPDFLIERREPORTDOCUMENTNUMBER","");
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","");
                    XXXXXXSEHIR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","");
                    return new TTReportObject[] { KARAR,NewFieldA3,NewField14,RAPORSEBEP,RAPORNO,RAPORTARIHI,TANI,ADI,BABAADI,NewField25,TCKIMLIKNO,NewField79,S5,S8,NewField6,TARIH,NewField11,NewField12,SINIFRUTBE,BIRLIK,NewField121,NewField1121,NewField11211,NewField154,NewField111211,NewField155,NewField111212,NewField156,NewField111213,NewField1451,NewField1112111,NewField1651,NewField1312111,NewField11541,NewField11112111,NewField157,NewField111214,NewField1452,NewField1112112,NewField1652,NewField1312112,NewField11542,NewField11112112,SOYADI,SICILNO,MUAYENEAMACI,SKBASKANI,NewField1653,NewField1312113,KUVVET,TCKIMLIKNOBARKOD,FOTOGRAF,FOTOGRAF1,TCNO,NewField152,NewField111215,DECISIONTIME,XXXXXXBASLIK,EVRAKNO,BASLIK,XXXXXXSEHIR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPreDeclarationDocumentFlierReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
//
            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//
            /* Yakınlık derecesinin artık görünmemesi istendi (27.07.2016 Mustafa)
            if (hc.Episode.MyRelationship() != null)
            {
                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            }
             */
            
            //            this.KUVVET.CalcValue = hc.Episode.ForcesCommand != null ? hc.Episode.ForcesCommand.Qref : "" ;
            
            //SK Başkanı
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string sName = member.MemberDoctor.Name;
                    string sTitle = string.Empty;
                    sTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(member.MemberDoctor.Title.Value);
                    sTitle += (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.ShortName);
                    string sEmpID = member.MemberDoctor.EmploymentRecordID == null ? "" : member.MemberDoctor.EmploymentRecordID;
                    string sTitle2 = TTObjectClasses.SystemParameter.GetParameterValue("HCPDFLIERREPORTSIGNATUREBLOCK","");
                    this.SKBASKANI.CalcValue = sName + "\n" + sTitle + "(" + sEmpID + ")" + "\n" + sTitle2;
                }
            }
            
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                string maddeDilimFikra = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    maddeDilimFikra += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    maddeDilimFikra += "  ";
                }
                maddeDilimFikra = maddeDilimFikra.Substring(0, maddeDilimFikra.Length - 2);
                maddeDilimFikra += "]";
                
                this.KARAR.CalcValue = maddeDilimFikra + "\n";
            }

            // Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString());
            }
            
            
            // Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            // TC Kimlik No nun barkod olarak yazılması
            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWBARCODEONHCPREDECREPORT", "FALSE") == "TRUE")
            {
                if(this.TCKIMLIKNO.CalcValue != string.Empty)
                {
                    this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                    this.TCKIMLIKNOBARKOD.CalcValue = "*" + this.TCKIMLIKNO.CalcValue + "*";
                }
            }
            else
                this.TCKIMLIKNOBARKOD.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            
            //AdditionalMembers
            if (hc.UnsuitableForMilitaryService == true)
            {
                this.FOTOGRAF.Visible = EvetHayirEnum.ehEvet;
                this.FOTOGRAF1.Visible = EvetHayirEnum.ehHayir;
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

        public HCPreDeclarationDocumentFlierReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "C7203EFB-0742-4709-9E32-6D3608F9C34F", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCPREDECLARATIONDOCUMENTFLIERREPORT";
            Caption = "Uçucu Sağlık Kurulu Ön Bildirim Belgesi";
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