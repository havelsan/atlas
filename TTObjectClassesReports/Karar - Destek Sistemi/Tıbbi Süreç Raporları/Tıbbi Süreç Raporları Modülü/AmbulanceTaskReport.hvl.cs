
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
    public partial class AmbulanceTaskReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class headerGroup : TTReportGroup
        {
            public AmbulanceTaskReport MyParentReport
            {
                get { return (AmbulanceTaskReport)ParentReport; }
            }

            new public headerGroupHeader Header()
            {
                return (headerGroupHeader)_header;
            }

            new public headerGroupFooter Footer()
            {
                return (headerGroupFooter)_footer;
            }

            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField1113 { get {return Header().NewField1113;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine9 { get {return Header().NewLine9;} }
            public TTReportShape NewLine10 { get {return Header().NewLine10;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public headerGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public headerGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new headerGroupHeader(this);
                _footer = new headerGroupFooter(this);

            }

            public partial class headerGroupHeader : TTReportSection
            {
                public AmbulanceTaskReport MyParentReport
                {
                    get { return (AmbulanceTaskReport)ParentReport; }
                }
                
                public TTReportField NewField151;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField7;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField1113;
                public TTReportField NewField3;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField4;
                public TTReportField NewField15;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine9;
                public TTReportShape NewLine10;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18; 
                public headerGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 5, 209, 14, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Size = 14;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"AMBULANS GÖREV DEFTERİ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 17, 295, 17, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 55, 295, 55, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 25, 140, 53, false);
                    NewField7.Name = "NewField7";
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.Value = @"
RÜTBESİ, ADI SOYADI

BİRLİK / EV ADRESİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 26, 54, false);
                    NewField11.Name = "NewField11";
                    NewField11.FontAngle = 900;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11.Value = @"Görev Tarihi
";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 20, 41, 54, false);
                    NewField12.Name = "NewField12";
                    NewField12.FontAngle = 900;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12.Value = @"Çıkış Saati
";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 20, 34, 54, false);
                    NewField13.Name = "NewField13";
                    NewField13.FontAngle = 900;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField13.Value = @"Giriş Saati
";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 20, 48, 54, false);
                    NewField14.Name = "NewField14";
                    NewField14.FontAngle = 900;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField14.Value = @"Ambulansın Plakası
";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 20, 18, 54, false);
                    NewField1.Name = "NewField1";
                    NewField1.FontAngle = 900;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1.Value = @"Sıra No
";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 18, 78, 23, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.Value = @"Görev Türü";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 26, 56, 54, false);
                    NewField111.Name = "NewField111";
                    NewField111.FontAngle = 900;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111.Value = @"XXXXXX İÇİ
";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 26, 63, 54, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.FontAngle = 900;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HAVAALANI-XXXXXX
";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 26, 70, 54, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.FontAngle = 900;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1112.Value = @"PROTOKOL
";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 26, 78, 54, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.FontAngle = 900;
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1113.Value = @"DİĞER
";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 18, 153, 23, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.Value = @"HASTANIN";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 25, 148, 53, false);
                    NewField121.Name = "NewField121";
                    NewField121.FontAngle = 900;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121.Value = @"ALINDIĞI YER
";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 25, 156, 53, false);
                    NewField122.Name = "NewField122";
                    NewField122.FontAngle = 900;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField122.Value = @"BIRAKILDIĞI YER
";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 19, 227, 54, false);
                    NewField4.Name = "NewField4";
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.Value = @"GÖREVE GİDEN PERSONELİN
ADI SOYADI

1. AMBULANS ŞÖFÖRÜ

2.HEMŞİRE

3.TABİB";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 18, 294, 53, false);
                    NewField15.Name = "NewField15";
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.Value = @"ÇIKIŞ EMRİ VERENİN 
ADI SOYADI VE İMZASI

(GÖREV EMRİ VERENİN 
ADI SOYADI VE İRTİBAT NOSU)";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 17, 295, 55, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 228, 17, 228, 55, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 156, 17, 156, 55, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 24, 156, 24, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 24, 149, 55, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 24, 141, 55, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 79, 17, 79, 55, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 24, 71, 55, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 64, 24, 64, 55, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 24, 56, 55, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 17, 49, 55, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 17, 41, 55, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 17, 34, 55, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 27, 17, 27, 55, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 17, 11, 55, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 17, 19, 55, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField151.CalcValue = NewField151.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField15.CalcValue = NewField15.Value;
                    return new TTReportObject[] { NewField151,NewField7,NewField11,NewField12,NewField13,NewField14,NewField1,NewField2,NewField111,NewField1111,NewField1112,NewField1113,NewField3,NewField121,NewField122,NewField4,NewField15};
                }
            }
            public partial class headerGroupFooter : TTReportSection
            {
                public AmbulanceTaskReport MyParentReport
                {
                    get { return (AmbulanceTaskReport)ParentReport; }
                }
                 
                public headerGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public headerGroup header;

        public partial class MAINGroup : TTReportGroup
        {
            public AmbulanceTaskReport MyParentReport
            {
                get { return (AmbulanceTaskReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine101 { get {return Body().NewLine101;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public TTReportShape NewLine151 { get {return Body().NewLine151;} }
            public TTReportShape NewLine161 { get {return Body().NewLine161;} }
            public TTReportShape NewLine171 { get {return Body().NewLine171;} }
            public TTReportShape NewLine181 { get {return Body().NewLine181;} }
            public TTReportField PATIENTADDRESS { get {return Body().PATIENTADDRESS;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField ARRIVALREGION { get {return Body().ARRIVALREGION;} }
            public TTReportField COMMITTER { get {return Body().COMMITTER;} }
            public TTReportField DUTYDATE { get {return Body().DUTYDATE;} }
            public TTReportField EXITTIME { get {return Body().EXITTIME;} }
            public TTReportField STARTREGION { get {return Body().STARTREGION;} }
            public TTReportField COMMITTERTELNO { get {return Body().COMMITTERTELNO;} }
            public TTReportField MILITARYUNITNAME { get {return Body().MILITARYUNITNAME;} }
            public TTReportField PATIENTRANKNAME { get {return Body().PATIENTRANKNAME;} }
            public TTReportField PLATE { get {return Body().PLATE;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField GorevTuru1 { get {return Body().GorevTuru1;} }
            public TTReportField GorevTuru2 { get {return Body().GorevTuru2;} }
            public TTReportField GorevTuru3 { get {return Body().GorevTuru3;} }
            public TTReportField GorevTuru4 { get {return Body().GorevTuru4;} }
            public TTReportField DUTYTYPE { get {return Body().DUTYTYPE;} }
            public TTReportField RETURNTIME { get {return Body().RETURNTIME;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField Personeller { get {return Body().Personeller;} }
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
                list[0] = new TTReportNqlData<Ambulance.GetAmbulanceNQL_Class>("GetAmbulanceNQL", Ambulance.GetAmbulanceNQL((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.StartDate),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.EndDate)));
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
                public AmbulanceTaskReport MyParentReport
                {
                    get { return (AmbulanceTaskReport)ParentReport; }
                }
                
                public TTReportShape NewLine4;
                public TTReportShape NewLine111;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine101;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine151;
                public TTReportShape NewLine161;
                public TTReportShape NewLine171;
                public TTReportShape NewLine181;
                public TTReportField PATIENTADDRESS;
                public TTReportField PATIENTNAME;
                public TTReportShape NewLine1;
                public TTReportField ARRIVALREGION;
                public TTReportField COMMITTER;
                public TTReportField DUTYDATE;
                public TTReportField EXITTIME;
                public TTReportField STARTREGION;
                public TTReportField COMMITTERTELNO;
                public TTReportField MILITARYUNITNAME;
                public TTReportField PATIENTRANKNAME;
                public TTReportField PLATE;
                public TTReportField PROTOCOLNO;
                public TTReportField GorevTuru1;
                public TTReportField GorevTuru2;
                public TTReportField GorevTuru3;
                public TTReportField GorevTuru4;
                public TTReportField DUTYTYPE;
                public TTReportField RETURNTIME;
                public TTReportField OBJECTID;
                public TTReportField Personeller; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 46, 49, 46, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 38, 295, 38, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 228, 0, 228, 38, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 156, 0, 156, 38, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 0, 149, 38, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 0, 141, 38, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 79, 0, 79, 38, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 0, 71, 38, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine101 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 64, 0, 64, 38, false);
                    NewLine101.Name = "NewLine101";
                    NewLine101.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 0, 56, 38, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 49, 0, 49, 38, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 0, 41, 38, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 38, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 27, 0, 27, 38, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 0, 11, 38, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 38, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    PATIENTADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 23, 139, 28, false);
                    PATIENTADDRESS.Name = "PATIENTADDRESS";
                    PATIENTADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.Value = @"{#PATIENTADDRESS#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 6, 139, 11, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.Value = @"{#PATIENTNAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 0, 295, 38, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    ARRIVALREGION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 1, 156, 37, false);
                    ARRIVALREGION.Name = "ARRIVALREGION";
                    ARRIVALREGION.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRIVALREGION.FontAngle = 900;
                    ARRIVALREGION.VertAlign = VerticalAlignmentEnum.vaBottom;
                    ARRIVALREGION.Value = @"{#ARRIVALREGION#}";

                    COMMITTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 1, 294, 6, false);
                    COMMITTER.Name = "COMMITTER";
                    COMMITTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMMITTER.MultiLine = EvetHayirEnum.ehEvet;
                    COMMITTER.NoClip = EvetHayirEnum.ehEvet;
                    COMMITTER.WordBreak = EvetHayirEnum.ehEvet;
                    COMMITTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    COMMITTER.Value = @"{#COMMITTER#}";

                    DUTYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 26, 37, false);
                    DUTYDATE.Name = "DUTYDATE";
                    DUTYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUTYDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    DUTYDATE.FontAngle = 900;
                    DUTYDATE.VertAlign = VerticalAlignmentEnum.vaBottom;
                    DUTYDATE.Value = @"{#DUTYDATE#}";

                    EXITTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 40, 37, false);
                    EXITTIME.Name = "EXITTIME";
                    EXITTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXITTIME.TextFormat = @"dd/MM/yyyy HH:mm";
                    EXITTIME.FontAngle = 900;
                    EXITTIME.VertAlign = VerticalAlignmentEnum.vaBottom;
                    EXITTIME.Value = @"{#EXITTIME#}";

                    STARTREGION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 148, 37, false);
                    STARTREGION.Name = "STARTREGION";
                    STARTREGION.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTREGION.FontAngle = 900;
                    STARTREGION.VertAlign = VerticalAlignmentEnum.vaBottom;
                    STARTREGION.Value = @"{#STARTREGION#}";

                    COMMITTERTELNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 9, 294, 14, false);
                    COMMITTERTELNO.Name = "COMMITTERTELNO";
                    COMMITTERTELNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMMITTERTELNO.MultiLine = EvetHayirEnum.ehEvet;
                    COMMITTERTELNO.NoClip = EvetHayirEnum.ehEvet;
                    COMMITTERTELNO.WordBreak = EvetHayirEnum.ehEvet;
                    COMMITTERTELNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    COMMITTERTELNO.Value = @"{#COMMITTERTELNO#}";

                    MILITARYUNITNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 12, 139, 17, false);
                    MILITARYUNITNAME.Name = "MILITARYUNITNAME";
                    MILITARYUNITNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNITNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNITNAME.NoClip = EvetHayirEnum.ehEvet;
                    MILITARYUNITNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNITNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    MILITARYUNITNAME.Value = @"{#MILITARYUNITNAME#}";

                    PATIENTRANKNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 139, 6, false);
                    PATIENTRANKNAME.Name = "PATIENTRANKNAME";
                    PATIENTRANKNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTRANKNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTRANKNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTRANKNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTRANKNAME.Value = @"{#PATIENTRANKNAME#}";

                    PLATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 47, 37, false);
                    PLATE.Name = "PLATE";
                    PLATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PLATE.FontAngle = 900;
                    PLATE.VertAlign = VerticalAlignmentEnum.vaBottom;
                    PLATE.Value = @"{#PLATE#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 18, 37, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.FontAngle = 900;
                    PROTOCOLNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    PROTOCOLNO.Value = @"{#PROTOCOLNO#}";

                    GorevTuru1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 13, 55, 24, false);
                    GorevTuru1.Name = "GorevTuru1";
                    GorevTuru1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GorevTuru1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    GorevTuru1.Value = @"";

                    GorevTuru2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 13, 63, 24, false);
                    GorevTuru2.Name = "GorevTuru2";
                    GorevTuru2.FieldType = ReportFieldTypeEnum.ftVariable;
                    GorevTuru2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    GorevTuru2.Value = @"";

                    GorevTuru3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 13, 70, 24, false);
                    GorevTuru3.Name = "GorevTuru3";
                    GorevTuru3.FieldType = ReportFieldTypeEnum.ftVariable;
                    GorevTuru3.VertAlign = VerticalAlignmentEnum.vaBottom;
                    GorevTuru3.Value = @"";

                    GorevTuru4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 13, 78, 24, false);
                    GorevTuru4.Name = "GorevTuru4";
                    GorevTuru4.FieldType = ReportFieldTypeEnum.ftVariable;
                    GorevTuru4.VertAlign = VerticalAlignmentEnum.vaBottom;
                    GorevTuru4.Value = @"";

                    DUTYTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 29, 290, 34, false);
                    DUTYTYPE.Name = "DUTYTYPE";
                    DUTYTYPE.Visible = EvetHayirEnum.ehHayir;
                    DUTYTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUTYTYPE.Value = @"{#DUTYTYPE#}";

                    RETURNTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 33, 37, false);
                    RETURNTIME.Name = "RETURNTIME";
                    RETURNTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETURNTIME.TextFormat = @"dd/MM/yyyy HH:mm";
                    RETURNTIME.FontAngle = 900;
                    RETURNTIME.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RETURNTIME.Value = @"{#RETURNTIME#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 29, 260, 34, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    Personeller = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 227, 6, false);
                    Personeller.Name = "Personeller";
                    Personeller.FieldType = ReportFieldTypeEnum.ftVariable;
                    Personeller.MultiLine = EvetHayirEnum.ehEvet;
                    Personeller.NoClip = EvetHayirEnum.ehEvet;
                    Personeller.WordBreak = EvetHayirEnum.ehEvet;
                    Personeller.ExpandTabs = EvetHayirEnum.ehEvet;
                    Personeller.TextFont.Size = 9;
                    Personeller.TextFont.CharSet = 162;
                    Personeller.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Ambulance.GetAmbulanceNQL_Class dataset_GetAmbulanceNQL = ParentGroup.rsGroup.GetCurrentRecord<Ambulance.GetAmbulanceNQL_Class>(0);
                    PATIENTADDRESS.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.PatientAddress) : "");
                    PATIENTNAME.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.PatientName) : "");
                    ARRIVALREGION.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.ArrivalRegion) : "");
                    COMMITTER.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.Committer) : "");
                    DUTYDATE.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.DutyDate) : "");
                    EXITTIME.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.ExitTime) : "");
                    STARTREGION.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.StartRegion) : "");
                    COMMITTERTELNO.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.CommitterTelNo) : "");
                    MILITARYUNITNAME.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.Militaryunitname) : "");
                    PATIENTRANKNAME.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.Patientrankname) : "");
                    PLATE.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.Plate) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.ProtocolNo) : "");
                    GorevTuru1.CalcValue = @"";
                    GorevTuru2.CalcValue = @"";
                    GorevTuru3.CalcValue = @"";
                    GorevTuru4.CalcValue = @"";
                    DUTYTYPE.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.DutyType) : "");
                    RETURNTIME.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.ReturnTime) : "");
                    OBJECTID.CalcValue = (dataset_GetAmbulanceNQL != null ? Globals.ToStringCore(dataset_GetAmbulanceNQL.ObjectID) : "");
                    Personeller.CalcValue = @"";
                    return new TTReportObject[] { PATIENTADDRESS,PATIENTNAME,ARRIVALREGION,COMMITTER,DUTYDATE,EXITTIME,STARTREGION,COMMITTERTELNO,MILITARYUNITNAME,PATIENTRANKNAME,PLATE,PROTOCOLNO,GorevTuru1,GorevTuru2,GorevTuru3,GorevTuru4,DUTYTYPE,RETURNTIME,OBJECTID,Personeller};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string dutyTypeName = this.DUTYTYPE.CalcValue.ToString();
                    string sObjectID = this.OBJECTID.CalcValue.ToString();
                    if (!string.IsNullOrEmpty(dutyTypeName))
                    {


                        switch (dutyTypeName)
                        {
                            case "InHospital":
                                this.GorevTuru1.CalcValue = "X";
                                this.GorevTuru2.CalcValue = "";
                                this.GorevTuru3.CalcValue = "";
                                this.GorevTuru4.CalcValue = "";
                                break;
                            case "Aitport":
                                this.GorevTuru1.CalcValue = "";
                                this.GorevTuru2.CalcValue = "X";
                                this.GorevTuru3.CalcValue = "";
                                this.GorevTuru4.CalcValue = "";
                                break;
                            case "Protocol":
                                this.GorevTuru1.CalcValue = "";
                                this.GorevTuru2.CalcValue = "";
                                this.GorevTuru3.CalcValue = "X";
                                this.GorevTuru4.CalcValue = "";
                                break;
                            case "Other":
                                this.GorevTuru1.CalcValue = "";
                                this.GorevTuru2.CalcValue = "";
                                this.GorevTuru3.CalcValue = "";
                                this.GorevTuru4.CalcValue = "X";
                                break;
                            default:
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(sObjectID))
                    {

                        BindingList<AmbulancePersonnel.GetAmbulancePersonnelNQL_Class> ambulancePersonnel = AmbulancePersonnel.GetAmbulancePersonnelNQL(sObjectID);
                        if (ambulancePersonnel.Count > 0)
                        {
                            int i = 0;
                            foreach (AmbulancePersonnel.GetAmbulancePersonnelNQL_Class personel in ambulancePersonnel)
                            {
                                i++;
                                 this.Personeller.CalcValue += i + ". " + personel.Name + " " + personel.Surname + " "+"("+personel.Work+")\n";
                            }
                            i = 0;
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

        public AmbulanceTaskReport()
        {
            header = new headerGroup(this,"header");
            MAIN = new MAINGroup(header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("StartDate", "", "Görev Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("EndDate", "", "Görev Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("StartDate"))
                _runtimeParameters.StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["StartDate"]);
            if (parameters.ContainsKey("EndDate"))
                _runtimeParameters.EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["EndDate"]);
            Name = "AMBULANCETASKREPORT";
            Caption = "Ambulans Görev Defteri";
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