
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
    /// Alındı Belgesi_KİK006.0/M (İhale)
    /// </summary>
    public partial class AlindiBelgesi_TeklifGiris : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public AlindiBelgesi_TeklifGiris MyParentReport
            {
                get { return (AlindiBelgesi_TeklifGiris)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField ALINDITARIHI { get {return Header().ALINDITARIHI;} }
            public TTReportField YETERLIKLABEL { get {return Header().YETERLIKLABEL;} }
            public TTReportField TENDERDATE { get {return Header().TENDERDATE;} }
            public TTReportField IHALETARIHLABEL { get {return Header().IHALETARIHLABEL;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO111111121 { get {return Header().LOGO111111121;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField TIME { get {return Header().TIME;} }
            public TTReportField SALEDATE { get {return Header().SALEDATE;} }
            public TTReportField SALETIME { get {return Header().SALETIME;} }
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
                public AlindiBelgesi_TeklifGiris MyParentReport
                {
                    get { return (AlindiBelgesi_TeklifGiris)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField5;
                public TTReportField ACTDEFINE;
                public TTReportField ALINDITARIHI;
                public TTReportField YETERLIKLABEL;
                public TTReportField TENDERDATE;
                public TTReportField IHALETARIHLABEL;
                public TTReportField NewField4;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField10;
                public TTReportField NewField19;
                public TTReportField ORDERNO;
                public TTReportField NewField1;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO111111121;
                public TTReportField DATE;
                public TTReportField TIME;
                public TTReportField SALEDATE;
                public TTReportField SALETIME; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 125;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 39, 65, false);
                    NewField2.Name = "NewField2";
                    NewField2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 65, 39, 70, false);
                    NewField3.Name = "NewField3";
                    NewField3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İdarenin Adı";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 60, 170, 65, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.TextFont.CharSet = 162;
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 65, 170, 70, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.CharSet = 162;
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 70, 39, 75, false);
                    NewField5.Name = "NewField5";
                    NewField5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"İşin Adı";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 70, 170, 75, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.TextFont.CharSet = 162;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    ALINDITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 84, 170, 89, false);
                    ALINDITARIHI.Name = "ALINDITARIHI";
                    ALINDITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALINDITARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ALINDITARIHI.TextFont.Name = "Arial";
                    ALINDITARIHI.TextFont.CharSet = 162;
                    ALINDITARIHI.Value = @"{%SALEDATE%} günü, saat {%SALETIME%}";

                    YETERLIKLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 75, 39, 80, false);
                    YETERLIKLABEL.Name = "YETERLIKLABEL";
                    YETERLIKLABEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERLIKLABEL.MultiLine = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL.TextFont.Name = "Arial";
                    YETERLIKLABEL.TextFont.Bold = true;
                    YETERLIKLABEL.TextFont.CharSet = 162;
                    YETERLIKLABEL.Value = @"İhale Tarih ve Saati";

                    TENDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 75, 170, 80, false);
                    TENDERDATE.Name = "TENDERDATE";
                    TENDERDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    TENDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TENDERDATE.TextFont.Name = "Arial";
                    TENDERDATE.TextFont.CharSet = 162;
                    TENDERDATE.Value = @"DATE.FormattedValue + "" günü, saat "" + TIME.FormattedValue";

                    IHALETARIHLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 80, 39, 89, false);
                    IHALETARIHLABEL.Name = "IHALETARIHLABEL";
                    IHALETARIHLABEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALETARIHLABEL.MultiLine = EvetHayirEnum.ehEvet;
                    IHALETARIHLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    IHALETARIHLABEL.TextFont.Name = "Arial";
                    IHALETARIHLABEL.TextFont.Bold = true;
                    IHALETARIHLABEL.TextFont.CharSet = 162;
                    IHALETARIHLABEL.Value = @"İhale Teklif Zarfının Verildiği Tarih ve Saat";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 84, 40, 89, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 75, 40, 80, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 70, 40, 75, false);
                    NewField7.Name = "NewField7";
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 65, 40, 70, false);
                    NewField8.Name = "NewField8";
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 60, 40, 65, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 89, 39, 94, false);
                    NewField19.Name = "NewField19";
                    NewField19.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Sıra No";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 89, 170, 94, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 89, 40, 94, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 35, 170, 58, false);
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

                    LOGO111111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 35, 40, 55, false);
                    LOGO111111121.Name = "LOGO111111121";
                    LOGO111111121.Visible = EvetHayirEnum.ehHayir;
                    LOGO111111121.TextFont.Name = "Courier New";
                    LOGO111111121.TextFont.CharSet = 1;
                    LOGO111111121.Value = @"LOGO";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 12, 239, 17, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Long Date";
                    DATE.TextFont.CharSet = 1;
                    DATE.Value = @"{#TENDERDATE#}";

                    TIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 21, 239, 26, false);
                    TIME.Name = "TIME";
                    TIME.Visible = EvetHayirEnum.ehHayir;
                    TIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIME.TextFormat = @"Short Time";
                    TIME.TextFont.CharSet = 1;
                    TIME.Value = @"{#TENDERDATE#}";

                    SALEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 34, 239, 39, false);
                    SALEDATE.Name = "SALEDATE";
                    SALEDATE.Visible = EvetHayirEnum.ehHayir;
                    SALEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SALEDATE.TextFormat = @"Long Date";
                    SALEDATE.TextFont.CharSet = 1;
                    SALEDATE.Value = @"{#SALEDATE#}";

                    SALETIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 42, 239, 47, false);
                    SALETIME.Name = "SALETIME";
                    SALETIME.Visible = EvetHayirEnum.ehHayir;
                    SALETIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SALETIME.TextFormat = @"Short Time";
                    SALETIME.TextFont.CharSet = 1;
                    SALETIME.Value = @"{#SALEDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.KIKTenderRegisterNO) : "");
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Responsibleprocurementunitdef) : "");
                    NewField5.CalcValue = NewField5.Value;
                    ACTDEFINE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.ActDefine) : "");
                    SALEDATE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.SaleDate) : "");
                    SALETIME.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.SaleDate) : "");
                    ALINDITARIHI.CalcValue = MyParentReport.PARTB.SALEDATE.FormattedValue + @" günü, saat " + MyParentReport.PARTB.SALETIME.FormattedValue;
                    YETERLIKLABEL.CalcValue = YETERLIKLABEL.Value;
                    IHALETARIHLABEL.CalcValue = IHALETARIHLABEL.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField19.CalcValue = NewField19.Value;
                    ORDERNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.OrderNo) : "");
                    NewField1.CalcValue = NewField1.Value;
                    LOGO111111121.CalcValue = LOGO111111121.Value;
                    DATE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.TenderDate) : "");
                    TIME.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.TenderDate) : "");
                    TENDERDATE.CalcValue = DATE.FormattedValue + " günü, saat " + TIME.FormattedValue;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NewField3,KIKTENDERREGISTERNO,RESPONSIBLEPROCUREMENTUNITDEF,NewField5,ACTDEFINE,SALEDATE,SALETIME,ALINDITARIHI,YETERLIKLABEL,IHALETARIHLABEL,NewField4,NewField6,NewField7,NewField8,NewField10,NewField19,ORDERNO,NewField1,LOGO111111121,DATE,TIME,TENDERDATE,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public AlindiBelgesi_TeklifGiris MyParentReport
                {
                    get { return (AlindiBelgesi_TeklifGiris)ParentReport; }
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
                    string objectID = ((AlindiBelgesi_TeklifGiris)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public AlindiBelgesi_TeklifGiris MyParentReport
            {
                get { return (AlindiBelgesi_TeklifGiris)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HEADYETERLIK11 { get {return Body().HEADYETERLIK11;} }
            public TTReportField DESCYETERLIK { get {return Body().DESCYETERLIK;} }
            public TTReportField FIRMA { get {return Body().FIRMA;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
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

             
            protected override object[] GetGroupByValues()
            {

                DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataSet_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);    
                return new object[] {(dataSet_GetDocumentSoldFirmsByProjectObjectID==null ? null : dataSet_GetDocumentSoldFirmsByProjectObjectID.ObjectID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public AlindiBelgesi_TeklifGiris MyParentReport
                {
                    get { return (AlindiBelgesi_TeklifGiris)ParentReport; }
                }
                
                public TTReportField HEADYETERLIK11;
                public TTReportField DESCYETERLIK;
                public TTReportField FIRMA;
                public TTReportField NewField141;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 69;
                    RepeatCount = 0;
                    
                    HEADYETERLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 11, false);
                    HEADYETERLIK11.Name = "HEADYETERLIK11";
                    HEADYETERLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADYETERLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADYETERLIK11.TextFont.Name = "Arial";
                    HEADYETERLIK11.TextFont.Size = 11;
                    HEADYETERLIK11.TextFont.Bold = true;
                    HEADYETERLIK11.TextFont.CharSet = 162;
                    HEADYETERLIK11.Value = @"İHALE TEKLİF ZARFI ALINDI BELGESİ";

                    DESCYETERLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 170, 30, false);
                    DESCYETERLIK.Name = "DESCYETERLIK";
                    DESCYETERLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESCYETERLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCYETERLIK.MultiLine = EvetHayirEnum.ehEvet;
                    DESCYETERLIK.WordBreak = EvetHayirEnum.ehEvet;
                    DESCYETERLIK.TextFont.Name = "Arial";
                    DESCYETERLIK.TextFont.CharSet = 162;
                    DESCYETERLIK.Value = @"""       "" + {%FIRMA%} + "" adlı adaya ait ihale teklif zarfı, yukarıda belirtilen sıra numarası ile kayda alınarak, yine yukarıda belirtilen tarih ve saatte teslim alınmıştır.""";

                    FIRMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 3, 219, 8, false);
                    FIRMA.Name = "FIRMA";
                    FIRMA.Visible = EvetHayirEnum.ehHayir;
                    FIRMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMA.CaseFormat = CaseFormatEnum.fcTitleCase;
                    FIRMA.Value = @"{#PARTB.SUPPLIER#}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 40, 170, 45, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Underline = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"TESLİM ALAN İDARE YETKİLİSİ";

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

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 29, 247, 34, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME.ObjectDefName = "PurchaseProject";
                    NAME.DataMember = "ADMINAUTHORIZED.NAME";
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{@TTOBJECTID@}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 37, 247, 42, false);
                    RANK.Name = "RANK";
                    RANK.Visible = EvetHayirEnum.ehHayir;
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK.ObjectDefName = "PurchaseProject";
                    RANK.DataMember = "ADMINAUTHORIZED.RANK.NAME";
                    RANK.TextFont.CharSet = 1;
                    RANK.Value = @"{@TTOBJECTID@}";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 45, 247, 50, false);
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
                    NewField141.CalcValue = NewField141.Value;
                    TITLE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TITLE.PostFieldValueCalculation();
                    DELIVEREDBYDUTY.CalcValue = MyParentReport.MAIN.TITLE.CalcValue;
                    DELIVEREDBYDUTY.PostFieldValueCalculation();
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RANK.PostFieldValueCalculation();
                    DESCYETERLIK.CalcValue = "       " + MyParentReport.MAIN.FIRMA.CalcValue + " adlı adaya ait ihale teklif zarfı, yukarıda belirtilen sıra numarası ile kayda alınarak, yine yukarıda belirtilen tarih ve saatte teslim alınmıştır.";
                    DELIVEREDBYNAME.CalcValue = MyParentReport.MAIN.RANK.CalcValue + " " + MyParentReport.MAIN.NAME.CalcValue;
                    return new TTReportObject[] { HEADYETERLIK11,FIRMA,NewField141,TITLE,DELIVEREDBYDUTY,NAME,RANK,DESCYETERLIK,DELIVEREDBYNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AlindiBelgesi_TeklifGiris()
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
            Name = "ALINDIBELGESI_TEKLIFGIRIS";
            Caption = "Alındı Belgesi_KİK006.0/M (İhale)";
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