
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
    /// Beş Yıllık Uçucu Muayene Fişi A4(Arkalı-Önlü)
    /// </summary>
    public partial class HCEFlierSlipReportForFiveYears : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("C7203EFB-0742-4709-9E32-6D3608F9C34F");
        }

        public partial class ArkasayfaGroup : TTReportGroup
        {
            public HCEFlierSlipReportForFiveYears MyParentReport
            {
                get { return (HCEFlierSlipReportForFiveYears)ParentReport; }
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
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportShape NewLine20 { get {return Header().NewLine20;} }
            public TTReportShape NewLine21 { get {return Header().NewLine21;} }
            public TTReportShape NewLine22 { get {return Header().NewLine22;} }
            public TTReportShape NewLine102 { get {return Header().NewLine102;} }
            public TTReportField BoyLbl11 { get {return Header().BoyLbl11;} }
            public TTReportField BoyLbl13 { get {return Header().BoyLbl13;} }
            public TTReportField BoyLbl12111 { get {return Header().BoyLbl12111;} }
            public TTReportField BoyLbl11121 { get {return Header().BoyLbl11121;} }
            public TTReportField BoyLbl111121 { get {return Header().BoyLbl111121;} }
            public TTReportField BoyLbl112111 { get {return Header().BoyLbl112111;} }
            public TTReportField BoyLbl12 { get {return Header().BoyLbl12;} }
            public TTReportField BoyLbl121 { get {return Header().BoyLbl121;} }
            public TTReportField BoyLbl1121111 { get {return Header().BoyLbl1121111;} }
            public TTReportField BoyLbl1111211 { get {return Header().BoyLbl1111211;} }
            public TTReportField BoyLbl1121 { get {return Header().BoyLbl1121;} }
            public TTReportField BoyLbl122 { get {return Header().BoyLbl122;} }
            public TTReportField BoyLbl1221 { get {return Header().BoyLbl1221;} }
            public TTReportField BoyLbl1222 { get {return Header().BoyLbl1222;} }
            public TTReportField BoyLbl1223 { get {return Header().BoyLbl1223;} }
            public TTReportField BoyLbl1225 { get {return Header().BoyLbl1225;} }
            public TTReportField BoyLbl12111211 { get {return Header().BoyLbl12111211;} }
            public TTReportShape NewLine19 { get {return Header().NewLine19;} }
            public TTReportField BoyLbl12112111 { get {return Header().BoyLbl12112111;} }
            public TTReportShape NewLine191 { get {return Header().NewLine191;} }
            public TTReportShape NewLine192 { get {return Header().NewLine192;} }
            public TTReportField BoyLbl111121121 { get {return Header().BoyLbl111121121;} }
            public TTReportField BoyLbl1121121111 { get {return Header().BoyLbl1121121111;} }
            public TTReportField BoyLbl111121122 { get {return Header().BoyLbl111121122;} }
            public TTReportShape NewLine171 { get {return Header().NewLine171;} }
            public TTReportShape NewLine1171 { get {return Header().NewLine1171;} }
            public TTReportField BoyLbl11121111 { get {return Header().BoyLbl11121111;} }
            public TTReportField BoyLbl11111211 { get {return Header().BoyLbl11111211;} }
            public TTReportShape NewLine193 { get {return Header().NewLine193;} }
            public TTReportField BoyLbl12112112 { get {return Header().BoyLbl12112112;} }
            public TTReportField BoyLbl121121121 { get {return Header().BoyLbl121121121;} }
            public TTReportField BoyLbl1121121121 { get {return Header().BoyLbl1121121121;} }
            public TTReportField BoyLbl11211211211 { get {return Header().BoyLbl11211211211;} }
            public TTReportShape NewLine1191 { get {return Header().NewLine1191;} }
            public TTReportShape NewLine11911 { get {return Header().NewLine11911;} }
            public TTReportShape NewLine11912 { get {return Header().NewLine11912;} }
            public TTReportShape NewLine11913 { get {return Header().NewLine11913;} }
            public TTReportShape NewLine11914 { get {return Header().NewLine11914;} }
            public TTReportShape NewLine11915 { get {return Header().NewLine11915;} }
            public TTReportShape NewLine11916 { get {return Header().NewLine11916;} }
            public TTReportShape NewLine161911 { get {return Header().NewLine161911;} }
            public TTReportField BoyLbl1121121112 { get {return Header().BoyLbl1121121112;} }
            public TTReportField BoyLbl12111211211 { get {return Header().BoyLbl12111211211;} }
            public TTReportField BoyLbl1 { get {return Header().BoyLbl1;} }
            public TTReportField BoyLbl14 { get {return Header().BoyLbl14;} }
            public TTReportField BoyLbl15 { get {return Header().BoyLbl15;} }
            public TTReportField BoyLbl16 { get {return Header().BoyLbl16;} }
            public TTReportField BoyLbl17 { get {return Header().BoyLbl17;} }
            public TTReportShape NewLine1172 { get {return Header().NewLine1172;} }
            public TTReportField BoyLbl171 { get {return Header().BoyLbl171;} }
            public TTReportField BoyLbl161 { get {return Header().BoyLbl161;} }
            public TTReportField BoyLbl2 { get {return Header().BoyLbl2;} }
            public TTReportField BoyLbl18 { get {return Header().BoyLbl18;} }
            public TTReportField BoyLbl19 { get {return Header().BoyLbl19;} }
            public TTReportField BoyLbl20 { get {return Header().BoyLbl20;} }
            public TTReportField BoyLbl21 { get {return Header().BoyLbl21;} }
            public TTReportField BoyLbl22 { get {return Header().BoyLbl22;} }
            public TTReportField BoyLbl24 { get {return Header().BoyLbl24;} }
            public TTReportField BoyLbl172 { get {return Header().BoyLbl172;} }
            public TTReportField BoyLbl173 { get {return Header().BoyLbl173;} }
            public TTReportShape NewLine1173 { get {return Header().NewLine1173;} }
            public TTReportField BoyLbl23 { get {return Header().BoyLbl23;} }
            public TTReportField BoyLbl181 { get {return Header().BoyLbl181;} }
            public TTReportField BoyLbl191 { get {return Header().BoyLbl191;} }
            public TTReportField BoyLbl102 { get {return Header().BoyLbl102;} }
            public TTReportField BoyLbl112 { get {return Header().BoyLbl112;} }
            public TTReportField BoyLbl123 { get {return Header().BoyLbl123;} }
            public TTReportField BoyLbl142 { get {return Header().BoyLbl142;} }
            public TTReportField BoyLbl1271 { get {return Header().BoyLbl1271;} }
            public TTReportField BoyLbl25 { get {return Header().BoyLbl25;} }
            public TTReportField BoyLbl182 { get {return Header().BoyLbl182;} }
            public TTReportField BoyLbl192 { get {return Header().BoyLbl192;} }
            public TTReportField BoyLbl103 { get {return Header().BoyLbl103;} }
            public TTReportField BoyLbl113 { get {return Header().BoyLbl113;} }
            public TTReportField BoyLbl124 { get {return Header().BoyLbl124;} }
            public TTReportField BoyLbl143 { get {return Header().BoyLbl143;} }
            public TTReportShape NewLine1174 { get {return Header().NewLine1174;} }
            public TTReportShape NewLine14711 { get {return Header().NewLine14711;} }
            public TTReportShape NewLine111741 { get {return Header().NewLine111741;} }
            public TTReportField BoyLbl152 { get {return Header().BoyLbl152;} }
            public TTReportField BoyLbl1251 { get {return Header().BoyLbl1251;} }
            public TTReportField BoyLbl1252 { get {return Header().BoyLbl1252;} }
            public TTReportShape NewLine1147111 { get {return Header().NewLine1147111;} }
            public TTReportField BoyLbl111112111 { get {return Header().BoyLbl111112111;} }
            public TTReportField BoyLbl111211121 { get {return Header().BoyLbl111211121;} }
            public TTReportField BoyLbl12221 { get {return Header().BoyLbl12221;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField BoyLbl1111211111 { get {return Header().BoyLbl1111211111;} }
            public TTReportField BoyLbl1111211112 { get {return Header().BoyLbl1111211112;} }
            public TTReportShape NewLine13711 { get {return Header().NewLine13711;} }
            public TTReportField BoyLbl12111121111 { get {return Header().BoyLbl12111121111;} }
            public TTReportField BoyLbl1111211113 { get {return Header().BoyLbl1111211113;} }
            public TTReportField BoyLbl13111121111 { get {return Header().BoyLbl13111121111;} }
            public TTReportField BoyLbl3 { get {return Header().BoyLbl3;} }
            public TTReportField BoyLbl26 { get {return Header().BoyLbl26;} }
            public TTReportField BoyLbl4 { get {return Header().BoyLbl4;} }
            public TTReportField BoyLbl111112111131 { get {return Header().BoyLbl111112111131;} }
            public TTReportField BoyLbl27 { get {return Header().BoyLbl27;} }
            public TTReportField BoyLbl162 { get {return Header().BoyLbl162;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField BoyLbl125 { get {return Header().BoyLbl125;} }
            public TTReportField BoyLbl112112 { get {return Header().BoyLbl112112;} }
            public TTReportField BoyLbl111122 { get {return Header().BoyLbl111122;} }
            public ArkasayfaGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ArkasayfaGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ArkasayfaGroupHeader(this);
                _footer = new ArkasayfaGroupFooter(this);

            }

            public partial class ArkasayfaGroupHeader : TTReportSection
            {
                public HCEFlierSlipReportForFiveYears MyParentReport
                {
                    get { return (HCEFlierSlipReportForFiveYears)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine102;
                public TTReportField BoyLbl11;
                public TTReportField BoyLbl13;
                public TTReportField BoyLbl12111;
                public TTReportField BoyLbl11121;
                public TTReportField BoyLbl111121;
                public TTReportField BoyLbl112111;
                public TTReportField BoyLbl12;
                public TTReportField BoyLbl121;
                public TTReportField BoyLbl1121111;
                public TTReportField BoyLbl1111211;
                public TTReportField BoyLbl1121;
                public TTReportField BoyLbl122;
                public TTReportField BoyLbl1221;
                public TTReportField BoyLbl1222;
                public TTReportField BoyLbl1223;
                public TTReportField BoyLbl1225;
                public TTReportField BoyLbl12111211;
                public TTReportShape NewLine19;
                public TTReportField BoyLbl12112111;
                public TTReportShape NewLine191;
                public TTReportShape NewLine192;
                public TTReportField BoyLbl111121121;
                public TTReportField BoyLbl1121121111;
                public TTReportField BoyLbl111121122;
                public TTReportShape NewLine171;
                public TTReportShape NewLine1171;
                public TTReportField BoyLbl11121111;
                public TTReportField BoyLbl11111211;
                public TTReportShape NewLine193;
                public TTReportField BoyLbl12112112;
                public TTReportField BoyLbl121121121;
                public TTReportField BoyLbl1121121121;
                public TTReportField BoyLbl11211211211;
                public TTReportShape NewLine1191;
                public TTReportShape NewLine11911;
                public TTReportShape NewLine11912;
                public TTReportShape NewLine11913;
                public TTReportShape NewLine11914;
                public TTReportShape NewLine11915;
                public TTReportShape NewLine11916;
                public TTReportShape NewLine161911;
                public TTReportField BoyLbl1121121112;
                public TTReportField BoyLbl12111211211;
                public TTReportField BoyLbl1;
                public TTReportField BoyLbl14;
                public TTReportField BoyLbl15;
                public TTReportField BoyLbl16;
                public TTReportField BoyLbl17;
                public TTReportShape NewLine1172;
                public TTReportField BoyLbl171;
                public TTReportField BoyLbl161;
                public TTReportField BoyLbl2;
                public TTReportField BoyLbl18;
                public TTReportField BoyLbl19;
                public TTReportField BoyLbl20;
                public TTReportField BoyLbl21;
                public TTReportField BoyLbl22;
                public TTReportField BoyLbl24;
                public TTReportField BoyLbl172;
                public TTReportField BoyLbl173;
                public TTReportShape NewLine1173;
                public TTReportField BoyLbl23;
                public TTReportField BoyLbl181;
                public TTReportField BoyLbl191;
                public TTReportField BoyLbl102;
                public TTReportField BoyLbl112;
                public TTReportField BoyLbl123;
                public TTReportField BoyLbl142;
                public TTReportField BoyLbl1271;
                public TTReportField BoyLbl25;
                public TTReportField BoyLbl182;
                public TTReportField BoyLbl192;
                public TTReportField BoyLbl103;
                public TTReportField BoyLbl113;
                public TTReportField BoyLbl124;
                public TTReportField BoyLbl143;
                public TTReportShape NewLine1174;
                public TTReportShape NewLine14711;
                public TTReportShape NewLine111741;
                public TTReportField BoyLbl152;
                public TTReportField BoyLbl1251;
                public TTReportField BoyLbl1252;
                public TTReportShape NewLine1147111;
                public TTReportField BoyLbl111112111;
                public TTReportField BoyLbl111211121;
                public TTReportField BoyLbl12221;
                public TTReportShape NewLine121;
                public TTReportField BoyLbl1111211111;
                public TTReportField BoyLbl1111211112;
                public TTReportShape NewLine13711;
                public TTReportField BoyLbl12111121111;
                public TTReportField BoyLbl1111211113;
                public TTReportField BoyLbl13111121111;
                public TTReportField BoyLbl3;
                public TTReportField BoyLbl26;
                public TTReportField BoyLbl4;
                public TTReportField BoyLbl111112111131;
                public TTReportField BoyLbl27;
                public TTReportField BoyLbl162;
                public TTReportShape NewLine1;
                public TTReportField BoyLbl125;
                public TTReportField BoyLbl112112;
                public TTReportField BoyLbl111122; 
                public ArkasayfaGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 281;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 22, 199, 22, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 6, 199, 276, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 276, 199, 276, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 39, 7, 155, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 122, 7, 276, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 71, 199, 71, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 55, 199, 55, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 194, 199, 194, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 215, 199, 215, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 231, 199, 231, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 6, 31, 276, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 7, 42, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 95, 199, 95, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 177, 199, 177, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 38, 199, 38, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine102 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 161, 199, 161, false);
                    NewLine102.Name = "NewLine102";
                    NewLine102.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 28, 34, false);
                    BoyLbl11.Name = "BoyLbl11";
                    BoyLbl11.MultiLine = EvetHayirEnum.ehEvet;
                    BoyLbl11.NoClip = EvetHayirEnum.ehEvet;
                    BoyLbl11.WordBreak = EvetHayirEnum.ehEvet;
                    BoyLbl11.ExpandTabs = EvetHayirEnum.ehEvet;
                    BoyLbl11.TextFont.Name = "Arial Narrow";
                    BoyLbl11.TextFont.Size = 9;
                    BoyLbl11.Value = @"KADIN
DOĞUM";

                    BoyLbl13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 59, 28, 68, false);
                    BoyLbl13.Name = "BoyLbl13";
                    BoyLbl13.MultiLine = EvetHayirEnum.ehEvet;
                    BoyLbl13.NoClip = EvetHayirEnum.ehEvet;
                    BoyLbl13.WordBreak = EvetHayirEnum.ehEvet;
                    BoyLbl13.ExpandTabs = EvetHayirEnum.ehEvet;
                    BoyLbl13.TextFont.Name = "Arial Narrow";
                    BoyLbl13.TextFont.Size = 9;
                    BoyLbl13.Value = @"GENEL
CERRAHİ";

                    BoyLbl12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 32, 198, 37, false);
                    BoyLbl12111.Name = "BoyLbl12111";
                    BoyLbl12111.TextFont.Name = "Arial Narrow";
                    BoyLbl12111.TextFont.Size = 9;
                    BoyLbl12111.Value = @"İmza";

                    BoyLbl11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 23, 52, 28, false);
                    BoyLbl11121.Name = "BoyLbl11121";
                    BoyLbl11121.TextFont.Name = "Arial Narrow";
                    BoyLbl11121.TextFont.Size = 9;
                    BoyLbl11121.Value = @"Bulguların Özeti";

                    BoyLbl111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 49, 198, 54, false);
                    BoyLbl111121.Name = "BoyLbl111121";
                    BoyLbl111121.TextFont.Name = "Arial Narrow";
                    BoyLbl111121.TextFont.Size = 9;
                    BoyLbl111121.Value = @"İmza";

                    BoyLbl112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 39, 52, 44, false);
                    BoyLbl112111.Name = "BoyLbl112111";
                    BoyLbl112111.TextFont.Name = "Arial Narrow";
                    BoyLbl112111.TextFont.Size = 9;
                    BoyLbl112111.Value = @"Bulguların Özeti";

                    BoyLbl12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 44, 28, 49, false);
                    BoyLbl12.Name = "BoyLbl12";
                    BoyLbl12.TextFont.Name = "Arial Narrow";
                    BoyLbl12.TextFont.Size = 9;
                    BoyLbl12.Value = @"ÜROLOJİ";

                    BoyLbl121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 81, 28, 86, false);
                    BoyLbl121.Name = "BoyLbl121";
                    BoyLbl121.TextFont.Name = "Arial Narrow";
                    BoyLbl121.TextFont.Size = 9;
                    BoyLbl121.Value = @"RADYOLOJİ";

                    BoyLbl1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 65, 198, 70, false);
                    BoyLbl1121111.Name = "BoyLbl1121111";
                    BoyLbl1121111.TextFont.Name = "Arial Narrow";
                    BoyLbl1121111.TextFont.Size = 9;
                    BoyLbl1121111.Value = @"İmza";

                    BoyLbl1111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 56, 52, 61, false);
                    BoyLbl1111211.Name = "BoyLbl1111211";
                    BoyLbl1111211.TextFont.Name = "Arial Narrow";
                    BoyLbl1111211.TextFont.Size = 9;
                    BoyLbl1111211.Value = @"Bulguların Özeti";

                    BoyLbl1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 121, 30, 133, false);
                    BoyLbl1121.Name = "BoyLbl1121";
                    BoyLbl1121.MultiLine = EvetHayirEnum.ehEvet;
                    BoyLbl1121.NoClip = EvetHayirEnum.ehEvet;
                    BoyLbl1121.WordBreak = EvetHayirEnum.ehEvet;
                    BoyLbl1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    BoyLbl1121.TextFont.Name = "Arial Narrow";
                    BoyLbl1121.TextFont.Size = 9;
                    BoyLbl1121.Value = @"BİYOKİMYA /
MİKROBİYOLOJİ";

                    BoyLbl122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 167, 28, 172, false);
                    BoyLbl122.Name = "BoyLbl122";
                    BoyLbl122.TextFont.Name = "Arial Narrow";
                    BoyLbl122.TextFont.Size = 9;
                    BoyLbl122.Value = @"DİĞER";

                    BoyLbl1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 183, 28, 188, false);
                    BoyLbl1221.Name = "BoyLbl1221";
                    BoyLbl1221.TextFont.Name = "Arial Narrow";
                    BoyLbl1221.TextFont.Size = 9;
                    BoyLbl1221.Value = @"RAPOR";

                    BoyLbl1222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 202, 28, 207, false);
                    BoyLbl1222.Name = "BoyLbl1222";
                    BoyLbl1222.TextFont.Name = "Arial Narrow";
                    BoyLbl1222.TextFont.Size = 9;
                    BoyLbl1222.Value = @"TANI";

                    BoyLbl1223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 221, 28, 226, false);
                    BoyLbl1223.Name = "BoyLbl1223";
                    BoyLbl1223.TextFont.Name = "Arial Narrow";
                    BoyLbl1223.TextFont.Size = 9;
                    BoyLbl1223.Value = @"KARAR";

                    BoyLbl1225 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 251, 28, 256, false);
                    BoyLbl1225.Name = "BoyLbl1225";
                    BoyLbl1225.TextFont.Name = "Arial Narrow";
                    BoyLbl1225.TextFont.Size = 9;
                    BoyLbl1225.Value = @"ONAY";

                    BoyLbl12111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 188, 198, 193, false);
                    BoyLbl12111211.Name = "BoyLbl12111211";
                    BoyLbl12111211.TextFont.Name = "Arial Narrow";
                    BoyLbl12111211.TextFont.Size = 9;
                    BoyLbl12111211.Value = @"İmza";

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 76, 90, 76, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl12112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 71, 62, 76, false);
                    BoyLbl12112111.Name = "BoyLbl12112111";
                    BoyLbl12112111.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl12112111.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl12112111.TextFont.Name = "Arial Narrow";
                    BoyLbl12112111.TextFont.Size = 9;
                    BoyLbl12112111.Value = @" 2 Yönlü Akciğer Grafisi";

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 81, 90, 81, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine192 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 90, 90, 90, false);
                    NewLine192.Name = "NewLine192";
                    NewLine192.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl111121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 76, 62, 81, false);
                    BoyLbl111121121.Name = "BoyLbl111121121";
                    BoyLbl111121121.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl111121121.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl111121121.TextFont.Name = "Arial Narrow";
                    BoyLbl111121121.TextFont.Size = 9;
                    BoyLbl111121121.Value = @" Ön Sinüs Grafisi";

                    BoyLbl1121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 81, 62, 90, false);
                    BoyLbl1121121111.Name = "BoyLbl1121121111";
                    BoyLbl1121121111.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1121121111.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1121121111.MultiLine = EvetHayirEnum.ehEvet;
                    BoyLbl1121121111.NoClip = EvetHayirEnum.ehEvet;
                    BoyLbl1121121111.WordBreak = EvetHayirEnum.ehEvet;
                    BoyLbl1121121111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BoyLbl1121121111.TextFont.Name = "Arial Narrow";
                    BoyLbl1121121111.TextFont.Size = 9;
                    BoyLbl1121121111.Value = @" 4 Yönlü Lumbosasakral
 Grafi";

                    BoyLbl111121122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 90, 62, 95, false);
                    BoyLbl111121122.Name = "BoyLbl111121122";
                    BoyLbl111121122.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl111121122.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl111121122.TextFont.Name = "Arial Narrow";
                    BoyLbl111121122.TextFont.Size = 9;
                    BoyLbl111121122.Value = @" Batın USG";

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 76, 71, 76, 95, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 90, 71, 90, 95, false);
                    NewLine1171.Name = "NewLine1171";
                    NewLine1171.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 72, 111, 77, false);
                    BoyLbl11121111.Name = "BoyLbl11121111";
                    BoyLbl11121111.TextFont.Name = "Arial Narrow";
                    BoyLbl11121111.TextFont.Size = 9;
                    BoyLbl11121111.Value = @"Bulguların Özeti";

                    BoyLbl11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 89, 198, 94, false);
                    BoyLbl11111211.Name = "BoyLbl11111211";
                    BoyLbl11111211.TextFont.Name = "Arial Narrow";
                    BoyLbl11111211.TextFont.Size = 9;
                    BoyLbl11111211.Value = @"İmza";

                    NewLine193 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 101, 199, 101, false);
                    NewLine193.Name = "NewLine193";
                    NewLine193.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl12112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 95, 71, 101, false);
                    BoyLbl12112112.Name = "BoyLbl12112112";
                    BoyLbl12112112.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl12112112.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl12112112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl12112112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl12112112.TextFont.Name = "Arial Narrow";
                    BoyLbl12112112.TextFont.Size = 9;
                    BoyLbl12112112.Value = @"TAM KAN";

                    BoyLbl121121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 95, 111, 101, false);
                    BoyLbl121121121.Name = "BoyLbl121121121";
                    BoyLbl121121121.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl121121121.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl121121121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl121121121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl121121121.TextFont.Name = "Arial Narrow";
                    BoyLbl121121121.TextFont.Size = 9;
                    BoyLbl121121121.Value = @"TAM İDRAR";

                    BoyLbl1121121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 95, 173, 101, false);
                    BoyLbl1121121121.Name = "BoyLbl1121121121";
                    BoyLbl1121121121.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1121121121.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1121121121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1121121121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl1121121121.TextFont.Name = "Arial Narrow";
                    BoyLbl1121121121.TextFont.Size = 9;
                    BoyLbl1121121121.Value = @"BİYOKİMYA";

                    BoyLbl11211211211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 95, 199, 101, false);
                    BoyLbl11211211211.Name = "BoyLbl11211211211";
                    BoyLbl11211211211.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl11211211211.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl11211211211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl11211211211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl11211211211.TextFont.Name = "Arial Narrow";
                    BoyLbl11211211211.TextFont.Size = 9;
                    BoyLbl11211211211.Value = @"SEROLOJİ";

                    NewLine1191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 106, 173, 106, false);
                    NewLine1191.Name = "NewLine1191";
                    NewLine1191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11911 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 111, 199, 111, false);
                    NewLine11911.Name = "NewLine11911";
                    NewLine11911.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11912 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 116, 173, 116, false);
                    NewLine11912.Name = "NewLine11912";
                    NewLine11912.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11913 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 121, 199, 121, false);
                    NewLine11913.Name = "NewLine11913";
                    NewLine11913.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11914 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 126, 173, 126, false);
                    NewLine11914.Name = "NewLine11914";
                    NewLine11914.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11915 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 131, 199, 131, false);
                    NewLine11915.Name = "NewLine11915";
                    NewLine11915.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11916 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 136, 199, 136, false);
                    NewLine11916.Name = "NewLine11916";
                    NewLine11916.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161911 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 144, 199, 144, false);
                    NewLine161911.Name = "NewLine161911";
                    NewLine161911.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl1121121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 101, 49, 106, false);
                    BoyLbl1121121112.Name = "BoyLbl1121121112";
                    BoyLbl1121121112.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1121121112.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1121121112.TextFont.Name = "Arial Narrow";
                    BoyLbl1121121112.TextFont.Size = 9;
                    BoyLbl1121121112.Value = @"Eritrosit";

                    BoyLbl12111211211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 106, 49, 111, false);
                    BoyLbl12111211211.Name = "BoyLbl12111211211";
                    BoyLbl12111211211.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl12111211211.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl12111211211.TextFont.Name = "Arial Narrow";
                    BoyLbl12111211211.TextFont.Size = 9;
                    BoyLbl12111211211.Value = @"Hematokrit";

                    BoyLbl1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 111, 49, 116, false);
                    BoyLbl1.Name = "BoyLbl1";
                    BoyLbl1.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1.TextFont.Name = "Arial Narrow";
                    BoyLbl1.TextFont.Size = 9;
                    BoyLbl1.Value = @"Hemoglobin";

                    BoyLbl14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 116, 49, 121, false);
                    BoyLbl14.Name = "BoyLbl14";
                    BoyLbl14.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl14.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl14.TextFont.Name = "Arial Narrow";
                    BoyLbl14.TextFont.Size = 9;
                    BoyLbl14.Value = @"Plt";

                    BoyLbl15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 121, 49, 126, false);
                    BoyLbl15.Name = "BoyLbl15";
                    BoyLbl15.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl15.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl15.TextFont.Name = "Arial Narrow";
                    BoyLbl15.TextFont.Size = 9;
                    BoyLbl15.Value = @"Lökosit";

                    BoyLbl16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 126, 49, 136, false);
                    BoyLbl16.Name = "BoyLbl16";
                    BoyLbl16.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl16.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl16.TextFont.Name = "Arial Narrow";
                    BoyLbl16.TextFont.Size = 9;
                    BoyLbl16.Value = @"Sedim 1 saat";

                    BoyLbl17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 136, 49, 144, false);
                    BoyLbl17.Name = "BoyLbl17";
                    BoyLbl17.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl17.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl17.TextFont.Name = "Arial Narrow";
                    BoyLbl17.TextFont.Size = 9;
                    BoyLbl17.Value = @"Segment";

                    NewLine1172 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 101, 71, 144, false);
                    NewLine1172.Name = "NewLine1172";
                    NewLine1172.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 136, 71, 144, false);
                    BoyLbl171.Name = "BoyLbl171";
                    BoyLbl171.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl171.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl171.TextFont.Name = "Arial Narrow";
                    BoyLbl171.TextFont.Size = 9;
                    BoyLbl171.Value = @" Lenfosit";

                    BoyLbl161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 126, 71, 136, false);
                    BoyLbl161.Name = "BoyLbl161";
                    BoyLbl161.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl161.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl161.TextFont.Name = "Arial Narrow";
                    BoyLbl161.TextFont.Size = 9;
                    BoyLbl161.Value = @" (                ) mm";

                    BoyLbl2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 101, 89, 106, false);
                    BoyLbl2.Name = "BoyLbl2";
                    BoyLbl2.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl2.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl2.TextFont.Name = "Arial Narrow";
                    BoyLbl2.TextFont.Size = 9;
                    BoyLbl2.Value = @"Dansite";

                    BoyLbl18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 106, 89, 111, false);
                    BoyLbl18.Name = "BoyLbl18";
                    BoyLbl18.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl18.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl18.TextFont.Name = "Arial Narrow";
                    BoyLbl18.TextFont.Size = 9;
                    BoyLbl18.Value = @"Protein";

                    BoyLbl19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 111, 89, 116, false);
                    BoyLbl19.Name = "BoyLbl19";
                    BoyLbl19.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl19.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl19.TextFont.Name = "Arial Narrow";
                    BoyLbl19.TextFont.Size = 9;
                    BoyLbl19.Value = @"Glukoz";

                    BoyLbl20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 116, 89, 121, false);
                    BoyLbl20.Name = "BoyLbl20";
                    BoyLbl20.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl20.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl20.TextFont.Name = "Arial Narrow";
                    BoyLbl20.TextFont.Size = 9;
                    BoyLbl20.Value = @"Bilirübin";

                    BoyLbl21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 121, 89, 126, false);
                    BoyLbl21.Name = "BoyLbl21";
                    BoyLbl21.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl21.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl21.TextFont.Name = "Arial Narrow";
                    BoyLbl21.TextFont.Size = 9;
                    BoyLbl21.Value = @"Ürobilinojen";

                    BoyLbl22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 126, 89, 131, false);
                    BoyLbl22.Name = "BoyLbl22";
                    BoyLbl22.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl22.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl22.TextFont.Name = "Arial Narrow";
                    BoyLbl22.TextFont.Size = 9;
                    BoyLbl22.Value = @"Hemoglobin";

                    BoyLbl24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 131, 89, 136, false);
                    BoyLbl24.Name = "BoyLbl24";
                    BoyLbl24.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl24.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl24.TextFont.Name = "Arial Narrow";
                    BoyLbl24.TextFont.Size = 9;
                    BoyLbl24.Value = @"Mikroskopi";

                    BoyLbl172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 136, 89, 144, false);
                    BoyLbl172.Name = "BoyLbl172";
                    BoyLbl172.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl172.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl172.TextFont.Name = "Arial Narrow";
                    BoyLbl172.TextFont.Size = 9;
                    BoyLbl172.Value = @"Eozinofil";

                    BoyLbl173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 136, 111, 144, false);
                    BoyLbl173.Name = "BoyLbl173";
                    BoyLbl173.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl173.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl173.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl173.TextFont.Name = "Arial Narrow";
                    BoyLbl173.TextFont.Size = 9;
                    BoyLbl173.Value = @" Monosit";

                    NewLine1173 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 111, 101, 111, 161, false);
                    NewLine1173.Name = "NewLine1173";
                    NewLine1173.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 101, 129, 106, false);
                    BoyLbl23.Name = "BoyLbl23";
                    BoyLbl23.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl23.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl23.TextFont.Name = "Arial Narrow";
                    BoyLbl23.TextFont.Size = 9;
                    BoyLbl23.Value = @"A.K.Ş.";

                    BoyLbl181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 106, 129, 111, false);
                    BoyLbl181.Name = "BoyLbl181";
                    BoyLbl181.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl181.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl181.TextFont.Name = "Arial Narrow";
                    BoyLbl181.TextFont.Size = 9;
                    BoyLbl181.Value = @"Azotemi";

                    BoyLbl191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 111, 129, 116, false);
                    BoyLbl191.Name = "BoyLbl191";
                    BoyLbl191.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl191.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl191.TextFont.Name = "Arial Narrow";
                    BoyLbl191.TextFont.Size = 9;
                    BoyLbl191.Value = @"Kolesterol";

                    BoyLbl102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 116, 129, 121, false);
                    BoyLbl102.Name = "BoyLbl102";
                    BoyLbl102.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl102.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl102.TextFont.Name = "Arial Narrow";
                    BoyLbl102.TextFont.Size = 9;
                    BoyLbl102.Value = @"Trigliserid";

                    BoyLbl112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 121, 129, 126, false);
                    BoyLbl112.Name = "BoyLbl112";
                    BoyLbl112.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl112.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl112.TextFont.Name = "Arial Narrow";
                    BoyLbl112.TextFont.Size = 9;
                    BoyLbl112.Value = @"LDL";

                    BoyLbl123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 126, 129, 131, false);
                    BoyLbl123.Name = "BoyLbl123";
                    BoyLbl123.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl123.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl123.TextFont.Name = "Arial Narrow";
                    BoyLbl123.TextFont.Size = 9;
                    BoyLbl123.Value = @"HDL";

                    BoyLbl142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 131, 129, 136, false);
                    BoyLbl142.Name = "BoyLbl142";
                    BoyLbl142.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl142.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl142.TextFont.Name = "Arial Narrow";
                    BoyLbl142.TextFont.Size = 9;
                    BoyLbl142.Value = @"SGOT";

                    BoyLbl1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 136, 129, 144, false);
                    BoyLbl1271.Name = "BoyLbl1271";
                    BoyLbl1271.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1271.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1271.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl1271.TextFont.Name = "Arial Narrow";
                    BoyLbl1271.TextFont.Size = 9;
                    BoyLbl1271.Value = @"SGPT";

                    BoyLbl25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 101, 160, 106, false);
                    BoyLbl25.Name = "BoyLbl25";
                    BoyLbl25.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl25.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl25.TextFont.Name = "Arial Narrow";
                    BoyLbl25.TextFont.Size = 9;
                    BoyLbl25.Value = @"Kreatinin";

                    BoyLbl182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 106, 160, 111, false);
                    BoyLbl182.Name = "BoyLbl182";
                    BoyLbl182.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl182.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl182.TextFont.Name = "Arial Narrow";
                    BoyLbl182.TextFont.Size = 9;
                    BoyLbl182.Value = @"Total Bilirubin";

                    BoyLbl192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 111, 160, 116, false);
                    BoyLbl192.Name = "BoyLbl192";
                    BoyLbl192.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl192.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl192.TextFont.Name = "Arial Narrow";
                    BoyLbl192.TextFont.Size = 9;
                    BoyLbl192.Value = @"Direkt Bilirubin";

                    BoyLbl103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 116, 160, 121, false);
                    BoyLbl103.Name = "BoyLbl103";
                    BoyLbl103.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl103.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl103.TextFont.Name = "Arial Narrow";
                    BoyLbl103.TextFont.Size = 9;
                    BoyLbl103.Value = @"İndirekt Bilirubin";

                    BoyLbl113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 121, 160, 126, false);
                    BoyLbl113.Name = "BoyLbl113";
                    BoyLbl113.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl113.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl113.TextFont.Name = "Arial Narrow";
                    BoyLbl113.TextFont.Size = 9;
                    BoyLbl113.Value = @"GGT";

                    BoyLbl124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 126, 160, 131, false);
                    BoyLbl124.Name = "BoyLbl124";
                    BoyLbl124.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl124.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl124.TextFont.Name = "Arial Narrow";
                    BoyLbl124.TextFont.Size = 9;
                    BoyLbl124.Value = @"ALP";

                    BoyLbl143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 131, 160, 136, false);
                    BoyLbl143.Name = "BoyLbl143";
                    BoyLbl143.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl143.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl143.TextFont.Name = "Arial Narrow";
                    BoyLbl143.TextFont.Size = 9;
                    BoyLbl143.Value = @"Ürik Asit";

                    NewLine1174 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 173, 101, 173, 144, false);
                    NewLine1174.Name = "NewLine1174";
                    NewLine1174.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 136, 141, 144, false);
                    NewLine14711.Name = "NewLine14711";
                    NewLine14711.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111741 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 136, 160, 144, false);
                    NewLine111741.Name = "NewLine111741";
                    NewLine111741.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 101, 186, 111, false);
                    BoyLbl152.Name = "BoyLbl152";
                    BoyLbl152.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl152.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl152.TextFont.Name = "Arial Narrow";
                    BoyLbl152.TextFont.Size = 9;
                    BoyLbl152.Value = @" HBsAg";

                    BoyLbl1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 111, 186, 121, false);
                    BoyLbl1251.Name = "BoyLbl1251";
                    BoyLbl1251.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1251.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl1251.TextFont.Name = "Arial Narrow";
                    BoyLbl1251.TextFont.Size = 9;
                    BoyLbl1251.Value = @" VDRL";

                    BoyLbl1252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 121, 186, 131, false);
                    BoyLbl1252.Name = "BoyLbl1252";
                    BoyLbl1252.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1252.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1252.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BoyLbl1252.TextFont.Name = "Arial Narrow";
                    BoyLbl1252.TextFont.Size = 9;
                    BoyLbl1252.Value = @" AntiHIV";

                    NewLine1147111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 186, 131, 186, 144, false);
                    NewLine1147111.Name = "NewLine1147111";
                    NewLine1147111.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 145, 55, 150, false);
                    BoyLbl111112111.Name = "BoyLbl111112111";
                    BoyLbl111112111.TextFont.Name = "Arial Narrow";
                    BoyLbl111112111.TextFont.Size = 9;
                    BoyLbl111112111.Value = @"Biyokimya Uzmanı";

                    BoyLbl111211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 155, 198, 160, false);
                    BoyLbl111211121.Name = "BoyLbl111211121";
                    BoyLbl111211121.TextFont.Name = "Arial Narrow";
                    BoyLbl111211121.TextFont.Size = 9;
                    BoyLbl111211121.Value = @"İmza";

                    BoyLbl12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 196, 37, 214, false);
                    BoyLbl12221.Name = "BoyLbl12221";
                    BoyLbl12221.MultiLine = EvetHayirEnum.ehEvet;
                    BoyLbl12221.NoClip = EvetHayirEnum.ehEvet;
                    BoyLbl12221.WordBreak = EvetHayirEnum.ehEvet;
                    BoyLbl12221.ExpandTabs = EvetHayirEnum.ehEvet;
                    BoyLbl12221.TextFont.Name = "Arial Narrow";
                    BoyLbl12221.TextFont.Size = 9;
                    BoyLbl12221.Value = @"1 :
2 :
3 :
4 :";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 31, 254, 199, 254, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl1111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 232, 198, 237, false);
                    BoyLbl1111211111.Name = "BoyLbl1111211111";
                    BoyLbl1111211111.TextFont.Name = "Arial Narrow";
                    BoyLbl1111211111.TextFont.Size = 9;
                    BoyLbl1111211111.Value = @"Sağ.Krl.Bşk          Üye            Üye            Üye            Üye           Üye          Üye           Üye          Üye           Üye          Üye         Üye";

                    BoyLbl1111211112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 256, 110, 261, false);
                    BoyLbl1111211112.Name = "BoyLbl1111211112";
                    BoyLbl1111211112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1111211112.TextFont.Name = "Arial Narrow";
                    BoyLbl1111211112.TextFont.Size = 9;
                    BoyLbl1111211112.Value = @"XXXXXX Sağ.K.lığı";

                    NewLine13711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 111, 254, 111, 276, false);
                    NewLine13711.Name = "NewLine13711";
                    NewLine13711.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl12111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 256, 198, 261, false);
                    BoyLbl12111121111.Name = "BoyLbl12111121111";
                    BoyLbl12111121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl12111121111.TextFont.Name = "Arial Narrow";
                    BoyLbl12111121111.TextFont.Size = 9;
                    BoyLbl12111121111.Value = @"MSB Sağ.D.Bşk.lığı";

                    BoyLbl1111211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 265, 47, 270, false);
                    BoyLbl1111211113.Name = "BoyLbl1111211113";
                    BoyLbl1111211113.TextFont.Name = "Arial Narrow";
                    BoyLbl1111211113.TextFont.Size = 9;
                    BoyLbl1111211113.Value = @"Kayıt Nu.";

                    BoyLbl13111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 270, 47, 275, false);
                    BoyLbl13111121111.Name = "BoyLbl13111121111";
                    BoyLbl13111121111.TextFont.Name = "Arial Narrow";
                    BoyLbl13111121111.TextFont.Size = 9;
                    BoyLbl13111121111.Value = @"Tarih";

                    BoyLbl3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 265, 50, 270, false);
                    BoyLbl3.Name = "BoyLbl3";
                    BoyLbl3.TextFont.Name = "Arial Narrow";
                    BoyLbl3.TextFont.Size = 9;
                    BoyLbl3.Value = @":";

                    BoyLbl26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 270, 50, 275, false);
                    BoyLbl26.Name = "BoyLbl26";
                    BoyLbl26.TextFont.Name = "Arial Narrow";
                    BoyLbl26.TextFont.Size = 9;
                    BoyLbl26.Value = @":";

                    BoyLbl4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 265, 127, 270, false);
                    BoyLbl4.Name = "BoyLbl4";
                    BoyLbl4.TextFont.Name = "Arial Narrow";
                    BoyLbl4.TextFont.Size = 9;
                    BoyLbl4.Value = @"Kayıt Nu.";

                    BoyLbl111112111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 270, 127, 275, false);
                    BoyLbl111112111131.Name = "BoyLbl111112111131";
                    BoyLbl111112111131.TextFont.Name = "Arial Narrow";
                    BoyLbl111112111131.TextFont.Size = 9;
                    BoyLbl111112111131.Value = @"Tarih";

                    BoyLbl27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 265, 130, 270, false);
                    BoyLbl27.Name = "BoyLbl27";
                    BoyLbl27.TextFont.Name = "Arial Narrow";
                    BoyLbl27.TextFont.Size = 9;
                    BoyLbl27.Value = @":";

                    BoyLbl162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 270, 130, 275, false);
                    BoyLbl162.Name = "BoyLbl162";
                    BoyLbl162.TextFont.Name = "Arial Narrow";
                    BoyLbl162.TextFont.Size = 9;
                    BoyLbl162.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 199, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 28, 16, false);
                    BoyLbl125.Name = "BoyLbl125";
                    BoyLbl125.TextFont.Name = "Arial Narrow";
                    BoyLbl125.TextFont.Size = 9;
                    BoyLbl125.Value = @"GÖĞÜS";

                    BoyLbl112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 7, 52, 12, false);
                    BoyLbl112112.Name = "BoyLbl112112";
                    BoyLbl112112.TextFont.Name = "Arial Narrow";
                    BoyLbl112112.TextFont.Size = 9;
                    BoyLbl112112.Value = @"Bulguların Özeti";

                    BoyLbl111122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 16, 198, 21, false);
                    BoyLbl111122.Name = "BoyLbl111122";
                    BoyLbl111122.TextFont.Name = "Arial Narrow";
                    BoyLbl111122.TextFont.Size = 9;
                    BoyLbl111122.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BoyLbl11.CalcValue = BoyLbl11.Value;
                    BoyLbl13.CalcValue = BoyLbl13.Value;
                    BoyLbl12111.CalcValue = BoyLbl12111.Value;
                    BoyLbl11121.CalcValue = BoyLbl11121.Value;
                    BoyLbl111121.CalcValue = BoyLbl111121.Value;
                    BoyLbl112111.CalcValue = BoyLbl112111.Value;
                    BoyLbl12.CalcValue = BoyLbl12.Value;
                    BoyLbl121.CalcValue = BoyLbl121.Value;
                    BoyLbl1121111.CalcValue = BoyLbl1121111.Value;
                    BoyLbl1111211.CalcValue = BoyLbl1111211.Value;
                    BoyLbl1121.CalcValue = BoyLbl1121.Value;
                    BoyLbl122.CalcValue = BoyLbl122.Value;
                    BoyLbl1221.CalcValue = BoyLbl1221.Value;
                    BoyLbl1222.CalcValue = BoyLbl1222.Value;
                    BoyLbl1223.CalcValue = BoyLbl1223.Value;
                    BoyLbl1225.CalcValue = BoyLbl1225.Value;
                    BoyLbl12111211.CalcValue = BoyLbl12111211.Value;
                    BoyLbl12112111.CalcValue = BoyLbl12112111.Value;
                    BoyLbl111121121.CalcValue = BoyLbl111121121.Value;
                    BoyLbl1121121111.CalcValue = BoyLbl1121121111.Value;
                    BoyLbl111121122.CalcValue = BoyLbl111121122.Value;
                    BoyLbl11121111.CalcValue = BoyLbl11121111.Value;
                    BoyLbl11111211.CalcValue = BoyLbl11111211.Value;
                    BoyLbl12112112.CalcValue = BoyLbl12112112.Value;
                    BoyLbl121121121.CalcValue = BoyLbl121121121.Value;
                    BoyLbl1121121121.CalcValue = BoyLbl1121121121.Value;
                    BoyLbl11211211211.CalcValue = BoyLbl11211211211.Value;
                    BoyLbl1121121112.CalcValue = BoyLbl1121121112.Value;
                    BoyLbl12111211211.CalcValue = BoyLbl12111211211.Value;
                    BoyLbl1.CalcValue = BoyLbl1.Value;
                    BoyLbl14.CalcValue = BoyLbl14.Value;
                    BoyLbl15.CalcValue = BoyLbl15.Value;
                    BoyLbl16.CalcValue = BoyLbl16.Value;
                    BoyLbl17.CalcValue = BoyLbl17.Value;
                    BoyLbl171.CalcValue = BoyLbl171.Value;
                    BoyLbl161.CalcValue = BoyLbl161.Value;
                    BoyLbl2.CalcValue = BoyLbl2.Value;
                    BoyLbl18.CalcValue = BoyLbl18.Value;
                    BoyLbl19.CalcValue = BoyLbl19.Value;
                    BoyLbl20.CalcValue = BoyLbl20.Value;
                    BoyLbl21.CalcValue = BoyLbl21.Value;
                    BoyLbl22.CalcValue = BoyLbl22.Value;
                    BoyLbl24.CalcValue = BoyLbl24.Value;
                    BoyLbl172.CalcValue = BoyLbl172.Value;
                    BoyLbl173.CalcValue = BoyLbl173.Value;
                    BoyLbl23.CalcValue = BoyLbl23.Value;
                    BoyLbl181.CalcValue = BoyLbl181.Value;
                    BoyLbl191.CalcValue = BoyLbl191.Value;
                    BoyLbl102.CalcValue = BoyLbl102.Value;
                    BoyLbl112.CalcValue = BoyLbl112.Value;
                    BoyLbl123.CalcValue = BoyLbl123.Value;
                    BoyLbl142.CalcValue = BoyLbl142.Value;
                    BoyLbl1271.CalcValue = BoyLbl1271.Value;
                    BoyLbl25.CalcValue = BoyLbl25.Value;
                    BoyLbl182.CalcValue = BoyLbl182.Value;
                    BoyLbl192.CalcValue = BoyLbl192.Value;
                    BoyLbl103.CalcValue = BoyLbl103.Value;
                    BoyLbl113.CalcValue = BoyLbl113.Value;
                    BoyLbl124.CalcValue = BoyLbl124.Value;
                    BoyLbl143.CalcValue = BoyLbl143.Value;
                    BoyLbl152.CalcValue = BoyLbl152.Value;
                    BoyLbl1251.CalcValue = BoyLbl1251.Value;
                    BoyLbl1252.CalcValue = BoyLbl1252.Value;
                    BoyLbl111112111.CalcValue = BoyLbl111112111.Value;
                    BoyLbl111211121.CalcValue = BoyLbl111211121.Value;
                    BoyLbl12221.CalcValue = BoyLbl12221.Value;
                    BoyLbl1111211111.CalcValue = BoyLbl1111211111.Value;
                    BoyLbl1111211112.CalcValue = BoyLbl1111211112.Value;
                    BoyLbl12111121111.CalcValue = BoyLbl12111121111.Value;
                    BoyLbl1111211113.CalcValue = BoyLbl1111211113.Value;
                    BoyLbl13111121111.CalcValue = BoyLbl13111121111.Value;
                    BoyLbl3.CalcValue = BoyLbl3.Value;
                    BoyLbl26.CalcValue = BoyLbl26.Value;
                    BoyLbl4.CalcValue = BoyLbl4.Value;
                    BoyLbl111112111131.CalcValue = BoyLbl111112111131.Value;
                    BoyLbl27.CalcValue = BoyLbl27.Value;
                    BoyLbl162.CalcValue = BoyLbl162.Value;
                    BoyLbl125.CalcValue = BoyLbl125.Value;
                    BoyLbl112112.CalcValue = BoyLbl112112.Value;
                    BoyLbl111122.CalcValue = BoyLbl111122.Value;
                    return new TTReportObject[] { BoyLbl11,BoyLbl13,BoyLbl12111,BoyLbl11121,BoyLbl111121,BoyLbl112111,BoyLbl12,BoyLbl121,BoyLbl1121111,BoyLbl1111211,BoyLbl1121,BoyLbl122,BoyLbl1221,BoyLbl1222,BoyLbl1223,BoyLbl1225,BoyLbl12111211,BoyLbl12112111,BoyLbl111121121,BoyLbl1121121111,BoyLbl111121122,BoyLbl11121111,BoyLbl11111211,BoyLbl12112112,BoyLbl121121121,BoyLbl1121121121,BoyLbl11211211211,BoyLbl1121121112,BoyLbl12111211211,BoyLbl1,BoyLbl14,BoyLbl15,BoyLbl16,BoyLbl17,BoyLbl171,BoyLbl161,BoyLbl2,BoyLbl18,BoyLbl19,BoyLbl20,BoyLbl21,BoyLbl22,BoyLbl24,BoyLbl172,BoyLbl173,BoyLbl23,BoyLbl181,BoyLbl191,BoyLbl102,BoyLbl112,BoyLbl123,BoyLbl142,BoyLbl1271,BoyLbl25,BoyLbl182,BoyLbl192,BoyLbl103,BoyLbl113,BoyLbl124,BoyLbl143,BoyLbl152,BoyLbl1251,BoyLbl1252,BoyLbl111112111,BoyLbl111211121,BoyLbl12221,BoyLbl1111211111,BoyLbl1111211112,BoyLbl12111121111,BoyLbl1111211113,BoyLbl13111121111,BoyLbl3,BoyLbl26,BoyLbl4,BoyLbl111112111131,BoyLbl27,BoyLbl162,BoyLbl125,BoyLbl112112,BoyLbl111122};
                }
            }
            public partial class ArkasayfaGroupFooter : TTReportSection
            {
                public HCEFlierSlipReportForFiveYears MyParentReport
                {
                    get { return (HCEFlierSlipReportForFiveYears)ParentReport; }
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
            public HCEFlierSlipReportForFiveYears MyParentReport
            {
                get { return (HCEFlierSlipReportForFiveYears)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportShape NewLine8 { get {return Body().NewLine8;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine26 { get {return Body().NewLine26;} }
            public TTReportShape NewLine28 { get {return Body().NewLine28;} }
            public TTReportShape NewLine29 { get {return Body().NewLine29;} }
            public TTReportShape NewLine30 { get {return Body().NewLine30;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField DOGUMILI { get {return Body().DOGUMILI;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportShape NewLine172 { get {return Body().NewLine172;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField DuzenleyenMerkezLbl { get {return Body().DuzenleyenMerkezLbl;} }
            public TTReportField DuzenleyenMerkezLbl2 { get {return Body().DuzenleyenMerkezLbl2;} }
            public TTReportField DUZENLEYENMERKEZ { get {return Body().DUZENLEYENMERKEZ;} }
            public TTReportField AdLbl { get {return Body().AdLbl;} }
            public TTReportField SoyadLbl { get {return Body().SoyadLbl;} }
            public TTReportField BabaAdLbl { get {return Body().BabaAdLbl;} }
            public TTReportField SinifRutbeLbl { get {return Body().SinifRutbeLbl;} }
            public TTReportField SicilNoLbl { get {return Body().SicilNoLbl;} }
            public TTReportField EmSanSicilNoLbl { get {return Body().EmSanSicilNoLbl;} }
            public TTReportField DTarihLbl { get {return Body().DTarihLbl;} }
            public TTReportField TCNoLbl { get {return Body().TCNoLbl;} }
            public TTReportField RaporNoLbl12 { get {return Body().RaporNoLbl12;} }
            public TTReportField RaporNoLbl13 { get {return Body().RaporNoLbl13;} }
            public TTReportField RaporNoLbl14 { get {return Body().RaporNoLbl14;} }
            public TTReportField RaporNoLbl15 { get {return Body().RaporNoLbl15;} }
            public TTReportField RaporNoLbl16 { get {return Body().RaporNoLbl16;} }
            public TTReportField RaporNoLbl17 { get {return Body().RaporNoLbl17;} }
            public TTReportField RaporNoLbl18 { get {return Body().RaporNoLbl18;} }
            public TTReportField RaporNoLbl19 { get {return Body().RaporNoLbl19;} }
            public TTReportField AD { get {return Body().AD;} }
            public TTReportField SOYAD { get {return Body().SOYAD;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField SICIL { get {return Body().SICIL;} }
            public TTReportField EMSANSICIL { get {return Body().EMSANSICIL;} }
            public TTReportField DOGUMTARIHI { get {return Body().DOGUMTARIHI;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField BirlikLbl1 { get {return Body().BirlikLbl1;} }
            public TTReportField UcakLbl { get {return Body().UcakLbl;} }
            public TTReportField MaksatLbl { get {return Body().MaksatLbl;} }
            public TTReportField SonIslemLbl { get {return Body().SonIslemLbl;} }
            public TTReportField BoyLbl { get {return Body().BoyLbl;} }
            public TTReportField KiloLbl { get {return Body().KiloLbl;} }
            public TTReportField RaporNoLbl121 { get {return Body().RaporNoLbl121;} }
            public TTReportField RaporNoLbl131 { get {return Body().RaporNoLbl131;} }
            public TTReportField RaporNoLbl141 { get {return Body().RaporNoLbl141;} }
            public TTReportField RaporNoLbl151 { get {return Body().RaporNoLbl151;} }
            public TTReportField RaporNoLbl161 { get {return Body().RaporNoLbl161;} }
            public TTReportField RaporNoLbl171 { get {return Body().RaporNoLbl171;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField UCAKTIPI { get {return Body().UCAKTIPI;} }
            public TTReportField MUAYENESEBEBI { get {return Body().MUAYENESEBEBI;} }
            public TTReportField SONSKSONUCU { get {return Body().SONSKSONUCU;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField KILO { get {return Body().KILO;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField BoyLbl1 { get {return Body().BoyLbl1;} }
            public TTReportField BoyLbl11 { get {return Body().BoyLbl11;} }
            public TTReportField BoyLbl12 { get {return Body().BoyLbl12;} }
            public TTReportField BoyLbl13 { get {return Body().BoyLbl13;} }
            public TTReportField BoyLbl14 { get {return Body().BoyLbl14;} }
            public TTReportField RaporNoLbl162 { get {return Body().RaporNoLbl162;} }
            public TTReportField RaporNoLbl163 { get {return Body().RaporNoLbl163;} }
            public TTReportField RaporNoLbl164 { get {return Body().RaporNoLbl164;} }
            public TTReportField BoyLbl15 { get {return Body().BoyLbl15;} }
            public TTReportField BoyLbl16 { get {return Body().BoyLbl16;} }
            public TTReportField BoyLbl111 { get {return Body().BoyLbl111;} }
            public TTReportField BoyLbl161 { get {return Body().BoyLbl161;} }
            public TTReportField BoyLbl162 { get {return Body().BoyLbl162;} }
            public TTReportField BoyLbl163 { get {return Body().BoyLbl163;} }
            public TTReportField BoyLbl164 { get {return Body().BoyLbl164;} }
            public TTReportField BoyLbl165 { get {return Body().BoyLbl165;} }
            public TTReportField BoyLbl1111 { get {return Body().BoyLbl1111;} }
            public TTReportField BoyLbl1112 { get {return Body().BoyLbl1112;} }
            public TTReportField BoyLbl1113 { get {return Body().BoyLbl1113;} }
            public TTReportField BoyLbl1114 { get {return Body().BoyLbl1114;} }
            public TTReportField BoyLbl1115 { get {return Body().BoyLbl1115;} }
            public TTReportField BoyLbl1117 { get {return Body().BoyLbl1117;} }
            public TTReportField BoyLbl112 { get {return Body().BoyLbl112;} }
            public TTReportField BoyLbl121 { get {return Body().BoyLbl121;} }
            public TTReportField BoyLbl131 { get {return Body().BoyLbl131;} }
            public TTReportField RaporNoLbl1261 { get {return Body().RaporNoLbl1261;} }
            public TTReportField RaporNoLbl1361 { get {return Body().RaporNoLbl1361;} }
            public TTReportField BoyLbl1211 { get {return Body().BoyLbl1211;} }
            public TTReportField BoyLbl1212 { get {return Body().BoyLbl1212;} }
            public TTReportField BoyLbl1213 { get {return Body().BoyLbl1213;} }
            public TTReportField BoyLbl13121 { get {return Body().BoyLbl13121;} }
            public TTReportShape NewLine162 { get {return Body().NewLine162;} }
            public TTReportField BoyLbl1121 { get {return Body().BoyLbl1121;} }
            public TTReportField BoyLbl1131 { get {return Body().BoyLbl1131;} }
            public TTReportField BoyLbl1122 { get {return Body().BoyLbl1122;} }
            public TTReportField BoyLbl1132 { get {return Body().BoyLbl1132;} }
            public TTReportField BoyLbl13122 { get {return Body().BoyLbl13122;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField BoyLbl11211 { get {return Body().BoyLbl11211;} }
            public TTReportField BoyLbl11311 { get {return Body().BoyLbl11311;} }
            public TTReportField BoyLbl12211 { get {return Body().BoyLbl12211;} }
            public TTReportField BoyLbl12311 { get {return Body().BoyLbl12311;} }
            public TTReportField BoyLbl11212 { get {return Body().BoyLbl11212;} }
            public TTReportField BoyLbl11312 { get {return Body().BoyLbl11312;} }
            public TTReportField BoyLbl12212 { get {return Body().BoyLbl12212;} }
            public TTReportField BoyLbl12312 { get {return Body().BoyLbl12312;} }
            public TTReportField BoyLbl11213 { get {return Body().BoyLbl11213;} }
            public TTReportField BoyLbl11313 { get {return Body().BoyLbl11313;} }
            public TTReportField BoyLbl12213 { get {return Body().BoyLbl12213;} }
            public TTReportField BoyLbl12313 { get {return Body().BoyLbl12313;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportShape NewLine1261 { get {return Body().NewLine1261;} }
            public TTReportShape NewLine1262 { get {return Body().NewLine1262;} }
            public TTReportShape NewLine1263 { get {return Body().NewLine1263;} }
            public TTReportShape NewLine1264 { get {return Body().NewLine1264;} }
            public TTReportShape NewLine1265 { get {return Body().NewLine1265;} }
            public TTReportField BoyLbl111211 { get {return Body().BoyLbl111211;} }
            public TTReportField BoyLbl1112112 { get {return Body().BoyLbl1112112;} }
            public TTReportShape NewLine15621 { get {return Body().NewLine15621;} }
            public TTReportField BoyLbl1112111 { get {return Body().BoyLbl1112111;} }
            public TTReportField BoyLbl1112113 { get {return Body().BoyLbl1112113;} }
            public TTReportField BoyLbl1112114 { get {return Body().BoyLbl1112114;} }
            public TTReportField BoyLbl1112115 { get {return Body().BoyLbl1112115;} }
            public TTReportField BoyLbl1112116 { get {return Body().BoyLbl1112116;} }
            public TTReportField BoyLbl1112117 { get {return Body().BoyLbl1112117;} }
            public TTReportField BoyLbl12112111 { get {return Body().BoyLbl12112111;} }
            public TTReportField BoyLbl12112112 { get {return Body().BoyLbl12112112;} }
            public TTReportField BoyLbl111121121 { get {return Body().BoyLbl111121121;} }
            public TTReportField BoyLbl121121121 { get {return Body().BoyLbl121121121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine11211 { get {return Body().NewLine11211;} }
            public TTReportShape NewLine11212 { get {return Body().NewLine11212;} }
            public TTReportShape NewLine11213 { get {return Body().NewLine11213;} }
            public TTReportShape NewLine11214 { get {return Body().NewLine11214;} }
            public TTReportField BoyLbl112131 { get {return Body().BoyLbl112131;} }
            public TTReportField BoyLbl17111 { get {return Body().BoyLbl17111;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField UcakLbl1 { get {return Body().UcakLbl1;} }
            public TTReportField MUAYENETARIHI { get {return Body().MUAYENETARIHI;} }
            public TTReportField UcakLbl11 { get {return Body().UcakLbl11;} }
            public TTReportField RaporNoLbl1131 { get {return Body().RaporNoLbl1131;} }
            public TTReportField GOREVI { get {return Body().GOREVI;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportShape NewLine182 { get {return Body().NewLine182;} }
            public TTReportField BoyLbl1561 { get {return Body().BoyLbl1561;} }
            public TTReportField BoyLbl112132 { get {return Body().BoyLbl112132;} }
            public TTReportField BoyLbl17112 { get {return Body().BoyLbl17112;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommitteeNQL", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCEFlierSlipReportForFiveYears MyParentReport
                {
                    get { return (HCEFlierSlipReportForFiveYears)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField BOLUM;
                public TTReportShape NewLine;
                public TTReportShape NewLine8;
                public TTReportShape NewLine9;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine18;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine26;
                public TTReportShape NewLine28;
                public TTReportShape NewLine29;
                public TTReportShape NewLine30;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField DTARIHI;
                public TTReportField DOGUMILI;
                public TTReportField DYERILCE;
                public TTReportField DYERIL;
                public TTReportField DYERULKE;
                public TTReportShape NewLine172;
                public TTReportField NewField1;
                public TTReportShape NewLine1;
                public TTReportField DuzenleyenMerkezLbl;
                public TTReportField DuzenleyenMerkezLbl2;
                public TTReportField DUZENLEYENMERKEZ;
                public TTReportField AdLbl;
                public TTReportField SoyadLbl;
                public TTReportField BabaAdLbl;
                public TTReportField SinifRutbeLbl;
                public TTReportField SicilNoLbl;
                public TTReportField EmSanSicilNoLbl;
                public TTReportField DTarihLbl;
                public TTReportField TCNoLbl;
                public TTReportField RaporNoLbl12;
                public TTReportField RaporNoLbl13;
                public TTReportField RaporNoLbl14;
                public TTReportField RaporNoLbl15;
                public TTReportField RaporNoLbl16;
                public TTReportField RaporNoLbl17;
                public TTReportField RaporNoLbl18;
                public TTReportField RaporNoLbl19;
                public TTReportField AD;
                public TTReportField SOYAD;
                public TTReportField BABAADI;
                public TTReportField SINIFRUTBE;
                public TTReportField SICIL;
                public TTReportField EMSANSICIL;
                public TTReportField DOGUMTARIHI;
                public TTReportField TCKIMLIKNO;
                public TTReportField BirlikLbl1;
                public TTReportField UcakLbl;
                public TTReportField MaksatLbl;
                public TTReportField SonIslemLbl;
                public TTReportField BoyLbl;
                public TTReportField KiloLbl;
                public TTReportField RaporNoLbl121;
                public TTReportField RaporNoLbl131;
                public TTReportField RaporNoLbl141;
                public TTReportField RaporNoLbl151;
                public TTReportField RaporNoLbl161;
                public TTReportField RaporNoLbl171;
                public TTReportField BIRLIK;
                public TTReportField UCAKTIPI;
                public TTReportField MUAYENESEBEBI;
                public TTReportField SONSKSONUCU;
                public TTReportField BOY;
                public TTReportField KILO;
                public TTReportShape NewLine2;
                public TTReportField BoyLbl1;
                public TTReportField BoyLbl11;
                public TTReportField BoyLbl12;
                public TTReportField BoyLbl13;
                public TTReportField BoyLbl14;
                public TTReportField RaporNoLbl162;
                public TTReportField RaporNoLbl163;
                public TTReportField RaporNoLbl164;
                public TTReportField BoyLbl15;
                public TTReportField BoyLbl16;
                public TTReportField BoyLbl111;
                public TTReportField BoyLbl161;
                public TTReportField BoyLbl162;
                public TTReportField BoyLbl163;
                public TTReportField BoyLbl164;
                public TTReportField BoyLbl165;
                public TTReportField BoyLbl1111;
                public TTReportField BoyLbl1112;
                public TTReportField BoyLbl1113;
                public TTReportField BoyLbl1114;
                public TTReportField BoyLbl1115;
                public TTReportField BoyLbl1117;
                public TTReportField BoyLbl112;
                public TTReportField BoyLbl121;
                public TTReportField BoyLbl131;
                public TTReportField RaporNoLbl1261;
                public TTReportField RaporNoLbl1361;
                public TTReportField BoyLbl1211;
                public TTReportField BoyLbl1212;
                public TTReportField BoyLbl1213;
                public TTReportField BoyLbl13121;
                public TTReportShape NewLine162;
                public TTReportField BoyLbl1121;
                public TTReportField BoyLbl1131;
                public TTReportField BoyLbl1122;
                public TTReportField BoyLbl1132;
                public TTReportField BoyLbl13122;
                public TTReportShape NewLine12;
                public TTReportField BoyLbl11211;
                public TTReportField BoyLbl11311;
                public TTReportField BoyLbl12211;
                public TTReportField BoyLbl12311;
                public TTReportField BoyLbl11212;
                public TTReportField BoyLbl11312;
                public TTReportField BoyLbl12212;
                public TTReportField BoyLbl12312;
                public TTReportField BoyLbl11213;
                public TTReportField BoyLbl11313;
                public TTReportField BoyLbl12213;
                public TTReportField BoyLbl12313;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1261;
                public TTReportShape NewLine1262;
                public TTReportShape NewLine1263;
                public TTReportShape NewLine1264;
                public TTReportShape NewLine1265;
                public TTReportField BoyLbl111211;
                public TTReportField BoyLbl1112112;
                public TTReportShape NewLine15621;
                public TTReportField BoyLbl1112111;
                public TTReportField BoyLbl1112113;
                public TTReportField BoyLbl1112114;
                public TTReportField BoyLbl1112115;
                public TTReportField BoyLbl1112116;
                public TTReportField BoyLbl1112117;
                public TTReportField BoyLbl12112111;
                public TTReportField BoyLbl12112112;
                public TTReportField BoyLbl111121121;
                public TTReportField BoyLbl121121121;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine11212;
                public TTReportShape NewLine11213;
                public TTReportShape NewLine11214;
                public TTReportField BoyLbl112131;
                public TTReportField BoyLbl17111;
                public TTReportField NewField161;
                public TTReportField NewField121;
                public TTReportField UcakLbl1;
                public TTReportField MUAYENETARIHI;
                public TTReportField UcakLbl11;
                public TTReportField RaporNoLbl1131;
                public TTReportField GOREVI;
                public TTReportField NewField1161;
                public TTReportField NewField11611;
                public TTReportShape NewLine182;
                public TTReportField BoyLbl1561;
                public TTReportField BoyLbl112132;
                public TTReportField BoyLbl17112; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 283;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 199, 12, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Size = 12;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCFLIERSLIPREPORTCAPTION"","""")";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 38, 242, 43, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.Visible = EvetHayirEnum.ehHayir;
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.TextFont.Size = 8;
                    BOLUM.Value = @"{#BOLUM#}";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 199, 14, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 163, 26, 163, 87, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 14, 199, 97, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 87, 199, 87, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 77, 26, 77, 87, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 95, 199, 278, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 128, 199, 128, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 108, 199, 108, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 143, 199, 143, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 157, 199, 157, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 171, 199, 171, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine26 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 202, 199, 202, false);
                    NewLine26.Name = "NewLine26";
                    NewLine26.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine28 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 263, 199, 263, false);
                    NewLine28.Name = "NewLine28";
                    NewLine28.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine29 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 7, 97, false);
                    NewLine29.Name = "NewLine29";
                    NewLine29.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine30 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 97, 7, 278, false);
                    NewLine30.Name = "NewLine30";
                    NewLine30.DrawStyle = DrawStyleConstants.vbSolid;

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 242, 21, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 23, 242, 28, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 30, 242, 35, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#DTARIHI#}";

                    DOGUMILI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 47, 242, 52, false);
                    DOGUMILI.Name = "DOGUMILI";
                    DOGUMILI.Visible = EvetHayirEnum.ehHayir;
                    DOGUMILI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMILI.Value = @"{#DOGUMYERI#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 73, 243, 78, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERILCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERILCE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERILCE.TextFont.Name = "Arial Narrow";
                    DYERILCE.TextFont.Size = 8;
                    DYERILCE.Value = @"{#DOGUMYERIILCE#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 81, 243, 86, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.MultiLine = EvetHayirEnum.ehEvet;
                    DYERIL.WordBreak = EvetHayirEnum.ehEvet;
                    DYERIL.TextFont.Name = "Arial Narrow";
                    DYERIL.TextFont.Size = 8;
                    DYERIL.Value = @"{#DOGUMYERI#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 65, 243, 70, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.DrawStyle = DrawStyleConstants.vbSolid;
                    DYERULKE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.MultiLine = EvetHayirEnum.ehEvet;
                    DYERULKE.WordBreak = EvetHayirEnum.ehEvet;
                    DYERULKE.TextFont.Name = "Arial Narrow";
                    DYERULKE.TextFont.Size = 8;
                    DYERULKE.Value = @"{#DOGUMYERIULKE#}";

                    NewLine172 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 248, 199, 248, false);
                    NewLine172.Name = "NewLine172";
                    NewLine172.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 34, 198, 77, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftOLE;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 26, 199, 26, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    DuzenleyenMerkezLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 39, 20, false);
                    DuzenleyenMerkezLbl.Name = "DuzenleyenMerkezLbl";
                    DuzenleyenMerkezLbl.TextFont.Name = "Arial Narrow";
                    DuzenleyenMerkezLbl.TextFont.Size = 9;
                    DuzenleyenMerkezLbl.Value = @"DÜZENLEYEN MERKEZ";

                    DuzenleyenMerkezLbl2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 15, 41, 20, false);
                    DuzenleyenMerkezLbl2.Name = "DuzenleyenMerkezLbl2";
                    DuzenleyenMerkezLbl2.TextFont.Name = "Arial Narrow";
                    DuzenleyenMerkezLbl2.TextFont.Size = 9;
                    DuzenleyenMerkezLbl2.Value = @":";

                    DUZENLEYENMERKEZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 15, 151, 25, false);
                    DUZENLEYENMERKEZ.Name = "DUZENLEYENMERKEZ";
                    DUZENLEYENMERKEZ.FieldType = ReportFieldTypeEnum.ftExpression;
                    DUZENLEYENMERKEZ.MultiLine = EvetHayirEnum.ehEvet;
                    DUZENLEYENMERKEZ.WordBreak = EvetHayirEnum.ehEvet;
                    DUZENLEYENMERKEZ.TextFont.Name = "Arial Narrow";
                    DUZENLEYENMERKEZ.TextFont.Size = 9;
                    DUZENLEYENMERKEZ.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"","""")";

                    AdLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 35, 31, 40, false);
                    AdLbl.Name = "AdLbl";
                    AdLbl.TextFont.Name = "Arial Narrow";
                    AdLbl.TextFont.Size = 9;
                    AdLbl.Value = @"ADI";

                    SoyadLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 42, 31, 47, false);
                    SoyadLbl.Name = "SoyadLbl";
                    SoyadLbl.TextFont.Name = "Arial Narrow";
                    SoyadLbl.TextFont.Size = 9;
                    SoyadLbl.Value = @"SOYADI";

                    BabaAdLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 49, 31, 54, false);
                    BabaAdLbl.Name = "BabaAdLbl";
                    BabaAdLbl.TextFont.Name = "Arial Narrow";
                    BabaAdLbl.TextFont.Size = 9;
                    BabaAdLbl.Value = @"BABA ADI";

                    SinifRutbeLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 56, 31, 61, false);
                    SinifRutbeLbl.Name = "SinifRutbeLbl";
                    SinifRutbeLbl.TextFont.Name = "Arial Narrow";
                    SinifRutbeLbl.TextFont.Size = 9;
                    SinifRutbeLbl.Value = @"SINIF VE RÜTBE";

                    SicilNoLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 67, 31, 72, false);
                    SicilNoLbl.Name = "SicilNoLbl";
                    SicilNoLbl.TextFont.Name = "Arial Narrow";
                    SicilNoLbl.TextFont.Size = 9;
                    SicilNoLbl.Value = @"SİCİL NU.";

                    EmSanSicilNoLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 74, 31, 79, false);
                    EmSanSicilNoLbl.Name = "EmSanSicilNoLbl";
                    EmSanSicilNoLbl.TextFont.Name = "Arial Narrow";
                    EmSanSicilNoLbl.TextFont.Size = 9;
                    EmSanSicilNoLbl.Value = @"EM.SAN.SİC.NU.";

                    DTarihLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 81, 31, 86, false);
                    DTarihLbl.Name = "DTarihLbl";
                    DTarihLbl.TextFont.Name = "Arial Narrow";
                    DTarihLbl.TextFont.Size = 9;
                    DTarihLbl.Value = @"DOĞUM TARİHİ";

                    TCNoLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 31, 33, false);
                    TCNoLbl.Name = "TCNoLbl";
                    TCNoLbl.TextFont.Name = "Arial Narrow";
                    TCNoLbl.TextFont.Size = 9;
                    TCNoLbl.Value = @"TC.KİMLİK.NU.";

                    RaporNoLbl12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 35, 33, 40, false);
                    RaporNoLbl12.Name = "RaporNoLbl12";
                    RaporNoLbl12.TextFont.Name = "Arial Narrow";
                    RaporNoLbl12.TextFont.Size = 9;
                    RaporNoLbl12.Value = @":";

                    RaporNoLbl13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 42, 33, 47, false);
                    RaporNoLbl13.Name = "RaporNoLbl13";
                    RaporNoLbl13.TextFont.Name = "Arial Narrow";
                    RaporNoLbl13.TextFont.Size = 9;
                    RaporNoLbl13.Value = @":";

                    RaporNoLbl14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 49, 33, 54, false);
                    RaporNoLbl14.Name = "RaporNoLbl14";
                    RaporNoLbl14.TextFont.Name = "Arial Narrow";
                    RaporNoLbl14.TextFont.Size = 9;
                    RaporNoLbl14.Value = @":";

                    RaporNoLbl15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 56, 33, 61, false);
                    RaporNoLbl15.Name = "RaporNoLbl15";
                    RaporNoLbl15.TextFont.Name = "Arial Narrow";
                    RaporNoLbl15.TextFont.Size = 9;
                    RaporNoLbl15.Value = @":";

                    RaporNoLbl16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 67, 33, 72, false);
                    RaporNoLbl16.Name = "RaporNoLbl16";
                    RaporNoLbl16.TextFont.Name = "Arial Narrow";
                    RaporNoLbl16.TextFont.Size = 9;
                    RaporNoLbl16.Value = @":";

                    RaporNoLbl17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 74, 33, 79, false);
                    RaporNoLbl17.Name = "RaporNoLbl17";
                    RaporNoLbl17.TextFont.Name = "Arial Narrow";
                    RaporNoLbl17.TextFont.Size = 9;
                    RaporNoLbl17.Value = @":";

                    RaporNoLbl18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 81, 33, 86, false);
                    RaporNoLbl18.Name = "RaporNoLbl18";
                    RaporNoLbl18.TextFont.Name = "Arial Narrow";
                    RaporNoLbl18.TextFont.Size = 9;
                    RaporNoLbl18.Value = @":";

                    RaporNoLbl19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 28, 33, 33, false);
                    RaporNoLbl19.Name = "RaporNoLbl19";
                    RaporNoLbl19.TextFont.Name = "Arial Narrow";
                    RaporNoLbl19.TextFont.Size = 9;
                    RaporNoLbl19.Value = @":";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 35, 76, 40, false);
                    AD.Name = "AD";
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.TextFont.Name = "Arial Narrow";
                    AD.TextFont.Size = 9;
                    AD.Value = @"{#PNAME#}";

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 42, 76, 47, false);
                    SOYAD.Name = "SOYAD";
                    SOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYAD.TextFont.Name = "Arial Narrow";
                    SOYAD.TextFont.Size = 9;
                    SOYAD.Value = @"{#PSURNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 49, 76, 54, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 9;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 56, 76, 66, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 9;
                    SINIFRUTBE.Value = @"";

                    SICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 67, 76, 72, false);
                    SICIL.Name = "SICIL";
                    SICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICIL.NoClip = EvetHayirEnum.ehEvet;
                    SICIL.TextFont.Name = "Arial Narrow";
                    SICIL.TextFont.Size = 9;
                    SICIL.Value = @"";

                    EMSANSICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 74, 76, 79, false);
                    EMSANSICIL.Name = "EMSANSICIL";
                    EMSANSICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMSANSICIL.TextFont.Name = "Arial Narrow";
                    EMSANSICIL.TextFont.Size = 9;
                    EMSANSICIL.Value = @"";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 81, 76, 86, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"Short Date";
                    DOGUMTARIHI.TextFont.Name = "Arial Narrow";
                    DOGUMTARIHI.TextFont.Size = 9;
                    DOGUMTARIHI.Value = @"{#DTARIHI#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 28, 76, 33, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.Value = @"{#TCNO#}";

                    BirlikLbl1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 28, 88, 33, false);
                    BirlikLbl1.Name = "BirlikLbl1";
                    BirlikLbl1.TextFont.Name = "Arial Narrow";
                    BirlikLbl1.TextFont.Size = 9;
                    BirlikLbl1.Value = @"BİRLİĞİ";

                    UcakLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 48, 105, 53, false);
                    UcakLbl.Name = "UcakLbl";
                    UcakLbl.TextFont.Name = "Arial Narrow";
                    UcakLbl.TextFont.Size = 9;
                    UcakLbl.Value = @"UÇTUĞU UÇAK TİPİ";

                    MaksatLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 53, 105, 62, false);
                    MaksatLbl.Name = "MaksatLbl";
                    MaksatLbl.MultiLine = EvetHayirEnum.ehEvet;
                    MaksatLbl.NoClip = EvetHayirEnum.ehEvet;
                    MaksatLbl.WordBreak = EvetHayirEnum.ehEvet;
                    MaksatLbl.ExpandTabs = EvetHayirEnum.ehEvet;
                    MaksatLbl.TextFont.Name = "Arial Narrow";
                    MaksatLbl.TextFont.Size = 9;
                    MaksatLbl.Value = @"NE MAKSATLA
MUAYENE EDİLDİĞİ";

                    SonIslemLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 62, 105, 71, false);
                    SonIslemLbl.Name = "SonIslemLbl";
                    SonIslemLbl.MultiLine = EvetHayirEnum.ehEvet;
                    SonIslemLbl.NoClip = EvetHayirEnum.ehEvet;
                    SonIslemLbl.WordBreak = EvetHayirEnum.ehEvet;
                    SonIslemLbl.ExpandTabs = EvetHayirEnum.ehEvet;
                    SonIslemLbl.TextFont.Name = "Arial Narrow";
                    SonIslemLbl.TextFont.Size = 9;
                    SonIslemLbl.Value = @"SON SAĞLIK İŞLEMİ
VE SONUCU";

                    BoyLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 81, 88, 86, false);
                    BoyLbl.Name = "BoyLbl";
                    BoyLbl.TextFont.Name = "Arial Narrow";
                    BoyLbl.TextFont.Size = 9;
                    BoyLbl.Value = @"BOY";

                    KiloLbl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 81, 127, 86, false);
                    KiloLbl.Name = "KiloLbl";
                    KiloLbl.TextFont.Name = "Arial Narrow";
                    KiloLbl.TextFont.Size = 9;
                    KiloLbl.Value = @"KİLO";

                    RaporNoLbl121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 28, 90, 33, false);
                    RaporNoLbl121.Name = "RaporNoLbl121";
                    RaporNoLbl121.TextFont.Name = "Arial Narrow";
                    RaporNoLbl121.TextFont.Size = 9;
                    RaporNoLbl121.Value = @":";

                    RaporNoLbl131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 62, 107, 67, false);
                    RaporNoLbl131.Name = "RaporNoLbl131";
                    RaporNoLbl131.TextFont.Name = "Arial Narrow";
                    RaporNoLbl131.TextFont.Size = 9;
                    RaporNoLbl131.Value = @":";

                    RaporNoLbl141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 48, 107, 53, false);
                    RaporNoLbl141.Name = "RaporNoLbl141";
                    RaporNoLbl141.TextFont.Name = "Arial Narrow";
                    RaporNoLbl141.TextFont.Size = 9;
                    RaporNoLbl141.Value = @":";

                    RaporNoLbl151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 53, 107, 59, false);
                    RaporNoLbl151.Name = "RaporNoLbl151";
                    RaporNoLbl151.TextFont.Name = "Arial Narrow";
                    RaporNoLbl151.TextFont.Size = 9;
                    RaporNoLbl151.Value = @":";

                    RaporNoLbl161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 81, 129, 86, false);
                    RaporNoLbl161.Name = "RaporNoLbl161";
                    RaporNoLbl161.TextFont.Name = "Arial Narrow";
                    RaporNoLbl161.TextFont.Size = 9;
                    RaporNoLbl161.Value = @":";

                    RaporNoLbl171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 81, 90, 86, false);
                    RaporNoLbl171.Name = "RaporNoLbl171";
                    RaporNoLbl171.TextFont.Name = "Arial Narrow";
                    RaporNoLbl171.TextFont.Size = 9;
                    RaporNoLbl171.Value = @":";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 28, 162, 43, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    UCAKTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 48, 162, 53, false);
                    UCAKTIPI.Name = "UCAKTIPI";
                    UCAKTIPI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UCAKTIPI.MultiLine = EvetHayirEnum.ehEvet;
                    UCAKTIPI.WordBreak = EvetHayirEnum.ehEvet;
                    UCAKTIPI.ObjectDefName = "AircraftTypeDefinition";
                    UCAKTIPI.DataMember = "NAME";
                    UCAKTIPI.TextFont.Name = "Arial Narrow";
                    UCAKTIPI.TextFont.Size = 9;
                    UCAKTIPI.Value = @"{#UCAKTIPI#}";

                    MUAYENESEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 53, 162, 62, false);
                    MUAYENESEBEBI.Name = "MUAYENESEBEBI";
                    MUAYENESEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENESEBEBI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MUAYENESEBEBI.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENESEBEBI.WordBreak = EvetHayirEnum.ehEvet;
                    MUAYENESEBEBI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MUAYENESEBEBI.TextFont.Name = "Arial Narrow";
                    MUAYENESEBEBI.TextFont.Size = 9;
                    MUAYENESEBEBI.Value = @"{#SKSEBEBI#}";

                    SONSKSONUCU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 62, 162, 71, false);
                    SONSKSONUCU.Name = "SONSKSONUCU";
                    SONSKSONUCU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONSKSONUCU.MultiLine = EvetHayirEnum.ehEvet;
                    SONSKSONUCU.WordBreak = EvetHayirEnum.ehEvet;
                    SONSKSONUCU.TextFont.Name = "Arial Narrow";
                    SONSKSONUCU.TextFont.Size = 9;
                    SONSKSONUCU.Value = @"";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 81, 115, 86, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 9;
                    BOY.Value = @"{#BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 81, 162, 86, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.TextFont.Name = "Arial Narrow";
                    KILO.TextFont.Size = 9;
                    KILO.Value = @"{#KILO#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 87, 30, 278, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 95, 28, 100, false);
                    BoyLbl1.Name = "BoyLbl1";
                    BoyLbl1.TextFont.Name = "Arial Narrow";
                    BoyLbl1.TextFont.Size = 9;
                    BoyLbl1.Value = @"DAHİLİYE";

                    BoyLbl11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 88, 51, 93, false);
                    BoyLbl11.Name = "BoyLbl11";
                    BoyLbl11.TextFont.Name = "Arial Narrow";
                    BoyLbl11.TextFont.Size = 9;
                    BoyLbl11.Value = @"Bulguların Özeti";

                    BoyLbl12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 93, 41, 98, false);
                    BoyLbl12.Name = "BoyLbl12";
                    BoyLbl12.TextFont.Name = "Arial Narrow";
                    BoyLbl12.TextFont.Size = 9;
                    BoyLbl12.Value = @"TA";

                    BoyLbl13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 97, 41, 102, false);
                    BoyLbl13.Name = "BoyLbl13";
                    BoyLbl13.TextFont.Name = "Arial Narrow";
                    BoyLbl13.TextFont.Size = 9;
                    BoyLbl13.Value = @"NABIZ";

                    BoyLbl14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 102, 41, 107, false);
                    BoyLbl14.Name = "BoyLbl14";
                    BoyLbl14.TextFont.Name = "Arial Narrow";
                    BoyLbl14.TextFont.Size = 9;
                    BoyLbl14.Value = @"ATEŞ";

                    RaporNoLbl162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 93, 43, 98, false);
                    RaporNoLbl162.Name = "RaporNoLbl162";
                    RaporNoLbl162.TextFont.Name = "Arial Narrow";
                    RaporNoLbl162.TextFont.Size = 9;
                    RaporNoLbl162.Value = @":";

                    RaporNoLbl163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 97, 43, 102, false);
                    RaporNoLbl163.Name = "RaporNoLbl163";
                    RaporNoLbl163.TextFont.Name = "Arial Narrow";
                    RaporNoLbl163.TextFont.Size = 9;
                    RaporNoLbl163.Value = @":";

                    RaporNoLbl164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 102, 43, 107, false);
                    RaporNoLbl164.Name = "RaporNoLbl164";
                    RaporNoLbl164.TextFont.Name = "Arial Narrow";
                    RaporNoLbl164.TextFont.Size = 9;
                    RaporNoLbl164.Value = @":";

                    BoyLbl15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 116, 28, 121, false);
                    BoyLbl15.Name = "BoyLbl15";
                    BoyLbl15.TextFont.Name = "Arial Narrow";
                    BoyLbl15.TextFont.Size = 9;
                    BoyLbl15.Value = @"KARDİYOLOJİ";

                    BoyLbl16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 133, 28, 138, false);
                    BoyLbl16.Name = "BoyLbl16";
                    BoyLbl16.TextFont.Name = "Arial Narrow";
                    BoyLbl16.TextFont.Size = 9;
                    BoyLbl16.Value = @"NÖROLOJİ";

                    BoyLbl111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 102, 198, 107, false);
                    BoyLbl111.Name = "BoyLbl111";
                    BoyLbl111.TextFont.Name = "Arial Narrow";
                    BoyLbl111.TextFont.Size = 9;
                    BoyLbl111.Value = @"İmza";

                    BoyLbl161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 148, 28, 153, false);
                    BoyLbl161.Name = "BoyLbl161";
                    BoyLbl161.TextFont.Name = "Arial Narrow";
                    BoyLbl161.TextFont.Size = 9;
                    BoyLbl161.Value = @"RUH. HST.";

                    BoyLbl162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 162, 28, 167, false);
                    BoyLbl162.Name = "BoyLbl162";
                    BoyLbl162.TextFont.Name = "Arial Narrow";
                    BoyLbl162.TextFont.Size = 9;
                    BoyLbl162.Value = @"ORTOPEDİ";

                    BoyLbl163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 184, 28, 189, false);
                    BoyLbl163.Name = "BoyLbl163";
                    BoyLbl163.TextFont.Name = "Arial Narrow";
                    BoyLbl163.TextFont.Size = 9;
                    BoyLbl163.Value = @"GÖZ";

                    BoyLbl164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 217, 28, 232, false);
                    BoyLbl164.Name = "BoyLbl164";
                    BoyLbl164.MultiLine = EvetHayirEnum.ehEvet;
                    BoyLbl164.NoClip = EvetHayirEnum.ehEvet;
                    BoyLbl164.WordBreak = EvetHayirEnum.ehEvet;
                    BoyLbl164.ExpandTabs = EvetHayirEnum.ehEvet;
                    BoyLbl164.TextFont.Name = "Arial Narrow";
                    BoyLbl164.TextFont.Size = 9;
                    BoyLbl164.Value = @"KULAK
BURUN
BOĞAZ";

                    BoyLbl165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 253, 28, 258, false);
                    BoyLbl165.Name = "BoyLbl165";
                    BoyLbl165.TextFont.Name = "Arial Narrow";
                    BoyLbl165.TextFont.Size = 9;
                    BoyLbl165.Value = @"ENFK. HST.";

                    BoyLbl1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 122, 198, 127, false);
                    BoyLbl1111.Name = "BoyLbl1111";
                    BoyLbl1111.TextFont.Name = "Arial Narrow";
                    BoyLbl1111.TextFont.Size = 9;
                    BoyLbl1111.Value = @"İmza";

                    BoyLbl1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 137, 198, 142, false);
                    BoyLbl1112.Name = "BoyLbl1112";
                    BoyLbl1112.TextFont.Name = "Arial Narrow";
                    BoyLbl1112.TextFont.Size = 9;
                    BoyLbl1112.Value = @"İmza";

                    BoyLbl1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 151, 198, 156, false);
                    BoyLbl1113.Name = "BoyLbl1113";
                    BoyLbl1113.TextFont.Name = "Arial Narrow";
                    BoyLbl1113.TextFont.Size = 9;
                    BoyLbl1113.Value = @"İmza";

                    BoyLbl1114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 165, 198, 170, false);
                    BoyLbl1114.Name = "BoyLbl1114";
                    BoyLbl1114.TextFont.Name = "Arial Narrow";
                    BoyLbl1114.TextFont.Size = 9;
                    BoyLbl1114.Value = @"İmza";

                    BoyLbl1115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 196, 198, 201, false);
                    BoyLbl1115.Name = "BoyLbl1115";
                    BoyLbl1115.TextFont.Name = "Arial Narrow";
                    BoyLbl1115.TextFont.Size = 9;
                    BoyLbl1115.Value = @"İmza";

                    BoyLbl1117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 257, 198, 262, false);
                    BoyLbl1117.Name = "BoyLbl1117";
                    BoyLbl1117.TextFont.Name = "Arial Narrow";
                    BoyLbl1117.TextFont.Size = 9;
                    BoyLbl1117.Value = @"İmza";

                    BoyLbl112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 109, 51, 114, false);
                    BoyLbl112.Name = "BoyLbl112";
                    BoyLbl112.TextFont.Name = "Arial Narrow";
                    BoyLbl112.TextFont.Size = 9;
                    BoyLbl112.Value = @"Bulguların Özeti";

                    BoyLbl121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 114, 41, 119, false);
                    BoyLbl121.Name = "BoyLbl121";
                    BoyLbl121.TextFont.Name = "Arial Narrow";
                    BoyLbl121.TextFont.Size = 9;
                    BoyLbl121.Value = @"EKG";

                    BoyLbl131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 119, 41, 124, false);
                    BoyLbl131.Name = "BoyLbl131";
                    BoyLbl131.TextFont.Name = "Arial Narrow";
                    BoyLbl131.TextFont.Size = 9;
                    BoyLbl131.Value = @"EKO";

                    RaporNoLbl1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 114, 43, 119, false);
                    RaporNoLbl1261.Name = "RaporNoLbl1261";
                    RaporNoLbl1261.TextFont.Name = "Arial Narrow";
                    RaporNoLbl1261.TextFont.Size = 9;
                    RaporNoLbl1261.Value = @":";

                    RaporNoLbl1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 119, 43, 124, false);
                    RaporNoLbl1361.Name = "RaporNoLbl1361";
                    RaporNoLbl1361.TextFont.Name = "Arial Narrow";
                    RaporNoLbl1361.TextFont.Size = 9;
                    RaporNoLbl1361.Value = @":";

                    BoyLbl1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 129, 51, 134, false);
                    BoyLbl1211.Name = "BoyLbl1211";
                    BoyLbl1211.TextFont.Name = "Arial Narrow";
                    BoyLbl1211.TextFont.Size = 9;
                    BoyLbl1211.Value = @"Bulguların Özeti";

                    BoyLbl1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 144, 51, 149, false);
                    BoyLbl1212.Name = "BoyLbl1212";
                    BoyLbl1212.TextFont.Name = "Arial Narrow";
                    BoyLbl1212.TextFont.Size = 9;
                    BoyLbl1212.Value = @"Bulguların Özeti";

                    BoyLbl1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 158, 51, 163, false);
                    BoyLbl1213.Name = "BoyLbl1213";
                    BoyLbl1213.TextFont.Name = "Arial Narrow";
                    BoyLbl1213.TextFont.Size = 9;
                    BoyLbl1213.Value = @"Bulguların Özeti";

                    BoyLbl13121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 249, 51, 254, false);
                    BoyLbl13121.Name = "BoyLbl13121";
                    BoyLbl13121.TextFont.Name = "Arial Narrow";
                    BoyLbl13121.TextFont.Size = 9;
                    BoyLbl13121.Value = @"Bulguların Özeti";

                    NewLine162 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 189, 199, 189, false);
                    NewLine162.Name = "NewLine162";
                    NewLine162.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 172, 51, 176, false);
                    BoyLbl1121.Name = "BoyLbl1121";
                    BoyLbl1121.TextFont.Name = "Arial Narrow";
                    BoyLbl1121.TextFont.Size = 9;
                    BoyLbl1121.Value = @"UZAK GÖRME";

                    BoyLbl1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 176, 51, 180, false);
                    BoyLbl1131.Name = "BoyLbl1131";
                    BoyLbl1131.TextFont.Name = "Arial Narrow";
                    BoyLbl1131.TextFont.Size = 9;
                    BoyLbl1131.Value = @"DÜZELTMESİZ";

                    BoyLbl1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 180, 51, 184, false);
                    BoyLbl1122.Name = "BoyLbl1122";
                    BoyLbl1122.TextFont.Name = "Arial Narrow";
                    BoyLbl1122.TextFont.Size = 9;
                    BoyLbl1122.Value = @"DÜZELTMELİ";

                    BoyLbl1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 184, 51, 188, false);
                    BoyLbl1132.Name = "BoyLbl1132";
                    BoyLbl1132.TextFont.Name = "Arial Narrow";
                    BoyLbl1132.TextFont.Size = 9;
                    BoyLbl1132.Value = @"YAKIN GÖRME";

                    BoyLbl13122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 190, 51, 195, false);
                    BoyLbl13122.Name = "BoyLbl13122";
                    BoyLbl13122.TextFont.Name = "Arial Narrow";
                    BoyLbl13122.TextFont.Size = 9;
                    BoyLbl13122.Value = @"Bulguların Özeti";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 171, 65, 189, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 172, 80, 176, false);
                    BoyLbl11211.Name = "BoyLbl11211";
                    BoyLbl11211.TextFont.Name = "Arial Narrow";
                    BoyLbl11211.TextFont.Size = 9;
                    BoyLbl11211.Value = @"Sağ Göz";

                    BoyLbl11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 176, 80, 180, false);
                    BoyLbl11311.Name = "BoyLbl11311";
                    BoyLbl11311.TextFont.Name = "Arial Narrow";
                    BoyLbl11311.TextFont.Size = 9;
                    BoyLbl11311.Value = @"20/";

                    BoyLbl12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 180, 80, 184, false);
                    BoyLbl12211.Name = "BoyLbl12211";
                    BoyLbl12211.TextFont.Name = "Arial Narrow";
                    BoyLbl12211.TextFont.Size = 9;
                    BoyLbl12211.Value = @"20/";

                    BoyLbl12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 184, 80, 188, false);
                    BoyLbl12311.Name = "BoyLbl12311";
                    BoyLbl12311.TextFont.Name = "Arial Narrow";
                    BoyLbl12311.TextFont.Size = 9;
                    BoyLbl12311.Value = @"(30-50) cm";

                    BoyLbl11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 172, 122, 176, false);
                    BoyLbl11212.Name = "BoyLbl11212";
                    BoyLbl11212.TextFont.Name = "Arial Narrow";
                    BoyLbl11212.TextFont.Size = 9;
                    BoyLbl11212.Value = @"Sol Göz";

                    BoyLbl11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 176, 122, 180, false);
                    BoyLbl11312.Name = "BoyLbl11312";
                    BoyLbl11312.TextFont.Name = "Arial Narrow";
                    BoyLbl11312.TextFont.Size = 9;
                    BoyLbl11312.Value = @"20/";

                    BoyLbl12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 180, 122, 184, false);
                    BoyLbl12212.Name = "BoyLbl12212";
                    BoyLbl12212.TextFont.Name = "Arial Narrow";
                    BoyLbl12212.TextFont.Size = 9;
                    BoyLbl12212.Value = @"20/";

                    BoyLbl12312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 184, 122, 188, false);
                    BoyLbl12312.Name = "BoyLbl12312";
                    BoyLbl12312.TextFont.Name = "Arial Narrow";
                    BoyLbl12312.TextFont.Size = 9;
                    BoyLbl12312.Value = @"Sağ";

                    BoyLbl11213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 172, 165, 176, false);
                    BoyLbl11213.Name = "BoyLbl11213";
                    BoyLbl11213.TextFont.Name = "Arial Narrow";
                    BoyLbl11213.TextFont.Size = 9;
                    BoyLbl11213.Value = @"Her iki göz";

                    BoyLbl11313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 176, 165, 180, false);
                    BoyLbl11313.Name = "BoyLbl11313";
                    BoyLbl11313.TextFont.Name = "Arial Narrow";
                    BoyLbl11313.TextFont.Size = 9;
                    BoyLbl11313.Value = @"20/";

                    BoyLbl12213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 180, 165, 184, false);
                    BoyLbl12213.Name = "BoyLbl12213";
                    BoyLbl12213.TextFont.Name = "Arial Narrow";
                    BoyLbl12213.TextFont.Size = 9;
                    BoyLbl12213.Value = @"20/";

                    BoyLbl12313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 184, 165, 188, false);
                    BoyLbl12313.Name = "BoyLbl12313";
                    BoyLbl12313.TextFont.Name = "Arial Narrow";
                    BoyLbl12313.TextFont.Size = 9;
                    BoyLbl12313.Value = @"Sol";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 171, 108, 189, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 171, 151, 189, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1261 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 222, 199, 222, false);
                    NewLine1261.Name = "NewLine1261";
                    NewLine1261.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1262 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 207, 199, 207, false);
                    NewLine1262.Name = "NewLine1262";
                    NewLine1262.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1263 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 212, 199, 212, false);
                    NewLine1263.Name = "NewLine1263";
                    NewLine1263.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1264 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 50, 217, 199, 217, false);
                    NewLine1264.Name = "NewLine1264";
                    NewLine1264.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1265 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 50, 227, 199, 227, false);
                    NewLine1265.Name = "NewLine1265";
                    NewLine1265.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 202, 124, 207, false);
                    BoyLbl111211.Name = "BoyLbl111211";
                    BoyLbl111211.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl111211.TextFont.Name = "Arial Narrow";
                    BoyLbl111211.TextFont.Size = 9;
                    BoyLbl111211.Value = @"Odiyometri Bulguları";

                    BoyLbl1112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 207, 60, 212, false);
                    BoyLbl1112112.Name = "BoyLbl1112112";
                    BoyLbl1112112.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112112.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112112.TextFont.Name = "Arial Narrow";
                    BoyLbl1112112.TextFont.Size = 9;
                    BoyLbl1112112.Value = @"FREKANS";

                    NewLine15621 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 232, 199, 232, false);
                    NewLine15621.Name = "NewLine15621";
                    NewLine15621.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 207, 83, 212, false);
                    BoyLbl1112111.Name = "BoyLbl1112111";
                    BoyLbl1112111.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112111.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112111.TextFont.Name = "Arial Narrow";
                    BoyLbl1112111.TextFont.Size = 9;
                    BoyLbl1112111.Value = @"256";

                    BoyLbl1112113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 207, 106, 212, false);
                    BoyLbl1112113.Name = "BoyLbl1112113";
                    BoyLbl1112113.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112113.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112113.TextFont.Name = "Arial Narrow";
                    BoyLbl1112113.TextFont.Size = 9;
                    BoyLbl1112113.Value = @"512";

                    BoyLbl1112114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 207, 130, 212, false);
                    BoyLbl1112114.Name = "BoyLbl1112114";
                    BoyLbl1112114.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112114.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112114.TextFont.Name = "Arial Narrow";
                    BoyLbl1112114.TextFont.Size = 9;
                    BoyLbl1112114.Value = @"1024";

                    BoyLbl1112115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 207, 153, 212, false);
                    BoyLbl1112115.Name = "BoyLbl1112115";
                    BoyLbl1112115.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112115.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112115.TextFont.Name = "Arial Narrow";
                    BoyLbl1112115.TextFont.Size = 9;
                    BoyLbl1112115.Value = @"2048";

                    BoyLbl1112116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 207, 176, 212, false);
                    BoyLbl1112116.Name = "BoyLbl1112116";
                    BoyLbl1112116.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112116.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112116.TextFont.Name = "Arial Narrow";
                    BoyLbl1112116.TextFont.Size = 9;
                    BoyLbl1112116.Value = @"4096";

                    BoyLbl1112117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 207, 199, 212, false);
                    BoyLbl1112117.Name = "BoyLbl1112117";
                    BoyLbl1112117.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl1112117.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl1112117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl1112117.TextFont.Name = "Arial Narrow";
                    BoyLbl1112117.TextFont.Size = 9;
                    BoyLbl1112117.Value = @"8192";

                    BoyLbl12112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 212, 60, 217, false);
                    BoyLbl12112111.Name = "BoyLbl12112111";
                    BoyLbl12112111.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl12112111.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl12112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl12112111.TextFont.Name = "Arial Narrow";
                    BoyLbl12112111.TextFont.Size = 9;
                    BoyLbl12112111.Value = @"HY";

                    BoyLbl12112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 217, 60, 222, false);
                    BoyLbl12112112.Name = "BoyLbl12112112";
                    BoyLbl12112112.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl12112112.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl12112112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl12112112.TextFont.Name = "Arial Narrow";
                    BoyLbl12112112.TextFont.Size = 9;
                    BoyLbl12112112.Value = @"KY";

                    BoyLbl111121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 222, 60, 227, false);
                    BoyLbl111121121.Name = "BoyLbl111121121";
                    BoyLbl111121121.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl111121121.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl111121121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl111121121.TextFont.Name = "Arial Narrow";
                    BoyLbl111121121.TextFont.Size = 9;
                    BoyLbl111121121.Value = @"HY";

                    BoyLbl121121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 227, 60, 232, false);
                    BoyLbl121121121.Name = "BoyLbl121121121";
                    BoyLbl121121121.DrawStyle = DrawStyleConstants.vbSolid;
                    BoyLbl121121121.FillStyle = FillStyleConstants.vbFSTransparent;
                    BoyLbl121121121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BoyLbl121121121.TextFont.Name = "Arial Narrow";
                    BoyLbl121121121.TextFont.Size = 9;
                    BoyLbl121121121.Value = @"KY";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 83, 212, 83, 232, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 106, 212, 106, 232, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 130, 212, 130, 232, false);
                    NewLine11212.Name = "NewLine11212";
                    NewLine11212.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11213 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 212, 153, 232, false);
                    NewLine11213.Name = "NewLine11213";
                    NewLine11213.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11214 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 212, 176, 232, false);
                    NewLine11214.Name = "NewLine11214";
                    NewLine11214.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 233, 51, 238, false);
                    BoyLbl112131.Name = "BoyLbl112131";
                    BoyLbl112131.TextFont.Name = "Arial Narrow";
                    BoyLbl112131.TextFont.Size = 9;
                    BoyLbl112131.Value = @"Bulguların Özeti";

                    BoyLbl17111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 242, 198, 247, false);
                    BoyLbl17111.Name = "BoyLbl17111";
                    BoyLbl17111.TextFont.Name = "Arial Narrow";
                    BoyLbl17111.TextFont.Size = 9;
                    BoyLbl17111.Value = @"İmza";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 15, 173, 20, false);
                    NewField161.Name = "NewField161";
                    NewField161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Name = "Arial Narrow";
                    NewField161.TextFont.Size = 8;
                    NewField161.Value = @"RAPOR NO";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 20, 173, 25, false);
                    NewField121.Name = "NewField121";
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 8;
                    NewField121.Value = @"RAPOR TARİHİ";

                    UcakLbl1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 43, 120, 48, false);
                    UcakLbl1.Name = "UcakLbl1";
                    UcakLbl1.TextFont.Name = "Arial Narrow";
                    UcakLbl1.TextFont.Size = 9;
                    UcakLbl1.Value = @"MUAYENE BAŞLANGIÇ TARİHİ :";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 43, 162, 48, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"Short Date";
                    MUAYENETARIHI.TextFont.Name = "Arial Narrow";
                    MUAYENETARIHI.TextFont.Size = 9;
                    MUAYENETARIHI.Value = @"";

                    UcakLbl11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 71, 105, 80, false);
                    UcakLbl11.Name = "UcakLbl11";
                    UcakLbl11.TextFont.Name = "Arial Narrow";
                    UcakLbl11.TextFont.Size = 9;
                    UcakLbl11.Value = @"GÖREVİ";

                    RaporNoLbl1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 71, 107, 76, false);
                    RaporNoLbl1131.Name = "RaporNoLbl1131";
                    RaporNoLbl1131.TextFont.Name = "Arial Narrow";
                    RaporNoLbl1131.TextFont.Size = 9;
                    RaporNoLbl1131.Value = @":";

                    GOREVI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 71, 162, 80, false);
                    GOREVI.Name = "GOREVI";
                    GOREVI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREVI.MultiLine = EvetHayirEnum.ehEvet;
                    GOREVI.WordBreak = EvetHayirEnum.ehEvet;
                    GOREVI.ObjectDefName = "HCDutyTypeDef";
                    GOREVI.DataMember = "NAME";
                    GOREVI.TextFont.Name = "Arial Narrow";
                    GOREVI.TextFont.Size = 9;
                    GOREVI.Value = @"{#GOREV#}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 15, 175, 20, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Name = "Arial Narrow";
                    NewField1161.TextFont.Size = 8;
                    NewField1161.Value = @":";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 20, 175, 25, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11611.TextFont.Name = "Arial Narrow";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.Value = @":";

                    NewLine182 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 278, 199, 278, false);
                    NewLine182.Name = "NewLine182";
                    NewLine182.DrawStyle = DrawStyleConstants.vbSolid;

                    BoyLbl1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 268, 28, 273, false);
                    BoyLbl1561.Name = "BoyLbl1561";
                    BoyLbl1561.TextFont.Name = "Arial Narrow";
                    BoyLbl1561.TextFont.Size = 9;
                    BoyLbl1561.Value = @"CİLDİYE";

                    BoyLbl112132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 264, 51, 269, false);
                    BoyLbl112132.Name = "BoyLbl112132";
                    BoyLbl112132.TextFont.Name = "Arial Narrow";
                    BoyLbl112132.TextFont.Size = 9;
                    BoyLbl112132.Value = @"Bulguların Özeti";

                    BoyLbl17112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 272, 198, 277, false);
                    BoyLbl17112.Name = "BoyLbl17112";
                    BoyLbl17112.TextFont.Name = "Arial Narrow";
                    BoyLbl17112.TextFont.Size = 9;
                    BoyLbl17112.Value = @"İmza";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommitteeNQL = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    BOLUM.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Bolum) : "");
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dtarihi) : "");
                    DOGUMILI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeri) : "");
                    DYERILCE.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeriilce) : "");
                    DYERIL.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeri) : "");
                    DYERULKE.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dogumyeriulke) : "");
                    NewField1.CalcValue = @"";
                    DuzenleyenMerkezLbl.CalcValue = DuzenleyenMerkezLbl.Value;
                    DuzenleyenMerkezLbl2.CalcValue = DuzenleyenMerkezLbl2.Value;
                    AdLbl.CalcValue = AdLbl.Value;
                    SoyadLbl.CalcValue = SoyadLbl.Value;
                    BabaAdLbl.CalcValue = BabaAdLbl.Value;
                    SinifRutbeLbl.CalcValue = SinifRutbeLbl.Value;
                    SicilNoLbl.CalcValue = SicilNoLbl.Value;
                    EmSanSicilNoLbl.CalcValue = EmSanSicilNoLbl.Value;
                    DTarihLbl.CalcValue = DTarihLbl.Value;
                    TCNoLbl.CalcValue = TCNoLbl.Value;
                    RaporNoLbl12.CalcValue = RaporNoLbl12.Value;
                    RaporNoLbl13.CalcValue = RaporNoLbl13.Value;
                    RaporNoLbl14.CalcValue = RaporNoLbl14.Value;
                    RaporNoLbl15.CalcValue = RaporNoLbl15.Value;
                    RaporNoLbl16.CalcValue = RaporNoLbl16.Value;
                    RaporNoLbl17.CalcValue = RaporNoLbl17.Value;
                    RaporNoLbl18.CalcValue = RaporNoLbl18.Value;
                    RaporNoLbl19.CalcValue = RaporNoLbl19.Value;
                    AD.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Pname) : "");
                    SOYAD.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Psurname) : "");
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.FatherName) : "");
                    SINIFRUTBE.CalcValue = @"";
                    SICIL.CalcValue = @"";
                    EMSANSICIL.CalcValue = @"";
                    DOGUMTARIHI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Dtarihi) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Tcno) : "");
                    BirlikLbl1.CalcValue = BirlikLbl1.Value;
                    UcakLbl.CalcValue = UcakLbl.Value;
                    MaksatLbl.CalcValue = MaksatLbl.Value;
                    SonIslemLbl.CalcValue = SonIslemLbl.Value;
                    BoyLbl.CalcValue = BoyLbl.Value;
                    KiloLbl.CalcValue = KiloLbl.Value;
                    RaporNoLbl121.CalcValue = RaporNoLbl121.Value;
                    RaporNoLbl131.CalcValue = RaporNoLbl131.Value;
                    RaporNoLbl141.CalcValue = RaporNoLbl141.Value;
                    RaporNoLbl151.CalcValue = RaporNoLbl151.Value;
                    RaporNoLbl161.CalcValue = RaporNoLbl161.Value;
                    RaporNoLbl171.CalcValue = RaporNoLbl171.Value;
                    BIRLIK.CalcValue = @"";
                    UCAKTIPI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Ucaktipi) : "");
                    UCAKTIPI.PostFieldValueCalculation();
                    MUAYENESEBEBI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Sksebebi) : "");
                    SONSKSONUCU.CalcValue = @"";
                    BOY.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Boy) : "");
                    KILO.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Kilo) : "");
                    BoyLbl1.CalcValue = BoyLbl1.Value;
                    BoyLbl11.CalcValue = BoyLbl11.Value;
                    BoyLbl12.CalcValue = BoyLbl12.Value;
                    BoyLbl13.CalcValue = BoyLbl13.Value;
                    BoyLbl14.CalcValue = BoyLbl14.Value;
                    RaporNoLbl162.CalcValue = RaporNoLbl162.Value;
                    RaporNoLbl163.CalcValue = RaporNoLbl163.Value;
                    RaporNoLbl164.CalcValue = RaporNoLbl164.Value;
                    BoyLbl15.CalcValue = BoyLbl15.Value;
                    BoyLbl16.CalcValue = BoyLbl16.Value;
                    BoyLbl111.CalcValue = BoyLbl111.Value;
                    BoyLbl161.CalcValue = BoyLbl161.Value;
                    BoyLbl162.CalcValue = BoyLbl162.Value;
                    BoyLbl163.CalcValue = BoyLbl163.Value;
                    BoyLbl164.CalcValue = BoyLbl164.Value;
                    BoyLbl165.CalcValue = BoyLbl165.Value;
                    BoyLbl1111.CalcValue = BoyLbl1111.Value;
                    BoyLbl1112.CalcValue = BoyLbl1112.Value;
                    BoyLbl1113.CalcValue = BoyLbl1113.Value;
                    BoyLbl1114.CalcValue = BoyLbl1114.Value;
                    BoyLbl1115.CalcValue = BoyLbl1115.Value;
                    BoyLbl1117.CalcValue = BoyLbl1117.Value;
                    BoyLbl112.CalcValue = BoyLbl112.Value;
                    BoyLbl121.CalcValue = BoyLbl121.Value;
                    BoyLbl131.CalcValue = BoyLbl131.Value;
                    RaporNoLbl1261.CalcValue = RaporNoLbl1261.Value;
                    RaporNoLbl1361.CalcValue = RaporNoLbl1361.Value;
                    BoyLbl1211.CalcValue = BoyLbl1211.Value;
                    BoyLbl1212.CalcValue = BoyLbl1212.Value;
                    BoyLbl1213.CalcValue = BoyLbl1213.Value;
                    BoyLbl13121.CalcValue = BoyLbl13121.Value;
                    BoyLbl1121.CalcValue = BoyLbl1121.Value;
                    BoyLbl1131.CalcValue = BoyLbl1131.Value;
                    BoyLbl1122.CalcValue = BoyLbl1122.Value;
                    BoyLbl1132.CalcValue = BoyLbl1132.Value;
                    BoyLbl13122.CalcValue = BoyLbl13122.Value;
                    BoyLbl11211.CalcValue = BoyLbl11211.Value;
                    BoyLbl11311.CalcValue = BoyLbl11311.Value;
                    BoyLbl12211.CalcValue = BoyLbl12211.Value;
                    BoyLbl12311.CalcValue = BoyLbl12311.Value;
                    BoyLbl11212.CalcValue = BoyLbl11212.Value;
                    BoyLbl11312.CalcValue = BoyLbl11312.Value;
                    BoyLbl12212.CalcValue = BoyLbl12212.Value;
                    BoyLbl12312.CalcValue = BoyLbl12312.Value;
                    BoyLbl11213.CalcValue = BoyLbl11213.Value;
                    BoyLbl11313.CalcValue = BoyLbl11313.Value;
                    BoyLbl12213.CalcValue = BoyLbl12213.Value;
                    BoyLbl12313.CalcValue = BoyLbl12313.Value;
                    BoyLbl111211.CalcValue = BoyLbl111211.Value;
                    BoyLbl1112112.CalcValue = BoyLbl1112112.Value;
                    BoyLbl1112111.CalcValue = BoyLbl1112111.Value;
                    BoyLbl1112113.CalcValue = BoyLbl1112113.Value;
                    BoyLbl1112114.CalcValue = BoyLbl1112114.Value;
                    BoyLbl1112115.CalcValue = BoyLbl1112115.Value;
                    BoyLbl1112116.CalcValue = BoyLbl1112116.Value;
                    BoyLbl1112117.CalcValue = BoyLbl1112117.Value;
                    BoyLbl12112111.CalcValue = BoyLbl12112111.Value;
                    BoyLbl12112112.CalcValue = BoyLbl12112112.Value;
                    BoyLbl111121121.CalcValue = BoyLbl111121121.Value;
                    BoyLbl121121121.CalcValue = BoyLbl121121121.Value;
                    BoyLbl112131.CalcValue = BoyLbl112131.Value;
                    BoyLbl17111.CalcValue = BoyLbl17111.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField121.CalcValue = NewField121.Value;
                    UcakLbl1.CalcValue = UcakLbl1.Value;
                    MUAYENETARIHI.CalcValue = @"";
                    UcakLbl11.CalcValue = UcakLbl11.Value;
                    RaporNoLbl1131.CalcValue = RaporNoLbl1131.Value;
                    GOREVI.CalcValue = (dataset_GetCurrentHealthCommitteeNQL != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommitteeNQL.Gorev) : "");
                    GOREVI.PostFieldValueCalculation();
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    BoyLbl1561.CalcValue = BoyLbl1561.Value;
                    BoyLbl112132.CalcValue = BoyLbl112132.Value;
                    BoyLbl17112.CalcValue = BoyLbl17112.Value;
                    HEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCFLIERSLIPREPORTCAPTION","");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    DUZENLEYENMERKEZ.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER","");
                    return new TTReportObject[] { BOLUM,DTARIHI,DOGUMILI,DYERILCE,DYERIL,DYERULKE,NewField1,DuzenleyenMerkezLbl,DuzenleyenMerkezLbl2,AdLbl,SoyadLbl,BabaAdLbl,SinifRutbeLbl,SicilNoLbl,EmSanSicilNoLbl,DTarihLbl,TCNoLbl,RaporNoLbl12,RaporNoLbl13,RaporNoLbl14,RaporNoLbl15,RaporNoLbl16,RaporNoLbl17,RaporNoLbl18,RaporNoLbl19,AD,SOYAD,BABAADI,SINIFRUTBE,SICIL,EMSANSICIL,DOGUMTARIHI,TCKIMLIKNO,BirlikLbl1,UcakLbl,MaksatLbl,SonIslemLbl,BoyLbl,KiloLbl,RaporNoLbl121,RaporNoLbl131,RaporNoLbl141,RaporNoLbl151,RaporNoLbl161,RaporNoLbl171,BIRLIK,UCAKTIPI,MUAYENESEBEBI,SONSKSONUCU,BOY,KILO,BoyLbl1,BoyLbl11,BoyLbl12,BoyLbl13,BoyLbl14,RaporNoLbl162,RaporNoLbl163,RaporNoLbl164,BoyLbl15,BoyLbl16,BoyLbl111,BoyLbl161,BoyLbl162,BoyLbl163,BoyLbl164,BoyLbl165,BoyLbl1111,BoyLbl1112,BoyLbl1113,BoyLbl1114,BoyLbl1115,BoyLbl1117,BoyLbl112,BoyLbl121,BoyLbl131,RaporNoLbl1261,RaporNoLbl1361,BoyLbl1211,BoyLbl1212,BoyLbl1213,BoyLbl13121,BoyLbl1121,BoyLbl1131,BoyLbl1122,BoyLbl1132,BoyLbl13122,BoyLbl11211,BoyLbl11311,BoyLbl12211,BoyLbl12311,BoyLbl11212,BoyLbl11312,BoyLbl12212,BoyLbl12312,BoyLbl11213,BoyLbl11313,BoyLbl12213,BoyLbl12313,BoyLbl111211,BoyLbl1112112,BoyLbl1112111,BoyLbl1112113,BoyLbl1112114,BoyLbl1112115,BoyLbl1112116,BoyLbl1112117,BoyLbl12112111,BoyLbl12112112,BoyLbl111121121,BoyLbl121121121,BoyLbl112131,BoyLbl17111,NewField161,NewField121,UcakLbl1,MUAYENETARIHI,UcakLbl11,RaporNoLbl1131,GOREVI,NewField1161,NewField11611,BoyLbl1561,BoyLbl112132,BoyLbl17112,HEADER,SITENAME,SITECITY,DUZENLEYENMERKEZ};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCEFlierSlipReportForFiveYears)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
//            {
//                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name);
//                if(pMilClass != null)
//                    this.SINIFRUTBE.CalcValue = this.SINIFRUTBE.CalcValue + " ";
//                this.SINIFRUTBE.CalcValue = this.SINIFRUTBE.CalcValue + (pRank == null ? "" : pRank.Name);
//            }
            
//            if(hc.AutomaticallyCreated != true)
//            {
//                if (hc.Episode.MyRelationship() != null)
//                {
//                    if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
//                        this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
//                }
//            }
            
            if(hc.AutomaticallyCreated == true)
                this.MUAYENETARIHI.CalcValue = hc.Episode.OpeningDate.ToString();
            else
            {
                foreach( TTObjectState state in hc.GetStateHistory())
                {
                    if(state.StateDefID == HealthCommittee.States.CommitteeAcceptance)
                    {
                        if (state.BranchDate != null)
                            this.MUAYENETARIHI.CalcValue = state.BranchDate.ToString();
                        break;
                    }
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

        public HCEFlierSlipReportForFiveYears()
        {
            Arkasayfa = new ArkasayfaGroup(this,"Arkasayfa");
            MAIN = new MAINGroup(Arkasayfa,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "C7203EFB-0742-4709-9E32-6D3608F9C34F", "No", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCEFLIERSLIPREPORTFORFIVEYEARS";
            Caption = "Beş Yıllık Uçucu Muayene Fişi";
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