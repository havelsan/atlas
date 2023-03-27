
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
    /// Yatan Hasta Reçete Çıkış Çizelgesi
    /// </summary>
    public partial class InpatientPrescriptionOutSchedule : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public InpatientPrescriptionOutSchedule MyParentReport
            {
                get { return (InpatientPrescriptionOutSchedule)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public InpatientPrescriptionOutSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionOutSchedule)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField DATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 185, 20, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"XXXXXX BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN {%DATE%} TARİHİNE AİT YATAN HASTA ÇIKIŞ ÇİZELGESİDİR.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 24, 10, 33, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA
NU.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 70, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ECZANE ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 24, 90, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"REÇETE
MİKTARI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 24, 126, 33, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"TUTAR TOPLAMI";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 24, 185, 33, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"TESLİM ALAN ECZACI KAŞE İMZA";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 15, 239, 20, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.Value = @"{@DATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    HEADER.CalcValue = @"XXXXXX BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN " + MyParentReport.PARTA.DATE.FormattedValue + @" TARİHİNE AİT YATAN HASTA ÇIKIŞ ÇİZELGESİDİR.";
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    return new TTReportObject[] { DATE,HEADER,NewField1,NewField11,NewField12,NewField13,NewField14};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public InpatientPrescriptionOutSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionOutSchedule)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 110, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 185, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 185, 0, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

#region PARTA_Methods
            public static int prescriptionCount = 0;
        public static double balance = 0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientPrescriptionOutSchedule MyParentReport
            {
                get { return (InpatientPrescriptionOutSchedule)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PRESCRIPTIONCOUNTTEXT { get {return Body().PRESCRIPTIONCOUNTTEXT;} }
            public TTReportField PRESCRIPTIONCOUNT { get {return Body().PRESCRIPTIONCOUNT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PHARMACY { get {return Body().PHARMACY;} }
            public TTReportField BALANCE { get {return Body().BALANCE;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<PrescriptionDistribute.GetExternalPharmacyBalance_Class>("GetExternalPharmacyBalance", PrescriptionDistribute.GetExternalPharmacyBalance((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.DATE)));
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
                public InpatientPrescriptionOutSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionOutSchedule)ParentReport; }
                }
                
                public TTReportField PRESCRIPTIONCOUNTTEXT;
                public TTReportField PRESCRIPTIONCOUNT;
                public TTReportField ORDERNO;
                public TTReportField PHARMACY;
                public TTReportField BALANCE;
                public TTReportField NewField141;
                public TTReportShape NewLine11;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    PRESCRIPTIONCOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 10, 90, 20, false);
                    PRESCRIPTIONCOUNTTEXT.Name = "PRESCRIPTIONCOUNTTEXT";
                    PRESCRIPTIONCOUNTTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRESCRIPTIONCOUNTTEXT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNTTEXT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNTTEXT.Value = @"Adet";

                    PRESCRIPTIONCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 90, 10, false);
                    PRESCRIPTIONCOUNT.Name = "PRESCRIPTIONCOUNT";
                    PRESCRIPTIONCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRESCRIPTIONCOUNT.VertAlign = VerticalAlignmentEnum.vaBottom;
                    PRESCRIPTIONCOUNT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNT.Value = @"{#PRESCRIPTIONCOUNT#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 10, 20, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}.";

                    PHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 70, 20, false);
                    PHARMACY.Name = "PHARMACY";
                    PHARMACY.DrawStyle = DrawStyleConstants.vbSolid;
                    PHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHARMACY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PHARMACY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PHARMACY.ObjectDefName = "ExternalPharmacy";
                    PHARMACY.DataMember = "NAME";
                    PHARMACY.TextFont.Name = "Arial";
                    PHARMACY.TextFont.CharSet = 162;
                    PHARMACY.Value = @"{#EXTERNALPHARMACY#}";

                    BALANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 126, 20, false);
                    BALANCE.Name = "BALANCE";
                    BALANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    BALANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BALANCE.TextFormat = @"Currency";
                    BALANCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BALANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BALANCE.TextFont.Name = "Arial";
                    BALANCE.TextFont.CharSet = 162;
                    BALANCE.Value = @"{#BALANCE#}   ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 0, 185, 20, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 70, 0, 90, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 70, 20, 90, 20, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetExternalPharmacyBalance_Class dataset_GetExternalPharmacyBalance = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetExternalPharmacyBalance_Class>(0);
                    PRESCRIPTIONCOUNTTEXT.CalcValue = PRESCRIPTIONCOUNTTEXT.Value;
                    PRESCRIPTIONCOUNT.CalcValue = (dataset_GetExternalPharmacyBalance != null ? Globals.ToStringCore(dataset_GetExternalPharmacyBalance.Prescriptioncount) : "");
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @".";
                    PHARMACY.CalcValue = (dataset_GetExternalPharmacyBalance != null ? Globals.ToStringCore(dataset_GetExternalPharmacyBalance.ExternalPharmacy) : "");
                    PHARMACY.PostFieldValueCalculation();
                    BALANCE.CalcValue = (dataset_GetExternalPharmacyBalance != null ? Globals.ToStringCore(dataset_GetExternalPharmacyBalance.Balance) : "") + @"   ";
                    NewField141.CalcValue = NewField141.Value;
                    return new TTReportObject[] { PRESCRIPTIONCOUNTTEXT,PRESCRIPTIONCOUNT,ORDERNO,PHARMACY,BALANCE,NewField141};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    PARTAGroup.prescriptionCount += Convert.ToInt32(PRESCRIPTIONCOUNT.CalcValue);
            PARTAGroup.balance += Convert.ToDouble(BALANCE.CalcValue);
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MAIN2Group : TTReportGroup
        {
            public InpatientPrescriptionOutSchedule MyParentReport
            {
                get { return (InpatientPrescriptionOutSchedule)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
            public TTReportField COUNTTEXT { get {return Body().COUNTTEXT;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public InpatientPrescriptionOutSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionOutSchedule)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField COUNTTEXT; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 185, 8, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.NoClip = EvetHayirEnum.ehEvet;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 3, 240, 8, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.TextFormat = @"NUMBERTEXT";
                    COUNTTEXT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTAL.CalcValue = @"";
                    COUNTTEXT.CalcValue = @"";
                    return new TTReportObject[] { TOTAL,COUNTTEXT};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    COUNTTEXT.CalcValue = PARTAGroup.prescriptionCount.ToString();
                    TOTAL.CalcValue = MyParentReport.RuntimeParameters.DATE.Value.ToShortDateString() + " TARİHİNE AİT TOPLAM "
                        + PARTAGroup.prescriptionCount.ToString() + " (" + COUNTTEXT.FormattedValue + ") ADET REÇETE BEDELİ " + PARTAGroup.balance.ToString() + " TL DİR.";
                    PARTAGroup.balance = 0;
                    PARTAGroup.prescriptionCount = 0;
#endregion MAIN2 BODY_Script
                }
            }

        }

        public MAIN2Group MAIN2;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InpatientPrescriptionOutSchedule()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            MAIN2 = new MAIN2Group(PARTA,"MAIN2");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DATE", "", "Tarih Seçiniz :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DATE"))
                _runtimeParameters.DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["DATE"]);
            Name = "INPATIENTPRESCRIPTIONOUTSCHEDULE";
            Caption = "Yatan Hasta Reçete Çıkış Çizelgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 15;
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