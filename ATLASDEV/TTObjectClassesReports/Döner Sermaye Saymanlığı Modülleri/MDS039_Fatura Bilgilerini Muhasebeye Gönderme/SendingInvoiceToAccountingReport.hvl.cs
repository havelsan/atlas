
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
    /// Fatura Bilgilerini Muhasebeye Gönderme Raporu
    /// </summary>
    public partial class SendingInvoiceToAccountingReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public SendingInvoiceToAccountingReport MyParentReport
            {
                get { return (SendingInvoiceToAccountingReport)ParentReport; }
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
                public SendingInvoiceToAccountingReport MyParentReport
                {
                    get { return (SendingInvoiceToAccountingReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SendingInvoiceToAccountingReport MyParentReport
                {
                    get { return (SendingInvoiceToAccountingReport)ParentReport; }
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
            public SendingInvoiceToAccountingReport MyParentReport
            {
                get { return (SendingInvoiceToAccountingReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField CASHOFFICELBL1 { get {return Header().CASHOFFICELBL1;} }
            public TTReportField CASHIERLBL1 { get {return Header().CASHIERLBL1;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportField NewField1212211 { get {return Header().NewField1212211;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField1182 { get {return Header().NewField1182;} }
            public TTReportField NewField1172 { get {return Header().NewField1172;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportField NewField11811 { get {return Footer().NewField11811;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
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
                public SendingInvoiceToAccountingReport MyParentReport
                {
                    get { return (SendingInvoiceToAccountingReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField NewField1111;
                public TTReportField CASHOFFICELBL1;
                public TTReportField CASHIERLBL1;
                public TTReportField NewField1112211;
                public TTReportField NewField1212211;
                public TTReportField ENDDATE;
                public TTReportField NewField161;
                public TTReportField NewField181;
                public TTReportField NewField171;
                public TTReportShape NewLine1111;
                public TTReportField NewField1171;
                public TTReportField NewField11711;
                public TTReportField NewField1181;
                public TTReportField NewField1182;
                public TTReportField NewField1172; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 22, 82, 27, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.ObjectDefName = "SendingInvoiceToAccounting";
                    STARTDATE.DataMember = "STARTDATE";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@TTOBJECTID@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 14, 283, 20, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"FATURA BİLGİLERİNİ MUHASEBEYE GÖNDERME RAPORU";

                    CASHOFFICELBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 22, 36, 27, false);
                    CASHOFFICELBL1.Name = "CASHOFFICELBL1";
                    CASHOFFICELBL1.TextFont.Size = 8;
                    CASHOFFICELBL1.TextFont.Bold = true;
                    CASHOFFICELBL1.TextFont.CharSet = 162;
                    CASHOFFICELBL1.Value = @"Fatura Başlangıç Tarihi";

                    CASHIERLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 28, 36, 33, false);
                    CASHIERLBL1.Name = "CASHIERLBL1";
                    CASHIERLBL1.TextFont.Size = 8;
                    CASHIERLBL1.TextFont.Bold = true;
                    CASHIERLBL1.TextFont.CharSet = 162;
                    CASHIERLBL1.Value = @"Fatura Bitiş Tarihi";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 22, 38, 27, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewField1212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 28, 38, 33, false);
                    NewField1212211.Name = "NewField1212211";
                    NewField1212211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212211.TextFont.Bold = true;
                    NewField1212211.TextFont.CharSet = 162;
                    NewField1212211.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 28, 82, 33, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.ObjectDefName = "SendingInvoiceToAccounting";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@TTOBJECTID@}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 34, 129, 38, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Kurum";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 34, 243, 38, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Size = 8;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Fatura Tarihi";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 34, 154, 38, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Size = 8;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Hasta No";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 39, 283, 39, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 34, 178, 38, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"H.Protokol No";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 34, 223, 38, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Size = 8;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"Adı Soyadı";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 34, 263, 38, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.Size = 8;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"Fatura No";

                    NewField1182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 34, 283, 38, false);
                    NewField1182.Name = "NewField1182";
                    NewField1182.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1182.TextFont.Size = 8;
                    NewField1182.TextFont.Bold = true;
                    NewField1182.TextFont.CharSet = 162;
                    NewField1182.Value = @"Tutar";

                    NewField1172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 34, 21, 38, false);
                    NewField1172.Name = "NewField1172";
                    NewField1172.TextFont.Size = 8;
                    NewField1172.TextFont.Bold = true;
                    NewField1172.TextFont.CharSet = 162;
                    NewField1172.Value = @"Sıra No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    STARTDATE.PostFieldValueCalculation();
                    NewField1111.CalcValue = NewField1111.Value;
                    CASHOFFICELBL1.CalcValue = CASHOFFICELBL1.Value;
                    CASHIERLBL1.CalcValue = CASHIERLBL1.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField1212211.CalcValue = NewField1212211.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    NewField161.CalcValue = NewField161.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1182.CalcValue = NewField1182.Value;
                    NewField1172.CalcValue = NewField1172.Value;
                    return new TTReportObject[] { STARTDATE,NewField1111,CASHOFFICELBL1,CASHIERLBL1,NewField1112211,NewField1212211,ENDDATE,NewField161,NewField181,NewField171,NewField1171,NewField11711,NewField1181,NewField1182,NewField1172};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SendingInvoiceToAccountingReport MyParentReport
                {
                    get { return (SendingInvoiceToAccountingReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111;
                public TTReportField NewField11811;
                public TTReportField TOPLAMTUTAR; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 2, 283, 2, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 4, 255, 9, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.TextFont.Size = 8;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @"Toplam Tutar :";

                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 4, 283, 9, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Size = 8;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{@sumof(TUTAR)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11811.CalcValue = NewField11811.Value;
                    TOPLAMTUTAR.CalcValue = ParentGroup.FieldSums["TUTAR"].Value.ToString();;
                    return new TTReportObject[] { NewField11811,TOPLAMTUTAR};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public SendingInvoiceToAccountingReport MyParentReport
            {
                get { return (SendingInvoiceToAccountingReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField HPROTOKOLNO { get {return Body().HPROTOKOLNO;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField FATURATARIHI { get {return Body().FATURATARIHI;} }
            public TTReportField FATURANO { get {return Body().FATURANO;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
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
                list[0] = new TTReportNqlData<SendingInvoiceDetails.GetBySITAObjectID_Class>("GetBySITAObjectID", SendingInvoiceDetails.GetBySITAObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SendingInvoiceToAccountingReport MyParentReport
                {
                    get { return (SendingInvoiceToAccountingReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField KURUM;
                public TTReportField HASTANO;
                public TTReportField HPROTOKOLNO;
                public TTReportField ADISOYADI;
                public TTReportField FATURATARIHI;
                public TTReportField FATURANO;
                public TTReportField TUTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 21, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 129, 5, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Size = 8;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#PAYERCODE#} {#PAYERNAME#}";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 154, 5, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.TextFont.Size = 8;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{#PATIENTID#}";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 178, 5, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTOKOLNO.TextFont.Size = 8;
                    HPROTOKOLNO.TextFont.CharSet = 162;
                    HPROTOKOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 223, 5, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 243, 5, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI.TextFormat = @"Short Date";
                    FATURATARIHI.TextFont.Size = 8;
                    FATURATARIHI.TextFont.CharSet = 162;
                    FATURATARIHI.Value = @"{#INVOICEDATE#}";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 0, 263, 5, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#INVOICENO#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 283, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#INVOICEPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SendingInvoiceDetails.GetBySITAObjectID_Class dataset_GetBySITAObjectID = ParentGroup.rsGroup.GetCurrentRecord<SendingInvoiceDetails.GetBySITAObjectID_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    KURUM.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.Payercode) : "") + @" " + (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.Payername) : "");
                    HASTANO.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.Patientid) : "");
                    HPROTOKOLNO.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.HospitalProtocolNo) : "");
                    ADISOYADI.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.Patientname) : "") + @" " + (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.Patientsurname) : "");
                    FATURATARIHI.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.InvoiceDate) : "");
                    FATURANO.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.InvoiceNo) : "");
                    TUTAR.CalcValue = (dataset_GetBySITAObjectID != null ? Globals.ToStringCore(dataset_GetBySITAObjectID.InvoicePrice) : "");
                    return new TTReportObject[] { SIRANO,KURUM,HASTANO,HPROTOKOLNO,ADISOYADI,FATURATARIHI,FATURANO,TUTAR};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SendingInvoiceToAccountingReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SENDINGINVOICETOACCOUNTINGREPORT";
            Caption = "Fatura Bilgilerini Muhasebeye Gönderme Raporu";
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