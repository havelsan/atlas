
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
    /// Alındı Belgesi_KİK006.0/M (Yeterlik)
    /// </summary>
    public partial class AlindiBelgesi_Yeterlik : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public AlindiBelgesi_Yeterlik MyParentReport
            {
                get { return (AlindiBelgesi_Yeterlik)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField ALINDITARIHI { get {return Header().ALINDITARIHI;} }
            public TTReportField YETERLIKLABEL { get {return Header().YETERLIKLABEL;} }
            public TTReportField SUFFICIENCYDUEDATE { get {return Header().SUFFICIENCYDUEDATE;} }
            public TTReportField IHALETARIHLABEL { get {return Header().IHALETARIHLABEL;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO1121111111 { get {return Header().LOGO1121111111;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField TIME { get {return Header().TIME;} }
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
                list[0] = new TTReportNqlData<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>("GetDocumentSoldFirmsByProjectObjectID", DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public AlindiBelgesi_Yeterlik MyParentReport
                {
                    get { return (AlindiBelgesi_Yeterlik)ParentReport; }
                }
                
                public TTReportField ALINDITARIHI;
                public TTReportField YETERLIKLABEL;
                public TTReportField SUFFICIENCYDUEDATE;
                public TTReportField IHALETARIHLABEL;
                public TTReportField NewField4;
                public TTReportField NewField6;
                public TTReportField NewField19;
                public TTReportField ORDERNO;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField15;
                public TTReportField ACTDEFINE;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField101;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO1121111111;
                public TTReportField DATE;
                public TTReportField TIME; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 110;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ALINDITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 68, 170, 73, false);
                    ALINDITARIHI.Name = "ALINDITARIHI";
                    ALINDITARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ALINDITARIHI.TextFont.Name = "Arial";
                    ALINDITARIHI.TextFont.CharSet = 162;
                    ALINDITARIHI.Value = @"____/____/________ ..................... günü, saat ____:____";

                    YETERLIKLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 39, 64, false);
                    YETERLIKLABEL.Name = "YETERLIKLABEL";
                    YETERLIKLABEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERLIKLABEL.MultiLine = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL.TextFont.Name = "Arial";
                    YETERLIKLABEL.TextFont.Bold = true;
                    YETERLIKLABEL.TextFont.CharSet = 162;
                    YETERLIKLABEL.Value = @"Son Başvuru Tarih ve Saati";

                    SUFFICIENCYDUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 59, 170, 64, false);
                    SUFFICIENCYDUEDATE.Name = "SUFFICIENCYDUEDATE";
                    SUFFICIENCYDUEDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUFFICIENCYDUEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUFFICIENCYDUEDATE.TextFont.Name = "Arial";
                    SUFFICIENCYDUEDATE.TextFont.CharSet = 162;
                    SUFFICIENCYDUEDATE.Value = @"DATE.FormattedValue + "" günü, saat "" + TIME.FormattedValue";

                    IHALETARIHLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 64, 39, 73, false);
                    IHALETARIHLABEL.Name = "IHALETARIHLABEL";
                    IHALETARIHLABEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALETARIHLABEL.MultiLine = EvetHayirEnum.ehEvet;
                    IHALETARIHLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    IHALETARIHLABEL.TextFont.Name = "Arial";
                    IHALETARIHLABEL.TextFont.Bold = true;
                    IHALETARIHLABEL.TextFont.CharSet = 162;
                    IHALETARIHLABEL.Value = @"Yeterlik Başvurusunun Verildiği Tarih ve Saat";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 68, 40, 73, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 59, 40, 64, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 73, 39, 78, false);
                    NewField19.Name = "NewField19";
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Sıra No";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 73, 170, 78, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 73, 40, 78, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İhale Kayıt Numarası";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField13.Name = "NewField13";
                    NewField13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İdarenin Adı";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 170, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.TextFont.CharSet = 162;
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 170, 50, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.CharSet = 162;
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField15.Name = "NewField15";
                    NewField15.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"İşin Adı";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.TextFont.CharSet = 162;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField17.Name = "NewField17";
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField101.Name = "NewField101";
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Bold = true;
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @":";

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

                    LOGO1121111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO1121111111.Name = "LOGO1121111111";
                    LOGO1121111111.Visible = EvetHayirEnum.ehHayir;
                    LOGO1121111111.TextFont.Name = "Courier New";
                    LOGO1121111111.TextFont.CharSet = 1;
                    LOGO1121111111.Value = @"LOGO";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 15, 237, 20, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Long Date";
                    DATE.TextFont.CharSet = 1;
                    DATE.Value = @"{#SUFFICIENCYDUEDATE#}";

                    TIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 24, 237, 29, false);
                    TIME.Name = "TIME";
                    TIME.Visible = EvetHayirEnum.ehHayir;
                    TIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIME.TextFormat = @"Short Time";
                    TIME.TextFont.CharSet = 1;
                    TIME.Value = @"{#SUFFICIENCYDUEDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    ALINDITARIHI.CalcValue = ALINDITARIHI.Value;
                    YETERLIKLABEL.CalcValue = YETERLIKLABEL.Value;
                    IHALETARIHLABEL.CalcValue = IHALETARIHLABEL.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField19.CalcValue = NewField19.Value;
                    ORDERNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.OrderNo) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.KIKTenderRegisterNO) : "");
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Responsibleprocurementunitdef) : "");
                    NewField15.CalcValue = NewField15.Value;
                    ACTDEFINE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.ActDefine) : "");
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField101.CalcValue = NewField101.Value;
                    LOGO1121111111.CalcValue = LOGO1121111111.Value;
                    DATE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.SufficiencyDueDate) : "");
                    TIME.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.SufficiencyDueDate) : "");
                    SUFFICIENCYDUEDATE.CalcValue = DATE.FormattedValue + " günü, saat " + TIME.FormattedValue;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { ALINDITARIHI,YETERLIKLABEL,IHALETARIHLABEL,NewField4,NewField6,NewField19,ORDERNO,NewField1,NewField12,NewField13,KIKTENDERREGISTERNO,RESPONSIBLEPROCUREMENTUNITDEF,NewField15,ACTDEFINE,NewField17,NewField18,NewField101,LOGO1121111111,DATE,TIME,SUFFICIENCYDUEDATE,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public AlindiBelgesi_Yeterlik MyParentReport
                {
                    get { return (AlindiBelgesi_Yeterlik)ParentReport; }
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
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((AlindiBelgesi_Yeterlik)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public AlindiBelgesi_Yeterlik MyParentReport
            {
                get { return (AlindiBelgesi_Yeterlik)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HEADYETERLIK11 { get {return Body().HEADYETERLIK11;} }
            public TTReportField DESCYETERLIK { get {return Body().DESCYETERLIK;} }
            public TTReportField FIRMA { get {return Body().FIRMA;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField DELIVEREDBYNAME { get {return Body().DELIVEREDBYNAME;} }
            public TTReportField DELIVEREDBYDUTY { get {return Body().DELIVEREDBYDUTY;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public TTReportField TITLE { get {return Body().TITLE;} }
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
                public AlindiBelgesi_Yeterlik MyParentReport
                {
                    get { return (AlindiBelgesi_Yeterlik)ParentReport; }
                }
                
                public TTReportField HEADYETERLIK11;
                public TTReportField DESCYETERLIK;
                public TTReportField FIRMA;
                public TTReportField NewField1141;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 67;
                    RepeatCount = 0;
                    
                    HEADYETERLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 11, false);
                    HEADYETERLIK11.Name = "HEADYETERLIK11";
                    HEADYETERLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADYETERLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADYETERLIK11.TextFont.Name = "Arial";
                    HEADYETERLIK11.TextFont.Size = 11;
                    HEADYETERLIK11.TextFont.Bold = true;
                    HEADYETERLIK11.TextFont.CharSet = 162;
                    HEADYETERLIK11.Value = @"YETERLİK BAŞVURUSU ALINDI BELGESİ";

                    DESCYETERLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 170, 30, false);
                    DESCYETERLIK.Name = "DESCYETERLIK";
                    DESCYETERLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESCYETERLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCYETERLIK.MultiLine = EvetHayirEnum.ehEvet;
                    DESCYETERLIK.WordBreak = EvetHayirEnum.ehEvet;
                    DESCYETERLIK.TextFont.Name = "Arial";
                    DESCYETERLIK.TextFont.CharSet = 162;
                    DESCYETERLIK.Value = @"""       "" + {%FIRMA%} + "" adlı adaya ait yeterlik başvurusu, yukarıda belirtilen sıra numarası ile kayda alınarak, yine yukarıda belirtilen tarih ve saatte teslim alınmıştır.""";

                    FIRMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 3, 219, 8, false);
                    FIRMA.Name = "FIRMA";
                    FIRMA.Visible = EvetHayirEnum.ehHayir;
                    FIRMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMA.CaseFormat = CaseFormatEnum.fcTitleCase;
                    FIRMA.Value = @"{#PARTB.SUPPLIER#}";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 40, 170, 45, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Underline = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"TESLİM ALAN İDARE YETKİLİSİ";

                    DELIVEREDBYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 45, 170, 50, false);
                    DELIVEREDBYNAME.Name = "DELIVEREDBYNAME";
                    DELIVEREDBYNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    DELIVEREDBYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYNAME.NoClip = EvetHayirEnum.ehEvet;
                    DELIVEREDBYNAME.TextFont.Name = "Arial";
                    DELIVEREDBYNAME.TextFont.CharSet = 162;
                    DELIVEREDBYNAME.Value = @"{%RANK%} + "" "" + {%NAME%}";

                    DELIVEREDBYDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 50, 170, 55, false);
                    DELIVEREDBYDUTY.Name = "DELIVEREDBYDUTY";
                    DELIVEREDBYDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYDUTY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYDUTY.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVEREDBYDUTY.WordBreak = EvetHayirEnum.ehEvet;
                    DELIVEREDBYDUTY.ObjectDefName = "UserTitleEnum";
                    DELIVEREDBYDUTY.DataMember = "DISPLAYTEXT";
                    DELIVEREDBYDUTY.TextFont.Name = "Arial";
                    DELIVEREDBYDUTY.TextFont.CharSet = 162;
                    DELIVEREDBYDUTY.Value = @"{%TITLE%}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 33, 247, 38, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME.ObjectDefName = "PurchaseProject";
                    NAME.DataMember = "ADMINAUTHORIZED.NAME";
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{@TTOBJECTID@}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 41, 247, 46, false);
                    RANK.Name = "RANK";
                    RANK.Visible = EvetHayirEnum.ehHayir;
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK.ObjectDefName = "PurchaseProject";
                    RANK.DataMember = "ADMINAUTHORIZED.RANK.NAME";
                    RANK.TextFont.CharSet = 1;
                    RANK.Value = @"{@TTOBJECTID@}";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 49, 247, 54, false);
                    TITLE.Name = "TITLE";
                    TITLE.Visible = EvetHayirEnum.ehHayir;
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.ObjectDefName = "PurchaseProject";
                    TITLE.DataMember = "ADMINAUTHORIZED.TITLE";
                    TITLE.TextFont.CharSet = 1;
                    TITLE.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = MyParentReport.PARTB.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    HEADYETERLIK11.CalcValue = HEADYETERLIK11.Value;
                    FIRMA.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Supplier) : "");
                    NewField1141.CalcValue = NewField1141.Value;
                    TITLE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TITLE.PostFieldValueCalculation();
                    DELIVEREDBYDUTY.CalcValue = MyParentReport.MAIN.TITLE.CalcValue;
                    DELIVEREDBYDUTY.PostFieldValueCalculation();
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RANK.PostFieldValueCalculation();
                    DESCYETERLIK.CalcValue = "       " + MyParentReport.MAIN.FIRMA.CalcValue + " adlı adaya ait yeterlik başvurusu, yukarıda belirtilen sıra numarası ile kayda alınarak, yine yukarıda belirtilen tarih ve saatte teslim alınmıştır.";
                    DELIVEREDBYNAME.CalcValue = MyParentReport.MAIN.RANK.CalcValue + " " + MyParentReport.MAIN.NAME.CalcValue;
                    return new TTReportObject[] { HEADYETERLIK11,FIRMA,NewField1141,TITLE,DELIVEREDBYDUTY,NAME,RANK,DESCYETERLIK,DELIVEREDBYNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AlindiBelgesi_Yeterlik()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ALINDIBELGESI_YETERLIK";
            Caption = "Alındı Belgesi_KİK006.0/M (Yeterlik)";
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
            fd.TextFont.CharSet = 0;
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