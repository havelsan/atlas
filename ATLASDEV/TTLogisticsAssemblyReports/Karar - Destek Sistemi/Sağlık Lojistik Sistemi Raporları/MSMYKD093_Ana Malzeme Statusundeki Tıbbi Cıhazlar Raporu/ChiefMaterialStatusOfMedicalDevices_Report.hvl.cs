
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
    /// Ana Malzeme Statusundeki Tıbbi Cıhazlar Raporu
    /// </summary>
    public partial class ChiefMaterialStatusOfMedicalDevices : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ChiefMaterialStatusOfMedicalDevices MyParentReport
            {
                get { return (ChiefMaterialStatusOfMedicalDevices)ParentReport; }
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
            public TTReportField HOSPITAL1111 { get {return Header().HOSPITAL1111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public ChiefMaterialStatusOfMedicalDevices MyParentReport
                {
                    get { return (ChiefMaterialStatusOfMedicalDevices)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField HOSPITAL1111;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField12;
                public TTReportField NewField121; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 25, 194, 38, false);
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

                    HOSPITAL1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 6, 194, 23, false);
                    HOSPITAL1111.Name = "HOSPITAL1111";
                    HOSPITAL1111.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL1111.TextFont.Name = "Arial";
                    HOSPITAL1111.TextFont.Size = 12;
                    HOSPITAL1111.TextFont.Bold = true;
                    HOSPITAL1111.TextFont.CharSet = 162;
                    HOSPITAL1111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 56, 20, 72, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S.NU.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 56, 122, 63, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"CİHAZIN";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 63, 67, 72, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"ADI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 63, 90, 72, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"MARKA / MODEL";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 56, 137, 72, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"MİKTARI";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 63, 122, 72, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"KLİNİĞİ";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 56, 170, 72, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"
BAKIM
 GEREKTİRİR Mİ ?";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 56, 206, 72, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"
KALİBRASYON GEREKTİRİR Mİ?";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 26, 51, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"DEPOSU :";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 44, 194, 51, false);
                    NewField121.Name = "NewField121";
                    NewField121.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.ObjectDefName = "Store";
                    NewField121.DataMember = "NAME";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"{@STORE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = MyParentReport.RuntimeParameters.STORE.ToString();
                    NewField121.PostFieldValueCalculation();
                    HOSPITAL1111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ReportName,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField12,NewField121,HOSPITAL1111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                ReportName.CalcValue = "XXXXXX BİYOMEDİKAL MÜHENDİSLİK MERKEZİ"+"\n"+"ANA MALZEME STATÜSÜNDEKİ TIBBİ CİHAZLAR RAPORU";
            else
                ReportName.CalcValue = "ANA MALZEME STATÜSÜNDEKİ TIBBİ CİHAZLAR RAPORU";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ChiefMaterialStatusOfMedicalDevices MyParentReport
                {
                    get { return (ChiefMaterialStatusOfMedicalDevices)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1;
                public TTReportShape NewLine111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 35, 7, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 1, 122, 6, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Name = "Arial";
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 206, 6, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 206, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CurrentUser1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ChiefMaterialStatusOfMedicalDevices MyParentReport
            {
                get { return (ChiefMaterialStatusOfMedicalDevices)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField NEEDCALIBRATION { get {return Body().NEEDCALIBRATION;} }
            public TTReportField NEEDMAINTENANCE { get {return Body().NEEDMAINTENANCE;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField INHELD { get {return Body().INHELD;} }
            public TTReportField NAME1 { get {return Body().NAME1;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetStatusOfChiefMaterial_Class>("GetStatusOfChiefMaterial", CMRActionRequest.GetStatusOfChiefMaterial((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE)));
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
                public ChiefMaterialStatusOfMedicalDevices MyParentReport
                {
                    get { return (ChiefMaterialStatusOfMedicalDevices)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField MARK;
                public TTReportField NEEDCALIBRATION;
                public TTReportField NEEDMAINTENANCE;
                public TTReportField NewField1;
                public TTReportField INHELD;
                public TTReportField NAME1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 67, 11, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 0, 90, 11, false);
                    MARK.Name = "MARK";
                    MARK.DrawStyle = DrawStyleConstants.vbSolid;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARK.MultiLine = EvetHayirEnum.ehEvet;
                    MARK.WordBreak = EvetHayirEnum.ehEvet;
                    MARK.TextFont.Size = 9;
                    MARK.TextFont.CharSet = 162;
                    MARK.Value = @"{#MARK#} / {#MODEL#}";

                    NEEDCALIBRATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 206, 11, false);
                    NEEDCALIBRATION.Name = "NEEDCALIBRATION";
                    NEEDCALIBRATION.DrawStyle = DrawStyleConstants.vbSolid;
                    NEEDCALIBRATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEEDCALIBRATION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEEDCALIBRATION.MultiLine = EvetHayirEnum.ehEvet;
                    NEEDCALIBRATION.WordBreak = EvetHayirEnum.ehEvet;
                    NEEDCALIBRATION.TextFont.Size = 9;
                    NEEDCALIBRATION.TextFont.CharSet = 162;
                    NEEDCALIBRATION.Value = @"{#NEEDCALIBRATION#}";

                    NEEDMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 170, 11, false);
                    NEEDMAINTENANCE.Name = "NEEDMAINTENANCE";
                    NEEDMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    NEEDMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEEDMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEEDMAINTENANCE.MultiLine = EvetHayirEnum.ehEvet;
                    NEEDMAINTENANCE.WordBreak = EvetHayirEnum.ehEvet;
                    NEEDMAINTENANCE.TextFont.Size = 9;
                    NEEDMAINTENANCE.TextFont.CharSet = 162;
                    NEEDMAINTENANCE.Value = @"{#NEEDMAINTENANCE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 20, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@counter@}";

                    INHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 137, 11, false);
                    INHELD.Name = "INHELD";
                    INHELD.DrawStyle = DrawStyleConstants.vbSolid;
                    INHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    INHELD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    INHELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INHELD.TextFont.Size = 9;
                    INHELD.TextFont.CharSet = 162;
                    INHELD.Value = @"{#INHELD#}";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 122, 11, false);
                    NAME1.Name = "NAME1";
                    NAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.MultiLine = EvetHayirEnum.ehEvet;
                    NAME1.WordBreak = EvetHayirEnum.ehEvet;
                    NAME1.TextFont.Size = 9;
                    NAME1.TextFont.CharSet = 162;
                    NAME1.Value = @"{#NAME1#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetStatusOfChiefMaterial_Class dataset_GetStatusOfChiefMaterial = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetStatusOfChiefMaterial_Class>(0);
                    NAME.CalcValue = (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.Name) : "");
                    MARK.CalcValue = (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.Mark) : "") + @" / " + (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.Model) : "");
                    NEEDCALIBRATION.CalcValue = (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.NeedCalibration) : "");
                    NEEDMAINTENANCE.CalcValue = (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.NeedMaintenance) : "");
                    NewField1.CalcValue = ParentGroup.Counter.ToString();
                    INHELD.CalcValue = (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.Inheld) : "");
                    NAME1.CalcValue = (dataset_GetStatusOfChiefMaterial != null ? Globals.ToStringCore(dataset_GetStatusOfChiefMaterial.Name1) : "");
                    return new TTReportObject[] { NAME,MARK,NEEDCALIBRATION,NEEDMAINTENANCE,NewField1,INHELD,NAME1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(!string.IsNullOrEmpty(NEEDMAINTENANCE.CalcValue))
               {
                   if(NEEDMAINTENANCE.CalcValue == "True")
                   {
                       NEEDMAINTENANCE.CalcValue = "Bakım Gerektirir.";
                   }
                   else
                       NEEDMAINTENANCE.CalcValue = "Bakım Gerektirmez.";
               }
               else
               {
                   NEEDMAINTENANCE.CalcValue = "Bakım Gerektirmez.";
               }
               
               if(!string.IsNullOrEmpty(NEEDCALIBRATION.CalcValue))
                  {
                      if(NEEDCALIBRATION.CalcValue == "True")
                      {
                          NEEDCALIBRATION.CalcValue = "Kalibrasyon Gerektirir.";
                      }
                      else
                          NEEDCALIBRATION.CalcValue = "Kalibrasyon Gerektirmez.";
                  }
                  else
                  {
                      NEEDCALIBRATION.CalcValue = "Kalibrasyon Gerektirmez.";
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

        public ChiefMaterialStatusOfMedicalDevices()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Bulunduğu Depo : ", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            Name = "CHIEFMATERIALSTATUSOFMEDICALDEVICES";
            Caption = "Ana Malzeme Statusundeki Tıbbi Cıhazlar Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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