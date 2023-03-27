
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
    /// Toplu Fatura Ek Listesi (Haydarpaşa)
    /// </summary>
    public partial class CollectedInvoiceListReportByDate : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string BRANCHCODE = (string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue("");
            public int? BRANCHCOUNTER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTCOUNTER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CollectedInvoiceListReportByDate MyParentReport
            {
                get { return (CollectedInvoiceListReportByDate)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public CollectedInvoiceListReportByDate MyParentReport
                {
                    get { return (CollectedInvoiceListReportByDate)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCODE = "AAAAAAABBBBBB";
            ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCOUNTER = 0;
            ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.PATIENTCOUNTER = 0;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CollectedInvoiceListReportByDate MyParentReport
                {
                    get { return (CollectedInvoiceListReportByDate)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoiceListReportByDate MyParentReport
            {
                get { return (CollectedInvoiceListReportByDate)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField BASLIK11311 { get {return Header().BASLIK11311;} }
            public TTReportField BASLIK112311 { get {return Header().BASLIK112311;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField BASLIK1113115 { get {return Header().BASLIK1113115;} }
            public TTReportField BASLIK1113116 { get {return Header().BASLIK1113116;} }
            public TTReportField BASLIK16113113 { get {return Header().BASLIK16113113;} }
            public TTReportField BASLIK16113114 { get {return Header().BASLIK16113114;} }
            public TTReportField BASLIK16113115 { get {return Header().BASLIK16113115;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField BASLIK111312 { get {return Header().BASLIK111312;} }
            public TTReportField BASLIK1113211 { get {return Header().BASLIK1113211;} }
            public TTReportField BASLIK111313 { get {return Header().BASLIK111313;} }
            public TTReportField BASLIK1113212 { get {return Header().BASLIK1113212;} }
            public TTReportField BASLIK111314 { get {return Header().BASLIK111314;} }
            public TTReportField BASLIK1113213 { get {return Header().BASLIK1113213;} }
            public TTReportField KURUMKODU { get {return Header().KURUMKODU;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField FATURATARIHI { get {return Header().FATURATARIHI;} }
            public TTReportField FATURANO { get {return Header().FATURANO;} }
            public TTReportField BASLIK15113111 { get {return Header().BASLIK15113111;} }
            public TTReportField BASLIK151131161 { get {return Header().BASLIK151131161;} }
            public TTReportField BASLIK1161131151 { get {return Header().BASLIK1161131151;} }
            public TTReportField Provizyon_No { get {return Header().Provizyon_No;} }
            public TTReportField TOPLAMKLASOR { get {return Footer().TOPLAMKLASOR;} }
            public TTReportField TOPLAMHASTA { get {return Footer().TOPLAMHASTA;} }
            public TTReportField TOPLAMFATURATUTAR { get {return Footer().TOPLAMFATURATUTAR;} }
            public TTReportField BASLIK111311 { get {return Footer().BASLIK111311;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                list[0] = new TTReportNqlData<CollectedInvoice.CIPatientListByDate_Class>("CIPatientListByDate", CollectedInvoice.CIPatientListByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CollectedInvoiceListReportByDate MyParentReport
                {
                    get { return (CollectedInvoiceListReportByDate)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField BASLIK11311;
                public TTReportField BASLIK112311;
                public TTReportField ENDDATE;
                public TTReportField BASLIK1113115;
                public TTReportField BASLIK1113116;
                public TTReportField BASLIK16113113;
                public TTReportField BASLIK16113114;
                public TTReportField BASLIK16113115;
                public TTReportShape NewLine1;
                public TTReportField STARTDATE;
                public TTReportField BASLIK111312;
                public TTReportField BASLIK1113211;
                public TTReportField BASLIK111313;
                public TTReportField BASLIK1113212;
                public TTReportField BASLIK111314;
                public TTReportField BASLIK1113213;
                public TTReportField KURUMKODU;
                public TTReportField KURUMADI;
                public TTReportField FATURATARIHI;
                public TTReportField FATURANO;
                public TTReportField BASLIK15113111;
                public TTReportField BASLIK151131161;
                public TTReportField BASLIK1161131151;
                public TTReportField Provizyon_No; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 45;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 12, 286, 17, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"TOPLU FATURA EK LİSTESİ";

                    BASLIK11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 23, 28, 27, false);
                    BASLIK11311.Name = "BASLIK11311";
                    BASLIK11311.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK11311.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK11311.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK11311.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK11311.TextFont.Name = "Arial";
                    BASLIK11311.TextFont.Size = 8;
                    BASLIK11311.TextFont.Bold = true;
                    BASLIK11311.TextFont.CharSet = 162;
                    BASLIK11311.Value = @"Kurum Adı";

                    BASLIK112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 23, 31, 27, false);
                    BASLIK112311.Name = "BASLIK112311";
                    BASLIK112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK112311.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK112311.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK112311.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK112311.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK112311.TextFont.Name = "Arial";
                    BASLIK112311.TextFont.Bold = true;
                    BASLIK112311.TextFont.CharSet = 162;
                    BASLIK112311.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 3, 250, 7, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.NoClip = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    BASLIK1113115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 39, 67, 43, false);
                    BASLIK1113115.Name = "BASLIK1113115";
                    BASLIK1113115.TextFont.Name = "Arial";
                    BASLIK1113115.TextFont.Size = 8;
                    BASLIK1113115.TextFont.Bold = true;
                    BASLIK1113115.TextFont.CharSet = 162;
                    BASLIK1113115.Value = @"Adı Soyadı";

                    BASLIK1113116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 39, 21, 43, false);
                    BASLIK1113116.Name = "BASLIK1113116";
                    BASLIK1113116.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1113116.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1113116.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1113116.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1113116.TextFont.Name = "Arial";
                    BASLIK1113116.TextFont.Size = 8;
                    BASLIK1113116.TextFont.Bold = true;
                    BASLIK1113116.TextFont.CharSet = 162;
                    BASLIK1113116.Value = @"Sıra No";

                    BASLIK16113113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 39, 286, 43, false);
                    BASLIK16113113.Name = "BASLIK16113113";
                    BASLIK16113113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BASLIK16113113.TextFont.Name = "Arial";
                    BASLIK16113113.TextFont.Size = 8;
                    BASLIK16113113.TextFont.Bold = true;
                    BASLIK16113113.TextFont.CharSet = 162;
                    BASLIK16113113.Value = @"Tutar";

                    BASLIK16113114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 39, 109, 43, false);
                    BASLIK16113114.Name = "BASLIK16113114";
                    BASLIK16113114.TextFont.Name = "Arial";
                    BASLIK16113114.TextFont.Size = 8;
                    BASLIK16113114.TextFont.Bold = true;
                    BASLIK16113114.TextFont.CharSet = 162;
                    BASLIK16113114.Value = @"Kabul Tarihi";

                    BASLIK16113115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 39, 131, 43, false);
                    BASLIK16113115.Name = "BASLIK16113115";
                    BASLIK16113115.TextFont.Name = "Arial";
                    BASLIK16113115.TextFont.Size = 8;
                    BASLIK16113115.TextFont.Bold = true;
                    BASLIK16113115.TextFont.CharSet = 162;
                    BASLIK16113115.Value = @"Taburcu Tarihi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 44, 286, 44, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 3, 228, 7, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.NoClip = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    BASLIK111312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 18, 28, 22, false);
                    BASLIK111312.Name = "BASLIK111312";
                    BASLIK111312.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111312.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK111312.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK111312.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK111312.TextFont.Name = "Arial";
                    BASLIK111312.TextFont.Size = 8;
                    BASLIK111312.TextFont.Bold = true;
                    BASLIK111312.TextFont.CharSet = 162;
                    BASLIK111312.Value = @"Kurum Kodu";

                    BASLIK1113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 18, 31, 22, false);
                    BASLIK1113211.Name = "BASLIK1113211";
                    BASLIK1113211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1113211.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1113211.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1113211.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1113211.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1113211.TextFont.Name = "Arial";
                    BASLIK1113211.TextFont.Bold = true;
                    BASLIK1113211.TextFont.CharSet = 162;
                    BASLIK1113211.Value = @":";

                    BASLIK111313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 28, 28, 32, false);
                    BASLIK111313.Name = "BASLIK111313";
                    BASLIK111313.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111313.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK111313.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK111313.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK111313.TextFont.Name = "Arial";
                    BASLIK111313.TextFont.Size = 8;
                    BASLIK111313.TextFont.Bold = true;
                    BASLIK111313.TextFont.CharSet = 162;
                    BASLIK111313.Value = @"Fatura Tarihi";

                    BASLIK1113212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 28, 31, 32, false);
                    BASLIK1113212.Name = "BASLIK1113212";
                    BASLIK1113212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1113212.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1113212.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1113212.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1113212.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1113212.TextFont.Name = "Arial";
                    BASLIK1113212.TextFont.Bold = true;
                    BASLIK1113212.TextFont.CharSet = 162;
                    BASLIK1113212.Value = @":";

                    BASLIK111314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 33, 28, 37, false);
                    BASLIK111314.Name = "BASLIK111314";
                    BASLIK111314.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111314.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK111314.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK111314.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK111314.TextFont.Name = "Arial";
                    BASLIK111314.TextFont.Size = 8;
                    BASLIK111314.TextFont.Bold = true;
                    BASLIK111314.TextFont.CharSet = 162;
                    BASLIK111314.Value = @"Fatura No";

                    BASLIK1113213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 33, 31, 37, false);
                    BASLIK1113213.Name = "BASLIK1113213";
                    BASLIK1113213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1113213.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1113213.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1113213.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1113213.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1113213.TextFont.Name = "Arial";
                    BASLIK1113213.TextFont.Bold = true;
                    BASLIK1113213.TextFont.CharSet = 162;
                    BASLIK1113213.Value = @":";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 18, 94, 22, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.TextFont.Name = "Arial";
                    KURUMKODU.TextFont.Size = 8;
                    KURUMKODU.TextFont.CharSet = 162;
                    KURUMKODU.Value = @"{#PAYERCODE#}";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 23, 286, 27, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"{#PAYERNAME#}";

                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 28, 94, 32, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI.TextFormat = @"Short Date";
                    FATURATARIHI.TextFont.Name = "Arial";
                    FATURATARIHI.TextFont.Size = 8;
                    FATURATARIHI.TextFont.CharSet = 162;
                    FATURATARIHI.Value = @"{#DOCUMENTDATE#}";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 33, 94, 37, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.Name = "Arial";
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#DOCUMENTNO#}";

                    BASLIK15113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 39, 90, 43, false);
                    BASLIK15113111.Name = "BASLIK15113111";
                    BASLIK15113111.TextFont.Name = "Arial";
                    BASLIK15113111.TextFont.Size = 8;
                    BASLIK15113111.TextFont.Bold = true;
                    BASLIK15113111.TextFont.CharSet = 162;
                    BASLIK15113111.Value = @"TC Kimlik No";

                    BASLIK151131161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 39, 264, 43, false);
                    BASLIK151131161.Name = "BASLIK151131161";
                    BASLIK151131161.TextFont.Name = "Arial";
                    BASLIK151131161.TextFont.Size = 8;
                    BASLIK151131161.TextFont.Bold = true;
                    BASLIK151131161.TextFont.CharSet = 162;
                    BASLIK151131161.Value = @"Tanı";

                    BASLIK1161131151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 39, 182, 43, false);
                    BASLIK1161131151.Name = "BASLIK1161131151";
                    BASLIK1161131151.TextFont.Name = "Arial";
                    BASLIK1161131151.TextFont.Size = 8;
                    BASLIK1161131151.TextFont.Bold = true;
                    BASLIK1161131151.TextFont.CharSet = 162;
                    BASLIK1161131151.Value = @"Uzmanlık Dalı";

                    Provizyon_No = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 39, 203, 43, false);
                    Provizyon_No.Name = "Provizyon_No";
                    Provizyon_No.Value = @"Provizyon No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CIPatientListByDate_Class dataset_CIPatientListByDate = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CIPatientListByDate_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    BASLIK11311.CalcValue = BASLIK11311.Value;
                    BASLIK112311.CalcValue = BASLIK112311.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    BASLIK1113115.CalcValue = BASLIK1113115.Value;
                    BASLIK1113116.CalcValue = BASLIK1113116.Value;
                    BASLIK16113113.CalcValue = BASLIK16113113.Value;
                    BASLIK16113114.CalcValue = BASLIK16113114.Value;
                    BASLIK16113115.CalcValue = BASLIK16113115.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    BASLIK111312.CalcValue = BASLIK111312.Value;
                    BASLIK1113211.CalcValue = BASLIK1113211.Value;
                    BASLIK111313.CalcValue = BASLIK111313.Value;
                    BASLIK1113212.CalcValue = BASLIK1113212.Value;
                    BASLIK111314.CalcValue = BASLIK111314.Value;
                    BASLIK1113213.CalcValue = BASLIK1113213.Value;
                    KURUMKODU.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Payercode) : "");
                    KURUMADI.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Payername) : "");
                    FATURATARIHI.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.DocumentDate) : "");
                    FATURANO.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.DocumentNo) : "");
                    BASLIK15113111.CalcValue = BASLIK15113111.Value;
                    BASLIK151131161.CalcValue = BASLIK151131161.Value;
                    BASLIK1161131151.CalcValue = BASLIK1161131151.Value;
                    Provizyon_No.CalcValue = Provizyon_No.Value;
                    return new TTReportObject[] { NewField11,BASLIK11311,BASLIK112311,ENDDATE,BASLIK1113115,BASLIK1113116,BASLIK16113113,BASLIK16113114,BASLIK16113115,STARTDATE,BASLIK111312,BASLIK1113211,BASLIK111313,BASLIK1113212,BASLIK111314,BASLIK1113213,KURUMKODU,KURUMADI,FATURATARIHI,FATURANO,BASLIK15113111,BASLIK151131161,BASLIK1161131151,Provizyon_No};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CollectedInvoiceListReportByDate MyParentReport
                {
                    get { return (CollectedInvoiceListReportByDate)ParentReport; }
                }
                
                public TTReportField TOPLAMKLASOR;
                public TTReportField TOPLAMHASTA;
                public TTReportField TOPLAMFATURATUTAR;
                public TTReportField BASLIK111311;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMKLASOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 1, 316, 6, false);
                    TOPLAMKLASOR.Name = "TOPLAMKLASOR";
                    TOPLAMKLASOR.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMKLASOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMKLASOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMKLASOR.Value = @"";

                    TOPLAMHASTA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 319, 1, 335, 6, false);
                    TOPLAMHASTA.Name = "TOPLAMHASTA";
                    TOPLAMHASTA.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMHASTA.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMHASTA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMHASTA.Value = @"{@subgroupcount@}";

                    TOPLAMFATURATUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 2, 286, 6, false);
                    TOPLAMFATURATUTAR.Name = "TOPLAMFATURATUTAR";
                    TOPLAMFATURATUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFATURATUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMFATURATUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFATURATUTAR.TextFont.Name = "Arial";
                    TOPLAMFATURATUTAR.TextFont.Size = 8;
                    TOPLAMFATURATUTAR.TextFont.CharSet = 162;
                    TOPLAMFATURATUTAR.Value = @"{@sumof(TUTAR)@}";

                    BASLIK111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 2, 260, 6, false);
                    BASLIK111311.Name = "BASLIK111311";
                    BASLIK111311.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111311.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK111311.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK111311.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK111311.TextFont.Name = "Arial";
                    BASLIK111311.TextFont.Size = 8;
                    BASLIK111311.TextFont.Bold = true;
                    BASLIK111311.TextFont.CharSet = 162;
                    BASLIK111311.Value = @"Toplam Tutar:";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 286, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CIPatientListByDate_Class dataset_CIPatientListByDate = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CIPatientListByDate_Class>(0);
                    TOPLAMKLASOR.CalcValue = @"";
                    TOPLAMHASTA.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    TOPLAMFATURATUTAR.CalcValue = ParentGroup.FieldSums["TUTAR"].Value.ToString();;
                    BASLIK111311.CalcValue = BASLIK111311.Value;
                    return new TTReportObject[] { TOPLAMKLASOR,TOPLAMHASTA,TOPLAMFATURATUTAR,BASLIK111311};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    /*
            int klasortoplam = (int)((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCOUNTER;
            this.TOPLAMKLASOR.CalcValue = klasortoplam.ToString();
             */
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoiceListReportByDate MyParentReport
            {
                get { return (CollectedInvoiceListReportByDate)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BRANS { get {return Body().BRANS;} }
            public TTReportField KLASORSIRANO { get {return Body().KLASORSIRANO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField MUAYENETARIHI { get {return Body().MUAYENETARIHI;} }
            public TTReportField TABURCUTARIHI { get {return Body().TABURCUTARIHI;} }
            public TTReportField BRANCHCODE { get {return Body().BRANCHCODE;} }
            public TTReportField EPISODEOBJECTID { get {return Body().EPISODEOBJECTID;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField KABULTARIHI { get {return Body().KABULTARIHI;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField UZMANLIKDALI { get {return Body().UZMANLIKDALI;} }
            public TTReportField PROVIZYONNO { get {return Body().PROVIZYONNO;} }
            public TTReportField PATIENTADMISSION { get {return Body().PATIENTADMISSION;} }
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

                CollectedInvoice.CIPatientListByDate_Class dataSet_CIPatientListByDate = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CIPatientListByDate_Class>(0);    
                return new object[] {(dataSet_CIPatientListByDate==null ? null : dataSet_CIPatientListByDate.ID)};
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
                public CollectedInvoiceListReportByDate MyParentReport
                {
                    get { return (CollectedInvoiceListReportByDate)ParentReport; }
                }
                
                public TTReportField BRANS;
                public TTReportField KLASORSIRANO;
                public TTReportField HASTAADI;
                public TTReportField SIRANO;
                public TTReportField TUTAR;
                public TTReportField MUAYENETARIHI;
                public TTReportField TABURCUTARIHI;
                public TTReportField BRANCHCODE;
                public TTReportField EPISODEOBJECTID;
                public TTReportField TCKIMLIKNO;
                public TTReportField KABULTARIHI;
                public TTReportField TANI;
                public TTReportField UZMANLIKDALI;
                public TTReportField PROVIZYONNO;
                public TTReportField PATIENTADMISSION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    BRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 338, 0, 388, 5, false);
                    BRANS.Name = "BRANS";
                    BRANS.Visible = EvetHayirEnum.ehHayir;
                    BRANS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANS.Value = @"{#PARTA.SPECIALITYCODE#} {#PARTA.SPECIALITYNAME#}";

                    KLASORSIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 390, 0, 413, 5, false);
                    KLASORSIRANO.Name = "KLASORSIRANO";
                    KLASORSIRANO.Visible = EvetHayirEnum.ehHayir;
                    KLASORSIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLASORSIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLASORSIRANO.Value = @"";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 67, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PARTA.PATIENTNAME#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 21, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 1, 286, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#PARTA.TOTALPRICE#}";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 416, 0, 442, 5, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.Visible = EvetHayirEnum.ehHayir;
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"Short Date";
                    MUAYENETARIHI.Value = @"";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 1, 131, 5, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"Short Date";
                    TABURCUTARIHI.TextFont.Name = "Arial";
                    TABURCUTARIHI.TextFont.Size = 8;
                    TABURCUTARIHI.TextFont.CharSet = 162;
                    TABURCUTARIHI.Value = @"";

                    BRANCHCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 316, 5, false);
                    BRANCHCODE.Name = "BRANCHCODE";
                    BRANCHCODE.Visible = EvetHayirEnum.ehHayir;
                    BRANCHCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANCHCODE.Value = @"{#PARTA.SPECIALITYCODE#}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 319, 0, 335, 5, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.Value = @"{#PARTA.EPISODEOBJECTID#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 1, 90, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.PATIENTUNIQUEREFNO#}";

                    KABULTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 1, 109, 5, false);
                    KABULTARIHI.Name = "KABULTARIHI";
                    KABULTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KABULTARIHI.TextFormat = @"Short Date";
                    KABULTARIHI.TextFont.Name = "Arial";
                    KABULTARIHI.TextFont.Size = 8;
                    KABULTARIHI.TextFont.CharSet = 162;
                    KABULTARIHI.Value = @"{#PARTA.OPENINGDATE#}";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 1, 264, 5, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial";
                    TANI.TextFont.Size = 8;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    UZMANLIKDALI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 1, 182, 5, false);
                    UZMANLIKDALI.Name = "UZMANLIKDALI";
                    UZMANLIKDALI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDALI.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.ExpandTabs = EvetHayirEnum.ehEvet;
                    UZMANLIKDALI.TextFont.Name = "Arial";
                    UZMANLIKDALI.TextFont.Size = 8;
                    UZMANLIKDALI.TextFont.CharSet = 162;
                    UZMANLIKDALI.Value = @"{#PARTA.SPECIALITYNAME#}";

                    PROVIZYONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 203, 5, false);
                    PROVIZYONNO.Name = "PROVIZYONNO";
                    PROVIZYONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONNO.Value = @"";

                    PATIENTADMISSION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 448, 0, 485, 5, false);
                    PATIENTADMISSION.Name = "PATIENTADMISSION";
                    PATIENTADMISSION.Visible = EvetHayirEnum.ehHayir;
                    PATIENTADMISSION.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTADMISSION.Value = @"{#PARTA.PATIENTADMISSION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CIPatientListByDate_Class dataset_CIPatientListByDate = MyParentReport.PARTA.rsGroup.GetCurrentRecord<CollectedInvoice.CIPatientListByDate_Class>(0);
                    BRANS.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Specialitycode) : "") + @" " + (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Specialityname) : "");
                    KLASORSIRANO.CalcValue = @"";
                    HASTAADI.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Patientname) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TUTAR.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.TotalPrice) : "");
                    MUAYENETARIHI.CalcValue = @"";
                    TABURCUTARIHI.CalcValue = @"";
                    BRANCHCODE.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Specialitycode) : "");
                    EPISODEOBJECTID.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Episodeobjectid) : "");
                    TCKIMLIKNO.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Patientuniquerefno) : "");
                    KABULTARIHI.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.OpeningDate) : "");
                    TANI.CalcValue = @"";
                    UZMANLIKDALI.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Specialityname) : "");
                    PROVIZYONNO.CalcValue = @"";
                    PATIENTADMISSION.CalcValue = (dataset_CIPatientListByDate != null ? Globals.ToStringCore(dataset_CIPatientListByDate.Patientadmission) : "");
                    return new TTReportObject[] { BRANS,KLASORSIRANO,HASTAADI,SIRANO,TUTAR,MUAYENETARIHI,TABURCUTARIHI,BRANCHCODE,EPISODEOBJECTID,TCKIMLIKNO,KABULTARIHI,TANI,UZMANLIKDALI,PROVIZYONNO,PATIENTADMISSION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    /*
            if(this.HASTATURU.FormattedValue == "OUTPATIENT" || HASTATURU.FormattedValue == "OUTPATİENT")
               this.HASTATURU.CalcValue = "AYAKTAN";
            else
               this.HASTATURU.CalcValue = "YATAN";
            
            if (((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCODE != this.BRANCHCODE.CalcValue)
            {
                ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCODE = this.BRANCHCODE.CalcValue;
                ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCOUNTER = ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCOUNTER + 1;
                ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.PATIENTCOUNTER = 1;
            }
            else
            {
                ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.PATIENTCOUNTER = ((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.PATIENTCOUNTER + 1;
            }
            
            int klasorsira = (int)((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.BRANCHCOUNTER;
            int hastasira = (int)((CollectedInvoiceListReportByDate)ParentReport).RuntimeParameters.PATIENTCOUNTER;
            
            this.KLASORSIRANO.CalcValue = klasorsira.ToString();
            this.HASTASIRANO.CalcValue = hastasira.ToString();
             */
            
            TTObjectContext objectContext = new TTObjectContext(true);
            Episode eps = (Episode)objectContext.GetObject(new Guid(this.EPISODEOBJECTID.CalcValue),"Episode");
            PatientAdmission PA=(PatientAdmission)objectContext.GetObject(new Guid(this.PATIENTADMISSION.CalcValue),"PatientAdmission");
           
            IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
            inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetAllClinicDischargeDatesByEpisode(objectContext, eps.ObjectID.ToString());
            foreach(InPatientTreatmentClinicApplication clinicApp in inpatientTreatmentClinicList)
            {
                this.TABURCUTARIHI.CalcValue = clinicApp.ClinicDischargeDate.ToString();
                break;
            }
            
            string ICD = "";
            IList diagnosisCodeList = new List<string>();
            
            foreach(DiagnosisGrid dg in eps.Diagnosis)
            {
                if(!diagnosisCodeList.Contains(dg.Diagnose.Code))
                {
                    ICD = ICD + dg.Diagnose.Code + " " + dg.Diagnose.Name + ",";
                    diagnosisCodeList.Add(dg.Diagnose.Code);
                }
            }
            
            if(ICD != "")
                ICD = ICD.Substring(0, ICD.Length - 1);
            
            this.TANI.CalcValue = ICD;
            
            this.PROVIZYONNO.CalcValue= PA.ProvisionNo;
           
            
            /*
            foreach (PatientExamination PE in eps.PatientExaminations)
            {
                if (PE.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    this.MUAYENETARIHI.CalcValue = PE.ProcessDate.ToString();
                    break;
                }
            }
             */
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

        public CollectedInvoiceListReportByDate()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("BRANCHCODE", "", "", @"", false, false, false, new Guid("286becbe-2627-4308-8246-33610e93c094"));
            reportParameter = Parameters.Add("BRANCHCOUNTER", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTCOUNTER", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("BRANCHCODE"))
                _runtimeParameters.BRANCHCODE = (string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(parameters["BRANCHCODE"]);
            if (parameters.ContainsKey("BRANCHCOUNTER"))
                _runtimeParameters.BRANCHCOUNTER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["BRANCHCOUNTER"]);
            if (parameters.ContainsKey("PATIENTCOUNTER"))
                _runtimeParameters.PATIENTCOUNTER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTCOUNTER"]);
            Name = "COLLECTEDINVOICELISTREPORTBYDATE";
            Caption = "Toplu Fatura Ek Listesi (Haydarpaşa)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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