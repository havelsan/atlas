
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
    public partial class GelirGiderToplamYekunRaporu : TTReport
    {
#region Methods
   double toplamGelir = 0;
        double toplamGider = 0;
        double toplamFark = 0;
        int donemCounter = 0;
        List<Donem> donemList = new List<Donem>();
        
        public class Donem
        {
            public string donemAdi;
            public double gelir;
            public double gider;
            public double fark;
        }

        public Donem CreateDonem(string donemAdi, double gelir, double gider, double fark)
        {
            Donem donem = new Donem()
            {
                donemAdi = donemAdi,
                gelir = gelir,
                gider = gider,
                fark = fark
            };

            donemList.Add(donem);
            return donem;
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public int? MONTH = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public GelirGiderToplamYekunRaporu MyParentReport
            {
                get { return (GelirGiderToplamYekunRaporu)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField TOPLAMLBL { get {return Footer().TOPLAMLBL;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportShape NewLine4 { get {return Footer().NewLine4;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportField TOPLAMFARK { get {return Footer().TOPLAMFARK;} }
            public TTReportField TOPLAMGELIR { get {return Footer().TOPLAMGELIR;} }
            public TTReportField TOPLAMGIDER { get {return Footer().TOPLAMGIDER;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine141 { get {return Footer().NewLine141;} }
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
                public GelirGiderToplamYekunRaporu MyParentReport
                {
                    get { return (GelirGiderToplamYekunRaporu)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    MyParentReport.toplamGelir = 0;
            MyParentReport.toplamGider = 0;
            MyParentReport.toplamFark = 0;
            MyParentReport.donemCounter = 0;
            MyParentReport.donemList.Clear();
            
            if (MyParentReport.RuntimeParameters.YEAR.HasValue && MyParentReport.RuntimeParameters.MONTH.HasValue)
            {
                List<AccountVoucher.AccountVoucherPeriodPricesInfo> list = AccountVoucher.GetAccountVoucherPeriodPrices(MyParentReport.RuntimeParameters.YEAR.Value, MyParentReport.RuntimeParameters.MONTH.Value);
                list.OrderBy(x => x.month);
                foreach (AccountVoucher.AccountVoucherPeriodPricesInfo item in list)
                {
                    string donemAdi = TTObjectClasses.Common.GetDisplayTextOfEnumValue("MonthsEnum", item.month) + " " + item.year;
                    MyParentReport.CreateDonem(donemAdi, item.totalNonDept, item.totalDept, item.totalDifference);
                }
            }
            
            MyParentReport.MAIN.RepeatCount = MyParentReport.donemList.Count;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public GelirGiderToplamYekunRaporu MyParentReport
                {
                    get { return (GelirGiderToplamYekunRaporu)ParentReport; }
                }
                
                public TTReportField TOPLAMLBL;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine14;
                public TTReportField TOPLAMFARK;
                public TTReportField TOPLAMGELIR;
                public TTReportField TOPLAMGIDER;
                public TTReportShape NewLine11;
                public TTReportShape NewLine141; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 52, 10, false);
                    TOPLAMLBL.Name = "TOPLAMLBL";
                    TOPLAMLBL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAMLBL.TextFont.Name = "Arial Narrow";
                    TOPLAMLBL.TextFont.Size = 9;
                    TOPLAMLBL.TextFont.Bold = true;
                    TOPLAMLBL.Value = @"Toplam";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 10, 203, 10, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 10, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 0, 153, 10, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 0, 103, 10, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    TOPLAMFARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 202, 10, false);
                    TOPLAMFARK.Name = "TOPLAMFARK";
                    TOPLAMFARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFARK.TextFormat = @"#,##0.#0";
                    TOPLAMFARK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAMFARK.TextFont.Name = "Arial Narrow";
                    TOPLAMFARK.TextFont.Size = 9;
                    TOPLAMFARK.TextFont.Bold = true;
                    TOPLAMFARK.Value = @"";

                    TOPLAMGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 102, 10, false);
                    TOPLAMGELIR.Name = "TOPLAMGELIR";
                    TOPLAMGELIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMGELIR.TextFormat = @"#,##0.#0";
                    TOPLAMGELIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAMGELIR.TextFont.Name = "Arial Narrow";
                    TOPLAMGELIR.TextFont.Size = 9;
                    TOPLAMGELIR.TextFont.Bold = true;
                    TOPLAMGELIR.Value = @"";

                    TOPLAMGIDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 152, 10, false);
                    TOPLAMGIDER.Name = "TOPLAMGIDER";
                    TOPLAMGIDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMGIDER.TextFormat = @"#,##0.#0";
                    TOPLAMGIDER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAMGIDER.TextFont.Name = "Arial Narrow";
                    TOPLAMGIDER.TextFont.Size = 9;
                    TOPLAMGIDER.TextFont.Bold = true;
                    TOPLAMGIDER.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 53, 0, 53, 10, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMLBL.CalcValue = TOPLAMLBL.Value;
                    TOPLAMFARK.CalcValue = @"";
                    TOPLAMGELIR.CalcValue = @"";
                    TOPLAMGIDER.CalcValue = @"";
                    return new TTReportObject[] { TOPLAMLBL,TOPLAMFARK,TOPLAMGELIR,TOPLAMGIDER};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.TOPLAMGELIR.CalcValue += MyParentReport.toplamGelir.ToString();
            this.TOPLAMGIDER.CalcValue = MyParentReport.toplamGider.ToString();
            this.TOPLAMFARK.CalcValue = MyParentReport.toplamFark.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADERGroup : TTReportGroup
        {
            public GelirGiderToplamYekunRaporu MyParentReport
            {
                get { return (GelirGiderToplamYekunRaporu)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField LBL_ADSOYADI { get {return Header().LBL_ADSOYADI;} }
            public TTReportField BIRIMLBL { get {return Header().BIRIMLBL;} }
            public TTReportField REPORTHEADER1111 { get {return Header().REPORTHEADER1111;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField BIRIMLBL1 { get {return Header().BIRIMLBL1;} }
            public TTReportField BIRIMLBL2 { get {return Header().BIRIMLBL2;} }
            public TTReportField BIRIMLBL3 { get {return Header().BIRIMLBL3;} }
            public TTReportField BIRIMLBL11 { get {return Header().BIRIMLBL11;} }
            public TTReportField BIRIMLBL111 { get {return Header().BIRIMLBL111;} }
            public TTReportField BIRIMLBL112 { get {return Header().BIRIMLBL112;} }
            public TTReportField KURULUSID { get {return Header().KURULUSID;} }
            public TTReportField DONEM { get {return Header().DONEM;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField TARIH2 { get {return Header().TARIH2;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField BIRIMLBL1211 { get {return Header().BIRIMLBL1211;} }
            public TTReportField KURULUSADI { get {return Header().KURULUSADI;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField LBL_ADSOYADI1 { get {return Header().LBL_ADSOYADI1;} }
            public TTReportField LBL_ADSOYADI2 { get {return Header().LBL_ADSOYADI2;} }
            public TTReportField LBL_ADSOYADI3 { get {return Header().LBL_ADSOYADI3;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public GelirGiderToplamYekunRaporu MyParentReport
                {
                    get { return (GelirGiderToplamYekunRaporu)ParentReport; }
                }
                
                public TTReportField LBL_ADSOYADI;
                public TTReportField BIRIMLBL;
                public TTReportField REPORTHEADER1111;
                public TTReportShape NewLine3;
                public TTReportField BIRIMLBL1;
                public TTReportField BIRIMLBL2;
                public TTReportField BIRIMLBL3;
                public TTReportField BIRIMLBL11;
                public TTReportField BIRIMLBL111;
                public TTReportField BIRIMLBL112;
                public TTReportField KURULUSID;
                public TTReportField DONEM;
                public TTReportField TARIH1;
                public TTReportField TARIH2;
                public TTReportShape NewLine13;
                public TTReportField BIRIMLBL1211;
                public TTReportField KURULUSADI;
                public TTReportShape NewLine131;
                public TTReportShape NewLine4;
                public TTReportField LBL_ADSOYADI1;
                public TTReportField LBL_ADSOYADI2;
                public TTReportField LBL_ADSOYADI3;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine15;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine17; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 42, 52, 47, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI.TextFont.Size = 9;
                    LBL_ADSOYADI.TextFont.Bold = true;
                    LBL_ADSOYADI.Value = @"Dönem";

                    BIRIMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 28, 25, false);
                    BIRIMLBL.Name = "BIRIMLBL";
                    BIRIMLBL.TextFont.Name = "Arial Narrow";
                    BIRIMLBL.TextFont.Bold = true;
                    BIRIMLBL.Value = @"Kuruluş Adı :";

                    REPORTHEADER1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 12, 202, 18, false);
                    REPORTHEADER1111.Name = "REPORTHEADER1111";
                    REPORTHEADER1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1111.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1111.TextFont.Size = 12;
                    REPORTHEADER1111.TextFont.Bold = true;
                    REPORTHEADER1111.Value = @"GELİR / GİDER TOPLAM YEKÜN RAPORU";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 8, 48, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 20, 177, 25, false);
                    BIRIMLBL1.Name = "BIRIMLBL1";
                    BIRIMLBL1.TextFont.Name = "Arial Narrow";
                    BIRIMLBL1.TextFont.Bold = true;
                    BIRIMLBL1.Value = @"Kuruluş Id";

                    BIRIMLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 25, 177, 30, false);
                    BIRIMLBL2.Name = "BIRIMLBL2";
                    BIRIMLBL2.TextFont.Name = "Arial Narrow";
                    BIRIMLBL2.TextFont.Bold = true;
                    BIRIMLBL2.Value = @"Dönem";

                    BIRIMLBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 30, 177, 35, false);
                    BIRIMLBL3.Name = "BIRIMLBL3";
                    BIRIMLBL3.TextFont.Name = "Arial Narrow";
                    BIRIMLBL3.TextFont.Bold = true;
                    BIRIMLBL3.Value = @"Tarih Aralığı";

                    BIRIMLBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 20, 179, 25, false);
                    BIRIMLBL11.Name = "BIRIMLBL11";
                    BIRIMLBL11.TextFont.Name = "Arial Narrow";
                    BIRIMLBL11.TextFont.Bold = true;
                    BIRIMLBL11.Value = @":";

                    BIRIMLBL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 25, 179, 30, false);
                    BIRIMLBL111.Name = "BIRIMLBL111";
                    BIRIMLBL111.TextFont.Name = "Arial Narrow";
                    BIRIMLBL111.TextFont.Bold = true;
                    BIRIMLBL111.Value = @":";

                    BIRIMLBL112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 30, 179, 35, false);
                    BIRIMLBL112.Name = "BIRIMLBL112";
                    BIRIMLBL112.TextFont.Name = "Arial Narrow";
                    BIRIMLBL112.TextFont.Bold = true;
                    BIRIMLBL112.Value = @":";

                    KURULUSID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 20, 197, 25, false);
                    KURULUSID.Name = "KURULUSID";
                    KURULUSID.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURULUSID.TextFont.Name = "Arial Narrow";
                    KURULUSID.Value = @"";

                    DONEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 25, 197, 30, false);
                    DONEM.Name = "DONEM";
                    DONEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DONEM.TextFont.Name = "Arial Narrow";
                    DONEM.Value = @"{@YEAR@}";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 30, 197, 35, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.TextFont.Name = "Arial Narrow";
                    TARIH1.Value = @"";

                    TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 35, 197, 40, false);
                    TARIH2.Name = "TARIH2";
                    TARIH2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH2.TextFont.Name = "Arial Narrow";
                    TARIH2.Value = @"";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 11, 203, 48, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMLBL1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 30, 202, 35, false);
                    BIRIMLBL1211.Name = "BIRIMLBL1211";
                    BIRIMLBL1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIMLBL1211.TextFont.Name = "Arial Narrow";
                    BIRIMLBL1211.TextFont.Bold = true;
                    BIRIMLBL1211.Value = @"-";

                    KURULUSADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 20, 158, 40, false);
                    KURULUSADI.Name = "KURULUSADI";
                    KURULUSADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURULUSADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURULUSADI.NoClip = EvetHayirEnum.ehEvet;
                    KURULUSADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURULUSADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURULUSADI.TextFont.Name = "Arial Narrow";
                    KURULUSADI.Value = @"";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 19, 159, 41, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 41, 203, 41, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    LBL_ADSOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 42, 102, 47, false);
                    LBL_ADSOYADI1.Name = "LBL_ADSOYADI1";
                    LBL_ADSOYADI1.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI1.TextFont.Size = 9;
                    LBL_ADSOYADI1.TextFont.Bold = true;
                    LBL_ADSOYADI1.Value = @"Toplam Gelir";

                    LBL_ADSOYADI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 42, 152, 47, false);
                    LBL_ADSOYADI2.Name = "LBL_ADSOYADI2";
                    LBL_ADSOYADI2.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI2.TextFont.Size = 9;
                    LBL_ADSOYADI2.TextFont.Bold = true;
                    LBL_ADSOYADI2.Value = @"Toplam Gider";

                    LBL_ADSOYADI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 42, 202, 47, false);
                    LBL_ADSOYADI3.Name = "LBL_ADSOYADI3";
                    LBL_ADSOYADI3.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI3.TextFont.Size = 9;
                    LBL_ADSOYADI3.TextFont.Bold = true;
                    LBL_ADSOYADI3.Value = @"Fark";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 41, 153, 48, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 48, 203, 48, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 53, 41, 53, 48, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 19, 203, 19, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 203, 11, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 41, 103, 48, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_ADSOYADI.CalcValue = LBL_ADSOYADI.Value;
                    BIRIMLBL.CalcValue = BIRIMLBL.Value;
                    REPORTHEADER1111.CalcValue = REPORTHEADER1111.Value;
                    BIRIMLBL1.CalcValue = BIRIMLBL1.Value;
                    BIRIMLBL2.CalcValue = BIRIMLBL2.Value;
                    BIRIMLBL3.CalcValue = BIRIMLBL3.Value;
                    BIRIMLBL11.CalcValue = BIRIMLBL11.Value;
                    BIRIMLBL111.CalcValue = BIRIMLBL111.Value;
                    BIRIMLBL112.CalcValue = BIRIMLBL112.Value;
                    KURULUSID.CalcValue = @"";
                    DONEM.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    TARIH1.CalcValue = @"";
                    TARIH2.CalcValue = @"";
                    BIRIMLBL1211.CalcValue = BIRIMLBL1211.Value;
                    KURULUSADI.CalcValue = @"";
                    LBL_ADSOYADI1.CalcValue = LBL_ADSOYADI1.Value;
                    LBL_ADSOYADI2.CalcValue = LBL_ADSOYADI2.Value;
                    LBL_ADSOYADI3.CalcValue = LBL_ADSOYADI3.Value;
                    return new TTReportObject[] { LBL_ADSOYADI,BIRIMLBL,REPORTHEADER1111,BIRIMLBL1,BIRIMLBL2,BIRIMLBL3,BIRIMLBL11,BIRIMLBL111,BIRIMLBL112,KURULUSID,DONEM,TARIH1,TARIH2,BIRIMLBL1211,KURULUSADI,LBL_ADSOYADI1,LBL_ADSOYADI2,LBL_ADSOYADI3};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.KURULUSADI.CalcValue = SystemParameter.GetParameterValue("HOSPITALNAME", "");
            this.KURULUSID.CalcValue = SystemParameter.GetParameterValue("GELIRGIDERISLEMLERIKURULUSID", "12852");
            
            if (MyParentReport.RuntimeParameters.MONTH.HasValue && MyParentReport.RuntimeParameters.YEAR.HasValue)
            {
                int month = MyParentReport.RuntimeParameters.MONTH.Value;
                int year = MyParentReport.RuntimeParameters.YEAR.Value;

                if (month == 0)
                {
                    this.TARIH1.CalcValue = "01.01." + year;
                    this.TARIH2.CalcValue = "31.12." + year;
                }
                else
                {
                    this.TARIH1.CalcValue = "01." + (month < 10 ? "0" : string.Empty) + month + "." + year;
                    this.TARIH2.CalcValue = DateTime.DaysInMonth(year, month) + "." + (month < 10 ? "0" : string.Empty) + month + "." + year;
                }
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public GelirGiderToplamYekunRaporu MyParentReport
                {
                    get { return (GelirGiderToplamYekunRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine2;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine14;
                public TTReportShape NewLine16; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 203, 1, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbInsideSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, -1, 8, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 53, -1, 53, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, -1, 103, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, -1, 153, 1, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, -1, 203, 1, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public GelirGiderToplamYekunRaporu MyParentReport
            {
                get { return (GelirGiderToplamYekunRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField FARK { get {return Body().FARK;} }
            public TTReportField DONEM { get {return Body().DONEM;} }
            public TTReportField GELIR { get {return Body().GELIR;} }
            public TTReportField GIDER { get {return Body().GIDER;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
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
                public GelirGiderToplamYekunRaporu MyParentReport
                {
                    get { return (GelirGiderToplamYekunRaporu)ParentReport; }
                }
                
                public TTReportField FARK;
                public TTReportField DONEM;
                public TTReportField GELIR;
                public TTReportField GIDER;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    FARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 202, 10, false);
                    FARK.Name = "FARK";
                    FARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    FARK.TextFormat = @"#,##0.#0";
                    FARK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FARK.TextFont.Name = "Arial Narrow";
                    FARK.TextFont.Size = 9;
                    FARK.Value = @"";

                    DONEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 52, 10, false);
                    DONEM.Name = "DONEM";
                    DONEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DONEM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DONEM.TextFont.Name = "Arial Narrow";
                    DONEM.TextFont.Size = 9;
                    DONEM.TextFont.Bold = true;
                    DONEM.Value = @"";

                    GELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 102, 10, false);
                    GELIR.Name = "GELIR";
                    GELIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELIR.TextFormat = @"#,##0.#0";
                    GELIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GELIR.TextFont.Name = "Arial Narrow";
                    GELIR.TextFont.Size = 9;
                    GELIR.Value = @"";

                    GIDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 152, 10, false);
                    GIDER.Name = "GIDER";
                    GIDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIDER.TextFormat = @"#,##0.#0";
                    GIDER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GIDER.TextFont.Name = "Arial Narrow";
                    GIDER.TextFont.Size = 9;
                    GIDER.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 10, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 0, 153, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 0, 103, 10, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 53, 0, 53, 10, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 10, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FARK.CalcValue = @"";
                    DONEM.CalcValue = @"";
                    GELIR.CalcValue = @"";
                    GIDER.CalcValue = @"";
                    return new TTReportObject[] { FARK,DONEM,GELIR,GIDER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.donemList != null && MyParentReport.donemList.Count > 0)
            {
                Donem donem = MyParentReport.donemList[MyParentReport.donemCounter];
                this.DONEM.CalcValue = donem.donemAdi;
                this.GELIR.CalcValue = donem.gelir.ToString();
                this.GIDER.CalcValue = donem.gider.ToString();
                this.FARK.CalcValue = donem.fark.ToString();

                MyParentReport.toplamGelir += donem.gelir;
                MyParentReport.toplamGider += donem.gider;
                MyParentReport.toplamFark += donem.fark;
                MyParentReport.donemCounter++;
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

        public GelirGiderToplamYekunRaporu()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEADER = new HEADERGroup(PARTA,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MONTH", "", "Ay", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("YEAR", "", "Yıl", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MONTH"))
                _runtimeParameters.MONTH = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["MONTH"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["YEAR"]);
            Name = "GELIRGIDERTOPLAMYEKUNRAPORU";
            Caption = "Gelir Gider Toplam Yekün Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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