
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
    /// Tıbbi Genetik Materyal Bilgi Etiketi
    /// </summary>
    public partial class GeneticMaterialRequestInfoSticker : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public GeneticMaterialRequestInfoSticker MyParentReport
            {
                get { return (GeneticMaterialRequestInfoSticker)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DogumTarihi { get {return Body().DogumTarihi;} }
            public TTReportField HastaninDogumTarihi1 { get {return Body().HastaninDogumTarihi1;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField AdSoyad1 { get {return Body().AdSoyad1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111221 { get {return Body().NewField111221;} }
            public TTReportField OrneklNo { get {return Body().OrneklNo;} }
            public TTReportField Adi { get {return Body().Adi;} }
            public TTReportField Soyadi { get {return Body().Soyadi;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField NewField121221 { get {return Body().NewField121221;} }
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
                list[0] = new TTReportNqlData<Genetic.GeneticSampleReportQuery_Class>("GeneticSampleReportQuery", Genetic.GeneticSampleReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public GeneticMaterialRequestInfoSticker MyParentReport
                {
                    get { return (GeneticMaterialRequestInfoSticker)ParentReport; }
                }
                
                public TTReportField DogumTarihi;
                public TTReportField HastaninDogumTarihi1;
                public TTReportField NewField12211;
                public TTReportField AdSoyad1;
                public TTReportField NewField11;
                public TTReportField NewField111221;
                public TTReportField OrneklNo;
                public TTReportField Adi;
                public TTReportField Soyadi;
                public TTReportField ADSOYAD;
                public TTReportField NewField121221; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    DogumTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 11, 64, 16, false);
                    DogumTarihi.Name = "DogumTarihi";
                    DogumTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    DogumTarihi.TextFormat = @"Short Date";
                    DogumTarihi.ObjectDefName = "GENETIC";
                    DogumTarihi.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DogumTarihi.TextFont.Name = "Arial";
                    DogumTarihi.TextFont.Size = 9;
                    DogumTarihi.TextFont.CharSet = 162;
                    DogumTarihi.Value = @"{@TTOBJECTID@}";

                    HastaninDogumTarihi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 11, 32, 16, false);
                    HastaninDogumTarihi1.Name = "HastaninDogumTarihi1";
                    HastaninDogumTarihi1.TextFont.Name = "Arial";
                    HastaninDogumTarihi1.TextFont.Size = 9;
                    HastaninDogumTarihi1.TextFont.Bold = true;
                    HastaninDogumTarihi1.TextFont.CharSet = 162;
                    HastaninDogumTarihi1.Value = @"Doğum Tarihi";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 11, 34, 16, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Name = "Arial";
                    NewField12211.TextFont.Size = 9;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @":";

                    AdSoyad1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 32, 11, false);
                    AdSoyad1.Name = "AdSoyad1";
                    AdSoyad1.TextFont.Name = "Arial";
                    AdSoyad1.TextFont.Size = 9;
                    AdSoyad1.TextFont.Bold = true;
                    AdSoyad1.TextFont.CharSet = 162;
                    AdSoyad1.Value = @"Adı Soyadı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 16, 32, 21, false);
                    NewField11.Name = "NewField11";
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Örnek No";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 6, 34, 11, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 9;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @":";

                    OrneklNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 16, 64, 21, false);
                    OrneklNo.Name = "OrneklNo";
                    OrneklNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrneklNo.TextFormat = @"Short Date";
                    OrneklNo.TextFont.Name = "Arial";
                    OrneklNo.TextFont.Size = 9;
                    OrneklNo.TextFont.CharSet = 162;
                    OrneklNo.Value = @"{#GENETICSAMPLENO#}";

                    Adi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 9, 147, 14, false);
                    Adi.Name = "Adi";
                    Adi.Visible = EvetHayirEnum.ehHayir;
                    Adi.FieldType = ReportFieldTypeEnum.ftVariable;
                    Adi.TextFormat = @"Short Date";
                    Adi.ObjectDefName = "GENETIC";
                    Adi.DataMember = "EPISODE.PATIENT.NAME";
                    Adi.TextFont.Name = "Arial";
                    Adi.TextFont.Size = 9;
                    Adi.TextFont.CharSet = 162;
                    Adi.Value = @"{@TTOBJECTID@}";

                    Soyadi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 15, 147, 20, false);
                    Soyadi.Name = "Soyadi";
                    Soyadi.Visible = EvetHayirEnum.ehHayir;
                    Soyadi.FieldType = ReportFieldTypeEnum.ftVariable;
                    Soyadi.TextFormat = @"Short Date";
                    Soyadi.ObjectDefName = "GENETIC";
                    Soyadi.DataMember = "EPISODE.PATIENT.SURNAME";
                    Soyadi.TextFont.Name = "Arial";
                    Soyadi.TextFont.Size = 9;
                    Soyadi.TextFont.CharSet = 162;
                    Soyadi.Value = @"{@TTOBJECTID@}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 6, 64, 11, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.Value = @"{%Adi%} {%Soyadi%}";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 16, 34, 21, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.TextFont.Name = "Arial";
                    NewField121221.TextFont.Size = 9;
                    NewField121221.TextFont.Bold = true;
                    NewField121221.TextFont.CharSet = 162;
                    NewField121221.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Genetic.GeneticSampleReportQuery_Class dataset_GeneticSampleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Genetic.GeneticSampleReportQuery_Class>(0);
                    DogumTarihi.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DogumTarihi.PostFieldValueCalculation();
                    HastaninDogumTarihi1.CalcValue = HastaninDogumTarihi1.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    AdSoyad1.CalcValue = AdSoyad1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    OrneklNo.CalcValue = (dataset_GeneticSampleReportQuery != null ? Globals.ToStringCore(dataset_GeneticSampleReportQuery.GeneticSampleNo) : "");
                    Adi.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    Adi.PostFieldValueCalculation();
                    Soyadi.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    Soyadi.PostFieldValueCalculation();
                    ADSOYAD.CalcValue = MyParentReport.MAIN.Adi.FormattedValue + @" " + MyParentReport.MAIN.Soyadi.FormattedValue;
                    NewField121221.CalcValue = NewField121221.Value;
                    return new TTReportObject[] { DogumTarihi,HastaninDogumTarihi1,NewField12211,AdSoyad1,NewField11,NewField111221,OrneklNo,Adi,Soyadi,ADSOYAD,NewField121221};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GeneticMaterialRequestInfoSticker()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "GENETICMATERIALREQUESTINFOSTICKER";
            Caption = "Tıbbi Genetik Materyal Bilgi Etiketi";
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