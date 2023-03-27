
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
    /// Depo Envanterindeki Cizhazlar Raporu
    /// </summary>
    public partial class FixedAssetMaterialTrackingReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialTrackingReport MyParentReport
            {
                get { return (FixedAssetMaterialTrackingReport)ParentReport; }
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
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField Service { get {return Header().Service;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField HOSPITAL111 { get {return Header().HOSPITAL111;} }
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
                public FixedAssetMaterialTrackingReport MyParentReport
                {
                    get { return (FixedAssetMaterialTrackingReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField11111;
                public TTReportField Service;
                public TTReportShape NewLine111;
                public TTReportField HOSPITAL111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 26, 40, 46, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 244, 46, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"DEPO ENVANTERİNDEKİ CİHAZLAR RAPORU";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 53, 35, 59, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Bulunduğu Servis :";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 53, 258, 59, false);
                    Service.Name = "Service";
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.MultiLine = EvetHayirEnum.ehEvet;
                    Service.WordBreak = EvetHayirEnum.ehEvet;
                    Service.ObjectDefName = "Store";
                    Service.DataMember = "NAME";
                    Service.TextFont.Name = "Arial";
                    Service.TextFont.CharSet = 162;
                    Service.Value = @"{@STORE@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 60, 258, 60, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    HOSPITAL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 244, 24, false);
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
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    Service.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    Service.PostFieldValueCalculation();
                    HOSPITAL111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,ReportName,NewField11111,Service,HOSPITAL111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialTrackingReport MyParentReport
                {
                    get { return (FixedAssetMaterialTrackingReport)ParentReport; }
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
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 26, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 1, 146, 6, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 1, 258, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 0, 258, 0, false);
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
            public FixedAssetMaterialTrackingReport MyParentReport
            {
                get { return (FixedAssetMaterialTrackingReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
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
                public FixedAssetMaterialTrackingReport MyParentReport
                {
                    get { return (FixedAssetMaterialTrackingReport)ParentReport; }
                }
                
                public TTReportField NewField1221;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportShape NewLine12; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 0, 258, 6, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Anlık Durumu";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 68, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NSN Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 157, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Demirbaş Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 178, 6, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Marka";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 199, 6, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Model";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 0, 220, 6, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 6, 258, 6, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    return new TTReportObject[] { NewField1221,NewField1,NewField11,NewField12,NewField121,NewField122};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialTrackingReport MyParentReport
                {
                    get { return (FixedAssetMaterialTrackingReport)ParentReport; }
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
            public FixedAssetMaterialTrackingReport MyParentReport
            {
                get { return (FixedAssetMaterialTrackingReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField FixedAssetNO { get {return Body().FixedAssetNO;} }
            public TTReportField FixedAssetName { get {return Body().FixedAssetName;} }
            public TTReportField Mark { get {return Body().Mark;} }
            public TTReportField Model { get {return Body().Model;} }
            public TTReportField SerialNumber { get {return Body().SerialNumber;} }
            public TTReportField CMRStatus { get {return Body().CMRStatus;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class>("GetFixedAssetMaterialTrackingReportQuery", FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public FixedAssetMaterialTrackingReport MyParentReport
                {
                    get { return (FixedAssetMaterialTrackingReport)ParentReport; }
                }
                
                public TTReportField FixedAssetNO;
                public TTReportField FixedAssetName;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNumber;
                public TTReportField CMRStatus;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    FixedAssetNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 68, 10, false);
                    FixedAssetNO.Name = "FixedAssetNO";
                    FixedAssetNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetNO.TextFont.Name = "Arial";
                    FixedAssetNO.TextFont.CharSet = 162;
                    FixedAssetNO.Value = @"{#NATOSTOCKNO#}";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 1, 157, 10, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.Name = "Arial";
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"{#FIXEDASSETNAME#}";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 1, 178, 10, false);
                    Mark.Name = "Mark";
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.WordBreak = EvetHayirEnum.ehEvet;
                    Mark.TextFont.Name = "Arial";
                    Mark.TextFont.CharSet = 162;
                    Mark.Value = @"{#MARK#}";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 199, 10, false);
                    Model.Name = "Model";
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.WordBreak = EvetHayirEnum.ehEvet;
                    Model.TextFont.Name = "Arial";
                    Model.TextFont.CharSet = 162;
                    Model.Value = @"{#MODEL#}";

                    SerialNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 1, 220, 10, false);
                    SerialNumber.Name = "SerialNumber";
                    SerialNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber.TextFont.Name = "Arial";
                    SerialNumber.TextFont.CharSet = 162;
                    SerialNumber.Value = @"{#SERIALNUMBER#}";

                    CMRStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 1, 258, 10, false);
                    CMRStatus.Name = "CMRStatus";
                    CMRStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    CMRStatus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CMRStatus.MultiLine = EvetHayirEnum.ehEvet;
                    CMRStatus.WordBreak = EvetHayirEnum.ehEvet;
                    CMRStatus.ObjectDefName = "FixedAssetCMRStatusEnum";
                    CMRStatus.DataMember = "DISPLAYTEXT";
                    CMRStatus.TextFont.Name = "Arial";
                    CMRStatus.TextFont.CharSet = 162;
                    CMRStatus.Value = @"{#CMRSTATUS#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 10, 258, 10, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class dataset_GetFixedAssetMaterialTrackingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class>(0);
                    FixedAssetNO.CalcValue = (dataset_GetFixedAssetMaterialTrackingReportQuery != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialTrackingReportQuery.NATOStockNO) : "");
                    FixedAssetName.CalcValue = (dataset_GetFixedAssetMaterialTrackingReportQuery != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialTrackingReportQuery.Fixedassetname) : "");
                    Mark.CalcValue = (dataset_GetFixedAssetMaterialTrackingReportQuery != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialTrackingReportQuery.Mark) : "");
                    Model.CalcValue = (dataset_GetFixedAssetMaterialTrackingReportQuery != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialTrackingReportQuery.Model) : "");
                    SerialNumber.CalcValue = (dataset_GetFixedAssetMaterialTrackingReportQuery != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialTrackingReportQuery.SerialNumber) : "");
                    CMRStatus.CalcValue = (dataset_GetFixedAssetMaterialTrackingReportQuery != null ? Globals.ToStringCore(dataset_GetFixedAssetMaterialTrackingReportQuery.CMRStatus) : "");
                    CMRStatus.PostFieldValueCalculation();
                    return new TTReportObject[] { FixedAssetNO,FixedAssetName,Mark,Model,SerialNumber,CMRStatus};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FixedAssetMaterialTrackingReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Bulunduğu Depo", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            Name = "FIXEDASSETMATERIALTRACKINGREPORT";
            Caption = "Depo Envanterindeki Cizhazlar Raporu";
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