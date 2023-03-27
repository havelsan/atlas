
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
    /// Kesilmiş Toplu Faturalar Raporu
    /// </summary>
    public partial class CIReport : TTReport
    {
#region Methods
   public double TotalPrice;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CIReport MyParentReport
            {
                get { return (CIReport)ParentReport; }
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
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public CIReport MyParentReport
                {
                    get { return (CIReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 30, 6, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 52, 6, false);
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
#region PARTB HEADER_Script
                    ((CIReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((CIReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CIReport MyParentReport
                {
                    get { return (CIReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportShape NewLine1111;
                public TTReportField PageNumber; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 44, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 2, 135, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 191, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 2, 191, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

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
            public CIReport MyParentReport
            {
                get { return (CIReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField NewField11213 { get {return Header().NewField11213;} }
            public TTReportField NewField11214 { get {return Header().NewField11214;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField141211 { get {return Header().NewField141211;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField BASLIK11113111 { get {return Footer().BASLIK11113111;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
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
                public CIReport MyParentReport
                {
                    get { return (CIReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField STARTDATE;
                public TTReportField NewField121;
                public TTReportField ENDDATE;
                public TTReportField NewField1221;
                public TTReportField NewField11221;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField11212;
                public TTReportField NewField11213;
                public TTReportField NewField11214;
                public TTReportField NewField111211;
                public TTReportField NewField11112111;
                public TTReportShape NewLine1111;
                public TTReportField NewField141211; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 191, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"KESİLMİŞ TOPLU FATURALAR RAPORU";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 16, 33, 21, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 69, 21, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 22, 33, 27, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 22, 69, 27, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 22, 35, 27, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 16, 35, 21, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 28, 23, 33, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Sıra No";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 28, 57, 33, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Fatura No";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 28, 110, 33, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.TextFont.Size = 8;
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @"Kurum";

                    NewField11213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 28, 132, 33, false);
                    NewField11213.Name = "NewField11213";
                    NewField11213.TextFont.Size = 8;
                    NewField11213.TextFont.Bold = true;
                    NewField11213.TextFont.CharSet = 162;
                    NewField11213.Value = @"Hizmet Grubu";

                    NewField11214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 28, 152, 33, false);
                    NewField11214.Name = "NewField11214";
                    NewField11214.TextFont.Size = 8;
                    NewField11214.TextFont.Bold = true;
                    NewField11214.TextFont.CharSet = 162;
                    NewField11214.Value = @"Hasta Durumu";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 28, 40, 33, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Fatura Tarihi";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 28, 191, 33, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11112111.TextFont.Size = 8;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Fatura Tutarı";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 34, 191, 34, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 28, 169, 33, false);
                    NewField141211.Name = "NewField141211";
                    NewField141211.TextFont.Size = 8;
                    NewField141211.TextFont.Bold = true;
                    NewField141211.TextFont.CharSet = 162;
                    NewField141211.Value = @"Hasta Sayısı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField121.CalcValue = NewField121.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField11213.CalcValue = NewField11213.Value;
                    NewField11214.CalcValue = NewField11214.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField141211.CalcValue = NewField141211.Value;
                    return new TTReportObject[] { NewField11,NewField12,STARTDATE,NewField121,ENDDATE,NewField1221,NewField11221,NewField1121,NewField11211,NewField11212,NewField11213,NewField11214,NewField111211,NewField11112111,NewField141211};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CIReport MyParentReport
                {
                    get { return (CIReport)ParentReport; }
                }
                
                public TTReportField TOPLAMTUTAR;
                public TTReportField BASLIK11113111;
                public TTReportShape NewLine1112; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 2, 191, 7, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Size = 8;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"";

                    BASLIK11113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 2, 165, 7, false);
                    BASLIK11113111.Name = "BASLIK11113111";
                    BASLIK11113111.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK11113111.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK11113111.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK11113111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK11113111.TextFont.Size = 8;
                    BASLIK11113111.TextFont.Bold = true;
                    BASLIK11113111.TextFont.CharSet = 162;
                    BASLIK11113111.Value = @"Toplam Tutar:";

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 191, 1, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMTUTAR.CalcValue = @"";
                    BASLIK11113111.CalcValue = BASLIK11113111.Value;
                    return new TTReportObject[] { TOPLAMTUTAR,BASLIK11113111};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.TOPLAMTUTAR.CalcValue = ((CIReport)ParentReport).TotalPrice.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CIReport MyParentReport
            {
                get { return (CIReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField FATURANO { get {return Body().FATURANO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField HİZMETGRUBU { get {return Body().HİZMETGRUBU;} }
            public TTReportField HASTADURUMU { get {return Body().HASTADURUMU;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField HASTASAY { get {return Body().HASTASAY;} }
            public TTReportField CURRENTSTATEDEFID { get {return Body().CURRENTSTATEDEFID;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
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
                list[0] = new TTReportNqlData<CollectedInvoice.CIReportQuery_Class>("CIReportQuery", CollectedInvoice.CIReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CIReport MyParentReport
                {
                    get { return (CIReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField FATURANO;
                public TTReportField TARIH;
                public TTReportField KURUM;
                public TTReportField HİZMETGRUBU;
                public TTReportField HASTADURUMU;
                public TTReportField TUTAR;
                public TTReportField HASTASAY;
                public TTReportField CURRENTSTATEDEFID;
                public TTReportField STATUS; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 23, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 57, 5, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#DOCUMENTNO#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 40, 5, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#DOCUMENTDATE#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 110, 5, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Size = 8;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#PAYERNAME#}";

                    HİZMETGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 132, 5, false);
                    HİZMETGRUBU.Name = "HİZMETGRUBU";
                    HİZMETGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HİZMETGRUBU.MultiLine = EvetHayirEnum.ehEvet;
                    HİZMETGRUBU.NoClip = EvetHayirEnum.ehEvet;
                    HİZMETGRUBU.WordBreak = EvetHayirEnum.ehEvet;
                    HİZMETGRUBU.ExpandTabs = EvetHayirEnum.ehEvet;
                    HİZMETGRUBU.ObjectDefName = "CollectedInvoiceProcedureGroupEnum";
                    HİZMETGRUBU.DataMember = "DISPLAYTEXT";
                    HİZMETGRUBU.TextFont.Size = 8;
                    HİZMETGRUBU.TextFont.CharSet = 162;
                    HİZMETGRUBU.Value = @"{#PROCEDUREGROUP#}";

                    HASTADURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 152, 5, false);
                    HASTADURUMU.Name = "HASTADURUMU";
                    HASTADURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTADURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    HASTADURUMU.NoClip = EvetHayirEnum.ehEvet;
                    HASTADURUMU.WordBreak = EvetHayirEnum.ehEvet;
                    HASTADURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTADURUMU.ObjectDefName = "OutPatientInPatientEnum";
                    HASTADURUMU.DataMember = "DISPLAYTEXT";
                    HASTADURUMU.TextFont.Size = 8;
                    HASTADURUMU.TextFont.CharSet = 162;
                    HASTADURUMU.Value = @"{#PATIENTSTATUS#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 191, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#TOTALPRICE#}";

                    HASTASAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 169, 5, false);
                    HASTASAY.Name = "HASTASAY";
                    HASTASAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAY.TextFont.Size = 8;
                    HASTASAY.TextFont.CharSet = 162;
                    HASTASAY.Value = @"{#PATIENTCOUNT#}";

                    CURRENTSTATEDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 247, 5, false);
                    CURRENTSTATEDEFID.Name = "CURRENTSTATEDEFID";
                    CURRENTSTATEDEFID.Visible = EvetHayirEnum.ehHayir;
                    CURRENTSTATEDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTSTATEDEFID.TextFont.Size = 8;
                    CURRENTSTATEDEFID.TextFont.CharSet = 162;
                    CURRENTSTATEDEFID.Value = @"{#CURRENTSTATEDEFID#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 0, 205, 5, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.TextFont.Size = 8;
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CIReportQuery_Class dataset_CIReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CIReportQuery_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    FATURANO.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.DocumentNo) : "");
                    TARIH.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.DocumentDate) : "");
                    KURUM.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.Payername) : "");
                    HİZMETGRUBU.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.PROCEDUREGROUP) : "");
                    HİZMETGRUBU.PostFieldValueCalculation();
                    HASTADURUMU.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.PATIENTSTATUS) : "");
                    HASTADURUMU.PostFieldValueCalculation();
                    TUTAR.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.TotalPrice) : "");
                    HASTASAY.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.Patientcount) : "");
                    CURRENTSTATEDEFID.CalcValue = (dataset_CIReportQuery != null ? Globals.ToStringCore(dataset_CIReportQuery.CurrentStateDefID) : "");
                    STATUS.CalcValue = @"";
                    return new TTReportObject[] { SIRANO,FATURANO,TARIH,KURUM,HİZMETGRUBU,HASTADURUMU,TUTAR,HASTASAY,CURRENTSTATEDEFID,STATUS};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.CURRENTSTATEDEFID.CalcValue == "fe582ca6-0ba3-49f4-bc65-089ab9a29cac") // İptal
                this.STATUS.CalcValue = "(İPTAL)";                
            else // Toplu Faturalandı
                ((CIReport)ParentReport).TotalPrice += Convert.ToDouble(this.TUTAR.CalcValue);
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

        public CIReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangış Tarihi ", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "CIREPORT";
            Caption = "Kesilmiş Toplu Faturalar Raporu";
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


        protected override void RunPreScript()
        {
#region CIREPORT_PreScript
            TotalPrice = 0;
#endregion CIREPORT_PreScript
        }
    }
}