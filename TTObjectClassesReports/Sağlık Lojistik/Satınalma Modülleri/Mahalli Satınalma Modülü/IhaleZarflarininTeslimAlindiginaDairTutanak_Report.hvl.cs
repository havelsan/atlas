
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
    /// İhale Zarflarının Teslim Alındığına Dair Tutanak
    /// </summary>
    public partial class IhaleZarflarininTeslimAlindiginaDairTutanak : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string DELIVEREDBY = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Part1Group : TTReportGroup
        {
            public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
            {
                get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField YETERLIKLABEL11 { get {return Header().YETERLIKLABEL11;} }
            public TTReportField TENDERDATE { get {return Header().TENDERDATE;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField1101 { get {return Header().NewField1101;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField IDAREADI { get {return Header().IDAREADI;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField YETERLIKLABEL111 { get {return Header().YETERLIKLABEL111;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField TIME { get {return Header().TIME;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO0 { get {return Header().LOGO0;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField151;
                public TTReportField ACTDEFINE;
                public TTReportField YETERLIKLABEL11;
                public TTReportField TENDERDATE;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField1101;
                public TTReportField NewField13;
                public TTReportField IDAREADI;
                public TTReportField NewField1161;
                public TTReportField YETERLIKLABEL111;
                public TTReportField DOCUMENTDATE;
                public TTReportField NewField1162;
                public TTReportField HEADER;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField TIME;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO0;
                public TTReportField DATE; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 96;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField121.Name = "NewField121";
                    NewField121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İhale Kayıt Numarası";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 170, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.TextFont.CharSet = 162;
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField151.Name = "NewField151";
                    NewField151.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"İşin Adı";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.TextFont.CharSet = 162;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    YETERLIKLABEL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 39, 60, false);
                    YETERLIKLABEL11.Name = "YETERLIKLABEL11";
                    YETERLIKLABEL11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YETERLIKLABEL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERLIKLABEL11.TextFont.Name = "Arial";
                    YETERLIKLABEL11.TextFont.Bold = true;
                    YETERLIKLABEL11.TextFont.CharSet = 162;
                    YETERLIKLABEL11.Value = @"İhale Tarih ve Saati";

                    TENDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 55, 170, 60, false);
                    TENDERDATE.Name = "TENDERDATE";
                    TENDERDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    TENDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TENDERDATE.TextFont.Name = "Arial";
                    TENDERDATE.TextFont.CharSet = 162;
                    TENDERDATE.Value = @"DATE.FormattedValue + "" günü, saat "" + TIME.FormattedValue";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 55, 40, 60, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField171.Name = "NewField171";
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @":";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1101.TextFont.Name = "Arial";
                    NewField1101.TextFont.Bold = true;
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField13.Name = "NewField13";
                    NewField13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İdarenin Adı";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 170, 50, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    IDAREADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDAREADI.TextFont.Name = "Arial";
                    IDAREADI.TextFont.CharSet = 162;
                    IDAREADI.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    YETERLIKLABEL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 39, 69, false);
                    YETERLIKLABEL111.Name = "YETERLIKLABEL111";
                    YETERLIKLABEL111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERLIKLABEL111.MultiLine = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL111.WordBreak = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL111.TextFont.Name = "Arial";
                    YETERLIKLABEL111.TextFont.Bold = true;
                    YETERLIKLABEL111.TextFont.CharSet = 162;
                    YETERLIKLABEL111.Value = @"Tutanağın Düzenlenme Tarih ve Saati";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 64, 170, 69, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTDATE.TextFont.Name = "Arial";
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"_ _/_ _/_ _ _ _ ................günü, saat ___:___";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 64, 40, 69, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1162.TextFont.Name = "Arial";
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @":";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 79, 170, 85, false);
                    HEADER.Name = "HEADER";
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Size = 11;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"İHALE TEKLİF ZARFLARININ İHALE KOMİSYONUNCA TESLİM ALINDIĞINA DAİR TUTANAK";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 90, 40, 95, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA NO";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 90, 155, 95, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ADAYIN ADI/ÜNVANI";

                    TIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 34, 243, 39, false);
                    TIME.Name = "TIME";
                    TIME.Visible = EvetHayirEnum.ehHayir;
                    TIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIME.TextFormat = @"Short Time";
                    TIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TIME.TextFont.Name = "Arial";
                    TIME.TextFont.Size = 11;
                    TIME.TextFont.CharSet = 162;
                    TIME.Value = @"{#TENDERDATE#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 170, 38, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO0.Name = "LOGO0";
                    LOGO0.Visible = EvetHayirEnum.ehHayir;
                    LOGO0.TextFont.Name = "Courier New";
                    LOGO0.Value = @"LOGO";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 27, 240, 32, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Long Date";
                    DATE.Value = @"{#TENDERDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.KIKTenderRegisterNO) : "");
                    NewField151.CalcValue = NewField151.Value;
                    ACTDEFINE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "");
                    YETERLIKLABEL11.CalcValue = YETERLIKLABEL11.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    NewField13.CalcValue = NewField13.Value;
                    IDAREADI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    NewField1161.CalcValue = NewField1161.Value;
                    YETERLIKLABEL111.CalcValue = YETERLIKLABEL111.Value;
                    DOCUMENTDATE.CalcValue = DOCUMENTDATE.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    HEADER.CalcValue = HEADER.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    TIME.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.TenderDate) : "");
                    LOGO0.CalcValue = LOGO0.Value;
                    DATE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.TenderDate) : "");
                    TENDERDATE.CalcValue = DATE.FormattedValue + " günü, saat " + TIME.FormattedValue;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField121,KIKTENDERREGISTERNO,NewField151,ACTDEFINE,YETERLIKLABEL11,NewField161,NewField171,NewField1101,NewField13,IDAREADI,NewField1161,YETERLIKLABEL111,DOCUMENTDATE,NewField1162,HEADER,NewField1,NewField11,TIME,LOGO0,DATE,TENDERDATE,XXXXXXBASLIK};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    string objectID = ((IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PART1 FOOTER_Script
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
            {
                get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField Count { get {return Body().Count;} }
            public TTReportField CountText { get {return Body().CountText;} }
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
                list[0] = new TTReportNqlData<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>("GetDocumentSoldFirmsByProjectObjectID", DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField SUPPLIER;
                public TTReportField Count;
                public TTReportField CountText; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 40, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 11;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 155, 5, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.Size = 11;
                    SUPPLIER.TextFont.CharSet = 162;
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    Count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 228, 5, false);
                    Count.Name = "Count";
                    Count.Visible = EvetHayirEnum.ehHayir;
                    Count.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count.Value = @"{@counter@}";

                    CountText = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 247, 5, false);
                    CountText.Name = "CountText";
                    CountText.Visible = EvetHayirEnum.ehHayir;
                    CountText.FieldType = ReportFieldTypeEnum.ftVariable;
                    CountText.TextFormat = @"NUMBERTEXT";
                    CountText.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    ORDERNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.OrderNo) : "");
                    SUPPLIER.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Supplier) : "");
                    Count.CalcValue = ParentGroup.Counter.ToString();
                    CountText.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { ORDERNO,SUPPLIER,Count,CountText};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    count = Convert.ToInt32(Count.CalcValue);
            countText = CountText.FormattedValue;
#endregion MAIN BODY_Script
                }
            }

#region MAIN_Methods
            public static int count = 0;
        public static string countText = "Sıfır";
#endregion MAIN_Methods
        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
            {
                get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField DELIVEREDBYNAME { get {return Body().DELIVEREDBYNAME;} }
            public TTReportField DELIVEREDBYDUTY { get {return Body().DELIVEREDBYDUTY;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField DESC { get {return Body().DESC;} }
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
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NewField1121;
                public TTReportField DESC; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 55;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DELIVEREDBYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 29, 170, 34, false);
                    DELIVEREDBYNAME.Name = "DELIVEREDBYNAME";
                    DELIVEREDBYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYNAME.TextFont.Name = "Arial";
                    DELIVEREDBYNAME.TextFont.CharSet = 162;
                    DELIVEREDBYNAME.Value = @"";

                    DELIVEREDBYDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 34, 170, 39, false);
                    DELIVEREDBYDUTY.Name = "DELIVEREDBYDUTY";
                    DELIVEREDBYDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYDUTY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYDUTY.TextFont.Name = "Arial";
                    DELIVEREDBYDUTY.TextFont.CharSet = 162;
                    DELIVEREDBYDUTY.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 24, 170, 29, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Teslim Eden İhale Yetkilisi";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 170, 21, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Name = "Arial";
                    DESC.TextFont.CharSet = 162;
                    DESC.Value = @"""     İhalenin başladığı saate kadar yukarıda bulunan "" + MAINGroup.count.ToString() + ""("" + MAINGroup.countText.ToString() +"") adet ihale teklif zarfı, idare marifetiyle komisyonumuza ulaşmıştır. İhale saatine kadar saklanmış olan ihale teklif zarfları ekte olup ___/___/______ tarihinde, saat ___:___'da teslim alınmıştır.""";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DELIVEREDBYNAME.CalcValue = @"";
                    DELIVEREDBYDUTY.CalcValue = @"";
                    NewField1121.CalcValue = NewField1121.Value;
                    DESC.CalcValue = "     İhalenin başladığı saate kadar yukarıda bulunan " + MAINGroup.count.ToString() + "(" + MAINGroup.countText.ToString() +") adet ihale teklif zarfı, idare marifetiyle komisyonumuza ulaşmıştır. İhale saatine kadar saklanmış olan ihale teklif zarfları ekte olup ___/___/______ tarihinde, saat ___:___'da teslim alınmıştır.";
                    return new TTReportObject[] { DELIVEREDBYNAME,DELIVEREDBYDUTY,NewField1121,DESC};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport).RuntimeParameters.DELIVEREDBY.ToString();
            ResUser ru = (ResUser)context.GetObject(new Guid(sObjectID),"ResUser");            
            DELIVEREDBYNAME.CalcValue = ru.Rank + " " + ru.Name;            
            if (ru.Title != null)
                DELIVEREDBYDUTY.CalcValue = (TTObjectClasses.Common.GetEnumValueDefOfEnumValue((Enum)ru.Title)).DisplayText;
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
            {
                get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1121 { get {return Header().NewField1121;} }
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
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                
                public TTReportField NewField1121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 170, 6, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 11;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Teslim Alan İhale Komisyonu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField1121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
            {
                get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProject.GetTenderCommisionMembersQuery_Class>("GetTenderCommisionMembersQuery", PurchaseProject.GetTenderCommisionMembersQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public IhaleZarflarininTeslimAlindiginaDairTutanak MyParentReport
                {
                    get { return (IhaleZarflarininTeslimAlindiginaDairTutanak)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 3;
                    RepeatWidth = 47;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 16, 57, 20, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 21, 57, 25, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.TextFont.CharSet = 162;
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 2, 57, 6, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.TextFont.CharSet = 162;
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 57, 15, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANK.MultiLine = EvetHayirEnum.ehEvet;
                    RANK.WordBreak = EvetHayirEnum.ehEvet;
                    RANK.TextFont.Name = "Arial";
                    RANK.TextFont.CharSet = 162;
                    RANK.Value = @"{#RANK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetTenderCommisionMembersQuery_Class dataset_GetTenderCommisionMembersQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetTenderCommisionMembersQuery_Class>(0);
                    NAMESURNAME.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Namesurname) : "");
                    HOSPFUNC.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Hospfunc) : "");
                    HOSPFUNC.PostFieldValueCalculation();
                    COMFUNC.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Comfunc) : "");
                    COMFUNC.PostFieldValueCalculation();
                    RANK.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Rank) : "");
                    return new TTReportObject[] { NAMESURNAME,HOSPFUNC,COMFUNC,RANK};
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public IhaleZarflarininTeslimAlindiginaDairTutanak()
        {
            Part1 = new Part1Group(this,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            PARTA = new PARTAGroup(Part1,"PARTA");
            PARTB = new PARTBGroup(Part1,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
            reportParameter = Parameters.Add("DELIVEREDBY", "", "Teslim Eden Yetkili", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("DELIVEREDBY"))
                _runtimeParameters.DELIVEREDBY = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DELIVEREDBY"]);
            Name = "IHALEZARFLARININTESLIMALINDIGINADAIRTUTANAK";
            Caption = "İhale Zarflarının Teslim Alındığına Dair Tutanak";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
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