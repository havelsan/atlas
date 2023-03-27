
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
    public partial class InpatientPrescriptionDailyDistributeSchedule : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public InpatientPrescriptionDailyDistributeSchedule MyParentReport
            {
                get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
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
                public InpatientPrescriptionDailyDistributeSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
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
                    
                    Height = 43;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 205, 24, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"XXXXXX BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN {%DATE%} TARİHİNE AİT
GÜNLÜK REÇETE DAĞITIM ÇİZELGESİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 28, 31, 33, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA NU.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 28, 97, 33, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ECZANE ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 28, 134, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"REÇETE MİKTARI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 28, 175, 33, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"TUTAR TOPLAMI";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 28, 205, 33, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"DAĞITIM ŞEKLİ";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 15, 239, 20, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.Value = @"{@DATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    HEADER.CalcValue = @"XXXXXX BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN " + MyParentReport.PARTA.DATE.FormattedValue + @" TARİHİNE AİT
GÜNLÜK REÇETE DAĞITIM ÇİZELGESİ";
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
                public InpatientPrescriptionDailyDistributeSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
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
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 40, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 125, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 205, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 205, 0, false);
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
            public InpatientPrescriptionDailyDistributeSchedule MyParentReport
            {
                get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PRESCRIPTIONCOUNTYEXT { get {return Body().PRESCRIPTIONCOUNTYEXT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PHARMACY { get {return Body().PHARMACY;} }
            public TTReportField BALANCE { get {return Body().BALANCE;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField PRESCRIPTIONCOUNT { get {return Body().PRESCRIPTIONCOUNT;} }
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
                list[0] = new TTReportNqlData<PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class>("GetInpatientPrescriptionOutScheduleQuery", PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.DATE)));
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
                public InpatientPrescriptionDailyDistributeSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
                }
                
                public TTReportField PRESCRIPTIONCOUNTYEXT;
                public TTReportField ORDERNO;
                public TTReportField PHARMACY;
                public TTReportField BALANCE;
                public TTReportField NewField141;
                public TTReportField PRESCRIPTIONCOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    PRESCRIPTIONCOUNTYEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 134, 5, false);
                    PRESCRIPTIONCOUNTYEXT.Name = "PRESCRIPTIONCOUNTYEXT";
                    PRESCRIPTIONCOUNTYEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    PRESCRIPTIONCOUNTYEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNTYEXT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRESCRIPTIONCOUNTYEXT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNTYEXT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNTYEXT.Value = @"{#PRESCRIPTIONCOUNT#} Adet   ";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 31, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}.";

                    PHARMACY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 0, 97, 5, false);
                    PHARMACY.Name = "PHARMACY";
                    PHARMACY.DrawStyle = DrawStyleConstants.vbSolid;
                    PHARMACY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHARMACY.ObjectDefName = "ExternalPharmacy";
                    PHARMACY.DataMember = "NAME";
                    PHARMACY.TextFont.Name = "Arial";
                    PHARMACY.TextFont.CharSet = 162;
                    PHARMACY.Value = @"{#EXTERNALPHARMACY#}";

                    BALANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 175, 5, false);
                    BALANCE.Name = "BALANCE";
                    BALANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    BALANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BALANCE.TextFormat = @"Currency";
                    BALANCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BALANCE.TextFont.Name = "Arial";
                    BALANCE.TextFont.CharSet = 162;
                    BALANCE.Value = @"{#BALANCE#}   ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 205, 5, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"";

                    PRESCRIPTIONCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 0, 254, 5, false);
                    PRESCRIPTIONCOUNT.Name = "PRESCRIPTIONCOUNT";
                    PRESCRIPTIONCOUNT.Visible = EvetHayirEnum.ehHayir;
                    PRESCRIPTIONCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRESCRIPTIONCOUNT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNT.Value = @"{#PRESCRIPTIONCOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class dataset_GetInpatientPrescriptionOutScheduleQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetInpatientPrescriptionOutScheduleQuery_Class>(0);
                    PRESCRIPTIONCOUNTYEXT.CalcValue = (dataset_GetInpatientPrescriptionOutScheduleQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOutScheduleQuery.Prescriptioncount) : "") + @" Adet   ";
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @".";
                    PHARMACY.CalcValue = (dataset_GetInpatientPrescriptionOutScheduleQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOutScheduleQuery.ExternalPharmacy) : "");
                    PHARMACY.PostFieldValueCalculation();
                    BALANCE.CalcValue = (dataset_GetInpatientPrescriptionOutScheduleQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOutScheduleQuery.Balance) : "") + @"   ";
                    NewField141.CalcValue = NewField141.Value;
                    PRESCRIPTIONCOUNT.CalcValue = (dataset_GetInpatientPrescriptionOutScheduleQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOutScheduleQuery.Prescriptioncount) : "");
                    return new TTReportObject[] { PRESCRIPTIONCOUNTYEXT,ORDERNO,PHARMACY,BALANCE,NewField141,PRESCRIPTIONCOUNT};
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
            public InpatientPrescriptionDailyDistributeSchedule MyParentReport
            {
                get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField TOTALBALANCE { get {return Body().TOTALBALANCE;} }
            public TTReportField TOTALBALANCE1 { get {return Body().TOTALBALANCE1;} }
            public TTReportField TOTALCOUNT { get {return Body().TOTALCOUNT;} }
            public TTReportField TOTALCOUNT1 { get {return Body().TOTALCOUNT1;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField TOTALBALANCE2 { get {return Body().TOTALBALANCE2;} }
            public TTReportField TOTALCOUNT2 { get {return Body().TOTALCOUNT2;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
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
                public InpatientPrescriptionDailyDistributeSchedule MyParentReport
                {
                    get { return (InpatientPrescriptionDailyDistributeSchedule)ParentReport; }
                }
                
                public TTReportField TOTALBALANCE;
                public TTReportField TOTALBALANCE1;
                public TTReportField TOTALCOUNT;
                public TTReportField TOTALCOUNT1;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportShape NewLine1;
                public TTReportField TOTALBALANCE2;
                public TTReportField TOTALCOUNT2;
                public TTReportField NewField111;
                public TTReportField NewField1121; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 27;
                    RepeatCount = 0;
                    
                    TOTALBALANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 3, 175, 8, false);
                    TOTALBALANCE.Name = "TOTALBALANCE";
                    TOTALBALANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALBALANCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALBALANCE.TextFont.Name = "Arial";
                    TOTALBALANCE.TextFont.Bold = true;
                    TOTALBALANCE.TextFont.CharSet = 162;
                    TOTALBALANCE.Value = @"";

                    TOTALBALANCE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 8, 175, 13, false);
                    TOTALBALANCE1.Name = "TOTALBALANCE1";
                    TOTALBALANCE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALBALANCE1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALBALANCE1.TextFont.Name = "Arial";
                    TOTALBALANCE1.TextFont.Bold = true;
                    TOTALBALANCE1.TextFont.CharSet = 162;
                    TOTALBALANCE1.Value = @"0,00 TL";

                    TOTALCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 3, 131, 8, false);
                    TOTALCOUNT.Name = "TOTALCOUNT";
                    TOTALCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCOUNT.TextFont.Name = "Arial";
                    TOTALCOUNT.TextFont.Bold = true;
                    TOTALCOUNT.TextFont.CharSet = 162;
                    TOTALCOUNT.Value = @"";

                    TOTALCOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 8, 131, 13, false);
                    TOTALCOUNT1.Name = "TOTALCOUNT1";
                    TOTALCOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOUNT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCOUNT1.TextFont.Name = "Arial";
                    TOTALCOUNT1.TextFont.Bold = true;
                    TOTALCOUNT1.TextFont.CharSet = 162;
                    TOTALCOUNT1.Value = @"0 Adet";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 3, 92, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"OTOMATİK";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 8, 92, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"NÖBET";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 3, 94, 8, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 8, 94, 13, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 69, 14, 175, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALBALANCE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 15, 175, 20, false);
                    TOTALBALANCE2.Name = "TOTALBALANCE2";
                    TOTALBALANCE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALBALANCE2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALBALANCE2.TextFont.Name = "Arial";
                    TOTALBALANCE2.TextFont.Bold = true;
                    TOTALBALANCE2.TextFont.CharSet = 162;
                    TOTALBALANCE2.Value = @"";

                    TOTALCOUNT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 15, 131, 20, false);
                    TOTALCOUNT2.Name = "TOTALCOUNT2";
                    TOTALCOUNT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOUNT2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALCOUNT2.TextFont.Name = "Arial";
                    TOTALCOUNT2.TextFont.Bold = true;
                    TOTALCOUNT2.TextFont.CharSet = 162;
                    TOTALCOUNT2.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 15, 92, 20, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"TOPLAM";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 15, 94, 20, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTALBALANCE.CalcValue = @"";
                    TOTALBALANCE1.CalcValue = @"0,00 TL";
                    TOTALCOUNT.CalcValue = @"";
                    TOTALCOUNT1.CalcValue = @"0 Adet";
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    TOTALBALANCE2.CalcValue = @"";
                    TOTALCOUNT2.CalcValue = @"";
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { TOTALBALANCE,TOTALBALANCE1,TOTALCOUNT,TOTALCOUNT1,NewField1,NewField11,NewField12,NewField121,TOTALBALANCE2,TOTALCOUNT2,NewField111,NewField1121};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    TOTALCOUNT.CalcValue = PARTAGroup.prescriptionCount.ToString() + " Adet";
                    TOTALBALANCE.CalcValue = PARTAGroup.balance.ToString() + " TL";
                    TOTALCOUNT2.CalcValue = TOTALCOUNT.CalcValue;
                    TOTALBALANCE2.CalcValue = TOTALBALANCE.CalcValue;
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

        public InpatientPrescriptionDailyDistributeSchedule()
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
            Name = "INPATIENTPRESCRIPTIONDAILYDISTRIBUTESCHEDULE";
            Caption = "Günlük Reçete Dağıtım Çizelgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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