
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
    public partial class CollectedInvoiceListReport_Tooth : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoiceListReport_Tooth MyParentReport
            {
                get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

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
                public CollectedInvoiceListReport_Tooth MyParentReport
                {
                    get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CollectedInvoiceListReport_Tooth MyParentReport
                {
                    get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
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

        public PARTAGroup PARTA;

        public partial class HEADGroup : TTReportGroup
        {
            public CollectedInvoiceListReport_Tooth MyParentReport
            {
                get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField BOLUM { get {return Header().BOLUM;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField FATURANO { get {return Header().FATURANO;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField NewField121111 { get {return Header().NewField121111;} }
            public TTReportField NewField12112 { get {return Header().NewField12112;} }
            public TTReportField FATURATARIHI { get {return Header().FATURATARIHI;} }
            public TTReportField NewField121112 { get {return Header().NewField121112;} }
            public TTReportField SAYFANO { get {return Header().SAYFANO;} }
            public TTReportField NewField121121 { get {return Header().NewField121121;} }
            public TTReportField NewField1211121 { get {return Header().NewField1211121;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>("CollectedInvoiceListReportQuery_Tooth", CollectedPatientList.CollectedInvoiceListReportQuery_Tooth((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public CollectedInvoiceListReport_Tooth MyParentReport
                {
                    get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
                }
                
                public TTReportField NewField101;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField KURUMADI;
                public TTReportField BOLUM;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportShape NewLine111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField1112;
                public TTReportField FATURANO;
                public TTReportField NewField11112;
                public TTReportField NewField11611;
                public TTReportField NewField111611;
                public TTReportField NewField191;
                public TTReportField NewField12111;
                public TTReportField ACIKLAMA;
                public TTReportField NewField121111;
                public TTReportField NewField12112;
                public TTReportField FATURATARIHI;
                public TTReportField NewField121112;
                public TTReportField SAYFANO;
                public TTReportField NewField121121;
                public TTReportField NewField1211121; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 202, 17, false);
                    NewField101.Name = "NewField101";
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Size = 9;
                    NewField101.TextFont.Bold = true;
                    NewField101.TextFont.Underline = true;
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"FATURA EK LİSTESİ";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 31, 33, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Kurum Adı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 31, 38, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Bölüm";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 29, 202, 33, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"{#PAYERNAME#}";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 34, 202, 38, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BOLUM.TextFont.Name = "Arial";
                    BOLUM.TextFont.Size = 8;
                    BOLUM.TextFont.CharSet = 162;
                    BOLUM.Value = @"DİŞ HEKİMLİĞİ BİLİMLERİ MERKEZİ";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 21, 49, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Sıra No";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 45, 119, 49, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"TC Kimlik No";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 50, 202, 50, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 29, 33, 33, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @":";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 34, 33, 38, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @":";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 31, 28, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 8;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"Fatura No";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 24, 74, 28, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FATURANO.TextFont.Name = "Arial";
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#DOCUMENTNO#}";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 24, 33, 28, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Size = 8;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @":";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 45, 141, 49, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Provizyon No";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 45, 202, 49, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 8;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"Tutar";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 45, 73, 49, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Size = 8;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Hasta Adı";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 31, 43, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Size = 8;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"Açıklama";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 39, 202, 43, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACIKLAMA.TextFont.Name = "Arial";
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#DESCRIPTION#}";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 39, 33, 43, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 8;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @":";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 24, 110, 28, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.TextFont.Name = "Arial";
                    NewField12112.TextFont.Size = 8;
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @"Fatura Tarihi";

                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 24, 153, 28, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FATURATARIHI.TextFormat = @"Short Date";
                    FATURATARIHI.TextFont.Name = "Arial";
                    FATURATARIHI.TextFont.Size = 8;
                    FATURATARIHI.TextFont.CharSet = 162;
                    FATURATARIHI.Value = @"{#DOCUMENTDATE#}";

                    NewField121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 24, 112, 28, false);
                    NewField121112.Name = "NewField121112";
                    NewField121112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121112.TextFont.Name = "Arial";
                    NewField121112.TextFont.Size = 8;
                    NewField121112.TextFont.Bold = true;
                    NewField121112.TextFont.CharSet = 162;
                    NewField121112.Value = @":";

                    SAYFANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 19, 153, 23, false);
                    SAYFANO.Name = "SAYFANO";
                    SAYFANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYFANO.TextFont.Name = "Arial";
                    SAYFANO.TextFont.Size = 8;
                    SAYFANO.TextFont.CharSet = 162;
                    SAYFANO.Value = @"{@pagenumber@}";

                    NewField121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 19, 110, 23, false);
                    NewField121121.Name = "NewField121121";
                    NewField121121.TextFont.Name = "Arial";
                    NewField121121.TextFont.Size = 8;
                    NewField121121.TextFont.Bold = true;
                    NewField121121.TextFont.CharSet = 162;
                    NewField121121.Value = @"Sayfa No";

                    NewField1211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 19, 112, 23, false);
                    NewField1211121.Name = "NewField1211121";
                    NewField1211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211121.TextFont.Name = "Arial";
                    NewField1211121.TextFont.Size = 8;
                    NewField1211121.TextFont.Bold = true;
                    NewField1211121.TextFont.CharSet = 162;
                    NewField1211121.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class dataset_CollectedInvoiceListReportQuery_Tooth = ParentGroup.rsGroup.GetCurrentRecord<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>(0);
                    NewField101.CalcValue = NewField101.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    KURUMADI.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.Payername) : "");
                    BOLUM.CalcValue = BOLUM.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    FATURANO.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.DocumentNo) : "");
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    ACIKLAMA.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.Description) : "");
                    NewField121111.CalcValue = NewField121111.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    FATURATARIHI.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.DocumentDate) : "");
                    NewField121112.CalcValue = NewField121112.Value;
                    SAYFANO.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField121121.CalcValue = NewField121121.Value;
                    NewField1211121.CalcValue = NewField1211121.Value;
                    return new TTReportObject[] { NewField101,NewField111,NewField121,KURUMADI,BOLUM,NewField151,NewField161,NewField1111,NewField11111,NewField1112,FATURANO,NewField11112,NewField11611,NewField111611,NewField191,NewField12111,ACIKLAMA,NewField121111,NewField12112,FATURATARIHI,NewField121112,SAYFANO,NewField121121,NewField1211121};
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public CollectedInvoiceListReport_Tooth MyParentReport
                {
                    get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
                }
                
                public TTReportField TOPLAMTUTAR;
                public TTReportField NewField1171;
                public TTReportShape NewLine1111; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 2, 202, 6, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Name = "Arial";
                    TOPLAMTUTAR.TextFont.Size = 8;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{@sumof(TUTAR1)@}";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 2, 177, 6, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"Toplam Tutar :";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 202, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class dataset_CollectedInvoiceListReportQuery_Tooth = ParentGroup.rsGroup.GetCurrentRecord<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>(0);
                    TOPLAMTUTAR.CalcValue = ParentGroup.FieldSums["TUTAR1"].Value.ToString();;
                    NewField1171.CalcValue = NewField1171.Value;
                    return new TTReportObject[] { TOPLAMTUTAR,NewField1171};
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoiceListReport_Tooth MyParentReport
            {
                get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField PROVIZYONNO { get {return Body().PROVIZYONNO;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField TUTAR1 { get {return Body().TUTAR1;} }
            public TTReportField EPISODEOBJECTID { get {return Body().EPISODEOBJECTID;} }
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

                CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class dataSet_CollectedInvoiceListReportQuery_Tooth = ParentGroup.rsGroup.GetCurrentRecord<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>(0);    
                return new object[] {(dataSet_CollectedInvoiceListReportQuery_Tooth==null ? null : dataSet_CollectedInvoiceListReportQuery_Tooth.Specialityname)};
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
                public CollectedInvoiceListReport_Tooth MyParentReport
                {
                    get { return (CollectedInvoiceListReport_Tooth)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField HASTAADI;
                public TTReportField TCKIMLIKNO;
                public TTReportField PROVIZYONNO;
                public TTReportField TUTAR;
                public TTReportField TUTAR1;
                public TTReportField EPISODEOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 21, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 73, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#HEAD.PATIENTNAME#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 119, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#HEAD.UNIQUEREFNO#}";

                    PROVIZYONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 1, 141, 5, false);
                    PROVIZYONNO.Name = "PROVIZYONNO";
                    PROVIZYONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONNO.TextFont.Name = "Arial";
                    PROVIZYONNO.TextFont.Size = 8;
                    PROVIZYONNO.TextFont.CharSet = 162;
                    PROVIZYONNO.Value = @"";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 1, 202, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#HEAD.TOTALPRICE#}";

                    TUTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 1, 240, 5, false);
                    TUTAR1.Name = "TUTAR1";
                    TUTAR1.Visible = EvetHayirEnum.ehHayir;
                    TUTAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR1.TextFont.Name = "Arial";
                    TUTAR1.TextFont.Size = 8;
                    TUTAR1.TextFont.CharSet = 162;
                    TUTAR1.Value = @"{#HEAD.TOTALPRICE#}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 1, 273, 5, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial";
                    EPISODEOBJECTID.TextFont.Size = 8;
                    EPISODEOBJECTID.TextFont.CharSet = 162;
                    EPISODEOBJECTID.Value = @"{#HEAD.EPISODEOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class dataset_CollectedInvoiceListReportQuery_Tooth = MyParentReport.HEAD.rsGroup.GetCurrentRecord<CollectedPatientList.CollectedInvoiceListReportQuery_Tooth_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    HASTAADI.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.Patientname) : "");
                    TCKIMLIKNO.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.UniqueRefNo) : "");
                    PROVIZYONNO.CalcValue = @"";
                    TUTAR.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.TotalPrice) : "");
                    TUTAR1.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.TotalPrice) : "");
                    EPISODEOBJECTID.CalcValue = (dataset_CollectedInvoiceListReportQuery_Tooth != null ? Globals.ToStringCore(dataset_CollectedInvoiceListReportQuery_Tooth.Episodeobjectid) : "");
                    return new TTReportObject[] { SIRANO,HASTAADI,TCKIMLIKNO,PROVIZYONNO,TUTAR,TUTAR1,EPISODEOBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                            
//            TTObjectContext context = new TTObjectContext(true);
//            string eObjectId = EPISODEOBJECTID.CalcValue;
//            Episode e = (Episode)context.GetObject(new Guid(eObjectId),"Episode");
//
//            // Provizyon Numarasını getirir
//             this.PROVIZYONNO.CalcValue = e.PatientAdmission.ProvisionNo;
//
//
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

        public CollectedInvoiceListReport_Tooth()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEAD = new HEADGroup(PARTA,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COLLECTEDINVOICELISTREPORT_TOOTH";
            Caption = "Toplu Fatura Ek Listesi (Diş)";
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