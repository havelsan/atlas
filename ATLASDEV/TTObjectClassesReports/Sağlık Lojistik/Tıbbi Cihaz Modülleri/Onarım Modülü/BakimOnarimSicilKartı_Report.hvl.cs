
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
    /// Tıbbli Cihaz Sicil Kartı
    /// </summary>
    public partial class BakimOnarimSicilKartı : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public BakimOnarimSicilKartı MyParentReport
            {
                get { return (BakimOnarimSicilKartı)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HOSPITAL13 { get {return Header().HOSPITAL13;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField OWNERMILITARYUNIT1 { get {return Header().OWNERMILITARYUNIT1;} }
            public TTReportField FAMNAME1 { get {return Header().FAMNAME1;} }
            public TTReportField NATOSTOCKNO1 { get {return Header().NATOSTOCKNO1;} }
            public TTReportField MARK1 { get {return Header().MARK1;} }
            public TTReportField MODEL1 { get {return Header().MODEL1;} }
            public TTReportField PRODUCTIONDATE1 { get {return Header().PRODUCTIONDATE1;} }
            public TTReportField SERIALNUMBER1 { get {return Header().SERIALNUMBER1;} }
            public TTReportField VOLTAGE1 { get {return Header().VOLTAGE1;} }
            public TTReportField FREQUENCY1 { get {return Header().FREQUENCY1;} }
            public TTReportField GUARANTYENDDATE1 { get {return Header().GUARANTYENDDATE1;} }
            public TTReportField PRODUCTIONDATE11 { get {return Header().PRODUCTIONDATE11;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111121 { get {return Header().NewField111121;} }
            public TTReportField NewField111131 { get {return Header().NewField111131;} }
            public TTReportField NewField111141 { get {return Header().NewField111141;} }
            public TTReportField NewField111151 { get {return Header().NewField111151;} }
            public TTReportField NewField1131111 { get {return Header().NewField1131111;} }
            public TTReportField NewField11111561 { get {return Footer().NewField11111561;} }
            public TTReportField NewField111511111 { get {return Footer().NewField111511111;} }
            public TTReportField NewField112511111 { get {return Footer().NewField112511111;} }
            public TTReportField NewField113511111 { get {return Footer().NewField113511111;} }
            public TTReportField NewField114511111 { get {return Footer().NewField114511111;} }
            public TTReportField NewField115511111 { get {return Footer().NewField115511111;} }
            public TTReportField NewField116511111 { get {return Footer().NewField116511111;} }
            public TTReportField NewField1111115111 { get {return Footer().NewField1111115111;} }
            public TTReportField NewField1111115311 { get {return Footer().NewField1111115311;} }
            public TTReportField NewField1111115211 { get {return Footer().NewField1111115211;} }
            public TTReportField NewField1111115411 { get {return Footer().NewField1111115411;} }
            public TTReportField NewField1111115511 { get {return Footer().NewField1111115511;} }
            public TTReportField NewField12111561 { get {return Footer().NewField12111561;} }
            public TTReportField NewField121511111 { get {return Footer().NewField121511111;} }
            public TTReportField NewField122511111 { get {return Footer().NewField122511111;} }
            public TTReportField NewField123511111 { get {return Footer().NewField123511111;} }
            public TTReportField NewField124511111 { get {return Footer().NewField124511111;} }
            public TTReportField NewField125511111 { get {return Footer().NewField125511111;} }
            public TTReportField NewField126511111 { get {return Footer().NewField126511111;} }
            public TTReportField NewField1211115111 { get {return Footer().NewField1211115111;} }
            public TTReportField NewField1211115311 { get {return Footer().NewField1211115311;} }
            public TTReportField NewField1211115211 { get {return Footer().NewField1211115211;} }
            public TTReportField NewField1211115411 { get {return Footer().NewField1211115411;} }
            public TTReportField NewField1211115511 { get {return Footer().NewField1211115511;} }
            public TTReportField PrintDate1111 { get {return Footer().PrintDate1111;} }
            public TTReportField PageNumber1111 { get {return Footer().PageNumber1111;} }
            public TTReportField CurrentUser1111 { get {return Footer().CurrentUser1111;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public BakimOnarimSicilKartı MyParentReport
                {
                    get { return (BakimOnarimSicilKartı)ParentReport; }
                }
                
                public TTReportField HOSPITAL13;
                public TTReportField NewField1121;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField161;
                public TTReportField OWNERMILITARYUNIT1;
                public TTReportField FAMNAME1;
                public TTReportField NATOSTOCKNO1;
                public TTReportField MARK1;
                public TTReportField MODEL1;
                public TTReportField PRODUCTIONDATE1;
                public TTReportField SERIALNUMBER1;
                public TTReportField VOLTAGE1;
                public TTReportField FREQUENCY1;
                public TTReportField GUARANTYENDDATE1;
                public TTReportField PRODUCTIONDATE11;
                public TTReportField NewField101;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111121;
                public TTReportField NewField111131;
                public TTReportField NewField111141;
                public TTReportField NewField111151;
                public TTReportField NewField1131111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 112;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 11, 251, 22, false);
                    HOSPITAL13.Name = "HOSPITAL13";
                    HOSPITAL13.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL13.TextFont.Name = "Arial";
                    HOSPITAL13.TextFont.Size = 13;
                    HOSPITAL13.TextFont.Bold = true;
                    HOSPITAL13.TextFont.CharSet = 162;
                    HOSPITAL13.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 27, 251, 34, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 13;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"TIBBİ CİHAZ SİCİL KARTI";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 43, 47, 50, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Birliği /Kliniği /Servisi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 50, 47, 57, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Cihazın Adı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 57, 47, 64, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"NATO / Milli Stok No.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 64, 47, 71, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Markası";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 71, 47, 78, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Size = 12;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Modeli";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 71, 231, 82, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Size = 12;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Satıcı Firma Bilgileri 
(Adı, Adresi, Telefon Ve Faks Numarası Web Ve E-Mail Adresi)";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 43, 231, 57, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Size = 12;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Garanti Başlangıç Tarihi /Süresi  
(Bakım Onarım Ve Yedek Parça)";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 64, 231, 71, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Size = 12;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"Fiyatı (TL veya Döviz)";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 57, 231, 64, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Size = 12;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Hizmete Girdiği Tarih";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 85, 47, 93, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Voltaj ve Frekansı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 78, 47, 85, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İmal Tarihi/Seri No.";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 82, 231, 93, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Size = 12;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Üretici Firma Bilgileri 
(Adı, Adresi, Telefon Ve Faks Numarası Web ve E-Mail Adresi)
";

                    OWNERMILITARYUNIT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 43, 129, 50, false);
                    OWNERMILITARYUNIT1.Name = "OWNERMILITARYUNIT1";
                    OWNERMILITARYUNIT1.DrawStyle = DrawStyleConstants.vbSolid;
                    OWNERMILITARYUNIT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERMILITARYUNIT1.Value = @"";

                    FAMNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 50, 129, 57, false);
                    FAMNAME1.Name = "FAMNAME1";
                    FAMNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    FAMNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAMNAME1.Value = @"";

                    NATOSTOCKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 57, 129, 64, false);
                    NATOSTOCKNO1.Name = "NATOSTOCKNO1";
                    NATOSTOCKNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO1.Value = @"";

                    MARK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 64, 129, 71, false);
                    MARK1.Name = "MARK1";
                    MARK1.DrawStyle = DrawStyleConstants.vbSolid;
                    MARK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK1.Value = @"";

                    MODEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 71, 129, 78, false);
                    MODEL1.Name = "MODEL1";
                    MODEL1.DrawStyle = DrawStyleConstants.vbSolid;
                    MODEL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL1.Value = @"";

                    PRODUCTIONDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 78, 83, 85, false);
                    PRODUCTIONDATE1.Name = "PRODUCTIONDATE1";
                    PRODUCTIONDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCTIONDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTIONDATE1.Value = @"";

                    SERIALNUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 78, 129, 85, false);
                    SERIALNUMBER1.Name = "SERIALNUMBER1";
                    SERIALNUMBER1.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER1.Value = @"";

                    VOLTAGE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 85, 83, 93, false);
                    VOLTAGE1.Name = "VOLTAGE1";
                    VOLTAGE1.DrawStyle = DrawStyleConstants.vbSolid;
                    VOLTAGE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    VOLTAGE1.Value = @"";

                    FREQUENCY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 85, 129, 93, false);
                    FREQUENCY1.Name = "FREQUENCY1";
                    FREQUENCY1.DrawStyle = DrawStyleConstants.vbSolid;
                    FREQUENCY1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREQUENCY1.Value = @"";

                    GUARANTYENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 43, 285, 57, false);
                    GUARANTYENDDATE1.Name = "GUARANTYENDDATE1";
                    GUARANTYENDDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    GUARANTYENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUARANTYENDDATE1.Value = @"";

                    PRODUCTIONDATE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 57, 285, 64, false);
                    PRODUCTIONDATE11.Name = "PRODUCTIONDATE11";
                    PRODUCTIONDATE11.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCTIONDATE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTIONDATE11.Value = @"";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 64, 285, 71, false);
                    NewField101.Name = "NewField101";
                    NewField101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField101.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 71, 285, 82, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.Value = @"";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 82, 285, 93, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.Value = @"";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 102, 60, 112, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İŞ İSTEK 
NUMARASI";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 102, 112, 112, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"ARIZA VE YAPILAN 
İŞLEMİN AYRINTILARI";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 102, 144, 112, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @"İŞİN BAŞLANGIÇ
 TARİHİ";

                    NewField111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 102, 176, 112, false);
                    NewField111131.Name = "NewField111131";
                    NewField111131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111131.TextFont.CharSet = 162;
                    NewField111131.Value = @"İŞİN BİTİŞ 
TARİHİ";

                    NewField111141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 102, 231, 112, false);
                    NewField111141.Name = "NewField111141";
                    NewField111141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111141.TextFont.CharSet = 162;
                    NewField111141.Value = @"KULLANILAN YEDEK
 PARÇALARIN İSİMLERİ";

                    NewField111151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 102, 33, 112, false);
                    NewField111151.Name = "NewField111151";
                    NewField111151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111151.TextFont.CharSet = 162;
                    NewField111151.Value = @"ARIZA 
TARİHİ";

                    NewField1131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 102, 285, 112, false);
                    NewField1131111.Name = "NewField1131111";
                    NewField1131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131111.TextFont.CharSet = 162;
                    NewField1131111.Value = @"İŞİ YAPAN TEKNİK 
PERSONELİN KİMLİĞİ ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField161.CalcValue = NewField161.Value;
                    OWNERMILITARYUNIT1.CalcValue = @"";
                    FAMNAME1.CalcValue = @"";
                    NATOSTOCKNO1.CalcValue = @"";
                    MARK1.CalcValue = @"";
                    MODEL1.CalcValue = @"";
                    PRODUCTIONDATE1.CalcValue = @"";
                    SERIALNUMBER1.CalcValue = @"";
                    VOLTAGE1.CalcValue = @"";
                    FREQUENCY1.CalcValue = @"";
                    GUARANTYENDDATE1.CalcValue = @"";
                    PRODUCTIONDATE11.CalcValue = @"";
                    NewField101.CalcValue = NewField101.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField111131.CalcValue = NewField111131.Value;
                    NewField111141.CalcValue = NewField111141.Value;
                    NewField111151.CalcValue = NewField111151.Value;
                    NewField1131111.CalcValue = NewField1131111.Value;
                    HOSPITAL13.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField1121,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,NewField19,NewField111,NewField121,NewField161,OWNERMILITARYUNIT1,FAMNAME1,NATOSTOCKNO1,MARK1,MODEL1,PRODUCTIONDATE1,SERIALNUMBER1,VOLTAGE1,FREQUENCY1,GUARANTYENDDATE1,PRODUCTIONDATE11,NewField101,NewField131,NewField141,NewField11111,NewField111111,NewField111121,NewField111131,NewField111141,NewField111151,NewField1131111,HOSPITAL13};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    string objectID = ((BakimOnarimSicilKartı)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            FixedAssetMaterialDefinition fixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)ctx.GetObject(new Guid(objectID), typeof(FixedAssetMaterialDefinition));
            if(fixedAssetMaterialDefinition.FixedAssetDefinition != null)
            {
                this.FAMNAME1.CalcValue = fixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                this.NATOSTOCKNO1.CalcValue = fixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO;
            }
            if(fixedAssetMaterialDefinition.Model != null)
            {
                this.MODEL1.CalcValue = fixedAssetMaterialDefinition.Model;
            }
            if(fixedAssetMaterialDefinition.Mark != null)
            {
                this.MARK1.CalcValue = fixedAssetMaterialDefinition.Mark;
            }
            if(fixedAssetMaterialDefinition.Stock != null && fixedAssetMaterialDefinition.Stock.Store != null)
            {
                this.OWNERMILITARYUNIT1.CalcValue = fixedAssetMaterialDefinition.Stock.Store.Name;
            }
            if(fixedAssetMaterialDefinition.ProductionDate != null)
            {
                this.PRODUCTIONDATE1.CalcValue = ((DateTime)(fixedAssetMaterialDefinition.ProductionDate)).ToShortDateString();
                this.PRODUCTIONDATE11.CalcValue = ((DateTime)(fixedAssetMaterialDefinition.ProductionDate)).ToShortDateString();
            }
            if(fixedAssetMaterialDefinition.SerialNumber != null)
            {
                this.SERIALNUMBER1.CalcValue = fixedAssetMaterialDefinition.SerialNumber;
            }
            if(fixedAssetMaterialDefinition.Voltage != null)
            {
                this.VOLTAGE1.CalcValue = fixedAssetMaterialDefinition.Voltage;
            }
            if(fixedAssetMaterialDefinition.Frequency != null)
            {
                this.FREQUENCY1.CalcValue = fixedAssetMaterialDefinition.Frequency;
            }
            if(fixedAssetMaterialDefinition.GuarantyEndDate != null)
            {
                this.GUARANTYENDDATE1.CalcValue=((DateTime)(fixedAssetMaterialDefinition.GuarantyEndDate)).ToShortDateString();
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public BakimOnarimSicilKartı MyParentReport
                {
                    get { return (BakimOnarimSicilKartı)ParentReport; }
                }
                
                public TTReportField NewField11111561;
                public TTReportField NewField111511111;
                public TTReportField NewField112511111;
                public TTReportField NewField113511111;
                public TTReportField NewField114511111;
                public TTReportField NewField115511111;
                public TTReportField NewField116511111;
                public TTReportField NewField1111115111;
                public TTReportField NewField1111115311;
                public TTReportField NewField1111115211;
                public TTReportField NewField1111115411;
                public TTReportField NewField1111115511;
                public TTReportField NewField12111561;
                public TTReportField NewField121511111;
                public TTReportField NewField122511111;
                public TTReportField NewField123511111;
                public TTReportField NewField124511111;
                public TTReportField NewField125511111;
                public TTReportField NewField126511111;
                public TTReportField NewField1211115111;
                public TTReportField NewField1211115311;
                public TTReportField NewField1211115211;
                public TTReportField NewField1211115411;
                public TTReportField NewField1211115511;
                public TTReportField PrintDate1111;
                public TTReportField PageNumber1111;
                public TTReportField CurrentUser1111;
                public TTReportShape NewLine111111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 15, 179, 27, false);
                    NewField11111561.Name = "NewField11111561";
                    NewField11111561.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111561.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111561.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111561.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111561.TextFont.Size = 12;
                    NewField11111561.TextFont.CharSet = 162;
                    NewField11111561.Value = @"";

                    NewField111511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 15, 234, 27, false);
                    NewField111511111.Name = "NewField111511111";
                    NewField111511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111511111.TextFont.Size = 12;
                    NewField111511111.TextFont.CharSet = 162;
                    NewField111511111.Value = @"";

                    NewField112511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 21, 286, 27, false);
                    NewField112511111.Name = "NewField112511111";
                    NewField112511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112511111.TextFont.Size = 12;
                    NewField112511111.TextFont.CharSet = 162;
                    NewField112511111.Value = @"";

                    NewField113511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 15, 204, 27, false);
                    NewField113511111.Name = "NewField113511111";
                    NewField113511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113511111.TextFont.Size = 12;
                    NewField113511111.TextFont.CharSet = 162;
                    NewField113511111.Value = @"";

                    NewField114511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 21, 262, 27, false);
                    NewField114511111.Name = "NewField114511111";
                    NewField114511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114511111.TextFont.Size = 12;
                    NewField114511111.TextFont.CharSet = 162;
                    NewField114511111.Value = @"";

                    NewField115511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 15, 286, 21, false);
                    NewField115511111.Name = "NewField115511111";
                    NewField115511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField115511111.TextFont.Size = 12;
                    NewField115511111.TextFont.Bold = true;
                    NewField115511111.TextFont.CharSet = 162;
                    NewField115511111.Value = @"";

                    NewField116511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 15, 49, 27, false);
                    NewField116511111.Name = "NewField116511111";
                    NewField116511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField116511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField116511111.TextFont.Size = 12;
                    NewField116511111.TextFont.CharSet = 162;
                    NewField116511111.Value = @"";

                    NewField1111115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 15, 107, 27, false);
                    NewField1111115111.Name = "NewField1111115111";
                    NewField1111115111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111115111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111115111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111115111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111115111.TextFont.Size = 12;
                    NewField1111115111.TextFont.CharSet = 162;
                    NewField1111115111.Value = @"";

                    NewField1111115311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 15, 77, 27, false);
                    NewField1111115311.Name = "NewField1111115311";
                    NewField1111115311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111115311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111115311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111115311.TextFont.Size = 12;
                    NewField1111115311.TextFont.CharSet = 162;
                    NewField1111115311.Value = @"";

                    NewField1111115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 21, 151, 27, false);
                    NewField1111115211.Name = "NewField1111115211";
                    NewField1111115211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111115211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111115211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111115211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111115211.TextFont.Size = 12;
                    NewField1111115211.TextFont.CharSet = 162;
                    NewField1111115211.Value = @"";

                    NewField1111115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 21, 127, 27, false);
                    NewField1111115411.Name = "NewField1111115411";
                    NewField1111115411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111115411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111115411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111115411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111115411.TextFont.Size = 12;
                    NewField1111115411.TextFont.CharSet = 162;
                    NewField1111115411.Value = @"";

                    NewField1111115511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 15, 151, 21, false);
                    NewField1111115511.Name = "NewField1111115511";
                    NewField1111115511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111115511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111115511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111115511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111115511.TextFont.Size = 12;
                    NewField1111115511.TextFont.Bold = true;
                    NewField1111115511.TextFont.CharSet = 162;
                    NewField1111115511.Value = @"";

                    NewField12111561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 3, 179, 15, false);
                    NewField12111561.Name = "NewField12111561";
                    NewField12111561.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111561.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111561.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111561.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12111561.TextFont.Size = 12;
                    NewField12111561.TextFont.CharSet = 162;
                    NewField12111561.Value = @"Periyodik Bakım";

                    NewField121511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 3, 234, 15, false);
                    NewField121511111.Name = "NewField121511111";
                    NewField121511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121511111.TextFont.Size = 12;
                    NewField121511111.TextFont.CharSet = 162;
                    NewField121511111.Value = @"Bakım Süresi";

                    NewField122511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 9, 286, 15, false);
                    NewField122511111.Name = "NewField122511111";
                    NewField122511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122511111.TextFont.Size = 12;
                    NewField122511111.TextFont.CharSet = 162;
                    NewField122511111.Value = @"Kullanıcı";

                    NewField123511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 3, 204, 15, false);
                    NewField123511111.Name = "NewField123511111";
                    NewField123511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField123511111.TextFont.Size = 12;
                    NewField123511111.TextFont.CharSet = 162;
                    NewField123511111.Value = @"Tarih";

                    NewField124511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 9, 262, 15, false);
                    NewField124511111.Name = "NewField124511111";
                    NewField124511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField124511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField124511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField124511111.TextFont.Size = 12;
                    NewField124511111.TextFont.CharSet = 162;
                    NewField124511111.Value = @"Tek.Per.";

                    NewField125511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 3, 286, 9, false);
                    NewField125511111.Name = "NewField125511111";
                    NewField125511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField125511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField125511111.TextFont.Size = 12;
                    NewField125511111.TextFont.Bold = true;
                    NewField125511111.TextFont.CharSet = 162;
                    NewField125511111.Value = @"Adı Soyadı, İmza";

                    NewField126511111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 49, 15, false);
                    NewField126511111.Name = "NewField126511111";
                    NewField126511111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField126511111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField126511111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField126511111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField126511111.TextFont.Size = 12;
                    NewField126511111.TextFont.CharSet = 162;
                    NewField126511111.Value = @"Periyodik Bakım";

                    NewField1211115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 3, 107, 15, false);
                    NewField1211115111.Name = "NewField1211115111";
                    NewField1211115111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211115111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211115111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211115111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211115111.TextFont.Size = 12;
                    NewField1211115111.TextFont.CharSet = 162;
                    NewField1211115111.Value = @"Bakım Süresi";

                    NewField1211115311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 3, 77, 15, false);
                    NewField1211115311.Name = "NewField1211115311";
                    NewField1211115311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211115311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211115311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211115311.TextFont.Size = 12;
                    NewField1211115311.TextFont.CharSet = 162;
                    NewField1211115311.Value = @"Tarih";

                    NewField1211115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 9, 151, 15, false);
                    NewField1211115211.Name = "NewField1211115211";
                    NewField1211115211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211115211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211115211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211115211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211115211.TextFont.Size = 12;
                    NewField1211115211.TextFont.CharSet = 162;
                    NewField1211115211.Value = @"Kullanıcı";

                    NewField1211115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 9, 127, 15, false);
                    NewField1211115411.Name = "NewField1211115411";
                    NewField1211115411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211115411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211115411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211115411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211115411.TextFont.Size = 12;
                    NewField1211115411.TextFont.CharSet = 162;
                    NewField1211115411.Value = @"Tek.Per.";

                    NewField1211115511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 3, 151, 9, false);
                    NewField1211115511.Name = "NewField1211115511";
                    NewField1211115511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211115511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211115511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211115511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211115511.TextFont.Size = 12;
                    NewField1211115511.TextFont.Bold = true;
                    NewField1211115511.TextFont.CharSet = 162;
                    NewField1211115511.Value = @"Adı Soyadı, İmza";

                    PrintDate1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 30, 34, 35, false);
                    PrintDate1111.Name = "PrintDate1111";
                    PrintDate1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1111.TextFont.Size = 8;
                    PrintDate1111.TextFont.CharSet = 162;
                    PrintDate1111.Value = @"{@printdate@}";

                    PageNumber1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 30, 286, 35, false);
                    PageNumber1111.Name = "PageNumber1111";
                    PageNumber1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1111.TextFont.Size = 8;
                    PageNumber1111.TextFont.CharSet = 162;
                    PageNumber1111.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 30, 153, 35, false);
                    CurrentUser1111.Name = "CurrentUser1111";
                    CurrentUser1111.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1111.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1111.TextFont.Size = 8;
                    CurrentUser1111.TextFont.CharSet = 162;
                    CurrentUser1111.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 30, 286, 30, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111561.CalcValue = NewField11111561.Value;
                    NewField111511111.CalcValue = NewField111511111.Value;
                    NewField112511111.CalcValue = NewField112511111.Value;
                    NewField113511111.CalcValue = NewField113511111.Value;
                    NewField114511111.CalcValue = NewField114511111.Value;
                    NewField115511111.CalcValue = NewField115511111.Value;
                    NewField116511111.CalcValue = NewField116511111.Value;
                    NewField1111115111.CalcValue = NewField1111115111.Value;
                    NewField1111115311.CalcValue = NewField1111115311.Value;
                    NewField1111115211.CalcValue = NewField1111115211.Value;
                    NewField1111115411.CalcValue = NewField1111115411.Value;
                    NewField1111115511.CalcValue = NewField1111115511.Value;
                    NewField12111561.CalcValue = NewField12111561.Value;
                    NewField121511111.CalcValue = NewField121511111.Value;
                    NewField122511111.CalcValue = NewField122511111.Value;
                    NewField123511111.CalcValue = NewField123511111.Value;
                    NewField124511111.CalcValue = NewField124511111.Value;
                    NewField125511111.CalcValue = NewField125511111.Value;
                    NewField126511111.CalcValue = NewField126511111.Value;
                    NewField1211115111.CalcValue = NewField1211115111.Value;
                    NewField1211115311.CalcValue = NewField1211115311.Value;
                    NewField1211115211.CalcValue = NewField1211115211.Value;
                    NewField1211115411.CalcValue = NewField1211115411.Value;
                    NewField1211115511.CalcValue = NewField1211115511.Value;
                    PrintDate1111.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1111.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1111.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { NewField11111561,NewField111511111,NewField112511111,NewField113511111,NewField114511111,NewField115511111,NewField116511111,NewField1111115111,NewField1111115311,NewField1111115211,NewField1111115411,NewField1111115511,NewField12111561,NewField121511111,NewField122511111,NewField123511111,NewField124511111,NewField125511111,NewField126511111,NewField1211115111,NewField1211115311,NewField1211115211,NewField1211115411,NewField1211115511,PrintDate1111,PageNumber1111,CurrentUser1111};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public BakimOnarimSicilKartı MyParentReport
            {
                get { return (BakimOnarimSicilKartı)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DELIVERYDATE { get {return Body().DELIVERYDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField USEDMATERIAL { get {return Body().USEDMATERIAL;} }
            public TTReportField RESPONSIBLEUSER { get {return Body().RESPONSIBLEUSER;} }
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
                list[0] = new TTReportNqlData<Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class>("GetMaintenanceAndRepairRegistryCardReportQueryNEW", Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public BakimOnarimSicilKartı MyParentReport
                {
                    get { return (BakimOnarimSicilKartı)ParentReport; }
                }
                
                public TTReportField REQUESTDATE;
                public TTReportField REQUESTNO;
                public TTReportField DESCRIPTION;
                public TTReportField DELIVERYDATE;
                public TTReportField ENDDATE;
                public TTReportField USEDMATERIAL;
                public TTReportField RESPONSIBLEUSER; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 33, 9, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 60, 9, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTNO.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTNO.TextFont.Size = 9;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 112, 9, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 144, 9, false);
                    DELIVERYDATE.Name = "DELIVERYDATE";
                    DELIVERYDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERYDATE.TextFormat = @"Short Date";
                    DELIVERYDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVERYDATE.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVERYDATE.WordBreak = EvetHayirEnum.ehEvet;
                    DELIVERYDATE.TextFont.Size = 9;
                    DELIVERYDATE.TextFont.CharSet = 162;
                    DELIVERYDATE.Value = @"{#DELIVERYDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 176, 9, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    USEDMATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 231, 9, false);
                    USEDMATERIAL.Name = "USEDMATERIAL";
                    USEDMATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    USEDMATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDMATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    USEDMATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    USEDMATERIAL.TextFont.Size = 9;
                    USEDMATERIAL.TextFont.CharSet = 162;
                    USEDMATERIAL.Value = @"{#USEDMATERIAL#}";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 285, 9, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.MultiLine = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.WordBreak = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.TextFont.Size = 9;
                    RESPONSIBLEUSER.TextFont.CharSet = 162;
                    RESPONSIBLEUSER.Value = @"{#RESPONSIBLEUSER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class>(0);
                    REQUESTDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.RequestDate) : "");
                    REQUESTNO.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.RequestNo) : "");
                    DESCRIPTION.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.Description) : "");
                    DELIVERYDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.DeliveryDate) : "");
                    ENDDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.EndDate) : "");
                    USEDMATERIAL.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.Usedmaterial) : "");
                    RESPONSIBLEUSER.CalcValue = (dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryCardReportQueryNEW.Responsibleuser) : "");
                    return new TTReportObject[] { REQUESTDATE,REQUESTNO,DESCRIPTION,DELIVERYDATE,ENDDATE,USEDMATERIAL,RESPONSIBLEUSER};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BakimOnarimSicilKartı()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Tıbbi Cihaz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("a45073d2-3e80-4264-b596-1d4962072c8e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "BAKIMONARIMSICILKARTı";
            Caption = "Tıbbli Cihaz Sicil Kartı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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