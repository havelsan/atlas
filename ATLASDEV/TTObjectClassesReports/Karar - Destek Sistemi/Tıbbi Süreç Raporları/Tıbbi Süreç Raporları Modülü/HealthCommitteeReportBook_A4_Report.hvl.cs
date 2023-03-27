
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
    /// Sağlık Kurulu Defteri (Sağlık Kurulu A4)
    /// </summary>
    public partial class HealthCommitteeReportBook_A4 : TTReport
    {
#region Methods
   public int isFlagZero = 0;
        public int groupCounter = 0;
        int countOfA = 0;
        int countOfB = 0;
        int countOfC = 0;
        int countOfD = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public int? HEALTHCOMITEETYPEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public HealthCommitteeTypeEnum? HEALTHCOMITEETYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField DATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 17, 290, 25, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.TextFont.Size = 14;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"SAĞLIK KURULU DEFTERİ";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 25, 290, 30, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.WordBreak = EvetHayirEnum.ehEvet;
                    DATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@DATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = @"SAĞLIK KURULU DEFTERİ";
                    DATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    return new TTReportObject[] { BASLIK,DATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            ResHospital hospital = TTObjectClasses.Common.GetCurrentHospital(context);
            
            if(((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE == HealthCommitteeTypeEnum.FlierCommittee)
                BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCFLIERREPORTBOOKCAPTION", hospital.Name + " UÇUCU SAĞLIK KURULU DEFTERİ");
            else
                BASLIK.CalcValue = hospital.Name + " SAĞLIK KURULU DEFTERİ";

            ((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(DATE.FormattedValue + " 00:00:00");
            ((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(DATE.FormattedValue + " 23:59:59");
            
            ((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG = ((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE == null ? 0 : 1;
            
            if(((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG == 0 || ((HealthCommitteeReportBook_A4)ParentReport).isFlagZero == 1)
            {
                if(((HealthCommitteeReportBook_A4)ParentReport).isFlagZero == 0)
                    ((HealthCommitteeReportBook_A4)ParentReport).isFlagZero = 1;
                if(((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG != 0)
                    ((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG = 0;
            }
            
            // NQL de hata vermemesi için bu şekilde herhangi bir değere set ediliyor
            if(((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPEFLAG == 0)
                ((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE = HealthCommitteeTypeEnum.NormalCommittee;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 290, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu: {@pagenumber@} / {@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"Sayfa Nu: " + ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class CAPTIONGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public CAPTIONGroupHeader Header()
            {
                return (CAPTIONGroupHeader)_header;
            }

            new public CAPTIONGroupFooter Footer()
            {
                return (CAPTIONGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine122 { get {return Header().NewLine122;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportShape NewLine1113 { get {return Header().NewLine1113;} }
            public TTReportShape NewLine1114 { get {return Header().NewLine1114;} }
            public TTReportShape NewLine1115 { get {return Header().NewLine1115;} }
            public TTReportShape NewLine1116 { get {return Header().NewLine1116;} }
            public TTReportShape NewLine1117 { get {return Header().NewLine1117;} }
            public TTReportShape NewLine1118 { get {return Header().NewLine1118;} }
            public TTReportField PAGENUMBER { get {return Header().PAGENUMBER;} }
            public TTReportField PAGECOUNT { get {return Header().PAGECOUNT;} }
            public TTReportField REPORTDATE { get {return Footer().REPORTDATE;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField SK_CHAIRMAN { get {return Footer().SK_CHAIRMAN;} }
            public TTReportField SK_MEMBER1 { get {return Footer().SK_MEMBER1;} }
            public TTReportField SK_MEMBER2 { get {return Footer().SK_MEMBER2;} }
            public TTReportField SK_MEMBER3 { get {return Footer().SK_MEMBER3;} }
            public TTReportField SK_MEMBER4 { get {return Footer().SK_MEMBER4;} }
            public TTReportField SK_MEMBER5 { get {return Footer().SK_MEMBER5;} }
            public TTReportField SK_MEMBER6 { get {return Footer().SK_MEMBER6;} }
            public TTReportField SK_MEMBER7 { get {return Footer().SK_MEMBER7;} }
            public TTReportField SK_MEMBER8 { get {return Footer().SK_MEMBER8;} }
            public TTReportField SK_MEMBER9 { get {return Footer().SK_MEMBER9;} }
            public TTReportField SK_MEMBER10 { get {return Footer().SK_MEMBER10;} }
            public TTReportField SK_MEMBER11 { get {return Footer().SK_MEMBER11;} }
            public TTReportField SK_MEMBER12 { get {return Footer().SK_MEMBER12;} }
            public TTReportField SK_MEMBER13 { get {return Footer().SK_MEMBER13;} }
            public TTReportField SK_MEMBER14 { get {return Footer().SK_MEMBER14;} }
            public TTReportField SK_MEMBER15 { get {return Footer().SK_MEMBER15;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField COUNTOFA { get {return Footer().COUNTOFA;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField NewField11112 { get {return Footer().NewField11112;} }
            public TTReportField NewField11113 { get {return Footer().NewField11113;} }
            public TTReportField NewField11114 { get {return Footer().NewField11114;} }
            public TTReportField COUNTOFB { get {return Footer().COUNTOFB;} }
            public TTReportField COUNTOFC { get {return Footer().COUNTOFC;} }
            public TTReportField COUNTOFD { get {return Footer().COUNTOFD;} }
            public TTReportField COUNT { get {return Footer().COUNT;} }
            public TTReportField NewField11113111 { get {return Footer().NewField11113111;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public CAPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CAPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new CAPTIONGroupHeader(this);
                _footer = new CAPTIONGroupFooter(this);

            }

            public partial class CAPTIONGroupHeader : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine1113;
                public TTReportShape NewLine1114;
                public TTReportShape NewLine1115;
                public TTReportShape NewLine1116;
                public TTReportShape NewLine1117;
                public TTReportShape NewLine1118;
                public TTReportField PAGENUMBER;
                public TTReportField PAGECOUNT; 
                public CAPTIONGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 22, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor Nu ve Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 4, 54, 13, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Muayeneye Gönderen Makam Tarih ve Nu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 4, 92, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AÇIK KÜNYESİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 4, 126, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"GÖNDERİLEN MAKAM";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 4, 166, 13, false);
                    NewField132.Name = "NewField132";
                    NewField132.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"TEŞHİS";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 4, 255, 13, false);
                    NewField133.Name = "NewField133";
                    NewField133.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField133.WordBreak = EvetHayirEnum.ehEvet;
                    NewField133.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"KARAR";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 4, 290, 13, false);
                    NewField134.Name = "NewField134";
                    NewField134.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.MultiLine = EvetHayirEnum.ehEvet;
                    NewField134.WordBreak = EvetHayirEnum.ehEvet;
                    NewField134.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"FOTOĞRAF";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 4, 290, 4, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 13, 290, 13, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 4, 8, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 4, 22, 13, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 4, 54, 13, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 4, 92, 13, false);
                    NewLine1114.Name = "NewLine1114";
                    NewLine1114.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 4, 126, 13, false);
                    NewLine1115.Name = "NewLine1115";
                    NewLine1115.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 4, 166, 13, false);
                    NewLine1116.Name = "NewLine1116";
                    NewLine1116.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 255, 4, 255, 13, false);
                    NewLine1117.Name = "NewLine1117";
                    NewLine1117.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1118 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, 4, 290, 13, false);
                    NewLine1118.Name = "NewLine1118";
                    NewLine1118.DrawStyle = DrawStyleConstants.vbSolid;

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 5, 334, 10, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.Visible = EvetHayirEnum.ehHayir;
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"{@pagenumber@}";

                    PAGECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 337, 5, 364, 10, false);
                    PAGECOUNT.Name = "PAGECOUNT";
                    PAGECOUNT.Visible = EvetHayirEnum.ehHayir;
                    PAGECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGECOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGECOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGECOUNT.TextFont.CharSet = 162;
                    PAGECOUNT.Value = @"{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    PAGECOUNT.CalcValue = ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField1,NewField12,NewField13,NewField131,NewField132,NewField133,NewField134,PAGENUMBER,PAGECOUNT};
                }

                public override void RunScript()
                {
#region CAPTION HEADER_Script
                    //            if(((HelathCommitteeReportBook)ParentReport).RuntimeParameters.ISLASTPAGE == "False")
//                this.Visible = EvetHayirEnum.ehEvet;
//            else
//                this.Visible = EvetHayirEnum.ehHayir;
#endregion CAPTION HEADER_Script
                }
            }
            public partial class CAPTIONGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField REPORTDATE;
                public TTReportField DESCRIPTION;
                public TTReportField NewField111;
                public TTReportField SK_CHAIRMAN;
                public TTReportField SK_MEMBER1;
                public TTReportField SK_MEMBER2;
                public TTReportField SK_MEMBER3;
                public TTReportField SK_MEMBER4;
                public TTReportField SK_MEMBER5;
                public TTReportField SK_MEMBER6;
                public TTReportField SK_MEMBER7;
                public TTReportField SK_MEMBER8;
                public TTReportField SK_MEMBER9;
                public TTReportField SK_MEMBER10;
                public TTReportField SK_MEMBER11;
                public TTReportField SK_MEMBER12;
                public TTReportField SK_MEMBER13;
                public TTReportField SK_MEMBER14;
                public TTReportField SK_MEMBER15;
                public TTReportField NewField1111;
                public TTReportField COUNTOFA;
                public TTReportField NewField11111;
                public TTReportField NewField11112;
                public TTReportField NewField11113;
                public TTReportField NewField11114;
                public TTReportField COUNTOFB;
                public TTReportField COUNTOFC;
                public TTReportField COUNTOFD;
                public TTReportField COUNT;
                public TTReportField NewField11113111;
                public TTReportShape NewLine11; 
                public CAPTIONGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 121;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 19, 333, 24, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.Visible = EvetHayirEnum.ehHayir;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REPORTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORTDATE.TextFont.CharSet = 162;
                    REPORTDATE.Value = @"{@DATE@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 113, 290, 118, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{%REPORTDATE%} TARİHLİ OTURUMUN HEYET TEŞKİLİDİR.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 35, 40, 40, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Sağlık Kurulu Başkanı";

                    SK_CHAIRMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 42, 53, 59, false);
                    SK_CHAIRMAN.Name = "SK_CHAIRMAN";
                    SK_CHAIRMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_CHAIRMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SK_CHAIRMAN.TextFont.Name = "Courier New";
                    SK_CHAIRMAN.TextFont.Size = 7;
                    SK_CHAIRMAN.TextFont.CharSet = 162;
                    SK_CHAIRMAN.Value = @"";

                    SK_MEMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 42, 101, 59, false);
                    SK_MEMBER1.Name = "SK_MEMBER1";
                    SK_MEMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER1.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER1.TextFont.Name = "Courier New";
                    SK_MEMBER1.TextFont.Size = 7;
                    SK_MEMBER1.TextFont.CharSet = 162;
                    SK_MEMBER1.Value = @"";

                    SK_MEMBER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 42, 149, 59, false);
                    SK_MEMBER2.Name = "SK_MEMBER2";
                    SK_MEMBER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER2.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER2.TextFont.Name = "Courier New";
                    SK_MEMBER2.TextFont.Size = 7;
                    SK_MEMBER2.TextFont.CharSet = 162;
                    SK_MEMBER2.Value = @"";

                    SK_MEMBER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 42, 196, 59, false);
                    SK_MEMBER3.Name = "SK_MEMBER3";
                    SK_MEMBER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER3.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER3.TextFont.Name = "Courier New";
                    SK_MEMBER3.TextFont.Size = 7;
                    SK_MEMBER3.TextFont.CharSet = 162;
                    SK_MEMBER3.Value = @"";

                    SK_MEMBER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 42, 243, 59, false);
                    SK_MEMBER4.Name = "SK_MEMBER4";
                    SK_MEMBER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER4.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER4.TextFont.Name = "Courier New";
                    SK_MEMBER4.TextFont.Size = 7;
                    SK_MEMBER4.TextFont.CharSet = 162;
                    SK_MEMBER4.Value = @"";

                    SK_MEMBER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 42, 290, 59, false);
                    SK_MEMBER5.Name = "SK_MEMBER5";
                    SK_MEMBER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER5.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER5.TextFont.Name = "Courier New";
                    SK_MEMBER5.TextFont.Size = 7;
                    SK_MEMBER5.TextFont.CharSet = 162;
                    SK_MEMBER5.Value = @"";

                    SK_MEMBER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 67, 53, 84, false);
                    SK_MEMBER6.Name = "SK_MEMBER6";
                    SK_MEMBER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER6.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER6.TextFont.Name = "Courier New";
                    SK_MEMBER6.TextFont.Size = 7;
                    SK_MEMBER6.TextFont.CharSet = 162;
                    SK_MEMBER6.Value = @"";

                    SK_MEMBER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 67, 101, 84, false);
                    SK_MEMBER7.Name = "SK_MEMBER7";
                    SK_MEMBER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER7.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER7.TextFont.Name = "Courier New";
                    SK_MEMBER7.TextFont.Size = 7;
                    SK_MEMBER7.TextFont.CharSet = 162;
                    SK_MEMBER7.Value = @"";

                    SK_MEMBER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 67, 149, 84, false);
                    SK_MEMBER8.Name = "SK_MEMBER8";
                    SK_MEMBER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER8.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER8.TextFont.Name = "Courier New";
                    SK_MEMBER8.TextFont.Size = 7;
                    SK_MEMBER8.TextFont.CharSet = 162;
                    SK_MEMBER8.Value = @"";

                    SK_MEMBER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 67, 196, 84, false);
                    SK_MEMBER9.Name = "SK_MEMBER9";
                    SK_MEMBER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER9.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER9.TextFont.Name = "Courier New";
                    SK_MEMBER9.TextFont.Size = 7;
                    SK_MEMBER9.TextFont.CharSet = 162;
                    SK_MEMBER9.Value = @"";

                    SK_MEMBER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 67, 243, 84, false);
                    SK_MEMBER10.Name = "SK_MEMBER10";
                    SK_MEMBER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER10.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER10.TextFont.Name = "Courier New";
                    SK_MEMBER10.TextFont.Size = 7;
                    SK_MEMBER10.TextFont.CharSet = 162;
                    SK_MEMBER10.Value = @"";

                    SK_MEMBER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 67, 290, 84, false);
                    SK_MEMBER11.Name = "SK_MEMBER11";
                    SK_MEMBER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER11.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER11.TextFont.Name = "Courier New";
                    SK_MEMBER11.TextFont.Size = 7;
                    SK_MEMBER11.TextFont.CharSet = 162;
                    SK_MEMBER11.Value = @"";

                    SK_MEMBER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 93, 53, 110, false);
                    SK_MEMBER12.Name = "SK_MEMBER12";
                    SK_MEMBER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER12.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER12.TextFont.Name = "Courier New";
                    SK_MEMBER12.TextFont.Size = 7;
                    SK_MEMBER12.TextFont.CharSet = 162;
                    SK_MEMBER12.Value = @"";

                    SK_MEMBER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 93, 101, 110, false);
                    SK_MEMBER13.Name = "SK_MEMBER13";
                    SK_MEMBER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER13.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER13.TextFont.Name = "Courier New";
                    SK_MEMBER13.TextFont.Size = 7;
                    SK_MEMBER13.TextFont.CharSet = 162;
                    SK_MEMBER13.Value = @"";

                    SK_MEMBER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 93, 149, 110, false);
                    SK_MEMBER14.Name = "SK_MEMBER14";
                    SK_MEMBER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER14.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER14.TextFont.Name = "Courier New";
                    SK_MEMBER14.TextFont.Size = 7;
                    SK_MEMBER14.TextFont.CharSet = 162;
                    SK_MEMBER14.Value = @"";

                    SK_MEMBER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 93, 196, 110, false);
                    SK_MEMBER15.Name = "SK_MEMBER15";
                    SK_MEMBER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    SK_MEMBER15.MultiLine = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.WordBreak = EvetHayirEnum.ehEvet;
                    SK_MEMBER15.TextFont.Name = "Courier New";
                    SK_MEMBER15.TextFont.Size = 7;
                    SK_MEMBER15.TextFont.CharSet = 162;
                    SK_MEMBER15.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 27, 9, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Karar Sayıları";

                    COUNTOFA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 10, 37, 15, false);
                    COUNTOFA.Name = "COUNTOFA";
                    COUNTOFA.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTOFA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTOFA.TextFont.Size = 9;
                    COUNTOFA.TextFont.CharSet = 162;
                    COUNTOFA.Value = @"";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 13, 15, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"A :";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 13, 20, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112.TextFont.Size = 9;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"B :";

                    NewField11113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 13, 25, false);
                    NewField11113.Name = "NewField11113";
                    NewField11113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11113.TextFont.Size = 9;
                    NewField11113.TextFont.Bold = true;
                    NewField11113.TextFont.CharSet = 162;
                    NewField11113.Value = @"C :";

                    NewField11114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 25, 13, 30, false);
                    NewField11114.Name = "NewField11114";
                    NewField11114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114.TextFont.Size = 9;
                    NewField11114.TextFont.Bold = true;
                    NewField11114.TextFont.CharSet = 162;
                    NewField11114.Value = @"D :";

                    COUNTOFB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 15, 37, 20, false);
                    COUNTOFB.Name = "COUNTOFB";
                    COUNTOFB.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTOFB.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTOFB.TextFont.Size = 9;
                    COUNTOFB.TextFont.CharSet = 162;
                    COUNTOFB.Value = @"";

                    COUNTOFC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 37, 25, false);
                    COUNTOFC.Name = "COUNTOFC";
                    COUNTOFC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTOFC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTOFC.TextFont.Size = 9;
                    COUNTOFC.TextFont.CharSet = 162;
                    COUNTOFC.Value = @"";

                    COUNTOFD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 25, 37, 30, false);
                    COUNTOFD.Name = "COUNTOFD";
                    COUNTOFD.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTOFD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTOFD.TextFont.Size = 9;
                    COUNTOFD.TextFont.CharSet = 162;
                    COUNTOFD.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 4, 290, 9, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COUNT.Value = @"";

                    NewField11113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 4, 264, 9, false);
                    NewField11113111.Name = "NewField11113111";
                    NewField11113111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11113111.TextFont.Size = 8;
                    NewField11113111.TextFont.Bold = true;
                    NewField11113111.TextFont.CharSet = 162;
                    NewField11113111.Value = @"Toplam Sağlık Kurulu İşlem Sayısı :";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 220, 3, 290, 3, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTDATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    DESCRIPTION.CalcValue = MyParentReport.CAPTION.REPORTDATE.FormattedValue + @" TARİHLİ OTURUMUN HEYET TEŞKİLİDİR.";
                    NewField111.CalcValue = NewField111.Value;
                    SK_CHAIRMAN.CalcValue = @"";
                    SK_MEMBER1.CalcValue = @"";
                    SK_MEMBER2.CalcValue = @"";
                    SK_MEMBER3.CalcValue = @"";
                    SK_MEMBER4.CalcValue = @"";
                    SK_MEMBER5.CalcValue = @"";
                    SK_MEMBER6.CalcValue = @"";
                    SK_MEMBER7.CalcValue = @"";
                    SK_MEMBER8.CalcValue = @"";
                    SK_MEMBER9.CalcValue = @"";
                    SK_MEMBER10.CalcValue = @"";
                    SK_MEMBER11.CalcValue = @"";
                    SK_MEMBER12.CalcValue = @"";
                    SK_MEMBER13.CalcValue = @"";
                    SK_MEMBER14.CalcValue = @"";
                    SK_MEMBER15.CalcValue = @"";
                    NewField1111.CalcValue = NewField1111.Value;
                    COUNTOFA.CalcValue = @"";
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField11113.CalcValue = NewField11113.Value;
                    NewField11114.CalcValue = NewField11114.Value;
                    COUNTOFB.CalcValue = @"";
                    COUNTOFC.CalcValue = @"";
                    COUNTOFD.CalcValue = @"";
                    COUNT.CalcValue = @"";
                    NewField11113111.CalcValue = NewField11113111.Value;
                    return new TTReportObject[] { REPORTDATE,DESCRIPTION,NewField111,SK_CHAIRMAN,SK_MEMBER1,SK_MEMBER2,SK_MEMBER3,SK_MEMBER4,SK_MEMBER5,SK_MEMBER6,SK_MEMBER7,SK_MEMBER8,SK_MEMBER9,SK_MEMBER10,SK_MEMBER11,SK_MEMBER12,SK_MEMBER13,SK_MEMBER14,SK_MEMBER15,NewField1111,COUNTOFA,NewField11111,NewField11112,NewField11113,NewField11114,COUNTOFB,COUNTOFC,COUNTOFD,COUNT,NewField11113111};
                }

                public override void RunScript()
                {
#region CAPTION FOOTER_Script
                    this.COUNT.CalcValue = ((HealthCommitteeReportBook_A4)ParentReport).groupCounter.ToString();                                                                                                   
            // Toplam madde/dilim/fıkra sayıları set edilir ve sıfırlanır(rapor refresh edilince üzerine eklemesin)
            this.COUNTOFA.CalcValue = ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfA.ToString();
            this.COUNTOFB.CalcValue = ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfB.ToString();
            this.COUNTOFC.CalcValue = ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfC.ToString();
            this.COUNTOFD.CalcValue = ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfD.ToString();
            
            ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfA = 0;
            ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfB = 0;
            ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfC = 0;
            ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfD = 0;
            
            TTObjectContext context = new TTObjectContext(true);
            HealthCommitteeTypeEnum committeeType = HealthCommitteeTypeEnum.NormalCommittee;
            
            if (((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE != null)
                committeeType = (HealthCommitteeTypeEnum)((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.HEALTHCOMITEETYPE;
            
            //IList<MemberOfHealthCommitteeDefinition> currentDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetTodaysMemberDefinition(context, Convert.ToDateTime(((HealthCommitteeReportBook_A4)ParentReport).RuntimeParameters.STARTDATE), HealthCommitteeTypeEnum.NormalCommittee);
            IList<MemberOfHealthCommitteeDefinition> currentDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetMemberDefinitions(context);
            
            if(currentDefs.Count > 0)
            {
                MemberOfHealthCommitteeDefinition memberDef = currentDefs[0];

                if(memberDef != null)
                {
                    string sCrLf = "\r\n";
                    string sMembersText = sCrLf;
                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId = "", sMemberSpeciality = "";


                    //Signatures

                    //Chairman
                    if (memberDef.MasterOfHealthCommittee2 != null)
                    {
                        string chairmanName = memberDef.MasterOfHealthCommittee2.Name;
                        string chairmanMilClass = memberDef.MasterOfHealthCommittee2.MilitaryClass == null ? "" : memberDef.MasterOfHealthCommittee2.MilitaryClass.ShortName;
                        string chairmanRank = memberDef.MasterOfHealthCommittee2.Rank == null ? "" : memberDef.MasterOfHealthCommittee2.Rank.ShortName;
                        string chairmanTitle = !memberDef.MasterOfHealthCommittee2.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(memberDef.MasterOfHealthCommittee2.Title.Value);
                        string chairmanRecId = memberDef.MasterOfHealthCommittee2.EmploymentRecordID == null ? "" : memberDef.MasterOfHealthCommittee2.EmploymentRecordID;
                        string chairmanMainSpeciality = "";
                        string chairmanSpecialities = "";
                        for (int s = 0; s < memberDef.MasterOfHealthCommittee2.ResourceSpecialities.Count; s++)
                            if (memberDef.MasterOfHealthCommittee2.ResourceSpecialities[s].MainSpeciality.Equals(true))
                                chairmanMainSpeciality += memberDef.MasterOfHealthCommittee2.ResourceSpecialities[s].Speciality.Name+" Uzm.";
                            else
                                chairmanSpecialities += memberDef.MasterOfHealthCommittee2.ResourceSpecialities[s].Speciality.Name + " Uzm.\r\n";

                        //if (chairmanSpecialities != "") chairmanSpecialities += " Uzm.";
                        //else if (chairmanMainSpeciality != "") chairmanMainSpeciality += " Uzm.";

                        this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanTitle + chairmanRank + "(" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
                        //this.SK_CHAIRMAN.CalcValue = chairmanName + "\r\n" + chairmanMilClass + chairmanTitle + chairmanRank + "(" + chairmanRecId + ")" + "\r\n" + chairmanMainSpeciality + "\r\n" + chairmanSpecialities;
                    }


                    foreach (HealthCommitteMemberGrid pMember in memberDef.Members)
                    {
                        if (pMember.Doctor != null)
                        {
                            string memberName = pMember.Doctor.Name;
                            string memberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
                            string memberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
                            string memberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
                            string memberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
                            string memberMainSpeciality = "";
                            string memberSpecialities = "";
                            for (int s = 0; s < pMember.Doctor.ResourceSpecialities.Count; s++)
                                if (pMember.Doctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
                                    memberMainSpeciality += pMember.Doctor.ResourceSpecialities[s].Speciality.Name+" Uzm.";
                                else
                                    memberSpecialities += pMember.Doctor.ResourceSpecialities[s].Speciality.Name + " Uzm.\r\n";
                            
                            string sigText = memberName + "\r\n" + memberTitle + memberRank + "(" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
                            //string sigText = memberName + "\r\n" + memberMilClass + memberTitle + memberRank + "(" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;

                            if (this.SK_MEMBER1.CalcValue.Length == 0) this.SK_MEMBER1.CalcValue = sigText;
                            else if (this.SK_MEMBER2.CalcValue.Length == 0) this.SK_MEMBER2.CalcValue = sigText;
                            else if (this.SK_MEMBER3.CalcValue.Length == 0) this.SK_MEMBER3.CalcValue = sigText;
                            else if (this.SK_MEMBER4.CalcValue.Length == 0) this.SK_MEMBER4.CalcValue = sigText;
                            else if (this.SK_MEMBER5.CalcValue.Length == 0) this.SK_MEMBER5.CalcValue = sigText;
                            else if (this.SK_MEMBER6.CalcValue.Length == 0) this.SK_MEMBER6.CalcValue = sigText;
                            else if (this.SK_MEMBER7.CalcValue.Length == 0) this.SK_MEMBER7.CalcValue = sigText;
                            else if (this.SK_MEMBER8.CalcValue.Length == 0) this.SK_MEMBER8.CalcValue = sigText;
                            else if (this.SK_MEMBER9.CalcValue.Length == 0) this.SK_MEMBER9.CalcValue = sigText;
                            else if (this.SK_MEMBER10.CalcValue.Length == 0) this.SK_MEMBER10.CalcValue = sigText;
                            else if (this.SK_MEMBER11.CalcValue.Length == 0) this.SK_MEMBER11.CalcValue = sigText;
                            else if (this.SK_MEMBER12.CalcValue.Length == 0) this.SK_MEMBER12.CalcValue = sigText;
                            else if (this.SK_MEMBER13.CalcValue.Length == 0) this.SK_MEMBER13.CalcValue = sigText;
                            else if (this.SK_MEMBER14.CalcValue.Length == 0) this.SK_MEMBER14.CalcValue = sigText;
                            else if (this.SK_MEMBER15.CalcValue.Length == 0) this.SK_MEMBER15.CalcValue = sigText;
                        }
                    }

                    /*
                     * old text area signatures changed by ET @ 21.03.2012
                     * 
                    const int COLUMN_COUNT = 4;
                    const int SPACE_COUNT = 31;
                    const int SPECIALITY_COUNT = 29;
                    int nCounter = 0;
                    int nRow = 0;
                    bool writeSKChairman = false;
                    
                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    int nRate;
                    
                    // SK Başkanı Yazılır
                    if (memberDef.MasterOfHealthCommittee2 != null)
                    {
                        sMemberName = memberDef.MasterOfHealthCommittee2.Name;
                        sMemberMilClass = memberDef.MasterOfHealthCommittee2.MilitaryClass == null ? "" : memberDef.MasterOfHealthCommittee2.MilitaryClass.ShortName;
                        sMemberRank = memberDef.MasterOfHealthCommittee2.Rank == null ? "" : memberDef.MasterOfHealthCommittee2.Rank.ShortName;
                        sMemberTitle = !memberDef.MasterOfHealthCommittee2.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(memberDef.MasterOfHealthCommittee2.Title.Value);
                        sMemberRecId = memberDef.MasterOfHealthCommittee2.EmploymentRecordID == null ? "" : memberDef.MasterOfHealthCommittee2.EmploymentRecordID;
                        
                        if (memberDef.MasterOfHealthCommittee2.GetSpeciality() != null)
                            sMemberSpeciality = memberDef.MasterOfHealthCommittee2.GetSpeciality().Name;
                        
                        sNameRow = sNameRow.Insert(nCounter, sMemberName);
                        //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberTitle + " " + sMemberRank);
                        //sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                        sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                        //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
                        if (sMemberSpeciality != "")
                        {
                            sMemberSpeciality += " Uzm.";
                            if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                            {
                                if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
                                    sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
                                
                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
                                sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
                            }
                            else
                            {
                                sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                            }
                        }
                        else
                        {
                            sTitleRow = sTitleRow.Insert(nCounter, "");
                            sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                        }
                        
                        nCounter += SPACE_COUNT;
                        
                        nRow = nCounter / SPACE_COUNT;
                        nRate = nRow % COLUMN_COUNT;
                        if (nRate == 0)
                        {
                            sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sNameRow + "\r\n";
                            sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sRankRow + "\r\n";
                            sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sTitleRow + "\r\n";
                            sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
                            sMembersText += sSpecialityRow + "\r\n";

                            sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                            sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                            sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                            sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                            sMembersText +=  sCrLf + sCrLf;
                            nCounter = 0;
                        }
                    }
                    
                    foreach(HealthCommitteMemberGrid pMember in memberDef.Members)
                    {
                        if (pMember.Doctor != null)
                        {
                            sMemberName = pMember.Doctor.Name;
                            sMemberMilClass = pMember.Doctor.MilitaryClass == null ? "" : pMember.Doctor.MilitaryClass.ShortName;
                            sMemberRank = pMember.Doctor.Rank == null ? "" : pMember.Doctor.Rank.ShortName;
                            sMemberTitle = !pMember.Doctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pMember.Doctor.Title.Value);
                            sMemberRecId = pMember.Doctor.EmploymentRecordID == null ? "" : pMember.Doctor.EmploymentRecordID;
                            
                            if (pMember.Doctor.GetSpeciality() != null)
                                sMemberSpeciality = pMember.Doctor.GetSpeciality().Name;
                            else
                                sMemberSpeciality = "";
                            
                            sNameRow = sNameRow.Insert(nCounter, sMemberName);
                            //sRankRow = sRankRow.Insert(nCounter, sMemberMilClass + " " + sMemberTitle  + " " + sMemberRank);
                            //sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                            sRankRow = sRankRow.Insert(nCounter, sMemberTitle + sMemberRank + "(" + sMemberRecId + ")");
                            //sTitleRow = sTitleRow.Insert(nCounter, "(" + sMemberRecId + ")");
                            //sSpecialityRow = sSpecialityRow.Insert(nCounter,  sMemberSpeciality + " Uzm.");

                            if (sMemberSpeciality != "")
                            {
                                sMemberSpeciality += " Uzm.";
                                if (sMemberSpeciality.Length > SPECIALITY_COUNT)
                                {
                                    if (sMemberSpeciality.Length > SPECIALITY_COUNT*2)
                                        sMemberSpeciality = sMemberSpeciality.Substring(0,SPECIALITY_COUNT*2);
                                    
                                    sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality.Substring(0,SPECIALITY_COUNT));
                                    sSpecialityRow = sSpecialityRow.Insert(nCounter, sMemberSpeciality.Substring(SPECIALITY_COUNT,sMemberSpeciality.Length-SPECIALITY_COUNT));
                                }
                                else
                                {
                                    sTitleRow = sTitleRow.Insert(nCounter, sMemberSpeciality);
                                    sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                                }
                            }
                            else
                            {
                                sTitleRow = sTitleRow.Insert(nCounter, "");
                                sSpecialityRow = sSpecialityRow.Insert(nCounter, "");
                            }
                            
                            nCounter += SPACE_COUNT;

                            nRow = nCounter / SPACE_COUNT;
                            nRate = nRow % COLUMN_COUNT;
                            if (nRate == 0)
                            {
                                sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                                sMembersText += sNameRow + "\r\n";
                                sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                                sMembersText += sRankRow + "\r\n";
                                sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                                sMembersText += sTitleRow + "\r\n";
                                sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
                                sMembersText += sSpecialityRow + "\r\n";

                                sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                                sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                                sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                                sSpecialityRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                                sMembersText +=  sCrLf + sCrLf;
                                nCounter = 0;
                            }
                        }
                    }
                    
                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sNameRow + "\r\n";
                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sRankRow + "\r\n";
                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sTitleRow + "\r\n";
                    sSpecialityRow = sSpecialityRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sSpecialityRow + "\r\n";
                    
                    this.MEMBERS.CalcValue = sMembersText;

                     */
                }
                
            }
#endregion CAPTION FOOTER_Script
                }
            }

        }

        public CAPTIONGroup CAPTION;

        public partial class PARTCGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1211 { get {return Footer().NewLine1211;} }
            public TTReportShape NewLine12111 { get {return Footer().NewLine12111;} }
            public TTReportShape NewLine12121 { get {return Footer().NewLine12121;} }
            public TTReportShape NewLine12131 { get {return Footer().NewLine12131;} }
            public TTReportShape NewLine12141 { get {return Footer().NewLine12141;} }
            public TTReportShape NewLine12151 { get {return Footer().NewLine12151;} }
            public TTReportShape NewLine12161 { get {return Footer().NewLine12161;} }
            public TTReportShape NewLine116121 { get {return Footer().NewLine116121;} }
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
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine12111;
                public TTReportShape NewLine12121;
                public TTReportShape NewLine12131;
                public TTReportShape NewLine12141;
                public TTReportShape NewLine12151;
                public TTReportShape NewLine12161;
                public TTReportShape NewLine116121; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 2, 290, 2, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 2, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 0, 22, 2, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 0, 54, 2, false);
                    NewLine12121.Name = "NewLine12121";
                    NewLine12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 0, 92, 2, false);
                    NewLine12131.Name = "NewLine12131";
                    NewLine12131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 0, 126, 2, false);
                    NewLine12141.Name = "NewLine12141";
                    NewLine12141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 2, false);
                    NewLine12151.Name = "NewLine12151";
                    NewLine12151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12151.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 255, 0, 255, 2, false);
                    NewLine12161.Name = "NewLine12161";
                    NewLine12161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine116121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, 0, 290, 2, false);
                    NewLine116121.Name = "NewLine116121";
                    NewLine116121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine116121.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COUNTER { get {return Header().COUNTER;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetHealthCommitteesByType_Class>("GetHealthCommitteesByType", HealthCommittee.GetHealthCommitteesByType((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((HealthCommitteeTypeEnum)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.HEALTHCOMITEETYPE.ToString()].EnumValue),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHCOMITEETYPEFLAG),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField COUNTER; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 0, 334, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.Visible = EvetHayirEnum.ehHayir;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteesByType_Class dataset_GetHealthCommitteesByType = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteesByType_Class>(0);
                    COUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { COUNTER};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    ((HealthCommitteeReportBook_A4)ParentReport).groupCounter = Convert.ToInt16(this.COUNTER.CalcValue);
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REPORTNODATE { get {return Body().REPORTNODATE;} }
            public TTReportField SENDERDATENO { get {return Body().SENDERDATENO;} }
            public TTReportField INFOS { get {return Body().INFOS;} }
            public TTReportField GONDERILEN { get {return Body().GONDERILEN;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField FOTO { get {return Body().FOTO;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField XXXXXXLIKSUBESI { get {return Body().XXXXXXLIKSUBESI;} }
            public TTReportField PNAME { get {return Body().PNAME;} }
            public TTReportField PSURNAME { get {return Body().PSURNAME;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField KILO { get {return Body().KILO;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine113 { get {return Body().NewLine113;} }
            public TTReportShape NewLine114 { get {return Body().NewLine114;} }
            public TTReportShape NewLine115 { get {return Body().NewLine115;} }
            public TTReportShape NewLine116 { get {return Body().NewLine116;} }
            public TTReportShape NewLine117 { get {return Body().NewLine117;} }
            public TTReportShape NewLine111211 { get {return Body().NewLine111211;} }
            public TTReportField SKSEBEBI { get {return Body().SKSEBEBI;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
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
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField REPORTNODATE;
                public TTReportField SENDERDATENO;
                public TTReportField INFOS;
                public TTReportField GONDERILEN;
                public TTReportField TESHIS;
                public TTReportField KARAR;
                public TTReportField FOTO;
                public TTReportField OBJECTID;
                public TTReportField REPORTDATE;
                public TTReportField DTARIHI;
                public TTReportField MADDE;
                public TTReportField XXXXXXLIKSUBESI;
                public TTReportField PNAME;
                public TTReportField PSURNAME;
                public TTReportField TCNO;
                public TTReportField FATHERNAME;
                public TTReportField BOY;
                public TTReportField KILO;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine113;
                public TTReportShape NewLine114;
                public TTReportShape NewLine115;
                public TTReportShape NewLine116;
                public TTReportShape NewLine117;
                public TTReportShape NewLine111211;
                public TTReportField SKSEBEBI;
                public TTReportField DECISIONTIME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 42;
                    RepeatCount = 0;
                    
                    REPORTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 22, 42, false);
                    REPORTNODATE.Name = "REPORTNODATE";
                    REPORTNODATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNODATE.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNODATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNODATE.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNODATE.TextFont.Size = 9;
                    REPORTNODATE.TextFont.CharSet = 162;
                    REPORTNODATE.Value = @"{#PARTB.RAPORNO#}";

                    SENDERDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 54, 42, false);
                    SENDERDATENO.Name = "SENDERDATENO";
                    SENDERDATENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERDATENO.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERDATENO.NoClip = EvetHayirEnum.ehEvet;
                    SENDERDATENO.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERDATENO.TextFont.Size = 9;
                    SENDERDATENO.TextFont.CharSet = 162;
                    SENDERDATENO.Value = @"";

                    INFOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 92, 42, false);
                    INFOS.Name = "INFOS";
                    INFOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOS.MultiLine = EvetHayirEnum.ehEvet;
                    INFOS.NoClip = EvetHayirEnum.ehEvet;
                    INFOS.WordBreak = EvetHayirEnum.ehEvet;
                    INFOS.TextFont.Size = 9;
                    INFOS.TextFont.CharSet = 162;
                    INFOS.Value = @"";

                    GONDERILEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 0, 126, 42, false);
                    GONDERILEN.Name = "GONDERILEN";
                    GONDERILEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILEN.MultiLine = EvetHayirEnum.ehEvet;
                    GONDERILEN.NoClip = EvetHayirEnum.ehEvet;
                    GONDERILEN.WordBreak = EvetHayirEnum.ehEvet;
                    GONDERILEN.TextFont.Size = 9;
                    GONDERILEN.TextFont.CharSet = 162;
                    GONDERILEN.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 0, 166, 42, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.NoClip = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Size = 9;
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 255, 42, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 0, 290, 42, false);
                    FOTO.Name = "FOTO";
                    FOTO.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOTO.TextFont.Size = 9;
                    FOTO.TextFont.CharSet = 162;
                    FOTO.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 18, 333, 23, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#PARTB.HEALTHCOMMITTEEOBJECTID#}";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 24, 333, 29, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.Visible = EvetHayirEnum.ehHayir;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.Value = @"{#PARTB.RAPORTARIHI#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 30, 333, 35, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#PARTB.DTARIHI#}";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 36, 333, 41, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.Value = @"";

                    XXXXXXLIKSUBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 12, 333, 17, false);
                    XXXXXXLIKSUBESI.Name = "XXXXXXLIKSUBESI";
                    XXXXXXLIKSUBESI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXLIKSUBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBESI.Value = @"";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 3, 366, 8, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.Value = @"{#PARTB.PNAME#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 11, 366, 16, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.Value = @"{#PARTB.PSURNAME#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 19, 366, 24, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.Value = @"{#PARTB.TCNO#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 28, 366, 33, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.Visible = EvetHayirEnum.ehHayir;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#PARTB.FATHERNAME#}";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 36, 366, 41, false);
                    BOY.Name = "BOY";
                    BOY.Visible = EvetHayirEnum.ehHayir;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.Value = @"{#PARTB.BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 375, 3, 400, 8, false);
                    KILO.Name = "KILO";
                    KILO.Visible = EvetHayirEnum.ehHayir;
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.Value = @"{#PARTB.KILO#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 42, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 0, 22, 42, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 0, 54, 42, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 0, 92, 42, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 0, 126, 42, false);
                    NewLine114.Name = "NewLine114";
                    NewLine114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 42, false);
                    NewLine115.Name = "NewLine115";
                    NewLine115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine115.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 255, 0, 255, 42, false);
                    NewLine116.Name = "NewLine116";
                    NewLine116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine116.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, 0, 290, 42, false);
                    NewLine117.Name = "NewLine117";
                    NewLine117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine117.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 290, 0, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                    SKSEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 375, 36, 400, 41, false);
                    SKSEBEBI.Name = "SKSEBEBI";
                    SKSEBEBI.Visible = EvetHayirEnum.ehHayir;
                    SKSEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKSEBEBI.Value = @"{#PARTB.SKSEBEBI#}";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 4, 333, 9, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteesByType_Class dataset_GetHealthCommitteesByType = MyParentReport.PARTB.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteesByType_Class>(0);
                    REPORTNODATE.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Raporno) : "");
                    SENDERDATENO.CalcValue = @"";
                    INFOS.CalcValue = @"";
                    GONDERILEN.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    FOTO.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Healthcommitteeobjectid) : "");
                    REPORTDATE.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Raportarihi) : "");
                    DTARIHI.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Dtarihi) : "");
                    MADDE.CalcValue = @"";
                    XXXXXXLIKSUBESI.CalcValue = @"";
                    PNAME.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Pname) : "");
                    PSURNAME.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Psurname) : "");
                    TCNO.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Tcno) : "");
                    FATHERNAME.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.FatherName) : "");
                    BOY.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Boy) : "");
                    KILO.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Kilo) : "");
                    SKSEBEBI.CalcValue = (dataset_GetHealthCommitteesByType != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByType.Sksebebi) : "");
                    DECISIONTIME.CalcValue = @"";
                    return new TTReportObject[] { REPORTNODATE,SENDERDATENO,INFOS,GONDERILEN,TESHIS,KARAR,FOTO,OBJECTID,REPORTDATE,DTARIHI,MADDE,XXXXXXLIKSUBESI,PNAME,PSURNAME,TCNO,FATHERNAME,BOY,KILO,SKSEBEBI,DECISIONTIME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            string sObjectID = this.OBJECTID.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
//            
//            if(hc == null)
//                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommittee is null");
//            
////            string dogumUlke = this.DYERULKE.CalcValue;
////            string dogumIl = this.DYERIL.CalcValue;
////            string dogumIlce = this.DYERILCE.CalcValue;
////            string dogumYeri = "";
////            
////            if (dogumIlce.Trim() != "" )
////            {
////                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
////                    dogumYeri = dogumIlce;
////                else
////                    dogumYeri = dogumIl;
////            }
////            else if (dogumIl.Trim() != "")
////                dogumYeri = dogumIl;
////            else
////                dogumYeri = dogumUlke;
//            
//            this.INFOS.CalcValue = this.PNAME.CalcValue + " " + this.PSURNAME.CalcValue + "\r\n";
//            this.INFOS.CalcValue += "Doğum Tarihi: " + this.DTARIHI.FormattedValue + "\r\n";
//            this.INFOS.CalcValue += "Doğum Yeri: " + dogumYeri + "\r\n";
//            this.INFOS.CalcValue += "T.C. No: " + this.TCNO.CalcValue + "\r\n";
//            this.INFOS.CalcValue += "Baba Adı: " + this.FATHERNAME.CalcValue + "\r\n";
//            this.INFOS.CalcValue += "Boy: " + this.BOY.CalcValue + "\r\n";
//            this.INFOS.CalcValue += "Ağırlık: " + this.KILO.CalcValue + "\r\n";
//            
//            
//            // Windesk No : INC016453
//            
//            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
//            //            RankDefinitions pRank = hc.Episode.Rank;
////
//            //            string force = hc.Episode.ForcesCommand != null ? hc.Episode.ForcesCommand.Qref : "";
//            //            string milClassAndRank = string.Empty;
////
//            //            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
//            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
//            //                milClassAndRank = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
//            //            else
//            //                milClassAndRank = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
////
//            //            if (hc.Episode.MyRelationship() != null)
//            //            {
//            //                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
//            //                    milClassAndRank += " (" + hc.Episode.MyRelationship().Relationship + ")";
//            //            }
//            
//            //            this.INFOS.CalcValue += "Kuvvet: " + force + "\r\n";
//            //            this.INFOS.CalcValue += "Sınıf-Rütbe: " + milClassAndRank + "\r\n";
//            //            if(hc.MemberOfHealthCommittee.CommitteeType != HealthCommitteeTypeEnum.FlierCommittee)
//            //                this.INFOS.CalcValue += "As. Şubesi: " + this.XXXXXXLIKSUBESI.CalcValue + "\r\n";
//            
//            //Tanı
////            int nCount = 1;
////            IList diagnosisCodeList = new List<string>();
////            this.TESHIS.CalcValue = "";
////            
////            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
////            {
////                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
////                {
////                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
////                    {
////                        this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
////                        if (pGrid.FreeDiagnosis != null)
////                            this.TESHIS.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
////                        this.TESHIS.CalcValue += "\r\n";
////                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
////                        nCount++;
////                    }
////                }
////            }
////            
////            //Karar
////            this.KARAR.CalcValue = "Muayene Sebebi : ";
////            this.KARAR.CalcValue += this.SKSEBEBI.CalcValue + "\r\n\r\n";
////            
////            this.KARAR.CalcValue += "Karar : ";
////            if(hc.HealthCommitteeDecision != null )
////            {
////                if(hc.HCDecisionTime != null)
////                {
////                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
////                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
////                }
////                
////                if(hc.HCDecisionUnitOfTime != null)
////                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
////                
////                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\n";
////            }
////            
////            
////            //Madde-Dilim-Fıkra
////            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
////            if (theAnectodes.Count > 0)
////            {
////                this.MADDE.CalcValue = "[";
////                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
////                {
////                    this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
////                    this.MADDE.CalcValue += "  ";
////                    
////                    if(theAnectode.Dilim == SliceEnum.A)
////                        ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfA++;
////                    else if(theAnectode.Dilim == SliceEnum.B)
////                        ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfB++;
////                    else if(theAnectode.Dilim == SliceEnum.C)
////                        ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfC++;
////                    else if(theAnectode.Dilim == SliceEnum.D)
////                        ((TTReportClasses.HealthCommitteeReportBook_A4)ParentReport).countOfD++;
////                }
////                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
////                this.MADDE.CalcValue += "]";
////                
////                this.KARAR.CalcValue = this.KARAR.CalcValue + "\r\n" + this.MADDE.CalcValue;
////            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTFGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class>("GetHCAdditionalReportByDate", HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.HEALTHCOMITEETYPEFLAG),((HealthCommitteeTypeEnum)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.HEALTHCOMITEETYPE.ToString()].EnumValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTDGroup : TTReportGroup
        {
            public HealthCommitteeReportBook_A4 MyParentReport
            {
                get { return (HealthCommitteeReportBook_A4)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField REPORTNODATE { get {return Body().REPORTNODATE;} }
            public TTReportField SENDERDATENO { get {return Body().SENDERDATENO;} }
            public TTReportField INFOS { get {return Body().INFOS;} }
            public TTReportField GONDERILEN { get {return Body().GONDERILEN;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField FOTO { get {return Body().FOTO;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine1211 { get {return Body().NewLine1211;} }
            public TTReportShape NewLine1311 { get {return Body().NewLine1311;} }
            public TTReportShape NewLine1411 { get {return Body().NewLine1411;} }
            public TTReportShape NewLine1511 { get {return Body().NewLine1511;} }
            public TTReportShape NewLine1611 { get {return Body().NewLine1611;} }
            public TTReportShape NewLine1711 { get {return Body().NewLine1711;} }
            public TTReportShape NewLine1112111 { get {return Body().NewLine1112111;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public HealthCommitteeReportBook_A4 MyParentReport
                {
                    get { return (HealthCommitteeReportBook_A4)ParentReport; }
                }
                
                public TTReportField REPORTNODATE;
                public TTReportField SENDERDATENO;
                public TTReportField INFOS;
                public TTReportField GONDERILEN;
                public TTReportField TESHIS;
                public TTReportField KARAR;
                public TTReportField FOTO;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine1311;
                public TTReportShape NewLine1411;
                public TTReportShape NewLine1511;
                public TTReportShape NewLine1611;
                public TTReportShape NewLine1711;
                public TTReportShape NewLine1112111;
                public TTReportField OBJECTID; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 37;
                    RepeatCount = 0;
                    
                    REPORTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 22, 42, false);
                    REPORTNODATE.Name = "REPORTNODATE";
                    REPORTNODATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNODATE.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNODATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNODATE.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNODATE.TextFont.Size = 9;
                    REPORTNODATE.TextFont.CharSet = 162;
                    REPORTNODATE.Value = @"";

                    SENDERDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 54, 42, false);
                    SENDERDATENO.Name = "SENDERDATENO";
                    SENDERDATENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERDATENO.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERDATENO.NoClip = EvetHayirEnum.ehEvet;
                    SENDERDATENO.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERDATENO.TextFont.Size = 9;
                    SENDERDATENO.TextFont.CharSet = 162;
                    SENDERDATENO.Value = @"";

                    INFOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 92, 42, false);
                    INFOS.Name = "INFOS";
                    INFOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOS.MultiLine = EvetHayirEnum.ehEvet;
                    INFOS.NoClip = EvetHayirEnum.ehEvet;
                    INFOS.WordBreak = EvetHayirEnum.ehEvet;
                    INFOS.TextFont.Size = 9;
                    INFOS.TextFont.CharSet = 162;
                    INFOS.Value = @"";

                    GONDERILEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 0, 126, 42, false);
                    GONDERILEN.Name = "GONDERILEN";
                    GONDERILEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILEN.MultiLine = EvetHayirEnum.ehEvet;
                    GONDERILEN.NoClip = EvetHayirEnum.ehEvet;
                    GONDERILEN.WordBreak = EvetHayirEnum.ehEvet;
                    GONDERILEN.TextFont.Size = 9;
                    GONDERILEN.TextFont.CharSet = 162;
                    GONDERILEN.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 0, 166, 42, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.NoClip = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Size = 9;
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 255, 42, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 0, 290, 42, false);
                    FOTO.Name = "FOTO";
                    FOTO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOTO.TextFont.Size = 9;
                    FOTO.TextFont.CharSet = 162;
                    FOTO.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 42, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 22, 0, 22, 42, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 54, 0, 54, 42, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 0, 92, 42, false);
                    NewLine1311.Name = "NewLine1311";
                    NewLine1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 0, 126, 42, false);
                    NewLine1411.Name = "NewLine1411";
                    NewLine1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1411.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 42, false);
                    NewLine1511.Name = "NewLine1511";
                    NewLine1511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1511.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1611 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 255, 0, 255, 42, false);
                    NewLine1611.Name = "NewLine1611";
                    NewLine1611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1611.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, 0, 290, 42, false);
                    NewLine1711.Name = "NewLine1711";
                    NewLine1711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1711.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 290, 0, false);
                    NewLine1112111.Name = "NewLine1112111";
                    NewLine1112111.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 4, 333, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#PARTF.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class dataset_GetHCAdditionalReportByDate = MyParentReport.PARTF.rsGroup.GetCurrentRecord<HealthCommitteeAdditionalReport.GetHCAdditionalReportByDate_Class>(0);
                    REPORTNODATE.CalcValue = @"";
                    SENDERDATENO.CalcValue = @"";
                    INFOS.CalcValue = @"";
                    GONDERILEN.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    FOTO.CalcValue = FOTO.Value;
                    OBJECTID.CalcValue = (dataset_GetHCAdditionalReportByDate != null ? Globals.ToStringCore(dataset_GetHCAdditionalReportByDate.ObjectID) : "");
                    return new TTReportObject[] { REPORTNODATE,SENDERDATENO,INFOS,GONDERILEN,TESHIS,KARAR,FOTO,OBJECTID};
                }

                public override void RunScript()
                {
#region PARTD BODY_Script
                    //                                                                                    string sObjectID = this.OBJECTID.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HealthCommitteeAdditionalReport hca = (HealthCommitteeAdditionalReport)context.GetObject(new Guid(sObjectID),"HealthCommitteeAdditionalReport");
//            EpisodeAction ea = (EpisodeAction)context.GetObject(new Guid(sObjectID),"EpisodeAction");
//            this.REPORTNODATE.CalcValue = hca.ReportNo.ToString() +"\r\n"+hca.ReportDate.Value.Date.ToShortDateString() + "\r\n" + TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hca.ReportType.Value);
//           // this.SENDERDATENO.CalcValue = ea.Episode.SenderChair == null ? "" : ea.Episode.SenderChair.Name;
//            
//            
//            string dogumUlke = ea.Episode.Patient.CountryOfBirth == null ? "" : ea.Episode.Patient.CountryOfBirth.Name;
//            string dogumIl = ea.Episode.Patient.CityOfBirth == null ? "" : ea.Episode.Patient.CityOfBirth.Name;
//            string dogumIlce = ea.Episode.Patient.TownOfBirth == null ? "" : ea.Episode.Patient.TownOfBirth.Name;
//            string dogumYeri = "";
//            if (dogumIlce.Trim() != "" )
//            {
//                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
//                    dogumYeri = dogumIlce;
//                else
//                    dogumYeri = dogumIl;
//            }
//            else if (dogumIl.Trim() != "")
//                dogumYeri = dogumIl;
//            else
//                dogumYeri = dogumUlke;
//            
//            this.INFOS.CalcValue = ea.Episode.Patient.Name + " " + ea.Episode.Patient.Surname + "\r\n";
//            this.INFOS.CalcValue += "Doğum Tarihi: " + ea.Episode.Patient.BirthDate.Value.Date.ToShortDateString() + "\r\n";
//            this.INFOS.CalcValue += "Doğum Yeri: " + dogumYeri + "\r\n";
//            this.INFOS.CalcValue += "T.C. No: " + ea.Episode.Patient.UniqueRefNo + "\r\n";
//            this.INFOS.CalcValue += "Baba Adı: " + ea.Episode.Patient.FatherName + "\r\n";
//            
//            
//            // Windesk No : INC016453
//            
////            MilitaryClassDefinitions pMilClass = ea.Episode.MilitaryClass;
////            RankDefinitions pRank = ea.Episode.Rank;
////            
////            string force = ea.Episode.ForcesCommand != null ? ea.Episode.ForcesCommand.Qref : "";
////            string milClassAndRank = string.Empty;
////            
////            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
////            if (ea.Episode.MilitaryClass == null && ea.Episode.Rank == null)
////                milClassAndRank = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(ea.Episode.PatientGroup.Value);
////            else
////                milClassAndRank = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
////            
////            if (ea.Episode.MyRelationship() != null)
////            {
////                if (ea.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && ea.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
////                    milClassAndRank += " (" + ea.Episode.MyRelationship().Relationship + ")";
////            }
////            
//            
//            
////            if(hca.IsOtherHospitalHC != null && hca.IsOtherHospitalHC.Value == true)
////            {
////                
////                this.INFOS.CalcValue += "Boy: " + ea.Episode.Patient.Heigth + "\r\n";
////                this.INFOS.CalcValue += "Ağırlık: " + ea.Episode.Patient.Weight + "\r\n";
////                this.INFOS.CalcValue += "Kuvvet: " + force + "\r\n";
////                this.INFOS.CalcValue += "Sınıf-Rütbe: " + milClassAndRank + "\r\n";
////                if(hca.HCCommitteeType != HealthCommitteeTypeEnum.FlierCommittee)
////                {
////                    this.INFOS.CalcValue += "As. Şubesi: ";
////                    this.INFOS.CalcValue += ea.Episode.MilitaryOffice == null ? "" : ea.Episode.MilitaryOffice.Name + "\r\n";
////                }
////                this.KARAR.CalcValue = "Sağlık Kurulu Rapor Tarihi: " + hca.HCDate.Value.Date.ToShortDateString() + "\nSağlık Kurulu Rapor No: " + hca.HCReportNo + "\n";
////                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hca.Report.ToString());
////            }
////            else
////            {
////                
////                this.INFOS.CalcValue += "Boy: " + hca.HealthCommittee.ClinicHeight + "\r\n";
////                this.INFOS.CalcValue += "Ağırlık: " + hca.HealthCommittee.ClinicWeight + "\r\n";
////                this.INFOS.CalcValue += "Kuvvet: " + force + "\r\n";
////                this.INFOS.CalcValue += "Sınıf-Rütbe: " + milClassAndRank + "\r\n";
////                if(hca.HealthCommittee.MemberOfHealthCommittee.CommitteeType != HealthCommitteeTypeEnum.FlierCommittee)
////                {
////                    this.INFOS.CalcValue += "As. Şubesi: ";
////                    this.INFOS.CalcValue += ea.Episode.MilitaryOffice == null ? "" : ea.Episode.MilitaryOffice.Name + "\r\n";
////                }
////                this.KARAR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hca.Report.ToString());
////            }
//            this.TESHIS.CalcValue = "";
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeReportBook_A4()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            CAPTION = new CAPTIONGroup(PARTA,"CAPTION");
            PARTC = new PARTCGroup(CAPTION,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            PARTF = new PARTFGroup(PARTC,"PARTF");
            PARTD = new PARTDGroup(PARTF,"PARTD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DATE", "", "Rapor Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("HEALTHCOMITEETYPEFLAG", "", "Sağlık Kurulu Tipi Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("HEALTHCOMITEETYPE", "", "Sağlık Kurulu Tipi", @"", false, true, false, new Guid("50df466d-66a6-4824-8225-2ba9fb6189dc"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DATE"))
                _runtimeParameters.DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["DATE"]);
            if (parameters.ContainsKey("HEALTHCOMITEETYPEFLAG"))
                _runtimeParameters.HEALTHCOMITEETYPEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["HEALTHCOMITEETYPEFLAG"]);
            if (parameters.ContainsKey("HEALTHCOMITEETYPE"))
                _runtimeParameters.HEALTHCOMITEETYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue(parameters["HEALTHCOMITEETYPE"]);
            Name = "HEALTHCOMMITTEEREPORTBOOK_A4";
            Caption = "Sağlık Kurulu Defteri (Sağlık Kurulu A4)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            DontUseWatermark = EvetHayirEnum.ehEvet;
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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