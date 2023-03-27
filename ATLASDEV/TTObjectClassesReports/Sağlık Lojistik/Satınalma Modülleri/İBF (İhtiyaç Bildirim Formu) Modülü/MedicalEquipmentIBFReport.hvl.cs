
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
    /// Tıbbi Cihaz İşletme, Bakım ve İdame İhtiyaçlarına İlişkin İhtiyaç Bildirim Formu
    /// </summary>
    public partial class MedicalEquipmentIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MedicalEquipmentIBFReport MyParentReport
            {
                get { return (MedicalEquipmentIBFReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1151211 { get {return Footer().NewField1151211;} }
            public TTReportField NewField11121511 { get {return Footer().NewField11121511;} }
            public TTReportField NewField12121511 { get {return Footer().NewField12121511;} }
            public TTReportField NewField13121511 { get {return Footer().NewField13121511;} }
            public TTReportField NewField14121511 { get {return Footer().NewField14121511;} }
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
                public MedicalEquipmentIBFReport MyParentReport
                {
                    get { return (MedicalEquipmentIBFReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 289, 23, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @".... YILI TIBBİ CİHAZ İŞLETME, BAKIM VE İDAME İHTİYAÇLARINA İLİŞKİN İHTİYAÇ BİLDİRİM FORMU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    return new TTReportObject[] { REPORTNAME};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if(purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                REPORTNAME.CalcValue = ibfDemand.IBFYear.ToString() + " YILI TIBBİ CİHAZ İŞLETME, BAKIM VE İDAME İHTİYAÇLARINA İLİŞKİN İHTİYAÇ BİLDİRİM FORMU";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                REPORTNAME.CalcValue = ibf.IBFYear.ToString() + " YILI TIBBİ CİHAZ İŞLETME, BAKIM VE İDAME İHTİYAÇLARINA İLİŞKİN İHTİYAÇ BİLDİRİM FORMU";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                REPORTNAME.CalcValue = lbPurchase.IBFYear.ToString() + " YILI TIBBİ CİHAZ İŞLETME, BAKIM VE İDAME İHTİYAÇLARINA İLİŞKİN İHTİYAÇ BİLDİRİM FORMU";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MedicalEquipmentIBFReport MyParentReport
                {
                    get { return (MedicalEquipmentIBFReport)ParentReport; }
                }
                
                public TTReportField NewField1151211;
                public TTReportField NewField11121511;
                public TTReportField NewField12121511;
                public TTReportField NewField13121511;
                public TTReportField NewField14121511; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 75;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1151211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 70, 9, false);
                    NewField1151211.Name = "NewField1151211";
                    NewField1151211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1151211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151211.TextFont.Name = "Arial";
                    NewField1151211.TextFont.Size = 8;
                    NewField1151211.TextFont.Bold = true;
                    NewField1151211.TextFont.CharSet = 162;
                    NewField1151211.Value = @"TIBBİ CİHAZ TAMİR
TEKNİSYENİ";

                    NewField11121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 1, 143, 9, false);
                    NewField11121511.Name = "NewField11121511";
                    NewField11121511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121511.TextFont.Name = "Arial";
                    NewField11121511.TextFont.Size = 8;
                    NewField11121511.TextFont.Bold = true;
                    NewField11121511.TextFont.CharSet = 162;
                    NewField11121511.Value = @"İLGİLİ SAYMAN";

                    NewField12121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 1, 216, 9, false);
                    NewField12121511.Name = "NewField12121511";
                    NewField12121511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12121511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12121511.TextFont.Name = "Arial";
                    NewField12121511.TextFont.Size = 8;
                    NewField12121511.TextFont.Bold = true;
                    NewField12121511.TextFont.CharSet = 162;
                    NewField12121511.Value = @"İKMAL KISIM AMİRİ";

                    NewField13121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 1, 289, 9, false);
                    NewField13121511.Name = "NewField13121511";
                    NewField13121511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13121511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13121511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13121511.TextFont.Name = "Arial";
                    NewField13121511.TextFont.Size = 8;
                    NewField13121511.TextFont.Bold = true;
                    NewField13121511.TextFont.CharSet = 162;
                    NewField13121511.Value = @"İDARİ AMİRİ";

                    NewField14121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 35, 169, 43, false);
                    NewField14121511.Name = "NewField14121511";
                    NewField14121511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14121511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14121511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14121511.TextFont.Name = "Arial";
                    NewField14121511.TextFont.Size = 8;
                    NewField14121511.TextFont.Bold = true;
                    NewField14121511.TextFont.CharSet = 162;
                    NewField14121511.Value = @"ONAY
(BİRLİK K. / KURUM AMİRİ)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1151211.CalcValue = NewField1151211.Value;
                    NewField11121511.CalcValue = NewField11121511.Value;
                    NewField12121511.CalcValue = NewField12121511.Value;
                    NewField13121511.CalcValue = NewField13121511.Value;
                    NewField14121511.CalcValue = NewField14121511.Value;
                    return new TTReportObject[] { NewField1151211,NewField11121511,NewField12121511,NewField13121511,NewField14121511};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MedicalEquipmentIBFReport MyParentReport
            {
                get { return (MedicalEquipmentIBFReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField112131 { get {return Header().NewField112131;} }
            public TTReportField NewField1131211 { get {return Header().NewField1131211;} }
            public TTReportField YEAR0 { get {return Header().YEAR0;} }
            public TTReportField NewField112141 { get {return Header().NewField112141;} }
            public TTReportField NewField1141211 { get {return Header().NewField1141211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField112121 { get {return Header().NewField112121;} }
            public TTReportField YEAR1 { get {return Header().YEAR1;} }
            public TTReportField YEAR2 { get {return Header().YEAR2;} }
            public TTReportField YEAR3 { get {return Header().YEAR3;} }
            public TTReportField YEAR4 { get {return Header().YEAR4;} }
            public TTReportField GRANDTOTALPRICE { get {return Footer().GRANDTOTALPRICE;} }
            public TTReportField NewField112151 { get {return Footer().NewField112151;} }
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
                public MedicalEquipmentIBFReport MyParentReport
                {
                    get { return (MedicalEquipmentIBFReport)ParentReport; }
                }
                
                public TTReportField NewField112131;
                public TTReportField NewField1131211;
                public TTReportField YEAR0;
                public TTReportField NewField112141;
                public TTReportField NewField1141211;
                public TTReportField NewField11121;
                public TTReportField NewField112111;
                public TTReportField NewField112121;
                public TTReportField YEAR1;
                public TTReportField YEAR2;
                public TTReportField YEAR3;
                public TTReportField YEAR4; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 10, 141, 29, false);
                    NewField112131.Name = "NewField112131";
                    NewField112131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112131.TextFont.Name = "Arial";
                    NewField112131.TextFont.Size = 8;
                    NewField112131.TextFont.Bold = true;
                    NewField112131.TextFont.CharSet = 162;
                    NewField112131.Value = @"
YEDEK PARÇANIN
KULLANILACAĞI CİHAZIN
ADI / MARKA/ MODELİ";

                    NewField1131211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 10, 167, 29, false);
                    NewField1131211.Name = "NewField1131211";
                    NewField1131211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131211.TextFont.Name = "Arial";
                    NewField1131211.TextFont.Size = 8;
                    NewField1131211.TextFont.Bold = true;
                    NewField1131211.TextFont.CharSet = 162;
                    NewField1131211.Value = @"HANGİ AMAÇLA
TEDARİK
EDİLECEĞİ
(BAKIM, ONARIM
VEYA STOK)";

                    YEAR0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 10, 183, 29, false);
                    YEAR0.Name = "YEAR0";
                    YEAR0.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR0.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR0.TextFont.Name = "Arial";
                    YEAR0.TextFont.Size = 8;
                    YEAR0.TextFont.Bold = true;
                    YEAR0.TextFont.CharSet = 162;
                    YEAR0.Value = @"....
YILI
SARF
MİKTARI
";

                    NewField112141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 10, 268, 29, false);
                    NewField112141.Name = "NewField112141";
                    NewField112141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112141.TextFont.Name = "Arial";
                    NewField112141.TextFont.Size = 8;
                    NewField112141.TextFont.Bold = true;
                    NewField112141.TextFont.CharSet = 162;
                    NewField112141.Value = @"TAHMİNİ
BİRİM
FİYATI
(KDV DAHİL)
(TL)";

                    NewField1141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 10, 289, 29, false);
                    NewField1141211.Name = "NewField1141211";
                    NewField1141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141211.TextFont.Name = "Arial";
                    NewField1141211.TextFont.Size = 8;
                    NewField1141211.TextFont.Bold = true;
                    NewField1141211.TextFont.CharSet = 162;
                    NewField1141211.Value = @"TOPLAM
TUTARI
(KDV DAHİL)
(TL)";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 18, 29, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Size = 8;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"

S.
NU.";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 10, 101, 29, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Size = 8;
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"

NATO STOK
NUMARASI";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 10, 73, 29, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Size = 8;
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"

YEDEK PARÇA
ADI";

                    YEAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 10, 199, 29, false);
                    YEAR1.Name = "YEAR1";
                    YEAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR1.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR1.TextFont.Name = "Arial";
                    YEAR1.TextFont.Size = 8;
                    YEAR1.TextFont.Bold = true;
                    YEAR1.TextFont.CharSet = 162;
                    YEAR1.Value = @"....
YILI
SARF
MİKTARI
";

                    YEAR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 10, 215, 29, false);
                    YEAR2.Name = "YEAR2";
                    YEAR2.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR2.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR2.TextFont.Name = "Arial";
                    YEAR2.TextFont.Size = 8;
                    YEAR2.TextFont.Bold = true;
                    YEAR2.TextFont.CharSet = 162;
                    YEAR2.Value = @"....
YILI
SARF
MİKTARI
";

                    YEAR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 10, 231, 29, false);
                    YEAR3.Name = "YEAR3";
                    YEAR3.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR3.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR3.TextFont.Name = "Arial";
                    YEAR3.TextFont.Size = 8;
                    YEAR3.TextFont.Bold = true;
                    YEAR3.TextFont.CharSet = 162;
                    YEAR3.Value = @"....
YILI
SONU
DEPO
MEVCUDU";

                    YEAR4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 10, 247, 29, false);
                    YEAR4.Name = "YEAR4";
                    YEAR4.DrawStyle = DrawStyleConstants.vbSolid;
                    YEAR4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR4.MultiLine = EvetHayirEnum.ehEvet;
                    YEAR4.TextFont.Name = "Arial";
                    YEAR4.TextFont.Size = 8;
                    YEAR4.TextFont.Bold = true;
                    YEAR4.TextFont.CharSet = 162;
                    YEAR4.Value = @"....
YILI
İHTİYAÇ
MİKTARI
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112131.CalcValue = NewField112131.Value;
                    NewField1131211.CalcValue = NewField1131211.Value;
                    YEAR0.CalcValue = YEAR0.Value;
                    NewField112141.CalcValue = NewField112141.Value;
                    NewField1141211.CalcValue = NewField1141211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    YEAR1.CalcValue = YEAR1.Value;
                    YEAR2.CalcValue = YEAR2.Value;
                    YEAR3.CalcValue = YEAR3.Value;
                    YEAR4.CalcValue = YEAR4.Value;
                    return new TTReportObject[] { NewField112131,NewField1131211,YEAR0,NewField112141,NewField1141211,NewField11121,NewField112111,NewField112121,YEAR1,YEAR2,YEAR3,YEAR4};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if(purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                YEAR0.CalcValue = (ibfDemand.IBFYear - 4).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR1.CalcValue = (ibfDemand.IBFYear - 3).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR2.CalcValue = (ibfDemand.IBFYear - 2).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR3.CalcValue = (ibfDemand.IBFYear - 2).ToString() + " YILI\nSONU\nDEPO\nMEVCUDU\n(ADET)";
                YEAR4.CalcValue = ibfDemand.IBFYear.ToString() + "\nYILI\nİHTİYAÇ\nMİKTARI";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                YEAR0.CalcValue = (ibf.IBFYear - 4).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR1.CalcValue = (ibf.IBFYear - 3).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR2.CalcValue = (ibf.IBFYear - 2).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR3.CalcValue = (ibf.IBFYear - 2).ToString() + " YILI\nSONU\nDEPO\nMEVCUDU\n(ADET)";
                YEAR4.CalcValue = ibf.IBFYear.ToString() + "\nYILI\nİHTİYAÇ\nMİKTARI";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                YEAR0.CalcValue = (lbPurchase.IBFYear - 4).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR1.CalcValue = (lbPurchase.IBFYear - 3).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR2.CalcValue = (lbPurchase.IBFYear - 2).ToString() + "\nYILI\nSARF\nMİKTARI";
                YEAR3.CalcValue = (lbPurchase.IBFYear - 2).ToString() + " YILI\nSONU\nDEPO\nMEVCUDU\n(ADET)";
                YEAR4.CalcValue = lbPurchase.IBFYear.ToString() + "\nYILI\nİHTİYAÇ\nMİKTARI";
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MedicalEquipmentIBFReport MyParentReport
                {
                    get { return (MedicalEquipmentIBFReport)ParentReport; }
                }
                
                public TTReportField GRANDTOTALPRICE;
                public TTReportField NewField112151; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                    GRANDTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 289, 8, false);
                    GRANDTOTALPRICE.Name = "GRANDTOTALPRICE";
                    GRANDTOTALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTALPRICE.MultiLine = EvetHayirEnum.ehEvet;
                    GRANDTOTALPRICE.TextFont.Name = "Arial";
                    GRANDTOTALPRICE.TextFont.Size = 8;
                    GRANDTOTALPRICE.TextFont.CharSet = 162;
                    GRANDTOTALPRICE.Value = @"";

                    NewField112151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 268, 8, false);
                    NewField112151.Name = "NewField112151";
                    NewField112151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField112151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112151.TextFont.Name = "Arial";
                    NewField112151.TextFont.Size = 8;
                    NewField112151.TextFont.Bold = true;
                    NewField112151.TextFont.CharSet = 162;
                    NewField112151.Value = @"
GENEL TOPLAM ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GRANDTOTALPRICE.CalcValue = @"";
                    NewField112151.CalcValue = NewField112151.Value;
                    return new TTReportObject[] { GRANDTOTALPRICE,NewField112151};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    GRANDTOTALPRICE.CalcValue = "\n" + PARTBGroup.totalPrice.ToString();
            PARTBGroup.totalPrice = 0;
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static double totalPrice = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MedicalEquipmentIBFReport MyParentReport
            {
                get { return (MedicalEquipmentIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STORESTOCK { get {return Body().STORESTOCK;} }
            public TTReportField CONSUMPTIONAMOUNT { get {return Body().CONSUMPTIONAMOUNT;} }
            public TTReportField CONSUMPTIONAMOUNT1 { get {return Body().CONSUMPTIONAMOUNT1;} }
            public TTReportField CONSUMPTIONAMOUNT2 { get {return Body().CONSUMPTIONAMOUNT2;} }
            public TTReportField PURPOSE { get {return Body().PURPOSE;} }
            public TTReportField DEPENDENTSPARE { get {return Body().DEPENDENTSPARE;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField DETAILOBJECTID { get {return Body().DETAILOBJECTID;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[3];
                list[0] = new TTReportNqlData<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>("GetAnnualRequirementDetailInListQuery", AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<IBFDetDetailIn.GetIBFDetailInQuery_Class>("GetIBFDetailInQuery", IBFDetDetailIn.GetIBFDetailInQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[2] = new TTReportNqlData<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>("GetLBPurchaseProjectDetailInQuery", LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MedicalEquipmentIBFReport MyParentReport
                {
                    get { return (MedicalEquipmentIBFReport)ParentReport; }
                }
                
                public TTReportField STORESTOCK;
                public TTReportField CONSUMPTIONAMOUNT;
                public TTReportField CONSUMPTIONAMOUNT1;
                public TTReportField CONSUMPTIONAMOUNT2;
                public TTReportField PURPOSE;
                public TTReportField DEPENDENTSPARE;
                public TTReportField TOTALPRICE;
                public TTReportField COUNT;
                public TTReportField NSN;
                public TTReportField MATERIAL;
                public TTReportField REQUESTAMOUNT;
                public TTReportField UNITPRICE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine14;
                public TTReportShape NewLine16;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    STORESTOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 0, 231, 8, false);
                    STORESTOCK.Name = "STORESTOCK";
                    STORESTOCK.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORESTOCK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STORESTOCK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORESTOCK.TextFont.Name = "Arial";
                    STORESTOCK.TextFont.Size = 8;
                    STORESTOCK.TextFont.CharSet = 162;
                    STORESTOCK.Value = @"";

                    CONSUMPTIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 183, 8, false);
                    CONSUMPTIONAMOUNT.Name = "CONSUMPTIONAMOUNT";
                    CONSUMPTIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT.TextFont.Size = 8;
                    CONSUMPTIONAMOUNT.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT.Value = @"{#CONSUMPTIONAMOUNT#}{#CONSUMPTIONAMOUNT!GetIBFDetailInQuery#}{#CONSUMPTIONAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    CONSUMPTIONAMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 199, 8, false);
                    CONSUMPTIONAMOUNT1.Name = "CONSUMPTIONAMOUNT1";
                    CONSUMPTIONAMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT1.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT1.TextFont.Size = 8;
                    CONSUMPTIONAMOUNT1.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT1.Value = @"";

                    CONSUMPTIONAMOUNT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 215, 8, false);
                    CONSUMPTIONAMOUNT2.Name = "CONSUMPTIONAMOUNT2";
                    CONSUMPTIONAMOUNT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONAMOUNT2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONSUMPTIONAMOUNT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMPTIONAMOUNT2.TextFont.Name = "Arial";
                    CONSUMPTIONAMOUNT2.TextFont.Size = 8;
                    CONSUMPTIONAMOUNT2.TextFont.CharSet = 162;
                    CONSUMPTIONAMOUNT2.Value = @"";

                    PURPOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 0, 167, 8, false);
                    PURPOSE.Name = "PURPOSE";
                    PURPOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURPOSE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURPOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURPOSE.MultiLine = EvetHayirEnum.ehEvet;
                    PURPOSE.WordBreak = EvetHayirEnum.ehEvet;
                    PURPOSE.TextFont.Name = "Arial";
                    PURPOSE.TextFont.Size = 8;
                    PURPOSE.TextFont.CharSet = 162;
                    PURPOSE.Value = @"";

                    DEPENDENTSPARE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 141, 8, false);
                    DEPENDENTSPARE.Name = "DEPENDENTSPARE";
                    DEPENDENTSPARE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPENDENTSPARE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEPENDENTSPARE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEPENDENTSPARE.MultiLine = EvetHayirEnum.ehEvet;
                    DEPENDENTSPARE.WordBreak = EvetHayirEnum.ehEvet;
                    DEPENDENTSPARE.TextFont.Name = "Arial";
                    DEPENDENTSPARE.TextFont.Size = 8;
                    DEPENDENTSPARE.TextFont.CharSet = 162;
                    DEPENDENTSPARE.Value = @"";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 289, 8, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 8, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 8;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 0, 101, 8, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 8;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NSN#}{#NSN!GetIBFDetailInQuery#}{#NSN!GetLBPurchaseProjectDetailInQuery#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 72, 8, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 8;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 247, 8, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 8;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#REQUESTAMOUNT#}{#REQUESTAMOUNT!GetIBFDetailInQuery#}{#APPROVEDAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 268, 8, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}{#UNITPRICE!GetIBFDetailInQuery#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 0, 18, 8, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 0, 73, 8, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 101, 0, 101, 8, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 0, 141, 8, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 167, 0, 167, 8, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 0, 183, 8, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 0, 199, 8, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 215, 0, 215, 8, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 231, 0, 231, 8, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 0, 247, 8, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 0, 268, 8, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 8, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 8, 289, 8, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 0, 327, 5, false);
                    DETAILOBJECTID.Name = "DETAILOBJECTID";
                    DETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    DETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DETAILOBJECTID.Value = @"{#OBJECTID#}{#OBJECTID!GetIBFDetailInQuery#}{#OBJECTID!GetLBPurchaseProjectDetailInQuery#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class dataset_GetAnnualRequirementDetailInListQuery = ParentGroup.rsGroup.GetCurrentRecord<AnnualRequirementDetailInList.GetAnnualRequirementDetailInListQuery_Class>(0);
                    IBFDetDetailIn.GetIBFDetailInQuery_Class dataset_GetIBFDetailInQuery = ParentGroup.rsGroup.GetCurrentRecord<IBFDetDetailIn.GetIBFDetailInQuery_Class>(1);
                    LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class dataset_GetLBPurchaseProjectDetailInQuery = ParentGroup.rsGroup.GetCurrentRecord<LBPurchaseProjectDetailInList.GetLBPurchaseProjectDetailInQuery_Class>(2);
                    STORESTOCK.CalcValue = @"";
                    CONSUMPTIONAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ConsumptionAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ConsumptionAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ConsumptionAmount) : "");
                    CONSUMPTIONAMOUNT1.CalcValue = @"";
                    CONSUMPTIONAMOUNT2.CalcValue = @"";
                    PURPOSE.CalcValue = @"";
                    DEPENDENTSPARE.CalcValue = @"";
                    TOTALPRICE.CalcValue = @"";
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    NSN.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.NSN) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.NSN) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.NSN) : "");
                    MATERIAL.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "");
                    REQUESTAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.RequestAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.RequestAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    UNITPRICE.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Unitprice) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Unitprice) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { STORESTOCK,CONSUMPTIONAMOUNT,CONSUMPTIONAMOUNT1,CONSUMPTIONAMOUNT2,PURPOSE,DEPENDENTSPARE,TOTALPRICE,COUNT,NSN,MATERIAL,REQUESTAMOUNT,UNITPRICE,DETAILOBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(DETAILOBJECTID.CalcValue != "")
            {
                string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
                if(purchaseAction is IBFDemand)
                {
                    IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                    IBFDet_MedicalEquipmentIn medicalEquipment = (IBFDet_MedicalEquipmentIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_MedicalEquipmentIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(medicalEquipment.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = medicalEquipment.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = medicalEquipment.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = medicalEquipment.Amount.ToString();
                    
                    DEPENDENTSPARE.CalcValue = medicalEquipment.DependentSpare;
                    PURPOSE.CalcValue = medicalEquipment.Purpose;
                    CONSUMPTIONAMOUNT1.CalcValue = medicalEquipment.ConsumptionAmount1.ToString();
                    CONSUMPTIONAMOUNT2.CalcValue = medicalEquipment.ConsumptionAmount2.ToString();
                    STORESTOCK.CalcValue = medicalEquipment.StoreStock.ToString();
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_MedicalEquipmentIn medicalEquipment = (ARD_MedicalEquipmentIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_MedicalEquipmentIn));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        if(medicalEquipment.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = medicalEquipment.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = medicalEquipment.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = medicalEquipment.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = medicalEquipment.LB_ApproveAmount.ToString();
                    
                    DEPENDENTSPARE.CalcValue = medicalEquipment.DependentSpare;
                    PURPOSE.CalcValue = medicalEquipment.Purpose;
                    CONSUMPTIONAMOUNT1.CalcValue = medicalEquipment.ConsumptionAmount1.ToString();
                    CONSUMPTIONAMOUNT2.CalcValue = medicalEquipment.ConsumptionAmount2.ToString();
                    STORESTOCK.CalcValue = medicalEquipment.StoreStock.ToString();
                }
                else if(purchaseAction is LBPurchaseProject)
                {
                    LBD_MedicalEquipmentIn medicalEquipment = (LBD_MedicalEquipmentIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(LBD_MedicalEquipmentIn));
                    DEPENDENTSPARE.CalcValue = medicalEquipment.DependentSpare;
                    PURPOSE.CalcValue = medicalEquipment.Purpose;
                    CONSUMPTIONAMOUNT1.CalcValue = medicalEquipment.ConsumptionAmount1.ToString();
                    CONSUMPTIONAMOUNT2.CalcValue = medicalEquipment.ConsumptionAmount2.ToString();
                }
            }
            
            double amount = Convert.ToDouble(REQUESTAMOUNT.CalcValue);
            double unitPrice = 0;
            if(UNITPRICE.CalcValue != "")
                unitPrice = Convert.ToDouble(UNITPRICE.CalcValue);
            TOTALPRICE.CalcValue = (amount * unitPrice).ToString();
            PARTBGroup.totalPrice += amount * unitPrice;
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

        public MedicalEquipmentIBFReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MEDICALEQUIPMENTIBFREPORT";
            Caption = "Tıbbi Cihaz İşletme, Bakım ve İdame İhtiyaçlarına İlişkin İhtiyaç Bildirim Formu";
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