
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
    /// Demirbaş Zimmet Raporu
    /// </summary>
    public partial class FixedAssetMaterialDebitReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialDebitReport MyParentReport
            {
                get { return (FixedAssetMaterialDebitReport)ParentReport; }
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
            public TTReportField HOSPITAL11 { get {return Header().HOSPITAL11;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
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
                public FixedAssetMaterialDebitReport MyParentReport
                {
                    get { return (FixedAssetMaterialDebitReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField HOSPITAL11;
                public TTReportField LOGO1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 21, 201, 35, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"DEMİRBAŞ ZİMMET RAPORU";

                    HOSPITAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 7, 209, 17, false);
                    HOSPITAL11.Name = "HOSPITAL11";
                    HOSPITAL11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL11.TextFont.Name = "Arial";
                    HOSPITAL11.TextFont.Size = 13;
                    HOSPITAL11.TextFont.Bold = true;
                    HOSPITAL11.TextFont.CharSet = 162;
                    HOSPITAL11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 2, 339, 22, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.Visible = EvetHayirEnum.ehHayir;
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    HOSPITAL11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ReportName,LOGO1,HOSPITAL11};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialDebitReport MyParentReport
                {
                    get { return (FixedAssetMaterialDebitReport)ParentReport; }
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
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -7, 1, 18, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 1, 144, 6, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 1, 270, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -7, 0, 270, 0, false);
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
            public FixedAssetMaterialDebitReport MyParentReport
            {
                get { return (FixedAssetMaterialDebitReport)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
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
                public FixedAssetMaterialDebitReport MyParentReport
                {
                    get { return (FixedAssetMaterialDebitReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 30, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NSN Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 2, 110, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Cihazın Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 2, 152, 11, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Marka";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 2, 172, 11, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Model";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 2, 197, 11, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 2, 228, 11, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Zimmet Sahibi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 2, 270, 11, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Bulunduğu Servis";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -7, 2, 1, 11, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"S.N.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 2, 132, 11, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Son 
Kalibrasyon";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 2, 52, 11, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Garanti Bitiş";

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
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField121,NewField122,NewField111,NewField1111,NewField2,NewField3,NewField4};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialDebitReport MyParentReport
                {
                    get { return (FixedAssetMaterialDebitReport)ParentReport; }
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
            public FixedAssetMaterialDebitReport MyParentReport
            {
                get { return (FixedAssetMaterialDebitReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NatoNum { get {return Body().NatoNum;} }
            public TTReportField FixedAssetName { get {return Body().FixedAssetName;} }
            public TTReportField Mark { get {return Body().Mark;} }
            public TTReportField Model { get {return Body().Model;} }
            public TTReportField SerialNumber { get {return Body().SerialNumber;} }
            public TTReportField DebitPerson { get {return Body().DebitPerson;} }
            public TTReportField Service { get {return Body().Service;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField STOREOBJECTID { get {return Body().STOREOBJECTID;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
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
                list[0] = new TTReportNqlData<FixedAssetMaterialDefinition.GetDebitReport_Class>("GetDebitReport2", FixedAssetMaterialDefinition.GetDebitReport((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public FixedAssetMaterialDebitReport MyParentReport
                {
                    get { return (FixedAssetMaterialDebitReport)ParentReport; }
                }
                
                public TTReportField NatoNum;
                public TTReportField FixedAssetName;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNumber;
                public TTReportField DebitPerson;
                public TTReportField Service;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField STOREOBJECTID;
                public TTReportField DESCRIPTION;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    NatoNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 30, 9, false);
                    NatoNum.Name = "NatoNum";
                    NatoNum.DrawStyle = DrawStyleConstants.vbSolid;
                    NatoNum.FieldType = ReportFieldTypeEnum.ftVariable;
                    NatoNum.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NatoNum.TextFont.Name = "Arial";
                    NatoNum.TextFont.CharSet = 162;
                    NatoNum.Value = @"{#NATO#}";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 0, 110, 9, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.DrawStyle = DrawStyleConstants.vbSolid;
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.Name = "Arial";
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"{#FIXEDASSET#}";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 152, 9, false);
                    Mark.Name = "Mark";
                    Mark.DrawStyle = DrawStyleConstants.vbSolid;
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.MultiLine = EvetHayirEnum.ehEvet;
                    Mark.WordBreak = EvetHayirEnum.ehEvet;
                    Mark.TextFont.Name = "Arial";
                    Mark.TextFont.CharSet = 162;
                    Mark.Value = @"{#MARK#}";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 172, 9, false);
                    Model.Name = "Model";
                    Model.DrawStyle = DrawStyleConstants.vbSolid;
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.MultiLine = EvetHayirEnum.ehEvet;
                    Model.WordBreak = EvetHayirEnum.ehEvet;
                    Model.TextFont.Name = "Arial";
                    Model.TextFont.CharSet = 162;
                    Model.Value = @"{#MODEL#}";

                    SerialNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 197, 9, false);
                    SerialNumber.Name = "SerialNumber";
                    SerialNumber.DrawStyle = DrawStyleConstants.vbSolid;
                    SerialNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber.MultiLine = EvetHayirEnum.ehEvet;
                    SerialNumber.TextFont.Name = "Arial";
                    SerialNumber.TextFont.CharSet = 162;
                    SerialNumber.Value = @"{#SERIALNUMBER#}";

                    DebitPerson = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 228, 9, false);
                    DebitPerson.Name = "DebitPerson";
                    DebitPerson.DrawStyle = DrawStyleConstants.vbSolid;
                    DebitPerson.FieldType = ReportFieldTypeEnum.ftVariable;
                    DebitPerson.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DebitPerson.MultiLine = EvetHayirEnum.ehEvet;
                    DebitPerson.WordBreak = EvetHayirEnum.ehEvet;
                    DebitPerson.TextFont.Name = "Arial";
                    DebitPerson.TextFont.CharSet = 162;
                    DebitPerson.Value = @"";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 270, 9, false);
                    Service.Name = "Service";
                    Service.DrawStyle = DrawStyleConstants.vbSolid;
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.MultiLine = EvetHayirEnum.ehEvet;
                    Service.WordBreak = EvetHayirEnum.ehEvet;
                    Service.ObjectDefName = "Store";
                    Service.DataMember = "NAME";
                    Service.TextFont.Name = "Arial";
                    Service.TextFont.Size = 9;
                    Service.TextFont.CharSet = 162;
                    Service.Value = @"{@STORE@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -7, 0, 1, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.Value = @"{@counter@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 132, 9, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.TextFormat = @"dd/MM/yyyy";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.Value = @"{#LASTCALIBRATIONDATE#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 52, 9, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.TextFormat = @"Short Date";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.Value = @"{#GUARANTYENDDATE#}";

                    STOREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 1, 329, 6, false);
                    STOREOBJECTID.Name = "STOREOBJECTID";
                    STOREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOREOBJECTID.Value = @"{@STORE@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 332, 1, 357, 6, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 4, 326, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FixedAssetMaterialDefinition.GetDebitReport_Class dataset_GetDebitReport2 = ParentGroup.rsGroup.GetCurrentRecord<FixedAssetMaterialDefinition.GetDebitReport_Class>(0);
                    NatoNum.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.Nato) : "");
                    FixedAssetName.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.Fixedasset) : "");
                    Mark.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.Mark) : "");
                    Model.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.Model) : "");
                    SerialNumber.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.SerialNumber) : "");
                    DebitPerson.CalcValue = @"";
                    Service.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    Service.PostFieldValueCalculation();
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    NewField2.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.LastCalibrationDate) : "");
                    NewField3.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.GuarantyEndDate) : "");
                    STOREOBJECTID.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    DESCRIPTION.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.Description) : "");
                    OBJECTID.CalcValue = (dataset_GetDebitReport2 != null ? Globals.ToStringCore(dataset_GetDebitReport2.ObjectID) : "");
                    return new TTReportObject[] { NatoNum,FixedAssetName,Mark,Model,SerialNumber,DebitPerson,Service,NewField1,NewField2,NewField3,STOREOBJECTID,DESCRIPTION,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<SubStoreDefinition.GetSubStoreDefinition_Class> subStoreDefinition;
            BindingList<FixedAssetDefinition.FixedAssetDefinitionFormNQL_Class> fixedAsset;
            if(!string.IsNullOrEmpty(STOREOBJECTID.CalcValue))
            {
                
                subStoreDefinition =  SubStoreDefinition.GetSubStoreDefinition(ctx,"WHERE OBJECTID ='"+ this.STOREOBJECTID.CalcValue +"'");
                foreach (SubStoreDefinition.GetSubStoreDefinition_Class cx in subStoreDefinition)
                {
                    this.DebitPerson.CalcValue = cx.Storeresponsiblename.ToString();
                }
                
            }
            
            if(string.IsNullOrEmpty(FixedAssetName.CalcValue))
            {
                FixedAssetName.CalcValue = DESCRIPTION.CalcValue ;
                
            }
            if(string.IsNullOrEmpty(NatoNum.CalcValue))
            {
                if(!string.IsNullOrEmpty(OBJECTID.CalcValue))
                {
                    fixedAsset = FixedAssetDefinition.FixedAssetDefinitionFormNQL(ctx,"WHERE OBJECTID = '"+ this.OBJECTID.CalcValue +"'");
                    foreach(FixedAssetDefinition.FixedAssetDefinitionFormNQL_Class fx in fixedAsset)
                    {
                        this.NatoNum.CalcValue = fx.NATOStockNO.ToString();
                    }
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

        public FixedAssetMaterialDebitReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            Name = "FIXEDASSETMATERIALDEBITREPORT";
            Caption = "Demirbaş Zimmet Raporu";
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