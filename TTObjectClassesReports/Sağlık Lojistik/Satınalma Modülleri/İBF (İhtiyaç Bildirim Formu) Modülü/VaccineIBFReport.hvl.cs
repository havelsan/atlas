
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
    /// Yurt İçi Sağlık Ana Malzeme Modernizasyonu İhtiyaç Bildirim Formu
    /// </summary>
    public partial class VaccineIBFReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public VaccineIBFReport MyParentReport
            {
                get { return (VaccineIBFReport)ParentReport; }
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
            public TTReportField NewField11121311 { get {return Header().NewField11121311;} }
            public TTReportField NewField111312111 { get {return Header().NewField111312111;} }
            public TTReportField NewField111312112 { get {return Header().NewField111312112;} }
            public TTReportField NewField1211213111 { get {return Header().NewField1211213111;} }
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
                public VaccineIBFReport MyParentReport
                {
                    get { return (VaccineIBFReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField11121311;
                public TTReportField NewField111312111;
                public TTReportField NewField111312112;
                public TTReportField NewField1211213111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 289, 23, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 9;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"XXXXXX SAĞLIK XXXXXXLIĞI .... YILI YURT İÇİ SAĞLIK ANA MALZEME MODERNİZASYONU İHTİYAÇ BİLDİRİM FORMU";

                    NewField11121311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 31, 29, false);
                    NewField11121311.Name = "NewField11121311";
                    NewField11121311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121311.TextFont.Name = "Arial";
                    NewField11121311.TextFont.Size = 8;
                    NewField11121311.TextFont.Bold = true;
                    NewField11121311.TextFont.CharSet = 162;
                    NewField11121311.Value = @"PROJE NU.";

                    NewField111312111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 31, 33, false);
                    NewField111312111.Name = "NewField111312111";
                    NewField111312111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111312111.TextFont.Name = "Arial";
                    NewField111312111.TextFont.Size = 8;
                    NewField111312111.TextFont.Bold = true;
                    NewField111312111.TextFont.CharSet = 162;
                    NewField111312111.Value = @"PROJENİN ADI";

                    NewField111312112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 25, 33, 29, false);
                    NewField111312112.Name = "NewField111312112";
                    NewField111312112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111312112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111312112.TextFont.Name = "Arial";
                    NewField111312112.TextFont.Size = 8;
                    NewField111312112.TextFont.Bold = true;
                    NewField111312112.TextFont.CharSet = 162;
                    NewField111312112.Value = @":";

                    NewField1211213111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 29, 33, 33, false);
                    NewField1211213111.Name = "NewField1211213111";
                    NewField1211213111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211213111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211213111.TextFont.Name = "Arial";
                    NewField1211213111.TextFont.Size = 8;
                    NewField1211213111.TextFont.Bold = true;
                    NewField1211213111.TextFont.CharSet = 162;
                    NewField1211213111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField11121311.CalcValue = NewField11121311.Value;
                    NewField111312111.CalcValue = NewField111312111.Value;
                    NewField111312112.CalcValue = NewField111312112.Value;
                    NewField1211213111.CalcValue = NewField1211213111.Value;
                    return new TTReportObject[] { REPORTNAME,NewField11121311,NewField111312111,NewField111312112,NewField1211213111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            BasePurchaseAction purchaseAction = (BasePurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(BasePurchaseAction));
            if(purchaseAction is IBFDemand)
            {
                IBFDemand ibfDemand = (IBFDemand)purchaseAction;
                REPORTNAME.CalcValue = "XXXXXX SAĞLIK XXXXXXLIĞI " + ibfDemand.IBFYear.ToString() + " YILI YURT İÇİ SAĞLIK ANA MALZEME MODERNİZASYONU İHTİYAÇ BİLDİRİM FORMU";
            }
            else if(purchaseAction is AnnualRequirement)
            {
                AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                REPORTNAME.CalcValue = "XXXXXX SAĞLIK XXXXXXLIĞI " + ibf.IBFYear.ToString() + " YILI YURT İÇİ SAĞLIK ANA MALZEME MODERNİZASYONU İHTİYAÇ BİLDİRİM FORMU";
            }
            else if(purchaseAction is LBPurchaseProject)
            {
                LBPurchaseProject lbPurchase = (LBPurchaseProject)purchaseAction;
                REPORTNAME.CalcValue = "XXXXXX SAĞLIK XXXXXXLIĞI " + lbPurchase.IBFYear.ToString() + " YILI YURT İÇİ SAĞLIK ANA MALZEME MODERNİZASYONU İHTİYAÇ BİLDİRİM FORMU";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public VaccineIBFReport MyParentReport
                {
                    get { return (VaccineIBFReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public VaccineIBFReport MyParentReport
            {
                get { return (VaccineIBFReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111112111 { get {return Header().NewField111112111;} }
            public TTReportField NewField111112121 { get {return Header().NewField111112121;} }
            public TTReportField NewField12121112 { get {return Header().NewField12121112;} }
            public TTReportField NewField12121111 { get {return Header().NewField12121111;} }
            public TTReportField NewField11121111 { get {return Header().NewField11121111;} }
            public TTReportField NewField1111212 { get {return Header().NewField1111212;} }
            public TTReportField NewField1111211 { get {return Header().NewField1111211;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField112131 { get {return Header().NewField112131;} }
            public TTReportField NewField1131211 { get {return Header().NewField1131211;} }
            public TTReportField NewField112141 { get {return Header().NewField112141;} }
            public TTReportField NewField1141211 { get {return Header().NewField1141211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112121 { get {return Header().NewField112121;} }
            public TTReportField NewField11221331 { get {return Header().NewField11221331;} }
            public TTReportField NewField11221341 { get {return Header().NewField11221341;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1131212 { get {return Header().NewField1131212;} }
            public TTReportField NewField12121311 { get {return Header().NewField12121311;} }
            public TTReportField NewField12121312 { get {return Header().NewField12121312;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField113312211 { get {return Header().NewField113312211;} }
            public TTReportField NewField113312212 { get {return Header().NewField113312212;} }
            public TTReportField NewField1212213311 { get {return Header().NewField1212213311;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField NewField1141212 { get {return Header().NewField1141212;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
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
                public VaccineIBFReport MyParentReport
                {
                    get { return (VaccineIBFReport)ParentReport; }
                }
                
                public TTReportField NewField111112111;
                public TTReportField NewField111112121;
                public TTReportField NewField12121112;
                public TTReportField NewField12121111;
                public TTReportField NewField11121111;
                public TTReportField NewField1111212;
                public TTReportField NewField1111211;
                public TTReportField NewField112111;
                public TTReportField NewField112131;
                public TTReportField NewField1131211;
                public TTReportField NewField112141;
                public TTReportField NewField1141211;
                public TTReportField NewField11121;
                public TTReportField NewField112121;
                public TTReportField NewField11221331;
                public TTReportField NewField11221341;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField1131212;
                public TTReportField NewField12121311;
                public TTReportField NewField12121312;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportField NewField113312211;
                public TTReportField NewField113312212;
                public TTReportField NewField1212213311;
                public TTReportShape NewLine3;
                public TTReportField NewField1141212; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 6, 126, 18, false);
                    NewField111112111.Name = "NewField111112111";
                    NewField111112111.FontAngle = 900;
                    NewField111112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111112111.TextFont.Name = "Arial";
                    NewField111112111.TextFont.Size = 6;
                    NewField111112111.TextFont.Bold = true;
                    NewField111112111.TextFont.CharSet = 162;
                    NewField111112111.Value = @"MAKAM";

                    NewField111112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 6, 123, 18, false);
                    NewField111112121.Name = "NewField111112121";
                    NewField111112121.FontAngle = 900;
                    NewField111112121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111112121.TextFont.Name = "Arial";
                    NewField111112121.TextFont.Size = 6;
                    NewField111112121.TextFont.Bold = true;
                    NewField111112121.TextFont.CharSet = 162;
                    NewField111112121.Value = @"LAYAN";

                    NewField12121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 6, 120, 18, false);
                    NewField12121112.Name = "NewField12121112";
                    NewField12121112.FontAngle = 900;
                    NewField12121112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12121112.TextFont.Name = "Arial";
                    NewField12121112.TextFont.Size = 6;
                    NewField12121112.TextFont.Bold = true;
                    NewField12121112.TextFont.CharSet = 162;
                    NewField12121112.Value = @"HAZIR-";

                    NewField12121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 6, 114, 18, false);
                    NewField12121111.Name = "NewField12121111";
                    NewField12121111.FontAngle = 900;
                    NewField12121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12121111.TextFont.Name = "Arial";
                    NewField12121111.TextFont.Size = 6;
                    NewField12121111.TextFont.Bold = true;
                    NewField12121111.TextFont.CharSet = 162;
                    NewField12121111.Value = @"LU";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 6, 117, 18, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.FontAngle = 900;
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11121111.TextFont.Name = "Arial";
                    NewField11121111.TextFont.Size = 6;
                    NewField11121111.TextFont.Bold = true;
                    NewField11121111.TextFont.CharSet = 162;
                    NewField11121111.Value = @"MAKAM";

                    NewField1111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 6, 111, 18, false);
                    NewField1111212.Name = "NewField1111212";
                    NewField1111212.FontAngle = 900;
                    NewField1111212.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111212.TextFont.Name = "Arial";
                    NewField1111212.TextFont.Size = 6;
                    NewField1111212.TextFont.Bold = true;
                    NewField1111212.TextFont.CharSet = 162;
                    NewField1111212.Value = @"SORUM-";

                    NewField1111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 1, 62, 18, false);
                    NewField1111211.Name = "NewField1111211";
                    NewField1111211.FontAngle = 900;
                    NewField1111211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111211.TextFont.Name = "Arial";
                    NewField1111211.TextFont.Size = 7;
                    NewField1111211.TextFont.Bold = true;
                    NewField1111211.TextFont.CharSet = 162;
                    NewField1111211.Value = @"MİKTARI";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 1, 59, 18, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.FontAngle = 900;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Size = 7;
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"İSTEK";

                    NewField112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 1, 75, 18, false);
                    NewField112131.Name = "NewField112131";
                    NewField112131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112131.TextFont.Name = "Arial";
                    NewField112131.TextFont.Size = 7;
                    NewField112131.TextFont.Bold = true;
                    NewField112131.TextFont.CharSet = 162;
                    NewField112131.Value = @"
TAHMİNİ
TUTAR
(BİN TL)";

                    NewField1131211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 1, 195, 6, false);
                    NewField1131211.Name = "NewField1131211";
                    NewField1131211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131211.TextFont.Name = "Arial";
                    NewField1131211.TextFont.Size = 7;
                    NewField1131211.TextFont.Bold = true;
                    NewField1131211.TextFont.CharSet = 162;
                    NewField1131211.Value = @"TEKNİK ŞARTNAME BİLGİLERİ";

                    NewField112141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 1, 265, 18, false);
                    NewField112141.Name = "NewField112141";
                    NewField112141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112141.TextFont.Name = "Arial";
                    NewField112141.TextFont.Size = 7;
                    NewField112141.TextFont.Bold = true;
                    NewField112141.TextFont.CharSet = 162;
                    NewField112141.Value = @"
KLİNİK / 
BAĞLI BİRLİK";

                    NewField1141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 1, 289, 18, false);
                    NewField1141211.Name = "NewField1141211";
                    NewField1141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141211.TextFont.Name = "Arial";
                    NewField1141211.TextFont.Size = 7;
                    NewField1141211.TextFont.Bold = true;
                    NewField1141211.TextFont.CharSet = 162;
                    NewField1141211.Value = @"AÇIKLAMALAR";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 17, 18, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Size = 7;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"
S.
NU.";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 56, 18, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112121.TextFont.Name = "Arial";
                    NewField112121.TextFont.Size = 7;
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"CİHAZIN ADI";

                    NewField11221331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 6, 153, 18, false);
                    NewField11221331.Name = "NewField11221331";
                    NewField11221331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221331.TextFont.Name = "Arial";
                    NewField11221331.TextFont.Size = 7;
                    NewField11221331.TextFont.Bold = true;
                    NewField11221331.TextFont.CharSet = 162;
                    NewField11221331.Value = @"ADI";

                    NewField11221341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 1, 209, 18, false);
                    NewField11221341.Name = "NewField11221341";
                    NewField11221341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221341.TextFont.Name = "Arial";
                    NewField11221341.TextFont.Size = 7;
                    NewField11221341.TextFont.Bold = true;
                    NewField11221341.TextFont.CharSet = 162;
                    NewField11221341.Value = @"
TEDARİK
MAKAMI";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 1, 62, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 18, 62, 18, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1131212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 1, 88, 18, false);
                    NewField1131212.Name = "NewField1131212";
                    NewField1131212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131212.TextFont.Name = "Arial";
                    NewField1131212.TextFont.Size = 7;
                    NewField1131212.TextFont.Bold = true;
                    NewField1131212.TextFont.CharSet = 162;
                    NewField1131212.Value = @"
TOPLAM
TUTAR
(BİN TL)";

                    NewField12121311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 1, 97, 18, false);
                    NewField12121311.Name = "NewField12121311";
                    NewField12121311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12121311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121311.TextFont.Name = "Arial";
                    NewField12121311.TextFont.Size = 7;
                    NewField12121311.TextFont.Bold = true;
                    NewField12121311.TextFont.CharSet = 162;
                    NewField12121311.Value = @"MKS";

                    NewField12121312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 108, 18, false);
                    NewField12121312.Name = "NewField12121312";
                    NewField12121312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12121312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12121312.TextFont.Name = "Arial";
                    NewField12121312.TextFont.Size = 7;
                    NewField12121312.TextFont.Bold = true;
                    NewField12121312.TextFont.CharSet = 162;
                    NewField12121312.Value = @"
KAYNAK
TÜRÜ";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 117, 6, 117, 18, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 6, 126, 18, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113312211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 6, 170, 18, false);
                    NewField113312211.Name = "NewField113312211";
                    NewField113312211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113312211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113312211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113312211.TextFont.Name = "Arial";
                    NewField113312211.TextFont.Size = 7;
                    NewField113312211.TextFont.Bold = true;
                    NewField113312211.TextFont.CharSet = 162;
                    NewField113312211.Value = @"NUMARASI";

                    NewField113312212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 6, 183, 18, false);
                    NewField113312212.Name = "NewField113312212";
                    NewField113312212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113312212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113312212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113312212.TextFont.Name = "Arial";
                    NewField113312212.TextFont.Size = 7;
                    NewField113312212.TextFont.Bold = true;
                    NewField113312212.TextFont.CharSet = 162;
                    NewField113312212.Value = @"TARİHİ";

                    NewField1212213311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 6, 195, 18, false);
                    NewField1212213311.Name = "NewField1212213311";
                    NewField1212213311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212213311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212213311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212213311.TextFont.Name = "Arial";
                    NewField1212213311.TextFont.Size = 7;
                    NewField1212213311.TextFont.Bold = true;
                    NewField1212213311.TextFont.CharSet = 162;
                    NewField1212213311.Value = @"NOTLAR";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 18, 126, 18, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1141212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 1, 241, 18, false);
                    NewField1141212.Name = "NewField1141212";
                    NewField1141212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141212.TextFont.Name = "Arial";
                    NewField1141212.TextFont.Size = 7;
                    NewField1141212.TextFont.Bold = true;
                    NewField1141212.TextFont.CharSet = 162;
                    NewField1141212.Value = @"

DAĞITIM YERİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111112111.CalcValue = NewField111112111.Value;
                    NewField111112121.CalcValue = NewField111112121.Value;
                    NewField12121112.CalcValue = NewField12121112.Value;
                    NewField12121111.CalcValue = NewField12121111.Value;
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField1111212.CalcValue = NewField1111212.Value;
                    NewField1111211.CalcValue = NewField1111211.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField112131.CalcValue = NewField112131.Value;
                    NewField1131211.CalcValue = NewField1131211.Value;
                    NewField112141.CalcValue = NewField112141.Value;
                    NewField1141211.CalcValue = NewField1141211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField11221331.CalcValue = NewField11221331.Value;
                    NewField11221341.CalcValue = NewField11221341.Value;
                    NewField1131212.CalcValue = NewField1131212.Value;
                    NewField12121311.CalcValue = NewField12121311.Value;
                    NewField12121312.CalcValue = NewField12121312.Value;
                    NewField113312211.CalcValue = NewField113312211.Value;
                    NewField113312212.CalcValue = NewField113312212.Value;
                    NewField1212213311.CalcValue = NewField1212213311.Value;
                    NewField1141212.CalcValue = NewField1141212.Value;
                    return new TTReportObject[] { NewField111112111,NewField111112121,NewField12121112,NewField12121111,NewField11121111,NewField1111212,NewField1111211,NewField112111,NewField112131,NewField1131211,NewField112141,NewField1141211,NewField11121,NewField112121,NewField11221331,NewField11221341,NewField1131212,NewField12121311,NewField12121312,NewField113312211,NewField113312212,NewField1212213311,NewField1141212};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public VaccineIBFReport MyParentReport
                {
                    get { return (VaccineIBFReport)ParentReport; }
                }
                
                public TTReportShape NewLine13; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public VaccineIBFReport MyParentReport
            {
                get { return (VaccineIBFReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField CLINIC { get {return Body().CLINIC;} }
            public TTReportField DISTRIBUTIONPLACE { get {return Body().DISTRIBUTIONPLACE;} }
            public TTReportField SUPPORTINGPLACE { get {return Body().SUPPORTINGPLACE;} }
            public TTReportField RESOURCETYPE { get {return Body().RESOURCETYPE;} }
            public TTReportField MKS { get {return Body().MKS;} }
            public TTReportField SPECIFICATIONNAME { get {return Body().SPECIFICATIONNAME;} }
            public TTReportField SPECIFICATIONNO { get {return Body().SPECIFICATIONNO;} }
            public TTReportField SPECIFICATIONDATE { get {return Body().SPECIFICATIONDATE;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public TTReportShape NewLine161 { get {return Body().NewLine161;} }
            public TTReportShape NewLine162 { get {return Body().NewLine162;} }
            public TTReportShape NewLine163 { get {return Body().NewLine163;} }
            public TTReportShape NewLine164 { get {return Body().NewLine164;} }
            public TTReportShape NewLine165 { get {return Body().NewLine165;} }
            public TTReportShape NewLine166 { get {return Body().NewLine166;} }
            public TTReportShape NewLine167 { get {return Body().NewLine167;} }
            public TTReportShape NewLine168 { get {return Body().NewLine168;} }
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
                public VaccineIBFReport MyParentReport
                {
                    get { return (VaccineIBFReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField CLINIC;
                public TTReportField DISTRIBUTIONPLACE;
                public TTReportField SUPPORTINGPLACE;
                public TTReportField RESOURCETYPE;
                public TTReportField MKS;
                public TTReportField SPECIFICATIONNAME;
                public TTReportField SPECIFICATIONNO;
                public TTReportField SPECIFICATIONDATE;
                public TTReportField REQUESTAMOUNT;
                public TTReportField COUNT;
                public TTReportField MATERIAL;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine14;
                public TTReportShape NewLine16;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine141;
                public TTReportShape NewLine161;
                public TTReportShape NewLine162;
                public TTReportShape NewLine163;
                public TTReportShape NewLine164;
                public TTReportShape NewLine165;
                public TTReportShape NewLine166;
                public TTReportShape NewLine167;
                public TTReportShape NewLine168;
                public TTReportField DETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 0, 289, 6, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 7;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}{#DETAILDESCRIPTION!GetIBFDetailInQuery#}";

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 265, 6, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINIC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLINIC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLINIC.TextFont.Name = "Arial";
                    CLINIC.TextFont.Size = 7;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"";

                    DISTRIBUTIONPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 0, 241, 6, false);
                    DISTRIBUTIONPLACE.Name = "DISTRIBUTIONPLACE";
                    DISTRIBUTIONPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONPLACE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONPLACE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONPLACE.TextFont.Name = "Arial";
                    DISTRIBUTIONPLACE.TextFont.Size = 7;
                    DISTRIBUTIONPLACE.TextFont.CharSet = 162;
                    DISTRIBUTIONPLACE.Value = @"";

                    SUPPORTINGPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 209, 6, false);
                    SUPPORTINGPLACE.Name = "SUPPORTINGPLACE";
                    SUPPORTINGPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPORTINGPLACE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPORTINGPLACE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPORTINGPLACE.TextFont.Name = "Arial";
                    SUPPORTINGPLACE.TextFont.Size = 7;
                    SUPPORTINGPLACE.TextFont.CharSet = 162;
                    SUPPORTINGPLACE.Value = @"";

                    RESOURCETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 108, 6, false);
                    RESOURCETYPE.Name = "RESOURCETYPE";
                    RESOURCETYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCETYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESOURCETYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESOURCETYPE.TextFont.Name = "Arial";
                    RESOURCETYPE.TextFont.Size = 7;
                    RESOURCETYPE.TextFont.CharSet = 162;
                    RESOURCETYPE.Value = @"";

                    MKS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 97, 6, false);
                    MKS.Name = "MKS";
                    MKS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MKS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MKS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MKS.TextFont.Name = "Arial";
                    MKS.TextFont.Size = 7;
                    MKS.TextFont.CharSet = 162;
                    MKS.Value = @"";

                    SPECIFICATIONNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 152, 6, false);
                    SPECIFICATIONNAME.Name = "SPECIFICATIONNAME";
                    SPECIFICATIONNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIFICATIONNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPECIFICATIONNAME.MultiLine = EvetHayirEnum.ehEvet;
                    SPECIFICATIONNAME.WordBreak = EvetHayirEnum.ehEvet;
                    SPECIFICATIONNAME.TextFont.Name = "Arial";
                    SPECIFICATIONNAME.TextFont.Size = 7;
                    SPECIFICATIONNAME.TextFont.CharSet = 162;
                    SPECIFICATIONNAME.Value = @"";

                    SPECIFICATIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 170, 6, false);
                    SPECIFICATIONNO.Name = "SPECIFICATIONNO";
                    SPECIFICATIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIFICATIONNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPECIFICATIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPECIFICATIONNO.TextFont.Name = "Arial";
                    SPECIFICATIONNO.TextFont.Size = 7;
                    SPECIFICATIONNO.TextFont.CharSet = 162;
                    SPECIFICATIONNO.Value = @"";

                    SPECIFICATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 183, 6, false);
                    SPECIFICATIONDATE.Name = "SPECIFICATIONDATE";
                    SPECIFICATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIFICATIONDATE.TextFormat = @"dd/MM/yyyy";
                    SPECIFICATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SPECIFICATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SPECIFICATIONDATE.TextFont.Name = "Arial";
                    SPECIFICATIONDATE.TextFont.Size = 7;
                    SPECIFICATIONDATE.TextFont.CharSet = 162;
                    SPECIFICATIONDATE.Value = @"";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 62, 6, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 7;
                    REQUESTAMOUNT.TextFont.CharSet = 162;
                    REQUESTAMOUNT.Value = @"{#REQUESTAMOUNT#}{#REQUESTAMOUNT!GetIBFDetailInQuery#}{#APPROVEDAMOUNT!GetLBPurchaseProjectDetailInQuery#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 17, 6, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 7;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 55, 6, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 7;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"{#MATERIAL#}{#MATERIAL!GetIBFDetailInQuery#}{#MATERIAL!GetLBPurchaseProjectDetailInQuery#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 0, 17, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 0, 56, 6, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 75, 0, 75, 6, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 0, 195, 6, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 209, 0, 209, 6, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 241, 0, 241, 6, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 265, 0, 265, 6, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine24.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 289, 0, 289, 6, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine25.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 6, 289, 6, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 289, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 62, 0, 62, 6, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine141.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 88, 0, 88, 6, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine162 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 97, 0, 97, 6, false);
                    NewLine162.Name = "NewLine162";
                    NewLine162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine162.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine163 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 0, 108, 6, false);
                    NewLine163.Name = "NewLine163";
                    NewLine163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine163.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine164 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 117, 0, 117, 6, false);
                    NewLine164.Name = "NewLine164";
                    NewLine164.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine164.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine165 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 126, 0, 126, 6, false);
                    NewLine165.Name = "NewLine165";
                    NewLine165.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine165.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine166 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 0, 153, 6, false);
                    NewLine166.Name = "NewLine166";
                    NewLine166.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine166.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine167 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 6, false);
                    NewLine167.Name = "NewLine167";
                    NewLine167.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine167.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine168 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 0, 183, 6, false);
                    NewLine168.Name = "NewLine168";
                    NewLine168.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine168.ExtendTo = ExtendToEnum.extPageHeight;

                    DETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 1, 330, 6, false);
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
                    DESCRIPTION.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Description) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.DetailDescription) : "");
                    CLINIC.CalcValue = @"";
                    DISTRIBUTIONPLACE.CalcValue = @"";
                    SUPPORTINGPLACE.CalcValue = @"";
                    RESOURCETYPE.CalcValue = @"";
                    MKS.CalcValue = @"";
                    SPECIFICATIONNAME.CalcValue = @"";
                    SPECIFICATIONNO.CalcValue = @"";
                    SPECIFICATIONDATE.CalcValue = @"";
                    REQUESTAMOUNT.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.RequestAmount) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.RequestAmount) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ApprovedAmount) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MATERIAL.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.Material) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.Material) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.Material) : "");
                    DETAILOBJECTID.CalcValue = (dataset_GetAnnualRequirementDetailInListQuery != null ? Globals.ToStringCore(dataset_GetAnnualRequirementDetailInListQuery.ObjectID) : "") + (dataset_GetIBFDetailInQuery != null ? Globals.ToStringCore(dataset_GetIBFDetailInQuery.ObjectID) : "") + (dataset_GetLBPurchaseProjectDetailInQuery != null ? Globals.ToStringCore(dataset_GetLBPurchaseProjectDetailInQuery.ObjectID) : "");
                    return new TTReportObject[] { DESCRIPTION,CLINIC,DISTRIBUTIONPLACE,SUPPORTINGPLACE,RESOURCETYPE,MKS,SPECIFICATIONNAME,SPECIFICATIONNO,SPECIFICATIONDATE,REQUESTAMOUNT,COUNT,MATERIAL,DETAILOBJECTID};
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
                    IBFDet_VaccineIn vaccine = (IBFDet_VaccineIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(IBFDet_VaccineIn));
                    if(ibfDemand.CurrentStateDefID == IBFDemand.States.New || ibfDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        if(vaccine.ClinicApprovedAmount == null)
                            REQUESTAMOUNT.CalcValue = vaccine.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = vaccine.ClinicApprovedAmount.ToString();
                    }
                    else if(ibfDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval ||ibfDemand.CurrentStateDefID == IBFDemand.States.Completed)
                        REQUESTAMOUNT.CalcValue = vaccine.Amount.ToString();
                    
                    MKS.CalcValue = vaccine.MKS;
                    RESOURCETYPE.CalcValue = vaccine.ResourceType;
                    SUPPORTINGPLACE.CalcValue = vaccine.SupportingPlace;
                    DISTRIBUTIONPLACE.CalcValue = vaccine.DistributingPlace;
                    CLINIC.CalcValue = vaccine.Clinic;
                    
                }
                else if(purchaseAction is AnnualRequirement)
                {
                    AnnualRequirement ibf = (AnnualRequirement)purchaseAction;
                    ARD_VaccineIn vaccine = (ARD_VaccineIn)MyParentReport.ReportObjectContext.GetObject(new Guid(DETAILOBJECTID.CalcValue), typeof(ARD_VaccineIn));
                    if(ibf.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty || ibf.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {                        
                        if(vaccine.ACC_ApproveAmount == null)
                            REQUESTAMOUNT.CalcValue = vaccine.RequestAmount.ToString();
                        else
                            REQUESTAMOUNT.CalcValue = vaccine.ACC_ApproveAmount.ToString();
                    }
                    
                    else if(ibf.CurrentStateDefID == AnnualRequirement.States.LDApprove || ibf.CurrentStateDefID == AnnualRequirement.States.Completed)
                        REQUESTAMOUNT.CalcValue = vaccine.LD_ApproveAmount.ToString();
                    
                    else
                        REQUESTAMOUNT.CalcValue = vaccine.LB_ApproveAmount.ToString();
                    
                    MKS.CalcValue = vaccine.MKS;
                    RESOURCETYPE.CalcValue = vaccine.ResourceType;
                    SUPPORTINGPLACE.CalcValue = vaccine.SupportingPlace;
                    DISTRIBUTIONPLACE.CalcValue = vaccine.DistributionPlace;
                    CLINIC.CalcValue = vaccine.Clinic;
                }
            }
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

        public VaccineIBFReport()
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
            Name = "VACCINEIBFREPORT";
            Caption = "Yurt İçi Sağlık Ana Malzeme Modernizasyonu İhtiyaç Bildirim Formu";
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