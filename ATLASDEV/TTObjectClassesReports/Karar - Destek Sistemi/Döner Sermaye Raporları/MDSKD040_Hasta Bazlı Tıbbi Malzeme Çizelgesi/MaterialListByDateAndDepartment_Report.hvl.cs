
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
    /// Hasta Bazlı Tıbbi Malzeme Çizelgesi
    /// </summary>
    public partial class MaterialListByDateAndDepartment : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public OutPatientInPatientBothEnum? OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue("");
            public int? PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<Guid> RESOURCE = new List<Guid>();
            public int? RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public MaterialListByDateAndDepartment MyParentReport
            {
                get { return (MaterialListByDateAndDepartment)ParentReport; }
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
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 29, 5, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 56, 5, false);
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
                    ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            if (((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.RESOURCE == null)
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.RESOURCEFLAG = 0;
            else
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.RESOURCEFLAG = 1;
            
            
            if (((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.OutPatient)
            {
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 0;
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 0;
            }
            else if (((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.InPatient)
            {
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 1;
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
            }
            else if (((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH == OutPatientInPatientBothEnum.Both)
            {
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
                ((MaterialListByDateAndDepartment)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
            }
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 1, 138, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 204, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 41, 6, false);
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
            public MaterialListByDateAndDepartment MyParentReport
            {
                get { return (MaterialListByDateAndDepartment)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11411211 { get {return Header().NewField11411211;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField111211411 { get {return Header().NewField111211411;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField NewField11211211 { get {return Header().NewField11211211;} }
            public TTReportField NewField1111121 { get {return Footer().NewField1111121;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportShape NewLine111121 { get {return Footer().NewLine111121;} }
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
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField STARTDATE;
                public TTReportField NewField11411211;
                public TTReportField ENDDATE;
                public TTReportField NewField111211411;
                public TTReportField NewField1111;
                public TTReportField NewField1111111;
                public TTReportField PATIENTSTATUS;
                public TTReportField NewField11211211; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 15, 31, 20, false);
                    NewField121.Name = "NewField121";
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Tarih";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 15, 51, 20, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11411211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 15, 33, 20, false);
                    NewField11411211.Name = "NewField11411211";
                    NewField11411211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411211.TextFont.Name = "Arial";
                    NewField11411211.TextFont.Size = 8;
                    NewField11411211.TextFont.Bold = true;
                    NewField11411211.TextFont.CharSet = 162;
                    NewField11411211.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 15, 75, 20, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField111211411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 15, 54, 20, false);
                    NewField111211411.Name = "NewField111211411";
                    NewField111211411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211411.TextFont.Name = "Arial";
                    NewField111211411.TextFont.Size = 8;
                    NewField111211411.TextFont.CharSet = 162;
                    NewField111211411.Value = @"-";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 203, 13, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HASTA BAZLI TIBBİ MALZEME ÇİZELGESİ";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 31, 25, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 8;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Hasta Durumu";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 20, 75, 25, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.TextFont.Name = "Arial";
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"{@OUTPATIENTINPATIENTBOTH@}";

                    NewField11211211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 20, 33, 25, false);
                    NewField11211211.Name = "NewField11211211";
                    NewField11211211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211211.TextFont.Name = "Arial";
                    NewField11211211.TextFont.Size = 8;
                    NewField11211211.TextFont.Bold = true;
                    NewField11211211.TextFont.CharSet = 162;
                    NewField11211211.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField121.CalcValue = NewField121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11411211.CalcValue = NewField11411211.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField111211411.CalcValue = NewField111211411.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    PATIENTSTATUS.CalcValue = MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTBOTH.ToString();
                    NewField11211211.CalcValue = NewField11211211.Value;
                    return new TTReportObject[] { NewField121,STARTDATE,NewField11411211,ENDDATE,NewField111211411,NewField1111,NewField1111111,PATIENTSTATUS,NewField11211211};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (this.PATIENTSTATUS.CalcValue == "OutPatient")
                this.PATIENTSTATUS.CalcValue = "Ayaktan";
            else if (this.PATIENTSTATUS.CalcValue == "InPatient")
                this.PATIENTSTATUS.CalcValue = "Yatan";
            else if (this.PATIENTSTATUS.CalcValue == "Both")
                this.PATIENTSTATUS.CalcValue = "Hepsi";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField NewField1111121;
                public TTReportField GENELTOPLAM;
                public TTReportShape NewLine111121; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 3, 176, 8, false);
                    NewField1111121.Name = "NewField1111121";
                    NewField1111121.TextFont.Name = "Arial";
                    NewField1111121.TextFont.Size = 8;
                    NewField1111121.TextFont.Bold = true;
                    NewField1111121.TextFont.CharSet = 162;
                    NewField1111121.Value = @"Genel Toplam :";

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 3, 203, 8, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENELTOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENELTOPLAM.TextFont.Name = "Arial";
                    GENELTOPLAM.TextFont.Size = 8;
                    GENELTOPLAM.TextFont.CharSet = 162;
                    GENELTOPLAM.Value = @"{@sumof(BOLUMTOPLAM)@}";

                    NewLine111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 2, 203, 2, false);
                    NewLine111121.Name = "NewLine111121";
                    NewLine111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111121.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111121.CalcValue = NewField1111121.Value;
                    GENELTOPLAM.CalcValue = ParentGroup.FieldSums["BOLUMTOPLAM"].Value.ToString();;
                    return new TTReportObject[] { NewField1111121,GENELTOPLAM};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialListByDateAndDepartment MyParentReport
            {
                get { return (MaterialListByDateAndDepartment)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField RESOURCE { get {return Header().RESOURCE;} }
            public TTReportField NewField111121 { get {return Header().NewField111121;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField NewField121711 { get {return Header().NewField121711;} }
            public TTReportField NewField1117121 { get {return Header().NewField1117121;} }
            public TTReportField NewField1117111 { get {return Header().NewField1117111;} }
            public TTReportField NewField121111 { get {return Footer().NewField121111;} }
            public TTReportShape NewLine12111 { get {return Footer().NewLine12111;} }
            public TTReportField BOLUMTOPLAM { get {return Footer().BOLUMTOPLAM;} }
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
                list[0] = new TTReportNqlData<AccountTransaction.GetMaterialListByDateAndDepartment_Class>("GetMaterialListByDateAndDepartment", AccountTransaction.GetMaterialListByDateAndDepartment((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS1),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS2),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS3),(List<Guid>) MyParentReport.RuntimeParameters.RESOURCE,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCEFLAG)));
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
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField RESOURCE;
                public TTReportField NewField111121;
                public TTReportField NewField11511;
                public TTReportField NewField11711;
                public TTReportField NewField11911;
                public TTReportShape NewLine11111;
                public TTReportField NewField111711;
                public TTReportField NewField121711;
                public TTReportField NewField1117121;
                public TTReportField NewField1117111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 33, 9, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Poliklinik / Klinik";

                    RESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 4, 203, 9, false);
                    RESOURCE.Name = "RESOURCE";
                    RESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCE.TextFont.Name = "Arial";
                    RESOURCE.TextFont.Size = 8;
                    RESOURCE.TextFont.CharSet = 162;
                    RESOURCE.Value = @"{#DEPARTMENT#}";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 4, 35, 9, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111121.TextFont.Name = "Arial";
                    NewField111121.TextFont.Size = 8;
                    NewField111121.TextFont.Bold = true;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @":";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 19, 13, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Size = 8;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Sıra";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 9, 42, 13, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Size = 8;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"TC Kimlik No";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 9, 85, 13, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.TextFont.Name = "Arial";
                    NewField11911.TextFont.Size = 8;
                    NewField11911.TextFont.Bold = true;
                    NewField11911.TextFont.CharSet = 162;
                    NewField11911.Value = @"Hasta Adı";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 14, 203, 14, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 9, 185, 13, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Name = "Arial";
                    NewField111711.TextFont.Size = 8;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.TextFont.CharSet = 162;
                    NewField111711.Value = @"Miktar";

                    NewField121711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 9, 174, 13, false);
                    NewField121711.Name = "NewField121711";
                    NewField121711.TextFont.Name = "Arial";
                    NewField121711.TextFont.Size = 8;
                    NewField121711.TextFont.Bold = true;
                    NewField121711.TextFont.CharSet = 162;
                    NewField121711.Value = @"Tıbbi Malzeme Adı";

                    NewField1117121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 108, 13, false);
                    NewField1117121.Name = "NewField1117121";
                    NewField1117121.TextFont.Name = "Arial";
                    NewField1117121.TextFont.Size = 8;
                    NewField1117121.TextFont.Bold = true;
                    NewField1117121.TextFont.CharSet = 162;
                    NewField1117121.Value = @"H.Protokol No";

                    NewField1117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 9, 203, 13, false);
                    NewField1117111.Name = "NewField1117111";
                    NewField1117111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1117111.TextFont.Name = "Arial";
                    NewField1117111.TextFont.Size = 8;
                    NewField1117111.TextFont.Bold = true;
                    NewField1117111.TextFont.CharSet = 162;
                    NewField1117111.Value = @"Fiyat";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMaterialListByDateAndDepartment_Class dataset_GetMaterialListByDateAndDepartment = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMaterialListByDateAndDepartment_Class>(0);
                    NewField11111.CalcValue = NewField11111.Value;
                    RESOURCE.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.Department) : "");
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    NewField121711.CalcValue = NewField121711.Value;
                    NewField1117121.CalcValue = NewField1117121.Value;
                    NewField1117111.CalcValue = NewField1117111.Value;
                    return new TTReportObject[] { NewField11111,RESOURCE,NewField111121,NewField11511,NewField11711,NewField11911,NewField111711,NewField121711,NewField1117121,NewField1117111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField NewField121111;
                public TTReportShape NewLine12111;
                public TTReportField BOLUMTOPLAM; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 3, 176, 8, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 8;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"Bölüm Toplamı :";

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 2, 203, 2, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12111.DrawWidth = 2;

                    BOLUMTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 3, 203, 8, false);
                    BOLUMTOPLAM.Name = "BOLUMTOPLAM";
                    BOLUMTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMTOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BOLUMTOPLAM.TextFont.Name = "Arial";
                    BOLUMTOPLAM.TextFont.Size = 8;
                    BOLUMTOPLAM.TextFont.CharSet = 162;
                    BOLUMTOPLAM.Value = @"{@sumof(FIYAT)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMaterialListByDateAndDepartment_Class dataset_GetMaterialListByDateAndDepartment = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMaterialListByDateAndDepartment_Class>(0);
                    NewField121111.CalcValue = NewField121111.Value;
                    BOLUMTOPLAM.CalcValue = ParentGroup.FieldSums["FIYAT"].Value.ToString();;
                    return new TTReportObject[] { NewField121111,BOLUMTOPLAM};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialListByDateAndDepartment MyParentReport
            {
                get { return (MaterialListByDateAndDepartment)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField MALZEMEADI { get {return Body().MALZEMEADI;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField FIYAT { get {return Body().FIYAT;} }
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

                AccountTransaction.GetMaterialListByDateAndDepartment_Class dataSet_GetMaterialListByDateAndDepartment = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMaterialListByDateAndDepartment_Class>(0);    
                return new object[] {(dataSet_GetMaterialListByDateAndDepartment==null ? null : dataSet_GetMaterialListByDateAndDepartment.Department)};
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
                public MaterialListByDateAndDepartment MyParentReport
                {
                    get { return (MaterialListByDateAndDepartment)ParentReport; }
                }
                
                public TTReportField TCKIMLIKNO;
                public TTReportField SNO;
                public TTReportField HASTAADI;
                public TTReportField MALZEMEADI;
                public TTReportField MIKTAR;
                public TTReportField HPROTOKOLNO;
                public TTReportField FIYAT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 42, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.UNIQUEREFNO#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 19, 5, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 8;
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@groupcounter@}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 0, 85, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PARTA.NAME#} {#PARTA.SURNAME#}";

                    MALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 174, 5, false);
                    MALZEMEADI.Name = "MALZEMEADI";
                    MALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADI.NoClip = EvetHayirEnum.ehEvet;
                    MALZEMEADI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALZEMEADI.TextFont.Name = "Arial";
                    MALZEMEADI.TextFont.Size = 8;
                    MALZEMEADI.TextFont.CharSet = 162;
                    MALZEMEADI.Value = @"{#PARTA.DESCRIPTION#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 185, 5, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#PARTA.AMOUNT#}";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 108, 5, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.TextFont.Name = "Arial";
                    HPROTOKOLNO.TextFont.Size = 8;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#PARTA.HOSPITALPROTOCOLNO#}";

                    FIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 203, 5, false);
                    FIYAT.Name = "FIYAT";
                    FIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIYAT.TextFormat = @"#,##0.#0";
                    FIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT.TextFont.Name = "Arial";
                    FIYAT.TextFont.Size = 8;
                    FIYAT.TextFont.CharSet = 162;
                    FIYAT.Value = @"{#PARTA.TOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMaterialListByDateAndDepartment_Class dataset_GetMaterialListByDateAndDepartment = MyParentReport.PARTA.rsGroup.GetCurrentRecord<AccountTransaction.GetMaterialListByDateAndDepartment_Class>(0);
                    TCKIMLIKNO.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.UniqueRefNo) : "");
                    SNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    HASTAADI.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.Name) : "") + @" " + (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.Surname) : "");
                    MALZEMEADI.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.Description) : "");
                    MIKTAR.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.Amount) : "");
                    HPROTOKOLNO.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.HospitalProtocolNo) : "");
                    FIYAT.CalcValue = (dataset_GetMaterialListByDateAndDepartment != null ? Globals.ToStringCore(dataset_GetMaterialListByDateAndDepartment.Totalprice) : "");
                    return new TTReportObject[] { TCKIMLIKNO,SNO,HASTAADI,MALZEMEADI,MIKTAR,HPROTOKOLNO,FIYAT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialListByDateAndDepartment()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTBOTH", "", "Hasta Durumu", @"", true, true, false, new Guid("0ab6e9e9-139a-4b78-9a97-05ed687758d5"));
            reportParameter = Parameters.Add("PATIENTSTATUS1", "", "Hasta Durumu 1", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS2", "", "Hasta Durumu 2", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS3", "", "Hasta Durumu 3", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("RESOURCE", "", "Poliklinik / Klinik", @"", false, true, true, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("1b976b6f-6d6c-473a-8e77-8b3d83b204ff");
            reportParameter = Parameters.Add("RESOURCEFLAG", "", "Poliklinik / Klinik Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTBOTH"))
                _runtimeParameters.OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue(parameters["OUTPATIENTINPATIENTBOTH"]);
            if (parameters.ContainsKey("PATIENTSTATUS1"))
                _runtimeParameters.PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS1"]);
            if (parameters.ContainsKey("PATIENTSTATUS2"))
                _runtimeParameters.PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS2"]);
            if (parameters.ContainsKey("PATIENTSTATUS3"))
                _runtimeParameters.PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS3"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (List<Guid>)parameters["RESOURCE"];
            if (parameters.ContainsKey("RESOURCEFLAG"))
                _runtimeParameters.RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESOURCEFLAG"]);
            Name = "MATERIALLISTBYDATEANDDEPARTMENT";
            Caption = "Hasta Bazlı Tıbbi Malzeme Çizelgesi";
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