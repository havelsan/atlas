
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
    /// Tahliye ve HEK Grafiği
    /// </summary>
    public partial class CompletedandHEKGraphicReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public int? YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public CompletedandHEKGraphicReport MyParentReport
            {
                get { return (CompletedandHEKGraphicReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField REPORTHEADER { get {return Body().REPORTHEADER;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
            public TTReportField NewField1112 { get {return Body().NewField1112;} }
            public TTReportField NewField1113 { get {return Body().NewField1113;} }
            public TTReportField NewField13111 { get {return Body().NewField13111;} }
            public TTReportField NewField13112 { get {return Body().NewField13112;} }
            public TTReportField NewField13113 { get {return Body().NewField13113;} }
            public TTReportField NewField13114 { get {return Body().NewField13114;} }
            public TTReportField NewField111131 { get {return Body().NewField111131;} }
            public TTReportField NewField121131 { get {return Body().NewField121131;} }
            public TTReportField NewField131131 { get {return Body().NewField131131;} }
            public TTReportField NewField13115 { get {return Body().NewField13115;} }
            public TTReportField NewField151131 { get {return Body().NewField151131;} }
            public TTReportField NewField151132 { get {return Body().NewField151132;} }
            public TTReportField NewField151133 { get {return Body().NewField151133;} }
            public TTReportField NewField1231151 { get {return Body().NewField1231151;} }
            public TTReportField NewField1231152 { get {return Body().NewField1231152;} }
            public TTReportField NewField1231153 { get {return Body().NewField1231153;} }
            public TTReportField NewField1231154 { get {return Body().NewField1231154;} }
            public TTReportField NewField1231155 { get {return Body().NewField1231155;} }
            public TTReportField NewField15511321 { get {return Body().NewField15511321;} }
            public TTReportField NewField15511322 { get {return Body().NewField15511322;} }
            public TTReportField NewField14511321 { get {return Body().NewField14511321;} }
            public TTReportField OCAKTAHLIYE { get {return Body().OCAKTAHLIYE;} }
            public TTReportField SUBATTAHLIYE { get {return Body().SUBATTAHLIYE;} }
            public TTReportField MARTTAHLIYE { get {return Body().MARTTAHLIYE;} }
            public TTReportField NISANTAHLIYE { get {return Body().NISANTAHLIYE;} }
            public TTReportField MAYISTAHLIYE { get {return Body().MAYISTAHLIYE;} }
            public TTReportField HAZIRANTAHLIYE { get {return Body().HAZIRANTAHLIYE;} }
            public TTReportField TEMMUZTAHLIYE { get {return Body().TEMMUZTAHLIYE;} }
            public TTReportField AGUSTOSTAHLIYE { get {return Body().AGUSTOSTAHLIYE;} }
            public TTReportField EYLULTAHLIYE { get {return Body().EYLULTAHLIYE;} }
            public TTReportField EKIMTAHLIYE { get {return Body().EKIMTAHLIYE;} }
            public TTReportField KASIMTAHLIYE { get {return Body().KASIMTAHLIYE;} }
            public TTReportField ARALIKTAHLIYE { get {return Body().ARALIKTAHLIYE;} }
            public TTReportField OCAKHEK { get {return Body().OCAKHEK;} }
            public TTReportField SUBATHEK { get {return Body().SUBATHEK;} }
            public TTReportField MARTHEK { get {return Body().MARTHEK;} }
            public TTReportField NISANHEK { get {return Body().NISANHEK;} }
            public TTReportField MAYISHEK { get {return Body().MAYISHEK;} }
            public TTReportField HAZIRANHEK { get {return Body().HAZIRANHEK;} }
            public TTReportField TEMMUZHEK { get {return Body().TEMMUZHEK;} }
            public TTReportField AGUSTOSHEK { get {return Body().AGUSTOSHEK;} }
            public TTReportField EYLULHEK { get {return Body().EYLULHEK;} }
            public TTReportField EKIMHEK { get {return Body().EKIMHEK;} }
            public TTReportField KASIMHEK { get {return Body().KASIMHEK;} }
            public TTReportField ARALIKHEK { get {return Body().ARALIKHEK;} }
            public TTReportField OCAKORAN { get {return Body().OCAKORAN;} }
            public TTReportField SUBATORAN { get {return Body().SUBATORAN;} }
            public TTReportField MARTORAN { get {return Body().MARTORAN;} }
            public TTReportField NISANORAN { get {return Body().NISANORAN;} }
            public TTReportField MAYISORAN { get {return Body().MAYISORAN;} }
            public TTReportField HAZIRANORAN { get {return Body().HAZIRANORAN;} }
            public TTReportField TEMMUZORAN { get {return Body().TEMMUZORAN;} }
            public TTReportField AGUSTOSORAN { get {return Body().AGUSTOSORAN;} }
            public TTReportField EYLULORAN { get {return Body().EYLULORAN;} }
            public TTReportField EKIMORAN { get {return Body().EKIMORAN;} }
            public TTReportField KASIMORAN { get {return Body().KASIMORAN;} }
            public TTReportField ARALIKORAN { get {return Body().ARALIKORAN;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportShape GrafikOcak { get {return Body().GrafikOcak;} }
            public TTReportShape GrafikSubat { get {return Body().GrafikSubat;} }
            public TTReportShape GrafikMart { get {return Body().GrafikMart;} }
            public TTReportShape GrafikAralik { get {return Body().GrafikAralik;} }
            public TTReportShape GrafikKasim { get {return Body().GrafikKasim;} }
            public TTReportShape GrafikEkim { get {return Body().GrafikEkim;} }
            public TTReportShape GrafikEylul { get {return Body().GrafikEylul;} }
            public TTReportShape GrafikNisan { get {return Body().GrafikNisan;} }
            public TTReportShape GrafikMayis { get {return Body().GrafikMayis;} }
            public TTReportShape GrafikHaziran { get {return Body().GrafikHaziran;} }
            public TTReportShape GrafikTemmuz { get {return Body().GrafikTemmuz;} }
            public TTReportShape GrafikAgustos { get {return Body().GrafikAgustos;} }
            public TTReportShape GrafikOcakTa { get {return Body().GrafikOcakTa;} }
            public TTReportShape GrafikSubatTa { get {return Body().GrafikSubatTa;} }
            public TTReportShape GrafikMartTa { get {return Body().GrafikMartTa;} }
            public TTReportShape GrafikNisanTa { get {return Body().GrafikNisanTa;} }
            public TTReportShape GrafikMayisTa { get {return Body().GrafikMayisTa;} }
            public TTReportShape GrafikHaziranTa { get {return Body().GrafikHaziranTa;} }
            public TTReportShape GrafikTemmuzTa { get {return Body().GrafikTemmuzTa;} }
            public TTReportShape GrafikAgustosTa { get {return Body().GrafikAgustosTa;} }
            public TTReportShape GrafikEylulTa { get {return Body().GrafikEylulTa;} }
            public TTReportShape GrafikEkimTa { get {return Body().GrafikEkimTa;} }
            public TTReportShape GrafikKasimTa { get {return Body().GrafikKasimTa;} }
            public TTReportShape GrafikAralikTa { get {return Body().GrafikAralikTa;} }
            public TTReportField GridLegend100 { get {return Body().GridLegend100;} }
            public TTReportShape grid100 { get {return Body().grid100;} }
            public TTReportShape grid1001 { get {return Body().grid1001;} }
            public TTReportShape grid1002 { get {return Body().grid1002;} }
            public TTReportShape grid1003 { get {return Body().grid1003;} }
            public TTReportShape grid1004 { get {return Body().grid1004;} }
            public TTReportShape grid1005 { get {return Body().grid1005;} }
            public TTReportShape grid11001 { get {return Body().grid11001;} }
            public TTReportShape grid12001 { get {return Body().grid12001;} }
            public TTReportShape grid13001 { get {return Body().grid13001;} }
            public TTReportShape grid14001 { get {return Body().grid14001;} }
            public TTReportField GridLegend90 { get {return Body().GridLegend90;} }
            public TTReportField GridLegend80 { get {return Body().GridLegend80;} }
            public TTReportField GridLegend70 { get {return Body().GridLegend70;} }
            public TTReportField GridLegend60 { get {return Body().GridLegend60;} }
            public TTReportField GridLegend50 { get {return Body().GridLegend50;} }
            public TTReportField GridLegend40 { get {return Body().GridLegend40;} }
            public TTReportField GridLegend30 { get {return Body().GridLegend30;} }
            public TTReportField GridLegend20 { get {return Body().GridLegend20;} }
            public TTReportField GridLegend10 { get {return Body().GridLegend10;} }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportShape NewRect12 { get {return Body().NewRect12;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
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
                public CompletedandHEKGraphicReport MyParentReport
                {
                    get { return (CompletedandHEKGraphicReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField REPORTHEADER;
                public TTReportField NewField111;
                public TTReportField YEAR;
                public TTReportField NewField1112;
                public TTReportField NewField1113;
                public TTReportField NewField13111;
                public TTReportField NewField13112;
                public TTReportField NewField13113;
                public TTReportField NewField13114;
                public TTReportField NewField111131;
                public TTReportField NewField121131;
                public TTReportField NewField131131;
                public TTReportField NewField13115;
                public TTReportField NewField151131;
                public TTReportField NewField151132;
                public TTReportField NewField151133;
                public TTReportField NewField1231151;
                public TTReportField NewField1231152;
                public TTReportField NewField1231153;
                public TTReportField NewField1231154;
                public TTReportField NewField1231155;
                public TTReportField NewField15511321;
                public TTReportField NewField15511322;
                public TTReportField NewField14511321;
                public TTReportField OCAKTAHLIYE;
                public TTReportField SUBATTAHLIYE;
                public TTReportField MARTTAHLIYE;
                public TTReportField NISANTAHLIYE;
                public TTReportField MAYISTAHLIYE;
                public TTReportField HAZIRANTAHLIYE;
                public TTReportField TEMMUZTAHLIYE;
                public TTReportField AGUSTOSTAHLIYE;
                public TTReportField EYLULTAHLIYE;
                public TTReportField EKIMTAHLIYE;
                public TTReportField KASIMTAHLIYE;
                public TTReportField ARALIKTAHLIYE;
                public TTReportField OCAKHEK;
                public TTReportField SUBATHEK;
                public TTReportField MARTHEK;
                public TTReportField NISANHEK;
                public TTReportField MAYISHEK;
                public TTReportField HAZIRANHEK;
                public TTReportField TEMMUZHEK;
                public TTReportField AGUSTOSHEK;
                public TTReportField EYLULHEK;
                public TTReportField EKIMHEK;
                public TTReportField KASIMHEK;
                public TTReportField ARALIKHEK;
                public TTReportField OCAKORAN;
                public TTReportField SUBATORAN;
                public TTReportField MARTORAN;
                public TTReportField NISANORAN;
                public TTReportField MAYISORAN;
                public TTReportField HAZIRANORAN;
                public TTReportField TEMMUZORAN;
                public TTReportField AGUSTOSORAN;
                public TTReportField EYLULORAN;
                public TTReportField EKIMORAN;
                public TTReportField KASIMORAN;
                public TTReportField ARALIKORAN;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField4;
                public TTReportField NewField14;
                public TTReportShape GrafikOcak;
                public TTReportShape GrafikSubat;
                public TTReportShape GrafikMart;
                public TTReportShape GrafikAralik;
                public TTReportShape GrafikKasim;
                public TTReportShape GrafikEkim;
                public TTReportShape GrafikEylul;
                public TTReportShape GrafikNisan;
                public TTReportShape GrafikMayis;
                public TTReportShape GrafikHaziran;
                public TTReportShape GrafikTemmuz;
                public TTReportShape GrafikAgustos;
                public TTReportShape GrafikOcakTa;
                public TTReportShape GrafikSubatTa;
                public TTReportShape GrafikMartTa;
                public TTReportShape GrafikNisanTa;
                public TTReportShape GrafikMayisTa;
                public TTReportShape GrafikHaziranTa;
                public TTReportShape GrafikTemmuzTa;
                public TTReportShape GrafikAgustosTa;
                public TTReportShape GrafikEylulTa;
                public TTReportShape GrafikEkimTa;
                public TTReportShape GrafikKasimTa;
                public TTReportShape GrafikAralikTa;
                public TTReportField GridLegend100;
                public TTReportShape grid100;
                public TTReportShape grid1001;
                public TTReportShape grid1002;
                public TTReportShape grid1003;
                public TTReportShape grid1004;
                public TTReportShape grid1005;
                public TTReportShape grid11001;
                public TTReportShape grid12001;
                public TTReportShape grid13001;
                public TTReportShape grid14001;
                public TTReportField GridLegend90;
                public TTReportField GridLegend80;
                public TTReportField GridLegend70;
                public TTReportField GridLegend60;
                public TTReportField GridLegend50;
                public TTReportField GridLegend40;
                public TTReportField GridLegend30;
                public TTReportField GridLegend20;
                public TTReportField GridLegend10;
                public TTReportShape NewRect1;
                public TTReportShape NewRect12;
                public TTReportField NewField2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 23, 280, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"EK-8.6";

                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 33, 228, 48, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTHEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER.TextFont.Name = "Arial";
                    REPORTHEADER.TextFont.Size = 11;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.TextFont.CharSet = 162;
                    REPORTHEADER.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 33, 72, 48, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 33, 280, 48, false);
                    YEAR.Name = "YEAR";
                    YEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR.TextFont.Name = "Arial";
                    YEAR.TextFont.Bold = true;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @" Mali Yıl : {@YEAR@}";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 48, 280, 168, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 11;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 168, 72, 174, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @" Aylar";

                    NewField13111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 174, 72, 180, false);
                    NewField13111.Name = "NewField13111";
                    NewField13111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13111.TextFont.Name = "Arial";
                    NewField13111.TextFont.Bold = true;
                    NewField13111.TextFont.CharSet = 162;
                    NewField13111.Value = @" Tahliye Miktarı";

                    NewField13112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 180, 72, 186, false);
                    NewField13112.Name = "NewField13112";
                    NewField13112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13112.TextFont.Name = "Arial";
                    NewField13112.TextFont.Bold = true;
                    NewField13112.TextFont.CharSet = 162;
                    NewField13112.Value = @" HEK Miktarı";

                    NewField13113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 186, 72, 192, false);
                    NewField13113.Name = "NewField13113";
                    NewField13113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13113.TextFont.Name = "Arial";
                    NewField13113.TextFont.Bold = true;
                    NewField13113.TextFont.CharSet = 162;
                    NewField13113.Value = @" HEK / Tahliye (%)";

                    NewField13114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 168, 280, 174, false);
                    NewField13114.Name = "NewField13114";
                    NewField13114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13114.TextFont.Name = "Arial";
                    NewField13114.TextFont.Bold = true;
                    NewField13114.TextFont.CharSet = 162;
                    NewField13114.Value = @" Aylar";

                    NewField111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 174, 280, 180, false);
                    NewField111131.Name = "NewField111131";
                    NewField111131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111131.TextFont.Name = "Arial";
                    NewField111131.TextFont.Bold = true;
                    NewField111131.TextFont.CharSet = 162;
                    NewField111131.Value = @" Tahliye Miktarı";

                    NewField121131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 180, 280, 186, false);
                    NewField121131.Name = "NewField121131";
                    NewField121131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121131.TextFont.Name = "Arial";
                    NewField121131.TextFont.Bold = true;
                    NewField121131.TextFont.CharSet = 162;
                    NewField121131.Value = @" HEK Miktarı";

                    NewField131131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 186, 280, 192, false);
                    NewField131131.Name = "NewField131131";
                    NewField131131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131131.TextFont.Name = "Arial";
                    NewField131131.TextFont.Bold = true;
                    NewField131131.TextFont.CharSet = 162;
                    NewField131131.Value = @" HEK / Tahliye (%)";

                    NewField13115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 168, 85, 174, false);
                    NewField13115.Name = "NewField13115";
                    NewField13115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13115.TextFont.Name = "Arial";
                    NewField13115.TextFont.Bold = true;
                    NewField13115.TextFont.CharSet = 162;
                    NewField13115.Value = @"O";

                    NewField151131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 168, 98, 174, false);
                    NewField151131.Name = "NewField151131";
                    NewField151131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151131.TextFont.Name = "Arial";
                    NewField151131.TextFont.Bold = true;
                    NewField151131.TextFont.CharSet = 162;
                    NewField151131.Value = @"Ş";

                    NewField151132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 168, 111, 174, false);
                    NewField151132.Name = "NewField151132";
                    NewField151132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151132.TextFont.Name = "Arial";
                    NewField151132.TextFont.Bold = true;
                    NewField151132.TextFont.CharSet = 162;
                    NewField151132.Value = @"M";

                    NewField151133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 168, 124, 174, false);
                    NewField151133.Name = "NewField151133";
                    NewField151133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151133.TextFont.Name = "Arial";
                    NewField151133.TextFont.Bold = true;
                    NewField151133.TextFont.CharSet = 162;
                    NewField151133.Value = @"N";

                    NewField1231151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 168, 137, 174, false);
                    NewField1231151.Name = "NewField1231151";
                    NewField1231151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231151.TextFont.Name = "Arial";
                    NewField1231151.TextFont.Bold = true;
                    NewField1231151.TextFont.CharSet = 162;
                    NewField1231151.Value = @"M";

                    NewField1231152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 168, 150, 174, false);
                    NewField1231152.Name = "NewField1231152";
                    NewField1231152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231152.TextFont.Name = "Arial";
                    NewField1231152.TextFont.Bold = true;
                    NewField1231152.TextFont.CharSet = 162;
                    NewField1231152.Value = @"H";

                    NewField1231153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 168, 163, 174, false);
                    NewField1231153.Name = "NewField1231153";
                    NewField1231153.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231153.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231153.TextFont.Name = "Arial";
                    NewField1231153.TextFont.Bold = true;
                    NewField1231153.TextFont.CharSet = 162;
                    NewField1231153.Value = @"T";

                    NewField1231154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 168, 176, 174, false);
                    NewField1231154.Name = "NewField1231154";
                    NewField1231154.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231154.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231154.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231154.TextFont.Name = "Arial";
                    NewField1231154.TextFont.Bold = true;
                    NewField1231154.TextFont.CharSet = 162;
                    NewField1231154.Value = @"A";

                    NewField1231155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 168, 189, 174, false);
                    NewField1231155.Name = "NewField1231155";
                    NewField1231155.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231155.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231155.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231155.TextFont.Name = "Arial";
                    NewField1231155.TextFont.Bold = true;
                    NewField1231155.TextFont.CharSet = 162;
                    NewField1231155.Value = @"E";

                    NewField15511321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 168, 202, 174, false);
                    NewField15511321.Name = "NewField15511321";
                    NewField15511321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15511321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15511321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15511321.TextFont.Name = "Arial";
                    NewField15511321.TextFont.Bold = true;
                    NewField15511321.TextFont.CharSet = 162;
                    NewField15511321.Value = @"E";

                    NewField15511322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 168, 215, 174, false);
                    NewField15511322.Name = "NewField15511322";
                    NewField15511322.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15511322.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15511322.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15511322.TextFont.Name = "Arial";
                    NewField15511322.TextFont.Bold = true;
                    NewField15511322.TextFont.CharSet = 162;
                    NewField15511322.Value = @"K";

                    NewField14511321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 168, 228, 174, false);
                    NewField14511321.Name = "NewField14511321";
                    NewField14511321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14511321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14511321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14511321.TextFont.Name = "Arial";
                    NewField14511321.TextFont.Bold = true;
                    NewField14511321.TextFont.CharSet = 162;
                    NewField14511321.Value = @"A";

                    OCAKTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 174, 85, 180, false);
                    OCAKTAHLIYE.Name = "OCAKTAHLIYE";
                    OCAKTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAKTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAKTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OCAKTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OCAKTAHLIYE.TextFont.Name = "Arial";
                    OCAKTAHLIYE.TextFont.CharSet = 162;
                    OCAKTAHLIYE.Value = @"{%OCAKTAHLIYE%}";

                    SUBATTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 174, 98, 180, false);
                    SUBATTAHLIYE.Name = "SUBATTAHLIYE";
                    SUBATTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBATTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBATTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBATTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBATTAHLIYE.TextFont.Name = "Arial";
                    SUBATTAHLIYE.TextFont.CharSet = 162;
                    SUBATTAHLIYE.Value = @"{%SUBATTAHLIYE%}";

                    MARTTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 174, 111, 180, false);
                    MARTTAHLIYE.Name = "MARTTAHLIYE";
                    MARTTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    MARTTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARTTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARTTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARTTAHLIYE.TextFont.Name = "Arial";
                    MARTTAHLIYE.TextFont.CharSet = 162;
                    MARTTAHLIYE.Value = @"{%MARTTAHLIYE%}";

                    NISANTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 174, 124, 180, false);
                    NISANTAHLIYE.Name = "NISANTAHLIYE";
                    NISANTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    NISANTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISANTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NISANTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NISANTAHLIYE.TextFont.Name = "Arial";
                    NISANTAHLIYE.TextFont.CharSet = 162;
                    NISANTAHLIYE.Value = @"{%NISANTAHLIYE%}";

                    MAYISTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 174, 137, 180, false);
                    MAYISTAHLIYE.Name = "MAYISTAHLIYE";
                    MAYISTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYISTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYISTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAYISTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAYISTAHLIYE.TextFont.Name = "Arial";
                    MAYISTAHLIYE.TextFont.CharSet = 162;
                    MAYISTAHLIYE.Value = @"{%MAYISTAHLIYE%}";

                    HAZIRANTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 174, 150, 180, false);
                    HAZIRANTAHLIYE.Name = "HAZIRANTAHLIYE";
                    HAZIRANTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRANTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRANTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HAZIRANTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAZIRANTAHLIYE.TextFont.Name = "Arial";
                    HAZIRANTAHLIYE.TextFont.CharSet = 162;
                    HAZIRANTAHLIYE.Value = @"{%HAZIRANTAHLIYE%}";

                    TEMMUZTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 174, 163, 180, false);
                    TEMMUZTAHLIYE.Name = "TEMMUZTAHLIYE";
                    TEMMUZTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEMMUZTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEMMUZTAHLIYE.TextFont.Name = "Arial";
                    TEMMUZTAHLIYE.TextFont.CharSet = 162;
                    TEMMUZTAHLIYE.Value = @"{%TEMMUZTAHLIYE%}";

                    AGUSTOSTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 174, 176, 180, false);
                    AGUSTOSTAHLIYE.Name = "AGUSTOSTAHLIYE";
                    AGUSTOSTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOSTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOSTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AGUSTOSTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGUSTOSTAHLIYE.TextFont.Name = "Arial";
                    AGUSTOSTAHLIYE.TextFont.CharSet = 162;
                    AGUSTOSTAHLIYE.Value = @"{%AGUSTOSTAHLIYE%}";

                    EYLULTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 174, 189, 180, false);
                    EYLULTAHLIYE.Name = "EYLULTAHLIYE";
                    EYLULTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLULTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLULTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EYLULTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EYLULTAHLIYE.TextFont.Name = "Arial";
                    EYLULTAHLIYE.TextFont.CharSet = 162;
                    EYLULTAHLIYE.Value = @"{%EYLULTAHLIYE%}";

                    EKIMTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 174, 202, 180, false);
                    EKIMTAHLIYE.Name = "EKIMTAHLIYE";
                    EKIMTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIMTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIMTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EKIMTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EKIMTAHLIYE.TextFont.Name = "Arial";
                    EKIMTAHLIYE.TextFont.CharSet = 162;
                    EKIMTAHLIYE.Value = @"{%EKIMTAHLIYE%}";

                    KASIMTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 174, 215, 180, false);
                    KASIMTAHLIYE.Name = "KASIMTAHLIYE";
                    KASIMTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIMTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIMTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KASIMTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KASIMTAHLIYE.TextFont.Name = "Arial";
                    KASIMTAHLIYE.TextFont.CharSet = 162;
                    KASIMTAHLIYE.Value = @"{%KASIMTAHLIYE%}";

                    ARALIKTAHLIYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 174, 228, 180, false);
                    ARALIKTAHLIYE.Name = "ARALIKTAHLIYE";
                    ARALIKTAHLIYE.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIKTAHLIYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIKTAHLIYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARALIKTAHLIYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARALIKTAHLIYE.TextFont.Name = "Arial";
                    ARALIKTAHLIYE.TextFont.CharSet = 162;
                    ARALIKTAHLIYE.Value = @"{%ARALIKTAHLIYE%}";

                    OCAKHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 180, 85, 186, false);
                    OCAKHEK.Name = "OCAKHEK";
                    OCAKHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAKHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAKHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OCAKHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OCAKHEK.TextFont.Name = "Arial";
                    OCAKHEK.TextFont.CharSet = 162;
                    OCAKHEK.Value = @"{%OCAKHEK%}";

                    SUBATHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 180, 98, 186, false);
                    SUBATHEK.Name = "SUBATHEK";
                    SUBATHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBATHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBATHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBATHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBATHEK.TextFont.Name = "Arial";
                    SUBATHEK.TextFont.CharSet = 162;
                    SUBATHEK.Value = @"{%SUBATHEK%}";

                    MARTHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 180, 111, 186, false);
                    MARTHEK.Name = "MARTHEK";
                    MARTHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    MARTHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARTHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARTHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARTHEK.TextFont.Name = "Arial";
                    MARTHEK.TextFont.CharSet = 162;
                    MARTHEK.Value = @"{%MARTHEK%}";

                    NISANHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 180, 124, 186, false);
                    NISANHEK.Name = "NISANHEK";
                    NISANHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    NISANHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISANHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NISANHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NISANHEK.TextFont.Name = "Arial";
                    NISANHEK.TextFont.CharSet = 162;
                    NISANHEK.Value = @"{%NISANHEK%}";

                    MAYISHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 180, 137, 186, false);
                    MAYISHEK.Name = "MAYISHEK";
                    MAYISHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYISHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYISHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAYISHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAYISHEK.TextFont.Name = "Arial";
                    MAYISHEK.TextFont.CharSet = 162;
                    MAYISHEK.Value = @"{%MAYISHEK%}";

                    HAZIRANHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 180, 150, 186, false);
                    HAZIRANHEK.Name = "HAZIRANHEK";
                    HAZIRANHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRANHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRANHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HAZIRANHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAZIRANHEK.TextFont.Name = "Arial";
                    HAZIRANHEK.TextFont.CharSet = 162;
                    HAZIRANHEK.Value = @"{%HAZIRANHEK%}";

                    TEMMUZHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 180, 163, 186, false);
                    TEMMUZHEK.Name = "TEMMUZHEK";
                    TEMMUZHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEMMUZHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEMMUZHEK.TextFont.Name = "Arial";
                    TEMMUZHEK.TextFont.CharSet = 162;
                    TEMMUZHEK.Value = @"{%TEMMUZHEK%}";

                    AGUSTOSHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 180, 176, 186, false);
                    AGUSTOSHEK.Name = "AGUSTOSHEK";
                    AGUSTOSHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOSHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOSHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AGUSTOSHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGUSTOSHEK.TextFont.Name = "Arial";
                    AGUSTOSHEK.TextFont.CharSet = 162;
                    AGUSTOSHEK.Value = @"{%AGUSTOSHEK%}";

                    EYLULHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 180, 189, 186, false);
                    EYLULHEK.Name = "EYLULHEK";
                    EYLULHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLULHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLULHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EYLULHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EYLULHEK.TextFont.Name = "Arial";
                    EYLULHEK.TextFont.CharSet = 162;
                    EYLULHEK.Value = @"{%EYLULHEK%}";

                    EKIMHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 180, 202, 186, false);
                    EKIMHEK.Name = "EKIMHEK";
                    EKIMHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIMHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIMHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EKIMHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EKIMHEK.TextFont.Name = "Arial";
                    EKIMHEK.TextFont.CharSet = 162;
                    EKIMHEK.Value = @"{%EKIMHEK%}";

                    KASIMHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 180, 215, 186, false);
                    KASIMHEK.Name = "KASIMHEK";
                    KASIMHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIMHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIMHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KASIMHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KASIMHEK.TextFont.Name = "Arial";
                    KASIMHEK.TextFont.CharSet = 162;
                    KASIMHEK.Value = @"{%KASIMHEK%}";

                    ARALIKHEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 180, 228, 186, false);
                    ARALIKHEK.Name = "ARALIKHEK";
                    ARALIKHEK.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIKHEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIKHEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARALIKHEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARALIKHEK.TextFont.Name = "Arial";
                    ARALIKHEK.TextFont.CharSet = 162;
                    ARALIKHEK.Value = @"{%ARALIKHEK%}";

                    OCAKORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 186, 85, 192, false);
                    OCAKORAN.Name = "OCAKORAN";
                    OCAKORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAKORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAKORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OCAKORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OCAKORAN.TextFont.Name = "Arial";
                    OCAKORAN.TextFont.CharSet = 162;
                    OCAKORAN.Value = @"{%OCAKORAN%}";

                    SUBATORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 186, 98, 192, false);
                    SUBATORAN.Name = "SUBATORAN";
                    SUBATORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBATORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBATORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBATORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBATORAN.TextFont.Name = "Arial";
                    SUBATORAN.TextFont.CharSet = 162;
                    SUBATORAN.Value = @"{%SUBATORAN%}";

                    MARTORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 186, 111, 192, false);
                    MARTORAN.Name = "MARTORAN";
                    MARTORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    MARTORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARTORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARTORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARTORAN.TextFont.Name = "Arial";
                    MARTORAN.TextFont.CharSet = 162;
                    MARTORAN.Value = @"{%MARTORAN%}";

                    NISANORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 186, 124, 192, false);
                    NISANORAN.Name = "NISANORAN";
                    NISANORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    NISANORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISANORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NISANORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NISANORAN.TextFont.Name = "Arial";
                    NISANORAN.TextFont.CharSet = 162;
                    NISANORAN.Value = @"{%NISANORAN%}";

                    MAYISORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 186, 137, 192, false);
                    MAYISORAN.Name = "MAYISORAN";
                    MAYISORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYISORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYISORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAYISORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAYISORAN.TextFont.Name = "Arial";
                    MAYISORAN.TextFont.CharSet = 162;
                    MAYISORAN.Value = @"{%MAYISORAN%}";

                    HAZIRANORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 186, 150, 192, false);
                    HAZIRANORAN.Name = "HAZIRANORAN";
                    HAZIRANORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRANORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRANORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HAZIRANORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAZIRANORAN.TextFont.Name = "Arial";
                    HAZIRANORAN.TextFont.CharSet = 162;
                    HAZIRANORAN.Value = @"{%HAZIRANORAN%}";

                    TEMMUZORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 186, 163, 192, false);
                    TEMMUZORAN.Name = "TEMMUZORAN";
                    TEMMUZORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEMMUZORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEMMUZORAN.TextFont.Name = "Arial";
                    TEMMUZORAN.TextFont.CharSet = 162;
                    TEMMUZORAN.Value = @"{%TEMMUZORAN%}";

                    AGUSTOSORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 186, 176, 192, false);
                    AGUSTOSORAN.Name = "AGUSTOSORAN";
                    AGUSTOSORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOSORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOSORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AGUSTOSORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGUSTOSORAN.TextFont.Name = "Arial";
                    AGUSTOSORAN.TextFont.CharSet = 162;
                    AGUSTOSORAN.Value = @"{%AGUSTOSORAN%}";

                    EYLULORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 186, 189, 192, false);
                    EYLULORAN.Name = "EYLULORAN";
                    EYLULORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLULORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLULORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EYLULORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EYLULORAN.TextFont.Name = "Arial";
                    EYLULORAN.TextFont.CharSet = 162;
                    EYLULORAN.Value = @"{%EYLULORAN%}";

                    EKIMORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 186, 202, 192, false);
                    EKIMORAN.Name = "EKIMORAN";
                    EKIMORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIMORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIMORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EKIMORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EKIMORAN.TextFont.Name = "Arial";
                    EKIMORAN.TextFont.CharSet = 162;
                    EKIMORAN.Value = @"{%EKIMORAN%}";

                    KASIMORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 186, 215, 192, false);
                    KASIMORAN.Name = "KASIMORAN";
                    KASIMORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIMORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIMORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KASIMORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KASIMORAN.TextFont.Name = "Arial";
                    KASIMORAN.TextFont.CharSet = 162;
                    KASIMORAN.Value = @"{%KASIMORAN%}";

                    ARALIKORAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 186, 228, 192, false);
                    ARALIKORAN.Name = "ARALIKORAN";
                    ARALIKORAN.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIKORAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIKORAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARALIKORAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARALIKORAN.TextFont.Name = "Arial";
                    ARALIKORAN.TextFont.CharSet = 162;
                    ARALIKORAN.Value = @"{%ARALIKORAN%}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 48, 72, 168, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 228, 48, 228, 168, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 72, 258, 77, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Tahliye Miktarı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 58, 252, 63, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"HEK Miktarı";

                    GrafikOcak = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 72, 168, 78, 168, false);
                    GrafikOcak.Name = "GrafikOcak";
                    GrafikOcak.FillColor = System.Drawing.Color.Blue;
                    GrafikOcak.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikSubat = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 85, 168, 91, 168, false);
                    GrafikSubat.Name = "GrafikSubat";
                    GrafikSubat.FillColor = System.Drawing.Color.Blue;
                    GrafikSubat.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikMart = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 98, 168, 104, 168, false);
                    GrafikMart.Name = "GrafikMart";
                    GrafikMart.FillColor = System.Drawing.Color.Blue;
                    GrafikMart.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikAralik = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 215, 168, 221, 168, false);
                    GrafikAralik.Name = "GrafikAralik";
                    GrafikAralik.FillColor = System.Drawing.Color.Blue;
                    GrafikAralik.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikKasim = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 202, 168, 208, 168, false);
                    GrafikKasim.Name = "GrafikKasim";
                    GrafikKasim.FillColor = System.Drawing.Color.Blue;
                    GrafikKasim.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikEkim = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 189, 168, 195, 168, false);
                    GrafikEkim.Name = "GrafikEkim";
                    GrafikEkim.FillColor = System.Drawing.Color.Blue;
                    GrafikEkim.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikEylul = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 176, 168, 182, 168, false);
                    GrafikEylul.Name = "GrafikEylul";
                    GrafikEylul.FillColor = System.Drawing.Color.Blue;
                    GrafikEylul.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikNisan = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 111, 168, 117, 168, false);
                    GrafikNisan.Name = "GrafikNisan";
                    GrafikNisan.FillColor = System.Drawing.Color.Blue;
                    GrafikNisan.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikMayis = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 124, 168, 130, 168, false);
                    GrafikMayis.Name = "GrafikMayis";
                    GrafikMayis.FillColor = System.Drawing.Color.Blue;
                    GrafikMayis.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikHaziran = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 137, 168, 143, 168, false);
                    GrafikHaziran.Name = "GrafikHaziran";
                    GrafikHaziran.FillColor = System.Drawing.Color.Blue;
                    GrafikHaziran.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikTemmuz = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 150, 168, 156, 168, false);
                    GrafikTemmuz.Name = "GrafikTemmuz";
                    GrafikTemmuz.FillColor = System.Drawing.Color.Blue;
                    GrafikTemmuz.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikAgustos = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 163, 168, 169, 168, false);
                    GrafikAgustos.Name = "GrafikAgustos";
                    GrafikAgustos.FillColor = System.Drawing.Color.Blue;
                    GrafikAgustos.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikOcakTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 78, 168, 85, 168, false);
                    GrafikOcakTa.Name = "GrafikOcakTa";
                    GrafikOcakTa.FillColor = System.Drawing.Color.Red;
                    GrafikOcakTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikSubatTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 91, 168, 98, 168, false);
                    GrafikSubatTa.Name = "GrafikSubatTa";
                    GrafikSubatTa.FillColor = System.Drawing.Color.Red;
                    GrafikSubatTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikMartTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 104, 168, 111, 168, false);
                    GrafikMartTa.Name = "GrafikMartTa";
                    GrafikMartTa.FillColor = System.Drawing.Color.Red;
                    GrafikMartTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikNisanTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 117, 168, 124, 168, false);
                    GrafikNisanTa.Name = "GrafikNisanTa";
                    GrafikNisanTa.FillColor = System.Drawing.Color.Red;
                    GrafikNisanTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikMayisTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 130, 168, 137, 168, false);
                    GrafikMayisTa.Name = "GrafikMayisTa";
                    GrafikMayisTa.FillColor = System.Drawing.Color.Red;
                    GrafikMayisTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikHaziranTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 143, 168, 150, 168, false);
                    GrafikHaziranTa.Name = "GrafikHaziranTa";
                    GrafikHaziranTa.FillColor = System.Drawing.Color.Red;
                    GrafikHaziranTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikTemmuzTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 156, 168, 163, 168, false);
                    GrafikTemmuzTa.Name = "GrafikTemmuzTa";
                    GrafikTemmuzTa.FillColor = System.Drawing.Color.Red;
                    GrafikTemmuzTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikAgustosTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 169, 168, 176, 168, false);
                    GrafikAgustosTa.Name = "GrafikAgustosTa";
                    GrafikAgustosTa.FillColor = System.Drawing.Color.Red;
                    GrafikAgustosTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikEylulTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 182, 168, 189, 168, false);
                    GrafikEylulTa.Name = "GrafikEylulTa";
                    GrafikEylulTa.FillColor = System.Drawing.Color.Red;
                    GrafikEylulTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikEkimTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 195, 168, 202, 168, false);
                    GrafikEkimTa.Name = "GrafikEkimTa";
                    GrafikEkimTa.FillColor = System.Drawing.Color.Red;
                    GrafikEkimTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikKasimTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 208, 168, 215, 168, false);
                    GrafikKasimTa.Name = "GrafikKasimTa";
                    GrafikKasimTa.FillColor = System.Drawing.Color.Red;
                    GrafikKasimTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GrafikAralikTa = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 221, 168, 228, 168, false);
                    GrafikAralikTa.Name = "GrafikAralikTa";
                    GrafikAralikTa.FillColor = System.Drawing.Color.Red;
                    GrafikAralikTa.DrawStyle = DrawStyleConstants.vbSolid;

                    GridLegend100 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 65, 71, 70, false);
                    GridLegend100.Name = "GridLegend100";
                    GridLegend100.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend100.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend100.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend100.Value = @"";

                    grid100 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 68, 228, 68, false);
                    grid100.Name = "grid100";
                    grid100.ForeColor = System.Drawing.Color.Gray;
                    grid100.DrawStyle = DrawStyleConstants.vbDot;
                    grid100.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid1001 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 88, 228, 88, false);
                    grid1001.Name = "grid1001";
                    grid1001.ForeColor = System.Drawing.Color.Gray;
                    grid1001.DrawStyle = DrawStyleConstants.vbDot;
                    grid1001.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid1002 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 108, 228, 108, false);
                    grid1002.Name = "grid1002";
                    grid1002.ForeColor = System.Drawing.Color.Gray;
                    grid1002.DrawStyle = DrawStyleConstants.vbDot;
                    grid1002.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid1003 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 128, 228, 128, false);
                    grid1003.Name = "grid1003";
                    grid1003.ForeColor = System.Drawing.Color.Gray;
                    grid1003.DrawStyle = DrawStyleConstants.vbDot;
                    grid1003.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid1004 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 148, 228, 148, false);
                    grid1004.Name = "grid1004";
                    grid1004.ForeColor = System.Drawing.Color.Gray;
                    grid1004.DrawStyle = DrawStyleConstants.vbDot;
                    grid1004.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid1005 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 78, 228, 78, false);
                    grid1005.Name = "grid1005";
                    grid1005.ForeColor = System.Drawing.Color.Gray;
                    grid1005.DrawStyle = DrawStyleConstants.vbDot;
                    grid1005.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid11001 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 98, 228, 98, false);
                    grid11001.Name = "grid11001";
                    grid11001.ForeColor = System.Drawing.Color.Gray;
                    grid11001.DrawStyle = DrawStyleConstants.vbDot;
                    grid11001.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid12001 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 118, 228, 118, false);
                    grid12001.Name = "grid12001";
                    grid12001.ForeColor = System.Drawing.Color.Gray;
                    grid12001.DrawStyle = DrawStyleConstants.vbDot;
                    grid12001.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid13001 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 138, 228, 138, false);
                    grid13001.Name = "grid13001";
                    grid13001.ForeColor = System.Drawing.Color.Gray;
                    grid13001.DrawStyle = DrawStyleConstants.vbDot;
                    grid13001.FillStyle = FillStyleConstants.vbHorizontalLine;

                    grid14001 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 72, 158, 228, 158, false);
                    grid14001.Name = "grid14001";
                    grid14001.ForeColor = System.Drawing.Color.Gray;
                    grid14001.DrawStyle = DrawStyleConstants.vbDot;
                    grid14001.FillStyle = FillStyleConstants.vbHorizontalLine;

                    GridLegend90 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 75, 71, 80, false);
                    GridLegend90.Name = "GridLegend90";
                    GridLegend90.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend90.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend90.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend90.Value = @"";

                    GridLegend80 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 85, 71, 90, false);
                    GridLegend80.Name = "GridLegend80";
                    GridLegend80.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend80.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend80.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend80.Value = @"80";

                    GridLegend70 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 95, 71, 100, false);
                    GridLegend70.Name = "GridLegend70";
                    GridLegend70.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend70.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend70.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend70.Value = @"";

                    GridLegend60 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 105, 71, 110, false);
                    GridLegend60.Name = "GridLegend60";
                    GridLegend60.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend60.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend60.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend60.Value = @"";

                    GridLegend50 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 115, 71, 120, false);
                    GridLegend50.Name = "GridLegend50";
                    GridLegend50.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend50.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend50.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend50.Value = @"";

                    GridLegend40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 125, 71, 130, false);
                    GridLegend40.Name = "GridLegend40";
                    GridLegend40.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend40.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend40.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend40.Value = @"";

                    GridLegend30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 135, 71, 140, false);
                    GridLegend30.Name = "GridLegend30";
                    GridLegend30.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend30.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend30.Value = @"";

                    GridLegend20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 145, 71, 150, false);
                    GridLegend20.Name = "GridLegend20";
                    GridLegend20.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend20.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend20.Value = @"";

                    GridLegend10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 155, 71, 160, false);
                    GridLegend10.Name = "GridLegend10";
                    GridLegend10.FieldType = ReportFieldTypeEnum.ftVariable;
                    GridLegend10.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GridLegend10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GridLegend10.Value = @"";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 261, 56, 267, 62, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.FillColor = System.Drawing.Color.Blue;
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 261, 70, 267, 76, false);
                    NewRect12.Name = "NewRect12";
                    NewRect12.FillColor = System.Drawing.Color.Red;
                    NewRect12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 198, 139, 203, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.Value = @"Bu Rapor {@printdate@} Tarhinde Alınmıştır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    REPORTHEADER.CalcValue = @"";
                    NewField111.CalcValue = NewField111.Value;
                    YEAR.CalcValue = @" Mali Yıl : " + MyParentReport.RuntimeParameters.YEAR.ToString();
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField13111.CalcValue = NewField13111.Value;
                    NewField13112.CalcValue = NewField13112.Value;
                    NewField13113.CalcValue = NewField13113.Value;
                    NewField13114.CalcValue = NewField13114.Value;
                    NewField111131.CalcValue = NewField111131.Value;
                    NewField121131.CalcValue = NewField121131.Value;
                    NewField131131.CalcValue = NewField131131.Value;
                    NewField13115.CalcValue = NewField13115.Value;
                    NewField151131.CalcValue = NewField151131.Value;
                    NewField151132.CalcValue = NewField151132.Value;
                    NewField151133.CalcValue = NewField151133.Value;
                    NewField1231151.CalcValue = NewField1231151.Value;
                    NewField1231152.CalcValue = NewField1231152.Value;
                    NewField1231153.CalcValue = NewField1231153.Value;
                    NewField1231154.CalcValue = NewField1231154.Value;
                    NewField1231155.CalcValue = NewField1231155.Value;
                    NewField15511321.CalcValue = NewField15511321.Value;
                    NewField15511322.CalcValue = NewField15511322.Value;
                    NewField14511321.CalcValue = NewField14511321.Value;
                    OCAKTAHLIYE.CalcValue = MyParentReport.MAIN.OCAKTAHLIYE.CalcValue;
                    SUBATTAHLIYE.CalcValue = MyParentReport.MAIN.SUBATTAHLIYE.CalcValue;
                    MARTTAHLIYE.CalcValue = MyParentReport.MAIN.MARTTAHLIYE.CalcValue;
                    NISANTAHLIYE.CalcValue = MyParentReport.MAIN.NISANTAHLIYE.CalcValue;
                    MAYISTAHLIYE.CalcValue = MyParentReport.MAIN.MAYISTAHLIYE.CalcValue;
                    HAZIRANTAHLIYE.CalcValue = MyParentReport.MAIN.HAZIRANTAHLIYE.CalcValue;
                    TEMMUZTAHLIYE.CalcValue = MyParentReport.MAIN.TEMMUZTAHLIYE.CalcValue;
                    AGUSTOSTAHLIYE.CalcValue = MyParentReport.MAIN.AGUSTOSTAHLIYE.CalcValue;
                    EYLULTAHLIYE.CalcValue = MyParentReport.MAIN.EYLULTAHLIYE.CalcValue;
                    EKIMTAHLIYE.CalcValue = MyParentReport.MAIN.EKIMTAHLIYE.CalcValue;
                    KASIMTAHLIYE.CalcValue = MyParentReport.MAIN.KASIMTAHLIYE.CalcValue;
                    ARALIKTAHLIYE.CalcValue = MyParentReport.MAIN.ARALIKTAHLIYE.CalcValue;
                    OCAKHEK.CalcValue = MyParentReport.MAIN.OCAKHEK.CalcValue;
                    SUBATHEK.CalcValue = MyParentReport.MAIN.SUBATHEK.CalcValue;
                    MARTHEK.CalcValue = MyParentReport.MAIN.MARTHEK.CalcValue;
                    NISANHEK.CalcValue = MyParentReport.MAIN.NISANHEK.CalcValue;
                    MAYISHEK.CalcValue = MyParentReport.MAIN.MAYISHEK.CalcValue;
                    HAZIRANHEK.CalcValue = MyParentReport.MAIN.HAZIRANHEK.CalcValue;
                    TEMMUZHEK.CalcValue = MyParentReport.MAIN.TEMMUZHEK.CalcValue;
                    AGUSTOSHEK.CalcValue = MyParentReport.MAIN.AGUSTOSHEK.CalcValue;
                    EYLULHEK.CalcValue = MyParentReport.MAIN.EYLULHEK.CalcValue;
                    EKIMHEK.CalcValue = MyParentReport.MAIN.EKIMHEK.CalcValue;
                    KASIMHEK.CalcValue = MyParentReport.MAIN.KASIMHEK.CalcValue;
                    ARALIKHEK.CalcValue = MyParentReport.MAIN.ARALIKHEK.CalcValue;
                    OCAKORAN.CalcValue = MyParentReport.MAIN.OCAKORAN.CalcValue;
                    SUBATORAN.CalcValue = MyParentReport.MAIN.SUBATORAN.CalcValue;
                    MARTORAN.CalcValue = MyParentReport.MAIN.MARTORAN.CalcValue;
                    NISANORAN.CalcValue = MyParentReport.MAIN.NISANORAN.CalcValue;
                    MAYISORAN.CalcValue = MyParentReport.MAIN.MAYISORAN.CalcValue;
                    HAZIRANORAN.CalcValue = MyParentReport.MAIN.HAZIRANORAN.CalcValue;
                    TEMMUZORAN.CalcValue = MyParentReport.MAIN.TEMMUZORAN.CalcValue;
                    AGUSTOSORAN.CalcValue = MyParentReport.MAIN.AGUSTOSORAN.CalcValue;
                    EYLULORAN.CalcValue = MyParentReport.MAIN.EYLULORAN.CalcValue;
                    EKIMORAN.CalcValue = MyParentReport.MAIN.EKIMORAN.CalcValue;
                    KASIMORAN.CalcValue = MyParentReport.MAIN.KASIMORAN.CalcValue;
                    ARALIKORAN.CalcValue = MyParentReport.MAIN.ARALIKORAN.CalcValue;
                    NewField4.CalcValue = NewField4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    GridLegend100.CalcValue = @"";
                    GridLegend90.CalcValue = @"";
                    GridLegend80.CalcValue = @"80";
                    GridLegend70.CalcValue = @"";
                    GridLegend60.CalcValue = @"";
                    GridLegend50.CalcValue = @"";
                    GridLegend40.CalcValue = @"";
                    GridLegend30.CalcValue = @"";
                    GridLegend20.CalcValue = @"";
                    GridLegend10.CalcValue = @"";
                    NewField2.CalcValue = @"Bu Rapor " + DateTime.Now.ToShortDateString() + @" Tarhinde Alınmıştır.";
                    return new TTReportObject[] { NewField1,REPORTHEADER,NewField111,YEAR,NewField1112,NewField1113,NewField13111,NewField13112,NewField13113,NewField13114,NewField111131,NewField121131,NewField131131,NewField13115,NewField151131,NewField151132,NewField151133,NewField1231151,NewField1231152,NewField1231153,NewField1231154,NewField1231155,NewField15511321,NewField15511322,NewField14511321,OCAKTAHLIYE,SUBATTAHLIYE,MARTTAHLIYE,NISANTAHLIYE,MAYISTAHLIYE,HAZIRANTAHLIYE,TEMMUZTAHLIYE,AGUSTOSTAHLIYE,EYLULTAHLIYE,EKIMTAHLIYE,KASIMTAHLIYE,ARALIKTAHLIYE,OCAKHEK,SUBATHEK,MARTHEK,NISANHEK,MAYISHEK,HAZIRANHEK,TEMMUZHEK,AGUSTOSHEK,EYLULHEK,EKIMHEK,KASIMHEK,ARALIKHEK,OCAKORAN,SUBATORAN,MARTORAN,NISANORAN,MAYISORAN,HAZIRANORAN,TEMMUZORAN,AGUSTOSORAN,EYLULORAN,EKIMORAN,KASIMORAN,ARALIKORAN,NewField4,NewField14,GridLegend100,GridLegend90,GridLegend80,GridLegend70,GridLegend60,GridLegend50,GridLegend40,GridLegend30,GridLegend20,GridLegend10,NewField2};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                REPORTHEADER.CalcValue = "XXXXXX Biyomedikal Mühendislik Merkezi Tahliye Ve HEK Grafiği";
            else
                REPORTHEADER.CalcValue = "Tahliye Ve HEK Grafiği";
            
            
            // fabrika için
            
            int ocakHEK = 0;
            int subatHEK = 0;
            int martHEK = 0;
            int nisanHEK = 0;
            int mayisHEK = 0;
            int haziranHEK = 0;
            int temmuzHEK = 0;
            int agustosHEK = 0;
            int eylulHEK = 0;
            int ekimHEK = 0;
            int kasimHEK = 0;
            int aralikHEK = 0;
            int toplamHEK = 0;

            int ocakTA = 0;
            int subatTA = 0;
            int martTA = 0;
            int nisanTA = 0;
            int mayisTA = 0;
            int haziranTA = 0;
            int temmuzTA = 0;
            int agustosTA = 0;
            int eylulTA = 0;
            int ekimTA = 0;
            int kasimTA = 0;
            int aralikTA = 0;
            int toplamTAHLIYE = 0;


            Guid hekStateDefId = MaintenanceOrder.States.HEK;

            TTObjectContext ctx = new TTObjectContext(true);
            IBindingList allList = MaintenanceOrder.FabrikaHEKQuery(ctx, (int)(this.MyParentReport.RuntimeParameters.YEAR.Value));

            foreach (MaintenanceOrder rp1 in allList)
            {

                foreach (TTObjectState objectState in rp1.GetStateHistory())
                {
                    if ((objectState.StateDefID.Equals(hekStateDefId)) )
                    {
                        if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 1 || rp1.StartDate.Value.Month == 01))
                        { ocakHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 2 || rp1.StartDate.Value.Month == 02))
                        { subatHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 3 || rp1.StartDate.Value.Month == 03))
                        { martHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 4 || rp1.StartDate.Value.Month == 04))
                        { nisanHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 5 || rp1.StartDate.Value.Month == 05))
                        { mayisHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 6 || rp1.StartDate.Value.Month == 06))
                        { haziranHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 7 || rp1.StartDate.Value.Month == 07))
                        { temmuzHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 8 || rp1.StartDate.Value.Month == 08))
                        { agustosHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 9 || rp1.StartDate.Value.Month == 09))
                        { eylulHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 10))
                        { ekimHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 11))
                        { kasimHEK++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 12))
                        { aralikHEK++; }
                    }

                    else if (!((objectState.StateDefID.Equals(hekStateDefId))))
                    {
                        if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 1 || rp1.StartDate.Value.Month == 01))
                        { ocakTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 2 || rp1.StartDate.Value.Month == 02))
                        { subatTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 3 || rp1.StartDate.Value.Month == 03))
                        { martTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 4 || rp1.StartDate.Value.Month == 04))
                        { nisanTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 5 || rp1.StartDate.Value.Month == 05))
                        { mayisTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 6 || rp1.StartDate.Value.Month == 06))
                        { haziranTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 7 || rp1.StartDate.Value.Month == 07))
                        { temmuzTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 8 || rp1.StartDate.Value.Month == 08))
                        { agustosTA++; }

                        else if (rp1.StartDate.HasValue && (rp1.StartDate.Value.Month == 9 || rp1.StartDate.Value.Month == 09))
                        { eylulTA++; }

                        else if (rp1.StartDate.HasValue && rp1.StartDate.Value.Month == 10)
                        { ekimTA++; }

                        else if (rp1.StartDate.HasValue && rp1.StartDate.Value.Month == 11)
                        { kasimTA++; }

                        else if (rp1.StartDate.HasValue && rp1.StartDate.Value.Month == 12)
                        { aralikTA++; }

                    }
                }


            }

            toplamHEK = ocakHEK + subatHEK + martHEK + nisanHEK + mayisHEK + haziranHEK + temmuzHEK + agustosHEK + eylulHEK + ekimHEK + kasimHEK + aralikHEK;
            toplamTAHLIYE = ocakTA + subatTA + martTA + nisanTA + mayisTA + haziranTA + temmuzTA + agustosTA + eylulTA + ekimTA + kasimTA + aralikTA;
            int[] monthHEK = { ocakHEK, subatHEK, martHEK, nisanHEK, mayisHEK, haziranHEK, temmuzHEK, agustosHEK, eylulHEK, ekimHEK, kasimHEK, aralikHEK };
            int[] monthTA = { ocakTA, subatTA, martTA, nisanTA, mayisTA, haziranTA, temmuzTA, agustosTA, eylulTA, ekimTA, kasimTA, aralikTA };

            //throw new TTException("hek amount:"+hekList.Count.ToString()+"\r\nnormal amount:"+normalList.Count.ToString());

            int GraphScale = 1;
            int bolen = 1;

            for (int i = 0; i < 12; i++)
            {
                if (monthHEK[i] > (GraphScale * 10))
                {
                    GraphScale = GraphScale * 10;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                if (monthTA[i] > (GraphScale * 10))
                {
                    GraphScale = GraphScale * 10;
                }
            }



            GridLegend100.CalcValue = (10 * GraphScale).ToString();
            GridLegend90.CalcValue = (9 * GraphScale).ToString();
            GridLegend80.CalcValue = (8 * GraphScale).ToString();
            GridLegend70.CalcValue = (7 * GraphScale).ToString();
            GridLegend60.CalcValue = (6 * GraphScale).ToString();
            GridLegend50.CalcValue = (5 * GraphScale).ToString();
            GridLegend40.CalcValue = (4 * GraphScale).ToString();
            GridLegend30.CalcValue = (3 * GraphScale).ToString();
            GridLegend20.CalcValue = (2 * GraphScale).ToString();
            GridLegend10.CalcValue = (1 * GraphScale).ToString();


            if (GraphScale > 10)
            {
                bolen = GraphScale / 10;
            }

            //------------------------------------------------------ alt taraf tahliye için MCA

            OCAKTAHLIYE.CalcValue = ocakTA.ToString();
            GrafikOcakTa.Y1 = 168 - (ocakTA / bolen);

            SUBATTAHLIYE.CalcValue = subatTA.ToString();
            GrafikSubatTa.Y1 = 168 - (subatTA / bolen);

            MARTTAHLIYE.CalcValue = martTA.ToString();
            GrafikMartTa.Y1 = 168 - (martTA / bolen);

            NISANTAHLIYE.CalcValue = nisanTA.ToString();
            GrafikNisanTa.Y1 = 168 - (nisanTA / bolen);

            MAYISTAHLIYE.CalcValue = mayisTA.ToString();
            GrafikMayisTa.Y1 = 168 - (mayisTA / bolen);

            HAZIRANTAHLIYE.CalcValue = haziranTA.ToString();
            GrafikHaziranTa.Y1 = 168 - (haziranTA / bolen);

            TEMMUZTAHLIYE.CalcValue = temmuzTA.ToString();
            GrafikTemmuzTa.Y1 = 168 - (temmuzTA / bolen);

            AGUSTOSTAHLIYE.CalcValue = agustosTA.ToString();
            GrafikAgustosTa.Y1 = 168 - (agustosTA / bolen);

            EYLULTAHLIYE.CalcValue = eylulTA.ToString();
            GrafikEylulTa.Y1 = 168 - (eylulTA / bolen);

            EKIMTAHLIYE.CalcValue = ekimTA.ToString();
            GrafikEkimTa.Y1 = 168 - (ekimTA / bolen);

            KASIMTAHLIYE.CalcValue = kasimTA.ToString();
            GrafikKasimTa.Y1 = 168 - (kasimTA / bolen);

            ARALIKTAHLIYE.CalcValue = aralikTA.ToString();
            GrafikAralikTa.Y1 = 168 - (aralikTA / bolen);

            //------------------------------------- alt taraf hek için MCA


            OCAKHEK.CalcValue = ocakHEK.ToString();
            if (ocakTA != 0 && ocakHEK != 0)
            { OCAKORAN.CalcValue = "%" + ((double)(100 * (double)ocakHEK / (double)ocakTA)).ToString("##.##"); }
            else if (ocakTA == 0 || ocakHEK == 0 )
            { OCAKORAN.CalcValue = "-"; }
            GrafikOcak.Y1 = 168 - (ocakHEK / bolen);

            SUBATHEK.CalcValue = subatHEK.ToString();
            if (subatTA != 0 && subatHEK != 0)
            { SUBATORAN.CalcValue = "%" + ((double)(100 * (double)subatHEK / (double)subatTA)).ToString("##.##"); }
            else if (subatTA == 0 || subatHEK == 0)
            { SUBATORAN.CalcValue = "-"; }
            GrafikSubat.Y1 = 168 - (subatHEK / bolen);

            MARTHEK.CalcValue = martHEK.ToString();
            if (martTA != 0 && martHEK != 0)
            { MARTORAN.CalcValue = "%" + ((double)(100 * (double)martHEK / (double)martTA)).ToString("##.##"); }
            else if (martTA == 0 || martHEK == 0)
            { MARTORAN.CalcValue = "-"; }
            GrafikMart.Y1 = 168 - (martHEK / bolen);

            NISANHEK.CalcValue = nisanHEK.ToString();
            if (nisanTA != 0 && nisanHEK !=0)
            { NISANORAN.CalcValue = "%" + ((double)(100 * (double)nisanHEK / (double)nisanTA)).ToString("##.##"); }
            else if (nisanTA == 0 || nisanHEK ==0)
            { NISANORAN.CalcValue = "-"; }
            GrafikNisan.Y1 = 168 - (nisanHEK / bolen);

            MAYISHEK.CalcValue = mayisHEK.ToString();
            if (mayisTA != 0 && mayisHEK != 0)
            { MAYISORAN.CalcValue = "%" +((double) (100 *(double)mayisHEK / (double)mayisTA)).ToString("##.##"); }
            else if (mayisTA == 0 || mayisHEK == 0)
            { MAYISORAN.CalcValue = "-"; }
            GrafikMayis.Y1 = 168 - (mayisHEK / bolen);

            HAZIRANHEK.CalcValue = haziranHEK.ToString();
            if (haziranTA != 0 && haziranHEK != 0)
            { HAZIRANORAN.CalcValue = "%" + ((double)(100 * (double)haziranHEK / (double)haziranTA)).ToString("##.##"); }
            else if (haziranTA == 0 || haziranHEK == 0)
            { HAZIRANORAN.CalcValue = "-"; }
            GrafikHaziran.Y1 = 168 - (haziranHEK / bolen);

            TEMMUZHEK.CalcValue = temmuzHEK.ToString();
            if (temmuzTA != 0 && temmuzHEK != 0)
            { TEMMUZORAN.CalcValue = "%" + ((double)(100 * (double)temmuzHEK / (double)temmuzTA)).ToString("##.##"); }
            else if (temmuzTA == 0 || temmuzHEK == 0 )
            { TEMMUZORAN.CalcValue = "-"; }
            GrafikTemmuz.Y1 = 168 - (temmuzHEK / bolen);

            AGUSTOSHEK.CalcValue = agustosHEK.ToString();
            if (agustosTA != 0 && agustosHEK !=0)
            { AGUSTOSORAN.CalcValue = "%" + ((double)(100 * (double)agustosHEK / (double)agustosTA)).ToString("##.##"); }
            else if (agustosTA == 0 || agustosHEK == 0)
            { AGUSTOSORAN.CalcValue = "-"; }
            GrafikAgustos.Y1 = 168 - (agustosHEK / bolen);

            EYLULHEK.CalcValue = eylulHEK.ToString();
            if (eylulTA != 0 && eylulHEK != 0)
            { EYLULORAN.CalcValue = "%" + ((double)(100 * (double)eylulHEK / (double)eylulTA)).ToString("##.##"); }
            else if (eylulTA == 0 || eylulHEK == 0)
            { EYLULORAN.CalcValue = "-"; }
            GrafikEylul.Y1 = 168 - (eylulHEK / bolen);

            EKIMHEK.CalcValue = ekimHEK.ToString();
            if (ekimTA != 0 && ekimHEK != 0)
            { EKIMORAN.CalcValue = "%" + ((double)(100 * (double)ekimHEK / (double)ekimTA)).ToString("##.##"); }
            else if (ekimTA == 0 || ekimHEK == 0)
            { EKIMORAN.CalcValue = "-"; }
            GrafikEkim.Y1 = 168 - (ekimHEK / bolen);

            KASIMHEK.CalcValue = kasimHEK.ToString();
            if (kasimTA != 0 && kasimHEK != 0)
            { KASIMORAN.CalcValue = "%" + ((double)(100 * (double)kasimHEK / (double)kasimTA)).ToString("##.##"); }
            else if (kasimTA == 0 || kasimHEK ==0)
            { KASIMORAN.CalcValue = "-"; }
            GrafikKasim.Y1 = 168 - (kasimHEK / bolen);

            ARALIKHEK.CalcValue = aralikHEK.ToString();
            if (aralikTA != 0 && agustosHEK != 0)
            { ARALIKORAN.CalcValue = "%" + ((double)(100 * (double)aralikHEK / (double)aralikTA)).ToString("##.##"); }
            else if (aralikTA == 0 || agustosHEK == 0)
            { ARALIKORAN.CalcValue = "-"; }
            GrafikAralik.Y1 = 168 - (aralikHEK / bolen);
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

        public CompletedandHEKGraphicReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("YEAR", "", "Mali Yılı Giriniz", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["YEAR"]);
            Name = "COMPLETEDANDHEKGRAPHICREPORT";
            Caption = "Tahliye ve HEK Grafiği";
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