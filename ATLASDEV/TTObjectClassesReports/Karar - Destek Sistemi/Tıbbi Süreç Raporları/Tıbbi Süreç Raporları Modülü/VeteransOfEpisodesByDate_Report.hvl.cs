
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
    public partial class VeteransOfEpisodesByDate : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTOPENINGDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDOPENINGDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public VeteransOfEpisodesByDate MyParentReport
            {
                get { return (VeteransOfEpisodesByDate)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField AcilisTarihi { get {return Header().AcilisTarihi;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField AcilisTarihi1 { get {return Header().AcilisTarihi1;} }
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
                public VeteransOfEpisodesByDate MyParentReport
                {
                    get { return (VeteransOfEpisodesByDate)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1;
                public TTReportField AcilisTarihi;
                public TTReportField NewField2;
                public TTReportField AcilisTarihi1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 201, 30, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 35, 140, 40, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GAZİ HİZMET BİLGİLERİ";

                    AcilisTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 43, 53, 48, false);
                    AcilisTarihi.Name = "AcilisTarihi";
                    AcilisTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    AcilisTarihi.TextFormat = @"dd/MM/yyyy";
                    AcilisTarihi.Value = @"{@STARTOPENINGDATE@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 43, 34, 48, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Başlangıç Tarihi : ";

                    AcilisTarihi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 43, 75, 48, false);
                    AcilisTarihi1.Name = "AcilisTarihi1";
                    AcilisTarihi1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AcilisTarihi1.TextFormat = @"dd/MM/yyyy";
                    AcilisTarihi1.Value = @" {@ENDOPENINGDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    AcilisTarihi.CalcValue = MyParentReport.RuntimeParameters.STARTOPENINGDATE.ToString();
                    NewField2.CalcValue = NewField2.Value;
                    AcilisTarihi1.CalcValue = @" " + MyParentReport.RuntimeParameters.ENDOPENINGDATE.ToString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,AcilisTarihi,NewField2,AcilisTarihi1,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public VeteransOfEpisodesByDate MyParentReport
                {
                    get { return (VeteransOfEpisodesByDate)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public VeteransOfEpisodesByDate MyParentReport
            {
                get { return (VeteransOfEpisodesByDate)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine112 { get {return Footer().NewLine112;} }
            public TTReportShape NewLine113 { get {return Footer().NewLine113;} }
            public TTReportShape NewLine114 { get {return Footer().NewLine114;} }
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
                public VeteransOfEpisodesByDate MyParentReport
                {
                    get { return (VeteransOfEpisodesByDate)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 45, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TC Kimlik No";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 3, 97, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Adı Soyadı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 3, 149, 10, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Başvurduğu Bölüm";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 3, 201, 10, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Başvurduğu Tarih";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField121};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public VeteransOfEpisodesByDate MyParentReport
                {
                    get { return (VeteransOfEpisodesByDate)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine112;
                public TTReportShape NewLine113;
                public TTReportShape NewLine114; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 4, 201, 4, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, -6, 9, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, -6, 45, 4, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 97, -6, 97, 4, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, -6, 149, 4, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, -6, 201, 4, false);
                    NewLine114.Name = "NewLine114";
                    NewLine114.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public VeteransOfEpisodesByDate MyParentReport
            {
                get { return (VeteransOfEpisodesByDate)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField KimlikNo { get {return Body().KimlikNo;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField AdiSoyadi { get {return Body().AdiSoyadi;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine1112 { get {return Body().NewLine1112;} }
            public TTReportShape NewLine1113 { get {return Body().NewLine1113;} }
            public TTReportField Bolum { get {return Body().Bolum;} }
            public TTReportField Tarih { get {return Body().Tarih;} }
            public TTReportField TCNo { get {return Body().TCNo;} }
            public TTReportField YabanciKimlikNo { get {return Body().YabanciKimlikNo;} }
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
                list[0] = new TTReportNqlData<Episode.GetVeteransOfEpisodesByDate_Class>("GetVeteransOfEpisodesByDate", Episode.GetVeteransOfEpisodesByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTOPENINGDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDOPENINGDATE)));
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
                public VeteransOfEpisodesByDate MyParentReport
                {
                    get { return (VeteransOfEpisodesByDate)ParentReport; }
                }
                
                public TTReportField KimlikNo;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField AdiSoyadi;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine1113;
                public TTReportField Bolum;
                public TTReportField Tarih;
                public TTReportField TCNo;
                public TTReportField YabanciKimlikNo; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    KimlikNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 44, 7, false);
                    KimlikNo.Name = "KimlikNo";
                    KimlikNo.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 0, 201, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 0, 9, 8, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, 0, 45, 8, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    AdiSoyadi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 96, 7, false);
                    AdiSoyadi.Name = "AdiSoyadi";
                    AdiSoyadi.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdiSoyadi.Value = @"{#NAME#} {#SURNAME#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 97, 0, 97, 8, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 0, 201, 8, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 0, 149, 8, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;

                    Bolum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 148, 7, false);
                    Bolum.Name = "Bolum";
                    Bolum.FieldType = ReportFieldTypeEnum.ftVariable;
                    Bolum.ObjectDefName = "SpecialityDefinition";
                    Bolum.DataMember = "NAME";
                    Bolum.Value = @"{#MAINSPECIALITY#}";

                    Tarih = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 1, 200, 7, false);
                    Tarih.Name = "Tarih";
                    Tarih.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tarih.TextFormat = @"dd/MM/yyyy";
                    Tarih.Value = @"{#OPENINGDATE#}";

                    TCNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 2, 244, 7, false);
                    TCNo.Name = "TCNo";
                    TCNo.Visible = EvetHayirEnum.ehHayir;
                    TCNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNo.Value = @"{#UNIQUEREFNO#}";

                    YabanciKimlikNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 1, 275, 6, false);
                    YabanciKimlikNo.Name = "YabanciKimlikNo";
                    YabanciKimlikNo.Visible = EvetHayirEnum.ehHayir;
                    YabanciKimlikNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    YabanciKimlikNo.Value = @"{#FOREIGNUNIQUEREFNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Episode.GetVeteransOfEpisodesByDate_Class dataset_GetVeteransOfEpisodesByDate = ParentGroup.rsGroup.GetCurrentRecord<Episode.GetVeteransOfEpisodesByDate_Class>(0);
                    KimlikNo.CalcValue = KimlikNo.Value;
                    AdiSoyadi.CalcValue = (dataset_GetVeteransOfEpisodesByDate != null ? Globals.ToStringCore(dataset_GetVeteransOfEpisodesByDate.Name) : "") + @" " + (dataset_GetVeteransOfEpisodesByDate != null ? Globals.ToStringCore(dataset_GetVeteransOfEpisodesByDate.Surname) : "");
                    Bolum.CalcValue = (dataset_GetVeteransOfEpisodesByDate != null ? Globals.ToStringCore(dataset_GetVeteransOfEpisodesByDate.MainSpeciality) : "");
                    Bolum.PostFieldValueCalculation();
                    Tarih.CalcValue = (dataset_GetVeteransOfEpisodesByDate != null ? Globals.ToStringCore(dataset_GetVeteransOfEpisodesByDate.OpeningDate) : "");
                    TCNo.CalcValue = (dataset_GetVeteransOfEpisodesByDate != null ? Globals.ToStringCore(dataset_GetVeteransOfEpisodesByDate.UniqueRefNo) : "");
                    YabanciKimlikNo.CalcValue = (dataset_GetVeteransOfEpisodesByDate != null ? Globals.ToStringCore(dataset_GetVeteransOfEpisodesByDate.ForeignUniqueRefNo) : "");
                    return new TTReportObject[] { KimlikNo,AdiSoyadi,Bolum,Tarih,TCNo,YabanciKimlikNo};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.TCNo.CalcValue != "")
                this.KimlikNo.CalcValue = this.TCNo.CalcValue;
            else if(this.YabanciKimlikNo.CalcValue != "")
                this.KimlikNo.CalcValue = " * " + this.YabanciKimlikNo.CalcValue;
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

        public VeteransOfEpisodesByDate()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTOPENINGDATE", "", "Vaka Açılış Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDOPENINGDATE", "", "Vaka Açılışi Bitiş Tarih", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTOPENINGDATE"))
                _runtimeParameters.STARTOPENINGDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTOPENINGDATE"]);
            if (parameters.ContainsKey("ENDOPENINGDATE"))
                _runtimeParameters.ENDOPENINGDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDOPENINGDATE"]);
            Name = "VETERANSOFEPISODESBYDATE";
            Caption = "Gazi Hizmet Raporu";
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