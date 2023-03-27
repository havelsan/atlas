
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
    /// İş Emirleri Durumu Raporu
    /// </summary>
    public partial class WorkOrdersStateReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public WorkOrdersStateReport MyParentReport
            {
                get { return (WorkOrdersStateReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
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
                public WorkOrdersStateReport MyParentReport
                {
                    get { return (WorkOrdersStateReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 228, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"İŞ İSTEK DURUMU RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 20, 116, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.TextFormat = @"Short Date";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@STARTDATE@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 20, 150, 25, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFormat = @"Short Date";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"{@ENDDATE@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 18, 120, 25, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Black";
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"-";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField1.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField2.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { LOGO,ReportName,NewField1,NewField2,NewField3};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public WorkOrdersStateReport MyParentReport
                {
                    get { return (WorkOrdersStateReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -16, 0, 9, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 137, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 275, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -16, 0, 275, 0, false);
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
            public WorkOrdersStateReport MyParentReport
            {
                get { return (WorkOrdersStateReport)ParentReport; }
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
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
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
                public WorkOrdersStateReport MyParentReport
                {
                    get { return (WorkOrdersStateReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportShape NewLine1;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -8, 0, 12, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İş İstek Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 35, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İş İstek Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 57, 8, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İş İstek Türü";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 0, 121, 8, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Cihaz Adı";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 249, 8, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"İşlem Durumu";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 166, 8, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Cihazın Kullanıcısı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 221, 8, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Gönderen Kısım";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -16, 9, 275, 9, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -15, 1, -9, 8, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"S.N";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 274, 8, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Onarım Yap.
Per.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField121,NewField122,NewField111,NewField1111,NewField2,NewField3};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public WorkOrdersStateReport MyParentReport
                {
                    get { return (WorkOrdersStateReport)ParentReport; }
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
            public WorkOrdersStateReport MyParentReport
            {
                get { return (WorkOrdersStateReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RequestNO { get {return Body().RequestNO;} }
            public TTReportField RequestDate { get {return Body().RequestDate;} }
            public TTReportField RequestType { get {return Body().RequestType;} }
            public TTReportField FixedAssetMaterialName { get {return Body().FixedAssetMaterialName;} }
            public TTReportField State { get {return Body().State;} }
            public TTReportField DeviceUser { get {return Body().DeviceUser;} }
            public TTReportField SenderSection { get {return Body().SenderSection;} }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField RESPONSIBLEUSER { get {return Body().RESPONSIBLEUSER;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField FIXEDASSETNAME { get {return Body().FIXEDASSETNAME;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetWorkOrdersStateReportQuery_Class>("GetWorkOrdersStateReportQuery", CMRActionRequest.GetWorkOrdersStateReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public WorkOrdersStateReport MyParentReport
                {
                    get { return (WorkOrdersStateReport)ParentReport; }
                }
                
                public TTReportField RequestNO;
                public TTReportField RequestDate;
                public TTReportField RequestType;
                public TTReportField FixedAssetMaterialName;
                public TTReportField State;
                public TTReportField DeviceUser;
                public TTReportField SenderSection;
                public TTReportField ObjectID;
                public TTReportShape NewLine1;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField RESPONSIBLEUSER;
                public TTReportField DESCRIPTION;
                public TTReportField FIXEDASSETNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    RequestNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -8, 1, 12, 10, false);
                    RequestNO.Name = "RequestNO";
                    RequestNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestNO.TextFont.Name = "Arial";
                    RequestNO.TextFont.Size = 8;
                    RequestNO.TextFont.CharSet = 162;
                    RequestNO.Value = @"{#REQUESTNO#}";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 35, 10, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDate.TextFormat = @"dd/MM/yyyy";
                    RequestDate.TextFont.Name = "Arial";
                    RequestDate.TextFont.Size = 8;
                    RequestDate.TextFont.CharSet = 162;
                    RequestDate.Value = @"{#REQUESTDATE#}";

                    RequestType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 57, 10, false);
                    RequestType.Name = "RequestType";
                    RequestType.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestType.WordBreak = EvetHayirEnum.ehEvet;
                    RequestType.ObjectDefName = "RequestTypeEnum";
                    RequestType.DataMember = "DISPLAYTEXT";
                    RequestType.TextFont.Name = "Arial";
                    RequestType.TextFont.Size = 8;
                    RequestType.TextFont.CharSet = 162;
                    RequestType.Value = @"{#REQUESTTYPE#}";

                    FixedAssetMaterialName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 1, 121, 10, false);
                    FixedAssetMaterialName.Name = "FixedAssetMaterialName";
                    FixedAssetMaterialName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetMaterialName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetMaterialName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetMaterialName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetMaterialName.TextFont.Name = "Arial";
                    FixedAssetMaterialName.TextFont.Size = 8;
                    FixedAssetMaterialName.TextFont.CharSet = 162;
                    FixedAssetMaterialName.Value = @"";

                    State = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 249, 10, false);
                    State.Name = "State";
                    State.FieldType = ReportFieldTypeEnum.ftVariable;
                    State.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    State.MultiLine = EvetHayirEnum.ehEvet;
                    State.WordBreak = EvetHayirEnum.ehEvet;
                    State.TextFont.Name = "Arial";
                    State.TextFont.Size = 8;
                    State.TextFont.CharSet = 162;
                    State.Value = @"";

                    DeviceUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 166, 10, false);
                    DeviceUser.Name = "DeviceUser";
                    DeviceUser.FieldType = ReportFieldTypeEnum.ftVariable;
                    DeviceUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DeviceUser.MultiLine = EvetHayirEnum.ehEvet;
                    DeviceUser.WordBreak = EvetHayirEnum.ehEvet;
                    DeviceUser.TextFont.Name = "Arial";
                    DeviceUser.TextFont.Size = 8;
                    DeviceUser.TextFont.CharSet = 162;
                    DeviceUser.Value = @"{#DEVICEUSER#}";

                    SenderSection = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 221, 10, false);
                    SenderSection.Name = "SenderSection";
                    SenderSection.FieldType = ReportFieldTypeEnum.ftVariable;
                    SenderSection.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SenderSection.MultiLine = EvetHayirEnum.ehEvet;
                    SenderSection.WordBreak = EvetHayirEnum.ehEvet;
                    SenderSection.TextFont.Name = "Arial";
                    SenderSection.TextFont.Size = 8;
                    SenderSection.TextFont.CharSet = 162;
                    SenderSection.Value = @"{#SENDERSECTION#}";

                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 3, 341, 8, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.Value = @"{#OBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -15, 11, 276, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 342, 3, 367, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.Value = @"{#CURRENTSTATEDEFID#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -15, 1, -9, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"{@counter@}";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 1, 275, 10, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.MultiLine = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.WordBreak = EvetHayirEnum.ehEvet;
                    RESPONSIBLEUSER.TextFont.Size = 8;
                    RESPONSIBLEUSER.TextFont.CharSet = 162;
                    RESPONSIBLEUSER.Value = @"{#RESPONSIBLEUSER#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 371, 3, 396, 8, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    FIXEDASSETNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 397, 3, 422, 8, false);
                    FIXEDASSETNAME.Name = "FIXEDASSETNAME";
                    FIXEDASSETNAME.Visible = EvetHayirEnum.ehHayir;
                    FIXEDASSETNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIXEDASSETNAME.Value = @"{#FIXEDASSETNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetWorkOrdersStateReportQuery_Class dataset_GetWorkOrdersStateReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetWorkOrdersStateReportQuery_Class>(0);
                    RequestNO.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.RequestNo) : "");
                    RequestDate.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.RequestDate) : "");
                    RequestType.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.RequestType) : "");
                    RequestType.PostFieldValueCalculation();
                    FixedAssetMaterialName.CalcValue = @"";
                    State.CalcValue = @"";
                    DeviceUser.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.Deviceuser) : "");
                    SenderSection.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.Sendersection) : "");
                    ObjectID.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.ObjectID) : "");
                    NewField1.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.CurrentStateDefID) : "");
                    NewField2.CalcValue = ParentGroup.Counter.ToString();
                    RESPONSIBLEUSER.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.Responsibleuser) : "");
                    DESCRIPTION.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.Description) : "");
                    FIXEDASSETNAME.CalcValue = (dataset_GetWorkOrdersStateReportQuery != null ? Globals.ToStringCore(dataset_GetWorkOrdersStateReportQuery.Fixedassetname) : "");
                    return new TTReportObject[] { RequestNO,RequestDate,RequestType,FixedAssetMaterialName,State,DeviceUser,SenderSection,ObjectID,NewField1,NewField2,RESPONSIBLEUSER,DESCRIPTION,FIXEDASSETNAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //MCA
            
            TTObjectContext ctx = new TTObjectContext(true);
            CMRAction action = (CMRAction)ctx.GetObject(new Guid(this.ObjectID.CalcValue), typeof(CMRAction));
            /*if (action.Equals(null))
            {
                this.State.CalcValue = action.CurrentStateDef.DisplayText.ToString();
            }*/
            if (!FixedAssetTypeEnum.StockNO.Equals(null))
            {
                if(((CMRActionRequest)action).FixedAssetType == FixedAssetTypeEnum.StockNO)
                {
                    // this.FixedAssetMaterialName.CalcValue = ((CMRActionRequest)action).FixedAssetDefinition.Name;
                }
            }
            
            if(!string.IsNullOrEmpty(DESCRIPTION.CalcValue))
            {
                FixedAssetMaterialName.CalcValue = DESCRIPTION.CalcValue;
            }
            else
            {
                FixedAssetMaterialName.CalcValue = FIXEDASSETNAME.CalcValue;
            }
            
            
            if(string.IsNullOrEmpty(FixedAssetMaterialName.CalcValue))
            {
                if(action.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                    FixedAssetMaterialName.CalcValue = action.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
            }
            
            
            if (!action.Equals(null))
            {
                if(action.CurrentStateDef.DisplayText == "İşlem Durumu")
                    State.CalcValue = "Kademede";
                else
                    State.CalcValue = action.CurrentStateDef.DisplayText.ToString();
            }
            //if(action is MaterialMaintenance)
            //{
            //    this.FixedAssetMaterialName.CalcValue = ((MaterialMaintenance)action).FixedAssetMaterialDefinition.Description;
            //}

            //            switch(this.RequestType.CalcValue)
            //            {
            //                case "Kalibrasyon":
            //                    Calibration calibration = (Calibration)ctx.GetObject(new Guid(this.ObjectID.CalcValue), typeof(CMRAction));
            //                    this.State.CalcValue = calibration.ForkCMRAction[0].CurrentStateDef.DisplayText.ToString();
            //                    break;
            //                case "Bakım":
            //                    Maintenance maintenance = (Maintenance)ctx.GetObject(new Guid(this.ObjectID.CalcValue), typeof(CMRAction));
            //                    this.State.CalcValue = maintenance.ForkCMRAction[0].CurrentStateDef.DisplayText.ToString();
            //                    break;
            //                case "Onarım":
            //                    Repair repair = (Repair)ctx.GetObject(new Guid(this.ObjectID.CalcValue), typeof(CMRAction));
            //                    this.State.CalcValue = repair.ForkCMRAction[0].CurrentStateDef.DisplayText.ToString();
            //                    break;
            //            }
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

        public WorkOrdersStateReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "WORKORDERSSTATEREPORT";
            Caption = "İş Emirleri Durumu Raporu";
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