
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
    /// Sayım Tartı Çizelgesi
    /// </summary>
    public partial class CensusScheduleReport2 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public string ASSETACCOUNTANT = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string ACCOUNTRESPONSIBLE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? CARDDRAWERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CensusScheduleReport2 MyParentReport
            {
                get { return (CensusScheduleReport2)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField AdditionNO1 { get {return Header().AdditionNO1;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public CensusScheduleReport2 MyParentReport
                {
                    get { return (CensusScheduleReport2)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField AdditionNO1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 11, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"DEVİR ÇİZELGESİ";

                    AdditionNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    AdditionNO1.Name = "AdditionNO1";
                    AdditionNO1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO1.TextFont.Name = "Arial";
                    AdditionNO1.TextFont.Bold = true;
                    AdditionNO1.TextFont.CharSet = 162;
                    AdditionNO1.Value = @"EK-27";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    AdditionNO1.CalcValue = AdditionNO1.Value;
                    return new TTReportObject[] { ReportName,AdditionNO1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CensusScheduleReport2 MyParentReport
                {
                    get { return (CensusScheduleReport2)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 1, 100, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.Bold = true;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"EK-27-{@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"EK-27-" + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public CensusScheduleReport2 MyParentReport
            {
                get { return (CensusScheduleReport2)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField OldOrderNO { get {return Header().OldOrderNO;} }
            public TTReportField NewOrderNO { get {return Header().NewOrderNO;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField OldOrderNO1 { get {return Header().OldOrderNO1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField AccountantName { get {return Footer().AccountantName;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField AccountResponsibleName { get {return Footer().AccountResponsibleName;} }
            public TTReportField AccountantTitle { get {return Footer().AccountantTitle;} }
            public TTReportField AccountResponsibleTitle { get {return Footer().AccountResponsibleTitle;} }
            public TTReportField AccountantTitleName { get {return Footer().AccountantTitleName;} }
            public TTReportField AccountResponsibleTitleName { get {return Footer().AccountResponsibleTitleName;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField COUNT { get {return Footer().COUNT;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
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
                public CensusScheduleReport2 MyParentReport
                {
                    get { return (CensusScheduleReport2)ParentReport; }
                }
                
                public TTReportField OldOrderNO;
                public TTReportField NewOrderNO;
                public TTReportField NewField11111;
                public TTReportField AMOUNT;
                public TTReportField NewField111211;
                public TTReportField OldOrderNO1;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine2;
                public TTReportShape NewLine14; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OldOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 4, 10, 63, false);
                    OldOrderNO.Name = "OldOrderNO";
                    OldOrderNO.FontAngle = 900;
                    OldOrderNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    OldOrderNO.TextFont.Name = "Arial";
                    OldOrderNO.TextFont.Size = 11;
                    OldOrderNO.TextFont.Bold = true;
                    OldOrderNO.TextFont.CharSet = 162;
                    OldOrderNO.Value = @"BİR ÖNCEKİ YILIN DEVİR";

                    NewOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 4, 30, 63, false);
                    NewOrderNO.Name = "NewOrderNO";
                    NewOrderNO.FontAngle = 900;
                    NewOrderNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewOrderNO.TextFont.Name = "Arial";
                    NewOrderNO.TextFont.Size = 11;
                    NewOrderNO.TextFont.Bold = true;
                    NewOrderNO.TextFont.CharSet = 162;
                    NewOrderNO.Value = @"SIRA NU.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 4, 143, 63, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.FontAngle = 900;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"ÖLÇÜ BİRİMİ";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 4, 164, 63, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FontAngle = 900;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaBottom;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.Size = 11;
                    AMOUNT.TextFont.Bold = true;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"MİKTARI";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 4, 128, 63, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 11;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"




STOK KAYIT KARTININ AİT OLDUĞU
MALIN STOK NUMARASI VE
FENNİ İSMİ";

                    OldOrderNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 15, 63, false);
                    OldOrderNO1.Name = "OldOrderNO1";
                    OldOrderNO1.FontAngle = 900;
                    OldOrderNO1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    OldOrderNO1.TextFont.Name = "Arial";
                    OldOrderNO1.TextFont.Size = 11;
                    OldOrderNO1.TextFont.Bold = true;
                    OldOrderNO1.TextFont.CharSet = 162;
                    OldOrderNO1.Value = @"ÇİZELGESİNDEKİ SIRA NU.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 150, 4, 150, 63, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 4, 170, 63, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 4, 20, 63, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 4, 0, 63, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 63, 170, 63, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 4, 170, 4, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OldOrderNO.CalcValue = OldOrderNO.Value;
                    NewOrderNO.CalcValue = NewOrderNO.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    AMOUNT.CalcValue = AMOUNT.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    OldOrderNO1.CalcValue = OldOrderNO1.Value;
                    return new TTReportObject[] { OldOrderNO,NewOrderNO,NewField11111,AMOUNT,NewField111211,OldOrderNO1};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CensusScheduleReport2 MyParentReport
                {
                    get { return (CensusScheduleReport2)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField AccountantName;
                public TTReportField NewField11;
                public TTReportField AccountResponsibleName;
                public TTReportField AccountantTitle;
                public TTReportField AccountResponsibleTitle;
                public TTReportField AccountantTitleName;
                public TTReportField AccountResponsibleTitleName;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField COUNT;
                public TTReportField TOTAL;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField NewField13; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 90;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 28, 50, 33, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sayman";

                    AccountantName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 38, 50, 43, false);
                    AccountantName.Name = "AccountantName";
                    AccountantName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountantName.CaseFormat = CaseFormatEnum.fcNameSurname;
                    AccountantName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountantName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountantName.NoClip = EvetHayirEnum.ehEvet;
                    AccountantName.ObjectDefName = "ResUser";
                    AccountantName.DataMember = "NAME";
                    AccountantName.TextFont.Name = "Arial";
                    AccountantName.TextFont.CharSet = 162;
                    AccountantName.Value = @"{@ASSETACCOUNTANT@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 28, 170, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Hesap Sorumlusu";

                    AccountResponsibleName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 38, 170, 43, false);
                    AccountResponsibleName.Name = "AccountResponsibleName";
                    AccountResponsibleName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountResponsibleName.CaseFormat = CaseFormatEnum.fcNameSurname;
                    AccountResponsibleName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountResponsibleName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountResponsibleName.NoClip = EvetHayirEnum.ehEvet;
                    AccountResponsibleName.ObjectDefName = "ResUser";
                    AccountResponsibleName.DataMember = "NAME";
                    AccountResponsibleName.TextFont.Name = "Arial";
                    AccountResponsibleName.TextFont.CharSet = 162;
                    AccountResponsibleName.Value = @"{@ACCOUNTRESPONSIBLE@}";

                    AccountantTitle = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 2, 239, 7, false);
                    AccountantTitle.Name = "AccountantTitle";
                    AccountantTitle.Visible = EvetHayirEnum.ehHayir;
                    AccountantTitle.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountantTitle.ObjectDefName = "ResUser";
                    AccountantTitle.DataMember = "TITLE";
                    AccountantTitle.Value = @"{@ASSETACCOUNTANT@}";

                    AccountResponsibleTitle = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 7, 239, 12, false);
                    AccountResponsibleTitle.Name = "AccountResponsibleTitle";
                    AccountResponsibleTitle.Visible = EvetHayirEnum.ehHayir;
                    AccountResponsibleTitle.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountResponsibleTitle.ObjectDefName = "ResUser";
                    AccountResponsibleTitle.DataMember = "TITLE";
                    AccountResponsibleTitle.Value = @"{@ACCOUNTRESPONSIBLE@}";

                    AccountantTitleName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 33, 50, 38, false);
                    AccountantTitleName.Name = "AccountantTitleName";
                    AccountantTitleName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountantTitleName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    AccountantTitleName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountantTitleName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountantTitleName.NoClip = EvetHayirEnum.ehEvet;
                    AccountantTitleName.ObjectDefName = "UserTitleEnum";
                    AccountantTitleName.DataMember = "DISPLAYTEXT";
                    AccountantTitleName.TextFont.Name = "Arial";
                    AccountantTitleName.TextFont.CharSet = 162;
                    AccountantTitleName.Value = @"{%AccountantTitle%}";

                    AccountResponsibleTitleName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 33, 170, 38, false);
                    AccountResponsibleTitleName.Name = "AccountResponsibleTitleName";
                    AccountResponsibleTitleName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountResponsibleTitleName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    AccountResponsibleTitleName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountResponsibleTitleName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountResponsibleTitleName.NoClip = EvetHayirEnum.ehEvet;
                    AccountResponsibleTitleName.ObjectDefName = "UserTitleEnum";
                    AccountResponsibleTitleName.DataMember = "DISPLAYTEXT";
                    AccountResponsibleTitleName.TextFont.Name = "Arial";
                    AccountResponsibleTitleName.TextFont.CharSet = 162;
                    AccountResponsibleTitleName.Value = @"{%AccountResponsibleTitle%}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 43, 50, 58, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 43, 170, 58, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 170, 8, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"///// Yalnız {@subgroupcount@} Kalemdir. /////";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 9, 170, 19, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.MultiLine = EvetHayirEnum.ehEvet;
                    TOTAL.WordBreak = EvetHayirEnum.ehEvet;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 2, 267, 7, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT.Value = @"{@subgroupcount@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 53, 100, 58, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"O N A Y";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    AccountantName.CalcValue = MyParentReport.RuntimeParameters.ASSETACCOUNTANT.ToString();
                    AccountantName.PostFieldValueCalculation();
                    NewField11.CalcValue = NewField11.Value;
                    AccountResponsibleName.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTRESPONSIBLE.ToString();
                    AccountResponsibleName.PostFieldValueCalculation();
                    AccountantTitle.CalcValue = MyParentReport.RuntimeParameters.ASSETACCOUNTANT.ToString();
                    AccountantTitle.PostFieldValueCalculation();
                    AccountResponsibleTitle.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTRESPONSIBLE.ToString();
                    AccountResponsibleTitle.PostFieldValueCalculation();
                    AccountantTitleName.CalcValue = MyParentReport.PARTB.AccountantTitle.CalcValue;
                    AccountantTitleName.PostFieldValueCalculation();
                    AccountResponsibleTitleName.CalcValue = MyParentReport.PARTB.AccountResponsibleTitle.CalcValue;
                    AccountResponsibleTitleName.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    COUNT.CalcValue = @"///// Yalnız " + (ParentGroup.SubGroupCount - 1).ToString() + @" Kalemdir. /////";
                    TOTAL.CalcValue = @"";
                    SUBGROUPCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField1,AccountantName,NewField11,AccountResponsibleName,AccountantTitle,AccountResponsibleTitle,AccountantTitleName,AccountResponsibleTitleName,NewField2,NewField12,COUNT,TOTAL,SUBGROUPCOUNT,NewField13};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string termID = ((CensusScheduleReport2)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(accountingTerm.EndDate != null)
                TOTAL.CalcValue = Convert.ToDateTime(accountingTerm.EndDate).Year.ToString() + " bütçe / takvim yılı teftişine ibraz edilen bu devir çizelgesi " + SUBGROUPCOUNT.CalcValue + " kalem mal ve " + PARTBGroup.zeroCensus.ToString() + " kalem sıfır devirli malı kapsar.";
            PARTBGroup.zeroCensus = 0;
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static int zeroCensus = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public CensusScheduleReport2 MyParentReport
            {
                get { return (CensusScheduleReport2)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OLDORDERNO { get {return Body().OLDORDERNO;} }
            public TTReportField NEWORDERNO { get {return Body().NEWORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine113 { get {return Body().NewLine113;} }
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
                list[0] = new TTReportNqlData<StockCensus.GetCensusScheduleReportQuery_Class>("GetCensusScheduleReportQuery", StockCensus.GetCensusScheduleReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWERID)));
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
                public CensusScheduleReport2 MyParentReport
                {
                    get { return (CensusScheduleReport2)ParentReport; }
                }
                
                public TTReportField OLDORDERNO;
                public TTReportField NEWORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField TOTAL;
                public TTReportShape NewLine111;
                public TTReportShape NewLine113; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 18;
                    RepeatCount = 0;
                    
                    OLDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 20, 13, false);
                    OLDORDERNO.Name = "OLDORDERNO";
                    OLDORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    OLDORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    OLDORDERNO.TextFont.Name = "Arial";
                    OLDORDERNO.TextFont.CharSet = 162;
                    OLDORDERNO.Value = @"{#OLDORDERNO#}";

                    NEWORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 35, 13, false);
                    NEWORDERNO.Name = "NEWORDERNO";
                    NEWORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    NEWORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    NEWORDERNO.TextFont.Name = "Arial";
                    NEWORDERNO.TextFont.CharSet = 162;
                    NEWORDERNO.Value = @"{#NEWORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 128, 13, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#NATOSTOCKNO#} - {#MATERIALNAME#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 150, 13, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 170, 13, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.MultiLine = EvetHayirEnum.ehEvet;
                    TOTAL.WordBreak = EvetHayirEnum.ehEvet;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"{#TOTAL#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 13, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 13, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetCensusScheduleReportQuery_Class dataset_GetCensusScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetCensusScheduleReportQuery_Class>(0);
                    OLDORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Oldorderno) : "");
                    NEWORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Neworderno) : "");
                    MATERIALNAME.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.NATOStockNO) : "") + @" - " + (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Materialname) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.DistributionType) : "");
                    TOTAL.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Total) : "");
                    return new TTReportObject[] { OLDORDERNO,NEWORDERNO,MATERIALNAME,DISTRIBUTIONTYPE,TOTAL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(TOTAL.CalcValue == "0")
            {
                PARTBGroup.zeroCensus++;
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

        public CensusScheduleReport2()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Devri Yapılacak Depoyu Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Devri Yapılacak Dönemi Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("ASSETACCOUNTANT", "", "Mal Saymanını Seçiniz", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter.ListFilterExpression = "USERTYPE = 20";
            reportParameter = Parameters.Add("ACCOUNTRESPONSIBLE", "", "Mal Sorumlusunu Seçiniz", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter.ListFilterExpression = "USERTYPE = 21";
            reportParameter = Parameters.Add("CARDDRAWERID", "00000000-0000-0000-0000-000000000000", "Masa", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("ASSETACCOUNTANT"))
                _runtimeParameters.ASSETACCOUNTANT = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ASSETACCOUNTANT"]);
            if (parameters.ContainsKey("ACCOUNTRESPONSIBLE"))
                _runtimeParameters.ACCOUNTRESPONSIBLE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ACCOUNTRESPONSIBLE"]);
            if (parameters.ContainsKey("CARDDRAWERID"))
                _runtimeParameters.CARDDRAWERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CARDDRAWERID"]);
            Name = "CENSUSSCHEDULEREPORT2";
            Caption = "Sayım Tartı Çizelgesi";
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