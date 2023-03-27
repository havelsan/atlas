
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
    public partial class MUAYENEBILGILERI : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public int? HEALTHFACILITYID = (int?)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue("0");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("23:59");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public MUAYENEBILGILERI MyParentReport
            {
                get { return (MUAYENEBILGILERI)ParentReport; }
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
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public MUAYENEBILGILERI MyParentReport
                {
                    get { return (MUAYENEBILGILERI)ParentReport; }
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
                    ReportName1.Value = @"MUAYENE BİLGİSİ KAYDEDİLMİŞ HASTALAR";

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

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 27, 56, 32, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STARTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.NoClip = EvetHayirEnum.ehEvet;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 32, 56, 37, false);
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
                public MUAYENEBILGILERI MyParentReport
                {
                    get { return (MUAYENEBILGILERI)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 103, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 30, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 170, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public MUAYENEBILGILERI MyParentReport
            {
                get { return (MUAYENEBILGILERI)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11312 { get {return Header().NewField11312;} }
            public TTReportField NewField11313 { get {return Header().NewField11313;} }
            public TTReportField NewField11314 { get {return Header().NewField11314;} }
            public TTReportField NewField11315 { get {return Header().NewField11315;} }
            public TTReportField NewField11316 { get {return Header().NewField11316;} }
            public TTReportField HEALTHFACILITYNAME { get {return Header().HEALTHFACILITYNAME;} }
            public TTReportField HEALTHFACILITYID { get {return Header().HEALTHFACILITYID;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
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

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>("MUAYENEBILGILERIReportQuery", MuayeneGiris.MUAYENEBILGILERIReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHFACILITYID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public MUAYENEBILGILERI MyParentReport
                {
                    get { return (MUAYENEBILGILERI)ParentReport; }
                }
                
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField11312;
                public TTReportField NewField11313;
                public TTReportField NewField11314;
                public TTReportField NewField11315;
                public TTReportField NewField11316;
                public TTReportField HEALTHFACILITYNAME;
                public TTReportField HEALTHFACILITYID;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
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
                    NewField11311.Value = @"İşlem Tarihi.";

                    NewField11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 6, 128, 11, false);
                    NewField11312.Name = "NewField11312";
                    NewField11312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11312.TextFont.Bold = true;
                    NewField11312.TextFont.CharSet = 162;
                    NewField11312.Value = @"S.Kodu";

                    NewField11313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 6, 170, 11, false);
                    NewField11313.Name = "NewField11313";
                    NewField11313.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11313.TextFont.Bold = true;
                    NewField11313.TextFont.CharSet = 162;
                    NewField11313.Value = @"Durumu";

                    NewField11314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 6, 95, 11, false);
                    NewField11314.Name = "NewField11314";
                    NewField11314.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11314.TextFont.Bold = true;
                    NewField11314.TextFont.CharSet = 162;
                    NewField11314.Value = @"Muayene Tarihi";

                    NewField11315 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 6, 115, 11, false);
                    NewField11315.Name = "NewField11315";
                    NewField11315.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11315.TextFont.Bold = true;
                    NewField11315.TextFont.CharSet = 162;
                    NewField11315.Value = @"Referans Nu.";

                    NewField11316 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 6, 72, 11, false);
                    NewField11316.Name = "NewField11316";
                    NewField11316.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11316.TextFont.Bold = true;
                    NewField11316.TextFont.CharSet = 162;
                    NewField11316.Value = @"Vatandaşlık Nu.";

                    HEALTHFACILITYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 170, 5, false);
                    HEALTHFACILITYNAME.Name = "HEALTHFACILITYNAME";
                    HEALTHFACILITYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYNAME.Value = @"";

                    HEALTHFACILITYID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 16, 5, false);
                    HEALTHFACILITYID.Name = "HEALTHFACILITYID";
                    HEALTHFACILITYID.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHFACILITYID.Value = @"{#HEALTHFACILITYID#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 170, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 12, 170, 12, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MuayeneGiris.MUAYENEBILGILERIReportQuery_Class dataset_MUAYENEBILGILERIReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(0);
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11312.CalcValue = NewField11312.Value;
                    NewField11313.CalcValue = NewField11313.Value;
                    NewField11314.CalcValue = NewField11314.Value;
                    NewField11315.CalcValue = NewField11315.Value;
                    NewField11316.CalcValue = NewField11316.Value;
                    HEALTHFACILITYNAME.CalcValue = @"";
                    HEALTHFACILITYID.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.HealthFacilityID) : "");
                    return new TTReportObject[] { NewField1131,NewField11311,NewField11312,NewField11313,NewField11314,NewField11315,NewField11316,HEALTHFACILITYNAME,HEALTHFACILITYID};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (string.IsNullOrEmpty(HEALTHFACILITYID.CalcValue) == false && Globals.IsNumeric(HEALTHFACILITYID.CalcValue))
                    {
                        SaglikTesisi saglikTesisi = SaglikTesisi.GetSaglikTesisi(Convert.ToInt32(HEALTHFACILITYID.CalcValue));
                        if (saglikTesisi != null)
                            HEALTHFACILITYNAME.CalcValue = saglikTesisi.tesisAdi;
                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MUAYENEBILGILERI MyParentReport
                {
                    get { return (MUAYENEBILGILERI)ParentReport; }
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
                    MuayeneGiris.MUAYENEBILGILERIReportQuery_Class dataset_MUAYENEBILGILERIReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(0);
                    NewField161311.CalcValue = NewField161311.Value;
                    SUBGROUPCOUNTHASTAKABUL.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { NewField161311,SUBGROUPCOUNTHASTAKABUL};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MUAYENEBILGILERI MyParentReport
            {
                get { return (MUAYENEBILGILERI)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MEDULAACTIONID { get {return Body().MEDULAACTIONID;} }
            public TTReportField WORKLISTDATE { get {return Body().WORKLISTDATE;} }
            public TTReportField HASTATCKIMLIKNO { get {return Body().HASTATCKIMLIKNO;} }
            public TTReportField MUAYENETARIHI { get {return Body().MUAYENETARIHI;} }
            public TTReportField REFERANSNO { get {return Body().REFERANSNO;} }
            public TTReportField SONUCKODU { get {return Body().SONUCKODU;} }
            public TTReportField DURUMU { get {return Body().DURUMU;} }
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

                MuayeneGiris.MUAYENEBILGILERIReportQuery_Class dataSet_MUAYENEBILGILERIReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(0);    
                return new object[] {(dataSet_MUAYENEBILGILERIReportQuery==null ? null : dataSet_MUAYENEBILGILERIReportQuery.HealthFacilityID)};
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
                public MUAYENEBILGILERI MyParentReport
                {
                    get { return (MUAYENEBILGILERI)ParentReport; }
                }
                
                public TTReportField MEDULAACTIONID;
                public TTReportField WORKLISTDATE;
                public TTReportField HASTATCKIMLIKNO;
                public TTReportField MUAYENETARIHI;
                public TTReportField REFERANSNO;
                public TTReportField SONUCKODU;
                public TTReportField DURUMU; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MEDULAACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 21, 6, false);
                    MEDULAACTIONID.Name = "MEDULAACTIONID";
                    MEDULAACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDULAACTIONID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MEDULAACTIONID.Value = @"{#PARTA.MEDULAACTIONID#}";

                    WORKLISTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 47, 6, false);
                    WORKLISTDATE.Name = "WORKLISTDATE";
                    WORKLISTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKLISTDATE.TextFormat = @"Short Date";
                    WORKLISTDATE.Value = @"{#PARTA.WORKLISTDATE#}";

                    HASTATCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 1, 72, 6, false);
                    HASTATCKIMLIKNO.Name = "HASTATCKIMLIKNO";
                    HASTATCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCKIMLIKNO.Value = @"{#PARTA.HASTATCKIMLIKNO#}";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 1, 95, 6, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.Value = @"{#PARTA.MUAYENETARIHI#}";

                    REFERANSNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 1, 115, 6, false);
                    REFERANSNO.Name = "REFERANSNO";
                    REFERANSNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFERANSNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REFERANSNO.Value = @"{#PARTA.REFERANSNO#}";

                    SONUCKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 1, 128, 6, false);
                    SONUCKODU.Name = "SONUCKODU";
                    SONUCKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SONUCKODU.Value = @"{#PARTA.SONUCKODU#}";

                    DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 170, 6, false);
                    DURUMU.Name = "DURUMU";
                    DURUMU.TextFont.Size = 8;
                    DURUMU.TextFont.CharSet = 162;
                    DURUMU.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MuayeneGiris.MUAYENEBILGILERIReportQuery_Class dataset_MUAYENEBILGILERIReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(0);
                    MEDULAACTIONID.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.MedulaActionID) : "");
                    WORKLISTDATE.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.WorkListDate) : "");
                    HASTATCKIMLIKNO.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.hastaTCKimlikNo) : "");
                    MUAYENETARIHI.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.muayeneTarihi) : "");
                    REFERANSNO.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.referansNo) : "");
                    SONUCKODU.CalcValue = (dataset_MUAYENEBILGILERIReportQuery != null ? Globals.ToStringCore(dataset_MUAYENEBILGILERIReportQuery.sonucKodu) : "");
                    DURUMU.CalcValue = DURUMU.Value;
                    return new TTReportObject[] { MEDULAACTIONID,WORKLISTDATE,HASTATCKIMLIKNO,MUAYENETARIHI,REFERANSNO,SONUCKODU,DURUMU};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    MuayeneGiris.MUAYENEBILGILERIReportQuery_Class dataset_MUAYENEBILGILERIReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MuayeneGiris.MUAYENEBILGILERIReportQuery_Class>(0);
                    MuayeneGiris muayeneGiris = this.ParentReport.ReportObjectContext.GetObject(dataset_MUAYENEBILGILERIReportQuery.Muayenegirisobjectid.Value, typeof(MuayeneGiris)) as MuayeneGiris;
                    if (muayeneGiris != null)
                        DURUMU.CalcValue = muayeneGiris.MuayeneDurumu;
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

        public MUAYENEBILGILERI()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
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
            Name = "MUAYENEBILGILERI";
            Caption = "Muayene Bilgisi Kaydedilmiş Hastalar";
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