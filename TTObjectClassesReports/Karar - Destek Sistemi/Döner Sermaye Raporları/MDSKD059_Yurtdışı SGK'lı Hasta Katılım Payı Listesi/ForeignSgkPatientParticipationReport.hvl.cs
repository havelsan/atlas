
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
    /// Yurtdışı SGK'lı Hasta Katılım Payı Listesi
    /// </summary>
    public partial class ForeignSgkPatientParticipationReport : TTReport
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
            public ForeignSgkPatientParticipationReport MyParentReport
            {
                get { return (ForeignSgkPatientParticipationReport)ParentReport; }
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
            public TTReportShape NewLine111111111 { get {return Footer().NewLine111111111;} }
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
                public ForeignSgkPatientParticipationReport MyParentReport
                {
                    get { return (ForeignSgkPatientParticipationReport)ParentReport; }
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
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 28, 7, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 2, 55, 7, false);
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
                    ((ForeignSgkPatientParticipationReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((ForeignSgkPatientParticipationReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            ((ForeignSgkPatientParticipationReport)ParentReport).RuntimeParameters.RESOURCEFLAG = ((ForeignSgkPatientParticipationReport)ParentReport).RuntimeParameters.RESOURCE == null || ((ForeignSgkPatientParticipationReport)ParentReport).RuntimeParameters.RESOURCE.Count == 0 ? 0 : 1;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ForeignSgkPatientParticipationReport MyParentReport
                {
                    get { return (ForeignSgkPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportShape NewLine111111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 39, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 9;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 2, 178, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 9;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 2, 286, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 9;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 286, 1, false);
                    NewLine111111111.Name = "NewLine111111111";
                    NewLine111111111.DrawStyle = DrawStyleConstants.vbSolid;

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
            public ForeignSgkPatientParticipationReport MyParentReport
            {
                get { return (ForeignSgkPatientParticipationReport)ParentReport; }
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
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField11122111 { get {return Header().NewField11122111;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField11212111 { get {return Header().NewField11212111;} }
            public TTReportField NewField11312111 { get {return Header().NewField11312111;} }
            public TTReportField NewField111121111 { get {return Header().NewField111121111;} }
            public TTReportField NewField1121121111 { get {return Header().NewField1121121111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField111122111 { get {return Header().NewField111122111;} }
            public TTReportField NewField111121211 { get {return Header().NewField111121211;} }
            public TTReportField NewField111121311 { get {return Header().NewField111121311;} }
            public TTReportField NewField1112121111 { get {return Header().NewField1112121111;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField BASLIK111131111 { get {return Footer().BASLIK111131111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public ForeignSgkPatientParticipationReport MyParentReport
                {
                    get { return (ForeignSgkPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField11211;
                public TTReportField STARTDATE;
                public TTReportField NewField111211;
                public TTReportField NewField11122111;
                public TTReportField NewField1112111;
                public TTReportField NewField11112111;
                public TTReportField NewField11212111;
                public TTReportField NewField11312111;
                public TTReportField NewField111121111;
                public TTReportField NewField1121121111;
                public TTReportField ENDDATE;
                public TTReportField NewField111122111;
                public TTReportField NewField111121211;
                public TTReportField NewField111121311;
                public TTReportField NewField1112121111;
                public TTReportShape NewLine1111111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 286, 10, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"YURTDIŞI SGK'LI HASTA KATILIM PAYI LİSTESİ";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 31, 16, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 11, 86, 16, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 31, 22, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 9;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Bitiş Tarihi";

                    NewField11122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 11, 33, 16, false);
                    NewField11122111.Name = "NewField11122111";
                    NewField11122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11122111.TextFont.Bold = true;
                    NewField11122111.TextFont.CharSet = 162;
                    NewField11122111.Value = @":";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 19, 28, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Size = 9;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Sıra No";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 23, 86, 28, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Size = 9;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Adı Soyadı";

                    NewField11212111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 23, 127, 28, false);
                    NewField11212111.Name = "NewField11212111";
                    NewField11212111.TextFont.Size = 9;
                    NewField11212111.TextFont.Bold = true;
                    NewField11212111.TextFont.CharSet = 162;
                    NewField11212111.Value = @"Tarih";

                    NewField11312111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 23, 188, 28, false);
                    NewField11312111.Name = "NewField11312111";
                    NewField11312111.TextFont.Size = 9;
                    NewField11312111.TextFont.Bold = true;
                    NewField11312111.TextFont.CharSet = 162;
                    NewField11312111.Value = @"Bölüm";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 23, 40, 28, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Size = 9;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"TC Kimlik No";

                    NewField1121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 23, 107, 28, false);
                    NewField1121121111.Name = "NewField1121121111";
                    NewField1121121111.TextFont.Size = 9;
                    NewField1121121111.TextFont.Bold = true;
                    NewField1121121111.TextFont.CharSet = 162;
                    NewField1121121111.Value = @"Protokol No";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 17, 86, 22, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField111122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 17, 33, 22, false);
                    NewField111122111.Name = "NewField111122111";
                    NewField111122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111122111.TextFont.Bold = true;
                    NewField111122111.TextFont.CharSet = 162;
                    NewField111122111.Value = @":";

                    NewField111121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 23, 204, 28, false);
                    NewField111121211.Name = "NewField111121211";
                    NewField111121211.TextFont.Size = 9;
                    NewField111121211.TextFont.Bold = true;
                    NewField111121211.TextFont.CharSet = 162;
                    NewField111121211.Value = @"Kod";

                    NewField111121311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 23, 268, 28, false);
                    NewField111121311.Name = "NewField111121311";
                    NewField111121311.TextFont.Size = 9;
                    NewField111121311.TextFont.Bold = true;
                    NewField111121311.TextFont.CharSet = 162;
                    NewField111121311.Value = @"Açıklama";

                    NewField1112121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 23, 286, 28, false);
                    NewField1112121111.Name = "NewField1112121111";
                    NewField1112121111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1112121111.TextFont.Size = 9;
                    NewField1112121111.TextFont.Bold = true;
                    NewField1112121111.TextFont.CharSet = 162;
                    NewField1112121111.Value = @"Tutar";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 29, 286, 29, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField11122111.CalcValue = NewField11122111.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField11212111.CalcValue = NewField11212111.Value;
                    NewField11312111.CalcValue = NewField11312111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField1121121111.CalcValue = NewField1121121111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField111122111.CalcValue = NewField111122111.Value;
                    NewField111121211.CalcValue = NewField111121211.Value;
                    NewField111121311.CalcValue = NewField111121311.Value;
                    NewField1112121111.CalcValue = NewField1112121111.Value;
                    return new TTReportObject[] { NewField11111,NewField11211,STARTDATE,NewField111211,NewField11122111,NewField1112111,NewField11112111,NewField11212111,NewField11312111,NewField111121111,NewField1121121111,ENDDATE,NewField111122111,NewField111121211,NewField111121311,NewField1112121111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ForeignSgkPatientParticipationReport MyParentReport
                {
                    get { return (ForeignSgkPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField TOPLAMTUTAR;
                public TTReportField BASLIK111131111;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 2, 286, 7, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Size = 9;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{@sumof(TUTAR)@}";

                    BASLIK111131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 2, 260, 7, false);
                    BASLIK111131111.Name = "BASLIK111131111";
                    BASLIK111131111.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111131111.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK111131111.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK111131111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK111131111.TextFont.Size = 9;
                    BASLIK111131111.TextFont.Bold = true;
                    BASLIK111131111.TextFont.CharSet = 162;
                    BASLIK111131111.Value = @"Toplam Tutar:";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 286, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMTUTAR.CalcValue = ParentGroup.FieldSums["TUTAR"].Value.ToString();;
                    BASLIK111131111.CalcValue = BASLIK111131111.Value;
                    return new TTReportObject[] { TOPLAMTUTAR,BASLIK111131111};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ForeignSgkPatientParticipationReport MyParentReport
            {
                get { return (ForeignSgkPatientParticipationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
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
                list[0] = new TTReportNqlData<Receipt.GetForeignSgkPatientParticipationByDate_Class>("GetForeignSgkPatientParticipationByDate", Receipt.GetForeignSgkPatientParticipationByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<string>) MyParentReport.RuntimeParameters.RESOURCE,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCEFLAG)));
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
                public ForeignSgkPatientParticipationReport MyParentReport
                {
                    get { return (ForeignSgkPatientParticipationReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
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
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 19, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 9;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 86, 6, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    ADSOYAD.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    ADSOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#ADI#} {#SOYADI#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 1, 127, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#TARIH#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 1, 204, 6, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Size = 9;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#KOD#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 1, 286, 6, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.NoClip = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Size = 9;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#TUTAR#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 1, 107, 6, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOKOLNO#}";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 188, 6, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM.TextFont.Size = 9;
                    BOLUM.TextFont.CharSet = 162;
                    BOLUM.Value = @"{#BOLUM#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 40, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 1, 268, 6, false);
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
                    Receipt.GetForeignSgkPatientParticipationByDate_Class dataset_GetForeignSgkPatientParticipationByDate = ParentGroup.rsGroup.GetCurrentRecord<Receipt.GetForeignSgkPatientParticipationByDate_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    ADSOYAD.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Adi) : "") + @" " + (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Soyadi) : "");
                    TARIH.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Tarih) : "");
                    KOD.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Kod) : "");
                    TUTAR.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Tutar) : "");
                    PROTOKOLNO.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Protokolno) : "");
                    BOLUM.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Bolum) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Tckimlikno) : "");
                    ACIKLAMA.CalcValue = (dataset_GetForeignSgkPatientParticipationByDate != null ? Globals.ToStringCore(dataset_GetForeignSgkPatientParticipationByDate.Aciklama) : "");
                    return new TTReportObject[] { SIRANO,ADSOYAD,TARIH,KOD,TUTAR,PROTOKOLNO,BOLUM,TCKIMLIKNO,ACIKLAMA};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ForeignSgkPatientParticipationReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("RESOURCEFLAG", "", "Poliklinik / Klinik Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
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
            Name = "FOREIGNSGKPATIENTPARTICIPATIONREPORT";
            Caption = "Yurtdışı SGK'lı Hasta Katılım Payı Listesi";
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