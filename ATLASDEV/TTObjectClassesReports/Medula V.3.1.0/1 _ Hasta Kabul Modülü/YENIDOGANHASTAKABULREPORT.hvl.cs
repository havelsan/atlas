
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
    public partial class YENIDOGANHASTAKABULREPORT : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public YENIDOGANHASTAKABULREPORT MyParentReport
            {
                get { return (YENIDOGANHASTAKABULREPORT)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField MEDULAACTIONID { get {return Header().MEDULAACTIONID;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField HEALTHFACILITYID { get {return Header().HEALTHFACILITYID;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField1132 { get {return Header().NewField1132;} }
            public TTReportField NewField12311 { get {return Header().NewField12311;} }
            public TTReportField NewField111321 { get {return Header().NewField111321;} }
            public TTReportField NewField1123111 { get {return Header().NewField1123111;} }
            public TTReportField NewField11113211 { get {return Header().NewField11113211;} }
            public TTReportField NewField111231111 { get {return Header().NewField111231111;} }
            public TTReportField NewField1111132111 { get {return Header().NewField1111132111;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField111412 { get {return Header().NewField111412;} }
            public TTReportField NewField111413 { get {return Header().NewField111413;} }
            public TTReportField NewField111414 { get {return Header().NewField111414;} }
            public TTReportField NewField111415 { get {return Header().NewField111415;} }
            public TTReportField NewField111416 { get {return Header().NewField111416;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField154 { get {return Header().NewField154;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1451 { get {return Header().NewField1451;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField1452 { get {return Header().NewField1452;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField1453 { get {return Header().NewField1453;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportField NewField1454 { get {return Header().NewField1454;} }
            public TTReportField NewField1441 { get {return Header().NewField1441;} }
            public TTReportField NewField14541 { get {return Header().NewField14541;} }
            public TTReportField PROVIZYONTARIHI { get {return Header().PROVIZYONTARIHI;} }
            public TTReportField HASTABASVURUNO { get {return Header().HASTABASVURUNO;} }
            public TTReportField TAKIPNO { get {return Header().TAKIPNO;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField DOGUMTARIHI { get {return Header().DOGUMTARIHI;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField155 { get {return Header().NewField155;} }
            public TTReportField SONUCKODU { get {return Header().SONUCKODU;} }
            public TTReportField SONUCMESAJI { get {return Header().SONUCMESAJI;} }
            public TTReportField PROVIZYONTIPIDESC { get {return Header().PROVIZYONTIPIDESC;} }
            public TTReportField TEDAVITURUDESC { get {return Header().TEDAVITURUDESC;} }
            public TTReportField BRANSKODUDESC { get {return Header().BRANSKODUDESC;} }
            public TTReportField TEDAVITIPIDESC { get {return Header().TEDAVITIPIDESC;} }
            public TTReportField TAKIPTIPIDESC { get {return Header().TAKIPTIPIDESC;} }
            public TTReportField SIGORTALITURUDESC { get {return Header().SIGORTALITURUDESC;} }
            public TTReportField DEVREDILENKURUMDESC { get {return Header().DEVREDILENKURUMDESC;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField CINSIYETDESC { get {return Header().CINSIYETDESC;} }
            public TTReportField CEVAPSIGORTALITURUDESC { get {return Header().CEVAPSIGORTALITURUDESC;} }
            public TTReportField NewField145 { get {return Header().NewField145;} }
            public TTReportField NewField1455 { get {return Header().NewField1455;} }
            public TTReportField COCUKSIRANO { get {return Header().COCUKSIRANO;} }
            public TTReportField NewField1541 { get {return Header().NewField1541;} }
            public TTReportField NewField15541 { get {return Header().NewField15541;} }
            public TTReportField COCUKDOGUMTARIHI { get {return Header().COCUKDOGUMTARIHI;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<BaseHastaKabul.HASTAKABULReportQuery_Class>("HASTAKABULReportQuery", BaseHastaKabul.HASTAKABULReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public YENIDOGANHASTAKABULREPORT MyParentReport
                {
                    get { return (YENIDOGANHASTAKABULREPORT)ParentReport; }
                }
                
                public TTReportField MEDULAACTIONID;
                public TTReportField NewField1131;
                public TTReportField NewField111;
                public TTReportField REPORTNAME;
                public TTReportField NewField131;
                public TTReportField NewField1311;
                public TTReportField NewField1141;
                public TTReportField HEALTHFACILITYID;
                public TTReportShape NewLine1;
                public TTReportField NewField1132;
                public TTReportField NewField12311;
                public TTReportField NewField111321;
                public TTReportField NewField1123111;
                public TTReportField NewField11113211;
                public TTReportField NewField111231111;
                public TTReportField NewField1111132111;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField111412;
                public TTReportField NewField111413;
                public TTReportField NewField111414;
                public TTReportField NewField111415;
                public TTReportField NewField111416;
                public TTReportShape NewLine11;
                public TTReportField NewField11311;
                public TTReportField NewField4;
                public TTReportField NewField45;
                public TTReportField NewField14;
                public TTReportField NewField154;
                public TTReportField NewField141;
                public TTReportField NewField1451;
                public TTReportField NewField142;
                public TTReportField NewField1452;
                public TTReportField NewField143;
                public TTReportField NewField1453;
                public TTReportField NewField144;
                public TTReportField NewField1454;
                public TTReportField NewField1441;
                public TTReportField NewField14541;
                public TTReportField PROVIZYONTARIHI;
                public TTReportField HASTABASVURUNO;
                public TTReportField TAKIPNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField DOGUMTARIHI;
                public TTReportField NewField15;
                public TTReportField NewField155;
                public TTReportField SONUCKODU;
                public TTReportField SONUCMESAJI;
                public TTReportField PROVIZYONTIPIDESC;
                public TTReportField TEDAVITURUDESC;
                public TTReportField BRANSKODUDESC;
                public TTReportField TEDAVITIPIDESC;
                public TTReportField TAKIPTIPIDESC;
                public TTReportField SIGORTALITURUDESC;
                public TTReportField DEVREDILENKURUMDESC;
                public TTReportField ADSOYAD;
                public TTReportField CINSIYETDESC;
                public TTReportField CEVAPSIGORTALITURUDESC;
                public TTReportField NewField145;
                public TTReportField NewField1455;
                public TTReportField COCUKSIRANO;
                public TTReportField NewField1541;
                public TTReportField NewField15541;
                public TTReportField COCUKDOGUMTARIHI; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 153;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MEDULAACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 32, 170, 37, false);
                    MEDULAACTIONID.Name = "MEDULAACTIONID";
                    MEDULAACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDULAACTIONID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEDULAACTIONID.Value = @"{#MEDULAACTIONID#}";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 32, 119, 37, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Provizyon Bilgileri";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 32, 145, 37, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İşlem Nu.";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 25, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 38, 50, 43, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Provizyon Tarihi";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 32, 146, 37, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 38, 52, 43, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    HEALTHFACILITYID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 38, 233, 43, false);
                    HEALTHFACILITYID.Name = "HEALTHFACILITYID";
                    HEALTHFACILITYID.Visible = EvetHayirEnum.ehHayir;
                    HEALTHFACILITYID.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYID.Value = @"{#HEALTHFACILITYID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 37, 170, 37, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 44, 50, 49, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132.TextFont.Bold = true;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @"Provizyonun Tipi";

                    NewField12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 50, 50, 55, false);
                    NewField12311.Name = "NewField12311";
                    NewField12311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12311.TextFont.Bold = true;
                    NewField12311.TextFont.CharSet = 162;
                    NewField12311.Value = @"Tedavi Türü";

                    NewField111321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 56, 50, 61, false);
                    NewField111321.Name = "NewField111321";
                    NewField111321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111321.TextFont.Bold = true;
                    NewField111321.TextFont.CharSet = 162;
                    NewField111321.Value = @"Branş";

                    NewField1123111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 62, 50, 67, false);
                    NewField1123111.Name = "NewField1123111";
                    NewField1123111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123111.TextFont.Bold = true;
                    NewField1123111.TextFont.CharSet = 162;
                    NewField1123111.Value = @"Tedavi Tipi";

                    NewField11113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 68, 50, 73, false);
                    NewField11113211.Name = "NewField11113211";
                    NewField11113211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11113211.TextFont.Bold = true;
                    NewField11113211.TextFont.CharSet = 162;
                    NewField11113211.Value = @"Takibin Tipi";

                    NewField111231111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 74, 50, 79, false);
                    NewField111231111.Name = "NewField111231111";
                    NewField111231111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111231111.TextFont.Bold = true;
                    NewField111231111.TextFont.CharSet = 162;
                    NewField111231111.Value = @"Sigortalı Türü";

                    NewField1111132111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 80, 50, 85, false);
                    NewField1111132111.Name = "NewField1111132111";
                    NewField1111132111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111132111.TextFont.Bold = true;
                    NewField1111132111.TextFont.CharSet = 162;
                    NewField1111132111.Value = @"Devredilen Kurum";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 44, 52, 49, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 50, 52, 55, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @":";

                    NewField111412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 62, 52, 67, false);
                    NewField111412.Name = "NewField111412";
                    NewField111412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111412.TextFont.Bold = true;
                    NewField111412.TextFont.CharSet = 162;
                    NewField111412.Value = @":";

                    NewField111413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 68, 52, 73, false);
                    NewField111413.Name = "NewField111413";
                    NewField111413.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111413.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111413.TextFont.Bold = true;
                    NewField111413.TextFont.CharSet = 162;
                    NewField111413.Value = @":";

                    NewField111414 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 74, 52, 79, false);
                    NewField111414.Name = "NewField111414";
                    NewField111414.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111414.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111414.TextFont.Bold = true;
                    NewField111414.TextFont.CharSet = 162;
                    NewField111414.Value = @":";

                    NewField111415 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 56, 52, 61, false);
                    NewField111415.Name = "NewField111415";
                    NewField111415.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111415.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111415.TextFont.Bold = true;
                    NewField111415.TextFont.CharSet = 162;
                    NewField111415.Value = @":";

                    NewField111416 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 80, 52, 85, false);
                    NewField111416.Name = "NewField111416";
                    NewField111416.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111416.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111416.TextFont.Bold = true;
                    NewField111416.TextFont.CharSet = 162;
                    NewField111416.Value = @":";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 105, 170, 105, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 100, 119, 105, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Cevap Bilgileri";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 112, 50, 117, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Başvuru Numarası";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 112, 52, 117, false);
                    NewField45.Name = "NewField45";
                    NewField45.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField45.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField45.TextFont.Bold = true;
                    NewField45.TextFont.CharSet = 162;
                    NewField45.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 118, 50, 123, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Takip Numarası";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 118, 52, 123, false);
                    NewField154.Name = "NewField154";
                    NewField154.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField154.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField154.TextFont.Bold = true;
                    NewField154.TextFont.CharSet = 162;
                    NewField154.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 124, 50, 129, false);
                    NewField141.Name = "NewField141";
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"TC Kimlik Numarası";

                    NewField1451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 124, 52, 129, false);
                    NewField1451.Name = "NewField1451";
                    NewField1451.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1451.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1451.TextFont.Bold = true;
                    NewField1451.TextFont.CharSet = 162;
                    NewField1451.Value = @":";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 130, 50, 135, false);
                    NewField142.Name = "NewField142";
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Adı ve Soyadı";

                    NewField1452 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 130, 52, 135, false);
                    NewField1452.Name = "NewField1452";
                    NewField1452.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1452.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1452.TextFont.Bold = true;
                    NewField1452.TextFont.CharSet = 162;
                    NewField1452.Value = @":";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 136, 50, 141, false);
                    NewField143.Name = "NewField143";
                    NewField143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Doğum Tarihi";

                    NewField1453 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 136, 52, 141, false);
                    NewField1453.Name = "NewField1453";
                    NewField1453.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1453.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1453.TextFont.Bold = true;
                    NewField1453.TextFont.CharSet = 162;
                    NewField1453.Value = @":";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 142, 50, 147, false);
                    NewField144.Name = "NewField144";
                    NewField144.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField144.TextFont.Bold = true;
                    NewField144.TextFont.CharSet = 162;
                    NewField144.Value = @"Cinsiyeti";

                    NewField1454 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 142, 52, 147, false);
                    NewField1454.Name = "NewField1454";
                    NewField1454.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1454.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1454.TextFont.Bold = true;
                    NewField1454.TextFont.CharSet = 162;
                    NewField1454.Value = @":";

                    NewField1441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 148, 50, 153, false);
                    NewField1441.Name = "NewField1441";
                    NewField1441.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1441.TextFont.Bold = true;
                    NewField1441.TextFont.CharSet = 162;
                    NewField1441.Value = @"Sigortalı Türü";

                    NewField14541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 148, 52, 153, false);
                    NewField14541.Name = "NewField14541";
                    NewField14541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14541.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14541.TextFont.Bold = true;
                    NewField14541.TextFont.CharSet = 162;
                    NewField14541.Value = @":";

                    PROVIZYONTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 38, 102, 43, false);
                    PROVIZYONTARIHI.Name = "PROVIZYONTARIHI";
                    PROVIZYONTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROVIZYONTARIHI.ObjectDefName = "BaseHastaKabul";
                    PROVIZYONTARIHI.DataMember = "PROVIZYONGIRISDVO.PROVIZYONTARIHI";
                    PROVIZYONTARIHI.Value = @"{@TTOBJECTID@}";

                    HASTABASVURUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 112, 102, 117, false);
                    HASTABASVURUNO.Name = "HASTABASVURUNO";
                    HASTABASVURUNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTABASVURUNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTABASVURUNO.ObjectDefName = "BaseHastaKabul";
                    HASTABASVURUNO.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.HASTABASVURUNO";
                    HASTABASVURUNO.Value = @"{@TTOBJECTID@}";

                    TAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 118, 102, 123, false);
                    TAKIPNO.Name = "TAKIPNO";
                    TAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAKIPNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TAKIPNO.ObjectDefName = "BaseHastaKabul";
                    TAKIPNO.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.TAKIPNO";
                    TAKIPNO.Value = @"{@TTOBJECTID@}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 124, 102, 129, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.ObjectDefName = "BaseHastaKabul";
                    TCKIMLIKNO.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.HASTABILGILERI.TCKIMLIKNO";
                    TCKIMLIKNO.Value = @"{@TTOBJECTID@}";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 136, 102, 141, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOGUMTARIHI.ObjectDefName = "BaseHastaKabul";
                    DOGUMTARIHI.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.HASTABILGILERI.DOGUMTARIHI";
                    DOGUMTARIHI.Value = @"{@TTOBJECTID@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 106, 50, 111, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Cevap Açıklaması";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 106, 52, 111, false);
                    NewField155.Name = "NewField155";
                    NewField155.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField155.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField155.TextFont.Bold = true;
                    NewField155.TextFont.CharSet = 162;
                    NewField155.Value = @":";

                    SONUCKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 106, 64, 111, false);
                    SONUCKODU.Name = "SONUCKODU";
                    SONUCKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONUCKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SONUCKODU.ObjectDefName = "BaseHastaKabul";
                    SONUCKODU.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.SONUCKODU";
                    SONUCKODU.Value = @"{@TTOBJECTID@}";

                    SONUCMESAJI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 106, 170, 111, false);
                    SONUCMESAJI.Name = "SONUCMESAJI";
                    SONUCMESAJI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONUCMESAJI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SONUCMESAJI.ObjectDefName = "BaseHastaKabul";
                    SONUCMESAJI.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.SONUCMESAJI";
                    SONUCMESAJI.Value = @"{@TTOBJECTID@}";

                    PROVIZYONTIPIDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 44, 102, 49, false);
                    PROVIZYONTIPIDESC.Name = "PROVIZYONTIPIDESC";
                    PROVIZYONTIPIDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONTIPIDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROVIZYONTIPIDESC.ObjectDefName = "BaseHastaKabul";
                    PROVIZYONTIPIDESC.DataMember = "PROVIZYONGIRISDVO.ProvizyonTipiDesc";
                    PROVIZYONTIPIDESC.Value = @"{@TTOBJECTID@}";

                    TEDAVITURUDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 50, 102, 55, false);
                    TEDAVITURUDESC.Name = "TEDAVITURUDESC";
                    TEDAVITURUDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVITURUDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEDAVITURUDESC.ObjectDefName = "BaseHastaKabul";
                    TEDAVITURUDESC.DataMember = "PROVIZYONGIRISDVO.TedaviTuruDesc";
                    TEDAVITURUDESC.Value = @"{@TTOBJECTID@}";

                    BRANSKODUDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 56, 102, 61, false);
                    BRANSKODUDESC.Name = "BRANSKODUDESC";
                    BRANSKODUDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANSKODUDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BRANSKODUDESC.ObjectDefName = "BaseHastaKabul";
                    BRANSKODUDESC.DataMember = "PROVIZYONGIRISDVO.BransDesc";
                    BRANSKODUDESC.Value = @"{@TTOBJECTID@}";

                    TEDAVITIPIDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 62, 102, 67, false);
                    TEDAVITIPIDESC.Name = "TEDAVITIPIDESC";
                    TEDAVITIPIDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVITIPIDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEDAVITIPIDESC.ObjectDefName = "BaseHastaKabul";
                    TEDAVITIPIDESC.DataMember = "PROVIZYONGIRISDVO.TedaviTipiDesc";
                    TEDAVITIPIDESC.Value = @"{@TTOBJECTID@}";

                    TAKIPTIPIDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 68, 102, 73, false);
                    TAKIPTIPIDESC.Name = "TAKIPTIPIDESC";
                    TAKIPTIPIDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAKIPTIPIDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TAKIPTIPIDESC.ObjectDefName = "BaseHastaKabul";
                    TAKIPTIPIDESC.DataMember = "PROVIZYONGIRISDVO.TakipTipiDesc";
                    TAKIPTIPIDESC.Value = @"{@TTOBJECTID@}";

                    SIGORTALITURUDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 74, 102, 79, false);
                    SIGORTALITURUDESC.Name = "SIGORTALITURUDESC";
                    SIGORTALITURUDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGORTALITURUDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIGORTALITURUDESC.ObjectDefName = "BaseHastaKabul";
                    SIGORTALITURUDESC.DataMember = "PROVIZYONGIRISDVO.SigortaliTuruDesc";
                    SIGORTALITURUDESC.Value = @"{@TTOBJECTID@}";

                    DEVREDILENKURUMDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 80, 170, 85, false);
                    DEVREDILENKURUMDESC.Name = "DEVREDILENKURUMDESC";
                    DEVREDILENKURUMDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEVREDILENKURUMDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEVREDILENKURUMDESC.ObjectDefName = "BaseHastaKabul";
                    DEVREDILENKURUMDESC.DataMember = "PROVIZYONGIRISDVO.DevredilenKurumDesc";
                    DEVREDILENKURUMDESC.Value = @"{@TTOBJECTID@}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 130, 170, 135, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADSOYAD.ObjectDefName = "BaseHastaKabul";
                    ADSOYAD.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.HASTABILGILERI.AdiVeSoyadiDesc";
                    ADSOYAD.Value = @"{@TTOBJECTID@}";

                    CINSIYETDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 142, 102, 147, false);
                    CINSIYETDESC.Name = "CINSIYETDESC";
                    CINSIYETDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYETDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CINSIYETDESC.ObjectDefName = "BaseHastaKabul";
                    CINSIYETDESC.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.HASTABILGILERI.CinsiyetDesc";
                    CINSIYETDESC.Value = @"{@TTOBJECTID@}";

                    CEVAPSIGORTALITURUDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 148, 102, 153, false);
                    CEVAPSIGORTALITURUDESC.Name = "CEVAPSIGORTALITURUDESC";
                    CEVAPSIGORTALITURUDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CEVAPSIGORTALITURUDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CEVAPSIGORTALITURUDESC.ObjectDefName = "BaseHastaKabul";
                    CEVAPSIGORTALITURUDESC.DataMember = "PROVIZYONGIRISDVO.PROVIZYONCEVAPDVO.HASTABILGILERI.SigortaliTuruDesc";
                    CEVAPSIGORTALITURUDESC.Value = @"{@TTOBJECTID@}";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 86, 50, 91, false);
                    NewField145.Name = "NewField145";
                    NewField145.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField145.TextFont.Bold = true;
                    NewField145.TextFont.CharSet = 162;
                    NewField145.Value = @"Çocuk Sıra Nu.";

                    NewField1455 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 86, 52, 91, false);
                    NewField1455.Name = "NewField1455";
                    NewField1455.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1455.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1455.TextFont.Bold = true;
                    NewField1455.TextFont.CharSet = 162;
                    NewField1455.Value = @":";

                    COCUKSIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 86, 102, 91, false);
                    COCUKSIRANO.Name = "COCUKSIRANO";
                    COCUKSIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    COCUKSIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COCUKSIRANO.ObjectDefName = "BaseHastaKabul";
                    COCUKSIRANO.DataMember = "PROVIZYONGIRISDVO.YENIDOGANBILGISI.COCUKSIRA";
                    COCUKSIRANO.Value = @"{@TTOBJECTID@}";

                    NewField1541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 92, 50, 97, false);
                    NewField1541.Name = "NewField1541";
                    NewField1541.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1541.TextFont.Bold = true;
                    NewField1541.TextFont.CharSet = 162;
                    NewField1541.Value = @"Çocuk Doğum Tarihi";

                    NewField15541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 92, 52, 97, false);
                    NewField15541.Name = "NewField15541";
                    NewField15541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15541.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15541.TextFont.Bold = true;
                    NewField15541.TextFont.CharSet = 162;
                    NewField15541.Value = @":";

                    COCUKDOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 92, 102, 97, false);
                    COCUKDOGUMTARIHI.Name = "COCUKDOGUMTARIHI";
                    COCUKDOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    COCUKDOGUMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COCUKDOGUMTARIHI.ObjectDefName = "BaseHastaKabul";
                    COCUKDOGUMTARIHI.DataMember = "PROVIZYONGIRISDVO.YENIDOGANBILGISI.DOGUMTARIHI";
                    COCUKDOGUMTARIHI.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseHastaKabul.HASTAKABULReportQuery_Class dataset_HASTAKABULReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseHastaKabul.HASTAKABULReportQuery_Class>(0);
                    MEDULAACTIONID.CalcValue = (dataset_HASTAKABULReportQuery != null ? Globals.ToStringCore(dataset_HASTAKABULReportQuery.MedulaActionID) : "");
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField111.CalcValue = NewField111.Value;
                    REPORTNAME.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    HEALTHFACILITYID.CalcValue = (dataset_HASTAKABULReportQuery != null ? Globals.ToStringCore(dataset_HASTAKABULReportQuery.HealthFacilityID) : "");
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField12311.CalcValue = NewField12311.Value;
                    NewField111321.CalcValue = NewField111321.Value;
                    NewField1123111.CalcValue = NewField1123111.Value;
                    NewField11113211.CalcValue = NewField11113211.Value;
                    NewField111231111.CalcValue = NewField111231111.Value;
                    NewField1111132111.CalcValue = NewField1111132111.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111412.CalcValue = NewField111412.Value;
                    NewField111413.CalcValue = NewField111413.Value;
                    NewField111414.CalcValue = NewField111414.Value;
                    NewField111415.CalcValue = NewField111415.Value;
                    NewField111416.CalcValue = NewField111416.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField45.CalcValue = NewField45.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField154.CalcValue = NewField154.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1451.CalcValue = NewField1451.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1452.CalcValue = NewField1452.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField1453.CalcValue = NewField1453.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField1454.CalcValue = NewField1454.Value;
                    NewField1441.CalcValue = NewField1441.Value;
                    NewField14541.CalcValue = NewField14541.Value;
                    PROVIZYONTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROVIZYONTARIHI.PostFieldValueCalculation();
                    HASTABASVURUNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTABASVURUNO.PostFieldValueCalculation();
                    TAKIPNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TAKIPNO.PostFieldValueCalculation();
                    TCKIMLIKNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TCKIMLIKNO.PostFieldValueCalculation();
                    DOGUMTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DOGUMTARIHI.PostFieldValueCalculation();
                    NewField15.CalcValue = NewField15.Value;
                    NewField155.CalcValue = NewField155.Value;
                    SONUCKODU.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SONUCKODU.PostFieldValueCalculation();
                    SONUCMESAJI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SONUCMESAJI.PostFieldValueCalculation();
                    PROVIZYONTIPIDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROVIZYONTIPIDESC.PostFieldValueCalculation();
                    TEDAVITURUDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TEDAVITURUDESC.PostFieldValueCalculation();
                    BRANSKODUDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BRANSKODUDESC.PostFieldValueCalculation();
                    TEDAVITIPIDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TEDAVITIPIDESC.PostFieldValueCalculation();
                    TAKIPTIPIDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TAKIPTIPIDESC.PostFieldValueCalculation();
                    SIGORTALITURUDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SIGORTALITURUDESC.PostFieldValueCalculation();
                    DEVREDILENKURUMDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DEVREDILENKURUMDESC.PostFieldValueCalculation();
                    ADSOYAD.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ADSOYAD.PostFieldValueCalculation();
                    CINSIYETDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    CINSIYETDESC.PostFieldValueCalculation();
                    CEVAPSIGORTALITURUDESC.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    CEVAPSIGORTALITURUDESC.PostFieldValueCalculation();
                    NewField145.CalcValue = NewField145.Value;
                    NewField1455.CalcValue = NewField1455.Value;
                    COCUKSIRANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    COCUKSIRANO.PostFieldValueCalculation();
                    NewField1541.CalcValue = NewField1541.Value;
                    NewField15541.CalcValue = NewField15541.Value;
                    COCUKDOGUMTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    COCUKDOGUMTARIHI.PostFieldValueCalculation();
                    return new TTReportObject[] { MEDULAACTIONID,NewField1131,NewField111,REPORTNAME,NewField131,NewField1311,NewField1141,HEALTHFACILITYID,NewField1132,NewField12311,NewField111321,NewField1123111,NewField11113211,NewField111231111,NewField1111132111,NewField11411,NewField111411,NewField111412,NewField111413,NewField111414,NewField111415,NewField111416,NewField11311,NewField4,NewField45,NewField14,NewField154,NewField141,NewField1451,NewField142,NewField1452,NewField143,NewField1453,NewField144,NewField1454,NewField1441,NewField14541,PROVIZYONTARIHI,HASTABASVURUNO,TAKIPNO,TCKIMLIKNO,DOGUMTARIHI,NewField15,NewField155,SONUCKODU,SONUCMESAJI,PROVIZYONTIPIDESC,TEDAVITURUDESC,BRANSKODUDESC,TEDAVITIPIDESC,TAKIPTIPIDESC,SIGORTALITURUDESC,DEVREDILENKURUMDESC,ADSOYAD,CINSIYETDESC,CEVAPSIGORTALITURUDESC,NewField145,NewField1455,COCUKSIRANO,NewField1541,NewField15541,COCUKDOGUMTARIHI};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (string.IsNullOrEmpty(HEALTHFACILITYID.CalcValue) == false && Globals.IsNumeric(HEALTHFACILITYID.CalcValue))
                    {
                        SaglikTesisi saglikTesisi = SaglikTesisi.GetSaglikTesisi(Convert.ToInt32(HEALTHFACILITYID.CalcValue));
                        if (saglikTesisi != null)
                            REPORTNAME.CalcValue = saglikTesisi.ToString();
                        else
                            REPORTNAME.CalcValue = HEALTHFACILITYID.CalcValue;
                    }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public YENIDOGANHASTAKABULREPORT MyParentReport
                {
                    get { return (YENIDOGANHASTAKABULREPORT)ParentReport; }
                }
                
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1;
                public TTReportField PrintDate1;
                public TTReportShape NewLine111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 102, 5, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 30, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 170, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseHastaKabul.HASTAKABULReportQuery_Class dataset_HASTAKABULReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseHastaKabul.HASTAKABULReportQuery_Class>(0);
                    PageNumber1.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : "";
                    return new TTReportObject[] { PageNumber1,PrintDate1,CurrentUser1};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public YENIDOGANHASTAKABULREPORT MyParentReport
            {
                get { return (YENIDOGANHASTAKABULREPORT)ParentReport; }
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
                public YENIDOGANHASTAKABULREPORT MyParentReport
                {
                    get { return (YENIDOGANHASTAKABULREPORT)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
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

        public YENIDOGANHASTAKABULREPORT()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Nesne Tekil Numarasını Giriniz", @"", true, true, false, new Guid("c0ae1e86-7d0f-412f-9366-d0199baae614"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid_"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "YENIDOGANHASTAKABULREPORT";
            Caption = "Yeni Doğan Hasta Kabul Dökümü";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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