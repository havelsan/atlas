
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
    /// Sağlık Kurulu Defteri (Sağlık Kurulu)
    /// </summary>
    public partial class HealthCommitteeReportBook : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeReportBook MyParentReport
            {
                get { return (HealthCommitteeReportBook)ParentReport; }
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
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField DATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 21, 291, 29, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.TextFont.Size = 14;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"SAĞLIK KURULU DEFTERİ";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 29, 291, 34, false);
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
            
            BASLIK.CalcValue = hospital.Name + " SAĞLIK KURULU DEFTERİ";

            ((HealthCommitteeReportBook)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(DATE.FormattedValue + " 00:00:00");
            ((HealthCommitteeReportBook)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(DATE.FormattedValue + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 174, 6, false);
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
            public HealthCommitteeReportBook MyParentReport
            {
                get { return (HealthCommitteeReportBook)ParentReport; }
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
            public TTReportField MEMBERS { get {return Footer().MEMBERS;} }
            public TTReportField REPORTDATE { get {return Footer().REPORTDATE;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
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
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
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
                    
                    Height = 23;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 13, 30, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor Nu ve Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 13, 66, 22, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Muayeneye Gönderen Makam Tarih ve Nu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 13, 115, 22, false);
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

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 13, 166, 22, false);
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

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 13, 211, 22, false);
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

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 13, 256, 22, false);
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

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 13, 291, 22, false);
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

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 13, 291, 13, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 22, 291, 22, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 13, 14, 22, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 13, 30, 22, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 66, 13, 66, 22, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 13, 115, 22, false);
                    NewLine1114.Name = "NewLine1114";
                    NewLine1114.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 13, 166, 22, false);
                    NewLine1115.Name = "NewLine1115";
                    NewLine1115.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 13, 211, 22, false);
                    NewLine1116.Name = "NewLine1116";
                    NewLine1116.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 13, 256, 22, false);
                    NewLine1117.Name = "NewLine1117";
                    NewLine1117.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1118 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 13, 291, 22, false);
                    NewLine1118.Name = "NewLine1118";
                    NewLine1118.DrawStyle = DrawStyleConstants.vbSolid;

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 5, 412, 10, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.Visible = EvetHayirEnum.ehHayir;
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"{@pagenumber@}";

                    PAGECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 415, 5, 442, 10, false);
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
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
                }
                
                public TTReportField MEMBERS;
                public TTReportField REPORTDATE;
                public TTReportField DESCRIPTION;
                public TTReportField NewField11; 
                public CAPTIONGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 87;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MEMBERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 8, 291, 77, false);
                    MEMBERS.Name = "MEMBERS";
                    MEMBERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBERS.MultiLine = EvetHayirEnum.ehEvet;
                    MEMBERS.WordBreak = EvetHayirEnum.ehEvet;
                    MEMBERS.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEMBERS.TextFont.Name = "Courier New";
                    MEMBERS.TextFont.Size = 7;
                    MEMBERS.TextFont.Bold = true;
                    MEMBERS.TextFont.CharSet = 162;
                    MEMBERS.Value = @"";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 19, 409, 24, false);
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

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 81, 291, 86, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{%REPORTDATE%} TARİHLİ OTURUMUN HEYET TEŞKİLİDİR.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 46, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Sağlık Kurulu Başkanı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MEMBERS.CalcValue = @"";
                    REPORTDATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    DESCRIPTION.CalcValue = MyParentReport.CAPTION.REPORTDATE.FormattedValue + @" TARİHLİ OTURUMUN HEYET TEŞKİLİDİR.";
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { MEMBERS,REPORTDATE,DESCRIPTION,NewField11};
                }

                public override void RunScript()
                {
#region CAPTION FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            IList<MemberOfHealthCommitteeDefinition> currentDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetMemberDefinitions(context);
            
            if(currentDefs.Count > 0)
            {
                MemberOfHealthCommitteeDefinition memberDef = currentDefs[0];

                if(memberDef != null)
                {
                    string sCrLf = "\r\n";
                    string sMembersText = sCrLf;
                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "", sMemberRecId = "", sMemberSpeciality = "";
                    
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
                }
                
            }
#endregion CAPTION FOOTER_Script
                }
            }

        }

        public CAPTIONGroup CAPTION;

        public partial class PARTCGroup : TTReportGroup
        {
            public HealthCommitteeReportBook MyParentReport
            {
                get { return (HealthCommitteeReportBook)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportShape NewLine11121 { get {return Header().NewLine11121;} }
            public TTReportShape NewLine11131 { get {return Header().NewLine11131;} }
            public TTReportShape NewLine11141 { get {return Header().NewLine11141;} }
            public TTReportShape NewLine11151 { get {return Header().NewLine11151;} }
            public TTReportShape NewLine11161 { get {return Header().NewLine11161;} }
            public TTReportShape NewLine116111 { get {return Header().NewLine116111;} }
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
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine11121;
                public TTReportShape NewLine11131;
                public TTReportShape NewLine11141;
                public TTReportShape NewLine11151;
                public TTReportShape NewLine11161;
                public TTReportShape NewLine116111; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 0, 30, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 66, 0, 66, 0, false);
                    NewLine11121.Name = "NewLine11121";
                    NewLine11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 0, 115, 0, false);
                    NewLine11131.Name = "NewLine11131";
                    NewLine11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 0, false);
                    NewLine11141.Name = "NewLine11141";
                    NewLine11141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 0, false);
                    NewLine11151.Name = "NewLine11151";
                    NewLine11151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11151.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 0, false);
                    NewLine11161.Name = "NewLine11161";
                    NewLine11161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine116111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 0, false);
                    NewLine116111.Name = "NewLine116111";
                    NewLine116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine116111.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
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

                    Height = 3;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 2, 291, 2, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 2, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 0, 30, 2, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 66, 0, 66, 2, false);
                    NewLine12121.Name = "NewLine12121";
                    NewLine12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 0, 115, 2, false);
                    NewLine12131.Name = "NewLine12131";
                    NewLine12131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 2, false);
                    NewLine12141.Name = "NewLine12141";
                    NewLine12141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 2, false);
                    NewLine12151.Name = "NewLine12151";
                    NewLine12151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12151.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 2, false);
                    NewLine12161.Name = "NewLine12161";
                    NewLine12161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine116121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 2, false);
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
            public HealthCommitteeReportBook MyParentReport
            {
                get { return (HealthCommitteeReportBook)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportShape NewLine11122 { get {return Header().NewLine11122;} }
            public TTReportShape NewLine11131 { get {return Header().NewLine11131;} }
            public TTReportShape NewLine11141 { get {return Header().NewLine11141;} }
            public TTReportShape NewLine11151 { get {return Header().NewLine11151;} }
            public TTReportShape NewLine11161 { get {return Header().NewLine11161;} }
            public TTReportShape NewLine116111 { get {return Header().NewLine116111;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine1211 { get {return Footer().NewLine1211;} }
            public TTReportShape NewLine1311 { get {return Footer().NewLine1311;} }
            public TTReportShape NewLine1411 { get {return Footer().NewLine1411;} }
            public TTReportShape NewLine1511 { get {return Footer().NewLine1511;} }
            public TTReportShape NewLine1611 { get {return Footer().NewLine1611;} }
            public TTReportShape NewLine11121 { get {return Footer().NewLine11121;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetHealthCommitteesByDate_Class>("GetHealthCommitteesByDate", HealthCommittee.GetHealthCommitteesByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
                }
                
                public TTReportShape NewLine1112;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine11122;
                public TTReportShape NewLine11131;
                public TTReportShape NewLine11141;
                public TTReportShape NewLine11151;
                public TTReportShape NewLine11161;
                public TTReportShape NewLine116111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 0, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 0, 30, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 66, 0, 66, 0, false);
                    NewLine11122.Name = "NewLine11122";
                    NewLine11122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11122.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 0, 115, 0, false);
                    NewLine11131.Name = "NewLine11131";
                    NewLine11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 0, false);
                    NewLine11141.Name = "NewLine11141";
                    NewLine11141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 0, false);
                    NewLine11151.Name = "NewLine11151";
                    NewLine11151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11151.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 0, false);
                    NewLine11161.Name = "NewLine11161";
                    NewLine11161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine116111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 0, false);
                    NewLine116111.Name = "NewLine116111";
                    NewLine116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine116111.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteesByDate_Class dataset_GetHealthCommitteesByDate = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteesByDate_Class>(0);
                    return new TTReportObject[] { };
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine1311;
                public TTReportShape NewLine1411;
                public TTReportShape NewLine1511;
                public TTReportShape NewLine1611;
                public TTReportShape NewLine11121; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 1, 14, 3, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 1, 30, 3, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 66, 1, 66, 3, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 1, 115, 3, false);
                    NewLine1311.Name = "NewLine1311";
                    NewLine1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 1, 166, 3, false);
                    NewLine1411.Name = "NewLine1411";
                    NewLine1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1411.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 1, 211, 3, false);
                    NewLine1511.Name = "NewLine1511";
                    NewLine1511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1511.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1611 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 1, 256, 3, false);
                    NewLine1611.Name = "NewLine1611";
                    NewLine1611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1611.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 1, 291, 3, false);
                    NewLine11121.Name = "NewLine11121";
                    NewLine11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11121.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteesByDate_Class dataset_GetHealthCommitteesByDate = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteesByDate_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeReportBook MyParentReport
            {
                get { return (HealthCommitteeReportBook)ParentReport; }
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
            public TTReportField DYERIL { get {return Body().DYERIL;} }
            public TTReportField DYERILCE { get {return Body().DYERILCE;} }
            public TTReportField DYERULKE { get {return Body().DYERULKE;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine113 { get {return Body().NewLine113;} }
            public TTReportShape NewLine114 { get {return Body().NewLine114;} }
            public TTReportShape NewLine115 { get {return Body().NewLine115;} }
            public TTReportShape NewLine116 { get {return Body().NewLine116;} }
            public TTReportShape NewLine117 { get {return Body().NewLine117;} }
            public TTReportShape NewLine111211 { get {return Body().NewLine111211;} }
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
                public HealthCommitteeReportBook MyParentReport
                {
                    get { return (HealthCommitteeReportBook)ParentReport; }
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
                public TTReportField DYERIL;
                public TTReportField DYERILCE;
                public TTReportField DYERULKE;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine113;
                public TTReportShape NewLine114;
                public TTReportShape NewLine115;
                public TTReportShape NewLine116;
                public TTReportShape NewLine117;
                public TTReportShape NewLine111211;
                public TTReportField DECISIONTIME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 42;
                    RepeatCount = 0;
                    
                    REPORTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 30, 42, false);
                    REPORTNODATE.Name = "REPORTNODATE";
                    REPORTNODATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNODATE.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNODATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNODATE.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNODATE.TextFont.Size = 9;
                    REPORTNODATE.TextFont.CharSet = 162;
                    REPORTNODATE.Value = @"{#PARTB.RAPORNO#}";

                    SENDERDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 66, 42, false);
                    SENDERDATENO.Name = "SENDERDATENO";
                    SENDERDATENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERDATENO.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERDATENO.NoClip = EvetHayirEnum.ehEvet;
                    SENDERDATENO.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERDATENO.TextFont.Size = 9;
                    SENDERDATENO.TextFont.CharSet = 162;
                    SENDERDATENO.Value = @"";

                    INFOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 0, 115, 42, false);
                    INFOS.Name = "INFOS";
                    INFOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOS.MultiLine = EvetHayirEnum.ehEvet;
                    INFOS.NoClip = EvetHayirEnum.ehEvet;
                    INFOS.WordBreak = EvetHayirEnum.ehEvet;
                    INFOS.TextFont.Size = 9;
                    INFOS.TextFont.CharSet = 162;
                    INFOS.Value = @"";

                    GONDERILEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 166, 42, false);
                    GONDERILEN.Name = "GONDERILEN";
                    GONDERILEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILEN.MultiLine = EvetHayirEnum.ehEvet;
                    GONDERILEN.NoClip = EvetHayirEnum.ehEvet;
                    GONDERILEN.WordBreak = EvetHayirEnum.ehEvet;
                    GONDERILEN.TextFont.Size = 9;
                    GONDERILEN.TextFont.CharSet = 162;
                    GONDERILEN.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 211, 42, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.NoClip = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Size = 9;
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 256, 42, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 0, 291, 42, false);
                    FOTO.Name = "FOTO";
                    FOTO.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOTO.TextFont.Size = 9;
                    FOTO.TextFont.CharSet = 162;
                    FOTO.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 11, 411, 16, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#PARTB.HEALTHCOMMITTEEOBJECTID#}";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 19, 411, 24, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.Visible = EvetHayirEnum.ehHayir;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.Value = @"{#PARTB.RAPORTARIHI#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 27, 411, 32, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#PARTB.DTARIHI#}";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 36, 411, 41, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.Value = @"";

                    XXXXXXLIKSUBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 386, 3, 411, 8, false);
                    XXXXXXLIKSUBESI.Name = "XXXXXXLIKSUBESI";
                    XXXXXXLIKSUBESI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXLIKSUBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBESI.Value = @"";

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 419, 3, 444, 8, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.Value = @"{#PARTB.PNAME#}";

                    PSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 419, 11, 444, 16, false);
                    PSURNAME.Name = "PSURNAME";
                    PSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PSURNAME.Value = @"{#PARTB.PSURNAME#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 419, 19, 444, 24, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.Value = @"{#PARTB.TCNO#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 419, 28, 444, 33, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.Visible = EvetHayirEnum.ehHayir;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#PARTB.FATHERNAME#}";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 419, 36, 444, 41, false);
                    BOY.Name = "BOY";
                    BOY.Visible = EvetHayirEnum.ehHayir;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.Value = @"{#PARTB.BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 453, 3, 478, 8, false);
                    KILO.Name = "KILO";
                    KILO.Visible = EvetHayirEnum.ehHayir;
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.Value = @"{#PARTB.KILO#}";

                    DYERIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 453, 11, 478, 16, false);
                    DYERIL.Name = "DYERIL";
                    DYERIL.Visible = EvetHayirEnum.ehHayir;
                    DYERIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERIL.Value = @"{#PARTB.DOGUMYERI#}";

                    DYERILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 453, 19, 478, 24, false);
                    DYERILCE.Name = "DYERILCE";
                    DYERILCE.Visible = EvetHayirEnum.ehHayir;
                    DYERILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERILCE.Value = @"{#PARTB.DOGUMYERIILCE#}";

                    DYERULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 453, 28, 478, 33, false);
                    DYERULKE.Name = "DYERULKE";
                    DYERULKE.Visible = EvetHayirEnum.ehHayir;
                    DYERULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERULKE.Value = @"{#PARTB.DOGUMYERIULKE#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 14, 42, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 30, 0, 30, 42, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 66, 0, 66, 42, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 0, 115, 42, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 166, 0, 166, 42, false);
                    NewLine114.Name = "NewLine114";
                    NewLine114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 42, false);
                    NewLine115.Name = "NewLine115";
                    NewLine115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine115.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 42, false);
                    NewLine116.Name = "NewLine116";
                    NewLine116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine116.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 42, false);
                    NewLine117.Name = "NewLine117";
                    NewLine117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine117.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 0, 291, 0, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 8, 335, 13, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHealthCommitteesByDate_Class dataset_GetHealthCommitteesByDate = MyParentReport.PARTB.rsGroup.GetCurrentRecord<HealthCommittee.GetHealthCommitteesByDate_Class>(0);
                    REPORTNODATE.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Raporno) : "");
                    SENDERDATENO.CalcValue = @"";
                    INFOS.CalcValue = @"";
                    GONDERILEN.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    FOTO.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Healthcommitteeobjectid) : "");
                    REPORTDATE.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Raportarihi) : "");
                    DTARIHI.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Dtarihi) : "");
                    MADDE.CalcValue = @"";
                    XXXXXXLIKSUBESI.CalcValue = @"";
                    PNAME.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Pname) : "");
                    PSURNAME.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Psurname) : "");
                    TCNO.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Tcno) : "");
                    FATHERNAME.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.FatherName) : "");
                    BOY.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Boy) : "");
                    KILO.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Kilo) : "");
                    DYERIL.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Dogumyeri) : "");
                    DYERILCE.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Dogumyeriilce) : "");
                    DYERULKE.CalcValue = (dataset_GetHealthCommitteesByDate != null ? Globals.ToStringCore(dataset_GetHealthCommitteesByDate.Dogumyeriulke) : "");
                    DECISIONTIME.CalcValue = @"";
                    return new TTReportObject[] { REPORTNODATE,SENDERDATENO,INFOS,GONDERILEN,TESHIS,KARAR,FOTO,OBJECTID,REPORTDATE,DTARIHI,MADDE,XXXXXXLIKSUBESI,PNAME,PSURNAME,TCNO,FATHERNAME,BOY,KILO,DYERIL,DYERILCE,DYERULKE,DECISIONTIME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sObjectID = this.OBJECTID.CalcValue.ToString();
            TTObjectContext context = new TTObjectContext(true);
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommittee is null");
            
            string dogumUlke = this.DYERULKE.CalcValue;
            string dogumIl = this.DYERIL.CalcValue;
            string dogumIlce = this.DYERILCE.CalcValue;
            string dogumYeri = "";
            
            if (dogumIlce.Trim() != "" )
            {
                if(dogumIlce.Trim().ToUpper() != "MERKEZ")
                    dogumYeri = dogumIlce;
                else
                    dogumYeri = dogumIl;
            }
            else if (dogumIl.Trim() != "")
                dogumYeri = dogumIl;
            else
                dogumYeri = dogumUlke;
            
            this.INFOS.CalcValue = this.PNAME.CalcValue + " " + this.PSURNAME.CalcValue + "\r\n";
            this.INFOS.CalcValue += "Doğum Tarihi: " + this.DTARIHI.FormattedValue + "\r\n";
            this.INFOS.CalcValue += "Doğum Yeri: " + dogumYeri + "\r\n";
            this.INFOS.CalcValue += "T.C. No: " + this.TCNO.CalcValue + "\r\n";
            this.INFOS.CalcValue += "Baba Adı: " + this.FATHERNAME.CalcValue + "\r\n";
            this.INFOS.CalcValue += "Boy: " + this.BOY.CalcValue + "\r\n";
            this.INFOS.CalcValue += "Ağırlık: " + this.KILO.CalcValue + "\r\n";
            //this.INFOS.CalcValue += "As. Şubesi: " + this.XXXXXXLIKSUBESI.CalcValue + "\r\n";
            
            //Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TESHIS.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TESHIS.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TESHIS.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
            
            //Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString())  + "\r\n";
            }
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    this.MADDE.CalcValue += "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]";
                
                this.KARAR.CalcValue = this.KARAR.CalcValue + "\r\n" + this.MADDE.CalcValue;
            }
            
            this.REPORTNODATE.CalcValue = this.REPORTNODATE.CalcValue + "\r\n\r\n" + this.REPORTDATE.FormattedValue;
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

        public HealthCommitteeReportBook()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            CAPTION = new CAPTIONGroup(PARTA,"CAPTION");
            PARTC = new PARTCGroup(CAPTION,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DATE", "", "Rapor Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DATE"))
                _runtimeParameters.DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["DATE"]);
            Name = "HEALTHCOMMITTEEREPORTBOOK";
            Caption = "Sağlık Kurulu Defteri (Sağlık Kurulu)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            PaperSize = 39;
            p_PageWidth = 378;
            p_PageHeight = 279;
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