
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
    /// Bağlı Birlik Dağıtım / İade Belgesi
    /// </summary>
    public partial class DepDistributionDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public DepDistributionDocumentReport MyParentReport
            {
                get { return (DepDistributionDocumentReport)ParentReport; }
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
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 200, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"DAĞITIM / İADE BELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public DepDistributionDocumentReport MyParentReport
            {
                get { return (DepDistributionDocumentReport)ParentReport; }
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
            public TTReportField NewField1321115 { get {return Header().NewField1321115;} }
            public TTReportField NewField1321111 { get {return Header().NewField1321111;} }
            public TTReportField NewField1321112 { get {return Header().NewField1321112;} }
            public TTReportField NewField15111231 { get {return Header().NewField15111231;} }
            public TTReportField TASINIRMALSAYMANLIGI { get {return Header().TASINIRMALSAYMANLIGI;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField BELGENUMARASI { get {return Header().BELGENUMARASI;} }
            public TTReportField EMIRTARIHSAYISI { get {return Header().EMIRTARIHSAYISI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField DAGITIMMI { get {return Header().DAGITIMMI;} }
            public TTReportField IADEMI { get {return Header().IADEMI;} }
            public TTReportField NewField1121111 { get {return Footer().NewField1121111;} }
            public TTReportField NewField11111211 { get {return Footer().NewField11111211;} }
            public TTReportField DESCRIPTIONTOPLEFT { get {return Footer().DESCRIPTIONTOPLEFT;} }
            public TTReportField DESCRIPTIONTOPRIGHT { get {return Footer().DESCRIPTIONTOPRIGHT;} }
            public TTReportField NewField111211111 { get {return Footer().NewField111211111;} }
            public TTReportField NewField1111112111 { get {return Footer().NewField1111112111;} }
            public TTReportField DESCRIPTIONBOTTOMLEFT { get {return Footer().DESCRIPTIONBOTTOMLEFT;} }
            public TTReportField DESCRIPTIONBOTTOMRIGHT { get {return Footer().DESCRIPTIONBOTTOMRIGHT;} }
            public TTReportField DATETIMETOPLEFT { get {return Footer().DATETIMETOPLEFT;} }
            public TTReportField DATETIMETOPRIGHT { get {return Footer().DATETIMETOPRIGHT;} }
            public TTReportField DATETIMEBOTTOMLEFT { get {return Footer().DATETIMEBOTTOMLEFT;} }
            public TTReportField DATETIMEBOTTOMRIGHT { get {return Footer().DATETIMEBOTTOMRIGHT;} }
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
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField111123;
                public TTReportField NewField1321115;
                public TTReportField NewField1321111;
                public TTReportField NewField1321112;
                public TTReportField NewField15111231;
                public TTReportField TASINIRMALSAYMANLIGI;
                public TTReportField BIRLIK;
                public TTReportField BELGENUMARASI;
                public TTReportField EMIRTARIHSAYISI;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField DAGITIMMI;
                public TTReportField IADEMI; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 200, 9, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.TextFont.Bold = true;
                    NewField111123.Value = @"Belge Nu. :";

                    NewField1321115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 108, 13, false);
                    NewField1321115.Name = "NewField1321115";
                    NewField1321115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321115.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1321115.TextFont.Bold = true;
                    NewField1321115.Value = @"Taşınır Mal Saymanlığı";

                    NewField1321111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 9, 200, 18, false);
                    NewField1321111.Name = "NewField1321111";
                    NewField1321111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321111.TextFont.Bold = true;
                    NewField1321111.Value = @"İşlemin Cinsi :";

                    NewField1321112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 18, 200, 26, false);
                    NewField1321112.Name = "NewField1321112";
                    NewField1321112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321112.TextFont.Bold = true;
                    NewField1321112.Value = @"Emir Tarih ve Sayısı :";

                    NewField15111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 108, 26, false);
                    NewField15111231.Name = "NewField15111231";
                    NewField15111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15111231.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField15111231.TextFont.Bold = true;
                    NewField15111231.Value = @"Birlik";

                    TASINIRMALSAYMANLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 107, 13, false);
                    TASINIRMALSAYMANLIGI.Name = "TASINIRMALSAYMANLIGI";
                    TASINIRMALSAYMANLIGI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TASINIRMALSAYMANLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TASINIRMALSAYMANLIGI.VertAlign = VerticalAlignmentEnum.vaTop;
                    TASINIRMALSAYMANLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    TASINIRMALSAYMANLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    TASINIRMALSAYMANLIGI.TextFont.Size = 10;
                    TASINIRMALSAYMANLIGI.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 19, 106, 26, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaTop;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Size = 10;
                    BIRLIK.Value = @"";

                    BELGENUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 1, 198, 8, false);
                    BELGENUMARASI.Name = "BELGENUMARASI";
                    BELGENUMARASI.FillStyle = FillStyleConstants.vbFSTransparent;
                    BELGENUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELGENUMARASI.TextFont.Size = 10;
                    BELGENUMARASI.Value = @"";

                    EMIRTARIHSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 19, 198, 26, false);
                    EMIRTARIHSAYISI.Name = "EMIRTARIHSAYISI";
                    EMIRTARIHSAYISI.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRTARIHSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHSAYISI.TextFont.Size = 10;
                    EMIRTARIHSAYISI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 11, 149, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Size = 10;
                    NewField1.Value = @"Dağıtım";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 11, 174, 16, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField2.TextFont.Size = 10;
                    NewField2.Value = @"İade";

                    DAGITIMMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 11, 149, 16, false);
                    DAGITIMMI.Name = "DAGITIMMI";
                    DAGITIMMI.DrawStyle = DrawStyleConstants.vbSolid;
                    DAGITIMMI.FillStyle = FillStyleConstants.vbFSTransparent;
                    DAGITIMMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIMMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAGITIMMI.TextFont.Size = 10;
                    DAGITIMMI.Value = @"";

                    IADEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 11, 180, 16, false);
                    IADEMI.Name = "IADEMI";
                    IADEMI.DrawStyle = DrawStyleConstants.vbSolid;
                    IADEMI.FillStyle = FillStyleConstants.vbFSTransparent;
                    IADEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IADEMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IADEMI.TextFont.Size = 10;
                    IADEMI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111123.CalcValue = NewField111123.Value;
                    NewField1321115.CalcValue = NewField1321115.Value;
                    NewField1321111.CalcValue = NewField1321111.Value;
                    NewField1321112.CalcValue = NewField1321112.Value;
                    NewField15111231.CalcValue = NewField15111231.Value;
                    TASINIRMALSAYMANLIGI.CalcValue = @"";
                    BIRLIK.CalcValue = @"";
                    BELGENUMARASI.CalcValue = @"";
                    EMIRTARIHSAYISI.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    DAGITIMMI.CalcValue = @"";
                    IADEMI.CalcValue = @"";
                    return new TTReportObject[] { NewField111123,NewField1321115,NewField1321111,NewField1321112,NewField15111231,TASINIRMALSAYMANLIGI,BIRLIK,BELGENUMARASI,EMIRTARIHSAYISI,NewField1,NewField2,DAGITIMMI,IADEMI};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                if(stockAction is IDistributionDepStore)
                {
                    IDistributionDepStore distributionDepStore = (IDistributionDepStore)stockAction;
                    TASINIRMALSAYMANLIGI.CalcValue = distributionDepStore.GetAccountingTerm().GetAccountancy().GetName();
                    BIRLIK.CalcValue = stockAction.Store.Name;
                    DAGITIMMI.CalcValue = "X";
                }
                if (stockAction is IReturnDepStore)
                {
                    IReturnDepStore returnDepStore = (IReturnDepStore)stockAction;
                    TASINIRMALSAYMANLIGI.CalcValue = returnDepStore.GetAccountingTerm().GetAccountancy().GetName();
                    BIRLIK.CalcValue = stockAction.Store.Name;
                    IADEMI.CalcValue = "X";
                }
                EMIRTARIHSAYISI.CalcValue = stockAction.TransactionDate.Value.ToShortDateString() + " / " + stockAction.StockActionID.Value.Value;
                BELGENUMARASI.CalcValue = stockAction.RegistrationNumber;
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField1121111;
                public TTReportField NewField11111211;
                public TTReportField DESCRIPTIONTOPLEFT;
                public TTReportField DESCRIPTIONTOPRIGHT;
                public TTReportField NewField111211111;
                public TTReportField NewField1111112111;
                public TTReportField DESCRIPTIONBOTTOMLEFT;
                public TTReportField DESCRIPTIONBOTTOMRIGHT;
                public TTReportField DATETIMETOPLEFT;
                public TTReportField DATETIMETOPRIGHT;
                public TTReportField DATETIMEBOTTOMLEFT;
                public TTReportField DATETIMEBOTTOMRIGHT; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 68;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 105, 34, false);
                    NewField1121111.Name = "NewField1121111";
                    NewField1121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121111.TextFont.Bold = true;
                    NewField1121111.Value = @"";

                    NewField11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 200, 34, false);
                    NewField11111211.Name = "NewField11111211";
                    NewField11111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111211.TextFont.Bold = true;
                    NewField11111211.Value = @"";

                    DESCRIPTIONTOPLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 104, 25, false);
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

                    DESCRIPTIONTOPRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 199, 25, false);
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

                    NewField111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 105, 68, false);
                    NewField111211111.Name = "NewField111211111";
                    NewField111211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211111.TextFont.Bold = true;
                    NewField111211111.Value = @"";

                    NewField1111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 34, 200, 68, false);
                    NewField1111112111.Name = "NewField1111112111";
                    NewField1111112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112111.TextFont.Bold = true;
                    NewField1111112111.Value = @"";

                    DESCRIPTIONBOTTOMLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 35, 104, 59, false);
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

                    DESCRIPTIONBOTTOMRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 35, 199, 59, false);
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

                    DATETIMETOPLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 27, 104, 33, false);
                    DATETIMETOPLEFT.Name = "DATETIMETOPLEFT";
                    DATETIMETOPLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMETOPLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMETOPLEFT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMETOPLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMETOPLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMETOPLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMETOPLEFT.TextFont.Name = "Courier New";
                    DATETIMETOPLEFT.TextFont.Size = 8;
                    DATETIMETOPLEFT.Value = @"";

                    DATETIMETOPRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 27, 199, 33, false);
                    DATETIMETOPRIGHT.Name = "DATETIMETOPRIGHT";
                    DATETIMETOPRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMETOPRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMETOPRIGHT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMETOPRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMETOPRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMETOPRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMETOPRIGHT.TextFont.Name = "Courier New";
                    DATETIMETOPRIGHT.TextFont.Size = 8;
                    DATETIMETOPRIGHT.Value = @"";

                    DATETIMEBOTTOMLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 61, 104, 67, false);
                    DATETIMEBOTTOMLEFT.Name = "DATETIMEBOTTOMLEFT";
                    DATETIMEBOTTOMLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMEBOTTOMLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMEBOTTOMLEFT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMEBOTTOMLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMLEFT.TextFont.Name = "Courier New";
                    DATETIMEBOTTOMLEFT.TextFont.Size = 8;
                    DATETIMEBOTTOMLEFT.Value = @"";

                    DATETIMEBOTTOMRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 61, 199, 67, false);
                    DATETIMEBOTTOMRIGHT.Name = "DATETIMEBOTTOMRIGHT";
                    DATETIMEBOTTOMRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMEBOTTOMRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMEBOTTOMRIGHT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMEBOTTOMRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMRIGHT.TextFont.Name = "Courier New";
                    DATETIMEBOTTOMRIGHT.TextFont.Size = 8;
                    DATETIMEBOTTOMRIGHT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121111.CalcValue = NewField1121111.Value;
                    NewField11111211.CalcValue = NewField11111211.Value;
                    DESCRIPTIONTOPLEFT.CalcValue = @"";
                    DESCRIPTIONTOPRIGHT.CalcValue = @"";
                    NewField111211111.CalcValue = NewField111211111.Value;
                    NewField1111112111.CalcValue = NewField1111112111.Value;
                    DESCRIPTIONBOTTOMLEFT.CalcValue = @"";
                    DESCRIPTIONBOTTOMRIGHT.CalcValue = @"";
                    DATETIMETOPLEFT.CalcValue = @"";
                    DATETIMETOPRIGHT.CalcValue = @"";
                    DATETIMEBOTTOMLEFT.CalcValue = @"";
                    DATETIMEBOTTOMRIGHT.CalcValue = @"";
                    return new TTReportObject[] { NewField1121111,NewField11111211,DESCRIPTIONTOPLEFT,DESCRIPTIONTOPRIGHT,NewField111211111,NewField1111112111,DESCRIPTIONBOTTOMLEFT,DESCRIPTIONBOTTOMRIGHT,DATETIMETOPLEFT,DATETIMETOPRIGHT,DATETIMEBOTTOMLEFT,DATETIMEBOTTOMRIGHT};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    //            if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
//            {
//                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
//
//                foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
//                {
//                    string signDesc = string.Empty;
//                    string vekil = string.Empty;
//                    signDesc += "Adı Soyadı     :";
//                    if (stockActionSignDetail.SignUser.MilitaryClass != null)
//                        signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
//                    if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
//                        signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
//                    signDesc += stockActionSignDetail.SignUser.Name;
//                    if (stockActionSignDetail.SignUser != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.EmploymentRecordID) == false)
//                        signDesc += "\r\n               (" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
//                    signDesc += "\r\n\r\nİmzası        :";
//                    if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
//                        vekil += " Vek.";
//                    switch (stockActionSignDetail.SignUserType)
//                    {
//                        case SignUserTypeEnum.HesapSorumlusu:
//                            this.DESCRIPTIONTOPLEFT.CalcValue = "Taşınır Mal Hesap Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
//                            this.DATETIMETOPLEFT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
//                            break;
//                        case SignUserTypeEnum.MalSaymani:
//                            this.DESCRIPTIONBOTTOMLEFT.CalcValue = "Taşınır Mal Saymanı" + vekil + "\r\n\r\n" + signDesc;
//                            this.DATETIMEBOTTOMLEFT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
//                            break;
//                        case SignUserTypeEnum.MalSorumlusu:
//                            if(stockAction is DistributionDocument)
//                            {
//                                this.DESCRIPTIONTOPRIGHT.CalcValue = "Teslim Eden Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
//                                this.DATETIMETOPRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
//                            }
//                            else
//                            {
//                                this.DESCRIPTIONBOTTOMRIGHT.CalcValue = "Teslim Alan Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
//                                this.DATETIMEBOTTOMRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
//                            }
//                            break;
//                        case SignUserTypeEnum.DepoSorumlusu:
//                            if(stockAction is DistributionDocument)
//                            {
//                                this.DESCRIPTIONBOTTOMRIGHT.CalcValue = "Teslim Alan Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
//                                this.DATETIMEBOTTOMRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
//                            }
//                            else
//                            {
//                                this.DESCRIPTIONTOPRIGHT.CalcValue = "Teslim Eden Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
//                                this.DATETIMETOPRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
//                            }
//                            break;
//                        default:
//                            break;
//                    }
//                }
//            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public DepDistributionDocumentReport MyParentReport
            {
                get { return (DepDistributionDocumentReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField1311111 { get {return Header().NewField1311111;} }
            public TTReportField NewField1311112 { get {return Header().NewField1311112;} }
            public TTReportField NewField1211111 { get {return Header().NewField1211111;} }
            public TTReportField NewField1311113 { get {return Header().NewField1311113;} }
            public TTReportField DESCRIPTIONTOTAL { get {return Footer().DESCRIPTIONTOTAL;} }
            public TTReportField GROUPCOUNT { get {return Footer().GROUPCOUNT;} }
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
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField111113;
                public TTReportField NewField1311111;
                public TTReportField NewField1311112;
                public TTReportField NewField1211111;
                public TTReportField NewField1311113; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 18;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 17, 18, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"
S. Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 43, 18, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Stok Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 0, 107, 18, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Taşınır Malın Cins, Özellikleri";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 130, 18, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.Value = @"
Ölçü
Birimi";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 147, 18, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111113.TextFont.Size = 8;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.Value = @"
İstenen/İade
Edilecek
Miktar";

                    NewField1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 181, 18, false);
                    NewField1311111.Name = "NewField1311111";
                    NewField1311111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311111.TextFont.Bold = true;
                    NewField1311111.Value = @"
Birim Fiyatı";

                    NewField1311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 200, 18, false);
                    NewField1311112.Name = "NewField1311112";
                    NewField1311112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112.TextFont.Bold = true;
                    NewField1311112.Value = @"Açıklamalar";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 119, 18, false);
                    NewField1211111.Name = "NewField1211111";
                    NewField1211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211111.TextFont.Size = 8;
                    NewField1211111.TextFont.Bold = true;
                    NewField1211111.Value = @"
Taşınır
Malın
Durumu";

                    NewField1311113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 0, 164, 18, false);
                    NewField1311113.Name = "NewField1311113";
                    NewField1311113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311113.TextFont.Size = 8;
                    NewField1311113.TextFont.Bold = true;
                    NewField1311113.Value = @"
Alınan/
Verilen
Miktar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1311111.CalcValue = NewField1311111.Value;
                    NewField1311112.CalcValue = NewField1311112.Value;
                    NewField1211111.CalcValue = NewField1211111.Value;
                    NewField1311113.CalcValue = NewField1311113.Value;
                    return new TTReportObject[] { NewField1111,NewField11111,NewField111111,NewField111112,NewField111113,NewField1311111,NewField1311112,NewField1211111,NewField1311113};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTIONTOTAL;
                public TTReportField GROUPCOUNT; 
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

                    GROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 1, 207, 6, false);
                    GROUPCOUNT.Name = "GROUPCOUNT";
                    GROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    GROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUPCOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    GROUPCOUNT.TextFont.Size = 10;
                    GROUPCOUNT.TextFont.CharSet = 1;
                    GROUPCOUNT.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTIONTOTAL.CalcValue = @"";
                    GROUPCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { DESCRIPTIONTOTAL,GROUPCOUNT};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string closer = "/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";
                        DESCRIPTIONTOTAL.CalcValue = closer + "Yalnız " + GROUPCOUNT.CalcValue + "(" + TTReportTool.Common.SpellNumber(GROUPCOUNT.CalcValue) + ") kalemdir." + closer;
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DepDistributionDocumentReport MyParentReport
            {
                get { return (DepDistributionDocumentReport)ParentReport; }
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
            public TTReportField STOCKLEVELTYPE { get {return Body().STOCKLEVELTYPE;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField ISTENENIADEEDILECEKMIKTAR { get {return Body().ISTENENIADEEDILECEKMIKTAR;} }
            public TTReportField DPRICE { get {return Body().DPRICE;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionInDetailsReportQuery_Class>("StockActionInDetailsReportQuery", StockAction.StockActionInDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DepDistributionDocumentReport MyParentReport
                {
                    get { return (DepDistributionDocumentReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField STOCKLEVELTYPE;
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField DESCRIPTION;
                public TTReportField ISTENENIADEEDILECEKMIKTAR;
                public TTReportField DPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 17, 5, false);
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

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 43, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 0, 107, 5, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 9;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 130, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 0, 164, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"";

                    STOCKLEVELTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 119, 5, false);
                    STOCKLEVELTYPE.Name = "STOCKLEVELTYPE";
                    STOCKLEVELTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKLEVELTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKLEVELTYPE.TextFont.Size = 8;
                    STOCKLEVELTYPE.Value = @"{#STOCKLEVELTYPE#}";

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 244, 6, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.VertAlign = VerticalAlignmentEnum.vaTop;
                    STOCKACTIONDETAILOBJECTID.TextFont.Size = 10;
                    STOCKACTIONDETAILOBJECTID.TextFont.CharSet = 1;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 200, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.Value = @"";

                    ISTENENIADEEDILECEKMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 147, 5, false);
                    ISTENENIADEEDILECEKMIKTAR.Name = "ISTENENIADEEDILECEKMIKTAR";
                    ISTENENIADEEDILECEKMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ISTENENIADEEDILECEKMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTENENIADEEDILECEKMIKTAR.TextFormat = @"#,##0.00";
                    ISTENENIADEEDILECEKMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISTENENIADEEDILECEKMIKTAR.TextFont.Size = 9;
                    ISTENENIADEEDILECEKMIKTAR.Value = @"{#AMOUNT#}";

                    DPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 181, 5, false);
                    DPRICE.Name = "DPRICE";
                    DPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    DPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DPRICE.TextFormat = @"#,###.######";
                    DPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DPRICE.ObjectDefName = "StockActionDetailIn";
                    DPRICE.DataMember = "UnitPrice";
                    DPRICE.TextFont.Size = 9;
                    DPRICE.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionInDetailsReportQuery_Class dataset_StockActionInDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionInDetailsReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    NATOSTOCKNO.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.NATOStockNO) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Materialname) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.DistributionType) : "");
                    AMOUNT.CalcValue = @"";
                    STOCKLEVELTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Stockleveltype) : "");
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Stockactiondetailobjectid) : "");
                    DESCRIPTION.CalcValue = @"";
                    ISTENENIADEEDILECEKMIKTAR.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Amount) : "");
                    DPRICE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Stockactiondetailobjectid) : "");
                    DPRICE.PostFieldValueCalculation();
                    return new TTReportObject[] { ORDERNO,NATOSTOCKNO,MATERIALDESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,STOCKLEVELTYPE,STOCKACTIONDETAILOBJECTID,DESCRIPTION,ISTENENIADEEDILECEKMIKTAR,DPRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                DistributionDepStoreMat distributionDepStoreMat = (DistributionDepStoreMat)MyParentReport.ReportObjectContext.GetObject(new Guid(STOCKACTIONDETAILOBJECTID.CalcValue), typeof(DistributionDepStoreMat));
                AMOUNT.CalcValue = distributionDepStoreMat.AcceptedAmount.ToString();
                //  if (stockAction is DistributionDocument)
                //{
                //                    DPRICE.Visible = EvetHayirEnum.ehEvet;
                //                }
                //                if (stockAction is ReturningDocument)
                //                {
                //                    IPRICE.Visible = EvetHayirEnum.ehEvet;
                //                }
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

        public DepDistributionDocumentReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DEPDISTRIBUTIONDOCUMENTREPORT";
            Caption = "Bağlı Birlik Dağıtım / İade Belgesi";
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