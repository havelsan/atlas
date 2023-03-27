
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
    /// Toplam Borç Raporu
    /// </summary>
    public partial class ToplamBorcRaporu : TTReport
    {
#region Methods
   public double toplamBorc = 0;
        public int rowCount = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public int? MONTH = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? YEAR = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ToplamBorcRaporu MyParentReport
            {
                get { return (ToplamBorcRaporu)ParentReport; }
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
            public TTReportField TOPLAMBORC { get {return Footer().TOPLAMBORC;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportShape NewLine4 { get {return Footer().NewLine4;} }
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
                public ToplamBorcRaporu MyParentReport
                {
                    get { return (ToplamBorcRaporu)ParentReport; }
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
                    MyParentReport.toplamBorc = 0; 
            MyParentReport.rowCount = 0;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ToplamBorcRaporu MyParentReport
                {
                    get { return (ToplamBorcRaporu)ParentReport; }
                }
                
                public TTReportField SATIRSAYISI;
                public TTReportField TOPLAMBORC;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine141; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SATIRSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 104, 6, false);
                    SATIRSAYISI.Name = "SATIRSAYISI";
                    SATIRSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SATIRSAYISI.TextFont.Name = "Arial Narrow";
                    SATIRSAYISI.TextFont.Size = 9;
                    SATIRSAYISI.TextFont.Bold = true;
                    SATIRSAYISI.Value = @"Toplam Satır Sayısı : ";

                    TOPLAMBORC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 202, 6, false);
                    TOPLAMBORC.Name = "TOPLAMBORC";
                    TOPLAMBORC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMBORC.TextFormat = @"#,##0.#0";
                    TOPLAMBORC.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMBORC.TextFont.Name = "Arial Narrow";
                    TOPLAMBORC.TextFont.Size = 9;
                    TOPLAMBORC.TextFont.Bold = true;
                    TOPLAMBORC.Value = @"";

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

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 105, 0, 105, 7, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SATIRSAYISI.CalcValue = @"Toplam Satır Sayısı : ";
                    TOPLAMBORC.CalcValue = @"";
                    return new TTReportObject[] { SATIRSAYISI,TOPLAMBORC};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.SATIRSAYISI.CalcValue += MyParentReport.rowCount.ToString();
            this.TOPLAMBORC.CalcValue = MyParentReport.toplamBorc.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADERGroup : TTReportGroup
        {
            public ToplamBorcRaporu MyParentReport
            {
                get { return (ToplamBorcRaporu)ParentReport; }
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
            public TTReportField LBL_ADSOYADI3 { get {return Header().LBL_ADSOYADI3;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine151 { get {return Header().NewLine151;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
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
                public ToplamBorcRaporu MyParentReport
                {
                    get { return (ToplamBorcRaporu)ParentReport; }
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
                public TTReportField LBL_ADSOYADI3;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine151; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 42, 104, 47, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
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
                    REPORTHEADER1111.Value = @"TOPLAM BORÇ RAPORU";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 8, 48, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 20, 178, 25, false);
                    BIRIMLBL1.Name = "BIRIMLBL1";
                    BIRIMLBL1.TextFont.Name = "Arial Narrow";
                    BIRIMLBL1.TextFont.Bold = true;
                    BIRIMLBL1.Value = @"Kuruluş Id";

                    BIRIMLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 25, 178, 30, false);
                    BIRIMLBL2.Name = "BIRIMLBL2";
                    BIRIMLBL2.TextFont.Name = "Arial Narrow";
                    BIRIMLBL2.TextFont.Bold = true;
                    BIRIMLBL2.Value = @"Dönem";

                    BIRIMLBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 30, 178, 35, false);
                    BIRIMLBL3.Name = "BIRIMLBL3";
                    BIRIMLBL3.TextFont.Name = "Arial Narrow";
                    BIRIMLBL3.TextFont.Bold = true;
                    BIRIMLBL3.Value = @"Tarih Aralığı";

                    BIRIMLBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 20, 180, 25, false);
                    BIRIMLBL11.Name = "BIRIMLBL11";
                    BIRIMLBL11.TextFont.Name = "Arial Narrow";
                    BIRIMLBL11.TextFont.Bold = true;
                    BIRIMLBL11.Value = @":";

                    BIRIMLBL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 25, 180, 30, false);
                    BIRIMLBL111.Name = "BIRIMLBL111";
                    BIRIMLBL111.TextFont.Name = "Arial Narrow";
                    BIRIMLBL111.TextFont.Bold = true;
                    BIRIMLBL111.Value = @":";

                    BIRIMLBL112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 30, 180, 35, false);
                    BIRIMLBL112.Name = "BIRIMLBL112";
                    BIRIMLBL112.TextFont.Name = "Arial Narrow";
                    BIRIMLBL112.TextFont.Bold = true;
                    BIRIMLBL112.Value = @":";

                    KURULUSID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 20, 198, 25, false);
                    KURULUSID.Name = "KURULUSID";
                    KURULUSID.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURULUSID.TextFont.Name = "Arial Narrow";
                    KURULUSID.Value = @"";

                    DONEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 25, 198, 30, false);
                    DONEM.Name = "DONEM";
                    DONEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DONEM.TextFont.Name = "Arial Narrow";
                    DONEM.Value = @"{@YEAR@}";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 30, 198, 35, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.TextFont.Name = "Arial Narrow";
                    TARIH1.Value = @"";

                    TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 35, 198, 40, false);
                    TARIH2.Name = "TARIH2";
                    TARIH2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH2.TextFont.Name = "Arial Narrow";
                    TARIH2.Value = @"";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 11, 203, 48, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMLBL1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 30, 203, 35, false);
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

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 20, 159, 41, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 41, 203, 41, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    LBL_ADSOYADI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 42, 202, 47, false);
                    LBL_ADSOYADI3.Name = "LBL_ADSOYADI3";
                    LBL_ADSOYADI3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBL_ADSOYADI3.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI3.TextFont.Size = 9;
                    LBL_ADSOYADI3.TextFont.Bold = true;
                    LBL_ADSOYADI3.Value = @"Borç Tutarı";

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 48, 203, 48, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 19, 203, 19, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 203, 11, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 105, 41, 105, 48, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

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
                    LBL_ADSOYADI3.CalcValue = LBL_ADSOYADI3.Value;
                    return new TTReportObject[] { LBL_ADSOYADI,BIRIMLBL,REPORTHEADER1111,BIRIMLBL1,BIRIMLBL2,BIRIMLBL3,BIRIMLBL11,BIRIMLBL111,BIRIMLBL112,KURULUSID,DONEM,TARIH1,TARIH2,BIRIMLBL1211,KURULUSADI,LBL_ADSOYADI3};
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
                public ToplamBorcRaporu MyParentReport
                {
                    get { return (ToplamBorcRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine2;
                public TTReportShape NewLine1;
                public TTReportShape NewLine16;
                public TTReportShape NewLine121; 
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

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, -1, 203, 1, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 105, -1, 105, 1, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

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
            public ToplamBorcRaporu MyParentReport
            {
                get { return (ToplamBorcRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BORC { get {return Body().BORC;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
            public TTReportField DONEM { get {return Body().DONEM;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
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
                list[0] = new TTReportNqlData<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class>("GetAccountTotalDebtsByMonthYear", AccountTotalDebt.GetAccountTotalDebtsByMonthYear((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MONTH),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR)));
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
                public ToplamBorcRaporu MyParentReport
                {
                    get { return (ToplamBorcRaporu)ParentReport; }
                }
                
                public TTReportField BORC;
                public TTReportField MONTH;
                public TTReportField YEAR;
                public TTReportField DONEM;
                public TTReportShape NewLine1;
                public TTReportShape NewLine14;
                public TTReportShape NewLine2;
                public TTReportShape NewLine121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    BORC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 0, 202, 5, false);
                    BORC.Name = "BORC";
                    BORC.FieldType = ReportFieldTypeEnum.ftVariable;
                    BORC.TextFormat = @"#,##0.#0";
                    BORC.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BORC.TextFont.Name = "Arial Narrow";
                    BORC.TextFont.Size = 9;
                    BORC.Value = @"{#TOTALDEBT#}";

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

                    DONEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 104, 5, false);
                    DONEM.Name = "DONEM";
                    DONEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DONEM.TextFont.Name = "Arial Narrow";
                    DONEM.TextFont.Size = 9;
                    DONEM.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 105, 0, 105, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class dataset_GetAccountTotalDebtsByMonthYear = ParentGroup.rsGroup.GetCurrentRecord<AccountTotalDebt.GetAccountTotalDebtsByMonthYear_Class>(0);
                    BORC.CalcValue = (dataset_GetAccountTotalDebtsByMonthYear != null ? Globals.ToStringCore(dataset_GetAccountTotalDebtsByMonthYear.TotalDebt) : "");
                    MONTH.CalcValue = (dataset_GetAccountTotalDebtsByMonthYear != null ? Globals.ToStringCore(dataset_GetAccountTotalDebtsByMonthYear.Month) : "");
                    MONTH.PostFieldValueCalculation();
                    YEAR.CalcValue = (dataset_GetAccountTotalDebtsByMonthYear != null ? Globals.ToStringCore(dataset_GetAccountTotalDebtsByMonthYear.Year) : "");
                    DONEM.CalcValue = @"";
                    return new TTReportObject[] { BORC,MONTH,YEAR,DONEM};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.DONEM.CalcValue = this.MONTH.CalcValue + " " + this.YEAR.CalcValue;
            
            if(!string.IsNullOrEmpty(this.BORC.CalcValue))
                MyParentReport.toplamBorc += double.Parse(this.BORC.CalcValue);
            
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

        public ToplamBorcRaporu()
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
            Name = "TOPLAMBORCRAPORU";
            Caption = "Toplam Borç Raporu";
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