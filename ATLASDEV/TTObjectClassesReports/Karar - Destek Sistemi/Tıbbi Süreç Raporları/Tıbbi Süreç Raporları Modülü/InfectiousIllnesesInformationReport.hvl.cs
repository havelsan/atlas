
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
    /// Bulaşıcı ve Bildirimi Zorunlu Hastalıklar Bildirim Fişi
    /// </summary>
    public partial class InfectiousIllnesesInformationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class ArkasayfaGroup : TTReportGroup
        {
            public InfectiousIllnesesInformationReport MyParentReport
            {
                get { return (InfectiousIllnesesInformationReport)ParentReport; }
            }

            new public ArkasayfaGroupHeader Header()
            {
                return (ArkasayfaGroupHeader)_header;
            }

            new public ArkasayfaGroupFooter Footer()
            {
                return (ArkasayfaGroupFooter)_footer;
            }

            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField NewField49 { get {return Header().NewField49;} }
            public TTReportField NewField58 { get {return Header().NewField58;} }
            public TTReportField NewField28 { get {return Header().NewField28;} }
            public TTReportField NewField29 { get {return Header().NewField29;} }
            public TTReportField NewField30 { get {return Header().NewField30;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField ESEX { get {return Header().ESEX;} }
            public TTReportField KSEX { get {return Header().KSEX;} }
            public TTReportField BHAL { get {return Header().BHAL;} }
            public TTReportField EHAL { get {return Header().EHAL;} }
            public TTReportField DHAL { get {return Header().DHAL;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField AD { get {return Header().AD;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField DYERIDTARIHI { get {return Header().DYERIDTARIHI;} }
            public TTReportField DUHUL { get {return Header().DUHUL;} }
            public TTReportField MESLEK { get {return Header().MESLEK;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField MEDENIHAL { get {return Header().MEDENIHAL;} }
            public TTReportField HOMECITY { get {return Header().HOMECITY;} }
            public TTReportField HOMECOUNTRY { get {return Header().HOMECOUNTRY;} }
            public TTReportField HOMETOWN { get {return Header().HOMETOWN;} }
            public TTReportField NewField155 { get {return Header().NewField155;} }
            public TTReportField SOYAD { get {return Header().SOYAD;} }
            public TTReportField NewField154 { get {return Header().NewField154;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField HASTALIKADI1 { get {return Header().HASTALIKADI1;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField ULUSLARARASIKOD1 { get {return Header().ULUSLARARASIKOD1;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField BASLAMATARIHI1 { get {return Header().BASLAMATARIHI1;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField TANITARIHI1 { get {return Header().TANITARIHI1;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField XXXXXX { get {return Header().XXXXXX;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public ArkasayfaGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ArkasayfaGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class>("GetInfectiousIllnesesInformationNQL2", InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ArkasayfaGroupHeader(this);
                _footer = new ArkasayfaGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ArkasayfaGroupHeader : TTReportSection
            {
                public InfectiousIllnesesInformationReport MyParentReport
                {
                    get { return (InfectiousIllnesesInformationReport)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine4;
                public TTReportField NewField6;
                public TTReportField NewField45;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportField NewField51;
                public TTReportShape NewLine7;
                public TTReportField NewField21;
                public TTReportField NewField24;
                public TTReportField NewField26;
                public TTReportField NewField49;
                public TTReportField NewField58;
                public TTReportField NewField28;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportField NewField31;
                public TTReportField ESEX;
                public TTReportField KSEX;
                public TTReportField BHAL;
                public TTReportField EHAL;
                public TTReportField DHAL;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField AD;
                public TTReportField BABAADI;
                public TTReportField DYERIDTARIHI;
                public TTReportField DUHUL;
                public TTReportField MESLEK;
                public TTReportField ADRES;
                public TTReportField SEX;
                public TTReportField MEDENIHAL;
                public TTReportField HOMECITY;
                public TTReportField HOMECOUNTRY;
                public TTReportField HOMETOWN;
                public TTReportField NewField155;
                public TTReportField SOYAD;
                public TTReportField NewField154;
                public TTReportShape NewLine14;
                public TTReportField NewField16;
                public TTReportField NewField191;
                public TTReportField HASTALIKADI1;
                public TTReportField NewField102;
                public TTReportField ULUSLARARASIKOD1;
                public TTReportField NewField112;
                public TTReportField BASLAMATARIHI1;
                public TTReportField NewField122;
                public TTReportField TANITARIHI1;
                public TTReportField NewField162;
                public TTReportField NewField1261;
                public TTReportField XXXXXX;
                public TTReportField PATIENTSTATUS; 
                public ArkasayfaGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 153;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 14, 146, 14, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 3;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 146, 14, 146, 144, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 3;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 35, 11, 144, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine4.DrawWidth = 3;

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 19, 78, 25, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"HASTANIN KIMLIK BILGILERI";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 37, 34, 45, false);
                    NewField45.Name = "NewField45";
                    NewField45.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.TextFont.Size = 9;
                    NewField45.TextFont.Bold = true;
                    NewField45.Value = @"Adı";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 26, 146, 26, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine5.DrawWidth = 3;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 144, 146, 144, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine6.DrawWidth = 3;

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 31, 48, 36, false);
                    NewField51.Name = "NewField51";
                    NewField51.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.TextFont.Size = 9;
                    NewField51.TextFont.Bold = true;
                    NewField51.Value = @"Erkek";

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 14, 11, 35, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine7.DrawWidth = 3;

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 53, 34, 61, false);
                    NewField21.Name = "NewField21";
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Size = 9;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"Baba Adı";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 61, 34, 69, false);
                    NewField24.Name = "NewField24";
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"Doğum Tarihi";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 76, 106, 84, false);
                    NewField26.Name = "NewField26";
                    NewField26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 9;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"Ölümüşse Tarihi";

                    NewField49 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 69, 34, 77, false);
                    NewField49.Name = "NewField49";
                    NewField49.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField49.TextFont.Name = "Arial Narrow";
                    NewField49.TextFont.Size = 9;
                    NewField49.TextFont.Bold = true;
                    NewField49.Value = @"Mesleği";

                    NewField58 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 77, 78, 85, false);
                    NewField58.Name = "NewField58";
                    NewField58.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField58.TextFont.Name = "Arial Narrow";
                    NewField58.TextFont.Size = 9;
                    NewField58.TextFont.Bold = true;
                    NewField58.Value = @"Adresi";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 31, 68, 36, false);
                    NewField28.Name = "NewField28";
                    NewField28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField28.TextFont.Name = "Arial Narrow";
                    NewField28.TextFont.Size = 9;
                    NewField28.TextFont.Bold = true;
                    NewField28.Value = @"Kadın";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 68, 185, 73, false);
                    NewField29.Name = "NewField29";
                    NewField29.Visible = EvetHayirEnum.ehHayir;
                    NewField29.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField29.TextFont.Name = "Arial Narrow";
                    NewField29.TextFont.Size = 9;
                    NewField29.TextFont.Bold = true;
                    NewField29.Value = @"Bekar";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 73, 185, 78, false);
                    NewField30.Name = "NewField30";
                    NewField30.Visible = EvetHayirEnum.ehHayir;
                    NewField30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField30.TextFont.Name = "Arial Narrow";
                    NewField30.TextFont.Size = 9;
                    NewField30.TextFont.Bold = true;
                    NewField30.Value = @"Evli";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 78, 185, 83, false);
                    NewField31.Name = "NewField31";
                    NewField31.Visible = EvetHayirEnum.ehHayir;
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.TextFont.Name = "Arial Narrow";
                    NewField31.TextFont.Size = 9;
                    NewField31.TextFont.Bold = true;
                    NewField31.Value = @"Dul";

                    ESEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 31, 53, 36, false);
                    ESEX.Name = "ESEX";
                    ESEX.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    ESEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    ESEX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ESEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ESEX.TextFont.Name = "Arial Narrow";
                    ESEX.TextFont.Size = 9;
                    ESEX.TextFont.Bold = true;
                    ESEX.Value = @"";

                    KSEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 31, 73, 36, false);
                    KSEX.Name = "KSEX";
                    KSEX.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    KSEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    KSEX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KSEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KSEX.TextFont.Name = "Arial Narrow";
                    KSEX.TextFont.Size = 9;
                    KSEX.TextFont.Bold = true;
                    KSEX.Value = @"";

                    BHAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 68, 191, 73, false);
                    BHAL.Name = "BHAL";
                    BHAL.Visible = EvetHayirEnum.ehHayir;
                    BHAL.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    BHAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BHAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BHAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BHAL.TextFont.Name = "Arial Narrow";
                    BHAL.TextFont.Size = 9;
                    BHAL.TextFont.Bold = true;
                    BHAL.Value = @"";

                    EHAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 73, 191, 78, false);
                    EHAL.Name = "EHAL";
                    EHAL.Visible = EvetHayirEnum.ehHayir;
                    EHAL.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    EHAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    EHAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EHAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EHAL.TextFont.Name = "Arial Narrow";
                    EHAL.TextFont.Size = 9;
                    EHAL.TextFont.Bold = true;
                    EHAL.Value = @"";

                    DHAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 78, 191, 83, false);
                    DHAL.Name = "DHAL";
                    DHAL.Visible = EvetHayirEnum.ehHayir;
                    DHAL.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    DHAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DHAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DHAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DHAL.TextFont.Name = "Arial Narrow";
                    DHAL.TextFont.Size = 9;
                    DHAL.TextFont.Bold = true;
                    DHAL.Value = @"";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 38, 205, 42, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#PATIENTBIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 42, 205, 46, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.ObjectDefName = "City";
                    DYER.DataMember = "NAME";
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#PATIENTCITYOFBIRTH#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 37, 78, 45, false);
                    AD.Name = "AD";
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AD.TextFont.Name = "Arial Narrow";
                    AD.TextFont.Size = 9;
                    AD.Value = @"{#PATIENTNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 53, 78, 61, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 9;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    DYERIDTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 61, 78, 69, false);
                    DYERIDTARIHI.Name = "DYERIDTARIHI";
                    DYERIDTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIDTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DYERIDTARIHI.TextFont.Name = "Arial Narrow";
                    DYERIDTARIHI.TextFont.Size = 9;
                    DYERIDTARIHI.Value = @"{%DTARIH%}";

                    DUHUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 76, 144, 84, false);
                    DUHUL.Name = "DUHUL";
                    DUHUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUHUL.TextFormat = @"Short Date";
                    DUHUL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DUHUL.TextFont.Name = "Arial Narrow";
                    DUHUL.TextFont.Size = 9;
                    DUHUL.Value = @"{#DEATHTIME#}";

                    MESLEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 69, 78, 77, false);
                    MESLEK.Name = "MESLEK";
                    MESLEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MESLEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MESLEK.TextFont.Name = "Arial Narrow";
                    MESLEK.TextFont.Size = 9;
                    MESLEK.Value = @"{#JOB#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 85, 78, 140, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.NoClip = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 9;
                    ADRES.Value = @"{#HOMEADDRESS#} {%HOMETOWN%} {%HOMECITY%} {%HOMECOUNTRY%}";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 34, 205, 38, false);
                    SEX.Name = "SEX";
                    SEX.Visible = EvetHayirEnum.ehHayir;
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"{#SEX#}";

                    MEDENIHAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 30, 205, 34, false);
                    MEDENIHAL.Name = "MEDENIHAL";
                    MEDENIHAL.Visible = EvetHayirEnum.ehHayir;
                    MEDENIHAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDENIHAL.TextFont.Name = "Arial Narrow";
                    MEDENIHAL.TextFont.Size = 9;
                    MEDENIHAL.Value = @"{#MARITALSTATUS#}";

                    HOMECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 54, 205, 58, false);
                    HOMECITY.Name = "HOMECITY";
                    HOMECITY.Visible = EvetHayirEnum.ehHayir;
                    HOMECITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMECITY.ObjectDefName = "City";
                    HOMECITY.DataMember = "NAME";
                    HOMECITY.TextFont.Name = "Arial Narrow";
                    HOMECITY.TextFont.Size = 9;
                    HOMECITY.Value = @"{#HOMECITY#}";

                    HOMECOUNTRY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 50, 205, 54, false);
                    HOMECOUNTRY.Name = "HOMECOUNTRY";
                    HOMECOUNTRY.Visible = EvetHayirEnum.ehHayir;
                    HOMECOUNTRY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMECOUNTRY.ObjectDefName = "Country";
                    HOMECOUNTRY.DataMember = "NAME";
                    HOMECOUNTRY.TextFont.Name = "Arial Narrow";
                    HOMECOUNTRY.TextFont.Size = 9;
                    HOMECOUNTRY.Value = @"{#HOMECOUNTRY#}";

                    HOMETOWN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 46, 205, 50, false);
                    HOMETOWN.Name = "HOMETOWN";
                    HOMETOWN.Visible = EvetHayirEnum.ehHayir;
                    HOMETOWN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMETOWN.ObjectDefName = "TownDefinitions";
                    HOMETOWN.DataMember = "NAME";
                    HOMETOWN.TextFont.Name = "Arial Narrow";
                    HOMETOWN.TextFont.Size = 9;
                    HOMETOWN.Value = @"{#HOMETOWN#}";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 45, 34, 53, false);
                    NewField155.Name = "NewField155";
                    NewField155.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField155.TextFont.Name = "Arial Narrow";
                    NewField155.TextFont.Size = 9;
                    NewField155.TextFont.Bold = true;
                    NewField155.Value = @"Soyadı";

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 45, 78, 53, false);
                    SOYAD.Name = "SOYAD";
                    SOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SOYAD.TextFont.Name = "Arial Narrow";
                    SOYAD.TextFont.Size = 9;
                    SOYAD.Value = @"{#PATIENTSURNAME#}";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 29, 34, 37, false);
                    NewField154.Name = "NewField154";
                    NewField154.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField154.TextFont.Name = "Arial Narrow";
                    NewField154.TextFont.Size = 9;
                    NewField154.TextFont.Bold = true;
                    NewField154.Value = @"Cinsiyeti";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 78, 14, 78, 144, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 3;

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 19, 142, 25, false);
                    NewField16.Name = "NewField16";
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"HASTALIK DURUMU";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 28, 100, 36, false);
                    NewField191.Name = "NewField191";
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"Hastalığın Adı";

                    HASTALIKADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 36, 144, 44, false);
                    HASTALIKADI1.Name = "HASTALIKADI1";
                    HASTALIKADI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTALIKADI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTALIKADI1.TextFont.Name = "Arial Narrow";
                    HASTALIKADI1.TextFont.Size = 9;
                    HASTALIKADI1.Value = @"{#ILLNESESNAME#} ";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 44, 130, 52, false);
                    NewField102.Name = "NewField102";
                    NewField102.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField102.TextFont.Name = "Arial Narrow";
                    NewField102.TextFont.Size = 9;
                    NewField102.TextFont.Bold = true;
                    NewField102.Value = @"Uluslararası Kod Numarası";

                    ULUSLARARASIKOD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 52, 144, 60, false);
                    ULUSLARARASIKOD1.Name = "ULUSLARARASIKOD1";
                    ULUSLARARASIKOD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ULUSLARARASIKOD1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ULUSLARARASIKOD1.TextFont.Name = "Arial Narrow";
                    ULUSLARARASIKOD1.TextFont.Size = 9;
                    ULUSLARARASIKOD1.Value = @"{#DIAGNOSISCODE#} - {#DIAGNOSISNAME#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 60, 106, 68, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"Başladığı Tarih";

                    BASLAMATARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 60, 144, 68, false);
                    BASLAMATARIHI1.Name = "BASLAMATARIHI1";
                    BASLAMATARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLAMATARIHI1.TextFormat = @"Short Date";
                    BASLAMATARIHI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLAMATARIHI1.TextFont.Name = "Arial Narrow";
                    BASLAMATARIHI1.TextFont.Size = 9;
                    BASLAMATARIHI1.Value = @"{#STARTTIMEOFINFECTIOUS#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 68, 106, 76, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Tanı Konduğu Tarih";

                    TANITARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 68, 144, 76, false);
                    TANITARIHI1.Name = "TANITARIHI1";
                    TANITARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANITARIHI1.TextFormat = @"Short Date";
                    TANITARIHI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANITARIHI1.TextFont.Name = "Arial Narrow";
                    TANITARIHI1.TextFont.Size = 9;
                    TANITARIHI1.Value = @"{#ACTIONDATE#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 113, 102, 121, false);
                    NewField162.Name = "NewField162";
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.Size = 9;
                    NewField162.TextFont.Bold = true;
                    NewField162.Value = @"Düşünceler";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 84, 144, 92, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Name = "Arial Narrow";
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.Value = @"Halen Yattığı Yerin Adresi";

                    XXXXXX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 92, 144, 112, false);
                    XXXXXX.Name = "XXXXXX";
                    XXXXXX.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXX.TextFormat = @"Short Date";
                    XXXXXX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXX.TextFont.Name = "Arial Narrow";
                    XXXXXX.TextFont.Size = 9;
                    XXXXXX.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") ";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 59, 205, 63, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSTATUS.TextFont.Name = "Arial Narrow";
                    PATIENTSTATUS.TextFont.Size = 9;
                    PATIENTSTATUS.Value = @"{#PATIENTSTATUS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class dataset_GetInfectiousIllnesesInformationNQL2 = ParentGroup.rsGroup.GetCurrentRecord<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class>(0);
                    NewField6.CalcValue = NewField6.Value;
                    NewField45.CalcValue = NewField45.Value;
                    NewField51.CalcValue = NewField51.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField49.CalcValue = NewField49.Value;
                    NewField58.CalcValue = NewField58.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField31.CalcValue = NewField31.Value;
                    ESEX.CalcValue = @"";
                    KSEX.CalcValue = @"";
                    BHAL.CalcValue = @"";
                    EHAL.CalcValue = @"";
                    DHAL.CalcValue = @"";
                    DTARIH.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Patientbirthdate) : "");
                    DYER.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Patientcityofbirth) : "");
                    DYER.PostFieldValueCalculation();
                    AD.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Patientname) : "");
                    BABAADI.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.FatherName) : "");
                    DYERIDTARIHI.CalcValue = MyParentReport.Arkasayfa.DTARIH.FormattedValue;
                    DUHUL.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.DeathTime) : "");
                    MESLEK.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Job) : "");
                    HOMETOWN.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Hometown) : "");
                    HOMETOWN.PostFieldValueCalculation();
                    HOMECITY.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Homecity) : "");
                    HOMECITY.PostFieldValueCalculation();
                    HOMECOUNTRY.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Homecountry) : "");
                    HOMECOUNTRY.PostFieldValueCalculation();
                    ADRES.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Homeaddress) : "") + @" " + MyParentReport.Arkasayfa.HOMETOWN.CalcValue + @" " + MyParentReport.Arkasayfa.HOMECITY.CalcValue + @" " + MyParentReport.Arkasayfa.HOMECOUNTRY.CalcValue;
                    SEX.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Sex) : "");
                    MEDENIHAL.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Maritalstatus) : "");
                    NewField155.CalcValue = NewField155.Value;
                    SOYAD.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Patientsurname) : "");
                    NewField154.CalcValue = NewField154.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField191.CalcValue = NewField191.Value;
                    HASTALIKADI1.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.IllnesesName) : "") + @" ";
                    NewField102.CalcValue = NewField102.Value;
                    ULUSLARARASIKOD1.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Diagnosiscode) : "") + @" - " + (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Diagnosisname) : "");
                    NewField112.CalcValue = NewField112.Value;
                    BASLAMATARIHI1.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.StartTimeOfInfectious) : "");
                    NewField122.CalcValue = NewField122.Value;
                    TANITARIHI1.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.ActionDate) : "");
                    NewField162.CalcValue = NewField162.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    PATIENTSTATUS.CalcValue = PATIENTSTATUS.Value;
                    XXXXXX.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") ;
                    return new TTReportObject[] { NewField6,NewField45,NewField51,NewField21,NewField24,NewField26,NewField49,NewField58,NewField28,NewField29,NewField30,NewField31,ESEX,KSEX,BHAL,EHAL,DHAL,DTARIH,DYER,AD,BABAADI,DYERIDTARIHI,DUHUL,MESLEK,HOMETOWN,HOMECITY,HOMECOUNTRY,ADRES,SEX,MEDENIHAL,NewField155,SOYAD,NewField154,NewField16,NewField191,HASTALIKADI1,NewField102,ULUSLARARASIKOD1,NewField112,BASLAMATARIHI1,NewField122,TANITARIHI1,NewField162,NewField1261,PATIENTSTATUS,XXXXXX};
                }

                public override void RunScript()
                {
#region ARKASAYFA HEADER_Script
                    //System.Diagnostics.Debugger.Break(); 
            if (this.SEX.CalcValue == "Male")
                this.ESEX.CalcValue = "X";
            else if(this.SEX.CalcValue == "Female")
                this.KSEX.CalcValue = "X";
            
            if(this.PATIENTSTATUS.CalcValue == "1")
                this.XXXXXX.Visible = EvetHayirEnum.ehEvet;
            else
                this.XXXXXX.Visible = EvetHayirEnum.ehHayir;
            

//            if (this.MEDENIHAL.CalcValue =="Single")
//                this.BHAL.CalcValue="X";
//            else
//                if(this.MEDENIHAL.CalcValue =="Married")
//                this.EHAL.CalcValue="X";
//            else
//                if(this.MEDENIHAL.CalcValue =="Widow" || this.MEDENIHAL.CalcValue =="Divorced")
//                this.DHAL.CalcValue="X";
#endregion ARKASAYFA HEADER_Script
                }
            }
            public partial class ArkasayfaGroupFooter : TTReportSection
            {
                public InfectiousIllnesesInformationReport MyParentReport
                {
                    get { return (InfectiousIllnesesInformationReport)ParentReport; }
                }
                 
                public ArkasayfaGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ArkasayfaGroup Arkasayfa;

        public partial class MAINGroup : TTReportGroup
        {
            public InfectiousIllnesesInformationReport MyParentReport
            {
                get { return (InfectiousIllnesesInformationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField PID { get {return Body().PID;} }
            public TTReportField RTARIH { get {return Body().RTARIH;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField UZMANLIKDAL { get {return Body().UZMANLIKDAL;} }
            public TTReportField RUTBEONAY { get {return Body().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Body().SINIFONAY;} }
            public TTReportField GOREV { get {return Body().GOREV;} }
            public TTReportField SICILNO { get {return Body().SICILNO;} }
            public TTReportField SICILKULLAN { get {return Body().SICILKULLAN;} }
            public TTReportField DIPLOMANO { get {return Body().DIPLOMANO;} }
            public TTReportField PROCEDUREDOCTOR { get {return Body().PROCEDUREDOCTOR;} }
            public TTReportField PROCEDUREDOCTORNAME { get {return Body().PROCEDUREDOCTORNAME;} }
            public TTReportField USERCLASSRANK { get {return Body().USERCLASSRANK;} }
            public TTReportField UZ { get {return Body().UZ;} }
            public TTReportField DIPSIC { get {return Body().DIPSIC;} }
            public TTReportField DIPSICLABEL { get {return Body().DIPSICLABEL;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
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
                public InfectiousIllnesesInformationReport MyParentReport
                {
                    get { return (InfectiousIllnesesInformationReport)ParentReport; }
                }
                
                public TTReportField ACTIONID;
                public TTReportField HASTANO;
                public TTReportField PID;
                public TTReportField RTARIH;
                public TTReportField NewField10;
                public TTReportField UZMANLIKDAL;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField GOREV;
                public TTReportField SICILNO;
                public TTReportField SICILKULLAN;
                public TTReportField DIPLOMANO;
                public TTReportField PROCEDUREDOCTOR;
                public TTReportField PROCEDUREDOCTORNAME;
                public TTReportField USERCLASSRANK;
                public TTReportField UZ;
                public TTReportField DIPSIC;
                public TTReportField DIPSICLABEL;
                public TTReportField NewField101; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 157;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 27, 194, 31, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONID.ObjectDefName = "InfectiousIllnesesInformation";
                    ACTIONID.DataMember = "ID";
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{@TTOBJECTID@}";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 31, 194, 35, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTANO.MultiLine = EvetHayirEnum.ehEvet;
                    HASTANO.NoClip = EvetHayirEnum.ehEvet;
                    HASTANO.WordBreak = EvetHayirEnum.ehEvet;
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.Value = @"";

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 23, 194, 27, false);
                    PID.Name = "PID";
                    PID.Visible = EvetHayirEnum.ehHayir;
                    PID.FillStyle = FillStyleConstants.vbFSTransparent;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.ObjectDefName = "Episode";
                    PID.DataMember = "PATIENT.ID";
                    PID.TextFont.Name = "Arial Narrow";
                    PID.TextFont.Size = 9;
                    PID.Value = @"{#Arkasayfa.EPISODE#}";

                    RTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 13, 137, 19, false);
                    RTARIH.Name = "RTARIH";
                    RTARIH.FieldType = ReportFieldTypeEnum.ftExpression;
                    RTARIH.TextFormat = @"Short Date";
                    RTARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RTARIH.MultiLine = EvetHayirEnum.ehEvet;
                    RTARIH.WordBreak = EvetHayirEnum.ehEvet;
                    RTARIH.TextFont.Name = "Arial Narrow";
                    RTARIH.TextFont.Size = 9;
                    RTARIH.TextFont.Bold = true;
                    RTARIH.Value = @"TTObjectClasses.Common.RecTime().ToString()";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 26, 119, 40, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 12;
                    NewField10.Value = @"BİLDİRİMİ ZORUNLU HASTALIKLAR FİŞİ
(U. Hıfzısıhha Kanunu Mad.57-64)";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 52, 194, 56, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 60, 194, 64, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 56, 194, 60, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 39, 194, 44, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 35, 194, 39, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 44, 194, 48, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 48, 194, 52, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"";

                    PROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 64, 194, 68, false);
                    PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
                    PROCEDUREDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTOR.TextFont.Name = "Arial Narrow";
                    PROCEDUREDOCTOR.TextFont.Size = 9;
                    PROCEDUREDOCTOR.Value = @"{#Arkasayfa.PROCEDUREDOCTOR#}";

                    PROCEDUREDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 116, 143, 120, false);
                    PROCEDUREDOCTORNAME.Name = "PROCEDUREDOCTORNAME";
                    PROCEDUREDOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTORNAME.TextFont.Name = "Arial Narrow";
                    PROCEDUREDOCTORNAME.TextFont.Size = 9;
                    PROCEDUREDOCTORNAME.Value = @"{#Arkasayfa.PROCEDUREDOCTORNAME#}";

                    USERCLASSRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 120, 143, 124, false);
                    USERCLASSRANK.Name = "USERCLASSRANK";
                    USERCLASSRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERCLASSRANK.TextFont.Name = "Arial Narrow";
                    USERCLASSRANK.TextFont.Size = 9;
                    USERCLASSRANK.Value = @"{#Arkasayfa.PROCEDUREDOCTORRANK#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 128, 143, 132, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{#Arkasayfa.PROCEDUREDOCTORSPECIALITY#}";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 124, 143, 128, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 124, 108, 128, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 51, 143, 98, false);
                    NewField101.Name = "NewField101";
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField101.TextFont.Name = "Arial Narrow";
                    NewField101.TextFont.Size = 12;
                    NewField101.Value = @"GÖNDERENİN

Adı Soyadı:
Mesleği:
Kurum Adresi:
İş Adresi:
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class dataset_GetInfectiousIllnesesInformationNQL2 = MyParentReport.Arkasayfa.rsGroup.GetCurrentRecord<InfectiousIllnesesInformation.GetInfectiousIllnesesInformationNQL_Class>(0);
                    ACTIONID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ACTIONID.PostFieldValueCalculation();
                    HASTANO.CalcValue = @"";
                    PID.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Episode) : "");
                    PID.PostFieldValueCalculation();
                    NewField10.CalcValue = NewField10.Value;
                    UZMANLIKDAL.CalcValue = @"";
                    RUTBEONAY.CalcValue = @"";
                    SINIFONAY.CalcValue = @"";
                    GOREV.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    SICILKULLAN.CalcValue = @"";
                    DIPLOMANO.CalcValue = @"";
                    PROCEDUREDOCTOR.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Proceduredoctor) : "");
                    PROCEDUREDOCTORNAME.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Proceduredoctorname) : "");
                    USERCLASSRANK.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Proceduredoctorrank) : "");
                    UZ.CalcValue = (dataset_GetInfectiousIllnesesInformationNQL2 != null ? Globals.ToStringCore(dataset_GetInfectiousIllnesesInformationNQL2.Proceduredoctorspeciality) : "");
                    DIPSIC.CalcValue = @"";
                    DIPSICLABEL.CalcValue = @"";
                    NewField101.CalcValue = NewField101.Value;
                    RTARIH.CalcValue = TTObjectClasses.Common.RecTime().ToString();
                    return new TTReportObject[] { ACTIONID,HASTANO,PID,NewField10,UZMANLIKDAL,RUTBEONAY,SINIFONAY,GOREV,SICILNO,SICILKULLAN,DIPLOMANO,PROCEDUREDOCTOR,PROCEDUREDOCTORNAME,USERCLASSRANK,UZ,DIPSIC,DIPSICLABEL,NewField101,RTARIH};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string procedureDoctorObjectID =  this.PROCEDUREDOCTOR.CalcValue;
            if (procedureDoctorObjectID != "")
            {
                ResUser procedureDoctor = (ResUser)objectContext.GetObject(new Guid(procedureDoctorObjectID),"ResUser");
                this.SINIFONAY.CalcValue = (procedureDoctor.MilitaryClass == null ? "" : procedureDoctor.MilitaryClass.Name);
                this.RUTBEONAY.CalcValue = (procedureDoctor.Rank == null ? "" : procedureDoctor.Rank.Name);
                //this.UZMANLIKDAL.CalcValue = procedureDoctor.;
                this.SICILNO.CalcValue = procedureDoctor.EmploymentRecordID;
                this.DIPLOMANO.CalcValue = procedureDoctor.DiplomaNo;
                this.GOREV.CalcValue = procedureDoctor.Work;
                
                if (TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN","TRUE").ToString() == "TRUE")
                {
                    this.DIPSICLABEL.CalcValue = "SİCİL NO :";
                    this.DIPSIC.CalcValue = procedureDoctor.EmploymentRecordID;
                }
                else
                {
                    this.DIPSICLABEL.CalcValue = "DİPLOMA NO :";
                    this.DIPSIC.CalcValue = procedureDoctor.DiplomaNo;
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

        public InfectiousIllnesesInformationReport()
        {
            Arkasayfa = new ArkasayfaGroup(this,"Arkasayfa");
            MAIN = new MAINGroup(Arkasayfa,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Bulaşıcı ve Bildirimi Zorunlu Hastalıklar", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INFECTIOUSILLNESESINFORMATIONREPORT";
            Caption = "Bulaşıcı ve Bildirimi Zorunlu Hastalıklar Bildirim Fişi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 11;
            p_PageWidth = 148;
            p_PageHeight = 210;
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