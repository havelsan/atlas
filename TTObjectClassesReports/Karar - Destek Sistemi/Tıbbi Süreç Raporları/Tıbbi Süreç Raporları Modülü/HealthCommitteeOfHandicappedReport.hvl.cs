
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
    /// Sağlık Kurulu Özürlü Raporu
    /// </summary>
    public partial class HealthCommitteeOfHandicappedReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public HealthCommitteeOfHandicappedReport MyParentReport
            {
                get { return (HealthCommitteeOfHandicappedReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField S3 { get {return Footer().S3;} }
            public TTReportField S4 { get {return Footer().S4;} }
            public TTReportField S5 { get {return Footer().S5;} }
            public TTReportField S1 { get {return Footer().S1;} }
            public TTReportField S2 { get {return Footer().S2;} }
            public TTReportField S6 { get {return Footer().S6;} }
            public TTReportField SKBASKANI { get {return Footer().SKBASKANI;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public TTReportField NewField7 { get {return Footer().NewField7;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField YCIHAZI { get {return Footer().YCIHAZI;} }
            public TTReportField ORTEZPROTEZ { get {return Footer().ORTEZPROTEZ;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportShape NewLine4 { get {return Footer().NewLine4;} }
            public TTReportShape NewLine5 { get {return Footer().NewLine5;} }
            public TTReportShape NewLine6 { get {return Footer().NewLine6;} }
            public TTReportShape NewLine7 { get {return Footer().NewLine7;} }
            public TTReportShape NewLine8 { get {return Footer().NewLine8;} }
            public TTReportShape NewLine9 { get {return Footer().NewLine9;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportField NewField27 { get {return Footer().NewField27;} }
            public TTReportField NewField28 { get {return Footer().NewField28;} }
            public TTReportShape NewLine15 { get {return Footer().NewLine15;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public TTReportField RAPORSAYISI89 { get {return Footer().RAPORSAYISI89;} }
            public TTReportField SUREKLI { get {return Footer().SUREKLI;} }
            public TTReportField BASTABIP { get {return Footer().BASTABIP;} }
            public TTReportField NewField { get {return Footer().NewField;} }
            public TTReportField RAPORSAYISI191 { get {return Footer().RAPORSAYISI191;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField101 { get {return Footer().NewField101;} }
            public TTReportField SUREKLI1 { get {return Footer().SUREKLI1;} }
            public TTReportField NewField1101 { get {return Footer().NewField1101;} }
            public TTReportField SUREKLI2 { get {return Footer().SUREKLI2;} }
            public TTReportField NewField1102 { get {return Footer().NewField1102;} }
            public TTReportField SUREKLI11 { get {return Footer().SUREKLI11;} }
            public TTReportField NewField11011 { get {return Footer().NewField11011;} }
            public TTReportField SUREKLI3 { get {return Footer().SUREKLI3;} }
            public TTReportField NewField1103 { get {return Footer().NewField1103;} }
            public TTReportField SUREKLI12 { get {return Footer().SUREKLI12;} }
            public TTReportField NewField11012 { get {return Footer().NewField11012;} }
            public TTReportField SUREKLI13 { get {return Footer().SUREKLI13;} }
            public TTReportField NewField12011 { get {return Footer().NewField12011;} }
            public TTReportField SUREKLI111 { get {return Footer().SUREKLI111;} }
            public TTReportField NewField111011 { get {return Footer().NewField111011;} }
            public TTReportField MEMBERS { get {return Footer().MEMBERS;} }
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
                public HealthCommitteeOfHandicappedReport MyParentReport
                {
                    get { return (HealthCommitteeOfHandicappedReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField XXXXXXBASLIK; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 9, 197, 24, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%XXXXXXBASLIK%}
ÖZÜRLÜ SAĞLIK KURULU RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 9, 302, 15, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HEADER.CalcValue = MyParentReport.HEADER.XXXXXXBASLIK.CalcValue + @"
ÖZÜRLÜ SAĞLIK KURULU RAPORU";
                    return new TTReportObject[] { XXXXXXBASLIK,HEADER};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public HealthCommitteeOfHandicappedReport MyParentReport
                {
                    get { return (HealthCommitteeOfHandicappedReport)ParentReport; }
                }
                
                public TTReportField S3;
                public TTReportField S4;
                public TTReportField S5;
                public TTReportField S1;
                public TTReportField S2;
                public TTReportField S6;
                public TTReportField SKBASKANI;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField YCIHAZI;
                public TTReportField ORTEZPROTEZ;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine9;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportField RAPORSAYISI89;
                public TTReportField SUREKLI;
                public TTReportField BASTABIP;
                public TTReportField NewField;
                public TTReportField RAPORSAYISI191;
                public TTReportField NewField16;
                public TTReportField NewField101;
                public TTReportField SUREKLI1;
                public TTReportField NewField1101;
                public TTReportField SUREKLI2;
                public TTReportField NewField1102;
                public TTReportField SUREKLI11;
                public TTReportField NewField11011;
                public TTReportField SUREKLI3;
                public TTReportField NewField1103;
                public TTReportField SUREKLI12;
                public TTReportField NewField11012;
                public TTReportField SUREKLI13;
                public TTReportField NewField12011;
                public TTReportField SUREKLI111;
                public TTReportField NewField111011;
                public TTReportField MEMBERS; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 202;
                    RepeatCount = 0;
                    
                    S3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 126, 188, 134, false);
                    S3.Name = "S3";
                    S3.Visible = EvetHayirEnum.ehHayir;
                    S3.FieldType = ReportFieldTypeEnum.ftVariable;
                    S3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S3.MultiLine = EvetHayirEnum.ehEvet;
                    S3.WordBreak = EvetHayirEnum.ehEvet;
                    S3.ExpandTabs = EvetHayirEnum.ehEvet;
                    S3.TextFont.Name = "Arial Narrow";
                    S3.TextFont.Size = 8;
                    S3.Value = @"";

                    S4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 147, 67, 155, false);
                    S4.Name = "S4";
                    S4.Visible = EvetHayirEnum.ehHayir;
                    S4.FieldType = ReportFieldTypeEnum.ftVariable;
                    S4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S4.MultiLine = EvetHayirEnum.ehEvet;
                    S4.WordBreak = EvetHayirEnum.ehEvet;
                    S4.ExpandTabs = EvetHayirEnum.ehEvet;
                    S4.TextFont.Name = "Arial Narrow";
                    S4.TextFont.Size = 8;
                    S4.Value = @"";

                    S5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 147, 128, 155, false);
                    S5.Name = "S5";
                    S5.Visible = EvetHayirEnum.ehHayir;
                    S5.FieldType = ReportFieldTypeEnum.ftVariable;
                    S5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S5.MultiLine = EvetHayirEnum.ehEvet;
                    S5.WordBreak = EvetHayirEnum.ehEvet;
                    S5.ExpandTabs = EvetHayirEnum.ehEvet;
                    S5.TextFont.Name = "Arial Narrow";
                    S5.TextFont.Size = 8;
                    S5.Value = @"";

                    S1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 126, 67, 134, false);
                    S1.Name = "S1";
                    S1.Visible = EvetHayirEnum.ehHayir;
                    S1.FieldType = ReportFieldTypeEnum.ftVariable;
                    S1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S1.MultiLine = EvetHayirEnum.ehEvet;
                    S1.WordBreak = EvetHayirEnum.ehEvet;
                    S1.ExpandTabs = EvetHayirEnum.ehEvet;
                    S1.TextFont.Name = "Arial Narrow";
                    S1.TextFont.Size = 8;
                    S1.Value = @"";

                    S2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 126, 128, 134, false);
                    S2.Name = "S2";
                    S2.Visible = EvetHayirEnum.ehHayir;
                    S2.FieldType = ReportFieldTypeEnum.ftVariable;
                    S2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S2.MultiLine = EvetHayirEnum.ehEvet;
                    S2.WordBreak = EvetHayirEnum.ehEvet;
                    S2.ExpandTabs = EvetHayirEnum.ehEvet;
                    S2.TextFont.Name = "Arial Narrow";
                    S2.TextFont.Size = 8;
                    S2.Value = @"";

                    S6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 147, 188, 155, false);
                    S6.Name = "S6";
                    S6.Visible = EvetHayirEnum.ehHayir;
                    S6.FieldType = ReportFieldTypeEnum.ftVariable;
                    S6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    S6.MultiLine = EvetHayirEnum.ehEvet;
                    S6.WordBreak = EvetHayirEnum.ehEvet;
                    S6.ExpandTabs = EvetHayirEnum.ehEvet;
                    S6.TextFont.Name = "Arial Narrow";
                    S6.TextFont.Size = 8;
                    S6.Value = @"";

                    SKBASKANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 176, 128, 184, false);
                    SKBASKANI.Name = "SKBASKANI";
                    SKBASKANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKBASKANI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SKBASKANI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SKBASKANI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SKBASKANI.MultiLine = EvetHayirEnum.ehEvet;
                    SKBASKANI.WordBreak = EvetHayirEnum.ehEvet;
                    SKBASKANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SKBASKANI.TextFont.Name = "Arial Narrow";
                    SKBASKANI.TextFont.Size = 8;
                    SKBASKANI.Value = @"";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 53, 202, 53, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 61, 202, 61, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 54, 95, 59, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"SONUÇ";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 54, 190, 59, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"SONUÇ";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 62, 63, 67, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.Value = @"H sınıfı ehliyet alabilir                                                ";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 73, 63, 78, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.Value = @"Özel tertibatlı araç kullanabilir.                                          ";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 103, 38, 108, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.Value = @"Diğer: (Açıklayınız)                                             ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 93, 159, 101, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"Özel eğitim amaçlı 
değerlendirilmesi uygundur.                                         ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 83, 159, 91, false);
                    NewField11.Name = "NewField11";
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.Value = @"Tekerlekli sandalye kullanması
gereklidir.                                               ";

                    YCIHAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 73, 159, 81, false);
                    YCIHAZI.Name = "YCIHAZI";
                    YCIHAZI.MultiLine = EvetHayirEnum.ehEvet;
                    YCIHAZI.WordBreak = EvetHayirEnum.ehEvet;
                    YCIHAZI.TextFont.Name = "Arial Narrow";
                    YCIHAZI.Value = @"................  yardımcı cihazı kullanması gereklidir                                               ";

                    ORTEZPROTEZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 63, 159, 71, false);
                    ORTEZPROTEZ.Name = "ORTEZPROTEZ";
                    ORTEZPROTEZ.MultiLine = EvetHayirEnum.ehEvet;
                    ORTEZPROTEZ.WordBreak = EvetHayirEnum.ehEvet;
                    ORTEZPROTEZ.TextFont.Name = "Arial Narrow";
                    ORTEZPROTEZ.Value = @"................................ ortezi/protezi 
kullanması gereklidir.                                                                      ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 93, 63, 98, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.Value = @"İşitme cihazı kullanması gereklidir.                                            ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 83, 63, 88, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.Value = @"Akülü araç kullanması gereklidir.                                                                                             ";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 72, 202, 72, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 82, 202, 82, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 92, 202, 92, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 102, 202, 102, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 115, 202, 115, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 53, 8, 115, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 53, 202, 115, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 65, 53, 65, 102, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 53, 103, 102, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 53, 160, 102, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 124, 202, 124, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 192, 202, 192, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 170, 128, 175, false);
                    NewField27.Name = "NewField27";
                    NewField27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField27.TextFont.Name = "Arial Narrow";
                    NewField27.TextFont.Size = 8;
                    NewField27.TextFont.Bold = true;
                    NewField27.Value = @"Kurul Başkanı";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 186, 81, 191, false);
                    NewField28.Name = "NewField28";
                    NewField28.TextFont.Name = "Arial Narrow";
                    NewField28.Value = @"Oybirliği/Oyçokluğu ile karar verilmiştir.";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 124, 8, 192, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 124, 202, 192, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI89 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 83, 11, false);
                    RAPORSAYISI89.Name = "RAPORSAYISI89";
                    RAPORSAYISI89.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI89.TextFont.Size = 9;
                    RAPORSAYISI89.TextFont.Bold = true;
                    RAPORSAYISI89.Value = @"KİŞİNİN ÖZÜR GRUBU:";

                    SUREKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 13, 89, 17, false);
                    SUREKLI.Name = "SUREKLI";
                    SUREKLI.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI.Value = @"";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 176, 186, 184, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASTABIP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASTABIP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial Narrow";
                    BASTABIP.TextFont.Size = 8;
                    BASTABIP.Value = @"";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 170, 186, 175, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 8;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Başhekim";

                    RAPORSAYISI191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 47, 184, 52, false);
                    RAPORSAYISI191.Name = "RAPORSAYISI191";
                    RAPORSAYISI191.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI191.TextFont.Size = 9;
                    RAPORSAYISI191.TextFont.Bold = true;
                    RAPORSAYISI191.Value = @"RAPORUN KULLANIM AMACI (EVET,HAYIR VEYA DEĞERLENDİRİLMEDİ  ŞEKLİNDE MUTLAKA BELİRTİNİZ):";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 119, 20, 123, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.Value = @"ONAY:";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 34, 17, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Size = 8;
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @"Ortopedik";

                    SUREKLI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 20, 89, 24, false);
                    SUREKLI1.Name = "SUREKLI1";
                    SUREKLI1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI1.Value = @"";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 34, 24, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.TextFont.Name = "Arial";
                    NewField1101.TextFont.Size = 8;
                    NewField1101.TextFont.Bold = true;
                    NewField1101.Value = @"Görme";

                    SUREKLI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 27, 89, 31, false);
                    SUREKLI2.Name = "SUREKLI2";
                    SUREKLI2.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI2.Value = @"";

                    NewField1102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 27, 34, 31, false);
                    NewField1102.Name = "NewField1102";
                    NewField1102.TextFont.Name = "Arial";
                    NewField1102.TextFont.Size = 8;
                    NewField1102.TextFont.Bold = true;
                    NewField1102.Value = @"İşitme";

                    SUREKLI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 34, 89, 38, false);
                    SUREKLI11.Name = "SUREKLI11";
                    SUREKLI11.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI11.Value = @"";

                    NewField11011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 34, 38, false);
                    NewField11011.Name = "NewField11011";
                    NewField11011.TextFont.Name = "Arial";
                    NewField11011.TextFont.Size = 8;
                    NewField11011.TextFont.Bold = true;
                    NewField11011.Value = @"Dil ve Konuşma";

                    SUREKLI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 13, 188, 17, false);
                    SUREKLI3.Name = "SUREKLI3";
                    SUREKLI3.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI3.Value = @"";

                    NewField1103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 13, 137, 17, false);
                    NewField1103.Name = "NewField1103";
                    NewField1103.TextFont.Name = "Arial";
                    NewField1103.TextFont.Size = 8;
                    NewField1103.TextFont.Bold = true;
                    NewField1103.Value = @"Zihinsel";

                    SUREKLI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 20, 188, 24, false);
                    SUREKLI12.Name = "SUREKLI12";
                    SUREKLI12.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI12.Value = @"";

                    NewField11012 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 20, 137, 24, false);
                    NewField11012.Name = "NewField11012";
                    NewField11012.TextFont.Name = "Arial";
                    NewField11012.TextFont.Size = 8;
                    NewField11012.TextFont.Bold = true;
                    NewField11012.Value = @"Ruhsal ve Duygusal";

                    SUREKLI13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 27, 188, 31, false);
                    SUREKLI13.Name = "SUREKLI13";
                    SUREKLI13.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI13.Value = @"";

                    NewField12011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 27, 137, 31, false);
                    NewField12011.Name = "NewField12011";
                    NewField12011.TextFont.Name = "Arial";
                    NewField12011.TextFont.Size = 8;
                    NewField12011.TextFont.Bold = true;
                    NewField12011.Value = @"Süreğen (Kronik)";

                    SUREKLI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 34, 188, 38, false);
                    SUREKLI111.Name = "SUREKLI111";
                    SUREKLI111.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI111.Value = @"";

                    NewField111011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 34, 137, 38, false);
                    NewField111011.Name = "NewField111011";
                    NewField111011.TextFont.Name = "Arial";
                    NewField111011.TextFont.Size = 8;
                    NewField111011.TextFont.Bold = true;
                    NewField111011.Value = @"Sınıflanamayan";

                    MEMBERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 125, 199, 168, false);
                    MEMBERS.Name = "MEMBERS";
                    MEMBERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBERS.MultiLine = EvetHayirEnum.ehEvet;
                    MEMBERS.WordBreak = EvetHayirEnum.ehEvet;
                    MEMBERS.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEMBERS.TextFont.Size = 8;
                    MEMBERS.TextFont.Bold = true;
                    MEMBERS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    S3.CalcValue = @"";
                    S4.CalcValue = @"";
                    S5.CalcValue = @"";
                    S1.CalcValue = @"";
                    S2.CalcValue = @"";
                    S6.CalcValue = @"";
                    SKBASKANI.CalcValue = @"";
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    YCIHAZI.CalcValue = YCIHAZI.Value;
                    ORTEZPROTEZ.CalcValue = ORTEZPROTEZ.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    RAPORSAYISI89.CalcValue = RAPORSAYISI89.Value;
                    SUREKLI.CalcValue = SUREKLI.Value;
                    BASTABIP.CalcValue = @"";
                    NewField.CalcValue = NewField.Value;
                    RAPORSAYISI191.CalcValue = RAPORSAYISI191.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField101.CalcValue = NewField101.Value;
                    SUREKLI1.CalcValue = SUREKLI1.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    SUREKLI2.CalcValue = SUREKLI2.Value;
                    NewField1102.CalcValue = NewField1102.Value;
                    SUREKLI11.CalcValue = SUREKLI11.Value;
                    NewField11011.CalcValue = NewField11011.Value;
                    SUREKLI3.CalcValue = SUREKLI3.Value;
                    NewField1103.CalcValue = NewField1103.Value;
                    SUREKLI12.CalcValue = SUREKLI12.Value;
                    NewField11012.CalcValue = NewField11012.Value;
                    SUREKLI13.CalcValue = SUREKLI13.Value;
                    NewField12011.CalcValue = NewField12011.Value;
                    SUREKLI111.CalcValue = SUREKLI111.Value;
                    NewField111011.CalcValue = NewField111011.Value;
                    MEMBERS.CalcValue = @"";
                    return new TTReportObject[] { S3,S4,S5,S1,S2,S6,SKBASKANI,NewField5,NewField6,NewField7,NewField8,NewField9,NewField1,NewField11,YCIHAZI,ORTEZPROTEZ,NewField14,NewField15,NewField27,NewField28,RAPORSAYISI89,SUREKLI,BASTABIP,NewField,RAPORSAYISI191,NewField16,NewField101,SUREKLI1,NewField1101,SUREKLI2,NewField1102,SUREKLI11,NewField11011,SUREKLI3,NewField1103,SUREKLI12,NewField11012,SUREKLI13,NewField12011,SUREKLI111,NewField111011,MEMBERS};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeOfHandicappedReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            /*Tanı
            int nCount = 1;
            this.TESHIS.CalcValue = "";
            BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> pDiagnosis = HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID(sObjectID);
            foreach(HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class pGrid in pDiagnosis)
            {
                this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TESHIS.CalcValue += "\r\n";
                nCount++;
            }
             */
            
            //Baştabip and SK Başkanı
            string sCrLf = "\r\n";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.ChiefOfMedicine)
                {
                    string sTitle1 = (member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.Name);
                    sTitle1 += " " + (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.Name);
                    string sMasterText = member.MemberDoctor.Name + sCrLf + sTitle1;

                    this.BASTABIP.CalcValue = sMasterText;
                }

                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MasterOfHealthCommittee)
                {
                    string sTitle1 = (member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.Name);
                    sTitle1 += " " + (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.Name);
                    string sMasterText = member.MemberDoctor.Name + sCrLf + sTitle1;

                    this.SKBASKANI.CalcValue = sMasterText;
                }
                //Members
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MemberOfHealthCommittee)
                {
                    string sMembersText = sCrLf;
                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "";

                    const int COLUMN_COUNT = 3;
                    const int SPACE_COUNT = 60;
                    int nCounter = 0;
                    int nRow = 0;

                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                    
                    sMemberName = member.MemberDoctor.Name;
                    sMemberMilClass = member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.Name;
                    sMemberRank = member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.Name;
                    sMemberTitle = !member.MemberDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(member.MemberDoctor.Title.Value);

                    sNameRow = sNameRow.Insert(nCounter, sMemberName);
                    sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberRank);
                    sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);

                    nCounter += SPACE_COUNT;

                    nRow = nCounter / SPACE_COUNT;
                    int nRate = nRow % COLUMN_COUNT;
                    if (nRate == 0)
                    {
                        sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sNameRow + "\r\n";
                        sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sRankRow + "\r\n";
                        sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sTitleRow + "\r\n";

                        sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                        sMembersText += sCrLf + sCrLf + sCrLf;
                        nCounter = 0;
                    }
                    

                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sNameRow + "\r\n";
                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sRankRow + "\r\n";
                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sTitleRow + "\r\n";

                    this.MEMBERS.CalcValue = sMembersText;
                }
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeOfHandicappedReport MyParentReport
            {
                get { return (HealthCommitteeOfHandicappedReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportField RAPORSAYISI { get {return Body().RAPORSAYISI;} }
            public TTReportField RAPORSAYISI2 { get {return Body().RAPORSAYISI2;} }
            public TTReportField RAPORSAYISI3 { get {return Body().RAPORSAYISI3;} }
            public TTReportField RAPORSAYISI6 { get {return Body().RAPORSAYISI6;} }
            public TTReportField RAPORSAYISI8 { get {return Body().RAPORSAYISI8;} }
            public TTReportField RAPORSAYISI10 { get {return Body().RAPORSAYISI10;} }
            public TTReportField RAPORSAYISI11 { get {return Body().RAPORSAYISI11;} }
            public TTReportField RAPORSAYISI12 { get {return Body().RAPORSAYISI12;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField MURTAR { get {return Body().MURTAR;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField RAPORSAYISI19 { get {return Body().RAPORSAYISI19;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField RAPORSAYISI9 { get {return Body().RAPORSAYISI9;} }
            public TTReportField RAPORSAYISI7 { get {return Body().RAPORSAYISI7;} }
            public TTReportField RAPORSAYISI91 { get {return Body().RAPORSAYISI91;} }
            public TTReportField RAPORSAYISI20 { get {return Body().RAPORSAYISI20;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportShape NewRect6 { get {return Body().NewRect6;} }
            public TTReportField YIL { get {return Body().YIL;} }
            public TTReportField RAPORSAYISI16 { get {return Body().RAPORSAYISI16;} }
            public TTReportField RAPORSAYISI13 { get {return Body().RAPORSAYISI13;} }
            public TTReportField RAPORSAYISI4 { get {return Body().RAPORSAYISI4;} }
            public TTReportField H01 { get {return Body().H01;} }
            public TTReportField CKURUM { get {return Body().CKURUM;} }
            public TTReportField KISISEL { get {return Body().KISISEL;} }
            public TTReportField RAPORNO2 { get {return Body().RAPORNO2;} }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportShape NewLine29 { get {return Body().NewLine29;} }
            public TTReportShape NewLine31 { get {return Body().NewLine31;} }
            public TTReportShape NewLine32 { get {return Body().NewLine32;} }
            public TTReportField RAPORSAYISI5 { get {return Body().RAPORSAYISI5;} }
            public TTReportField RAPORSAYISI21 { get {return Body().RAPORSAYISI21;} }
            public TTReportField RAPORSAYISI17 { get {return Body().RAPORSAYISI17;} }
            public TTReportField RAPORSAYISI22 { get {return Body().RAPORSAYISI22;} }
            public TTReportShape NewLine33 { get {return Body().NewLine33;} }
            public TTReportField RAPORSAYISI24 { get {return Body().RAPORSAYISI24;} }
            public TTReportShape NewLine34 { get {return Body().NewLine34;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField RAPORSAYISI31 { get {return Body().RAPORSAYISI31;} }
            public TTReportField RAPORSAYISI14 { get {return Body().RAPORSAYISI14;} }
            public TTReportField PNO { get {return Body().PNO;} }
            public TTReportField RAPORSAYISI92 { get {return Body().RAPORSAYISI92;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine35 { get {return Body().NewLine35;} }
            public TTReportShape NewLine42 { get {return Body().NewLine42;} }
            public TTReportShape NewLine52 { get {return Body().NewLine52;} }
            public TTReportField RAPORSAYISI18 { get {return Body().RAPORSAYISI18;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportField RAPORSAYISI23 { get {return Body().RAPORSAYISI23;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportField RAPORSAYISI25 { get {return Body().RAPORSAYISI25;} }
            public TTReportField RAPORSAYISI33 { get {return Body().RAPORSAYISI33;} }
            public TTReportShape NewLine36 { get {return Body().NewLine36;} }
            public TTReportField RAPORSAYISI43 { get {return Body().RAPORSAYISI43;} }
            public TTReportShape NewLine41 { get {return Body().NewLine41;} }
            public TTReportField RAPORSAYISI53 { get {return Body().RAPORSAYISI53;} }
            public TTReportShape NewLine51 { get {return Body().NewLine51;} }
            public TTReportField RAPORSAYISI63 { get {return Body().RAPORSAYISI63;} }
            public TTReportShape NewLine61 { get {return Body().NewLine61;} }
            public TTReportField RAPORSAYISI73 { get {return Body().RAPORSAYISI73;} }
            public TTReportShape NewLine71 { get {return Body().NewLine71;} }
            public TTReportShape NewLine81 { get {return Body().NewLine81;} }
            public TTReportField RAPORSAYISI83 { get {return Body().RAPORSAYISI83;} }
            public TTReportField RAPORSAYISI93 { get {return Body().RAPORSAYISI93;} }
            public TTReportShape NewLine91 { get {return Body().NewLine91;} }
            public TTReportField RAPORSAYISI26 { get {return Body().RAPORSAYISI26;} }
            public TTReportShape NewLine8 { get {return Body().NewLine8;} }
            public TTReportField RAPORSAYISI27 { get {return Body().RAPORSAYISI27;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportField RAPORSAYISI28 { get {return Body().RAPORSAYISI28;} }
            public TTReportShape NewLine62 { get {return Body().NewLine62;} }
            public TTReportField RAPORSAYISI34 { get {return Body().RAPORSAYISI34;} }
            public TTReportShape NewLine72 { get {return Body().NewLine72;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField RAPORSAYISI111 { get {return Body().RAPORSAYISI111;} }
            public TTReportShape NewLine156 { get {return Body().NewLine156;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportShape NewLine171 { get {return Body().NewLine171;} }
            public TTReportField AOZUR1 { get {return Body().AOZUR1;} }
            public TTReportShape NewLine117 { get {return Body().NewLine117;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField RAPORGECERLILIK1 { get {return Body().RAPORGECERLILIK1;} }
            public TTReportShape NewLine119 { get {return Body().NewLine119;} }
            public TTReportShape NewLine181 { get {return Body().NewLine181;} }
            public TTReportShape NewLine191 { get {return Body().NewLine191;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField CALISAMAZISLER1 { get {return Body().CALISAMAZISLER1;} }
            public TTReportField RAPORSAYISI198 { get {return Body().RAPORSAYISI198;} }
            public TTReportField SUREKLI1 { get {return Body().SUREKLI1;} }
            public TTReportField OZURYUZDESI1 { get {return Body().OZURYUZDESI1;} }
            public TTReportShape NewLine118 { get {return Body().NewLine118;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommittee", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HealthCommitteeOfHandicappedReport MyParentReport
                {
                    get { return (HealthCommitteeOfHandicappedReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportShape NewLine;
                public TTReportField RAPORSAYISI;
                public TTReportField RAPORSAYISI2;
                public TTReportField RAPORSAYISI3;
                public TTReportField RAPORSAYISI6;
                public TTReportField RAPORSAYISI8;
                public TTReportField RAPORSAYISI10;
                public TTReportField RAPORSAYISI11;
                public TTReportField RAPORSAYISI12;
                public TTReportField BABAADI;
                public TTReportField DYER;
                public TTReportField MURTAR;
                public TTReportShape NewLine2;
                public TTReportShape NewLine7;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportField RAPORSAYISI19;
                public TTReportField RAPORTARIHI;
                public TTReportField RAPORSAYISI9;
                public TTReportField RAPORSAYISI7;
                public TTReportField RAPORSAYISI91;
                public TTReportField RAPORSAYISI20;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine10;
                public TTReportShape NewRect6;
                public TTReportField YIL;
                public TTReportField RAPORSAYISI16;
                public TTReportField RAPORSAYISI13;
                public TTReportField RAPORSAYISI4;
                public TTReportField H01;
                public TTReportField CKURUM;
                public TTReportField KISISEL;
                public TTReportField RAPORNO2;
                public TTReportField HEADER;
                public TTReportShape NewLine29;
                public TTReportShape NewLine31;
                public TTReportShape NewLine32;
                public TTReportField RAPORSAYISI5;
                public TTReportField RAPORSAYISI21;
                public TTReportField RAPORSAYISI17;
                public TTReportField RAPORSAYISI22;
                public TTReportShape NewLine33;
                public TTReportField RAPORSAYISI24;
                public TTReportShape NewLine34;
                public TTReportField NewField2;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine3;
                public TTReportField RAPORSAYISI31;
                public TTReportField RAPORSAYISI14;
                public TTReportField PNO;
                public TTReportField RAPORSAYISI92;
                public TTReportShape NewLine24;
                public TTReportShape NewLine35;
                public TTReportShape NewLine42;
                public TTReportShape NewLine52;
                public TTReportField RAPORSAYISI18;
                public TTReportShape NewLine14;
                public TTReportShape NewLine6;
                public TTReportField RAPORSAYISI23;
                public TTReportShape NewLine21;
                public TTReportField RAPORSAYISI25;
                public TTReportField RAPORSAYISI33;
                public TTReportShape NewLine36;
                public TTReportField RAPORSAYISI43;
                public TTReportShape NewLine41;
                public TTReportField RAPORSAYISI53;
                public TTReportShape NewLine51;
                public TTReportField RAPORSAYISI63;
                public TTReportShape NewLine61;
                public TTReportField RAPORSAYISI73;
                public TTReportShape NewLine71;
                public TTReportShape NewLine81;
                public TTReportField RAPORSAYISI83;
                public TTReportField RAPORSAYISI93;
                public TTReportShape NewLine91;
                public TTReportField RAPORSAYISI26;
                public TTReportShape NewLine8;
                public TTReportField RAPORSAYISI27;
                public TTReportShape NewLine15;
                public TTReportField RAPORSAYISI28;
                public TTReportShape NewLine62;
                public TTReportField RAPORSAYISI34;
                public TTReportShape NewLine72;
                public TTReportShape NewLine9;
                public TTReportField TCNO;
                public TTReportField RAPORSAYISI111;
                public TTReportShape NewLine156;
                public TTReportField TESHIS;
                public TTReportShape NewLine171;
                public TTReportField AOZUR1;
                public TTReportShape NewLine117;
                public TTReportField NewField181;
                public TTReportField RAPORGECERLILIK1;
                public TTReportShape NewLine119;
                public TTReportShape NewLine181;
                public TTReportShape NewLine191;
                public TTReportField NewField12;
                public TTReportField CALISAMAZISLER1;
                public TTReportField RAPORSAYISI198;
                public TTReportField SUREKLI1;
                public TTReportField OZURYUZDESI1;
                public TTReportShape NewLine118; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 263;
                    RepeatCount = 0;
                    
                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 7, 83, 11, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial";
                    ADSOYAD.TextFont.Size = 8;
                    ADSOYAD.Value = @"{#PNAME#} {#PSURNAME#}";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 6, 172, 6, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 43, 11, false);
                    RAPORSAYISI.Name = "RAPORSAYISI";
                    RAPORSAYISI.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI.TextFont.Size = 9;
                    RAPORSAYISI.TextFont.Bold = true;
                    RAPORSAYISI.Value = @"Adı Soyadı";

                    RAPORSAYISI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 13, 43, 17, false);
                    RAPORSAYISI2.Name = "RAPORSAYISI2";
                    RAPORSAYISI2.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI2.TextFont.Size = 8;
                    RAPORSAYISI2.TextFont.Bold = true;
                    RAPORSAYISI2.Value = @"Baba Adı";

                    RAPORSAYISI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 7, 115, 11, false);
                    RAPORSAYISI3.Name = "RAPORSAYISI3";
                    RAPORSAYISI3.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI3.TextFont.Size = 8;
                    RAPORSAYISI3.TextFont.Bold = true;
                    RAPORSAYISI3.Value = @"T.C. Kimlik Nu";

                    RAPORSAYISI6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 19, 43, 23, false);
                    RAPORSAYISI6.Name = "RAPORSAYISI6";
                    RAPORSAYISI6.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI6.TextFont.Size = 8;
                    RAPORSAYISI6.TextFont.Bold = true;
                    RAPORSAYISI6.Value = @"Müracaat Tarihi";

                    RAPORSAYISI8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 25, 43, 29, false);
                    RAPORSAYISI8.Name = "RAPORSAYISI8";
                    RAPORSAYISI8.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI8.TextFont.Size = 8;
                    RAPORSAYISI8.TextFont.Bold = true;
                    RAPORSAYISI8.Value = @"Muayeneye Gönderen";

                    RAPORSAYISI10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 7, 46, 11, false);
                    RAPORSAYISI10.Name = "RAPORSAYISI10";
                    RAPORSAYISI10.TextFont.Size = 8;
                    RAPORSAYISI10.TextFont.Bold = true;
                    RAPORSAYISI10.Value = @":";

                    RAPORSAYISI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 13, 46, 17, false);
                    RAPORSAYISI11.Name = "RAPORSAYISI11";
                    RAPORSAYISI11.TextFont.Size = 8;
                    RAPORSAYISI11.TextFont.Bold = true;
                    RAPORSAYISI11.Value = @":";

                    RAPORSAYISI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 7, 118, 11, false);
                    RAPORSAYISI12.Name = "RAPORSAYISI12";
                    RAPORSAYISI12.TextFont.Size = 8;
                    RAPORSAYISI12.TextFont.Bold = true;
                    RAPORSAYISI12.Value = @":";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 13, 83, 17, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Name = "Arial";
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 13, 143, 17, false);
                    DYER.Name = "DYER";
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial";
                    DYER.TextFont.Size = 8;
                    DYER.Value = @"{#DOGUMYERI#}";

                    MURTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 19, 83, 23, false);
                    MURTAR.Name = "MURTAR";
                    MURTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MURTAR.TextFormat = @"dd/mm/yyyy";
                    MURTAR.TextFont.Name = "Arial";
                    MURTAR.TextFont.Size = 8;
                    MURTAR.Value = @"{#HGTARIHI#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 36, 172, 36, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 6, 8, 36, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 45, 202, 45, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 93, 2, 93, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 81, 201, 81, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 39, 68, 44, false);
                    RAPORSAYISI19.Name = "RAPORSAYISI19";
                    RAPORSAYISI19.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI19.TextFont.Size = 9;
                    RAPORSAYISI19.TextFont.Bold = true;
                    RAPORSAYISI19.Value = @"ÖZRE İLİŞKİN BİLGİLER :";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 19, 169, 23, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/mm/yyyy";
                    RAPORTARIHI.TextFont.Name = "Arial";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    RAPORSAYISI9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 25, 115, 29, false);
                    RAPORSAYISI9.Name = "RAPORSAYISI9";
                    RAPORSAYISI9.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI9.TextFont.Size = 8;
                    RAPORSAYISI9.TextFont.Bold = true;
                    RAPORSAYISI9.Value = @"B - Kişisel Müracaat";

                    RAPORSAYISI7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 25, 74, 29, false);
                    RAPORSAYISI7.Name = "RAPORSAYISI7";
                    RAPORSAYISI7.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI7.TextFont.Size = 8;
                    RAPORSAYISI7.TextFont.Bold = true;
                    RAPORSAYISI7.Value = @"A - Çalıştığı Kurum";

                    RAPORSAYISI91 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 46, 149, 54, false);
                    RAPORSAYISI91.Name = "RAPORSAYISI91";
                    RAPORSAYISI91.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORSAYISI91.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORSAYISI91.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI91.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI91.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI91.TextFont.Bold = true;
                    RAPORSAYISI91.Value = @"Özre İlişkin Klinik Bulgular, Radyolojik Tetkikler ve Laboratuvar Bilgileri";

                    RAPORSAYISI20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 46, 200, 54, false);
                    RAPORSAYISI20.Name = "RAPORSAYISI20";
                    RAPORSAYISI20.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI20.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI20.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI20.TextFont.Bold = true;
                    RAPORSAYISI20.Value = @"Özür Oranı %";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 45, 202, 55, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 45, 8, 55, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 55, 202, 55, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 172, 6, 202, 36, false);
                    NewRect6.Name = "NewRect6";
                    NewRect6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect6.FillStyle = FillStyleConstants.vbFSTransparent;

                    YIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 13, 163, 17, false);
                    YIL.Name = "YIL";
                    YIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YIL.TextFormat = @"yyyy";
                    YIL.TextFont.Name = "Arial";
                    YIL.TextFont.Size = 8;
                    YIL.Value = @"{#DTARIHI#}";

                    RAPORSAYISI16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 13, 147, 17, false);
                    RAPORSAYISI16.Name = "RAPORSAYISI16";
                    RAPORSAYISI16.TextFont.Size = 8;
                    RAPORSAYISI16.Value = @"/";

                    RAPORSAYISI13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 31, 46, 35, false);
                    RAPORSAYISI13.Name = "RAPORSAYISI13";
                    RAPORSAYISI13.TextFont.Size = 8;
                    RAPORSAYISI13.Value = @":";

                    RAPORSAYISI4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 31, 43, 35, false);
                    RAPORSAYISI4.Name = "RAPORSAYISI4";
                    RAPORSAYISI4.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI4.TextFont.Size = 8;
                    RAPORSAYISI4.TextFont.Bold = true;
                    RAPORSAYISI4.Value = @"Rapor Numarası";

                    H01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 49, 41, 53, false);
                    H01.Name = "H01";
                    H01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    H01.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    H01.TextFont.Name = "Arial Narrow";
                    H01.TextFont.Bold = true;
                    H01.Value = @"Sistemler";

                    CKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 25, 83, 29, false);
                    CKURUM.Name = "CKURUM";
                    CKURUM.DrawStyle = DrawStyleConstants.vbSolid;
                    CKURUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CKURUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CKURUM.TextFont.Name = "Arial";
                    CKURUM.TextFont.Size = 8;
                    CKURUM.TextFont.Bold = true;
                    CKURUM.Value = @"";

                    KISISEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 25, 125, 29, false);
                    KISISEL.Name = "KISISEL";
                    KISISEL.DrawStyle = DrawStyleConstants.vbSolid;
                    KISISEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KISISEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KISISEL.TextFont.Name = "Arial";
                    KISISEL.TextFont.Size = 8;
                    KISISEL.TextFont.Bold = true;
                    KISISEL.Value = @"";

                    RAPORNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 31, 83, 35, false);
                    RAPORNO2.Name = "RAPORNO2";
                    RAPORNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO2.TextFont.Name = "Arial";
                    RAPORNO2.TextFont.Size = 8;
                    RAPORNO2.Value = @"{#RAPORNO#}";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 60, 5, false);
                    HEADER.Name = "HEADER";
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Size = 9;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"KİŞİSEL BİLGİLER:";

                    NewLine29 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 12, 172, 12, false);
                    NewLine29.Name = "NewLine29";
                    NewLine29.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine31 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 18, 172, 18, false);
                    NewLine31.Name = "NewLine31";
                    NewLine31.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine32 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 24, 172, 24, false);
                    NewLine32.Name = "NewLine32";
                    NewLine32.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 13, 115, 17, false);
                    RAPORSAYISI5.Name = "RAPORSAYISI5";
                    RAPORSAYISI5.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI5.TextFont.Size = 8;
                    RAPORSAYISI5.TextFont.Bold = true;
                    RAPORSAYISI5.Value = @"Doğum Yeri/Yılı";

                    RAPORSAYISI21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 13, 118, 17, false);
                    RAPORSAYISI21.Name = "RAPORSAYISI21";
                    RAPORSAYISI21.TextFont.Size = 8;
                    RAPORSAYISI21.TextFont.Bold = true;
                    RAPORSAYISI21.Value = @":";

                    RAPORSAYISI17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 115, 23, false);
                    RAPORSAYISI17.Name = "RAPORSAYISI17";
                    RAPORSAYISI17.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI17.TextFont.Size = 8;
                    RAPORSAYISI17.TextFont.Bold = true;
                    RAPORSAYISI17.Value = @"Rapor Tarihi";

                    RAPORSAYISI22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 19, 118, 23, false);
                    RAPORSAYISI22.Name = "RAPORSAYISI22";
                    RAPORSAYISI22.TextFont.Size = 8;
                    RAPORSAYISI22.TextFont.Bold = true;
                    RAPORSAYISI22.Value = @":";

                    NewLine33 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 84, 6, 84, 24, false);
                    NewLine33.Name = "NewLine33";
                    NewLine33.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 25, 46, 29, false);
                    RAPORSAYISI24.Name = "RAPORSAYISI24";
                    RAPORSAYISI24.TextFont.Size = 8;
                    RAPORSAYISI24.TextFont.Bold = true;
                    RAPORSAYISI24.Value = @":";

                    NewLine34 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 30, 172, 30, false);
                    NewLine34.Name = "NewLine34";
                    NewLine34.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 8, 200, 34, false);
                    NewField2.Name = "NewField2";
                    NewField2.FontAngle = 890;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"FOTOĞRAF";

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 46, 45, 46, 55, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 45, 183, 55, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 84, 30, 84, 36, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 31, 122, 35, false);
                    RAPORSAYISI31.Name = "RAPORSAYISI31";
                    RAPORSAYISI31.TextFont.Size = 8;
                    RAPORSAYISI31.Value = @":";

                    RAPORSAYISI14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 31, 119, 35, false);
                    RAPORSAYISI14.Name = "RAPORSAYISI14";
                    RAPORSAYISI14.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI14.TextFont.Size = 8;
                    RAPORSAYISI14.TextFont.Bold = true;
                    RAPORSAYISI14.Value = @"Bilgi İşlem Numarası";

                    PNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 31, 170, 35, false);
                    PNO.Name = "PNO";
                    PNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNO.TextFont.Name = "Arial";
                    PNO.TextFont.Size = 8;
                    PNO.Value = @"{#PID#}";

                    RAPORSAYISI92 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 57, 44, 61, false);
                    RAPORSAYISI92.Name = "RAPORSAYISI92";
                    RAPORSAYISI92.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI92.TextFont.Size = 8;
                    RAPORSAYISI92.Value = @"Kulak Burun Boğaz Sistemi";

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 55, 8, 213, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine35 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 46, 55, 46, 213, false);
                    NewLine35.Name = "NewLine35";
                    NewLine35.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine42 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 55, 183, 213, false);
                    NewLine42.Name = "NewLine42";
                    NewLine42.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine52 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 55, 202, 213, false);
                    NewLine52.Name = "NewLine52";
                    NewLine52.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 65, 44, 73, false);
                    RAPORSAYISI18.Name = "RAPORSAYISI18";
                    RAPORSAYISI18.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI18.NoClip = EvetHayirEnum.ehEvet;
                    RAPORSAYISI18.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI18.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORSAYISI18.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI18.TextFont.Size = 8;
                    RAPORSAYISI18.Value = @"Zihinsel,Ruhsal,
Davranışsal Bozukluk";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 64, 202, 64, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 74, 202, 74, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 75, 44, 83, false);
                    RAPORSAYISI23.Name = "RAPORSAYISI23";
                    RAPORSAYISI23.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI23.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI23.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORSAYISI23.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI23.TextFont.Size = 8;
                    RAPORSAYISI23.Value = @"Deri";

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 84, 202, 84, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 96, 44, 104, false);
                    RAPORSAYISI25.Name = "RAPORSAYISI25";
                    RAPORSAYISI25.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI25.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI25.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORSAYISI25.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI25.TextFont.Size = 8;
                    RAPORSAYISI25.Value = @"Hemopoetik
Sistem";

                    RAPORSAYISI33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 85, 44, 93, false);
                    RAPORSAYISI33.Name = "RAPORSAYISI33";
                    RAPORSAYISI33.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI33.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI33.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORSAYISI33.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI33.TextFont.Size = 8;
                    RAPORSAYISI33.Value = @"Kardiyovasküler 
Sistem";

                    NewLine36 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 95, 202, 95, false);
                    NewLine36.Name = "NewLine36";
                    NewLine36.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 108, 44, 116, false);
                    RAPORSAYISI43.Name = "RAPORSAYISI43";
                    RAPORSAYISI43.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI43.TextFont.Size = 8;
                    RAPORSAYISI43.Value = @"Görme Sistemi";

                    NewLine41 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 107, 202, 107, false);
                    NewLine41.Name = "NewLine41";
                    NewLine41.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 119, 44, 127, false);
                    RAPORSAYISI53.Name = "RAPORSAYISI53";
                    RAPORSAYISI53.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI53.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI53.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORSAYISI53.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI53.TextFont.Size = 8;
                    RAPORSAYISI53.Value = @"Sindirim Sistemi";

                    NewLine51 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 118, 202, 118, false);
                    NewLine51.Name = "NewLine51";
                    NewLine51.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI63 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 129, 44, 137, false);
                    RAPORSAYISI63.Name = "RAPORSAYISI63";
                    RAPORSAYISI63.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORSAYISI63.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORSAYISI63.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORSAYISI63.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI63.TextFont.Size = 9;
                    RAPORSAYISI63.Value = @"Kadın Hastalıkları ve Doğum";

                    NewLine61 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 128, 202, 128, false);
                    NewLine61.Name = "NewLine61";
                    NewLine61.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 140, 44, 148, false);
                    RAPORSAYISI73.Name = "RAPORSAYISI73";
                    RAPORSAYISI73.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI73.TextFont.Size = 9;
                    RAPORSAYISI73.Value = @"Ürogenital Sistem";

                    NewLine71 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 139, 202, 139, false);
                    NewLine71.Name = "NewLine71";
                    NewLine71.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine81 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 149, 202, 149, false);
                    NewLine81.Name = "NewLine81";
                    NewLine81.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI83 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 150, 44, 158, false);
                    RAPORSAYISI83.Name = "RAPORSAYISI83";
                    RAPORSAYISI83.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI83.TextFont.Size = 9;
                    RAPORSAYISI83.Value = @"Endokrin Sistem";

                    RAPORSAYISI93 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 161, 44, 169, false);
                    RAPORSAYISI93.Name = "RAPORSAYISI93";
                    RAPORSAYISI93.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI93.TextFont.Size = 9;
                    RAPORSAYISI93.Value = @"Solunum Sistemi";

                    NewLine91 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 160, 202, 160, false);
                    NewLine91.Name = "NewLine91";
                    NewLine91.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 171, 44, 179, false);
                    RAPORSAYISI26.Name = "RAPORSAYISI26";
                    RAPORSAYISI26.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI26.TextFont.Size = 9;
                    RAPORSAYISI26.Value = @"Yanıklar";

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 170, 202, 170, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 182, 44, 190, false);
                    RAPORSAYISI27.Name = "RAPORSAYISI27";
                    RAPORSAYISI27.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI27.TextFont.Size = 9;
                    RAPORSAYISI27.Value = @"Onkolojik Hastalıklar";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 181, 202, 181, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 193, 44, 201, false);
                    RAPORSAYISI28.Name = "RAPORSAYISI28";
                    RAPORSAYISI28.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI28.TextFont.Size = 9;
                    RAPORSAYISI28.Value = @"Sinir Sistemi";

                    NewLine62 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 192, 202, 192, false);
                    NewLine62.Name = "NewLine62";
                    NewLine62.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORSAYISI34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 204, 44, 212, false);
                    RAPORSAYISI34.Name = "RAPORSAYISI34";
                    RAPORSAYISI34.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI34.TextFont.Size = 9;
                    RAPORSAYISI34.Value = @"Kas İskelet Sistemi";

                    NewLine72 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 203, 202, 203, false);
                    NewLine72.Name = "NewLine72";
                    NewLine72.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 213, 202, 213, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 7, 169, 11, false);
                    TCNO.Name = "TCNO";
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Name = "Arial";
                    TCNO.TextFont.Size = 8;
                    TCNO.Value = @"{#TCNO#}";

                    RAPORSAYISI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 19, 46, 23, false);
                    RAPORSAYISI111.Name = "RAPORSAYISI111";
                    RAPORSAYISI111.TextFont.Size = 8;
                    RAPORSAYISI111.TextFont.Bold = true;
                    RAPORSAYISI111.Value = @":";

                    NewLine156 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 225, 202, 225, false);
                    NewLine156.Name = "NewLine156";
                    NewLine156.DrawStyle = DrawStyleConstants.vbSolid;

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 226, 88, 236, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Name = "Arial Narrow";
                    TESHIS.TextFont.Size = 7;
                    TESHIS.Value = @"";

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 237, 202, 237, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    AOZUR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 238, 88, 246, false);
                    AOZUR1.Name = "AOZUR1";
                    AOZUR1.TextFont.Name = "Arial Narrow";
                    AOZUR1.TextFont.Underline = true;
                    AOZUR1.Value = @"Ağır Özürlü:..........................(Evet/Hayır)";

                    NewLine117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 248, 202, 248, false);
                    NewLine117.Name = "NewLine117";
                    NewLine117.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 250, 32, 255, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.Value = @"Sürekli :";

                    RAPORGECERLILIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 249, 194, 254, false);
                    RAPORGECERLILIK1.Name = "RAPORGECERLILIK1";
                    RAPORGECERLILIK1.TextFont.Name = "Arial Narrow";
                    RAPORGECERLILIK1.Value = @"Raporun Geçerlilik Süresi:Rakamla:                          Yazıyla:";

                    NewLine119 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 225, 202, 256, false);
                    NewLine119.Name = "NewLine119";
                    NewLine119.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 225, 8, 256, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 89, 225, 89, 248, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 226, 194, 230, false);
                    NewField12.Name = "NewField12";
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Underline = true;
                    NewField12.Value = @"Kişinin Özür Oranı";

                    CALISAMAZISLER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 238, 194, 246, false);
                    CALISAMAZISLER1.Name = "CALISAMAZISLER1";
                    CALISAMAZISLER1.MultiLine = EvetHayirEnum.ehEvet;
                    CALISAMAZISLER1.WordBreak = EvetHayirEnum.ehEvet;
                    CALISAMAZISLER1.ExpandTabs = EvetHayirEnum.ehEvet;
                    CALISAMAZISLER1.TextFont.Name = "Arial Narrow";
                    CALISAMAZISLER1.Value = @"Çalıştırılamayacağı İş Alanları:";

                    RAPORSAYISI198 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 219, 83, 224, false);
                    RAPORSAYISI198.Name = "RAPORSAYISI198";
                    RAPORSAYISI198.TextFont.Name = "Arial Narrow";
                    RAPORSAYISI198.TextFont.Size = 9;
                    RAPORSAYISI198.TextFont.Bold = true;
                    RAPORSAYISI198.Value = @"ÖZÜRLÜ SAĞLIK KURULU RAPORUNUN SONUCU :";

                    SUREKLI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 250, 42, 255, false);
                    SUREKLI1.Name = "SUREKLI1";
                    SUREKLI1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUREKLI1.Value = @"";

                    OZURYUZDESI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 231, 194, 236, false);
                    OZURYUZDESI1.Name = "OZURYUZDESI1";
                    OZURYUZDESI1.TextFont.Name = "Arial Narrow";
                    OZURYUZDESI1.Value = @"% Rakamla:                       Yazıyla:";

                    NewLine118 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 256, 202, 256, false);
                    NewLine118.Name = "NewLine118";
                    NewLine118.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    ADSOYAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    RAPORSAYISI.CalcValue = RAPORSAYISI.Value;
                    RAPORSAYISI2.CalcValue = RAPORSAYISI2.Value;
                    RAPORSAYISI3.CalcValue = RAPORSAYISI3.Value;
                    RAPORSAYISI6.CalcValue = RAPORSAYISI6.Value;
                    RAPORSAYISI8.CalcValue = RAPORSAYISI8.Value;
                    RAPORSAYISI10.CalcValue = RAPORSAYISI10.Value;
                    RAPORSAYISI11.CalcValue = RAPORSAYISI11.Value;
                    RAPORSAYISI12.CalcValue = RAPORSAYISI12.Value;
                    BABAADI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    DYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    MURTAR.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Hgtarihi) : "");
                    RAPORSAYISI19.CalcValue = RAPORSAYISI19.Value;
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    RAPORSAYISI9.CalcValue = RAPORSAYISI9.Value;
                    RAPORSAYISI7.CalcValue = RAPORSAYISI7.Value;
                    RAPORSAYISI91.CalcValue = RAPORSAYISI91.Value;
                    RAPORSAYISI20.CalcValue = RAPORSAYISI20.Value;
                    YIL.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    RAPORSAYISI16.CalcValue = RAPORSAYISI16.Value;
                    RAPORSAYISI13.CalcValue = RAPORSAYISI13.Value;
                    RAPORSAYISI4.CalcValue = RAPORSAYISI4.Value;
                    H01.CalcValue = H01.Value;
                    CKURUM.CalcValue = CKURUM.Value;
                    KISISEL.CalcValue = KISISEL.Value;
                    RAPORNO2.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    HEADER.CalcValue = HEADER.Value;
                    RAPORSAYISI5.CalcValue = RAPORSAYISI5.Value;
                    RAPORSAYISI21.CalcValue = RAPORSAYISI21.Value;
                    RAPORSAYISI17.CalcValue = RAPORSAYISI17.Value;
                    RAPORSAYISI22.CalcValue = RAPORSAYISI22.Value;
                    RAPORSAYISI24.CalcValue = RAPORSAYISI24.Value;
                    NewField2.CalcValue = NewField2.Value;
                    RAPORSAYISI31.CalcValue = RAPORSAYISI31.Value;
                    RAPORSAYISI14.CalcValue = RAPORSAYISI14.Value;
                    PNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    RAPORSAYISI92.CalcValue = RAPORSAYISI92.Value;
                    RAPORSAYISI18.CalcValue = RAPORSAYISI18.Value;
                    RAPORSAYISI23.CalcValue = RAPORSAYISI23.Value;
                    RAPORSAYISI25.CalcValue = RAPORSAYISI25.Value;
                    RAPORSAYISI33.CalcValue = RAPORSAYISI33.Value;
                    RAPORSAYISI43.CalcValue = RAPORSAYISI43.Value;
                    RAPORSAYISI53.CalcValue = RAPORSAYISI53.Value;
                    RAPORSAYISI63.CalcValue = RAPORSAYISI63.Value;
                    RAPORSAYISI73.CalcValue = RAPORSAYISI73.Value;
                    RAPORSAYISI83.CalcValue = RAPORSAYISI83.Value;
                    RAPORSAYISI93.CalcValue = RAPORSAYISI93.Value;
                    RAPORSAYISI26.CalcValue = RAPORSAYISI26.Value;
                    RAPORSAYISI27.CalcValue = RAPORSAYISI27.Value;
                    RAPORSAYISI28.CalcValue = RAPORSAYISI28.Value;
                    RAPORSAYISI34.CalcValue = RAPORSAYISI34.Value;
                    TCNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    RAPORSAYISI111.CalcValue = RAPORSAYISI111.Value;
                    TESHIS.CalcValue = @"";
                    AOZUR1.CalcValue = AOZUR1.Value;
                    NewField181.CalcValue = NewField181.Value;
                    RAPORGECERLILIK1.CalcValue = RAPORGECERLILIK1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    CALISAMAZISLER1.CalcValue = CALISAMAZISLER1.Value;
                    RAPORSAYISI198.CalcValue = RAPORSAYISI198.Value;
                    SUREKLI1.CalcValue = SUREKLI1.Value;
                    OZURYUZDESI1.CalcValue = OZURYUZDESI1.Value;
                    return new TTReportObject[] { ADSOYAD,RAPORSAYISI,RAPORSAYISI2,RAPORSAYISI3,RAPORSAYISI6,RAPORSAYISI8,RAPORSAYISI10,RAPORSAYISI11,RAPORSAYISI12,BABAADI,DYER,MURTAR,RAPORSAYISI19,RAPORTARIHI,RAPORSAYISI9,RAPORSAYISI7,RAPORSAYISI91,RAPORSAYISI20,YIL,RAPORSAYISI16,RAPORSAYISI13,RAPORSAYISI4,H01,CKURUM,KISISEL,RAPORNO2,HEADER,RAPORSAYISI5,RAPORSAYISI21,RAPORSAYISI17,RAPORSAYISI22,RAPORSAYISI24,NewField2,RAPORSAYISI31,RAPORSAYISI14,PNO,RAPORSAYISI92,RAPORSAYISI18,RAPORSAYISI23,RAPORSAYISI25,RAPORSAYISI33,RAPORSAYISI43,RAPORSAYISI53,RAPORSAYISI63,RAPORSAYISI73,RAPORSAYISI83,RAPORSAYISI93,RAPORSAYISI26,RAPORSAYISI27,RAPORSAYISI28,RAPORSAYISI34,TCNO,RAPORSAYISI111,TESHIS,AOZUR1,NewField181,RAPORGECERLILIK1,NewField12,CALISAMAZISLER1,RAPORSAYISI198,SUREKLI1,OZURYUZDESI1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeOfHandicappedReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            //Tanı
            int nCount = 1;
            this.TESHIS.CalcValue = "";
            BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> pDiagnosis = HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID(sObjectID);
            foreach(HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class pGrid in pDiagnosis)
            {
                this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TESHIS.CalcValue += "\r\n";
                nCount++;
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

        public HealthCommitteeOfHandicappedReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEOFHANDICAPPEDREPORT";
            Caption = "Sağlık Kurulu Özürlü Raporu";
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