
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
    public partial class ChattelDocumentOutDetailReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? BUDGETTYPE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public ChattelDocumentOutDetailReport MyParentReport
            {
                get { return (ChattelDocumentOutDetailReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField STOCKACTIONOBJECTID { get {return Header().STOCKACTIONOBJECTID;} }
            public TTReportField NewField11111211 { get {return Footer().NewField11111211;} }
            public TTReportField NewField111211111 { get {return Footer().NewField111211111;} }
            public TTReportField DESCRIPTIONBOTTOMLEFT { get {return Footer().DESCRIPTIONBOTTOMLEFT;} }
            public TTReportField DESCRIPTIONBOTTOMRIGHT { get {return Footer().DESCRIPTIONBOTTOMRIGHT;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField STOCKACTIONOBJECTID; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 200, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"TAŞINIR MAL İŞLEM BELGESİ";

                    STOCKACTIONOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 9, 251, 14, false);
                    STOCKACTIONOBJECTID.Name = "STOCKACTIONOBJECTID";
                    STOCKACTIONOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONOBJECTID.VertAlign = VerticalAlignmentEnum.vaTop;
                    STOCKACTIONOBJECTID.ObjectDefName = "DocumentRecordLog";
                    STOCKACTIONOBJECTID.DataMember = "STOCKACTION.StockActionObjectID";
                    STOCKACTIONOBJECTID.TextFont.Size = 10;
                    STOCKACTIONOBJECTID.TextFont.CharSet = 1;
                    STOCKACTIONOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    STOCKACTIONOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    STOCKACTIONOBJECTID.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField11,STOCKACTIONOBJECTID};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField NewField11111211;
                public TTReportField NewField111211111;
                public TTReportField DESCRIPTIONBOTTOMLEFT;
                public TTReportField DESCRIPTIONBOTTOMRIGHT; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 40;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 105, 33, false);
                    NewField11111211.Name = "NewField11111211";
                    NewField11111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111211.TextFont.Bold = true;
                    NewField11111211.Value = @"";

                    NewField111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 200, 33, false);
                    NewField111211111.Name = "NewField111211111";
                    NewField111211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211111.TextFont.Bold = true;
                    NewField111211111.Value = @"";

                    DESCRIPTIONBOTTOMLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 103, 33, false);
                    DESCRIPTIONBOTTOMLEFT.Name = "DESCRIPTIONBOTTOMLEFT";
                    DESCRIPTIONBOTTOMLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONBOTTOMLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONBOTTOMLEFT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONBOTTOMLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMLEFT.TextFont.Name = "Courier New";
                    DESCRIPTIONBOTTOMLEFT.TextFont.Size = 8;
                    DESCRIPTIONBOTTOMLEFT.Value = @"";

                    DESCRIPTIONBOTTOMRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 0, 200, 33, false);
                    DESCRIPTIONBOTTOMRIGHT.Name = "DESCRIPTIONBOTTOMRIGHT";
                    DESCRIPTIONBOTTOMRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONBOTTOMRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONBOTTOMRIGHT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONBOTTOMRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMRIGHT.TextFont.Name = "Courier New";
                    DESCRIPTIONBOTTOMRIGHT.TextFont.Size = 8;
                    DESCRIPTIONBOTTOMRIGHT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111211.CalcValue = NewField11111211.Value;
                    NewField111211111.CalcValue = NewField111211111.Value;
                    DESCRIPTIONBOTTOMLEFT.CalcValue = @"";
                    DESCRIPTIONBOTTOMRIGHT.CalcValue = @"";
                    return new TTReportObject[] { NewField11111211,NewField111211111,DESCRIPTIONBOTTOMLEFT,DESCRIPTIONBOTTOMRIGHT};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));

                        if (string.IsNullOrEmpty(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue) == false && Globals.IsGuid(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue))
                        {
                            Guid stockActionObjectID = new Guid(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue);
                            StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(stockActionObjectID, typeof(StockAction));

                            string message = string.Empty;
                            message = "Malzeme tam ve sağlam olarak TESLİM EDİLMİŞTİR.\r\n";
                            message += "                                ..../..../20....\r\n\r\n";
                            message += "Adı Soyadı : ................................\r\n\r\n";
                            message += "Ünvanı     : ................................\r\n\r\n";
                            message += "İmzası     : ................................";
                            DESCRIPTIONBOTTOMLEFT.CalcValue = message;

                            message = "Malzeme tam ve sağlam olarak TESLİM ALINMIŞTIR.\r\n";
                            message += "                                ..../..../20....\r\n\r\n";
                            message += "Adı Soyadı : ................................\r\n\r\n";
                            message += "Ünvanı     : ................................\r\n\r\n";
                            message += "İmzası     : ................................";
                            DESCRIPTIONBOTTOMRIGHT.CalcValue = message;
                        }
                    }
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public ChattelDocumentOutDetailReport MyParentReport
            {
                get { return (ChattelDocumentOutDetailReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111123 { get {return Header().NewField111123;} }
            public TTReportField NewField1321111 { get {return Header().NewField1321111;} }
            public TTReportField NewField11111231 { get {return Header().NewField11111231;} }
            public TTReportField NewField113211111 { get {return Header().NewField113211111;} }
            public TTReportField NewField113211112 { get {return Header().NewField113211112;} }
            public TTReportField NewField113211113 { get {return Header().NewField113211113;} }
            public TTReportField NewField1111112311 { get {return Header().NewField1111112311;} }
            public TTReportField NewField1321112 { get {return Header().NewField1321112;} }
            public TTReportField NewField1321113 { get {return Header().NewField1321113;} }
            public TTReportField NewField1321114 { get {return Header().NewField1321114;} }
            public TTReportField NewField1321115 { get {return Header().NewField1321115;} }
            public TTReportField NewField1321116 { get {return Header().NewField1321116;} }
            public TTReportField NewField1321117 { get {return Header().NewField1321117;} }
            public TTReportField DOCUMENTRECORDLOGNUMBER { get {return Header().DOCUMENTRECORDLOGNUMBER;} }
            public TTReportField DOCUMENTDATETIME { get {return Header().DOCUMENTDATETIME;} }
            public TTReportField DOCUMENTTRANSACTIONTYPE { get {return Header().DOCUMENTTRANSACTIONTYPE;} }
            public TTReportField DOCUMENTTRANSACTIONTYPEVALUE { get {return Header().DOCUMENTTRANSACTIONTYPEVALUE;} }
            public TTReportField BASEDATETIMENUMBER { get {return Header().BASEDATETIMENUMBER;} }
            public TTReportField CONCLUSIONDATETIMENUMBER { get {return Header().CONCLUSIONDATETIMENUMBER;} }
            public TTReportField IDARESI { get {return Header().IDARESI;} }
            public TTReportField HARCAMABIRIMI { get {return Header().HARCAMABIRIMI;} }
            public TTReportField DEPOSUAMBARI { get {return Header().DEPOSUAMBARI;} }
            public TTReportField TESLIMEDENFIRMA { get {return Header().TESLIMEDENFIRMA;} }
            public TTReportField IDARESIKODU { get {return Header().IDARESIKODU;} }
            public TTReportField HARCAMABIRIMIKODU { get {return Header().HARCAMABIRIMIKODU;} }
            public TTReportField DEPOSUAMBARIKODU { get {return Header().DEPOSUAMBARIKODU;} }
            public TTReportField TESLIMEDENFIRMAKODU { get {return Header().TESLIMEDENFIRMAKODU;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField1112 { get {return Footer().NewField1112;} }
            public TTReportField NewField12111 { get {return Footer().NewField12111;} }
            public TTReportField NewField111121 { get {return Footer().NewField111121;} }
            public TTReportField NewField111122 { get {return Footer().NewField111122;} }
            public TTReportField NewField1221111 { get {return Footer().NewField1221111;} }
            public TTReportField NewField1121111 { get {return Footer().NewField1121111;} }
            public TTReportField NewField11111211 { get {return Footer().NewField11111211;} }
            public TTReportField GONDERILENYER { get {return Footer().GONDERILENYER;} }
            public TTReportField GONDERILENDEPO { get {return Footer().GONDERILENDEPO;} }
            public TTReportField GONDERILENYERKODU { get {return Footer().GONDERILENYERKODU;} }
            public TTReportField GONDERILENDEPOKODU { get {return Footer().GONDERILENDEPOKODU;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
            public TTReportField DESCRIPTIONTOPLEFT { get {return Footer().DESCRIPTIONTOPLEFT;} }
            public TTReportField DESCRIPTIONTOPRIGHT { get {return Footer().DESCRIPTIONTOPRIGHT;} }
            public TTReportField SIGNTOPLEFTS { get {return Footer().SIGNTOPLEFTS;} }
            public TTReportField SIGNTOPRIGHTS { get {return Footer().SIGNTOPRIGHTS;} }
            public TTReportField SIGNTOPLEFTM { get {return Footer().SIGNTOPLEFTM;} }
            public TTReportField SIGNTOPLEFTE { get {return Footer().SIGNTOPLEFTE;} }
            public TTReportField SIGNTOPRIGHTM { get {return Footer().SIGNTOPRIGHTM;} }
            public TTReportField SIGNTOPRIGHTE { get {return Footer().SIGNTOPRIGHTE;} }
            public TTReportField NewField12112 { get {return Footer().NewField12112;} }
            public TTReportField SUMOFPRICE { get {return Footer().SUMOFPRICE;} }
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
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField NewField111123;
                public TTReportField NewField1321111;
                public TTReportField NewField11111231;
                public TTReportField NewField113211111;
                public TTReportField NewField113211112;
                public TTReportField NewField113211113;
                public TTReportField NewField1111112311;
                public TTReportField NewField1321112;
                public TTReportField NewField1321113;
                public TTReportField NewField1321114;
                public TTReportField NewField1321115;
                public TTReportField NewField1321116;
                public TTReportField NewField1321117;
                public TTReportField DOCUMENTRECORDLOGNUMBER;
                public TTReportField DOCUMENTDATETIME;
                public TTReportField DOCUMENTTRANSACTIONTYPE;
                public TTReportField DOCUMENTTRANSACTIONTYPEVALUE;
                public TTReportField BASEDATETIMENUMBER;
                public TTReportField CONCLUSIONDATETIMENUMBER;
                public TTReportField IDARESI;
                public TTReportField HARCAMABIRIMI;
                public TTReportField DEPOSUAMBARI;
                public TTReportField TESLIMEDENFIRMA;
                public TTReportField IDARESIKODU;
                public TTReportField HARCAMABIRIMIKODU;
                public TTReportField DEPOSUAMBARIKODU;
                public TTReportField TESLIMEDENFIRMAKODU; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 61, 5, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.TextFont.Bold = true;
                    NewField111123.Value = @"BELGE NU.";

                    NewField1321111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 170, 5, false);
                    NewField1321111.Name = "NewField1321111";
                    NewField1321111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321111.TextFont.Bold = true;
                    NewField1321111.Value = @"TARİH";

                    NewField11111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 5, 181, 10, false);
                    NewField11111231.Name = "NewField11111231";
                    NewField11111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111231.TextFont.Bold = true;
                    NewField11111231.Value = @"KODU";

                    NewField113211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 20, 181, 25, false);
                    NewField113211111.Name = "NewField113211111";
                    NewField113211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211111.TextFont.Bold = true;
                    NewField113211111.Value = @"KODU";

                    NewField113211112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 15, 181, 20, false);
                    NewField113211112.Name = "NewField113211112";
                    NewField113211112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211112.TextFont.Bold = true;
                    NewField113211112.Value = @"KODU";

                    NewField113211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 10, 181, 15, false);
                    NewField113211113.Name = "NewField113211113";
                    NewField113211113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211113.TextFont.Bold = true;
                    NewField113211113.Value = @"KODU";

                    NewField1111112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 25, 200, 30, false);
                    NewField1111112311.Name = "NewField1111112311";
                    NewField1111112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112311.TextFont.Bold = true;
                    NewField1111112311.Value = @"İŞLEM ÇEŞİDİ";

                    NewField1321112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 61, 10, false);
                    NewField1321112.Name = "NewField1321112";
                    NewField1321112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321112.TextFont.Bold = true;
                    NewField1321112.Value = @"İDARESİ";

                    NewField1321113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 61, 15, false);
                    NewField1321113.Name = "NewField1321113";
                    NewField1321113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321113.TextFont.Bold = true;
                    NewField1321113.Value = @"HARCAMA BİRİMİ";

                    NewField1321114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 61, 20, false);
                    NewField1321114.Name = "NewField1321114";
                    NewField1321114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321114.TextFont.Bold = true;
                    NewField1321114.Value = @"DEPOSU / AMBARI";

                    NewField1321115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 61, 25, false);
                    NewField1321115.Name = "NewField1321115";
                    NewField1321115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321115.TextFont.Bold = true;
                    NewField1321115.Value = @"TESLİM EDEN FİRMA";

                    NewField1321116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 103, 30, false);
                    NewField1321116.Name = "NewField1321116";
                    NewField1321116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321116.TextFont.Bold = true;
                    NewField1321116.Value = @"FATURA VEYA DAYANAĞI BELGENİN TARİH / SAYI";

                    NewField1321117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 103, 35, false);
                    NewField1321117.Name = "NewField1321117";
                    NewField1321117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321117.TextFont.Bold = true;
                    NewField1321117.Value = @"MUAYENE VE KABUL KOMİSYON RAPORU TARİH / SAYI ";

                    DOCUMENTRECORDLOGNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 0, 149, 5, false);
                    DOCUMENTRECORDLOGNUMBER.Name = "DOCUMENTRECORDLOGNUMBER";
                    DOCUMENTRECORDLOGNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTRECORDLOGNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTRECORDLOGNUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DOCUMENTRECORDLOGNUMBER.ObjectDefName = "DocumentRecordLog";
                    DOCUMENTRECORDLOGNUMBER.DataMember = "DOCUMENTRECORDLOGNUMBER";
                    DOCUMENTRECORDLOGNUMBER.TextFont.Name = "Arial";
                    DOCUMENTRECORDLOGNUMBER.Value = @"{@TTOBJECTID@}  ";

                    DOCUMENTDATETIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 200, 5, false);
                    DOCUMENTDATETIME.Name = "DOCUMENTDATETIME";
                    DOCUMENTDATETIME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTDATETIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATETIME.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATETIME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTDATETIME.ObjectDefName = "DocumentRecordLog";
                    DOCUMENTDATETIME.DataMember = "DOCUMENTDATETIME";
                    DOCUMENTDATETIME.TextFont.Name = "Arial";
                    DOCUMENTDATETIME.Value = @"{@TTOBJECTID@}  ";

                    DOCUMENTTRANSACTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 30, 200, 35, false);
                    DOCUMENTTRANSACTIONTYPE.Name = "DOCUMENTTRANSACTIONTYPE";
                    DOCUMENTTRANSACTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTTRANSACTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTTRANSACTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTTRANSACTIONTYPE.ObjectDefName = "DocumentTransactionTypeEnum";
                    DOCUMENTTRANSACTIONTYPE.DataMember = "DISPLAYTEXT";
                    DOCUMENTTRANSACTIONTYPE.TextFont.Name = "Arial";
                    DOCUMENTTRANSACTIONTYPE.Value = @"{%DOCUMENTTRANSACTIONTYPEVALUE%}";

                    DOCUMENTTRANSACTIONTYPEVALUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 14, 275, 19, false);
                    DOCUMENTTRANSACTIONTYPEVALUE.Name = "DOCUMENTTRANSACTIONTYPEVALUE";
                    DOCUMENTTRANSACTIONTYPEVALUE.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTTRANSACTIONTYPEVALUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTTRANSACTIONTYPEVALUE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DOCUMENTTRANSACTIONTYPEVALUE.ObjectDefName = "DocumentRecordLog";
                    DOCUMENTTRANSACTIONTYPEVALUE.DataMember = "DOCUMENTTRANSACTIONTYPE";
                    DOCUMENTTRANSACTIONTYPEVALUE.TextFont.Name = "Arial";
                    DOCUMENTTRANSACTIONTYPEVALUE.Value = @"{@TTOBJECTID@}  ";

                    BASEDATETIMENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 25, 159, 30, false);
                    BASEDATETIMENUMBER.Name = "BASEDATETIMENUMBER";
                    BASEDATETIMENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    BASEDATETIMENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASEDATETIMENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BASEDATETIMENUMBER.TextFont.Name = "Arial";
                    BASEDATETIMENUMBER.Value = @"";

                    CONCLUSIONDATETIMENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 30, 159, 35, false);
                    CONCLUSIONDATETIMENUMBER.Name = "CONCLUSIONDATETIMENUMBER";
                    CONCLUSIONDATETIMENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    CONCLUSIONDATETIMENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONDATETIMENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONCLUSIONDATETIMENUMBER.TextFont.Name = "Arial";
                    CONCLUSIONDATETIMENUMBER.Value = @"";

                    IDARESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 5, 170, 10, false);
                    IDARESI.Name = "IDARESI";
                    IDARESI.DrawStyle = DrawStyleConstants.vbSolid;
                    IDARESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDARESI.TextFont.Size = 10;
                    IDARESI.Value = @"";

                    HARCAMABIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 10, 170, 15, false);
                    HARCAMABIRIMI.Name = "HARCAMABIRIMI";
                    HARCAMABIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMABIRIMI.TextFont.Size = 10;
                    HARCAMABIRIMI.Value = @"";

                    DEPOSUAMBARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 15, 170, 20, false);
                    DEPOSUAMBARI.Name = "DEPOSUAMBARI";
                    DEPOSUAMBARI.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPOSUAMBARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPOSUAMBARI.TextFont.Size = 10;
                    DEPOSUAMBARI.Value = @"";

                    TESLIMEDENFIRMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 20, 170, 25, false);
                    TESLIMEDENFIRMA.Name = "TESLIMEDENFIRMA";
                    TESLIMEDENFIRMA.DrawStyle = DrawStyleConstants.vbSolid;
                    TESLIMEDENFIRMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDENFIRMA.TextFont.Size = 10;
                    TESLIMEDENFIRMA.Value = @"";

                    IDARESIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 5, 200, 10, false);
                    IDARESIKODU.Name = "IDARESIKODU";
                    IDARESIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    IDARESIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDARESIKODU.TextFont.Size = 8;
                    IDARESIKODU.Value = @"";

                    HARCAMABIRIMIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 10, 200, 15, false);
                    HARCAMABIRIMIKODU.Name = "HARCAMABIRIMIKODU";
                    HARCAMABIRIMIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMABIRIMIKODU.TextFont.Size = 8;
                    HARCAMABIRIMIKODU.Value = @"";

                    DEPOSUAMBARIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 15, 200, 20, false);
                    DEPOSUAMBARIKODU.Name = "DEPOSUAMBARIKODU";
                    DEPOSUAMBARIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPOSUAMBARIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPOSUAMBARIKODU.TextFont.Size = 8;
                    DEPOSUAMBARIKODU.Value = @"";

                    TESLIMEDENFIRMAKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 20, 200, 25, false);
                    TESLIMEDENFIRMAKODU.Name = "TESLIMEDENFIRMAKODU";
                    TESLIMEDENFIRMAKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    TESLIMEDENFIRMAKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDENFIRMAKODU.TextFont.Size = 8;
                    TESLIMEDENFIRMAKODU.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111123.CalcValue = NewField111123.Value;
                    NewField1321111.CalcValue = NewField1321111.Value;
                    NewField11111231.CalcValue = NewField11111231.Value;
                    NewField113211111.CalcValue = NewField113211111.Value;
                    NewField113211112.CalcValue = NewField113211112.Value;
                    NewField113211113.CalcValue = NewField113211113.Value;
                    NewField1111112311.CalcValue = NewField1111112311.Value;
                    NewField1321112.CalcValue = NewField1321112.Value;
                    NewField1321113.CalcValue = NewField1321113.Value;
                    NewField1321114.CalcValue = NewField1321114.Value;
                    NewField1321115.CalcValue = NewField1321115.Value;
                    NewField1321116.CalcValue = NewField1321116.Value;
                    NewField1321117.CalcValue = NewField1321117.Value;
                    DOCUMENTRECORDLOGNUMBER.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DOCUMENTRECORDLOGNUMBER.PostFieldValueCalculation();
                    DOCUMENTDATETIME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DOCUMENTDATETIME.PostFieldValueCalculation();
                    DOCUMENTTRANSACTIONTYPEVALUE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DOCUMENTTRANSACTIONTYPEVALUE.PostFieldValueCalculation();
                    DOCUMENTTRANSACTIONTYPE.CalcValue = MyParentReport.PARTA.DOCUMENTTRANSACTIONTYPEVALUE.CalcValue;
                    DOCUMENTTRANSACTIONTYPE.PostFieldValueCalculation();
                    BASEDATETIMENUMBER.CalcValue = @"";
                    CONCLUSIONDATETIMENUMBER.CalcValue = @"";
                    IDARESI.CalcValue = @"";
                    HARCAMABIRIMI.CalcValue = @"";
                    DEPOSUAMBARI.CalcValue = @"";
                    TESLIMEDENFIRMA.CalcValue = @"";
                    IDARESIKODU.CalcValue = @"";
                    HARCAMABIRIMIKODU.CalcValue = @"";
                    DEPOSUAMBARIKODU.CalcValue = @"";
                    TESLIMEDENFIRMAKODU.CalcValue = @"";
                    return new TTReportObject[] { NewField111123,NewField1321111,NewField11111231,NewField113211111,NewField113211112,NewField113211113,NewField1111112311,NewField1321112,NewField1321113,NewField1321114,NewField1321115,NewField1321116,NewField1321117,DOCUMENTRECORDLOGNUMBER,DOCUMENTDATETIME,DOCUMENTTRANSACTIONTYPEVALUE,DOCUMENTTRANSACTIONTYPE,BASEDATETIMENUMBER,CONCLUSIONDATETIMENUMBER,IDARESI,HARCAMABIRIMI,DEPOSUAMBARI,TESLIMEDENFIRMA,IDARESIKODU,HARCAMABIRIMIKODU,DEPOSUAMBARIKODU,TESLIMEDENFIRMAKODU};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));
                if (string.IsNullOrEmpty(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue) == false && Globals.IsGuid(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue))
                {
                    Guid stockActionObjectID = new Guid(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue);

                    StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(stockActionObjectID, typeof(StockAction));

                    if (stockAction is IBaseChattelDocument)
                    {
                        IBaseChattelDocument baseChattelDocument = (IBaseChattelDocument)stockAction;
                        BASEDATETIMENUMBER.CalcValue = baseChattelDocument.GetTransactionDate().Value.ToString("dd.MM.yyyy") + " / " + baseChattelDocument.GetStockActionID();
                    }

                    if (stockAction is IChattelDocumentOutputWithAccountancy)
                    {
                        IChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy = (IChattelDocumentOutputWithAccountancy)stockAction;
                        DEPOSUAMBARI.CalcValue = chattelDocumentOutputWithAccountancy.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = chattelDocumentOutputWithAccountancy.GetStore().GetQREF();
                        //  IDARESI.CalcValue = chattelDocumentOutputWithAccountancy.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        //  IDARESIKODU.CalcValue = chattelDocumentOutputWithAccountancy.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        //   if(string.IsNullOrEmpty(chattelDocumentOutputWithAccountancy.SpendingUnit) == false)
                        //     HARCAMABIRIMI.CalcValue = chattelDocumentOutputWithAccountancy.SpendingUnit.ToString();
                        //  if(string.IsNullOrEmpty(chattelDocumentOutputWithAccountancy.SpendingUnitCode) == false)
                        //      HARCAMABIRIMIKODU.CalcValue = chattelDocumentOutputWithAccountancy.SpendingUnitCode.ToString();
                    }

                    if (stockAction is IDistributionDocument)
                    {
                        IDistributionDocument distributionDocument = (IDistributionDocument)stockAction;
                        DEPOSUAMBARI.CalcValue = distributionDocument.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = distributionDocument.GetStore().GetQREF();
                        // IDARESI.CalcValue = distributionDocument.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        // IDARESIKODU.CalcValue = distributionDocument.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        // HARCAMABIRIMI.CalcValue = distributionDocument.AccountingTerm.Accountancy.Name;
                        //  HARCAMABIRIMIKODU.CalcValue = distributionDocument.AccountingTerm.Accountancy.AccountancyNO;
                    }
                    if (stockAction is IProductionConsumptionDocument)
                    {
                        IProductionConsumptionDocument productionConsumptionDocument = (IProductionConsumptionDocument)stockAction;
                        DEPOSUAMBARI.CalcValue = productionConsumptionDocument.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = productionConsumptionDocument.GetStore().GetQREF();
                        //   IDARESI.CalcValue = productionConsumptionDocument.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        //    IDARESIKODU.CalcValue = productionConsumptionDocument.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        //   HARCAMABIRIMI.CalcValue = productionConsumptionDocument.AccountingTerm.Accountancy.Name;
                        //   HARCAMABIRIMIKODU.CalcValue = productionConsumptionDocument.AccountingTerm.Accountancy.AccountancyNO;
                    }
                    if (stockAction is ICensusFixed)
                    {
                        ICensusFixed censusFixed = (ICensusFixed)stockAction;
                        DEPOSUAMBARI.CalcValue = censusFixed.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = censusFixed.GetStore().GetQREF();
                        //   IDARESI.CalcValue = censusFixed.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        //   IDARESIKODU.CalcValue = censusFixed.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        //   HARCAMABIRIMI.CalcValue = censusFixed.AccountingTerm.Accountancy.Name;
                        //   HARCAMABIRIMIKODU.CalcValue = censusFixed.AccountingTerm.Accountancy.AccountancyNO;
                        BASEDATETIMENUMBER.CalcValue = censusFixed.GetTransactionDate().Value.ToString("dd.MM.yyyy") + " / " + censusFixed.GetRegistrationNumber();
                    }
                    if (stockAction is IConsignedCensusFixed)
                    {
                        IConsignedCensusFixed consignedCensusFixed = (IConsignedCensusFixed)stockAction;
                        DEPOSUAMBARI.CalcValue = consignedCensusFixed.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = consignedCensusFixed.GetStore().GetQREF();
                        //  IDARESI.CalcValue = consignedCensusFixed.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        // IDARESIKODU.CalcValue = consignedCensusFixed.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        //  HARCAMABIRIMI.CalcValue = consignedCensusFixed.AccountingTerm.Accountancy.Name;
                        //  HARCAMABIRIMIKODU.CalcValue = consignedCensusFixed.AccountingTerm.Accountancy.AccountancyNO;
                        BASEDATETIMENUMBER.CalcValue = consignedCensusFixed.GetTransactionDate().Value.ToString("dd.MM.yyyy") + " / " + consignedCensusFixed.GetRegistrationNumber();
                    }
                    if (stockAction is IDeleteRecordDocumentDestroyable)
                    {
                        IDeleteRecordDocumentDestroyable deleteRecordDocumentDestroyable = (IDeleteRecordDocumentDestroyable)stockAction;
                        DEPOSUAMBARI.CalcValue = deleteRecordDocumentDestroyable.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = deleteRecordDocumentDestroyable.GetStore().GetQREF();
                        //   IDARESI.CalcValue = deleteRecordDocumentDestroyable.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        //  IDARESIKODU.CalcValue = deleteRecordDocumentDestroyable.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        //   HARCAMABIRIMI.CalcValue = deleteRecordDocumentDestroyable.AccountingTerm.Accountancy.Name;
                        //   HARCAMABIRIMIKODU.CalcValue = deleteRecordDocumentDestroyable.AccountingTerm.Accountancy.AccountancyNO;
                    }
                    if (stockAction is IStockMerge)
                    {
                        IStockMerge stockMerge = (IStockMerge)stockAction;
                        DEPOSUAMBARI.CalcValue = stockMerge.GetStore().GetName();
                        DEPOSUAMBARIKODU.CalcValue = stockMerge.GetStore().GetQREF();
                        //   IDARESI.CalcValue = stockMerge.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        //   IDARESIKODU.CalcValue = stockMerge.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code;
                        //  HARCAMABIRIMI.CalcValue = stockMerge.AccountingTerm.Accountancy.Name;
                        //  HARCAMABIRIMIKODU.CalcValue = stockMerge.AccountingTerm.Accountancy.AccountancyNO;
                        BASEDATETIMENUMBER.CalcValue = stockMerge.GetTransactionDate().Value.ToString("dd.MM.yyyy") + " / " + stockMerge.GetRegistrationNumber();
                    }
                }
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField111121;
                public TTReportField NewField111122;
                public TTReportField NewField1221111;
                public TTReportField NewField1121111;
                public TTReportField NewField11111211;
                public TTReportField GONDERILENYER;
                public TTReportField GONDERILENDEPO;
                public TTReportField GONDERILENYERKODU;
                public TTReportField GONDERILENDEPOKODU;
                public TTReportField DESCRIPTION;
                public TTReportField DESCRIPTIONTOPLEFT;
                public TTReportField DESCRIPTIONTOPRIGHT;
                public TTReportField SIGNTOPLEFTS;
                public TTReportField SIGNTOPRIGHTS;
                public TTReportField SIGNTOPLEFTM;
                public TTReportField SIGNTOPLEFTE;
                public TTReportField SIGNTOPRIGHTM;
                public TTReportField SIGNTOPRIGHTE;
                public TTReportField NewField12112;
                public TTReportField SUMOFPRICE; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 63;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 200, 15, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"NOT :";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 200, 21, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.Value = @"BİRİMLER VE DEPOLAR ARASI TAŞINIR HAREKETLERİNDE";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 61, 26, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.Value = @"GÖNDERİLEN YER";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 26, 61, 31, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111121.TextFont.Bold = true;
                    NewField111121.Value = @"GÖNDERİLEN DEPO / AMBAR";

                    NewField111122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 21, 180, 26, false);
                    NewField111122.Name = "NewField111122";
                    NewField111122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111122.TextFont.Bold = true;
                    NewField111122.Value = @"KODU";

                    NewField1221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 26, 180, 31, false);
                    NewField1221111.Name = "NewField1221111";
                    NewField1221111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221111.TextFont.Bold = true;
                    NewField1221111.Value = @"KODU";

                    NewField1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 105, 63, false);
                    NewField1121111.Name = "NewField1121111";
                    NewField1121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121111.TextFont.Bold = true;
                    NewField1121111.Value = @"";

                    NewField11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 31, 200, 63, false);
                    NewField11111211.Name = "NewField11111211";
                    NewField11111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111211.TextFont.Bold = true;
                    NewField11111211.Value = @"";

                    GONDERILENYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 21, 169, 26, false);
                    GONDERILENYER.Name = "GONDERILENYER";
                    GONDERILENYER.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERILENYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILENYER.TextFont.Size = 10;
                    GONDERILENYER.Value = @"";

                    GONDERILENDEPO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 26, 169, 31, false);
                    GONDERILENDEPO.Name = "GONDERILENDEPO";
                    GONDERILENDEPO.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERILENDEPO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILENDEPO.TextFont.Size = 10;
                    GONDERILENDEPO.Value = @"";

                    GONDERILENYERKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 21, 200, 26, false);
                    GONDERILENYERKODU.Name = "GONDERILENYERKODU";
                    GONDERILENYERKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERILENYERKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILENYERKODU.TextFont.Size = 10;
                    GONDERILENYERKODU.Value = @"";

                    GONDERILENDEPOKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 26, 200, 31, false);
                    GONDERILENDEPOKODU.Name = "GONDERILENDEPOKODU";
                    GONDERILENDEPOKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERILENDEPOKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILENDEPOKODU.TextFont.Size = 10;
                    GONDERILENDEPOKODU.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 6, 199, 15, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Courier New";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.Value = @"";

                    DESCRIPTIONTOPLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 32, 104, 43, false);
                    DESCRIPTIONTOPLEFT.Name = "DESCRIPTIONTOPLEFT";
                    DESCRIPTIONTOPLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONTOPLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOPLEFT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONTOPLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPLEFT.TextFont.Name = "Courier New";
                    DESCRIPTIONTOPLEFT.TextFont.Size = 8;
                    DESCRIPTIONTOPLEFT.Value = @"";

                    DESCRIPTIONTOPRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 32, 199, 43, false);
                    DESCRIPTIONTOPRIGHT.Name = "DESCRIPTIONTOPRIGHT";
                    DESCRIPTIONTOPRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONTOPRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOPRIGHT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONTOPRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPRIGHT.TextFont.Name = "Courier New";
                    DESCRIPTIONTOPRIGHT.TextFont.Size = 8;
                    DESCRIPTIONTOPRIGHT.Value = @"";

                    SIGNTOPLEFTS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 41, 62, false);
                    SIGNTOPLEFTS.Name = "SIGNTOPLEFTS";
                    SIGNTOPLEFTS.FillStyle = FillStyleConstants.vbFSTransparent;
                    SIGNTOPLEFTS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNTOPLEFTS.VertAlign = VerticalAlignmentEnum.vaTop;
                    SIGNTOPLEFTS.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTS.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTS.TextFont.Name = "Courier New";
                    SIGNTOPLEFTS.TextFont.Size = 7;
                    SIGNTOPLEFTS.Value = @"";

                    SIGNTOPRIGHTS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 43, 136, 62, false);
                    SIGNTOPRIGHTS.Name = "SIGNTOPRIGHTS";
                    SIGNTOPRIGHTS.FillStyle = FillStyleConstants.vbFSTransparent;
                    SIGNTOPRIGHTS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNTOPRIGHTS.VertAlign = VerticalAlignmentEnum.vaTop;
                    SIGNTOPRIGHTS.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTS.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTS.TextFont.Name = "Courier New";
                    SIGNTOPRIGHTS.TextFont.Size = 7;
                    SIGNTOPRIGHTS.Value = @"";

                    SIGNTOPLEFTM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 43, 73, 62, false);
                    SIGNTOPLEFTM.Name = "SIGNTOPLEFTM";
                    SIGNTOPLEFTM.FillStyle = FillStyleConstants.vbFSTransparent;
                    SIGNTOPLEFTM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNTOPLEFTM.VertAlign = VerticalAlignmentEnum.vaTop;
                    SIGNTOPLEFTM.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTM.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTM.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTM.TextFont.Name = "Courier New";
                    SIGNTOPLEFTM.TextFont.Size = 7;
                    SIGNTOPLEFTM.Value = @"";

                    SIGNTOPLEFTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 43, 104, 62, false);
                    SIGNTOPLEFTE.Name = "SIGNTOPLEFTE";
                    SIGNTOPLEFTE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SIGNTOPLEFTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNTOPLEFTE.VertAlign = VerticalAlignmentEnum.vaTop;
                    SIGNTOPLEFTE.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTE.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNTOPLEFTE.TextFont.Name = "Courier New";
                    SIGNTOPLEFTE.TextFont.Size = 7;
                    SIGNTOPLEFTE.Value = @"";

                    SIGNTOPRIGHTM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 43, 167, 62, false);
                    SIGNTOPRIGHTM.Name = "SIGNTOPRIGHTM";
                    SIGNTOPRIGHTM.FillStyle = FillStyleConstants.vbFSTransparent;
                    SIGNTOPRIGHTM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNTOPRIGHTM.VertAlign = VerticalAlignmentEnum.vaTop;
                    SIGNTOPRIGHTM.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTM.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTM.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTM.TextFont.Name = "Courier New";
                    SIGNTOPRIGHTM.TextFont.Size = 7;
                    SIGNTOPRIGHTM.Value = @"";

                    SIGNTOPRIGHTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 43, 199, 62, false);
                    SIGNTOPRIGHTE.Name = "SIGNTOPRIGHTE";
                    SIGNTOPRIGHTE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SIGNTOPRIGHTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNTOPRIGHTE.VertAlign = VerticalAlignmentEnum.vaTop;
                    SIGNTOPRIGHTE.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTE.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNTOPRIGHTE.TextFont.Name = "Courier New";
                    SIGNTOPRIGHTE.TextFont.Size = 7;
                    SIGNTOPRIGHTE.Value = @"";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 147, 5, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112.TextFont.Bold = true;
                    NewField12112.Value = @"GENEL TOPLAM";

                    SUMOFPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 0, 200, 5, false);
                    SUMOFPRICE.Name = "SUMOFPRICE";
                    SUMOFPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    SUMOFPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFPRICE.TextFormat = @"#.##";
                    SUMOFPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUMOFPRICE.TextFont.Bold = true;
                    SUMOFPRICE.Value = @"{@sumof(SUMOFPRICE)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField111122.CalcValue = NewField111122.Value;
                    NewField1221111.CalcValue = NewField1221111.Value;
                    NewField1121111.CalcValue = NewField1121111.Value;
                    NewField11111211.CalcValue = NewField11111211.Value;
                    GONDERILENYER.CalcValue = @"";
                    GONDERILENDEPO.CalcValue = @"";
                    GONDERILENYERKODU.CalcValue = @"";
                    GONDERILENDEPOKODU.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    DESCRIPTIONTOPLEFT.CalcValue = @"";
                    DESCRIPTIONTOPRIGHT.CalcValue = @"";
                    SIGNTOPLEFTS.CalcValue = @"";
                    SIGNTOPRIGHTS.CalcValue = @"";
                    SIGNTOPLEFTM.CalcValue = @"";
                    SIGNTOPLEFTE.CalcValue = @"";
                    SIGNTOPRIGHTM.CalcValue = @"";
                    SIGNTOPRIGHTE.CalcValue = @"";
                    NewField12112.CalcValue = NewField12112.Value;
                    SUMOFPRICE.CalcValue = ParentGroup.FieldSums["SUMOFPRICE"].Value.ToString();;
                    return new TTReportObject[] { NewField1111,NewField1112,NewField12111,NewField111121,NewField111122,NewField1221111,NewField1121111,NewField11111211,GONDERILENYER,GONDERILENDEPO,GONDERILENYERKODU,GONDERILENDEPOKODU,DESCRIPTION,DESCRIPTIONTOPLEFT,DESCRIPTIONTOPRIGHT,SIGNTOPLEFTS,SIGNTOPRIGHTS,SIGNTOPLEFTM,SIGNTOPLEFTE,SIGNTOPRIGHTM,SIGNTOPRIGHTE,NewField12112,SUMOFPRICE};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));

                if (string.IsNullOrEmpty(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue) == false && Globals.IsGuid(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue))
                {
                    Guid stockActionObjectID = new Guid(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue);
                    StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(stockActionObjectID, typeof(StockAction));
                    DESCRIPTION.CalcValue = stockAction.Description;

                    foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                    {
                        if(stockActionSignDetail.SignUserType != SignUserTypeEnum.YetkiliMakam)
                        {
                            string signDesc = string.Empty;
                            string unvan = string.Empty;
                            string vekil = string.Empty;
                            signDesc += stockActionSignDetail.SignUser.Name + "\r\n";
                            if (stockActionSignDetail.SignUser.Title != null && stockActionSignDetail.SignUser.Title != UserTitleEnum.Unused)
                                signDesc += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(stockActionSignDetail.SignUser.Title.Value).DisplayText;
                            if (stockActionSignDetail.SignUser.MilitaryClass != null)
                                signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                            if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
                            {
                                if(stockActionSignDetail.SignUser.StaffOfficer.HasValue && (bool)stockActionSignDetail.SignUser.StaffOfficer)
                                    signDesc += "Kurmay " + stockActionSignDetail.SignUser.Rank.ShortName;
                                else
                                    signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                            }
                            if (stockActionSignDetail.SignUser != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.EmploymentRecordID) == false)
                                signDesc += " (" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
                            if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
                                vekil += " Vek.";
                            if (stockActionSignDetail.SignUserType.HasValue)
                                unvan = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(stockActionSignDetail.SignUserType.Value).DisplayText;
                            switch (stockActionSignDetail.SignUserType)
                            {
                                case SignUserTypeEnum.HesapSorumlusu:
                                    this.SIGNTOPRIGHTS.CalcValue = unvan + vekil + "\r\n" + signDesc;
                                    this.SIGNTOPLEFTS.CalcValue = unvan;
                                    break;
                                case SignUserTypeEnum.MalSorumlusu:
                                    this.SIGNTOPRIGHTM.CalcValue = unvan + vekil + "\r\n" + signDesc;
                                    this.SIGNTOPLEFTM.CalcValue = unvan;
                                    break;
                                case SignUserTypeEnum.MalSaymani:
                                    this.SIGNTOPRIGHTE.CalcValue = unvan + vekil + "\r\n" + signDesc;
                                    this.SIGNTOPLEFTE.CalcValue = unvan;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (stockAction is IChattelDocumentOutputWithAccountancy)
                    {
                        IChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy = (IChattelDocumentOutputWithAccountancy)stockAction;
                        GONDERILENYER.CalcValue = chattelDocumentOutputWithAccountancy.GetAccountancy().GetName();
                        GONDERILENYERKODU.CalcValue = chattelDocumentOutputWithAccountancy.GetAccountancy().GetAccountancyNO();
                    }

                    if (stockAction is IDistributionDocument)
                    {
                        IDistributionDocument distributionDocument = (IDistributionDocument)stockAction;
                        GONDERILENYER.CalcValue = distributionDocument.GetDestinationStore().GetName();
                        GONDERILENYERKODU.CalcValue = distributionDocument.GetDestinationStore().GetQREF();
                    }

                    double amount = 0;
                    string message = string.Empty;

                    foreach (StockActionDetail stockActionDetail in stockAction.StockActionDetails)
                        amount += stockActionDetail.Amount.Value;

                    message = "Yukarıda gösterilen ..... kalem, toplam ..... taşınırın GİRİŞ KAYDI YAPILMIŞTIR.\r\n";
                    message += "                                      ..../..../20....\r\n";
                    DESCRIPTIONTOPLEFT.CalcValue = message;

                    message = "Yukarıda gösterilen " + documentRecordLog.NumberOfRows + " kalem, toplam " + amount + " taşınırın ÇIKIŞ KAYDI YAPILMIŞTIR.\r\n";
                    message += "                                            " + documentRecordLog.DocumentDateTime.Value.ToString("dd.MM.yyyy");
                    DESCRIPTIONTOPRIGHT.CalcValue = message;
                }
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ChattelDocumentOutDetailReport MyParentReport
            {
                get { return (ChattelDocumentOutDetailReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField1311111 { get {return Header().NewField1311111;} }
            public TTReportField NewField1311112 { get {return Header().NewField1311112;} }
            public TTReportField DESCRIPTIONTOTAL { get {return Footer().DESCRIPTIONTOTAL;} }
            public TTReportField SUMOFPRICE { get {return Footer().SUMOFPRICE;} }
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
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField111113;
                public TTReportField NewField1311111;
                public TTReportField NewField1311112; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 200, 9, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"TAŞINIR MALIN";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 19, 27, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"
Sıra Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 9, 53, 27, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Stok Numarası";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 9, 129, 27, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Cins, Özellikleri ve Malın Durumu";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 9, 144, 27, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.Value = @"
Ölçü
Birimi";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 9, 162, 27, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.Value = @"Miktarı";

                    NewField1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 9, 180, 27, false);
                    NewField1311111.Name = "NewField1311111";
                    NewField1311111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311111.TextFont.Bold = true;
                    NewField1311111.Value = @"Birim Maliyet Bedeli";

                    NewField1311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 9, 200, 27, false);
                    NewField1311112.Name = "NewField1311112";
                    NewField1311112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112.TextFont.Bold = true;
                    NewField1311112.Value = @"Tutarı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1311111.CalcValue = NewField1311111.Value;
                    NewField1311112.CalcValue = NewField1311112.Value;
                    return new TTReportObject[] { NewField111,NewField1111,NewField11111,NewField111111,NewField111112,NewField111113,NewField1311111,NewField1311112};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTIONTOTAL;
                public TTReportField SUMOFPRICE; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    DESCRIPTIONTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 199, 6, false);
                    DESCRIPTIONTOTAL.Name = "DESCRIPTIONTOTAL";
                    DESCRIPTIONTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTIONTOTAL.TextFont.Name = "Arial";
                    DESCRIPTIONTOTAL.TextFont.Size = 10;
                    DESCRIPTIONTOTAL.Value = @"";

                    SUMOFPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 2, 251, 7, false);
                    SUMOFPRICE.Name = "SUMOFPRICE";
                    SUMOFPRICE.Visible = EvetHayirEnum.ehHayir;
                    SUMOFPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    SUMOFPRICE.TextFont.Size = 10;
                    SUMOFPRICE.TextFont.CharSet = 1;
                    SUMOFPRICE.Value = @"{@sumof(PRICE)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTIONTOTAL.CalcValue = @"";
                    SUMOFPRICE.CalcValue = ParentGroup.FieldSums["PRICE"].Value.ToString();;
                    return new TTReportObject[] { DESCRIPTIONTOTAL,SUMOFPRICE};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));
                        string closer = "////";
                        DESCRIPTIONTOTAL.CalcValue = closer + "Yalnız " + documentRecordLog.NumberOfRows + "(" + TTReportTool.Common.SpellNumber(documentRecordLog.NumberOfRows.ToString()) + ") kalemdir." + closer;
                    }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ChattelDocumentOutDetailReport MyParentReport
            {
                get { return (ChattelDocumentOutDetailReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
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
                list[0] = new TTReportNqlData<StockTransaction.StockTransactionOutDetailsReportQuery_Class>("StockTransactionOutDetailsReportQuery", StockTransaction.StockTransactionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTC.STOCKACTIONOBJECTID.CalcValue),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.BUDGETTYPE)));
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
                public ChattelDocumentOutDetailReport MyParentReport
                {
                    get { return (ChattelDocumentOutDetailReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.Value = @"{@counter@} ";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 5, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extPageHeight;

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 53, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.TextFont.Size = 9;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 129, 5, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 9;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 144, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 162, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 180, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.ObjectDefName = "StockActionDetailOut";
                    UNITPRICE.DataMember = "UnitPrice";
                    UNITPRICE.TextFont.Size = 9;
                    UNITPRICE.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 200, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,###.######";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.ObjectDefName = "StockActionDetailOut";
                    PRICE.DataMember = "Price";
                    PRICE.TextFont.Size = 9;
                    PRICE.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.StockTransactionOutDetailsReportQuery_Class dataset_StockTransactionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.StockTransactionOutDetailsReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    NATOSTOCKNO.CalcValue = (dataset_StockTransactionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionOutDetailsReportQuery.NATOStockNO) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockTransactionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionOutDetailsReportQuery.Materialname) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockTransactionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionOutDetailsReportQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_StockTransactionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionOutDetailsReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_StockTransactionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    UNITPRICE.PostFieldValueCalculation();
                    PRICE.CalcValue = (dataset_StockTransactionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockTransactionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    PRICE.PostFieldValueCalculation();
                    return new TTReportObject[] { ORDERNO,NATOSTOCKNO,MATERIALDESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,UNITPRICE,PRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ChattelDocumentOutDetailReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("BUDGETTYPE", "", "Bütçe Türü Seçiniz", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("BUDGETTYPE"))
                _runtimeParameters.BUDGETTYPE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["BUDGETTYPE"]);
            Name = "CHATTELDOCUMENTOUTDETAILREPORT";
            Caption = "Taşınır Mal İşlem Belgesi";
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
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
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
            fd.TextFont.Size = 11;
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