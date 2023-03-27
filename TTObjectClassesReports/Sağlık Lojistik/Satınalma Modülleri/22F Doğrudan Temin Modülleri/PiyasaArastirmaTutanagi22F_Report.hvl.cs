
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
    /// Piyasa Araştırma Tutanağı
    /// </summary>
    public partial class PiyasaArastirmaTutanagi22F : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class AGroup : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public AGroupHeader Header()
            {
                return (AGroupHeader)_header;
            }

            new public AGroupFooter Footer()
            {
                return (AGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public AGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public AGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new AGroupHeader(this);
                _footer = new AGroupFooter(this);

            }

            public partial class AGroupHeader : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public AGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 2, 279, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"{@pagenumber@} / {@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField11};
                }
            }
            public partial class AGroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                 
                public AGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public AGroup A;

        public partial class BASLIKGroup : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public BASLIKGroupHeader Header()
            {
                return (BASLIKGroupHeader)_header;
            }

            new public BASLIKGroupFooter Footer()
            {
                return (BASLIKGroupFooter)_footer;
            }

            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField CONFIRMNO { get {return Header().CONFIRMNO;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField HASTAISIM { get {return Header().HASTAISIM;} }
            public TTReportField HASTAPROTNO { get {return Header().HASTAPROTNO;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField UZMANLIKDALI { get {return Header().UZMANLIKDALI;} }
            public TTReportField FOREIGN { get {return Header().FOREIGN;} }
            public TTReportField FOREIGNUNIQUENUMBER { get {return Header().FOREIGNUNIQUENUMBER;} }
            public TTReportField KANUN11 { get {return Footer().KANUN11;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
            public TTReportField NewField1122 { get {return Footer().NewField1122;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField BASKANUNVAN { get {return Footer().BASKANUNVAN;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField UYE2 { get {return Footer().UYE2;} }
            public TTReportField UYE1UNVAN { get {return Footer().UYE1UNVAN;} }
            public TTReportField UYE2UNVAN { get {return Footer().UYE2UNVAN;} }
            public TTReportField TTOBJECTID { get {return Footer().TTOBJECTID;} }
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
                list[0] = new TTReportNqlData<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>("MaterialRequestFormReportNewNQL", DirectPurchaseAction.MaterialRequestFormReportNewNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField ACTDEFINE;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField CONFIRMNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAISIM;
                public TTReportField HASTAPROTNO;
                public TTReportField OBJECTID;
                public TTReportField UZMANLIKDALI;
                public TTReportField FOREIGN;
                public TTReportField FOREIGNUNIQUENUMBER; 
                public BASLIKGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 259, 6, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"PİYASA FİYAT ARAŞTIRMASI TUTANAĞI";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 8, 279, 13, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftExpression;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Size = 7;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.CharSet = 162;
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 8, 82, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 7;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İDARENİN ADI";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 13, 82, 18, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 7;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"YAPILAN İŞ/MAL/HİZMET ADI NİTELİĞİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 20, 82, 29, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 7;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"ALIM VE YETKİLENDİRİLEN GÖREVLİLERE ONAY BELGESİ / GÖREVLENDİRME ONAYI TARİHİ";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 13, 279, 18, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.TextFont.Size = 7;
                    ACTDEFINE.TextFont.CharSet = 162;
                    ACTDEFINE.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 8, 83, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 7;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 13, 83, 18, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 7;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 24, 83, 29, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 7;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    CONFIRMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 24, 128, 29, false);
                    CONFIRMNO.Name = "CONFIRMNO";
                    CONFIRMNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNO.TextFont.Name = "Arial";
                    CONFIRMNO.TextFont.Size = 7;
                    CONFIRMNO.TextFont.Bold = true;
                    CONFIRMNO.TextFont.CharSet = 162;
                    CONFIRMNO.Value = @".../.../20..    4590 - .....-../";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 7, 330, 12, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 7;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    HASTAISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 13, 330, 18, false);
                    HASTAISIM.Name = "HASTAISIM";
                    HASTAISIM.Visible = EvetHayirEnum.ehHayir;
                    HASTAISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAISIM.TextFont.Name = "Arial";
                    HASTAISIM.TextFont.Size = 7;
                    HASTAISIM.TextFont.CharSet = 162;
                    HASTAISIM.Value = @"{#HASTAISIM#} {#HASTASOYISIM#}";

                    HASTAPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 19, 330, 24, false);
                    HASTAPROTNO.Name = "HASTAPROTNO";
                    HASTAPROTNO.Visible = EvetHayirEnum.ehHayir;
                    HASTAPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAPROTNO.TextFont.Name = "Arial";
                    HASTAPROTNO.TextFont.Size = 7;
                    HASTAPROTNO.TextFont.CharSet = 162;
                    HASTAPROTNO.Value = @"{#HASTAPROTNO#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 25, 330, 30, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.Size = 7;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    UZMANLIKDALI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 31, 330, 36, false);
                    UZMANLIKDALI.Name = "UZMANLIKDALI";
                    UZMANLIKDALI.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDALI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDALI.ObjectDefName = "ResSection";
                    UZMANLIKDALI.DataMember = "NAME";
                    UZMANLIKDALI.TextFont.Name = "Arial";
                    UZMANLIKDALI.TextFont.Size = 7;
                    UZMANLIKDALI.TextFont.CharSet = 162;
                    UZMANLIKDALI.Value = @"{#MASTERRESOURCE#}";

                    FOREIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 2, 328, 7, false);
                    FOREIGN.Name = "FOREIGN";
                    FOREIGN.Visible = EvetHayirEnum.ehHayir;
                    FOREIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGN.Value = @"{#FOREIGN#}";

                    FOREIGNUNIQUENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 330, 2, 355, 7, false);
                    FOREIGNUNIQUENUMBER.Name = "FOREIGNUNIQUENUMBER";
                    FOREIGNUNIQUENUMBER.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNUNIQUENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNUNIQUENUMBER.Value = @"{#FOREIGNUNIQUEREFNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    ACTDEFINE.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    CONFIRMNO.CalcValue = CONFIRMNO.Value;
                    TCKIMLIKNO.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Tckimlikno) : "");
                    HASTAISIM.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Hastaisim) : "") + @" " + (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Hastasoyisim) : "");
                    HASTAPROTNO.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Hastaprotno) : "");
                    OBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    UZMANLIKDALI.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.MasterResource) : "");
                    UZMANLIKDALI.PostFieldValueCalculation();
                    FOREIGN.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.Foreign) : "");
                    FOREIGNUNIQUENUMBER.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ForeignUniqueRefNo) : "");
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField12,NewField13,NewField14,NewField15,ACTDEFINE,NewField11,NewField111,NewField121,CONFIRMNO,TCKIMLIKNO,HASTAISIM,HASTAPROTNO,OBJECTID,UZMANLIKDALI,FOREIGN,FOREIGNUNIQUENUMBER,RESPONSIBLEPROCUREMENTUNITDEF};
                }

                public override void RunScript()
                {
#region BASLIK HEADER_Script
                    string objectID = this.OBJECTID.CalcValue;
            DirectPurchaseAction dpa = (DirectPurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            string tc = this.FOREIGN.CalcValue == "True" ? "( * )"+ this.FOREIGNUNIQUENUMBER.CalcValue : this.TCKIMLIKNO.CalcValue ;
            string a = " XXXXXXmiz " + this.UZMANLIKDALI.CalcValue + "  'de işlem görmekte olan hasta " + this.HASTAISIM.CalcValue + " TC: " + tc + " için " + dpa.DirectPurchaseActionDetails.Count.ToString() + "  kalem malzeme temini işi " ;
            this.ACTDEFINE.CalcValue = a;
#endregion BASLIK HEADER_Script
                }
            }
            public partial class BASLIKGroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField KANUN11;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField16;
                public TTReportField BASKAN;
                public TTReportField BASKANUNVAN;
                public TTReportField UYE1;
                public TTReportField UYE2;
                public TTReportField UYE1UNVAN;
                public TTReportField UYE2UNVAN;
                public TTReportField TTOBJECTID; 
                public BASLIKGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    RepeatCount = 0;
                    
                    KANUN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 3, 279, 13, false);
                    KANUN11.Name = "KANUN11";
                    KANUN11.DrawStyle = DrawStyleConstants.vbSolid;
                    KANUN11.MultiLine = EvetHayirEnum.ehEvet;
                    KANUN11.WordBreak = EvetHayirEnum.ehEvet;
                    KANUN11.TextFont.Name = "Arial";
                    KANUN11.TextFont.Size = 7;
                    KANUN11.TextFont.CharSet = 162;
                    KANUN11.Value = @"     4734 sayılı Kamu İhale Kanunu'nun 22/F maddesi uyarınca doğrudan temin usulü ile yapılacak alımlara ilişkin yapılan fiyat araştırmasında firmalarca/kişilerce teklif edilen fiyatlar tarafımızca değerlendirilerek yukarıda adı ve adresleri belirtilen  kişi/firma/firmalardan alım yapılması uygun görülmüştür.";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 24, 21, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"ADI SOYADI ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 29, 21, 34, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"ÜNVANI";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 24, 22, 29, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 29, 22, 34, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 17, 51, 22, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 8;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"BAŞKAN";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 17, 116, 22, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"ÜYE";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 17, 183, 22, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"ÜYE";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 24, 86, 29, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.TextFont.Size = 7;
                    BASKAN.TextFont.CharSet = 162;
                    BASKAN.Value = @"";

                    BASKANUNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 29, 86, 34, false);
                    BASKANUNVAN.Name = "BASKANUNVAN";
                    BASKANUNVAN.TextFont.Size = 7;
                    BASKANUNVAN.TextFont.CharSet = 162;
                    BASKANUNVAN.Value = @"";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 24, 151, 29, false);
                    UYE1.Name = "UYE1";
                    UYE1.TextFont.Size = 7;
                    UYE1.TextFont.CharSet = 162;
                    UYE1.Value = @"";

                    UYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 24, 218, 29, false);
                    UYE2.Name = "UYE2";
                    UYE2.TextFont.Size = 7;
                    UYE2.TextFont.CharSet = 162;
                    UYE2.Value = @"";

                    UYE1UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 29, 151, 34, false);
                    UYE1UNVAN.Name = "UYE1UNVAN";
                    UYE1UNVAN.TextFont.Size = 7;
                    UYE1UNVAN.TextFont.CharSet = 162;
                    UYE1UNVAN.Value = @"";

                    UYE2UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 29, 218, 34, false);
                    UYE2UNVAN.Name = "UYE2UNVAN";
                    UYE2UNVAN.TextFont.Size = 7;
                    UYE2UNVAN.TextFont.CharSet = 162;
                    UYE2UNVAN.Value = @"";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 10, 331, 15, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    KANUN11.CalcValue = KANUN11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField16.CalcValue = NewField16.Value;
                    BASKAN.CalcValue = BASKAN.Value;
                    BASKANUNVAN.CalcValue = BASKANUNVAN.Value;
                    UYE1.CalcValue = UYE1.Value;
                    UYE2.CalcValue = UYE2.Value;
                    UYE1UNVAN.CalcValue = UYE1UNVAN.Value;
                    UYE2UNVAN.CalcValue = UYE2UNVAN.Value;
                    TTOBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    return new TTReportObject[] { KANUN11,NewField1,NewField2,NewField1121,NewField1122,NewField3,NewField4,NewField16,BASKAN,BASKANUNVAN,UYE1,UYE2,UYE1UNVAN,UYE2UNVAN,TTOBJECTID};
                }

                public override void RunScript()
                {
#region BASLIK FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA_Class> commisionMembers = DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA(ctx, TTOBJECTID.CalcValue);
            
            
            foreach(DirectPurchaseCommisionMember.GetDPCommisionMemberByDPA_Class commisionMember  in commisionMembers)
            {
                if(commisionMember.MemberDuty == 0) //başkansa
                {
                    this.BASKAN.CalcValue = commisionMember.NameString != null ? commisionMember.NameString.ToString() : null;
                    this.BASKANUNVAN.CalcValue = commisionMember.Title != null ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(commisionMember.Title.Value).ToString() + " " : null ;
                    this.BASKANUNVAN.CalcValue += commisionMember.Sinif + " ";
                    this.BASKANUNVAN.CalcValue += commisionMember.Name;
                }
                else
                {   
                    if(this.UYE1.CalcValue == "")
                    {
                         this.UYE1.CalcValue = commisionMember.NameString != null ? commisionMember.NameString.ToString() : null;
                         this.UYE1UNVAN.CalcValue = commisionMember.Title != null ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(commisionMember.Title.Value).ToString() + " " : null;
                          this.UYE1UNVAN.CalcValue += commisionMember.Sinif + " ";
                          this.UYE1UNVAN.CalcValue += commisionMember.Name;
                    }
                    else
                    {
                        this.UYE2.CalcValue = commisionMember.NameString != null ? commisionMember.NameString.ToString() : null;
                        this.UYE2UNVAN.CalcValue = commisionMember.Title != null ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(commisionMember.Title.Value).ToString() + " " : null;  
                           this.UYE2UNVAN.CalcValue += commisionMember.Sinif + " ";
                          this.UYE2UNVAN.CalcValue += commisionMember.Name;
                    }
                }
            }
#endregion BASLIK FOOTER_Script
                }
            }

        }

        public BASLIKGroup BASLIK;

        public partial class FIRM1Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public FIRM1GroupHeader Header()
            {
                return (FIRM1GroupHeader)_header;
            }

            new public FIRM1GroupFooter Footer()
            {
                return (FIRM1GroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField FIRMAMETIN1 { get {return Header().FIRMAMETIN1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField FIRMAMETIN2 { get {return Header().FIRMAMETIN2;} }
            public TTReportField FIRMAMETIN0 { get {return Header().FIRMAMETIN0;} }
            public TTReportField MIKTAR1 { get {return Header().MIKTAR1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField MIKTAR11 { get {return Header().MIKTAR11;} }
            public TTReportField TXTUBB0 { get {return Header().TXTUBB0;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField UBB10 { get {return Header().UBB10;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField UBB11 { get {return Header().UBB11;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField1143 { get {return Header().NewField1143;} }
            public TTReportField NewField11412 { get {return Header().NewField11412;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public TTReportField FIRMAOBJECTID0 { get {return Header().FIRMAOBJECTID0;} }
            public TTReportField FIRMAOBJECTID1 { get {return Header().FIRMAOBJECTID1;} }
            public TTReportField FIRMAOBJECTID2 { get {return Header().FIRMAOBJECTID2;} }
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
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField FIRMAMETIN1;
                public TTReportField NewField13;
                public TTReportField FIRMAMETIN2;
                public TTReportField FIRMAMETIN0;
                public TTReportField MIKTAR1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField MIKTAR11;
                public TTReportField TXTUBB0;
                public TTReportField NewField2;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField UBB10;
                public TTReportField NewField15;
                public TTReportField NewField142;
                public TTReportField NewField1142;
                public TTReportField NewField11411;
                public TTReportField UBB11;
                public TTReportField NewField16;
                public TTReportField NewField143;
                public TTReportField NewField1143;
                public TTReportField NewField11412;
                public TTReportField NewField3;
                public TTReportField TTOBJECTID;
                public TTReportField FIRMAOBJECTID0;
                public TTReportField FIRMAOBJECTID1;
                public TTReportField FIRMAOBJECTID2; 
                public FIRM1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 4, 8, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 6;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S. Nu.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 4, 74, 27, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 6;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Malzemenin Adı";

                    FIRMAMETIN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 9, 202, 14, false);
                    FIRMAMETIN1.Name = "FIRMAMETIN1";
                    FIRMAMETIN1.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN1.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN1.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN1.TextFont.Name = "Arial";
                    FIRMAMETIN1.TextFont.Size = 5;
                    FIRMAMETIN1.TextFont.Bold = true;
                    FIRMAMETIN1.TextFont.CharSet = 162;
                    FIRMAMETIN1.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 4, 259, 9, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 6;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 9, 259, 14, false);
                    FIRMAMETIN2.Name = "FIRMAMETIN2";
                    FIRMAMETIN2.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN2.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN2.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN2.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN2.TextFont.Name = "Arial";
                    FIRMAMETIN2.TextFont.Size = 5;
                    FIRMAMETIN2.TextFont.Bold = true;
                    FIRMAMETIN2.TextFont.CharSet = 162;
                    FIRMAMETIN2.Value = @"";

                    FIRMAMETIN0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 9, 145, 14, false);
                    FIRMAMETIN0.Name = "FIRMAMETIN0";
                    FIRMAMETIN0.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN0.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN0.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN0.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN0.TextFont.Name = "Arial";
                    FIRMAMETIN0.TextFont.Size = 5;
                    FIRMAMETIN0.TextFont.Bold = true;
                    FIRMAMETIN0.TextFont.CharSet = 162;
                    FIRMAMETIN0.Value = @"";

                    MIKTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 9, 80, 27, false);
                    MIKTAR1.Name = "MIKTAR1";
                    MIKTAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR1.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR1.TextFont.Name = "Arial";
                    MIKTAR1.TextFont.Size = 6;
                    MIKTAR1.TextFont.Bold = true;
                    MIKTAR1.TextFont.CharSet = 162;
                    MIKTAR1.Value = @"İhti- yaç Mik- tarı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 15, 27, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 6;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İhtiyaç SUT / İşlem Kodu";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 25, 27, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 6;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İhtiyaç SUT / İşlem Fiyatı";

                    MIKTAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 9, 88, 27, false);
                    MIKTAR11.Name = "MIKTAR11";
                    MIKTAR11.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR11.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR11.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR11.TextFont.Name = "Arial";
                    MIKTAR11.TextFont.Size = 6;
                    MIKTAR11.TextFont.Bold = true;
                    MIKTAR11.TextFont.CharSet = 162;
                    MIKTAR11.Value = @"Ölçü Birimi";

                    TXTUBB0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 14, 108, 27, false);
                    TXTUBB0.Name = "TXTUBB0";
                    TXTUBB0.DrawStyle = DrawStyleConstants.vbSolid;
                    TXTUBB0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TXTUBB0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TXTUBB0.MultiLine = EvetHayirEnum.ehEvet;
                    TXTUBB0.WordBreak = EvetHayirEnum.ehEvet;
                    TXTUBB0.TextFont.Name = "Arial";
                    TXTUBB0.TextFont.Size = 6;
                    TXTUBB0.TextFont.Bold = true;
                    TXTUBB0.TextFont.CharSet = 162;
                    TXTUBB0.Value = @"Teklif Ettiği UBB";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 14, 117, 27, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 6;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Teklif Ettiği SUT Kodu";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 14, 127, 27, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 6;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Birim Fiyat (TL)";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 14, 137, 27, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 6;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Tutarı (TL)";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 14, 145, 27, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 6;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Kabul veya Red";

                    UBB10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 14, 165, 27, false);
                    UBB10.Name = "UBB10";
                    UBB10.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB10.MultiLine = EvetHayirEnum.ehEvet;
                    UBB10.WordBreak = EvetHayirEnum.ehEvet;
                    UBB10.TextFont.Name = "Arial";
                    UBB10.TextFont.Size = 6;
                    UBB10.TextFont.Bold = true;
                    UBB10.TextFont.CharSet = 162;
                    UBB10.Value = @"Teklif Ettiği UBB";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 14, 174, 27, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 6;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Teklif Ettiği SUT Kodu";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 14, 184, 27, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.Name = "Arial";
                    NewField142.TextFont.Size = 6;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Birim Fiyat (TL)";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 14, 194, 27, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1142.TextFont.Name = "Arial";
                    NewField1142.TextFont.Size = 6;
                    NewField1142.TextFont.Bold = true;
                    NewField1142.TextFont.CharSet = 162;
                    NewField1142.Value = @"Tutarı (TL)";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 14, 202, 27, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 6;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Kabul veya Red";

                    UBB11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 14, 222, 27, false);
                    UBB11.Name = "UBB11";
                    UBB11.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB11.MultiLine = EvetHayirEnum.ehEvet;
                    UBB11.WordBreak = EvetHayirEnum.ehEvet;
                    UBB11.TextFont.Name = "Arial";
                    UBB11.TextFont.Size = 6;
                    UBB11.TextFont.Bold = true;
                    UBB11.TextFont.CharSet = 162;
                    UBB11.Value = @"Teklif Ettiği UBB";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 14, 231, 27, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 6;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Teklif Ettiği SUT Kodu";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 14, 241, 27, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField143.MultiLine = EvetHayirEnum.ehEvet;
                    NewField143.WordBreak = EvetHayirEnum.ehEvet;
                    NewField143.TextFont.Name = "Arial";
                    NewField143.TextFont.Size = 6;
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Birim Fiyat (TL)";

                    NewField1143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 14, 251, 27, false);
                    NewField1143.Name = "NewField1143";
                    NewField1143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1143.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1143.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1143.TextFont.Name = "Arial";
                    NewField1143.TextFont.Size = 6;
                    NewField1143.TextFont.Bold = true;
                    NewField1143.TextFont.CharSet = 162;
                    NewField1143.Value = @"Tutarı (TL)";

                    NewField11412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 14, 259, 27, false);
                    NewField11412.Name = "NewField11412";
                    NewField11412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11412.TextFont.Name = "Arial";
                    NewField11412.TextFont.Size = 6;
                    NewField11412.TextFont.Bold = true;
                    NewField11412.TextFont.CharSet = 162;
                    NewField11412.Value = @"Kabul veya Red";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 4, 279, 27, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 6;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Açıklama";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 26, 339, 31, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 6;
                    TTOBJECTID.TextFont.Bold = true;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#BASLIK.OBJECTID#}";

                    FIRMAOBJECTID0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 4, 338, 9, false);
                    FIRMAOBJECTID0.Name = "FIRMAOBJECTID0";
                    FIRMAOBJECTID0.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID0.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID0.TextFont.Name = "Arial";
                    FIRMAOBJECTID0.TextFont.Size = 6;
                    FIRMAOBJECTID0.TextFont.Bold = true;
                    FIRMAOBJECTID0.TextFont.CharSet = 162;
                    FIRMAOBJECTID0.Value = @"";

                    FIRMAOBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 10, 338, 15, false);
                    FIRMAOBJECTID1.Name = "FIRMAOBJECTID1";
                    FIRMAOBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID1.TextFont.Name = "Arial";
                    FIRMAOBJECTID1.TextFont.Size = 6;
                    FIRMAOBJECTID1.TextFont.Bold = true;
                    FIRMAOBJECTID1.TextFont.CharSet = 162;
                    FIRMAOBJECTID1.Value = @"";

                    FIRMAOBJECTID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 17, 338, 22, false);
                    FIRMAOBJECTID2.Name = "FIRMAOBJECTID2";
                    FIRMAOBJECTID2.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID2.TextFont.Name = "Arial";
                    FIRMAOBJECTID2.TextFont.Size = 6;
                    FIRMAOBJECTID2.TextFont.Bold = true;
                    FIRMAOBJECTID2.TextFont.CharSet = 162;
                    FIRMAOBJECTID2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = MyParentReport.BASLIK.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    FIRMAMETIN1.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    FIRMAMETIN2.CalcValue = @"";
                    FIRMAMETIN0.CalcValue = @"";
                    MIKTAR1.CalcValue = MIKTAR1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    MIKTAR11.CalcValue = MIKTAR11.Value;
                    TXTUBB0.CalcValue = TXTUBB0.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    UBB10.CalcValue = UBB10.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    UBB11.CalcValue = UBB11.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField1143.CalcValue = NewField1143.Value;
                    NewField11412.CalcValue = NewField11412.Value;
                    NewField3.CalcValue = NewField3.Value;
                    TTOBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    FIRMAOBJECTID0.CalcValue = @"";
                    FIRMAOBJECTID1.CalcValue = @"";
                    FIRMAOBJECTID2.CalcValue = @"";
                    return new TTReportObject[] { NewField1,NewField12,FIRMAMETIN1,NewField13,FIRMAMETIN2,FIRMAMETIN0,MIKTAR1,NewField11,NewField111,MIKTAR11,TXTUBB0,NewField2,NewField14,NewField141,NewField1141,UBB10,NewField15,NewField142,NewField1142,NewField11411,UBB11,NewField16,NewField143,NewField1143,NewField11412,NewField3,TTOBJECTID,FIRMAOBJECTID0,FIRMAOBJECTID1,FIRMAOBJECTID2};
                }

                public override void RunScript()
                {
#region FIRM1 HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = new  BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class>();
            BindingList<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class> details = DirectPurchaseActionDetail.MaterialRequestFormReportNQL(ctx, TTOBJECTID.CalcValue);
            foreach(DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class detail in details )
            {
                BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> padfirmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, detail.ObjectID.ToString());
                foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class padfirmPriceOffer in padfirmPriceOfferList )
                {
                    bool firmaEkle = true;
                    foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class firmPriceOffer in firmPriceOfferList)
                    {
                        if(padfirmPriceOffer.Firmaobjectid == firmPriceOffer.Firmaobjectid)
                            firmaEkle = false;
                    }
                    if(firmaEkle == true)
                        firmPriceOfferList.Add(padfirmPriceOffer);
                }
            }
            if (firmPriceOfferList.Count > 0)
            {
                int repeatNO;
                if (firmPriceOfferList.Count > 3)
                    repeatNO = 3;
                else
                    repeatNO = firmPriceOfferList.Count;

                TTReportField rf;
                for (int i = 0; i < repeatNO; i++)
                {
                    rf = FieldsByName("FIRMAMETIN" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firm != null ? firmPriceOfferList[i].Firm.ToString() : null;

                    rf = FieldsByName("FIRMAOBJECTID" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firmaobjectid != null ? firmPriceOfferList[i].Firmaobjectid.ToString() : null;
                }
            }
#endregion FIRM1 HEADER_Script
                }
            }
            public partial class FIRM1GroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                 
                public FIRM1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FIRM1Group FIRM1;

        public partial class BODY1Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public BODY1GroupBody Body()
            {
                return (BODY1GroupBody)_body;
            }
            public TTReportField ORDERNO1 { get {return Body().ORDERNO1;} }
            public TTReportField MALZEMEADI1 { get {return Body().MALZEMEADI1;} }
            public TTReportField AMOUNT1 { get {return Body().AMOUNT1;} }
            public TTReportField OLCUBIRIMI1 { get {return Body().OLCUBIRIMI1;} }
            public TTReportField IHTIYACSUTKODU1 { get {return Body().IHTIYACSUTKODU1;} }
            public TTReportField SUTFIYATI1 { get {return Body().SUTFIYATI1;} }
            public TTReportField UBB1 { get {return Body().UBB1;} }
            public TTReportField SUTKODU1 { get {return Body().SUTKODU1;} }
            public TTReportField FIYAT1 { get {return Body().FIYAT1;} }
            public TTReportField TUTAR1 { get {return Body().TUTAR1;} }
            public TTReportField DURUM1 { get {return Body().DURUM1;} }
            public TTReportField UBB2 { get {return Body().UBB2;} }
            public TTReportField SUTKODU2 { get {return Body().SUTKODU2;} }
            public TTReportField FIYAT2 { get {return Body().FIYAT2;} }
            public TTReportField TUTAR2 { get {return Body().TUTAR2;} }
            public TTReportField DURUM2 { get {return Body().DURUM2;} }
            public TTReportField ACIKLAMA1 { get {return Body().ACIKLAMA1;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField UBB0 { get {return Body().UBB0;} }
            public TTReportField SUTKODU0 { get {return Body().SUTKODU0;} }
            public TTReportField FIYAT0 { get {return Body().FIYAT0;} }
            public TTReportField TUTAR0 { get {return Body().TUTAR0;} }
            public TTReportField DURUM0 { get {return Body().DURUM0;} }
            public TTReportField FIRMAOBJECTID0 { get {return Body().FIRMAOBJECTID0;} }
            public TTReportField FIRMAOBJECTID1 { get {return Body().FIRMAOBJECTID1;} }
            public TTReportField FIRMAOBJECTID2 { get {return Body().FIRMAOBJECTID2;} }
            public TTReportField ISLEMKODU { get {return Body().ISLEMKODU;} }
            public TTReportField RPCMATERIALNAME { get {return Body().RPCMATERIALNAME;} }
            public TTReportField NEWSUTNAME { get {return Body().NEWSUTNAME;} }
            public TTReportField NEWSUTCODE { get {return Body().NEWSUTCODE;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public BODY1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BODY1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>("GetPiyasaArastirmaTutanagiNQL", DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BODY1GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class BODY1GroupBody : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField ORDERNO1;
                public TTReportField MALZEMEADI1;
                public TTReportField AMOUNT1;
                public TTReportField OLCUBIRIMI1;
                public TTReportField IHTIYACSUTKODU1;
                public TTReportField SUTFIYATI1;
                public TTReportField UBB1;
                public TTReportField SUTKODU1;
                public TTReportField FIYAT1;
                public TTReportField TUTAR1;
                public TTReportField DURUM1;
                public TTReportField UBB2;
                public TTReportField SUTKODU2;
                public TTReportField FIYAT2;
                public TTReportField TUTAR2;
                public TTReportField DURUM2;
                public TTReportField ACIKLAMA1;
                public TTReportField TTOBJECTID;
                public TTReportField UBB0;
                public TTReportField SUTKODU0;
                public TTReportField FIYAT0;
                public TTReportField TUTAR0;
                public TTReportField DURUM0;
                public TTReportField FIRMAOBJECTID0;
                public TTReportField FIRMAOBJECTID1;
                public TTReportField FIRMAOBJECTID2;
                public TTReportField ISLEMKODU;
                public TTReportField RPCMATERIALNAME;
                public TTReportField NEWSUTNAME;
                public TTReportField NEWSUTCODE;
                public TTReportField CODELESSMATERIALNAME; 
                public BODY1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ORDERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 8, 5, false);
                    ORDERNO1.Name = "ORDERNO1";
                    ORDERNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO1.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO1.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO1.TextFont.Name = "Arial";
                    ORDERNO1.TextFont.Size = 5;
                    ORDERNO1.TextFont.CharSet = 162;
                    ORDERNO1.Value = @"{@groupcounter@}";

                    MALZEMEADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 74, 5, false);
                    MALZEMEADI1.Name = "MALZEMEADI1";
                    MALZEMEADI1.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI1.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADI1.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADI1.TextFont.Name = "Arial";
                    MALZEMEADI1.TextFont.Size = 5;
                    MALZEMEADI1.TextFont.CharSet = 162;
                    MALZEMEADI1.Value = @"";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 80, 5, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT1.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT1.TextFont.Name = "Arial";
                    AMOUNT1.TextFont.Size = 5;
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"{#AMOUNT#}";

                    OLCUBIRIMI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    OLCUBIRIMI1.Name = "OLCUBIRIMI1";
                    OLCUBIRIMI1.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI1.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI1.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI1.TextFont.Name = "Arial";
                    OLCUBIRIMI1.TextFont.Size = 5;
                    OLCUBIRIMI1.TextFont.CharSet = 162;
                    OLCUBIRIMI1.Value = @"{#DISTRIBUTIONTYPE#}";

                    IHTIYACSUTKODU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 15, 5, false);
                    IHTIYACSUTKODU1.Name = "IHTIYACSUTKODU1";
                    IHTIYACSUTKODU1.DrawStyle = DrawStyleConstants.vbSolid;
                    IHTIYACSUTKODU1.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHTIYACSUTKODU1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHTIYACSUTKODU1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHTIYACSUTKODU1.MultiLine = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU1.WordBreak = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU1.TextFont.Name = "Arial";
                    IHTIYACSUTKODU1.TextFont.Size = 5;
                    IHTIYACSUTKODU1.TextFont.CharSet = 162;
                    IHTIYACSUTKODU1.Value = @"";

                    SUTFIYATI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 25, 5, false);
                    SUTFIYATI1.Name = "SUTFIYATI1";
                    SUTFIYATI1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYATI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYATI1.TextFormat = @"#,##0.#0";
                    SUTFIYATI1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUTFIYATI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYATI1.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYATI1.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYATI1.TextFont.Name = "Arial";
                    SUTFIYATI1.TextFont.Size = 5;
                    SUTFIYATI1.TextFont.CharSet = 162;
                    SUTFIYATI1.Value = @"{#SUTPRICE#}";

                    UBB1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 165, 5, false);
                    UBB1.Name = "UBB1";
                    UBB1.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB1.MultiLine = EvetHayirEnum.ehEvet;
                    UBB1.WordBreak = EvetHayirEnum.ehEvet;
                    UBB1.TextFont.Name = "Arial";
                    UBB1.TextFont.Size = 5;
                    UBB1.TextFont.CharSet = 162;
                    UBB1.Value = @"";

                    SUTKODU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 174, 5, false);
                    SUTKODU1.Name = "SUTKODU1";
                    SUTKODU1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU1.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU1.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU1.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU1.TextFont.Name = "Arial";
                    SUTKODU1.TextFont.Size = 5;
                    SUTKODU1.TextFont.CharSet = 162;
                    SUTKODU1.Value = @"";

                    FIYAT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 184, 5, false);
                    FIYAT1.Name = "FIYAT1";
                    FIYAT1.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT1.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT1.TextFormat = @"#,##0.#0";
                    FIYAT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT1.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT1.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT1.TextFont.Name = "Arial";
                    FIYAT1.TextFont.Size = 5;
                    FIYAT1.TextFont.CharSet = 162;
                    FIYAT1.Value = @"";

                    TUTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 194, 5, false);
                    TUTAR1.Name = "TUTAR1";
                    TUTAR1.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR1.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR1.TextFormat = @"#,##0.#0";
                    TUTAR1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR1.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR1.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR1.TextFont.Name = "Arial";
                    TUTAR1.TextFont.Size = 5;
                    TUTAR1.TextFont.CharSet = 162;
                    TUTAR1.Value = @"";

                    DURUM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 0, 202, 5, false);
                    DURUM1.Name = "DURUM1";
                    DURUM1.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM1.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM1.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM1.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM1.TextFont.Name = "Wingdings";
                    DURUM1.TextFont.Size = 7;
                    DURUM1.TextFont.CharSet = 2;
                    DURUM1.Value = @"";

                    UBB2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 222, 5, false);
                    UBB2.Name = "UBB2";
                    UBB2.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB2.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB2.MultiLine = EvetHayirEnum.ehEvet;
                    UBB2.WordBreak = EvetHayirEnum.ehEvet;
                    UBB2.TextFont.Name = "Arial";
                    UBB2.TextFont.Size = 5;
                    UBB2.TextFont.CharSet = 162;
                    UBB2.Value = @"";

                    SUTKODU2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 231, 5, false);
                    SUTKODU2.Name = "SUTKODU2";
                    SUTKODU2.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU2.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU2.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU2.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU2.TextFont.Name = "Arial";
                    SUTKODU2.TextFont.Size = 5;
                    SUTKODU2.TextFont.CharSet = 162;
                    SUTKODU2.Value = @"";

                    FIYAT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 241, 5, false);
                    FIYAT2.Name = "FIYAT2";
                    FIYAT2.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT2.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT2.TextFormat = @"#,##0.#0";
                    FIYAT2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT2.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT2.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT2.TextFont.Name = "Arial";
                    FIYAT2.TextFont.Size = 5;
                    FIYAT2.TextFont.CharSet = 162;
                    FIYAT2.Value = @"";

                    TUTAR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 251, 5, false);
                    TUTAR2.Name = "TUTAR2";
                    TUTAR2.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR2.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR2.TextFormat = @"#,##0.#0";
                    TUTAR2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR2.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR2.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR2.TextFont.Name = "Arial";
                    TUTAR2.TextFont.Size = 5;
                    TUTAR2.TextFont.CharSet = 162;
                    TUTAR2.Value = @"";

                    DURUM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 0, 259, 5, false);
                    DURUM2.Name = "DURUM2";
                    DURUM2.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM2.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM2.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM2.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM2.TextFont.Name = "Wingdings";
                    DURUM2.TextFont.Size = 7;
                    DURUM2.TextFont.CharSet = 2;
                    DURUM2.Value = @"";

                    ACIKLAMA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 0, 279, 5, false);
                    ACIKLAMA1.Name = "ACIKLAMA1";
                    ACIKLAMA1.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA1.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA1.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA1.TextFont.Name = "Arial";
                    ACIKLAMA1.TextFont.Size = 5;
                    ACIKLAMA1.TextFont.CharSet = 162;
                    ACIKLAMA1.Value = @"{#DESCRIPTION#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 13, 315, 18, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 5;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#OBJECTID#}";

                    UBB0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 108, 5, false);
                    UBB0.Name = "UBB0";
                    UBB0.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB0.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB0.MultiLine = EvetHayirEnum.ehEvet;
                    UBB0.WordBreak = EvetHayirEnum.ehEvet;
                    UBB0.TextFont.Name = "Arial";
                    UBB0.TextFont.Size = 5;
                    UBB0.TextFont.CharSet = 162;
                    UBB0.Value = @"";

                    SUTKODU0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 117, 5, false);
                    SUTKODU0.Name = "SUTKODU0";
                    SUTKODU0.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU0.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU0.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU0.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU0.TextFont.Name = "Arial";
                    SUTKODU0.TextFont.Size = 5;
                    SUTKODU0.TextFont.CharSet = 162;
                    SUTKODU0.Value = @"";

                    FIYAT0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 127, 5, false);
                    FIYAT0.Name = "FIYAT0";
                    FIYAT0.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT0.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT0.TextFormat = @"#,##0.#0";
                    FIYAT0.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT0.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT0.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT0.TextFont.Name = "Arial";
                    FIYAT0.TextFont.Size = 5;
                    FIYAT0.TextFont.CharSet = 162;
                    FIYAT0.Value = @"";

                    TUTAR0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 137, 5, false);
                    TUTAR0.Name = "TUTAR0";
                    TUTAR0.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR0.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR0.TextFormat = @"#,##0.#0";
                    TUTAR0.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR0.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR0.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR0.TextFont.Name = "Arial";
                    TUTAR0.TextFont.Size = 5;
                    TUTAR0.TextFont.CharSet = 162;
                    TUTAR0.Value = @"";

                    DURUM0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 145, 5, false);
                    DURUM0.Name = "DURUM0";
                    DURUM0.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM0.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM0.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM0.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM0.TextFont.Name = "Wingdings";
                    DURUM0.TextFont.Size = 7;
                    DURUM0.TextFont.CharSet = 2;
                    DURUM0.Value = @"";

                    FIRMAOBJECTID0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 13, 303, 18, false);
                    FIRMAOBJECTID0.Name = "FIRMAOBJECTID0";
                    FIRMAOBJECTID0.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID0.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID0.TextFont.Name = "Arial";
                    FIRMAOBJECTID0.TextFont.Size = 5;
                    FIRMAOBJECTID0.TextFont.CharSet = 162;
                    FIRMAOBJECTID0.Value = @"{%FIRM1.FIRMAOBJECTID0%}";

                    FIRMAOBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 13, 309, 18, false);
                    FIRMAOBJECTID1.Name = "FIRMAOBJECTID1";
                    FIRMAOBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID1.TextFont.Name = "Arial";
                    FIRMAOBJECTID1.TextFont.Size = 5;
                    FIRMAOBJECTID1.TextFont.CharSet = 162;
                    FIRMAOBJECTID1.Value = @"{%FIRM1.FIRMAOBJECTID1%}";

                    FIRMAOBJECTID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 13, 321, 18, false);
                    FIRMAOBJECTID2.Name = "FIRMAOBJECTID2";
                    FIRMAOBJECTID2.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID2.TextFont.Name = "Arial";
                    FIRMAOBJECTID2.TextFont.Size = 5;
                    FIRMAOBJECTID2.TextFont.CharSet = 162;
                    FIRMAOBJECTID2.Value = @"{%FIRM1.FIRMAOBJECTID2%}";

                    ISLEMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 313, 6, false);
                    ISLEMKODU.Name = "ISLEMKODU";
                    ISLEMKODU.Visible = EvetHayirEnum.ehHayir;
                    ISLEMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMKODU.TextFont.Name = "Arial";
                    ISLEMKODU.TextFont.Size = 8;
                    ISLEMKODU.TextFont.CharSet = 162;
                    ISLEMKODU.Value = @"{#ISLEMKODU#}";

                    RPCMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 1, 329, 6, false);
                    RPCMATERIALNAME.Name = "RPCMATERIALNAME";
                    RPCMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    RPCMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    RPCMATERIALNAME.TextFont.Name = "Arial";
                    RPCMATERIALNAME.TextFont.Size = 8;
                    RPCMATERIALNAME.TextFont.CharSet = 162;
                    RPCMATERIALNAME.Value = @"{#RPCMATERIALNAME#}";

                    NEWSUTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 7, 313, 12, false);
                    NEWSUTNAME.Name = "NEWSUTNAME";
                    NEWSUTNAME.Visible = EvetHayirEnum.ehHayir;
                    NEWSUTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSUTNAME.TextFont.Name = "Arial";
                    NEWSUTNAME.TextFont.Size = 8;
                    NEWSUTNAME.TextFont.CharSet = 162;
                    NEWSUTNAME.Value = @"{#SUTNAME#}";

                    NEWSUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 7, 329, 12, false);
                    NEWSUTCODE.Name = "NEWSUTCODE";
                    NEWSUTCODE.Visible = EvetHayirEnum.ehHayir;
                    NEWSUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSUTCODE.TextFont.Name = "Arial";
                    NEWSUTCODE.TextFont.Size = 8;
                    NEWSUTCODE.TextFont.CharSet = 162;
                    NEWSUTCODE.Value = @"{#SUTCODE#}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 0, 297, 5, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class dataset_GetPiyasaArastirmaTutanagiNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>(0);
                    ORDERNO1.CalcValue = ParentGroup.GroupCounter.ToString();
                    MALZEMEADI1.CalcValue = @"";
                    AMOUNT1.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Amount) : "");
                    OLCUBIRIMI1.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.DistributionType) : "");
                    IHTIYACSUTKODU1.CalcValue = @"";
                    SUTFIYATI1.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTPrice) : "");
                    ACIKLAMA1.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Description) : "");
                    TTOBJECTID.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.ObjectID) : "");
                    FIRMAOBJECTID0.CalcValue = MyParentReport.FIRM1.FIRMAOBJECTID0.CalcValue;
                    FIRMAOBJECTID1.CalcValue = MyParentReport.FIRM1.FIRMAOBJECTID1.CalcValue;
                    FIRMAOBJECTID2.CalcValue = MyParentReport.FIRM1.FIRMAOBJECTID2.CalcValue;
                    ISLEMKODU.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Islemkodu) : "");
                    RPCMATERIALNAME.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Rpcmaterialname) : "");
                    NEWSUTNAME.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTName) : "");
                    NEWSUTCODE.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTCode) : "");
                    CODELESSMATERIALNAME.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Codelessmaterialname) : "");
                    UBB1.CalcValue = @"";
                    SUTKODU1.CalcValue = @"";
                    FIYAT1.CalcValue = @"";
                    TUTAR1.CalcValue = @"";
                    DURUM1.CalcValue = @"";
                    UBB2.CalcValue = @"";
                    SUTKODU2.CalcValue = @"";
                    FIYAT2.CalcValue = @"";
                    TUTAR2.CalcValue = @"";
                    DURUM2.CalcValue = @"";
                    UBB0.CalcValue = @"";
                    SUTKODU0.CalcValue = @"";
                    FIYAT0.CalcValue = @"";
                    TUTAR0.CalcValue = @"";
                    DURUM0.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO1,MALZEMEADI1,AMOUNT1,OLCUBIRIMI1,IHTIYACSUTKODU1,SUTFIYATI1,ACIKLAMA1,TTOBJECTID,FIRMAOBJECTID0,FIRMAOBJECTID1,FIRMAOBJECTID2,ISLEMKODU,RPCMATERIALNAME,NEWSUTNAME,NEWSUTCODE,CODELESSMATERIALNAME,UBB1,SUTKODU1,FIYAT1,TUTAR1,DURUM1,UBB2,SUTKODU2,FIYAT2,TUTAR2,DURUM2,UBB0,SUTKODU0,FIYAT0,TUTAR0,DURUM0};
                }

                public override void RunScript()
                {
#region BODY1 BODY_Script
                    TTObjectContext octx = new TTObjectContext(true);
            string objectID = ((PiyasaArastirmaTutanagi22F)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            string UBB = "UBB Kapsam Dışı";
            DirectPurchaseAction dpa = (DirectPurchaseAction)octx.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            
            TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, TTOBJECTID.CalcValue);
            
            if (firmPriceOfferList.Count > 0)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                TTReportField rf;
                for (int i = 0; i < firmPriceOfferList.Count; i++)
                {
                    DPADetailFirmPriceOffer firmPriceOffer = (DPADetailFirmPriceOffer)ctx.GetObject(new Guid(firmPriceOfferList[i].ObjectID.ToString()), typeof(DPADetailFirmPriceOffer));
                    if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID0.CalcValue)
                    {
                        if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                        {
                            rf = FieldsByName("UBB0");
                            rf.CalcValue = UBB;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.RPCMATERIALNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = this.ISLEMKODU.CalcValue;
                            rf = FieldsByName("SUTKODU0");
                            rf.CalcValue = this.ISLEMKODU.CalcValue;
                        }
                        else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
                        {
                            rf = FieldsByName("UBB0");
                            rf.CalcValue = UBB;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.CODELESSMATERIALNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = firmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MatchedSUTCode;
                            rf = FieldsByName("SUTFIYATI1");
                            rf.CalcValue = firmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MatchedSUTPrice.ToString();
                        }
                        else
                        {
                            rf = FieldsByName("UBB0");
                            rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.NEWSUTNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = this.NEWSUTCODE.CalcValue;
                            rf = FieldsByName("SUTKODU0");
                            rf.CalcValue = firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                        }
                        
                        rf = FieldsByName("FIYAT0");
                        rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                        rf = FieldsByName("TUTAR0");
                        rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                        rf = FieldsByName("DURUM0");
                        rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                    }
                    else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID1.CalcValue)
                    {
                        if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                        {
                            rf = FieldsByName("UBB1");
                            rf.CalcValue = UBB;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.RPCMATERIALNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = this.ISLEMKODU.CalcValue;
                            rf = FieldsByName("SUTKODU1");
                            rf.CalcValue = this.ISLEMKODU.CalcValue;
                        }
                        else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
                        {
                            rf = FieldsByName("UBB1");
                            rf.CalcValue = UBB;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.CODELESSMATERIALNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = firmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MatchedSUTCode;
                            rf = FieldsByName("SUTFIYATI1");
                            rf.CalcValue = firmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MatchedSUTPrice.ToString();
                        }
                        else
                        {
                            rf = FieldsByName("UBB1");
                            rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.NEWSUTNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = this.NEWSUTCODE.CalcValue;
                            rf = FieldsByName("SUTKODU1");
                            rf.CalcValue = firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                        }

                        rf = FieldsByName("FIYAT1");
                        rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                        rf = FieldsByName("TUTAR1");
                        rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                        rf = FieldsByName("DURUM1");
                        rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                    }
                    else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID2.CalcValue)
                    {if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                        {
                            rf = FieldsByName("UBB2");
                            rf.CalcValue = UBB;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.RPCMATERIALNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = this.ISLEMKODU.CalcValue;
                            rf = FieldsByName("SUTKODU2");
                            rf.CalcValue = this.ISLEMKODU.CalcValue;
                        }
                        else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
                        {
                            rf = FieldsByName("UBB2");
                            rf.CalcValue = UBB;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.CODELESSMATERIALNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = firmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MatchedSUTCode;
                            rf = FieldsByName("SUTFIYATI1");
                            rf.CalcValue = firmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MatchedSUTPrice.ToString();
                        }
                        else
                        {
                            rf = FieldsByName("UBB2");
                            rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null;
                            rf = FieldsByName("MALZEMEADI1");
                            rf.CalcValue = this.NEWSUTNAME.CalcValue;
                            rf = FieldsByName("IHTIYACSUTKODU1");
                            rf.CalcValue = this.NEWSUTCODE.CalcValue;
                            rf = FieldsByName("SUTKODU2");
                            rf.CalcValue = firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                        }
                        
                        rf = FieldsByName("FIYAT2");
                        rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                        rf = FieldsByName("TUTAR2");
                        rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                        rf = FieldsByName("DURUM2");
                        rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                    }
                }
            }
#endregion BODY1 BODY_Script
                }
            }

        }

        public BODY1Group BODY1;

        public partial class FIRM2Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public FIRM2GroupHeader Header()
            {
                return (FIRM2GroupHeader)_header;
            }

            new public FIRM2GroupFooter Footer()
            {
                return (FIRM2GroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField FIRMAMETIN4 { get {return Header().FIRMAMETIN4;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField FIRMAMETIN5 { get {return Header().FIRMAMETIN5;} }
            public TTReportField FIRMAMETIN3 { get {return Header().FIRMAMETIN3;} }
            public TTReportField MIKTAR11 { get {return Header().MIKTAR11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField MIKTAR111 { get {return Header().MIKTAR111;} }
            public TTReportField TXTUBB10 { get {return Header().TXTUBB10;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField UBB101 { get {return Header().UBB101;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField12411 { get {return Header().NewField12411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField UBB111 { get {return Header().UBB111;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportField NewField13411 { get {return Header().NewField13411;} }
            public TTReportField NewField121411 { get {return Header().NewField121411;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public TTReportField FIRMAOBJECTID3 { get {return Header().FIRMAOBJECTID3;} }
            public TTReportField FIRMAOBJECTID4 { get {return Header().FIRMAOBJECTID4;} }
            public TTReportField FIRMAOBJECTID5 { get {return Header().FIRMAOBJECTID5;} }
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
                _body = null;
                _header = new FIRM2GroupHeader(this);
                _footer = new FIRM2GroupFooter(this);

            }

            public partial class FIRM2GroupHeader : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField FIRMAMETIN4;
                public TTReportField NewField131;
                public TTReportField FIRMAMETIN5;
                public TTReportField FIRMAMETIN3;
                public TTReportField MIKTAR11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField MIKTAR111;
                public TTReportField TXTUBB10;
                public TTReportField NewField12;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField UBB101;
                public TTReportField NewField151;
                public TTReportField NewField1241;
                public TTReportField NewField12411;
                public TTReportField NewField111411;
                public TTReportField UBB111;
                public TTReportField NewField161;
                public TTReportField NewField1341;
                public TTReportField NewField13411;
                public TTReportField NewField121411;
                public TTReportField NewField13;
                public TTReportField TTOBJECTID;
                public TTReportField FIRMAOBJECTID3;
                public TTReportField FIRMAOBJECTID4;
                public TTReportField FIRMAOBJECTID5; 
                public FIRM2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 3, 8, 26, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 6;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S. Nu.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 3, 74, 26, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 6;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Malzemenin Adı";

                    FIRMAMETIN4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 8, 202, 13, false);
                    FIRMAMETIN4.Name = "FIRMAMETIN4";
                    FIRMAMETIN4.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN4.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN4.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN4.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN4.TextFont.Name = "Arial";
                    FIRMAMETIN4.TextFont.Size = 5;
                    FIRMAMETIN4.TextFont.Bold = true;
                    FIRMAMETIN4.TextFont.CharSet = 162;
                    FIRMAMETIN4.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 3, 259, 8, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 6;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 8, 259, 13, false);
                    FIRMAMETIN5.Name = "FIRMAMETIN5";
                    FIRMAMETIN5.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN5.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN5.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN5.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN5.TextFont.Name = "Arial";
                    FIRMAMETIN5.TextFont.Size = 5;
                    FIRMAMETIN5.TextFont.Bold = true;
                    FIRMAMETIN5.TextFont.CharSet = 162;
                    FIRMAMETIN5.Value = @"";

                    FIRMAMETIN3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 8, 145, 13, false);
                    FIRMAMETIN3.Name = "FIRMAMETIN3";
                    FIRMAMETIN3.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN3.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN3.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN3.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN3.TextFont.Name = "Arial";
                    FIRMAMETIN3.TextFont.Size = 6;
                    FIRMAMETIN3.TextFont.Bold = true;
                    FIRMAMETIN3.TextFont.CharSet = 162;
                    FIRMAMETIN3.Value = @"";

                    MIKTAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 8, 80, 26, false);
                    MIKTAR11.Name = "MIKTAR11";
                    MIKTAR11.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR11.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR11.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR11.TextFont.Name = "Arial";
                    MIKTAR11.TextFont.Size = 6;
                    MIKTAR11.TextFont.Bold = true;
                    MIKTAR11.TextFont.CharSet = 162;
                    MIKTAR11.Value = @"İhti- yaç Mik- tarı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 15, 26, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 6;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İhtiyaç SUT / İşlem Kodu";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 3, 25, 26, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 6;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İhtiyaç SUT / İşlem Fiyatı";

                    MIKTAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 8, 88, 26, false);
                    MIKTAR111.Name = "MIKTAR111";
                    MIKTAR111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR111.TextFont.Name = "Arial";
                    MIKTAR111.TextFont.Size = 6;
                    MIKTAR111.TextFont.Bold = true;
                    MIKTAR111.TextFont.CharSet = 162;
                    MIKTAR111.Value = @"Ölçü Birimi";

                    TXTUBB10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 13, 108, 26, false);
                    TXTUBB10.Name = "TXTUBB10";
                    TXTUBB10.DrawStyle = DrawStyleConstants.vbSolid;
                    TXTUBB10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TXTUBB10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TXTUBB10.MultiLine = EvetHayirEnum.ehEvet;
                    TXTUBB10.WordBreak = EvetHayirEnum.ehEvet;
                    TXTUBB10.TextFont.Name = "Arial";
                    TXTUBB10.TextFont.Size = 6;
                    TXTUBB10.TextFont.Bold = true;
                    TXTUBB10.TextFont.CharSet = 162;
                    TXTUBB10.Value = @"Teklif Ettiği UBB";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 13, 117, 26, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 6;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Teklif Ettiği SUT Kodu";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 13, 127, 26, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 6;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Birim Fiyat (TL)";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 13, 137, 26, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 6;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Tutarı (TL)";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 13, 145, 26, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 6;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Kabul veya Red";

                    UBB101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 13, 165, 26, false);
                    UBB101.Name = "UBB101";
                    UBB101.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB101.MultiLine = EvetHayirEnum.ehEvet;
                    UBB101.WordBreak = EvetHayirEnum.ehEvet;
                    UBB101.TextFont.Name = "Arial";
                    UBB101.TextFont.Size = 6;
                    UBB101.TextFont.Bold = true;
                    UBB101.TextFont.CharSet = 162;
                    UBB101.Value = @"Teklif Ettiği UBB";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 13, 174, 26, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 6;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Teklif Ettiği SUT Kodu";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 13, 184, 26, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1241.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 6;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Birim Fiyat (TL)";

                    NewField12411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 13, 194, 26, false);
                    NewField12411.Name = "NewField12411";
                    NewField12411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12411.TextFont.Name = "Arial";
                    NewField12411.TextFont.Size = 6;
                    NewField12411.TextFont.Bold = true;
                    NewField12411.TextFont.CharSet = 162;
                    NewField12411.Value = @"Tutarı (TL)";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 13, 202, 26, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111411.TextFont.Name = "Arial";
                    NewField111411.TextFont.Size = 6;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Kabul veya Red";

                    UBB111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 13, 222, 26, false);
                    UBB111.Name = "UBB111";
                    UBB111.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB111.MultiLine = EvetHayirEnum.ehEvet;
                    UBB111.WordBreak = EvetHayirEnum.ehEvet;
                    UBB111.TextFont.Name = "Arial";
                    UBB111.TextFont.Size = 6;
                    UBB111.TextFont.Bold = true;
                    UBB111.TextFont.CharSet = 162;
                    UBB111.Value = @"Teklif Ettiği UBB";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 13, 231, 26, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 6;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Teklif Ettiği SUT Kodu";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 13, 241, 26, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1341.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1341.TextFont.Name = "Arial";
                    NewField1341.TextFont.Size = 6;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"Birim Fiyat (TL)";

                    NewField13411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 13, 251, 26, false);
                    NewField13411.Name = "NewField13411";
                    NewField13411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13411.TextFont.Name = "Arial";
                    NewField13411.TextFont.Size = 6;
                    NewField13411.TextFont.Bold = true;
                    NewField13411.TextFont.CharSet = 162;
                    NewField13411.Value = @"Tutarı (TL)";

                    NewField121411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 13, 259, 26, false);
                    NewField121411.Name = "NewField121411";
                    NewField121411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121411.TextFont.Name = "Arial";
                    NewField121411.TextFont.Size = 6;
                    NewField121411.TextFont.Bold = true;
                    NewField121411.TextFont.CharSet = 162;
                    NewField121411.Value = @"Kabul veya Red";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 3, 279, 26, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 6;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Açıklama";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 26, 323, 31, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 6;
                    TTOBJECTID.TextFont.Bold = true;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#BASLIK.OBJECTID#}";

                    FIRMAOBJECTID3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 4, 322, 9, false);
                    FIRMAOBJECTID3.Name = "FIRMAOBJECTID3";
                    FIRMAOBJECTID3.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID3.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID3.TextFont.Name = "Arial";
                    FIRMAOBJECTID3.TextFont.Size = 6;
                    FIRMAOBJECTID3.TextFont.Bold = true;
                    FIRMAOBJECTID3.TextFont.CharSet = 162;
                    FIRMAOBJECTID3.Value = @"";

                    FIRMAOBJECTID4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 10, 322, 15, false);
                    FIRMAOBJECTID4.Name = "FIRMAOBJECTID4";
                    FIRMAOBJECTID4.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID4.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID4.TextFont.Name = "Arial";
                    FIRMAOBJECTID4.TextFont.Size = 6;
                    FIRMAOBJECTID4.TextFont.Bold = true;
                    FIRMAOBJECTID4.TextFont.CharSet = 162;
                    FIRMAOBJECTID4.Value = @"";

                    FIRMAOBJECTID5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 17, 322, 22, false);
                    FIRMAOBJECTID5.Name = "FIRMAOBJECTID5";
                    FIRMAOBJECTID5.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID5.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID5.TextFont.Name = "Arial";
                    FIRMAOBJECTID5.TextFont.Size = 6;
                    FIRMAOBJECTID5.TextFont.Bold = true;
                    FIRMAOBJECTID5.TextFont.CharSet = 162;
                    FIRMAOBJECTID5.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = MyParentReport.BASLIK.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    FIRMAMETIN4.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    FIRMAMETIN5.CalcValue = @"";
                    FIRMAMETIN3.CalcValue = @"";
                    MIKTAR11.CalcValue = MIKTAR11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    MIKTAR111.CalcValue = MIKTAR111.Value;
                    TXTUBB10.CalcValue = TXTUBB10.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    UBB101.CalcValue = UBB101.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField12411.CalcValue = NewField12411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    UBB111.CalcValue = UBB111.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField13411.CalcValue = NewField13411.Value;
                    NewField121411.CalcValue = NewField121411.Value;
                    NewField13.CalcValue = NewField13.Value;
                    TTOBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    FIRMAOBJECTID3.CalcValue = @"";
                    FIRMAOBJECTID4.CalcValue = @"";
                    FIRMAOBJECTID5.CalcValue = @"";
                    return new TTReportObject[] { NewField11,NewField121,FIRMAMETIN4,NewField131,FIRMAMETIN5,FIRMAMETIN3,MIKTAR11,NewField111,NewField1111,MIKTAR111,TXTUBB10,NewField12,NewField141,NewField1141,NewField11411,UBB101,NewField151,NewField1241,NewField12411,NewField111411,UBB111,NewField161,NewField1341,NewField13411,NewField121411,NewField13,TTOBJECTID,FIRMAOBJECTID3,FIRMAOBJECTID4,FIRMAOBJECTID5};
                }

                public override void RunScript()
                {
#region FIRM2 HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = new  BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class>();
            BindingList<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class> details = DirectPurchaseActionDetail.MaterialRequestFormReportNQL(ctx, TTOBJECTID.CalcValue);
            foreach(DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class detail in details )
            {
                BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> padfirmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, detail.ObjectID.ToString());
                foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class padfirmPriceOffer in padfirmPriceOfferList )
                {
                    bool firmaEkle = true;
                    foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class firmPriceOffer in firmPriceOfferList)
                    {
                        if(padfirmPriceOffer.Firmaobjectid == firmPriceOffer.Firmaobjectid)
                            firmaEkle = false;
                    }
                    if(firmaEkle == true)
                        firmPriceOfferList.Add(padfirmPriceOffer);
                }                
            }
            
            if (firmPriceOfferList.Count > 3)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                
                int repeatNO;
                if (firmPriceOfferList.Count > 6)
                    repeatNO = 6;
                else
                    repeatNO = firmPriceOfferList.Count;

                TTReportField rf;
                for (int i = 3; i < repeatNO; i++)
                {
                    rf = FieldsByName("FIRMAMETIN" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firm != null ? firmPriceOfferList[i].Firm.ToString() : null;

                    rf = FieldsByName("FIRMAOBJECTID" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firmaobjectid != null ? firmPriceOfferList[i].Firmaobjectid.ToString() : null;

                }
            }
#endregion FIRM2 HEADER_Script
                }
            }
            public partial class FIRM2GroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                 
                public FIRM2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FIRM2Group FIRM2;

        public partial class BODY2Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public BODY2GroupBody Body()
            {
                return (BODY2GroupBody)_body;
            }
            public TTReportField ORDERNO111 { get {return Body().ORDERNO111;} }
            public TTReportField MALZEMEADI111 { get {return Body().MALZEMEADI111;} }
            public TTReportField AMOUNT111 { get {return Body().AMOUNT111;} }
            public TTReportField OLCUBIRIMI111 { get {return Body().OLCUBIRIMI111;} }
            public TTReportField IHTIYACSUTKODU111 { get {return Body().IHTIYACSUTKODU111;} }
            public TTReportField SUTFIYATI111 { get {return Body().SUTFIYATI111;} }
            public TTReportField UBB4 { get {return Body().UBB4;} }
            public TTReportField SUTKODU4 { get {return Body().SUTKODU4;} }
            public TTReportField FIYAT4 { get {return Body().FIYAT4;} }
            public TTReportField TUTAR4 { get {return Body().TUTAR4;} }
            public TTReportField DURUM4 { get {return Body().DURUM4;} }
            public TTReportField UBB5 { get {return Body().UBB5;} }
            public TTReportField SUTKODU5 { get {return Body().SUTKODU5;} }
            public TTReportField FIYAT5 { get {return Body().FIYAT5;} }
            public TTReportField TUTAR5 { get {return Body().TUTAR5;} }
            public TTReportField DURUM5 { get {return Body().DURUM5;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField UBB3 { get {return Body().UBB3;} }
            public TTReportField SUTKODU3 { get {return Body().SUTKODU3;} }
            public TTReportField FIYAT3 { get {return Body().FIYAT3;} }
            public TTReportField TUTAR3 { get {return Body().TUTAR3;} }
            public TTReportField DURUM3 { get {return Body().DURUM3;} }
            public TTReportField FIRMAOBJECTID3 { get {return Body().FIRMAOBJECTID3;} }
            public TTReportField FIRMAOBJECTID4 { get {return Body().FIRMAOBJECTID4;} }
            public TTReportField FIRMAOBJECTID5 { get {return Body().FIRMAOBJECTID5;} }
            public TTReportField ACIKLAMA2 { get {return Body().ACIKLAMA2;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public BODY2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BODY2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>("GetPiyasaArastirmaTutanagiNQL", DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BODY2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class BODY2GroupBody : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField ORDERNO111;
                public TTReportField MALZEMEADI111;
                public TTReportField AMOUNT111;
                public TTReportField OLCUBIRIMI111;
                public TTReportField IHTIYACSUTKODU111;
                public TTReportField SUTFIYATI111;
                public TTReportField UBB4;
                public TTReportField SUTKODU4;
                public TTReportField FIYAT4;
                public TTReportField TUTAR4;
                public TTReportField DURUM4;
                public TTReportField UBB5;
                public TTReportField SUTKODU5;
                public TTReportField FIYAT5;
                public TTReportField TUTAR5;
                public TTReportField DURUM5;
                public TTReportField TTOBJECTID;
                public TTReportField UBB3;
                public TTReportField SUTKODU3;
                public TTReportField FIYAT3;
                public TTReportField TUTAR3;
                public TTReportField DURUM3;
                public TTReportField FIRMAOBJECTID3;
                public TTReportField FIRMAOBJECTID4;
                public TTReportField FIRMAOBJECTID5;
                public TTReportField ACIKLAMA2;
                public TTReportField CODELESSMATERIALNAME; 
                public BODY2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ORDERNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 8, 5, false);
                    ORDERNO111.Name = "ORDERNO111";
                    ORDERNO111.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO111.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO111.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO111.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO111.TextFont.Name = "Arial";
                    ORDERNO111.TextFont.Size = 5;
                    ORDERNO111.TextFont.CharSet = 162;
                    ORDERNO111.Value = @"{@groupcounter@}";

                    MALZEMEADI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 74, 5, false);
                    MALZEMEADI111.Name = "MALZEMEADI111";
                    MALZEMEADI111.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI111.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI111.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADI111.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADI111.TextFont.Name = "Arial";
                    MALZEMEADI111.TextFont.Size = 5;
                    MALZEMEADI111.TextFont.CharSet = 162;
                    MALZEMEADI111.Value = @"{#SUTNAME#}";

                    AMOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 80, 5, false);
                    AMOUNT111.Name = "AMOUNT111";
                    AMOUNT111.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT111.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT111.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT111.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT111.TextFont.Name = "Arial";
                    AMOUNT111.TextFont.Size = 5;
                    AMOUNT111.TextFont.CharSet = 162;
                    AMOUNT111.Value = @"{#AMOUNT#}";

                    OLCUBIRIMI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    OLCUBIRIMI111.Name = "OLCUBIRIMI111";
                    OLCUBIRIMI111.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI111.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI111.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI111.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI111.TextFont.Name = "Arial";
                    OLCUBIRIMI111.TextFont.Size = 5;
                    OLCUBIRIMI111.TextFont.CharSet = 162;
                    OLCUBIRIMI111.Value = @"{#DISTRIBUTIONTYPE#}";

                    IHTIYACSUTKODU111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 15, 5, false);
                    IHTIYACSUTKODU111.Name = "IHTIYACSUTKODU111";
                    IHTIYACSUTKODU111.DrawStyle = DrawStyleConstants.vbSolid;
                    IHTIYACSUTKODU111.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHTIYACSUTKODU111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHTIYACSUTKODU111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHTIYACSUTKODU111.MultiLine = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU111.WordBreak = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU111.TextFont.Name = "Arial";
                    IHTIYACSUTKODU111.TextFont.Size = 5;
                    IHTIYACSUTKODU111.TextFont.CharSet = 162;
                    IHTIYACSUTKODU111.Value = @"{#SUTCODE#}";

                    SUTFIYATI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 25, 5, false);
                    SUTFIYATI111.Name = "SUTFIYATI111";
                    SUTFIYATI111.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYATI111.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYATI111.TextFormat = @"#,##0.#0";
                    SUTFIYATI111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUTFIYATI111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYATI111.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYATI111.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYATI111.TextFont.Name = "Arial";
                    SUTFIYATI111.TextFont.Size = 5;
                    SUTFIYATI111.TextFont.CharSet = 162;
                    SUTFIYATI111.Value = @"{#SUTPRICE#}";

                    UBB4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 165, 5, false);
                    UBB4.Name = "UBB4";
                    UBB4.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB4.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB4.MultiLine = EvetHayirEnum.ehEvet;
                    UBB4.WordBreak = EvetHayirEnum.ehEvet;
                    UBB4.TextFont.Name = "Arial";
                    UBB4.TextFont.Size = 5;
                    UBB4.TextFont.CharSet = 162;
                    UBB4.Value = @"";

                    SUTKODU4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 174, 5, false);
                    SUTKODU4.Name = "SUTKODU4";
                    SUTKODU4.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU4.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU4.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU4.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU4.TextFont.Name = "Arial";
                    SUTKODU4.TextFont.Size = 5;
                    SUTKODU4.TextFont.CharSet = 162;
                    SUTKODU4.Value = @"";

                    FIYAT4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 184, 5, false);
                    FIYAT4.Name = "FIYAT4";
                    FIYAT4.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT4.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT4.TextFormat = @"#,##0.#0";
                    FIYAT4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT4.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT4.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT4.TextFont.Name = "Arial";
                    FIYAT4.TextFont.Size = 5;
                    FIYAT4.TextFont.CharSet = 162;
                    FIYAT4.Value = @"";

                    TUTAR4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 194, 5, false);
                    TUTAR4.Name = "TUTAR4";
                    TUTAR4.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR4.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR4.TextFormat = @"#,##0.#0";
                    TUTAR4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR4.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR4.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR4.TextFont.Name = "Arial";
                    TUTAR4.TextFont.Size = 5;
                    TUTAR4.TextFont.CharSet = 162;
                    TUTAR4.Value = @"";

                    DURUM4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 0, 202, 5, false);
                    DURUM4.Name = "DURUM4";
                    DURUM4.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM4.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM4.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM4.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM4.TextFont.Name = "Wingdings";
                    DURUM4.TextFont.Size = 7;
                    DURUM4.TextFont.CharSet = 2;
                    DURUM4.Value = @"";

                    UBB5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 222, 5, false);
                    UBB5.Name = "UBB5";
                    UBB5.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB5.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB5.MultiLine = EvetHayirEnum.ehEvet;
                    UBB5.WordBreak = EvetHayirEnum.ehEvet;
                    UBB5.TextFont.Name = "Arial";
                    UBB5.TextFont.Size = 5;
                    UBB5.TextFont.CharSet = 162;
                    UBB5.Value = @"";

                    SUTKODU5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 231, 5, false);
                    SUTKODU5.Name = "SUTKODU5";
                    SUTKODU5.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU5.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU5.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU5.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU5.TextFont.Name = "Arial";
                    SUTKODU5.TextFont.Size = 5;
                    SUTKODU5.TextFont.CharSet = 162;
                    SUTKODU5.Value = @"";

                    FIYAT5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 241, 5, false);
                    FIYAT5.Name = "FIYAT5";
                    FIYAT5.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT5.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT5.TextFormat = @"#,##0.#0";
                    FIYAT5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT5.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT5.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT5.TextFont.Name = "Arial";
                    FIYAT5.TextFont.Size = 5;
                    FIYAT5.TextFont.CharSet = 162;
                    FIYAT5.Value = @"";

                    TUTAR5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 251, 5, false);
                    TUTAR5.Name = "TUTAR5";
                    TUTAR5.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR5.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR5.TextFormat = @"#,##0.#0";
                    TUTAR5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR5.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR5.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR5.TextFont.Name = "Arial";
                    TUTAR5.TextFont.Size = 5;
                    TUTAR5.TextFont.CharSet = 162;
                    TUTAR5.Value = @"";

                    DURUM5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 0, 259, 5, false);
                    DURUM5.Name = "DURUM5";
                    DURUM5.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM5.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM5.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM5.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM5.TextFont.Name = "Wingdings";
                    DURUM5.TextFont.Size = 7;
                    DURUM5.TextFont.CharSet = 2;
                    DURUM5.Value = @"";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 324, 6, 349, 11, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 5;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#OBJECTID#}";

                    UBB3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 108, 5, false);
                    UBB3.Name = "UBB3";
                    UBB3.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB3.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB3.MultiLine = EvetHayirEnum.ehEvet;
                    UBB3.WordBreak = EvetHayirEnum.ehEvet;
                    UBB3.TextFont.Name = "Arial";
                    UBB3.TextFont.Size = 5;
                    UBB3.TextFont.CharSet = 162;
                    UBB3.Value = @"";

                    SUTKODU3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 117, 5, false);
                    SUTKODU3.Name = "SUTKODU3";
                    SUTKODU3.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU3.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU3.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU3.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU3.TextFont.Name = "Arial";
                    SUTKODU3.TextFont.Size = 5;
                    SUTKODU3.TextFont.CharSet = 162;
                    SUTKODU3.Value = @"";

                    FIYAT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 127, 5, false);
                    FIYAT3.Name = "FIYAT3";
                    FIYAT3.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT3.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT3.TextFormat = @"#,##0.#0";
                    FIYAT3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT3.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT3.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT3.TextFont.Name = "Arial";
                    FIYAT3.TextFont.Size = 5;
                    FIYAT3.TextFont.CharSet = 162;
                    FIYAT3.Value = @"";

                    TUTAR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 137, 5, false);
                    TUTAR3.Name = "TUTAR3";
                    TUTAR3.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR3.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR3.TextFormat = @"#,##0.#0";
                    TUTAR3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR3.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR3.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR3.TextFont.Name = "Arial";
                    TUTAR3.TextFont.Size = 5;
                    TUTAR3.TextFont.CharSet = 162;
                    TUTAR3.Value = @"";

                    DURUM3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 145, 5, false);
                    DURUM3.Name = "DURUM3";
                    DURUM3.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM3.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM3.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM3.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM3.TextFont.Name = "Wingdings";
                    DURUM3.TextFont.Size = 7;
                    DURUM3.TextFont.CharSet = 2;
                    DURUM3.Value = @"";

                    FIRMAOBJECTID3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 1, 322, 6, false);
                    FIRMAOBJECTID3.Name = "FIRMAOBJECTID3";
                    FIRMAOBJECTID3.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID3.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID3.TextFont.Name = "Arial";
                    FIRMAOBJECTID3.TextFont.Size = 5;
                    FIRMAOBJECTID3.TextFont.CharSet = 162;
                    FIRMAOBJECTID3.Value = @"{%FIRM2.FIRMAOBJECTID3%}";

                    FIRMAOBJECTID4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 7, 322, 12, false);
                    FIRMAOBJECTID4.Name = "FIRMAOBJECTID4";
                    FIRMAOBJECTID4.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID4.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID4.TextFont.Name = "Arial";
                    FIRMAOBJECTID4.TextFont.Size = 5;
                    FIRMAOBJECTID4.TextFont.CharSet = 162;
                    FIRMAOBJECTID4.Value = @"{%FIRM2.FIRMAOBJECTID4%}";

                    FIRMAOBJECTID5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 323, 0, 348, 5, false);
                    FIRMAOBJECTID5.Name = "FIRMAOBJECTID5";
                    FIRMAOBJECTID5.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID5.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID5.TextFont.Name = "Arial";
                    FIRMAOBJECTID5.TextFont.Size = 5;
                    FIRMAOBJECTID5.TextFont.CharSet = 162;
                    FIRMAOBJECTID5.Value = @"{%FIRM2.FIRMAOBJECTID5%}";

                    ACIKLAMA2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 0, 279, 5, false);
                    ACIKLAMA2.Name = "ACIKLAMA2";
                    ACIKLAMA2.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA2.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA2.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA2.TextFont.Name = "Arial";
                    ACIKLAMA2.TextFont.Size = 5;
                    ACIKLAMA2.TextFont.CharSet = 162;
                    ACIKLAMA2.Value = @"{#DESCRIPTION#}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 1, 297, 6, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class dataset_GetPiyasaArastirmaTutanagiNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>(0);
                    ORDERNO111.CalcValue = ParentGroup.GroupCounter.ToString();
                    MALZEMEADI111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTName) : "");
                    AMOUNT111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Amount) : "");
                    OLCUBIRIMI111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.DistributionType) : "");
                    IHTIYACSUTKODU111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTCode) : "");
                    SUTFIYATI111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTPrice) : "");
                    TTOBJECTID.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.ObjectID) : "");
                    FIRMAOBJECTID3.CalcValue = MyParentReport.FIRM2.FIRMAOBJECTID3.CalcValue;
                    FIRMAOBJECTID4.CalcValue = MyParentReport.FIRM2.FIRMAOBJECTID4.CalcValue;
                    FIRMAOBJECTID5.CalcValue = MyParentReport.FIRM2.FIRMAOBJECTID5.CalcValue;
                    ACIKLAMA2.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Description) : "");
                    CODELESSMATERIALNAME.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Codelessmaterialname) : "");
                    UBB4.CalcValue = @"";
                    SUTKODU4.CalcValue = @"";
                    FIYAT4.CalcValue = @"";
                    TUTAR4.CalcValue = @"";
                    DURUM4.CalcValue = @"";
                    UBB5.CalcValue = @"";
                    SUTKODU5.CalcValue = @"";
                    FIYAT5.CalcValue = @"";
                    TUTAR5.CalcValue = @"";
                    DURUM5.CalcValue = @"";
                    UBB3.CalcValue = @"";
                    SUTKODU3.CalcValue = @"";
                    FIYAT3.CalcValue = @"";
                    TUTAR3.CalcValue = @"";
                    DURUM3.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO111,MALZEMEADI111,AMOUNT111,OLCUBIRIMI111,IHTIYACSUTKODU111,SUTFIYATI111,TTOBJECTID,FIRMAOBJECTID3,FIRMAOBJECTID4,FIRMAOBJECTID5,ACIKLAMA2,CODELESSMATERIALNAME,UBB4,SUTKODU4,FIYAT4,TUTAR4,DURUM4,UBB5,SUTKODU5,FIYAT5,TUTAR5,DURUM5,UBB3,SUTKODU3,FIYAT3,TUTAR3,DURUM3};
                }

                public override void RunScript()
                {
#region BODY2 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, TTOBJECTID.CalcValue);
            
            //            if (firmPriceOfferList.Count > 3)
            //            {
            
            if(!string.IsNullOrEmpty(this.FIRMAOBJECTID3.CalcValue) || !string.IsNullOrEmpty(this.FIRMAOBJECTID4.CalcValue) || !string.IsNullOrEmpty(this.FIRMAOBJECTID5.CalcValue) )
                this.Visible = EvetHayirEnum.ehEvet;
            
            TTReportField rf;
            for (int i = 0; i < firmPriceOfferList.Count; i++)
            {
                DPADetailFirmPriceOffer firmPriceOffer = (DPADetailFirmPriceOffer)ctx.GetObject(new Guid(firmPriceOfferList[i].ObjectID.ToString()), typeof(DPADetailFirmPriceOffer));
                if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID3.CalcValue)
                {
                    rf = FieldsByName("UBB3");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU3");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT3");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR3");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM3");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
                else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID4.CalcValue)
                {
                    rf = FieldsByName("UBB4");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU4");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT4");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR4");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM4");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
                else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID5.CalcValue)
                {
                    rf = FieldsByName("UBB5");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU5");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT5");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR5");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM5");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
            }
            //  }
#endregion BODY2 BODY_Script
                }
            }

        }

        public BODY2Group BODY2;

        public partial class FIRM3Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public FIRM3GroupHeader Header()
            {
                return (FIRM3GroupHeader)_header;
            }

            new public FIRM3GroupFooter Footer()
            {
                return (FIRM3GroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField FIRMAMETIN7 { get {return Header().FIRMAMETIN7;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField FIRMAMETIN8 { get {return Header().FIRMAMETIN8;} }
            public TTReportField FIRMAMETIN6 { get {return Header().FIRMAMETIN6;} }
            public TTReportField MIKTAR111 { get {return Header().MIKTAR111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField MIKTAR1111 { get {return Header().MIKTAR1111;} }
            public TTReportField TXTUBB101 { get {return Header().TXTUBB101;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField UBB1101 { get {return Header().UBB1101;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField111421 { get {return Header().NewField111421;} }
            public TTReportField NewField1114111 { get {return Header().NewField1114111;} }
            public TTReportField UBB1111 { get {return Header().UBB1111;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField111431 { get {return Header().NewField111431;} }
            public TTReportField NewField1114121 { get {return Header().NewField1114121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public TTReportField FIRMAOBJECTID6 { get {return Header().FIRMAOBJECTID6;} }
            public TTReportField FIRMAOBJECTID7 { get {return Header().FIRMAOBJECTID7;} }
            public TTReportField FIRMAOBJECTID8 { get {return Header().FIRMAOBJECTID8;} }
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
                _body = null;
                _header = new FIRM3GroupHeader(this);
                _footer = new FIRM3GroupFooter(this);

            }

            public partial class FIRM3GroupHeader : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField FIRMAMETIN7;
                public TTReportField NewField1131;
                public TTReportField FIRMAMETIN8;
                public TTReportField FIRMAMETIN6;
                public TTReportField MIKTAR111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField MIKTAR1111;
                public TTReportField TXTUBB101;
                public TTReportField NewField121;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField UBB1101;
                public TTReportField NewField1151;
                public TTReportField NewField11421;
                public TTReportField NewField111421;
                public TTReportField NewField1114111;
                public TTReportField UBB1111;
                public TTReportField NewField1161;
                public TTReportField NewField11431;
                public TTReportField NewField111431;
                public TTReportField NewField1114121;
                public TTReportField NewField131;
                public TTReportField TTOBJECTID;
                public TTReportField FIRMAOBJECTID6;
                public TTReportField FIRMAOBJECTID7;
                public TTReportField FIRMAOBJECTID8; 
                public FIRM3GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 2, 8, 25, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 6;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"S. Nu.";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 2, 74, 25, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 6;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Malzemenin Adı";

                    FIRMAMETIN7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 7, 202, 12, false);
                    FIRMAMETIN7.Name = "FIRMAMETIN7";
                    FIRMAMETIN7.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN7.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN7.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN7.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN7.TextFont.Name = "Arial";
                    FIRMAMETIN7.TextFont.Size = 5;
                    FIRMAMETIN7.TextFont.Bold = true;
                    FIRMAMETIN7.TextFont.CharSet = 162;
                    FIRMAMETIN7.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 259, 7, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 6;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 7, 259, 12, false);
                    FIRMAMETIN8.Name = "FIRMAMETIN8";
                    FIRMAMETIN8.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN8.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN8.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN8.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN8.TextFont.Name = "Arial";
                    FIRMAMETIN8.TextFont.Size = 5;
                    FIRMAMETIN8.TextFont.Bold = true;
                    FIRMAMETIN8.TextFont.CharSet = 162;
                    FIRMAMETIN8.Value = @"";

                    FIRMAMETIN6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 7, 145, 12, false);
                    FIRMAMETIN6.Name = "FIRMAMETIN6";
                    FIRMAMETIN6.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN6.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN6.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN6.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN6.TextFont.Name = "Arial";
                    FIRMAMETIN6.TextFont.Size = 5;
                    FIRMAMETIN6.TextFont.Bold = true;
                    FIRMAMETIN6.TextFont.CharSet = 162;
                    FIRMAMETIN6.Value = @"";

                    MIKTAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 7, 80, 25, false);
                    MIKTAR111.Name = "MIKTAR111";
                    MIKTAR111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR111.TextFont.Name = "Arial";
                    MIKTAR111.TextFont.Size = 6;
                    MIKTAR111.TextFont.Bold = true;
                    MIKTAR111.TextFont.CharSet = 162;
                    MIKTAR111.Value = @"İhti- yaç Mik- tarı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 15, 25, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 6;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İhtiyaç SUT / İşlem Kodu";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 2, 25, 25, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 6;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İhtiyaç SUT / İşlem Fiyatı";

                    MIKTAR1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 7, 88, 25, false);
                    MIKTAR1111.Name = "MIKTAR1111";
                    MIKTAR1111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR1111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR1111.TextFont.Name = "Arial";
                    MIKTAR1111.TextFont.Size = 6;
                    MIKTAR1111.TextFont.Bold = true;
                    MIKTAR1111.TextFont.CharSet = 162;
                    MIKTAR1111.Value = @"Ölçü Birimi";

                    TXTUBB101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 12, 108, 25, false);
                    TXTUBB101.Name = "TXTUBB101";
                    TXTUBB101.DrawStyle = DrawStyleConstants.vbSolid;
                    TXTUBB101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TXTUBB101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TXTUBB101.MultiLine = EvetHayirEnum.ehEvet;
                    TXTUBB101.WordBreak = EvetHayirEnum.ehEvet;
                    TXTUBB101.TextFont.Name = "Arial";
                    TXTUBB101.TextFont.Size = 6;
                    TXTUBB101.TextFont.Bold = true;
                    TXTUBB101.TextFont.CharSet = 162;
                    TXTUBB101.Value = @"Teklif Ettiği UBB";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 12, 117, 25, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 6;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Teklif Ettiği SUT Kodu";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 12, 127, 25, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 6;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Birim Fiyat (TL)";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 12, 137, 25, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 6;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Tutarı (TL)";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 12, 145, 25, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111411.TextFont.Name = "Arial";
                    NewField111411.TextFont.Size = 6;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Kabul veya Red";

                    UBB1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 12, 165, 25, false);
                    UBB1101.Name = "UBB1101";
                    UBB1101.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB1101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB1101.MultiLine = EvetHayirEnum.ehEvet;
                    UBB1101.WordBreak = EvetHayirEnum.ehEvet;
                    UBB1101.TextFont.Name = "Arial";
                    UBB1101.TextFont.Size = 6;
                    UBB1101.TextFont.Bold = true;
                    UBB1101.TextFont.CharSet = 162;
                    UBB1101.Value = @"Teklif Ettiği UBB";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 12, 174, 25, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Size = 6;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Teklif Ettiği SUT Kodu";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 12, 184, 25, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11421.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11421.TextFont.Name = "Arial";
                    NewField11421.TextFont.Size = 6;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"Birim Fiyat (TL)";

                    NewField111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 12, 194, 25, false);
                    NewField111421.Name = "NewField111421";
                    NewField111421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111421.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111421.TextFont.Name = "Arial";
                    NewField111421.TextFont.Size = 6;
                    NewField111421.TextFont.Bold = true;
                    NewField111421.TextFont.CharSet = 162;
                    NewField111421.Value = @"Tutarı (TL)";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 12, 202, 25, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114111.TextFont.Name = "Arial";
                    NewField1114111.TextFont.Size = 6;
                    NewField1114111.TextFont.Bold = true;
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @"Kabul veya Red";

                    UBB1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 12, 222, 25, false);
                    UBB1111.Name = "UBB1111";
                    UBB1111.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB1111.MultiLine = EvetHayirEnum.ehEvet;
                    UBB1111.WordBreak = EvetHayirEnum.ehEvet;
                    UBB1111.TextFont.Name = "Arial";
                    UBB1111.TextFont.Size = 6;
                    UBB1111.TextFont.Bold = true;
                    UBB1111.TextFont.CharSet = 162;
                    UBB1111.Value = @"Teklif Ettiği UBB";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 12, 231, 25, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 6;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Teklif Ettiği SUT Kodu";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 12, 241, 25, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11431.TextFont.Name = "Arial";
                    NewField11431.TextFont.Size = 6;
                    NewField11431.TextFont.Bold = true;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"Birim Fiyat (TL)";

                    NewField111431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 12, 251, 25, false);
                    NewField111431.Name = "NewField111431";
                    NewField111431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111431.TextFont.Name = "Arial";
                    NewField111431.TextFont.Size = 6;
                    NewField111431.TextFont.Bold = true;
                    NewField111431.TextFont.CharSet = 162;
                    NewField111431.Value = @"Tutarı (TL)";

                    NewField1114121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 12, 259, 25, false);
                    NewField1114121.Name = "NewField1114121";
                    NewField1114121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114121.TextFont.Name = "Arial";
                    NewField1114121.TextFont.Size = 6;
                    NewField1114121.TextFont.Bold = true;
                    NewField1114121.TextFont.CharSet = 162;
                    NewField1114121.Value = @"Kabul veya Red";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 2, 279, 25, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 6;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Açıklama";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 25, 323, 30, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 6;
                    TTOBJECTID.TextFont.Bold = true;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#BASLIK.OBJECTID#}";

                    FIRMAOBJECTID6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 3, 322, 8, false);
                    FIRMAOBJECTID6.Name = "FIRMAOBJECTID6";
                    FIRMAOBJECTID6.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID6.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID6.TextFont.Name = "Arial";
                    FIRMAOBJECTID6.TextFont.Size = 6;
                    FIRMAOBJECTID6.TextFont.Bold = true;
                    FIRMAOBJECTID6.TextFont.CharSet = 162;
                    FIRMAOBJECTID6.Value = @"";

                    FIRMAOBJECTID7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 9, 322, 14, false);
                    FIRMAOBJECTID7.Name = "FIRMAOBJECTID7";
                    FIRMAOBJECTID7.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID7.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID7.TextFont.Name = "Arial";
                    FIRMAOBJECTID7.TextFont.Size = 6;
                    FIRMAOBJECTID7.TextFont.Bold = true;
                    FIRMAOBJECTID7.TextFont.CharSet = 162;
                    FIRMAOBJECTID7.Value = @"";

                    FIRMAOBJECTID8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 16, 322, 21, false);
                    FIRMAOBJECTID8.Name = "FIRMAOBJECTID8";
                    FIRMAOBJECTID8.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID8.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID8.TextFont.Name = "Arial";
                    FIRMAOBJECTID8.TextFont.Size = 6;
                    FIRMAOBJECTID8.TextFont.Bold = true;
                    FIRMAOBJECTID8.TextFont.CharSet = 162;
                    FIRMAOBJECTID8.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = MyParentReport.BASLIK.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    FIRMAMETIN7.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    FIRMAMETIN8.CalcValue = @"";
                    FIRMAMETIN6.CalcValue = @"";
                    MIKTAR111.CalcValue = MIKTAR111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    MIKTAR1111.CalcValue = MIKTAR1111.Value;
                    TXTUBB101.CalcValue = TXTUBB101.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    UBB1101.CalcValue = UBB1101.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField111421.CalcValue = NewField111421.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    UBB1111.CalcValue = UBB1111.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField111431.CalcValue = NewField111431.Value;
                    NewField1114121.CalcValue = NewField1114121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    TTOBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    FIRMAOBJECTID6.CalcValue = @"";
                    FIRMAOBJECTID7.CalcValue = @"";
                    FIRMAOBJECTID8.CalcValue = @"";
                    return new TTReportObject[] { NewField111,NewField1121,FIRMAMETIN7,NewField1131,FIRMAMETIN8,FIRMAMETIN6,MIKTAR111,NewField1111,NewField11111,MIKTAR1111,TXTUBB101,NewField121,NewField1141,NewField11411,NewField111411,UBB1101,NewField1151,NewField11421,NewField111421,NewField1114111,UBB1111,NewField1161,NewField11431,NewField111431,NewField1114121,NewField131,TTOBJECTID,FIRMAOBJECTID6,FIRMAOBJECTID7,FIRMAOBJECTID8};
                }

                public override void RunScript()
                {
#region FIRM3 HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = new  BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class>();
            BindingList<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class> details = DirectPurchaseActionDetail.MaterialRequestFormReportNQL(ctx, TTOBJECTID.CalcValue);
            foreach(DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class detail in details )
            {
                BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> padfirmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, detail.ObjectID.ToString());
                foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class padfirmPriceOffer in padfirmPriceOfferList )
                {
                    bool firmaEkle = true;
                    foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class firmPriceOffer in firmPriceOfferList)
                    {
                        if(padfirmPriceOffer.Firmaobjectid == firmPriceOffer.Firmaobjectid)
                            firmaEkle = false;
                    }
                    if(firmaEkle == true)
                        firmPriceOfferList.Add(padfirmPriceOffer);
                }
            }
            
            if (firmPriceOfferList.Count > 6)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                
                int repeatNO;
                if (firmPriceOfferList.Count > 9)
                    repeatNO = 9;
                else
                    repeatNO = firmPriceOfferList.Count;

                TTReportField rf;
                for (int i = 6; i < repeatNO; i++)
                {
                    rf = FieldsByName("FIRMAMETIN" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firm != null ? firmPriceOfferList[i].Firm.ToString() : null;

                    rf = FieldsByName("FIRMAOBJECTID" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firmaobjectid != null ? firmPriceOfferList[i].Firmaobjectid.ToString() : null;

                }
            }
#endregion FIRM3 HEADER_Script
                }
            }
            public partial class FIRM3GroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                 
                public FIRM3GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FIRM3Group FIRM3;

        public partial class BODY3Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public BODY3GroupBody Body()
            {
                return (BODY3GroupBody)_body;
            }
            public TTReportField ORDERNO1111 { get {return Body().ORDERNO1111;} }
            public TTReportField MALZEMEADI1111 { get {return Body().MALZEMEADI1111;} }
            public TTReportField AMOUNT1111 { get {return Body().AMOUNT1111;} }
            public TTReportField OLCUBIRIMI1111 { get {return Body().OLCUBIRIMI1111;} }
            public TTReportField IHTIYACSUTKODU1111 { get {return Body().IHTIYACSUTKODU1111;} }
            public TTReportField SUTFIYATI1111 { get {return Body().SUTFIYATI1111;} }
            public TTReportField UBB7 { get {return Body().UBB7;} }
            public TTReportField SUTKODU7 { get {return Body().SUTKODU7;} }
            public TTReportField FIYAT7 { get {return Body().FIYAT7;} }
            public TTReportField TUTAR7 { get {return Body().TUTAR7;} }
            public TTReportField DURUM7 { get {return Body().DURUM7;} }
            public TTReportField UBB8 { get {return Body().UBB8;} }
            public TTReportField SUTKODU8 { get {return Body().SUTKODU8;} }
            public TTReportField FIYAT8 { get {return Body().FIYAT8;} }
            public TTReportField TUTAR8 { get {return Body().TUTAR8;} }
            public TTReportField DURUM8 { get {return Body().DURUM8;} }
            public TTReportField ACIKLAMA3 { get {return Body().ACIKLAMA3;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField UBB6 { get {return Body().UBB6;} }
            public TTReportField SUTKODU6 { get {return Body().SUTKODU6;} }
            public TTReportField FIYAT6 { get {return Body().FIYAT6;} }
            public TTReportField TUTAR6 { get {return Body().TUTAR6;} }
            public TTReportField DURUM6 { get {return Body().DURUM6;} }
            public TTReportField FIRMAOBJECTID6 { get {return Body().FIRMAOBJECTID6;} }
            public TTReportField FIRMAOBJECTID7 { get {return Body().FIRMAOBJECTID7;} }
            public TTReportField FIRMAOBJECTID8 { get {return Body().FIRMAOBJECTID8;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public BODY3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BODY3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>("GetPiyasaArastirmaTutanagiNQL", DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BODY3GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class BODY3GroupBody : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField ORDERNO1111;
                public TTReportField MALZEMEADI1111;
                public TTReportField AMOUNT1111;
                public TTReportField OLCUBIRIMI1111;
                public TTReportField IHTIYACSUTKODU1111;
                public TTReportField SUTFIYATI1111;
                public TTReportField UBB7;
                public TTReportField SUTKODU7;
                public TTReportField FIYAT7;
                public TTReportField TUTAR7;
                public TTReportField DURUM7;
                public TTReportField UBB8;
                public TTReportField SUTKODU8;
                public TTReportField FIYAT8;
                public TTReportField TUTAR8;
                public TTReportField DURUM8;
                public TTReportField ACIKLAMA3;
                public TTReportField TTOBJECTID;
                public TTReportField UBB6;
                public TTReportField SUTKODU6;
                public TTReportField FIYAT6;
                public TTReportField TUTAR6;
                public TTReportField DURUM6;
                public TTReportField FIRMAOBJECTID6;
                public TTReportField FIRMAOBJECTID7;
                public TTReportField FIRMAOBJECTID8;
                public TTReportField CODELESSMATERIALNAME; 
                public BODY3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ORDERNO1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 8, 5, false);
                    ORDERNO1111.Name = "ORDERNO1111";
                    ORDERNO1111.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO1111.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO1111.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO1111.TextFont.Name = "Arial";
                    ORDERNO1111.TextFont.Size = 5;
                    ORDERNO1111.TextFont.CharSet = 162;
                    ORDERNO1111.Value = @"{@groupcounter@}";

                    MALZEMEADI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 74, 5, false);
                    MALZEMEADI1111.Name = "MALZEMEADI1111";
                    MALZEMEADI1111.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI1111.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADI1111.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADI1111.TextFont.Name = "Arial";
                    MALZEMEADI1111.TextFont.Size = 5;
                    MALZEMEADI1111.TextFont.CharSet = 162;
                    MALZEMEADI1111.Value = @"{#SUTNAME#}";

                    AMOUNT1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 80, 5, false);
                    AMOUNT1111.Name = "AMOUNT1111";
                    AMOUNT1111.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1111.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT1111.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT1111.TextFont.Name = "Arial";
                    AMOUNT1111.TextFont.Size = 5;
                    AMOUNT1111.TextFont.CharSet = 162;
                    AMOUNT1111.Value = @"{#AMOUNT#}";

                    OLCUBIRIMI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    OLCUBIRIMI1111.Name = "OLCUBIRIMI1111";
                    OLCUBIRIMI1111.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI1111.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI1111.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI1111.TextFont.Name = "Arial";
                    OLCUBIRIMI1111.TextFont.Size = 5;
                    OLCUBIRIMI1111.TextFont.CharSet = 162;
                    OLCUBIRIMI1111.Value = @"{#DISTRIBUTIONTYPE#}";

                    IHTIYACSUTKODU1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 15, 5, false);
                    IHTIYACSUTKODU1111.Name = "IHTIYACSUTKODU1111";
                    IHTIYACSUTKODU1111.DrawStyle = DrawStyleConstants.vbSolid;
                    IHTIYACSUTKODU1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHTIYACSUTKODU1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHTIYACSUTKODU1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHTIYACSUTKODU1111.MultiLine = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU1111.WordBreak = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU1111.TextFont.Name = "Arial";
                    IHTIYACSUTKODU1111.TextFont.Size = 5;
                    IHTIYACSUTKODU1111.TextFont.CharSet = 162;
                    IHTIYACSUTKODU1111.Value = @"{#SUTCODE#}";

                    SUTFIYATI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 25, 5, false);
                    SUTFIYATI1111.Name = "SUTFIYATI1111";
                    SUTFIYATI1111.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYATI1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYATI1111.TextFormat = @"#,##0.#0";
                    SUTFIYATI1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUTFIYATI1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYATI1111.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYATI1111.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYATI1111.TextFont.Name = "Arial";
                    SUTFIYATI1111.TextFont.Size = 5;
                    SUTFIYATI1111.TextFont.CharSet = 162;
                    SUTFIYATI1111.Value = @"{#SUTPRICE#}";

                    UBB7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 165, 5, false);
                    UBB7.Name = "UBB7";
                    UBB7.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB7.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB7.MultiLine = EvetHayirEnum.ehEvet;
                    UBB7.WordBreak = EvetHayirEnum.ehEvet;
                    UBB7.TextFont.Name = "Arial";
                    UBB7.TextFont.Size = 5;
                    UBB7.TextFont.CharSet = 162;
                    UBB7.Value = @"";

                    SUTKODU7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 174, 5, false);
                    SUTKODU7.Name = "SUTKODU7";
                    SUTKODU7.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU7.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU7.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU7.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU7.TextFont.Name = "Arial";
                    SUTKODU7.TextFont.Size = 5;
                    SUTKODU7.TextFont.CharSet = 162;
                    SUTKODU7.Value = @"";

                    FIYAT7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 184, 5, false);
                    FIYAT7.Name = "FIYAT7";
                    FIYAT7.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT7.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT7.TextFormat = @"#,##0.#0";
                    FIYAT7.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT7.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT7.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT7.TextFont.Name = "Arial";
                    FIYAT7.TextFont.Size = 5;
                    FIYAT7.TextFont.CharSet = 162;
                    FIYAT7.Value = @"";

                    TUTAR7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 194, 5, false);
                    TUTAR7.Name = "TUTAR7";
                    TUTAR7.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR7.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR7.TextFormat = @"#,##0.#0";
                    TUTAR7.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR7.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR7.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR7.TextFont.Name = "Arial";
                    TUTAR7.TextFont.Size = 5;
                    TUTAR7.TextFont.CharSet = 162;
                    TUTAR7.Value = @"";

                    DURUM7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 0, 202, 5, false);
                    DURUM7.Name = "DURUM7";
                    DURUM7.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM7.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM7.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM7.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM7.TextFont.Name = "Wingdings";
                    DURUM7.TextFont.Size = 7;
                    DURUM7.TextFont.CharSet = 2;
                    DURUM7.Value = @"";

                    UBB8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 222, 5, false);
                    UBB8.Name = "UBB8";
                    UBB8.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB8.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB8.MultiLine = EvetHayirEnum.ehEvet;
                    UBB8.WordBreak = EvetHayirEnum.ehEvet;
                    UBB8.TextFont.Name = "Arial";
                    UBB8.TextFont.Size = 5;
                    UBB8.TextFont.CharSet = 162;
                    UBB8.Value = @"";

                    SUTKODU8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 231, 5, false);
                    SUTKODU8.Name = "SUTKODU8";
                    SUTKODU8.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU8.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU8.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU8.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU8.TextFont.Name = "Arial";
                    SUTKODU8.TextFont.Size = 5;
                    SUTKODU8.TextFont.CharSet = 162;
                    SUTKODU8.Value = @"";

                    FIYAT8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 241, 5, false);
                    FIYAT8.Name = "FIYAT8";
                    FIYAT8.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT8.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT8.TextFormat = @"#,##0.#0";
                    FIYAT8.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT8.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT8.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT8.TextFont.Name = "Arial";
                    FIYAT8.TextFont.Size = 5;
                    FIYAT8.TextFont.CharSet = 162;
                    FIYAT8.Value = @"";

                    TUTAR8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 251, 5, false);
                    TUTAR8.Name = "TUTAR8";
                    TUTAR8.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR8.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR8.TextFormat = @"#,##0.#0";
                    TUTAR8.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR8.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR8.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR8.TextFont.Name = "Arial";
                    TUTAR8.TextFont.Size = 5;
                    TUTAR8.TextFont.CharSet = 162;
                    TUTAR8.Value = @"";

                    DURUM8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 0, 259, 5, false);
                    DURUM8.Name = "DURUM8";
                    DURUM8.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM8.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM8.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM8.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM8.TextFont.Name = "Wingdings";
                    DURUM8.TextFont.Size = 7;
                    DURUM8.TextFont.CharSet = 2;
                    DURUM8.Value = @"";

                    ACIKLAMA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 0, 279, 5, false);
                    ACIKLAMA3.Name = "ACIKLAMA3";
                    ACIKLAMA3.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA3.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA3.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA3.TextFont.Name = "Arial";
                    ACIKLAMA3.TextFont.Size = 5;
                    ACIKLAMA3.TextFont.CharSet = 162;
                    ACIKLAMA3.Value = @"{#DESCRIPTION#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 323, 5, 348, 10, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 5;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#OBJECTID#}";

                    UBB6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 108, 5, false);
                    UBB6.Name = "UBB6";
                    UBB6.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB6.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB6.MultiLine = EvetHayirEnum.ehEvet;
                    UBB6.WordBreak = EvetHayirEnum.ehEvet;
                    UBB6.TextFont.Name = "Arial";
                    UBB6.TextFont.Size = 5;
                    UBB6.TextFont.CharSet = 162;
                    UBB6.Value = @"";

                    SUTKODU6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 117, 5, false);
                    SUTKODU6.Name = "SUTKODU6";
                    SUTKODU6.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU6.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU6.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU6.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU6.TextFont.Name = "Arial";
                    SUTKODU6.TextFont.Size = 5;
                    SUTKODU6.TextFont.CharSet = 162;
                    SUTKODU6.Value = @"";

                    FIYAT6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 127, 5, false);
                    FIYAT6.Name = "FIYAT6";
                    FIYAT6.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT6.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT6.TextFormat = @"#,##0.#0";
                    FIYAT6.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT6.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT6.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT6.TextFont.Name = "Arial";
                    FIYAT6.TextFont.Size = 5;
                    FIYAT6.TextFont.CharSet = 162;
                    FIYAT6.Value = @"";

                    TUTAR6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 137, 5, false);
                    TUTAR6.Name = "TUTAR6";
                    TUTAR6.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR6.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR6.TextFormat = @"#,##0.#0";
                    TUTAR6.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR6.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR6.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR6.TextFont.Name = "Arial";
                    TUTAR6.TextFont.Size = 5;
                    TUTAR6.TextFont.CharSet = 162;
                    TUTAR6.Value = @"";

                    DURUM6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 145, 5, false);
                    DURUM6.Name = "DURUM6";
                    DURUM6.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM6.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM6.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM6.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM6.TextFont.Name = "Wingdings";
                    DURUM6.TextFont.Size = 7;
                    DURUM6.TextFont.CharSet = 2;
                    DURUM6.Value = @"";

                    FIRMAOBJECTID6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 0, 322, 5, false);
                    FIRMAOBJECTID6.Name = "FIRMAOBJECTID6";
                    FIRMAOBJECTID6.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID6.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID6.TextFont.Name = "Arial";
                    FIRMAOBJECTID6.TextFont.Size = 5;
                    FIRMAOBJECTID6.TextFont.CharSet = 162;
                    FIRMAOBJECTID6.Value = @"{%FIRM3.FIRMAOBJECTID6%}";

                    FIRMAOBJECTID7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 6, 322, 11, false);
                    FIRMAOBJECTID7.Name = "FIRMAOBJECTID7";
                    FIRMAOBJECTID7.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID7.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID7.TextFont.Name = "Arial";
                    FIRMAOBJECTID7.TextFont.Size = 5;
                    FIRMAOBJECTID7.TextFont.CharSet = 162;
                    FIRMAOBJECTID7.Value = @"{%FIRM3.FIRMAOBJECTID7%}";

                    FIRMAOBJECTID8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 323, -1, 348, 4, false);
                    FIRMAOBJECTID8.Name = "FIRMAOBJECTID8";
                    FIRMAOBJECTID8.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID8.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID8.TextFont.Name = "Arial";
                    FIRMAOBJECTID8.TextFont.Size = 5;
                    FIRMAOBJECTID8.TextFont.CharSet = 162;
                    FIRMAOBJECTID8.Value = @"{%FIRM3.FIRMAOBJECTID8%}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 0, 297, 5, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class dataset_GetPiyasaArastirmaTutanagiNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>(0);
                    ORDERNO1111.CalcValue = ParentGroup.GroupCounter.ToString();
                    MALZEMEADI1111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTName) : "");
                    AMOUNT1111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Amount) : "");
                    OLCUBIRIMI1111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.DistributionType) : "");
                    IHTIYACSUTKODU1111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTCode) : "");
                    SUTFIYATI1111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTPrice) : "");
                    ACIKLAMA3.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Description) : "");
                    TTOBJECTID.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.ObjectID) : "");
                    FIRMAOBJECTID6.CalcValue = MyParentReport.FIRM3.FIRMAOBJECTID6.CalcValue;
                    FIRMAOBJECTID7.CalcValue = MyParentReport.FIRM3.FIRMAOBJECTID7.CalcValue;
                    FIRMAOBJECTID8.CalcValue = MyParentReport.FIRM3.FIRMAOBJECTID8.CalcValue;
                    CODELESSMATERIALNAME.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Codelessmaterialname) : "");
                    UBB7.CalcValue = @"";
                    SUTKODU7.CalcValue = @"";
                    FIYAT7.CalcValue = @"";
                    TUTAR7.CalcValue = @"";
                    DURUM7.CalcValue = @"";
                    UBB8.CalcValue = @"";
                    SUTKODU8.CalcValue = @"";
                    FIYAT8.CalcValue = @"";
                    TUTAR8.CalcValue = @"";
                    DURUM8.CalcValue = @"";
                    UBB6.CalcValue = @"";
                    SUTKODU6.CalcValue = @"";
                    FIYAT6.CalcValue = @"";
                    TUTAR6.CalcValue = @"";
                    DURUM6.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO1111,MALZEMEADI1111,AMOUNT1111,OLCUBIRIMI1111,IHTIYACSUTKODU1111,SUTFIYATI1111,ACIKLAMA3,TTOBJECTID,FIRMAOBJECTID6,FIRMAOBJECTID7,FIRMAOBJECTID8,CODELESSMATERIALNAME,UBB7,SUTKODU7,FIYAT7,TUTAR7,DURUM7,UBB8,SUTKODU8,FIYAT8,TUTAR8,DURUM8,UBB6,SUTKODU6,FIYAT6,TUTAR6,DURUM6};
                }

                public override void RunScript()
                {
#region BODY3 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, TTOBJECTID.CalcValue);
            //            if (firmPriceOfferList.Count > 6)
            //            {
            if(!string.IsNullOrEmpty(this.FIRMAOBJECTID6.CalcValue) || !string.IsNullOrEmpty(this.FIRMAOBJECTID7.CalcValue) || !string.IsNullOrEmpty(this.FIRMAOBJECTID8.CalcValue) )
                this.Visible = EvetHayirEnum.ehEvet;
            
            TTReportField rf;
            for (int i = 0; i < firmPriceOfferList.Count; i++)
            {
                DPADetailFirmPriceOffer firmPriceOffer = (DPADetailFirmPriceOffer)ctx.GetObject(new Guid(firmPriceOfferList[i].ObjectID.ToString()), typeof(DPADetailFirmPriceOffer));
                if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID6.CalcValue)
                {
                    rf = FieldsByName("UBB6");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU6");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT6");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR6");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM6");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
                else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID7.CalcValue)
                {
                    rf = FieldsByName("UBB7");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU7");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT7");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR7");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM7");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
                else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID8.CalcValue)
                {
                    rf = FieldsByName("UBB8");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU8");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT8");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR8");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM8");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
            }
            //  }
#endregion BODY3 BODY_Script
                }
            }

        }

        public BODY3Group BODY3;

        public partial class FIRM4Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public FIRM4GroupHeader Header()
            {
                return (FIRM4GroupHeader)_header;
            }

            new public FIRM4GroupFooter Footer()
            {
                return (FIRM4GroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField FIRMAMETIN10 { get {return Header().FIRMAMETIN10;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField FIRMAMETIN11 { get {return Header().FIRMAMETIN11;} }
            public TTReportField FIRMAMETIN9 { get {return Header().FIRMAMETIN9;} }
            public TTReportField MIKTAR1111 { get {return Header().MIKTAR1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField MIKTAR11111 { get {return Header().MIKTAR11111;} }
            public TTReportField TXTUBB1101 { get {return Header().TXTUBB1101;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField1114111 { get {return Header().NewField1114111;} }
            public TTReportField UBB11011 { get {return Header().UBB11011;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField112411 { get {return Header().NewField112411;} }
            public TTReportField NewField1124111 { get {return Header().NewField1124111;} }
            public TTReportField NewField11114111 { get {return Header().NewField11114111;} }
            public TTReportField UBB11111 { get {return Header().UBB11111;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField NewField1134111 { get {return Header().NewField1134111;} }
            public TTReportField NewField11214111 { get {return Header().NewField11214111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public TTReportField FIRMAOBJECTID9 { get {return Header().FIRMAOBJECTID9;} }
            public TTReportField FIRMAOBJECTID10 { get {return Header().FIRMAOBJECTID10;} }
            public TTReportField FIRMAOBJECTID11 { get {return Header().FIRMAOBJECTID11;} }
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
                _body = null;
                _header = new FIRM4GroupHeader(this);
                _footer = new FIRM4GroupFooter(this);

            }

            public partial class FIRM4GroupHeader : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField11211;
                public TTReportField FIRMAMETIN10;
                public TTReportField NewField11311;
                public TTReportField FIRMAMETIN11;
                public TTReportField FIRMAMETIN9;
                public TTReportField MIKTAR1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField MIKTAR11111;
                public TTReportField TXTUBB1101;
                public TTReportField NewField1121;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField1114111;
                public TTReportField UBB11011;
                public TTReportField NewField11511;
                public TTReportField NewField112411;
                public TTReportField NewField1124111;
                public TTReportField NewField11114111;
                public TTReportField UBB11111;
                public TTReportField NewField11611;
                public TTReportField NewField113411;
                public TTReportField NewField1134111;
                public TTReportField NewField11214111;
                public TTReportField NewField1131;
                public TTReportField TTOBJECTID;
                public TTReportField FIRMAOBJECTID9;
                public TTReportField FIRMAOBJECTID10;
                public TTReportField FIRMAOBJECTID11; 
                public FIRM4GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 3, 8, 26, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 6;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"S. Nu.";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 3, 74, 26, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 6;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Malzemenin Adı";

                    FIRMAMETIN10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 8, 202, 13, false);
                    FIRMAMETIN10.Name = "FIRMAMETIN10";
                    FIRMAMETIN10.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN10.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN10.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN10.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN10.TextFont.Name = "Arial";
                    FIRMAMETIN10.TextFont.Size = 5;
                    FIRMAMETIN10.TextFont.Bold = true;
                    FIRMAMETIN10.TextFont.CharSet = 162;
                    FIRMAMETIN10.Value = @"";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 3, 259, 8, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 6;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Kişi / Firma ve Fiyat Teklifleri";

                    FIRMAMETIN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 8, 259, 13, false);
                    FIRMAMETIN11.Name = "FIRMAMETIN11";
                    FIRMAMETIN11.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN11.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN11.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN11.TextFont.Name = "Arial";
                    FIRMAMETIN11.TextFont.Size = 5;
                    FIRMAMETIN11.TextFont.Bold = true;
                    FIRMAMETIN11.TextFont.CharSet = 162;
                    FIRMAMETIN11.Value = @"";

                    FIRMAMETIN9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 8, 145, 13, false);
                    FIRMAMETIN9.Name = "FIRMAMETIN9";
                    FIRMAMETIN9.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN9.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAMETIN9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN9.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN9.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN9.TextFont.Name = "Arial";
                    FIRMAMETIN9.TextFont.Size = 5;
                    FIRMAMETIN9.TextFont.Bold = true;
                    FIRMAMETIN9.TextFont.CharSet = 162;
                    FIRMAMETIN9.Value = @"";

                    MIKTAR1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 8, 80, 26, false);
                    MIKTAR1111.Name = "MIKTAR1111";
                    MIKTAR1111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR1111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR1111.TextFont.Name = "Arial";
                    MIKTAR1111.TextFont.Size = 6;
                    MIKTAR1111.TextFont.Bold = true;
                    MIKTAR1111.TextFont.CharSet = 162;
                    MIKTAR1111.Value = @"İhti- yaç Mik- tarı";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 15, 26, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 6;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İhtiyaç SUT / İşlem Kodu";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 3, 25, 26, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 6;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"İhtiyaç SUT / İşlem Fiyatı";

                    MIKTAR11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 8, 88, 26, false);
                    MIKTAR11111.Name = "MIKTAR11111";
                    MIKTAR11111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR11111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR11111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR11111.TextFont.Name = "Arial";
                    MIKTAR11111.TextFont.Size = 6;
                    MIKTAR11111.TextFont.Bold = true;
                    MIKTAR11111.TextFont.CharSet = 162;
                    MIKTAR11111.Value = @"Ölçü Birimi";

                    TXTUBB1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 13, 108, 26, false);
                    TXTUBB1101.Name = "TXTUBB1101";
                    TXTUBB1101.DrawStyle = DrawStyleConstants.vbSolid;
                    TXTUBB1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TXTUBB1101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TXTUBB1101.MultiLine = EvetHayirEnum.ehEvet;
                    TXTUBB1101.WordBreak = EvetHayirEnum.ehEvet;
                    TXTUBB1101.TextFont.Name = "Arial";
                    TXTUBB1101.TextFont.Size = 6;
                    TXTUBB1101.TextFont.Bold = true;
                    TXTUBB1101.TextFont.CharSet = 162;
                    TXTUBB1101.Value = @"Teklif Ettiği UBB";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 13, 117, 26, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 6;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Teklif Ettiği SUT Kodu";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 13, 127, 26, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.TextFont.Size = 6;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Birim Fiyat (TL)";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 13, 137, 26, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111411.TextFont.Name = "Arial";
                    NewField111411.TextFont.Size = 6;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Tutarı (TL)";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 13, 145, 26, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114111.TextFont.Name = "Arial";
                    NewField1114111.TextFont.Size = 6;
                    NewField1114111.TextFont.Bold = true;
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @"Kabul veya Red";

                    UBB11011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 13, 165, 26, false);
                    UBB11011.Name = "UBB11011";
                    UBB11011.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB11011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB11011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB11011.MultiLine = EvetHayirEnum.ehEvet;
                    UBB11011.WordBreak = EvetHayirEnum.ehEvet;
                    UBB11011.TextFont.Name = "Arial";
                    UBB11011.TextFont.Size = 6;
                    UBB11011.TextFont.Bold = true;
                    UBB11011.TextFont.CharSet = 162;
                    UBB11011.Value = @"Teklif Ettiği UBB";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 13, 174, 26, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11511.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11511.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Size = 6;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Teklif Ettiği SUT Kodu";

                    NewField112411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 13, 184, 26, false);
                    NewField112411.Name = "NewField112411";
                    NewField112411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112411.TextFont.Name = "Arial";
                    NewField112411.TextFont.Size = 6;
                    NewField112411.TextFont.Bold = true;
                    NewField112411.TextFont.CharSet = 162;
                    NewField112411.Value = @"Birim Fiyat (TL)";

                    NewField1124111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 13, 194, 26, false);
                    NewField1124111.Name = "NewField1124111";
                    NewField1124111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1124111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1124111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1124111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1124111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1124111.TextFont.Name = "Arial";
                    NewField1124111.TextFont.Size = 6;
                    NewField1124111.TextFont.Bold = true;
                    NewField1124111.TextFont.CharSet = 162;
                    NewField1124111.Value = @"Tutarı (TL)";

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 13, 202, 26, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11114111.TextFont.Name = "Arial";
                    NewField11114111.TextFont.Size = 6;
                    NewField11114111.TextFont.Bold = true;
                    NewField11114111.TextFont.CharSet = 162;
                    NewField11114111.Value = @"Kabul veya Red";

                    UBB11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 13, 222, 26, false);
                    UBB11111.Name = "UBB11111";
                    UBB11111.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB11111.MultiLine = EvetHayirEnum.ehEvet;
                    UBB11111.WordBreak = EvetHayirEnum.ehEvet;
                    UBB11111.TextFont.Name = "Arial";
                    UBB11111.TextFont.Size = 6;
                    UBB11111.TextFont.Bold = true;
                    UBB11111.TextFont.CharSet = 162;
                    UBB11111.Value = @"Teklif Ettiği UBB";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 13, 231, 26, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 6;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Teklif Ettiği SUT Kodu";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 13, 241, 26, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113411.TextFont.Name = "Arial";
                    NewField113411.TextFont.Size = 6;
                    NewField113411.TextFont.Bold = true;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"Birim Fiyat (TL)";

                    NewField1134111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 13, 251, 26, false);
                    NewField1134111.Name = "NewField1134111";
                    NewField1134111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1134111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1134111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1134111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1134111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1134111.TextFont.Name = "Arial";
                    NewField1134111.TextFont.Size = 6;
                    NewField1134111.TextFont.Bold = true;
                    NewField1134111.TextFont.CharSet = 162;
                    NewField1134111.Value = @"Tutarı (TL)";

                    NewField11214111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 13, 259, 26, false);
                    NewField11214111.Name = "NewField11214111";
                    NewField11214111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11214111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214111.TextFont.Name = "Arial";
                    NewField11214111.TextFont.Size = 6;
                    NewField11214111.TextFont.Bold = true;
                    NewField11214111.TextFont.CharSet = 162;
                    NewField11214111.Value = @"Kabul veya Red";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 3, 279, 26, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 6;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Açıklama";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 26, 323, 31, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 6;
                    TTOBJECTID.TextFont.Bold = true;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#BASLIK.OBJECTID#}";

                    FIRMAOBJECTID9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 4, 322, 9, false);
                    FIRMAOBJECTID9.Name = "FIRMAOBJECTID9";
                    FIRMAOBJECTID9.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID9.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID9.TextFont.Name = "Arial";
                    FIRMAOBJECTID9.TextFont.Size = 6;
                    FIRMAOBJECTID9.TextFont.Bold = true;
                    FIRMAOBJECTID9.TextFont.CharSet = 162;
                    FIRMAOBJECTID9.Value = @"";

                    FIRMAOBJECTID10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 10, 322, 15, false);
                    FIRMAOBJECTID10.Name = "FIRMAOBJECTID10";
                    FIRMAOBJECTID10.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID10.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID10.TextFont.Name = "Arial";
                    FIRMAOBJECTID10.TextFont.Size = 6;
                    FIRMAOBJECTID10.TextFont.Bold = true;
                    FIRMAOBJECTID10.TextFont.CharSet = 162;
                    FIRMAOBJECTID10.Value = @"";

                    FIRMAOBJECTID11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 17, 322, 22, false);
                    FIRMAOBJECTID11.Name = "FIRMAOBJECTID11";
                    FIRMAOBJECTID11.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID11.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID11.TextFont.Name = "Arial";
                    FIRMAOBJECTID11.TextFont.Size = 6;
                    FIRMAOBJECTID11.TextFont.Bold = true;
                    FIRMAOBJECTID11.TextFont.CharSet = 162;
                    FIRMAOBJECTID11.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class dataset_MaterialRequestFormReportNewNQL = MyParentReport.BASLIK.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(0);
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    FIRMAMETIN10.CalcValue = @"";
                    NewField11311.CalcValue = NewField11311.Value;
                    FIRMAMETIN11.CalcValue = @"";
                    FIRMAMETIN9.CalcValue = @"";
                    MIKTAR1111.CalcValue = MIKTAR1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    MIKTAR11111.CalcValue = MIKTAR11111.Value;
                    TXTUBB1101.CalcValue = TXTUBB1101.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    UBB11011.CalcValue = UBB11011.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField112411.CalcValue = NewField112411.Value;
                    NewField1124111.CalcValue = NewField1124111.Value;
                    NewField11114111.CalcValue = NewField11114111.Value;
                    UBB11111.CalcValue = UBB11111.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    NewField1134111.CalcValue = NewField1134111.Value;
                    NewField11214111.CalcValue = NewField11214111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    TTOBJECTID.CalcValue = (dataset_MaterialRequestFormReportNewNQL != null ? Globals.ToStringCore(dataset_MaterialRequestFormReportNewNQL.ObjectID) : "");
                    FIRMAOBJECTID9.CalcValue = @"";
                    FIRMAOBJECTID10.CalcValue = @"";
                    FIRMAOBJECTID11.CalcValue = @"";
                    return new TTReportObject[] { NewField1111,NewField11211,FIRMAMETIN10,NewField11311,FIRMAMETIN11,FIRMAMETIN9,MIKTAR1111,NewField11111,NewField111111,MIKTAR11111,TXTUBB1101,NewField1121,NewField11411,NewField111411,NewField1114111,UBB11011,NewField11511,NewField112411,NewField1124111,NewField11114111,UBB11111,NewField11611,NewField113411,NewField1134111,NewField11214111,NewField1131,TTOBJECTID,FIRMAOBJECTID9,FIRMAOBJECTID10,FIRMAOBJECTID11};
                }

                public override void RunScript()
                {
#region FIRM4 HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = new  BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class>();
            BindingList<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class> details = DirectPurchaseActionDetail.MaterialRequestFormReportNQL(ctx, TTOBJECTID.CalcValue);
            foreach(DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class detail in details )
            {
                BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> padfirmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, detail.ObjectID.ToString());
                foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class padfirmPriceOffer in padfirmPriceOfferList )
                {
                    bool firmaEkle = true;
                    foreach(DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class firmPriceOffer in firmPriceOfferList)
                    {
                        if(padfirmPriceOffer.Firmaobjectid == firmPriceOffer.Firmaobjectid)
                            firmaEkle = false;
                    }
                    if(firmaEkle == true)
                        firmPriceOfferList.Add(padfirmPriceOffer);
                }
            }
            
            if (firmPriceOfferList.Count > 9)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                
                int repeatNO;
                if (firmPriceOfferList.Count > 12)
                    repeatNO = 12;
                else
                    repeatNO = firmPriceOfferList.Count;

                TTReportField rf;
                for (int i = 9; i < repeatNO; i++)
                {
                    rf = FieldsByName("FIRMAMETIN" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firm != null ? firmPriceOfferList[i].Firm.ToString() : null;

                    rf = FieldsByName("FIRMAOBJECTID" + i);
                    rf.CalcValue = firmPriceOfferList[i].Firmaobjectid != null ? firmPriceOfferList[i].Firmaobjectid.ToString() : null;

                }
            }
#endregion FIRM4 HEADER_Script
                }
            }
            public partial class FIRM4GroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                 
                public FIRM4GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FIRM4Group FIRM4;

        public partial class BODY4Group : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public BODY4GroupBody Body()
            {
                return (BODY4GroupBody)_body;
            }
            public TTReportField ORDERNO11111 { get {return Body().ORDERNO11111;} }
            public TTReportField MALZEMEADI11111 { get {return Body().MALZEMEADI11111;} }
            public TTReportField AMOUNT11111 { get {return Body().AMOUNT11111;} }
            public TTReportField OLCUBIRIMI11111 { get {return Body().OLCUBIRIMI11111;} }
            public TTReportField IHTIYACSUTKODU11111 { get {return Body().IHTIYACSUTKODU11111;} }
            public TTReportField SUTFIYATI11111 { get {return Body().SUTFIYATI11111;} }
            public TTReportField UBB10 { get {return Body().UBB10;} }
            public TTReportField SUTKODU10 { get {return Body().SUTKODU10;} }
            public TTReportField FIYAT10 { get {return Body().FIYAT10;} }
            public TTReportField TUTAR10 { get {return Body().TUTAR10;} }
            public TTReportField DURUM10 { get {return Body().DURUM10;} }
            public TTReportField UBB11 { get {return Body().UBB11;} }
            public TTReportField SUTKODU11 { get {return Body().SUTKODU11;} }
            public TTReportField FIYAT11 { get {return Body().FIYAT11;} }
            public TTReportField TUTAR11 { get {return Body().TUTAR11;} }
            public TTReportField DURUM11 { get {return Body().DURUM11;} }
            public TTReportField ACIKLAMA4 { get {return Body().ACIKLAMA4;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField UBB9 { get {return Body().UBB9;} }
            public TTReportField SUTKODU9 { get {return Body().SUTKODU9;} }
            public TTReportField FIYAT9 { get {return Body().FIYAT9;} }
            public TTReportField TUTAR9 { get {return Body().TUTAR9;} }
            public TTReportField DURUM9 { get {return Body().DURUM9;} }
            public TTReportField FIRMAOBJECTID9 { get {return Body().FIRMAOBJECTID9;} }
            public TTReportField FIRMAOBJECTID10 { get {return Body().FIRMAOBJECTID10;} }
            public TTReportField FIRMAOBJECTID11 { get {return Body().FIRMAOBJECTID11;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public BODY4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BODY4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>("GetPiyasaArastirmaTutanagiNQL", DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BODY4GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class BODY4GroupBody : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField ORDERNO11111;
                public TTReportField MALZEMEADI11111;
                public TTReportField AMOUNT11111;
                public TTReportField OLCUBIRIMI11111;
                public TTReportField IHTIYACSUTKODU11111;
                public TTReportField SUTFIYATI11111;
                public TTReportField UBB10;
                public TTReportField SUTKODU10;
                public TTReportField FIYAT10;
                public TTReportField TUTAR10;
                public TTReportField DURUM10;
                public TTReportField UBB11;
                public TTReportField SUTKODU11;
                public TTReportField FIYAT11;
                public TTReportField TUTAR11;
                public TTReportField DURUM11;
                public TTReportField ACIKLAMA4;
                public TTReportField TTOBJECTID;
                public TTReportField UBB9;
                public TTReportField SUTKODU9;
                public TTReportField FIYAT9;
                public TTReportField TUTAR9;
                public TTReportField DURUM9;
                public TTReportField FIRMAOBJECTID9;
                public TTReportField FIRMAOBJECTID10;
                public TTReportField FIRMAOBJECTID11;
                public TTReportField CODELESSMATERIALNAME; 
                public BODY4GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ORDERNO11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 8, 5, false);
                    ORDERNO11111.Name = "ORDERNO11111";
                    ORDERNO11111.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO11111.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO11111.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO11111.TextFont.Name = "Arial";
                    ORDERNO11111.TextFont.Size = 5;
                    ORDERNO11111.TextFont.CharSet = 162;
                    ORDERNO11111.Value = @"{@groupcounter@}";

                    MALZEMEADI11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 74, 5, false);
                    MALZEMEADI11111.Name = "MALZEMEADI11111";
                    MALZEMEADI11111.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI11111.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADI11111.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADI11111.TextFont.Name = "Arial";
                    MALZEMEADI11111.TextFont.Size = 5;
                    MALZEMEADI11111.TextFont.CharSet = 162;
                    MALZEMEADI11111.Value = @"{#SUTNAME#}";

                    AMOUNT11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 80, 5, false);
                    AMOUNT11111.Name = "AMOUNT11111";
                    AMOUNT11111.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT11111.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT11111.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT11111.TextFont.Name = "Arial";
                    AMOUNT11111.TextFont.Size = 5;
                    AMOUNT11111.TextFont.CharSet = 162;
                    AMOUNT11111.Value = @"{#AMOUNT#}";

                    OLCUBIRIMI11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    OLCUBIRIMI11111.Name = "OLCUBIRIMI11111";
                    OLCUBIRIMI11111.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI11111.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI11111.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI11111.TextFont.Name = "Arial";
                    OLCUBIRIMI11111.TextFont.Size = 5;
                    OLCUBIRIMI11111.TextFont.CharSet = 162;
                    OLCUBIRIMI11111.Value = @"{#DISTRIBUTIONTYPE#}";

                    IHTIYACSUTKODU11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 15, 5, false);
                    IHTIYACSUTKODU11111.Name = "IHTIYACSUTKODU11111";
                    IHTIYACSUTKODU11111.DrawStyle = DrawStyleConstants.vbSolid;
                    IHTIYACSUTKODU11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHTIYACSUTKODU11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHTIYACSUTKODU11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHTIYACSUTKODU11111.MultiLine = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU11111.WordBreak = EvetHayirEnum.ehEvet;
                    IHTIYACSUTKODU11111.TextFont.Name = "Arial";
                    IHTIYACSUTKODU11111.TextFont.Size = 5;
                    IHTIYACSUTKODU11111.TextFont.CharSet = 162;
                    IHTIYACSUTKODU11111.Value = @"{#SUTCODE#}";

                    SUTFIYATI11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 25, 5, false);
                    SUTFIYATI11111.Name = "SUTFIYATI11111";
                    SUTFIYATI11111.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYATI11111.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYATI11111.TextFormat = @"#,##0.#0";
                    SUTFIYATI11111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUTFIYATI11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYATI11111.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYATI11111.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYATI11111.TextFont.Name = "Arial";
                    SUTFIYATI11111.TextFont.Size = 5;
                    SUTFIYATI11111.TextFont.CharSet = 162;
                    SUTFIYATI11111.Value = @"{#SUTPRICE#}";

                    UBB10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 165, 5, false);
                    UBB10.Name = "UBB10";
                    UBB10.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB10.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB10.MultiLine = EvetHayirEnum.ehEvet;
                    UBB10.WordBreak = EvetHayirEnum.ehEvet;
                    UBB10.TextFont.Name = "Arial";
                    UBB10.TextFont.Size = 5;
                    UBB10.TextFont.CharSet = 162;
                    UBB10.Value = @"";

                    SUTKODU10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 174, 5, false);
                    SUTKODU10.Name = "SUTKODU10";
                    SUTKODU10.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU10.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU10.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU10.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU10.TextFont.Name = "Arial";
                    SUTKODU10.TextFont.Size = 5;
                    SUTKODU10.TextFont.CharSet = 162;
                    SUTKODU10.Value = @"";

                    FIYAT10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 184, 5, false);
                    FIYAT10.Name = "FIYAT10";
                    FIYAT10.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT10.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT10.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT10.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT10.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT10.TextFont.Name = "Arial";
                    FIYAT10.TextFont.Size = 5;
                    FIYAT10.TextFont.CharSet = 162;
                    FIYAT10.Value = @"";

                    TUTAR10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 194, 5, false);
                    TUTAR10.Name = "TUTAR10";
                    TUTAR10.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR10.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR10.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR10.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR10.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR10.TextFont.Name = "Arial";
                    TUTAR10.TextFont.Size = 5;
                    TUTAR10.TextFont.CharSet = 162;
                    TUTAR10.Value = @"";

                    DURUM10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 0, 202, 5, false);
                    DURUM10.Name = "DURUM10";
                    DURUM10.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM10.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM10.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM10.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM10.TextFont.Name = "Wingdings";
                    DURUM10.TextFont.Size = 7;
                    DURUM10.TextFont.CharSet = 2;
                    DURUM10.Value = @"";

                    UBB11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 222, 5, false);
                    UBB11.Name = "UBB11";
                    UBB11.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB11.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB11.MultiLine = EvetHayirEnum.ehEvet;
                    UBB11.WordBreak = EvetHayirEnum.ehEvet;
                    UBB11.TextFont.Name = "Arial";
                    UBB11.TextFont.Size = 5;
                    UBB11.TextFont.CharSet = 162;
                    UBB11.Value = @"";

                    SUTKODU11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 231, 5, false);
                    SUTKODU11.Name = "SUTKODU11";
                    SUTKODU11.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU11.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU11.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU11.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU11.TextFont.Name = "Arial";
                    SUTKODU11.TextFont.Size = 5;
                    SUTKODU11.TextFont.CharSet = 162;
                    SUTKODU11.Value = @"";

                    FIYAT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 241, 5, false);
                    FIYAT11.Name = "FIYAT11";
                    FIYAT11.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT11.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT11.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT11.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT11.TextFont.Name = "Arial";
                    FIYAT11.TextFont.Size = 5;
                    FIYAT11.TextFont.CharSet = 162;
                    FIYAT11.Value = @"";

                    TUTAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 251, 5, false);
                    TUTAR11.Name = "TUTAR11";
                    TUTAR11.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR11.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR11.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR11.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR11.TextFont.Name = "Arial";
                    TUTAR11.TextFont.Size = 5;
                    TUTAR11.TextFont.CharSet = 162;
                    TUTAR11.Value = @"";

                    DURUM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 0, 259, 5, false);
                    DURUM11.Name = "DURUM11";
                    DURUM11.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM11.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM11.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM11.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM11.TextFont.Name = "Wingdings";
                    DURUM11.TextFont.Size = 7;
                    DURUM11.TextFont.CharSet = 2;
                    DURUM11.Value = @"";

                    ACIKLAMA4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 0, 279, 5, false);
                    ACIKLAMA4.Name = "ACIKLAMA4";
                    ACIKLAMA4.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA4.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA4.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA4.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA4.TextFont.Name = "Arial";
                    ACIKLAMA4.TextFont.Size = 5;
                    ACIKLAMA4.TextFont.CharSet = 162;
                    ACIKLAMA4.Value = @"{#DESCRIPTION#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 322, 5, 347, 10, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial";
                    TTOBJECTID.TextFont.Size = 5;
                    TTOBJECTID.TextFont.CharSet = 162;
                    TTOBJECTID.Value = @"{#OBJECTID#}";

                    UBB9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 108, 5, false);
                    UBB9.Name = "UBB9";
                    UBB9.DrawStyle = DrawStyleConstants.vbSolid;
                    UBB9.FieldType = ReportFieldTypeEnum.ftExpression;
                    UBB9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBB9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBB9.MultiLine = EvetHayirEnum.ehEvet;
                    UBB9.WordBreak = EvetHayirEnum.ehEvet;
                    UBB9.TextFont.Name = "Arial";
                    UBB9.TextFont.Size = 5;
                    UBB9.TextFont.CharSet = 162;
                    UBB9.Value = @"";

                    SUTKODU9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 117, 5, false);
                    SUTKODU9.Name = "SUTKODU9";
                    SUTKODU9.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU9.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUTKODU9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU9.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU9.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU9.TextFont.Name = "Arial";
                    SUTKODU9.TextFont.Size = 5;
                    SUTKODU9.TextFont.CharSet = 162;
                    SUTKODU9.Value = @"";

                    FIYAT9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 127, 5, false);
                    FIYAT9.Name = "FIYAT9";
                    FIYAT9.DrawStyle = DrawStyleConstants.vbSolid;
                    FIYAT9.FieldType = ReportFieldTypeEnum.ftExpression;
                    FIYAT9.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FIYAT9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIYAT9.MultiLine = EvetHayirEnum.ehEvet;
                    FIYAT9.WordBreak = EvetHayirEnum.ehEvet;
                    FIYAT9.TextFont.Name = "Arial";
                    FIYAT9.TextFont.Size = 5;
                    FIYAT9.TextFont.CharSet = 162;
                    FIYAT9.Value = @"";

                    TUTAR9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 137, 5, false);
                    TUTAR9.Name = "TUTAR9";
                    TUTAR9.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR9.FieldType = ReportFieldTypeEnum.ftExpression;
                    TUTAR9.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR9.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR9.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR9.TextFont.Name = "Arial";
                    TUTAR9.TextFont.Size = 5;
                    TUTAR9.TextFont.CharSet = 162;
                    TUTAR9.Value = @"";

                    DURUM9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 145, 5, false);
                    DURUM9.Name = "DURUM9";
                    DURUM9.DrawStyle = DrawStyleConstants.vbSolid;
                    DURUM9.FieldType = ReportFieldTypeEnum.ftExpression;
                    DURUM9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURUM9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DURUM9.MultiLine = EvetHayirEnum.ehEvet;
                    DURUM9.WordBreak = EvetHayirEnum.ehEvet;
                    DURUM9.TextFont.Name = "Wingdings";
                    DURUM9.TextFont.Size = 7;
                    DURUM9.TextFont.CharSet = 2;
                    DURUM9.Value = @"";

                    FIRMAOBJECTID9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 0, 321, 5, false);
                    FIRMAOBJECTID9.Name = "FIRMAOBJECTID9";
                    FIRMAOBJECTID9.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID9.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID9.TextFont.Name = "Arial";
                    FIRMAOBJECTID9.TextFont.Size = 5;
                    FIRMAOBJECTID9.TextFont.CharSet = 162;
                    FIRMAOBJECTID9.Value = @"{%FIRM4.FIRMAOBJECTID9%}";

                    FIRMAOBJECTID10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 6, 321, 11, false);
                    FIRMAOBJECTID10.Name = "FIRMAOBJECTID10";
                    FIRMAOBJECTID10.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID10.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID10.TextFont.Name = "Arial";
                    FIRMAOBJECTID10.TextFont.Size = 5;
                    FIRMAOBJECTID10.TextFont.CharSet = 162;
                    FIRMAOBJECTID10.Value = @"{%FIRM4.FIRMAOBJECTID10%}";

                    FIRMAOBJECTID11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 322, -1, 347, 4, false);
                    FIRMAOBJECTID11.Name = "FIRMAOBJECTID11";
                    FIRMAOBJECTID11.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID11.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID11.TextFont.Name = "Arial";
                    FIRMAOBJECTID11.TextFont.Size = 5;
                    FIRMAOBJECTID11.TextFont.CharSet = 162;
                    FIRMAOBJECTID11.Value = @"{%FIRM4.FIRMAOBJECTID11%}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 281, 0, 296, 5, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class dataset_GetPiyasaArastirmaTutanagiNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>(0);
                    ORDERNO11111.CalcValue = ParentGroup.GroupCounter.ToString();
                    MALZEMEADI11111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTName) : "");
                    AMOUNT11111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Amount) : "");
                    OLCUBIRIMI11111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.DistributionType) : "");
                    IHTIYACSUTKODU11111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTCode) : "");
                    SUTFIYATI11111.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.SUTPrice) : "");
                    ACIKLAMA4.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Description) : "");
                    TTOBJECTID.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.ObjectID) : "");
                    FIRMAOBJECTID9.CalcValue = MyParentReport.FIRM4.FIRMAOBJECTID9.CalcValue;
                    FIRMAOBJECTID10.CalcValue = MyParentReport.FIRM4.FIRMAOBJECTID10.CalcValue;
                    FIRMAOBJECTID11.CalcValue = MyParentReport.FIRM4.FIRMAOBJECTID11.CalcValue;
                    CODELESSMATERIALNAME.CalcValue = (dataset_GetPiyasaArastirmaTutanagiNQL != null ? Globals.ToStringCore(dataset_GetPiyasaArastirmaTutanagiNQL.Codelessmaterialname) : "");
                    UBB10.CalcValue = @"";
                    SUTKODU10.CalcValue = @"";
                    FIYAT10.CalcValue = @"";
                    TUTAR10.CalcValue = @"";
                    DURUM10.CalcValue = @"";
                    UBB11.CalcValue = @"";
                    SUTKODU11.CalcValue = @"";
                    FIYAT11.CalcValue = @"";
                    TUTAR11.CalcValue = @"";
                    DURUM11.CalcValue = @"";
                    UBB9.CalcValue = @"";
                    SUTKODU9.CalcValue = @"";
                    FIYAT9.CalcValue = @"";
                    TUTAR9.CalcValue = @"";
                    DURUM9.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO11111,MALZEMEADI11111,AMOUNT11111,OLCUBIRIMI11111,IHTIYACSUTKODU11111,SUTFIYATI11111,ACIKLAMA4,TTOBJECTID,FIRMAOBJECTID9,FIRMAOBJECTID10,FIRMAOBJECTID11,CODELESSMATERIALNAME,UBB10,SUTKODU10,FIYAT10,TUTAR10,DURUM10,UBB11,SUTKODU11,FIYAT11,TUTAR11,DURUM11,UBB9,SUTKODU9,FIYAT9,TUTAR9,DURUM9};
                }

                public override void RunScript()
                {
#region BODY4 BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> firmPriceOfferList = DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer(ctx, TTOBJECTID.CalcValue);
            //            if (firmPriceOfferList.Count > 9)
            //            {
           if(!string.IsNullOrEmpty(this.FIRMAOBJECTID9.CalcValue) || !string.IsNullOrEmpty(this.FIRMAOBJECTID10.CalcValue) || !string.IsNullOrEmpty(this.FIRMAOBJECTID11.CalcValue) )
                this.Visible = EvetHayirEnum.ehEvet;
            
            TTReportField rf;
            for (int i = 0; i < firmPriceOfferList.Count; i++)
            {
                DPADetailFirmPriceOffer firmPriceOffer = (DPADetailFirmPriceOffer)ctx.GetObject(new Guid(firmPriceOfferList[i].ObjectID.ToString()), typeof(DPADetailFirmPriceOffer));
                if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID9.CalcValue)
                {
                    rf = FieldsByName("UBB9");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU9");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT9");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR9");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM9");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
                else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID10.CalcValue)
                {
                    rf = FieldsByName("UBB10");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU10");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT10");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR10");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM10");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
                else if (firmPriceOfferList[i].Firmaobjectid != null && firmPriceOfferList[i].Firmaobjectid .ToString() == this.FIRMAOBJECTID11.CalcValue)
                {
                    rf = FieldsByName("UBB11");
                    rf.CalcValue = firmPriceOffer.OfferedUBB != null ? firmPriceOffer.OfferedUBB.ProductNumber.ToString() : null ;
                    rf = FieldsByName("SUTKODU11");
                    rf.CalcValue =firmPriceOffer.OfferedSUTCode != null && firmPriceOffer.OfferedSUTCode.SUTCode != null ? firmPriceOffer.OfferedSUTCode.SUTCode.ToString() : null;
                    rf = FieldsByName("FIYAT11");
                    rf.CalcValue = firmPriceOffer.UnitPrice != null ? firmPriceOffer.UnitPrice.ToString() : null;
                    rf = FieldsByName("TUTAR11");
                    rf.CalcValue = firmPriceOfferList[i].Totalprice != null ? firmPriceOfferList[i].Totalprice.ToString() : null;
                    rf = FieldsByName("DURUM11");
                    rf.CalcValue = firmPriceOffer.AcceptedRejected != null && firmPriceOffer.AcceptedRejected == true ? "ü" :  "û";

                }
            }
            //  }
#endregion BODY4 BODY_Script
                }
            }

        }

        public BODY4Group BODY4;

        public partial class WINNERGroup : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public WINNERGroupHeader Header()
            {
                return (WINNERGroupHeader)_header;
            }

            new public WINNERGroupFooter Footer()
            {
                return (WINNERGroupFooter)_footer;
            }

            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField ADRESI1111 { get {return Header().ADRESI1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField MIKTAR1111 { get {return Header().MIKTAR1111;} }
            public TTReportField MIKTAR11111 { get {return Header().MIKTAR11111;} }
            public TTReportField FIRMAMETIN1101 { get {return Header().FIRMAMETIN1101;} }
            public TTReportField ADRESI11111 { get {return Header().ADRESI11111;} }
            public TTReportField ADRESI111111 { get {return Header().ADRESI111111;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField114411 { get {return Header().NewField114411;} }
            public TTReportField NewField1144111 { get {return Header().NewField1144111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
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
                _body = null;
                _header = new WINNERGroupHeader(this);
                _footer = new WINNERGroupFooter(this);

            }

            public partial class WINNERGroupHeader : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField NewField1211;
                public TTReportField NewField11311;
                public TTReportField ADRESI1111;
                public TTReportField NewField11111;
                public TTReportField NewField11211;
                public TTReportField MIKTAR1111;
                public TTReportField MIKTAR11111;
                public TTReportField FIRMAMETIN1101;
                public TTReportField ADRESI11111;
                public TTReportField ADRESI111111;
                public TTReportField NewField11711;
                public TTReportField NewField114411;
                public TTReportField NewField1144111;
                public TTReportField NewField1131; 
                public WINNERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 4, 8, 25, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Size = 6;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"S. Nu.";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 4, 279, 9, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 6;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Uygun Görülen Kişi / Firma / Firmalar";

                    ADRESI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 9, 171, 25, false);
                    ADRESI1111.Name = "ADRESI1111";
                    ADRESI1111.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRESI1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADRESI1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRESI1111.MultiLine = EvetHayirEnum.ehEvet;
                    ADRESI1111.WordBreak = EvetHayirEnum.ehEvet;
                    ADRESI1111.TextFont.Name = "Arial";
                    ADRESI1111.TextFont.Size = 6;
                    ADRESI1111.TextFont.Bold = true;
                    ADRESI1111.TextFont.CharSet = 162;
                    ADRESI1111.Value = @"Firma Adresi/Telefonu";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 17, 25, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 6;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"İhtiyaç SUT / İşlem Kodu";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 4, 65, 25, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 6;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Malzemenin Adı";

                    MIKTAR1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 4, 73, 25, false);
                    MIKTAR1111.Name = "MIKTAR1111";
                    MIKTAR1111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR1111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR1111.TextFont.Name = "Arial";
                    MIKTAR1111.TextFont.Size = 6;
                    MIKTAR1111.TextFont.Bold = true;
                    MIKTAR1111.TextFont.CharSet = 162;
                    MIKTAR1111.Value = @"Kesin- leşen Miktar";

                    MIKTAR11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 4, 81, 25, false);
                    MIKTAR11111.Name = "MIKTAR11111";
                    MIKTAR11111.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR11111.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR11111.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR11111.TextFont.Name = "Arial";
                    MIKTAR11111.TextFont.Size = 6;
                    MIKTAR11111.TextFont.Bold = true;
                    MIKTAR11111.TextFont.CharSet = 162;
                    MIKTAR11111.Value = @"Ölçü Birimi";

                    FIRMAMETIN1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 9, 123, 25, false);
                    FIRMAMETIN1101.Name = "FIRMAMETIN1101";
                    FIRMAMETIN1101.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAMETIN1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAMETIN1101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAMETIN1101.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAMETIN1101.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAMETIN1101.TextFont.Name = "Arial";
                    FIRMAMETIN1101.TextFont.Size = 6;
                    FIRMAMETIN1101.TextFont.Bold = true;
                    FIRMAMETIN1101.TextFont.CharSet = 162;
                    FIRMAMETIN1101.Value = @"FİRMA ADI";

                    ADRESI11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 9, 188, 25, false);
                    ADRESI11111.Name = "ADRESI11111";
                    ADRESI11111.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRESI11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADRESI11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRESI11111.MultiLine = EvetHayirEnum.ehEvet;
                    ADRESI11111.WordBreak = EvetHayirEnum.ehEvet;
                    ADRESI11111.TextFont.Name = "Arial";
                    ADRESI11111.TextFont.Size = 6;
                    ADRESI11111.TextFont.Bold = true;
                    ADRESI11111.TextFont.CharSet = 162;
                    ADRESI11111.Value = @"Kabul Edilen UBB";

                    ADRESI111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 9, 232, 25, false);
                    ADRESI111111.Name = "ADRESI111111";
                    ADRESI111111.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRESI111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADRESI111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRESI111111.MultiLine = EvetHayirEnum.ehEvet;
                    ADRESI111111.WordBreak = EvetHayirEnum.ehEvet;
                    ADRESI111111.TextFont.Name = "Arial";
                    ADRESI111111.TextFont.Size = 6;
                    ADRESI111111.TextFont.Bold = true;
                    ADRESI111111.TextFont.CharSet = 162;
                    ADRESI111111.Value = @"Kabul Edilen UBB 'nin Etiket Adı";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 9, 241, 25, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11711.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Size = 6;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"İhtiyaç SUT / İşlem Fiyatı";

                    NewField114411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 9, 250, 25, false);
                    NewField114411.Name = "NewField114411";
                    NewField114411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114411.TextFont.Name = "Arial";
                    NewField114411.TextFont.Size = 6;
                    NewField114411.TextFont.Bold = true;
                    NewField114411.TextFont.CharSet = 162;
                    NewField114411.Value = @"Kabul Edilen Birim Fiyat (TL)";

                    NewField1144111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 9, 259, 25, false);
                    NewField1144111.Name = "NewField1144111";
                    NewField1144111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1144111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1144111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1144111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1144111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1144111.TextFont.Name = "Arial";
                    NewField1144111.TextFont.Size = 6;
                    NewField1144111.TextFont.Bold = true;
                    NewField1144111.TextFont.CharSet = 162;
                    NewField1144111.Value = @"Kabul Edilen Tutarı (TL)";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 9, 279, 25, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 6;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Açıklama";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    ADRESI1111.CalcValue = ADRESI1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    MIKTAR1111.CalcValue = MIKTAR1111.Value;
                    MIKTAR11111.CalcValue = MIKTAR11111.Value;
                    FIRMAMETIN1101.CalcValue = FIRMAMETIN1101.Value;
                    ADRESI11111.CalcValue = ADRESI11111.Value;
                    ADRESI111111.CalcValue = ADRESI111111.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField114411.CalcValue = NewField114411.Value;
                    NewField1144111.CalcValue = NewField1144111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    return new TTReportObject[] { NewField1211,NewField11311,ADRESI1111,NewField11111,NewField11211,MIKTAR1111,MIKTAR11111,FIRMAMETIN1101,ADRESI11111,ADRESI111111,NewField11711,NewField114411,NewField1144111,NewField1131};
                }
            }
            public partial class WINNERGroupFooter : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                 
                public WINNERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public WINNERGroup WINNER;

        public partial class WINNERBODYGroup : TTReportGroup
        {
            public PiyasaArastirmaTutanagi22F MyParentReport
            {
                get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
            }

            new public WINNERBODYGroupBody Body()
            {
                return (WINNERBODYGroupBody)_body;
            }
            public TTReportField ORDERNO11 { get {return Body().ORDERNO11;} }
            public TTReportField FIRMAADI { get {return Body().FIRMAADI;} }
            public TTReportField ADDRESS { get {return Body().ADDRESS;} }
            public TTReportField MALZEMEADI { get {return Body().MALZEMEADI;} }
            public TTReportField OLCUBIRIMI { get {return Body().OLCUBIRIMI;} }
            public TTReportField SUTKODU { get {return Body().SUTKODU;} }
            public TTReportField KESINLESENMIKTAR { get {return Body().KESINLESENMIKTAR;} }
            public TTReportField KABULEDILENUBB { get {return Body().KABULEDILENUBB;} }
            public TTReportField ETIKETADI { get {return Body().ETIKETADI;} }
            public TTReportField SUTFIYAT { get {return Body().SUTFIYAT;} }
            public TTReportField BIRIMFIYAT { get {return Body().BIRIMFIYAT;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField SUTNAME { get {return Body().SUTNAME;} }
            public TTReportField SUTCODE { get {return Body().SUTCODE;} }
            public TTReportField RPCSUTKODU { get {return Body().RPCSUTKODU;} }
            public TTReportField RPCMALZEMEISMI { get {return Body().RPCMALZEMEISMI;} }
            public TTReportField PRODUCTNUMBER { get {return Body().PRODUCTNUMBER;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField CODELESSMATERIALNAME { get {return Body().CODELESSMATERIALNAME;} }
            public TTReportField MATCHEDSUTCODE { get {return Body().MATCHEDSUTCODE;} }
            public TTReportField MATCHEDSUTPRICE { get {return Body().MATCHEDSUTPRICE;} }
            public WINNERBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public WINNERBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class>("GetUygunGorulenFirmalarQuery", DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new WINNERBODYGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class WINNERBODYGroupBody : TTReportSection
            {
                public PiyasaArastirmaTutanagi22F MyParentReport
                {
                    get { return (PiyasaArastirmaTutanagi22F)ParentReport; }
                }
                
                public TTReportField ORDERNO11;
                public TTReportField FIRMAADI;
                public TTReportField ADDRESS;
                public TTReportField MALZEMEADI;
                public TTReportField OLCUBIRIMI;
                public TTReportField SUTKODU;
                public TTReportField KESINLESENMIKTAR;
                public TTReportField KABULEDILENUBB;
                public TTReportField ETIKETADI;
                public TTReportField SUTFIYAT;
                public TTReportField BIRIMFIYAT;
                public TTReportField TUTAR;
                public TTReportField ACIKLAMA;
                public TTReportField SUTNAME;
                public TTReportField SUTCODE;
                public TTReportField RPCSUTKODU;
                public TTReportField RPCMALZEMEISMI;
                public TTReportField PRODUCTNUMBER;
                public TTReportField NAME;
                public TTReportField CODELESSMATERIALNAME;
                public TTReportField MATCHEDSUTCODE;
                public TTReportField MATCHEDSUTPRICE; 
                public WINNERBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    ORDERNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 8, 5, false);
                    ORDERNO11.Name = "ORDERNO11";
                    ORDERNO11.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO11.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO11.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO11.TextFont.Name = "Arial";
                    ORDERNO11.TextFont.Size = 5;
                    ORDERNO11.TextFont.CharSet = 162;
                    ORDERNO11.Value = @"{@groupcounter@}";

                    FIRMAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 123, 5, false);
                    FIRMAADI.Name = "FIRMAADI";
                    FIRMAADI.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRMAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRMAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRMAADI.MultiLine = EvetHayirEnum.ehEvet;
                    FIRMAADI.WordBreak = EvetHayirEnum.ehEvet;
                    FIRMAADI.TextFont.Name = "Arial";
                    FIRMAADI.TextFont.Size = 5;
                    FIRMAADI.TextFont.CharSet = 162;
                    FIRMAADI.Value = @"{#FIRM#}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 171, 5, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.TextFont.Name = "Arial";
                    ADDRESS.TextFont.Size = 5;
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"{#FIRMADDRESS#}";

                    MALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 65, 5, false);
                    MALZEMEADI.Name = "MALZEMEADI";
                    MALZEMEADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADI.TextFont.Name = "Arial";
                    MALZEMEADI.TextFont.Size = 5;
                    MALZEMEADI.TextFont.CharSet = 162;
                    MALZEMEADI.Value = @"";

                    OLCUBIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 0, 81, 5, false);
                    OLCUBIRIMI.Name = "OLCUBIRIMI";
                    OLCUBIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.TextFont.Name = "Arial";
                    OLCUBIRIMI.TextFont.Size = 5;
                    OLCUBIRIMI.TextFont.CharSet = 162;
                    OLCUBIRIMI.Value = @"{#DISTRIBUTIONTYPE#}";

                    SUTKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 17, 5, false);
                    SUTKODU.Name = "SUTKODU";
                    SUTKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU.TextFont.Name = "Arial";
                    SUTKODU.TextFont.Size = 5;
                    SUTKODU.TextFont.CharSet = 162;
                    SUTKODU.Value = @"";

                    KESINLESENMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 73, 5, false);
                    KESINLESENMIKTAR.Name = "KESINLESENMIKTAR";
                    KESINLESENMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    KESINLESENMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KESINLESENMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KESINLESENMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KESINLESENMIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    KESINLESENMIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    KESINLESENMIKTAR.TextFont.Name = "Arial";
                    KESINLESENMIKTAR.TextFont.Size = 5;
                    KESINLESENMIKTAR.TextFont.CharSet = 162;
                    KESINLESENMIKTAR.Value = @"{#CERTAINAMOUNT#}";

                    KABULEDILENUBB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 188, 5, false);
                    KABULEDILENUBB.Name = "KABULEDILENUBB";
                    KABULEDILENUBB.DrawStyle = DrawStyleConstants.vbSolid;
                    KABULEDILENUBB.FieldType = ReportFieldTypeEnum.ftVariable;
                    KABULEDILENUBB.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KABULEDILENUBB.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KABULEDILENUBB.MultiLine = EvetHayirEnum.ehEvet;
                    KABULEDILENUBB.WordBreak = EvetHayirEnum.ehEvet;
                    KABULEDILENUBB.TextFont.Name = "Arial";
                    KABULEDILENUBB.TextFont.Size = 5;
                    KABULEDILENUBB.TextFont.CharSet = 162;
                    KABULEDILENUBB.Value = @"{#PRODUCTNUMBER#}";

                    ETIKETADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 232, 5, false);
                    ETIKETADI.Name = "ETIKETADI";
                    ETIKETADI.DrawStyle = DrawStyleConstants.vbSolid;
                    ETIKETADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ETIKETADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ETIKETADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ETIKETADI.MultiLine = EvetHayirEnum.ehEvet;
                    ETIKETADI.WordBreak = EvetHayirEnum.ehEvet;
                    ETIKETADI.TextFont.Name = "Arial";
                    ETIKETADI.TextFont.Size = 5;
                    ETIKETADI.TextFont.CharSet = 162;
                    ETIKETADI.Value = @"{#NAME#}";

                    SUTFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 241, 5, false);
                    SUTFIYAT.Name = "SUTFIYAT";
                    SUTFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYAT.TextFormat = @"#,##0.#0";
                    SUTFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUTFIYAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYAT.TextFont.Name = "Arial";
                    SUTFIYAT.TextFont.Size = 5;
                    SUTFIYAT.TextFont.CharSet = 162;
                    SUTFIYAT.Value = @"{#SUTPRICE#}";

                    BIRIMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 0, 250, 5, false);
                    BIRIMFIYAT.Name = "BIRIMFIYAT";
                    BIRIMFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMFIYAT.TextFormat = @"#,##0.#0";
                    BIRIMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIMFIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.TextFont.Name = "Arial";
                    BIRIMFIYAT.TextFont.Size = 5;
                    BIRIMFIYAT.TextFont.CharSet = 162;
                    BIRIMFIYAT.Value = @"{#UNITPRICE#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 259, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 5;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#TOTALPRICE#}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 0, 279, 5, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Name = "Arial";
                    ACIKLAMA.TextFont.Size = 5;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#DESCRIPTION#}";

                    SUTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 313, 5, false);
                    SUTNAME.Name = "SUTNAME";
                    SUTNAME.Visible = EvetHayirEnum.ehHayir;
                    SUTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTNAME.TextFont.Name = "Arial";
                    SUTNAME.TextFont.Size = 8;
                    SUTNAME.TextFont.CharSet = 162;
                    SUTNAME.Value = @"{#SUTNAME#}";

                    SUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 1, 329, 5, false);
                    SUTCODE.Name = "SUTCODE";
                    SUTCODE.Visible = EvetHayirEnum.ehHayir;
                    SUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTCODE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTCODE.TextFont.Name = "Arial";
                    SUTCODE.TextFont.Size = 8;
                    SUTCODE.TextFont.CharSet = 162;
                    SUTCODE.Value = @"{#SUTCODE#}";

                    RPCSUTKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 6, 313, 10, false);
                    RPCSUTKODU.Name = "RPCSUTKODU";
                    RPCSUTKODU.Visible = EvetHayirEnum.ehHayir;
                    RPCSUTKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    RPCSUTKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RPCSUTKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RPCSUTKODU.TextFont.Name = "Arial";
                    RPCSUTKODU.TextFont.Size = 8;
                    RPCSUTKODU.TextFont.CharSet = 162;
                    RPCSUTKODU.Value = @"{#RPCSUTKODU#}";

                    RPCMALZEMEISMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 6, 329, 10, false);
                    RPCMALZEMEISMI.Name = "RPCMALZEMEISMI";
                    RPCMALZEMEISMI.Visible = EvetHayirEnum.ehHayir;
                    RPCMALZEMEISMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RPCMALZEMEISMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RPCMALZEMEISMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RPCMALZEMEISMI.TextFont.Name = "Arial";
                    RPCMALZEMEISMI.TextFont.Size = 8;
                    RPCMALZEMEISMI.TextFont.CharSet = 162;
                    RPCMALZEMEISMI.Value = @"{#RPCMALZEMEISMI#}";

                    PRODUCTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 11, 313, 15, false);
                    PRODUCTNUMBER.Name = "PRODUCTNUMBER";
                    PRODUCTNUMBER.Visible = EvetHayirEnum.ehHayir;
                    PRODUCTNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRODUCTNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCTNUMBER.TextFont.Name = "Arial";
                    PRODUCTNUMBER.TextFont.Size = 8;
                    PRODUCTNUMBER.TextFont.CharSet = 162;
                    PRODUCTNUMBER.Value = @"{#PRODUCTNUMBER#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 11, 329, 15, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.TextFont.Name = "Arial";
                    NAME.TextFont.Size = 8;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                    CODELESSMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 281, 0, 296, 5, false);
                    CODELESSMATERIALNAME.Name = "CODELESSMATERIALNAME";
                    CODELESSMATERIALNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATERIALNAME.TextFont.Name = "Arial";
                    CODELESSMATERIALNAME.TextFont.Size = 8;
                    CODELESSMATERIALNAME.TextFont.CharSet = 162;
                    CODELESSMATERIALNAME.Value = @"{#CODELESSMATERIALNAME#}";

                    MATCHEDSUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 21, 311, 26, false);
                    MATCHEDSUTCODE.Name = "MATCHEDSUTCODE";
                    MATCHEDSUTCODE.Visible = EvetHayirEnum.ehHayir;
                    MATCHEDSUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATCHEDSUTCODE.TextFont.Name = "Arial";
                    MATCHEDSUTCODE.TextFont.Size = 8;
                    MATCHEDSUTCODE.TextFont.CharSet = 162;
                    MATCHEDSUTCODE.Value = @"{#MATCHEDSUTCODE#}";

                    MATCHEDSUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 22, 328, 27, false);
                    MATCHEDSUTPRICE.Name = "MATCHEDSUTPRICE";
                    MATCHEDSUTPRICE.Visible = EvetHayirEnum.ehHayir;
                    MATCHEDSUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATCHEDSUTPRICE.TextFont.Name = "Arial";
                    MATCHEDSUTPRICE.TextFont.Size = 8;
                    MATCHEDSUTPRICE.TextFont.CharSet = 162;
                    MATCHEDSUTPRICE.Value = @"{#MATCHEDSUTPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class dataset_GetUygunGorulenFirmalarQuery = ParentGroup.rsGroup.GetCurrentRecord<DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class>(0);
                    ORDERNO11.CalcValue = ParentGroup.GroupCounter.ToString();
                    FIRMAADI.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Firm) : "");
                    ADDRESS.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.FirmAddress) : "");
                    MALZEMEADI.CalcValue = @"";
                    OLCUBIRIMI.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.DistributionType) : "");
                    SUTKODU.CalcValue = @"";
                    KESINLESENMIKTAR.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.CertainAmount) : "");
                    KABULEDILENUBB.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.ProductNumber) : "");
                    ETIKETADI.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Name) : "");
                    SUTFIYAT.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.SUTPrice) : "");
                    BIRIMFIYAT.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.UnitPrice) : "");
                    TUTAR.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Totalprice) : "");
                    ACIKLAMA.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Description) : "");
                    SUTNAME.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.SUTName) : "");
                    SUTCODE.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.SUTCode) : "");
                    RPCSUTKODU.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Rpcsutkodu) : "");
                    RPCMALZEMEISMI.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Rpcmalzemeismi) : "");
                    PRODUCTNUMBER.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.ProductNumber) : "");
                    NAME.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Name) : "");
                    CODELESSMATERIALNAME.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.Codelessmaterialname) : "");
                    MATCHEDSUTCODE.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.MatchedSUTCode) : "");
                    MATCHEDSUTPRICE.CalcValue = (dataset_GetUygunGorulenFirmalarQuery != null ? Globals.ToStringCore(dataset_GetUygunGorulenFirmalarQuery.MatchedSUTPrice) : "");
                    return new TTReportObject[] { ORDERNO11,FIRMAADI,ADDRESS,MALZEMEADI,OLCUBIRIMI,SUTKODU,KESINLESENMIKTAR,KABULEDILENUBB,ETIKETADI,SUTFIYAT,BIRIMFIYAT,TUTAR,ACIKLAMA,SUTNAME,SUTCODE,RPCSUTKODU,RPCMALZEMEISMI,PRODUCTNUMBER,NAME,CODELESSMATERIALNAME,MATCHEDSUTCODE,MATCHEDSUTPRICE};
                }

                public override void RunScript()
                {
#region WINNERBODY BODY_Script
                    TTObjectContext octx = new TTObjectContext(true);
            string objectID = ((PiyasaArastirmaTutanagi22F)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            string UBB = "UBB Kapsam Dışı";
            DirectPurchaseAction dpa = (DirectPurchaseAction)octx.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            
            if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.SUTKODU.CalcValue = this.RPCSUTKODU.CalcValue;
                this.MALZEMEADI.CalcValue = this.RPCMALZEMEISMI.CalcValue;
                this.KABULEDILENUBB.CalcValue = UBB;
                this.ETIKETADI.CalcValue = UBB;
            }
            else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                this.MALZEMEADI.CalcValue = this.CODELESSMATERIALNAME.CalcValue;
                this.KABULEDILENUBB.CalcValue = UBB;
                this.ETIKETADI.CalcValue = UBB;
                this.SUTKODU.CalcValue = this.MATCHEDSUTCODE.CalcValue;
                this.SUTFIYAT.CalcValue = this.MATCHEDSUTPRICE.CalcValue;
            }
            else
            {
                this.SUTKODU.CalcValue = this.SUTCODE.CalcValue;
                this.MALZEMEADI.CalcValue = this.SUTNAME.CalcValue;
                this.KABULEDILENUBB.CalcValue = this.PRODUCTNUMBER.CalcValue;
                this.ETIKETADI.CalcValue = this.NAME.CalcValue;
            }
#endregion WINNERBODY BODY_Script
                }
            }

        }

        public WINNERBODYGroup WINNERBODY;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PiyasaArastirmaTutanagi22F()
        {
            A = new AGroup(this,"A");
            BASLIK = new BASLIKGroup(A,"BASLIK");
            FIRM1 = new FIRM1Group(BASLIK,"FIRM1");
            BODY1 = new BODY1Group(FIRM1,"BODY1");
            FIRM2 = new FIRM2Group(FIRM1,"FIRM2");
            BODY2 = new BODY2Group(FIRM2,"BODY2");
            FIRM3 = new FIRM3Group(FIRM2,"FIRM3");
            BODY3 = new BODY3Group(FIRM3,"BODY3");
            FIRM4 = new FIRM4Group(FIRM3,"FIRM4");
            BODY4 = new BODY4Group(FIRM4,"BODY4");
            WINNER = new WINNERGroup(FIRM4,"WINNER");
            WINNERBODY = new WINNERBODYGroup(WINNER,"WINNERBODY");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "22F Doğrudan Temin Detay", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PIYASAARASTIRMATUTANAGI22F";
            Caption = "Piyasa Araştırma Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 10;
            UserMarginTop = 5;
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