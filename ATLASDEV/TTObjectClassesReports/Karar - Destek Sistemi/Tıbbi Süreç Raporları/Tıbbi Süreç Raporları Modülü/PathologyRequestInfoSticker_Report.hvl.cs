
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
    /// Patoloji Tetkik İstek Bilgi Etiketi
    /// </summary>
    public partial class PathologyRequestInfoSticker : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyRequestInfoSticker MyParentReport
            {
                get { return (PathologyRequestInfoSticker)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Yas { get {return Body().Yas;} }
            public TTReportField DogumTarihi { get {return Body().DogumTarihi;} }
            public TTReportField HastanınYasi { get {return Body().HastanınYasi;} }
            public TTReportField HastaninDogumTarihi { get {return Body().HastaninDogumTarihi;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1122 { get {return Body().NewField1122;} }
            public TTReportField AdSoyad { get {return Body().AdSoyad;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField12212 { get {return Body().NewField12212;} }
            public TTReportField MateryalProtokolNo { get {return Body().MateryalProtokolNo;} }
            public TTReportField AdiSoyadi { get {return Body().AdiSoyadi;} }
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
                list[0] = new TTReportNqlData<Pathology.PathologyTestRequestInfoStickerNQL_Class>("PathologyTestRequestInfoStickerNQL", Pathology.PathologyTestRequestInfoStickerNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyRequestInfoSticker MyParentReport
                {
                    get { return (PathologyRequestInfoSticker)ParentReport; }
                }
                
                public TTReportField Yas;
                public TTReportField DogumTarihi;
                public TTReportField HastanınYasi;
                public TTReportField HastaninDogumTarihi;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField AdSoyad;
                public TTReportField NewField1;
                public TTReportField NewField12211;
                public TTReportField NewField12212;
                public TTReportField MateryalProtokolNo;
                public TTReportField AdiSoyadi; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 27;
                    RepeatCount = 0;
                    
                    Yas = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 16, 79, 21, false);
                    Yas.Name = "Yas";
                    Yas.TextFont.Name = "Arial";
                    Yas.TextFont.Size = 9;
                    Yas.TextFont.CharSet = 162;
                    Yas.Value = @"";

                    DogumTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 21, 79, 26, false);
                    DogumTarihi.Name = "DogumTarihi";
                    DogumTarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    DogumTarihi.TextFormat = @"Short Date";
                    DogumTarihi.TextFont.Name = "Arial";
                    DogumTarihi.TextFont.Size = 9;
                    DogumTarihi.TextFont.CharSet = 162;
                    DogumTarihi.Value = @"{#BIRTHDATE#}";

                    HastanınYasi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 16, 47, 21, false);
                    HastanınYasi.Name = "HastanınYasi";
                    HastanınYasi.TextFont.Name = "Arial";
                    HastanınYasi.TextFont.Size = 9;
                    HastanınYasi.TextFont.Bold = true;
                    HastanınYasi.TextFont.CharSet = 162;
                    HastanınYasi.Value = @"Yaşı";

                    HastaninDogumTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 21, 47, 26, false);
                    HastaninDogumTarihi.Name = "HastaninDogumTarihi";
                    HastaninDogumTarihi.TextFont.Name = "Arial";
                    HastaninDogumTarihi.TextFont.Size = 9;
                    HastaninDogumTarihi.TextFont.Bold = true;
                    HastaninDogumTarihi.TextFont.CharSet = 162;
                    HastaninDogumTarihi.Value = @"Doğum Tarihi";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 16, 49, 21, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 21, 49, 26, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Size = 9;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @":";

                    AdSoyad = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 11, 47, 16, false);
                    AdSoyad.Name = "AdSoyad";
                    AdSoyad.TextFont.Name = "Arial";
                    AdSoyad.TextFont.Size = 9;
                    AdSoyad.TextFont.Bold = true;
                    AdSoyad.TextFont.CharSet = 162;
                    AdSoyad.Value = @"Adı Soyadı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 11, 112, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Materyal Protokol No";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 11, 49, 16, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Name = "Arial";
                    NewField12211.TextFont.Size = 9;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @":";

                    NewField12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 14, 114, 25, false);
                    NewField12212.Name = "NewField12212";
                    NewField12212.TextFont.Name = "Arial";
                    NewField12212.TextFont.Size = 18;
                    NewField12212.TextFont.Bold = true;
                    NewField12212.TextFont.CharSet = 162;
                    NewField12212.Value = @"


:";

                    MateryalProtokolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 14, 153, 22, false);
                    MateryalProtokolNo.Name = "MateryalProtokolNo";
                    MateryalProtokolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    MateryalProtokolNo.TextFormat = @"Short Date";
                    MateryalProtokolNo.TextFont.Name = "Arial";
                    MateryalProtokolNo.TextFont.Size = 18;
                    MateryalProtokolNo.TextFont.CharSet = 162;
                    MateryalProtokolNo.Value = @"{#MATPRTNO#}";

                    AdiSoyadi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 11, 79, 16, false);
                    AdiSoyadi.Name = "AdiSoyadi";
                    AdiSoyadi.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdiSoyadi.TextFormat = @"Short Date";
                    AdiSoyadi.TextFont.Name = "Arial";
                    AdiSoyadi.TextFont.Size = 9;
                    AdiSoyadi.TextFont.CharSet = 162;
                    AdiSoyadi.Value = @"{#NAME#} {#SURNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Pathology.PathologyTestRequestInfoStickerNQL_Class dataset_PathologyTestRequestInfoStickerNQL = ParentGroup.rsGroup.GetCurrentRecord<Pathology.PathologyTestRequestInfoStickerNQL_Class>(0);
                    Yas.CalcValue = Yas.Value;
                    DogumTarihi.CalcValue = (dataset_PathologyTestRequestInfoStickerNQL != null ? Globals.ToStringCore(dataset_PathologyTestRequestInfoStickerNQL.BirthDate) : "");
                    HastanınYasi.CalcValue = HastanınYasi.Value;
                    HastaninDogumTarihi.CalcValue = HastaninDogumTarihi.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    AdSoyad.CalcValue = AdSoyad.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField12212.CalcValue = NewField12212.Value;
                    MateryalProtokolNo.CalcValue = (dataset_PathologyTestRequestInfoStickerNQL != null ? Globals.ToStringCore(dataset_PathologyTestRequestInfoStickerNQL.Matprtno) : "");
                    AdiSoyadi.CalcValue = (dataset_PathologyTestRequestInfoStickerNQL != null ? Globals.ToStringCore(dataset_PathologyTestRequestInfoStickerNQL.Name) : "") + @" " + (dataset_PathologyTestRequestInfoStickerNQL != null ? Globals.ToStringCore(dataset_PathologyTestRequestInfoStickerNQL.Surname) : "");
                    return new TTReportObject[] { Yas,DogumTarihi,HastanınYasi,HastaninDogumTarihi,NewField1121,NewField1122,AdSoyad,NewField1,NewField12211,NewField12212,MateryalProtokolNo,AdiSoyadi};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);    
            string sObjectID = ((PathologyRequestInfoSticker)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            //string sObjectID = this.NewField4.CalcValue;            
            Pathology pObject = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            this.Yas.CalcValue = pObject.Episode.Patient.Age.ToString();
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

        public PathologyRequestInfoSticker()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Episode Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYREQUESTINFOSTICKER";
            Caption = "Patoloji Tetkik İstek Bilgi Etiketi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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