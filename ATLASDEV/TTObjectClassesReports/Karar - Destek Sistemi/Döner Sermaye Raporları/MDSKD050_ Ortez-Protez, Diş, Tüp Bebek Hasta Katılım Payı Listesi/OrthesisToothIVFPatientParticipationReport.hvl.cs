
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
    /// Ortez-Protez, Diş, Tüp Bebek Hasta Katılım Payı Listesi
    /// </summary>
    public partial class OrthesisToothIVFPatientParticipationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public int? RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<string> RESOURCE = new List<string>();
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public OrthesisToothIVFPatientParticipationReport MyParentReport
            {
                get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
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
            public TTReportShape NewLine11111111 { get {return Footer().NewLine11111111;} }
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
                public OrthesisToothIVFPatientParticipationReport MyParentReport
                {
                    get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 29, 8, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 3, 56, 8, false);
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
                    ((OrthesisToothIVFPatientParticipationReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((OrthesisToothIVFPatientParticipationReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            ((OrthesisToothIVFPatientParticipationReport)ParentReport).RuntimeParameters.RESOURCEFLAG = ((OrthesisToothIVFPatientParticipationReport)ParentReport).RuntimeParameters.RESOURCE == null || ((OrthesisToothIVFPatientParticipationReport)ParentReport).RuntimeParameters.RESOURCE.Count == 0 ? 0 : 1;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OrthesisToothIVFPatientParticipationReport MyParentReport
                {
                    get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportShape NewLine11111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 40, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 9;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 2, 179, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 9;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 2, 287, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 9;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 287, 1, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

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
            public OrthesisToothIVFPatientParticipationReport MyParentReport
            {
                get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField1112121 { get {return Header().NewField1112121;} }
            public TTReportField NewField1112131 { get {return Header().NewField1112131;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField1111121111 { get {return Header().NewField1111121111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField11122111 { get {return Header().NewField11122111;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportField NewField111121121 { get {return Header().NewField111121121;} }
            public TTReportField NewField11111211111 { get {return Header().NewField11111211111;} }
            public TTReportField NewField111111211111 { get {return Header().NewField111111211111;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField BASLIK11113111 { get {return Footer().BASLIK11113111;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public OrthesisToothIVFPatientParticipationReport MyParentReport
                {
                    get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField STARTDATE;
                public TTReportField NewField11211;
                public TTReportField NewField1112211;
                public TTReportField NewField111211;
                public TTReportField NewField1112111;
                public TTReportField NewField1112121;
                public TTReportField NewField1112131;
                public TTReportField NewField11112111;
                public TTReportField NewField1111121111;
                public TTReportField ENDDATE;
                public TTReportField NewField11122111;
                public TTReportShape NewLine111111;
                public TTReportField NewField111121121;
                public TTReportField NewField11111211111;
                public TTReportField NewField111111211111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 287, 9, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"ORTEZ-PROTEZ, DİŞ, TÜP BEBEK HASTA KATILIM PAYI LİSTESİ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 10, 32, 15, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 10, 87, 15, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 16, 32, 21, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Bitiş Tarihi";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 10, 34, 15, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 22, 20, 27, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Sıra No";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 22, 87, 27, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Size = 9;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Adı Soyadı";

                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 22, 128, 27, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.TextFont.Size = 9;
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @"Tarih";

                    NewField1112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 22, 189, 27, false);
                    NewField1112131.Name = "NewField1112131";
                    NewField1112131.TextFont.Size = 9;
                    NewField1112131.TextFont.Bold = true;
                    NewField1112131.TextFont.CharSet = 162;
                    NewField1112131.Value = @"Bölüm";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 22, 41, 27, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Size = 9;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"TC Kimlik No";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 22, 205, 27, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.TextFont.Size = 9;
                    NewField1111121111.TextFont.Bold = true;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @"Kod";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 16, 87, 21, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField11122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 16, 34, 21, false);
                    NewField11122111.Name = "NewField11122111";
                    NewField11122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11122111.TextFont.Bold = true;
                    NewField11122111.TextFont.CharSet = 162;
                    NewField11122111.Value = @":";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 28, 287, 28, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 22, 108, 27, false);
                    NewField111121121.Name = "NewField111121121";
                    NewField111121121.TextFont.Size = 9;
                    NewField111121121.TextFont.Bold = true;
                    NewField111121121.TextFont.CharSet = 162;
                    NewField111121121.Value = @"Protokol No";

                    NewField11111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 22, 269, 27, false);
                    NewField11111211111.Name = "NewField11111211111";
                    NewField11111211111.TextFont.Size = 9;
                    NewField11111211111.TextFont.Bold = true;
                    NewField11111211111.TextFont.CharSet = 162;
                    NewField11111211111.Value = @"Açıklama";

                    NewField111111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 22, 287, 27, false);
                    NewField111111211111.Name = "NewField111111211111";
                    NewField111111211111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111111211111.TextFont.Size = 9;
                    NewField111111211111.TextFont.Bold = true;
                    NewField111111211111.TextFont.CharSet = 162;
                    NewField111111211111.Value = @"Tutar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1112121.CalcValue = NewField1112121.Value;
                    NewField1112131.CalcValue = NewField1112131.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField11122111.CalcValue = NewField11122111.Value;
                    NewField111121121.CalcValue = NewField111121121.Value;
                    NewField11111211111.CalcValue = NewField11111211111.Value;
                    NewField111111211111.CalcValue = NewField111111211111.Value;
                    return new TTReportObject[] { NewField1111,NewField1121,STARTDATE,NewField11211,NewField1112211,NewField111211,NewField1112111,NewField1112121,NewField1112131,NewField11112111,NewField1111121111,ENDDATE,NewField11122111,NewField111121121,NewField11111211111,NewField111111211111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OrthesisToothIVFPatientParticipationReport MyParentReport
                {
                    get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField TOPLAMTUTAR;
                public TTReportField BASLIK11113111;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 2, 287, 7, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Size = 9;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{@sumof(TUTAR)@}";

                    BASLIK11113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 2, 261, 7, false);
                    BASLIK11113111.Name = "BASLIK11113111";
                    BASLIK11113111.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK11113111.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK11113111.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK11113111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK11113111.TextFont.Size = 9;
                    BASLIK11113111.TextFont.Bold = true;
                    BASLIK11113111.TextFont.CharSet = 162;
                    BASLIK11113111.Value = @"Toplam Tutar:";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 287, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMTUTAR.CalcValue = ParentGroup.FieldSums["TUTAR"].Value.ToString();;
                    BASLIK11113111.CalcValue = BASLIK11113111.Value;
                    return new TTReportObject[] { TOPLAMTUTAR,BASLIK11113111};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public OrthesisToothIVFPatientParticipationReport MyParentReport
            {
                get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO11 { get {return Body().SIRANO11;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField KOD { get {return Body().KOD;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
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
                list[0] = new TTReportNqlData<Receipt.OrthesisToothIVFPatientParticipationReport_Class>("OrthesisToothIVFPatientParticipationReport", Receipt.OrthesisToothIVFPatientParticipationReport((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCEFLAG),(List<string>) MyParentReport.RuntimeParameters.RESOURCE));
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
                public OrthesisToothIVFPatientParticipationReport MyParentReport
                {
                    get { return (OrthesisToothIVFPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField SIRANO11;
                public TTReportField ADSOYAD;
                public TTReportField TARIH;
                public TTReportField KOD;
                public TTReportField TUTAR;
                public TTReportField PROTOKOLNO;
                public TTReportField BOLUM;
                public TTReportField TCKIMLIKNO;
                public TTReportField ACIKLAMA; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SIRANO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 20, 6, false);
                    SIRANO11.Name = "SIRANO11";
                    SIRANO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO11.TextFont.Size = 9;
                    SIRANO11.TextFont.CharSet = 162;
                    SIRANO11.Value = @"{@groupcounter@}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 87, 6, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    ADSOYAD.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    ADSOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#ADI#} {#SOYADI#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 1, 128, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#TARIH#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 1, 205, 6, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Size = 9;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#KOD#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 1, 287, 6, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Size = 9;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#TUTAR#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 1, 108, 6, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOKOLNO#}";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 189, 6, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM.TextFont.Size = 9;
                    BOLUM.TextFont.CharSet = 162;
                    BOLUM.Value = @"{#BOLUM#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 41, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 1, 269, 6, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Size = 9;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#ACIKLAMA#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.OrthesisToothIVFPatientParticipationReport_Class dataset_OrthesisToothIVFPatientParticipationReport = ParentGroup.rsGroup.GetCurrentRecord<Receipt.OrthesisToothIVFPatientParticipationReport_Class>(0);
                    SIRANO11.CalcValue = ParentGroup.GroupCounter.ToString();
                    ADSOYAD.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Adi) : "") + @" " + (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Soyadi) : "");
                    TARIH.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Tarih) : "");
                    KOD.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Kod) : "");
                    TUTAR.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Tutar) : "");
                    PROTOKOLNO.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Protokolno) : "");
                    BOLUM.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Bolum) : "");
                    TCKIMLIKNO.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Tckimlikno) : "");
                    ACIKLAMA.CalcValue = (dataset_OrthesisToothIVFPatientParticipationReport != null ? Globals.ToStringCore(dataset_OrthesisToothIVFPatientParticipationReport.Aciklama) : "");
                    return new TTReportObject[] { SIRANO11,ADSOYAD,TARIH,KOD,TUTAR,PROTOKOLNO,BOLUM,TCKIMLIKNO,ACIKLAMA};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OrthesisToothIVFPatientParticipationReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("RESOURCEFLAG", "", "Poliklink / Klinik Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("RESOURCE", "", "Poliklinik / Klinik", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("1b976b6f-6d6c-473a-8e77-8b3d83b204ff");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("RESOURCEFLAG"))
                _runtimeParameters.RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESOURCEFLAG"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (List<string>)parameters["RESOURCE"];
            Name = "ORTHESISTOOTHIVFPATIENTPARTICIPATIONREPORT";
            Caption = "Ortez-Protez, Diş, Tüp Bebek Hasta Katılım Payı Listesi";
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