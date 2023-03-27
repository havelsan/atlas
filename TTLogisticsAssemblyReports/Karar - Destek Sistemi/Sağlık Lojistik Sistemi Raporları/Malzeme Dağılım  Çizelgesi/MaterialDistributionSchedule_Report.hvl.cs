
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
    /// Malzeme Dağılım  Çizelgesi
    /// </summary>
    public partial class MaterialDistributionSchedule : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? ALL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialDistributionSchedule MyParentReport
            {
                get { return (MaterialDistributionSchedule)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField PrintDate111 { get {return Footer().PrintDate111;} }
            public TTReportField PageNumber111 { get {return Footer().PageNumber111;} }
            public TTReportField CurrentUser111 { get {return Footer().CurrentUser111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public MaterialDistributionSchedule MyParentReport
                {
                    get { return (MaterialDistributionSchedule)ParentReport; }
                }
                
                public TTReportField HOSPITALNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 8, 204, 23, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 11;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")+"" MALZEME DAĞITIM ÇİZELGESİ""";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")+" MALZEME DAĞITIM ÇİZELGESİ";
                    return new TTReportObject[] { HOSPITALNAME};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if(((MaterialDistributionSchedule)ParentReport).RuntimeParameters.MATERIAL == Guid.Empty)
            {
                ((MaterialDistributionSchedule)ParentReport).RuntimeParameters.ALL = 1;
            }
            else
            {
                ((MaterialDistributionSchedule)ParentReport).RuntimeParameters.ALL = 0;
            }
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialDistributionSchedule MyParentReport
                {
                    get { return (MaterialDistributionSchedule)ParentReport; }
                }
                
                public TTReportField PrintDate111;
                public TTReportField PageNumber111;
                public TTReportField CurrentUser111;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    PrintDate111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 32, 6, false);
                    PrintDate111.Name = "PrintDate111";
                    PrintDate111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate111.TextFont.Size = 8;
                    PrintDate111.TextFont.CharSet = 162;
                    PrintDate111.Value = @"{@printdate@}";

                    PageNumber111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 1, 205, 6, false);
                    PageNumber111.Name = "PageNumber111";
                    PageNumber111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber111.TextFont.Size = 8;
                    PageNumber111.TextFont.CharSet = 162;
                    PageNumber111.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 119, 6, false);
                    CurrentUser111.Name = "CurrentUser111";
                    CurrentUser111.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser111.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser111.TextFont.Size = 8;
                    CurrentUser111.TextFont.CharSet = 162;
                    CurrentUser111.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 205, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate111.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber111.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser111.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate111,PageNumber111,CurrentUser111};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialDistributionSchedule MyParentReport
            {
                get { return (MaterialDistributionSchedule)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField MATERIALTREENAME { get {return Header().MATERIALTREENAME;} }
            public TTReportField STOCKCARDNSN { get {return Header().STOCKCARDNSN;} }
            public TTReportField BARCODE { get {return Header().BARCODE;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Header().DISTRIBUTIONTYPE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Stock.GetMaterialDistributeReportQuery_Class>("GetMaterialDistributeReportQuery2", Stock.GetMaterialDistributeReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ALL)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public MaterialDistributionSchedule MyParentReport
                {
                    get { return (MaterialDistributionSchedule)ParentReport; }
                }
                
                public TTReportField MATERIALTREENAME;
                public TTReportField STOCKCARDNSN;
                public TTReportField BARCODE;
                public TTReportField NAME;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField7;
                public TTReportField NewField9; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 45;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MATERIALTREENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 13, 136, 18, false);
                    MATERIALTREENAME.Name = "MATERIALTREENAME";
                    MATERIALTREENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTREENAME.Value = @"{#MATERIALTREENAME#}";

                    STOCKCARDNSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 19, 136, 24, false);
                    STOCKCARDNSN.Name = "STOCKCARDNSN";
                    STOCKCARDNSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNSN.Value = @"{#STOCKCARDNSN#}";

                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 25, 136, 30, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.Value = @"{#BARCODE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 7, 136, 12, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 31, 136, 36, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 38, 12, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"MALZEMENİN ADI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 19, 38, 24, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"STOK NUMARASI";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 41, 30, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"BARKOD NUMARASI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 38, 36, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"ÖLÇÜ BİRİMİ";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 13, 38, 18, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"MASA BİLGİSİ";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 7, 42, 12, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 13, 42, 18, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 19, 42, 24, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 25, 42, 30, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 31, 42, 36, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 40, 169, 45, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"MALZEMENİN BULUNDUĞU DEPO";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 40, 198, 45, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"TOPLAM MİKTARI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetMaterialDistributeReportQuery_Class dataset_GetMaterialDistributeReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetMaterialDistributeReportQuery_Class>(0);
                    MATERIALTREENAME.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.Materialtreename) : "");
                    STOCKCARDNSN.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.Stockcardnsn) : "");
                    BARCODE.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.Barcode) : "");
                    NAME.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.Name) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.DistributionType) : "");
                    DISTRIBUTIONTYPE.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField9.CalcValue = NewField9.Value;
                    return new TTReportObject[] { MATERIALTREENAME,STOCKCARDNSN,BARCODE,NAME,DISTRIBUTIONTYPE,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,NewField16,NewField17,NewField18,NewField19,NewField7,NewField9};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialDistributionSchedule MyParentReport
                {
                    get { return (MaterialDistributionSchedule)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialDistributionSchedule MyParentReport
            {
                get { return (MaterialDistributionSchedule)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TOPLAMMIKTAR { get {return Body().TOPLAMMIKTAR;} }
            public TTReportField STORENAME { get {return Body().STORENAME;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Stock.GetMaterialDistributeReportQuery_Class dataSet_GetMaterialDistributeReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetMaterialDistributeReportQuery_Class>(0);    
                return new object[] {(dataSet_GetMaterialDistributeReportQuery2==null ? null : dataSet_GetMaterialDistributeReportQuery2.Name)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public MaterialDistributionSchedule MyParentReport
                {
                    get { return (MaterialDistributionSchedule)ParentReport; }
                }
                
                public TTReportField TOPLAMMIKTAR;
                public TTReportField STORENAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    TOPLAMMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 198, 5, false);
                    TOPLAMMIKTAR.Name = "TOPLAMMIKTAR";
                    TOPLAMMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMMIKTAR.Value = @"{#PARTB.TOPLAMMIKTAR#}";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 169, 5, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.Value = @"{#PARTB.STORENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetMaterialDistributeReportQuery_Class dataset_GetMaterialDistributeReportQuery2 = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Stock.GetMaterialDistributeReportQuery_Class>(0);
                    TOPLAMMIKTAR.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.Toplammiktar) : "");
                    STORENAME.CalcValue = (dataset_GetMaterialDistributeReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaterialDistributeReportQuery2.Storename) : "");
                    return new TTReportObject[] { TOPLAMMIKTAR,STORENAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialDistributionSchedule()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Malzeme", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
            reportParameter = Parameters.Add("ALL", "", "ALL", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            if (parameters.ContainsKey("ALL"))
                _runtimeParameters.ALL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ALL"]);
            Name = "MATERIALDISTRIBUTIONSCHEDULE";
            Caption = "Malzeme Dağılım  Çizelgesi";
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