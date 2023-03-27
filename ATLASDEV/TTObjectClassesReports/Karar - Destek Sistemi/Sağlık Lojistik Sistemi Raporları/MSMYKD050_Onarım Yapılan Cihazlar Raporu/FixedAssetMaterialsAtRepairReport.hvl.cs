
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
    /// Onarım Yapılan Cihazlar Raporu
    /// </summary>
    public partial class FixedAssetMaterialsAtRepairReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? RESPONSIBLEUSERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? SENDERSECTIONID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialsAtRepairReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField HOSPITAL111 { get {return Header().HOSPITAL111;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public FixedAssetMaterialsAtRepairReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField HOSPITAL111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 18, 275, 33, false);
                    ReportName.Name = "ReportName";
                    ReportName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 33, 139, 42, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.TextFormat = @"dd/MM/yyyy";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@STARTDATE@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 33, 146, 42, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"-";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 33, 168, 42, false);
                    NewField3.Name = "NewField3";
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.TextFormat = @"dd/MM/yyyy";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"{@ENDDATE@}";

                    HOSPITAL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 231, 18, false);
                    HOSPITAL111.Name = "HOSPITAL111";
                    HOSPITAL111.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL111.TextFont.Name = "Arial";
                    HOSPITAL111.TextFont.Size = 12;
                    HOSPITAL111.TextFont.Bold = true;
                    HOSPITAL111.TextFont.CharSet = 162;
                    HOSPITAL111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = @"";
                    NewField1.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    HOSPITAL111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ReportName,NewField1,NewField2,NewField3,HOSPITAL111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                ReportName.CalcValue = "BİYOMEDİKAL MÜHENDİSLİK MERKEZİ ONARIMI YAPILAN CİHAZLAR RAPORU";
            else
                ReportName.CalcValue = "ONARIMI YAPILAN CİHAZLAR RAPORU";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsAtRepairReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 1, 28, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 142, 6, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 1, 274, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 1, 274, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

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
            public FixedAssetMaterialsAtRepairReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField SIRANU { get {return Header().SIRANU;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField SumUnitPrice { get {return Footer().SumUnitPrice;} }
            public TTReportField Balik { get {return Footer().Balik;} }
            public TTReportField NQLCOLUMN { get {return Footer().NQLCOLUMN;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Repair.GetRepairForUsedMaterialCount_Class>("GetRepairForUsedMaterialCount", Repair.GetRepairForUsedMaterialCount((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.RESPONSIBLEUSERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SENDERSECTIONID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public FixedAssetMaterialsAtRepairReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField1111;
                public TTReportField SIRANU;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField2;
                public TTReportField NewField13; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 66, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Nato Stok Numarası (NSN)";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 1, 100, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Cihazın Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 1, 187, 14, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Onarıma Geliş Tarihi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 205, 14, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Onarım Bitiş Tarihi";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 371, 1, 391, 7, false);
                    NewField122.Name = "NewField122";
                    NewField122.Visible = EvetHayirEnum.ehHayir;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 1, 138, 14, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Bulunduğu Servis";

                    SIRANU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 1, 12, 14, false);
                    SIRANU.Name = "SIRANU";
                    SIRANU.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANU.TextFont.Bold = true;
                    SIRANU.TextFont.CharSet = 162;
                    SIRANU.Value = @"S.Nu.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 1, 169, 14, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Cihazın Onarımını Yapan Personel";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 7, 235, 14, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Cinsi";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 7, 245, 14, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Miktarı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 7, 258, 14, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Fiyatı(TL)";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 1, 285, 14, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Son 
Durumu";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 1, 258, 7, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Kullanılacak Yedek Parça";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 38, 14, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İş İstek Nu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetRepairForUsedMaterialCount_Class dataset_GetRepairForUsedMaterialCount = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetRepairForUsedMaterialCount_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    SIRANU.CalcValue = SIRANU.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField121,NewField122,NewField1111,SIRANU,NewField3,NewField4,NewField5,NewField6,NewField7,NewField2,NewField13};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsAtRepairReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
                }
                
                public TTReportField SumUnitPrice;
                public TTReportField Balik;
                public TTReportField NQLCOLUMN; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    RepeatCount = 0;
                    
                    SumUnitPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 0, 258, 7, false);
                    SumUnitPrice.Name = "SumUnitPrice";
                    SumUnitPrice.DrawStyle = DrawStyleConstants.vbSolid;
                    SumUnitPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    SumUnitPrice.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SumUnitPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SumUnitPrice.TextFont.Name = "Arial";
                    SumUnitPrice.TextFont.Bold = true;
                    SumUnitPrice.TextFont.CharSet = 162;
                    SumUnitPrice.Value = @"{@sumof(UNITPRICE)@}";

                    Balik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 245, 7, false);
                    Balik.Name = "Balik";
                    Balik.DrawStyle = DrawStyleConstants.vbSolid;
                    Balik.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Balik.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Balik.TextFont.Name = "Arial";
                    Balik.TextFont.Bold = true;
                    Balik.TextFont.CharSet = 162;
                    Balik.Value = @"Toplam Yedek Parça Maliyeti";

                    NQLCOLUMN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 8, 169, 13, false);
                    NQLCOLUMN.Name = "NQLCOLUMN";
                    NQLCOLUMN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NQLCOLUMN.Value = @"BU RAPORDA {#NQLCOLUMN#} TANE KALEM İŞ LİSTELENMEKTEDİR.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetRepairForUsedMaterialCount_Class dataset_GetRepairForUsedMaterialCount = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetRepairForUsedMaterialCount_Class>(0);
                    SumUnitPrice.CalcValue = ParentGroup.FieldSums["UNITPRICE"].Value.ToString();;
                    Balik.CalcValue = Balik.Value;
                    NQLCOLUMN.CalcValue = @"BU RAPORDA " + (dataset_GetRepairForUsedMaterialCount != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterialCount.Nqlcolumn) : "") + @" TANE KALEM İŞ LİSTELENMEKTEDİR.";
                    return new TTReportObject[] { SumUnitPrice,Balik,NQLCOLUMN};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public FixedAssetMaterialsAtRepairReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANU { get {return Body().SIRANU;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField SENDERSECTION { get {return Body().SENDERSECTION;} }
            public TTReportField RESPONSIBLEUSER { get {return Body().RESPONSIBLEUSER;} }
            public TTReportField DELIVERYDATE { get {return Body().DELIVERYDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField GETSTATUS { get {return Body().GETSTATUS;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
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
                list[0] = new TTReportNqlData<Repair.GetRepairForUsedMaterial_Class>("GetRepairForUsedMaterial", Repair.GetRepairForUsedMaterial((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.RESPONSIBLEUSERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SENDERSECTIONID)));
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
                public FixedAssetMaterialsAtRepairReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtRepairReport)ParentReport; }
                }
                
                public TTReportField SIRANU;
                public TTReportField OBJECTID;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIAL;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField NAME;
                public TTReportField SENDERSECTION;
                public TTReportField RESPONSIBLEUSER;
                public TTReportField DELIVERYDATE;
                public TTReportField ENDDATE;
                public TTReportField STATUS;
                public TTReportField GETSTATUS;
                public TTReportField REQUESTNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 0, 12, 5, false);
                    SIRANU.Name = "SIRANU";
                    SIRANU.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANU.TextFont.CharSet = 162;
                    SIRANU.Value = @"{@counter@}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 402, 2, 427, 7, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 66, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 235, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#USEDMATERIAL#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 0, 245, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 0, 258, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 0, 100, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#FAMNAME#}";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 138, 5, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERSECTION.ObjectDefName = "Resource";
                    SENDERSECTION.DataMember = "NAME";
                    SENDERSECTION.TextFont.CharSet = 162;
                    SENDERSECTION.Value = @"{#SENDERSECTION#}";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 169, 5, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESPONSIBLEUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEUSER.TextFont.CharSet = 162;
                    RESPONSIBLEUSER.Value = @"{#RESPONSIBLEUSER#}";

                    DELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 187, 5, false);
                    DELIVERYDATE.Name = "DELIVERYDATE";
                    DELIVERYDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERYDATE.TextFormat = @"dd/MM/yyyy";
                    DELIVERYDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVERYDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVERYDATE.TextFont.CharSet = 162;
                    DELIVERYDATE.Value = @"{#DELIVERYDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 205, 5, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 0, 285, 5, false);
                    STATUS.Name = "STATUS";
                    STATUS.DrawStyle = DrawStyleConstants.vbSolid;
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATUS.ObjectDefName = "FixedAssetCMRStatusEnum";
                    STATUS.DataMember = "DISPLAYTEXT";
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"{#CMRSTATUS#}";

                    GETSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 0, 333, 5, false);
                    GETSTATUS.Name = "GETSTATUS";
                    GETSTATUS.Visible = EvetHayirEnum.ehHayir;
                    GETSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GETSTATUS.Value = @"";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 38, 5, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetRepairForUsedMaterial_Class dataset_GetRepairForUsedMaterial = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetRepairForUsedMaterial_Class>(0);
                    SIRANU.CalcValue = ParentGroup.Counter.ToString();
                    OBJECTID.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.ObjectID) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.NATOStockNO) : "");
                    MATERIAL.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.Usedmaterial) : "");
                    AMOUNT.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.UnitPrice) : "");
                    NAME.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.Famname) : "");
                    SENDERSECTION.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.SenderSection) : "");
                    SENDERSECTION.PostFieldValueCalculation();
                    RESPONSIBLEUSER.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.Responsibleuser) : "");
                    DELIVERYDATE.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.DeliveryDate) : "");
                    ENDDATE.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.EndDate) : "");
                    STATUS.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.CMRStatus) : "");
                    STATUS.PostFieldValueCalculation();
                    GETSTATUS.CalcValue = @"";
                    REQUESTNO.CalcValue = (dataset_GetRepairForUsedMaterial != null ? Globals.ToStringCore(dataset_GetRepairForUsedMaterial.RequestNo) : "");
                    return new TTReportObject[] { SIRANU,OBJECTID,NATOSTOCKNO,MATERIAL,AMOUNT,UNITPRICE,NAME,SENDERSECTION,RESPONSIBLEUSER,DELIVERYDATE,ENDDATE,STATUS,GETSTATUS,REQUESTNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //STATUS.CalcValue = GETSTATUS.Value.ToString();
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

        public FixedAssetMaterialsAtRepairReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("RESPONSIBLEUSERID", "00000000-0000-0000-0000-000000000000", "Onarımı Yapan Personel", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("49d34251-525d-4d43-9c79-938d4facd154");
            reportParameter = Parameters.Add("SENDERSECTIONID", "00000000-0000-0000-0000-000000000000", "Bulunduğu Servis", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("RESPONSIBLEUSERID"))
                _runtimeParameters.RESPONSIBLEUSERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["RESPONSIBLEUSERID"]);
            if (parameters.ContainsKey("SENDERSECTIONID"))
                _runtimeParameters.SENDERSECTIONID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SENDERSECTIONID"]);
            Name = "FIXEDASSETMATERIALSATREPAIRREPORT";
            Caption = "Onarım Yapılan Cihazlar Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 10;
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