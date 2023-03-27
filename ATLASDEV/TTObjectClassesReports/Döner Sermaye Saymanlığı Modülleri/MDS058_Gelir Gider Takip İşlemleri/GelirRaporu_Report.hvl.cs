
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
    /// Gelir Raporu
    /// </summary>
    public partial class GelirRaporu : TTReport
    {
#region Methods
   public double totalPrice = 0;
        public int rowCount = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public int? MONTH = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public GelirRaporu MyParentReport
            {
                get { return (GelirRaporu)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField SATIRSAYISI { get {return Footer().SATIRSAYISI;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportShape NewLine4 { get {return Footer().NewLine4;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
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
                public GelirRaporu MyParentReport
                {
                    get { return (GelirRaporu)ParentReport; }
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
                    MyParentReport.totalPrice = 0;
            MyParentReport.rowCount = 0;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public GelirRaporu MyParentReport
                {
                    get { return (GelirRaporu)ParentReport; }
                }
                
                public TTReportField SATIRSAYISI;
                public TTReportField TOTALPRICE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine14; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SATIRSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 177, 6, false);
                    SATIRSAYISI.Name = "SATIRSAYISI";
                    SATIRSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SATIRSAYISI.TextFont.Name = "Arial Narrow";
                    SATIRSAYISI.TextFont.Size = 9;
                    SATIRSAYISI.TextFont.Bold = true;
                    SATIRSAYISI.Value = @"Toplam Satır Sayısı : ";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 202, 6, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.TextFont.Name = "Arial Narrow";
                    TOTALPRICE.TextFont.Size = 9;
                    TOTALPRICE.TextFont.Bold = true;
                    TOTALPRICE.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 7, 203, 7, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 7, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 7, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 0, 179, 7, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SATIRSAYISI.CalcValue = @"Toplam Satır Sayısı : ";
                    TOTALPRICE.CalcValue = @"";
                    return new TTReportObject[] { SATIRSAYISI,TOTALPRICE};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.SATIRSAYISI.CalcValue += MyParentReport.rowCount.ToString();
            this.TOTALPRICE.CalcValue = MyParentReport.totalPrice.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADERGroup : TTReportGroup
        {
            public GelirRaporu MyParentReport
            {
                get { return (GelirRaporu)ParentReport; }
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
                public GelirRaporu MyParentReport
                {
                    get { return (GelirRaporu)ParentReport; }
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
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 42, 39, 47, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI.TextFont.Size = 9;
                    LBL_ADSOYADI.TextFont.Bold = true;
                    LBL_ADSOYADI.Value = @"Kodu";

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
                    REPORTHEADER1111.Value = @"GELİR RAPORU DETAYLI";

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

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 19, 159, 48, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 41, 203, 41, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    LBL_ADSOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 42, 158, 47, false);
                    LBL_ADSOYADI1.Name = "LBL_ADSOYADI1";
                    LBL_ADSOYADI1.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI1.TextFont.Size = 9;
                    LBL_ADSOYADI1.TextFont.Bold = true;
                    LBL_ADSOYADI1.Value = @"Adı";

                    LBL_ADSOYADI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 42, 178, 47, false);
                    LBL_ADSOYADI2.Name = "LBL_ADSOYADI2";
                    LBL_ADSOYADI2.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI2.TextFont.Size = 9;
                    LBL_ADSOYADI2.TextFont.Bold = true;
                    LBL_ADSOYADI2.Value = @"Dönem";

                    LBL_ADSOYADI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 42, 202, 47, false);
                    LBL_ADSOYADI3.Name = "LBL_ADSOYADI3";
                    LBL_ADSOYADI3.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI3.TextFont.Size = 9;
                    LBL_ADSOYADI3.TextFont.Bold = true;
                    LBL_ADSOYADI3.Value = @"Tutar";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 41, 179, 48, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 48, 203, 48, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 41, 40, 48, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 19, 203, 19, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 203, 11, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

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
                public GelirRaporu MyParentReport
                {
                    get { return (GelirRaporu)ParentReport; }
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

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, -1, 40, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, -1, 159, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, -1, 179, 1, false);
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
            public GelirRaporu MyParentReport
            {
                get { return (GelirRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DONEM { get {return Body().DONEM;} }
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

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountVoucher.GetAccountVoucherDept_Class>("GetAccountVoucherDept", AccountVoucher.GetAccountVoucherDept((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MONTH),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR)));
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
                public GelirRaporu MyParentReport
                {
                    get { return (GelirRaporu)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField MONTH;
                public TTReportField YEAR;
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DONEM;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 202, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.TextFont.Name = "Arial Narrow";
                    TOTALPRICE.TextFont.Size = 9;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 1, 247, 6, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.ObjectDefName = "MonthsEnum";
                    MONTH.DataMember = "DISPLAYTEXT";
                    MONTH.TextFont.Name = "Arial Narrow";
                    MONTH.TextFont.Size = 9;
                    MONTH.Value = @"{#MONTH#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 1, 276, 6, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFont.Name = "Arial Narrow";
                    YEAR.TextFont.Size = 9;
                    YEAR.Value = @"{#YEAR#}";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 39, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.Name = "Arial Narrow";
                    CODE.TextFont.Size = 9;
                    CODE.Value = @"{#CODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 158, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DONEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 178, 5, false);
                    DONEM.Name = "DONEM";
                    DONEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DONEM.TextFont.Name = "Arial Narrow";
                    DONEM.TextFont.Size = 9;
                    DONEM.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 0, 179, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 0, 159, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 0, 40, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountVoucher.GetAccountVoucherDept_Class dataset_GetAccountVoucherDept = ParentGroup.rsGroup.GetCurrentRecord<AccountVoucher.GetAccountVoucherDept_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_GetAccountVoucherDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherDept.TotalPrice) : "");
                    MONTH.CalcValue = (dataset_GetAccountVoucherDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherDept.Month) : "");
                    MONTH.PostFieldValueCalculation();
                    YEAR.CalcValue = (dataset_GetAccountVoucherDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherDept.Year) : "");
                    CODE.CalcValue = (dataset_GetAccountVoucherDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherDept.Code) : "");
                    DESCRIPTION.CalcValue = (dataset_GetAccountVoucherDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherDept.Description) : "");
                    DONEM.CalcValue = @"";
                    return new TTReportObject[] { TOTALPRICE,MONTH,YEAR,CODE,DESCRIPTION,DONEM};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.DONEM.CalcValue = this.MONTH.CalcValue + " " + this.YEAR.CalcValue;
            
            if(!string.IsNullOrEmpty(this.TOTALPRICE.CalcValue))
                MyParentReport.totalPrice += double.Parse(this.TOTALPRICE.CalcValue);
            
            MyParentReport.rowCount++;
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

        public GelirRaporu()
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
            Name = "GELIRRAPORU";
            Caption = "Gelir Raporu";
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