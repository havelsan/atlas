
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
    /// Klinikteki Boş Yatak Listesi
    /// </summary>
    public partial class EmptyBedsByClinicReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string WARD = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public EmptyBedsByClinicReport MyParentReport
            {
                get { return (EmptyBedsByClinicReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField REPORTHEADER { get {return Header().REPORTHEADER;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField REPORTHEADER;
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1191;
                public TTReportField NewField11811;
                public TTReportField RDATE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 31, 165, 38, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.TextFont.Size = 15;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.TextFont.CharSet = 162;
                    REPORTHEADER.Value = @"KLİNİKTEKİ BOŞ YATAK LİSTESİ";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 33, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"Logo";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 9, 190, 31, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 33, 184, 38, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Tarih";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 33, 187, 38, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @":";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 33, 203, 38, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTHEADER.CalcValue = REPORTHEADER.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { REPORTHEADER,LOGO,NewField1191,NewField11811,RDATE,XXXXXXBASLIK};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 3, 206, 3, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 9, 206, 14, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 4, 206, 9, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 4, 112, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate,PageNumber,UserName};
                }
            }

        }

        public HeaderGroup Header;

        public partial class ClinicBodyGroup : TTReportGroup
        {
            public EmptyBedsByClinicReport MyParentReport
            {
                get { return (EmptyBedsByClinicReport)ParentReport; }
            }

            new public ClinicBodyGroupHeader Header()
            {
                return (ClinicBodyGroupHeader)_header;
            }

            new public ClinicBodyGroupFooter Footer()
            {
                return (ClinicBodyGroupFooter)_footer;
            }

            public TTReportField lableCLINIC1111 { get {return Header().lableCLINIC1111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField lableROOM121 { get {return Header().lableROOM121;} }
            public TTReportField CLINIC { get {return Header().CLINIC;} }
            public TTReportField TOTALBYCLINIC { get {return Footer().TOTALBYCLINIC;} }
            public TTReportField lableTOTALBYCLINIC { get {return Footer().lableTOTALBYCLINIC;} }
            public TTReportField lableROOM2 { get {return Footer().lableROOM2;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public ClinicBodyGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ClinicBodyGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ResBed.GetEmptyBedsByClinic_Class>("GetEmptyBedsByClinic", ResBed.GetEmptyBedsByClinic((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.WARD)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ClinicBodyGroupHeader(this);
                _footer = new ClinicBodyGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ClinicBodyGroupHeader : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField lableCLINIC1111;
                public TTReportShape NewLine1;
                public TTReportField lableROOM121;
                public TTReportField CLINIC; 
                public ClinicBodyGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lableCLINIC1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 3, 32, 9, false);
                    lableCLINIC1111.Name = "lableCLINIC1111";
                    lableCLINIC1111.Visible = EvetHayirEnum.ehHayir;
                    lableCLINIC1111.TextFont.Size = 11;
                    lableCLINIC1111.TextFont.Bold = true;
                    lableCLINIC1111.TextFont.CharSet = 162;
                    lableCLINIC1111.Value = @"Klinik";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 10, 190, 10, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    lableROOM121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 3, 35, 9, false);
                    lableROOM121.Name = "lableROOM121";
                    lableROOM121.Visible = EvetHayirEnum.ehHayir;
                    lableROOM121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableROOM121.TextFont.Size = 11;
                    lableROOM121.TextFont.Bold = true;
                    lableROOM121.TextFont.CharSet = 162;
                    lableROOM121.Value = @":";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 190, 9, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINIC.TextFont.Size = 11;
                    CLINIC.TextFont.Bold = true;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"{#CLINIC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetEmptyBedsByClinic_Class dataset_GetEmptyBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);
                    lableCLINIC1111.CalcValue = lableCLINIC1111.Value;
                    lableROOM121.CalcValue = lableROOM121.Value;
                    CLINIC.CalcValue = (dataset_GetEmptyBedsByClinic != null ? Globals.ToStringCore(dataset_GetEmptyBedsByClinic.Clinic) : "");
                    return new TTReportObject[] { lableCLINIC1111,lableROOM121,CLINIC};
                }
            }
            public partial class ClinicBodyGroupFooter : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField TOTALBYCLINIC;
                public TTReportField lableTOTALBYCLINIC;
                public TTReportField lableROOM2;
                public TTReportShape NewLine2; 
                public ClinicBodyGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALBYCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 1, 190, 7, false);
                    TOTALBYCLINIC.Name = "TOTALBYCLINIC";
                    TOTALBYCLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALBYCLINIC.Value = @"{@sumof(TOTALBYROOMGROUP)@}";

                    lableTOTALBYCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 79, 7, false);
                    lableTOTALBYCLINIC.Name = "lableTOTALBYCLINIC";
                    lableTOTALBYCLINIC.TextFont.Bold = true;
                    lableTOTALBYCLINIC.TextFont.CharSet = 162;
                    lableTOTALBYCLINIC.Value = @"Klinikde Toplam Boş Yatak Sayısı";

                    lableROOM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 83, 7, false);
                    lableROOM2.Name = "lableROOM2";
                    lableROOM2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableROOM2.TextFont.Bold = true;
                    lableROOM2.TextFont.CharSet = 162;
                    lableROOM2.Value = @":";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 8, 190, 8, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetEmptyBedsByClinic_Class dataset_GetEmptyBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);
                    TOTALBYCLINIC.CalcValue = ParentGroup.FieldSums["TOTALBYROOMGROUP"].Value.ToString();;
                    lableTOTALBYCLINIC.CalcValue = lableTOTALBYCLINIC.Value;
                    lableROOM2.CalcValue = lableROOM2.Value;
                    return new TTReportObject[] { TOTALBYCLINIC,lableTOTALBYCLINIC,lableROOM2};
                }
            }

        }

        public ClinicBodyGroup ClinicBody;

        public partial class RoomGroupBodyGroup : TTReportGroup
        {
            public EmptyBedsByClinicReport MyParentReport
            {
                get { return (EmptyBedsByClinicReport)ParentReport; }
            }

            new public RoomGroupBodyGroupHeader Header()
            {
                return (RoomGroupBodyGroupHeader)_header;
            }

            new public RoomGroupBodyGroupFooter Footer()
            {
                return (RoomGroupBodyGroupFooter)_footer;
            }

            public TTReportField ROOMGROUP { get {return Header().ROOMGROUP;} }
            public TTReportField lableROOMGROUP11 { get {return Header().lableROOMGROUP11;} }
            public TTReportField lableROOM111 { get {return Header().lableROOM111;} }
            public TTReportField lableBED111 { get {return Header().lableBED111;} }
            public TTReportField TOTALBYROOMGROUP { get {return Footer().TOTALBYROOMGROUP;} }
            public TTReportField lableROOM13 { get {return Footer().lableROOM13;} }
            public TTReportField lableTOTALBYROOM1 { get {return Footer().lableTOTALBYROOM1;} }
            public RoomGroupBodyGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RoomGroupBodyGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                ResBed.GetEmptyBedsByClinic_Class dataSet_GetEmptyBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);    
                return new object[] {(dataSet_GetEmptyBedsByClinic==null ? null : dataSet_GetEmptyBedsByClinic.Clinic)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new RoomGroupBodyGroupHeader(this);
                _footer = new RoomGroupBodyGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class RoomGroupBodyGroupHeader : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField ROOMGROUP;
                public TTReportField lableROOMGROUP11;
                public TTReportField lableROOM111;
                public TTReportField lableBED111; 
                public RoomGroupBodyGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ROOMGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 190, 7, false);
                    ROOMGROUP.Name = "ROOMGROUP";
                    ROOMGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROOMGROUP.Value = @"{#ClinicBody.ROOMGROUP#}";

                    lableROOMGROUP11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 38, 7, false);
                    lableROOMGROUP11.Name = "lableROOMGROUP11";
                    lableROOMGROUP11.TextFont.Bold = true;
                    lableROOMGROUP11.TextFont.CharSet = 162;
                    lableROOMGROUP11.Value = @"Oda Grup";

                    lableROOM111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 8, 70, 14, false);
                    lableROOM111.Name = "lableROOM111";
                    lableROOM111.TextFont.Bold = true;
                    lableROOM111.TextFont.CharSet = 162;
                    lableROOM111.Value = @"Oda";

                    lableBED111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 8, 190, 14, false);
                    lableBED111.Name = "lableBED111";
                    lableBED111.TextFont.Bold = true;
                    lableBED111.TextFont.CharSet = 162;
                    lableBED111.Value = @"Yatak";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetEmptyBedsByClinic_Class dataset_GetEmptyBedsByClinic = MyParentReport.ClinicBody.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);
                    ROOMGROUP.CalcValue = (dataset_GetEmptyBedsByClinic != null ? Globals.ToStringCore(dataset_GetEmptyBedsByClinic.Roomgroup) : "");
                    lableROOMGROUP11.CalcValue = lableROOMGROUP11.Value;
                    lableROOM111.CalcValue = lableROOM111.Value;
                    lableBED111.CalcValue = lableBED111.Value;
                    return new TTReportObject[] { ROOMGROUP,lableROOMGROUP11,lableROOM111,lableBED111};
                }
            }
            public partial class RoomGroupBodyGroupFooter : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField TOTALBYROOMGROUP;
                public TTReportField lableROOM13;
                public TTReportField lableTOTALBYROOM1; 
                public RoomGroupBodyGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALBYROOMGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 1, 190, 7, false);
                    TOTALBYROOMGROUP.Name = "TOTALBYROOMGROUP";
                    TOTALBYROOMGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALBYROOMGROUP.Value = @"{@subgroupcount@}";

                    lableROOM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 83, 7, false);
                    lableROOM13.Name = "lableROOM13";
                    lableROOM13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableROOM13.TextFont.Bold = true;
                    lableROOM13.TextFont.CharSet = 162;
                    lableROOM13.Value = @":";

                    lableTOTALBYROOM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 79, 7, false);
                    lableTOTALBYROOM1.Name = "lableTOTALBYROOM1";
                    lableTOTALBYROOM1.TextFont.Bold = true;
                    lableTOTALBYROOM1.TextFont.CharSet = 162;
                    lableTOTALBYROOM1.Value = @"Oda Grupda Toplam Boş Yatak Sayısı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetEmptyBedsByClinic_Class dataset_GetEmptyBedsByClinic = MyParentReport.ClinicBody.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);
                    TOTALBYROOMGROUP.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    lableROOM13.CalcValue = lableROOM13.Value;
                    lableTOTALBYROOM1.CalcValue = lableTOTALBYROOM1.Value;
                    return new TTReportObject[] { TOTALBYROOMGROUP,lableROOM13,lableTOTALBYROOM1};
                }
            }

        }

        public RoomGroupBodyGroup RoomGroupBody;

        public partial class RoomBodyGroup : TTReportGroup
        {
            public EmptyBedsByClinicReport MyParentReport
            {
                get { return (EmptyBedsByClinicReport)ParentReport; }
            }

            new public RoomBodyGroupHeader Header()
            {
                return (RoomBodyGroupHeader)_header;
            }

            new public RoomBodyGroupFooter Footer()
            {
                return (RoomBodyGroupFooter)_footer;
            }

            public TTReportField ROOM { get {return Header().ROOM;} }
            public TTReportField BED { get {return Header().BED;} }
            public TTReportField TOTALBYROOM { get {return Footer().TOTALBYROOM;} }
            public TTReportField lableTOTALBYROOM { get {return Footer().lableTOTALBYROOM;} }
            public TTReportField lableROOM12 { get {return Footer().lableROOM12;} }
            public RoomBodyGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RoomBodyGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                ResBed.GetEmptyBedsByClinic_Class dataSet_GetEmptyBedsByClinic = ParentGroup.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);    
                return new object[] {(dataSet_GetEmptyBedsByClinic==null ? null : dataSet_GetEmptyBedsByClinic.Clinic), (dataSet_GetEmptyBedsByClinic==null ? null : dataSet_GetEmptyBedsByClinic.Roomgroup)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new RoomBodyGroupHeader(this);
                _footer = new RoomBodyGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class RoomBodyGroupHeader : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField ROOM;
                public TTReportField BED; 
                public RoomBodyGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ROOM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 70, 6, false);
                    ROOM.Name = "ROOM";
                    ROOM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ROOM.Value = @"{#ClinicBody.ROOM#}";

                    BED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 1, 190, 6, false);
                    BED.Name = "BED";
                    BED.FieldType = ReportFieldTypeEnum.ftVariable;
                    BED.Value = @"{#ClinicBody.BED#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetEmptyBedsByClinic_Class dataset_GetEmptyBedsByClinic = MyParentReport.ClinicBody.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);
                    ROOM.CalcValue = (dataset_GetEmptyBedsByClinic != null ? Globals.ToStringCore(dataset_GetEmptyBedsByClinic.Room) : "");
                    BED.CalcValue = (dataset_GetEmptyBedsByClinic != null ? Globals.ToStringCore(dataset_GetEmptyBedsByClinic.Bed) : "");
                    return new TTReportObject[] { ROOM,BED};
                }
            }
            public partial class RoomBodyGroupFooter : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                
                public TTReportField TOTALBYROOM;
                public TTReportField lableTOTALBYROOM;
                public TTReportField lableROOM12; 
                public RoomBodyGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALBYROOM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 1, 185, 7, false);
                    TOTALBYROOM.Name = "TOTALBYROOM";
                    TOTALBYROOM.Visible = EvetHayirEnum.ehHayir;
                    TOTALBYROOM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALBYROOM.Value = @"{@subgroupcount@}";

                    lableTOTALBYROOM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 79, 7, false);
                    lableTOTALBYROOM.Name = "lableTOTALBYROOM";
                    lableTOTALBYROOM.Visible = EvetHayirEnum.ehHayir;
                    lableTOTALBYROOM.TextFont.Size = 11;
                    lableTOTALBYROOM.TextFont.Bold = true;
                    lableTOTALBYROOM.TextFont.CharSet = 162;
                    lableTOTALBYROOM.Value = @"Odada Toplam Boş Yatak Sayısı";

                    lableROOM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 83, 7, false);
                    lableROOM12.Name = "lableROOM12";
                    lableROOM12.Visible = EvetHayirEnum.ehHayir;
                    lableROOM12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lableROOM12.TextFont.Size = 11;
                    lableROOM12.TextFont.Bold = true;
                    lableROOM12.TextFont.CharSet = 162;
                    lableROOM12.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ResBed.GetEmptyBedsByClinic_Class dataset_GetEmptyBedsByClinic = MyParentReport.ClinicBody.rsGroup.GetCurrentRecord<ResBed.GetEmptyBedsByClinic_Class>(0);
                    TOTALBYROOM.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    lableTOTALBYROOM.CalcValue = lableTOTALBYROOM.Value;
                    lableROOM12.CalcValue = lableROOM12.Value;
                    return new TTReportObject[] { TOTALBYROOM,lableTOTALBYROOM,lableROOM12};
                }
            }

        }

        public RoomBodyGroup RoomBody;

        public partial class MAINGroup : TTReportGroup
        {
            public EmptyBedsByClinicReport MyParentReport
            {
                get { return (EmptyBedsByClinicReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public EmptyBedsByClinicReport MyParentReport
                {
                    get { return (EmptyBedsByClinicReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EmptyBedsByClinicReport()
        {
            Header = new HeaderGroup(this,"Header");
            ClinicBody = new ClinicBodyGroup(Header,"ClinicBody");
            RoomGroupBody = new RoomGroupBodyGroup(ClinicBody,"RoomGroupBody");
            RoomBody = new RoomBodyGroup(RoomGroupBody,"RoomBody");
            MAIN = new MAINGroup(RoomBody,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("WARD", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("WARD"))
                _runtimeParameters.WARD = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["WARD"]);
            Name = "EMPTYBEDSBYCLINICREPORT";
            Caption = "Klinikteki Boş Yatak Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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