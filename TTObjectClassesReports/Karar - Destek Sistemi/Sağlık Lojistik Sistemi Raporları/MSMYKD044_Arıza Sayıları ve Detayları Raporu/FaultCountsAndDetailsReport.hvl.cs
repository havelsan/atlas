
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
    /// Cihaz Arızalanma Raporu
    /// </summary>
    public partial class FaultCountsAndDetailsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? MATERIALFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FaultCountsAndDetailsReport MyParentReport
            {
                get { return (FaultCountsAndDetailsReport)ParentReport; }
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
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11621 { get {return Header().NewField11621;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField11511;
                public TTReportField NewField11621;
                public TTReportField NewField11711; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 232, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"TIBBİ CİHAZ ARIZALANMA RAPORU";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 20, 138, 26, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11511.TextFormat = @"Short Date";
                    NewField11511.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11511.TextFont.Size = 11;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"{@STARTDATE@}";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 20, 147, 26, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11621.TextFont.Size = 11;
                    NewField11621.TextFont.Bold = true;
                    NewField11621.TextFont.CharSet = 162;
                    NewField11621.Value = @"-";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 20, 197, 26, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11711.TextFormat = @"Short Date";
                    NewField11711.TextFont.Size = 11;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField11511.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField11711.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { LOGO,ReportName,NewField11511,NewField11621,NewField11711};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(((FaultCountsAndDetailsReport)ParentReport).RuntimeParameters.MATERIAL == Guid.Empty)
                ((FaultCountsAndDetailsReport)ParentReport).RuntimeParameters.MATERIALFLAG = 1;
            else
                ((FaultCountsAndDetailsReport)ParentReport).RuntimeParameters.MATERIALFLAG = 0;
            
            if(((FaultCountsAndDetailsReport)ParentReport).RuntimeParameters.STORE ==  Guid.Empty)
                ((FaultCountsAndDetailsReport)ParentReport).RuntimeParameters.STOREFLAG = 1;
            else
                ((FaultCountsAndDetailsReport)ParentReport).RuntimeParameters.STOREFLAG = 0;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
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

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 148, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 265, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 0, 265, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

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
            public FaultCountsAndDetailsReport MyParentReport
            {
                get { return (FaultCountsAndDetailsReport)ParentReport; }
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
            public TTReportField FaultType { get {return Header().FaultType;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>("GetFaultCountsAndDetailsReportQuery2", CMRActionRequest.GetFaultCountsAndDetailsReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREFLAG),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALFLAG)));
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
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField FaultType;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportShape NewLine1;
                public TTReportField NewField112;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 20, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Arıza Tipi :";

                    FaultType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 45, 7, false);
                    FaultType.Name = "FaultType";
                    FaultType.FieldType = ReportFieldTypeEnum.ftVariable;
                    FaultType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FaultType.NoClip = EvetHayirEnum.ehEvet;
                    FaultType.ObjectDefName = "RequestTypeEnum";
                    FaultType.DataMember = "DISPLAYTEXT";
                    FaultType.TextFont.Name = "Arial";
                    FaultType.TextFont.CharSet = 162;
                    FaultType.Value = @"{#REQUESTTYPE#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 58, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Cihaz NSN Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 7, 169, 13, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Cihaz Adı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -2, 14, 265, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 7, 76, 13, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Seri Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 7, 196, 13, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İstek Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 7, 237, 13, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Görevli Personel";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 7, 265, 13, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Onarım Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class dataset_GetFaultCountsAndDetailsReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    FaultType.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.RequestType) : "");
                    FaultType.PostFieldValueCalculation();
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField1,FaultType,NewField11,NewField111,NewField112,NewField1111,NewField11111,NewField111111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
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

        public partial class PARTCGroup : TTReportGroup
        {
            public FaultCountsAndDetailsReport MyParentReport
            {
                get { return (FaultCountsAndDetailsReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField FixedAssetCode { get {return Header().FixedAssetCode;} }
            public TTReportField FixedAssetName { get {return Header().FixedAssetName;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField SERIALNO { get {return Header().SERIALNO;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField FixedAssetFault { get {return Footer().FixedAssetFault;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class dataSet_GetFaultCountsAndDetailsReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(0);    
                return new object[] {(dataSet_GetFaultCountsAndDetailsReportQuery2==null ? null : dataSet_GetFaultCountsAndDetailsReportQuery2.RequestType)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
                }
                
                public TTReportField FixedAssetCode;
                public TTReportField FixedAssetName;
                public TTReportShape NewLine1;
                public TTReportField NewField1;
                public TTReportField SERIALNO;
                public TTReportField REQUESTNO;
                public TTReportField NAME;
                public TTReportField REQUESTDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FixedAssetCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 58, 9, false);
                    FixedAssetCode.Name = "FixedAssetCode";
                    FixedAssetCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetCode.TextFont.Name = "Arial";
                    FixedAssetCode.TextFont.CharSet = 162;
                    FixedAssetCode.Value = @"{#PARTB.STOCKNO#}";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 1, 169, 9, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"{#PARTB.FIXEDASSETNAME#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 10, 265, 10, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 11, 33, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Arıza Tanımları:";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 76, 9, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.Value = @"{#PARTB.SERIALNO#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 1, 196, 9, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.Value = @"{#PARTB.REQUESTNO#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 1, 237, 9, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#PARTB.NAME#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 1, 265, 8, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.Value = @"{#PARTB.REQUESTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class dataset_GetFaultCountsAndDetailsReportQuery2 = MyParentReport.PARTB.rsGroup.GetCurrentRecord<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(0);
                    FixedAssetCode.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.Stockno) : "");
                    FixedAssetName.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.Fixedassetname) : "");
                    NewField1.CalcValue = NewField1.Value;
                    SERIALNO.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.Serialno) : "");
                    REQUESTNO.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.RequestNo) : "");
                    NAME.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.Name) : "");
                    REQUESTDATE.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.RequestDate) : "");
                    return new TTReportObject[] { FixedAssetCode,FixedAssetName,NewField1,SERIALNO,REQUESTNO,NAME,REQUESTDATE};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
                }
                
                public TTReportField FixedAssetFault;
                public TTReportShape NewLine11; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    FixedAssetFault = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 265, 6, false);
                    FixedAssetFault.Name = "FixedAssetFault";
                    FixedAssetFault.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetFault.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FixedAssetFault.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetFault.NoClip = EvetHayirEnum.ehEvet;
                    FixedAssetFault.TextFont.Name = "Arial";
                    FixedAssetFault.TextFont.Bold = true;
                    FixedAssetFault.TextFont.CharSet = 162;
                    FixedAssetFault.Value = @"Cihaz Arıza Toplamı:{@subgroupcount@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 265, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class dataset_GetFaultCountsAndDetailsReportQuery2 = MyParentReport.PARTB.rsGroup.GetCurrentRecord<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(0);
                    FixedAssetFault.CalcValue = @"Cihaz Arıza Toplamı:" + (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { FixedAssetFault};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public FaultCountsAndDetailsReport MyParentReport
            {
                get { return (FaultCountsAndDetailsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField FaultDescription { get {return Body().FaultDescription;} }
            public TTReportField Count { get {return Body().Count;} }
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

                CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class dataSet_GetFaultCountsAndDetailsReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(0);    
                return new object[] {(dataSet_GetFaultCountsAndDetailsReportQuery2==null ? null : dataSet_GetFaultCountsAndDetailsReportQuery2.RequestType), (dataSet_GetFaultCountsAndDetailsReportQuery2==null ? null : dataSet_GetFaultCountsAndDetailsReportQuery2.FixedAssetNO)};
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
                public FaultCountsAndDetailsReport MyParentReport
                {
                    get { return (FaultCountsAndDetailsReport)ParentReport; }
                }
                
                public TTReportField FaultDescription;
                public TTReportField Count; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    FaultDescription = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 184, 5, false);
                    FaultDescription.Name = "FaultDescription";
                    FaultDescription.FieldType = ReportFieldTypeEnum.ftVariable;
                    FaultDescription.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FaultDescription.MultiLine = EvetHayirEnum.ehEvet;
                    FaultDescription.NoClip = EvetHayirEnum.ehEvet;
                    FaultDescription.WordBreak = EvetHayirEnum.ehEvet;
                    FaultDescription.ExpandTabs = EvetHayirEnum.ehEvet;
                    FaultDescription.TextFont.Name = "Arial";
                    FaultDescription.TextFont.CharSet = 162;
                    FaultDescription.Value = @"{#PARTB.FAULTDESCRIPTION#}";

                    Count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 10, 5, false);
                    Count.Name = "Count";
                    Count.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Count.TextFont.Name = "Arial";
                    Count.TextFont.Bold = true;
                    Count.TextFont.CharSet = 162;
                    Count.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class dataset_GetFaultCountsAndDetailsReportQuery2 = MyParentReport.PARTB.rsGroup.GetCurrentRecord<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(0);
                    FaultDescription.CalcValue = (dataset_GetFaultCountsAndDetailsReportQuery2 != null ? Globals.ToStringCore(dataset_GetFaultCountsAndDetailsReportQuery2.FaultDescription) : "");
                    Count.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { FaultDescription,Count};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FaultCountsAndDetailsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Tıbbi Cihaz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("19823496-5e62-42e8-9931-6f07ebe8211f");
            reportParameter = Parameters.Add("STOREFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("MATERIALFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            if (parameters.ContainsKey("STOREFLAG"))
                _runtimeParameters.STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREFLAG"]);
            if (parameters.ContainsKey("MATERIALFLAG"))
                _runtimeParameters.MATERIALFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["MATERIALFLAG"]);
            Name = "FAULTCOUNTSANDDETAILSREPORT";
            Caption = "Cihaz Arızalanma Raporu";
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