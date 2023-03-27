
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
    /// Dilim Bilgisine Göre Sağlık Kurulu İstatistikleri
    /// </summary>
    public partial class HealthCommitteeStatisticsBySlice : TTReport
    {
#region Methods
   public int sliceA = 0;
        public int sliceB = 0;
        public int sliceC = 0;
        public int sliceD = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public SliceEnum? SLICE = (SliceEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SliceEnum"].ConvertValue("");
            public int? SLICEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? SLICEORDER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public HealthCommitteeStatisticsBySlice MyParentReport
            {
                get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
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
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 30, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 1, 56, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
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
                    ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            if(((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICE == null)
            {
                ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEFLAG = 0;
                ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEORDER = -1;
            }
            else 
            {
                switch(((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICE)
                {
                    case SliceEnum.A:
                        ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEORDER = 0;
                        break;
                        case SliceEnum.B:
                        ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEORDER = 1;
                        break;
                        case SliceEnum.C:
                        ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEORDER = 2;
                        break;
                        case SliceEnum.D:
                        ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEORDER = 3;
                        break;
                }
                
                ((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICEFLAG = 1;
            }
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                
                public TTReportShape NewLine111111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 1, 204, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 139, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 204, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 2, 36, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public HealthCommitteeStatisticsBySlice MyParentReport
            {
                get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField SLICE { get {return Header().SLICE;} }
            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public TTReportField NewFieldb1 { get {return Header().NewFieldb1;} }
            public TTReportField NewFielda1 { get {return Header().NewFielda1;} }
            public TTReportField NewFieldc1 { get {return Header().NewFieldc1;} }
            public TTReportField Karar { get {return Header().Karar;} }
            public TTReportField NewFieldc11 { get {return Header().NewFieldc11;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField NewFieldc111 { get {return Header().NewFieldc111;} }
            public TTReportField NewFieldc12 { get {return Header().NewFieldc12;} }
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
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1211;
                public TTReportField NewField1121;
                public TTReportField STARTDATE;
                public TTReportField NewField11111;
                public TTReportField ENDDATE;
                public TTReportField NewField111111;
                public TTReportField SLICE;
                public TTReportField NewField113211;
                public TTReportField NewFieldb1;
                public TTReportField NewFielda1;
                public TTReportField NewFieldc1;
                public TTReportField Karar;
                public TTReportField NewFieldc11;
                public TTReportShape NewLine11111;
                public TTReportField NewField11211;
                public TTReportField NewField11212;
                public TTReportField NewFieldc111;
                public TTReportField NewFieldc12; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 16, 204, 21, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"DİLİM BİLGİSİNE GÖRE SAĞLIK KURULU İSTATİSTİĞİ";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 25, 29, 30, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Başlangıç Tarihi";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 25, 31, 30, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 25, 65, 30, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 31, 29, 36, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 31, 65, 36, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 37, 29, 42, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Dilim";

                    SLICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 37, 65, 42, false);
                    SLICE.Name = "SLICE";
                    SLICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SLICE.ObjectDefName = "SliceEnum";
                    SLICE.DataMember = "DISPLAYTEXT";
                    SLICE.TextFont.CharSet = 162;
                    SLICE.Value = @"{@SLICE@}";

                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 43, 19, 47, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"Sıra No";

                    NewFieldb1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 43, 88, 47, false);
                    NewFieldb1.Name = "NewFieldb1";
                    NewFieldb1.TextFont.Bold = true;
                    NewFieldb1.TextFont.CharSet = 162;
                    NewFieldb1.Value = @"Hasta Adı";

                    NewFielda1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 43, 45, 47, false);
                    NewFielda1.Name = "NewFielda1";
                    NewFielda1.TextFont.Bold = true;
                    NewFielda1.TextFont.CharSet = 162;
                    NewFielda1.Value = @"TC Kimlik No";

                    NewFieldc1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 43, 139, 47, false);
                    NewFieldc1.Name = "NewFieldc1";
                    NewFieldc1.TextFont.Bold = true;
                    NewFieldc1.TextFont.CharSet = 162;
                    NewFieldc1.Value = @"H.Protokol No";

                    Karar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 43, 204, 47, false);
                    Karar.Name = "Karar";
                    Karar.TextFont.Bold = true;
                    Karar.TextFont.CharSet = 162;
                    Karar.Value = @"Madde/Dilim/Fıkra";

                    NewFieldc11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 43, 159, 47, false);
                    NewFieldc11.Name = "NewFieldc11";
                    NewFieldc11.TextFont.Bold = true;
                    NewFieldc11.TextFont.CharSet = 162;
                    NewFieldc11.Value = @"Rapor Tarihi";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 48, 204, 48, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 31, 31, 36, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 37, 31, 42, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @":";

                    NewFieldc111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 43, 177, 47, false);
                    NewFieldc111.Name = "NewFieldc111";
                    NewFieldc111.TextFont.Bold = true;
                    NewFieldc111.TextFont.CharSet = 162;
                    NewFieldc111.Value = @"Rapor No";

                    NewFieldc12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 43, 113, 47, false);
                    NewFieldc12.Name = "NewFieldc12";
                    NewFieldc12.TextFont.Bold = true;
                    NewFieldc12.TextFont.CharSet = 162;
                    NewFieldc12.Value = @"Rütbe";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11111.CalcValue = NewField11111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField111111.CalcValue = NewField111111.Value;
                    SLICE.CalcValue = MyParentReport.RuntimeParameters.SLICE.ToString();
                    SLICE.PostFieldValueCalculation();
                    NewField113211.CalcValue = NewField113211.Value;
                    NewFieldb1.CalcValue = NewFieldb1.Value;
                    NewFielda1.CalcValue = NewFielda1.Value;
                    NewFieldc1.CalcValue = NewFieldc1.Value;
                    Karar.CalcValue = Karar.Value;
                    NewFieldc11.CalcValue = NewFieldc11.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewFieldc111.CalcValue = NewFieldc111.Value;
                    NewFieldc12.CalcValue = NewFieldc12.Value;
                    return new TTReportObject[] { NewField1111,NewField1211,NewField1121,STARTDATE,NewField11111,ENDDATE,NewField111111,SLICE,NewField113211,NewFieldb1,NewFielda1,NewFieldc1,Karar,NewFieldc11,NewField11211,NewField11212,NewFieldc111,NewFieldc12};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if(((HealthCommitteeStatisticsBySlice)ParentReport).RuntimeParameters.SLICE == null)
                this.SLICE.CalcValue = "Hepsi";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeStatisticsBySlice MyParentReport
            {
                get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewFieldc111 { get {return Footer().NewFieldc111;} }
            public TTReportField SLICEA { get {return Footer().SLICEA;} }
            public TTReportField A { get {return Footer().A;} }
            public TTReportField A1 { get {return Footer().A1;} }
            public TTReportField SLICEB { get {return Footer().SLICEB;} }
            public TTReportField A2 { get {return Footer().A2;} }
            public TTReportField A11 { get {return Footer().A11;} }
            public TTReportField SLICEC { get {return Footer().SLICEC;} }
            public TTReportField A3 { get {return Footer().A3;} }
            public TTReportField A12 { get {return Footer().A12;} }
            public TTReportField SLICED { get {return Footer().SLICED;} }
            public TTReportField A4 { get {return Footer().A4;} }
            public TTReportField A13 { get {return Footer().A13;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                
                public TTReportField NewFieldc111;
                public TTReportField SLICEA;
                public TTReportField A;
                public TTReportField A1;
                public TTReportField SLICEB;
                public TTReportField A2;
                public TTReportField A11;
                public TTReportField SLICEC;
                public TTReportField A3;
                public TTReportField A12;
                public TTReportField SLICED;
                public TTReportField A4;
                public TTReportField A13;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewFieldc111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 9, 163, 13, false);
                    NewFieldc111.Name = "NewFieldc111";
                    NewFieldc111.TextFont.Bold = true;
                    NewFieldc111.TextFont.CharSet = 162;
                    NewFieldc111.Value = @"Toplam";

                    SLICEA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 9, 182, 13, false);
                    SLICEA.Name = "SLICEA";
                    SLICEA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SLICEA.TextFont.CharSet = 162;
                    SLICEA.Value = @"";

                    A = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 9, 168, 13, false);
                    A.Name = "A";
                    A.TextFont.Bold = true;
                    A.TextFont.CharSet = 162;
                    A.Value = @"A";

                    A1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 9, 170, 13, false);
                    A1.Name = "A1";
                    A1.TextFont.Bold = true;
                    A1.TextFont.CharSet = 162;
                    A1.Value = @":";

                    SLICEB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 9, 204, 13, false);
                    SLICEB.Name = "SLICEB";
                    SLICEB.FieldType = ReportFieldTypeEnum.ftVariable;
                    SLICEB.TextFont.CharSet = 162;
                    SLICEB.Value = @"";

                    A2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 9, 190, 13, false);
                    A2.Name = "A2";
                    A2.TextFont.Bold = true;
                    A2.TextFont.CharSet = 162;
                    A2.Value = @"B";

                    A11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 9, 192, 13, false);
                    A11.Name = "A11";
                    A11.TextFont.Bold = true;
                    A11.TextFont.CharSet = 162;
                    A11.Value = @":";

                    SLICEC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 14, 182, 18, false);
                    SLICEC.Name = "SLICEC";
                    SLICEC.FieldType = ReportFieldTypeEnum.ftVariable;
                    SLICEC.TextFont.CharSet = 162;
                    SLICEC.Value = @"";

                    A3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 14, 168, 18, false);
                    A3.Name = "A3";
                    A3.TextFont.Bold = true;
                    A3.TextFont.CharSet = 162;
                    A3.Value = @"C";

                    A12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 14, 170, 18, false);
                    A12.Name = "A12";
                    A12.TextFont.Bold = true;
                    A12.TextFont.CharSet = 162;
                    A12.Value = @":";

                    SLICED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 14, 204, 18, false);
                    SLICED.Name = "SLICED";
                    SLICED.FieldType = ReportFieldTypeEnum.ftVariable;
                    SLICED.TextFont.CharSet = 162;
                    SLICED.Value = @"";

                    A4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 14, 190, 18, false);
                    A4.Name = "A4";
                    A4.TextFont.Bold = true;
                    A4.TextFont.CharSet = 162;
                    A4.Value = @"D";

                    A13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 14, 192, 18, false);
                    A13.Name = "A13";
                    A13.TextFont.Bold = true;
                    A13.TextFont.CharSet = 162;
                    A13.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 139, 14, 204, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 165, 19, 204, 19, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewFieldc111.CalcValue = NewFieldc111.Value;
                    SLICEA.CalcValue = @"";
                    A.CalcValue = A.Value;
                    A1.CalcValue = A1.Value;
                    SLICEB.CalcValue = @"";
                    A2.CalcValue = A2.Value;
                    A11.CalcValue = A11.Value;
                    SLICEC.CalcValue = @"";
                    A3.CalcValue = A3.Value;
                    A12.CalcValue = A12.Value;
                    SLICED.CalcValue = @"";
                    A4.CalcValue = A4.Value;
                    A13.CalcValue = A13.Value;
                    return new TTReportObject[] { NewFieldc111,SLICEA,A,A1,SLICEB,A2,A11,SLICEC,A3,A12,SLICED,A4,A13};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    SLICEA.CalcValue = "" + ((HealthCommitteeStatisticsBySlice)ParentReport).sliceA;
            SLICEB.CalcValue = "" + ((HealthCommitteeStatisticsBySlice)ParentReport).sliceB;
            SLICEC.CalcValue = "" + ((HealthCommitteeStatisticsBySlice)ParentReport).sliceC;
            SLICED.CalcValue = "" + ((HealthCommitteeStatisticsBySlice)ParentReport).sliceD;
            ((HealthCommitteeStatisticsBySlice)ParentReport).sliceA = 0;
            ((HealthCommitteeStatisticsBySlice)ParentReport).sliceB = 0;
            ((HealthCommitteeStatisticsBySlice)ParentReport).sliceC = 0;
            ((HealthCommitteeStatisticsBySlice)ParentReport).sliceD = 0;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeStatisticsBySlice MyParentReport
            {
                get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField MADDEDILIMFIKRA { get {return Body().MADDEDILIMFIKRA;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField DILIM { get {return Body().DILIM;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField FIKRA { get {return Body().FIKRA;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetHcBySlice_Class>("GetHcBySlice2", HealthCommittee.GetHcBySlice((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.SLICEORDER),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.SLICEFLAG)));
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
                public HealthCommitteeStatisticsBySlice MyParentReport
                {
                    get { return (HealthCommitteeStatisticsBySlice)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAADI;
                public TTReportField PROTOKOLNO;
                public TTReportField RAPORNO;
                public TTReportField MADDEDILIMFIKRA;
                public TTReportField MADDE;
                public TTReportField DILIM;
                public TTReportField TARIH;
                public TTReportField FIKRA;
                public TTReportField RUTBE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 19, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 45, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 88, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#NAME#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 1, 139, 5, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 177, 5, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.NoClip = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    MADDEDILIMFIKRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 1, 204, 5, false);
                    MADDEDILIMFIKRA.Name = "MADDEDILIMFIKRA";
                    MADDEDILIMFIKRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEDILIMFIKRA.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEDILIMFIKRA.NoClip = EvetHayirEnum.ehEvet;
                    MADDEDILIMFIKRA.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEDILIMFIKRA.ExpandTabs = EvetHayirEnum.ehEvet;
                    MADDEDILIMFIKRA.TextFont.CharSet = 162;
                    MADDEDILIMFIKRA.Value = @"[{%MADDE%}/{%DILIM%}/{%FIKRA%}]";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 1, 233, 5, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.MultiLine = EvetHayirEnum.ehEvet;
                    MADDE.NoClip = EvetHayirEnum.ehEvet;
                    MADDE.WordBreak = EvetHayirEnum.ehEvet;
                    MADDE.ExpandTabs = EvetHayirEnum.ehEvet;
                    MADDE.TextFont.Name = "Arial";
                    MADDE.TextFont.Size = 8;
                    MADDE.TextFont.CharSet = 162;
                    MADDE.Value = @"{#MATTER#}";

                    DILIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 1, 254, 5, false);
                    DILIM.Name = "DILIM";
                    DILIM.Visible = EvetHayirEnum.ehHayir;
                    DILIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DILIM.MultiLine = EvetHayirEnum.ehEvet;
                    DILIM.NoClip = EvetHayirEnum.ehEvet;
                    DILIM.WordBreak = EvetHayirEnum.ehEvet;
                    DILIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    DILIM.ObjectDefName = "SliceEnum";
                    DILIM.DataMember = "DISPLAYTEXT";
                    DILIM.TextFont.Name = "Arial";
                    DILIM.TextFont.Size = 8;
                    DILIM.TextFont.CharSet = 162;
                    DILIM.Value = @"{#SLICE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 1, 159, 5, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#REPORTDATE#}";

                    FIKRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 1, 280, 6, false);
                    FIKRA.Name = "FIKRA";
                    FIKRA.Visible = EvetHayirEnum.ehHayir;
                    FIKRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIKRA.Value = @"{#ANECTODE#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 113, 5, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBE.NoClip = EvetHayirEnum.ehEvet;
                    RUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    RUTBE.ExpandTabs = EvetHayirEnum.ehEvet;
                    RUTBE.TextFont.CharSet = 162;
                    RUTBE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHcBySlice_Class dataset_GetHcBySlice2 = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHcBySlice_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TCKIMLIKNO.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.UniqueRefNo) : "");
                    HASTAADI.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.Name) : "");
                    PROTOKOLNO.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.HospitalProtocolNo) : "");
                    RAPORNO.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.ReportNo) : "");
                    MADDE.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.Matter) : "");
                    DILIM.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.Slice) : "");
                    DILIM.PostFieldValueCalculation();
                    FIKRA.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.Anectode) : "");
                    MADDEDILIMFIKRA.CalcValue = @"[" + MyParentReport.MAIN.MADDE.CalcValue + @"/" + MyParentReport.MAIN.DILIM.CalcValue + @"/" + MyParentReport.MAIN.FIKRA.CalcValue + @"]";
                    TARIH.CalcValue = (dataset_GetHcBySlice2 != null ? Globals.ToStringCore(dataset_GetHcBySlice2.ReportDate) : "");
                    RUTBE.CalcValue = @"";
                    return new TTReportObject[] { SIRANO,TCKIMLIKNO,HASTAADI,PROTOKOLNO,RAPORNO,MADDE,DILIM,FIKRA,MADDEDILIMFIKRA,TARIH,RUTBE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string dilim = DILIM.CalcValue;
            switch(dilim)
            {
                case "A":
                    ((HealthCommitteeStatisticsBySlice)ParentReport).sliceA++;
                    break;
                case "B":
                    ((HealthCommitteeStatisticsBySlice)ParentReport).sliceB++;
                    break;
                case "C":
                    ((HealthCommitteeStatisticsBySlice)ParentReport).sliceC++;
                    break;
                case "D":
                    ((HealthCommitteeStatisticsBySlice)ParentReport).sliceD++;
                    break;
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

        public HealthCommitteeStatisticsBySlice()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SLICE", "", "Dilim", @"", false, true, false, new Guid("5ad28632-89d2-4ac7-8ba6-3c887a725a35"));
            reportParameter = Parameters.Add("SLICEFLAG", "", "Dilim Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("SLICEORDER", "", "Dilim Sırası", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SLICE"))
                _runtimeParameters.SLICE = (SliceEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SliceEnum"].ConvertValue(parameters["SLICE"]);
            if (parameters.ContainsKey("SLICEFLAG"))
                _runtimeParameters.SLICEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SLICEFLAG"]);
            if (parameters.ContainsKey("SLICEORDER"))
                _runtimeParameters.SLICEORDER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SLICEORDER"]);
            Name = "HEALTHCOMMITTEESTATISTICSBYSLICE";
            Caption = "Dilim Bilgisine Göre Sağlık Kurulu İstatistikleri";
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