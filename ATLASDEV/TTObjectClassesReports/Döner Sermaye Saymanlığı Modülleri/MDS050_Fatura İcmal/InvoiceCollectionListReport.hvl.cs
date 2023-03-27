
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
    public partial class InvoiceCollectionListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public InvoiceCollectionListReport MyParentReport
            {
                get { return (InvoiceCollectionListReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField InvoiceTotal { get {return Header().InvoiceTotal;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PAYERNAME { get {return Header().PAYERNAME;} }
            public TTReportField ICMALNO { get {return Header().ICMALNO;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField LBL { get {return Footer().LBL;} }
            public TTReportField IDARIVEMALIISLERMUDURU { get {return Footer().IDARIVEMALIISLERMUDURU;} }
            public TTReportField IMZA { get {return Footer().IMZA;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public InvoiceCollectionListReport MyParentReport
                {
                    get { return (InvoiceCollectionListReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField PAGENO;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField19;
                public TTReportField InvoiceTotal;
                public TTReportField HOSPITALNAME;
                public TTReportShape NewLine1;
                public TTReportField PAYERNAME;
                public TTReportField ICMALNO;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField112;
                public TTReportField NewField113;
                public TTReportField NewField1311;
                public TTReportField NewField22;
                public TTReportField NewField141; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 20, 167, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İCMAL LİSTESİ";

                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 21, 285, 26, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENO.Value = @"{@pagenumber@} / {@pagecount@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 33, 16, 38, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"S.No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 33, 135, 38, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Adı Soyadı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 33, 174, 38, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Sınıfı";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 33, 78, 38, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"TC Kimlik No";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 33, 55, 38, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Müracaat T.";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 33, 263, 38, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Fatura No";

                    InvoiceTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 33, 285, 38, false);
                    InvoiceTotal.Name = "InvoiceTotal";
                    InvoiceTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    InvoiceTotal.TextFont.Bold = true;
                    InvoiceTotal.TextFont.CharSet = 162;
                    InvoiceTotal.Value = @"Fatura Tutarı";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 11, 285, 19, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 39, 285, 39, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    PAYERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 27, 230, 32, false);
                    PAYERNAME.Name = "PAYERNAME";
                    PAYERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERNAME.TextFont.CharSet = 162;
                    PAYERNAME.Value = @"";

                    ICMALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 27, 285, 32, false);
                    ICMALNO.Name = "ICMALNO";
                    ICMALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICMALNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ICMALNO.TextFont.CharSet = 162;
                    ICMALNO.Value = @"";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 27, 22, 32, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"Kurum Adı :";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 27, 267, 32, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"İcmal No";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 21, 267, 26, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Sayfa No";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 21, 269, 26, false);
                    NewField113.Name = "NewField113";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @":";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 27, 269, 32, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 33, 35, 38, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Bold = true;
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @"Protokol No";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 33, 244, 38, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Branş Adı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    PAGENO.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField19.CalcValue = NewField19.Value;
                    InvoiceTotal.CalcValue = InvoiceTotal.Value;
                    PAYERNAME.CalcValue = @"";
                    ICMALNO.CalcValue = @"";
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField141.CalcValue = NewField141.Value;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField1,PAGENO,NewField3,NewField13,NewField14,NewField16,NewField17,NewField19,InvoiceTotal,PAYERNAME,ICMALNO,NewField20,NewField21,NewField112,NewField113,NewField1311,NewField22,NewField141,HOSPITALNAME};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    InvoiceCollection ic = MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(InvoiceCollection)) as InvoiceCollection;
            this.PAYERNAME.CalcValue = ic.Payer.Name;
            this.ICMALNO.CalcValue = ic.No.ToString();
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public InvoiceCollectionListReport MyParentReport
                {
                    get { return (InvoiceCollectionListReport)ParentReport; }
                }
                
                public TTReportField NewField4;
                public TTReportField TOTALPRICE;
                public TTReportShape NewLine11;
                public TTReportField LBL;
                public TTReportField IDARIVEMALIISLERMUDURU;
                public TTReportField IMZA; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 56;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 4, 259, 9, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Genel Toplam    :";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 4, 285, 9, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{@sumof(INVOICEPRICE)@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 2, 285, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 13, 285, 18, false);
                    LBL.Name = "LBL";
                    LBL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBL.TextFont.Name = "Arial";
                    LBL.TextFont.CharSet = 162;
                    LBL.Value = @"İdari ve Mali Hizmetler Müdürü";

                    IDARIVEMALIISLERMUDURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 18, 285, 23, false);
                    IDARIVEMALIISLERMUDURU.Name = "IDARIVEMALIISLERMUDURU";
                    IDARIVEMALIISLERMUDURU.FieldType = ReportFieldTypeEnum.ftExpression;
                    IDARIVEMALIISLERMUDURU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IDARIVEMALIISLERMUDURU.TextFont.Name = "Arial";
                    IDARIVEMALIISLERMUDURU.TextFont.CharSet = 162;
                    IDARIVEMALIISLERMUDURU.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""IDARIVEMALIISLERMUDURU"", """")";

                    IMZA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 30, 275, 45, false);
                    IMZA.Name = "IMZA";
                    IMZA.FieldType = ReportFieldTypeEnum.ftOLE;
                    IMZA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZA.MultiLine = EvetHayirEnum.ehEvet;
                    IMZA.NoClip = EvetHayirEnum.ehEvet;
                    IMZA.WordBreak = EvetHayirEnum.ehEvet;
                    IMZA.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMZA.ObjectDefName = "HospitalEmblemDefinition";
                    IMZA.DataMember = "EMBLEM";
                    IMZA.TextFont.CharSet = 162;
                    IMZA.Value = @"ec0dcc99-6b32-435f-92bc-c8b2d145efe1";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField4.CalcValue = NewField4.Value;
                    TOTALPRICE.CalcValue = ParentGroup.FieldSums["INVOICEPRICE"].Value.ToString();;
                    LBL.CalcValue = LBL.Value;
                    IMZA.CalcValue = @"ec0dcc99-6b32-435f-92bc-c8b2d145efe1";
                    IDARIVEMALIISLERMUDURU.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IDARIVEMALIISLERMUDURU", "");
                    return new TTReportObject[] { NewField4,TOTALPRICE,LBL,IMZA,IDARIVEMALIISLERMUDURU};
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public InvoiceCollectionListReport MyParentReport
            {
                get { return (InvoiceCollectionListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField CLASS { get {return Body().CLASS;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField OPENINGDATE { get {return Body().OPENINGDATE;} }
            public TTReportField EPISODEID { get {return Body().EPISODEID;} }
            public TTReportField INVOICENO { get {return Body().INVOICENO;} }
            public TTReportField INVOICEPRICE { get {return Body().INVOICEPRICE;} }
            public TTReportField SPECIALITYNAME { get {return Body().SPECIALITYNAME;} }
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
                list[0] = new TTReportNqlData<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class>("InvoiceCollectionListReportNQL", InvoiceCollectionDetail.InvoiceCollectionListReportNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InvoiceCollectionListReport MyParentReport
                {
                    get { return (InvoiceCollectionListReport)ParentReport; }
                }
                
                public TTReportField NO;
                public TTReportField PATIENTNAME;
                public TTReportField CLASS;
                public TTReportField TCKIMLIKNO;
                public TTReportField OPENINGDATE;
                public TTReportField EPISODEID;
                public TTReportField INVOICENO;
                public TTReportField INVOICEPRICE;
                public TTReportField SPECIALITYNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 16, 5, false);
                    NO.Name = "NO";
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.TextFont.CharSet = 162;
                    NO.Value = @"{@groupcounter@}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 0, 135, 5, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENTNAME#}";

                    CLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 174, 5, false);
                    CLASS.Name = "CLASS";
                    CLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASS.MultiLine = EvetHayirEnum.ehEvet;
                    CLASS.NoClip = EvetHayirEnum.ehEvet;
                    CLASS.WordBreak = EvetHayirEnum.ehEvet;
                    CLASS.ExpandTabs = EvetHayirEnum.ehEvet;
                    CLASS.TextFont.CharSet = 162;
                    CLASS.Value = @"{#PAYERTYPE#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 78, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 55, 5, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"dd/MM/yyyy";
                    OPENINGDATE.TextFont.CharSet = 162;
                    OPENINGDATE.Value = @"{#OPENINGDATE#}";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 35, 5, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.TextFont.CharSet = 162;
                    EPISODEID.Value = @"{#EPISODEID#}";

                    INVOICENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 0, 263, 5, false);
                    INVOICENO.Name = "INVOICENO";
                    INVOICENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICENO.TextFont.CharSet = 162;
                    INVOICENO.Value = @"{#INVOICENO#}";

                    INVOICEPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 285, 5, false);
                    INVOICEPRICE.Name = "INVOICEPRICE";
                    INVOICEPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEPRICE.TextFormat = @"#,##0.#0";
                    INVOICEPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INVOICEPRICE.TextFont.CharSet = 162;
                    INVOICEPRICE.Value = @"{#INVOICEPRICE#}";

                    SPECIALITYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 244, 5, false);
                    SPECIALITYNAME.Name = "SPECIALITYNAME";
                    SPECIALITYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALITYNAME.MultiLine = EvetHayirEnum.ehEvet;
                    SPECIALITYNAME.NoClip = EvetHayirEnum.ehEvet;
                    SPECIALITYNAME.WordBreak = EvetHayirEnum.ehEvet;
                    SPECIALITYNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    SPECIALITYNAME.TextFont.CharSet = 162;
                    SPECIALITYNAME.Value = @"{#SPECIALITYNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class dataset_InvoiceCollectionListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class>(0);
                    NO.CalcValue = ParentGroup.GroupCounter.ToString();
                    PATIENTNAME.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Patientname) : "");
                    CLASS.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Payertype) : "");
                    TCKIMLIKNO.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.UniqueRefNo) : "");
                    OPENINGDATE.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.OpeningDate) : "");
                    EPISODEID.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Episodeid) : "");
                    INVOICENO.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Invoiceno) : "");
                    INVOICEPRICE.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Invoiceprice) : "");
                    SPECIALITYNAME.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Specialityname) : "");
                    return new TTReportObject[] { NO,PATIENTNAME,CLASS,TCKIMLIKNO,OPENINGDATE,EPISODEID,INVOICENO,INVOICEPRICE,SPECIALITYNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoiceCollectionListReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Object ID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICECOLLECTIONLISTREPORT";
            Caption = "İcmal Listesi (Atılış Sırası)";
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