
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
    /// Tıbbi Cihaz Arızalanma Oranı Raporu
    /// </summary>
    public partial class FailureRateReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FailureRateReport MyParentReport
            {
                get { return (FailureRateReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ARIZALANMA_ORANI_RAPORU { get {return Header().ARIZALANMA_ORANI_RAPORU;} }
            public TTReportField SERVICE { get {return Header().SERVICE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField SIRANU1 { get {return Header().SIRANU1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11621 { get {return Header().NewField11621;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField HOSPITAL11 { get {return Header().HOSPITAL11;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public FailureRateReport MyParentReport
                {
                    get { return (FailureRateReport)ParentReport; }
                }
                
                public TTReportField ARIZALANMA_ORANI_RAPORU;
                public TTReportField SERVICE;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField SIRANU1;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField11511;
                public TTReportField NewField11621;
                public TTReportField NewField11711;
                public TTReportField HOSPITAL11; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ARIZALANMA_ORANI_RAPORU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 20, 239, 30, false);
                    ARIZALANMA_ORANI_RAPORU.Name = "ARIZALANMA_ORANI_RAPORU";
                    ARIZALANMA_ORANI_RAPORU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARIZALANMA_ORANI_RAPORU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARIZALANMA_ORANI_RAPORU.TextFont.Name = "Arial";
                    ARIZALANMA_ORANI_RAPORU.TextFont.Size = 12;
                    ARIZALANMA_ORANI_RAPORU.TextFont.Bold = true;
                    ARIZALANMA_ORANI_RAPORU.TextFont.CharSet = 162;
                    ARIZALANMA_ORANI_RAPORU.Value = @"TIBBI CİHAZ ARIZALANMA ORANI RAPORU";

                    SERVICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 38, 84, 55, false);
                    SERVICE.Name = "SERVICE";
                    SERVICE.DrawStyle = DrawStyleConstants.vbSolid;
                    SERVICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERVICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERVICE.TextFont.Bold = true;
                    SERVICE.TextFont.CharSet = 162;
                    SERVICE.Value = @"Klinik (Depo)";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 38, 106, 55, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Depo Mevcudu";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 38, 266, 55, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Toplam (İş İstek)
Arıza Bildirim Sayısı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 38, 129, 55, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Onarılan İş İstek 
Sayısı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 38, 153, 55, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Devam Eden İş İstek Sayısı";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 38, 187, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Onarımı Tamamlananlar İçin Harcanan Toplam Süre (Saat)";

                    SIRANU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 38, 13, 55, false);
                    SIRANU1.Name = "SIRANU1";
                    SIRANU1.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANU1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANU1.TextFont.Bold = true;
                    SIRANU1.TextFont.CharSet = 162;
                    SIRANU1.Value = @"S.Nu.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 38, 239, 55, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Toplam Hek Edilen Sayısı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 38, 212, 55, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Toplam Kalibrasyon Sayısı";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 30, 136, 36, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11511.TextFormat = @"Short Date";
                    NewField11511.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11511.TextFont.Size = 11;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"{@STARTDATE@}";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 30, 142, 35, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11621.TextFont.Size = 11;
                    NewField11621.TextFont.Bold = true;
                    NewField11621.TextFont.CharSet = 162;
                    NewField11621.Value = @"-";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 30, 168, 36, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11711.TextFormat = @"Short Date";
                    NewField11711.TextFont.Size = 11;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"{@ENDDATE@}";

                    HOSPITAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 8, 243, 18, false);
                    HOSPITAL11.Name = "HOSPITAL11";
                    HOSPITAL11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL11.TextFont.Name = "Arial";
                    HOSPITAL11.TextFont.Size = 13;
                    HOSPITAL11.TextFont.Bold = true;
                    HOSPITAL11.TextFont.CharSet = 162;
                    HOSPITAL11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ARIZALANMA_ORANI_RAPORU.CalcValue = ARIZALANMA_ORANI_RAPORU.Value;
                    SERVICE.CalcValue = SERVICE.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    SIRANU1.CalcValue = SIRANU1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField11511.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField11711.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    HOSPITAL11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ARIZALANMA_ORANI_RAPORU,SERVICE,NewField1,NewField2,NewField3,NewField4,NewField5,SIRANU1,NewField12,NewField121,NewField11511,NewField11621,NewField11711,HOSPITAL11};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FailureRateReport MyParentReport
                {
                    get { return (FailureRateReport)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1;
                public TTReportShape NewLine111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 30, 6, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 158, 6, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Name = "Arial";
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 1, 266, 6, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 1, 266, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CurrentUser1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public FailureRateReport MyParentReport
            {
                get { return (FailureRateReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField SERVICE { get {return Body().SERVICE;} }
            public TTReportField TOTALWORK { get {return Body().TOTALWORK;} }
            public TTReportField TOTALSTORE { get {return Body().TOTALSTORE;} }
            public TTReportField COMPLETED { get {return Body().COMPLETED;} }
            public TTReportField CONTINUE { get {return Body().CONTINUE;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField TOTALWORKTIME { get {return Body().TOTALWORKTIME;} }
            public TTReportField SERVICEOBJECTID { get {return Body().SERVICEOBJECTID;} }
            public TTReportField HEKCOUNT { get {return Body().HEKCOUNT;} }
            public TTReportField CALIBCOUNT { get {return Body().CALIBCOUNT;} }
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
                list[0] = new TTReportNqlData<CMRAction.GetFailureRateRQ_Class>("GetFailureRateRQ", CMRAction.GetFailureRateRQ((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public FailureRateReport MyParentReport
                {
                    get { return (FailureRateReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField SERVICE;
                public TTReportField TOTALWORK;
                public TTReportField TOTALSTORE;
                public TTReportField COMPLETED;
                public TTReportField CONTINUE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField TOTALWORKTIME;
                public TTReportField SERVICEOBJECTID;
                public TTReportField HEKCOUNT;
                public TTReportField CALIBCOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 13, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Size = 8;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    SERVICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 84, 5, false);
                    SERVICE.Name = "SERVICE";
                    SERVICE.DrawStyle = DrawStyleConstants.vbSolid;
                    SERVICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERVICE.TextFont.Size = 8;
                    SERVICE.TextFont.CharSet = 162;
                    SERVICE.Value = @" {#SERVICE#}";

                    TOTALWORK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 0, 266, 5, false);
                    TOTALWORK.Name = "TOTALWORK";
                    TOTALWORK.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALWORK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALWORK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALWORK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALWORK.TextFont.Size = 8;
                    TOTALWORK.TextFont.CharSet = 162;
                    TOTALWORK.Value = @"";

                    TOTALSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 106, 5, false);
                    TOTALSTORE.Name = "TOTALSTORE";
                    TOTALSTORE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALSTORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALSTORE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALSTORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALSTORE.TextFont.Size = 8;
                    TOTALSTORE.TextFont.CharSet = 162;
                    TOTALSTORE.Value = @"";

                    COMPLETED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 0, 129, 5, false);
                    COMPLETED.Name = "COMPLETED";
                    COMPLETED.DrawStyle = DrawStyleConstants.vbSolid;
                    COMPLETED.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPLETED.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMPLETED.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COMPLETED.TextFont.Size = 8;
                    COMPLETED.TextFont.CharSet = 162;
                    COMPLETED.Value = @"";

                    CONTINUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 153, 5, false);
                    CONTINUE.Name = "CONTINUE";
                    CONTINUE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONTINUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTINUE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONTINUE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONTINUE.TextFont.Size = 8;
                    CONTINUE.TextFont.CharSet = 162;
                    CONTINUE.Value = @"";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 333, 0, 358, 5, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 361, 0, 386, 5, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    TOTALWORKTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 187, 5, false);
                    TOTALWORKTIME.Name = "TOTALWORKTIME";
                    TOTALWORKTIME.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALWORKTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALWORKTIME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALWORKTIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALWORKTIME.TextFont.Size = 8;
                    TOTALWORKTIME.TextFont.CharSet = 162;
                    TOTALWORKTIME.Value = @"";

                    SERVICEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 389, 0, 414, 5, false);
                    SERVICEOBJECTID.Name = "SERVICEOBJECTID";
                    SERVICEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    SERVICEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVICEOBJECTID.Value = @"{#SERVICEOBJECTID#}";

                    HEKCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 239, 5, false);
                    HEKCOUNT.Name = "HEKCOUNT";
                    HEKCOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKCOUNT.TextFont.Size = 8;
                    HEKCOUNT.TextFont.CharSet = 162;
                    HEKCOUNT.Value = @"";

                    CALIBCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 212, 5, false);
                    CALIBCOUNT.Name = "CALIBCOUNT";
                    CALIBCOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CALIBCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CALIBCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CALIBCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CALIBCOUNT.TextFont.Size = 8;
                    CALIBCOUNT.TextFont.CharSet = 162;
                    CALIBCOUNT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetFailureRateRQ_Class dataset_GetFailureRateRQ = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetFailureRateRQ_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    SERVICE.CalcValue = @" " + (dataset_GetFailureRateRQ != null ? Globals.ToStringCore(dataset_GetFailureRateRQ.Service) : "");
                    TOTALWORK.CalcValue = @"";
                    TOTALSTORE.CalcValue = @"";
                    COMPLETED.CalcValue = @"";
                    CONTINUE.CalcValue = @"";
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    TOTALWORKTIME.CalcValue = @"";
                    SERVICEOBJECTID.CalcValue = (dataset_GetFailureRateRQ != null ? Globals.ToStringCore(dataset_GetFailureRateRQ.Serviceobjectid) : "");
                    HEKCOUNT.CalcValue = @"";
                    CALIBCOUNT.CalcValue = @"";
                    return new TTReportObject[] { COUNT,SERVICE,TOTALWORK,TOTALSTORE,COMPLETED,CONTINUE,STARTDATE,ENDDATE,TOTALWORKTIME,SERVICEOBJECTID,HEKCOUNT,CALIBCOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    int countFinish = 0;
            int countContinue = 0;
            
            DateTime startDate = Convert.ToDateTime(this.MyParentReport.Parameters.ItemByName("STARTDATE").Value);
            DateTime endDate = Convert.ToDateTime(this.MyParentReport.Parameters.ItemByName("ENDDATE").Value);

            Guid serviceobjectID = new Guid(SERVICEOBJECTID.CalcValue) ;
            

            TTObjectContext objectContext = new TTObjectContext(true);
            IList cmrActions = CMRAction.FailureRateReportOQ(objectContext,endDate,startDate,serviceobjectID);
            foreach(CMRAction cm in cmrActions)
            {
                if(cm is Repair  || cm is MaterialRepair)
                {
                    countFinish += cmrActions.Count;
                }
                
                
            }
            
            IList cmrActionsContinue = CMRAction.FailureRateReportOQ2(objectContext, startDate, endDate, serviceobjectID);
            
            countContinue = cmrActionsContinue.Count;
            
            COMPLETED.CalcValue = countFinish.ToString();
            CONTINUE.CalcValue = countContinue.ToString();

            IList cmrActionsTotalWork = CMRAction.FailureRateReportOQ3(objectContext, endDate, serviceobjectID, startDate);
            
            foreach(CMRAction cmr in cmrActionsTotalWork)
            {
                if(cmr is Repair)
                {
                    Repair repair = (Repair)cmr;
                    this.TOTALWORKTIME.CalcValue = repair.TotalWorkLoad.ToString();
                }
            }
            
            IList cmrTotalStore = CMRAction.GetStockInheld(objectContext,serviceobjectID);
            if(((TTObjectClasses.CMRAction.GetStockInheld_Class)(cmrTotalStore[0])).Depomevcudu != null)
                TOTALSTORE.CalcValue =(((TTObjectClasses.CMRAction.GetStockInheld_Class)(cmrTotalStore[0])).Depomevcudu).ToString();
            else
                TOTALSTORE.CalcValue="0";
            
            
            
            int hekCount = 0;
            int calibrationCount = 0;
            
            Guid hekStateDefId = Repair.States.HEK;
            Guid calibrationStateDefId = Calibration.States.Calibration;

            // TTObjectContext ctx = new TTObjectContext(true);
            IBindingList list2 = Repair.GetHekFromRepairQuery(objectContext,new Guid(SERVICEOBJECTID.CalcValue), " AND YEAR(ENDDATE) = " + startDate.Year.ToString());
            
            if(list2 != null)
            {
                foreach (Repair rep in list2)
                {
                    if(rep.RepairHEKCommisionMembers.Count > 0)
                        hekCount++;
                    if(rep is MaterialRepair)
                    {
                        
                        if(((MaterialRepair)rep).FixedAssetDefinition.NeedCalibration.HasValue && ((MaterialRepair)rep).FixedAssetDefinition.NeedCalibration == true)
                            calibrationCount++;
                        
                        
                    }
                    else
                    {
                        if(rep.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                        {
                            if(rep.FixedAssetMaterialDefinition.FixedAssetDefinition.NeedCalibration.HasValue && rep.FixedAssetMaterialDefinition.FixedAssetDefinition.NeedCalibration == true)
                                calibrationCount++;
                        }
                    }
                }
            }
            
            this.HEKCOUNT.CalcValue = hekCount.ToString();
            this.CALIBCOUNT.CalcValue = calibrationCount.ToString();
            
            this.TOTALWORK.CalcValue = ((int)countFinish + (int)countContinue  + (int)hekCount + (int)calibrationCount).ToString();
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

        public FailureRateReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlama Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "FAILURERATEREPORT";
            Caption = "Tıbbi Cihaz Arızalanma Oranı Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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