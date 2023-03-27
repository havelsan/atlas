
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
    /// Devire Göre Stok Kartları Listesi
    /// </summary>
    public partial class DevireGoreStokKartlari : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? CARDDRAWERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public StockCardStatusEnum? STATUS = (StockCardStatusEnum?)(int?)TTObjectDefManager.Instance.DataTypes["StockCardStatusEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DevireGoreStokKartlari MyParentReport
            {
                get { return (DevireGoreStokKartlari)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField122111 { get {return Header().NewField122111;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField STATUS { get {return Header().STATUS;} }
            public TTReportField NewField1111221 { get {return Header().NewField1111221;} }
            public TTReportField NewField112112 { get {return Header().NewField112112;} }
            public TTReportField CARDDRAWER { get {return Header().CARDDRAWER;} }
            public TTReportField NewField11221111 { get {return Header().NewField11221111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                public DevireGoreStokKartlari MyParentReport
                {
                    get { return (DevireGoreStokKartlari)ParentReport; }
                }
                
                public TTReportField NewField11121;
                public TTReportField NewField112111;
                public TTReportField NewField122111;
                public TTReportField ReportName1;
                public TTReportField STATUS;
                public TTReportField NewField1111221;
                public TTReportField NewField112112;
                public TTReportField CARDDRAWER;
                public TTReportField NewField11221111;
                public TTReportShape NewLine1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 40, 26, 45, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Yeni S.N.";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 40, 68, 45, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"NATO Stok Nu.";

                    NewField122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 40, 180, 45, false);
                    NewField122111.Name = "NewField122111";
                    NewField122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122111.TextFont.Name = "Arial";
                    NewField122111.TextFont.Bold = true;
                    NewField122111.TextFont.CharSet = 162;
                    NewField122111.Value = @"Stok Kartı İsmi";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 4, 180, 15, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Size = 12;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"DEVİRE GÖRE STOK KARTLARI LİSTESİ";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 26, 180, 31, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.ObjectDefName = "StockCardStatusEnum";
                    STATUS.DataMember = "DisplayText";
                    STATUS.TextFont.Bold = true;
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"{@STATUS@}";

                    NewField1111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 26, 30, 31, false);
                    NewField1111221.Name = "NewField1111221";
                    NewField1111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111221.TextFont.Name = "Arial";
                    NewField1111221.TextFont.Bold = true;
                    NewField1111221.TextFont.CharSet = 162;
                    NewField1111221.Value = @"Kart Durumu :";

                    NewField112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 40, 41, 45, false);
                    NewField112112.Name = "NewField112112";
                    NewField112112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112112.TextFont.Name = "Arial";
                    NewField112112.TextFont.Bold = true;
                    NewField112112.TextFont.CharSet = 162;
                    NewField112112.Value = @"Eski S.N.";

                    CARDDRAWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 20, 180, 25, false);
                    CARDDRAWER.Name = "CARDDRAWER";
                    CARDDRAWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDDRAWER.ObjectDefName = "ResCardDrawer";
                    CARDDRAWER.DataMember = "NAME";
                    CARDDRAWER.TextFont.Bold = true;
                    CARDDRAWER.TextFont.CharSet = 162;
                    CARDDRAWER.Value = @"{@CARDDRAWERID@}";

                    NewField11221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 20, 30, 25, false);
                    NewField11221111.Name = "NewField11221111";
                    NewField11221111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221111.TextFont.Name = "Arial";
                    NewField11221111.TextFont.Bold = true;
                    NewField11221111.TextFont.CharSet = 162;
                    NewField11221111.Value = @"Masa Adı :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 46, 181, 46, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 3;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField122111.CalcValue = NewField122111.Value;
                    ReportName1.CalcValue = ReportName1.Value;
                    STATUS.CalcValue = MyParentReport.RuntimeParameters.STATUS.ToString();
                    STATUS.PostFieldValueCalculation();
                    NewField1111221.CalcValue = NewField1111221.Value;
                    NewField112112.CalcValue = NewField112112.Value;
                    CARDDRAWER.CalcValue = MyParentReport.RuntimeParameters.CARDDRAWERID.ToString();
                    CARDDRAWER.PostFieldValueCalculation();
                    NewField11221111.CalcValue = NewField11221111.Value;
                    return new TTReportObject[] { NewField11121,NewField112111,NewField122111,ReportName1,STATUS,NewField1111221,NewField112112,CARDDRAWER,NewField11221111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DevireGoreStokKartlari MyParentReport
                {
                    get { return (DevireGoreStokKartlari)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public DevireGoreStokKartlari MyParentReport
            {
                get { return (DevireGoreStokKartlari)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STOCKCARD { get {return Body().STOCKCARD;} }
            public TTReportField OLDCARDORDERNO { get {return Body().OLDCARDORDERNO;} }
            public TTReportField CARDORDERNO { get {return Body().CARDORDERNO;} }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
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
                list[0] = new TTReportNqlData<StockCensusDetail.GetStockCencusByStockcardStatus_Class>("GetStockCencusByStockcardStatus", StockCensusDetail.GetStockCencusByStockcardStatus((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),((StockCardStatusEnum)TTObjectDefManager.Instance.DataTypes["StockCardStatusEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.STATUS.ToString()].EnumValue),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWERID)));
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
                public DevireGoreStokKartlari MyParentReport
                {
                    get { return (DevireGoreStokKartlari)ParentReport; }
                }
                
                public TTReportField STOCKCARD;
                public TTReportField OLDCARDORDERNO;
                public TTReportField CARDORDERNO;
                public TTReportField STOCKCARDNAME;
                public TTReportField COUNTER; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    STOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 68, 6, false);
                    STOCKCARD.Name = "STOCKCARD";
                    STOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARD.ObjectDefName = "StockCard";
                    STOCKCARD.DataMember = "NATOSTOCKNO";
                    STOCKCARD.Value = @"{#STOCKCARD#}";

                    OLDCARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 41, 6, false);
                    OLDCARDORDERNO.Name = "OLDCARDORDERNO";
                    OLDCARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDCARDORDERNO.Value = @"{#OLDCARDORDERNO#}";

                    CARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 26, 6, false);
                    CARDORDERNO.Name = "CARDORDERNO";
                    CARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDORDERNO.Value = @"{#CARDORDERNO#}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 1, 180, 6, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.ObjectDefName = "StockCard";
                    STOCKCARDNAME.DataMember = "NAME";
                    STOCKCARDNAME.Value = @"{#STOCKCARD#}";

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 8, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensusDetail.GetStockCencusByStockcardStatus_Class dataset_GetStockCencusByStockcardStatus = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetStockCencusByStockcardStatus_Class>(0);
                    STOCKCARD.CalcValue = (dataset_GetStockCencusByStockcardStatus != null ? Globals.ToStringCore(dataset_GetStockCencusByStockcardStatus.StockCard) : "");
                    STOCKCARD.PostFieldValueCalculation();
                    OLDCARDORDERNO.CalcValue = (dataset_GetStockCencusByStockcardStatus != null ? Globals.ToStringCore(dataset_GetStockCencusByStockcardStatus.OldCardOrderNo) : "");
                    CARDORDERNO.CalcValue = (dataset_GetStockCencusByStockcardStatus != null ? Globals.ToStringCore(dataset_GetStockCencusByStockcardStatus.CardOrderNo) : "");
                    STOCKCARDNAME.CalcValue = (dataset_GetStockCencusByStockcardStatus != null ? Globals.ToStringCore(dataset_GetStockCencusByStockcardStatus.StockCard) : "");
                    STOCKCARDNAME.PostFieldValueCalculation();
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { STOCKCARD,OLDCARDORDERNO,CARDORDERNO,STOCKCARDNAME,COUNTER};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DevireGoreStokKartlari()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Devir Yapılan Dönemi Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Devir Yapılan Depoyu Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("CARDDRAWERID", "00000000-0000-0000-0000-000000000000", "Devir Yapılan Masayı Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
            reportParameter = Parameters.Add("STATUS", "", "Kart Durumunu Seçiniz", @"", true, true, false, new Guid("a4b05482-f11e-4094-80bd-ef386b82e3e3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("CARDDRAWERID"))
                _runtimeParameters.CARDDRAWERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CARDDRAWERID"]);
            if (parameters.ContainsKey("STATUS"))
                _runtimeParameters.STATUS = (StockCardStatusEnum?)(int?)TTObjectDefManager.Instance.DataTypes["StockCardStatusEnum"].ConvertValue(parameters["STATUS"]);
            Name = "DEVIREGORESTOKKARTLARI";
            Caption = "Devire Göre Stok Kartları Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 15;
            UserMarginTop = 15;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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