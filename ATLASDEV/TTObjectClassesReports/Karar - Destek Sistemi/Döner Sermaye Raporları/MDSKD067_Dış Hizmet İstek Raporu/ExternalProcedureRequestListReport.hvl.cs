
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
    /// Dış Hizmet İstek Raporu
    /// </summary>
    public partial class ExternalProcedureRequestListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public ExternalProcedureRequestListReport MyParentReport
            {
                get { return (ExternalProcedureRequestListReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
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
                public ExternalProcedureRequestListReport MyParentReport
                {
                    get { return (ExternalProcedureRequestListReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 31, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 57, 6, false);
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
#region PARTB HEADER_Script
                    ((ExternalProcedureRequestListReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((ExternalProcedureRequestListReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ExternalProcedureRequestListReport MyParentReport
                {
                    get { return (ExternalProcedureRequestListReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine1111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 2, 180, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 2, 291, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 291, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

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

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public ExternalProcedureRequestListReport MyParentReport
            {
                get { return (ExternalProcedureRequestListReport)ParentReport; }
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
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1112311 { get {return Header().NewField1112311;} }
            public TTReportField NewFieldb11 { get {return Header().NewFieldb11;} }
            public TTReportField NewFielda11 { get {return Header().NewFielda11;} }
            public TTReportField NewFieldc11 { get {return Header().NewFieldc11;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewFieldb111 { get {return Header().NewFieldb111;} }
            public TTReportField NewFieldc112 { get {return Header().NewFieldc112;} }
            public TTReportField NewFieldc1211 { get {return Header().NewFieldc1211;} }
            public TTReportField NewFieldc11121 { get {return Header().NewFieldc11121;} }
            public TTReportField NewFieldc112111 { get {return Header().NewFieldc112111;} }
            public TTReportField NewFieldc112112 { get {return Header().NewFieldc112112;} }
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
                public ExternalProcedureRequestListReport MyParentReport
                {
                    get { return (ExternalProcedureRequestListReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField11121;
                public TTReportField NewField11211;
                public TTReportField STARTDATE;
                public TTReportField NewField111111;
                public TTReportField ENDDATE;
                public TTReportField NewField1112311;
                public TTReportField NewFieldb11;
                public TTReportField NewFielda11;
                public TTReportField NewFieldc11;
                public TTReportShape NewLine111111;
                public TTReportField NewField111211;
                public TTReportField NewFieldb111;
                public TTReportField NewFieldc112;
                public TTReportField NewFieldc1211;
                public TTReportField NewFieldc11121;
                public TTReportField NewFieldc112111;
                public TTReportField NewFieldc112112; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 12, 291, 17, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Size = 12;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"DIŞ HİZMET İSTEK RAPORU";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 20, 31, 25, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Başlangıç Tarihi";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 20, 33, 25, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 20, 67, 25, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 26, 31, 31, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 26, 67, 31, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 32, 18, 41, false);
                    NewField1112311.Name = "NewField1112311";
                    NewField1112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112311.NoClip = EvetHayirEnum.ehEvet;
                    NewField1112311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1112311.TextFont.Bold = true;
                    NewField1112311.TextFont.CharSet = 162;
                    NewField1112311.Value = @"Sıra
No";

                    NewFieldb11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 32, 56, 41, false);
                    NewFieldb11.Name = "NewFieldb11";
                    NewFieldb11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldb11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb11.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb11.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb11.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb11.TextFont.Bold = true;
                    NewFieldb11.TextFont.CharSet = 162;
                    NewFieldb11.Value = @"Hasta 
Grubu";

                    NewFielda11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 32, 37, 41, false);
                    NewFielda11.Name = "NewFielda11";
                    NewFielda11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFielda11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFielda11.MultiLine = EvetHayirEnum.ehEvet;
                    NewFielda11.NoClip = EvetHayirEnum.ehEvet;
                    NewFielda11.WordBreak = EvetHayirEnum.ehEvet;
                    NewFielda11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFielda11.TextFont.Bold = true;
                    NewFielda11.TextFont.CharSet = 162;
                    NewFielda11.Value = @"TC Kimlik 
No";

                    NewFieldc11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 32, 105, 41, false);
                    NewFieldc11.Name = "NewFieldc11";
                    NewFieldc11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldc11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldc11.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldc11.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldc11.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldc11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldc11.TextFont.Bold = true;
                    NewFieldc11.TextFont.CharSet = 162;
                    NewFieldc11.Value = @"H.Protokol
No";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 42, 291, 42, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 26, 33, 31, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @":";

                    NewFieldb111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 32, 86, 41, false);
                    NewFieldb111.Name = "NewFieldb111";
                    NewFieldb111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldb111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb111.TextFont.Bold = true;
                    NewFieldb111.TextFont.CharSet = 162;
                    NewFieldb111.Value = @"Hasta Adı";

                    NewFieldc112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 32, 126, 41, false);
                    NewFieldc112.Name = "NewFieldc112";
                    NewFieldc112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldc112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldc112.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldc112.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldc112.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldc112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldc112.TextFont.Bold = true;
                    NewFieldc112.TextFont.CharSet = 162;
                    NewFieldc112.Value = @"Dış Hizmet
İstek Tarihi";

                    NewFieldc1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 32, 164, 41, false);
                    NewFieldc1211.Name = "NewFieldc1211";
                    NewFieldc1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldc1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldc1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldc1211.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldc1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldc1211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldc1211.TextFont.Bold = true;
                    NewFieldc1211.TextFont.CharSet = 162;
                    NewFieldc1211.Value = @"Dış Hizmet
Yapılan XXXXXX";

                    NewFieldc11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 32, 214, 41, false);
                    NewFieldc11121.Name = "NewFieldc11121";
                    NewFieldc11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldc11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldc11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldc11121.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldc11121.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldc11121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldc11121.TextFont.Bold = true;
                    NewFieldc11121.TextFont.CharSet = 162;
                    NewFieldc11121.Value = @"İstenen Tetkik 
Sut Kodu ve Adı";

                    NewFieldc112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 32, 248, 41, false);
                    NewFieldc112111.Name = "NewFieldc112111";
                    NewFieldc112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldc112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldc112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldc112111.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldc112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldc112111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldc112111.TextFont.Bold = true;
                    NewFieldc112111.TextFont.CharSet = 162;
                    NewFieldc112111.Value = @"İstek Yapan 
Doktor";

                    NewFieldc112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 32, 291, 41, false);
                    NewFieldc112112.Name = "NewFieldc112112";
                    NewFieldc112112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFieldc112112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldc112112.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldc112112.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldc112112.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldc112112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldc112112.TextFont.Bold = true;
                    NewFieldc112112.TextFont.CharSet = 162;
                    NewFieldc112112.Value = @"İstek Yapan 
Poliklinik";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField111111.CalcValue = NewField111111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1112311.CalcValue = NewField1112311.Value;
                    NewFieldb11.CalcValue = NewFieldb11.Value;
                    NewFielda11.CalcValue = NewFielda11.Value;
                    NewFieldc11.CalcValue = NewFieldc11.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewFieldb111.CalcValue = NewFieldb111.Value;
                    NewFieldc112.CalcValue = NewFieldc112.Value;
                    NewFieldc1211.CalcValue = NewFieldc1211.Value;
                    NewFieldc11121.CalcValue = NewFieldc11121.Value;
                    NewFieldc112111.CalcValue = NewFieldc112111.Value;
                    NewFieldc112112.CalcValue = NewFieldc112112.Value;
                    return new TTReportObject[] { NewField11111,NewField11121,NewField11211,STARTDATE,NewField111111,ENDDATE,NewField1112311,NewFieldb11,NewFielda11,NewFieldc11,NewField111211,NewFieldb111,NewFieldc112,NewFieldc1211,NewFieldc11121,NewFieldc112111,NewFieldc112112};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ExternalProcedureRequestListReport MyParentReport
                {
                    get { return (ExternalProcedureRequestListReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ExternalProcedureRequestListReport MyParentReport
            {
                get { return (ExternalProcedureRequestListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HASTAGRUBU { get {return Body().HASTAGRUBU;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField ISTEKTARIHI { get {return Body().ISTEKTARIHI;} }
            public TTReportField HIZMETYAPILANXXXXXX { get {return Body().HIZMETYAPILANXXXXXX;} }
            public TTReportField ISTENENTETKIK { get {return Body().ISTENENTETKIK;} }
            public TTReportField ISTEKYAPANDOKTOR { get {return Body().ISTEKYAPANDOKTOR;} }
            public TTReportField ISTEKYAPANPOLIKLINIK { get {return Body().ISTEKYAPANPOLIKLINIK;} }
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
                list[0] = new TTReportNqlData<ExternalProcedureRequest.ExternalProcedureRequestListByDate_Class>("ExternalProcedureRequestListByDate2", ExternalProcedureRequest.ExternalProcedureRequestListByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public ExternalProcedureRequestListReport MyParentReport
                {
                    get { return (ExternalProcedureRequestListReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAGRUBU;
                public TTReportField HASTAADI;
                public TTReportField PROTOKOLNO;
                public TTReportField ISTEKTARIHI;
                public TTReportField HIZMETYAPILANXXXXXX;
                public TTReportField ISTENENTETKIK;
                public TTReportField ISTEKYAPANDOKTOR;
                public TTReportField ISTEKYAPANPOLIKLINIK; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 18, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 37, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    HASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 56, 6, false);
                    HASTAGRUBU.Name = "HASTAGRUBU";
                    HASTAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAGRUBU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAGRUBU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAGRUBU.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAGRUBU.NoClip = EvetHayirEnum.ehEvet;
                    HASTAGRUBU.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAGRUBU.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAGRUBU.ObjectDefName = "PatientGroupEnum";
                    HASTAGRUBU.DataMember = "DISPLAYTEXT";
                    HASTAGRUBU.TextFont.Size = 8;
                    HASTAGRUBU.TextFont.CharSet = 162;
                    HASTAGRUBU.Value = @"{#PATIENTGROUP#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 86, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 1, 105, 6, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.TextFont.Size = 8;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    ISTEKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 126, 6, false);
                    ISTEKTARIHI.Name = "ISTEKTARIHI";
                    ISTEKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKTARIHI.TextFormat = @"dd/MM/yyyy";
                    ISTEKTARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISTEKTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKTARIHI.TextFont.Size = 8;
                    ISTEKTARIHI.TextFont.CharSet = 162;
                    ISTEKTARIHI.Value = @"{#REQUESTDATE#}";

                    HIZMETYAPILANXXXXXX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 164, 6, false);
                    HIZMETYAPILANXXXXXX.Name = "HIZMETYAPILANXXXXXX";
                    HIZMETYAPILANXXXXXX.FieldType = ReportFieldTypeEnum.ftVariable;
                    HIZMETYAPILANXXXXXX.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIZMETYAPILANXXXXXX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HIZMETYAPILANXXXXXX.MultiLine = EvetHayirEnum.ehEvet;
                    HIZMETYAPILANXXXXXX.NoClip = EvetHayirEnum.ehEvet;
                    HIZMETYAPILANXXXXXX.WordBreak = EvetHayirEnum.ehEvet;
                    HIZMETYAPILANXXXXXX.ExpandTabs = EvetHayirEnum.ehEvet;
                    HIZMETYAPILANXXXXXX.TextFont.Size = 8;
                    HIZMETYAPILANXXXXXX.TextFont.CharSet = 162;
                    HIZMETYAPILANXXXXXX.Value = @"{#EXTERNALPLACE#}";

                    ISTENENTETKIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 1, 214, 6, false);
                    ISTENENTETKIK.Name = "ISTENENTETKIK";
                    ISTENENTETKIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTENENTETKIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISTENENTETKIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTENENTETKIK.MultiLine = EvetHayirEnum.ehEvet;
                    ISTENENTETKIK.NoClip = EvetHayirEnum.ehEvet;
                    ISTENENTETKIK.WordBreak = EvetHayirEnum.ehEvet;
                    ISTENENTETKIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTENENTETKIK.TextFont.Size = 8;
                    ISTENENTETKIK.TextFont.CharSet = 162;
                    ISTENENTETKIK.Value = @"{#PROCEDURENAME#}";

                    ISTEKYAPANDOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 248, 6, false);
                    ISTEKYAPANDOKTOR.Name = "ISTEKYAPANDOKTOR";
                    ISTEKYAPANDOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPANDOKTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISTEKYAPANDOKTOR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKYAPANDOKTOR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKYAPANDOKTOR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKYAPANDOKTOR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKYAPANDOKTOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKYAPANDOKTOR.TextFont.Size = 8;
                    ISTEKYAPANDOKTOR.TextFont.CharSet = 162;
                    ISTEKYAPANDOKTOR.Value = @"{#DOCTORNAME#}";

                    ISTEKYAPANPOLIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 1, 291, 6, false);
                    ISTEKYAPANPOLIKLINIK.Name = "ISTEKYAPANPOLIKLINIK";
                    ISTEKYAPANPOLIKLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPANPOLIKLINIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISTEKYAPANPOLIKLINIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKYAPANPOLIKLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKYAPANPOLIKLINIK.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKYAPANPOLIKLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKYAPANPOLIKLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKYAPANPOLIKLINIK.TextFont.Size = 8;
                    ISTEKYAPANPOLIKLINIK.TextFont.CharSet = 162;
                    ISTEKYAPANPOLIKLINIK.Value = @"{#FROMRESOURCE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExternalProcedureRequest.ExternalProcedureRequestListByDate_Class dataset_ExternalProcedureRequestListByDate2 = ParentGroup.rsGroup.GetCurrentRecord<ExternalProcedureRequest.ExternalProcedureRequestListByDate_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TCKIMLIKNO.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.UniqueRefNo) : "");
                    HASTAGRUBU.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.Patientgroup) : "");
                    HASTAGRUBU.PostFieldValueCalculation();
                    HASTAADI.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.Patientname) : "");
                    PROTOKOLNO.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.HospitalProtocolNo) : "");
                    ISTEKTARIHI.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.RequestDate) : "");
                    HIZMETYAPILANXXXXXX.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.Externalplace) : "");
                    ISTENENTETKIK.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.Procedurename) : "");
                    ISTEKYAPANDOKTOR.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.Doctorname) : "");
                    ISTEKYAPANPOLIKLINIK.CalcValue = (dataset_ExternalProcedureRequestListByDate2 != null ? Globals.ToStringCore(dataset_ExternalProcedureRequestListByDate2.Fromresource) : "");
                    return new TTReportObject[] { SIRANO,TCKIMLIKNO,HASTAGRUBU,HASTAADI,PROTOKOLNO,ISTEKTARIHI,HIZMETYAPILANXXXXXX,ISTENENTETKIK,ISTEKYAPANDOKTOR,ISTEKYAPANPOLIKLINIK};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ExternalProcedureRequestListReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "EXTERNALPROCEDUREREQUESTLISTREPORT";
            Caption = "Dış Hizmet İstek Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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