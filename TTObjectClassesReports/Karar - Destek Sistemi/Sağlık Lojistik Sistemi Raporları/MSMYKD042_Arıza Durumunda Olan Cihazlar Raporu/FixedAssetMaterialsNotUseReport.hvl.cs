
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
    /// Onarımı Devam Eden Tıbbi Cihazlar Raporu
    /// </summary>
    public partial class FixedAssetMaterialsNotUseReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? SENDERSECTIONID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? RESPONSIBLEUSERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? SENDERSECTIONFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? RESPONSIBLEUSERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialsNotUseReport MyParentReport
            {
                get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
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
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
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
                public FixedAssetMaterialsNotUseReport MyParentReport
                {
                    get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 1, 274, 21, false);
                    ReportName.Name = "ReportName";
                    ReportName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 21, 134, 30, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.TextFormat = @"Short Date";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"{@STARTDATE@}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 21, 141, 30, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"-";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 21, 163, 30, false);
                    NewField13.Name = "NewField13";
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.TextFormat = @"Short Date";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = @"";
                    NewField11.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { ReportName,NewField11,NewField12,NewField13};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                ReportName.CalcValue = "BİYOMEDİKAL MÜHENDİSLİK MERKEZİ ONARIMI DEVAM EDEN TIBBİ CİHAZLAR RAPORU";
            else
                ReportName.CalcValue = "ONARIMI DEVAM EDEN TIBBİ CİHAZLAR RAPORU";
            
            
            if(((FixedAssetMaterialsNotUseReport)ParentReport).RuntimeParameters.RESPONSIBLEUSERID == Guid.Empty)
                ((FixedAssetMaterialsNotUseReport)ParentReport).RuntimeParameters.RESPONSIBLEUSERFLAG = 1;
            else
                ((FixedAssetMaterialsNotUseReport)ParentReport).RuntimeParameters.RESPONSIBLEUSERFLAG = 0;
            
            if(((FixedAssetMaterialsNotUseReport)ParentReport).RuntimeParameters.SENDERSECTIONID == Guid.Empty)
                ((FixedAssetMaterialsNotUseReport)ParentReport).RuntimeParameters.SENDERSECTIONFLAG = 1;
            else
                ((FixedAssetMaterialsNotUseReport)ParentReport).RuntimeParameters.SENDERSECTIONFLAG = 0;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsNotUseReport MyParentReport
                {
                    get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
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
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 2, 27, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 2, 150, 7, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 2, 274, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 1, 274, 1, false);
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
            public FixedAssetMaterialsNotUseReport MyParentReport
            {
                get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField SIRANU { get {return Header().SIRANU;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
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
                public FixedAssetMaterialsNotUseReport MyParentReport
                {
                    get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField1111;
                public TTReportField SIRANU;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField13; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 1, 265, 11, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Durumu";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 45, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İşlem Numarası";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 1, 132, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Cihazın Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 3, 330, 9, false);
                    NewField12.Name = "NewField12";
                    NewField12.Visible = EvetHayirEnum.ehHayir;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Marka";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 331, 3, 351, 9, false);
                    NewField121.Name = "NewField121";
                    NewField121.Visible = EvetHayirEnum.ehHayir;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Model";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 352, 3, 372, 9, false);
                    NewField122.Name = "NewField122";
                    NewField122.Visible = EvetHayirEnum.ehHayir;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 1, 166, 11, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Bulunduğu Servis";

                    SIRANU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -7, 1, 7, 11, false);
                    SIRANU.Name = "SIRANU";
                    SIRANU.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANU.TextFont.Bold = true;
                    SIRANU.TextFont.CharSet = 162;
                    SIRANU.Value = @"S.Nu.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 1, 203, 11, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Cihazın Onarımını Yapacak Personel";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 1, 229, 11, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Onarıma Geliş Tarihi";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 74, 11, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Seri Numarası";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    SIRANU.CalcValue = SIRANU.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField11111,NewField1,NewField11,NewField12,NewField121,NewField122,NewField1111,SIRANU,NewField2,NewField3,NewField13};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsNotUseReport MyParentReport
                {
                    get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
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
            public FixedAssetMaterialsNotUseReport MyParentReport
            {
                get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField FixedAssetName { get {return Body().FixedAssetName;} }
            public TTReportField Mark { get {return Body().Mark;} }
            public TTReportField Model { get {return Body().Model;} }
            public TTReportField SerialNumber { get {return Body().SerialNumber;} }
            public TTReportField Service { get {return Body().Service;} }
            public TTReportField CMRStatus { get {return Body().CMRStatus;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField SIRANU { get {return Body().SIRANU;} }
            public TTReportField Onarıma_Gelis { get {return Body().Onarıma_Gelis;} }
            public TTReportField Personnel { get {return Body().Personnel;} }
            public TTReportField SerialNumber2 { get {return Body().SerialNumber2;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class>("GetOnarimiDevamEdenCihazlar", CMRActionRequest.GetOnarimiDevamEdenCihazlar((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SENDERSECTIONID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.RESPONSIBLEUSERID),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.SENDERSECTIONFLAG),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.RESPONSIBLEUSERFLAG)));
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
                public FixedAssetMaterialsNotUseReport MyParentReport
                {
                    get { return (FixedAssetMaterialsNotUseReport)ParentReport; }
                }
                
                public TTReportField FixedAssetName;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNumber;
                public TTReportField Service;
                public TTReportField CMRStatus;
                public TTReportShape NewLine1;
                public TTReportField SIRANU;
                public TTReportField Onarıma_Gelis;
                public TTReportField Personnel;
                public TTReportField SerialNumber2;
                public TTReportField REQUESTNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 132, 9, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.DrawStyle = DrawStyleConstants.vbSolid;
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.Size = 8;
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"{#FIXEDASSETNAME#}";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 331, 10, false);
                    Mark.Name = "Mark";
                    Mark.Visible = EvetHayirEnum.ehHayir;
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.WordBreak = EvetHayirEnum.ehEvet;
                    Mark.TextFont.Name = "Arial";
                    Mark.TextFont.CharSet = 162;
                    Mark.Value = @"{#MARK#}";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 331, 1, 351, 10, false);
                    Model.Name = "Model";
                    Model.Visible = EvetHayirEnum.ehHayir;
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.WordBreak = EvetHayirEnum.ehEvet;
                    Model.TextFont.Name = "Arial";
                    Model.TextFont.CharSet = 162;
                    Model.Value = @"{#MODEL#}";

                    SerialNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 351, 1, 371, 10, false);
                    SerialNumber.Name = "SerialNumber";
                    SerialNumber.Visible = EvetHayirEnum.ehHayir;
                    SerialNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber.TextFont.Name = "Arial";
                    SerialNumber.TextFont.CharSet = 162;
                    SerialNumber.Value = @"{#SERIALNUMBER#}";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 166, 9, false);
                    Service.Name = "Service";
                    Service.DrawStyle = DrawStyleConstants.vbSolid;
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.MultiLine = EvetHayirEnum.ehEvet;
                    Service.WordBreak = EvetHayirEnum.ehEvet;
                    Service.TextFont.Size = 8;
                    Service.TextFont.CharSet = 162;
                    Service.Value = @"{#SERVICE#}";

                    CMRStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 265, 9, false);
                    CMRStatus.Name = "CMRStatus";
                    CMRStatus.DrawStyle = DrawStyleConstants.vbSolid;
                    CMRStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    CMRStatus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CMRStatus.MultiLine = EvetHayirEnum.ehEvet;
                    CMRStatus.WordBreak = EvetHayirEnum.ehEvet;
                    CMRStatus.ObjectDefName = "FixedAssetCMRStatusEnum";
                    CMRStatus.DataMember = "DISPLAYTEXT";
                    CMRStatus.TextFont.Size = 8;
                    CMRStatus.TextFont.CharSet = 162;
                    CMRStatus.Value = @"{#CMRSTATUS#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -4, 10, -4, 10, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    SIRANU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -7, 0, 7, 9, false);
                    SIRANU.Name = "SIRANU";
                    SIRANU.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANU.TextFont.Size = 8;
                    SIRANU.TextFont.CharSet = 162;
                    SIRANU.Value = @"{@counter@}";

                    Onarıma_Gelis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 0, 229, 9, false);
                    Onarıma_Gelis.Name = "Onarıma_Gelis";
                    Onarıma_Gelis.DrawStyle = DrawStyleConstants.vbSolid;
                    Onarıma_Gelis.FieldType = ReportFieldTypeEnum.ftVariable;
                    Onarıma_Gelis.TextFormat = @"dd/MM/yyyy";
                    Onarıma_Gelis.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onarıma_Gelis.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onarıma_Gelis.TextFont.Size = 8;
                    Onarıma_Gelis.TextFont.CharSet = 162;
                    Onarıma_Gelis.Value = @"{#REQUESTDATE#}";

                    Personnel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 203, 9, false);
                    Personnel.Name = "Personnel";
                    Personnel.DrawStyle = DrawStyleConstants.vbSolid;
                    Personnel.FieldType = ReportFieldTypeEnum.ftVariable;
                    Personnel.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Personnel.MultiLine = EvetHayirEnum.ehEvet;
                    Personnel.WordBreak = EvetHayirEnum.ehEvet;
                    Personnel.ExpandTabs = EvetHayirEnum.ehEvet;
                    Personnel.TextFont.Size = 8;
                    Personnel.TextFont.CharSet = 162;
                    Personnel.Value = @"{#TITLE#}{#NAME#}";

                    SerialNumber2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 74, 9, false);
                    SerialNumber2.Name = "SerialNumber2";
                    SerialNumber2.DrawStyle = DrawStyleConstants.vbSolid;
                    SerialNumber2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SerialNumber2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber2.MultiLine = EvetHayirEnum.ehEvet;
                    SerialNumber2.WordBreak = EvetHayirEnum.ehEvet;
                    SerialNumber2.TextFont.Size = 8;
                    SerialNumber2.TextFont.CharSet = 162;
                    SerialNumber2.Value = @"{#SERIALNUMBER#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 45, 9, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTNO.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTNO.TextFont.Size = 8;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class dataset_GetOnarimiDevamEdenCihazlar = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class>(0);
                    FixedAssetName.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.Fixedassetname) : "");
                    Mark.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.Mark) : "");
                    Model.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.Model) : "");
                    SerialNumber.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.SerialNumber) : "");
                    Service.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.Service) : "");
                    CMRStatus.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.CMRStatus) : "");
                    CMRStatus.PostFieldValueCalculation();
                    SIRANU.CalcValue = ParentGroup.Counter.ToString();
                    Onarıma_Gelis.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.RequestDate) : "");
                    Personnel.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.Title) : "") + (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.Name) : "");
                    SerialNumber2.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.SerialNumber) : "");
                    REQUESTNO.CalcValue = (dataset_GetOnarimiDevamEdenCihazlar != null ? Globals.ToStringCore(dataset_GetOnarimiDevamEdenCihazlar.RequestNo) : "");
                    return new TTReportObject[] { FixedAssetName,Mark,Model,SerialNumber,Service,CMRStatus,SIRANU,Onarıma_Gelis,Personnel,SerialNumber2,REQUESTNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FixedAssetMaterialsNotUseReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SENDERSECTIONID", "00000000-0000-0000-0000-000000000000", "Bulunduğu Servis", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("RESPONSIBLEUSERID", "00000000-0000-0000-0000-000000000000", "Onarımı Yapan Personel", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("49d34251-525d-4d43-9c79-938d4facd154");
            reportParameter = Parameters.Add("SENDERSECTIONFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("RESPONSIBLEUSERFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SENDERSECTIONID"))
                _runtimeParameters.SENDERSECTIONID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SENDERSECTIONID"]);
            if (parameters.ContainsKey("RESPONSIBLEUSERID"))
                _runtimeParameters.RESPONSIBLEUSERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["RESPONSIBLEUSERID"]);
            if (parameters.ContainsKey("SENDERSECTIONFLAG"))
                _runtimeParameters.SENDERSECTIONFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SENDERSECTIONFLAG"]);
            if (parameters.ContainsKey("RESPONSIBLEUSERFLAG"))
                _runtimeParameters.RESPONSIBLEUSERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESPONSIBLEUSERFLAG"]);
            Name = "FIXEDASSETMATERIALSNOTUSEREPORT";
            Caption = "Onarımı Devam Eden Tıbbi Cihazlar Raporu";
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