
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
    /// Gider Raporu
    /// </summary>
    public partial class GiderRaporu : TTReport
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
            public GiderRaporu MyParentReport
            {
                get { return (GiderRaporu)ParentReport; }
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
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
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
                public GiderRaporu MyParentReport
                {
                    get { return (GiderRaporu)ParentReport; }
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
                public GiderRaporu MyParentReport
                {
                    get { return (GiderRaporu)ParentReport; }
                }
                
                public TTReportField SATIRSAYISI;
                public TTReportField TOTALPRICE;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine141; 
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

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 7, 203, 7, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 7, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 7, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 0, 179, 7, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

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
            public GiderRaporu MyParentReport
            {
                get { return (GiderRaporu)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField LBL_ADSOYADI1 { get {return Header().LBL_ADSOYADI1;} }
            public TTReportField BIRIMLBL1 { get {return Header().BIRIMLBL1;} }
            public TTReportField REPORTHEADER11111 { get {return Header().REPORTHEADER11111;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField BIRIMLBL11 { get {return Header().BIRIMLBL11;} }
            public TTReportField BIRIMLBL12 { get {return Header().BIRIMLBL12;} }
            public TTReportField BIRIMLBL13 { get {return Header().BIRIMLBL13;} }
            public TTReportField BIRIMLBL111 { get {return Header().BIRIMLBL111;} }
            public TTReportField BIRIMLBL1111 { get {return Header().BIRIMLBL1111;} }
            public TTReportField BIRIMLBL1211 { get {return Header().BIRIMLBL1211;} }
            public TTReportField KURULUSID { get {return Header().KURULUSID;} }
            public TTReportField DONEM { get {return Header().DONEM;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField TARIH2 { get {return Header().TARIH2;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportField BIRIMLBL11121 { get {return Header().BIRIMLBL11121;} }
            public TTReportField KURULUSADI { get {return Header().KURULUSADI;} }
            public TTReportShape NewLine1131 { get {return Header().NewLine1131;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportField LBL_ADSOYADI11 { get {return Header().LBL_ADSOYADI11;} }
            public TTReportField LBL_ADSOYADI12 { get {return Header().LBL_ADSOYADI12;} }
            public TTReportField LBL_ADSOYADI13 { get {return Header().LBL_ADSOYADI13;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine151 { get {return Header().NewLine151;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine141 { get {return Footer().NewLine141;} }
            public TTReportShape NewLine161 { get {return Footer().NewLine161;} }
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
                public GiderRaporu MyParentReport
                {
                    get { return (GiderRaporu)ParentReport; }
                }
                
                public TTReportField LBL_ADSOYADI1;
                public TTReportField BIRIMLBL1;
                public TTReportField REPORTHEADER11111;
                public TTReportShape NewLine13;
                public TTReportField BIRIMLBL11;
                public TTReportField BIRIMLBL12;
                public TTReportField BIRIMLBL13;
                public TTReportField BIRIMLBL111;
                public TTReportField BIRIMLBL1111;
                public TTReportField BIRIMLBL1211;
                public TTReportField KURULUSID;
                public TTReportField DONEM;
                public TTReportField TARIH1;
                public TTReportField TARIH2;
                public TTReportShape NewLine131;
                public TTReportField BIRIMLBL11121;
                public TTReportField KURULUSADI;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine14;
                public TTReportField LBL_ADSOYADI11;
                public TTReportField LBL_ADSOYADI12;
                public TTReportField LBL_ADSOYADI13;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine151;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_ADSOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 42, 39, 47, false);
                    LBL_ADSOYADI1.Name = "LBL_ADSOYADI1";
                    LBL_ADSOYADI1.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI1.TextFont.Size = 9;
                    LBL_ADSOYADI1.TextFont.Bold = true;
                    LBL_ADSOYADI1.Value = @"Kodu";

                    BIRIMLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 28, 25, false);
                    BIRIMLBL1.Name = "BIRIMLBL1";
                    BIRIMLBL1.TextFont.Name = "Arial Narrow";
                    BIRIMLBL1.TextFont.Bold = true;
                    BIRIMLBL1.Value = @"Kuruluş Adı :";

                    REPORTHEADER11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 12, 202, 18, false);
                    REPORTHEADER11111.Name = "REPORTHEADER11111";
                    REPORTHEADER11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER11111.TextFont.Name = "Arial Narrow";
                    REPORTHEADER11111.TextFont.Size = 12;
                    REPORTHEADER11111.TextFont.Bold = true;
                    REPORTHEADER11111.Value = @"GİDER RAPORU DETAYLI";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 8, 48, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMLBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 20, 177, 25, false);
                    BIRIMLBL11.Name = "BIRIMLBL11";
                    BIRIMLBL11.TextFont.Name = "Arial Narrow";
                    BIRIMLBL11.TextFont.Bold = true;
                    BIRIMLBL11.Value = @"Kuruluş Id";

                    BIRIMLBL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 25, 177, 30, false);
                    BIRIMLBL12.Name = "BIRIMLBL12";
                    BIRIMLBL12.TextFont.Name = "Arial Narrow";
                    BIRIMLBL12.TextFont.Bold = true;
                    BIRIMLBL12.Value = @"Dönem";

                    BIRIMLBL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 30, 177, 35, false);
                    BIRIMLBL13.Name = "BIRIMLBL13";
                    BIRIMLBL13.TextFont.Name = "Arial Narrow";
                    BIRIMLBL13.TextFont.Bold = true;
                    BIRIMLBL13.Value = @"Tarih Aralığı";

                    BIRIMLBL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 20, 179, 25, false);
                    BIRIMLBL111.Name = "BIRIMLBL111";
                    BIRIMLBL111.TextFont.Name = "Arial Narrow";
                    BIRIMLBL111.TextFont.Bold = true;
                    BIRIMLBL111.Value = @":";

                    BIRIMLBL1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 25, 179, 30, false);
                    BIRIMLBL1111.Name = "BIRIMLBL1111";
                    BIRIMLBL1111.TextFont.Name = "Arial Narrow";
                    BIRIMLBL1111.TextFont.Bold = true;
                    BIRIMLBL1111.Value = @":";

                    BIRIMLBL1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 30, 179, 35, false);
                    BIRIMLBL1211.Name = "BIRIMLBL1211";
                    BIRIMLBL1211.TextFont.Name = "Arial Narrow";
                    BIRIMLBL1211.TextFont.Bold = true;
                    BIRIMLBL1211.Value = @":";

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

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 11, 203, 48, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRIMLBL11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 30, 202, 35, false);
                    BIRIMLBL11121.Name = "BIRIMLBL11121";
                    BIRIMLBL11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIMLBL11121.TextFont.Name = "Arial Narrow";
                    BIRIMLBL11121.TextFont.Bold = true;
                    BIRIMLBL11121.Value = @"-";

                    KURULUSADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 20, 158, 40, false);
                    KURULUSADI.Name = "KURULUSADI";
                    KURULUSADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURULUSADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURULUSADI.NoClip = EvetHayirEnum.ehEvet;
                    KURULUSADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURULUSADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURULUSADI.TextFont.Name = "Arial Narrow";
                    KURULUSADI.Value = @"";

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 19, 159, 48, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 41, 203, 41, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    LBL_ADSOYADI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 42, 158, 47, false);
                    LBL_ADSOYADI11.Name = "LBL_ADSOYADI11";
                    LBL_ADSOYADI11.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI11.TextFont.Size = 9;
                    LBL_ADSOYADI11.TextFont.Bold = true;
                    LBL_ADSOYADI11.Value = @"Adı";

                    LBL_ADSOYADI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 42, 178, 47, false);
                    LBL_ADSOYADI12.Name = "LBL_ADSOYADI12";
                    LBL_ADSOYADI12.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI12.TextFont.Size = 9;
                    LBL_ADSOYADI12.TextFont.Bold = true;
                    LBL_ADSOYADI12.Value = @"Dönem";

                    LBL_ADSOYADI13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 42, 202, 47, false);
                    LBL_ADSOYADI13.Name = "LBL_ADSOYADI13";
                    LBL_ADSOYADI13.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI13.TextFont.Size = 9;
                    LBL_ADSOYADI13.TextFont.Bold = true;
                    LBL_ADSOYADI13.Value = @"Tutar";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 41, 179, 48, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 48, 203, 48, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 41, 40, 48, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 19, 203, 19, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 203, 11, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_ADSOYADI1.CalcValue = LBL_ADSOYADI1.Value;
                    BIRIMLBL1.CalcValue = BIRIMLBL1.Value;
                    REPORTHEADER11111.CalcValue = REPORTHEADER11111.Value;
                    BIRIMLBL11.CalcValue = BIRIMLBL11.Value;
                    BIRIMLBL12.CalcValue = BIRIMLBL12.Value;
                    BIRIMLBL13.CalcValue = BIRIMLBL13.Value;
                    BIRIMLBL111.CalcValue = BIRIMLBL111.Value;
                    BIRIMLBL1111.CalcValue = BIRIMLBL1111.Value;
                    BIRIMLBL1211.CalcValue = BIRIMLBL1211.Value;
                    KURULUSID.CalcValue = @"";
                    DONEM.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    TARIH1.CalcValue = @"";
                    TARIH2.CalcValue = @"";
                    BIRIMLBL11121.CalcValue = BIRIMLBL11121.Value;
                    KURULUSADI.CalcValue = @"";
                    LBL_ADSOYADI11.CalcValue = LBL_ADSOYADI11.Value;
                    LBL_ADSOYADI12.CalcValue = LBL_ADSOYADI12.Value;
                    LBL_ADSOYADI13.CalcValue = LBL_ADSOYADI13.Value;
                    return new TTReportObject[] { LBL_ADSOYADI1,BIRIMLBL1,REPORTHEADER11111,BIRIMLBL11,BIRIMLBL12,BIRIMLBL13,BIRIMLBL111,BIRIMLBL1111,BIRIMLBL1211,KURULUSID,DONEM,TARIH1,TARIH2,BIRIMLBL11121,KURULUSADI,LBL_ADSOYADI11,LBL_ADSOYADI12,LBL_ADSOYADI13};
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
                public GiderRaporu MyParentReport
                {
                    get { return (GiderRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine12;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine141;
                public TTReportShape NewLine161; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 203, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbInsideSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, -1, 8, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, -1, 40, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, -1, 159, 1, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, -1, 179, 1, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, -1, 203, 1, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

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
            public GiderRaporu MyParentReport
            {
                get { return (GiderRaporu)ParentReport; }
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
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
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
                list[0] = new TTReportNqlData<AccountVoucher.GetAccountVoucherIsDept_Class>("GetAccountVoucherIsDept", AccountVoucher.GetAccountVoucherIsDept((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.MONTH),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.YEAR)));
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
                public GiderRaporu MyParentReport
                {
                    get { return (GiderRaporu)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField MONTH;
                public TTReportField YEAR;
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DONEM;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine12; 
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

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 0, 203, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 0, 179, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 159, 0, 159, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 0, 40, 5, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine141.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 203, 0, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountVoucher.GetAccountVoucherIsDept_Class dataset_GetAccountVoucherIsDept = ParentGroup.rsGroup.GetCurrentRecord<AccountVoucher.GetAccountVoucherIsDept_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_GetAccountVoucherIsDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherIsDept.TotalPrice) : "");
                    MONTH.CalcValue = (dataset_GetAccountVoucherIsDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherIsDept.Month) : "");
                    MONTH.PostFieldValueCalculation();
                    YEAR.CalcValue = (dataset_GetAccountVoucherIsDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherIsDept.Year) : "");
                    CODE.CalcValue = (dataset_GetAccountVoucherIsDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherIsDept.Code) : "");
                    DESCRIPTION.CalcValue = (dataset_GetAccountVoucherIsDept != null ? Globals.ToStringCore(dataset_GetAccountVoucherIsDept.Description) : "");
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

        public GiderRaporu()
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
            Name = "GIDERRAPORU";
            Caption = "Gider Raporu";
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