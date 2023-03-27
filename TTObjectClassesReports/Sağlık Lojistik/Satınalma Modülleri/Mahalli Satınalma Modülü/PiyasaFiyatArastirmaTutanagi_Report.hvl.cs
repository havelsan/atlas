
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
    /// Piyasa Fiyat Araştırma Tutanağı
    /// </summary>
    public partial class PiyasaFiyatArastirmaTutanagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class BASLIKGroup : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public BASLIKGroupHeader Header()
            {
                return (BASLIKGroupHeader)_header;
            }

            new public BASLIKGroupFooter Footer()
            {
                return (BASLIKGroupFooter)_footer;
            }

            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField CONFIRMNO { get {return Header().CONFIRMNO;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public BASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new BASLIKGroupHeader(this);
                _footer = new BASLIKGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class BASLIKGroupHeader : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField ACTDEFINE;
                public TTReportField NewField2;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField CONFIRMNO; 
                public BASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 31, 257, 36, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @" {#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 31, 80, 36, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İdarenin Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 36, 80, 41, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Yapılan İş / Mal / Hizmetin Adı, Niteliği";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 41, 80, 50, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Alım ve Yetkilendirilen Görevlilere İlişkin Onay Belgesi / Görevlendirme Onayı Tarih ve No.su";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 36, 257, 41, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @" {#ACTDEFINE#} - {#ACTATTRIBUTE#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 257, 21, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"PİYASA FİYAT ARAŞTIRMASI TUTANAĞI";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 31, 81, 36, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 36, 81, 41, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 45, 81, 50, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 26, 80, 31, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"Tutanak No.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 26, 81, 31, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    CONFIRMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 45, 126, 50, false);
                    CONFIRMNO.Name = "CONFIRMNO";
                    CONFIRMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNO.TextFont.Name = "Arial";
                    CONFIRMNO.Value = @" {#CONFIRMNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = @" " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    ACTDEFINE.CalcValue = @" " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "") + @" - " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActAttribute) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    CONFIRMNO.CalcValue = @" " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmNO) : "");
                    return new TTReportObject[] { RESPONSIBLEPROCUREMENTUNITDEF,NewField3,NewField4,NewField5,ACTDEFINE,NewField2,NewField1,NewField11,NewField12,NewField13,NewField14,CONFIRMNO};
                }
            }
            public partial class BASLIKGroupFooter : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public BASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region BASLIK FOOTER_Script
                    string objectID = ((PiyasaFiyatArastirmaTutanagi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion BASLIK FOOTER_Script
                }
            }

        }

        public BASLIKGroup BASLIK;

        public partial class FIRM1Group : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public FIRM1GroupHeader Header()
            {
                return (FIRM1GroupHeader)_header;
            }

            new public FIRM1GroupFooter Footer()
            {
                return (FIRM1GroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField FIRMAMETIN1 { get {return Header().FIRMAMETIN1;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField FIRMAMETIN2 { get {return Header().FIRMAMETIN2;} }
            public TTReportField FIRMAMETIN3 { get {return Header().FIRMAMETIN3;} }
            public TTReportField FIRMAMETIN0 { get {return Header().FIRMAMETIN0;} }
            public TTReportField MIKTAR { get {return Header().MIKTAR;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField TEKLIF2 { get {return Header().TEKLIF2;} }
            public TTReportField TEKLIF3 { get {return Header().TEKLIF3;} }
            public TTReportField TEKLIF0 { get {return Header().TEKLIF0;} }
            public TTReportField TEKLIF1 { get {return Header().TEKLIF1;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public FIRM1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRM1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FIRM1GroupHeader(this);
                _footer = new FIRM1GroupFooter(this);

            }

            public partial class FIRM1GroupHeader : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField FIRMAMETIN1;
                public TTReportField NewField3;
                public TTReportField FIRMAMETIN2;
                public TTReportField FIRMAMETIN3;
                public TTReportField FIRMAMETIN0;
                public TTReportField MIKTAR;
                public TTReportField ORDERNO;
                public TTReportField TEKLIF2;
                public TTReportField TEKLIF3;
                public TTReportField TEKLIF0;
                public TTReportField TEKLIF1;
                public TTReportField ACTDEFINE;
                public TTReportField AMOUNT;
                public TTReportField TTOBJECTID; 
                public FIRM1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 10, 19, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"S. Nu.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 86, 19, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Mal / Hizmet / Yapım İşi";

                    FIRMAMETIN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 9, 181, 19, false);
                    FIRMAMETIN1.Name = "FIRMAMETIN1";
                    FIRMAMETIN1.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN1.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN1.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN1.TextFont.Name = "Arial";
                    FIRMAMETIN1.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 4, 257, 9, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 9, 219, 19, false);
                    FIRMAMETIN2.Name = "FIRMAMETIN2";
                    FIRMAMETIN2.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN2.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN2.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN2.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN2.TextFont.Name = "Arial";
                    FIRMAMETIN2.Value = @"";

                    FIRMAMETIN3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 9, 257, 19, false);
                    FIRMAMETIN3.Name = "FIRMAMETIN3";
                    FIRMAMETIN3.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN3.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN3.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN3.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN3.TextFont.Name = "Arial";
                    FIRMAMETIN3.Value = @"";

                    FIRMAMETIN0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 9, 143, 19, false);
                    FIRMAMETIN0.Name = "FIRMAMETIN0";
                    FIRMAMETIN0.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN0.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN0.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN0.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN0.TextFont.Name = "Arial";
                    FIRMAMETIN0.Value = @"";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 105, 19, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.Bold = true;
                    MIKTAR.Value = @"MİKTARI";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 10, 29, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@groupcounter@}";

                    TEKLIF2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 19, 219, 29, false);
                    TEKLIF2.Name = "TEKLIF2";
                    TEKLIF2.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF2.TextFormat = @"#,##0.#0";
                    TEKLIF2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF2.TextFont.Name = "Arial";
                    TEKLIF2.Value = @"";

                    TEKLIF3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 19, 257, 29, false);
                    TEKLIF3.Name = "TEKLIF3";
                    TEKLIF3.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF3.TextFormat = @"#,##0.#0";
                    TEKLIF3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF3.TextFont.Name = "Arial";
                    TEKLIF3.Value = @"";

                    TEKLIF0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 143, 29, false);
                    TEKLIF0.Name = "TEKLIF0";
                    TEKLIF0.FillColor = System.Drawing.Color.FromArgb(255,199,199,199);
                    TEKLIF0.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF0.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF0.TextFormat = @"#,##0.#0";
                    TEKLIF0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF0.TextFont.Name = "Arial";
                    TEKLIF0.Value = @"";

                    TEKLIF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 19, 181, 29, false);
                    TEKLIF1.Name = "TEKLIF1";
                    TEKLIF1.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF1.TextFormat = @"#,##0.#0";
                    TEKLIF1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF1.TextFont.Name = "Arial";
                    TEKLIF1.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 86, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{#BASLIK.ACTDEFINE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 105, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 10, 328, 15, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = MyParentReport.BASLIK.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    FIRMAMETIN1.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    FIRMAMETIN2.CalcValue = @"";
                    FIRMAMETIN3.CalcValue = @"";
                    FIRMAMETIN0.CalcValue = @"";
                    MIKTAR.CalcValue = MIKTAR.Value;
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TEKLIF2.CalcValue = @"";
                    TEKLIF3.CalcValue = @"";
                    TEKLIF0.CalcValue = @"";
                    TEKLIF1.CalcValue = @"";
                    ACTDEFINE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "");
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    AMOUNT.CalcValue = @"";
                    return new TTReportObject[] { NewField,NewField2,FIRMAMETIN1,NewField3,FIRMAMETIN2,FIRMAMETIN3,FIRMAMETIN0,MIKTAR,ORDERNO,TEKLIF2,TEKLIF3,TEKLIF0,TEKLIF1,ACTDEFINE,TTOBJECTID,AMOUNT};
                }

                public override void RunScript()
                {
#region FIRM1 HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> proposalList = ProposalDetail.GetTotalPriceForDirectPurchaseQuery(ctx, TTOBJECTID.CalcValue);
            if (proposalList.Count > 0)
            {
                int repeatNO;
                if(proposalList.Count > 4)
                    repeatNO = 4;
                else
                    repeatNO = proposalList.Count;
                
                TTReportField rf;
                for (int i = 0; i < repeatNO; i++)
                {
                    rf = FieldsByName("FIRMAMETIN" + i);
                    rf.CalcValue = proposalList[i].Supplier.ToString();
                    rf = FieldsByName("TEKLIF" + i);
                    rf.CalcValue = proposalList[i].Totalprice.ToString();
                }
                
                PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(TTOBJECTID.CalcValue), typeof(PurchaseProject));
                AMOUNT.CalcValue = pp.PurchaseProjectDetails.Count.ToString() + " Kalem";
            }
#endregion FIRM1 HEADER_Script
                }
            }
            public partial class FIRM1GroupFooter : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                 
                public FIRM1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FIRM1Group FIRM1;

        public partial class FIRM2Group : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public FIRM2GroupBody Body()
            {
                return (FIRM2GroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField FIRMAMETIN5 { get {return Body().FIRMAMETIN5;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField FIRMAMETIN6 { get {return Body().FIRMAMETIN6;} }
            public TTReportField FIRMAMETIN7 { get {return Body().FIRMAMETIN7;} }
            public TTReportField FIRMAMETIN4 { get {return Body().FIRMAMETIN4;} }
            public TTReportField MIKTAR1 { get {return Body().MIKTAR1;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField TEKLIF6 { get {return Body().TEKLIF6;} }
            public TTReportField TEKLIF7 { get {return Body().TEKLIF7;} }
            public TTReportField TEKLIF4 { get {return Body().TEKLIF4;} }
            public TTReportField TEKLIF5 { get {return Body().TEKLIF5;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public FIRM2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRM2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIRM2GroupBody(this);
            }

            public partial class FIRM2GroupBody : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField FIRMAMETIN5;
                public TTReportField NewField13;
                public TTReportField FIRMAMETIN6;
                public TTReportField FIRMAMETIN7;
                public TTReportField FIRMAMETIN4;
                public TTReportField MIKTAR1;
                public TTReportField ORDERNO;
                public TTReportField TEKLIF6;
                public TTReportField TEKLIF7;
                public TTReportField TEKLIF4;
                public TTReportField TEKLIF5;
                public TTReportField ACTDEFINE;
                public TTReportField AMOUNT;
                public TTReportField TTOBJECTID; 
                public FIRM2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 10, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"S. Nu.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 86, 19, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Mal / Hizmet / Yapım İşi";

                    FIRMAMETIN5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 9, 181, 19, false);
                    FIRMAMETIN5.Name = "FIRMAMETIN5";
                    FIRMAMETIN5.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN5.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN5.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN5.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN5.TextFont.Name = "Arial";
                    FIRMAMETIN5.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 4, 257, 9, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 9, 219, 19, false);
                    FIRMAMETIN6.Name = "FIRMAMETIN6";
                    FIRMAMETIN6.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN6.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN6.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN6.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN6.TextFont.Name = "Arial";
                    FIRMAMETIN6.Value = @"";

                    FIRMAMETIN7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 9, 257, 19, false);
                    FIRMAMETIN7.Name = "FIRMAMETIN7";
                    FIRMAMETIN7.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN7.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN7.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN7.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN7.TextFont.Name = "Arial";
                    FIRMAMETIN7.Value = @"";

                    FIRMAMETIN4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 9, 143, 19, false);
                    FIRMAMETIN4.Name = "FIRMAMETIN4";
                    FIRMAMETIN4.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN4.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN4.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN4.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN4.TextFont.Name = "Arial";
                    FIRMAMETIN4.Value = @"";

                    MIKTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 105, 19, false);
                    MIKTAR1.Name = "MIKTAR1";
                    MIKTAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1.TextFont.Name = "Arial";
                    MIKTAR1.TextFont.Bold = true;
                    MIKTAR1.Value = @"MİKTARI";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 10, 29, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@groupcounter@}";

                    TEKLIF6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 19, 219, 29, false);
                    TEKLIF6.Name = "TEKLIF6";
                    TEKLIF6.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF6.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF6.TextFormat = @"#,##0.#0";
                    TEKLIF6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF6.TextFont.Name = "Arial";
                    TEKLIF6.Value = @"";

                    TEKLIF7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 19, 257, 29, false);
                    TEKLIF7.Name = "TEKLIF7";
                    TEKLIF7.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF7.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF7.TextFormat = @"#,##0.#0";
                    TEKLIF7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF7.TextFont.Name = "Arial";
                    TEKLIF7.Value = @"";

                    TEKLIF4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 143, 29, false);
                    TEKLIF4.Name = "TEKLIF4";
                    TEKLIF4.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF4.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF4.TextFormat = @"#,##0.#0";
                    TEKLIF4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF4.TextFont.Name = "Arial";
                    TEKLIF4.Value = @"";

                    TEKLIF5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 19, 181, 29, false);
                    TEKLIF5.Name = "TEKLIF5";
                    TEKLIF5.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF5.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF5.TextFormat = @"#,##0.#0";
                    TEKLIF5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF5.TextFont.Name = "Arial";
                    TEKLIF5.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 86, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{%FIRM1.ACTDEFINE%}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 105, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{%FIRM1.AMOUNT%}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 10, 328, 15, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    FIRMAMETIN5.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    FIRMAMETIN6.CalcValue = @"";
                    FIRMAMETIN7.CalcValue = @"";
                    FIRMAMETIN4.CalcValue = @"";
                    MIKTAR1.CalcValue = MIKTAR1.Value;
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TEKLIF6.CalcValue = @"";
                    TEKLIF7.CalcValue = @"";
                    TEKLIF4.CalcValue = @"";
                    TEKLIF5.CalcValue = @"";
                    ACTDEFINE.CalcValue = MyParentReport.FIRM1.ACTDEFINE.CalcValue;
                    AMOUNT.CalcValue = MyParentReport.FIRM1.AMOUNT.CalcValue;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { NewField1,NewField12,FIRMAMETIN5,NewField13,FIRMAMETIN6,FIRMAMETIN7,FIRMAMETIN4,MIKTAR1,ORDERNO,TEKLIF6,TEKLIF7,TEKLIF4,TEKLIF5,ACTDEFINE,AMOUNT,TTOBJECTID};
                }

                public override void RunScript()
                {
#region FIRM2 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> proposalList = ProposalDetail.GetTotalPriceForDirectPurchaseQuery(ctx, TTOBJECTID.CalcValue);
                    if (proposalList.Count > 4)
                    {
                        this.Visible = EvetHayirEnum.ehEvet;
                        int repeatNO;
                        if(proposalList.Count > 8)
                            repeatNO = 8;
                        else
                            repeatNO = proposalList.Count;

                        TTReportField rf;
                        for (int i = 4; i < repeatNO; i++)
                        {
                            rf = FieldsByName("FIRMAMETIN" + i);
                            rf.CalcValue = proposalList[i].Supplier.ToString();
                            rf = FieldsByName("TEKLIF" + i);
                            rf.CalcValue = proposalList[i].Totalprice.ToString();
                        }
                    }
#endregion FIRM2 BODY_Script
                }
            }

        }

        public FIRM2Group FIRM2;

        public partial class FIRM3Group : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public FIRM3GroupBody Body()
            {
                return (FIRM3GroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField FIRMAMETIN9 { get {return Body().FIRMAMETIN9;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField FIRMAMETIN10 { get {return Body().FIRMAMETIN10;} }
            public TTReportField FIRMAMETIN11 { get {return Body().FIRMAMETIN11;} }
            public TTReportField FIRMAMETIN8 { get {return Body().FIRMAMETIN8;} }
            public TTReportField MIKTAR11 { get {return Body().MIKTAR11;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField TEKLIF10 { get {return Body().TEKLIF10;} }
            public TTReportField TEKLIF11 { get {return Body().TEKLIF11;} }
            public TTReportField TEKLIF8 { get {return Body().TEKLIF8;} }
            public TTReportField TEKLIF9 { get {return Body().TEKLIF9;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public FIRM3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRM3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIRM3GroupBody(this);
            }

            public partial class FIRM3GroupBody : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField FIRMAMETIN9;
                public TTReportField NewField131;
                public TTReportField FIRMAMETIN10;
                public TTReportField FIRMAMETIN11;
                public TTReportField FIRMAMETIN8;
                public TTReportField MIKTAR11;
                public TTReportField ORDERNO;
                public TTReportField TEKLIF10;
                public TTReportField TEKLIF11;
                public TTReportField TEKLIF8;
                public TTReportField TEKLIF9;
                public TTReportField ACTDEFINE;
                public TTReportField AMOUNT;
                public TTReportField TTOBJECTID; 
                public FIRM3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 10, 19, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"S. Nu.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 86, 19, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Mal / Hizmet / Yapım İşi";

                    FIRMAMETIN9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 9, 181, 19, false);
                    FIRMAMETIN9.Name = "FIRMAMETIN9";
                    FIRMAMETIN9.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN9.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN9.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN9.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN9.TextFont.Name = "Arial";
                    FIRMAMETIN9.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 4, 257, 9, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 9, 219, 19, false);
                    FIRMAMETIN10.Name = "FIRMAMETIN10";
                    FIRMAMETIN10.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN10.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN10.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN10.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN10.TextFont.Name = "Arial";
                    FIRMAMETIN10.Value = @"";

                    FIRMAMETIN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 9, 257, 19, false);
                    FIRMAMETIN11.Name = "FIRMAMETIN11";
                    FIRMAMETIN11.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN11.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN11.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN11.TextFont.Name = "Arial";
                    FIRMAMETIN11.Value = @"";

                    FIRMAMETIN8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 9, 143, 19, false);
                    FIRMAMETIN8.Name = "FIRMAMETIN8";
                    FIRMAMETIN8.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN8.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN8.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN8.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN8.TextFont.Name = "Arial";
                    FIRMAMETIN8.Value = @"";

                    MIKTAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 105, 19, false);
                    MIKTAR11.Name = "MIKTAR11";
                    MIKTAR11.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR11.TextFont.Name = "Arial";
                    MIKTAR11.TextFont.Bold = true;
                    MIKTAR11.Value = @"MİKTARI";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 10, 29, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@groupcounter@}";

                    TEKLIF10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 19, 219, 29, false);
                    TEKLIF10.Name = "TEKLIF10";
                    TEKLIF10.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF10.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF10.TextFormat = @"#,##0.#0";
                    TEKLIF10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF10.TextFont.Name = "Arial";
                    TEKLIF10.Value = @"";

                    TEKLIF11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 19, 257, 29, false);
                    TEKLIF11.Name = "TEKLIF11";
                    TEKLIF11.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF11.TextFormat = @"#,##0.#0";
                    TEKLIF11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF11.TextFont.Name = "Arial";
                    TEKLIF11.Value = @"";

                    TEKLIF8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 143, 29, false);
                    TEKLIF8.Name = "TEKLIF8";
                    TEKLIF8.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF8.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF8.TextFormat = @"#,##0.#0";
                    TEKLIF8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF8.TextFont.Name = "Arial";
                    TEKLIF8.Value = @"";

                    TEKLIF9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 19, 181, 29, false);
                    TEKLIF9.Name = "TEKLIF9";
                    TEKLIF9.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF9.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF9.TextFormat = @"#,##0.#0";
                    TEKLIF9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF9.TextFont.Name = "Arial";
                    TEKLIF9.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 86, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{%FIRM1.ACTDEFINE%}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 105, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{%FIRM1.AMOUNT%}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 9, 332, 14, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    FIRMAMETIN9.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    FIRMAMETIN10.CalcValue = @"";
                    FIRMAMETIN11.CalcValue = @"";
                    FIRMAMETIN8.CalcValue = @"";
                    MIKTAR11.CalcValue = MIKTAR11.Value;
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TEKLIF10.CalcValue = @"";
                    TEKLIF11.CalcValue = @"";
                    TEKLIF8.CalcValue = @"";
                    TEKLIF9.CalcValue = @"";
                    ACTDEFINE.CalcValue = MyParentReport.FIRM1.ACTDEFINE.CalcValue;
                    AMOUNT.CalcValue = MyParentReport.FIRM1.AMOUNT.CalcValue;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { NewField11,NewField121,FIRMAMETIN9,NewField131,FIRMAMETIN10,FIRMAMETIN11,FIRMAMETIN8,MIKTAR11,ORDERNO,TEKLIF10,TEKLIF11,TEKLIF8,TEKLIF9,ACTDEFINE,AMOUNT,TTOBJECTID};
                }

                public override void RunScript()
                {
#region FIRM3 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> proposalList = ProposalDetail.GetTotalPriceForDirectPurchaseQuery(ctx, TTOBJECTID.CalcValue);
                    if (proposalList.Count > 8)
                    {
                        this.Visible = EvetHayirEnum.ehEvet;
                        int repeatNO;
                        if(proposalList.Count > 12)
                            repeatNO = 12;
                        else
                            repeatNO = proposalList.Count;

                        TTReportField rf;
                        for (int i = 8; i < repeatNO; i++)
                        {
                            rf = FieldsByName("FIRMAMETIN" + i);
                            rf.CalcValue = proposalList[i].Supplier.ToString();
                            rf = FieldsByName("TEKLIF" + i);
                            rf.CalcValue = proposalList[i].Totalprice.ToString();
                        }
                    }
#endregion FIRM3 BODY_Script
                }
            }

        }

        public FIRM3Group FIRM3;

        public partial class FIRM4Group : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public FIRM4GroupBody Body()
            {
                return (FIRM4GroupBody)_body;
            }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField FIRMAMETIN13 { get {return Body().FIRMAMETIN13;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField FIRMAMETIN14 { get {return Body().FIRMAMETIN14;} }
            public TTReportField FIRMAMETIN15 { get {return Body().FIRMAMETIN15;} }
            public TTReportField FIRMAMETIN12 { get {return Body().FIRMAMETIN12;} }
            public TTReportField MIKTAR111 { get {return Body().MIKTAR111;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField TEKLIF14 { get {return Body().TEKLIF14;} }
            public TTReportField TEKLIF15 { get {return Body().TEKLIF15;} }
            public TTReportField TEKLIF12 { get {return Body().TEKLIF12;} }
            public TTReportField TEKLIF13 { get {return Body().TEKLIF13;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public FIRM4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRM4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIRM4GroupBody(this);
            }

            public partial class FIRM4GroupBody : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField FIRMAMETIN13;
                public TTReportField NewField1131;
                public TTReportField FIRMAMETIN14;
                public TTReportField FIRMAMETIN15;
                public TTReportField FIRMAMETIN12;
                public TTReportField MIKTAR111;
                public TTReportField ORDERNO;
                public TTReportField TEKLIF14;
                public TTReportField TEKLIF15;
                public TTReportField TEKLIF12;
                public TTReportField TEKLIF13;
                public TTReportField ACTDEFINE;
                public TTReportField AMOUNT;
                public TTReportField TTOBJECTID; 
                public FIRM4GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 10, 19, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"S. Nu.";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 86, 19, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Mal / Hizmet / Yapım İşi";

                    FIRMAMETIN13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 9, 181, 19, false);
                    FIRMAMETIN13.Name = "FIRMAMETIN13";
                    FIRMAMETIN13.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN13.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN13.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN13.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN13.TextFont.Name = "Arial";
                    FIRMAMETIN13.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 4, 257, 9, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 9, 219, 19, false);
                    FIRMAMETIN14.Name = "FIRMAMETIN14";
                    FIRMAMETIN14.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN14.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN14.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN14.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN14.TextFont.Name = "Arial";
                    FIRMAMETIN14.Value = @"";

                    FIRMAMETIN15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 9, 257, 19, false);
                    FIRMAMETIN15.Name = "FIRMAMETIN15";
                    FIRMAMETIN15.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN15.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN15.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN15.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN15.TextFont.Name = "Arial";
                    FIRMAMETIN15.Value = @"";

                    FIRMAMETIN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 9, 143, 19, false);
                    FIRMAMETIN12.Name = "FIRMAMETIN12";
                    FIRMAMETIN12.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN12.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN12.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN12.TextFont.Name = "Arial";
                    FIRMAMETIN12.Value = @"";

                    MIKTAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 105, 19, false);
                    MIKTAR111.Name = "MIKTAR111";
                    MIKTAR111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR111.TextFont.Name = "Arial";
                    MIKTAR111.TextFont.Bold = true;
                    MIKTAR111.Value = @"MİKTARI";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 10, 29, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@groupcounter@}";

                    TEKLIF14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 19, 219, 29, false);
                    TEKLIF14.Name = "TEKLIF14";
                    TEKLIF14.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF14.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF14.TextFormat = @"#,##0.#0";
                    TEKLIF14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF14.TextFont.Name = "Arial";
                    TEKLIF14.Value = @"";

                    TEKLIF15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 19, 257, 29, false);
                    TEKLIF15.Name = "TEKLIF15";
                    TEKLIF15.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF15.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF15.TextFormat = @"#,##0.#0";
                    TEKLIF15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF15.TextFont.Name = "Arial";
                    TEKLIF15.Value = @"";

                    TEKLIF12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 143, 29, false);
                    TEKLIF12.Name = "TEKLIF12";
                    TEKLIF12.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF12.TextFormat = @"#,##0.#0";
                    TEKLIF12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF12.TextFont.Name = "Arial";
                    TEKLIF12.Value = @"";

                    TEKLIF13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 19, 181, 29, false);
                    TEKLIF13.Name = "TEKLIF13";
                    TEKLIF13.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF13.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF13.TextFormat = @"#,##0.#0";
                    TEKLIF13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF13.TextFont.Name = "Arial";
                    TEKLIF13.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 86, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{%FIRM1.ACTDEFINE%}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 105, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{%FIRM1.AMOUNT%}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 12, 335, 17, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    FIRMAMETIN13.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    FIRMAMETIN14.CalcValue = @"";
                    FIRMAMETIN15.CalcValue = @"";
                    FIRMAMETIN12.CalcValue = @"";
                    MIKTAR111.CalcValue = MIKTAR111.Value;
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TEKLIF14.CalcValue = @"";
                    TEKLIF15.CalcValue = @"";
                    TEKLIF12.CalcValue = @"";
                    TEKLIF13.CalcValue = @"";
                    ACTDEFINE.CalcValue = MyParentReport.FIRM1.ACTDEFINE.CalcValue;
                    AMOUNT.CalcValue = MyParentReport.FIRM1.AMOUNT.CalcValue;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { NewField111,NewField1121,FIRMAMETIN13,NewField1131,FIRMAMETIN14,FIRMAMETIN15,FIRMAMETIN12,MIKTAR111,ORDERNO,TEKLIF14,TEKLIF15,TEKLIF12,TEKLIF13,ACTDEFINE,AMOUNT,TTOBJECTID};
                }

                public override void RunScript()
                {
#region FIRM4 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> proposalList = ProposalDetail.GetTotalPriceForDirectPurchaseQuery(ctx, TTOBJECTID.CalcValue);
                    if (proposalList.Count > 12)
                    {
                        this.Visible = EvetHayirEnum.ehEvet;
                        int repeatNO;
                        if(proposalList.Count > 16)
                            repeatNO = 16;
                        else
                            repeatNO = proposalList.Count;

                        TTReportField rf;
                        for (int i = 12; i < repeatNO; i++)
                        {
                            rf = FieldsByName("FIRMAMETIN" + i);
                            rf.CalcValue = proposalList[i].Supplier.ToString();
                            rf = FieldsByName("TEKLIF" + i);
                            rf.CalcValue = proposalList[i].Totalprice.ToString();
                        }
                    }
#endregion FIRM4 BODY_Script
                }
            }

        }

        public FIRM4Group FIRM4;

        public partial class FIRM5Group : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public FIRM5GroupBody Body()
            {
                return (FIRM5GroupBody)_body;
            }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField FIRMAMETIN17 { get {return Body().FIRMAMETIN17;} }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField FIRMAMETIN18 { get {return Body().FIRMAMETIN18;} }
            public TTReportField FIRMAMETIN19 { get {return Body().FIRMAMETIN19;} }
            public TTReportField FIRMAMETIN16 { get {return Body().FIRMAMETIN16;} }
            public TTReportField MIKTAR1111 { get {return Body().MIKTAR1111;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField TEKLIF18 { get {return Body().TEKLIF18;} }
            public TTReportField TEKLIF19 { get {return Body().TEKLIF19;} }
            public TTReportField TEKLIF16 { get {return Body().TEKLIF16;} }
            public TTReportField TEKLIF17 { get {return Body().TEKLIF17;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public FIRM5Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRM5Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIRM5GroupBody(this);
            }

            public partial class FIRM5GroupBody : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField11211;
                public TTReportField FIRMAMETIN17;
                public TTReportField NewField11311;
                public TTReportField FIRMAMETIN18;
                public TTReportField FIRMAMETIN19;
                public TTReportField FIRMAMETIN16;
                public TTReportField MIKTAR1111;
                public TTReportField ORDERNO;
                public TTReportField TEKLIF18;
                public TTReportField TEKLIF19;
                public TTReportField TEKLIF16;
                public TTReportField TEKLIF17;
                public TTReportField ACTDEFINE;
                public TTReportField AMOUNT;
                public TTReportField TTOBJECTID; 
                public FIRM5GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 10, 19, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"
S.
Nu.";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 86, 19, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Mal / Hizmet / Yapım İşi";

                    FIRMAMETIN17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 9, 181, 19, false);
                    FIRMAMETIN17.Name = "FIRMAMETIN17";
                    FIRMAMETIN17.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN17.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN17.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN17.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN17.TextFont.Name = "Arial";
                    FIRMAMETIN17.Value = @"";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 4, 257, 9, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 9, 219, 19, false);
                    FIRMAMETIN18.Name = "FIRMAMETIN18";
                    FIRMAMETIN18.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN18.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN18.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN18.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN18.TextFont.Name = "Arial";
                    FIRMAMETIN18.Value = @"";

                    FIRMAMETIN19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 9, 257, 19, false);
                    FIRMAMETIN19.Name = "FIRMAMETIN19";
                    FIRMAMETIN19.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN19.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN19.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN19.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN19.TextFont.Name = "Arial";
                    FIRMAMETIN19.Value = @"";

                    FIRMAMETIN16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 9, 143, 19, false);
                    FIRMAMETIN16.Name = "FIRMAMETIN16";
                    FIRMAMETIN16.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN16.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN16.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN16.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN16.TextFont.Name = "Arial";
                    FIRMAMETIN16.Value = @"";

                    MIKTAR1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 105, 19, false);
                    MIKTAR1111.Name = "MIKTAR1111";
                    MIKTAR1111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1111.TextFont.Name = "Arial";
                    MIKTAR1111.TextFont.Bold = true;
                    MIKTAR1111.Value = @"MİKTARI";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 10, 29, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@groupcounter@}";

                    TEKLIF18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 19, 219, 29, false);
                    TEKLIF18.Name = "TEKLIF18";
                    TEKLIF18.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF18.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF18.TextFormat = @"#,##0.#0";
                    TEKLIF18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF18.TextFont.Name = "Arial";
                    TEKLIF18.Value = @"";

                    TEKLIF19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 19, 257, 29, false);
                    TEKLIF19.Name = "TEKLIF19";
                    TEKLIF19.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF19.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF19.TextFormat = @"#,##0.#0";
                    TEKLIF19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF19.TextFont.Name = "Arial";
                    TEKLIF19.Value = @"";

                    TEKLIF16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 143, 29, false);
                    TEKLIF16.Name = "TEKLIF16";
                    TEKLIF16.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF16.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF16.TextFormat = @"#,##0.#0";
                    TEKLIF16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF16.TextFont.Name = "Arial";
                    TEKLIF16.Value = @"";

                    TEKLIF17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 19, 181, 29, false);
                    TEKLIF17.Name = "TEKLIF17";
                    TEKLIF17.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKLIF17.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKLIF17.TextFormat = @"#,##0.#0";
                    TEKLIF17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKLIF17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKLIF17.TextFont.Name = "Arial";
                    TEKLIF17.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 86, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{%FIRM1.ACTDEFINE%}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 105, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{%FIRM1.AMOUNT%}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 16, 337, 21, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    FIRMAMETIN17.CalcValue = @"";
                    NewField11311.CalcValue = NewField11311.Value;
                    FIRMAMETIN18.CalcValue = @"";
                    FIRMAMETIN19.CalcValue = @"";
                    FIRMAMETIN16.CalcValue = @"";
                    MIKTAR1111.CalcValue = MIKTAR1111.Value;
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TEKLIF18.CalcValue = @"";
                    TEKLIF19.CalcValue = @"";
                    TEKLIF16.CalcValue = @"";
                    TEKLIF17.CalcValue = @"";
                    ACTDEFINE.CalcValue = MyParentReport.FIRM1.ACTDEFINE.CalcValue;
                    AMOUNT.CalcValue = MyParentReport.FIRM1.AMOUNT.CalcValue;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { NewField1111,NewField11211,FIRMAMETIN17,NewField11311,FIRMAMETIN18,FIRMAMETIN19,FIRMAMETIN16,MIKTAR1111,ORDERNO,TEKLIF18,TEKLIF19,TEKLIF16,TEKLIF17,ACTDEFINE,AMOUNT,TTOBJECTID};
                }

                public override void RunScript()
                {
#region FIRM5 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> proposalList = ProposalDetail.GetTotalPriceForDirectPurchaseQuery(ctx, TTOBJECTID.CalcValue);
                    if (proposalList.Count > 16)
                    {
                        this.Visible = EvetHayirEnum.ehEvet;
                        int repeatNO;
                        if(proposalList.Count > 20)
                            repeatNO = 20;
                        else
                            repeatNO = proposalList.Count;

                        TTReportField rf;
                        for (int i = 16; i < repeatNO; i++)
                        {
                            rf = FieldsByName("FIRMAMETIN" + i);
                            rf.CalcValue = proposalList[i].Supplier.ToString();
                            rf = FieldsByName("TEKLIF" + i);
                            rf.CalcValue = proposalList[i].Totalprice.ToString();
                        }
                    }
#endregion FIRM5 BODY_Script
                }
            }

        }

        public FIRM5Group FIRM5;

        public partial class WINNERGroup : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public WINNERGroupBody Body()
            {
                return (WINNERGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField ADDRESS { get {return Body().ADDRESS;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField ADI1 { get {return Body().ADI1;} }
            public TTReportField ADRESI1 { get {return Body().ADRESI1;} }
            public TTReportField MIKTAR111 { get {return Body().MIKTAR111;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField KANUN { get {return Body().KANUN;} }
            public WINNERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public WINNERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new WINNERGroupBody(this);
            }

            public partial class WINNERGroupBody : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField SUPPLIER;
                public TTReportField ADDRESS;
                public TTReportField ACTDEFINE;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField ADI1;
                public TTReportField ADRESI1;
                public TTReportField MIKTAR111;
                public TTReportField AMOUNT;
                public TTReportField TTOBJECTID;
                public TTReportField KANUN; 
                public WINNERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 46;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 10, 29, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"{@groupcounter@}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 19, 164, 29, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 19, 257, 29, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.TextFont.Name = "Arial";
                    ADDRESS.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 86, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{%FIRM1.ACTDEFINE%}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 10, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"S. Nu.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 86, 19, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Mal / Hizmet / Yapım İşi";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 4, 257, 9, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"Uygun Görülen Kişi / Firma / Firmalar";

                    ADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 9, 164, 19, false);
                    ADI1.Name = "ADI1";
                    ADI1.DrawStyle = DrawStyleConstants.vbSolid;
                    ADI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADI1.MultiLine = EvetHayirEnum.ehEvet;
                    ADI1.WordBreak = EvetHayirEnum.ehEvet;
                    ADI1.TextFont.Name = "Arial";
                    ADI1.TextFont.Bold = true;
                    ADI1.Value = @"Adı";

                    ADRESI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 9, 257, 19, false);
                    ADRESI1.Name = "ADRESI1";
                    ADRESI1.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRESI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADRESI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRESI1.MultiLine = EvetHayirEnum.ehEvet;
                    ADRESI1.WordBreak = EvetHayirEnum.ehEvet;
                    ADRESI1.TextFont.Name = "Arial";
                    ADRESI1.TextFont.Bold = true;
                    ADRESI1.Value = @"Adresi";

                    MIKTAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 105, 19, false);
                    MIKTAR111.Name = "MIKTAR111";
                    MIKTAR111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR111.TextFont.Name = "Arial";
                    MIKTAR111.TextFont.Bold = true;
                    MIKTAR111.Value = @"MİKTARI";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 19, 105, 29, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{%FIRM1.AMOUNT%}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 315, 13, 340, 18, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                    KANUN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 33, 257, 43, false);
                    KANUN.Name = "KANUN";
                    KANUN.DrawStyle = DrawStyleConstants.vbSolid;
                    KANUN.MultiLine = EvetHayirEnum.ehEvet;
                    KANUN.WordBreak = EvetHayirEnum.ehEvet;
                    KANUN.TextFont.Name = "Arial";
                    KANUN.Value = @"     4734 sayılı Kamu İhale Kanunu'nun 22/d maddesi uyarınca doğrudan temin usulü ile yapılacak alımlara ilişkin yapılan piyasa araştırmasında firmalarca/kişilerce teklif edilen fiyatlar tarafımızca değerlendirilerek yukarıda adı ve adresleri belirtilen  kişi/kişilerden alım yapılması uygun görülmüştür.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    SUPPLIER.CalcValue = @"";
                    ADDRESS.CalcValue = @"";
                    ACTDEFINE.CalcValue = MyParentReport.FIRM1.ACTDEFINE.CalcValue;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    ADI1.CalcValue = ADI1.Value;
                    ADRESI1.CalcValue = ADRESI1.Value;
                    MIKTAR111.CalcValue = MIKTAR111.Value;
                    AMOUNT.CalcValue = MyParentReport.FIRM1.AMOUNT.CalcValue;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    KANUN.CalcValue = KANUN.Value;
                    return new TTReportObject[] { ORDERNO,SUPPLIER,ADDRESS,ACTDEFINE,NewField1,NewField12,NewField13,ADI1,ADRESI1,MIKTAR111,AMOUNT,TTOBJECTID,KANUN};
                }

                public override void RunScript()
                {
#region WINNER BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> proposalList = ProposalDetail.GetTotalPriceForDirectPurchaseQuery(ctx, TTOBJECTID.CalcValue);
            if(proposalList.Count > 0)
            {
                this.SUPPLIER.CalcValue = proposalList[0].Supplier.ToString();
                this.ADDRESS.CalcValue = proposalList[0].Address.ToString();
            }
#endregion WINNER BODY_Script
                }
            }

        }

        public WINNERGroup WINNER;

        public partial class COMMISIONMEMBERGroup : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public COMMISIONMEMBERGroupHeader Header()
            {
                return (COMMISIONMEMBERGroupHeader)_header;
            }

            new public COMMISIONMEMBERGroupFooter Footer()
            {
                return (COMMISIONMEMBERGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField EXPENSER { get {return Footer().EXPENSER;} }
            public TTReportField EXPENSERRANK { get {return Footer().EXPENSERRANK;} }
            public TTReportField EXPENSERDUTY { get {return Footer().EXPENSERDUTY;} }
            public TTReportField TTOBJECTID { get {return Footer().TTOBJECTID;} }
            public COMMISIONMEMBERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMMISIONMEMBERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new COMMISIONMEMBERGroupHeader(this);
                _footer = new COMMISIONMEMBERGroupFooter(this);

            }

            public partial class COMMISIONMEMBERGroupHeader : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public COMMISIONMEMBERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 4, 257, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Piyasa Fiyat Araştırma Görevlileri";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }
            }
            public partial class COMMISIONMEMBERGroupFooter : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField EXPENSER;
                public TTReportField EXPENSERRANK;
                public TTReportField EXPENSERDUTY;
                public TTReportField TTOBJECTID; 
                public COMMISIONMEMBERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 39;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 1, 202, 11, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.Value = @"HARCAMA YETKİLİSİ
_ _/_ _/_ _ _ _";

                    EXPENSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 11, 202, 16, false);
                    EXPENSER.Name = "EXPENSER";
                    EXPENSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPENSER.CaseFormat = CaseFormatEnum.fcNameSurname;
                    EXPENSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPENSER.NoClip = EvetHayirEnum.ehEvet;
                    EXPENSER.TextFont.Name = "Arial";
                    EXPENSER.Value = @"";

                    EXPENSERRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 16, 202, 21, false);
                    EXPENSERRANK.Name = "EXPENSERRANK";
                    EXPENSERRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPENSERRANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    EXPENSERRANK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPENSERRANK.NoClip = EvetHayirEnum.ehEvet;
                    EXPENSERRANK.TextFont.Name = "Arial";
                    EXPENSERRANK.Value = @"";

                    EXPENSERDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 21, 202, 26, false);
                    EXPENSERDUTY.Name = "EXPENSERDUTY";
                    EXPENSERDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPENSERDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    EXPENSERDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPENSERDUTY.NoClip = EvetHayirEnum.ehEvet;
                    EXPENSERDUTY.TextFont.Name = "Arial";
                    EXPENSERDUTY.Value = @"";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 322, 13, 347, 18, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    EXPENSER.CalcValue = @"";
                    EXPENSERRANK.CalcValue = @"";
                    EXPENSERDUTY.CalcValue = @"";
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { NewField2,EXPENSER,EXPENSERRANK,EXPENSERDUTY,TTOBJECTID};
                }

                public override void RunScript()
                {
#region COMMISIONMEMBER FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(TTOBJECTID.CalcValue), typeof(PurchaseProject));
            if(pp.Expenser != null)
            {
                EXPENSER.CalcValue = pp.Expenser.Name.ToString();
                EXPENSERRANK.CalcValue = pp.Expenser.Rank.ShortName.ToString();
                EXPENSERDUTY.CalcValue = pp.ExpenserDuty.ToString();
            }
#endregion COMMISIONMEMBER FOOTER_Script
                }
            }

        }

        public COMMISIONMEMBERGroup COMMISIONMEMBER;

        public partial class COMMISIONGroup : TTReportGroup
        {
            public PiyasaFiyatArastirmaTutanagi MyParentReport
            {
                get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
            }

            new public COMMISIONGroupBody Body()
            {
                return (COMMISIONGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public COMMISIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMMISIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class>("GetDirectPurchaseCommisionMembersQuery", PurchaseProject.GetDirectPurchaseCommisionMembersQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new COMMISIONGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class COMMISIONGroupBody : TTReportSection
            {
                public PiyasaFiyatArastirmaTutanagi MyParentReport
                {
                    get { return (PiyasaFiyatArastirmaTutanagi)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public COMMISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 5;
                    RepeatWidth = 47;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 12, 53, 16, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 17, 53, 21, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 53, 6, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 53, 11, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK.NoClip = EvetHayirEnum.ehEvet;
                    RANK.TextFont.Name = "Arial";
                    RANK.Value = @"{#RANK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class dataset_GetDirectPurchaseCommisionMembersQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class>(0);
                    NAMESURNAME.CalcValue = (dataset_GetDirectPurchaseCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetDirectPurchaseCommisionMembersQuery.Namesurname) : "");
                    HOSPFUNC.CalcValue = (dataset_GetDirectPurchaseCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetDirectPurchaseCommisionMembersQuery.Hospfunc) : "");
                    HOSPFUNC.PostFieldValueCalculation();
                    COMFUNC.CalcValue = (dataset_GetDirectPurchaseCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetDirectPurchaseCommisionMembersQuery.Comfunc) : "");
                    COMFUNC.PostFieldValueCalculation();
                    RANK.CalcValue = (dataset_GetDirectPurchaseCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetDirectPurchaseCommisionMembersQuery.Rank) : "");
                    return new TTReportObject[] { NAMESURNAME,HOSPFUNC,COMFUNC,RANK};
                }
            }

        }

        public COMMISIONGroup COMMISION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PiyasaFiyatArastirmaTutanagi()
        {
            BASLIK = new BASLIKGroup(this,"BASLIK");
            FIRM1 = new FIRM1Group(BASLIK,"FIRM1");
            FIRM2 = new FIRM2Group(FIRM1,"FIRM2");
            FIRM3 = new FIRM3Group(FIRM1,"FIRM3");
            FIRM4 = new FIRM4Group(FIRM1,"FIRM4");
            FIRM5 = new FIRM5Group(FIRM1,"FIRM5");
            WINNER = new WINNERGroup(FIRM1,"WINNER");
            COMMISIONMEMBER = new COMMISIONMEMBERGroup(FIRM1,"COMMISIONMEMBER");
            COMMISION = new COMMISIONGroup(COMMISIONMEMBER,"COMMISION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PIYASAFIYATARASTIRMATUTANAGI";
            Caption = "Piyasa Fiyat Araştırma Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
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