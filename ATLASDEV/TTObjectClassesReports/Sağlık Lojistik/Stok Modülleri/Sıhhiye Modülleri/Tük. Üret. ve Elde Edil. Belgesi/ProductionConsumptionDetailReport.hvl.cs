
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi Detaylı
    /// </summary>
    public partial class ProductionConsumptionDetailReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ProductionConsumptionDetailReport MyParentReport
            {
                get { return (ProductionConsumptionDetailReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
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
                public ProductionConsumptionDetailReport MyParentReport
                {
                    get { return (ProductionConsumptionDetailReport)ParentReport; }
                }
                
                public TTReportField NewField111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 3, 292, 12, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"TÜKETİM, ÜRETİM ve ELDE EDİLENLER BELGESİ YEDEK PARÇA KULLANIM DETAYI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { NewField111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ProductionConsumptionDetailReport MyParentReport
                {
                    get { return (ProductionConsumptionDetailReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ProductionConsumptionDetailReport MyParentReport
            {
                get { return (ProductionConsumptionDetailReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField1111112 { get {return Header().NewField1111112;} }
            public TTReportField NewField12111111 { get {return Header().NewField12111111;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField111111111 { get {return Header().NewField111111111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
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
                public ProductionConsumptionDetailReport MyParentReport
                {
                    get { return (ProductionConsumptionDetailReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField1111111;
                public TTReportField NewField1111112;
                public TTReportField NewField12111111;
                public TTReportField NewField11111111;
                public TTReportField NewField111111111;
                public TTReportField NewField111111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 27, 8, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"S. Nu.";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 0, 77, 8, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Size = 11;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Onarım Nu.";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 117, 8, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111112.TextFont.Size = 11;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Yardımcı Atolye Nu.";

                    NewField12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 292, 8, false);
                    NewField12111111.Name = "NewField12111111";
                    NewField12111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12111111.TextFont.Size = 11;
                    NewField12111111.TextFont.Bold = true;
                    NewField12111111.TextFont.CharSet = 162;
                    NewField12111111.Value = @"Miktarı";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 156, 8, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111111.TextFont.Size = 11;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"Ambalajlama Nu.";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 277, 8, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111111.TextFont.Size = 11;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.TextFont.CharSet = 162;
                    NewField111111111.Value = @"Malzeme Adı";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 52, 8, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Sipariş Nu.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField12111111.CalcValue = NewField12111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField11111,NewField1111111,NewField1111112,NewField12111111,NewField11111111,NewField111111111,NewField111111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ProductionConsumptionDetailReport MyParentReport
                {
                    get { return (ProductionConsumptionDetailReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ProductionConsumptionDetailReport MyParentReport
            {
                get { return (ProductionConsumptionDetailReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField AMBALAJNO { get {return Body().AMBALAJNO;} }
            public TTReportField MIKTARI { get {return Body().MIKTARI;} }
            public TTReportField MALZEMEADI { get {return Body().MALZEMEADI;} }
            public TTReportField ATOLYENO { get {return Body().ATOLYENO;} }
            public TTReportField ONARIMNO { get {return Body().ONARIMNO;} }
            public TTReportField ONARIMNO1 { get {return Body().ONARIMNO1;} }
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
                list[0] = new TTReportNqlData<UsedConsumedMaterail.GetColletedCMRAction_Class>("GetColletedCMRAction", UsedConsumedMaterail.GetColletedCMRAction((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ProductionConsumptionDetailReport MyParentReport
                {
                    get { return (ProductionConsumptionDetailReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField AMBALAJNO;
                public TTReportField MIKTARI;
                public TTReportField MALZEMEADI;
                public TTReportField ATOLYENO;
                public TTReportField ONARIMNO;
                public TTReportField ONARIMNO1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 27, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@} ";

                    AMBALAJNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 156, 5, false);
                    AMBALAJNO.Name = "AMBALAJNO";
                    AMBALAJNO.DrawStyle = DrawStyleConstants.vbSolid;
                    AMBALAJNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMBALAJNO.TextFormat = @"#,##0.#0";
                    AMBALAJNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMBALAJNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMBALAJNO.TextFont.Size = 8;
                    AMBALAJNO.TextFont.CharSet = 162;
                    AMBALAJNO.Value = @"{#AMBALAJLAMA#}";

                    MIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 292, 5, false);
                    MIKTARI.Name = "MIKTARI";
                    MIKTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTARI.TextFont.Size = 8;
                    MIKTARI.TextFont.CharSet = 162;
                    MIKTARI.Value = @"{#AMOUNT#}";

                    MALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 277, 5, false);
                    MALZEMEADI.Name = "MALZEMEADI";
                    MALZEMEADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI.TextFormat = @"#,##0.00";
                    MALZEMEADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALZEMEADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI.TextFont.Size = 8;
                    MALZEMEADI.TextFont.CharSet = 162;
                    MALZEMEADI.Value = @"{#MALZEME_ADI#}";

                    ATOLYENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 117, 5, false);
                    ATOLYENO.Name = "ATOLYENO";
                    ATOLYENO.DrawStyle = DrawStyleConstants.vbSolid;
                    ATOLYENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATOLYENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATOLYENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATOLYENO.TextFont.Size = 8;
                    ATOLYENO.TextFont.CharSet = 162;
                    ATOLYENO.Value = @"{#YARDIMCIATOLYE#}";

                    ONARIMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 0, 77, 5, false);
                    ONARIMNO.Name = "ONARIMNO";
                    ONARIMNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ONARIMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONARIMNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONARIMNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONARIMNO.TextFont.Size = 8;
                    ONARIMNO.TextFont.CharSet = 162;
                    ONARIMNO.Value = @"{#ONARIM#}";

                    ONARIMNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 52, 5, false);
                    ONARIMNO1.Name = "ONARIMNO1";
                    ONARIMNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    ONARIMNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONARIMNO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONARIMNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONARIMNO1.TextFont.Size = 8;
                    ONARIMNO1.TextFont.CharSet = 162;
                    ONARIMNO1.Value = @"{#SIPARIS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UsedConsumedMaterail.GetColletedCMRAction_Class dataset_GetColletedCMRAction = ParentGroup.rsGroup.GetCurrentRecord<UsedConsumedMaterail.GetColletedCMRAction_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    AMBALAJNO.CalcValue = (dataset_GetColletedCMRAction != null ? Globals.ToStringCore(dataset_GetColletedCMRAction.Ambalajlama) : "");
                    MIKTARI.CalcValue = (dataset_GetColletedCMRAction != null ? Globals.ToStringCore(dataset_GetColletedCMRAction.Amount) : "");
                    MALZEMEADI.CalcValue = (dataset_GetColletedCMRAction != null ? Globals.ToStringCore(dataset_GetColletedCMRAction.Malzeme_adi) : "");
                    ATOLYENO.CalcValue = (dataset_GetColletedCMRAction != null ? Globals.ToStringCore(dataset_GetColletedCMRAction.Yardimciatolye) : "");
                    ONARIMNO.CalcValue = (dataset_GetColletedCMRAction != null ? Globals.ToStringCore(dataset_GetColletedCMRAction.Onarim) : "");
                    ONARIMNO1.CalcValue = (dataset_GetColletedCMRAction != null ? Globals.ToStringCore(dataset_GetColletedCMRAction.Siparis) : "");
                    return new TTReportObject[] { ORDERNO,AMBALAJNO,MIKTARI,MALZEMEADI,ATOLYENO,ONARIMNO,ONARIMNO1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ProductionConsumptionDetailReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PRODUCTIONCONSUMPTIONDETAILREPORT";
            Caption = "Tüketim, Üretim ve Elde Edilenler Belgesi Detaylı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 256;
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