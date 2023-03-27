
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
    public partial class TAKIPNUMARASIALINMISHASTALAR : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public int? HEALTHFACILITYID = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue("0");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("23:59");
            public int? BRANSKODU = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue("0");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public TAKIPNUMARASIALINMISHASTALAR MyParentReport
            {
                get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
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
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
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
                    ReportName1.Value = @"TAKİP NUMARASI ALINMIŞ HASTALAR";

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
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
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
                    
                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 103, 5, false);
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

        public partial class PARTCGroup : TTReportGroup
        {
            public TAKIPNUMARASIALINMISHASTALAR MyParentReport
            {
                get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
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
            public TTReportField SUMOFHASTAKABUL { get {return Footer().SUMOFHASTAKABUL;} }
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
                list[0] = new TTReportNqlData<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>("TAKIPNUMARASIALINMISHASTALARReportQuery", BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHFACILITYID),(int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.BRANSKODU)));
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
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
                }
                
                public TTReportField HEALTHFACILITYNAME;
                public TTReportField HEALTHFACILITYID;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataset_TAKIPNUMARASIALINMISHASTALARReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);
                    HEALTHFACILITYNAME.CalcValue = @"";
                    HEALTHFACILITYID.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.HealthFacilityID) : "");
                    return new TTReportObject[] { HEALTHFACILITYNAME,HEALTHFACILITYID};
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
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
                }
                
                public TTReportField SUMOFHASTAKABUL;
                public TTReportField NewField1113161;
                public TTReportShape NewLine121; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SUMOFHASTAKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUMOFHASTAKABUL.Name = "SUMOFHASTAKABUL";
                    SUMOFHASTAKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFHASTAKABUL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUMOFHASTAKABUL.Value = @"{@sumof(SUBGROUPCOUNTHASTAKABUL)@}";

                    NewField1113161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
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
                    BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataset_TAKIPNUMARASIALINMISHASTALARReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);
                    SUMOFHASTAKABUL.CalcValue = ParentGroup.FieldSums["SUBGROUPCOUNTHASTAKABUL"].Value.ToString();;
                    NewField1113161.CalcValue = NewField1113161.Value;
                    return new TTReportObject[] { SUMOFHASTAKABUL,NewField1113161};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public TAKIPNUMARASIALINMISHASTALAR MyParentReport
            {
                get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField BRANSKODU { get {return Header().BRANSKODU;} }
            public TTReportField BRANS { get {return Header().BRANS;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11312 { get {return Header().NewField11312;} }
            public TTReportField NewField11313 { get {return Header().NewField11313;} }
            public TTReportField NewField11314 { get {return Header().NewField11314;} }
            public TTReportField NewField11315 { get {return Header().NewField11315;} }
            public TTReportField NewField11316 { get {return Header().NewField11316;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField NewField161311 { get {return Footer().NewField161311;} }
            public TTReportField SUBGROUPCOUNTHASTAKABUL { get {return Footer().SUBGROUPCOUNTHASTAKABUL;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);    
                return new object[] {(dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery==null ? null : dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery.HealthFacilityID)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
                }
                
                public TTReportField BRANSKODU;
                public TTReportField BRANS;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField11312;
                public TTReportField NewField11313;
                public TTReportField NewField11314;
                public TTReportField NewField11315;
                public TTReportField NewField11316;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BRANSKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 10, 5, false);
                    BRANSKODU.Name = "BRANSKODU";
                    BRANSKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANSKODU.Value = @"{#PARTC.BRANSKODU#}";

                    BRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 170, 5, false);
                    BRANS.Name = "BRANS";
                    BRANS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANS.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 6, 21, 11, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"İşlem Nu.";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 6, 47, 11, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"İşlem Tarihi";

                    NewField11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 6, 68, 11, false);
                    NewField11312.Name = "NewField11312";
                    NewField11312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11312.TextFont.Bold = true;
                    NewField11312.TextFont.CharSet = 162;
                    NewField11312.Value = @"Başvuru Nu.";

                    NewField11313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 6, 85, 11, false);
                    NewField11313.Name = "NewField11313";
                    NewField11313.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11313.TextFont.Bold = true;
                    NewField11313.TextFont.CharSet = 162;
                    NewField11313.Value = @"Takip Nu.";

                    NewField11314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 6, 108, 11, false);
                    NewField11314.Name = "NewField11314";
                    NewField11314.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11314.TextFont.Bold = true;
                    NewField11314.TextFont.CharSet = 162;
                    NewField11314.Value = @"Adı";

                    NewField11315 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 6, 139, 11, false);
                    NewField11315.Name = "NewField11315";
                    NewField11315.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11315.TextFont.Bold = true;
                    NewField11315.TextFont.CharSet = 162;
                    NewField11315.Value = @"Soyadı";

                    NewField11316 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 6, 170, 11, false);
                    NewField11316.Name = "NewField11316";
                    NewField11316.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11316.TextFont.Bold = true;
                    NewField11316.TextFont.CharSet = 162;
                    NewField11316.Value = @"Vatandaşlık Nu.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 170, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 12, 170, 12, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataset_TAKIPNUMARASIALINMISHASTALARReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);
                    BRANSKODU.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.bransKodu) : "");
                    BRANS.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11312.CalcValue = NewField11312.Value;
                    NewField11313.CalcValue = NewField11313.Value;
                    NewField11314.CalcValue = NewField11314.Value;
                    NewField11315.CalcValue = NewField11315.Value;
                    NewField11316.CalcValue = NewField11316.Value;
                    return new TTReportObject[] { BRANSKODU,BRANS,NewField1131,NewField11311,NewField11312,NewField11313,NewField11314,NewField11315,NewField11316};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (string.IsNullOrEmpty(BRANSKODU.CalcValue) == false)
                    {
                        SpecialityDefinition brans = SpecialityDefinition.GetBrans(BRANSKODU.CalcValue);
                        if (brans != null)
                            BRANS.CalcValue = brans.Name;
                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
                }
                
                public TTReportField NewField161311;
                public TTReportField SUBGROUPCOUNTHASTAKABUL;
                public TTReportShape NewLine12; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField161311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    NewField161311.Name = "NewField161311";
                    NewField161311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField161311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161311.TextFont.Bold = true;
                    NewField161311.TextFont.CharSet = 162;
                    NewField161311.Value = @"Toplam :";

                    SUBGROUPCOUNTHASTAKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 170, 6, false);
                    SUBGROUPCOUNTHASTAKABUL.Name = "SUBGROUPCOUNTHASTAKABUL";
                    SUBGROUPCOUNTHASTAKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNTHASTAKABUL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBGROUPCOUNTHASTAKABUL.Value = @"{@subgroupcount@}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 1, 170, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataset_TAKIPNUMARASIALINMISHASTALARReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);
                    NewField161311.CalcValue = NewField161311.Value;
                    SUBGROUPCOUNTHASTAKABUL.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { NewField161311,SUBGROUPCOUNTHASTAKABUL};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public TAKIPNUMARASIALINMISHASTALAR MyParentReport
            {
                get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MEDULAACTIONID { get {return Body().MEDULAACTIONID;} }
            public TTReportField PROVIZYONTARIHI { get {return Body().PROVIZYONTARIHI;} }
            public TTReportField HASTABASVURUNO { get {return Body().HASTABASVURUNO;} }
            public TTReportField TAKIPNO { get {return Body().TAKIPNO;} }
            public TTReportField AD { get {return Body().AD;} }
            public TTReportField SOYAD { get {return Body().SOYAD;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
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

                BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery = ParentGroup.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);    
                return new object[] {(dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery==null ? null : dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery.HealthFacilityID), (dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery==null ? null : dataSet_TAKIPNUMARASIALINMISHASTALARReportQuery.bransKodu)};
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
                public TAKIPNUMARASIALINMISHASTALAR MyParentReport
                {
                    get { return (TAKIPNUMARASIALINMISHASTALAR)ParentReport; }
                }
                
                public TTReportField MEDULAACTIONID;
                public TTReportField PROVIZYONTARIHI;
                public TTReportField HASTABASVURUNO;
                public TTReportField TAKIPNO;
                public TTReportField AD;
                public TTReportField SOYAD;
                public TTReportField TCKIMLIKNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    MEDULAACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 21, 5, false);
                    MEDULAACTIONID.Name = "MEDULAACTIONID";
                    MEDULAACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDULAACTIONID.Value = @"{#PARTC.MEDULAACTIONID#}";

                    PROVIZYONTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 47, 5, false);
                    PROVIZYONTARIHI.Name = "PROVIZYONTARIHI";
                    PROVIZYONTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONTARIHI.Value = @"{#PARTC.PROVIZYONTARIHI#}";

                    HASTABASVURUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 68, 5, false);
                    HASTABASVURUNO.Name = "HASTABASVURUNO";
                    HASTABASVURUNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTABASVURUNO.Value = @"{#PARTC.HASTABASVURUNO#}";

                    TAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 85, 5, false);
                    TAKIPNO.Name = "TAKIPNO";
                    TAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAKIPNO.Value = @"{#PARTC.TAKIPNO#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 108, 5, false);
                    AD.Name = "AD";
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.Value = @"{#PARTC.AD#}";

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 139, 5, false);
                    SOYAD.Name = "SOYAD";
                    SOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYAD.Value = @"{#PARTC.SOYAD#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 170, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"{#PARTC.TCKIMLIKNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class dataset_TAKIPNUMARASIALINMISHASTALARReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<BaseHastaKabul.TAKIPNUMARASIALINMISHASTALARReportQuery_Class>(0);
                    MEDULAACTIONID.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.MedulaActionID) : "");
                    PROVIZYONTARIHI.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.provizyonTarihi) : "");
                    HASTABASVURUNO.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.hastaBasvuruNo) : "");
                    TAKIPNO.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.takipNo) : "");
                    AD.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.ad) : "");
                    SOYAD.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.soyad) : "");
                    TCKIMLIKNO.CalcValue = (dataset_TAKIPNUMARASIALINMISHASTALARReportQuery != null ? Globals.ToStringCore(dataset_TAKIPNUMARASIALINMISHASTALARReportQuery.tcKimlikNo) : "");
                    return new TTReportObject[] { MEDULAACTIONID,PROVIZYONTARIHI,HASTABASVURUNO,TAKIPNO,AD,SOYAD,TCKIMLIKNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TAKIPNUMARASIALINMISHASTALAR()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("HEALTHFACILITYID", "0", "Sağlık Tesisi", @"", false, true, false, new Guid("356d7e0d-2f55-4f72-a85b-b1477416e9e1"));
            reportParameter.ListDefID = new Guid("228f6a96-13db-4b40-9cf6-50c083e12b0e");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("bf3434a5-9f3d-4dba-87cf-ad0a1662d342"));
            reportParameter = Parameters.Add("ENDDATE", "23:59", "Bitiş Tarihi", @"", true, true, false, new Guid("bf3434a5-9f3d-4dba-87cf-ad0a1662d342"));
            reportParameter = Parameters.Add("BRANSKODU", "XXXXXX", "Branş Kodu", @"", false, true, false, new Guid("356d7e0d-2f55-4f72-a85b-b1477416e9e1"));
            reportParameter.ListDefID = new Guid("8b28f3a9-d983-4221-a2b8-65a9dc603636");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("HEALTHFACILITYID"))
                _runtimeParameters.HEALTHFACILITYID = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(parameters["HEALTHFACILITYID"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("BRANSKODU"))
                _runtimeParameters.BRANSKODU = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(parameters["BRANSKODU"]);
            Name = "TAKIPNUMARASIALINMISHASTALAR";
            Caption = "Takip Numarası Alınmış Hastalar";
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