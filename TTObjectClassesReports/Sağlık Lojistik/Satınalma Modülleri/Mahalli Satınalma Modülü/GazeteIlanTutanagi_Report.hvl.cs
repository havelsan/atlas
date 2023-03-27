
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
    /// Gazete İlan Tutanağı
    /// </summary>
    public partial class GazeteIlanTutanagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public GazeteIlanTutanagi MyParentReport
            {
                get { return (GazeteIlanTutanagi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField DESC { get {return Header().DESC;} }
            public TTReportField KIKNO { get {return Header().KIKNO;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField ISINADI { get {return Header().ISINADI;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField ANNOUNCETYPEANDCOUNT { get {return Header().ANNOUNCETYPEANDCOUNT;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
            public TTReportField REPDESC { get {return Footer().REPDESC;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectReportNQL_Class>("PurchaseProjectReportNQL", PurchaseProject.PurchaseProjectReportNQL((long)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField NewField5;
                public TTReportField ACIKLAMA;
                public TTReportField HEADER;
                public TTReportField DESC;
                public TTReportField KIKNO;
                public TTReportField NewField21;
                public TTReportField NewField2;
                public TTReportField ISINADI;
                public TTReportField NewField12;
                public TTReportField NewField3;
                public TTReportField ANNOUNCETYPEANDCOUNT; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 28, 184, 33, false);
                    NewField5.Name = "NewField5";
                    NewField5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"GAZETE İLAN TUTANAĞI";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 22, 184, 27, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACIKLAMA.TextFont.Name = "Arial Narrow";
                    ACIKLAMA.TextFont.Bold = true;
                    ACIKLAMA.Value = @"{#ANNOUNCEMENTDESCRIPTION#}";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 184, 22, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Size = 11;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 50, 184, 62, false);
                    DESC.Name = "DESC";
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Name = "Arial Narrow";
                    DESC.Value = @"     Aşağıda adı, ilan yeri, ilan tarihi ve sayısı yazılı gazetede ilan edildiği görülerek iş bu gazete ilan tutanağı tarafımızdan düzenlenerek imza altına alınmıştır.";

                    KIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 37, 184, 42, false);
                    KIKNO.Name = "KIKNO";
                    KIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    KIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    KIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KIKNO.TextFont.Name = "Arial Narrow";
                    KIKNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 37, 34, 42, false);
                    NewField21.Name = "NewField21";
                    NewField21.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @":";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 37, 32, 42, false);
                    NewField2.Name = "NewField2";
                    NewField2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"KİK NO";

                    ISINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 43, 184, 48, false);
                    ISINADI.Name = "ISINADI";
                    ISINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISINADI.MultiLine = EvetHayirEnum.ehEvet;
                    ISINADI.WordBreak = EvetHayirEnum.ehEvet;
                    ISINADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISINADI.TextFont.Name = "Arial Narrow";
                    ISINADI.Value = @"{#ACTDEFINE#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 42, 34, 47, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 42, 32, 47, false);
                    NewField3.Name = "NewField3";
                    NewField3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İşin Adı";

                    ANNOUNCETYPEANDCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 184, 6, false);
                    ANNOUNCETYPEANDCOUNT.Name = "ANNOUNCETYPEANDCOUNT";
                    ANNOUNCETYPEANDCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANNOUNCETYPEANDCOUNT.TextFont.Name = "Arial Narrow";
                    ANNOUNCETYPEANDCOUNT.TextFont.Size = 9;
                    ANNOUNCETYPEANDCOUNT.Value = @"{#ANNOUNCETYPEANDCOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectReportNQL_Class dataset_PurchaseProjectReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectReportNQL_Class>(0);
                    NewField5.CalcValue = NewField5.Value;
                    ACIKLAMA.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.AnnouncementDescription) : "");
                    HEADER.CalcValue = @"";
                    DESC.CalcValue = DESC.Value;
                    KIKNO.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.KIKTenderRegisterNO) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField2.CalcValue = NewField2.Value;
                    ISINADI.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.ActDefine) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField3.CalcValue = NewField3.Value;
                    ANNOUNCETYPEANDCOUNT.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.AnnounceTypeandCount) : "");
                    return new TTReportObject[] { NewField5,ACIKLAMA,HEADER,DESC,KIKNO,NewField21,NewField2,ISINADI,NewField12,NewField3,ANNOUNCETYPEANDCOUNT};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER;
                public TTReportField USERNAME;
                public TTReportField REPDESC;
                public TTReportShape NewLine; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 85, 6, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 188, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.Name = "Arial Narrow";
                    PAGENUMBER.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 6, 52, 11, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Name = "Arial Narrow";
                    USERNAME.Value = @"";

                    REPDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 1, 156, 6, false);
                    REPDESC.Name = "REPDESC";
                    REPDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPDESC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    REPDESC.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REPDESC.TextFont.Name = "Arial Narrow";
                    REPDESC.Value = @"";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 1, 188, 1, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectReportNQL_Class dataset_PurchaseProjectReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectReportNQL_Class>(0);
                    USERNAME.CalcValue = @"";
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString() + @" - " + MyParentReport.PARTB.USERNAME.CalcValue;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    REPDESC.CalcValue = @"";
                    return new TTReportObject[] { USERNAME,PRINTDATE,PAGENUMBER,REPDESC};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public GazeteIlanTutanagi MyParentReport
            {
                get { return (GazeteIlanTutanagi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NAMESURNAME1 { get {return Footer().NAMESURNAME1;} }
            public TTReportField HOSPFUNC1 { get {return Footer().HOSPFUNC1;} }
            public TTReportField NAMESURNAME2 { get {return Footer().NAMESURNAME2;} }
            public TTReportField HOSPFUNC2 { get {return Footer().HOSPFUNC2;} }
            public TTReportField NAMESURNAME3 { get {return Footer().NAMESURNAME3;} }
            public TTReportField HOSPFUNC3 { get {return Footer().HOSPFUNC3;} }
            public TTReportField NAMESURNAME4 { get {return Footer().NAMESURNAME4;} }
            public TTReportField HOSPFUNC4 { get {return Footer().HOSPFUNC4;} }
            public TTReportField COMFUNC1 { get {return Footer().COMFUNC1;} }
            public TTReportField COMFUNC2 { get {return Footer().COMFUNC2;} }
            public TTReportField COMFUNC3 { get {return Footer().COMFUNC3;} }
            public TTReportField COMFUNC4 { get {return Footer().COMFUNC4;} }
            public TTReportField NAMESURNAME5 { get {return Footer().NAMESURNAME5;} }
            public TTReportField HOSPFUNC5 { get {return Footer().HOSPFUNC5;} }
            public TTReportField NAMESURNAME6 { get {return Footer().NAMESURNAME6;} }
            public TTReportField HOSPFUNC6 { get {return Footer().HOSPFUNC6;} }
            public TTReportField NAMESURNAME7 { get {return Footer().NAMESURNAME7;} }
            public TTReportField HOSPFUNC7 { get {return Footer().HOSPFUNC7;} }
            public TTReportField NAMESURNAME8 { get {return Footer().NAMESURNAME8;} }
            public TTReportField HOSPFUNC8 { get {return Footer().HOSPFUNC8;} }
            public TTReportField COMFUNC5 { get {return Footer().COMFUNC5;} }
            public TTReportField COMFUNC6 { get {return Footer().COMFUNC6;} }
            public TTReportField COMFUNC7 { get {return Footer().COMFUNC7;} }
            public TTReportField COMFUNC8 { get {return Footer().COMFUNC8;} }
            public TTReportField NAMESURNAME9 { get {return Footer().NAMESURNAME9;} }
            public TTReportField HOSPFUNC9 { get {return Footer().HOSPFUNC9;} }
            public TTReportField COMFUNC9 { get {return Footer().COMFUNC9;} }
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
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField NewField21;
                public TTReportField NewField31;
                public TTReportField NewField12;
                public TTReportField NewField22; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 134, 5, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"İlan Yeri";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 105, 5, false);
                    NewField31.Name = "NewField31";
                    NewField31.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField31.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField31.TextFont.Name = "Arial Narrow";
                    NewField31.TextFont.Bold = true;
                    NewField31.Value = @"Gazetenin Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 157, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Sayısı";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 180, 5, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField21.CalcValue = NewField21.Value;
                    NewField31.CalcValue = NewField31.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField22.CalcValue = NewField22.Value;
                    return new TTReportObject[] { NewField21,NewField31,NewField12,NewField22};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField NewField4;
                public TTReportField NAMESURNAME1;
                public TTReportField HOSPFUNC1;
                public TTReportField NAMESURNAME2;
                public TTReportField HOSPFUNC2;
                public TTReportField NAMESURNAME3;
                public TTReportField HOSPFUNC3;
                public TTReportField NAMESURNAME4;
                public TTReportField HOSPFUNC4;
                public TTReportField COMFUNC1;
                public TTReportField COMFUNC2;
                public TTReportField COMFUNC3;
                public TTReportField COMFUNC4;
                public TTReportField NAMESURNAME5;
                public TTReportField HOSPFUNC5;
                public TTReportField NAMESURNAME6;
                public TTReportField HOSPFUNC6;
                public TTReportField NAMESURNAME7;
                public TTReportField HOSPFUNC7;
                public TTReportField NAMESURNAME8;
                public TTReportField HOSPFUNC8;
                public TTReportField COMFUNC5;
                public TTReportField COMFUNC6;
                public TTReportField COMFUNC7;
                public TTReportField COMFUNC8;
                public TTReportField NAMESURNAME9;
                public TTReportField HOSPFUNC9;
                public TTReportField COMFUNC9; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 96;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 188, 11, false);
                    NewField4.Name = "NewField4";
                    NewField4.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"İHALE KOMİSYONU";

                    NAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 21, 67, 26, false);
                    NAMESURNAME1.Name = "NAMESURNAME1";
                    NAMESURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME1.TextFont.Name = "Arial Narrow";
                    NAMESURNAME1.Value = @"";

                    HOSPFUNC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 26, 67, 31, false);
                    HOSPFUNC1.Name = "HOSPFUNC1";
                    HOSPFUNC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC1.TextFont.Name = "Arial Narrow";
                    HOSPFUNC1.Value = @"";

                    NAMESURNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 21, 123, 26, false);
                    NAMESURNAME2.Name = "NAMESURNAME2";
                    NAMESURNAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME2.TextFont.Name = "Arial Narrow";
                    NAMESURNAME2.Value = @"";

                    HOSPFUNC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 26, 123, 31, false);
                    HOSPFUNC2.Name = "HOSPFUNC2";
                    HOSPFUNC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC2.TextFont.Name = "Arial Narrow";
                    HOSPFUNC2.Value = @"";

                    NAMESURNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 21, 179, 26, false);
                    NAMESURNAME3.Name = "NAMESURNAME3";
                    NAMESURNAME3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME3.TextFont.Name = "Arial Narrow";
                    NAMESURNAME3.Value = @"";

                    HOSPFUNC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 26, 179, 31, false);
                    HOSPFUNC3.Name = "HOSPFUNC3";
                    HOSPFUNC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC3.TextFont.Name = "Arial Narrow";
                    HOSPFUNC3.Value = @"";

                    NAMESURNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 48, 67, 53, false);
                    NAMESURNAME4.Name = "NAMESURNAME4";
                    NAMESURNAME4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME4.TextFont.Name = "Arial Narrow";
                    NAMESURNAME4.Value = @"";

                    HOSPFUNC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 53, 67, 58, false);
                    HOSPFUNC4.Name = "HOSPFUNC4";
                    HOSPFUNC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC4.TextFont.Name = "Arial Narrow";
                    HOSPFUNC4.Value = @"";

                    COMFUNC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 16, 67, 21, false);
                    COMFUNC1.Name = "COMFUNC1";
                    COMFUNC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC1.TextFont.Name = "Arial Narrow";
                    COMFUNC1.Value = @"";

                    COMFUNC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 16, 123, 21, false);
                    COMFUNC2.Name = "COMFUNC2";
                    COMFUNC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC2.TextFont.Name = "Arial Narrow";
                    COMFUNC2.Value = @"";

                    COMFUNC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 16, 179, 21, false);
                    COMFUNC3.Name = "COMFUNC3";
                    COMFUNC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC3.TextFont.Name = "Arial Narrow";
                    COMFUNC3.Value = @"";

                    COMFUNC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 43, 67, 48, false);
                    COMFUNC4.Name = "COMFUNC4";
                    COMFUNC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC4.TextFont.Name = "Arial Narrow";
                    COMFUNC4.Value = @"";

                    NAMESURNAME5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 48, 123, 53, false);
                    NAMESURNAME5.Name = "NAMESURNAME5";
                    NAMESURNAME5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME5.TextFont.Name = "Arial Narrow";
                    NAMESURNAME5.Value = @"";

                    HOSPFUNC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 53, 123, 58, false);
                    HOSPFUNC5.Name = "HOSPFUNC5";
                    HOSPFUNC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC5.TextFont.Name = "Arial Narrow";
                    HOSPFUNC5.Value = @"";

                    NAMESURNAME6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 48, 179, 53, false);
                    NAMESURNAME6.Name = "NAMESURNAME6";
                    NAMESURNAME6.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME6.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME6.TextFont.Name = "Arial Narrow";
                    NAMESURNAME6.Value = @"";

                    HOSPFUNC6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 53, 179, 58, false);
                    HOSPFUNC6.Name = "HOSPFUNC6";
                    HOSPFUNC6.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC6.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC6.TextFont.Name = "Arial Narrow";
                    HOSPFUNC6.Value = @"";

                    NAMESURNAME7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 76, 67, 81, false);
                    NAMESURNAME7.Name = "NAMESURNAME7";
                    NAMESURNAME7.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME7.TextFont.Name = "Arial Narrow";
                    NAMESURNAME7.Value = @"";

                    HOSPFUNC7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 81, 67, 86, false);
                    HOSPFUNC7.Name = "HOSPFUNC7";
                    HOSPFUNC7.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC7.TextFont.Name = "Arial Narrow";
                    HOSPFUNC7.Value = @"";

                    NAMESURNAME8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 76, 123, 81, false);
                    NAMESURNAME8.Name = "NAMESURNAME8";
                    NAMESURNAME8.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME8.TextFont.Name = "Arial Narrow";
                    NAMESURNAME8.Value = @"";

                    HOSPFUNC8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 81, 123, 86, false);
                    HOSPFUNC8.Name = "HOSPFUNC8";
                    HOSPFUNC8.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC8.TextFont.Name = "Arial Narrow";
                    HOSPFUNC8.Value = @"";

                    COMFUNC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 43, 123, 48, false);
                    COMFUNC5.Name = "COMFUNC5";
                    COMFUNC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC5.TextFont.Name = "Arial Narrow";
                    COMFUNC5.Value = @"";

                    COMFUNC6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 43, 179, 48, false);
                    COMFUNC6.Name = "COMFUNC6";
                    COMFUNC6.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC6.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC6.TextFont.Name = "Arial Narrow";
                    COMFUNC6.Value = @"";

                    COMFUNC7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 71, 67, 76, false);
                    COMFUNC7.Name = "COMFUNC7";
                    COMFUNC7.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC7.TextFont.Name = "Arial Narrow";
                    COMFUNC7.Value = @"";

                    COMFUNC8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 71, 123, 76, false);
                    COMFUNC8.Name = "COMFUNC8";
                    COMFUNC8.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC8.TextFont.Name = "Arial Narrow";
                    COMFUNC8.Value = @"";

                    NAMESURNAME9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 76, 179, 81, false);
                    NAMESURNAME9.Name = "NAMESURNAME9";
                    NAMESURNAME9.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME9.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME9.TextFont.Name = "Arial Narrow";
                    NAMESURNAME9.Value = @"";

                    HOSPFUNC9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 81, 179, 86, false);
                    HOSPFUNC9.Name = "HOSPFUNC9";
                    HOSPFUNC9.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC9.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC9.TextFont.Name = "Arial Narrow";
                    HOSPFUNC9.Value = @"";

                    COMFUNC9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 71, 179, 76, false);
                    COMFUNC9.Name = "COMFUNC9";
                    COMFUNC9.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC9.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COMFUNC9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC9.TextFont.Name = "Arial Narrow";
                    COMFUNC9.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField4.CalcValue = NewField4.Value;
                    NAMESURNAME1.CalcValue = @"";
                    HOSPFUNC1.CalcValue = @"";
                    NAMESURNAME2.CalcValue = @"";
                    HOSPFUNC2.CalcValue = @"";
                    NAMESURNAME3.CalcValue = @"";
                    HOSPFUNC3.CalcValue = @"";
                    NAMESURNAME4.CalcValue = @"";
                    HOSPFUNC4.CalcValue = @"";
                    COMFUNC1.CalcValue = @"";
                    COMFUNC2.CalcValue = @"";
                    COMFUNC3.CalcValue = @"";
                    COMFUNC4.CalcValue = @"";
                    NAMESURNAME5.CalcValue = @"";
                    HOSPFUNC5.CalcValue = @"";
                    NAMESURNAME6.CalcValue = @"";
                    HOSPFUNC6.CalcValue = @"";
                    NAMESURNAME7.CalcValue = @"";
                    HOSPFUNC7.CalcValue = @"";
                    NAMESURNAME8.CalcValue = @"";
                    HOSPFUNC8.CalcValue = @"";
                    COMFUNC5.CalcValue = @"";
                    COMFUNC6.CalcValue = @"";
                    COMFUNC7.CalcValue = @"";
                    COMFUNC8.CalcValue = @"";
                    NAMESURNAME9.CalcValue = @"";
                    HOSPFUNC9.CalcValue = @"";
                    COMFUNC9.CalcValue = @"";
                    return new TTReportObject[] { NewField4,NAMESURNAME1,HOSPFUNC1,NAMESURNAME2,HOSPFUNC2,NAMESURNAME3,HOSPFUNC3,NAMESURNAME4,HOSPFUNC4,COMFUNC1,COMFUNC2,COMFUNC3,COMFUNC4,NAMESURNAME5,HOSPFUNC5,NAMESURNAME6,HOSPFUNC6,NAMESURNAME7,HOSPFUNC7,NAMESURNAME8,HOSPFUNC8,COMFUNC5,COMFUNC6,COMFUNC7,COMFUNC8,NAMESURNAME9,HOSPFUNC9,COMFUNC9};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((GazeteIlanTutanagi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject pp = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            
            int i = 0;
            foreach(TenderCommision tc in pp.TenderCommisionMembers)
            {
                if((bool)tc.PrimeBackup)
                {
                    i++;
                    if (i<11)
                    {
                        TTReportField rf = FieldsByName("COMFUNC"+i);
                        rf.CalcValue = tc.MemberDuty.Value.ToString();
                        rf = FieldsByName("NAMESURNAME"+i);
                        rf.CalcValue = tc.ResUser.Rank.Name + " " + tc.ResUser.Name;
                        rf = FieldsByName("HOSPFUNC"+i);
                        rf.CalcValue = tc.ResUser.Title.Value.ToString();
                    }
                }
            }
#endregion PARTA FOOTER_PreScript
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public GazeteIlanTutanagi MyParentReport
            {
                get { return (GazeteIlanTutanagi)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField KIKBULTEN { get {return Body().KIKBULTEN;} }
            public TTReportField KIKYER { get {return Body().KIKYER;} }
            public TTReportField KIBSAYI { get {return Body().KIBSAYI;} }
            public TTReportField KIBDATE { get {return Body().KIBDATE;} }
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
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField KIKBULTEN;
                public TTReportField KIKYER;
                public TTReportField KIBSAYI;
                public TTReportField KIBDATE; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    KIKBULTEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 105, 5, false);
                    KIKBULTEN.Name = "KIKBULTEN";
                    KIKBULTEN.TextFont.Name = "Arial Narrow";
                    KIKBULTEN.Value = @"Kamu İhale Bülteni";

                    KIKYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 134, 5, false);
                    KIKYER.Name = "KIKYER";
                    KIKYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKYER.TextFont.Name = "Arial Narrow";
                    KIKYER.Value = @"";

                    KIBSAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 157, 5, false);
                    KIBSAYI.Name = "KIBSAYI";
                    KIBSAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIBSAYI.TextFont.Name = "Arial Narrow";
                    KIBSAYI.Value = @"{#PARTB.KIBANNOUNCEMENTCOUNT#}";

                    KIBDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 180, 5, false);
                    KIBDATE.Name = "KIBDATE";
                    KIBDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIBDATE.TextFormat = @"Short Date";
                    KIBDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIBDATE.TextFont.Name = "Arial Narrow";
                    KIBDATE.Value = @"{#PARTB.KIBANNOUNCEMENTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectReportNQL_Class dataset_PurchaseProjectReportNQL = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectReportNQL_Class>(0);
                    KIKBULTEN.CalcValue = KIKBULTEN.Value;
                    KIKYER.CalcValue = @"";
                    KIBSAYI.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.KIBAnnouncementCount) : "");
                    KIBDATE.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.KIBAnnouncementDate) : "");
                    return new TTReportObject[] { KIKBULTEN,KIKYER,KIBSAYI,KIBDATE};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public GazeteIlanTutanagi MyParentReport
            {
                get { return (GazeteIlanTutanagi)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField ULUSALYER { get {return Body().ULUSALYER;} }
            public TTReportField UGSAYI { get {return Body().UGSAYI;} }
            public TTReportField UGDATE { get {return Body().UGDATE;} }
            public TTReportField ULUSAL { get {return Body().ULUSAL;} }
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
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField ULUSALYER;
                public TTReportField UGSAYI;
                public TTReportField UGDATE;
                public TTReportField ULUSAL; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ULUSALYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 134, 5, false);
                    ULUSALYER.Name = "ULUSALYER";
                    ULUSALYER.TextFont.Name = "Arial Narrow";
                    ULUSALYER.Value = @"Tüm İller";

                    UGSAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 157, 5, false);
                    UGSAYI.Name = "UGSAYI";
                    UGSAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UGSAYI.TextFont.Name = "Arial Narrow";
                    UGSAYI.Value = @"{#PARTB.NATIONALNEWSANNOUNCECOUNT#}";

                    UGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 180, 5, false);
                    UGDATE.Name = "UGDATE";
                    UGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UGDATE.TextFormat = @"Short Date";
                    UGDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UGDATE.TextFont.Name = "Arial Narrow";
                    UGDATE.Value = @"{#PARTB.NATIONALNEWSPAPERANNOUNCEDATE#}";

                    ULUSAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 105, 5, false);
                    ULUSAL.Name = "ULUSAL";
                    ULUSAL.TextFont.Name = "Arial Narrow";
                    ULUSAL.Value = @"Ulusal Gazete";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectReportNQL_Class dataset_PurchaseProjectReportNQL = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectReportNQL_Class>(0);
                    ULUSALYER.CalcValue = ULUSALYER.Value;
                    UGSAYI.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.NationalNewsAnnounceCount) : "");
                    UGDATE.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.NationalNewspaperAnnounceDate) : "");
                    ULUSAL.CalcValue = ULUSAL.Value;
                    return new TTReportObject[] { ULUSALYER,UGSAYI,UGDATE,ULUSAL};
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTEGroup : TTReportGroup
        {
            public GazeteIlanTutanagi MyParentReport
            {
                get { return (GazeteIlanTutanagi)ParentReport; }
            }

            new public PARTEGroupBody Body()
            {
                return (PARTEGroupBody)_body;
            }
            public TTReportField YEREL1YER { get {return Body().YEREL1YER;} }
            public TTReportField YG1SAYI { get {return Body().YG1SAYI;} }
            public TTReportField YG1DATE { get {return Body().YG1DATE;} }
            public TTReportField YEREL1 { get {return Body().YEREL1;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTEGroupBody(this);
            }

            public partial class PARTEGroupBody : TTReportSection
            {
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField YEREL1YER;
                public TTReportField YG1SAYI;
                public TTReportField YG1DATE;
                public TTReportField YEREL1; 
                public PARTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    YEREL1YER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 134, 5, false);
                    YEREL1YER.Name = "YEREL1YER";
                    YEREL1YER.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEREL1YER.TextFont.Name = "Arial Narrow";
                    YEREL1YER.Value = @"";

                    YG1SAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 157, 5, false);
                    YG1SAYI.Name = "YG1SAYI";
                    YG1SAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YG1SAYI.TextFont.Name = "Arial Narrow";
                    YG1SAYI.Value = @"{#PARTB.LOCALNEWSPAPERANNOUNCECOUNT#}";

                    YG1DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 180, 5, false);
                    YG1DATE.Name = "YG1DATE";
                    YG1DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    YG1DATE.TextFormat = @"Short Date";
                    YG1DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YG1DATE.TextFont.Name = "Arial Narrow";
                    YG1DATE.Value = @"{#PARTB.LOCALNEWSPAPERANNOUNCEDATE#}";

                    YEREL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 105, 5, false);
                    YEREL1.Name = "YEREL1";
                    YEREL1.TextFont.Name = "Arial Narrow";
                    YEREL1.Value = @"Yerel Gazete";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectReportNQL_Class dataset_PurchaseProjectReportNQL = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectReportNQL_Class>(0);
                    YEREL1YER.CalcValue = @"";
                    YG1SAYI.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.LocalNewspaperAnnounceCount) : "");
                    YG1DATE.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.LocalNewspaperAnnounceDate) : "");
                    YEREL1.CalcValue = YEREL1.Value;
                    return new TTReportObject[] { YEREL1YER,YG1SAYI,YG1DATE,YEREL1};
                }
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTFGroup : TTReportGroup
        {
            public GazeteIlanTutanagi MyParentReport
            {
                get { return (GazeteIlanTutanagi)ParentReport; }
            }

            new public PARTFGroupBody Body()
            {
                return (PARTFGroupBody)_body;
            }
            public TTReportField YEREL2YER { get {return Body().YEREL2YER;} }
            public TTReportField YG2SAYI { get {return Body().YG2SAYI;} }
            public TTReportField YG2DATE { get {return Body().YG2DATE;} }
            public TTReportField YEREL2 { get {return Body().YEREL2;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTFGroupBody(this);
            }

            public partial class PARTFGroupBody : TTReportSection
            {
                public GazeteIlanTutanagi MyParentReport
                {
                    get { return (GazeteIlanTutanagi)ParentReport; }
                }
                
                public TTReportField YEREL2YER;
                public TTReportField YG2SAYI;
                public TTReportField YG2DATE;
                public TTReportField YEREL2; 
                public PARTFGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    YEREL2YER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 134, 5, false);
                    YEREL2YER.Name = "YEREL2YER";
                    YEREL2YER.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEREL2YER.TextFont.Name = "Arial Narrow";
                    YEREL2YER.Value = @"";

                    YG2SAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 157, 5, false);
                    YG2SAYI.Name = "YG2SAYI";
                    YG2SAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YG2SAYI.TextFont.Name = "Arial Narrow";
                    YG2SAYI.Value = @"{#PARTB.LOCALNEWSPAPERANNOUNCECOUNT2#}";

                    YG2DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 180, 5, false);
                    YG2DATE.Name = "YG2DATE";
                    YG2DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    YG2DATE.TextFormat = @"Short Date";
                    YG2DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YG2DATE.TextFont.Name = "Arial Narrow";
                    YG2DATE.Value = @"{#PARTB.LOCALNEWSPAPERANNOUNCEDATE2#}";

                    YEREL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 105, 5, false);
                    YEREL2.Name = "YEREL2";
                    YEREL2.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEREL2.TextFont.Name = "Arial Narrow";
                    YEREL2.Value = @"Yerel Gazete";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectReportNQL_Class dataset_PurchaseProjectReportNQL = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectReportNQL_Class>(0);
                    YEREL2YER.CalcValue = @"";
                    YG2SAYI.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.LocalNewspaperAnnounceCount2) : "");
                    YG2DATE.CalcValue = (dataset_PurchaseProjectReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectReportNQL.LocalNewspaperAnnounceDate2) : "");
                    YEREL2.CalcValue = @"Yerel Gazete";
                    return new TTReportObject[] { YEREL2YER,YG2SAYI,YG2DATE,YEREL2};
                }
            }

        }

        public PARTFGroup PARTF;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GazeteIlanTutanagi()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTD = new PARTDGroup(PARTA,"PARTD");
            PARTE = new PARTEGroup(PARTA,"PARTE");
            PARTF = new PARTFGroup(PARTA,"PARTF");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "GAZETEILANTUTANAGI";
            Caption = "Gazete İlan Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 5;
            PreferredPrinter = "<Default>";
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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