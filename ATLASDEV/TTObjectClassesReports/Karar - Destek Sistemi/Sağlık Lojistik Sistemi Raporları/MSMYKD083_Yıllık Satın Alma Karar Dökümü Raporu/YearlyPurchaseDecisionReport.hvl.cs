
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
    /// Yıllık Satın Alma Karar Dökümü Raporu
    /// </summary>
    public partial class YearlyPurchaseDecisionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public string ACCOUNTYEAR = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue("2010");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public YearlyPurchaseDecisionReport MyParentReport
            {
                get { return (YearlyPurchaseDecisionReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public YearlyPurchaseDecisionReport MyParentReport
                {
                    get { return (YearlyPurchaseDecisionReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField171;
                public TTReportField NewField1171; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"YILLIK SATIN ALMA KARAR DÖKÜMÜ RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 20, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Proje Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 25, 42, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 25, 93, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İstek Yapan Depo";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 25, 123, 35, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Durumu";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 25, 169, 35, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"İhale Şekli";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 25, 144, 35, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"İhale Türü";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 25, 225, 35, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"İstek Yapılan Malzeme";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 25, 257, 30, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Miktar";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 30, 241, 35, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"İstenen";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 30, 257, 35, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"Onay";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    return new TTReportObject[] { LOGO,REPORTNAME,NewField1,NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,NewField17,NewField171,NewField1171};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public YearlyPurchaseDecisionReport MyParentReport
                {
                    get { return (YearlyPurchaseDecisionReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 142, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public YearlyPurchaseDecisionReport MyParentReport
            {
                get { return (YearlyPurchaseDecisionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROJECTNO { get {return Body().PROJECTNO;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField MASTERRESOURCE { get {return Body().MASTERRESOURCE;} }
            public TTReportField STATE { get {return Body().STATE;} }
            public TTReportField PURCHASEMAINTYPE { get {return Body().PURCHASEMAINTYPE;} }
            public TTReportField PURCHASETYPE { get {return Body().PURCHASETYPE;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField SUPPLIEDAMOUNT { get {return Body().SUPPLIEDAMOUNT;} }
            public TTReportField REQUESTEDAMOUNT { get {return Body().REQUESTEDAMOUNT;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class>("GetYearlyPurchaseDecisionReportQuery", PurchaseProject.GetYearlyPurchaseDecisionReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PROJECTNO),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALID),(string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTYEAR)));
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
                public YearlyPurchaseDecisionReport MyParentReport
                {
                    get { return (YearlyPurchaseDecisionReport)ParentReport; }
                }
                
                public TTReportField PROJECTNO;
                public TTReportField ACTIONDATE;
                public TTReportField MASTERRESOURCE;
                public TTReportField STATE;
                public TTReportField PURCHASEMAINTYPE;
                public TTReportField PURCHASETYPE;
                public TTReportField MATERIALNAME;
                public TTReportField SUPPLIEDAMOUNT;
                public TTReportField REQUESTEDAMOUNT;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 20, 13, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"{#PURCHASEPROJECTNO#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 42, 13, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    ACTIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTIONDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTIONDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTIONDATE.TextFont.Name = "Arial";
                    ACTIONDATE.TextFont.CharSet = 162;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 93, 13, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MASTERRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MASTERRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.TextFont.Name = "Arial";
                    MASTERRESOURCE.TextFont.CharSet = 162;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                    STATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 123, 13, false);
                    STATE.Name = "STATE";
                    STATE.DrawStyle = DrawStyleConstants.vbSolid;
                    STATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATE.MultiLine = EvetHayirEnum.ehEvet;
                    STATE.WordBreak = EvetHayirEnum.ehEvet;
                    STATE.TextFont.Name = "Arial";
                    STATE.TextFont.CharSet = 162;
                    STATE.Value = @"";

                    PURCHASEMAINTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 144, 13, false);
                    PURCHASEMAINTYPE.Name = "PURCHASEMAINTYPE";
                    PURCHASEMAINTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEMAINTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEMAINTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURCHASEMAINTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEMAINTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    PURCHASEMAINTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    PURCHASEMAINTYPE.ObjectDefName = "PurchaseMainTypeEnum";
                    PURCHASEMAINTYPE.DataMember = "DISPLAYTEXT";
                    PURCHASEMAINTYPE.TextFont.Name = "Arial";
                    PURCHASEMAINTYPE.TextFont.CharSet = 162;
                    PURCHASEMAINTYPE.Value = @"{#PURCHASEMAINTYPE#}";

                    PURCHASETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 169, 13, false);
                    PURCHASETYPE.Name = "PURCHASETYPE";
                    PURCHASETYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASETYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASETYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURCHASETYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASETYPE.MultiLine = EvetHayirEnum.ehEvet;
                    PURCHASETYPE.WordBreak = EvetHayirEnum.ehEvet;
                    PURCHASETYPE.TextFont.Name = "Arial";
                    PURCHASETYPE.TextFont.CharSet = 162;
                    PURCHASETYPE.Value = @"{#PURCHASETYPENAME#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 225, 13, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#ITEMNAME#}";

                    SUPPLIEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 257, 13, false);
                    SUPPLIEDAMOUNT.Name = "SUPPLIEDAMOUNT";
                    SUPPLIEDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIEDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIEDAMOUNT.TextFormat = @"#,###";
                    SUPPLIEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIEDAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIEDAMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIEDAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIEDAMOUNT.TextFont.Name = "Arial";
                    SUPPLIEDAMOUNT.TextFont.CharSet = 162;
                    SUPPLIEDAMOUNT.Value = @"{#AMOUNT#}";

                    REQUESTEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 0, 241, 13, false);
                    REQUESTEDAMOUNT.Name = "REQUESTEDAMOUNT";
                    REQUESTEDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTEDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDAMOUNT.TextFormat = @"#,###";
                    REQUESTEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTEDAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTEDAMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTEDAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTEDAMOUNT.TextFont.Name = "Arial";
                    REQUESTEDAMOUNT.TextFont.CharSet = 162;
                    REQUESTEDAMOUNT.Value = @"{#REQUESTEDAMOUNT#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 3, 335, 16, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class dataset_GetYearlyPurchaseDecisionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class>(0);
                    PROJECTNO.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.PurchaseProjectNO) : "");
                    ACTIONDATE.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.ActionDate) : "");
                    MASTERRESOURCE.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.Masterresource) : "");
                    STATE.CalcValue = @"";
                    PURCHASEMAINTYPE.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.PurchaseMainType) : "");
                    PURCHASEMAINTYPE.PostFieldValueCalculation();
                    PURCHASETYPE.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.PurchaseTypeName) : "");
                    MATERIALNAME.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.ItemName) : "");
                    SUPPLIEDAMOUNT.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.Amount) : "");
                    REQUESTEDAMOUNT.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.RequestedAmount) : "");
                    OBJECTID.CalcValue = (dataset_GetYearlyPurchaseDecisionReportQuery != null ? Globals.ToStringCore(dataset_GetYearlyPurchaseDecisionReportQuery.ObjectID) : "");
                    return new TTReportObject[] { PROJECTNO,ACTIONDATE,MASTERRESOURCE,STATE,PURCHASEMAINTYPE,PURCHASETYPE,MATERIALNAME,SUPPLIEDAMOUNT,REQUESTEDAMOUNT,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(OBJECTID.CalcValue), typeof(PurchaseProject));
            STATE.CalcValue = pp.CurrentStateDef.DisplayText.ToString();
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

        public YearlyPurchaseDecisionReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PROJECTNO", "00000000-0000-0000-0000-000000000000", "Proje Numarasını Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
            reportParameter = Parameters.Add("MASTERID", "00000000-0000-0000-0000-000000000000", "İstek Yapan Birimi Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("MATERIALID", "00000000-0000-0000-0000-000000000000", "Malzeme Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
            reportParameter = Parameters.Add("ACCOUNTYEAR", "2010", "Mali Yılı Giriniz", @"", true, true, false, new Guid("5dcf77fd-4b8d-479a-9e5e-e5e7414cf8b6"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PROJECTNO"))
                _runtimeParameters.PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PROJECTNO"]);
            if (parameters.ContainsKey("MASTERID"))
                _runtimeParameters.MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MASTERID"]);
            if (parameters.ContainsKey("MATERIALID"))
                _runtimeParameters.MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIALID"]);
            if (parameters.ContainsKey("ACCOUNTYEAR"))
                _runtimeParameters.ACCOUNTYEAR = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue(parameters["ACCOUNTYEAR"]);
            Name = "YEARLYPURCHASEDECISIONREPORT";
            Caption = "Yıllık Satın Alma Karar Dökümü Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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