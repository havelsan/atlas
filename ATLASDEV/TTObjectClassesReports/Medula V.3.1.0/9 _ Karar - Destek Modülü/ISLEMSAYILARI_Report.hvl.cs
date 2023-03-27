
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
    public partial class ISLEMSAYILARI : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public int? HEALTHFACILITYID = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue("0");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("23:59");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField LOGO1;
                public TTReportField ReportName1;
                public TTReportField NewField111;
                public TTReportField NewField131;
                public TTReportField NewField1311;
                public TTReportField NewField1141;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 40, 25, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.Value = @"";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 5, 170, 25, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Size = 15;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"İŞLEM SAYILARI";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 27, 24, 32, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Başlangıç Tarihi";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 32, 24, 37, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Bitiş Tarihi";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 27, 26, 32, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 32, 26, 37, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 27, 51, 32, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STARTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.NoClip = EvetHayirEnum.ehEvet;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 32, 51, 37, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO1.CalcValue = LOGO1.Value;
                    ReportName1.CalcValue = ReportName1.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { LOGO1,ReportName1,NewField111,NewField131,NewField1311,NewField1141,STARTDATE,ENDDATE};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField CurrentUser1;
                public TTReportField PageNumber1;
                public TTReportField PrintDate1;
                public TTReportShape NewLine111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 102, 5, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 30, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 170, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber1.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : "";
                    return new TTReportObject[] { PageNumber1,PrintDate1,CurrentUser1};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
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
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField NewField1111111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 170, 7, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Tamamlanmış İşlemler";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111111.CalcValue = NewField1111111.Value;
                    return new TTReportObject[] { NewField1111111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField HEALTHFACILITYNAME { get {return Header().HEALTHFACILITYNAME;} }
            public TTReportField HEALTHFACILITYID { get {return Header().HEALTHFACILITYID;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField1113161 { get {return Footer().NewField1113161;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>("GUNLUKISLEMSAYISITAMAMLANMISReportQuery", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHFACILITYID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField HEALTHFACILITYNAME;
                public TTReportField HEALTHFACILITYID;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportShape NewLine1; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEALTHFACILITYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 170, 6, false);
                    HEALTHFACILITYNAME.Name = "HEALTHFACILITYNAME";
                    HEALTHFACILITYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYNAME.Value = @"";

                    HEALTHFACILITYID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 16, 6, false);
                    HEALTHFACILITYID.Name = "HEALTHFACILITYID";
                    HEALTHFACILITYID.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYID.Value = @"{#HEALTHFACILITYID#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 170, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 8, 70, 13, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İşlem";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 8, 170, 13, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İşlem Sayısı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 170, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>(0);
                    HEALTHFACILITYNAME.CalcValue = @"";
                    HEALTHFACILITYID.CalcValue = (dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery != null ? Globals.ToStringCore(dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery.HealthFacilityID) : "");
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    return new TTReportObject[] { HEALTHFACILITYNAME,HEALTHFACILITYID,NewField1111,NewField11111};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    if (string.IsNullOrEmpty(HEALTHFACILITYID.CalcValue) == false && Globals.IsNumeric(HEALTHFACILITYID.CalcValue))
            {
                SaglikTesisi saglikTesisi = SaglikTesisi.GetSaglikTesisi(Convert.ToInt32(HEALTHFACILITYID.CalcValue));
                if (saglikTesisi != null)
                    HEALTHFACILITYNAME.CalcValue = saglikTesisi.tesisAdi;
            }
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField1113161;
                public TTReportShape NewLine121; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField1113161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 1, 145, 6, false);
                    NewField1113161.Name = "NewField1113161";
                    NewField1113161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1113161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113161.TextFont.Bold = true;
                    NewField1113161.TextFont.CharSet = 162;
                    NewField1113161.Value = @"Toplam :";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>(0);
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField1113161.CalcValue = NewField1113161.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField1113161};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
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

                BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class dataSet_GUNLUKISLEMSAYISITAMAMLANMISReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>(0);    
                return new object[] {(dataSet_GUNLUKISLEMSAYISITAMAMLANMISReportQuery==null ? null : dataSet_GUNLUKISLEMSAYISITAMAMLANMISReportQuery.HealthFacilityID)};
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
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 2, 207, 7, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#PARTC.OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#PARTC.ISLEMSAYISI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 145, 5, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery != null ? Globals.ToStringCore(dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery != null ? Globals.ToStringCore(dataset_GUNLUKISLEMSAYISITAMAMLANMISReportQuery.Islemsayisi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
                    {
                        TTObjectDef objectDef;
                        TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                        if (objectDef != null)
                            OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
                    }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTB2Group : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public PARTB2GroupHeader Header()
            {
                return (PARTB2GroupHeader)_header;
            }

            new public PARTB2GroupFooter Footer()
            {
                return (PARTB2GroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public PARTB2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTB2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTB2GroupHeader(this);
                _footer = new PARTB2GroupFooter(this);

            }

            public partial class PARTB2GroupHeader : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField NewField111111; 
                public PARTB2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 170, 8, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Devam Eden İşlemler";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField111111};
                }
            }
            public partial class PARTB2GroupFooter : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                 
                public PARTB2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTB2Group PARTB2;

        public partial class PARTA2Group : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public PARTA2GroupHeader Header()
            {
                return (PARTA2GroupHeader)_header;
            }

            new public PARTA2GroupFooter Footer()
            {
                return (PARTA2GroupFooter)_footer;
            }

            public TTReportField HEALTHFACILITYNAME { get {return Header().HEALTHFACILITYNAME;} }
            public TTReportField HEALTHFACILITYID { get {return Header().HEALTHFACILITYID;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField SUMOFISLEMSAYISI { get {return Footer().SUMOFISLEMSAYISI;} }
            public TTReportField NewField11613111 { get {return Footer().NewField11613111;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public PARTA2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTA2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>("GUNLUKISLEMSAYISIDEVAMEDENReportQuery", BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHFACILITYID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTA2GroupHeader(this);
                _footer = new PARTA2GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTA2GroupHeader : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField HEALTHFACILITYNAME;
                public TTReportField HEALTHFACILITYID;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportShape NewLine11; 
                public PARTA2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEALTHFACILITYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 170, 6, false);
                    HEALTHFACILITYNAME.Name = "HEALTHFACILITYNAME";
                    HEALTHFACILITYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYNAME.Value = @"";

                    HEALTHFACILITYID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 16, 6, false);
                    HEALTHFACILITYID.Name = "HEALTHFACILITYID";
                    HEALTHFACILITYID.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYID.Value = @"{#HEALTHFACILITYID#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 170, 6, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 8, 70, 13, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İşlem";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 8, 170, 13, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"İşlem Sayısı";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 13, 170, 13, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>(0);
                    HEALTHFACILITYNAME.CalcValue = @"";
                    HEALTHFACILITYID.CalcValue = (dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery != null ? Globals.ToStringCore(dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery.HealthFacilityID) : "");
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { HEALTHFACILITYNAME,HEALTHFACILITYID,NewField11111,NewField111111};
                }

                public override void RunScript()
                {
#region PARTA2 HEADER_Script
                    if (string.IsNullOrEmpty(HEALTHFACILITYID.CalcValue) == false && Globals.IsNumeric(HEALTHFACILITYID.CalcValue))
            {
                SaglikTesisi saglikTesisi = SaglikTesisi.GetSaglikTesisi(Convert.ToInt32(HEALTHFACILITYID.CalcValue));
                if (saglikTesisi != null)
                    HEALTHFACILITYNAME.CalcValue = saglikTesisi.tesisAdi;
            }
#endregion PARTA2 HEADER_Script
                }
            }
            public partial class PARTA2GroupFooter : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField SUMOFISLEMSAYISI;
                public TTReportField NewField11613111;
                public TTReportShape NewLine1121; 
                public PARTA2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    SUMOFISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUMOFISLEMSAYISI.Name = "SUMOFISLEMSAYISI";
                    SUMOFISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFISLEMSAYISI.Value = @"{@sumof(ISLEMSAYISI)@}";

                    NewField11613111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    NewField11613111.Name = "NewField11613111";
                    NewField11613111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11613111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11613111.TextFont.Bold = true;
                    NewField11613111.TextFont.CharSet = 162;
                    NewField11613111.Value = @"Toplam :";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>(0);
                    SUMOFISLEMSAYISI.CalcValue = ParentGroup.FieldSums["ISLEMSAYISI"].Value.ToString();;
                    NewField11613111.CalcValue = NewField11613111.Value;
                    return new TTReportObject[] { SUMOFISLEMSAYISI,NewField11613111};
                }
            }

        }

        public PARTA2Group PARTA2;

        public partial class MAIN2Group : TTReportGroup
        {
            public ISLEMSAYILARI MyParentReport
            {
                get { return (ISLEMSAYILARI)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField OBJECTDEFID { get {return Body().OBJECTDEFID;} }
            public TTReportField ISLEMSAYISI { get {return Body().ISLEMSAYISI;} }
            public TTReportField OBJECTDEFCAPTION { get {return Body().OBJECTDEFCAPTION;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class dataSet_GUNLUKISLEMSAYISIDEVAMEDENReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>(0);    
                return new object[] {(dataSet_GUNLUKISLEMSAYISIDEVAMEDENReportQuery==null ? null : dataSet_GUNLUKISLEMSAYISIDEVAMEDENReportQuery.HealthFacilityID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public ISLEMSAYILARI MyParentReport
                {
                    get { return (ISLEMSAYILARI)ParentReport; }
                }
                
                public TTReportField OBJECTDEFID;
                public TTReportField ISLEMSAYISI;
                public TTReportField OBJECTDEFCAPTION; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    OBJECTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 2, 211, 7, false);
                    OBJECTDEFID.Name = "OBJECTDEFID";
                    OBJECTDEFID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFID.Value = @"{#PARTA2.OBJECTDEFID#}";

                    ISLEMSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    ISLEMSAYISI.Name = "ISLEMSAYISI";
                    ISLEMSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSAYISI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISLEMSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSAYISI.Value = @"{#PARTA2.ISLEMSAYISI#}";

                    OBJECTDEFCAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 145, 5, false);
                    OBJECTDEFCAPTION.Name = "OBJECTDEFCAPTION";
                    OBJECTDEFCAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEFCAPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTDEFCAPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery = MyParentReport.PARTA2.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>(0);
                    OBJECTDEFID.CalcValue = (dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery != null ? Globals.ToStringCore(dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery.ObjectDefID) : "");
                    ISLEMSAYISI.CalcValue = (dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery != null ? Globals.ToStringCore(dataset_GUNLUKISLEMSAYISIDEVAMEDENReportQuery.Islemsayisi) : "");
                    OBJECTDEFCAPTION.CalcValue = @"";
                    return new TTReportObject[] { OBJECTDEFID,ISLEMSAYISI,OBJECTDEFCAPTION};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    if (string.IsNullOrEmpty(OBJECTDEFID.CalcValue) == false && Globals.IsGuid(OBJECTDEFID.CalcValue))
                    {
                        TTObjectDef objectDef;
                        TTObjectDefManager.Instance.ObjectDefs.TryGetValue(new Guid(OBJECTDEFID.CalcValue), out objectDef);
                        if (objectDef != null)
                            OBJECTDEFCAPTION.CalcValue = objectDef.ApplicationName;
                    }
#endregion MAIN2 BODY_Script
                }
            }

        }

        public MAIN2Group MAIN2;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ISLEMSAYILARI()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            PARTB2 = new PARTB2Group(PARTB,"PARTB2");
            PARTA2 = new PARTA2Group(PARTB2,"PARTA2");
            MAIN2 = new MAIN2Group(PARTA2,"MAIN2");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("HEALTHFACILITYID", "0", "Sağlık Tesisi", @"", false, true, false, new Guid("356d7e0d-2f55-4f72-a85b-b1477416e9e1"));
            reportParameter.ListDefID = new Guid("228f6a96-13db-4b40-9cf6-50c083e12b0e");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("bf3434a5-9f3d-4dba-87cf-ad0a1662d342"));
            reportParameter = Parameters.Add("ENDDATE", "23:59", "Bitiş Tarihi", @"", true, true, false, new Guid("bf3434a5-9f3d-4dba-87cf-ad0a1662d342"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("HEALTHFACILITYID"))
                _runtimeParameters.HEALTHFACILITYID = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(parameters["HEALTHFACILITYID"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(parameters["ENDDATE"]);
            Name = "ISLEMSAYILARI";
            Caption = "İşlem Sayıları";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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