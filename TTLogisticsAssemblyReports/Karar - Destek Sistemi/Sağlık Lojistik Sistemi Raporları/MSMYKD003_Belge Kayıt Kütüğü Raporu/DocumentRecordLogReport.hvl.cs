
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
    public partial class DocumentRecordLogReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? ACCOUNTINGTERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DocumentRecordLogReport MyParentReport
            {
                get { return (DocumentRecordLogReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField ACCOUNTANCY { get {return Header().ACCOUNTANCY;} }
            public TTReportField TERMYEAR { get {return Header().TERMYEAR;} }
            public TTReportField ACCOUNTANCYNO { get {return Header().ACCOUNTANCYNO;} }
            public TTReportField ACCOUNTANCYNAME { get {return Header().ACCOUNTANCYNAME;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField CURRENTUSERNAME { get {return Footer().CURRENTUSERNAME;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public DocumentRecordLogReport MyParentReport
                {
                    get { return (DocumentRecordLogReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField ACCOUNTANCY;
                public TTReportField TERMYEAR;
                public TTReportField ACCOUNTANCYNO;
                public TTReportField ACCOUNTANCYNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 66, 18, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Taşınır Mal Saymanlığının Kodu";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 66, 24, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Mali Yıl";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 12, 69, 18, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 18, 69, 24, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    ACCOUNTANCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 12, 209, 18, false);
                    ACCOUNTANCY.Name = "ACCOUNTANCY";
                    ACCOUNTANCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCY.TextFont.Name = "Arial";
                    ACCOUNTANCY.TextFont.Size = 11;
                    ACCOUNTANCY.TextFont.CharSet = 162;
                    ACCOUNTANCY.Value = @"{%ACCOUNTANCYNO%} {%ACCOUNTANCYNAME%}";

                    TERMYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 18, 209, 24, false);
                    TERMYEAR.Name = "TERMYEAR";
                    TERMYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TERMYEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TERMYEAR.ObjectDefName = "AccountingTerm";
                    TERMYEAR.DataMember = "TermYear";
                    TERMYEAR.TextFont.Name = "Arial";
                    TERMYEAR.TextFont.Size = 11;
                    TERMYEAR.TextFont.CharSet = 162;
                    TERMYEAR.Value = @"{@ACCOUNTINGTERMID@}";

                    ACCOUNTANCYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 5, 292, 11, false);
                    ACCOUNTANCYNO.Name = "ACCOUNTANCYNO";
                    ACCOUNTANCYNO.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCYNO.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCYNO.DataMember = "ACCOUNTANCY.ACCOUNTANCYNO";
                    ACCOUNTANCYNO.TextFont.Size = 11;
                    ACCOUNTANCYNO.TextFont.Bold = true;
                    ACCOUNTANCYNO.TextFont.CharSet = 162;
                    ACCOUNTANCYNO.Value = @"{@ACCOUNTINGTERMID@}";

                    ACCOUNTANCYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 12, 291, 18, false);
                    ACCOUNTANCYNAME.Name = "ACCOUNTANCYNAME";
                    ACCOUNTANCYNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCYNAME.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCYNAME.DataMember = "ACCOUNTANCY.NAME";
                    ACCOUNTANCYNAME.TextFont.Size = 11;
                    ACCOUNTANCYNAME.TextFont.Bold = true;
                    ACCOUNTANCYNAME.TextFont.CharSet = 162;
                    ACCOUNTANCYNAME.Value = @"{@ACCOUNTINGTERMID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    ACCOUNTANCYNO.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTINGTERMID.ToString();
                    ACCOUNTANCYNO.PostFieldValueCalculation();
                    ACCOUNTANCYNAME.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTINGTERMID.ToString();
                    ACCOUNTANCYNAME.PostFieldValueCalculation();
                    ACCOUNTANCY.CalcValue = MyParentReport.PARTA.ACCOUNTANCYNO.CalcValue + @" " + MyParentReport.PARTA.ACCOUNTANCYNAME.CalcValue;
                    TERMYEAR.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTINGTERMID.ToString();
                    TERMYEAR.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField121,ACCOUNTANCYNO,ACCOUNTANCYNAME,ACCOUNTANCY,TERMYEAR};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DocumentRecordLogReport MyParentReport
                {
                    get { return (DocumentRecordLogReport)ParentReport; }
                }
                
                public TTReportField PRINTDATE;
                public TTReportField CURRENTUSERNAME;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.TextFormat = @"dd/MM/yyyy";
                    PRINTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRINTDATE.TextFont.Name = "Arial";
                    PRINTDATE.TextFont.Size = 8;
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@}";

                    CURRENTUSERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 157, 5, false);
                    CURRENTUSERNAME.Name = "CURRENTUSERNAME";
                    CURRENTUSERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSERNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CURRENTUSERNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSERNAME.NoClip = EvetHayirEnum.ehEvet;
                    CURRENTUSERNAME.TextFont.Name = "Arial";
                    CURRENTUSERNAME.TextFont.Size = 8;
                    CURRENTUSERNAME.TextFont.CharSet = 162;
                    CURRENTUSERNAME.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 287, 5, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 287, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    PAGENUMBER.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSERNAME.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PRINTDATE,PAGENUMBER,CURRENTUSERNAME};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public DocumentRecordLogReport MyParentReport
            {
                get { return (DocumentRecordLogReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
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
                public DocumentRecordLogReport MyParentReport
                {
                    get { return (DocumentRecordLogReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField11121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 287, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BELGE KAYIT KÜTÜĞÜ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 32, 21, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Belge Kayıt 
Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 9, 54, 21, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Kayıt Tarih";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 9, 76, 21, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İşlem Çeşidi";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 9, 129, 21, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Giriş ve Çıkış Nedenleri";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 9, 151, 21, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Kalem Adedi";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 9, 223, 21, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Alındığı / Verildiği Yer ve Kodu";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 9, 287, 21, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Açıklamalar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField1111,NewField11111,NewField112,NewField1211,NewField11121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DocumentRecordLogReport MyParentReport
                {
                    get { return (DocumentRecordLogReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DocumentRecordLogReport MyParentReport
            {
                get { return (DocumentRecordLogReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DOCUMENTRECORDLOGNUMBER { get {return Body().DOCUMENTRECORDLOGNUMBER;} }
            public TTReportField DOCUMENTDATETIME { get {return Body().DOCUMENTDATETIME;} }
            public TTReportField DOCUMENTTRANSACTIONTYPE { get {return Body().DOCUMENTTRANSACTIONTYPE;} }
            public TTReportField SUBJECT { get {return Body().SUBJECT;} }
            public TTReportField NUMBEROFROWS { get {return Body().NUMBEROFROWS;} }
            public TTReportField TAKENGIVENPLACE { get {return Body().TAKENGIVENPLACE;} }
            public TTReportField ACIKLAMALAR { get {return Body().ACIKLAMALAR;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField DESCRIPTIONS { get {return Body().DESCRIPTIONS;} }
            public TTReportField STOCKACTION { get {return Body().STOCKACTION;} }
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
                list[0] = new TTReportNqlData<DocumentRecordLog.GetDocumentRecordLogReportQuery_Class>("GetDocumentRecordLogReportQuery", DocumentRecordLog.GetDocumentRecordLogReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTINGTERMID)));
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
                public DocumentRecordLogReport MyParentReport
                {
                    get { return (DocumentRecordLogReport)ParentReport; }
                }
                
                public TTReportField DOCUMENTRECORDLOGNUMBER;
                public TTReportField DOCUMENTDATETIME;
                public TTReportField DOCUMENTTRANSACTIONTYPE;
                public TTReportField SUBJECT;
                public TTReportField NUMBEROFROWS;
                public TTReportField TAKENGIVENPLACE;
                public TTReportField ACIKLAMALAR;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportField DESCRIPTIONS;
                public TTReportField STOCKACTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    DOCUMENTRECORDLOGNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 32, 5, false);
                    DOCUMENTRECORDLOGNUMBER.Name = "DOCUMENTRECORDLOGNUMBER";
                    DOCUMENTRECORDLOGNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTRECORDLOGNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTRECORDLOGNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTRECORDLOGNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTRECORDLOGNUMBER.Value = @"{#DOCUMENTRECORDLOGNUMBER#} ";

                    DOCUMENTDATETIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 54, 5, false);
                    DOCUMENTDATETIME.Name = "DOCUMENTDATETIME";
                    DOCUMENTDATETIME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTDATETIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATETIME.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATETIME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTDATETIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTDATETIME.Value = @"{#DOCUMENTDATETIME#}";

                    DOCUMENTTRANSACTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 76, 5, false);
                    DOCUMENTTRANSACTIONTYPE.Name = "DOCUMENTTRANSACTIONTYPE";
                    DOCUMENTTRANSACTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTTRANSACTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTTRANSACTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTTRANSACTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTTRANSACTIONTYPE.ObjectDefName = "DocumentTransactionTypeEnum";
                    DOCUMENTTRANSACTIONTYPE.DataMember = "DISPLAYTEXT";
                    DOCUMENTTRANSACTIONTYPE.Value = @"{#DOCUMENTTRANSACTIONTYPE#}";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 0, 129, 5, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBJECT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBJECT.Value = @"{#SUBJECT#}";

                    NUMBEROFROWS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 151, 5, false);
                    NUMBEROFROWS.Name = "NUMBEROFROWS";
                    NUMBEROFROWS.DrawStyle = DrawStyleConstants.vbSolid;
                    NUMBEROFROWS.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBEROFROWS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NUMBEROFROWS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NUMBEROFROWS.Value = @"{#NUMBEROFROWS#} ";

                    TAKENGIVENPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 223, 5, false);
                    TAKENGIVENPLACE.Name = "TAKENGIVENPLACE";
                    TAKENGIVENPLACE.DrawStyle = DrawStyleConstants.vbSolid;
                    TAKENGIVENPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAKENGIVENPLACE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TAKENGIVENPLACE.Value = @"{#TAKENGIVENPLACE#}";

                    ACIKLAMALAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 0, 287, 5, false);
                    ACIKLAMALAR.Name = "ACIKLAMALAR";
                    ACIKLAMALAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMALAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMALAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMALAR.Value = @"";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    DESCRIPTIONS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 2, 326, 7, false);
                    DESCRIPTIONS.Name = "DESCRIPTIONS";
                    DESCRIPTIONS.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTIONS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONS.Value = @"{#DESCRIPTIONS#}";

                    STOCKACTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 331, 3, 356, 8, false);
                    STOCKACTION.Name = "STOCKACTION";
                    STOCKACTION.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTION.Value = @"{#STOCKACTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentRecordLog.GetDocumentRecordLogReportQuery_Class dataset_GetDocumentRecordLogReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DocumentRecordLog.GetDocumentRecordLogReportQuery_Class>(0);
                    DOCUMENTRECORDLOGNUMBER.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.DocumentRecordLogNumber) : "") + @" ";
                    DOCUMENTDATETIME.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.DocumentDateTime) : "");
                    DOCUMENTTRANSACTIONTYPE.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.DocumentTransactionType) : "");
                    DOCUMENTTRANSACTIONTYPE.PostFieldValueCalculation();
                    SUBJECT.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.Subject) : "");
                    NUMBEROFROWS.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.NumberOfRows) : "") + @" ";
                    TAKENGIVENPLACE.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.TakenGivenPlace) : "");
                    ACIKLAMALAR.CalcValue = @"";
                    DESCRIPTIONS.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.Descriptions) : "");
                    STOCKACTION.CalcValue = (dataset_GetDocumentRecordLogReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentRecordLogReportQuery.StockAction) : "");
                    return new TTReportObject[] { DOCUMENTRECORDLOGNUMBER,DOCUMENTDATETIME,DOCUMENTTRANSACTIONTYPE,SUBJECT,NUMBEROFROWS,TAKENGIVENPLACE,ACIKLAMALAR,DESCRIPTIONS,STOCKACTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string description = DESCRIPTIONS.CalcValue;
                    if(string.IsNullOrEmpty(STOCKACTION.CalcValue) == false && Globals.IsGuid(STOCKACTION.CalcValue))
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTION.CalcValue), typeof(StockAction).Name);
                        if(stockAction.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                            description += stockAction.CurrentStateDef.DisplayText;
                    }

                    ACIKLAMALAR.CalcValue = description;
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

        public DocumentRecordLogReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ACCOUNTINGTERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ACCOUNTINGTERMID"))
                _runtimeParameters.ACCOUNTINGTERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ACCOUNTINGTERMID"]);
            Name = "DOCUMENTRECORDLOGREPORT";
            Caption = "Belge Kayıt Kütüğü Raporu";
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