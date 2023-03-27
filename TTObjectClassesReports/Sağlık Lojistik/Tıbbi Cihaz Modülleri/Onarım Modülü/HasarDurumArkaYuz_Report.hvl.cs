
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
    /// Hasar ve Durum Tespit Raporu
    /// </summary>
    public partial class HasarDurumArkaYuz : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HasarDurumArkaYuz MyParentReport
            {
                get { return (HasarDurumArkaYuz)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField MalzemeIsimleri { get {return Body().MalzemeIsimleri;} }
            public TTReportField MalzemeMiktarlari { get {return Body().MalzemeMiktarlari;} }
            public TTReportField MalzemeBirimFiyat { get {return Body().MalzemeBirimFiyat;} }
            public TTReportField ToplamFiyat { get {return Body().ToplamFiyat;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportField GenelToplamFiyat { get {return Body().GenelToplamFiyat;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField GenelToplamMalzemeMiktari { get {return Body().GenelToplamMalzemeMiktari;} }
            public TTReportField GenelToplamBirimFiyat { get {return Body().GenelToplamBirimFiyat;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HasarDurumArkaYuz MyParentReport
                {
                    get { return (HasarDurumArkaYuz)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField1131;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField MalzemeIsimleri;
                public TTReportField MalzemeMiktarlari;
                public TTReportField MalzemeBirimFiyat;
                public TTReportField ToplamFiyat;
                public TTReportField NewField7;
                public TTReportField NewField19;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportField GenelToplamFiyat;
                public TTReportField NewField9;
                public TTReportField GenelToplamMalzemeMiktari;
                public TTReportField GenelToplamBirimFiyat; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 9, 162, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"HİZMETE ÖZEL";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 277, 32, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"HASAR VE DURUM TESPİT RAPORU";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 32, 277, 40, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 11;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Hasarlı Malzemenin";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 17, 156, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"ARKA YÜZ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 76, 51, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"ADI:";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 40, 141, 51, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"MİKTARI:";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 40, 201, 51, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"BİRİM FİYATI:";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 40, 277, 51, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"TOPLAM FİYAT:";

                    MalzemeIsimleri = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 51, 76, 104, false);
                    MalzemeIsimleri.Name = "MalzemeIsimleri";
                    MalzemeIsimleri.DrawStyle = DrawStyleConstants.vbSolid;
                    MalzemeIsimleri.Value = @"";

                    MalzemeMiktarlari = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 51, 141, 104, false);
                    MalzemeMiktarlari.Name = "MalzemeMiktarlari";
                    MalzemeMiktarlari.DrawStyle = DrawStyleConstants.vbSolid;
                    MalzemeMiktarlari.Value = @"";

                    MalzemeBirimFiyat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 51, 201, 104, false);
                    MalzemeBirimFiyat.Name = "MalzemeBirimFiyat";
                    MalzemeBirimFiyat.DrawStyle = DrawStyleConstants.vbSolid;
                    MalzemeBirimFiyat.Value = @"";

                    ToplamFiyat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 51, 277, 104, false);
                    ToplamFiyat.Name = "ToplamFiyat";
                    ToplamFiyat.DrawStyle = DrawStyleConstants.vbSolid;
                    ToplamFiyat.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 104, 76, 120, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 12;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Genel Toplam :";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 120, 277, 153, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 11;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"AÇIKLAMALAR: (f)";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 76, 103, 76, 120, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 104, 141, 120, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 104, 201, 120, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    GenelToplamFiyat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 104, 277, 120, false);
                    GenelToplamFiyat.Name = "GenelToplamFiyat";
                    GenelToplamFiyat.DrawStyle = DrawStyleConstants.vbSolid;
                    GenelToplamFiyat.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GenelToplamFiyat.TextFont.Name = "Arial";
                    GenelToplamFiyat.TextFont.CharSet = 162;
                    GenelToplamFiyat.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 163, 168, 175, false);
                    NewField9.Name = "NewField9";
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 12;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"HİZMETE ÖZEL";

                    GenelToplamMalzemeMiktari = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 104, 141, 120, false);
                    GenelToplamMalzemeMiktari.Name = "GenelToplamMalzemeMiktari";
                    GenelToplamMalzemeMiktari.DrawStyle = DrawStyleConstants.vbSolid;
                    GenelToplamMalzemeMiktari.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GenelToplamMalzemeMiktari.TextFont.Name = "Arial";
                    GenelToplamMalzemeMiktari.TextFont.CharSet = 162;
                    GenelToplamMalzemeMiktari.Value = @"";

                    GenelToplamBirimFiyat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 104, 201, 120, false);
                    GenelToplamBirimFiyat.Name = "GenelToplamBirimFiyat";
                    GenelToplamBirimFiyat.DrawStyle = DrawStyleConstants.vbSolid;
                    GenelToplamBirimFiyat.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GenelToplamBirimFiyat.TextFont.Name = "Arial";
                    GenelToplamBirimFiyat.TextFont.CharSet = 162;
                    GenelToplamBirimFiyat.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    MalzemeIsimleri.CalcValue = MalzemeIsimleri.Value;
                    MalzemeMiktarlari.CalcValue = MalzemeMiktarlari.Value;
                    MalzemeBirimFiyat.CalcValue = MalzemeBirimFiyat.Value;
                    ToplamFiyat.CalcValue = ToplamFiyat.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField19.CalcValue = NewField19.Value;
                    GenelToplamFiyat.CalcValue = GenelToplamFiyat.Value;
                    NewField9.CalcValue = NewField9.Value;
                    GenelToplamMalzemeMiktari.CalcValue = GenelToplamMalzemeMiktari.Value;
                    GenelToplamBirimFiyat.CalcValue = GenelToplamBirimFiyat.Value;
                    return new TTReportObject[] { NewField11,NewField121,NewField1131,NewField1,NewField2,NewField3,NewField4,NewField5,MalzemeIsimleri,MalzemeMiktarlari,MalzemeBirimFiyat,ToplamFiyat,NewField7,NewField19,GenelToplamFiyat,NewField9,GenelToplamMalzemeMiktari,GenelToplamBirimFiyat};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    MalzemeMiktarlari = null;
                    MalzemeIsimleri = null;

                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));

                    if (cmrAction is Repair)
                    {  
                        Repair repair = (Repair)cmrAction;
                     
                        if (repair.Repair_ItemEquipments.Count > 0)
                        {
                            foreach (Repair_ItemEquipment repairItem in repair.Repair_ItemEquipments)
                            {
                                if (MalzemeIsimleri == null)
                                {
                                    MalzemeIsimleri.CalcValue += repairItem.ItemName;
                                    MalzemeMiktarlari.CalcValue += repairItem.Amount;
                                   
                                   
                                }
                                else 
                                {
                                    MalzemeIsimleri.CalcValue += "\n" + repairItem.ItemName;
                                    MalzemeMiktarlari.CalcValue += "\n" + repairItem.Amount;
                                    
                                }
                            }
                        }
                    }
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

        public HasarDurumArkaYuz()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HASARDURUMARKAYUZ";
            Caption = "Hasar ve Durum Tespit Raporu Arka Yuz";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
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