
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
    /// Yetersizlik Formu_KİK013.0/M
    /// </summary>
    public partial class YetersizlikFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public YetersizlikFormu MyParentReport
            {
                get { return (YetersizlikFormu)ParentReport; }
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
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField PROJECTNO3 { get {return Header().PROJECTNO3;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField PROJECTNO4 { get {return Header().PROJECTNO4;} }
            public TTReportField SUPPLIERADDRESS { get {return Header().SUPPLIERADDRESS;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField PROJECTNO5 { get {return Header().PROJECTNO5;} }
            public TTReportField DESC { get {return Header().DESC;} }
            public TTReportField SAYI { get {return Header().SAYI;} }
            public TTReportField ILGI { get {return Header().ILGI;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO111111 { get {return Header().LOGO111111;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField DENYDESCRIPTION { get {return Header().DENYDESCRIPTION;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
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
                list[0] = new TTReportNqlData<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class>("GetUnSufficientFirmsByProjectObjectID", ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public YetersizlikFormu MyParentReport
                {
                    get { return (YetersizlikFormu)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField PROJECTNO3;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField DATE;
                public TTReportField PROJECTNO4;
                public TTReportField SUPPLIERADDRESS;
                public TTReportField SUPPLIER;
                public TTReportField PROJECTNO5;
                public TTReportField DESC;
                public TTReportField SAYI;
                public TTReportField ILGI;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO111111;
                public TTReportField ACTDEFINE;
                public TTReportField DENYDESCRIPTION;
                public TTReportField ORDERNO; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 146;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField2.Name = "NewField2";
                    NewField2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField.Name = "NewField";
                    NewField.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"SAYI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField4.Name = "NewField4";
                    NewField4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 95, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"KONU";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    PROJECTNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    PROJECTNO3.Name = "PROJECTNO3";
                    PROJECTNO3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO3.TextFont.Name = "Arial";
                    PROJECTNO3.Value = @"Yeterlilik değerlendirmesi sonucu yeterli bulunmayan adaylara/isteklilere bildirim.";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 39, 64, false);
                    NewField7.Name = "NewField7";
                    NewField7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Yeterlik Kararının Verildiği Tarih";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 59, 40, 64, false);
                    NewField8.Name = "NewField8";
                    NewField8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @":";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 59, 75, 64, false);
                    DATE.Name = "DATE";
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.Value = @"___/___/_______";

                    PROJECTNO4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 69, 170, 79, false);
                    PROJECTNO4.Name = "PROJECTNO4";
                    PROJECTNO4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO4.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO4.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO4.TextFont.Name = "Arial";
                    PROJECTNO4.Value = @"Bu mektup yeterlik kararının verildiği tarihten itibaren üç günlük süreyi aşmaksızın ___/___/______ tarihinde tarafınıza bildirilmiştir.";

                    SUPPLIERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 84, 170, 89, false);
                    SUPPLIERADDRESS.Name = "SUPPLIERADDRESS";
                    SUPPLIERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SUPPLIERADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIERADDRESS.TextFont.Name = "Arial";
                    SUPPLIERADDRESS.Value = @"{#SUPPLIERADDRESS#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 89, 170, 94, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"""       Sayın "" + {#SUPPLIER#}";

                    PROJECTNO5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 99, 10, 104, false);
                    PROJECTNO5.Name = "PROJECTNO5";
                    PROJECTNO5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO5.TextFont.Name = "Arial";
                    PROJECTNO5.TextFont.Bold = true;
                    PROJECTNO5.Value = @"İLGİ:";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 109, 170, 124, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Name = "Arial";
                    DESC.Value = @"{%ACTDEFINE%} + "" işi yeterlilik prosedürüne katıldığınız için teşekkür ederiz. Aşağıda belirtilen sebep(ler)den dolayı, yapılan değerlendirmede yeterli bulunmadığınızı üzülerek bildiriyoruz :""";

                    SAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 95, 50, false);
                    SAYI.Name = "SAYI";
                    SAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYI.TextFont.Name = "Arial";
                    SAYI.Value = @"";

                    ILGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 99, 170, 104, false);
                    ILGI.Name = "ILGI";
                    ILGI.TextFormat = @"dd/mm/yyyy";
                    ILGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ILGI.TextFont.Name = "Arial";
                    ILGI.Value = @"___/___/______ tarihinde xxxx sıra numarası ile kayda alınan yeterlilik başvurunuz.";

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

                    LOGO111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO111111.Name = "LOGO111111";
                    LOGO111111.Visible = EvetHayirEnum.ehHayir;
                    LOGO111111.TextFont.CharSet = 1;
                    LOGO111111.Value = @"LOGO";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 58, 170, 63, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.Visible = EvetHayirEnum.ehHayir;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    DENYDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 129, 170, 144, false);
                    DENYDESCRIPTION.Name = "DENYDESCRIPTION";
                    DENYDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DENYDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DENYDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DENYDESCRIPTION.TextFont.Name = "Arial";
                    DENYDESCRIPTION.Value = @"{#DESCRIPTION#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 59, 136, 64, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.Visible = EvetHayirEnum.ehHayir;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Bold = true;
                    ORDERNO.Value = @"{#ORDERNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class dataset_GetUnSufficientFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetUnSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetUnSufficientFirmsByProjectObjectID.KIKTenderRegisterNO) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    PROJECTNO3.CalcValue = PROJECTNO3.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    DATE.CalcValue = DATE.Value;
                    PROJECTNO4.CalcValue = PROJECTNO4.Value;
                    SUPPLIERADDRESS.CalcValue = (dataset_GetUnSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetUnSufficientFirmsByProjectObjectID.Supplieraddress) : "");
                    PROJECTNO5.CalcValue = PROJECTNO5.Value;
                    SAYI.CalcValue = @"";
                    ILGI.CalcValue = ILGI.Value;
                    LOGO111111.CalcValue = LOGO111111.Value;
                    ACTDEFINE.CalcValue = (dataset_GetUnSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetUnSufficientFirmsByProjectObjectID.ActDefine) : "");
                    DENYDESCRIPTION.CalcValue = (dataset_GetUnSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetUnSufficientFirmsByProjectObjectID.Description) : "");
                    ORDERNO.CalcValue = (dataset_GetUnSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetUnSufficientFirmsByProjectObjectID.OrderNo) : "");
                    SUPPLIER.CalcValue = "       Sayın " + (dataset_GetUnSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetUnSufficientFirmsByProjectObjectID.Supplier) : "");
                    DESC.CalcValue = MyParentReport.PARTB.ACTDEFINE.CalcValue + " işi yeterlilik prosedürüne katıldığınız için teşekkür ederiz. Aşağıda belirtilen sebep(ler)den dolayı, yapılan değerlendirmede yeterli bulunmadığınızı üzülerek bildiriyoruz :";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NewField,NewField3,NewField4,KIKTENDERREGISTERNO,NewField5,NewField6,PROJECTNO3,NewField7,NewField8,DATE,PROJECTNO4,SUPPLIERADDRESS,PROJECTNO5,SAYI,ILGI,LOGO111111,ACTDEFINE,DENYDESCRIPTION,ORDERNO,SUPPLIER,DESC,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string OrdNo = ORDERNO.CalcValue;
            ILGI.CalcValue = ILGI.CalcValue.ToString().Replace("xxxx", OrdNo);
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public YetersizlikFormu MyParentReport
                {
                    get { return (YetersizlikFormu)ParentReport; }
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
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class dataset_GetUnSufficientFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((YetersizlikFormu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public YetersizlikFormu MyParentReport
            {
                get { return (YetersizlikFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField133 { get {return Body().NewField133;} }
            public TTReportField NepNewField_1 { get {return Body().NepNewField_1;} }
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
                public YetersizlikFormu MyParentReport
                {
                    get { return (YetersizlikFormu)ParentReport; }
                }
                
                public TTReportField NewField133;
                public TTReportField NepNewField_1;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 75;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 50, 170, 55, false);
                    NewField133.Name = "NewField133";
                    NewField133.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.Value = @"İdare Yetkilisi";

                    NepNewField_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 45, false);
                    NepNewField_1.Name = "NepNewField_1";
                    NepNewField_1.MultiLine = EvetHayirEnum.ehEvet;
                    NepNewField_1.WordBreak = EvetHayirEnum.ehEvet;
                    NepNewField_1.TextFont.Name = "Arial";
                    NepNewField_1.Value = @"        Bu mektubun postaya verildiği tarihi izleyen yedinci gün kararın tarafınıza tebliğ edildiği tarih sayılacaktır. Bu tarihten yada bildirim mektubunun tarafınıza elden verildiği tarihten itibaren onbeş gün içinde 4734 sayılı Kanunun 54 ve 55inci maddeleri gereğince idaremize yazılı şikayette bulunmanız mümkündür. Şikayetin verilmesini izleyen otuz gün içinde idaremizce gerekçeli bir karar alınacak, yedi gün içinde tüm adaylara/isteklilere bildirilecektir. Bu süre içinde karar alınmaz yada alınan karar tarafınızdan uygun bulunmazsa, karar verme süresinin bitimini veya karar tarihini izleyen onbeş gün içinde Kamu İhale Kurumuna inceleme talebiye başvurmanız mümkündür.

    Bilgileri ve gereğini rica ederim.";

                    DELIVEREDBYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 55, 170, 60, false);
                    DELIVEREDBYNAME.Name = "DELIVEREDBYNAME";
                    DELIVEREDBYNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    DELIVEREDBYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYNAME.NoClip = EvetHayirEnum.ehEvet;
                    DELIVEREDBYNAME.TextFont.Name = "Arial";
                    DELIVEREDBYNAME.Value = @"{%RANK%} + "" "" + {%NAME%}";

                    DELIVEREDBYDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 60, 170, 65, false);
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
                    DELIVEREDBYDUTY.Value = @"{%TITLE%}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 47, 240, 52, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME.ObjectDefName = "PurchaseProject";
                    NAME.DataMember = "ADMINAUTHORIZED.NAME";
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{@TTOBJECTID@}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 55, 240, 60, false);
                    RANK.Name = "RANK";
                    RANK.Visible = EvetHayirEnum.ehHayir;
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK.ObjectDefName = "PurchaseProject";
                    RANK.DataMember = "ADMINAUTHORIZED.RANK.NAME";
                    RANK.TextFont.Name = "Arial Narrow";
                    RANK.TextFont.CharSet = 1;
                    RANK.Value = @"{@TTOBJECTID@}";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 63, 240, 68, false);
                    TITLE.Name = "TITLE";
                    TITLE.Visible = EvetHayirEnum.ehHayir;
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.ObjectDefName = "PurchaseProject";
                    TITLE.DataMember = "ADMINAUTHORIZED.TITLE";
                    TITLE.TextFont.Name = "Arial Narrow";
                    TITLE.TextFont.CharSet = 1;
                    TITLE.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField133.CalcValue = NewField133.Value;
                    NepNewField_1.CalcValue = NepNewField_1.Value;
                    TITLE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TITLE.PostFieldValueCalculation();
                    DELIVEREDBYDUTY.CalcValue = MyParentReport.MAIN.TITLE.CalcValue;
                    DELIVEREDBYDUTY.PostFieldValueCalculation();
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RANK.PostFieldValueCalculation();
                    DELIVEREDBYNAME.CalcValue = MyParentReport.MAIN.RANK.CalcValue + " " + MyParentReport.MAIN.NAME.CalcValue;
                    return new TTReportObject[] { NewField133,NepNewField_1,TITLE,DELIVEREDBYDUTY,NAME,RANK,DELIVEREDBYNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public YetersizlikFormu()
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
            Name = "YETERSIZLIKFORMU";
            Caption = "Yetersizlik Formu_KİK013.0/M";
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