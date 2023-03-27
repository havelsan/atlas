
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
    /// Epikriz
    /// </summary>
    public partial class SpecialCareExaminationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public SpecialCareExaminationReport MyParentReport
            {
                get { return (SpecialCareExaminationReport)ParentReport; }
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

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public SpecialCareExaminationReport MyParentReport
                {
                    get { return (SpecialCareExaminationReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public SpecialCareExaminationReport MyParentReport
                {
                    get { return (SpecialCareExaminationReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public SpecialCareExaminationReport MyParentReport
            {
                get { return (SpecialCareExaminationReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField RAPORTARIH { get {return Header().RAPORTARIH;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField NewField192 { get {return Header().NewField192;} }
            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField ALAN1 { get {return Header().ALAN1;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField ALAN11 { get {return Header().ALAN11;} }
            public TTReportField NewField111511 { get {return Header().NewField111511;} }
            public TTReportField NewField111811 { get {return Header().NewField111811;} }
            public TTReportField ALAN12 { get {return Header().ALAN12;} }
            public TTReportField NewField111512 { get {return Header().NewField111512;} }
            public TTReportField NewField111812 { get {return Header().NewField111812;} }
            public TTReportField ALAN13 { get {return Header().ALAN13;} }
            public TTReportField NewField111513 { get {return Header().NewField111513;} }
            public TTReportField NewField111813 { get {return Header().NewField111813;} }
            public TTReportField ALAN14 { get {return Header().ALAN14;} }
            public TTReportField NewField111514 { get {return Header().NewField111514;} }
            public TTReportField NewField111814 { get {return Header().NewField111814;} }
            public TTReportField ALAN141 { get {return Header().ALAN141;} }
            public TTReportField ALAN142 { get {return Header().ALAN142;} }
            public TTReportField ALAN143 { get {return Header().ALAN143;} }
            public TTReportField KONU1 { get {return Header().KONU1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField102 { get {return Footer().NewField102;} }
            public TTReportField NewField103 { get {return Footer().NewField103;} }
            public TTReportField NewField1315111 { get {return Footer().NewField1315111;} }
            public TTReportField KONU11 { get {return Footer().KONU11;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField11115131 { get {return Footer().NewField11115131;} }
            public TTReportField NewField113151111 { get {return Footer().NewField113151111;} }
            public TTReportField NewField1111151311 { get {return Footer().NewField1111151311;} }
            public TTReportField NewFieldA2 { get {return Footer().NewFieldA2;} }
            public TTReportField NewFieldA1 { get {return Footer().NewFieldA1;} }
            public TTReportField NewField113151112 { get {return Footer().NewField113151112;} }
            public TTReportField NewField1211151311 { get {return Footer().NewField1211151311;} }
            public TTReportField NewField1211151312 { get {return Footer().NewField1211151312;} }
            public TTReportField KONU12 { get {return Footer().KONU12;} }
            public TTReportField KONU121 { get {return Footer().KONU121;} }
            public TTReportField KONU122 { get {return Footer().KONU122;} }
            public TTReportField KONU123 { get {return Footer().KONU123;} }
            public TTReportField KONU124 { get {return Footer().KONU124;} }
            public TTReportField KONU1421 { get {return Footer().KONU1421;} }
            public TTReportField NewField123 { get {return Footer().NewField123;} }
            public NOTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.GetPatientInfoByEpisodeAction_Class>("GetPatientInfoByEpisodeAction", EpisodeAction.GetPatientInfoByEpisodeAction((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTGroupHeader(this);
                _footer = new NOTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NOTGroupHeader : TTReportSection
            {
                public SpecialCareExaminationReport MyParentReport
                {
                    get { return (SpecialCareExaminationReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField KONU;
                public TTReportField SICILNO;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField RAPORTARIH;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField SINIFRUTBE;
                public TTReportField NewField10;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField DTARIH;
                public TTReportField ACTIONDATE;
                public TTReportField NewField1;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField11;
                public TTReportField DYERVETARIH;
                public TTReportField NewField192;
                public TTReportField MILITARYUNIT;
                public TTReportField NewField1151;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField NewField101;
                public TTReportField ALAN1;
                public TTReportField NewField11511;
                public TTReportField NewField11811;
                public TTReportField ALAN11;
                public TTReportField NewField111511;
                public TTReportField NewField111811;
                public TTReportField ALAN12;
                public TTReportField NewField111512;
                public TTReportField NewField111812;
                public TTReportField ALAN13;
                public TTReportField NewField111513;
                public TTReportField NewField111813;
                public TTReportField ALAN14;
                public TTReportField NewField111514;
                public TTReportField NewField111814;
                public TTReportField ALAN141;
                public TTReportField ALAN142;
                public TTReportField ALAN143;
                public TTReportField KONU1;
                public TTReportField NewField12;
                public TTReportField XXXXXXBASLIK1; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 297;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 31, 205, 36, false);
                    HEADER.Name = "HEADER";
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"ÖZEL BAKIM MERKEZİNE MÜRACAAT EDEN PERSONELE DÜZENLENECEK MUAYENE RAPORU";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 204, 17, false);
                    KONU.Name = "KONU";
                    KONU.Visible = EvetHayirEnum.ehHayir;
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.MultiLine = EvetHayirEnum.ehEvet;
                    KONU.NoClip = EvetHayirEnum.ehEvet;
                    KONU.WordBreak = EvetHayirEnum.ehEvet;
                    KONU.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU.TextFont.Name = "Arial";
                    KONU.TextFont.Bold = true;
                    KONU.Value = @"Gnkur Bşk.lığının {#ACTIONDATE#} ve XXXXXX.SAĞ.:8100-3-08/Sağ.Hiz.D.Rp.Ş.sayılı yazısının EK'idir";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 65, 166, 70, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial";
                    SICILNO.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 50, 63, 55, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Sınıf ve Rütbesi";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 65, 61, 70, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Sicil No";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 60, 166, 65, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.DrawStyle = DrawStyleConstants.vbSolid;
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.TextFont.Name = "Arial";
                    BABAAD.Value = @"{#FATHERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 55, 166, 60, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial";
                    ADSOYAD.Value = @"{#NAME#} {#SURNAME#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 55, 61, 60, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Adı Soyadı";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 55, 63, 60, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 50, 63, 55, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 60, 61, 65, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @"Baba Adı";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 64, 63, 70, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @":";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 60, 63, 65, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @":";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 40, 61, 45, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"T.C.Kimlik No";

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 45, 166, 50, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIH.TextFont.Name = "Arial";
                    RAPORTARIH.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 40, 63, 45, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 45, 63, 50, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 45, 61, 50, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @"Rapor No ve Tarihi";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 50, 166, 55, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.DrawStyle = DrawStyleConstants.vbSolid;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Name = "Arial";
                    SINIFRUTBE.Value = @"";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 35, 8, false);
                    NewField10.Name = "NewField10";
                    NewField10.Visible = EvetHayirEnum.ehHayir;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"HİZMETE ÖZEL";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 2, 236, 7, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.TextFont.Name = "Arial";
                    SITENAME.TextFont.Bold = true;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 8, 236, 13, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.TextFont.Name = "Arial";
                    SITECITY.TextFont.Bold = true;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 23, 237, 28, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.DataMember = "BIRTHDATE";
                    DTARIH.TextFont.Name = "Arial";
                    DTARIH.TextFont.Bold = true;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 16, 236, 21, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFont.Name = "Arial";
                    ACTIONDATE.TextFont.Bold = true;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 17, 204, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"EK";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 40, 166, 45, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 40, 204, 80, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.FieldType = ReportFieldTypeEnum.ftOLE;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.Value = @"";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 70, 166, 75, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial";
                    DYERVETARIH.Value = @"{#TOWNOFBIRTH#} / {#CITYOFBIRTH#} - {%DTARIH%}";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 70, 61, 75, false);
                    NewField192.Name = "NewField192";
                    NewField192.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField192.TextFont.Name = "Arial";
                    NewField192.TextFont.Bold = true;
                    NewField192.Value = @"Doğum Yeri ve Tarihi";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 75, 166, 80, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.Value = @"";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 75, 61, 80, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.Value = @"Birliği/Adresi";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 70, 63, 75, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 75, 63, 80, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.TextFont.Name = "Arial";
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @":";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 289, 35, 293, false);
                    NewField101.Name = "NewField101";
                    NewField101.Visible = EvetHayirEnum.ehHayir;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @"HİZMETE ÖZEL";

                    ALAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 80, 204, 107, false);
                    ALAN1.Name = "ALAN1";
                    ALAN1.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN1.TextFont.Name = "Arial";
                    ALAN1.Value = @"";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 80, 61, 107, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"İÇ HASTALIKLARI";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 80, 63, 107, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.TextFont.Name = "Arial";
                    NewField11811.TextFont.Bold = true;
                    NewField11811.Value = @":";

                    ALAN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 107, 204, 134, false);
                    ALAN11.Name = "ALAN11";
                    ALAN11.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN11.TextFont.Name = "Arial";
                    ALAN11.Value = @"";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 107, 61, 134, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111511.TextFont.Name = "Arial";
                    NewField111511.TextFont.Bold = true;
                    NewField111511.Value = @"ENFEKSİYON";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 107, 63, 134, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111811.TextFont.Name = "Arial";
                    NewField111811.TextFont.Bold = true;
                    NewField111811.Value = @":";

                    ALAN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 134, 204, 161, false);
                    ALAN12.Name = "ALAN12";
                    ALAN12.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN12.TextFont.Name = "Arial";
                    ALAN12.Value = @"";

                    NewField111512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 134, 61, 161, false);
                    NewField111512.Name = "NewField111512";
                    NewField111512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111512.TextFont.Name = "Arial";
                    NewField111512.TextFont.Bold = true;
                    NewField111512.Value = @"PSİKİYATRİ";

                    NewField111812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 134, 63, 161, false);
                    NewField111812.Name = "NewField111812";
                    NewField111812.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111812.TextFont.Name = "Arial";
                    NewField111812.TextFont.Bold = true;
                    NewField111812.Value = @":";

                    ALAN13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 161, 204, 188, false);
                    ALAN13.Name = "ALAN13";
                    ALAN13.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN13.TextFont.Name = "Arial";
                    ALAN13.Value = @"";

                    NewField111513 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 161, 61, 188, false);
                    NewField111513.Name = "NewField111513";
                    NewField111513.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111513.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111513.NoClip = EvetHayirEnum.ehEvet;
                    NewField111513.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111513.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111513.TextFont.Name = "Arial";
                    NewField111513.TextFont.Bold = true;
                    NewField111513.Value = @"NÖROLOJİ veya FİZİK TEDAVİ REHABİLİTASYON";

                    NewField111813 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 161, 63, 188, false);
                    NewField111813.Name = "NewField111813";
                    NewField111813.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111813.TextFont.Name = "Arial";
                    NewField111813.TextFont.Bold = true;
                    NewField111813.Value = @":";

                    ALAN14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 188, 204, 212, false);
                    ALAN14.Name = "ALAN14";
                    ALAN14.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN14.TextFont.Name = "Arial";
                    ALAN14.Value = @"";

                    NewField111514 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 188, 61, 282, false);
                    NewField111514.Name = "NewField111514";
                    NewField111514.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111514.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111514.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111514.NoClip = EvetHayirEnum.ehEvet;
                    NewField111514.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111514.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111514.TextFont.Name = "Arial";
                    NewField111514.TextFont.Bold = true;
                    NewField111514.Value = @"LÜZUM GÖRÜLEN DİĞER BRANŞLAR(*)";

                    NewField111814 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 188, 63, 282, false);
                    NewField111814.Name = "NewField111814";
                    NewField111814.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111814.TextFont.Name = "Arial";
                    NewField111814.TextFont.Bold = true;
                    NewField111814.Value = @":";

                    ALAN141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 212, 204, 236, false);
                    ALAN141.Name = "ALAN141";
                    ALAN141.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN141.TextFont.Name = "Arial";
                    ALAN141.Value = @"";

                    ALAN142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 236, 204, 260, false);
                    ALAN142.Name = "ALAN142";
                    ALAN142.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN142.TextFont.Name = "Arial";
                    ALAN142.Value = @"";

                    ALAN143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 260, 204, 282, false);
                    ALAN143.Name = "ALAN143";
                    ALAN143.DrawStyle = DrawStyleConstants.vbSolid;
                    ALAN143.TextFont.Name = "Arial";
                    ALAN143.Value = @"";

                    KONU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 283, 203, 287, false);
                    KONU1.Name = "KONU1";
                    KONU1.MultiLine = EvetHayirEnum.ehEvet;
                    KONU1.NoClip = EvetHayirEnum.ehEvet;
                    KONU1.WordBreak = EvetHayirEnum.ehEvet;
                    KONU1.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU1.TextFont.Name = "Arial";
                    KONU1.Value = @"(*)Uzmanlar muayene esnasında diğer branşları ilgilendiren hastalık ve arıza görürlerse ilgili uzmanın da muayenesini isterler";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 289, 113, 294, false);
                    NewField12.Name = "NewField12";
                    NewField12.Visible = EvetHayirEnum.ehHayir;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"EK - 1";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 23, 205, 28, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    XXXXXXBASLIK1.TextFont.Name = "Arial";
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPatientInfoByEpisodeAction_Class dataset_GetPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPatientInfoByEpisodeAction_Class>(0);
                    HEADER.CalcValue = HEADER.Value;
                    KONU.CalcValue = @"Gnkur Bşk.lığının " + (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.ActionDate) : "") + @" ve XXXXXX.SAĞ.:8100-3-08/Sağ.Hiz.D.Rp.Ş.sayılı yazısının EK'idir";
                    SICILNO.CalcValue = @"";
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    BABAAD.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.FatherName) : "");
                    ADSOYAD.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Name) : "") + @" " + (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Surname) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    RAPORTARIH.CalcValue = @"";
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    SINIFRUTBE.CalcValue = @"";
                    NewField10.CalcValue = NewField10.Value;
                    DTARIH.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.BirthDate) : "");
                    ACTIONDATE.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.ActionDate) : "");
                    NewField1.CalcValue = NewField1.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.UniqueRefNo) : "");
                    NewField11.CalcValue = @"";
                    DYERVETARIH.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Townofbirth) : "") + @" / " + (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Cityofbirth) : "") + @" - " + MyParentReport.NOT.DTARIH.FormattedValue;
                    NewField192.CalcValue = NewField192.Value;
                    MILITARYUNIT.CalcValue = @"";
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField101.CalcValue = NewField101.Value;
                    ALAN1.CalcValue = ALAN1.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    ALAN11.CalcValue = ALAN11.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    ALAN12.CalcValue = ALAN12.Value;
                    NewField111512.CalcValue = NewField111512.Value;
                    NewField111812.CalcValue = NewField111812.Value;
                    ALAN13.CalcValue = ALAN13.Value;
                    NewField111513.CalcValue = NewField111513.Value;
                    NewField111813.CalcValue = NewField111813.Value;
                    ALAN14.CalcValue = ALAN14.Value;
                    NewField111514.CalcValue = NewField111514.Value;
                    NewField111814.CalcValue = NewField111814.Value;
                    ALAN141.CalcValue = ALAN141.Value;
                    ALAN142.CalcValue = ALAN142.Value;
                    ALAN143.CalcValue = ALAN143.Value;
                    KONU1.CalcValue = KONU1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { HEADER,KONU,SICILNO,NewField18,NewField19,BABAAD,ADSOYAD,NewField121,NewField131,NewField141,NewField151,NewField171,NewField181,NewField191,RAPORTARIH,NewField112,NewField122,NewField132,SINIFRUTBE,NewField10,DTARIH,ACTIONDATE,NewField1,TCKIMLIKNO,NewField11,DYERVETARIH,NewField192,MILITARYUNIT,NewField1151,NewField1171,NewField1181,NewField101,ALAN1,NewField11511,NewField11811,ALAN11,NewField111511,NewField111811,ALAN12,NewField111512,NewField111812,ALAN13,NewField111513,NewField111813,ALAN14,NewField111514,NewField111814,ALAN141,ALAN142,ALAN143,KONU1,NewField12,SITENAME,SITECITY,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region NOT HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SpecialCareExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
//            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
//            RankDefinitions pRank = hc.Episode.Rank;
//            
//            // sınıf ve rütbe boş ise hasta grubu gelsin istendi
//            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
//                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
//            else
//                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//            
//            if (hc.Episode.MyRelationship() != null)
//            {
//                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
//                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
//            }
#endregion NOT HEADER_Script
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public SpecialCareExaminationReport MyParentReport
                {
                    get { return (SpecialCareExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField102;
                public TTReportField NewField103;
                public TTReportField NewField1315111;
                public TTReportField KONU11;
                public TTReportField NewField13;
                public TTReportField NewField11115131;
                public TTReportField NewField113151111;
                public TTReportField NewField1111151311;
                public TTReportField NewFieldA2;
                public TTReportField NewFieldA1;
                public TTReportField NewField113151112;
                public TTReportField NewField1211151311;
                public TTReportField NewField1211151312;
                public TTReportField KONU12;
                public TTReportField KONU121;
                public TTReportField KONU122;
                public TTReportField KONU123;
                public TTReportField KONU124;
                public TTReportField KONU1421;
                public TTReportField NewField123; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 297;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 35, 11, false);
                    NewField102.Name = "NewField102";
                    NewField102.Visible = EvetHayirEnum.ehHayir;
                    NewField102.TextFont.Name = "Arial";
                    NewField102.TextFont.Bold = true;
                    NewField102.Value = @"HİZMETE ÖZEL";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 287, 35, 291, false);
                    NewField103.Name = "NewField103";
                    NewField103.Visible = EvetHayirEnum.ehHayir;
                    NewField103.TextFont.Name = "Arial";
                    NewField103.TextFont.Bold = true;
                    NewField103.Value = @"HİZMETE ÖZEL";

                    NewField1315111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 204, 47, false);
                    NewField1315111.Name = "NewField1315111";
                    NewField1315111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1315111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1315111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1315111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1315111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1315111.TextFont.Name = "Arial";
                    NewField1315111.Value = @"PA AKCİĞER GRAFİSİ:";

                    KONU11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 14, 204, 19, false);
                    KONU11.Name = "KONU11";
                    KONU11.MultiLine = EvetHayirEnum.ehEvet;
                    KONU11.NoClip = EvetHayirEnum.ehEvet;
                    KONU11.WordBreak = EvetHayirEnum.ehEvet;
                    KONU11.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU11.TextFont.Name = "Arial";
                    KONU11.Value = @"LABORATUVAR TETKİK VE SONUÇLARI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 7, 204, 12, false);
                    NewField13.Name = "NewField13";
                    NewField13.Visible = EvetHayirEnum.ehHayir;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"EK'in DEVAMI";

                    NewField11115131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 47, 204, 74, false);
                    NewField11115131.Name = "NewField11115131";
                    NewField11115131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11115131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11115131.NoClip = EvetHayirEnum.ehEvet;
                    NewField11115131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11115131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11115131.TextFont.Name = "Arial";
                    NewField11115131.Value = @"DÜSG              :";

                    NewField113151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 74, 107, 122, false);
                    NewField113151111.Name = "NewField113151111";
                    NewField113151111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113151111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113151111.NoClip = EvetHayirEnum.ehEvet;
                    NewField113151111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113151111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113151111.TextFont.Name = "Arial";
                    NewField113151111.Value = @"Kan Şekeri        :  
Üre                   :    
Kreatinin           :   
SGOT               :   
SGPT               :   
Trigliserit           :      
Total,HDL ve LDL Kolesterol :
Alkalen Fosfataz  :
HBsAg                :   
Gaitada Gizli Kan :";

                    NewField1111151311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 74, 204, 122, false);
                    NewField1111151311.Name = "NewField1111151311";
                    NewField1111151311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111151311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111151311.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111151311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111151311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111151311.TextFont.Name = "Arial";
                    NewField1111151311.Value = @"Sedimantasyon

 TAM KAN";

                    NewFieldA2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 122, 107, 146, false);
                    NewFieldA2.Name = "NewFieldA2";
                    NewFieldA2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewFieldA2.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldA2.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldA2.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldA2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldA2.TextFont.Name = "Arial";
                    NewFieldA2.Value = @"EKG";

                    NewFieldA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 122, 204, 146, false);
                    NewFieldA1.Name = "NewFieldA1";
                    NewFieldA1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewFieldA1.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldA1.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldA1.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldA1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldA1.TextFont.Name = "Arial";
                    NewFieldA1.Value = @" TAM İDRAR";

                    NewField113151112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 146, 204, 183, false);
                    NewField113151112.Name = "NewField113151112";
                    NewField113151112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113151112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113151112.NoClip = EvetHayirEnum.ehEvet;
                    NewField113151112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113151112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113151112.TextFont.Name = "Arial";
                    NewField113151112.Value = @"LÜZUM GÖRÜLEN DİĞER 
LABORATUVAR TETKİKLERİ";

                    NewField1211151311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 183, 204, 210, false);
                    NewField1211151311.Name = "NewField1211151311";
                    NewField1211151311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211151311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211151311.NoClip = EvetHayirEnum.ehEvet;
                    NewField1211151311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211151311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211151311.TextFont.Name = "Arial";
                    NewField1211151311.TextFont.Bold = true;
                    NewField1211151311.Value = @"TANI";

                    NewField1211151312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 210, 204, 237, false);
                    NewField1211151312.Name = "NewField1211151312";
                    NewField1211151312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211151312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211151312.NoClip = EvetHayirEnum.ehEvet;
                    NewField1211151312.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211151312.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211151312.TextFont.Name = "Arial";
                    NewField1211151312.TextFont.Bold = true;
                    NewField1211151312.Value = @"KARAR";

                    KONU12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 243, 37, 261, false);
                    KONU12.Name = "KONU12";
                    KONU12.MultiLine = EvetHayirEnum.ehEvet;
                    KONU12.NoClip = EvetHayirEnum.ehEvet;
                    KONU12.WordBreak = EvetHayirEnum.ehEvet;
                    KONU12.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU12.TextFont.Name = "Arial";
                    KONU12.Value = @"İmza

İç Hst.Uzm.";

                    KONU121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 243, 72, 260, false);
                    KONU121.Name = "KONU121";
                    KONU121.MultiLine = EvetHayirEnum.ehEvet;
                    KONU121.NoClip = EvetHayirEnum.ehEvet;
                    KONU121.WordBreak = EvetHayirEnum.ehEvet;
                    KONU121.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU121.TextFont.Name = "Arial";
                    KONU121.Value = @"İmza

Enf.Hst.Uzm.";

                    KONU122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 243, 111, 260, false);
                    KONU122.Name = "KONU122";
                    KONU122.MultiLine = EvetHayirEnum.ehEvet;
                    KONU122.NoClip = EvetHayirEnum.ehEvet;
                    KONU122.WordBreak = EvetHayirEnum.ehEvet;
                    KONU122.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU122.TextFont.Name = "Arial";
                    KONU122.Value = @"İmza

Psikiyatri Uzm.";

                    KONU123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 243, 155, 260, false);
                    KONU123.Name = "KONU123";
                    KONU123.MultiLine = EvetHayirEnum.ehEvet;
                    KONU123.NoClip = EvetHayirEnum.ehEvet;
                    KONU123.WordBreak = EvetHayirEnum.ehEvet;
                    KONU123.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU123.TextFont.Name = "Arial";
                    KONU123.Value = @"İmza

Nöroloji/FTR Uzm.";

                    KONU124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 242, 195, 260, false);
                    KONU124.Name = "KONU124";
                    KONU124.MultiLine = EvetHayirEnum.ehEvet;
                    KONU124.NoClip = EvetHayirEnum.ehEvet;
                    KONU124.WordBreak = EvetHayirEnum.ehEvet;
                    KONU124.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU124.TextFont.Name = "Arial";
                    KONU124.Value = @"İmza

Sağlık Krl.Bşk.";

                    KONU1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 265, 123, 283, false);
                    KONU1421.Name = "KONU1421";
                    KONU1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KONU1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KONU1421.MultiLine = EvetHayirEnum.ehEvet;
                    KONU1421.NoClip = EvetHayirEnum.ehEvet;
                    KONU1421.WordBreak = EvetHayirEnum.ehEvet;
                    KONU1421.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONU1421.TextFont.Name = "Arial";
                    KONU1421.Value = @"ONAY
BAŞTABİP";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 285, 115, 290, false);
                    NewField123.Name = "NewField123";
                    NewField123.Visible = EvetHayirEnum.ehHayir;
                    NewField123.TextFont.Name = "Arial";
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @"EK - 2";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPatientInfoByEpisodeAction_Class dataset_GetPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPatientInfoByEpisodeAction_Class>(0);
                    NewField102.CalcValue = NewField102.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField1315111.CalcValue = NewField1315111.Value;
                    KONU11.CalcValue = KONU11.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField11115131.CalcValue = NewField11115131.Value;
                    NewField113151111.CalcValue = NewField113151111.Value;
                    NewField1111151311.CalcValue = NewField1111151311.Value;
                    NewFieldA2.CalcValue = NewFieldA2.Value;
                    NewFieldA1.CalcValue = NewFieldA1.Value;
                    NewField113151112.CalcValue = NewField113151112.Value;
                    NewField1211151311.CalcValue = NewField1211151311.Value;
                    NewField1211151312.CalcValue = NewField1211151312.Value;
                    KONU12.CalcValue = KONU12.Value;
                    KONU121.CalcValue = KONU121.Value;
                    KONU122.CalcValue = KONU122.Value;
                    KONU123.CalcValue = KONU123.Value;
                    KONU124.CalcValue = KONU124.Value;
                    KONU1421.CalcValue = KONU1421.Value;
                    NewField123.CalcValue = NewField123.Value;
                    return new TTReportObject[] { NewField102,NewField103,NewField1315111,KONU11,NewField13,NewField11115131,NewField113151111,NewField1111151311,NewFieldA2,NewFieldA1,NewField113151112,NewField1211151311,NewField1211151312,KONU12,KONU121,KONU122,KONU123,KONU124,KONU1421,NewField123};
                }
            }

        }

        public NOTGroup NOT;

        public partial class MAINGroup : TTReportGroup
        {
            public SpecialCareExaminationReport MyParentReport
            {
                get { return (SpecialCareExaminationReport)ParentReport; }
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
                public SpecialCareExaminationReport MyParentReport
                {
                    get { return (SpecialCareExaminationReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
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

        public SpecialCareExaminationReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SPECIALCAREEXAMINATIONREPORT";
            Caption = "Özel Bakım Merkezi Muayene Raporu";
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