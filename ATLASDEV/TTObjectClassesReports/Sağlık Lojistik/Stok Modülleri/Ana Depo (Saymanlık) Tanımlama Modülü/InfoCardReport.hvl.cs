
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
    /// Taşinır Mal Sorumlusu Tanıtma Kartı
    /// </summary>
    public partial class InfoCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public InfoCardReport MyParentReport
            {
                get { return (InfoCardReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Birlik { get {return Body().Birlik;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField ReportName1 { get {return Body().ReportName1;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField11112 { get {return Body().NewField11112;} }
            public TTReportField NewField11113 { get {return Body().NewField11113;} }
            public TTReportField NewField131111 { get {return Body().NewField131111;} }
            public TTReportField NewField131112 { get {return Body().NewField131112;} }
            public TTReportField NewField1111131 { get {return Body().NewField1111131;} }
            public TTReportField NewField11311111 { get {return Body().NewField11311111;} }
            public TTReportField NewField1112 { get {return Body().NewField1112;} }
            public TTReportField NewField12111 { get {return Body().NewField12111;} }
            public TTReportField NewField12113 { get {return Body().NewField12113;} }
            public TTReportField NewField12114 { get {return Body().NewField12114;} }
            public TTReportField NewField12115 { get {return Body().NewField12115;} }
            public TTReportField Ad { get {return Body().Ad;} }
            public TTReportField Rutbe { get {return Body().Rutbe;} }
            public TTReportField Sicil { get {return Body().Sicil;} }
            public TTReportField Tarih { get {return Body().Tarih;} }
            public TTReportField NewField131113 { get {return Body().NewField131113;} }
            public TTReportField NewField131114 { get {return Body().NewField131114;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public TTReportField NewField12112 { get {return Body().NewField12112;} }
            public TTReportField NewField12116 { get {return Body().NewField12116;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportField ReportName11 { get {return Body().ReportName11;} }
            public TTReportField NewField1211131 { get {return Body().NewField1211131;} }
            public TTReportField NewField11311112 { get {return Body().NewField11311112;} }
            public TTReportField NewField111111311 { get {return Body().NewField111111311;} }
            public TTReportField NewField11311121 { get {return Body().NewField11311121;} }
            public TTReportField NewField1311131 { get {return Body().NewField1311131;} }
            public TTReportField MalSayman { get {return Body().MalSayman;} }
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
                public InfoCardReport MyParentReport
                {
                    get { return (InfoCardReport)ParentReport; }
                }
                
                public TTReportField Birlik;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111;
                public TTReportField ReportName1;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11112;
                public TTReportField NewField11113;
                public TTReportField NewField131111;
                public TTReportField NewField131112;
                public TTReportField NewField1111131;
                public TTReportField NewField11311111;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField12113;
                public TTReportField NewField12114;
                public TTReportField NewField12115;
                public TTReportField Ad;
                public TTReportField Rutbe;
                public TTReportField Sicil;
                public TTReportField Tarih;
                public TTReportField NewField131113;
                public TTReportField NewField131114;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine141;
                public TTReportField NewField12112;
                public TTReportField NewField12116;
                public TTReportShape NewLine15;
                public TTReportShape NewLine112;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1111;
                public TTReportField ReportName11;
                public TTReportField NewField1211131;
                public TTReportField NewField11311112;
                public TTReportField NewField111111311;
                public TTReportField NewField11311121;
                public TTReportField NewField1311131;
                public TTReportField MalSayman; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 279;
                    RepeatCount = 0;
                    
                    Birlik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 42, 124, 48, false);
                    Birlik.Name = "Birlik";
                    Birlik.FieldType = ReportFieldTypeEnum.ftVariable;
                    Birlik.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Birlik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Birlik.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 23, 14, 133, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 3;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 23, 201, 23, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 3;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 23, 201, 133, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 3;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 133, 201, 133, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 3;

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 24, 200, 35, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Size = 15;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"TAŞINIR MAL SORUMLUSU TANITMA KARTI";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 42, 44, 48, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Birliği";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 49, 44, 55, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Adı, Soyadı";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 56, 44, 62, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112.TextFont.Size = 11;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Rütbesi";

                    NewField11113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 63, 44, 69, false);
                    NewField11113.Name = "NewField11113";
                    NewField11113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11113.TextFont.Size = 11;
                    NewField11113.TextFont.Bold = true;
                    NewField11113.TextFont.CharSet = 162;
                    NewField11113.Value = @"Sicil Nu.";

                    NewField131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 70, 44, 76, false);
                    NewField131111.Name = "NewField131111";
                    NewField131111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131111.TextFont.Size = 11;
                    NewField131111.TextFont.Bold = true;
                    NewField131111.TextFont.CharSet = 162;
                    NewField131111.Value = @"İmzası";

                    NewField131112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 83, 197, 89, false);
                    NewField131112.Name = "NewField131112";
                    NewField131112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131112.TextFont.Size = 11;
                    NewField131112.TextFont.Bold = true;
                    NewField131112.TextFont.CharSet = 162;
                    NewField131112.Value = @"Yukarıda imzasıyla kimliği yazılı şahıs bu kartın arkasına yazılı işleri yapmağa yetkilidir.";

                    NewField1111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 95, 101, 101, false);
                    NewField1111131.Name = "NewField1111131";
                    NewField1111131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111131.TextFont.Size = 11;
                    NewField1111131.TextFont.Bold = true;
                    NewField1111131.TextFont.CharSet = 162;
                    NewField1111131.Value = @"Birlik XXXXXXı/Kısım Amiri";

                    NewField11311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 95, 193, 101, false);
                    NewField11311111.Name = "NewField11311111";
                    NewField11311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311111.TextFont.Size = 11;
                    NewField11311111.TextFont.Bold = true;
                    NewField11311111.TextFont.CharSet = 162;
                    NewField11311111.Value = @"Taşınır Mal Saymanı";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 42, 46, 48, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Size = 11;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @":";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 49, 46, 55, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Size = 11;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @":";

                    NewField12113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 56, 46, 62, false);
                    NewField12113.Name = "NewField12113";
                    NewField12113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12113.TextFont.Size = 11;
                    NewField12113.TextFont.Bold = true;
                    NewField12113.TextFont.CharSet = 162;
                    NewField12113.Value = @":";

                    NewField12114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 63, 46, 69, false);
                    NewField12114.Name = "NewField12114";
                    NewField12114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12114.TextFont.Size = 11;
                    NewField12114.TextFont.Bold = true;
                    NewField12114.TextFont.CharSet = 162;
                    NewField12114.Value = @":";

                    NewField12115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 70, 46, 76, false);
                    NewField12115.Name = "NewField12115";
                    NewField12115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12115.TextFont.Size = 11;
                    NewField12115.TextFont.Bold = true;
                    NewField12115.TextFont.CharSet = 162;
                    NewField12115.Value = @":";

                    Ad = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 49, 124, 55, false);
                    Ad.Name = "Ad";
                    Ad.FieldType = ReportFieldTypeEnum.ftVariable;
                    Ad.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Ad.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Ad.Value = @"";

                    Rutbe = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 56, 124, 62, false);
                    Rutbe.Name = "Rutbe";
                    Rutbe.FieldType = ReportFieldTypeEnum.ftVariable;
                    Rutbe.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Rutbe.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Rutbe.Value = @"";

                    Sicil = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 63, 124, 69, false);
                    Sicil.Name = "Sicil";
                    Sicil.FieldType = ReportFieldTypeEnum.ftVariable;
                    Sicil.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Sicil.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Sicil.Value = @"";

                    Tarih = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 70, 169, 76, false);
                    Tarih.Name = "Tarih";
                    Tarih.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tarih.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Tarih.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Tarih.Value = @"";

                    NewField131113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 62, 146, 68, false);
                    NewField131113.Name = "NewField131113";
                    NewField131113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131113.TextFont.Size = 11;
                    NewField131113.TextFont.Bold = true;
                    NewField131113.TextFont.CharSet = 162;
                    NewField131113.Value = @"Sıra Nu.";

                    NewField131114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 70, 146, 76, false);
                    NewField131114.Name = "NewField131114";
                    NewField131114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131114.TextFont.Size = 11;
                    NewField131114.TextFont.Bold = true;
                    NewField131114.TextFont.CharSet = 162;
                    NewField131114.Value = @"Tarih";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 171, 43, 171, 76, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 43, 197, 76, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 171, 43, 197, 43, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 2;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 171, 76, 197, 76, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine141.DrawWidth = 2;

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 62, 148, 68, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112.TextFont.Size = 11;
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @":";

                    NewField12116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 70, 148, 76, false);
                    NewField12116.Name = "NewField12116";
                    NewField12116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12116.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12116.TextFont.Size = 11;
                    NewField12116.TextFont.Bold = true;
                    NewField12116.TextFont.CharSet = 162;
                    NewField12116.Value = @":";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 148, 14, 258, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.DrawWidth = 3;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 148, 201, 148, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.DrawWidth = 3;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 148, 201, 258, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 3;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 258, 201, 258, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 3;

                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 149, 200, 160, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Size = 15;
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"TAŞINIR MAL SORUMLUSU TANITMA KARTININ ARKA KISMI";

                    NewField1211131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 176, 197, 182, false);
                    NewField1211131.Name = "NewField1211131";
                    NewField1211131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211131.TextFont.Size = 11;
                    NewField1211131.TextFont.Bold = true;
                    NewField1211131.TextFont.CharSet = 162;
                    NewField1211131.Value = @"1.	Tüketim taşınır mallarını almaya ve imza etmeye yetkilidir.";

                    NewField11311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 201, 197, 207, false);
                    NewField11311112.Name = "NewField11311112";
                    NewField11311112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311112.TextFont.Size = 11;
                    NewField11311112.TextFont.Bold = true;
                    NewField11311112.TextFont.CharSet = 162;
                    NewField11311112.Value = @"Not: Yetki verilmeyen taşınır mallara ait maddeyi yazmayınız.";

                    NewField111111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 165, 200, 171, false);
                    NewField111111311.Name = "NewField111111311";
                    NewField111111311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111311.TextFont.Size = 11;
                    NewField111111311.TextFont.Bold = true;
                    NewField111111311.TextFont.CharSet = 162;
                    NewField111111311.Value = @"Verilen Yetki";

                    NewField11311121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 187, 197, 193, false);
                    NewField11311121.Name = "NewField11311121";
                    NewField11311121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311121.TextFont.Size = 11;
                    NewField11311121.TextFont.Bold = true;
                    NewField11311121.TextFont.CharSet = 162;
                    NewField11311121.Value = @"2.	Dayanıklı taşınır mallarını almaya ve imza etmeye yetkilidir.";

                    NewField1311131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 44, 195, 72, false);
                    NewField1311131.Name = "NewField1311131";
                    NewField1311131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311131.TextFont.Size = 11;
                    NewField1311131.TextFont.Bold = true;
                    NewField1311131.TextFont.CharSet = 162;
                    NewField1311131.Value = @"Fotoğraf";

                    MalSayman = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 113, 194, 128, false);
                    MalSayman.Name = "MalSayman";
                    MalSayman.FieldType = ReportFieldTypeEnum.ftVariable;
                    MalSayman.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MalSayman.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MalSayman.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MalSayman.MultiLine = EvetHayirEnum.ehEvet;
                    MalSayman.ExpandTabs = EvetHayirEnum.ehEvet;
                    MalSayman.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Birlik.CalcValue = @"";
                    ReportName1.CalcValue = ReportName1.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField11113.CalcValue = NewField11113.Value;
                    NewField131111.CalcValue = NewField131111.Value;
                    NewField131112.CalcValue = NewField131112.Value;
                    NewField1111131.CalcValue = NewField1111131.Value;
                    NewField11311111.CalcValue = NewField11311111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField12113.CalcValue = NewField12113.Value;
                    NewField12114.CalcValue = NewField12114.Value;
                    NewField12115.CalcValue = NewField12115.Value;
                    Ad.CalcValue = @"";
                    Rutbe.CalcValue = @"";
                    Sicil.CalcValue = @"";
                    Tarih.CalcValue = @"";
                    NewField131113.CalcValue = NewField131113.Value;
                    NewField131114.CalcValue = NewField131114.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    NewField12116.CalcValue = NewField12116.Value;
                    ReportName11.CalcValue = ReportName11.Value;
                    NewField1211131.CalcValue = NewField1211131.Value;
                    NewField11311112.CalcValue = NewField11311112.Value;
                    NewField111111311.CalcValue = NewField111111311.Value;
                    NewField11311121.CalcValue = NewField11311121.Value;
                    NewField1311131.CalcValue = NewField1311131.Value;
                    MalSayman.CalcValue = @"";
                    return new TTReportObject[] { Birlik,ReportName1,NewField111,NewField1111,NewField11112,NewField11113,NewField131111,NewField131112,NewField1111131,NewField11311111,NewField1112,NewField12111,NewField12113,NewField12114,NewField12115,Ad,Rutbe,Sicil,Tarih,NewField131113,NewField131114,NewField12112,NewField12116,ReportName11,NewField1211131,NewField11311112,NewField111111311,NewField11311121,NewField1311131,MalSayman};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID != null)
            {
                Guid storeGuid = new Guid(MyParentReport.RuntimeParameters.TTOBJECTID);
                MainStoreDefinition mainStore = (MainStoreDefinition)MyParentReport.ReportObjectContext.GetObject(storeGuid , typeof(MainStoreDefinition));
                if(mainStore.GoodsResponsible != null)
                {
                    Ad.CalcValue = mainStore.GoodsResponsible.Name;
                    if(mainStore.GoodsResponsible.MilitaryClass != null && mainStore.GoodsResponsible.Rank != null)
                    {
                        Rutbe.CalcValue = mainStore.GoodsResponsible.MilitaryClass.ShortName + mainStore.GoodsResponsible.Rank.ShortName  ;
                    }
                    Sicil.CalcValue = mainStore.GoodsResponsible.EmploymentRecordID ;
                    Birlik.CalcValue = mainStore.Accountancy.AccountancyMilitaryUnit.Name;
                }
                string signDesc = string.Empty;
                signDesc += mainStore.GoodsAccountant.Name + "\r\n";
                if(mainStore.GoodsAccountant.MilitaryClass != null)
                    signDesc += mainStore.GoodsAccountant.MilitaryClass.ShortName;
                if(mainStore.GoodsAccountant.Rank != null)
                    signDesc += mainStore.GoodsAccountant.Rank.ShortName + "\r\n";
                signDesc += "(" + mainStore.GoodsAccountant.EmploymentRecordID + ")";
                MalSayman.CalcValue = signDesc;
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

        public InfoCardReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Mal Sorumlusu", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INFOCARDREPORT";
            Caption = "Taşinır Mal Sorumlusu Tanıtma Kartı";
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