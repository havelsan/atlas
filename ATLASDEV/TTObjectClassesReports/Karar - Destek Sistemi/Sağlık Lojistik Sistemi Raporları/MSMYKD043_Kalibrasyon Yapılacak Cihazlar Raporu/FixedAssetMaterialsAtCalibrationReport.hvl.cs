
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
    /// Kalibrasyon Yapılacak Cihazlar Raporu
    /// </summary>
    public partial class FixedAssetMaterialsAtCalibrationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public Guid? PERSONNEL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? PERSONNELFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialsAtCalibrationReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
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
            public TTReportField HOSPITAL111 { get {return Header().HOSPITAL111;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
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
                public FixedAssetMaterialsAtCalibrationReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField HOSPITAL111;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 20, 346, 40, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 20, 236, 33, false);
                    ReportName.Name = "ReportName";
                    ReportName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.MultiLine = EvetHayirEnum.ehEvet;
                    ReportName.NoClip = EvetHayirEnum.ehEvet;
                    ReportName.WordBreak = EvetHayirEnum.ehEvet;
                    ReportName.ExpandTabs = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"";

                    HOSPITAL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 2, 227, 19, false);
                    HOSPITAL111.Name = "HOSPITAL111";
                    HOSPITAL111.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL111.TextFont.Name = "Arial";
                    HOSPITAL111.TextFont.Size = 12;
                    HOSPITAL111.TextFont.Bold = true;
                    HOSPITAL111.TextFont.CharSet = 162;
                    HOSPITAL111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 37, 122, 42, false);
                    NewField151.Name = "NewField151";
                    NewField151.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField151.TextFormat = @"Short Date";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"{@STARTDATE@}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 37, 131, 42, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"-";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 37, 168, 42, false);
                    NewField171.Name = "NewField171";
                    NewField171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField171.TextFormat = @"Short Date";
                    NewField171.TextFont.Size = 11;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = @"";
                    NewField151.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    HOSPITAL111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,ReportName,NewField151,NewField161,NewField171,HOSPITAL111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(((FixedAssetMaterialsAtCalibrationReport)ParentReport).RuntimeParameters.PERSONNEL == Guid.Empty)
                ((FixedAssetMaterialsAtCalibrationReport)ParentReport).RuntimeParameters.PERSONNELFLAG = 1;
            else
                        ((FixedAssetMaterialsAtCalibrationReport)ParentReport).RuntimeParameters.PERSONNELFLAG = 0;
            
            if(((FixedAssetMaterialsAtCalibrationReport)ParentReport).RuntimeParameters.STORE == Guid.Empty)
                ((FixedAssetMaterialsAtCalibrationReport)ParentReport).RuntimeParameters.STOREFLAG = 1;
            else
                ((FixedAssetMaterialsAtCalibrationReport)ParentReport).RuntimeParameters.STOREFLAG = 0;
            
            
            
            
            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                ReportName.CalcValue = "XXXXXX BİYOMEDİKAL MÜHENDİSLİK MERKEZİ"+"\n"+"KALİBRASYON YAPILAN/YAPILACAK CİHAZLAR RAPORU";
            else
                ReportName.CalcValue = "KALİBRASYON YAPILAN/YAPILACAK CİHAZLAR RAPORU";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsAtCalibrationReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
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
            public FixedAssetMaterialsAtCalibrationReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField SERINU { get {return Header().SERINU;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12311 { get {return Header().NewField12311;} }
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
                public FixedAssetMaterialsAtCalibrationReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField1111;
                public TTReportShape NewLine1;
                public TTReportField SERINU;
                public TTReportField NewField13;
                public TTReportField NewField111;
                public TTReportField NewField1;
                public TTReportField NewField12311;
                public TTReportField NewField2;
                public TTReportField NewField3; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 4, 382, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Demirbaş Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 21, 320, 27, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Marka";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 321, 21, 341, 27, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Model";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 342, 21, 362, 27, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 156, 14, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Bulunduğu Servis/Klinik/XXXXXX";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 15, 257, 15, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    SERINU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 13, 14, false);
                    SERINU.Name = "SERINU";
                    SERINU.DrawStyle = DrawStyleConstants.vbSolid;
                    SERINU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERINU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERINU.TextFont.Name = "Arial";
                    SERINU.TextFont.Bold = true;
                    SERINU.TextFont.CharSet = 162;
                    SERINU.Value = @"S.Nu.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 53, 14, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"
Nato Stok Numarası
";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 1, 97, 14, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Cihazın Adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 13, 326, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Demirbaş Kodu";

                    NewField12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 205, 14, false);
                    NewField12311.Name = "NewField12311";
                    NewField12311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12311.TextFont.Name = "Arial";
                    NewField12311.TextFont.Bold = true;
                    NewField12311.TextFont.CharSet = 162;
                    NewField12311.Value = @"Cihazın Kalibrasyonunu
Yapan/Yapacak Personel";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 1, 231, 14, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Kalibrasyon Tarihi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 1, 256, 14, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Sonraki Kalibrasyon Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    SERINU.CalcValue = SERINU.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12311.CalcValue = NewField12311.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField11,NewField12,NewField121,NewField122,NewField1111,SERINU,NewField13,NewField111,NewField1,NewField12311,NewField2,NewField3};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsAtCalibrationReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
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
            public FixedAssetMaterialsAtCalibrationReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
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
            public TTReportField SIRANUCOUNTER { get {return Body().SIRANUCOUNTER;} }
            public TTReportField NatoStockNo { get {return Body().NatoStockNo;} }
            public TTReportField FixedAssetNO { get {return Body().FixedAssetNO;} }
            public TTReportField PERSONEL { get {return Body().PERSONEL;} }
            public TTReportField LASTCALIBRATIONDATE { get {return Body().LASTCALIBRATIONDATE;} }
            public TTReportField NEXTCALIBRATIONDATE { get {return Body().NEXTCALIBRATIONDATE;} }
            public TTReportField CALIBRATIONPERIOD { get {return Body().CALIBRATIONPERIOD;} }
            public TTReportField MO_ID { get {return Body().MO_ID;} }
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
                list[0] = new TTReportNqlData<Calibration.CalibrationReportQuery_Class>("CalibrationReportQuery", Calibration.CalibrationReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PERSONNEL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PERSONNELFLAG),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREFLAG)));
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
                public FixedAssetMaterialsAtCalibrationReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtCalibrationReport)ParentReport; }
                }
                
                public TTReportField FixedAssetName;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNumber;
                public TTReportField Service;
                public TTReportField SIRANUCOUNTER;
                public TTReportField NatoStockNo;
                public TTReportField FixedAssetNO;
                public TTReportField PERSONEL;
                public TTReportField LASTCALIBRATIONDATE;
                public TTReportField NEXTCALIBRATIONDATE;
                public TTReportField CALIBRATIONPERIOD;
                public TTReportField MO_ID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 0, 97, 15, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.DrawStyle = DrawStyleConstants.vbSolid;
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.Name = "Arial";
                    FixedAssetName.TextFont.Size = 9;
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 25, 321, 34, false);
                    Mark.Name = "Mark";
                    Mark.Visible = EvetHayirEnum.ehHayir;
                    Mark.DrawStyle = DrawStyleConstants.vbSolid;
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.WordBreak = EvetHayirEnum.ehEvet;
                    Mark.TextFont.Name = "Arial";
                    Mark.TextFont.CharSet = 162;
                    Mark.Value = @"";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 322, 25, 342, 34, false);
                    Model.Name = "Model";
                    Model.Visible = EvetHayirEnum.ehHayir;
                    Model.DrawStyle = DrawStyleConstants.vbSolid;
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.WordBreak = EvetHayirEnum.ehEvet;
                    Model.TextFont.Name = "Arial";
                    Model.TextFont.CharSet = 162;
                    Model.Value = @"";

                    SerialNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 343, 25, 363, 34, false);
                    SerialNumber.Name = "SerialNumber";
                    SerialNumber.Visible = EvetHayirEnum.ehHayir;
                    SerialNumber.DrawStyle = DrawStyleConstants.vbSolid;
                    SerialNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber.TextFont.Name = "Arial";
                    SerialNumber.TextFont.CharSet = 162;
                    SerialNumber.Value = @"";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 156, 15, false);
                    Service.Name = "Service";
                    Service.DrawStyle = DrawStyleConstants.vbSolid;
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.MultiLine = EvetHayirEnum.ehEvet;
                    Service.WordBreak = EvetHayirEnum.ehEvet;
                    Service.TextFont.Name = "Arial";
                    Service.TextFont.Size = 9;
                    Service.TextFont.CharSet = 162;
                    Service.Value = @"";

                    SIRANUCOUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 13, 15, false);
                    SIRANUCOUNTER.Name = "SIRANUCOUNTER";
                    SIRANUCOUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANUCOUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANUCOUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANUCOUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANUCOUNTER.Value = @"{@counter@}";

                    NatoStockNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 52, 15, false);
                    NatoStockNo.Name = "NatoStockNo";
                    NatoStockNo.DrawStyle = DrawStyleConstants.vbSolid;
                    NatoStockNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NatoStockNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NatoStockNo.TextFont.Name = "Arial";
                    NatoStockNo.TextFont.CharSet = 162;
                    NatoStockNo.Value = @"";

                    FixedAssetNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 12, 327, 21, false);
                    FixedAssetNO.Name = "FixedAssetNO";
                    FixedAssetNO.Visible = EvetHayirEnum.ehHayir;
                    FixedAssetNO.DrawStyle = DrawStyleConstants.vbSolid;
                    FixedAssetNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetNO.TextFont.Name = "Arial";
                    FixedAssetNO.TextFont.CharSet = 162;
                    FixedAssetNO.Value = @"";

                    PERSONEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 205, 15, false);
                    PERSONEL.Name = "PERSONEL";
                    PERSONEL.DrawStyle = DrawStyleConstants.vbSolid;
                    PERSONEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONEL.MultiLine = EvetHayirEnum.ehEvet;
                    PERSONEL.WordBreak = EvetHayirEnum.ehEvet;
                    PERSONEL.TextFont.Name = "Arial";
                    PERSONEL.TextFont.Size = 9;
                    PERSONEL.TextFont.CharSet = 162;
                    PERSONEL.Value = @"";

                    LASTCALIBRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 231, 15, false);
                    LASTCALIBRATIONDATE.Name = "LASTCALIBRATIONDATE";
                    LASTCALIBRATIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    LASTCALIBRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTCALIBRATIONDATE.TextFormat = @"Short Date";
                    LASTCALIBRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTCALIBRATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LASTCALIBRATIONDATE.Value = @"";

                    NEXTCALIBRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 256, 15, false);
                    NEXTCALIBRATIONDATE.Name = "NEXTCALIBRATIONDATE";
                    NEXTCALIBRATIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    NEXTCALIBRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEXTCALIBRATIONDATE.TextFormat = @"Short Date";
                    NEXTCALIBRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEXTCALIBRATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEXTCALIBRATIONDATE.Value = @"";

                    CALIBRATIONPERIOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 3, 328, 8, false);
                    CALIBRATIONPERIOD.Name = "CALIBRATIONPERIOD";
                    CALIBRATIONPERIOD.Visible = EvetHayirEnum.ehHayir;
                    CALIBRATIONPERIOD.DrawStyle = DrawStyleConstants.vbSolid;
                    CALIBRATIONPERIOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    CALIBRATIONPERIOD.Value = @"";

                    MO_ID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 342, 5, 367, 10, false);
                    MO_ID.Name = "MO_ID";
                    MO_ID.Visible = EvetHayirEnum.ehHayir;
                    MO_ID.DrawStyle = DrawStyleConstants.vbSolid;
                    MO_ID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MO_ID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Calibration.CalibrationReportQuery_Class dataset_CalibrationReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Calibration.CalibrationReportQuery_Class>(0);
                    FixedAssetName.CalcValue = @"";
                    Mark.CalcValue = @"";
                    Model.CalcValue = @"";
                    SerialNumber.CalcValue = @"";
                    Service.CalcValue = @"";
                    SIRANUCOUNTER.CalcValue = ParentGroup.Counter.ToString();
                    NatoStockNo.CalcValue = NatoStockNo.Value;
                    FixedAssetNO.CalcValue = @"";
                    PERSONEL.CalcValue = @"";
                    LASTCALIBRATIONDATE.CalcValue = @"";
                    NEXTCALIBRATIONDATE.CalcValue = @"";
                    CALIBRATIONPERIOD.CalcValue = @"";
                    MO_ID.CalcValue = (dataset_CalibrationReportQuery != null ? Globals.ToStringCore(dataset_CalibrationReportQuery.ObjectID) : "");
                    return new TTReportObject[] { FixedAssetName,Mark,Model,SerialNumber,Service,SIRANUCOUNTER,NatoStockNo,FixedAssetNO,PERSONEL,LASTCALIBRATIONDATE,NEXTCALIBRATIONDATE,CALIBRATIONPERIOD,MO_ID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);


            if (MO_ID.CalcValue.ToString() != "")
            {
                Calibration mo1 = (Calibration)ctx.GetObject(new Guid(this.MO_ID.CalcValue.ToString()), typeof(Calibration));
                int calibrationPeriod = 0 ;
                DateTime lastCalibrationDate = DateTime.MinValue ;
                
                if (mo1 != null )
                {
                    if (mo1.FixedAssetMaterialDefinition != null && mo1.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                    {
                        NatoStockNo.CalcValue = mo1.FixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO.ToString();
                        FixedAssetName.CalcValue = mo1.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString();
                        if(mo1.FixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod != null)
                            calibrationPeriod =(int)mo1.FixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod ;
                    }
                    else
                    {
                        NatoStockNo.CalcValue = "--";
                        FixedAssetName.CalcValue = "--";
                    }
                    
                   
                    if (mo1.FixedAssetMaterialDefinition != null)
                        Service.CalcValue = mo1.FixedAssetMaterialDefinition.Stock.Store.Name.ToString();
                    else if(mo1.SenderSection != null && string.IsNullOrEmpty(Service.CalcValue))
                        Service.CalcValue = mo1.SenderSection.Store.Name.ToString();
                    else
                        Service.CalcValue = "--";

                    if (mo1.ResponsibleUser != null && mo1.ResponsibleUser.Person != null)
                        PERSONEL.CalcValue = mo1.ResponsibleUser.Person.Name.ToString()+" "+mo1.ResponsibleUser.Person.Surname.ToString();
                    else
                        PERSONEL.CalcValue = "--";

                    if (mo1.FixedAssetMaterialDefinition != null)
                    {
                        LASTCALIBRATIONDATE.CalcValue = mo1.FixedAssetMaterialDefinition.LastCalibrationDate.Value.ToString();
                        lastCalibrationDate = (DateTime)mo1.FixedAssetMaterialDefinition.LastCalibrationDate ;
                    }
                    else
                        LASTCALIBRATIONDATE.CalcValue = "--";


                    if(calibrationPeriod > 0)
                    {
                        if(lastCalibrationDate != DateTime.MinValue)
                        {
                            DateTime nextCalibrationDate = lastCalibrationDate.AddMonths(calibrationPeriod);
                            NEXTCALIBRATIONDATE.CalcValue =nextCalibrationDate.ToString();
                        }
                    }
                    else
                        LASTCALIBRATIONDATE.CalcValue = "--";
                    
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

        public FixedAssetMaterialsAtCalibrationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Deposu", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STOREFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PERSONNEL", "00000000-0000-0000-0000-000000000000", "Personel ", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("PERSONNELFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("STOREFLAG"))
                _runtimeParameters.STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREFLAG"]);
            if (parameters.ContainsKey("PERSONNEL"))
                _runtimeParameters.PERSONNEL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PERSONNEL"]);
            if (parameters.ContainsKey("PERSONNELFLAG"))
                _runtimeParameters.PERSONNELFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PERSONNELFLAG"]);
            Name = "FIXEDASSETMATERIALSATCALIBRATIONREPORT";
            Caption = "Kalibrasyon Yapılacak Cihazlar Raporu";
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