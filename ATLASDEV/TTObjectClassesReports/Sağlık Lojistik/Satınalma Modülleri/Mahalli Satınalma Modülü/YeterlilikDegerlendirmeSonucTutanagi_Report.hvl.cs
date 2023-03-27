
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
    /// Yeterlilik Değerlendirme Sonuç Tutanağı_KİK012.0/M
    /// </summary>
    public partial class YeterlilikDegerlendirmeSonucTutanagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO12111111 { get {return Header().LOGO12111111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField5;
                public TTReportField NewField7;
                public TTReportField DATE;
                public TTReportField ACTDEFINE;
                public TTReportField NewField181;
                public TTReportField NewField12;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO12111111;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField NewField111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 79;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İdarenin Adı";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 170, 50, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"İşin Adı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 39, 65, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Tutanağın Doldurulduğu Tarih";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 59, 170, 64, false);
                    DATE.Name = "DATE";
                    DATE.TextFormat = @"dd/mm/yyyy hh:mm";
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.Size = 11;
                    DATE.Value = @"___/___/_______";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField181.Name = "NewField181";
                    NewField181.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"İhale Kayıt Numarası";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 170, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

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
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO12111111.Name = "LOGO12111111";
                    LOGO12111111.Visible = EvetHayirEnum.ehHayir;
                    LOGO12111111.TextFont.CharSet = 1;
                    LOGO12111111.Value = @"LOGO";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField121.Name = "NewField121";
                    NewField121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField122.Name = "NewField122";
                    NewField122.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 59, 40, 64, false);
                    NewField123.Name = "NewField123";
                    NewField123.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Name = "Arial";
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @":";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 70, 170, 76, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"YETERLİK DEĞERLENDİRME SONUCU TUTANAĞI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField7.CalcValue = NewField7.Value;
                    DATE.CalcValue = DATE.Value;
                    ACTDEFINE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "");
                    NewField181.CalcValue = NewField181.Value;
                    NewField12.CalcValue = NewField12.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.KIKTenderRegisterNO) : "");
                    LOGO12111111.CalcValue = LOGO12111111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField111.CalcValue = NewField111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField3,RESPONSIBLEPROCUREMENTUNITDEF,NewField5,NewField7,DATE,ACTDEFINE,NewField181,NewField12,KIKTENDERREGISTERNO,LOGO12111111,NewField121,NewField122,NewField123,NewField111,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
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
                    PROJECTNO.Value = @" Proje Nu. : {#PURCHASEPROJECTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    PROJECTNO.CalcValue = @" Proje Nu. : " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PurchaseProjectNO) : "");
                    return new TTReportObject[] { PROJECTNO};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTDGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
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
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"YETERLİK BAŞVURUSUNDA BULUNAN ADAYLAR
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class FIRMGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public FIRMGroupBody Body()
            {
                return (FIRMGroupBody)_body;
            }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public FIRMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class>("GetAllFirmsByProjectObjectID", ProjectFirmSufficiency.GetAllFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIRMGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class FIRMGroupBody : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField NO;
                public TTReportField SUPPLIER; 
                public FIRMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 5, 5, false);
                    NO.Name = "NO";
                    NO.DrawStyle = DrawStyleConstants.vbSolid;
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NO.TextFont.Name = "Arial";
                    NO.Value = @"{@counter@}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 170, 5, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class dataset_GetAllFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class>(0);
                    NO.CalcValue = ParentGroup.Counter.ToString();
                    SUPPLIER.CalcValue = (dataset_GetAllFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetAllFirmsByProjectObjectID.Supplier) : "");
                    return new TTReportObject[] { NO,SUPPLIER};
                }
            }

        }

        public FIRMGroup FIRM;

        public partial class PARTFGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField YETERSIZ1 { get {return Header().YETERSIZ1;} }
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
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField NewField19;
                public TTReportField NewField15;
                public TTReportField NewField1;
                public TTReportField YETERSIZ1; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 11, false);
                    NewField19.Name = "NewField19";
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 11;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"DEĞERLENDİRMEYE ALINAN ADAYLARIN YETERLİK DEĞERLENDİRME SONUCU
";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 15, 98, 20, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Yeterli/Yeterli Değil";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 64, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"";

                    YETERSIZ1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 15, 170, 20, false);
                    YETERSIZ1.Name = "YETERSIZ1";
                    YETERSIZ1.DrawStyle = DrawStyleConstants.vbSolid;
                    YETERSIZ1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YETERSIZ1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YETERSIZ1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERSIZ1.TextFont.Name = "Arial";
                    YETERSIZ1.TextFont.Bold = true;
                    YETERSIZ1.Value = @"Yeterli Bulunmama Gerekçesi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField19.CalcValue = NewField19.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField1.CalcValue = NewField1.Value;
                    YETERSIZ1.CalcValue = YETERSIZ1.Value;
                    return new TTReportObject[] { NewField19,NewField15,NewField1,YETERSIZ1};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTFGroup PARTF;

        public partial class SUFFICIENTGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public SUFFICIENTGroupBody Body()
            {
                return (SUFFICIENTGroupBody)_body;
            }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField YETERLI_YETERSIZ { get {return Body().YETERLI_YETERSIZ;} }
            public TTReportField REASON { get {return Body().REASON;} }
            public TTReportField SUFFICIENT { get {return Body().SUFFICIENT;} }
            public SUFFICIENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUFFICIENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class>("GetAllFirmsByProjectObjectID", ProjectFirmSufficiency.GetAllFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SUFFICIENTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SUFFICIENTGroupBody : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField SUPPLIER;
                public TTReportField YETERLI_YETERSIZ;
                public TTReportField REASON;
                public TTReportField SUFFICIENT; 
                public SUFFICIENTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 64, 10, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    YETERLI_YETERSIZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 98, 10, false);
                    YETERLI_YETERSIZ.Name = "YETERLI_YETERSIZ";
                    YETERLI_YETERSIZ.DrawStyle = DrawStyleConstants.vbSolid;
                    YETERLI_YETERSIZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    YETERLI_YETERSIZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YETERLI_YETERSIZ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERLI_YETERSIZ.MultiLine = EvetHayirEnum.ehEvet;
                    YETERLI_YETERSIZ.TextFont.Name = "Arial";
                    YETERLI_YETERSIZ.Value = @"";

                    REASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 0, 170, 10, false);
                    REASON.Name = "REASON";
                    REASON.DrawStyle = DrawStyleConstants.vbSolid;
                    REASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    REASON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REASON.MultiLine = EvetHayirEnum.ehEvet;
                    REASON.WordBreak = EvetHayirEnum.ehEvet;
                    REASON.TextFont.Name = "Arial";
                    REASON.Value = @"{#DESCRIPTION#}";

                    SUFFICIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 0, 240, 5, false);
                    SUFFICIENT.Name = "SUFFICIENT";
                    SUFFICIENT.Visible = EvetHayirEnum.ehHayir;
                    SUFFICIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUFFICIENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUFFICIENT.TextFont.Name = "Arial";
                    SUFFICIENT.Value = @"{#SUFFICIENT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class dataset_GetAllFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class>(0);
                    SUPPLIER.CalcValue = (dataset_GetAllFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetAllFirmsByProjectObjectID.Supplier) : "");
                    YETERLI_YETERSIZ.CalcValue = @"";
                    REASON.CalcValue = (dataset_GetAllFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetAllFirmsByProjectObjectID.Description) : "");
                    SUFFICIENT.CalcValue = (dataset_GetAllFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetAllFirmsByProjectObjectID.Sufficient) : "");
                    return new TTReportObject[] { SUPPLIER,YETERLI_YETERSIZ,REASON,SUFFICIENT};
                }

                public override void RunScript()
                {
#region SUFFICIENT BODY_Script
                    if (SUFFICIENT.CalcValue == "False")
                YETERLI_YETERSIZ.CalcValue = "YETERLİ\nDEĞİL";
            else
                YETERLI_YETERSIZ.CalcValue = "YETERLİ";
#endregion SUFFICIENT BODY_Script
                }
            }

        }

        public SUFFICIENTGroup SUFFICIENT;

        public partial class PARTAGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PROJECTNO14 { get {return Header().PROJECTNO14;} }
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
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField PROJECTNO14; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 10, false);
                    PROJECTNO14.Name = "PROJECTNO14";
                    PROJECTNO14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO14.TextFont.Name = "Arial";
                    PROJECTNO14.TextFont.Bold = true;
                    PROJECTNO14.Value = @"İHALE KOMİSYONU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO14.CalcValue = PROJECTNO14.Value;
                    return new TTReportObject[] { PROJECTNO14};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class TENDERCOMMISIONGroup : TTReportGroup
        {
            public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
            {
                get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
            }

            new public TENDERCOMMISIONGroupBody Body()
            {
                return (TENDERCOMMISIONGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public TENDERCOMMISIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TENDERCOMMISIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _body = new TENDERCOMMISIONGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TENDERCOMMISIONGroupBody : TTReportSection
            {
                public YeterlilikDegerlendirmeSonucTutanagi MyParentReport
                {
                    get { return (YeterlilikDegerlendirmeSonucTutanagi)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public TENDERCOMMISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    RepeatCount = 3;
                    RepeatWidth = 47;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 57, 19, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 57, 24, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 5, 57, 9, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 10, 57, 14, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK.NoClip = EvetHayirEnum.ehEvet;
                    RANK.TextFont.Name = "Arial";
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

        public TENDERCOMMISIONGroup TENDERCOMMISION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public YeterlilikDegerlendirmeSonucTutanagi()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTD = new PARTDGroup(PARTB,"PARTD");
            FIRM = new FIRMGroup(PARTD,"FIRM");
            PARTF = new PARTFGroup(PARTB,"PARTF");
            SUFFICIENT = new SUFFICIENTGroup(PARTF,"SUFFICIENT");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            TENDERCOMMISION = new TENDERCOMMISIONGroup(PARTA,"TENDERCOMMISION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "YETERLILIKDEGERLENDIRMESONUCTUTANAGI";
            Caption = "Yeterlilik Değerlendirme Sonuç Tutanağı_KİK012.0/M";
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