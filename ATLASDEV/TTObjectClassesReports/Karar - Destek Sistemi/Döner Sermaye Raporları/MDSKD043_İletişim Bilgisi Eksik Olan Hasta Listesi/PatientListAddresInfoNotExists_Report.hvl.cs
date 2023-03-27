
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
    /// İletişim Bilgisi Eksik Olan Hasta Listesi
    /// </summary>
    public partial class PatientListAddresInfoNotExists : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> RESOURCE = new List<string>();
            public int? RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public PatientListAddresInfoNotExists MyParentReport
            {
                get { return (PatientListAddresInfoNotExists)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 29, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 56, 7, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    ((PatientListAddresInfoNotExists)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((PatientListAddresInfoNotExists)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            if (((PatientListAddresInfoNotExists)ParentReport).RuntimeParameters.RESOURCE == null)
                ((PatientListAddresInfoNotExists)ParentReport).RuntimeParameters.RESOURCEFLAG = 0;
            else
                ((PatientListAddresInfoNotExists)ParentReport).RuntimeParameters.RESOURCEFLAG = 1;
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public PatientListAddresInfoNotExists MyParentReport
            {
                get { return (PatientListAddresInfoNotExists)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField111122111 { get {return Header().NewField111122111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1111221111 { get {return Header().NewField1111221111;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField NewField111211;
                public TTReportField STARTDATE;
                public TTReportField NewField1112111;
                public TTReportField NewField111122111;
                public TTReportField ENDDATE;
                public TTReportField NewField1111221111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 206, 22, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"İLETİŞİM BİLGİSİ EKSİK OLAN HASTA LİSTESİ";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 24, 32, 29, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 24, 87, 29, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 30, 32, 35, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Bitiş Tarihi";

                    NewField111122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 24, 34, 29, false);
                    NewField111122111.Name = "NewField111122111";
                    NewField111122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111122111.TextFont.Bold = true;
                    NewField111122111.TextFont.CharSet = 162;
                    NewField111122111.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 30, 87, 35, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1111221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 30, 34, 35, false);
                    NewField1111221111.Name = "NewField1111221111";
                    NewField1111221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111221111.TextFont.Bold = true;
                    NewField1111221111.TextFont.CharSet = 162;
                    NewField1111221111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField111122111.CalcValue = NewField111122111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1111221111.CalcValue = NewField1111221111.Value;
                    return new TTReportObject[] { NewField111111,NewField111211,STARTDATE,NewField1112111,NewField111122111,ENDDATE,NewField1111221111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 40, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 2, 141, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 206, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CURRENTUSER};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public PatientListAddresInfoNotExists MyParentReport
            {
                get { return (PatientListAddresInfoNotExists)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField RESOURCE { get {return Header().RESOURCE;} }
            public TTReportField SiraNo1 { get {return Header().SiraNo1;} }
            public TTReportField NewField11412111 { get {return Header().NewField11412111;} }
            public TTReportField NewField111121121 { get {return Header().NewField111121121;} }
            public TTReportField NewField1121121111 { get {return Header().NewField1121121111;} }
            public TTReportField VakaAcilisTarihi1 { get {return Header().VakaAcilisTarihi1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                list[0] = new TTReportNqlData<PatientAdmission.GetAdressInfoNotExists_Class>("GetAdressInfoNotExists", PatientAdmission.GetAdressInfoNotExists((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<string>) MyParentReport.RuntimeParameters.RESOURCE,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCEFLAG)));
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
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField NewField1;
                public TTReportField RESOURCE;
                public TTReportField SiraNo1;
                public TTReportField NewField11412111;
                public TTReportField NewField111121121;
                public TTReportField NewField1121121111;
                public TTReportField VakaAcilisTarihi1;
                public TTReportShape NewLine1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 33, 6, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 8;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Poliklinik / Klinik";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 1, 35, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @":";

                    RESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 206, 6, false);
                    RESOURCE.Name = "RESOURCE";
                    RESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCE.Value = @"{#DEPARTMENT#}";

                    SiraNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 34, 11, false);
                    SiraNo1.Name = "SiraNo1";
                    SiraNo1.TextFont.Bold = true;
                    SiraNo1.TextFont.CharSet = 162;
                    SiraNo1.Value = @"Sıra No";

                    NewField11412111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 7, 69, 11, false);
                    NewField11412111.Name = "NewField11412111";
                    NewField11412111.TextFont.Bold = true;
                    NewField11412111.TextFont.CharSet = 162;
                    NewField11412111.Value = @"TC Kimlik No";

                    NewField111121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 7, 139, 11, false);
                    NewField111121121.Name = "NewField111121121";
                    NewField111121121.TextFont.Bold = true;
                    NewField111121121.TextFont.CharSet = 162;
                    NewField111121121.Value = @"H.Protokol No";

                    NewField1121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 7, 103, 11, false);
                    NewField1121121111.Name = "NewField1121121111";
                    NewField1121121111.TextFont.Bold = true;
                    NewField1121121111.TextFont.CharSet = 162;
                    NewField1121121111.Value = @"Hasta Adı";

                    VakaAcilisTarihi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 7, 174, 11, false);
                    VakaAcilisTarihi1.Name = "VakaAcilisTarihi1";
                    VakaAcilisTarihi1.TextFont.Bold = true;
                    VakaAcilisTarihi1.TextFont.CharSet = 162;
                    VakaAcilisTarihi1.Value = @"Vaka Açılış Tarihi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 14, 206, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientAdmission.GetAdressInfoNotExists_Class dataset_GetAdressInfoNotExists = ParentGroup.rsGroup.GetCurrentRecord<PatientAdmission.GetAdressInfoNotExists_Class>(0);
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    RESOURCE.CalcValue = (dataset_GetAdressInfoNotExists != null ? Globals.ToStringCore(dataset_GetAdressInfoNotExists.Department) : "");
                    SiraNo1.CalcValue = SiraNo1.Value;
                    NewField11412111.CalcValue = NewField11412111.Value;
                    NewField111121121.CalcValue = NewField111121121.Value;
                    NewField1121121111.CalcValue = NewField1121121111.Value;
                    VakaAcilisTarihi1.CalcValue = VakaAcilisTarihi1.Value;
                    return new TTReportObject[] { NewField111111,NewField1,RESOURCE,SiraNo1,NewField11412111,NewField111121121,NewField1121121111,VakaAcilisTarihi1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientListAddresInfoNotExists MyParentReport
            {
                get { return (PatientListAddresInfoNotExists)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HASTA { get {return Body().HASTA;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField VAKATARIHI { get {return Body().VAKATARIHI;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
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

                PatientAdmission.GetAdressInfoNotExists_Class dataSet_GetAdressInfoNotExists = ParentGroup.rsGroup.GetCurrentRecord<PatientAdmission.GetAdressInfoNotExists_Class>(0);    
                return new object[] {(dataSet_GetAdressInfoNotExists==null ? null : dataSet_GetAdressInfoNotExists.Department)};
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
                public PatientListAddresInfoNotExists MyParentReport
                {
                    get { return (PatientListAddresInfoNotExists)ParentReport; }
                }
                
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTA;
                public TTReportField HPROTOKOLNO;
                public TTReportField VAKATARIHI;
                public TTReportField SIRANO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 69, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.Value = @"{#PARTA.UNIQUEREFNO#}";

                    HASTA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 1, 103, 6, false);
                    HASTA.Name = "HASTA";
                    HASTA.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTA.Value = @"{#PARTA.NAME#} {#PARTA.SURNAME#}";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 1, 139, 6, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.Value = @"{#PARTA.HOSPITALPROTOCOLNO#}";

                    VAKATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 174, 6, false);
                    VAKATARIHI.Name = "VAKATARIHI";
                    VAKATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    VAKATARIHI.TextFormat = @"Short Date";
                    VAKATARIHI.Value = @"{#PARTA.OPENINGDATE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 34, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientAdmission.GetAdressInfoNotExists_Class dataset_GetAdressInfoNotExists = MyParentReport.PARTA.rsGroup.GetCurrentRecord<PatientAdmission.GetAdressInfoNotExists_Class>(0);
                    TCKIMLIKNO.CalcValue = (dataset_GetAdressInfoNotExists != null ? Globals.ToStringCore(dataset_GetAdressInfoNotExists.UniqueRefNo) : "");
                    HASTA.CalcValue = (dataset_GetAdressInfoNotExists != null ? Globals.ToStringCore(dataset_GetAdressInfoNotExists.Name) : "") + @" " + (dataset_GetAdressInfoNotExists != null ? Globals.ToStringCore(dataset_GetAdressInfoNotExists.Surname) : "");
                    HPROTOKOLNO.CalcValue = (dataset_GetAdressInfoNotExists != null ? Globals.ToStringCore(dataset_GetAdressInfoNotExists.HospitalProtocolNo) : "");
                    VAKATARIHI.CalcValue = (dataset_GetAdressInfoNotExists != null ? Globals.ToStringCore(dataset_GetAdressInfoNotExists.OpeningDate) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { TCKIMLIKNO,HASTA,HPROTOKOLNO,VAKATARIHI,SIRANO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PatientListAddresInfoNotExists()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("RESOURCE", "", "Poliklinik /Klinik", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("1b976b6f-6d6c-473a-8e77-8b3d83b204ff");
            reportParameter = Parameters.Add("RESOURCEFLAG", "", "Poliklinik /Klinik Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (List<string>)parameters["RESOURCE"];
            if (parameters.ContainsKey("RESOURCEFLAG"))
                _runtimeParameters.RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESOURCEFLAG"]);
            Name = "PATIENTLISTADDRESINFONOTEXISTS";
            Caption = "İletişim Bilgisi Eksik Olan Hasta Listesi";
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