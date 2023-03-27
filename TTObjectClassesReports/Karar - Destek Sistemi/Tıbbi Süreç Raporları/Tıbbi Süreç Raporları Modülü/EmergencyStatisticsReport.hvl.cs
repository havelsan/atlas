
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
    /// Acil Servis Sağlık İstatistikleri
    /// </summary>
    public partial class EmergencyStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EmergencyStatisticsReport MyParentReport
            {
                get { return (EmergencyStatisticsReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField FVSTARTDATE1 { get {return Header().FVSTARTDATE1;} }
            public TTReportField FVENDDATE1 { get {return Header().FVENDDATE1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField edate { get {return Header().edate;} }
            public TTReportField sdate { get {return Header().sdate;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11011 { get {return Header().NewField11011;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField1111141111 { get {return Header().NewField1111141111;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField NewField111811 { get {return Header().NewField111811;} }
            public TTReportField NewField111511 { get {return Header().NewField111511;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField112811 { get {return Header().NewField112811;} }
            public TTReportField NewField11821 { get {return Header().NewField11821;} }
            public TTReportField NewField112821 { get {return Header().NewField112821;} }
            public TTReportField NewField1128211 { get {return Header().NewField1128211;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField lblGenelToplam { get {return Footer().lblGenelToplam;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportField SUBAY { get {return Footer().SUBAY;} }
            public TTReportField ASTSUBAY { get {return Footer().ASTSUBAY;} }
            public TTReportField SIVILMEMUR { get {return Footer().SIVILMEMUR;} }
            public TTReportField UZMANERBAS { get {return Footer().UZMANERBAS;} }
            public TTReportField ERERBAS { get {return Footer().ERERBAS;} }
            public TTReportField OGRENCI { get {return Footer().OGRENCI;} }
            public TTReportField EMEKLI { get {return Footer().EMEKLI;} }
            public TTReportField SIVIL { get {return Footer().SIVIL;} }
            public TTReportField HIZMETDISITOTAL { get {return Footer().HIZMETDISITOTAL;} }
            public TTReportField UZMANJANDARMA { get {return Footer().UZMANJANDARMA;} }
            public TTReportField DIGERHIZMETICI { get {return Footer().DIGERHIZMETICI;} }
            public TTReportField DIGERHIZMETDISI { get {return Footer().DIGERHIZMETDISI;} }
            public TTReportField XXXXXXIPERSONELAILE { get {return Footer().XXXXXXIPERSONELAILE;} }
            public TTReportField XXXXXXIEMEKLIAILE { get {return Footer().XXXXXXIEMEKLIAILE;} }
            public TTReportField GENELTOTAL { get {return Footer().GENELTOTAL;} }
            public TTReportField HIZMETICITOTAL { get {return Footer().HIZMETICITOTAL;} }
            public TTReportField GENERALAMIRAL { get {return Footer().GENERALAMIRAL;} }
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
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                
                public TTReportField FVSTARTDATE1;
                public TTReportField FVENDDATE1;
                public TTReportField NewField13;
                public TTReportField edate;
                public TTReportField sdate;
                public TTReportShape NewLine12;
                public TTReportField NewField1;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField11211;
                public TTReportField NewField1181;
                public TTReportField NewField1191;
                public TTReportField NewField11011;
                public TTReportField NewField11111;
                public TTReportField NewField11411;
                public TTReportField NewField11511;
                public TTReportField NewField11811;
                public TTReportField NewField11311;
                public TTReportField NewField111411;
                public TTReportField NewField1111141111;
                public TTReportField NewField111611;
                public TTReportField NewField111811;
                public TTReportField NewField111511;
                public TTReportField NewField111111;
                public TTReportField NewField112811;
                public TTReportField NewField11821;
                public TTReportField NewField112821;
                public TTReportField NewField1128211;
                public TTReportField NewField2; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FVSTARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 17, 214, 21, false);
                    FVSTARTDATE1.Name = "FVSTARTDATE1";
                    FVSTARTDATE1.Visible = EvetHayirEnum.ehHayir;
                    FVSTARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FVSTARTDATE1.TextFormat = @"yyyy-mm-dd hh:mm";
                    FVSTARTDATE1.TextFont.Name = "Courier New";
                    FVSTARTDATE1.TextFont.CharSet = 162;
                    FVSTARTDATE1.Value = @"{@STARTDATE@}";

                    FVENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, 16, 303, 21, false);
                    FVENDDATE1.Name = "FVENDDATE1";
                    FVENDDATE1.Visible = EvetHayirEnum.ehHayir;
                    FVENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FVENDDATE1.TextFormat = @"yyyy-mm-dd hh:mm";
                    FVENDDATE1.TextFont.Name = "Courier New";
                    FVENDDATE1.TextFont.CharSet = 162;
                    FVENDDATE1.Value = @"{@ENDDATE@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 22, 29, 27, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Tarih Aralığı : ";

                    edate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 22, 94, 27, false);
                    edate.Name = "edate";
                    edate.FieldType = ReportFieldTypeEnum.ftVariable;
                    edate.TextFormat = @"dd/MM/yyyy HH:mm";
                    edate.TextFont.CharSet = 162;
                    edate.Value = @"{@ENDDATE@}";

                    sdate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 22, 58, 27, false);
                    sdate.Name = "sdate";
                    sdate.FieldType = ReportFieldTypeEnum.ftVariable;
                    sdate.TextFormat = @"dd/MM/yyyy HH:mm";
                    sdate.TextFont.CharSet = 162;
                    sdate.Value = @"{@STARTDATE@}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 25, 64, 25, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 13, 386, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GÜNLÜK SAĞLIK FAALİYETLERİ
(AYAKTAN HASTA)";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 7, 386, 13, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.TextFont.CharSet = 162;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 283, 14, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"", """")";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 28, 173, 37, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Er
Erbaş";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 28, 118, 37, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"Subay";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 28, 129, 37, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Ast
Subay";

                    NewField11011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 28, 140, 37, false);
                    NewField11011.Name = "NewField11011";
                    NewField11011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11011.TextFont.Size = 9;
                    NewField11011.TextFont.Bold = true;
                    NewField11011.TextFont.CharSet = 162;
                    NewField11011.Value = @"Sivil
Memur";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 28, 151, 37, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Uzman
Erbaş";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 28, 239, 37, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Emekli";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 28, 217, 37, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11511.TextFont.Size = 9;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Ask.Per.
Ailesi";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 28, 272, 37, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11811.TextFont.Size = 9;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @"Toplam";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 28, 184, 37, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"XXXXXX
Öğrenci";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 28, 195, 37, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111411.TextFont.Size = 9;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Diğer
";

                    NewField1111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 28, 261, 37, false);
                    NewField1111141111.Name = "NewField1111141111";
                    NewField1111141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111141111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111141111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111141111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111141111.TextFont.Size = 9;
                    NewField1111141111.TextFont.Bold = true;
                    NewField1111141111.TextFont.CharSet = 162;
                    NewField1111141111.Value = @"Diğer
";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 28, 250, 37, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111611.TextFont.Size = 9;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"Sivil";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 28, 283, 37, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111811.TextFont.Size = 9;
                    NewField111811.TextFont.Bold = true;
                    NewField111811.TextFont.CharSet = 162;
                    NewField111811.Value = @"Genel
Toplam";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 28, 228, 37, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111511.TextFont.Size = 9;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.TextFont.CharSet = 162;
                    NewField111511.Value = @"Ask. Em.
Ailesi";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 28, 162, 37, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Size = 9;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Uzman
Jan.";

                    NewField112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 28, 206, 37, false);
                    NewField112811.Name = "NewField112811";
                    NewField112811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112811.TextFont.Size = 9;
                    NewField112811.TextFont.Bold = true;
                    NewField112811.TextFont.CharSet = 162;
                    NewField112811.Value = @"Toplam";

                    NewField11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 28, 107, 37, false);
                    NewField11821.Name = "NewField11821";
                    NewField11821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11821.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11821.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11821.TextFont.Size = 9;
                    NewField11821.TextFont.Bold = true;
                    NewField11821.TextFont.CharSet = 162;
                    NewField11821.Value = @"General/
Amiral";

                    NewField112821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 22, 206, 28, false);
                    NewField112821.Name = "NewField112821";
                    NewField112821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112821.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112821.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112821.TextFont.Size = 9;
                    NewField112821.TextFont.Bold = true;
                    NewField112821.TextFont.CharSet = 162;
                    NewField112821.Value = @"HİZMET İÇİ (MUVAZZAF)";

                    NewField1128211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 22, 283, 28, false);
                    NewField1128211.Name = "NewField1128211";
                    NewField1128211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1128211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1128211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1128211.TextFont.Size = 9;
                    NewField1128211.TextFont.Bold = true;
                    NewField1128211.TextFont.CharSet = 162;
                    NewField1128211.Value = @"HİZMET DIŞI (EMEKLİ/SİVİL)";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 283, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"", """") + "" GÜNLÜK SAĞLIK FAALİYETLERİ (ACİL HASTA)""";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FVSTARTDATE1.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    FVENDDATE1.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField13.CalcValue = NewField13.Value;
                    edate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    sdate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11011.CalcValue = NewField11011.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField1111141111.CalcValue = NewField1111141111.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField112811.CalcValue = NewField112811.Value;
                    NewField11821.CalcValue = NewField11821.Value;
                    NewField112821.CalcValue = NewField112821.Value;
                    NewField1128211.CalcValue = NewField1128211.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER", "");
                    NewField2.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER", "") + " GÜNLÜK SAĞLIK FAALİYETLERİ (ACİL HASTA)";
                    return new TTReportObject[] { FVSTARTDATE1,FVENDDATE1,NewField13,edate,sdate,NewField1,NewField11211,NewField1181,NewField1191,NewField11011,NewField11111,NewField11411,NewField11511,NewField11811,NewField11311,NewField111411,NewField1111141111,NewField111611,NewField111811,NewField111511,NewField111111,NewField112811,NewField11821,NewField112821,NewField1128211,XXXXXXIL,XXXXXXBASLIK,NewField2};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    TTReportTool.TTReportGroup g = ((EmergencyStatisticsReport)ParentReport).Groups("HEADER");
            g.Fields("OGRENCI").Value = "0";
            g.Fields("DIGERHIZMETICI").Value = "0";
            g.Fields("SIVIL").Value = "0";
            g.Fields("UZMANJANDARMA").Value = "0";
            g.Fields("UZMANERBAS").Value = "0";
            g.Fields("SIVILMEMUR").Value = "0";
            g.Fields("XXXXXXIPERSONELAILE").Value = "0";
            g.Fields("ASTSUBAY").Value = "0";
            g.Fields("GENERALAMIRAL").Value = "0";
            g.Fields("SUBAY").Value = "0";
            g.Fields("ERERBAS").Value = "0";
            g.Fields("EMEKLI").Value = "0";
            g.Fields("XXXXXXIEMEKLIAILE").Value = "0";
            g.Fields("DIGERHIZMETDISI").Value = "0";
#endregion HEADER HEADER_PreScript
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                
                public TTReportField TOPLAM;
                public TTReportField lblGenelToplam;
                public TTReportField GENELTOPLAM;
                public TTReportField SUBAY;
                public TTReportField ASTSUBAY;
                public TTReportField SIVILMEMUR;
                public TTReportField UZMANERBAS;
                public TTReportField ERERBAS;
                public TTReportField OGRENCI;
                public TTReportField EMEKLI;
                public TTReportField SIVIL;
                public TTReportField HIZMETDISITOTAL;
                public TTReportField UZMANJANDARMA;
                public TTReportField DIGERHIZMETICI;
                public TTReportField DIGERHIZMETDISI;
                public TTReportField XXXXXXIPERSONELAILE;
                public TTReportField XXXXXXIEMEKLIAILE;
                public TTReportField GENELTOTAL;
                public TTReportField HIZMETICITOTAL;
                public TTReportField GENERALAMIRAL; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 96, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.TextFont.Size = 9;
                    TOPLAM.TextFont.Bold = true;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"TOPLAM";

                    lblGenelToplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 96, 10, false);
                    lblGenelToplam.Name = "lblGenelToplam";
                    lblGenelToplam.DrawStyle = DrawStyleConstants.vbSolid;
                    lblGenelToplam.TextFont.Size = 9;
                    lblGenelToplam.TextFont.Bold = true;
                    lblGenelToplam.TextFont.CharSet = 162;
                    lblGenelToplam.Value = @"GENEL TOPLAM";

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 5, 118, 10, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOPLAM.FieldType = ReportFieldTypeEnum.ftExpression;
                    GENELTOPLAM.TextFont.Size = 9;
                    GENELTOPLAM.TextFont.Bold = true;
                    GENELTOPLAM.TextFont.CharSet = 162;
                    GENELTOPLAM.Value = @"(Convert.ToInt32({%GENERALAMIRAL%})+Convert.ToInt32({%SUBAY%})+Convert.ToInt32({%ASTSUBAY%})+Convert.ToInt32({%SIVILMEMUR%})+Convert.ToInt32({%UZMANERBAS%})+Convert.ToInt32({%UZMANJANDARMA%})+Convert.ToInt32({%ERERBAS%})+Convert.ToInt32({%OGRENCI%})+Convert.ToInt32({%DIGERHIZMETICI%})+Convert.ToInt32({%DIGERHIZMETDISI%})+Convert.ToInt32({%XXXXXXIPERSONELAILE%})+Convert.ToInt32({%XXXXXXIEMEKLIAILE%})+Convert.ToInt32({%EMEKLI%})+Convert.ToInt32({%SIVIL%})).ToString()";

                    SUBAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 118, 5, false);
                    SUBAY.Name = "SUBAY";
                    SUBAY.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBAY.TextFont.Size = 9;
                    SUBAY.TextFont.CharSet = 162;
                    SUBAY.Value = @"0";

                    ASTSUBAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 129, 5, false);
                    ASTSUBAY.Name = "ASTSUBAY";
                    ASTSUBAY.DrawStyle = DrawStyleConstants.vbSolid;
                    ASTSUBAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASTSUBAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ASTSUBAY.TextFont.Size = 9;
                    ASTSUBAY.TextFont.CharSet = 162;
                    ASTSUBAY.Value = @"0";

                    SIVILMEMUR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 140, 5, false);
                    SIVILMEMUR.Name = "SIVILMEMUR";
                    SIVILMEMUR.DrawStyle = DrawStyleConstants.vbSolid;
                    SIVILMEMUR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIVILMEMUR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIVILMEMUR.TextFont.Size = 9;
                    SIVILMEMUR.TextFont.CharSet = 162;
                    SIVILMEMUR.Value = @"0";

                    UZMANERBAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 151, 5, false);
                    UZMANERBAS.Name = "UZMANERBAS";
                    UZMANERBAS.DrawStyle = DrawStyleConstants.vbSolid;
                    UZMANERBAS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANERBAS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANERBAS.TextFont.Size = 9;
                    UZMANERBAS.TextFont.CharSet = 162;
                    UZMANERBAS.Value = @"0";

                    ERERBAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 173, 5, false);
                    ERERBAS.Name = "ERERBAS";
                    ERERBAS.DrawStyle = DrawStyleConstants.vbSolid;
                    ERERBAS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ERERBAS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ERERBAS.TextFont.Size = 9;
                    ERERBAS.TextFont.CharSet = 162;
                    ERERBAS.Value = @"0";

                    OGRENCI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 0, 184, 5, false);
                    OGRENCI.Name = "OGRENCI";
                    OGRENCI.DrawStyle = DrawStyleConstants.vbSolid;
                    OGRENCI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OGRENCI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OGRENCI.TextFont.Size = 9;
                    OGRENCI.TextFont.CharSet = 162;
                    OGRENCI.Value = @"0";

                    EMEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 239, 5, false);
                    EMEKLI.Name = "EMEKLI";
                    EMEKLI.DrawStyle = DrawStyleConstants.vbSolid;
                    EMEKLI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EMEKLI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMEKLI.TextFont.Size = 9;
                    EMEKLI.TextFont.CharSet = 162;
                    EMEKLI.Value = @"0";

                    SIVIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 250, 5, false);
                    SIVIL.Name = "SIVIL";
                    SIVIL.DrawStyle = DrawStyleConstants.vbSolid;
                    SIVIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIVIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIVIL.TextFont.Size = 9;
                    SIVIL.TextFont.CharSet = 162;
                    SIVIL.Value = @"0";

                    HIZMETDISITOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 0, 272, 5, false);
                    HIZMETDISITOTAL.Name = "HIZMETDISITOTAL";
                    HIZMETDISITOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    HIZMETDISITOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HIZMETDISITOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETDISITOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETDISITOTAL.TextFont.Size = 9;
                    HIZMETDISITOTAL.TextFont.Bold = true;
                    HIZMETDISITOTAL.TextFont.CharSet = 162;
                    HIZMETDISITOTAL.Value = @"(Convert.ToInt32({%DIGERHIZMETDISI%})+Convert.ToInt32({%XXXXXXIPERSONELAILE%})+Convert.ToInt32({%XXXXXXIEMEKLIAILE%})+Convert.ToInt32({%EMEKLI%})+Convert.ToInt32({%SIVIL%})).ToString()";

                    UZMANJANDARMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 162, 5, false);
                    UZMANJANDARMA.Name = "UZMANJANDARMA";
                    UZMANJANDARMA.DrawStyle = DrawStyleConstants.vbSolid;
                    UZMANJANDARMA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANJANDARMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANJANDARMA.TextFont.Size = 9;
                    UZMANJANDARMA.TextFont.CharSet = 162;
                    UZMANJANDARMA.Value = @"0";

                    DIGERHIZMETICI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 195, 5, false);
                    DIGERHIZMETICI.Name = "DIGERHIZMETICI";
                    DIGERHIZMETICI.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGERHIZMETICI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGERHIZMETICI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIGERHIZMETICI.TextFont.Size = 9;
                    DIGERHIZMETICI.TextFont.CharSet = 162;
                    DIGERHIZMETICI.Value = @"0";

                    DIGERHIZMETDISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 261, 5, false);
                    DIGERHIZMETDISI.Name = "DIGERHIZMETDISI";
                    DIGERHIZMETDISI.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGERHIZMETDISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGERHIZMETDISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIGERHIZMETDISI.TextFont.Size = 9;
                    DIGERHIZMETDISI.TextFont.CharSet = 162;
                    DIGERHIZMETDISI.Value = @"0";

                    XXXXXXIPERSONELAILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 0, 217, 5, false);
                    XXXXXXIPERSONELAILE.Name = "XXXXXXIPERSONELAILE";
                    XXXXXXIPERSONELAILE.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXIPERSONELAILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIPERSONELAILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIPERSONELAILE.TextFont.Size = 9;
                    XXXXXXIPERSONELAILE.TextFont.CharSet = 162;
                    XXXXXXIPERSONELAILE.Value = @"0";

                    XXXXXXIEMEKLIAILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 228, 5, false);
                    XXXXXXIEMEKLIAILE.Name = "XXXXXXIEMEKLIAILE";
                    XXXXXXIEMEKLIAILE.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXIEMEKLIAILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIEMEKLIAILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIEMEKLIAILE.TextFont.Size = 9;
                    XXXXXXIEMEKLIAILE.TextFont.CharSet = 162;
                    XXXXXXIEMEKLIAILE.Value = @"0";

                    GENELTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 0, 283, 5, false);
                    GENELTOTAL.Name = "GENELTOTAL";
                    GENELTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    GENELTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENELTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENELTOTAL.TextFont.Size = 9;
                    GENELTOTAL.TextFont.Bold = true;
                    GENELTOTAL.TextFont.CharSet = 162;
                    GENELTOTAL.Value = @"(Convert.ToInt32({%GENERALAMIRAL%})+Convert.ToInt32({%SUBAY%})+Convert.ToInt32({%ASTSUBAY%})+Convert.ToInt32({%SIVILMEMUR%})+Convert.ToInt32({%UZMANERBAS%})+Convert.ToInt32({%UZMANJANDARMA%})+Convert.ToInt32({%ERERBAS%})+Convert.ToInt32({%OGRENCI%})+Convert.ToInt32({%DIGERHIZMETICI%})+Convert.ToInt32({%DIGERHIZMETDISI%})+Convert.ToInt32({%XXXXXXIPERSONELAILE%})+Convert.ToInt32({%XXXXXXIEMEKLIAILE%})+Convert.ToInt32({%EMEKLI%})+Convert.ToInt32({%SIVIL%})).ToString()";

                    HIZMETICITOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 206, 5, false);
                    HIZMETICITOTAL.Name = "HIZMETICITOTAL";
                    HIZMETICITOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    HIZMETICITOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HIZMETICITOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETICITOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETICITOTAL.TextFont.Size = 9;
                    HIZMETICITOTAL.TextFont.Bold = true;
                    HIZMETICITOTAL.TextFont.CharSet = 162;
                    HIZMETICITOTAL.Value = @"(Convert.ToInt32({%GENERALAMIRAL%})+Convert.ToInt32({%SUBAY%})+Convert.ToInt32({%ASTSUBAY%})+Convert.ToInt32({%SIVILMEMUR%})+Convert.ToInt32({%UZMANERBAS%})+Convert.ToInt32({%UZMANJANDARMA%})+Convert.ToInt32({%ERERBAS%})+Convert.ToInt32({%OGRENCI%})+Convert.ToInt32({%DIGERHIZMETICI%})).ToString()";

                    GENERALAMIRAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 107, 5, false);
                    GENERALAMIRAL.Name = "GENERALAMIRAL";
                    GENERALAMIRAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENERALAMIRAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENERALAMIRAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENERALAMIRAL.TextFont.Size = 9;
                    GENERALAMIRAL.TextFont.CharSet = 162;
                    GENERALAMIRAL.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAM.CalcValue = TOPLAM.Value;
                    lblGenelToplam.CalcValue = lblGenelToplam.Value;
                    SUBAY.CalcValue = SUBAY.Value;
                    ASTSUBAY.CalcValue = ASTSUBAY.Value;
                    SIVILMEMUR.CalcValue = SIVILMEMUR.Value;
                    UZMANERBAS.CalcValue = UZMANERBAS.Value;
                    ERERBAS.CalcValue = ERERBAS.Value;
                    OGRENCI.CalcValue = OGRENCI.Value;
                    EMEKLI.CalcValue = EMEKLI.Value;
                    SIVIL.CalcValue = SIVIL.Value;
                    UZMANJANDARMA.CalcValue = UZMANJANDARMA.Value;
                    DIGERHIZMETICI.CalcValue = DIGERHIZMETICI.Value;
                    DIGERHIZMETDISI.CalcValue = DIGERHIZMETDISI.Value;
                    XXXXXXIPERSONELAILE.CalcValue = XXXXXXIPERSONELAILE.Value;
                    XXXXXXIEMEKLIAILE.CalcValue = XXXXXXIEMEKLIAILE.Value;
                    GENERALAMIRAL.CalcValue = GENERALAMIRAL.Value;
                    GENELTOPLAM.CalcValue = (Convert.ToInt32(MyParentReport.HEADER.GENERALAMIRAL.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SUBAY.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.ASTSUBAY.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SIVILMEMUR.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.UZMANERBAS.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.UZMANJANDARMA.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.ERERBAS.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.OGRENCI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.DIGERHIZMETICI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.DIGERHIZMETDISI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.XXXXXXIPERSONELAILE.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.XXXXXXIEMEKLIAILE.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.EMEKLI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SIVIL.CalcValue)).ToString();
                    HIZMETDISITOTAL.CalcValue = (Convert.ToInt32(MyParentReport.HEADER.DIGERHIZMETDISI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.XXXXXXIPERSONELAILE.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.XXXXXXIEMEKLIAILE.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.EMEKLI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SIVIL.CalcValue)).ToString();
                    GENELTOTAL.CalcValue = (Convert.ToInt32(MyParentReport.HEADER.GENERALAMIRAL.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SUBAY.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.ASTSUBAY.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SIVILMEMUR.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.UZMANERBAS.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.UZMANJANDARMA.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.ERERBAS.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.OGRENCI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.DIGERHIZMETICI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.DIGERHIZMETDISI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.XXXXXXIPERSONELAILE.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.XXXXXXIEMEKLIAILE.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.EMEKLI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SIVIL.CalcValue)).ToString();
                    HIZMETICITOTAL.CalcValue = (Convert.ToInt32(MyParentReport.HEADER.GENERALAMIRAL.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SUBAY.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.ASTSUBAY.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.SIVILMEMUR.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.UZMANERBAS.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.UZMANJANDARMA.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.ERERBAS.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.OGRENCI.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.DIGERHIZMETICI.CalcValue)).ToString();
                    return new TTReportObject[] { TOPLAM,lblGenelToplam,SUBAY,ASTSUBAY,SIVILMEMUR,UZMANERBAS,ERERBAS,OGRENCI,EMEKLI,SIVIL,UZMANJANDARMA,DIGERHIZMETICI,DIGERHIZMETDISI,XXXXXXIPERSONELAILE,XXXXXXIEMEKLIAILE,GENERALAMIRAL,GENELTOPLAM,HIZMETDISITOTAL,GENELTOTAL,HIZMETICITOTAL};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public EmergencyStatisticsReport MyParentReport
            {
                get { return (EmergencyStatisticsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ResClinic.GetEmergencyClinics_Class>("GetEmergencyClinics", ResClinic.GetEmergencyClinics());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                
                public TTReportField OBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 45, 12, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResClinic.GetEmergencyClinics_Class dataset_GetEmergencyClinics = ParentGroup.rsGroup.GetCurrentRecord<ResClinic.GetEmergencyClinics_Class>(0);
                    OBJECTID.CalcValue = (dataset_GetEmergencyClinics != null ? Globals.ToStringCore(dataset_GetEmergencyClinics.ObjectID) : "");
                    return new TTReportObject[] { OBJECTID};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class SUBAYGroup : TTReportGroup
        {
            public EmergencyStatisticsReport MyParentReport
            {
                get { return (EmergencyStatisticsReport)ParentReport; }
            }

            new public SUBAYGroupHeader Header()
            {
                return (SUBAYGroupHeader)_header;
            }

            new public SUBAYGroupFooter Footer()
            {
                return (SUBAYGroupFooter)_footer;
            }

            public TTReportField BIRIM { get {return Footer().BIRIM;} }
            public TTReportField SUBAY { get {return Footer().SUBAY;} }
            public TTReportField ASTSUBAY { get {return Footer().ASTSUBAY;} }
            public TTReportField SIVILMEMUR { get {return Footer().SIVILMEMUR;} }
            public TTReportField UZMANERBAS { get {return Footer().UZMANERBAS;} }
            public TTReportField ERERBAS { get {return Footer().ERERBAS;} }
            public TTReportField OGRENCI { get {return Footer().OGRENCI;} }
            public TTReportField EMEKLI { get {return Footer().EMEKLI;} }
            public TTReportField SIVIL { get {return Footer().SIVIL;} }
            public TTReportField HIZMETDISITOTAL { get {return Footer().HIZMETDISITOTAL;} }
            public TTReportField UZMANJANDARMA { get {return Footer().UZMANJANDARMA;} }
            public TTReportField DIGERHIZMETICI { get {return Footer().DIGERHIZMETICI;} }
            public TTReportField DIGERHIZMETDISI { get {return Footer().DIGERHIZMETDISI;} }
            public TTReportField XXXXXXIPERSONELAILE { get {return Footer().XXXXXXIPERSONELAILE;} }
            public TTReportField XXXXXXIEMEKLIAILE { get {return Footer().XXXXXXIEMEKLIAILE;} }
            public TTReportField GENELTOTAL { get {return Footer().GENELTOTAL;} }
            public TTReportField HIZMETICITOTAL { get {return Footer().HIZMETICITOTAL;} }
            public TTReportField GENERALAMIRAL { get {return Footer().GENERALAMIRAL;} }
            public SUBAYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBAYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.GetEpisodeActionsByRequestDate_Class>("GetEpisodeActionsByRequestDate", EpisodeAction.GetEpisodeActionsByRequestDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTA.OBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SUBAYGroupHeader(this);
                _footer = new SUBAYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SUBAYGroupHeader : TTReportSection
            {
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                 
                public SUBAYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
                public override void RunPreScript()
                {
#region SUBAY HEADER_PreScript
                    TTReportTool.TTReportGroup pg = ((EmergencyStatisticsReport)ParentReport).Groups("SUBAY");
            pg.Fields("OGRENCI").Value = "0";
            pg.Fields("DIGERHIZMETICI").Value = "0";
            pg.Fields("SIVIL").Value = "0";
            pg.Fields("UZMANJANDARMA").Value = "0";
            pg.Fields("UZMANERBAS").Value = "0";
            pg.Fields("SIVILMEMUR").Value = "0";
            pg.Fields("XXXXXXIPERSONELAILE").Value = "0";
            pg.Fields("ASTSUBAY").Value = "0";
            pg.Fields("GENERALAMIRAL").Value = "0";
            pg.Fields("SUBAY").Value = "0";
            pg.Fields("ERERBAS").Value = "0";
            pg.Fields("EMEKLI").Value = "0";
            pg.Fields("XXXXXXIEMEKLIAILE").Value = "0";
            pg.Fields("DIGERHIZMETDISI").Value = "0";
#endregion SUBAY HEADER_PreScript
                }
            }
            public partial class SUBAYGroupFooter : TTReportSection
            {
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                
                public TTReportField BIRIM;
                public TTReportField SUBAY;
                public TTReportField ASTSUBAY;
                public TTReportField SIVILMEMUR;
                public TTReportField UZMANERBAS;
                public TTReportField ERERBAS;
                public TTReportField OGRENCI;
                public TTReportField EMEKLI;
                public TTReportField SIVIL;
                public TTReportField HIZMETDISITOTAL;
                public TTReportField UZMANJANDARMA;
                public TTReportField DIGERHIZMETICI;
                public TTReportField DIGERHIZMETDISI;
                public TTReportField XXXXXXIPERSONELAILE;
                public TTReportField XXXXXXIEMEKLIAILE;
                public TTReportField GENELTOTAL;
                public TTReportField HIZMETICITOTAL;
                public TTReportField GENERALAMIRAL; 
                public SUBAYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 97, 5, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.ObjectDefName = "resource";
                    BIRIM.DataMember = "Name";
                    BIRIM.TextFont.Size = 8;
                    BIRIM.TextFont.Bold = true;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#MASTERRESOURCE#}";

                    SUBAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 118, 5, false);
                    SUBAY.Name = "SUBAY";
                    SUBAY.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBAY.TextFont.Size = 9;
                    SUBAY.TextFont.CharSet = 162;
                    SUBAY.Value = @"0";

                    ASTSUBAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 129, 5, false);
                    ASTSUBAY.Name = "ASTSUBAY";
                    ASTSUBAY.DrawStyle = DrawStyleConstants.vbSolid;
                    ASTSUBAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASTSUBAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ASTSUBAY.TextFont.Size = 9;
                    ASTSUBAY.TextFont.CharSet = 162;
                    ASTSUBAY.Value = @"0";

                    SIVILMEMUR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 140, 5, false);
                    SIVILMEMUR.Name = "SIVILMEMUR";
                    SIVILMEMUR.DrawStyle = DrawStyleConstants.vbSolid;
                    SIVILMEMUR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIVILMEMUR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIVILMEMUR.TextFont.Size = 9;
                    SIVILMEMUR.TextFont.CharSet = 162;
                    SIVILMEMUR.Value = @"0";

                    UZMANERBAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 151, 5, false);
                    UZMANERBAS.Name = "UZMANERBAS";
                    UZMANERBAS.DrawStyle = DrawStyleConstants.vbSolid;
                    UZMANERBAS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANERBAS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANERBAS.TextFont.Size = 9;
                    UZMANERBAS.TextFont.CharSet = 162;
                    UZMANERBAS.Value = @"0";

                    ERERBAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 173, 5, false);
                    ERERBAS.Name = "ERERBAS";
                    ERERBAS.DrawStyle = DrawStyleConstants.vbSolid;
                    ERERBAS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ERERBAS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ERERBAS.TextFont.Size = 9;
                    ERERBAS.TextFont.CharSet = 162;
                    ERERBAS.Value = @"0";

                    OGRENCI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 0, 184, 5, false);
                    OGRENCI.Name = "OGRENCI";
                    OGRENCI.DrawStyle = DrawStyleConstants.vbSolid;
                    OGRENCI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OGRENCI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OGRENCI.TextFont.Size = 9;
                    OGRENCI.TextFont.CharSet = 162;
                    OGRENCI.Value = @"0";

                    EMEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 239, 5, false);
                    EMEKLI.Name = "EMEKLI";
                    EMEKLI.DrawStyle = DrawStyleConstants.vbSolid;
                    EMEKLI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EMEKLI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMEKLI.TextFont.Size = 9;
                    EMEKLI.TextFont.CharSet = 162;
                    EMEKLI.Value = @"0";

                    SIVIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 250, 5, false);
                    SIVIL.Name = "SIVIL";
                    SIVIL.DrawStyle = DrawStyleConstants.vbSolid;
                    SIVIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIVIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIVIL.TextFont.Size = 9;
                    SIVIL.TextFont.CharSet = 162;
                    SIVIL.Value = @"0";

                    HIZMETDISITOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 0, 272, 5, false);
                    HIZMETDISITOTAL.Name = "HIZMETDISITOTAL";
                    HIZMETDISITOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    HIZMETDISITOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HIZMETDISITOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETDISITOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETDISITOTAL.TextFont.Size = 9;
                    HIZMETDISITOTAL.TextFont.Bold = true;
                    HIZMETDISITOTAL.TextFont.CharSet = 162;
                    HIZMETDISITOTAL.Value = @"(Convert.ToInt32({%DIGERHIZMETDISI%})+Convert.ToInt32({%XXXXXXIPERSONELAILE%})+Convert.ToInt32({%XXXXXXIEMEKLIAILE%})+Convert.ToInt32({%EMEKLI%})+Convert.ToInt32({%SIVIL%})).ToString()";

                    UZMANJANDARMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 162, 5, false);
                    UZMANJANDARMA.Name = "UZMANJANDARMA";
                    UZMANJANDARMA.DrawStyle = DrawStyleConstants.vbSolid;
                    UZMANJANDARMA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANJANDARMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANJANDARMA.TextFont.Size = 9;
                    UZMANJANDARMA.TextFont.CharSet = 162;
                    UZMANJANDARMA.Value = @"0";

                    DIGERHIZMETICI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 195, 5, false);
                    DIGERHIZMETICI.Name = "DIGERHIZMETICI";
                    DIGERHIZMETICI.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGERHIZMETICI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGERHIZMETICI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIGERHIZMETICI.TextFont.Size = 9;
                    DIGERHIZMETICI.TextFont.CharSet = 162;
                    DIGERHIZMETICI.Value = @"0";

                    DIGERHIZMETDISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 261, 5, false);
                    DIGERHIZMETDISI.Name = "DIGERHIZMETDISI";
                    DIGERHIZMETDISI.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGERHIZMETDISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGERHIZMETDISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIGERHIZMETDISI.TextFont.Size = 9;
                    DIGERHIZMETDISI.TextFont.CharSet = 162;
                    DIGERHIZMETDISI.Value = @"0";

                    XXXXXXIPERSONELAILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 0, 217, 5, false);
                    XXXXXXIPERSONELAILE.Name = "XXXXXXIPERSONELAILE";
                    XXXXXXIPERSONELAILE.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXIPERSONELAILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIPERSONELAILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIPERSONELAILE.TextFont.Size = 9;
                    XXXXXXIPERSONELAILE.TextFont.CharSet = 162;
                    XXXXXXIPERSONELAILE.Value = @"0";

                    XXXXXXIEMEKLIAILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 228, 5, false);
                    XXXXXXIEMEKLIAILE.Name = "XXXXXXIEMEKLIAILE";
                    XXXXXXIEMEKLIAILE.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXIEMEKLIAILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIEMEKLIAILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIEMEKLIAILE.TextFont.Size = 9;
                    XXXXXXIEMEKLIAILE.TextFont.CharSet = 162;
                    XXXXXXIEMEKLIAILE.Value = @"0";

                    GENELTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 0, 283, 5, false);
                    GENELTOTAL.Name = "GENELTOTAL";
                    GENELTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    GENELTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENELTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENELTOTAL.TextFont.Size = 9;
                    GENELTOTAL.TextFont.Bold = true;
                    GENELTOTAL.TextFont.CharSet = 162;
                    GENELTOTAL.Value = @"(Convert.ToInt32({%GENERALAMIRAL%})+Convert.ToInt32({%SUBAY%})+Convert.ToInt32({%ASTSUBAY%})+Convert.ToInt32({%SIVILMEMUR%})+Convert.ToInt32({%UZMANERBAS%})+Convert.ToInt32({%UZMANJANDARMA%})+Convert.ToInt32({%ERERBAS%})+Convert.ToInt32({%OGRENCI%})+Convert.ToInt32({%DIGERHIZMETICI%})+Convert.ToInt32({%DIGERHIZMETDISI%})+Convert.ToInt32({%XXXXXXIPERSONELAILE%})+Convert.ToInt32({%XXXXXXIEMEKLIAILE%})+Convert.ToInt32({%EMEKLI%})+Convert.ToInt32({%SIVIL%})).ToString()";

                    HIZMETICITOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 206, 5, false);
                    HIZMETICITOTAL.Name = "HIZMETICITOTAL";
                    HIZMETICITOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    HIZMETICITOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HIZMETICITOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETICITOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETICITOTAL.TextFont.Size = 9;
                    HIZMETICITOTAL.TextFont.Bold = true;
                    HIZMETICITOTAL.TextFont.CharSet = 162;
                    HIZMETICITOTAL.Value = @"(Convert.ToInt32({%GENERALAMIRAL%})+Convert.ToInt32({%SUBAY%})+Convert.ToInt32({%ASTSUBAY%})+Convert.ToInt32({%SIVILMEMUR%})+Convert.ToInt32({%UZMANERBAS%})+Convert.ToInt32({%UZMANJANDARMA%})+Convert.ToInt32({%ERERBAS%})+Convert.ToInt32({%OGRENCI%})+Convert.ToInt32({%DIGERHIZMETICI%})).ToString()";

                    GENERALAMIRAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 107, 5, false);
                    GENERALAMIRAL.Name = "GENERALAMIRAL";
                    GENERALAMIRAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENERALAMIRAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENERALAMIRAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENERALAMIRAL.TextFont.Size = 9;
                    GENERALAMIRAL.TextFont.CharSet = 162;
                    GENERALAMIRAL.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpisodeActionsByRequestDate_Class dataset_GetEpisodeActionsByRequestDate = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodeActionsByRequestDate_Class>(0);
                    BIRIM.CalcValue = (dataset_GetEpisodeActionsByRequestDate != null ? Globals.ToStringCore(dataset_GetEpisodeActionsByRequestDate.MasterResource) : "");
                    BIRIM.PostFieldValueCalculation();
                    SUBAY.CalcValue = SUBAY.Value;
                    ASTSUBAY.CalcValue = ASTSUBAY.Value;
                    SIVILMEMUR.CalcValue = SIVILMEMUR.Value;
                    UZMANERBAS.CalcValue = UZMANERBAS.Value;
                    ERERBAS.CalcValue = ERERBAS.Value;
                    OGRENCI.CalcValue = OGRENCI.Value;
                    EMEKLI.CalcValue = EMEKLI.Value;
                    SIVIL.CalcValue = SIVIL.Value;
                    UZMANJANDARMA.CalcValue = UZMANJANDARMA.Value;
                    DIGERHIZMETICI.CalcValue = DIGERHIZMETICI.Value;
                    DIGERHIZMETDISI.CalcValue = DIGERHIZMETDISI.Value;
                    XXXXXXIPERSONELAILE.CalcValue = XXXXXXIPERSONELAILE.Value;
                    XXXXXXIEMEKLIAILE.CalcValue = XXXXXXIEMEKLIAILE.Value;
                    GENERALAMIRAL.CalcValue = GENERALAMIRAL.Value;
                    HIZMETDISITOTAL.CalcValue = (Convert.ToInt32(MyParentReport.SUBAY.DIGERHIZMETDISI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.XXXXXXIPERSONELAILE.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.XXXXXXIEMEKLIAILE.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.EMEKLI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.SIVIL.CalcValue)).ToString();
                    GENELTOTAL.CalcValue = (Convert.ToInt32(MyParentReport.SUBAY.GENERALAMIRAL.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.SUBAY.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.ASTSUBAY.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.SIVILMEMUR.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.UZMANERBAS.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.UZMANJANDARMA.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.ERERBAS.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.OGRENCI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.DIGERHIZMETICI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.DIGERHIZMETDISI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.XXXXXXIPERSONELAILE.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.XXXXXXIEMEKLIAILE.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.EMEKLI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.SIVIL.CalcValue)).ToString();
                    HIZMETICITOTAL.CalcValue = (Convert.ToInt32(MyParentReport.SUBAY.GENERALAMIRAL.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.SUBAY.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.ASTSUBAY.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.SIVILMEMUR.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.UZMANERBAS.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.UZMANJANDARMA.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.ERERBAS.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.OGRENCI.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.DIGERHIZMETICI.CalcValue)).ToString();
                    return new TTReportObject[] { BIRIM,SUBAY,ASTSUBAY,SIVILMEMUR,UZMANERBAS,ERERBAS,OGRENCI,EMEKLI,SIVIL,UZMANJANDARMA,DIGERHIZMETICI,DIGERHIZMETDISI,XXXXXXIPERSONELAILE,XXXXXXIEMEKLIAILE,GENERALAMIRAL,HIZMETDISITOTAL,GENELTOTAL,HIZMETICITOTAL};
                }
            }

        }

        public SUBAYGroup SUBAY;

        public partial class MAINGroup : TTReportGroup
        {
            public EmergencyStatisticsReport MyParentReport
            {
                get { return (EmergencyStatisticsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField GRP { get {return Body().GRP;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                EpisodeAction.GetEpisodeActionsByRequestDate_Class dataSet_GetEpisodeActionsByRequestDate = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodeActionsByRequestDate_Class>(0);    
                return new object[] {(dataSet_GetEpisodeActionsByRequestDate==null ? null : dataSet_GetEpisodeActionsByRequestDate.MasterResource)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public EmergencyStatisticsReport MyParentReport
                {
                    get { return (EmergencyStatisticsReport)ParentReport; }
                }
                
                public TTReportField GRP;
                public TTReportField COUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    GRP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 57, 6, false);
                    GRP.Name = "GRP";
                    GRP.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRP.TextFont.Name = "Courier New";
                    GRP.TextFont.CharSet = 162;
                    GRP.Value = @"{#SUBAY.PATIENTGROUP#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 1, 92, 6, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.TextFont.Name = "Courier New";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{#SUBAY.SAYI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpisodeActionsByRequestDate_Class dataset_GetEpisodeActionsByRequestDate = MyParentReport.SUBAY.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodeActionsByRequestDate_Class>(0);
                    GRP.CalcValue = (dataset_GetEpisodeActionsByRequestDate != null ? Globals.ToStringCore(dataset_GetEpisodeActionsByRequestDate.Patientgroup) : "");
                    COUNT.CalcValue = (dataset_GetEpisodeActionsByRequestDate != null ? Globals.ToStringCore(dataset_GetEpisodeActionsByRequestDate.Sayi) : "");
                    return new TTReportObject[] { GRP,COUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            TTReportTool.TTReportGroup g = ((EmergencyStatisticsReport)ParentReport).Groups("HEADER");
            TTReportTool.TTReportGroup pg = ((EmergencyStatisticsReport)ParentReport).Groups("SUBAY");
            string patientGroup = TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[this.GRP.CalcValue].Name;
            TTDataDictionary.EnumValueDef pge = TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[this.GRP.CalcValue];
            TTObjectClasses.PatientGroupEnum patientGroupEnumValue = (TTObjectClasses.PatientGroupEnum) Convert.ToInt32(pge.Value);
            TTObjectClasses.PatientGroupDefinition patientGroupDef = TTObjectClasses.Common.PatientGroupDefinitionByEnum(objectContext,patientGroupEnumValue);
            string mainPatientGroup = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(patientGroupDef.MainPatientGroup.MainPatientGroupEnum).Name;

            
            switch(mainPatientGroup)
            {
                case "Cadet": //XXXXXX Ögrenci
                    {
                        pg.Fields("OGRENCI").Value = (Convert.ToInt32(pg.Fields("OGRENCI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("OGRENCI").Value = (Convert.ToInt32(g.Fields("OGRENCI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "MilitaryWorker"://XXXXXX işçi
                case "Candidate"://Aday
                    {
                        pg.Fields("DIGERHIZMETICI").Value = (Convert.ToInt32(pg.Fields("DIGERHIZMETICI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("DIGERHIZMETICI").Value = (Convert.ToInt32(g.Fields("DIGERHIZMETICI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "Civilian"://Sivil
                    {
                        pg.Fields("SIVIL").Value = (Convert.ToInt32(pg.Fields("SIVIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("SIVIL").Value = (Convert.ToInt32(g.Fields("SIVIL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "ExpertGendarme"://Uzman Jandarma
                    {
                        pg.Fields("UZMANJANDARMA").Value = (Convert.ToInt32(pg.Fields("UZMANJANDARMA").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("UZMANJANDARMA").Value = (Convert.ToInt32(g.Fields("UZMANJANDARMA").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "ExpertNonCom"://Uzman Erbaş
                    {
                        pg.Fields("UZMANERBAS").Value = (Convert.ToInt32(pg.Fields("UZMANERBAS").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("UZMANERBAS").Value = (Convert.ToInt32(g.Fields("UZMANERBAS").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "MilitaryCivilOfficial"://Sivil Memur
                    {
                        pg.Fields("SIVILMEMUR").Value = (Convert.ToInt32(pg.Fields("SIVILMEMUR").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("SIVILMEMUR").Value = (Convert.ToInt32(g.Fields("SIVILMEMUR").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "MilitaryPersonelFamily"://XXXXXX Personel Ailesi
                    {
                        pg.Fields("XXXXXXIPERSONELAILE").Value = (Convert.ToInt32(pg.Fields("XXXXXXIPERSONELAILE").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("XXXXXXIPERSONELAILE").Value = (Convert.ToInt32(g.Fields("XXXXXXIPERSONELAILE").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "NoncommissionedOfficer"://Astsubay
                    {
                        pg.Fields("ASTSUBAY").Value = (Convert.ToInt32(pg.Fields("ASTSUBAY").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("ASTSUBAY").Value = (Convert.ToInt32(g.Fields("ASTSUBAY").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "Officer"://Subay
                    {
                        if(patientGroupEnumValue == TTObjectClasses.PatientGroupEnum.GeneralAdmiral)
                        {
                            pg.Fields("GENERALAMIRAL").Value = (Convert.ToInt32(pg.Fields("GENERALAMIRAL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("GENERALAMIRAL").Value = (Convert.ToInt32(g.Fields("GENERALAMIRAL").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        }
                        else
                        {
                            pg.Fields("SUBAY").Value = (Convert.ToInt32(pg.Fields("SUBAY").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("SUBAY").Value = (Convert.ToInt32(g.Fields("SUBAY").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        }
                    }
                    break;
                case "PrivateNonCom"://Er/Erbaş
                    {
                        pg.Fields("ERERBAS").Value = (Convert.ToInt32(pg.Fields("ERERBAS").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("ERERBAS").Value = (Convert.ToInt32(g.Fields("ERERBAS").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "Retired"://Emekli
                    {
                        pg.Fields("EMEKLI").Value = (Convert.ToInt32(pg.Fields("EMEKLI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("EMEKLI").Value = (Convert.ToInt32(g.Fields("EMEKLI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "RetiredFamily"://XXXXXX Emekli Ailesi
                    {
                        pg.Fields("XXXXXXIEMEKLIAILE").Value = (Convert.ToInt32(pg.Fields("XXXXXXIEMEKLIAILE").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("XXXXXXIEMEKLIAILE").Value = (Convert.ToInt32(g.Fields("XXXXXXIEMEKLIAILE").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "Visitor"://Misafir XXXXXX Personel
                case "SpecialStatusBeneficiary"://Terhisli/Ayrılmış Hak Sahibi
                    {
                        pg.Fields("DIGERHIZMETDISI").Value = (Convert.ToInt32(pg.Fields("DIGERHIZMETDISI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("DIGERHIZMETDISI").Value = (Convert.ToInt32(g.Fields("DIGERHIZMETDISI").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                default:
                    break;
            }
            
            //g.Fields("GENELTOPLAM").Value = (Convert.ToInt32(g.Fields("GENELTOPLAM").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
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

        public EmergencyStatisticsReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            SUBAY = new SUBAYGroup(PARTA,"SUBAY");
            MAIN = new MAINGroup(SUBAY,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "EMERGENCYSTATISTICSREPORT";
            Caption = "Acil Servis Sağlık İstatistikleri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginTop = 10;
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