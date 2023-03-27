
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
    /// Kesilmiş Kurum Faturaları Raporu
    /// </summary>
    public partial class PIReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public int? PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<string> PAYER = new List<string>();
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public PIReport MyParentReport
            {
                get { return (PIReport)ParentReport; }
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
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public PIReport MyParentReport
                {
                    get { return (PIReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 27, 7, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 2, 54, 7, false);
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
                    ((PIReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((PIReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            if (((PIReport)ParentReport).RuntimeParameters.PAYER == null)
                ((PIReport)ParentReport).RuntimeParameters.PAYERFLAG = 0;
            else
                ((PIReport)ParentReport).RuntimeParameters.PAYERFLAG = 1;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PIReport MyParentReport
                {
                    get { return (PIReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 139, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 204, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 204, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

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
            public PIReport MyParentReport
            {
                get { return (PIReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField121211 { get {return Header().NewField121211;} }
            public TTReportField NewField131211 { get {return Header().NewField131211;} }
            public TTReportField NewField141211 { get {return Header().NewField141211;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField111121111 { get {return Header().NewField111121111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField1112112 { get {return Header().NewField1112112;} }
            public TTReportField NewField12112111 { get {return Header().NewField12112111;} }
            public TTReportField NewField1112131 { get {return Header().NewField1112131;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField BASLIK1113111 { get {return Footer().BASLIK1113111;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public PIReport MyParentReport
                {
                    get { return (PIReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField STARTDATE;
                public TTReportField NewField1121;
                public TTReportField NewField112211;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField121211;
                public TTReportField NewField131211;
                public TTReportField NewField141211;
                public TTReportField NewField1112111;
                public TTReportField NewField111121111;
                public TTReportField ENDDATE;
                public TTReportField NewField1112211;
                public TTReportShape NewLine11111;
                public TTReportField NewField1112112;
                public TTReportField NewField12112111;
                public TTReportField NewField1112131; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 204, 15, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"KESİLMİŞ KURUM FATURALARI RAPORU";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 16, 28, 21, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 16, 61, 21, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 22, 28, 27, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Bitiş Tarihi";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 16, 30, 21, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 28, 16, 37, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.NoClip = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Sıra 
No";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 28, 55, 37, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Fatura No";

                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 28, 160, 37, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.TextFont.Size = 8;
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @"Kurum";

                    NewField131211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 28, 173, 37, false);
                    NewField131211.Name = "NewField131211";
                    NewField131211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131211.NoClip = EvetHayirEnum.ehEvet;
                    NewField131211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131211.TextFont.Size = 8;
                    NewField131211.TextFont.Bold = true;
                    NewField131211.TextFont.CharSet = 162;
                    NewField131211.Value = @"Hasta Durumu";

                    NewField141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 28, 90, 37, false);
                    NewField141211.Name = "NewField141211";
                    NewField141211.TextFont.Size = 8;
                    NewField141211.TextFont.Bold = true;
                    NewField141211.TextFont.CharSet = 162;
                    NewField141211.Value = @"TC Kimlik No";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 28, 34, 37, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Size = 8;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Fatura Tarihi";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 28, 204, 37, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111121111.TextFont.Size = 8;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"Fatura Tutarı";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 22, 61, 27, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 22, 30, 27, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 38, 204, 38, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 28, 70, 37, false);
                    NewField1112112.Name = "NewField1112112";
                    NewField1112112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112112.NoClip = EvetHayirEnum.ehEvet;
                    NewField1112112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1112112.TextFont.Size = 8;
                    NewField1112112.TextFont.Bold = true;
                    NewField1112112.TextFont.CharSet = 162;
                    NewField1112112.Value = @"H.Protokol No";

                    NewField12112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 28, 115, 37, false);
                    NewField12112111.Name = "NewField12112111";
                    NewField12112111.TextFont.Size = 8;
                    NewField12112111.TextFont.Bold = true;
                    NewField12112111.TextFont.CharSet = 162;
                    NewField12112111.Value = @"Hasta Adı";

                    NewField1112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 28, 186, 37, false);
                    NewField1112131.Name = "NewField1112131";
                    NewField1112131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112131.NoClip = EvetHayirEnum.ehEvet;
                    NewField1112131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1112131.TextFont.Size = 8;
                    NewField1112131.TextFont.Bold = true;
                    NewField1112131.TextFont.CharSet = 162;
                    NewField1112131.Value = @"Fatura Durumu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField121211.CalcValue = NewField121211.Value;
                    NewField131211.CalcValue = NewField131211.Value;
                    NewField141211.CalcValue = NewField141211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField1112112.CalcValue = NewField1112112.Value;
                    NewField12112111.CalcValue = NewField12112111.Value;
                    NewField1112131.CalcValue = NewField1112131.Value;
                    return new TTReportObject[] { NewField111,NewField121,STARTDATE,NewField1121,NewField112211,NewField11211,NewField111211,NewField121211,NewField131211,NewField141211,NewField1112111,NewField111121111,ENDDATE,NewField1112211,NewField1112112,NewField12112111,NewField1112131};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PIReport MyParentReport
                {
                    get { return (PIReport)ParentReport; }
                }
                
                public TTReportField TOPLAMTUTAR;
                public TTReportField BASLIK1113111;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 2, 204, 7, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Size = 8;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{@sumof(TUTAR)@}";

                    BASLIK1113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 2, 186, 7, false);
                    BASLIK1113111.Name = "BASLIK1113111";
                    BASLIK1113111.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1113111.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1113111.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1113111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1113111.TextFont.Size = 8;
                    BASLIK1113111.TextFont.Bold = true;
                    BASLIK1113111.TextFont.CharSet = 162;
                    BASLIK1113111.Value = @"Toplam Tutar:";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 204, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMTUTAR.CalcValue = ParentGroup.FieldSums["TUTAR"].Value.ToString();;
                    BASLIK1113111.CalcValue = BASLIK1113111.Value;
                    return new TTReportObject[] { TOPLAMTUTAR,BASLIK1113111};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PIReport MyParentReport
            {
                get { return (PIReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField FATURANO { get {return Body().FATURANO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField PROTOKONO { get {return Body().PROTOKONO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HD { get {return Body().HD;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportField FD { get {return Body().FD;} }
            public TTReportField CURRENTSTATEDEFID { get {return Body().CURRENTSTATEDEFID;} }
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
                list[0] = new TTReportNqlData<PayerInvoice.PIReportQuery_Class>("PIReportQuery", PayerInvoice.PIReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<string>) MyParentReport.RuntimeParameters.PAYER,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PAYERFLAG)));
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
                public PIReport MyParentReport
                {
                    get { return (PIReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField FATURANO;
                public TTReportField TARIH;
                public TTReportField KURUM;
                public TTReportField TUTAR;
                public TTReportField PROTOKONO;
                public TTReportField HASTAADI;
                public TTReportField HD;
                public TTReportField TC;
                public TTReportField FD;
                public TTReportField CURRENTSTATEDEFID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 16, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 55, 5, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#DOCUMENTNO#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 34, 5, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#DOCUMENTDATE#}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 160, 5, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Size = 8;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#PAYERNAME#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 204, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#PRICE#}";

                    PROTOKONO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 70, 5, false);
                    PROTOKONO.Name = "PROTOKONO";
                    PROTOKONO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKONO.TextFont.Size = 8;
                    PROTOKONO.TextFont.CharSet = 162;
                    PROTOKONO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 115, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    HD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 173, 5, false);
                    HD.Name = "HD";
                    HD.FieldType = ReportFieldTypeEnum.ftVariable;
                    HD.MultiLine = EvetHayirEnum.ehEvet;
                    HD.NoClip = EvetHayirEnum.ehEvet;
                    HD.WordBreak = EvetHayirEnum.ehEvet;
                    HD.ExpandTabs = EvetHayirEnum.ehEvet;
                    HD.ObjectDefName = "PatientStatusEnum";
                    HD.DataMember = "DISPLAYTEXT";
                    HD.TextFont.Size = 8;
                    HD.TextFont.CharSet = 162;
                    HD.Value = @"{#PATIENTSTATUS#}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 90, 5, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.TextFont.Size = 8;
                    TC.TextFont.CharSet = 162;
                    TC.Value = @"{#UNIQUEREFNO#}";

                    FD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 186, 5, false);
                    FD.Name = "FD";
                    FD.FieldType = ReportFieldTypeEnum.ftVariable;
                    FD.MultiLine = EvetHayirEnum.ehEvet;
                    FD.NoClip = EvetHayirEnum.ehEvet;
                    FD.WordBreak = EvetHayirEnum.ehEvet;
                    FD.ExpandTabs = EvetHayirEnum.ehEvet;
                    FD.TextFont.Size = 8;
                    FD.TextFont.CharSet = 162;
                    FD.Value = @"";

                    CURRENTSTATEDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 237, 5, false);
                    CURRENTSTATEDEFID.Name = "CURRENTSTATEDEFID";
                    CURRENTSTATEDEFID.Visible = EvetHayirEnum.ehHayir;
                    CURRENTSTATEDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTSTATEDEFID.Value = @"{#CURRENTSTATEDEFID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoice.PIReportQuery_Class dataset_PIReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoice.PIReportQuery_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    FATURANO.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.DocumentNo) : "");
                    TARIH.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.DocumentDate) : "");
                    KURUM.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.Payername) : "");
                    TUTAR.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.Price) : "");
                    PROTOKONO.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.HospitalProtocolNo) : "");
                    HASTAADI.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.Patientname) : "") + @" " + (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.Patientsurname) : "");
                    HD.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.PatientStatus) : "");
                    HD.PostFieldValueCalculation();
                    TC.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.UniqueRefNo) : "");
                    FD.CalcValue = @"";
                    CURRENTSTATEDEFID.CalcValue = (dataset_PIReportQuery != null ? Globals.ToStringCore(dataset_PIReportQuery.CurrentStateDefID) : "");
                    return new TTReportObject[] { SIRANO,FATURANO,TARIH,KURUM,TUTAR,PROTOKONO,HASTAADI,HD,TC,FD,CURRENTSTATEDEFID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.CURRENTSTATEDEFID.CalcValue == "8cac931b-a2c7-4d83-96a9-897c7312c62e") // İptal
                this.FD.CalcValue = "İptal Edildi";                
            else // Faturalandı
                this.FD.CalcValue = "Faturalandı";
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

        public PIReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tairhi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PAYERFLAG", "", "Kurum Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PAYER", "", "Kurum", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("61cb92fe-0330-48f5-9e09-674ba7a57b3d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PAYERFLAG"))
                _runtimeParameters.PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYERFLAG"]);
            if (parameters.ContainsKey("PAYER"))
                _runtimeParameters.PAYER = (List<string>)parameters["PAYER"];
            Name = "PIREPORT";
            Caption = "Kesilmiş Kurum Faturaları Raporu";
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