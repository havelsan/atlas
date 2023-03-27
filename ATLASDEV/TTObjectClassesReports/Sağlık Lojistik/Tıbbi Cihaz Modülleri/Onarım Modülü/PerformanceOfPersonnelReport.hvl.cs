
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
    /// Personelin Performans Raporu
    /// </summary>
    public partial class PerformanceOfPersonnelReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PERSONNEL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PerformanceOfPersonnelReport MyParentReport
            {
                get { return (PerformanceOfPersonnelReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName1111 { get {return Header().ReportName1111;} }
            public TTReportField MATERIAL121 { get {return Header().MATERIAL121;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField Personnel { get {return Header().Personnel;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField HOSPITAL1 { get {return Header().HOSPITAL1;} }
            public TTReportField SECTION { get {return Header().SECTION;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField PrintDate111 { get {return Footer().PrintDate111;} }
            public TTReportField PageNumber111 { get {return Footer().PageNumber111;} }
            public TTReportField CurrentUser111 { get {return Footer().CurrentUser111;} }
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
                public PerformanceOfPersonnelReport MyParentReport
                {
                    get { return (PerformanceOfPersonnelReport)ParentReport; }
                }
                
                public TTReportField ReportName1111;
                public TTReportField MATERIAL121;
                public TTReportField NewField1;
                public TTReportField Personnel;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField17;
                public TTReportField NewField4;
                public TTReportField NewField14;
                public TTReportField HOSPITAL1;
                public TTReportField SECTION;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField13; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 22, 216, 30, false);
                    ReportName1111.Name = "ReportName1111";
                    ReportName1111.FillStyle = FillStyleConstants.vbFSTransparent;
                    ReportName1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1111.TextFont.Size = 13;
                    ReportName1111.TextFont.Bold = true;
                    ReportName1111.TextFont.CharSet = 162;
                    ReportName1111.Value = @"PERSONEL PERFORMANS RAPORU";

                    MATERIAL121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 48, 24, 64, false);
                    MATERIAL121.Name = "MATERIAL121";
                    MATERIAL121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL121.TextFont.Bold = true;
                    MATERIAL121.TextFont.CharSet = 162;
                    MATERIAL121.Value = @"Sıra Nu.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 42, 33, 47, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Personel Adı:";

                    Personnel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 42, 109, 47, false);
                    Personnel.Name = "Personnel";
                    Personnel.FieldType = ReportFieldTypeEnum.ftVariable;
                    Personnel.ObjectDefName = "ResUser";
                    Personnel.DataMember = "NAME";
                    Personnel.Value = @"{@PERSONNEL@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 48, 55, 64, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"
Bakım Onarım Kalib.
İstek Form Nu.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 48, 197, 64, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İşin Başlama 
Tarihi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 48, 272, 64, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"
Son Durumu";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 48, 172, 64, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Klinik";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 48, 111, 64, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Malzemenin Adı";

                    HOSPITAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 6, 239, 16, false);
                    HOSPITAL1.Name = "HOSPITAL1";
                    HOSPITAL1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL1.TextFont.Name = "Arial";
                    HOSPITAL1.TextFont.Size = 13;
                    HOSPITAL1.TextFont.Bold = true;
                    HOSPITAL1.TextFont.CharSet = 162;
                    HOSPITAL1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 16, 239, 24, false);
                    SECTION.Name = "SECTION";
                    SECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECTION.TextFont.Name = "Arial";
                    SECTION.TextFont.Size = 12;
                    SECTION.TextFont.Bold = true;
                    SECTION.TextFont.CharSet = 162;
                    SECTION.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 31, 132, 36, false);
                    NewField5.Name = "NewField5";
                    NewField5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField5.TextFormat = @"Short Date";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"{@STARTDATE@}";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 31, 141, 36, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"-";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 31, 178, 36, false);
                    NewField7.Name = "NewField7";
                    NewField7.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField7.TextFormat = @"Short Date";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"{@ENDDATE@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 48, 223, 64, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İşin Bitiş 
Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName1111.CalcValue = ReportName1111.Value;
                    MATERIAL121.CalcValue = MATERIAL121.Value;
                    NewField1.CalcValue = NewField1.Value;
                    Personnel.CalcValue = MyParentReport.RuntimeParameters.PERSONNEL.ToString();
                    Personnel.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    SECTION.CalcValue = @"";
                    NewField5.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField13.CalcValue = NewField13.Value;
                    HOSPITAL1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ReportName1111,MATERIAL121,NewField1,Personnel,NewField2,NewField3,NewField17,NewField4,NewField14,SECTION,NewField5,NewField6,NewField7,NewField13,HOSPITAL1};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    // Personnel.CalcValue = NAME.CalcValue;
#endregion PARTA HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                SECTION.CalcValue = "BİYOMEDİKAL MÜHENDİSLİK MERKEZİ";
            else
                SECTION.CalcValue = "";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PerformanceOfPersonnelReport MyParentReport
                {
                    get { return (PerformanceOfPersonnelReport)ParentReport; }
                }
                
                public TTReportField PrintDate111;
                public TTReportField PageNumber111;
                public TTReportField CurrentUser111;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 38, 6, false);
                    PrintDate111.Name = "PrintDate111";
                    PrintDate111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate111.TextFont.Size = 8;
                    PrintDate111.TextFont.CharSet = 162;
                    PrintDate111.Value = @"{@printdate@}";

                    PageNumber111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 1, 272, 6, false);
                    PageNumber111.Name = "PageNumber111";
                    PageNumber111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber111.TextFont.Size = 8;
                    PageNumber111.TextFont.CharSet = 162;
                    PageNumber111.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 157, 6, false);
                    CurrentUser111.Name = "CurrentUser111";
                    CurrentUser111.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser111.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser111.TextFont.Size = 8;
                    CurrentUser111.TextFont.CharSet = 162;
                    CurrentUser111.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 272, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate111.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber111.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser111.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate111,PageNumber111,CurrentUser111};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PerformanceOfPersonnelReport MyParentReport
            {
                get { return (PerformanceOfPersonnelReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO11 { get {return Body().ORDERNO11;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField CMRSTATUS { get {return Body().CMRSTATUS;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField SENDERSECTION { get {return Body().SENDERSECTION;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField NAME { get {return Body().NAME;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class>("GetPerformanceOfPersonnelReportQuery2", CMRActionRequest.GetPerformanceOfPersonnelReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PERSONNEL),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public PerformanceOfPersonnelReport MyParentReport
                {
                    get { return (PerformanceOfPersonnelReport)ParentReport; }
                }
                
                public TTReportField ORDERNO11;
                public TTReportField REQUESTNO;
                public TTReportField CMRSTATUS;
                public TTReportField REQUESTDATE;
                public TTReportField MATERIALNAME;
                public TTReportField SENDERSECTION;
                public TTReportField ENDDATE;
                public TTReportField DESCRIPTION;
                public TTReportField NAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ORDERNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 24, 5, false);
                    ORDERNO11.Name = "ORDERNO11";
                    ORDERNO11.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO11.TextFont.Size = 9;
                    ORDERNO11.TextFont.CharSet = 162;
                    ORDERNO11.Value = @"{@counter@}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 55, 5, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    CMRSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 0, 272, 5, false);
                    CMRSTATUS.Name = "CMRSTATUS";
                    CMRSTATUS.DrawStyle = DrawStyleConstants.vbSolid;
                    CMRSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CMRSTATUS.ObjectDefName = "FixedAssetCMRStatusEnum";
                    CMRSTATUS.DataMember = "DISPLAYTEXT";
                    CMRSTATUS.Value = @"{#CMRSTATUS#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 197, 5, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 111, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 172, 5, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.Value = @"{#SENDERSECTION#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 223, 5, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 0, 330, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 331, 0, 356, 5, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME1#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class dataset_GetPerformanceOfPersonnelReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class>(0);
                    ORDERNO11.CalcValue = ParentGroup.Counter.ToString();
                    REQUESTNO.CalcValue = (dataset_GetPerformanceOfPersonnelReportQuery2 != null ? Globals.ToStringCore(dataset_GetPerformanceOfPersonnelReportQuery2.RequestNo) : "");
                    CMRSTATUS.CalcValue = (dataset_GetPerformanceOfPersonnelReportQuery2 != null ? Globals.ToStringCore(dataset_GetPerformanceOfPersonnelReportQuery2.CMRStatus) : "");
                    CMRSTATUS.PostFieldValueCalculation();
                    REQUESTDATE.CalcValue = (dataset_GetPerformanceOfPersonnelReportQuery2 != null ? Globals.ToStringCore(dataset_GetPerformanceOfPersonnelReportQuery2.RequestDate) : "");
                    MATERIALNAME.CalcValue = @"";
                    SENDERSECTION.CalcValue = (dataset_GetPerformanceOfPersonnelReportQuery2 != null ? Globals.ToStringCore(dataset_GetPerformanceOfPersonnelReportQuery2.Sendersection) : "");
                    ENDDATE.CalcValue = @"";
                    DESCRIPTION.CalcValue = (dataset_GetPerformanceOfPersonnelReportQuery2 != null ? Globals.ToStringCore(dataset_GetPerformanceOfPersonnelReportQuery2.Description) : "");
                    NAME.CalcValue = (dataset_GetPerformanceOfPersonnelReportQuery2 != null ? Globals.ToStringCore(dataset_GetPerformanceOfPersonnelReportQuery2.Name1) : "");
                    return new TTReportObject[] { ORDERNO11,REQUESTNO,CMRSTATUS,REQUESTDATE,MATERIALNAME,SENDERSECTION,ENDDATE,DESCRIPTION,NAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext cont = new TTObjectContext(true);
            string requestno = this.REQUESTNO.CalcValue;
            BindingList<Repair.GetActualDeliveryDate_Class> list = Repair.GetActualDeliveryDate(cont, requestno);
            foreach (Repair.GetActualDeliveryDate_Class lst in list)
            {
                if(lst.RequestNo == requestno)
                    this.ENDDATE.CalcValue = lst.ActualDeliveryDate.ToString();
            }
            
            
            if(!string.IsNullOrEmpty(NAME.CalcValue))
            {
                MATERIALNAME.CalcValue = NAME.CalcValue;
            }
            else
            {
                MATERIALNAME.CalcValue = DESCRIPTION.CalcValue;
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

        public PerformanceOfPersonnelReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PERSONNEL", "00000000-0000-0000-0000-000000000000", "Personel", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PERSONNEL"))
                _runtimeParameters.PERSONNEL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PERSONNEL"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "PERFORMANCEOFPERSONNELREPORT";
            Caption = "Personelin Performans Raporu";
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