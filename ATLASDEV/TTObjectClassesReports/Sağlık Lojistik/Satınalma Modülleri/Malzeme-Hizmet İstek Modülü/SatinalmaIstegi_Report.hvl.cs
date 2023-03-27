
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
    /// Malzeme İstek Raporu
    /// </summary>
    public partial class SatinalmaIstegi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public SatinalmaIstegi MyParentReport
            {
                get { return (SatinalmaIstegi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField HOSPITALCITY { get {return Header().HOSPITALCITY;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
            public TTReportField REPDESC { get {return Footer().REPDESC;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField NewField10;
                public TTReportField HOSPITALNAME;
                public TTReportField HOSPITALCITY; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 55, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.Value = @"";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 19, 290, 28, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 15;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Malzeme İstek Raporu";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 2, 290, 11, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.TextFont.Name = "Arial Narrow";
                    HOSPITALNAME.TextFont.Size = 15;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    HOSPITALCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 11, 290, 17, false);
                    HOSPITALCITY.Name = "HOSPITALCITY";
                    HOSPITALCITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCITY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALCITY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALCITY.TextFont.Name = "Arial Narrow";
                    HOSPITALCITY.TextFont.Size = 15;
                    HOSPITALCITY.TextFont.Bold = true;
                    HOSPITALCITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    NewField10.CalcValue = NewField10.Value;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HOSPITALCITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField10,HOSPITALNAME,HOSPITALCITY};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER;
                public TTReportField USERNAME;
                public TTReportField REPDESC; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 1, 290, 1, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 2;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 2, 257, 7, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.Visible = EvetHayirEnum.ehHayir;
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 2, 290, 7, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.Name = "Arial Narrow";
                    PAGENUMBER.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 7, 51, 12, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Name = "Arial Narrow";
                    USERNAME.Value = @"";

                    REPDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 7, 290, 12, false);
                    REPDESC.Name = "REPDESC";
                    REPDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPDESC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    REPDESC.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REPDESC.TextFont.Name = "Arial Narrow";
                    REPDESC.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    USERNAME.CalcValue = @"";
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString() + @" - " + MyParentReport.PARTB.USERNAME.CalcValue;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    REPDESC.CalcValue = @"";
                    return new TTReportObject[] { USERNAME,PRINTDATE,PAGENUMBER,REPDESC};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public SatinalmaIstegi MyParentReport
            {
                get { return (SatinalmaIstegi)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField AYLIKSARFTITLE { get {return Header().AYLIKSARFTITLE;} }
            public TTReportField DEMANDTYPE { get {return Header().DEMANDTYPE;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField DEMANDID { get {return Header().DEMANDID;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField ISTEKACIKLAMA { get {return Header().ISTEKACIKLAMA;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField DEMANDDATE { get {return Header().DEMANDDATE;} }
            public TTReportField NSNTITLE { get {return Header().NSNTITLE;} }
            public TTReportField AMBALAJTITLE { get {return Header().AMBALAJTITLE;} }
            public TTReportField REQAMOUNTTITLE { get {return Header().REQAMOUNTTITLE;} }
            public TTReportField SYMDEPOTITLE { get {return Header().SYMDEPOTITLE;} }
            public TTReportField KLNDEPOTITLE { get {return Header().KLNDEPOTITLE;} }
            public TTReportField UNITPRICETITLE { get {return Header().UNITPRICETITLE;} }
            public TTReportField ONAYLAYAN { get {return Footer().ONAYLAYAN;} }
            public TTReportField DATE { get {return Footer().DATE;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Demand.SatınalmaIstek_DemandQuery_Class>("SatınalmaIstek_DemandQuery", Demand.SatınalmaIstek_DemandQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField AYLIKSARFTITLE;
                public TTReportField DEMANDTYPE;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField STORENAME;
                public TTReportField NewField8;
                public TTReportField DEMANDID;
                public TTReportField NewField;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField ISTEKACIKLAMA;
                public TTReportField NewField15;
                public TTReportField DEMANDDATE;
                public TTReportField NSNTITLE;
                public TTReportField AMBALAJTITLE;
                public TTReportField REQAMOUNTTITLE;
                public TTReportField SYMDEPOTITLE;
                public TTReportField KLNDEPOTITLE;
                public TTReportField UNITPRICETITLE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 53;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 42, 104, 53, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"MALZEME ADI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 42, 208, 53, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"BİRİMİ";

                    AYLIKSARFTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 42, 224, 53, false);
                    AYLIKSARFTITLE.Name = "AYLIKSARFTITLE";
                    AYLIKSARFTITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    AYLIKSARFTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AYLIKSARFTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AYLIKSARFTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    AYLIKSARFTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    AYLIKSARFTITLE.TextFont.Name = "Arial Narrow";
                    AYLIKSARFTITLE.TextFont.Size = 11;
                    AYLIKSARFTITLE.TextFont.Bold = true;
                    AYLIKSARFTITLE.Value = @"AYLIK SARF";

                    DEMANDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 21, 104, 26, false);
                    DEMANDTYPE.Name = "DEMANDTYPE";
                    DEMANDTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDTYPE.ObjectDefName = "DemandTypeEnum";
                    DEMANDTYPE.DataMember = "DISPLAYTEXT";
                    DEMANDTYPE.TextFont.Name = "Arial";
                    DEMANDTYPE.TextFont.Size = 11;
                    DEMANDTYPE.Value = @"{#DEMANDTYPE#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 9, 31, 14, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Tarih";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 31, 26, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"İstek Türü";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 27, 31, 32, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Açıklama";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 3, 191, 8, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.TextFont.Name = "Arial";
                    STORENAME.TextFont.Size = 11;
                    STORENAME.Value = @"{#MASTERRESOURCE#}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 31, 20, false);
                    NewField8.Name = "NewField8";
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"İstek No";

                    DEMANDID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 84, 20, false);
                    DEMANDID.Name = "DEMANDID";
                    DEMANDID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDID.TextFont.Name = "Arial";
                    DEMANDID.TextFont.Size = 11;
                    DEMANDID.Value = @"{#REQUESTNO#}";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 9, 37, 14, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 11;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @":";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 15, 37, 20, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 21, 37, 26, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 11;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 27, 37, 32, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 36, 8, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Bölüm";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 3, 37, 8, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    ISTEKACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 27, 290, 40, false);
                    ISTEKACIKLAMA.Name = "ISTEKACIKLAMA";
                    ISTEKACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKACIKLAMA.TextFont.Name = "Arial";
                    ISTEKACIKLAMA.TextFont.Size = 11;
                    ISTEKACIKLAMA.Value = @"{#DESCRIPTION#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 42, 23, 53, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"S. NO";

                    DEMANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 9, 84, 14, false);
                    DEMANDDATE.Name = "DEMANDDATE";
                    DEMANDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDDATE.TextFormat = @"Short Date";
                    DEMANDDATE.TextFont.Name = "Arial";
                    DEMANDDATE.TextFont.Size = 11;
                    DEMANDDATE.Value = @"{#DEMANDDATE#}";

                    NSNTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 42, 144, 53, false);
                    NSNTITLE.Name = "NSNTITLE";
                    NSNTITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    NSNTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSNTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSNTITLE.TextFont.Name = "Arial Narrow";
                    NSNTITLE.TextFont.Size = 11;
                    NSNTITLE.TextFont.Bold = true;
                    NSNTITLE.Value = @"NSN";

                    AMBALAJTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 42, 165, 53, false);
                    AMBALAJTITLE.Name = "AMBALAJTITLE";
                    AMBALAJTITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    AMBALAJTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMBALAJTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMBALAJTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    AMBALAJTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    AMBALAJTITLE.TextFont.Name = "Arial Narrow";
                    AMBALAJTITLE.TextFont.Size = 11;
                    AMBALAJTITLE.TextFont.Bold = true;
                    AMBALAJTITLE.Value = @"AMBALAJ FORMU";

                    REQAMOUNTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 42, 186, 53, false);
                    REQAMOUNTTITLE.Name = "REQAMOUNTTITLE";
                    REQAMOUNTTITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQAMOUNTTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQAMOUNTTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQAMOUNTTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    REQAMOUNTTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    REQAMOUNTTITLE.TextFont.Name = "Arial Narrow";
                    REQAMOUNTTITLE.TextFont.Size = 11;
                    REQAMOUNTTITLE.TextFont.Bold = true;
                    REQAMOUNTTITLE.Value = @"İSTEK MİKTARI";

                    SYMDEPOTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 42, 246, 53, false);
                    SYMDEPOTITLE.Name = "SYMDEPOTITLE";
                    SYMDEPOTITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    SYMDEPOTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SYMDEPOTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SYMDEPOTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    SYMDEPOTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    SYMDEPOTITLE.TextFont.Name = "Arial Narrow";
                    SYMDEPOTITLE.TextFont.Size = 11;
                    SYMDEPOTITLE.TextFont.Bold = true;
                    SYMDEPOTITLE.Value = @"SYM. DEPO MEV.";

                    KLNDEPOTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 42, 268, 53, false);
                    KLNDEPOTITLE.Name = "KLNDEPOTITLE";
                    KLNDEPOTITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    KLNDEPOTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLNDEPOTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KLNDEPOTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    KLNDEPOTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    KLNDEPOTITLE.TextFont.Name = "Arial Narrow";
                    KLNDEPOTITLE.TextFont.Size = 11;
                    KLNDEPOTITLE.TextFont.Bold = true;
                    KLNDEPOTITLE.Value = @"KLN. DEPO MEV.";

                    UNITPRICETITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 42, 290, 53, false);
                    UNITPRICETITLE.Name = "UNITPRICETITLE";
                    UNITPRICETITLE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICETITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICETITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICETITLE.TextFont.Name = "Arial Narrow";
                    UNITPRICETITLE.TextFont.Size = 11;
                    UNITPRICETITLE.TextFont.Bold = true;
                    UNITPRICETITLE.Value = @"BİRİM FİYAT";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Demand.SatınalmaIstek_DemandQuery_Class dataset_SatınalmaIstek_DemandQuery = ParentGroup.rsGroup.GetCurrentRecord<Demand.SatınalmaIstek_DemandQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    AYLIKSARFTITLE.CalcValue = AYLIKSARFTITLE.Value;
                    DEMANDTYPE.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.DemandType) : "");
                    DEMANDTYPE.PostFieldValueCalculation();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    STORENAME.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.Masterresource) : "");
                    NewField8.CalcValue = NewField8.Value;
                    DEMANDID.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.RequestNo) : "");
                    NewField.CalcValue = NewField.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    ISTEKACIKLAMA.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.Description) : "");
                    NewField15.CalcValue = NewField15.Value;
                    DEMANDDATE.CalcValue = (dataset_SatınalmaIstek_DemandQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandQuery.DemandDate) : "");
                    NSNTITLE.CalcValue = NSNTITLE.Value;
                    AMBALAJTITLE.CalcValue = AMBALAJTITLE.Value;
                    REQAMOUNTTITLE.CalcValue = REQAMOUNTTITLE.Value;
                    SYMDEPOTITLE.CalcValue = SYMDEPOTITLE.Value;
                    KLNDEPOTITLE.CalcValue = KLNDEPOTITLE.Value;
                    UNITPRICETITLE.CalcValue = UNITPRICETITLE.Value;
                    return new TTReportObject[] { NewField1,NewField2,AYLIKSARFTITLE,DEMANDTYPE,NewField5,NewField6,NewField7,STORENAME,NewField8,DEMANDID,NewField,NewField9,NewField10,NewField11,NewField12,NewField13,ISTEKACIKLAMA,NewField15,DEMANDDATE,NSNTITLE,AMBALAJTITLE,REQAMOUNTTITLE,SYMDEPOTITLE,KLNDEPOTITLE,UNITPRICETITLE};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                
                public TTReportField ONAYLAYAN;
                public TTReportField DATE; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 36;
                    RepeatCount = 0;
                    
                    ONAYLAYAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 23, 283, 28, false);
                    ONAYLAYAN.Name = "ONAYLAYAN";
                    ONAYLAYAN.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ONAYLAYAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYLAYAN.TextFont.Name = "Arial";
                    ONAYLAYAN.TextFont.Size = 11;
                    ONAYLAYAN.Value = @"Onaylayan Bölüm Yetkilisi";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 17, 283, 22, false);
                    DATE.Name = "DATE";
                    DATE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.Size = 11;
                    DATE.Value = @"-----/-----/----------";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Demand.SatınalmaIstek_DemandQuery_Class dataset_SatınalmaIstek_DemandQuery = ParentGroup.rsGroup.GetCurrentRecord<Demand.SatınalmaIstek_DemandQuery_Class>(0);
                    ONAYLAYAN.CalcValue = ONAYLAYAN.Value;
                    DATE.CalcValue = DATE.Value;
                    return new TTReportObject[] { ONAYLAYAN,DATE};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PURCHASEITEMCLASSGroup : TTReportGroup
        {
            public SatinalmaIstegi MyParentReport
            {
                get { return (SatinalmaIstegi)ParentReport; }
            }

            new public PURCHASEITEMCLASSGroupHeader Header()
            {
                return (PURCHASEITEMCLASSGroupHeader)_header;
            }

            new public PURCHASEITEMCLASSGroupFooter Footer()
            {
                return (PURCHASEITEMCLASSGroupFooter)_footer;
            }

            public TTReportField PURCHASEITEMCLASS { get {return Header().PURCHASEITEMCLASS;} }
            public PURCHASEITEMCLASSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PURCHASEITEMCLASSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class>("SatınalmaIstek_DemandDetailQuery", DemandDetail.SatınalmaIstek_DemandDetailQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PURCHASEITEMCLASSGroupHeader(this);
                _footer = new PURCHASEITEMCLASSGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PURCHASEITEMCLASSGroupHeader : TTReportSection
            {
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                
                public TTReportField PURCHASEITEMCLASS; 
                public PURCHASEITEMCLASSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PURCHASEITEMCLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 191, 6, false);
                    PURCHASEITEMCLASS.Name = "PURCHASEITEMCLASS";
                    PURCHASEITEMCLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEITEMCLASS.TextFont.Name = "Arial";
                    PURCHASEITEMCLASS.TextFont.Bold = true;
                    PURCHASEITEMCLASS.Value = @"{#PURCHASEITEMCLASS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DemandDetail.SatınalmaIstek_DemandDetailQuery_Class dataset_SatınalmaIstek_DemandDetailQuery = ParentGroup.rsGroup.GetCurrentRecord<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class>(0);
                    PURCHASEITEMCLASS.CalcValue = (dataset_SatınalmaIstek_DemandDetailQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandDetailQuery.Purchaseitemclass) : "");
                    return new TTReportObject[] { PURCHASEITEMCLASS};
                }
            }
            public partial class PURCHASEITEMCLASSGroupFooter : TTReportSection
            {
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                 
                public PURCHASEITEMCLASSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PURCHASEITEMCLASSGroup PURCHASEITEMCLASS;

        public partial class MAINGroup : TTReportGroup
        {
            public SatinalmaIstegi MyParentReport
            {
                get { return (SatinalmaIstegi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ITEMNAME { get {return Body().ITEMNAME;} }
            public TTReportField TYPENAME { get {return Body().TYPENAME;} }
            public TTReportField AYLIKSARF { get {return Body().AYLIKSARF;} }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField AMBALAJ { get {return Body().AMBALAJ;} }
            public TTReportField REQAMOUNT { get {return Body().REQAMOUNT;} }
            public TTReportField SYMDEPO { get {return Body().SYMDEPO;} }
            public TTReportField KLNDEPO { get {return Body().KLNDEPO;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
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

                DemandDetail.SatınalmaIstek_DemandDetailQuery_Class dataSet_SatınalmaIstek_DemandDetailQuery = ParentGroup.rsGroup.GetCurrentRecord<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class>(0);    
                return new object[] {(dataSet_SatınalmaIstek_DemandDetailQuery==null ? null : dataSet_SatınalmaIstek_DemandDetailQuery.Purchaseitemclass)};
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
                public SatinalmaIstegi MyParentReport
                {
                    get { return (SatinalmaIstegi)ParentReport; }
                }
                
                public TTReportField ITEMNAME;
                public TTReportField TYPENAME;
                public TTReportField AYLIKSARF;
                public TTReportField COUNTER;
                public TTReportField NSN;
                public TTReportField AMBALAJ;
                public TTReportField REQAMOUNT;
                public TTReportField SYMDEPO;
                public TTReportField KLNDEPO;
                public TTReportField UNITPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    ITEMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 104, 5, false);
                    ITEMNAME.Name = "ITEMNAME";
                    ITEMNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMNAME.TextFont.Name = "Arial";
                    ITEMNAME.TextFont.Size = 11;
                    ITEMNAME.Value = @"{#PURCHASEITEMCLASS.ITEMNAME#}";

                    TYPENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 208, 5, false);
                    TYPENAME.Name = "TYPENAME";
                    TYPENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    TYPENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYPENAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TYPENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TYPENAME.TextFont.Name = "Arial";
                    TYPENAME.TextFont.Size = 11;
                    TYPENAME.Value = @"{#PURCHASEITEMCLASS.TYPENAME#}";

                    AYLIKSARF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 0, 224, 5, false);
                    AYLIKSARF.Name = "AYLIKSARF";
                    AYLIKSARF.DrawStyle = DrawStyleConstants.vbSolid;
                    AYLIKSARF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AYLIKSARF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AYLIKSARF.TextFont.Name = "Arial";
                    AYLIKSARF.TextFont.Size = 11;
                    AYLIKSARF.Value = @"";

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 23, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.Name = "Arial";
                    COUNTER.TextFont.Size = 11;
                    COUNTER.Value = @"{@groupcounter@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 144, 5, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 11;
                    NSN.Value = @"";

                    AMBALAJ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 165, 5, false);
                    AMBALAJ.Name = "AMBALAJ";
                    AMBALAJ.DrawStyle = DrawStyleConstants.vbSolid;
                    AMBALAJ.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMBALAJ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMBALAJ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMBALAJ.TextFont.Name = "Arial";
                    AMBALAJ.TextFont.Size = 11;
                    AMBALAJ.Value = @"{#PURCHASEITEMCLASS.TYPENAME#}";

                    REQAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 186, 5, false);
                    REQAMOUNT.Name = "REQAMOUNT";
                    REQAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    REQAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQAMOUNT.TextFont.Name = "Arial";
                    REQAMOUNT.TextFont.Size = 11;
                    REQAMOUNT.Value = @"{#PURCHASEITEMCLASS.REQUESTAMOUNT#}";

                    SYMDEPO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 246, 5, false);
                    SYMDEPO.Name = "SYMDEPO";
                    SYMDEPO.DrawStyle = DrawStyleConstants.vbSolid;
                    SYMDEPO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SYMDEPO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SYMDEPO.TextFont.Name = "Arial";
                    SYMDEPO.TextFont.Size = 11;
                    SYMDEPO.Value = @"";

                    KLNDEPO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 268, 5, false);
                    KLNDEPO.Name = "KLNDEPO";
                    KLNDEPO.DrawStyle = DrawStyleConstants.vbSolid;
                    KLNDEPO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLNDEPO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLNDEPO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KLNDEPO.TextFont.Name = "Arial";
                    KLNDEPO.TextFont.Size = 11;
                    KLNDEPO.Value = @"{#PURCHASEITEMCLASS.STORESTOCKS#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 290, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.Size = 11;
                    UNITPRICE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DemandDetail.SatınalmaIstek_DemandDetailQuery_Class dataset_SatınalmaIstek_DemandDetailQuery = MyParentReport.PURCHASEITEMCLASS.rsGroup.GetCurrentRecord<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class>(0);
                    ITEMNAME.CalcValue = (dataset_SatınalmaIstek_DemandDetailQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandDetailQuery.ItemName) : "");
                    TYPENAME.CalcValue = (dataset_SatınalmaIstek_DemandDetailQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandDetailQuery.Typename) : "");
                    AYLIKSARF.CalcValue = AYLIKSARF.Value;
                    COUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    NSN.CalcValue = @"";
                    AMBALAJ.CalcValue = (dataset_SatınalmaIstek_DemandDetailQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandDetailQuery.Typename) : "");
                    REQAMOUNT.CalcValue = (dataset_SatınalmaIstek_DemandDetailQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandDetailQuery.RequestAmount) : "");
                    SYMDEPO.CalcValue = SYMDEPO.Value;
                    KLNDEPO.CalcValue = (dataset_SatınalmaIstek_DemandDetailQuery != null ? Globals.ToStringCore(dataset_SatınalmaIstek_DemandDetailQuery.StoreStocks) : "");
                    UNITPRICE.CalcValue = UNITPRICE.Value;
                    return new TTReportObject[] { ITEMNAME,TYPENAME,AYLIKSARF,COUNTER,NSN,AMBALAJ,REQAMOUNT,SYMDEPO,KLNDEPO,UNITPRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SatinalmaIstegi()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            PURCHASEITEMCLASS = new PURCHASEITEMCLASSGroup(PARTC,"PURCHASEITEMCLASS");
            MAIN = new MAINGroup(PURCHASEITEMCLASS,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İstek No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("4021b1ae-3060-4287-9b28-3de27e5654df");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SATINALMAISTEGI";
            Caption = "Malzeme İstek Raporu";
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