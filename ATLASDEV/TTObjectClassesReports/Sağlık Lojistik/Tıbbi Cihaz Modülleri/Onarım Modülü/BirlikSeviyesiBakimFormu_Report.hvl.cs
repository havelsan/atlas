
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
    /// Birlik Seviyesi Bakım Formu (Ek-4.12)
    /// </summary>
    public partial class BirlikSeviyesiBakimFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Part1Group : TTReportGroup
        {
            public BirlikSeviyesiBakimFormu MyParentReport
            {
                get { return (BirlikSeviyesiBakimFormu)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField CIHAZADI { get {return Header().CIHAZADI;} }
            public TTReportField MARKAMODELI { get {return Header().MARKAMODELI;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField SERINO { get {return Header().SERINO;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField STOKNO { get {return Header().STOKNO;} }
            public TTReportField BAKIMPERIYODU { get {return Header().BAKIMPERIYODU;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField BIRLIKKURUMSERVIS { get {return Header().BIRLIKKURUMSERVIS;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField61 { get {return Header().NewField61;} }
            public TTReportField NewField71 { get {return Header().NewField71;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField RUTBE { get {return Header().RUTBE;} }
            public TTReportField NewField62 { get {return Header().NewField62;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField NewField72 { get {return Header().NewField72;} }
            public TTReportField NewField73 { get {return Header().NewField73;} }
            public TTReportField NewField74 { get {return Header().NewField74;} }
            public TTReportField NewField75 { get {return Header().NewField75;} }
            public TTReportField NewField57 { get {return Header().NewField57;} }
            public TTReportField NewField58 { get {return Header().NewField58;} }
            public TTReportField NewField76 { get {return Header().NewField76;} }
            public TTReportField NewField59 { get {return Header().NewField59;} }
            public TTReportField NewField77 { get {return Header().NewField77;} }
            public TTReportField NewField60 { get {return Header().NewField60;} }
            public TTReportField NewField78 { get {return Header().NewField78;} }
            public TTReportField NewField_ { get {return Footer().NewField_;} }
            public TTReportField NewField51_ { get {return Footer().NewField51_;} }
            public TTReportField NewField61_ { get {return Footer().NewField61_;} }
            public TTReportField NewField71_ { get {return Footer().NewField71_;} }
            public TTReportField ILAVEBILGILER { get {return Footer().ILAVEBILGILER;} }
            public TTReportField NewField72_ { get {return Footer().NewField72_;} }
            public TTReportField NewField27_ { get {return Footer().NewField27_;} }
            public TTReportField NewField37_ { get {return Footer().NewField37_;} }
            public TTReportField NewField47_ { get {return Footer().NewField47_;} }
            public TTReportField NewField62_ { get {return Footer().NewField62_;} }
            public TTReportField NewField26_ { get {return Footer().NewField26_;} }
            public TTReportField NewField28_ { get {return Footer().NewField28_;} }
            public TTReportField NewField73_ { get {return Footer().NewField73_;} }
            public TTReportField NewField74_ { get {return Footer().NewField74_;} }
            public TTReportField NewField75_ { get {return Footer().NewField75_;} }
            public TTReportField NewField4_ { get {return Footer().NewField4_;} }
            public TTReportField NewField5_ { get {return Footer().NewField5_;} }
            public TTReportField NewField6_ { get {return Footer().NewField6_;} }
            public TTReportField NewField7_ { get {return Footer().NewField7_;} }
            public TTReportField NewField8_ { get {return Footer().NewField8_;} }
            public TTReportField NewField9_ { get {return Footer().NewField9_;} }
            public TTReportField NewField29_ { get {return Footer().NewField29_;} }
            public TTReportField NewField92_ { get {return Footer().NewField92_;} }
            public TTReportField NewField93_ { get {return Footer().NewField93_;} }
            public TTReportField NewField2_ { get {return Footer().NewField2_;} }
            public TTReportField NewField10_ { get {return Footer().NewField10_;} }
            public TTReportField NewField11_ { get {return Footer().NewField11_;} }
            public TTReportField NewField12_ { get {return Footer().NewField12_;} }
            public TTReportField NewField13_ { get {return Footer().NewField13_;} }
            public TTReportField NewField14_ { get {return Footer().NewField14_;} }
            public TTReportField NewField15_ { get {return Footer().NewField15_;} }
            public TTReportField NewField94_ { get {return Footer().NewField94_;} }
            public TTReportField NewField30_ { get {return Footer().NewField30_;} }
            public TTReportField NewField39_ { get {return Footer().NewField39_;} }
            public TTReportField NewField3_ { get {return Footer().NewField3_;} }
            public TTReportField NewField16_ { get {return Footer().NewField16_;} }
            public TTReportField NewField17_ { get {return Footer().NewField17_;} }
            public TTReportField NewField18_ { get {return Footer().NewField18_;} }
            public TTReportField NewField19_ { get {return Footer().NewField19_;} }
            public TTReportField NewField20_ { get {return Footer().NewField20_;} }
            public TTReportField NewField21_ { get {return Footer().NewField21_;} }
            public TTReportField NewField95_ { get {return Footer().NewField95_;} }
            public TTReportField NewField31_ { get {return Footer().NewField31_;} }
            public TTReportField NewField40_ { get {return Footer().NewField40_;} }
            public TTReportField NewField22_ { get {return Footer().NewField22_;} }
            public TTReportField NewField23_ { get {return Footer().NewField23_;} }
            public TTReportField NewField24_ { get {return Footer().NewField24_;} }
            public TTReportField NewField25_ { get {return Footer().NewField25_;} }
            public TTReportField NewField32_ { get {return Footer().NewField32_;} }
            public TTReportField NewField33_ { get {return Footer().NewField33_;} }
            public TTReportField NewField34_ { get {return Footer().NewField34_;} }
            public TTReportField NewField96_ { get {return Footer().NewField96_;} }
            public TTReportField NewField35_ { get {return Footer().NewField35_;} }
            public TTReportField NewField41_ { get {return Footer().NewField41_;} }
            public TTReportField NewField36_ { get {return Footer().NewField36_;} }
            public TTReportField NewField38_ { get {return Footer().NewField38_;} }
            public TTReportField NewField42_ { get {return Footer().NewField42_;} }
            public TTReportField NewField43_ { get {return Footer().NewField43_;} }
            public TTReportField NewField44_ { get {return Footer().NewField44_;} }
            public TTReportField NewField45_ { get {return Footer().NewField45_;} }
            public TTReportField NewField46_ { get {return Footer().NewField46_;} }
            public TTReportField NewField97_ { get {return Footer().NewField97_;} }
            public TTReportField NewField48_ { get {return Footer().NewField48_;} }
            public TTReportField NewField49_ { get {return Footer().NewField49_;} }
            public TTReportField NewField50_ { get {return Footer().NewField50_;} }
            public TTReportField NewField52_ { get {return Footer().NewField52_;} }
            public TTReportField NewField53_ { get {return Footer().NewField53_;} }
            public TTReportField NewField54_ { get {return Footer().NewField54_;} }
            public TTReportField NewField55_ { get {return Footer().NewField55_;} }
            public TTReportField NewField56_ { get {return Footer().NewField56_;} }
            public TTReportField NewField57_ { get {return Footer().NewField57_;} }
            public TTReportField NewField98_ { get {return Footer().NewField98_;} }
            public TTReportField NewField58_ { get {return Footer().NewField58_;} }
            public TTReportField NewField59_ { get {return Footer().NewField59_;} }
            public TTReportField NewField60_ { get {return Footer().NewField60_;} }
            public TTReportField NewField63_ { get {return Footer().NewField63_;} }
            public TTReportField NewField64_ { get {return Footer().NewField64_;} }
            public TTReportField NewField65_ { get {return Footer().NewField65_;} }
            public TTReportField NewField66_ { get {return Footer().NewField66_;} }
            public TTReportField NewField67_ { get {return Footer().NewField67_;} }
            public TTReportField NewField68_ { get {return Footer().NewField68_;} }
            public TTReportField NewField99_ { get {return Footer().NewField99_;} }
            public TTReportField NewField69_ { get {return Footer().NewField69_;} }
            public TTReportField NewField70_ { get {return Footer().NewField70_;} }
            public TTReportField NewField76_ { get {return Footer().NewField76_;} }
            public TTReportField NewField77_ { get {return Footer().NewField77_;} }
            public TTReportField NewField78_ { get {return Footer().NewField78_;} }
            public TTReportField NewField79_ { get {return Footer().NewField79_;} }
            public TTReportField NewField80_ { get {return Footer().NewField80_;} }
            public TTReportField NewField81_ { get {return Footer().NewField81_;} }
            public TTReportField NewField82_ { get {return Footer().NewField82_;} }
            public TTReportField NewField100_ { get {return Footer().NewField100_;} }
            public TTReportField NewField83_ { get {return Footer().NewField83_;} }
            public TTReportField NewField84_ { get {return Footer().NewField84_;} }
            public TTReportField NewField85_ { get {return Footer().NewField85_;} }
            public TTReportField NewField86_ { get {return Footer().NewField86_;} }
            public TTReportField NewField87_ { get {return Footer().NewField87_;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Repair.RepairReportNQL_Class>("RepairReportNQL", Repair.RepairReportNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public BirlikSeviyesiBakimFormu MyParentReport
                {
                    get { return (BirlikSeviyesiBakimFormu)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField CIHAZADI;
                public TTReportField MARKAMODELI;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField SERINO;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField STOKNO;
                public TTReportField BAKIMPERIYODU;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField BIRLIKKURUMSERVIS;
                public TTReportField NewField51;
                public TTReportField NewField61;
                public TTReportField NewField71;
                public TTReportField ADSOYAD;
                public TTReportField RUTBE;
                public TTReportField NewField62;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField72;
                public TTReportField NewField73;
                public TTReportField NewField74;
                public TTReportField NewField75;
                public TTReportField NewField57;
                public TTReportField NewField58;
                public TTReportField NewField76;
                public TTReportField NewField59;
                public TTReportField NewField77;
                public TTReportField NewField60;
                public TTReportField NewField78; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 68;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 34, 146, 48, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 17, 279, 23, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Ek-4.12";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 23, 279, 34, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"BİRLİK SEVİYESİ BAKIM FORMU";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 35, 53, 41, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Cihazın Adı";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 41, 53, 47, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Marka ve Modeli";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 35, 54, 41, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 41, 54, 47, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @":";

                    CIHAZADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 35, 145, 41, false);
                    CIHAZADI.Name = "CIHAZADI";
                    CIHAZADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIHAZADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CIHAZADI.TextFont.Name = "Arial";
                    CIHAZADI.TextFont.Size = 9;
                    CIHAZADI.TextFont.Bold = true;
                    CIHAZADI.TextFont.CharSet = 162;
                    CIHAZADI.Value = @"{#FAMNAME#}";

                    MARKAMODELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 41, 145, 47, false);
                    MARKAMODELI.Name = "MARKAMODELI";
                    MARKAMODELI.FieldType = ReportFieldTypeEnum.ftExpression;
                    MARKAMODELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODELI.TextFont.Name = "Arial";
                    MARKAMODELI.TextFont.Size = 9;
                    MARKAMODELI.TextFont.Bold = true;
                    MARKAMODELI.TextFont.CharSet = 162;
                    MARKAMODELI.Value = @"{#MARK#} + "" - "" + {#MODEL#}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 34, 174, 48, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField8.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 35, 173, 41, false);
                    NewField9.Name = "NewField9";
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Seri No   :";

                    SERINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 41, 173, 47, false);
                    SERINO.Name = "SERINO";
                    SERINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERINO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERINO.TextFont.Name = "Arial";
                    SERINO.TextFont.Size = 9;
                    SERINO.TextFont.Bold = true;
                    SERINO.TextFont.CharSet = 162;
                    SERINO.Value = @"";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 34, 279, 48, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField10.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 35, 203, 41, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Stok No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 41, 203, 47, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Bakım Periyodu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 35, 204, 41, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 41, 204, 47, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    STOKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 35, 278, 41, false);
                    STOKNO.Name = "STOKNO";
                    STOKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNO.TextFont.Name = "Arial";
                    STOKNO.TextFont.Size = 9;
                    STOKNO.TextFont.Bold = true;
                    STOKNO.TextFont.CharSet = 162;
                    STOKNO.Value = @"{#NATOSTOCKNO#}";

                    BAKIMPERIYODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 41, 278, 47, false);
                    BAKIMPERIYODU.Name = "BAKIMPERIYODU";
                    BAKIMPERIYODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BAKIMPERIYODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BAKIMPERIYODU.TextFont.Name = "Arial";
                    BAKIMPERIYODU.TextFont.Size = 9;
                    BAKIMPERIYODU.TextFont.Bold = true;
                    BAKIMPERIYODU.TextFont.CharSet = 162;
                    BAKIMPERIYODU.Value = @"{#MAINTENANCEPERIOD#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 48, 146, 56, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField15.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 49, 53, 55, false);
                    NewField16.Name = "NewField16";
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Birliği / Kurumu / Servisi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 49, 54, 55, false);
                    NewField17.Name = "NewField17";
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    BIRLIKKURUMSERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 49, 145, 55, false);
                    BIRLIKKURUMSERVIS.Name = "BIRLIKKURUMSERVIS";
                    BIRLIKKURUMSERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIKKURUMSERVIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIKKURUMSERVIS.TextFont.Name = "Arial";
                    BIRLIKKURUMSERVIS.TextFont.Size = 9;
                    BIRLIKKURUMSERVIS.TextFont.Bold = true;
                    BIRLIKKURUMSERVIS.TextFont.CharSet = 162;
                    BIRLIKKURUMSERVIS.Value = @"{#OWNERMILITARYUNIT#}";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 48, 279, 56, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.Value = @"";

                    NewField61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 49, 190, 55, false);
                    NewField61.Name = "NewField61";
                    NewField61.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField61.TextFont.Name = "Arial";
                    NewField61.TextFont.Size = 9;
                    NewField61.TextFont.Bold = true;
                    NewField61.TextFont.CharSet = 162;
                    NewField61.Value = @"Kullanıcı Adı Soyadı/Rütbesi";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 49, 191, 55, false);
                    NewField71.Name = "NewField71";
                    NewField71.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField71.TextFont.Name = "Arial";
                    NewField71.TextFont.Size = 9;
                    NewField71.TextFont.Bold = true;
                    NewField71.TextFont.CharSet = 162;
                    NewField71.Value = @":";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 49, 278, 55, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADSOYAD.TextFont.Name = "Arial";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.Bold = true;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#DEVICEUSER#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 49, 210, 55, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RUTBE.TextFont.Name = "Arial";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.TextFont.Bold = true;
                    RUTBE.TextFont.CharSet = 162;
                    RUTBE.Value = @"";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 56, 26, 68, false);
                    NewField62.Name = "NewField62";
                    NewField62.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField62.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField62.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField62.TextFont.Name = "Arial";
                    NewField62.TextFont.Size = 9;
                    NewField62.TextFont.Bold = true;
                    NewField62.TextFont.CharSet = 162;
                    NewField62.Value = @"S.No";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 56, 146, 68, false);
                    NewField26.Name = "NewField26";
                    NewField26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField26.TextFont.Name = "Arial";
                    NewField26.TextFont.Size = 9;
                    NewField26.TextFont.Bold = true;
                    NewField26.TextFont.CharSet = 162;
                    NewField26.Value = @"Kontrol Edilecek Yerler";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 56, 179, 62, false);
                    NewField27.Name = "NewField27";
                    NewField27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField27.TextFont.Name = "Arial";
                    NewField27.TextFont.Size = 9;
                    NewField27.TextFont.Bold = true;
                    NewField27.TextFont.CharSet = 162;
                    NewField27.Value = @"1 inci Bakım";

                    NewField72 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 56, 212, 62, false);
                    NewField72.Name = "NewField72";
                    NewField72.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField72.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField72.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField72.TextFont.Name = "Arial";
                    NewField72.TextFont.Size = 9;
                    NewField72.TextFont.Bold = true;
                    NewField72.TextFont.CharSet = 162;
                    NewField72.Value = @"............... Bakım";

                    NewField73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 56, 245, 62, false);
                    NewField73.Name = "NewField73";
                    NewField73.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField73.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField73.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField73.TextFont.Name = "Arial";
                    NewField73.TextFont.Size = 9;
                    NewField73.TextFont.Bold = true;
                    NewField73.TextFont.CharSet = 162;
                    NewField73.Value = @"............... Bakım";

                    NewField74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 56, 279, 62, false);
                    NewField74.Name = "NewField74";
                    NewField74.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField74.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField74.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField74.TextFont.Name = "Arial";
                    NewField74.TextFont.Size = 9;
                    NewField74.TextFont.Bold = true;
                    NewField74.TextFont.CharSet = 162;
                    NewField74.Value = @"............... Bakım";

                    NewField75 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 62, 162, 68, false);
                    NewField75.Name = "NewField75";
                    NewField75.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField75.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField75.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField75.TextFont.Name = "Arial";
                    NewField75.TextFont.Size = 9;
                    NewField75.TextFont.Bold = true;
                    NewField75.TextFont.CharSet = 162;
                    NewField75.Value = @"Kontrol";

                    NewField57 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 62, 179, 68, false);
                    NewField57.Name = "NewField57";
                    NewField57.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField57.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField57.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField57.TextFont.Name = "Arial";
                    NewField57.TextFont.Size = 9;
                    NewField57.TextFont.Bold = true;
                    NewField57.TextFont.CharSet = 162;
                    NewField57.Value = @"Parafe";

                    NewField58 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 62, 195, 68, false);
                    NewField58.Name = "NewField58";
                    NewField58.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField58.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField58.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField58.TextFont.Name = "Arial";
                    NewField58.TextFont.Size = 9;
                    NewField58.TextFont.Bold = true;
                    NewField58.TextFont.CharSet = 162;
                    NewField58.Value = @"Kontrol";

                    NewField76 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 62, 212, 68, false);
                    NewField76.Name = "NewField76";
                    NewField76.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField76.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField76.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField76.TextFont.Name = "Arial";
                    NewField76.TextFont.Size = 9;
                    NewField76.TextFont.Bold = true;
                    NewField76.TextFont.CharSet = 162;
                    NewField76.Value = @"Parafe";

                    NewField59 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 62, 228, 68, false);
                    NewField59.Name = "NewField59";
                    NewField59.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField59.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField59.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField59.TextFont.Name = "Arial";
                    NewField59.TextFont.Size = 9;
                    NewField59.TextFont.Bold = true;
                    NewField59.TextFont.CharSet = 162;
                    NewField59.Value = @"Kontrol";

                    NewField77 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 62, 245, 68, false);
                    NewField77.Name = "NewField77";
                    NewField77.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField77.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField77.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField77.TextFont.Name = "Arial";
                    NewField77.TextFont.Size = 9;
                    NewField77.TextFont.Bold = true;
                    NewField77.TextFont.CharSet = 162;
                    NewField77.Value = @"Parafe";

                    NewField60 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 62, 261, 68, false);
                    NewField60.Name = "NewField60";
                    NewField60.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField60.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField60.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField60.TextFont.Name = "Arial";
                    NewField60.TextFont.Size = 9;
                    NewField60.TextFont.Bold = true;
                    NewField60.TextFont.CharSet = 162;
                    NewField60.Value = @"Kontrol";

                    NewField78 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 62, 279, 68, false);
                    NewField78.Name = "NewField78";
                    NewField78.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField78.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField78.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField78.TextFont.Name = "Arial";
                    NewField78.TextFont.Size = 9;
                    NewField78.TextFont.Bold = true;
                    NewField78.TextFont.CharSet = 162;
                    NewField78.Value = @"Parafe";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.RepairReportNQL_Class dataset_RepairReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Repair.RepairReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    CIHAZADI.CalcValue = (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.Famname) : "");
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    SERINO.CalcValue = @"";
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    STOKNO.CalcValue = (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.NATOStockNO) : "");
                    BAKIMPERIYODU.CalcValue = (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.MaintenancePeriod) : "");
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    BIRLIKKURUMSERVIS.CalcValue = (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.Ownermilitaryunit) : "");
                    NewField51.CalcValue = NewField51.Value;
                    NewField61.CalcValue = NewField61.Value;
                    NewField71.CalcValue = NewField71.Value;
                    ADSOYAD.CalcValue = (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.Deviceuser) : "");
                    RUTBE.CalcValue = @"";
                    NewField62.CalcValue = NewField62.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField72.CalcValue = NewField72.Value;
                    NewField73.CalcValue = NewField73.Value;
                    NewField74.CalcValue = NewField74.Value;
                    NewField75.CalcValue = NewField75.Value;
                    NewField57.CalcValue = NewField57.Value;
                    NewField58.CalcValue = NewField58.Value;
                    NewField76.CalcValue = NewField76.Value;
                    NewField59.CalcValue = NewField59.Value;
                    NewField77.CalcValue = NewField77.Value;
                    NewField60.CalcValue = NewField60.Value;
                    NewField78.CalcValue = NewField78.Value;
                    MARKAMODELI.CalcValue = (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.Mark) : "") + " - " + (dataset_RepairReportNQL != null ? Globals.ToStringCore(dataset_RepairReportNQL.Model) : "");
                    return new TTReportObject[] { NewField,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,CIHAZADI,NewField8,NewField9,SERINO,NewField10,NewField11,NewField12,NewField13,NewField14,STOKNO,BAKIMPERIYODU,NewField15,NewField16,NewField17,BIRLIKKURUMSERVIS,NewField51,NewField61,NewField71,ADSOYAD,RUTBE,NewField62,NewField26,NewField27,NewField72,NewField73,NewField74,NewField75,NewField57,NewField58,NewField76,NewField59,NewField77,NewField60,NewField78,MARKAMODELI};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public BirlikSeviyesiBakimFormu MyParentReport
                {
                    get { return (BirlikSeviyesiBakimFormu)ParentReport; }
                }
                
                public TTReportField NewField_;
                public TTReportField NewField51_;
                public TTReportField NewField61_;
                public TTReportField NewField71_;
                public TTReportField ILAVEBILGILER;
                public TTReportField NewField72_;
                public TTReportField NewField27_;
                public TTReportField NewField37_;
                public TTReportField NewField47_;
                public TTReportField NewField62_;
                public TTReportField NewField26_;
                public TTReportField NewField28_;
                public TTReportField NewField73_;
                public TTReportField NewField74_;
                public TTReportField NewField75_;
                public TTReportField NewField4_;
                public TTReportField NewField5_;
                public TTReportField NewField6_;
                public TTReportField NewField7_;
                public TTReportField NewField8_;
                public TTReportField NewField9_;
                public TTReportField NewField29_;
                public TTReportField NewField92_;
                public TTReportField NewField93_;
                public TTReportField NewField2_;
                public TTReportField NewField10_;
                public TTReportField NewField11_;
                public TTReportField NewField12_;
                public TTReportField NewField13_;
                public TTReportField NewField14_;
                public TTReportField NewField15_;
                public TTReportField NewField94_;
                public TTReportField NewField30_;
                public TTReportField NewField39_;
                public TTReportField NewField3_;
                public TTReportField NewField16_;
                public TTReportField NewField17_;
                public TTReportField NewField18_;
                public TTReportField NewField19_;
                public TTReportField NewField20_;
                public TTReportField NewField21_;
                public TTReportField NewField95_;
                public TTReportField NewField31_;
                public TTReportField NewField40_;
                public TTReportField NewField22_;
                public TTReportField NewField23_;
                public TTReportField NewField24_;
                public TTReportField NewField25_;
                public TTReportField NewField32_;
                public TTReportField NewField33_;
                public TTReportField NewField34_;
                public TTReportField NewField96_;
                public TTReportField NewField35_;
                public TTReportField NewField41_;
                public TTReportField NewField36_;
                public TTReportField NewField38_;
                public TTReportField NewField42_;
                public TTReportField NewField43_;
                public TTReportField NewField44_;
                public TTReportField NewField45_;
                public TTReportField NewField46_;
                public TTReportField NewField97_;
                public TTReportField NewField48_;
                public TTReportField NewField49_;
                public TTReportField NewField50_;
                public TTReportField NewField52_;
                public TTReportField NewField53_;
                public TTReportField NewField54_;
                public TTReportField NewField55_;
                public TTReportField NewField56_;
                public TTReportField NewField57_;
                public TTReportField NewField98_;
                public TTReportField NewField58_;
                public TTReportField NewField59_;
                public TTReportField NewField60_;
                public TTReportField NewField63_;
                public TTReportField NewField64_;
                public TTReportField NewField65_;
                public TTReportField NewField66_;
                public TTReportField NewField67_;
                public TTReportField NewField68_;
                public TTReportField NewField99_;
                public TTReportField NewField69_;
                public TTReportField NewField70_;
                public TTReportField NewField76_;
                public TTReportField NewField77_;
                public TTReportField NewField78_;
                public TTReportField NewField79_;
                public TTReportField NewField80_;
                public TTReportField NewField81_;
                public TTReportField NewField82_;
                public TTReportField NewField100_;
                public TTReportField NewField83_;
                public TTReportField NewField84_;
                public TTReportField NewField85_;
                public TTReportField NewField86_;
                public TTReportField NewField87_; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 75;
                    RepeatCount = 0;
                    
                    NewField_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 48, 39, false);
                    NewField_.Name = "NewField_";
                    NewField_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField_.Value = @"";

                    NewField51_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 279, 8, false);
                    NewField51_.Name = "NewField51_";
                    NewField51_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51_.Value = @"";

                    NewField61_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 53, 7, false);
                    NewField61_.Name = "NewField61_";
                    NewField61_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField61_.TextFont.Name = "Arial";
                    NewField61_.TextFont.Size = 9;
                    NewField61_.TextFont.Bold = true;
                    NewField61_.TextFont.CharSet = 162;
                    NewField61_.Value = @"Varsa İlave Bilgiler";

                    NewField71_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 1, 54, 7, false);
                    NewField71_.Name = "NewField71_";
                    NewField71_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField71_.TextFont.Name = "Arial";
                    NewField71_.TextFont.Size = 9;
                    NewField71_.TextFont.Bold = true;
                    NewField71_.TextFont.CharSet = 162;
                    NewField71_.Value = @":";

                    ILAVEBILGILER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 278, 7, false);
                    ILAVEBILGILER.Name = "ILAVEBILGILER";
                    ILAVEBILGILER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILAVEBILGILER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ILAVEBILGILER.TextFont.Name = "Arial";
                    ILAVEBILGILER.TextFont.Size = 9;
                    ILAVEBILGILER.TextFont.Bold = true;
                    ILAVEBILGILER.TextFont.CharSet = 162;
                    ILAVEBILGILER.Value = @"";

                    NewField72_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 14, 48, 20, false);
                    NewField72_.Name = "NewField72_";
                    NewField72_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField72_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField72_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField72_.TextFont.Name = "Arial";
                    NewField72_.TextFont.Size = 9;
                    NewField72_.TextFont.Bold = true;
                    NewField72_.TextFont.CharSet = 162;
                    NewField72_.Value = @"1 inci Bakım";

                    NewField27_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 14, 81, 20, false);
                    NewField27_.Name = "NewField27_";
                    NewField27_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField27_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField27_.TextFont.Name = "Arial";
                    NewField27_.TextFont.Size = 9;
                    NewField27_.TextFont.Bold = true;
                    NewField27_.TextFont.CharSet = 162;
                    NewField27_.Value = @"............... Bakım";

                    NewField37_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 14, 114, 20, false);
                    NewField37_.Name = "NewField37_";
                    NewField37_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField37_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField37_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField37_.TextFont.Name = "Arial";
                    NewField37_.TextFont.Size = 9;
                    NewField37_.TextFont.Bold = true;
                    NewField37_.TextFont.CharSet = 162;
                    NewField37_.Value = @"............... Bakım";

                    NewField47_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 14, 147, 20, false);
                    NewField47_.Name = "NewField47_";
                    NewField47_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField47_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField47_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField47_.TextFont.Name = "Arial";
                    NewField47_.TextFont.Size = 9;
                    NewField47_.TextFont.Bold = true;
                    NewField47_.TextFont.CharSet = 162;
                    NewField47_.Value = @"............... Bakım";

                    NewField62_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 8, 147, 14, false);
                    NewField62_.Name = "NewField62_";
                    NewField62_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField62_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField62_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField62_.TextFont.Name = "Arial";
                    NewField62_.TextFont.Size = 9;
                    NewField62_.TextFont.Bold = true;
                    NewField62_.TextFont.CharSet = 162;
                    NewField62_.Value = @"Birlik Bakım Teknisyeni";

                    NewField26_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 8, 279, 14, false);
                    NewField26_.Name = "NewField26_";
                    NewField26_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField26_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField26_.TextFont.Name = "Arial";
                    NewField26_.TextFont.Size = 9;
                    NewField26_.TextFont.Bold = true;
                    NewField26_.TextFont.CharSet = 162;
                    NewField26_.Value = @"Kullanıcı Birlik Personeli";

                    NewField28_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 14, 180, 20, false);
                    NewField28_.Name = "NewField28_";
                    NewField28_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField28_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField28_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField28_.TextFont.Name = "Arial";
                    NewField28_.TextFont.Size = 9;
                    NewField28_.TextFont.Bold = true;
                    NewField28_.TextFont.CharSet = 162;
                    NewField28_.Value = @"1 inci Bakım";

                    NewField73_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 14, 213, 20, false);
                    NewField73_.Name = "NewField73_";
                    NewField73_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField73_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField73_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField73_.TextFont.Name = "Arial";
                    NewField73_.TextFont.Size = 9;
                    NewField73_.TextFont.Bold = true;
                    NewField73_.TextFont.CharSet = 162;
                    NewField73_.Value = @"............... Bakım";

                    NewField74_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 14, 246, 20, false);
                    NewField74_.Name = "NewField74_";
                    NewField74_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField74_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField74_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField74_.TextFont.Name = "Arial";
                    NewField74_.TextFont.Size = 9;
                    NewField74_.TextFont.Bold = true;
                    NewField74_.TextFont.CharSet = 162;
                    NewField74_.Value = @"............... Bakım";

                    NewField75_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 14, 279, 20, false);
                    NewField75_.Name = "NewField75_";
                    NewField75_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField75_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField75_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField75_.TextFont.Name = "Arial";
                    NewField75_.TextFont.Size = 9;
                    NewField75_.TextFont.Bold = true;
                    NewField75_.TextFont.CharSet = 162;
                    NewField75_.Value = @"............... Bakım";

                    NewField4_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 21, 34, 27, false);
                    NewField4_.Name = "NewField4_";
                    NewField4_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4_.TextFont.Name = "Arial";
                    NewField4_.TextFont.Size = 9;
                    NewField4_.TextFont.Bold = true;
                    NewField4_.TextFont.CharSet = 162;
                    NewField4_.Value = @"İMZA";

                    NewField5_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 27, 34, 33, false);
                    NewField5_.Name = "NewField5_";
                    NewField5_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5_.TextFont.Name = "Arial";
                    NewField5_.TextFont.Size = 9;
                    NewField5_.TextFont.Bold = true;
                    NewField5_.TextFont.CharSet = 162;
                    NewField5_.Value = @"ADI SOYADI";

                    NewField6_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 21, 35, 27, false);
                    NewField6_.Name = "NewField6_";
                    NewField6_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_.TextFont.Name = "Arial";
                    NewField6_.TextFont.Size = 9;
                    NewField6_.TextFont.Bold = true;
                    NewField6_.TextFont.CharSet = 162;
                    NewField6_.Value = @":";

                    NewField7_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 27, 35, 33, false);
                    NewField7_.Name = "NewField7_";
                    NewField7_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_.TextFont.Name = "Arial";
                    NewField7_.TextFont.Size = 9;
                    NewField7_.TextFont.Bold = true;
                    NewField7_.TextFont.CharSet = 162;
                    NewField7_.Value = @":";

                    NewField8_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 33, 34, 39, false);
                    NewField8_.Name = "NewField8_";
                    NewField8_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8_.TextFont.Name = "Arial";
                    NewField8_.TextFont.Size = 9;
                    NewField8_.TextFont.Bold = true;
                    NewField8_.TextFont.CharSet = 162;
                    NewField8_.Value = @"RÜTBESİ";

                    NewField9_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 33, 35, 39, false);
                    NewField9_.Name = "NewField9_";
                    NewField9_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9_.TextFont.Name = "Arial";
                    NewField9_.TextFont.Size = 9;
                    NewField9_.TextFont.Bold = true;
                    NewField9_.TextFont.CharSet = 162;
                    NewField9_.Value = @":";

                    NewField29_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 21, 48, 27, false);
                    NewField29_.Name = "NewField29_";
                    NewField29_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField29_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField29_.TextFont.Name = "Arial";
                    NewField29_.TextFont.Size = 9;
                    NewField29_.TextFont.Bold = true;
                    NewField29_.TextFont.CharSet = 162;
                    NewField29_.Value = @"";

                    NewField92_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 27, 48, 33, false);
                    NewField92_.Name = "NewField92_";
                    NewField92_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField92_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField92_.TextFont.Name = "Arial";
                    NewField92_.TextFont.Size = 9;
                    NewField92_.TextFont.Bold = true;
                    NewField92_.TextFont.CharSet = 162;
                    NewField92_.Value = @"";

                    NewField93_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 33, 48, 39, false);
                    NewField93_.Name = "NewField93_";
                    NewField93_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField93_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField93_.TextFont.Name = "Arial";
                    NewField93_.TextFont.Size = 9;
                    NewField93_.TextFont.Bold = true;
                    NewField93_.TextFont.CharSet = 162;
                    NewField93_.Value = @"";

                    NewField2_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 20, 81, 39, false);
                    NewField2_.Name = "NewField2_";
                    NewField2_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField2_.Value = @"";

                    NewField10_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 21, 67, 27, false);
                    NewField10_.Name = "NewField10_";
                    NewField10_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10_.TextFont.Name = "Arial";
                    NewField10_.TextFont.Size = 9;
                    NewField10_.TextFont.Bold = true;
                    NewField10_.TextFont.CharSet = 162;
                    NewField10_.Value = @"İMZA";

                    NewField11_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 27, 67, 33, false);
                    NewField11_.Name = "NewField11_";
                    NewField11_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11_.TextFont.Name = "Arial";
                    NewField11_.TextFont.Size = 9;
                    NewField11_.TextFont.Bold = true;
                    NewField11_.TextFont.CharSet = 162;
                    NewField11_.Value = @"ADI SOYADI";

                    NewField12_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 21, 68, 27, false);
                    NewField12_.Name = "NewField12_";
                    NewField12_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12_.TextFont.Name = "Arial";
                    NewField12_.TextFont.Size = 9;
                    NewField12_.TextFont.Bold = true;
                    NewField12_.TextFont.CharSet = 162;
                    NewField12_.Value = @":";

                    NewField13_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 27, 68, 33, false);
                    NewField13_.Name = "NewField13_";
                    NewField13_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13_.TextFont.Name = "Arial";
                    NewField13_.TextFont.Size = 9;
                    NewField13_.TextFont.Bold = true;
                    NewField13_.TextFont.CharSet = 162;
                    NewField13_.Value = @":";

                    NewField14_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 33, 67, 39, false);
                    NewField14_.Name = "NewField14_";
                    NewField14_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14_.TextFont.Name = "Arial";
                    NewField14_.TextFont.Size = 9;
                    NewField14_.TextFont.Bold = true;
                    NewField14_.TextFont.CharSet = 162;
                    NewField14_.Value = @"RÜTBESİ";

                    NewField15_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 33, 68, 39, false);
                    NewField15_.Name = "NewField15_";
                    NewField15_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15_.TextFont.Name = "Arial";
                    NewField15_.TextFont.Size = 9;
                    NewField15_.TextFont.Bold = true;
                    NewField15_.TextFont.CharSet = 162;
                    NewField15_.Value = @":";

                    NewField94_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 21, 81, 27, false);
                    NewField94_.Name = "NewField94_";
                    NewField94_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField94_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField94_.TextFont.Name = "Arial";
                    NewField94_.TextFont.Size = 9;
                    NewField94_.TextFont.Bold = true;
                    NewField94_.TextFont.CharSet = 162;
                    NewField94_.Value = @"";

                    NewField30_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 27, 81, 33, false);
                    NewField30_.Name = "NewField30_";
                    NewField30_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField30_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField30_.TextFont.Name = "Arial";
                    NewField30_.TextFont.Size = 9;
                    NewField30_.TextFont.Bold = true;
                    NewField30_.TextFont.CharSet = 162;
                    NewField30_.Value = @"";

                    NewField39_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 33, 81, 39, false);
                    NewField39_.Name = "NewField39_";
                    NewField39_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField39_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField39_.TextFont.Name = "Arial";
                    NewField39_.TextFont.Size = 9;
                    NewField39_.TextFont.Bold = true;
                    NewField39_.TextFont.CharSet = 162;
                    NewField39_.Value = @"";

                    NewField3_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 20, 114, 39, false);
                    NewField3_.Name = "NewField3_";
                    NewField3_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3_.Value = @"";

                    NewField16_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 21, 100, 27, false);
                    NewField16_.Name = "NewField16_";
                    NewField16_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16_.TextFont.Name = "Arial";
                    NewField16_.TextFont.Size = 9;
                    NewField16_.TextFont.Bold = true;
                    NewField16_.TextFont.CharSet = 162;
                    NewField16_.Value = @"İMZA";

                    NewField17_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 27, 100, 33, false);
                    NewField17_.Name = "NewField17_";
                    NewField17_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17_.TextFont.Name = "Arial";
                    NewField17_.TextFont.Size = 9;
                    NewField17_.TextFont.Bold = true;
                    NewField17_.TextFont.CharSet = 162;
                    NewField17_.Value = @"ADI SOYADI";

                    NewField18_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 21, 101, 27, false);
                    NewField18_.Name = "NewField18_";
                    NewField18_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18_.TextFont.Name = "Arial";
                    NewField18_.TextFont.Size = 9;
                    NewField18_.TextFont.Bold = true;
                    NewField18_.TextFont.CharSet = 162;
                    NewField18_.Value = @":";

                    NewField19_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 27, 101, 33, false);
                    NewField19_.Name = "NewField19_";
                    NewField19_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19_.TextFont.Name = "Arial";
                    NewField19_.TextFont.Size = 9;
                    NewField19_.TextFont.Bold = true;
                    NewField19_.TextFont.CharSet = 162;
                    NewField19_.Value = @":";

                    NewField20_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 33, 100, 39, false);
                    NewField20_.Name = "NewField20_";
                    NewField20_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20_.TextFont.Name = "Arial";
                    NewField20_.TextFont.Size = 9;
                    NewField20_.TextFont.Bold = true;
                    NewField20_.TextFont.CharSet = 162;
                    NewField20_.Value = @"RÜTBESİ";

                    NewField21_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 33, 101, 39, false);
                    NewField21_.Name = "NewField21_";
                    NewField21_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_.TextFont.Name = "Arial";
                    NewField21_.TextFont.Size = 9;
                    NewField21_.TextFont.Bold = true;
                    NewField21_.TextFont.CharSet = 162;
                    NewField21_.Value = @":";

                    NewField95_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 21, 114, 27, false);
                    NewField95_.Name = "NewField95_";
                    NewField95_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField95_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField95_.TextFont.Name = "Arial";
                    NewField95_.TextFont.Size = 9;
                    NewField95_.TextFont.Bold = true;
                    NewField95_.TextFont.CharSet = 162;
                    NewField95_.Value = @"";

                    NewField31_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 27, 114, 33, false);
                    NewField31_.Name = "NewField31_";
                    NewField31_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField31_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31_.TextFont.Name = "Arial";
                    NewField31_.TextFont.Size = 9;
                    NewField31_.TextFont.Bold = true;
                    NewField31_.TextFont.CharSet = 162;
                    NewField31_.Value = @"";

                    NewField40_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 33, 114, 39, false);
                    NewField40_.Name = "NewField40_";
                    NewField40_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField40_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField40_.TextFont.Name = "Arial";
                    NewField40_.TextFont.Size = 9;
                    NewField40_.TextFont.Bold = true;
                    NewField40_.TextFont.CharSet = 162;
                    NewField40_.Value = @"";

                    NewField22_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 20, 147, 39, false);
                    NewField22_.Name = "NewField22_";
                    NewField22_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22_.Value = @"";

                    NewField23_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 21, 133, 27, false);
                    NewField23_.Name = "NewField23_";
                    NewField23_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23_.TextFont.Name = "Arial";
                    NewField23_.TextFont.Size = 9;
                    NewField23_.TextFont.Bold = true;
                    NewField23_.TextFont.CharSet = 162;
                    NewField23_.Value = @"İMZA";

                    NewField24_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 27, 133, 33, false);
                    NewField24_.Name = "NewField24_";
                    NewField24_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24_.TextFont.Name = "Arial";
                    NewField24_.TextFont.Size = 9;
                    NewField24_.TextFont.Bold = true;
                    NewField24_.TextFont.CharSet = 162;
                    NewField24_.Value = @"ADI SOYADI";

                    NewField25_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 21, 134, 27, false);
                    NewField25_.Name = "NewField25_";
                    NewField25_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField25_.TextFont.Name = "Arial";
                    NewField25_.TextFont.Size = 9;
                    NewField25_.TextFont.Bold = true;
                    NewField25_.TextFont.CharSet = 162;
                    NewField25_.Value = @":";

                    NewField32_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 27, 134, 33, false);
                    NewField32_.Name = "NewField32_";
                    NewField32_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField32_.TextFont.Name = "Arial";
                    NewField32_.TextFont.Size = 9;
                    NewField32_.TextFont.Bold = true;
                    NewField32_.TextFont.CharSet = 162;
                    NewField32_.Value = @":";

                    NewField33_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 33, 133, 39, false);
                    NewField33_.Name = "NewField33_";
                    NewField33_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField33_.TextFont.Name = "Arial";
                    NewField33_.TextFont.Size = 9;
                    NewField33_.TextFont.Bold = true;
                    NewField33_.TextFont.CharSet = 162;
                    NewField33_.Value = @"RÜTBESİ";

                    NewField34_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 33, 134, 39, false);
                    NewField34_.Name = "NewField34_";
                    NewField34_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField34_.TextFont.Name = "Arial";
                    NewField34_.TextFont.Size = 9;
                    NewField34_.TextFont.Bold = true;
                    NewField34_.TextFont.CharSet = 162;
                    NewField34_.Value = @":";

                    NewField96_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 21, 147, 27, false);
                    NewField96_.Name = "NewField96_";
                    NewField96_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField96_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField96_.TextFont.Name = "Arial";
                    NewField96_.TextFont.Size = 9;
                    NewField96_.TextFont.Bold = true;
                    NewField96_.TextFont.CharSet = 162;
                    NewField96_.Value = @"";

                    NewField35_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 27, 147, 33, false);
                    NewField35_.Name = "NewField35_";
                    NewField35_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField35_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField35_.TextFont.Name = "Arial";
                    NewField35_.TextFont.Size = 9;
                    NewField35_.TextFont.Bold = true;
                    NewField35_.TextFont.CharSet = 162;
                    NewField35_.Value = @"";

                    NewField41_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 33, 147, 39, false);
                    NewField41_.Name = "NewField41_";
                    NewField41_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField41_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField41_.TextFont.Name = "Arial";
                    NewField41_.TextFont.Size = 9;
                    NewField41_.TextFont.Bold = true;
                    NewField41_.TextFont.CharSet = 162;
                    NewField41_.Value = @"";

                    NewField36_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 20, 180, 39, false);
                    NewField36_.Name = "NewField36_";
                    NewField36_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField36_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField36_.Value = @"";

                    NewField38_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 21, 166, 27, false);
                    NewField38_.Name = "NewField38_";
                    NewField38_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField38_.TextFont.Name = "Arial";
                    NewField38_.TextFont.Size = 9;
                    NewField38_.TextFont.Bold = true;
                    NewField38_.TextFont.CharSet = 162;
                    NewField38_.Value = @"İMZA";

                    NewField42_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 27, 166, 33, false);
                    NewField42_.Name = "NewField42_";
                    NewField42_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField42_.TextFont.Name = "Arial";
                    NewField42_.TextFont.Size = 9;
                    NewField42_.TextFont.Bold = true;
                    NewField42_.TextFont.CharSet = 162;
                    NewField42_.Value = @"ADI SOYADI";

                    NewField43_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 21, 167, 27, false);
                    NewField43_.Name = "NewField43_";
                    NewField43_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField43_.TextFont.Name = "Arial";
                    NewField43_.TextFont.Size = 9;
                    NewField43_.TextFont.Bold = true;
                    NewField43_.TextFont.CharSet = 162;
                    NewField43_.Value = @":";

                    NewField44_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 27, 167, 33, false);
                    NewField44_.Name = "NewField44_";
                    NewField44_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField44_.TextFont.Name = "Arial";
                    NewField44_.TextFont.Size = 9;
                    NewField44_.TextFont.Bold = true;
                    NewField44_.TextFont.CharSet = 162;
                    NewField44_.Value = @":";

                    NewField45_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 33, 166, 39, false);
                    NewField45_.Name = "NewField45_";
                    NewField45_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField45_.TextFont.Name = "Arial";
                    NewField45_.TextFont.Size = 9;
                    NewField45_.TextFont.Bold = true;
                    NewField45_.TextFont.CharSet = 162;
                    NewField45_.Value = @"RÜTBESİ";

                    NewField46_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 33, 167, 39, false);
                    NewField46_.Name = "NewField46_";
                    NewField46_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField46_.TextFont.Name = "Arial";
                    NewField46_.TextFont.Size = 9;
                    NewField46_.TextFont.Bold = true;
                    NewField46_.TextFont.CharSet = 162;
                    NewField46_.Value = @":";

                    NewField97_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 21, 180, 27, false);
                    NewField97_.Name = "NewField97_";
                    NewField97_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField97_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField97_.TextFont.Name = "Arial";
                    NewField97_.TextFont.Size = 9;
                    NewField97_.TextFont.Bold = true;
                    NewField97_.TextFont.CharSet = 162;
                    NewField97_.Value = @"";

                    NewField48_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 27, 180, 33, false);
                    NewField48_.Name = "NewField48_";
                    NewField48_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField48_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField48_.TextFont.Name = "Arial";
                    NewField48_.TextFont.Size = 9;
                    NewField48_.TextFont.Bold = true;
                    NewField48_.TextFont.CharSet = 162;
                    NewField48_.Value = @"";

                    NewField49_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 33, 180, 39, false);
                    NewField49_.Name = "NewField49_";
                    NewField49_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField49_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField49_.TextFont.Name = "Arial";
                    NewField49_.TextFont.Size = 9;
                    NewField49_.TextFont.Bold = true;
                    NewField49_.TextFont.CharSet = 162;
                    NewField49_.Value = @"";

                    NewField50_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 20, 213, 39, false);
                    NewField50_.Name = "NewField50_";
                    NewField50_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField50_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField50_.Value = @"";

                    NewField52_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 21, 199, 27, false);
                    NewField52_.Name = "NewField52_";
                    NewField52_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField52_.TextFont.Name = "Arial";
                    NewField52_.TextFont.Size = 9;
                    NewField52_.TextFont.Bold = true;
                    NewField52_.TextFont.CharSet = 162;
                    NewField52_.Value = @"İMZA";

                    NewField53_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 27, 199, 33, false);
                    NewField53_.Name = "NewField53_";
                    NewField53_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField53_.TextFont.Name = "Arial";
                    NewField53_.TextFont.Size = 9;
                    NewField53_.TextFont.Bold = true;
                    NewField53_.TextFont.CharSet = 162;
                    NewField53_.Value = @"ADI SOYADI";

                    NewField54_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 21, 200, 27, false);
                    NewField54_.Name = "NewField54_";
                    NewField54_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField54_.TextFont.Name = "Arial";
                    NewField54_.TextFont.Size = 9;
                    NewField54_.TextFont.Bold = true;
                    NewField54_.TextFont.CharSet = 162;
                    NewField54_.Value = @":";

                    NewField55_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 27, 200, 33, false);
                    NewField55_.Name = "NewField55_";
                    NewField55_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField55_.TextFont.Name = "Arial";
                    NewField55_.TextFont.Size = 9;
                    NewField55_.TextFont.Bold = true;
                    NewField55_.TextFont.CharSet = 162;
                    NewField55_.Value = @":";

                    NewField56_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 33, 199, 39, false);
                    NewField56_.Name = "NewField56_";
                    NewField56_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField56_.TextFont.Name = "Arial";
                    NewField56_.TextFont.Size = 9;
                    NewField56_.TextFont.Bold = true;
                    NewField56_.TextFont.CharSet = 162;
                    NewField56_.Value = @"RÜTBESİ";

                    NewField57_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 33, 200, 39, false);
                    NewField57_.Name = "NewField57_";
                    NewField57_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField57_.TextFont.Name = "Arial";
                    NewField57_.TextFont.Size = 9;
                    NewField57_.TextFont.Bold = true;
                    NewField57_.TextFont.CharSet = 162;
                    NewField57_.Value = @":";

                    NewField98_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 21, 213, 27, false);
                    NewField98_.Name = "NewField98_";
                    NewField98_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField98_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField98_.TextFont.Name = "Arial";
                    NewField98_.TextFont.Size = 9;
                    NewField98_.TextFont.Bold = true;
                    NewField98_.TextFont.CharSet = 162;
                    NewField98_.Value = @"";

                    NewField58_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 27, 213, 33, false);
                    NewField58_.Name = "NewField58_";
                    NewField58_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField58_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField58_.TextFont.Name = "Arial";
                    NewField58_.TextFont.Size = 9;
                    NewField58_.TextFont.Bold = true;
                    NewField58_.TextFont.CharSet = 162;
                    NewField58_.Value = @"";

                    NewField59_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 33, 213, 39, false);
                    NewField59_.Name = "NewField59_";
                    NewField59_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField59_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField59_.TextFont.Name = "Arial";
                    NewField59_.TextFont.Size = 9;
                    NewField59_.TextFont.Bold = true;
                    NewField59_.TextFont.CharSet = 162;
                    NewField59_.Value = @"";

                    NewField60_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 20, 246, 39, false);
                    NewField60_.Name = "NewField60_";
                    NewField60_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField60_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField60_.Value = @"";

                    NewField63_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 21, 232, 27, false);
                    NewField63_.Name = "NewField63_";
                    NewField63_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField63_.TextFont.Name = "Arial";
                    NewField63_.TextFont.Size = 9;
                    NewField63_.TextFont.Bold = true;
                    NewField63_.TextFont.CharSet = 162;
                    NewField63_.Value = @"İMZA";

                    NewField64_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 27, 232, 33, false);
                    NewField64_.Name = "NewField64_";
                    NewField64_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField64_.TextFont.Name = "Arial";
                    NewField64_.TextFont.Size = 9;
                    NewField64_.TextFont.Bold = true;
                    NewField64_.TextFont.CharSet = 162;
                    NewField64_.Value = @"ADI SOYADI";

                    NewField65_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 21, 233, 27, false);
                    NewField65_.Name = "NewField65_";
                    NewField65_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField65_.TextFont.Name = "Arial";
                    NewField65_.TextFont.Size = 9;
                    NewField65_.TextFont.Bold = true;
                    NewField65_.TextFont.CharSet = 162;
                    NewField65_.Value = @":";

                    NewField66_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 27, 233, 33, false);
                    NewField66_.Name = "NewField66_";
                    NewField66_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField66_.TextFont.Name = "Arial";
                    NewField66_.TextFont.Size = 9;
                    NewField66_.TextFont.Bold = true;
                    NewField66_.TextFont.CharSet = 162;
                    NewField66_.Value = @":";

                    NewField67_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 33, 232, 39, false);
                    NewField67_.Name = "NewField67_";
                    NewField67_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField67_.TextFont.Name = "Arial";
                    NewField67_.TextFont.Size = 9;
                    NewField67_.TextFont.Bold = true;
                    NewField67_.TextFont.CharSet = 162;
                    NewField67_.Value = @"RÜTBESİ";

                    NewField68_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 33, 233, 39, false);
                    NewField68_.Name = "NewField68_";
                    NewField68_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField68_.TextFont.Name = "Arial";
                    NewField68_.TextFont.Size = 9;
                    NewField68_.TextFont.Bold = true;
                    NewField68_.TextFont.CharSet = 162;
                    NewField68_.Value = @":";

                    NewField99_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 21, 246, 27, false);
                    NewField99_.Name = "NewField99_";
                    NewField99_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField99_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField99_.TextFont.Name = "Arial";
                    NewField99_.TextFont.Size = 9;
                    NewField99_.TextFont.Bold = true;
                    NewField99_.TextFont.CharSet = 162;
                    NewField99_.Value = @"";

                    NewField69_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 27, 246, 33, false);
                    NewField69_.Name = "NewField69_";
                    NewField69_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField69_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField69_.TextFont.Name = "Arial";
                    NewField69_.TextFont.Size = 9;
                    NewField69_.TextFont.Bold = true;
                    NewField69_.TextFont.CharSet = 162;
                    NewField69_.Value = @"";

                    NewField70_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 33, 246, 39, false);
                    NewField70_.Name = "NewField70_";
                    NewField70_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField70_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField70_.TextFont.Name = "Arial";
                    NewField70_.TextFont.Size = 9;
                    NewField70_.TextFont.Bold = true;
                    NewField70_.TextFont.CharSet = 162;
                    NewField70_.Value = @"";

                    NewField76_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 20, 279, 39, false);
                    NewField76_.Name = "NewField76_";
                    NewField76_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField76_.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField76_.Value = @"";

                    NewField77_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 21, 265, 27, false);
                    NewField77_.Name = "NewField77_";
                    NewField77_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField77_.TextFont.Name = "Arial";
                    NewField77_.TextFont.Size = 9;
                    NewField77_.TextFont.Bold = true;
                    NewField77_.TextFont.CharSet = 162;
                    NewField77_.Value = @"İMZA";

                    NewField78_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 27, 265, 33, false);
                    NewField78_.Name = "NewField78_";
                    NewField78_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField78_.TextFont.Name = "Arial";
                    NewField78_.TextFont.Size = 9;
                    NewField78_.TextFont.Bold = true;
                    NewField78_.TextFont.CharSet = 162;
                    NewField78_.Value = @"ADI SOYADI";

                    NewField79_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 21, 266, 27, false);
                    NewField79_.Name = "NewField79_";
                    NewField79_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField79_.TextFont.Name = "Arial";
                    NewField79_.TextFont.Size = 9;
                    NewField79_.TextFont.Bold = true;
                    NewField79_.TextFont.CharSet = 162;
                    NewField79_.Value = @":";

                    NewField80_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 27, 266, 33, false);
                    NewField80_.Name = "NewField80_";
                    NewField80_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField80_.TextFont.Name = "Arial";
                    NewField80_.TextFont.Size = 9;
                    NewField80_.TextFont.Bold = true;
                    NewField80_.TextFont.CharSet = 162;
                    NewField80_.Value = @":";

                    NewField81_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 33, 265, 39, false);
                    NewField81_.Name = "NewField81_";
                    NewField81_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField81_.TextFont.Name = "Arial";
                    NewField81_.TextFont.Size = 9;
                    NewField81_.TextFont.Bold = true;
                    NewField81_.TextFont.CharSet = 162;
                    NewField81_.Value = @"RÜTBESİ";

                    NewField82_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 33, 266, 39, false);
                    NewField82_.Name = "NewField82_";
                    NewField82_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField82_.TextFont.Name = "Arial";
                    NewField82_.TextFont.Size = 9;
                    NewField82_.TextFont.Bold = true;
                    NewField82_.TextFont.CharSet = 162;
                    NewField82_.Value = @":";

                    NewField100_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 21, 279, 27, false);
                    NewField100_.Name = "NewField100_";
                    NewField100_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField100_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField100_.TextFont.Name = "Arial";
                    NewField100_.TextFont.Size = 9;
                    NewField100_.TextFont.Bold = true;
                    NewField100_.TextFont.CharSet = 162;
                    NewField100_.Value = @"";

                    NewField83_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 27, 279, 33, false);
                    NewField83_.Name = "NewField83_";
                    NewField83_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField83_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField83_.TextFont.Name = "Arial";
                    NewField83_.TextFont.Size = 9;
                    NewField83_.TextFont.Bold = true;
                    NewField83_.TextFont.CharSet = 162;
                    NewField83_.Value = @"";

                    NewField84_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 33, 279, 39, false);
                    NewField84_.Name = "NewField84_";
                    NewField84_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField84_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField84_.TextFont.Name = "Arial";
                    NewField84_.TextFont.Size = 9;
                    NewField84_.TextFont.Bold = true;
                    NewField84_.TextFont.CharSet = 162;
                    NewField84_.Value = @"";

                    NewField85_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 42, 154, 48, false);
                    NewField85_.Name = "NewField85_";
                    NewField85_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField85_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField85_.TextFont.Name = "Arial";
                    NewField85_.TextFont.Size = 11;
                    NewField85_.TextFont.Bold = true;
                    NewField85_.TextFont.Underline = true;
                    NewField85_.TextFont.CharSet = 162;
                    NewField85_.Value = @"ONAY";

                    NewField86_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 48, 171, 58, false);
                    NewField86_.Name = "NewField86_";
                    NewField86_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField86_.MultiLine = EvetHayirEnum.ehEvet;
                    NewField86_.WordBreak = EvetHayirEnum.ehEvet;
                    NewField86_.TextFont.Name = "Arial";
                    NewField86_.TextFont.Size = 9;
                    NewField86_.TextFont.Bold = true;
                    NewField86_.TextFont.CharSet = 162;
                    NewField86_.Value = @"............................................................... ...............................................................";

                    NewField87_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 58, 171, 64, false);
                    NewField87_.Name = "NewField87_";
                    NewField87_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField87_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField87_.TextFont.Name = "Arial";
                    NewField87_.TextFont.Size = 9;
                    NewField87_.TextFont.Bold = true;
                    NewField87_.TextFont.CharSet = 162;
                    NewField87_.Value = @"XXXXXX Shh.İkm.Bkm.Mrk.K.lığı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.RepairReportNQL_Class dataset_RepairReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Repair.RepairReportNQL_Class>(0);
                    NewField_.CalcValue = NewField_.Value;
                    NewField51_.CalcValue = NewField51_.Value;
                    NewField61_.CalcValue = NewField61_.Value;
                    NewField71_.CalcValue = NewField71_.Value;
                    ILAVEBILGILER.CalcValue = @"";
                    NewField72_.CalcValue = NewField72_.Value;
                    NewField27_.CalcValue = NewField27_.Value;
                    NewField37_.CalcValue = NewField37_.Value;
                    NewField47_.CalcValue = NewField47_.Value;
                    NewField62_.CalcValue = NewField62_.Value;
                    NewField26_.CalcValue = NewField26_.Value;
                    NewField28_.CalcValue = NewField28_.Value;
                    NewField73_.CalcValue = NewField73_.Value;
                    NewField74_.CalcValue = NewField74_.Value;
                    NewField75_.CalcValue = NewField75_.Value;
                    NewField4_.CalcValue = NewField4_.Value;
                    NewField5_.CalcValue = NewField5_.Value;
                    NewField6_.CalcValue = NewField6_.Value;
                    NewField7_.CalcValue = NewField7_.Value;
                    NewField8_.CalcValue = NewField8_.Value;
                    NewField9_.CalcValue = NewField9_.Value;
                    NewField29_.CalcValue = NewField29_.Value;
                    NewField92_.CalcValue = NewField92_.Value;
                    NewField93_.CalcValue = NewField93_.Value;
                    NewField2_.CalcValue = NewField2_.Value;
                    NewField10_.CalcValue = NewField10_.Value;
                    NewField11_.CalcValue = NewField11_.Value;
                    NewField12_.CalcValue = NewField12_.Value;
                    NewField13_.CalcValue = NewField13_.Value;
                    NewField14_.CalcValue = NewField14_.Value;
                    NewField15_.CalcValue = NewField15_.Value;
                    NewField94_.CalcValue = NewField94_.Value;
                    NewField30_.CalcValue = NewField30_.Value;
                    NewField39_.CalcValue = NewField39_.Value;
                    NewField3_.CalcValue = NewField3_.Value;
                    NewField16_.CalcValue = NewField16_.Value;
                    NewField17_.CalcValue = NewField17_.Value;
                    NewField18_.CalcValue = NewField18_.Value;
                    NewField19_.CalcValue = NewField19_.Value;
                    NewField20_.CalcValue = NewField20_.Value;
                    NewField21_.CalcValue = NewField21_.Value;
                    NewField95_.CalcValue = NewField95_.Value;
                    NewField31_.CalcValue = NewField31_.Value;
                    NewField40_.CalcValue = NewField40_.Value;
                    NewField22_.CalcValue = NewField22_.Value;
                    NewField23_.CalcValue = NewField23_.Value;
                    NewField24_.CalcValue = NewField24_.Value;
                    NewField25_.CalcValue = NewField25_.Value;
                    NewField32_.CalcValue = NewField32_.Value;
                    NewField33_.CalcValue = NewField33_.Value;
                    NewField34_.CalcValue = NewField34_.Value;
                    NewField96_.CalcValue = NewField96_.Value;
                    NewField35_.CalcValue = NewField35_.Value;
                    NewField41_.CalcValue = NewField41_.Value;
                    NewField36_.CalcValue = NewField36_.Value;
                    NewField38_.CalcValue = NewField38_.Value;
                    NewField42_.CalcValue = NewField42_.Value;
                    NewField43_.CalcValue = NewField43_.Value;
                    NewField44_.CalcValue = NewField44_.Value;
                    NewField45_.CalcValue = NewField45_.Value;
                    NewField46_.CalcValue = NewField46_.Value;
                    NewField97_.CalcValue = NewField97_.Value;
                    NewField48_.CalcValue = NewField48_.Value;
                    NewField49_.CalcValue = NewField49_.Value;
                    NewField50_.CalcValue = NewField50_.Value;
                    NewField52_.CalcValue = NewField52_.Value;
                    NewField53_.CalcValue = NewField53_.Value;
                    NewField54_.CalcValue = NewField54_.Value;
                    NewField55_.CalcValue = NewField55_.Value;
                    NewField56_.CalcValue = NewField56_.Value;
                    NewField57_.CalcValue = NewField57_.Value;
                    NewField98_.CalcValue = NewField98_.Value;
                    NewField58_.CalcValue = NewField58_.Value;
                    NewField59_.CalcValue = NewField59_.Value;
                    NewField60_.CalcValue = NewField60_.Value;
                    NewField63_.CalcValue = NewField63_.Value;
                    NewField64_.CalcValue = NewField64_.Value;
                    NewField65_.CalcValue = NewField65_.Value;
                    NewField66_.CalcValue = NewField66_.Value;
                    NewField67_.CalcValue = NewField67_.Value;
                    NewField68_.CalcValue = NewField68_.Value;
                    NewField99_.CalcValue = NewField99_.Value;
                    NewField69_.CalcValue = NewField69_.Value;
                    NewField70_.CalcValue = NewField70_.Value;
                    NewField76_.CalcValue = NewField76_.Value;
                    NewField77_.CalcValue = NewField77_.Value;
                    NewField78_.CalcValue = NewField78_.Value;
                    NewField79_.CalcValue = NewField79_.Value;
                    NewField80_.CalcValue = NewField80_.Value;
                    NewField81_.CalcValue = NewField81_.Value;
                    NewField82_.CalcValue = NewField82_.Value;
                    NewField100_.CalcValue = NewField100_.Value;
                    NewField83_.CalcValue = NewField83_.Value;
                    NewField84_.CalcValue = NewField84_.Value;
                    NewField85_.CalcValue = NewField85_.Value;
                    NewField86_.CalcValue = NewField86_.Value;
                    NewField87_.CalcValue = NewField87_.Value;
                    return new TTReportObject[] { NewField_,NewField51_,NewField61_,NewField71_,ILAVEBILGILER,NewField72_,NewField27_,NewField37_,NewField47_,NewField62_,NewField26_,NewField28_,NewField73_,NewField74_,NewField75_,NewField4_,NewField5_,NewField6_,NewField7_,NewField8_,NewField9_,NewField29_,NewField92_,NewField93_,NewField2_,NewField10_,NewField11_,NewField12_,NewField13_,NewField14_,NewField15_,NewField94_,NewField30_,NewField39_,NewField3_,NewField16_,NewField17_,NewField18_,NewField19_,NewField20_,NewField21_,NewField95_,NewField31_,NewField40_,NewField22_,NewField23_,NewField24_,NewField25_,NewField32_,NewField33_,NewField34_,NewField96_,NewField35_,NewField41_,NewField36_,NewField38_,NewField42_,NewField43_,NewField44_,NewField45_,NewField46_,NewField97_,NewField48_,NewField49_,NewField50_,NewField52_,NewField53_,NewField54_,NewField55_,NewField56_,NewField57_,NewField98_,NewField58_,NewField59_,NewField60_,NewField63_,NewField64_,NewField65_,NewField66_,NewField67_,NewField68_,NewField99_,NewField69_,NewField70_,NewField76_,NewField77_,NewField78_,NewField79_,NewField80_,NewField81_,NewField82_,NewField100_,NewField83_,NewField84_,NewField85_,NewField86_,NewField87_};
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public BirlikSeviyesiBakimFormu MyParentReport
            {
                get { return (BirlikSeviyesiBakimFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField KONTROLEDILECEKHUSUS { get {return Body().KONTROLEDILECEKHUSUS;} }
            public TTReportField NewField57 { get {return Body().NewField57;} }
            public TTReportField NewField75 { get {return Body().NewField75;} }
            public TTReportField NewField85 { get {return Body().NewField85;} }
            public TTReportField NewField67 { get {return Body().NewField67;} }
            public TTReportField NewField95 { get {return Body().NewField95;} }
            public TTReportField NewField77 { get {return Body().NewField77;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField87 { get {return Body().NewField87;} }
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
                public BirlikSeviyesiBakimFormu MyParentReport
                {
                    get { return (BirlikSeviyesiBakimFormu)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField KONTROLEDILECEKHUSUS;
                public TTReportField NewField57;
                public TTReportField NewField75;
                public TTReportField NewField85;
                public TTReportField NewField67;
                public TTReportField NewField95;
                public TTReportField NewField77;
                public TTReportField NewField6;
                public TTReportField NewField87; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 26, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 9;
                    SIRANO.TextFont.Bold = true;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"";

                    KONTROLEDILECEKHUSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 146, 6, false);
                    KONTROLEDILECEKHUSUS.Name = "KONTROLEDILECEKHUSUS";
                    KONTROLEDILECEKHUSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    KONTROLEDILECEKHUSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONTROLEDILECEKHUSUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KONTROLEDILECEKHUSUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KONTROLEDILECEKHUSUS.TextFont.Name = "Arial";
                    KONTROLEDILECEKHUSUS.TextFont.Size = 9;
                    KONTROLEDILECEKHUSUS.TextFont.Bold = true;
                    KONTROLEDILECEKHUSUS.TextFont.CharSet = 162;
                    KONTROLEDILECEKHUSUS.Value = @"";

                    NewField57 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 162, 6, false);
                    NewField57.Name = "NewField57";
                    NewField57.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField57.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField57.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField57.TextFont.Name = "Arial";
                    NewField57.TextFont.Size = 9;
                    NewField57.TextFont.Bold = true;
                    NewField57.TextFont.CharSet = 162;
                    NewField57.Value = @"";

                    NewField75 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 179, 6, false);
                    NewField75.Name = "NewField75";
                    NewField75.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField75.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField75.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField75.TextFont.Name = "Arial";
                    NewField75.TextFont.Size = 9;
                    NewField75.TextFont.Bold = true;
                    NewField75.TextFont.CharSet = 162;
                    NewField75.Value = @"";

                    NewField85 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 195, 6, false);
                    NewField85.Name = "NewField85";
                    NewField85.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField85.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField85.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField85.TextFont.Name = "Arial";
                    NewField85.TextFont.Size = 9;
                    NewField85.TextFont.Bold = true;
                    NewField85.TextFont.CharSet = 162;
                    NewField85.Value = @"";

                    NewField67 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 212, 6, false);
                    NewField67.Name = "NewField67";
                    NewField67.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField67.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField67.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField67.TextFont.Name = "Arial";
                    NewField67.TextFont.Size = 9;
                    NewField67.TextFont.Bold = true;
                    NewField67.TextFont.CharSet = 162;
                    NewField67.Value = @"";

                    NewField95 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 228, 6, false);
                    NewField95.Name = "NewField95";
                    NewField95.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField95.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField95.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField95.TextFont.Name = "Arial";
                    NewField95.TextFont.Size = 9;
                    NewField95.TextFont.Bold = true;
                    NewField95.TextFont.CharSet = 162;
                    NewField95.Value = @"";

                    NewField77 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 245, 6, false);
                    NewField77.Name = "NewField77";
                    NewField77.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField77.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField77.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField77.TextFont.Name = "Arial";
                    NewField77.TextFont.Size = 9;
                    NewField77.TextFont.Bold = true;
                    NewField77.TextFont.CharSet = 162;
                    NewField77.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 0, 261, 6, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"";

                    NewField87 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 0, 279, 6, false);
                    NewField87.Name = "NewField87";
                    NewField87.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField87.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField87.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField87.TextFont.Name = "Arial";
                    NewField87.TextFont.Size = 9;
                    NewField87.TextFont.Bold = true;
                    NewField87.TextFont.CharSet = 162;
                    NewField87.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIRANO.CalcValue = @"";
                    KONTROLEDILECEKHUSUS.CalcValue = @"";
                    NewField57.CalcValue = NewField57.Value;
                    NewField75.CalcValue = NewField75.Value;
                    NewField85.CalcValue = NewField85.Value;
                    NewField67.CalcValue = NewField67.Value;
                    NewField95.CalcValue = NewField95.Value;
                    NewField77.CalcValue = NewField77.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField87.CalcValue = NewField87.Value;
                    return new TTReportObject[] { SIRANO,KONTROLEDILECEKHUSUS,NewField57,NewField75,NewField85,NewField67,NewField95,NewField77,NewField6,NewField87};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BirlikSeviyesiBakimFormu()
        {
            Part1 = new Part1Group(this,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "BIRLIKSEVIYESIBAKIMFORMU";
            Caption = "Birlik Seviyesi Bakım Formu (Ek-4.12)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 10;
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