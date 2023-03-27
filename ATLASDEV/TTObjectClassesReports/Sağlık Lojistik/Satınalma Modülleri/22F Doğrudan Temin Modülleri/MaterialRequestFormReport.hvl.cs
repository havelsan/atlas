
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
    /// Malzeme  ihtiyaç talep formu
    /// </summary>
    public partial class MaterialRequestFormReport : TTReport
    {
#region Methods
   public int counter = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class FOOTERGroup : TTReportGroup
        {
            public MaterialRequestFormReport MyParentReport
            {
                get { return (MaterialRequestFormReport)ParentReport; }
            }

            new public FOOTERGroupHeader Header()
            {
                return (FOOTERGroupHeader)_header;
            }

            new public FOOTERGroupFooter Footer()
            {
                return (FOOTERGroupFooter)_footer;
            }

            public FOOTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FOOTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FOOTERGroupHeader(this);
                _footer = new FOOTERGroupFooter(this);

            }

            public partial class FOOTERGroupHeader : TTReportSection
            {
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                 
                public FOOTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class FOOTERGroupFooter : TTReportSection
            {
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                 
                public FOOTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FOOTERGroup FOOTER;

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialRequestFormReport MyParentReport
            {
                get { return (MaterialRequestFormReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField UZMANLIK { get {return Header().UZMANLIK;} }
            public TTReportField yazi { get {return Header().yazi;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField IHALEYETKILISI { get {return Footer().IHALEYETKILISI;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
            public TTReportField IHALEYETKILISIIS { get {return Footer().IHALEYETKILISIIS;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField IHALEYETKILISISINRUT { get {return Footer().IHALEYETKILISISINRUT;} }
            public TTReportField IHALEYETKILISIUNVAN { get {return Footer().IHALEYETKILISIUNVAN;} }
            public TTReportField IHALEYETKILISIRUTBE { get {return Footer().IHALEYETKILISIRUTBE;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class>("MaterialRequestFormReportBackUpNQL", DirectPurchaseAction.MaterialRequestFormReportBackUpNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1111;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField122;
                public TTReportField NewField1221;
                public TTReportField UZMANLIK;
                public TTReportField yazi; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 6, 202, 26, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 8;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + "" BAŞTABİPLİĞİ "";";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 19, 200, 24, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"EK-A";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 27, 202, 31, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SAYI :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 32, 22, 40, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Sıra No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 32, 41, 40, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"SUT / İşlem Kodu";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 32, 60, 40, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"SUT / İşlem Fiyatı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 32, 170, 40, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Malzemenin Adı";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 32, 182, 40, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Size = 8;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Miktar";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 32, 202, 40, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Size = 8;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Ölçü Birimi";

                    UZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 17, 160, 21, false);
                    UZMANLIK.Name = "UZMANLIK";
                    UZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANLIK.ObjectDefName = "ResSection";
                    UZMANLIK.DataMember = "NAME";
                    UZMANLIK.TextFont.Name = "Arial";
                    UZMANLIK.TextFont.Size = 8;
                    UZMANLIK.TextFont.Bold = true;
                    UZMANLIK.TextFont.CharSet = 162;
                    UZMANLIK.Value = @"{#MASTERRESOURCE#}";

                    yazi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 21, 177, 25, false);
                    yazi.Name = "yazi";
                    yazi.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    yazi.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    yazi.MultiLine = EvetHayirEnum.ehEvet;
                    yazi.ExpandTabs = EvetHayirEnum.ehEvet;
                    yazi.TextFont.Name = "Arial";
                    yazi.TextFont.Size = 8;
                    yazi.TextFont.Bold = true;
                    yazi.TextFont.CharSet = 162;
                    yazi.Value = @"HASTAYA ÖZGÜ / ACİL MALZEME İHTİYAÇ TALEP VE GÖREVLENDİRME FORMU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class dataset_MaterialRequestFormReportBackUpNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class>(0);
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    UZMANLIK.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.MasterResource) : "");
                    UZMANLIK.PostFieldValueCalculation();
                    yazi.CalcValue = yazi.Value;
                    XXXXXXBASLIK.CalcValue = XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + " BAŞTABİPLİĞİ ";;
                    return new TTReportObject[] { NewField1111,NewField1,NewField2,NewField12,NewField121,NewField1121,NewField122,NewField1221,UZMANLIK,yazi,XXXXXXBASLIK};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                
                public TTReportField NewField5;
                public TTReportShape NewLine2;
                public TTReportField NewField141;
                public TTReportField IHALEYETKILISI;
                public TTReportShape NewLine3;
                public TTReportField IHALEYETKILISIIS;
                public TTReportField NewField4;
                public TTReportField IHALEYETKILISISINRUT;
                public TTReportField IHALEYETKILISIUNVAN;
                public TTReportField IHALEYETKILISIRUTBE; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    RepeatCount = 0;
                    
                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 155, 38, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 7;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Tarih
......../......../........
Yukarıdaki talebin satın alınması hususunu onaylarınıza uygun görüşle arz ederim.
Satın Alma ve Kabul Komisyon Başkanı


";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 106, 0, 202, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 202, 38, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"
......../......../........
UYGUNDUR
";

                    IHALEYETKILISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 17, 201, 22, false);
                    IHALEYETKILISI.Name = "IHALEYETKILISI";
                    IHALEYETKILISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEYETKILISI.MultiLine = EvetHayirEnum.ehEvet;
                    IHALEYETKILISI.WordBreak = EvetHayirEnum.ehEvet;
                    IHALEYETKILISI.ExpandTabs = EvetHayirEnum.ehEvet;
                    IHALEYETKILISI.ObjectDefName = "ResUser";
                    IHALEYETKILISI.DataMember = "NAME";
                    IHALEYETKILISI.TextFont.Name = "Arial";
                    IHALEYETKILISI.TextFont.Size = 8;
                    IHALEYETKILISI.TextFont.CharSet = 162;
                    IHALEYETKILISI.Value = @"{#IHALEYETKILISI#}";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 155, 0, 202, 0, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    IHALEYETKILISIIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 27, 201, 37, false);
                    IHALEYETKILISIIS.Name = "IHALEYETKILISIIS";
                    IHALEYETKILISIIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEYETKILISIIS.MultiLine = EvetHayirEnum.ehEvet;
                    IHALEYETKILISIIS.WordBreak = EvetHayirEnum.ehEvet;
                    IHALEYETKILISIIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    IHALEYETKILISIIS.TextFont.Name = "Arial";
                    IHALEYETKILISIIS.TextFont.Size = 8;
                    IHALEYETKILISIIS.TextFont.CharSet = 162;
                    IHALEYETKILISIIS.Value = @"{#IHALEYETKILISIIS#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 12, 201, 17, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"İHALE YETKİLİSİ";

                    IHALEYETKILISISINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 22, 201, 27, false);
                    IHALEYETKILISISINRUT.Name = "IHALEYETKILISISINRUT";
                    IHALEYETKILISISINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEYETKILISISINRUT.MultiLine = EvetHayirEnum.ehEvet;
                    IHALEYETKILISISINRUT.WordBreak = EvetHayirEnum.ehEvet;
                    IHALEYETKILISISINRUT.ExpandTabs = EvetHayirEnum.ehEvet;
                    IHALEYETKILISISINRUT.TextFont.Name = "Arial";
                    IHALEYETKILISISINRUT.TextFont.Size = 8;
                    IHALEYETKILISISINRUT.TextFont.CharSet = 162;
                    IHALEYETKILISISINRUT.Value = @"";

                    IHALEYETKILISIUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 236, 5, false);
                    IHALEYETKILISIUNVAN.Name = "IHALEYETKILISIUNVAN";
                    IHALEYETKILISIUNVAN.Visible = EvetHayirEnum.ehHayir;
                    IHALEYETKILISIUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEYETKILISIUNVAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHALEYETKILISIUNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEYETKILISIUNVAN.ObjectDefName = "UserTitleEnum";
                    IHALEYETKILISIUNVAN.DataMember = "DISPLAYTEXT";
                    IHALEYETKILISIUNVAN.TextFont.Name = "Arial";
                    IHALEYETKILISIUNVAN.TextFont.Size = 8;
                    IHALEYETKILISIUNVAN.TextFont.CharSet = 162;
                    IHALEYETKILISIUNVAN.Value = @"{#IHALEYETKILISIUNVAN#}";

                    IHALEYETKILISIRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 6, 236, 10, false);
                    IHALEYETKILISIRUTBE.Name = "IHALEYETKILISIRUTBE";
                    IHALEYETKILISIRUTBE.Visible = EvetHayirEnum.ehHayir;
                    IHALEYETKILISIRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEYETKILISIRUTBE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHALEYETKILISIRUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEYETKILISIRUTBE.ObjectDefName = "RankDefinitions";
                    IHALEYETKILISIRUTBE.DataMember = "NAME";
                    IHALEYETKILISIRUTBE.TextFont.Name = "Arial";
                    IHALEYETKILISIRUTBE.TextFont.Size = 8;
                    IHALEYETKILISIRUTBE.TextFont.CharSet = 162;
                    IHALEYETKILISIRUTBE.Value = @"{#IHALEYETKILISIRUTBE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class dataset_MaterialRequestFormReportBackUpNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class>(0);
                    NewField5.CalcValue = NewField5.Value;
                    NewField141.CalcValue = NewField141.Value;
                    IHALEYETKILISI.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Ihaleyetkilisi) : "");
                    IHALEYETKILISI.PostFieldValueCalculation();
                    IHALEYETKILISIIS.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Ihaleyetkilisiis) : "");
                    NewField4.CalcValue = NewField4.Value;
                    IHALEYETKILISISINRUT.CalcValue = @"";
                    IHALEYETKILISIUNVAN.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Ihaleyetkilisiunvan) : "");
                    IHALEYETKILISIUNVAN.PostFieldValueCalculation();
                    IHALEYETKILISIRUTBE.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Ihaleyetkilisirutbe) : "");
                    IHALEYETKILISIRUTBE.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField5,NewField141,IHALEYETKILISI,IHALEYETKILISIIS,NewField4,IHALEYETKILISISINRUT,IHALEYETKILISIUNVAN,IHALEYETKILISIRUTBE};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    string sinrut = ""+ this.IHALEYETKILISIUNVAN.CalcValue +" " + this.IHALEYETKILISIRUTBE.CalcValue + " ";
            this.IHALEYETKILISISINRUT.CalcValue = sinrut;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialRequestFormReport MyParentReport
            {
                get { return (MaterialRequestFormReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField TEXT { get {return Footer().TEXT;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField1221 { get {return Footer().NewField1221;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1241 { get {return Footer().NewField1241;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField TEXTINFO { get {return Footer().TEXTINFO;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField ADBILIMBASKANI { get {return Footer().ADBILIMBASKANI;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportField TCKIMLIKNO { get {return Footer().TCKIMLIKNO;} }
            public TTReportField HASTAISIM { get {return Footer().HASTAISIM;} }
            public TTReportField HASTAPROTNO { get {return Footer().HASTAPROTNO;} }
            public TTReportField ASILBASKAN { get {return Footer().ASILBASKAN;} }
            public TTReportField ASILUYE1 { get {return Footer().ASILUYE1;} }
            public TTReportField ASILUYE2 { get {return Footer().ASILUYE2;} }
            public TTReportField YEDEKBASKAN { get {return Footer().YEDEKBASKAN;} }
            public TTReportField YEDEKUYE1 { get {return Footer().YEDEKUYE1;} }
            public TTReportField YEDEKUYE2 { get {return Footer().YEDEKUYE2;} }
            public TTReportField OBJECTID { get {return Footer().OBJECTID;} }
            public TTReportField UZMANLIKDALI { get {return Footer().UZMANLIKDALI;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportField ADBILIMBASKANIUNVAN { get {return Footer().ADBILIMBASKANIUNVAN;} }
            public TTReportField ADBILIMBASKANIRUTBE { get {return Footer().ADBILIMBASKANIRUTBE;} }
            public TTReportField ADBILIMBASKANISICIL { get {return Footer().ADBILIMBASKANISICIL;} }
            public TTReportField INFOTEXT { get {return Footer().INFOTEXT;} }
            public TTReportField ACIKLAMA { get {return Footer().ACIKLAMA;} }
            public TTReportField ADBILIMBASKANISINRUT { get {return Footer().ADBILIMBASKANISINRUT;} }
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
                list[0] = new TTReportNqlData<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>("MaterialRequestFormReportNewNQL", DirectPurchaseAction.MaterialRequestFormReportNewNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                
                public TTReportField TEXT;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField12;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField1221;
                public TTReportField NewField131;
                public TTReportField NewField1241;
                public TTReportField NewField11411;
                public TTReportField TEXTINFO;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField ADBILIMBASKANI;
                public TTReportField NewField151;
                public TTReportShape NewLine12;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine121;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAISIM;
                public TTReportField HASTAPROTNO;
                public TTReportField ASILBASKAN;
                public TTReportField ASILUYE1;
                public TTReportField ASILUYE2;
                public TTReportField YEDEKBASKAN;
                public TTReportField YEDEKUYE1;
                public TTReportField YEDEKUYE2;
                public TTReportField OBJECTID;
                public TTReportField UZMANLIKDALI;
                public TTReportShape NewLine11111;
                public TTReportField ADBILIMBASKANIUNVAN;
                public TTReportField ADBILIMBASKANIRUTBE;
                public TTReportField ADBILIMBASKANISICIL;
                public TTReportField INFOTEXT;
                public TTReportField ACIKLAMA;
                public TTReportField ADBILIMBASKANISINRUT; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 121;
                    RepeatCount = 0;
                    
                    TEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 5, 202, 17, false);
                    TEXT.Name = "TEXT";
                    TEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    TEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEXT.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXT.TextFont.Name = "Arial";
                    TEXT.TextFont.Size = 8;
                    TEXT.TextFont.CharSet = 162;
                    TEXT.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 202, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"BÖLÜMÜN TALEP GEREKÇESİ";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 29, 108, 80, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.Underline = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Asil Üyeler";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 35, 29, 39, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Başkan   :";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 51, 29, 55, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Üye         :";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 67, 29, 71, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Üye         :";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 29, 202, 80, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Size = 8;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.Underline = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Yedek Üyeler";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 35, 124, 39, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Başkan   :";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 51, 124, 55, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 8;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Üye         :";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 67, 124, 71, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 8;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Üye         :";

                    TEXTINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 80, 202, 90, false);
                    TEXTINFO.Name = "TEXTINFO";
                    TEXTINFO.DrawStyle = DrawStyleConstants.vbSolid;
                    TEXTINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXTINFO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEXTINFO.MultiLine = EvetHayirEnum.ehEvet;
                    TEXTINFO.WordBreak = EvetHayirEnum.ehEvet;
                    TEXTINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXTINFO.TextFont.Name = "Arial";
                    TEXTINFO.TextFont.Size = 7;
                    TEXTINFO.TextFont.CharSet = 162;
                    TEXTINFO.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 90, 202, 103, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Tarih

......../......../........";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 90, 155, 103, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"";

                    ADBILIMBASKANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 103, 201, 108, false);
                    ADBILIMBASKANI.Name = "ADBILIMBASKANI";
                    ADBILIMBASKANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADBILIMBASKANI.MultiLine = EvetHayirEnum.ehEvet;
                    ADBILIMBASKANI.ObjectDefName = "ResUser";
                    ADBILIMBASKANI.DataMember = "NAME";
                    ADBILIMBASKANI.TextFont.Name = "Arial";
                    ADBILIMBASKANI.TextFont.Size = 8;
                    ADBILIMBASKANI.TextFont.CharSet = 162;
                    ADBILIMBASKANI.Value = @"{#CLINICCHIEF#}
";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 103, 161, 120, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 121, 202, 121, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 90, 202, 121, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 90, 202, 90, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    HASTAISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 7, 237, 12, false);
                    HASTAISIM.Name = "HASTAISIM";
                    HASTAISIM.Visible = EvetHayirEnum.ehHayir;
                    HASTAISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAISIM.TextFont.Name = "Arial";
                    HASTAISIM.TextFont.Size = 8;
                    HASTAISIM.TextFont.CharSet = 162;
                    HASTAISIM.Value = @"{#HASTAISIM#} {#HASTASOYISIM#}";

                    HASTAPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 13, 237, 18, false);
                    HASTAPROTNO.Name = "HASTAPROTNO";
                    HASTAPROTNO.Visible = EvetHayirEnum.ehHayir;
                    HASTAPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAPROTNO.TextFont.Name = "Arial";
                    HASTAPROTNO.TextFont.Size = 8;
                    HASTAPROTNO.TextFont.CharSet = 162;
                    HASTAPROTNO.Value = @"{#HASTAPROTNO#}";

                    ASILBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 35, 99, 47, false);
                    ASILBASKAN.Name = "ASILBASKAN";
                    ASILBASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASILBASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    ASILBASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    ASILBASKAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ASILBASKAN.TextFont.Name = "Arial";
                    ASILBASKAN.TextFont.Size = 8;
                    ASILBASKAN.TextFont.CharSet = 162;
                    ASILBASKAN.Value = @"";

                    ASILUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 51, 99, 63, false);
                    ASILUYE1.Name = "ASILUYE1";
                    ASILUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASILUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    ASILUYE1.WordBreak = EvetHayirEnum.ehEvet;
                    ASILUYE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ASILUYE1.TextFont.Name = "Arial";
                    ASILUYE1.TextFont.Size = 8;
                    ASILUYE1.TextFont.CharSet = 162;
                    ASILUYE1.Value = @"";

                    ASILUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 67, 99, 78, false);
                    ASILUYE2.Name = "ASILUYE2";
                    ASILUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASILUYE2.MultiLine = EvetHayirEnum.ehEvet;
                    ASILUYE2.WordBreak = EvetHayirEnum.ehEvet;
                    ASILUYE2.ExpandTabs = EvetHayirEnum.ehEvet;
                    ASILUYE2.TextFont.Name = "Arial";
                    ASILUYE2.TextFont.Size = 8;
                    ASILUYE2.TextFont.CharSet = 162;
                    ASILUYE2.Value = @"";

                    YEDEKBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 35, 194, 47, false);
                    YEDEKBASKAN.Name = "YEDEKBASKAN";
                    YEDEKBASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEDEKBASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    YEDEKBASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    YEDEKBASKAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    YEDEKBASKAN.TextFont.Name = "Arial";
                    YEDEKBASKAN.TextFont.Size = 8;
                    YEDEKBASKAN.TextFont.CharSet = 162;
                    YEDEKBASKAN.Value = @"";

                    YEDEKUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 51, 194, 63, false);
                    YEDEKUYE1.Name = "YEDEKUYE1";
                    YEDEKUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEDEKUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    YEDEKUYE1.WordBreak = EvetHayirEnum.ehEvet;
                    YEDEKUYE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    YEDEKUYE1.TextFont.Name = "Arial";
                    YEDEKUYE1.TextFont.Size = 8;
                    YEDEKUYE1.TextFont.CharSet = 162;
                    YEDEKUYE1.Value = @"";

                    YEDEKUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 67, 194, 78, false);
                    YEDEKUYE2.Name = "YEDEKUYE2";
                    YEDEKUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEDEKUYE2.MultiLine = EvetHayirEnum.ehEvet;
                    YEDEKUYE2.WordBreak = EvetHayirEnum.ehEvet;
                    YEDEKUYE2.ExpandTabs = EvetHayirEnum.ehEvet;
                    YEDEKUYE2.TextFont.Name = "Arial";
                    YEDEKUYE2.TextFont.Size = 8;
                    YEDEKUYE2.TextFont.CharSet = 162;
                    YEDEKUYE2.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 19, 237, 24, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    UZMANLIKDALI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 25, 237, 30, false);
                    UZMANLIKDALI.Name = "UZMANLIKDALI";
                    UZMANLIKDALI.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDALI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDALI.ObjectDefName = "ResSection";
                    UZMANLIKDALI.DataMember = "NAME";
                    UZMANLIKDALI.TextFont.Name = "Arial";
                    UZMANLIKDALI.TextFont.Size = 8;
                    UZMANLIKDALI.TextFont.CharSet = 162;
                    UZMANLIKDALI.Value = @"{#MASTERRESOURCE#}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 90, 13, 121, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    ADBILIMBASKANIUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 107, 235, 112, false);
                    ADBILIMBASKANIUNVAN.Name = "ADBILIMBASKANIUNVAN";
                    ADBILIMBASKANIUNVAN.Visible = EvetHayirEnum.ehHayir;
                    ADBILIMBASKANIUNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADBILIMBASKANIUNVAN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ADBILIMBASKANIUNVAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADBILIMBASKANIUNVAN.ObjectDefName = "UserTitleEnum";
                    ADBILIMBASKANIUNVAN.DataMember = "DISPLAYTEXT";
                    ADBILIMBASKANIUNVAN.TextFont.Name = "Arial";
                    ADBILIMBASKANIUNVAN.TextFont.Size = 8;
                    ADBILIMBASKANIUNVAN.TextFont.CharSet = 162;
                    ADBILIMBASKANIUNVAN.Value = @"{#PARTA.ADBILIMBASKANIUNVAN#}";

                    ADBILIMBASKANIRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 113, 235, 118, false);
                    ADBILIMBASKANIRUTBE.Name = "ADBILIMBASKANIRUTBE";
                    ADBILIMBASKANIRUTBE.Visible = EvetHayirEnum.ehHayir;
                    ADBILIMBASKANIRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADBILIMBASKANIRUTBE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADBILIMBASKANIRUTBE.ObjectDefName = "RankDefinitions";
                    ADBILIMBASKANIRUTBE.DataMember = "NAME";
                    ADBILIMBASKANIRUTBE.TextFont.Name = "Arial";
                    ADBILIMBASKANIRUTBE.TextFont.Size = 8;
                    ADBILIMBASKANIRUTBE.TextFont.CharSet = 162;
                    ADBILIMBASKANIRUTBE.Value = @"{#PARTA.ADBILIMBASKANIRUTBE#} ";

                    ADBILIMBASKANISICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 113, 201, 120, false);
                    ADBILIMBASKANISICIL.Name = "ADBILIMBASKANISICIL";
                    ADBILIMBASKANISICIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADBILIMBASKANISICIL.TextFont.Name = "Arial";
                    ADBILIMBASKANISICIL.TextFont.Size = 8;
                    ADBILIMBASKANISICIL.TextFont.CharSet = 162;
                    ADBILIMBASKANISICIL.Value = @"{#PARTA.ADBILIMBASKANISICIL#}";

                    INFOTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 17, 202, 29, false);
                    INFOTEXT.Name = "INFOTEXT";
                    INFOTEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    INFOTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    INFOTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    INFOTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    INFOTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFOTEXT.TextFont.Name = "Arial";
                    INFOTEXT.TextFont.Size = 8;
                    INFOTEXT.TextFont.CharSet = 162;
                    INFOTEXT.Value = @"";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 31, 237, 36, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.Visible = EvetHayirEnum.ehHayir;
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFont.Name = "Arial";
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#DESCRIPTION#}";

                    ADBILIMBASKANISINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 108, 201, 113, false);
                    ADBILIMBASKANISINRUT.Name = "ADBILIMBASKANISINRUT";
                    ADBILIMBASKANISINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADBILIMBASKANISINRUT.MultiLine = EvetHayirEnum.ehEvet;
                    ADBILIMBASKANISINRUT.WordBreak = EvetHayirEnum.ehEvet;
                    ADBILIMBASKANISINRUT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADBILIMBASKANISINRUT.TextFont.Name = "Arial";
                    ADBILIMBASKANISINRUT.TextFont.Size = 8;
                    ADBILIMBASKANISINRUT.TextFont.CharSet = 162;
                    ADBILIMBASKANISINRUT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class dataset_MaterialRequestFormReportBackUpNQL = MyParentReport.PARTA.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class>(0);
                    TEXT.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    TEXTINFO.CalcValue = @"";
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    ADBILIMBASKANI.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ClinicChief) : "") + @"
";
                    ADBILIMBASKANI.PostFieldValueCalculation();
                    NewField151.CalcValue = NewField151.Value;
                    TCKIMLIKNO.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Tckimlikno) : "");
                    HASTAISIM.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Hastaisim) : "") + @" " + (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Hastasoyisim) : "");
                    HASTAPROTNO.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Hastaprotno) : "");
                    ASILBASKAN.CalcValue = @"";
                    ASILUYE1.CalcValue = @"";
                    ASILUYE2.CalcValue = @"";
                    YEDEKBASKAN.CalcValue = @"";
                    YEDEKUYE1.CalcValue = @"";
                    YEDEKUYE2.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    UZMANLIKDALI.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.MasterResource) : "");
                    UZMANLIKDALI.PostFieldValueCalculation();
                    ADBILIMBASKANIUNVAN.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Adbilimbaskaniunvan) : "");
                    ADBILIMBASKANIUNVAN.PostFieldValueCalculation();
                    ADBILIMBASKANIRUTBE.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Adbilimbaskanirutbe) : "") + @" ";
                    ADBILIMBASKANIRUTBE.PostFieldValueCalculation();
                    ADBILIMBASKANISICIL.CalcValue = (dataset_MaterialRequestFormReportBackUpNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportBackUpNQL.Adbilimbaskanisicil) : "");
                    INFOTEXT.CalcValue = @"";
                    ACIKLAMA.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Description) : "");
                    ADBILIMBASKANISINRUT.CalcValue = @"";
                    return new TTReportObject[] { TEXT,NewField11,NewField121,NewField12,NewField141,NewField1141,NewField1221,NewField131,NewField1241,NewField11411,TEXTINFO,NewField14,NewField15,ADBILIMBASKANI,NewField151,TCKIMLIKNO,HASTAISIM,HASTAPROTNO,ASILBASKAN,ASILUYE1,ASILUYE2,YEDEKBASKAN,YEDEKUYE1,YEDEKUYE2,OBJECTID,UZMANLIKDALI,ADBILIMBASKANIUNVAN,ADBILIMBASKANIRUTBE,ADBILIMBASKANISICIL,INFOTEXT,ACIKLAMA,ADBILIMBASKANISINRUT};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string newobjectID = ((MaterialRequestFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DirectPurchaseAction newdpa = (DirectPurchaseAction)ctx.GetObject(new Guid(newobjectID), typeof(DirectPurchaseAction));

            if (newdpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                string text2 = "Yukarıda istemi yapılan malzeme taleplerimizin 4734 sayılı Kamu İhale Kanunu 22/F maddesi kapsamında stoklanamayan hastaya özgü işlem esnasında uygulanacak malzeme olduğunu,  ihtiyaçtan fazla talep edilmediğini, fazla talep edilmesinden kaynaklanan yasal sorumlulukların tarafımıza ait olduğunu, kısa ömürlü radyoaktif malzeme olması nedeniyle depolama imkanı olmadığı ve rekabete engel teşkil etmediğini taahhüt ederiz.";
                this.TEXTINFO.CalcValue = text2;
            }
            else
            {
                string text3 = "Yukarıda istemi yapılan malzeme taleplerimizin 4734 sayılı Kamu İhale Kanunu 22/F maddesi kapsamında hastaya özgü işlem esnasında uygulanacak malzeme olduğunu,  ihtiyaçtan fazla talep edilmediğini, fazla talep edilmesinden kaynaklanan yasal sorumlulukların tarafımıza ait olduğunu, yapılan talebin yürürlükteki yasa ve yönetmeliklere uygun olduğu ve rekabete engel teşkil etmediğini taahhüt ederiz.";
                this.TEXTINFO.CalcValue = text3;
            }
            
            
            
            string adsinrut = ""+ this.ADBILIMBASKANIUNVAN.CalcValue +" " + this.ADBILIMBASKANIRUTBE.CalcValue + " ";
            this.ADBILIMBASKANISINRUT.CalcValue = adsinrut;
            
            string a = "" + this.UZMANLIKDALI.CalcValue + "  'de işlem görecek .......... protokol numaralı " + this.TCKIMLIKNO.CalcValue + " T.C. Kimlik numaralı " + this.HASTAISIM.CalcValue + " isimli hasta için, yukarıda yazılı " + ((MaterialRequestFormReport)ParentReport).counter + " kalem malzemenin, 4734 sayılı Kanunun 22/F Doğrudan Temin usulü ile aşağıda asil ve yedek üye isimleri yazılı komisyon tarafından satın alma ve kabul işlemlerinin yürütülmesini arz ederim.";
            ((MaterialRequestFormReport)ParentReport).counter = 0;
            this.TEXT.CalcValue = a;
            
            string info = "" + this.ACIKLAMA.CalcValue + "";
            this.INFOTEXT.CalcValue = info;

            string objectID = this.OBJECTID.CalcValue;
            DirectPurchaseAction dpa = (DirectPurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            string asilBaskan = string.Empty;
            string asilUye1 = string.Empty;
            string asilUye2 = string.Empty;
            string yedekBaskan = string.Empty;
            string yedekUye1 = string.Empty;
            string yedekUye2 = string.Empty;
            
            List<CommisionMember> commisionPrimeMember = new List<CommisionMember>();
            List<CommisionMember> commisionBackupMember = new List<CommisionMember>();

            foreach (CommisionMember member in dpa.CommissionMembers)
            {
                if (member.MemberDuty.ToString() == DPACommisionMemberDutyEnum.Chief.ToString())
                {
                    if (member.PrimeBackup == true)
                    {
                        //ASILBASKAN Name-Surname, Rank, Title vs. set ediliyor.
                        if (member.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            asilBaskan += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText + " ";
                            asilBaskan += member.ResUser.Name + "\r\n";
                        }
                        else
                        {
                            asilBaskan += member.ResUser.Name + "\r\n";
                        }
                        if (member.ResUser.MilitaryClass != null)
                        {
                            asilBaskan += member.ResUser.MilitaryClass.ShortName;
                        }
                        if (member.ResUser.Rank != null)
                        {
                            asilBaskan += member.ResUser.Rank.ShortName + "\r\n";
                            //asilBaskan += "(" + member.ResUser.EmploymentRecordID + ")";
                            ASILBASKAN.CalcValue = asilBaskan;
                        }
                    }
                    else
                    {
                        if (member.ResUser.Title.HasValue)
                        {
                            //YEDEKBASKAN Name-Surname, Rank, Title vs. set ediliyor.
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            yedekBaskan += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText + " ";
                            yedekBaskan += member.ResUser.Name + "\r\n";
                        }
                        else
                        {
                            yedekBaskan += member.ResUser.Name + "\r\n";
                        }
                        if (member.ResUser.MilitaryClass != null)
                        {
                            yedekBaskan += member.ResUser.MilitaryClass.ShortName;
                        }
                        if (member.ResUser.Rank != null)
                        {
                            yedekBaskan += member.ResUser.Rank.ShortName + "\r\n";
                            //yedekBaskan += "(" + member.ResUser.EmploymentRecordID + ")";
                            YEDEKBASKAN.CalcValue = yedekBaskan;
                        }
                    }
                }

                if (member.MemberDuty.ToString() == DPACommisionMemberDutyEnum.Member.ToString())
                {
                    if (member.PrimeBackup == true)
                    {
                        commisionPrimeMember.Add(member);
                    }
                    else
                    {
                        commisionBackupMember.Add(member);
                    }
                }

            }

            //ASILUYE1 Name-Surname, Rank, Title vs. set ediliyor.
            if (commisionPrimeMember[0].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                asilUye1 += dataType.EnumValueDefs[(int)commisionPrimeMember[0].ResUser.Title.Value].DisplayText + " ";
                asilUye1 += commisionPrimeMember[0].ResUser.Name + "\r\n";
            }
            else
            {
                asilUye1 += commisionPrimeMember[0].ResUser.Name + "\r\n";
            }
            if (commisionPrimeMember[0].ResUser.MilitaryClass != null)
            {
                asilUye1 += commisionPrimeMember[0].ResUser.MilitaryClass.ShortName;
            }
            if (commisionPrimeMember[0].ResUser.Rank != null)
            {
                asilUye1 += commisionPrimeMember[0].ResUser.Rank.ShortName + "\r\n";
                //asilUye1 += "(" + commisionPrimeMember[0].ResUser.EmploymentRecordID + ")";
                ASILUYE1.CalcValue = asilUye1;
            }

            //ASILUYE2 Name-Surname, Rank, Title vs. set ediliyor.
            if (commisionPrimeMember[1].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                asilUye2 += dataType.EnumValueDefs[(int)commisionPrimeMember[1].ResUser.Title.Value].DisplayText + " ";
                asilUye2 += commisionPrimeMember[1].ResUser.Name + "\r\n";
            }
            else
            {
                asilUye2 += commisionPrimeMember[1].ResUser.Name + "\r\n";
            }
            if (commisionPrimeMember[1].ResUser.MilitaryClass != null)
            {
                asilUye2 += commisionPrimeMember[1].ResUser.MilitaryClass.ShortName;
            }
            if (commisionPrimeMember[1].ResUser.Rank != null)
            {
                asilUye2 += commisionPrimeMember[1].ResUser.Rank.ShortName + "\r\n";
                //asilUye2 += "(" + commisionPrimeMember[1].ResUser.EmploymentRecordID + ")";
                ASILUYE2.CalcValue = asilUye2;
            }

            //YEDEKUYE1 Name-Surname, Rank, Title vs. set ediliyor.
            if(commisionBackupMember[0].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                yedekUye1 += dataType.EnumValueDefs[(int)commisionBackupMember[0].ResUser.Title.Value].DisplayText + " ";
                yedekUye1 += commisionBackupMember[0].ResUser.Name + "\r\n";
            }
            else
            {
                yedekUye1 += commisionBackupMember[0].ResUser.Name + "\r\n";
            }
            if (commisionBackupMember[0].ResUser.MilitaryClass != null)
            {
                yedekUye1 += commisionBackupMember[0].ResUser.MilitaryClass.ShortName;
            }
            if (commisionBackupMember[0].ResUser.Rank != null)
            {
                yedekUye1 += commisionBackupMember[0].ResUser.Rank.ShortName + "\r\n";
                //yedekUye1 += "(" + commisionBackupMember[0].ResUser.EmploymentRecordID + ")";
                YEDEKUYE1.CalcValue = yedekUye1;
            }

            //YEDEKUYE2 Name-Surname, Rank, Title vs. set ediliyor.
            if(commisionBackupMember[1].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                yedekUye2 += dataType.EnumValueDefs[(int)commisionBackupMember[1].ResUser.Title.Value].DisplayText + " ";
                yedekUye2 += commisionBackupMember[1].ResUser.Name + "\r\n";
            }
            else
            {
                yedekUye2 += commisionBackupMember[1].ResUser.Name + "\r\n";
            }
            
            if (commisionBackupMember[1].ResUser.MilitaryClass != null)
            {
                yedekUye2 += commisionBackupMember[1].ResUser.MilitaryClass.ShortName;
            }
            if (commisionBackupMember[1].ResUser.Rank != null)
            {
                yedekUye2 += commisionBackupMember[1].ResUser.Rank.ShortName + "\r\n";
                //yedekUye2 += "(" + commisionBackupMember[1].ResUser.EmploymentRecordID + ")";
                YEDEKUYE2.CalcValue = yedekUye2;
            }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialRequestFormReport MyParentReport
            {
                get { return (MaterialRequestFormReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField SUTKODU { get {return Body().SUTKODU;} }
            public TTReportField SUTFIYATI { get {return Body().SUTFIYATI;} }
            public TTReportField TALEPCINSI { get {return Body().TALEPCINSI;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField OLCUBIRIMI { get {return Body().OLCUBIRIMI;} }
            public TTReportField SUTKOD { get {return Body().SUTKOD;} }
            public TTReportField TALEPCINS { get {return Body().TALEPCINS;} }
            public TTReportField ISLEMKODU { get {return Body().ISLEMKODU;} }
            public TTReportField RPCMATERIALNAME { get {return Body().RPCMATERIALNAME;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public TTReportField MATCHEDSUTCODE { get {return Body().MATCHEDSUTCODE;} }
            public TTReportField MATCHEDSUTPRICE { get {return Body().MATCHEDSUTPRICE;} }
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
                list[0] = new TTReportNqlData<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class>("MaterialRequestFormReportNQL", DirectPurchaseActionDetail.MaterialRequestFormReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTB.OBJECTID.CalcValue)));
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
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField SUTKODU;
                public TTReportField SUTFIYATI;
                public TTReportField TALEPCINSI;
                public TTReportField MIKTAR;
                public TTReportField OLCUBIRIMI;
                public TTReportField SUTKOD;
                public TTReportField TALEPCINS;
                public TTReportField ISLEMKODU;
                public TTReportField RPCMATERIALNAME;
                public TTReportField CODELESSMATERIALNAME;
                public TTReportField MATCHEDSUTCODE;
                public TTReportField MATCHEDSUTPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 22, 4, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@counter@}";

                    SUTKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 41, 4, false);
                    SUTKODU.Name = "SUTKODU";
                    SUTKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTKODU.ObjectDefName = "ProductSUTMatchDefinition";
                    SUTKODU.DataMember = "SUTCODE";
                    SUTKODU.TextFont.Name = "Arial";
                    SUTKODU.TextFont.Size = 8;
                    SUTKODU.TextFont.CharSet = 162;
                    SUTKODU.Value = @"{#SUTKODU#}";

                    SUTFIYATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 60, 4, false);
                    SUTFIYATI.Name = "SUTFIYATI";
                    SUTFIYATI.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYATI.TextFormat = @"#,##0.#0";
                    SUTFIYATI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTFIYATI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYATI.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYATI.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYATI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTFIYATI.TextFont.Name = "Arial";
                    SUTFIYATI.TextFont.Size = 8;
                    SUTFIYATI.TextFont.CharSet = 162;
                    SUTFIYATI.Value = @"{#SUTFIYAT#}";

                    TALEPCINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 170, 4, false);
                    TALEPCINSI.Name = "TALEPCINSI";
                    TALEPCINSI.DrawStyle = DrawStyleConstants.vbSolid;
                    TALEPCINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TALEPCINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TALEPCINSI.MultiLine = EvetHayirEnum.ehEvet;
                    TALEPCINSI.WordBreak = EvetHayirEnum.ehEvet;
                    TALEPCINSI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TALEPCINSI.TextFont.Name = "Arial";
                    TALEPCINSI.TextFont.Size = 8;
                    TALEPCINSI.TextFont.CharSet = 162;
                    TALEPCINSI.Value = @"{#TALEPCINSI#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 182, 4, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#MIKTAR#}";

                    OLCUBIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 202, 4, false);
                    OLCUBIRIMI.Name = "OLCUBIRIMI";
                    OLCUBIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ObjectDefName = "DistributionTypeDefinition";
                    OLCUBIRIMI.DataMember = "DISTRIBUTIONTYPE";
                    OLCUBIRIMI.TextFont.Name = "Arial";
                    OLCUBIRIMI.TextFont.Size = 8;
                    OLCUBIRIMI.TextFont.CharSet = 162;
                    OLCUBIRIMI.Value = @"{#OLCUBIRIMI#}";

                    SUTKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 226, 4, false);
                    SUTKOD.Name = "SUTKOD";
                    SUTKOD.Visible = EvetHayirEnum.ehHayir;
                    SUTKOD.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTKOD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKOD.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKOD.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTKOD.ObjectDefName = "ProductSUTMatchDefinition";
                    SUTKOD.DataMember = "SUTCODE";
                    SUTKOD.TextFont.Name = "Arial";
                    SUTKOD.TextFont.Size = 8;
                    SUTKOD.TextFont.CharSet = 162;
                    SUTKOD.Value = @"{#SUTKODU#}";

                    TALEPCINS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 247, 4, false);
                    TALEPCINS.Name = "TALEPCINS";
                    TALEPCINS.Visible = EvetHayirEnum.ehHayir;
                    TALEPCINS.DrawStyle = DrawStyleConstants.vbSolid;
                    TALEPCINS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TALEPCINS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TALEPCINS.MultiLine = EvetHayirEnum.ehEvet;
                    TALEPCINS.WordBreak = EvetHayirEnum.ehEvet;
                    TALEPCINS.ExpandTabs = EvetHayirEnum.ehEvet;
                    TALEPCINS.TextFont.Name = "Arial";
                    TALEPCINS.TextFont.Size = 8;
                    TALEPCINS.TextFont.CharSet = 162;
                    TALEPCINS.Value = @"{#TALEPCINSI#}";

                    ISLEMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 263, 4, false);
                    ISLEMKODU.Name = "ISLEMKODU";
                    ISLEMKODU.Visible = EvetHayirEnum.ehHayir;
                    ISLEMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMKODU.TextFont.Name = "Arial";
                    ISLEMKODU.TextFont.Size = 8;
                    ISLEMKODU.TextFont.CharSet = 162;
                    ISLEMKODU.Value = @"{#ISLEMKODU#}";

                    RPCMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 280, 5, false);
                    RPCMATERIALNAME.Name = "RPCMATERIALNAME";
                    RPCMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    RPCMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RPCMATERIALNAME.TextFont.Name = "Arial";
                    RPCMATERIALNAME.TextFont.Size = 8;
                    RPCMATERIALNAME.TextFont.CharSet = 162;
                    RPCMATERIALNAME.Value = @"{#RPCMATERIALNAME#}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 0, 296, 5, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                    MATCHEDSUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 0, 334, 5, false);
                    MATCHEDSUTCODE.Name = "MATCHEDSUTCODE";
                    MATCHEDSUTCODE.Visible = EvetHayirEnum.ehHayir;
                    MATCHEDSUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATCHEDSUTCODE.Value = @"{#MATCHEDSUTCODE#}";

                    MATCHEDSUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 0, 311, 5, false);
                    MATCHEDSUTPRICE.Name = "MATCHEDSUTPRICE";
                    MATCHEDSUTPRICE.Visible = EvetHayirEnum.ehHayir;
                    MATCHEDSUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATCHEDSUTPRICE.Value = @"{#MATCHEDSUTPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class dataset_MaterialRequestFormReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class>(0);
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    SUTKODU.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Sutkodu) : "");
                    SUTKODU.PostFieldValueCalculation();
                    SUTFIYATI.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Sutfiyat) : "");
                    TALEPCINSI.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Talepcinsi) : "");
                    MIKTAR.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Miktar) : "");
                    OLCUBIRIMI.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Olcubirimi) : "");
                    OLCUBIRIMI.PostFieldValueCalculation();
                    SUTKOD.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Sutkodu) : "");
                    SUTKOD.PostFieldValueCalculation();
                    TALEPCINS.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Talepcinsi) : "");
                    ISLEMKODU.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Islemkodu) : "");
                    RPCMATERIALNAME.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Rpcmaterialname) : "");
                    CODELESSMATERIALNAME.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.Codelessmaterialname) : "");
                    MATCHEDSUTCODE.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.MatchedSUTCode) : "");
                    MATCHEDSUTPRICE.CalcValue = (dataset_MaterialRequestFormReportNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNQL.MatchedSUTPrice) : "");
                    return new TTReportObject[] { SIRANO,SUTKODU,SUTFIYATI,TALEPCINSI,MIKTAR,OLCUBIRIMI,SUTKOD,TALEPCINS,ISLEMKODU,RPCMATERIALNAME,CODELESSMATERIALNAME,MATCHEDSUTCODE,MATCHEDSUTPRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((MaterialRequestFormReport)ParentReport).counter++;
            
            TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((MaterialRequestFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DirectPurchaseAction dpa = (DirectPurchaseAction)ctx.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));

            if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.TALEPCINSI.CalcValue = this.RPCMATERIALNAME.CalcValue;
                this.SUTKODU.CalcValue = this.ISLEMKODU.CalcValue;
            }
            else if(dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                this.TALEPCINSI.CalcValue = this.CODELESSMATERIALNAME.CalcValue;
                this.SUTKODU.CalcValue = this.MATCHEDSUTCODE.CalcValue;
                this.SUTFIYATI.CalcValue = this.MATCHEDSUTPRICE.CalcValue;
            }
            else
            {
                this.TALEPCINSI.CalcValue = this.TALEPCINS.CalcValue;
                this.SUTKODU.CalcValue = this.SUTKOD.CalcValue;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class SAYMANLIKGroup : TTReportGroup
        {
            public MaterialRequestFormReport MyParentReport
            {
                get { return (MaterialRequestFormReport)ParentReport; }
            }

            new public SAYMANLIKGroupBody Body()
            {
                return (SAYMANLIKGroupBody)_body;
            }
            public TTReportField FIELD1 { get {return Body().FIELD1;} }
            public TTReportField FIELD2 { get {return Body().FIELD2;} }
            public SAYMANLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SAYMANLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SAYMANLIKGroupBody(this);
            }

            public partial class SAYMANLIKGroupBody : TTReportSection
            {
                public MaterialRequestFormReport MyParentReport
                {
                    get { return (MaterialRequestFormReport)ParentReport; }
                }
                
                public TTReportField FIELD1;
                public TTReportField FIELD2; 
                public SAYMANLIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    RepeatCount = 0;
                    
                    FIELD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 108, 29, false);
                    FIELD1.Name = "FIELD1";
                    FIELD1.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIELD1.TextFont.Name = "Arial";
                    FIELD1.TextFont.Size = 9;
                    FIELD1.TextFont.CharSet = 162;
                    FIELD1.Value = @"Mal Saymanlığı/Saymanlığı Olmayan XXXXXXlerin İkmal Ks.A.liği
(Depo mevcudu olup olmadığı belirtilerek  Sayman/İkm.Ks.A. tarafından imzalanacaktır.)";

                    FIELD2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 202, 29, false);
                    FIELD2.Name = "FIELD2";
                    FIELD2.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIELD2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIELD2.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD2.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD2.ExpandTabs = EvetHayirEnum.ehEvet;
                    FIELD2.TextFont.Name = "Arial";
                    FIELD2.TextFont.CharSet = 162;
                    FIELD2.Value = @"Tarih
......../......../........
Sayman/İkm.Ks.A.
İmza ve Kaşesi
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FIELD1.CalcValue = FIELD1.Value;
                    FIELD2.CalcValue = FIELD2.Value;
                    return new TTReportObject[] { FIELD1,FIELD2};
                }

                public override void RunScript()
                {
#region SAYMANLIK BODY_Script
                    TTObjectContext octx = new TTObjectContext(true);
            string objectID = ((MaterialRequestFormReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DirectPurchaseAction dpa = (DirectPurchaseAction)octx.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            
            if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.FIELD1.Visible = EvetHayirEnum.ehHayir;
                this.FIELD2.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.FIELD1.Visible = EvetHayirEnum.ehEvet;
                this.FIELD2.Visible = EvetHayirEnum.ehEvet;
            }
#endregion SAYMANLIK BODY_Script
                }
            }

        }

        public SAYMANLIKGroup SAYMANLIK;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialRequestFormReport()
        {
            FOOTER = new FOOTERGroup(this,"FOOTER");
            PARTA = new PARTAGroup(FOOTER,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            SAYMANLIK = new SAYMANLIKGroup(PARTA,"SAYMANLIK");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "22F Doğrudan Temin Detay", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MATERIALREQUESTFORMREPORT";
            Caption = "Malzeme  ihtiyaç talep formu";
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