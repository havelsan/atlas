
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
    /// Günlük Reçete Dağıtım Çizelgesi
    /// </summary>
    public partial class EczaneDagilimGraph : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public EczaneDagilimGraph MyParentReport
            {
                get { return (EczaneDagilimGraph)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
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
                public EczaneDagilimGraph MyParentReport
                {
                    get { return (EczaneDagilimGraph)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField2;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField1141;
                public TTReportField NewField16;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportField NewField1341; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 33;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 283, 23, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"XXXXXX BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN REÇETE SAYILARINA VE PARASAL TUTARINA GÖRE ECZ. DAĞILIM GRAFİĞİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 20, 33, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA NU.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 23, 57, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ECZANE ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 23, 89, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"REÇETE MİKTARI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 23, 118, 33, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AVERAJ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 28, 151, 33, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"10 BİN TL";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 23, 151, 28, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"200 ADET RÇT";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 28, 184, 33, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"20 BIN TL";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 23, 184, 28, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"400 ADET RÇT";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 28, 217, 33, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"30 BIN TL";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 23, 217, 28, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"600 ADET RÇT";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 28, 250, 33, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"40 BİN TL";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 23, 250, 28, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"800 ADET RÇT";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 23, 283, 28, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"1000 ADET RÇT";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 28, 283, 33, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"50 BİN TL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER.CalcValue = @"XXXXXX BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN REÇETE SAYILARINA VE PARASAL TUTARINA GÖRE ECZ. DAĞILIM GRAFİĞİ";
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    return new TTReportObject[] { HEADER,NewField1,NewField11,NewField12,NewField13,NewField2,NewField14,NewField15,NewField141,NewField151,NewField1141,NewField16,NewField142,NewField143,NewField1341};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public EczaneDagilimGraph MyParentReport
                {
                    get { return (EczaneDagilimGraph)ParentReport; }
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
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 37, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 0, 169, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 1, 280, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 283, 0, false);
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
            public EczaneDagilimGraph MyParentReport
            {
                get { return (EczaneDagilimGraph)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PRESCRIPTIONCOUNTYEXT { get {return Body().PRESCRIPTIONCOUNTYEXT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PHARMACY { get {return Body().PHARMACY;} }
            public TTReportField BALANCE { get {return Body().BALANCE;} }
            public TTReportField PRESCRIPTIONCOUNT { get {return Body().PRESCRIPTIONCOUNT;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportShape RCTADET { get {return Body().RCTADET;} }
            public TTReportShape RCTTUTAR { get {return Body().RCTTUTAR;} }
            public TTReportField EXTERNALPHARMACY { get {return Body().EXTERNALPHARMACY;} }
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
                list[0] = new TTReportNqlData<ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class>("GetDistributeGraphReportQuery", ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
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
                public EczaneDagilimGraph MyParentReport
                {
                    get { return (EczaneDagilimGraph)ParentReport; }
                }
                
                public TTReportField PRESCRIPTIONCOUNTYEXT;
                public TTReportField ORDERNO;
                public TTReportField PHARMACY;
                public TTReportField BALANCE;
                public TTReportField PRESCRIPTIONCOUNT;
                public TTReportField NewField1;
                public TTReportShape RCTADET;
                public TTReportShape RCTTUTAR;
                public TTReportField EXTERNALPHARMACY; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    PRESCRIPTIONCOUNTYEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 89, 11, false);
                    PRESCRIPTIONCOUNTYEXT.Name = "PRESCRIPTIONCOUNTYEXT";
                    PRESCRIPTIONCOUNTYEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    PRESCRIPTIONCOUNTYEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNTYEXT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRESCRIPTIONCOUNTYEXT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNTYEXT.Value = @"";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 20, 11, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}.";

                    PHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 57, 11, false);
                    PHARMACY.Name = "PHARMACY";
                    PHARMACY.DrawStyle = DrawStyleConstants.vbSolid;
                    PHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHARMACY.TextFont.CharSet = 162;
                    PHARMACY.Value = @"{#NAME#}";

                    BALANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 118, 11, false);
                    BALANCE.Name = "BALANCE";
                    BALANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    BALANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BALANCE.TextFormat = @"Currency";
                    BALANCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BALANCE.TextFont.CharSet = 162;
                    BALANCE.Value = @"{#BALANCE#}";

                    PRESCRIPTIONCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 335, 5, false);
                    PRESCRIPTIONCOUNT.Name = "PRESCRIPTIONCOUNT";
                    PRESCRIPTIONCOUNT.Visible = EvetHayirEnum.ehHayir;
                    PRESCRIPTIONCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRESCRIPTIONCOUNT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNT.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 283, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"";

                    RCTADET = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 119, 1, 119, 4, false);
                    RCTADET.Name = "RCTADET";
                    RCTADET.FillColor = System.Drawing.Color.Red;
                    RCTADET.DrawStyle = DrawStyleConstants.vbSolid;

                    RCTTUTAR = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 119, 7, 119, 10, false);
                    RCTTUTAR.Name = "RCTTUTAR";
                    RCTTUTAR.FillColor = System.Drawing.Color.Blue;
                    RCTTUTAR.DrawStyle = DrawStyleConstants.vbSolid;

                    EXTERNALPHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 339, 0, 364, 5, false);
                    EXTERNALPHARMACY.Name = "EXTERNALPHARMACY";
                    EXTERNALPHARMACY.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALPHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALPHARMACY.Value = @"{#EXTERNALPHARMACY#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class dataset_GetDistributeGraphReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ExternalPharmacyPrescriptionTransaction.GetDistributeGraphReportQuery_Class>(0);
                    PRESCRIPTIONCOUNTYEXT.CalcValue = @"";
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @".";
                    PHARMACY.CalcValue = (dataset_GetDistributeGraphReportQuery != null ? Globals.ToStringCore(dataset_GetDistributeGraphReportQuery.Name) : "");
                    BALANCE.CalcValue = (dataset_GetDistributeGraphReportQuery != null ? Globals.ToStringCore(dataset_GetDistributeGraphReportQuery.Balance) : "");
                    PRESCRIPTIONCOUNT.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    EXTERNALPHARMACY.CalcValue = (dataset_GetDistributeGraphReportQuery != null ? Globals.ToStringCore(dataset_GetDistributeGraphReportQuery.ExternalPharmacy) : "");
                    return new TTReportObject[] { PRESCRIPTIONCOUNTYEXT,ORDERNO,PHARMACY,BALANCE,PRESCRIPTIONCOUNT,NewField1,EXTERNALPHARMACY};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //if (PRESCRIPTIONCOUNT.CalcValue != "")
            //{
            //   PARTAGroup.prescriptionCount = 119+Convert.ToInt32(PRESCRIPTIONCOUNT.CalcValue);
            //    RCTADET.X2 = 119 + (Int32)Math.Round(Convert.ToDouble(PRESCRIPTIONCOUNT.CalcValue) / 6.1);
            // }

            // if (BALANCE.CalcValue != "")
            // {
            //     PARTAGroup.balance = 119 + Convert.ToDouble(BALANCE.CalcValue);
            //     RCTTUTAR.X2 = 119 + (Int32)Math.Round(3.25 * (Convert.ToDouble(BALANCE.CalcValue) / 1000));
            // }
            DateTime startDate = Convert.ToDateTime(this.MyParentReport.Parameters.ItemByName("STARTDATE").Value);
            DateTime endDate = Convert.ToDateTime(this.MyParentReport.Parameters.ItemByName("ENDDATE").Value);
            TTObjectContext context = new TTObjectContext(true);
            string pharmacyGuid = EXTERNALPHARMACY.CalcValue ;
            int prescriptionCount = 0 ;
            IList prescriptionTransactions = ExternalPharmacyPrescriptionTransaction.GetDistributePrescriptionByTransactionDate(context, endDate, startDate, new Guid(pharmacyGuid));

            prescriptionCount = prescriptionTransactions.Count;
            PRESCRIPTIONCOUNT.CalcValue = prescriptionCount.ToString();
            PRESCRIPTIONCOUNTYEXT.CalcValue = prescriptionCount.ToString();

            //mca
            if (PRESCRIPTIONCOUNT.CalcValue != "")
            {
                PARTAGroup.prescriptionCount = 119 + Convert.ToInt32(PRESCRIPTIONCOUNT.CalcValue);
                RCTADET.X2 = 119 + (Int32)Math.Round(Convert.ToDouble(PRESCRIPTIONCOUNT.CalcValue) / 6.1);
            }

            if (BALANCE.CalcValue != "")
            {
                PARTAGroup.balance = 119 + Convert.ToDouble(BALANCE.CalcValue);
                RCTTUTAR.X2 = 119 + (Int32)Math.Round(3.3 * (Convert.ToDouble(BALANCE.CalcValue) / 1000));
            }
            //mca
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

        public EczaneDagilimGraph()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "ECZANEDAGILIMGRAPH";
            Caption = "Eczane Dağılım Grafiği";
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