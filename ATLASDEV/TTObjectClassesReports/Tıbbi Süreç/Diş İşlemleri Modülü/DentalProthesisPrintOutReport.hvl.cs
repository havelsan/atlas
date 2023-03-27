
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
    /// Filan
    /// </summary>
    public partial class DentalProthesisPrintOutReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public DentalProthesisPrintOutReport MyParentReport
            {
                get { return (DentalProthesisPrintOutReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField NAME12 { get {return Body().NAME12;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField PID1 { get {return Body().PID1;} }
            public TTReportField NewField2412 { get {return Body().NewField2412;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportShape NewLine8 { get {return Body().NewLine8;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField82 { get {return Body().NewField82;} }
            public TTReportField NewField83 { get {return Body().NewField83;} }
            public TTReportField NewField841 { get {return Body().NewField841;} }
            public TTReportField NewField882 { get {return Body().NewField882;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportField NewField78 { get {return Body().NewField78;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportField NewField249 { get {return Body().NewField249;} }
            public TTReportField NewField248 { get {return Body().NewField248;} }
            public TTReportField NewField247 { get {return Body().NewField247;} }
            public TTReportField NewField246 { get {return Body().NewField246;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField245 { get {return Body().NewField245;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportField NewField244 { get {return Body().NewField244;} }
            public TTReportField NewField243 { get {return Body().NewField243;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportField NewField84 { get {return Body().NewField84;} }
            public TTReportField NewField2422 { get {return Body().NewField2422;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportField NewField88 { get {return Body().NewField88;} }
            public TTReportField NewField80 { get {return Body().NewField80;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
            public TTReportField EMEKLISICILNO { get {return Body().EMEKLISICILNO;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField GIDECEGIYER { get {return Body().GIDECEGIYER;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportField TEDAVİ { get {return Body().TEDAVİ;} }
            public TTReportField DOKTOR { get {return Body().DOKTOR;} }
            public TTReportField DOKTORRUTBE { get {return Body().DOKTORRUTBE;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField PID { get {return Body().PID;} }
            public TTReportField DOKTORSICILNO { get {return Body().DOKTORSICILNO;} }
            public TTReportField DDOKTOR { get {return Body().DDOKTOR;} }
            public TTReportField DDOKTORRUTBE { get {return Body().DDOKTORRUTBE;} }
            public TTReportField DDOKTORSICILNO { get {return Body().DDOKTORSICILNO;} }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField FISNO { get {return Body().FISNO;} }
            public TTReportField AILENAME { get {return Body().AILENAME;} }
            public TTReportField NewField2433 { get {return Body().NewField2433;} }
            public TTReportField DOKTORUZMANLIK { get {return Body().DOKTORUZMANLIK;} }
            public TTReportField DUZMANLIK { get {return Body().DUZMANLIK;} }
            public TTReportShape NewLine241 { get {return Body().NewLine241;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportField DİŞ_POZİSYON { get {return Body().DİŞ_POZİSYON;} }
            public TTReportField DİŞ_NO { get {return Body().DİŞ_NO;} }
            public TTReportField TEDAVİ1 { get {return Body().TEDAVİ1;} }
            public TTReportField TEDAVİ11 { get {return Body().TEDAVİ11;} }
            public TTReportField TEDAVİ12 { get {return Body().TEDAVİ12;} }
            public TTReportField NewField13342 { get {return Body().NewField13342;} }
            public TTReportField NewField13344 { get {return Body().NewField13344;} }
            public TTReportField NewField144331 { get {return Body().NewField144331;} }
            public TTReportField NewField13343 { get {return Body().NewField13343;} }
            public TTReportField NewField144332 { get {return Body().NewField144332;} }
            public TTReportField NewField134331 { get {return Body().NewField134331;} }
            public TTReportField NewField1233441 { get {return Body().NewField1233441;} }
            public TTReportField DIPSIC { get {return Body().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Body().ADSOYADDOC;} }
            public TTReportField UZMANLIKDAL { get {return Body().UZMANLIKDAL;} }
            public TTReportField DIPSICLABEL { get {return Body().DIPSICLABEL;} }
            public TTReportField SINRUT { get {return Body().SINRUT;} }
            public TTReportField RUTBEONAY { get {return Body().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Body().SINIFONAY;} }
            public TTReportField UZ { get {return Body().UZ;} }
            public TTReportField GOREV { get {return Body().GOREV;} }
            public TTReportField DIPLOMANO { get {return Body().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Body().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Body().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Body().UNVAN;} }
            public TTReportField SICILNO { get {return Body().SICILNO;} }
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
                list[0] = new TTReportNqlData<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class>("DentalProthesisPrintOutSQL", DentalProsthesisProcedure.DentalProthesisPrintOutSQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DentalProthesisPrintOutReport MyParentReport
                {
                    get { return (DentalProthesisPrintOutReport)ParentReport; }
                }
                
                public TTReportField BIRLIK;
                public TTReportField NAME12;
                public TTReportField ACTIONID;
                public TTReportField HASTANO;
                public TTReportField PID1;
                public TTReportField NewField2412;
                public TTReportField NewField25;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine9;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportField NewField82;
                public TTReportField NewField83;
                public TTReportField NewField841;
                public TTReportField NewField882;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportField NewField78;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportField NewField249;
                public TTReportField NewField248;
                public TTReportField NewField247;
                public TTReportField NewField246;
                public TTReportField NewField29;
                public TTReportField NewField245;
                public TTReportShape NewLine21;
                public TTReportField NewField244;
                public TTReportField NewField243;
                public TTReportField TESHIS;
                public TTReportField NewField84;
                public TTReportField NewField2422;
                public TTReportShape NewLine22;
                public TTReportField NewField88;
                public TTReportField NewField80;
                public TTReportField RUTBE;
                public TTReportField EMEKLISICILNO;
                public TTReportField NAME;
                public TTReportField GIDECEGIYER;
                public TTReportShape NewLine23;
                public TTReportField TEDAVİ;
                public TTReportField DOKTOR;
                public TTReportField DOKTORRUTBE;
                public TTReportField PROTOKOLNO;
                public TTReportField TARIH;
                public TTReportField PID;
                public TTReportField DOKTORSICILNO;
                public TTReportField DDOKTOR;
                public TTReportField DDOKTORRUTBE;
                public TTReportField DDOKTORSICILNO;
                public TTReportField HEADER;
                public TTReportField KARAR;
                public TTReportField FISNO;
                public TTReportField AILENAME;
                public TTReportField NewField2433;
                public TTReportField DOKTORUZMANLIK;
                public TTReportField DUZMANLIK;
                public TTReportShape NewLine241;
                public TTReportShape NewLine25;
                public TTReportField DİŞ_POZİSYON;
                public TTReportField DİŞ_NO;
                public TTReportField TEDAVİ1;
                public TTReportField TEDAVİ11;
                public TTReportField TEDAVİ12;
                public TTReportField NewField13342;
                public TTReportField NewField13344;
                public TTReportField NewField144331;
                public TTReportField NewField13343;
                public TTReportField NewField144332;
                public TTReportField NewField134331;
                public TTReportField NewField1233441;
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField UZMANLIKDAL;
                public TTReportField DIPSICLABEL;
                public TTReportField SINRUT;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField UZ;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 285;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 49, 84, 74, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.NoClip = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.TextFont.Bold = true;
                    BIRLIK.Value = @"";

                    NAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 110, 84, 114, false);
                    NAME12.Name = "NAME12";
                    NAME12.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAME12.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME12.NoClip = EvetHayirEnum.ehEvet;
                    NAME12.ObjectDefName = "DentalProsthesisProcedure";
                    NAME12.DataMember = "EPISODE.PATIENT.FULLNAME";
                    NAME12.TextFont.Size = 8;
                    NAME12.TextFont.Bold = true;
                    NAME12.Value = @"{@TTOBJECTID@}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 19, 195, 23, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONID.TextFont.Size = 8;
                    ACTIONID.TextFont.Bold = true;
                    ACTIONID.Value = @"";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 4, 194, 8, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.Visible = EvetHayirEnum.ehHayir;
                    HASTANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTANO.MultiLine = EvetHayirEnum.ehEvet;
                    HASTANO.NoClip = EvetHayirEnum.ehEvet;
                    HASTANO.WordBreak = EvetHayirEnum.ehEvet;
                    HASTANO.TextFont.Size = 8;
                    HASTANO.TextFont.Bold = true;
                    HASTANO.Value = @"Hasta No   Pr.No";

                    PID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 8, 195, 13, false);
                    PID1.Name = "PID1";
                    PID1.Visible = EvetHayirEnum.ehHayir;
                    PID1.FillStyle = FillStyleConstants.vbFSTransparent;
                    PID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID1.TextFont.Size = 8;
                    PID1.TextFont.Bold = true;
                    PID1.Value = @"";

                    NewField2412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 49, 39, 54, false);
                    NewField2412.Name = "NewField2412";
                    NewField2412.TextFont.Size = 8;
                    NewField2412.TextFont.Bold = true;
                    NewField2412.Value = @"BİRLİĞİ";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 78, 38, 88, false);
                    NewField25.Name = "NewField25";
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.NoClip = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Size = 8;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"AİLE REİSİNİN
ADI SOYADI";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 35, 194, 35, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 3;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 76, 86, 76, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 3;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 98, 86, 98, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine3.DrawWidth = 3;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 44, 86, 44, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine4.DrawWidth = 3;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 39, 35, 39, 216, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine5.DrawWidth = 3;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 36, 194, 118, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine6.DrawWidth = 3;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 10, -1, 93, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 118, 193, 118, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine8.DrawWidth = 3;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 86, 35, 86, 118, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine9.DrawWidth = 3;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 92, -1, 282, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 115, 194, 256, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 3;

                    NewField82 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 119, 38, 127, false);
                    NewField82.Name = "NewField82";
                    NewField82.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField82.MultiLine = EvetHayirEnum.ehEvet;
                    NewField82.TextFont.Size = 8;
                    NewField82.TextFont.Bold = true;
                    NewField82.Value = @"SEVK EDİLEN 
LABORATUAR";

                    NewField83 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 146, 38, 161, false);
                    NewField83.Name = "NewField83";
                    NewField83.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField83.TextFont.Size = 8;
                    NewField83.TextFont.Bold = true;
                    NewField83.Value = @"TEŞHİS";

                    NewField841 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 164, 38, 179, false);
                    NewField841.Name = "NewField841";
                    NewField841.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField841.TextFont.Size = 8;
                    NewField841.TextFont.Bold = true;
                    NewField841.Value = @"YAPILAN İŞ/TEDAVİ";

                    NewField882 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 217, 61, 229, false);
                    NewField882.Name = "NewField882";
                    NewField882.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField882.MultiLine = EvetHayirEnum.ehEvet;
                    NewField882.NoClip = EvetHayirEnum.ehEvet;
                    NewField882.WordBreak = EvetHayirEnum.ehEvet;
                    NewField882.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField882.TextFont.Size = 8;
                    NewField882.TextFont.Bold = true;
                    NewField882.Value = @"DÖKÜM KONTROLÜ YAPILDIĞINA DAİR 
DİŞ TABİBİ KONTROLÜ";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 128, 194, 128, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 3;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 163, 194, 163, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 3;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 216, 194, 216, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 3;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 187, 194, 187, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.DrawWidth = 3;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 239, 194, 239, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.DrawWidth = 3;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 35, 1, 110, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.DrawWidth = 3;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 108, 1, 256, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.DrawWidth = 3;

                    NewField78 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 129, 38, 144, false);
                    NewField78.Name = "NewField78";
                    NewField78.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField78.MultiLine = EvetHayirEnum.ehEvet;
                    NewField78.NoClip = EvetHayirEnum.ehEvet;
                    NewField78.WordBreak = EvetHayirEnum.ehEvet;
                    NewField78.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField78.TextFont.Size = 8;
                    NewField78.TextFont.Bold = true;
                    NewField78.Value = @"SEVK EDEN DİŞ TBP.
ADI SOYADI 
RÜTBESİ
SİCİL NO";

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 35, 144, 118, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19.DrawWidth = 3;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 86, 76, 194, 76, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.DrawWidth = 3;

                    NewField249 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 36, 124, 41, false);
                    NewField249.Name = "NewField249";
                    NewField249.TextFont.Size = 8;
                    NewField249.TextFont.Bold = true;
                    NewField249.Value = @"SAĞ ÜST";

                    NewField248 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 112, 124, 117, false);
                    NewField248.Name = "NewField248";
                    NewField248.TextFont.Size = 8;
                    NewField248.TextFont.Bold = true;
                    NewField248.Value = @"SAĞ ALT";

                    NewField247 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 112, 193, 117, false);
                    NewField247.Name = "NewField247";
                    NewField247.TextFont.Size = 8;
                    NewField247.TextFont.Bold = true;
                    NewField247.Value = @"SOL ALT";

                    NewField246 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 36, 193, 41, false);
                    NewField246.Name = "NewField246";
                    NewField246.TextFont.Size = 8;
                    NewField246.TextFont.Bold = true;
                    NewField246.Value = @"SOL ÜST";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 102, 38, 114, false);
                    NewField29.Name = "NewField29";
                    NewField29.MultiLine = EvetHayirEnum.ehEvet;
                    NewField29.NoClip = EvetHayirEnum.ehEvet;
                    NewField29.WordBreak = EvetHayirEnum.ehEvet;
                    NewField29.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField29.TextFont.Size = 8;
                    NewField29.TextFont.Bold = true;
                    NewField29.Value = @"FİŞ SAHİBİNİN
T.C. NOSU
ADI VE SOYADI";

                    NewField245 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 36, 38, 41, false);
                    NewField245.Name = "NewField245";
                    NewField245.TextFont.Size = 8;
                    NewField245.TextFont.Bold = true;
                    NewField245.Value = @"SAĞLIK FİŞ NO";

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 114, 128, 114, 145, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.DrawWidth = 3;

                    NewField244 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 129, 133, 135, false);
                    NewField244.Name = "NewField244";
                    NewField244.TextFont.Size = 8;
                    NewField244.TextFont.Bold = true;
                    NewField244.Value = @"KAYIT NO";

                    NewField243 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 135, 133, 140, false);
                    NewField243.Name = "NewField243";
                    NewField243.TextFont.Size = 8;
                    NewField243.TextFont.Bold = true;
                    NewField243.Value = @"TARİHİ";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 146, 191, 161, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FillStyle = FillStyleConstants.vbFSTransparent;
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.NoClip = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Size = 8;
                    TESHIS.TextFont.Bold = true;
                    TESHIS.Value = @"";

                    NewField84 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 188, 38, 203, false);
                    NewField84.Name = "NewField84";
                    NewField84.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField84.TextFont.Size = 8;
                    NewField84.TextFont.Bold = true;
                    NewField84.Value = @"KARAR";

                    NewField2422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 188, 188, 193, false);
                    NewField2422.Name = "NewField2422";
                    NewField2422.TextFont.Size = 8;
                    NewField2422.TextFont.Bold = true;
                    NewField2422.Value = @"SEVK EDEN XXXXXX BAŞTABİBİNİN ONAYI";

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 216, 115, 239, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.DrawWidth = 3;

                    NewField88 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 217, 183, 223, false);
                    NewField88.Name = "NewField88";
                    NewField88.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField88.TextFont.Size = 8;
                    NewField88.TextFont.Bold = true;
                    NewField88.Value = @"DÖKÜMÜN FATURA TARİHİ VE NUMARASI";

                    NewField80 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 240, 66, 246, false);
                    NewField80.Name = "NewField80";
                    NewField80.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField80.TextFont.Size = 8;
                    NewField80.TextFont.Bold = true;
                    NewField80.Value = @"BAŞTABİBİN İMZASI TARİH VE MÜHÜR";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 27, 158, 32, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.Visible = EvetHayirEnum.ehHayir;
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.Value = @"";

                    EMEKLISICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 27, 168, 32, false);
                    EMEKLISICILNO.Name = "EMEKLISICILNO";
                    EMEKLISICILNO.Visible = EvetHayirEnum.ehHayir;
                    EMEKLISICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMEKLISICILNO.Value = @"";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 27, 148, 32, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"";

                    GIDECEGIYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 121, 191, 126, false);
                    GIDECEGIYER.Name = "GIDECEGIYER";
                    GIDECEGIYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    GIDECEGIYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDECEGIYER.MultiLine = EvetHayirEnum.ehEvet;
                    GIDECEGIYER.NoClip = EvetHayirEnum.ehEvet;
                    GIDECEGIYER.WordBreak = EvetHayirEnum.ehEvet;
                    GIDECEGIYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    GIDECEGIYER.ObjectDefName = "DentalProsthesisProcedure";
                    GIDECEGIYER.DataMember = "OUTERLABNAME";
                    GIDECEGIYER.TextFont.Size = 8;
                    GIDECEGIYER.TextFont.Bold = true;
                    GIDECEGIYER.Value = @"{@TTOBJECTID@}";

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 145, 194, 145, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.DrawWidth = 3;

                    TEDAVİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 165, 191, 169, false);
                    TEDAVİ.Name = "TEDAVİ";
                    TEDAVİ.FillStyle = FillStyleConstants.vbFSTransparent;
                    TEDAVİ.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVİ.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVİ.NoClip = EvetHayirEnum.ehEvet;
                    TEDAVİ.WordBreak = EvetHayirEnum.ehEvet;
                    TEDAVİ.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEDAVİ.ObjectDefName = "DentalProsthesisProcedure";
                    TEDAVİ.DataMember = "PROCEDUREOBJECT.NAME";
                    TEDAVİ.TextFont.Size = 8;
                    TEDAVİ.TextFont.Bold = true;
                    TEDAVİ.Value = @"{@TTOBJECTID@}";

                    DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 129, 85, 133, false);
                    DOKTOR.Name = "DOKTOR";
                    DOKTOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    DOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTOR.NoClip = EvetHayirEnum.ehEvet;
                    DOKTOR.TextFont.Size = 8;
                    DOKTOR.TextFont.Bold = true;
                    DOKTOR.Value = @"{#PROCEDUREDOCTORNAME#}";

                    DOKTORRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 133, 85, 137, false);
                    DOKTORRUTBE.Name = "DOKTORRUTBE";
                    DOKTORRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DOKTORRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORRUTBE.TextFont.Size = 8;
                    DOKTORRUTBE.TextFont.Bold = true;
                    DOKTORRUTBE.Value = @"{%SINIFONAY%} {%RUTBEONAY%}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 129, 180, 133, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.ObjectDefName = "DentalProsthesisProcedure";
                    PROTOKOLNO.DataMember = "EPISODE.HOSPITALPROTOCOLNO";
                    PROTOKOLNO.TextFont.Size = 8;
                    PROTOKOLNO.TextFont.Bold = true;
                    PROTOKOLNO.Value = @"{@TTOBJECTID@}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 135, 180, 139, false);
                    TARIH.Name = "TARIH";
                    TARIH.FillStyle = FillStyleConstants.vbFSTransparent;
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.ObjectDefName = "DentalExaminationProcedure";
                    TARIH.DataMember = "EPISODE.OPENINGDATE";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.Bold = true;
                    TARIH.Value = @"{@TTOBJECTID@}";

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 105, 84, 109, false);
                    PID.Name = "PID";
                    PID.FillStyle = FillStyleConstants.vbFSTransparent;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.NoClip = EvetHayirEnum.ehEvet;
                    PID.ObjectDefName = "DentalProsthesisProcedure";
                    PID.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    PID.TextFont.Size = 8;
                    PID.TextFont.Bold = true;
                    PID.Value = @"{@TTOBJECTID@}";

                    DOKTORSICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 137, 85, 141, false);
                    DOKTORSICILNO.Name = "DOKTORSICILNO";
                    DOKTORSICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    DOKTORSICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORSICILNO.TextFont.Size = 8;
                    DOKTORSICILNO.TextFont.Bold = true;
                    DOKTORSICILNO.Value = @"{%DIPSIC%}";

                    DDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 217, 107, 221, false);
                    DDOKTOR.Name = "DDOKTOR";
                    DDOKTOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    DDOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DDOKTOR.NoClip = EvetHayirEnum.ehEvet;
                    DDOKTOR.TextFont.Size = 8;
                    DDOKTOR.TextFont.Bold = true;
                    DDOKTOR.Value = @"";

                    DDOKTORRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 221, 107, 225, false);
                    DDOKTORRUTBE.Name = "DDOKTORRUTBE";
                    DDOKTORRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    DDOKTORRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DDOKTORRUTBE.TextFont.Size = 8;
                    DDOKTORRUTBE.TextFont.Bold = true;
                    DDOKTORRUTBE.Value = @"{%SINIFONAY%} {%RUTBEONAY%}";

                    DDOKTORSICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 225, 107, 229, false);
                    DDOKTORSICILNO.Name = "DDOKTORSICILNO";
                    DDOKTORSICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    DDOKTORSICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DDOKTORSICILNO.TextFont.Size = 8;
                    DDOKTORSICILNO.TextFont.Bold = true;
                    DDOKTORSICILNO.Value = @"{%DIPSIC%}";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 4, 169, 26, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"TÜRK SİLAHLI KUVVETLERİ METAL DÖKÜM RAPORU";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 188, 113, 215, false);
                    KARAR.Name = "KARAR";
                    KARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 8;
                    KARAR.TextFont.Bold = true;
                    KARAR.Value = @"";

                    FISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 37, 83, 41, false);
                    FISNO.Name = "FISNO";
                    FISNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    FISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FISNO.NoClip = EvetHayirEnum.ehEvet;
                    FISNO.TextFont.Size = 8;
                    FISNO.TextFont.Bold = true;
                    FISNO.Value = @"";

                    AILENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 79, 83, 88, false);
                    AILENAME.Name = "AILENAME";
                    AILENAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    AILENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    AILENAME.NoClip = EvetHayirEnum.ehEvet;
                    AILENAME.TextFont.Size = 8;
                    AILENAME.TextFont.Bold = true;
                    AILENAME.Value = @"";

                    NewField2433 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 63, 143, 69, false);
                    NewField2433.Name = "NewField2433";
                    NewField2433.TextFont.Size = 8;
                    NewField2433.TextFont.Bold = true;
                    NewField2433.Value = @"18  17  16  15  14  13  12  11";

                    DOKTORUZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 141, 113, 145, false);
                    DOKTORUZMANLIK.Name = "DOKTORUZMANLIK";
                    DOKTORUZMANLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    DOKTORUZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORUZMANLIK.MultiLine = EvetHayirEnum.ehEvet;
                    DOKTORUZMANLIK.NoClip = EvetHayirEnum.ehEvet;
                    DOKTORUZMANLIK.WordBreak = EvetHayirEnum.ehEvet;
                    DOKTORUZMANLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOKTORUZMANLIK.TextFont.Size = 8;
                    DOKTORUZMANLIK.TextFont.Bold = true;
                    DOKTORUZMANLIK.Value = @"{%UZ%}";

                    DUZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 229, 114, 237, false);
                    DUZMANLIK.Name = "DUZMANLIK";
                    DUZMANLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    DUZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUZMANLIK.MultiLine = EvetHayirEnum.ehEvet;
                    DUZMANLIK.NoClip = EvetHayirEnum.ehEvet;
                    DUZMANLIK.WordBreak = EvetHayirEnum.ehEvet;
                    DUZMANLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    DUZMANLIK.TextFont.Size = 8;
                    DUZMANLIK.TextFont.Bold = true;
                    DUZMANLIK.Value = @"{%UZ%}";

                    NewLine241 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 187, 115, 216, false);
                    NewLine241.Name = "NewLine241";
                    NewLine241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine241.DrawWidth = 3;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 256, 194, 256, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine25.DrawWidth = 3;

                    DİŞ_POZİSYON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 171, 191, 175, false);
                    DİŞ_POZİSYON.Name = "DİŞ_POZİSYON";
                    DİŞ_POZİSYON.FillStyle = FillStyleConstants.vbFSTransparent;
                    DİŞ_POZİSYON.FieldType = ReportFieldTypeEnum.ftVariable;
                    DİŞ_POZİSYON.MultiLine = EvetHayirEnum.ehEvet;
                    DİŞ_POZİSYON.NoClip = EvetHayirEnum.ehEvet;
                    DİŞ_POZİSYON.WordBreak = EvetHayirEnum.ehEvet;
                    DİŞ_POZİSYON.ExpandTabs = EvetHayirEnum.ehEvet;
                    DİŞ_POZİSYON.ObjectDefName = "DentalProsthesisProcedure";
                    DİŞ_POZİSYON.DataMember = "DENTALPOSITION";
                    DİŞ_POZİSYON.TextFont.Size = 8;
                    DİŞ_POZİSYON.TextFont.Bold = true;
                    DİŞ_POZİSYON.Value = @"{@TTOBJECTID@}";

                    DİŞ_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 177, 194, 181, false);
                    DİŞ_NO.Name = "DİŞ_NO";
                    DİŞ_NO.FillStyle = FillStyleConstants.vbFSTransparent;
                    DİŞ_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DİŞ_NO.MultiLine = EvetHayirEnum.ehEvet;
                    DİŞ_NO.NoClip = EvetHayirEnum.ehEvet;
                    DİŞ_NO.WordBreak = EvetHayirEnum.ehEvet;
                    DİŞ_NO.ExpandTabs = EvetHayirEnum.ehEvet;
                    DİŞ_NO.ObjectDefName = "DentalProsthesisProcedure";
                    DİŞ_NO.DataMember = "TOOTHNUMBER";
                    DİŞ_NO.TextFont.Size = 8;
                    DİŞ_NO.TextFont.Bold = true;
                    DİŞ_NO.Value = @"{@TTOBJECTID@}";

                    TEDAVİ1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 165, 64, 170, false);
                    TEDAVİ1.Name = "TEDAVİ1";
                    TEDAVİ1.FillStyle = FillStyleConstants.vbFSTransparent;
                    TEDAVİ1.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVİ1.NoClip = EvetHayirEnum.ehEvet;
                    TEDAVİ1.WordBreak = EvetHayirEnum.ehEvet;
                    TEDAVİ1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEDAVİ1.TextFont.Size = 8;
                    TEDAVİ1.TextFont.Bold = true;
                    TEDAVİ1.Value = @"Diş Tedavi:";

                    TEDAVİ11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 171, 67, 176, false);
                    TEDAVİ11.Name = "TEDAVİ11";
                    TEDAVİ11.FillStyle = FillStyleConstants.vbFSTransparent;
                    TEDAVİ11.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVİ11.NoClip = EvetHayirEnum.ehEvet;
                    TEDAVİ11.WordBreak = EvetHayirEnum.ehEvet;
                    TEDAVİ11.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEDAVİ11.TextFont.Size = 8;
                    TEDAVİ11.TextFont.Bold = true;
                    TEDAVİ11.Value = @"Diş Pozisyon:";

                    TEDAVİ12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 177, 66, 182, false);
                    TEDAVİ12.Name = "TEDAVİ12";
                    TEDAVİ12.FillStyle = FillStyleConstants.vbFSTransparent;
                    TEDAVİ12.MultiLine = EvetHayirEnum.ehEvet;
                    TEDAVİ12.NoClip = EvetHayirEnum.ehEvet;
                    TEDAVİ12.WordBreak = EvetHayirEnum.ehEvet;
                    TEDAVİ12.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEDAVİ12.TextFont.Size = 8;
                    TEDAVİ12.TextFont.Bold = true;
                    TEDAVİ12.Value = @"Diş Tedavi:";

                    NewField13342 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 83, 143, 89, false);
                    NewField13342.Name = "NewField13342";
                    NewField13342.TextFont.Size = 8;
                    NewField13342.TextFont.Bold = true;
                    NewField13342.Value = @"48  47  46  45  44  43  42  41";

                    NewField13344 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 69, 143, 75, false);
                    NewField13344.Name = "NewField13344";
                    NewField13344.TextFont.Size = 8;
                    NewField13344.TextFont.Bold = true;
                    NewField13344.Value = @"55  54  53  52  51";

                    NewField144331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 77, 143, 83, false);
                    NewField144331.Name = "NewField144331";
                    NewField144331.TextFont.Size = 8;
                    NewField144331.TextFont.Bold = true;
                    NewField144331.Value = @"85  84  83  82  81";

                    NewField13343 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 63, 192, 69, false);
                    NewField13343.Name = "NewField13343";
                    NewField13343.TextFont.Size = 8;
                    NewField13343.TextFont.Bold = true;
                    NewField13343.Value = @"21 22 23 24 25 26 27 28";

                    NewField144332 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 69, 179, 75, false);
                    NewField144332.Name = "NewField144332";
                    NewField144332.TextFont.Size = 8;
                    NewField144332.TextFont.Bold = true;
                    NewField144332.Value = @"61 62 63 64 65";

                    NewField134331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 83, 192, 89, false);
                    NewField134331.Name = "NewField134331";
                    NewField134331.TextFont.Size = 8;
                    NewField134331.TextFont.Bold = true;
                    NewField134331.Value = @"31 32 33 34 35 36 37 38";

                    NewField1233441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 77, 179, 83, false);
                    NewField1233441.Name = "NewField1233441";
                    NewField1233441.TextFont.Size = 8;
                    NewField1233441.TextFont.Bold = true;
                    NewField1233441.Value = @"71 72 73 74 75";

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 269, 183, 273, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.Visible = EvetHayirEnum.ehHayir;
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 261, 183, 265, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.Visible = EvetHayirEnum.ehHayir;
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 260, 71, 264, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 269, 133, 273, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.Visible = EvetHayirEnum.ehHayir;
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 265, 183, 269, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.Visible = EvetHayirEnum.ehHayir;
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 266, 43, 270, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 264, 71, 269, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#DOCMILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 273, 183, 277, false);
                    UZ.Name = "UZ";
                    UZ.Visible = EvetHayirEnum.ehHayir;
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 261, 44, 266, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 270, 100, 274, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 262, 100, 266, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 271, 44, 275, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 269, 71, 274, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 267, 100, 271, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class dataset_DentalProthesisPrintOutSQL = ParentGroup.rsGroup.GetCurrentRecord<DentalProsthesisProcedure.DentalProthesisPrintOutSQL_Class>(0);
                    BIRLIK.CalcValue = @"";
                    NAME12.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME12.PostFieldValueCalculation();
                    ACTIONID.CalcValue = @"";
                    HASTANO.CalcValue = @"Hasta No   Pr.No";
                    PID1.CalcValue = @"";
                    NewField2412.CalcValue = NewField2412.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField82.CalcValue = NewField82.Value;
                    NewField83.CalcValue = NewField83.Value;
                    NewField841.CalcValue = NewField841.Value;
                    NewField882.CalcValue = NewField882.Value;
                    NewField78.CalcValue = NewField78.Value;
                    NewField249.CalcValue = NewField249.Value;
                    NewField248.CalcValue = NewField248.Value;
                    NewField247.CalcValue = NewField247.Value;
                    NewField246.CalcValue = NewField246.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField245.CalcValue = NewField245.Value;
                    NewField244.CalcValue = NewField244.Value;
                    NewField243.CalcValue = NewField243.Value;
                    TESHIS.CalcValue = @"";
                    NewField84.CalcValue = NewField84.Value;
                    NewField2422.CalcValue = NewField2422.Value;
                    NewField88.CalcValue = NewField88.Value;
                    NewField80.CalcValue = NewField80.Value;
                    RUTBE.CalcValue = @"";
                    EMEKLISICILNO.CalcValue = @"";
                    NAME.CalcValue = @"";
                    GIDECEGIYER.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    GIDECEGIYER.PostFieldValueCalculation();
                    TEDAVİ.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TEDAVİ.PostFieldValueCalculation();
                    DOKTOR.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Proceduredoctorname) : "");
                    SINIFONAY.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Docmilitaryclass) : "");
                    RUTBEONAY.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Dokrank) : "");
                    DOKTORRUTBE.CalcValue = MyParentReport.MAIN.SINIFONAY.CalcValue + @" " + MyParentReport.MAIN.RUTBEONAY.CalcValue;
                    PROTOKOLNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROTOKOLNO.PostFieldValueCalculation();
                    TARIH.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TARIH.PostFieldValueCalculation();
                    PID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PID.PostFieldValueCalculation();
                    DIPSIC.CalcValue = @"";
                    DOKTORSICILNO.CalcValue = MyParentReport.MAIN.DIPSIC.CalcValue;
                    DDOKTOR.CalcValue = @"";
                    DDOKTORRUTBE.CalcValue = MyParentReport.MAIN.SINIFONAY.CalcValue + @" " + MyParentReport.MAIN.RUTBEONAY.CalcValue;
                    DDOKTORSICILNO.CalcValue = MyParentReport.MAIN.DIPSIC.CalcValue;
                    HEADER.CalcValue = @"TÜRK SİLAHLI KUVVETLERİ METAL DÖKÜM RAPORU";
                    KARAR.CalcValue = @"";
                    FISNO.CalcValue = @"";
                    AILENAME.CalcValue = @"";
                    NewField2433.CalcValue = NewField2433.Value;
                    UZ.CalcValue = MyParentReport.MAIN.UZMANLIKDAL.CalcValue;
                    DOKTORUZMANLIK.CalcValue = MyParentReport.MAIN.UZ.CalcValue;
                    DUZMANLIK.CalcValue = MyParentReport.MAIN.UZ.CalcValue;
                    DİŞ_POZİSYON.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DİŞ_POZİSYON.PostFieldValueCalculation();
                    DİŞ_NO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DİŞ_NO.PostFieldValueCalculation();
                    TEDAVİ1.CalcValue = TEDAVİ1.Value;
                    TEDAVİ11.CalcValue = TEDAVİ11.Value;
                    TEDAVİ12.CalcValue = TEDAVİ12.Value;
                    NewField13342.CalcValue = NewField13342.Value;
                    NewField13344.CalcValue = NewField13344.Value;
                    NewField144331.CalcValue = NewField144331.Value;
                    NewField13343.CalcValue = NewField13343.Value;
                    NewField144332.CalcValue = NewField144332.Value;
                    NewField134331.CalcValue = NewField134331.Value;
                    NewField1233441.CalcValue = NewField1233441.Value;
                    ADSOYADDOC.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    GOREV.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_DentalProthesisPrintOutSQL != null ? Globals.ToStringCore(dataset_DentalProthesisPrintOutSQL.Docemploymentrecordid) : "");
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { BIRLIK,NAME12,ACTIONID,HASTANO,PID1,NewField2412,NewField25,NewField82,NewField83,NewField841,NewField882,NewField78,NewField249,NewField248,NewField247,NewField246,NewField29,NewField245,NewField244,NewField243,TESHIS,NewField84,NewField2422,NewField88,NewField80,RUTBE,EMEKLISICILNO,NAME,GIDECEGIYER,TEDAVİ,DOKTOR,SINIFONAY,RUTBEONAY,DOKTORRUTBE,PROTOKOLNO,TARIH,PID,DIPSIC,DOKTORSICILNO,DDOKTOR,DDOKTORRUTBE,DDOKTORSICILNO,HEADER,KARAR,FISNO,AILENAME,NewField2433,UZ,DOKTORUZMANLIK,DUZMANLIK,DİŞ_POZİSYON,DİŞ_NO,TEDAVİ1,TEDAVİ11,TEDAVİ12,NewField13342,NewField13344,NewField144331,NewField13343,NewField144332,NewField134331,NewField1233441,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,GOREV,DIPLOMANO,UNVAN,SICILNO,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.SICILKULLAN.CalcValue=="TRUE")
            {
                this.DIPSICLABEL.CalcValue= "SİCİL NO :";
                this.DIPSIC.CalcValue=this.SICILNO.CalcValue;
            }
            else
            {
                this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
                this.DIPSIC.CalcValue=this.DIPLOMANO.CalcValue;
            }
            

            if(this.UNVANKULLAN.CalcValue!="TRUE")
            {
                this.SINRUT.CalcValue=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
            }
            else
            {
                if(this.UNVAN.CalcValue=="")
                {
                    this.SINRUT.Value=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
                else
                {
                    this.SINRUT.CalcValue=this.UNVAN.CalcValue + " " + this.RUTBEONAY.CalcValue;
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

        public DentalProthesisPrintOutReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protez İşlemi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DENTALPROTHESISPRINTOUTREPORT";
            Caption = "Falan";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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