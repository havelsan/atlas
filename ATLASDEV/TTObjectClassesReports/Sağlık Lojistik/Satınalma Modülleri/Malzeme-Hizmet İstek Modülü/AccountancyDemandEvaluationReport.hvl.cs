
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
    /// Saymanlık İstek Değerlendirme Çizelgesi Raporu
    /// </summary>
    public partial class AccountancyDemandEvaluationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public long? DEMANDNO = (long?)TTObjectDefManager.Instance.DataTypes["RequestNo_Seq"].ConvertValue("0");
            public Guid? PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DemandTypeEnum? DEMANDTYPE = (DemandTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["DemandTypeEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public AccountancyDemandEvaluationReport MyParentReport
            {
                get { return (AccountancyDemandEvaluationReport)ParentReport; }
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
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField DEMANDTYPE { get {return Header().DEMANDTYPE;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public AccountancyDemandEvaluationReport MyParentReport
                {
                    get { return (AccountancyDemandEvaluationReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField REPORTNAME;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField1171;
                public TTReportField NewField11711;
                public TTReportField NewField1111;
                public TTReportField NewField1131;
                public TTReportField DEMANDTYPE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 272, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"SAYMANLIK İSTEK DEĞERLENDİRME ÇİZELGESİ RAPORU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 35, 39, 45, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İstek Tarihi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 35, 18, 45, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İstek Nu.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 35, 113, 45, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İstek Yapan Birim";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 18, 30, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İstek Türü";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 35, 165, 45, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Saymanlık";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 35, 272, 45, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Ölçü Birimi";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 35, 214, 45, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"İstek Yapılan Malzeme";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 35, 246, 40, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Miktar";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 40, 230, 45, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"İstenen";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 40, 246, 45, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"Onay";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 35, 58, 45, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Proje Nu.";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 25, 19, 30, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    DEMANDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 25, 46, 30, false);
                    DEMANDTYPE.Name = "DEMANDTYPE";
                    DEMANDTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEMANDTYPE.NoClip = EvetHayirEnum.ehEvet;
                    DEMANDTYPE.ObjectDefName = "DemandTypeEnum";
                    DEMANDTYPE.DataMember = "DISPLAYTEXT";
                    DEMANDTYPE.TextFont.Name = "Arial";
                    DEMANDTYPE.TextFont.CharSet = 162;
                    DEMANDTYPE.Value = @"{@DEMANDTYPE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    DEMANDTYPE.CalcValue = MyParentReport.RuntimeParameters.DEMANDTYPE.ToString();
                    DEMANDTYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { LOGO,REPORTNAME,NewField11,NewField111,NewField121,NewField131,NewField141,NewField151,NewField161,NewField171,NewField1171,NewField11711,NewField1111,NewField1131,DEMANDTYPE};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public AccountancyDemandEvaluationReport MyParentReport
                {
                    get { return (AccountancyDemandEvaluationReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 152, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 272, 5, false);
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

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 272, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

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
            public AccountancyDemandEvaluationReport MyParentReport
            {
                get { return (AccountancyDemandEvaluationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROJECTNO { get {return Body().PROJECTNO;} }
            public TTReportField DEMANDNO { get {return Body().DEMANDNO;} }
            public TTReportField MASTERRESOURCE { get {return Body().MASTERRESOURCE;} }
            public TTReportField DEMANDDATE { get {return Body().DEMANDDATE;} }
            public TTReportField ACCOUNTANCY { get {return Body().ACCOUNTANCY;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField SUPPLIEDAMOUNT1 { get {return Body().SUPPLIEDAMOUNT1;} }
            public TTReportField REQUESTEDAMOUNT1 { get {return Body().REQUESTEDAMOUNT1;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
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
                list[0] = new TTReportNqlData<Demand.GetAccountancyDemandEvaluationReportQuery_Class>("GetAccountancyDemandEvaluationReportQuery", Demand.GetAccountancyDemandEvaluationReportQuery((long)TTObjectDefManager.Instance.DataTypes["RequestNo_Seq"].ConvertValue(MyParentReport.RuntimeParameters.DEMANDNO),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PROJECTNO),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALID),((DemandTypeEnum)TTObjectDefManager.Instance.DataTypes["DemandTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.DEMANDTYPE.ToString()].EnumValue)));
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
                public AccountancyDemandEvaluationReport MyParentReport
                {
                    get { return (AccountancyDemandEvaluationReport)ParentReport; }
                }
                
                public TTReportField PROJECTNO;
                public TTReportField DEMANDNO;
                public TTReportField MASTERRESOURCE;
                public TTReportField DEMANDDATE;
                public TTReportField ACCOUNTANCY;
                public TTReportField MATERIALNAME;
                public TTReportField SUPPLIEDAMOUNT1;
                public TTReportField REQUESTEDAMOUNT1;
                public TTReportField DISTRIBUTIONTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 0, 58, 9, false);
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

                    DEMANDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 18, 9, false);
                    DEMANDNO.Name = "DEMANDNO";
                    DEMANDNO.DrawStyle = DrawStyleConstants.vbSolid;
                    DEMANDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEMANDNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEMANDNO.MultiLine = EvetHayirEnum.ehEvet;
                    DEMANDNO.WordBreak = EvetHayirEnum.ehEvet;
                    DEMANDNO.TextFont.Name = "Arial";
                    DEMANDNO.TextFont.CharSet = 162;
                    DEMANDNO.Value = @"{#REQUESTNO#}";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 0, 113, 9, false);
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

                    DEMANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 39, 9, false);
                    DEMANDDATE.Name = "DEMANDDATE";
                    DEMANDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DEMANDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEMANDDATE.TextFormat = @"dd/MM/yyyy";
                    DEMANDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEMANDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEMANDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    DEMANDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    DEMANDDATE.TextFont.Name = "Arial";
                    DEMANDDATE.TextFont.CharSet = 162;
                    DEMANDDATE.Value = @"{#DEMANDDATE#}";

                    ACCOUNTANCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 165, 9, false);
                    ACCOUNTANCY.Name = "ACCOUNTANCY";
                    ACCOUNTANCY.DrawStyle = DrawStyleConstants.vbSolid;
                    ACCOUNTANCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCY.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANCY.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANCY.TextFont.Name = "Arial";
                    ACCOUNTANCY.TextFont.CharSet = 162;
                    ACCOUNTANCY.Value = @"{#ACCOUNTANCY#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 214, 9, false);
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

                    SUPPLIEDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 246, 9, false);
                    SUPPLIEDAMOUNT1.Name = "SUPPLIEDAMOUNT1";
                    SUPPLIEDAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIEDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIEDAMOUNT1.TextFormat = @"#,###";
                    SUPPLIEDAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIEDAMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIEDAMOUNT1.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIEDAMOUNT1.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIEDAMOUNT1.TextFont.Name = "Arial";
                    SUPPLIEDAMOUNT1.TextFont.CharSet = 162;
                    SUPPLIEDAMOUNT1.Value = @"{#AMOUNT#}";

                    REQUESTEDAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 230, 9, false);
                    REQUESTEDAMOUNT1.Name = "REQUESTEDAMOUNT1";
                    REQUESTEDAMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTEDAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDAMOUNT1.TextFormat = @"#,###";
                    REQUESTEDAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTEDAMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTEDAMOUNT1.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTEDAMOUNT1.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTEDAMOUNT1.TextFont.Name = "Arial";
                    REQUESTEDAMOUNT1.TextFont.CharSet = 162;
                    REQUESTEDAMOUNT1.Value = @"{#REQUESTAMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 272, 9, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#TYPENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Demand.GetAccountancyDemandEvaluationReportQuery_Class dataset_GetAccountancyDemandEvaluationReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Demand.GetAccountancyDemandEvaluationReportQuery_Class>(0);
                    PROJECTNO.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.PurchaseProjectNO) : "");
                    DEMANDNO.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.RequestNo) : "");
                    MASTERRESOURCE.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.Masterresource) : "");
                    DEMANDDATE.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.DemandDate) : "");
                    ACCOUNTANCY.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.Accountancy) : "");
                    MATERIALNAME.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.ItemName) : "");
                    SUPPLIEDAMOUNT1.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.Amount) : "");
                    REQUESTEDAMOUNT1.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.RequestAmount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetAccountancyDemandEvaluationReportQuery != null ? Globals.ToStringCore(dataset_GetAccountancyDemandEvaluationReportQuery.Typename) : "");
                    return new TTReportObject[] { PROJECTNO,DEMANDNO,MASTERRESOURCE,DEMANDDATE,ACCOUNTANCY,MATERIALNAME,SUPPLIEDAMOUNT1,REQUESTEDAMOUNT1,DISTRIBUTIONTYPE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AccountancyDemandEvaluationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DEMANDNO", "0", "İstek Numarasını Giriniz", @"", true, true, false, new Guid("22f4f714-4a34-47e4-a2a3-64eb29ec2d08"));
            reportParameter = Parameters.Add("PROJECTNO", "00000000-0000-0000-0000-000000000000", "Proje Numarasını Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
            reportParameter = Parameters.Add("MASTERID", "00000000-0000-0000-0000-000000000000", "İstek Yapan Birimi Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("MATERIALID", "00000000-0000-0000-0000-000000000000", "İstek Kalemini Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
            reportParameter = Parameters.Add("DEMANDTYPE", "", "İstek Türünü Seçiniz", @"", true, true, false, new Guid("4854ce27-f786-4781-b0fa-ce78323b0a1b"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DEMANDNO"))
                _runtimeParameters.DEMANDNO = (long?)TTObjectDefManager.Instance.DataTypes["RequestNo_Seq"].ConvertValue(parameters["DEMANDNO"]);
            if (parameters.ContainsKey("PROJECTNO"))
                _runtimeParameters.PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PROJECTNO"]);
            if (parameters.ContainsKey("MASTERID"))
                _runtimeParameters.MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MASTERID"]);
            if (parameters.ContainsKey("MATERIALID"))
                _runtimeParameters.MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIALID"]);
            if (parameters.ContainsKey("DEMANDTYPE"))
                _runtimeParameters.DEMANDTYPE = (DemandTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["DemandTypeEnum"].ConvertValue(parameters["DEMANDTYPE"]);
            Name = "ACCOUNTANCYDEMANDEVALUATIONREPORT";
            Caption = "Saymanlık İstek Değerlendirme Çizelgesi Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
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