
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
    /// Garantili Tıbbi Cihazlar Raporu
    /// </summary>
    public partial class FixedAssetMaterialGuarantyReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? NOW = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialGuarantyReport MyParentReport
            {
                get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
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
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField HOSPITAL1 { get {return Header().HOSPITAL1;} }
            public TTReportField SECTION { get {return Header().SECTION;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public FixedAssetMaterialGuarantyReport MyParentReport
                {
                    get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField HOSPITAL1;
                public TTReportField SECTION; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 2, 343, 22, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 20, 218, 33, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"GARANTİLİ TIBBI CİHAZ RAPORU";

                    HOSPITAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 230, 11, false);
                    HOSPITAL1.Name = "HOSPITAL1";
                    HOSPITAL1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL1.TextFont.Name = "Arial";
                    HOSPITAL1.TextFont.Size = 13;
                    HOSPITAL1.TextFont.Bold = true;
                    HOSPITAL1.TextFont.CharSet = 162;
                    HOSPITAL1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 11, 230, 19, false);
                    SECTION.Name = "SECTION";
                    SECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECTION.TextFont.Name = "Arial";
                    SECTION.TextFont.Size = 12;
                    SECTION.TextFont.Bold = true;
                    SECTION.TextFont.CharSet = 162;
                    SECTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    SECTION.CalcValue = @"";
                    HOSPITAL1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,ReportName,SECTION,HOSPITAL1};
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
                public FixedAssetMaterialGuarantyReport MyParentReport
                {
                    get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

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

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public FixedAssetMaterialGuarantyReport MyParentReport
            {
                get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11222 { get {return Header().NewField11222;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField122211 { get {return Header().NewField122211;} }
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
                public FixedAssetMaterialGuarantyReport MyParentReport
                {
                    get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
                }
                
                public TTReportField NewField11222;
                public TTReportField NewField11221;
                public TTReportField NewField1221;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportShape NewLine1;
                public TTReportField NewField122211; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 233, 7, false);
                    NewField11222.Name = "NewField11222";
                    NewField11222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11222.TextFont.Name = "Arial";
                    NewField11222.TextFont.Bold = true;
                    NewField11222.TextFont.CharSet = 162;
                    NewField11222.Value = @"Garantisi";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 211, 7, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Name = "Arial";
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Garanti Bit. Tar.";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 182, 7, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Garanti Baş. Tar.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -5, 1, 27, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NSN No";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 1, 96, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Demirbaş Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 116, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Marka";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 132, 7, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Model";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 153, 7, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -5, 7, 261, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 1, 261, 6, false);
                    NewField122211.Name = "NewField122211";
                    NewField122211.TextFont.Name = "Arial";
                    NewField122211.TextFont.Bold = true;
                    NewField122211.TextFont.CharSet = 162;
                    NewField122211.Value = @"Servis/Klinik
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11222.CalcValue = NewField11222.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField122211.CalcValue = NewField122211.Value;
                    return new TTReportObject[] { NewField11222,NewField11221,NewField1221,NewField1,NewField11,NewField12,NewField121,NewField122,NewField122211};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialGuarantyReport MyParentReport
                {
                    get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public FixedAssetMaterialGuarantyReport MyParentReport
            {
                get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField FixedAssetName { get {return Body().FixedAssetName;} }
            public TTReportField Mark { get {return Body().Mark;} }
            public TTReportField Model { get {return Body().Model;} }
            public TTReportField SerialNumber { get {return Body().SerialNumber;} }
            public TTReportField GuarantyStartDate { get {return Body().GuarantyStartDate;} }
            public TTReportField GuarantyEndDate { get {return Body().GuarantyEndDate;} }
            public TTReportField GuarantyState { get {return Body().GuarantyState;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class>("GetFixedAssetMaterialGuarantyReportQuery2", FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.NOW),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public FixedAssetMaterialGuarantyReport MyParentReport
                {
                    get { return (FixedAssetMaterialGuarantyReport)ParentReport; }
                }
                
                public TTReportField NSN;
                public TTReportField FixedAssetName;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNumber;
                public TTReportField GuarantyStartDate;
                public TTReportField GuarantyEndDate;
                public TTReportField GuarantyState;
                public TTReportField OBJECTID;
                public TTReportShape NewLine1;
                public TTReportField NAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -5, 1, 27, 11, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NATOSTOCKNO#}";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 1, 96, 11, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.Name = "Arial";
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"{#FIXEDASSETNAME#}";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 116, 11, false);
                    Mark.Name = "Mark";
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.WordBreak = EvetHayirEnum.ehEvet;
                    Mark.TextFont.Name = "Arial";
                    Mark.TextFont.CharSet = 162;
                    Mark.Value = @"{#MARK#}";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 132, 11, false);
                    Model.Name = "Model";
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.WordBreak = EvetHayirEnum.ehEvet;
                    Model.TextFont.Name = "Arial";
                    Model.TextFont.CharSet = 162;
                    Model.Value = @"{#MODEL#}";

                    SerialNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 153, 11, false);
                    SerialNumber.Name = "SerialNumber";
                    SerialNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber.TextFont.Name = "Arial";
                    SerialNumber.TextFont.CharSet = 162;
                    SerialNumber.Value = @"{#SERIALNUMBER#}";

                    GuarantyStartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 182, 11, false);
                    GuarantyStartDate.Name = "GuarantyStartDate";
                    GuarantyStartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    GuarantyStartDate.TextFormat = @"dd/MM/yyyy";
                    GuarantyStartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GuarantyStartDate.TextFont.Name = "Arial";
                    GuarantyStartDate.TextFont.CharSet = 162;
                    GuarantyStartDate.Value = @"{#GUARANTYSTARTDATE#}";

                    GuarantyEndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 211, 11, false);
                    GuarantyEndDate.Name = "GuarantyEndDate";
                    GuarantyEndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    GuarantyEndDate.TextFormat = @"dd/MM/yyyy";
                    GuarantyEndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GuarantyEndDate.TextFont.Name = "Arial";
                    GuarantyEndDate.TextFont.CharSet = 162;
                    GuarantyEndDate.Value = @"{#GUARANTYENDDATE#}";

                    GuarantyState = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 233, 11, false);
                    GuarantyState.Name = "GuarantyState";
                    GuarantyState.FieldType = ReportFieldTypeEnum.ftVariable;
                    GuarantyState.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GuarantyState.MultiLine = EvetHayirEnum.ehEvet;
                    GuarantyState.TextFont.Name = "Arial";
                    GuarantyState.TextFont.CharSet = 162;
                    GuarantyState.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 295, 1, 342, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -5, 12, 261, 12, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 1, 261, 11, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.ObjectDefName = "Store";
                    NAME.DataMember = "NAME";
                    NAME.Value = @"{@STORE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class dataset_GetFixedAssetMaterialGuarantyReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class>(0);
                    NSN.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.NATOStockNO) : "");
                    FixedAssetName.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.Fixedassetname) : "");
                    Mark.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.Mark) : "");
                    Model.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.Model) : "");
                    SerialNumber.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.SerialNumber) : "");
                    GuarantyStartDate.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.GuarantyStartDate) : "");
                    GuarantyEndDate.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.GuarantyEndDate) : "");
                    GuarantyState.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetFixedAssetMaterialGuarantyReportQuery2 != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialGuarantyReportQuery2.ObjectID) : "");
                    NAME.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    NAME.PostFieldValueCalculation();
                    return new TTReportObject[] { NSN,FixedAssetName,Mark,Model,SerialNumber,GuarantyStartDate,GuarantyEndDate,GuarantyState,OBJECTID,NAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    FixedAssetMaterialDefinition endDate = (FixedAssetMaterialDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(this.OBJECTID.CalcValue), typeof(FixedAssetMaterialDefinition));
            if(endDate.GuarantyEndDate.HasValue)
            {
                if(endDate.GuarantyEndDate.Value >= DateTime.Now)
                {
                    this.GuarantyState.CalcValue = "Devam\nEdiyor";
                }
                else
                {
                    this.GuarantyState.CalcValue = "Bitmiş";
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

        public FixedAssetMaterialGuarantyReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("NOW", "", "Now", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Bulunduğu Klinik", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("NOW"))
                _runtimeParameters.NOW = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["NOW"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            Name = "FIXEDASSETMATERIALGUARANTYREPORT";
            Caption = "Garantili Tıbbi Cihazlar Raporu";
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


        protected override void RunPreScript()
        {
#region FIXEDASSETMATERIALGUARANTYREPORT_PreScript
            RuntimeParameters.NOW= DateTime.Now;
#endregion FIXEDASSETMATERIALGUARANTYREPORT_PreScript
        }
    }
}