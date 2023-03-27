
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
    /// E2 Çizelgesi
    /// </summary>
    public partial class E2_Report : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public E2_Report MyParentReport
            {
                get { return (E2_Report)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField SDATE { get {return Header().SDATE;} }
            public TTReportField EDATE { get {return Header().EDATE;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportField NewField155 { get {return Header().NewField155;} }
            public TTReportField REFERENCEID { get {return Header().REFERENCEID;} }
            public TTReportField REFSEQNO { get {return Header().REFSEQNO;} }
            public TTReportField NewField188 { get {return Header().NewField188;} }
            public TTReportField FILLDATE { get {return Header().FILLDATE;} }
            public TTReportField HOSPITALNAMEHEADER { get {return Header().HOSPITALNAMEHEADER;} }
            public TTReportField HOSPITALCITYHEADER { get {return Header().HOSPITALCITYHEADER;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField NewField101 { get {return Footer().NewField101;} }
            public TTReportField PAGENUMBER1 { get {return Footer().PAGENUMBER1;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public E2_Report MyParentReport
                {
                    get { return (E2_Report)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField SDATE;
                public TTReportField EDATE;
                public TTReportField NewField144;
                public TTReportField NewField155;
                public TTReportField REFERENCEID;
                public TTReportField REFSEQNO;
                public TTReportField NewField188;
                public TTReportField FILLDATE;
                public TTReportField HOSPITALNAMEHEADER;
                public TTReportField HOSPITALCITYHEADER; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 21, 205, 25, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{%SDATE%} - {%EDATE%} Tarihleri Arası E2 TEVHİT CETVELİ";

                    SDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 26, 46, 30, false);
                    SDATE.Name = "SDATE";
                    SDATE.Visible = EvetHayirEnum.ehHayir;
                    SDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SDATE.TextFormat = @"DD/MM/YYYY HH:MM";
                    SDATE.ObjectDefName = "E2";
                    SDATE.DataMember = "STARTDATE";
                    SDATE.TextFont.Name = "Courier New";
                    SDATE.TextFont.CharSet = 162;
                    SDATE.Value = @"{@TTOBJECTID@}";

                    EDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 26, 59, 30, false);
                    EDATE.Name = "EDATE";
                    EDATE.Visible = EvetHayirEnum.ehHayir;
                    EDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EDATE.TextFormat = @"DD/MM/YYYY HH:MM";
                    EDATE.ObjectDefName = "E2";
                    EDATE.DataMember = "ENDDATE";
                    EDATE.TextFont.Name = "Courier New";
                    EDATE.TextFont.CharSet = 162;
                    EDATE.Value = @"{@TTOBJECTID@}";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 27, 147, 32, false);
                    NewField144.Name = "NewField144";
                    NewField144.TextFont.CharSet = 162;
                    NewField144.Value = @"Belge Kayıt No     :";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 33, 147, 38, false);
                    NewField155.Name = "NewField155";
                    NewField155.TextFont.CharSet = 162;
                    NewField155.Value = @"Belge Kayıt Tarihi :";

                    REFERENCEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 27, 166, 32, false);
                    REFERENCEID.Name = "REFERENCEID";
                    REFERENCEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFERENCEID.ObjectDefName = "E2";
                    REFERENCEID.DataMember = "REGISTRATIONNUMBER";
                    REFERENCEID.TextFont.CharSet = 162;
                    REFERENCEID.Value = @"{@TTOBJECTID@}";

                    REFSEQNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 27, 188, 32, false);
                    REFSEQNO.Name = "REFSEQNO";
                    REFSEQNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFSEQNO.TextFormat = @"#";
                    REFSEQNO.ObjectDefName = "E2";
                    REFSEQNO.DataMember = "SEQUENCENUMBER";
                    REFSEQNO.TextFont.CharSet = 162;
                    REFSEQNO.Value = @"{@TTOBJECTID@}";

                    NewField188 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 27, 172, 32, false);
                    NewField188.Name = "NewField188";
                    NewField188.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField188.TextFont.CharSet = 162;
                    NewField188.Value = @"/";

                    FILLDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 33, 174, 38, false);
                    FILLDATE.Name = "FILLDATE";
                    FILLDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FILLDATE.TextFormat = @"DD/MM/YYYY";
                    FILLDATE.ObjectDefName = "E2";
                    FILLDATE.DataMember = "TRANSACTIONDATE";
                    FILLDATE.TextFont.CharSet = 162;
                    FILLDATE.Value = @"{@TTOBJECTID@}";

                    HOSPITALNAMEHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 3, 188, 11, false);
                    HOSPITALNAMEHEADER.Name = "HOSPITALNAMEHEADER";
                    HOSPITALNAMEHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAMEHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAMEHEADER.TextFont.Size = 11;
                    HOSPITALNAMEHEADER.TextFont.Bold = true;
                    HOSPITALNAMEHEADER.TextFont.CharSet = 162;
                    HOSPITALNAMEHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    HOSPITALCITYHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 11, 188, 18, false);
                    HOSPITALCITYHEADER.Name = "HOSPITALCITYHEADER";
                    HOSPITALCITYHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALCITYHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALCITYHEADER.TextFont.Size = 11;
                    HOSPITALCITYHEADER.TextFont.Bold = true;
                    HOSPITALCITYHEADER.TextFont.CharSet = 162;
                    HOSPITALCITYHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SDATE.PostFieldValueCalculation();
                    EDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    EDATE.PostFieldValueCalculation();
                    DESCRIPTION.CalcValue = MyParentReport.PARTB.SDATE.FormattedValue + @" - " + MyParentReport.PARTB.EDATE.FormattedValue + @" Tarihleri Arası E2 TEVHİT CETVELİ";
                    NewField144.CalcValue = NewField144.Value;
                    NewField155.CalcValue = NewField155.Value;
                    REFERENCEID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    REFERENCEID.PostFieldValueCalculation();
                    REFSEQNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    REFSEQNO.PostFieldValueCalculation();
                    NewField188.CalcValue = NewField188.Value;
                    FILLDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FILLDATE.PostFieldValueCalculation();
                    HOSPITALNAMEHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HOSPITALCITYHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { SDATE,EDATE,DESCRIPTION,NewField144,NewField155,REFERENCEID,REFSEQNO,NewField188,FILLDATE,HOSPITALNAMEHEADER,HOSPITALCITYHEADER};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public E2_Report MyParentReport
                {
                    get { return (E2_Report)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField101;
                public TTReportField PAGENUMBER1;
                public TTReportField NewField19;
                public TTReportShape NewLine1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 61;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 24, 188, 29, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Başeczacı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 24, 120, 29, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Sayman";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 24, 52, 29, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Eczane Şefi";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 44, 120, 49, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Onay";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 189, 7, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"* Bu çizelge her ay sonunda Eczacı tarafından 3 nüsha hazırlanır.";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 189, 12, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"* 3. nüshası Eczacıda belge kayıt numarası verilene kadar takip için bekletilir.";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 189, 22, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"* Bu belge teftişe tabii olup istendiğinde müfettişe verilmek üzere dosyada muhafaza edilir.";

                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 52, 187, 57, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"Sayfa : {@pagenumber@}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 189, 17, false);
                    NewField19.Name = "NewField19";
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"* 1. ve 2. nüshası saymanlığa verilir. Belge kayıt numarası verildikten sonra 2. nüshası Eczacıya teslim edilir.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, -1, 187, -1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField101.CalcValue = NewField101.Value;
                    PAGENUMBER1.CalcValue = @"Sayfa : " + ParentReport.CurrentPageNumber.ToString();
                    NewField19.CalcValue = NewField19.Value;
                    return new TTReportObject[] { NewField13,NewField14,NewField15,NewField16,NewField17,NewField18,NewField101,PAGENUMBER1,NewField19};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public E2_Report MyParentReport
            {
                get { return (E2_Report)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField YALNIZ { get {return Footer().YALNIZ;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportShape NewLine15 { get {return Footer().NewLine15;} }
            public TTReportField KALEM { get {return Footer().KALEM;} }
            public TTReportField KALEMTEXT { get {return Footer().KALEMTEXT;} }
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
                public E2_Report MyParentReport
                {
                    get { return (E2_Report)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 2, 186, 9, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Miktarı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 2, 172, 9, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ölçü";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 2, 156, 9, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İlaçların İsimleri";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 22, 9, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Sıra No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField10,NewField11,NewField12,NewField13};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public E2_Report MyParentReport
                {
                    get { return (E2_Report)ParentReport; }
                }
                
                public TTReportField YALNIZ;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportField KALEM;
                public TTReportField KALEMTEXT; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    YALNIZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 186, 5, false);
                    YALNIZ.Name = "YALNIZ";
                    YALNIZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    YALNIZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YALNIZ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YALNIZ.TextFont.CharSet = 162;
                    YALNIZ.Value = @"/////////////////////////////////////////////////////////////////////////////////////////////Yalnız {%KALEM%} ({%KALEMTEXT%}) kalemdir. /////////////////////////////////////////////////////////////////////////////////////////////";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 8, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 1, 22, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 156, 1, 156, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 172, 1, 172, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 186, 1, 186, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    KALEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 198, 5, false);
                    KALEM.Name = "KALEM";
                    KALEM.Visible = EvetHayirEnum.ehHayir;
                    KALEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALEM.TextFont.Name = "Courier New";
                    KALEM.TextFont.CharSet = 162;
                    KALEM.Value = @"{@subgroupcount@}";

                    KALEMTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, -1, 206, 3, false);
                    KALEMTEXT.Name = "KALEMTEXT";
                    KALEMTEXT.Visible = EvetHayirEnum.ehHayir;
                    KALEMTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALEMTEXT.TextFormat = @"NUMBERTEXT";
                    KALEMTEXT.TextFont.CharSet = 162;
                    KALEMTEXT.Value = @"{%KALEM%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KALEM.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    KALEMTEXT.CalcValue = MyParentReport.PARTA.KALEM.CalcValue;
                    YALNIZ.CalcValue = @"/////////////////////////////////////////////////////////////////////////////////////////////Yalnız " + MyParentReport.PARTA.KALEM.CalcValue + @" (" + MyParentReport.PARTA.KALEMTEXT.FormattedValue + @") kalemdir. /////////////////////////////////////////////////////////////////////////////////////////////";
                    return new TTReportObject[] { KALEM,KALEMTEXT,YALNIZ};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public E2_Report MyParentReport
            {
                get { return (E2_Report)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField BIRIM { get {return Body().BIRIM;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField FULLDESC { get {return Body().FULLDESC;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public E2_Report MyParentReport
                {
                    get { return (E2_Report)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField BIRIM;
                public TTReportField SNO;
                public TTReportField FULLDESC; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 186, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"###,##0";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 172, 5, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#DISTRIBUTIONTYPE#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 22, 5, false);
                    SNO.Name = "SNO";
                    SNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@counter@}";

                    FULLDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 156, 5, false);
                    FULLDESC.Name = "FULLDESC";
                    FULLDESC.DrawStyle = DrawStyleConstants.vbSolid;
                    FULLDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLDESC.TextFont.CharSet = 162;
                    FULLDESC.Value = @"{#NATOSTOCKNO#} {#MATERIALNAME#} ({#STOCKCARDCLASSCODE#} - {#CARDORDERNO#})";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    BIRIM.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    SNO.CalcValue = ParentGroup.Counter.ToString();
                    FULLDESC.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "") + @" " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "") + @" (" + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockcardclasscode) : "") + @" - " + (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.CardOrderNO) : "") + @")";
                    return new TTReportObject[] { AMOUNT,BIRIM,SNO,FULLDESC};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public E2_Report()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "E2 Çizelgesi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "E2_REPORT";
            Caption = "E2 Çizelgesi";
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