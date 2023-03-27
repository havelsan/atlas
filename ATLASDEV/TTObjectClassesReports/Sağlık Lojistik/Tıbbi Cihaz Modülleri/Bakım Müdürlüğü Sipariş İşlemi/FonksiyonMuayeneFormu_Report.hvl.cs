
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
    /// Fonksiyon Muayenesi Formu (Ek-8.7)
    /// </summary>
    public partial class FonksiyonMuayeneFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public FonksiyonMuayeneFormu MyParentReport
            {
                get { return (FonksiyonMuayeneFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField MUAYENEACIKLAMALARI { get {return Body().MUAYENEACIKLAMALARI;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField ADI { get {return Body().ADI;} }
            public TTReportField MARKASI { get {return Body().MARKASI;} }
            public TTReportField MODELI { get {return Body().MODELI;} }
            public TTReportField SERINUMARASI { get {return Body().SERINUMARASI;} }
            public TTReportField AITOLDUGUBIRLIK { get {return Body().AITOLDUGUBIRLIK;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField GOREVYERI { get {return Body().GOREVYERI;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public FonksiyonMuayeneFormu MyParentReport
                {
                    get { return (FonksiyonMuayeneFormu)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField MUAYENEACIKLAMALARI;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField ADI;
                public TTReportField MARKASI;
                public TTReportField MODELI;
                public TTReportField SERINUMARASI;
                public TTReportField AITOLDUGUBIRLIK;
                public TTReportField ADISOYADI;
                public TTReportField SINIFRUTBE;
                public TTReportField GOREVYERI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 33, 195, 38, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"FONKSİYON MUAYENE FORMU";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 41, 195, 53, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"CİHAZA  AİT BİLGİLER";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 53, 66, 61, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @" ADI";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 61, 66, 69, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @" MARKASI";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 69, 66, 77, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @" MODELİ";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 77, 66, 85, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @" SERİ NUMARASI";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 85, 66, 93, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @" AİT OLDUĞU BİRLİK";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 93, 195, 105, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 11;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"MUAYENE İŞLEMİNE AİT AÇIKLAMALAR";

                    MUAYENEACIKLAMALARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 105, 195, 175, false);
                    MUAYENEACIKLAMALARI.Name = "MUAYENEACIKLAMALARI";
                    MUAYENEACIKLAMALARI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENEACIKLAMALARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEACIKLAMALARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUAYENEACIKLAMALARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENEACIKLAMALARI.TextFont.Name = "Arial";
                    MUAYENEACIKLAMALARI.TextFont.Size = 11;
                    MUAYENEACIKLAMALARI.TextFont.CharSet = 162;
                    MUAYENEACIKLAMALARI.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 175, 195, 187, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"MUAYENE İŞLEMİNİ YAPAN";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 187, 66, 197, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @" İMZA";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 197, 66, 207, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @" ADI SOYADI";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 207, 66, 217, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @" SINIFI VE RÜTBESI";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 217, 66, 227, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @" GÖREV YERİ";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 187, 195, 197, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 53, 195, 61, false);
                    ADI.Name = "ADI";
                    ADI.DrawStyle = DrawStyleConstants.vbSolid;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADI.TextFont.Name = "Arial";
                    ADI.TextFont.Size = 11;
                    ADI.TextFont.CharSet = 162;
                    ADI.Value = @"{#FIXEDASSETNAME#}";

                    MARKASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 61, 195, 69, false);
                    MARKASI.Name = "MARKASI";
                    MARKASI.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKASI.TextFont.Name = "Arial";
                    MARKASI.TextFont.Size = 11;
                    MARKASI.TextFont.CharSet = 162;
                    MARKASI.Value = @"{#MARK#}";

                    MODELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 69, 195, 77, false);
                    MODELI.Name = "MODELI";
                    MODELI.DrawStyle = DrawStyleConstants.vbSolid;
                    MODELI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MODELI.TextFont.Name = "Arial";
                    MODELI.TextFont.Size = 11;
                    MODELI.TextFont.CharSet = 162;
                    MODELI.Value = @"{#MODEL#}";

                    SERINUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 77, 195, 85, false);
                    SERINUMARASI.Name = "SERINUMARASI";
                    SERINUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    SERINUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERINUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERINUMARASI.TextFont.Name = "Arial";
                    SERINUMARASI.TextFont.Size = 11;
                    SERINUMARASI.TextFont.CharSet = 162;
                    SERINUMARASI.Value = @"{#SERIALNUMBER#}";

                    AITOLDUGUBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 85, 195, 93, false);
                    AITOLDUGUBIRLIK.Name = "AITOLDUGUBIRLIK";
                    AITOLDUGUBIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    AITOLDUGUBIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AITOLDUGUBIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AITOLDUGUBIRLIK.TextFont.Name = "Arial";
                    AITOLDUGUBIRLIK.TextFont.Size = 11;
                    AITOLDUGUBIRLIK.TextFont.CharSet = 162;
                    AITOLDUGUBIRLIK.Value = @"{#OWNERMILITARYUNIT#}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 197, 195, 207, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.DrawStyle = DrawStyleConstants.vbSolid;
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADISOYADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADISOYADI.TextFont.Name = "Arial";
                    ADISOYADI.TextFont.Size = 11;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 207, 195, 217, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.DrawStyle = DrawStyleConstants.vbSolid;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SINIFRUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SINIFRUTBE.TextFont.Name = "Arial";
                    SINIFRUTBE.TextFont.Size = 11;
                    SINIFRUTBE.TextFont.CharSet = 162;
                    SINIFRUTBE.Value = @"";

                    GOREVYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 217, 195, 227, false);
                    GOREVYERI.Name = "GOREVYERI";
                    GOREVYERI.DrawStyle = DrawStyleConstants.vbSolid;
                    GOREVYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREVYERI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GOREVYERI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GOREVYERI.TextFont.Name = "Arial";
                    GOREVYERI.TextFont.Size = 11;
                    GOREVYERI.TextFont.CharSet = 162;
                    GOREVYERI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    MUAYENEACIKLAMALARI.CalcValue = @"";
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    ADI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    MARKASI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "");
                    MODELI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "");
                    SERINUMARASI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    AITOLDUGUBIRLIK.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    ADISOYADI.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    GOREVYERI.CalcValue = @"";
                    return new TTReportObject[] { NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,MUAYENEACIKLAMALARI,NewField12,NewField13,NewField14,NewField15,NewField16,NewField17,ADI,MARKASI,MODELI,SERINUMARASI,AITOLDUGUBIRLIK,ADISOYADI,SINIFRUTBE,GOREVYERI};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FonksiyonMuayeneFormu()
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
            Name = "FONKSIYONMUAYENEFORMU";
            Caption = "Fonksiyon Muayenesi Formu (Ek-8.7)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            PaperSize = 10;
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