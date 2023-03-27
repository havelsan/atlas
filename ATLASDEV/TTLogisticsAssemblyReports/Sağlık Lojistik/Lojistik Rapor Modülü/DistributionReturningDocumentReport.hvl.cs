
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
    public partial class DistributionReturningDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public DistributionReturningDocumentReport MyParentReport
            {
                get { return (DistributionReturningDocumentReport)ParentReport; }
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
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
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
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
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
            public DistributionReturningDocumentReport MyParentReport
            {
                get { return (DistributionReturningDocumentReport)ParentReport; }
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
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
            public TTReportField NewField11111212 { get {return Footer().NewField11111212;} }
            public TTReportField NewField121211111 { get {return Footer().NewField121211111;} }
            public TTReportField TEXTMKYSTESLIM { get {return Footer().TEXTMKYSTESLIM;} }
            public TTReportField TEXTMKYSTESLIM1 { get {return Footer().TEXTMKYSTESLIM1;} }
            public TTReportField MKYSTESLIMALAN { get {return Footer().MKYSTESLIMALAN;} }
            public TTReportField MKYSTESLIMEDEN { get {return Footer().MKYSTESLIMEDEN;} }
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
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
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
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 200, 9, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.TextFont.Bold = true;
                    NewField111123.Value = @"Belge Nu. :";

                    NewField1321115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 111, 13, false);
                    NewField1321115.Name = "NewField1321115";
                    NewField1321115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321115.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1321115.TextFont.Bold = true;
                    NewField1321115.Value = @"Taşınır Mal Saymanlığı";

                    NewField1321111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 9, 200, 18, false);
                    NewField1321111.Name = "NewField1321111";
                    NewField1321111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321111.TextFont.Bold = true;
                    NewField1321111.Value = @"İşlemin Cinsi :";

                    NewField1321112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 18, 200, 26, false);
                    NewField1321112.Name = "NewField1321112";
                    NewField1321112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321112.TextFont.Bold = true;
                    NewField1321112.Value = @"Emir Tarih ve Sayısı :";

                    NewField15111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 111, 26, false);
                    NewField15111231.Name = "NewField15111231";
                    NewField15111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15111231.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField15111231.TextFont.Bold = true;
                    NewField15111231.Value = @"Birlik";

                    TASINIRMALSAYMANLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 107, 13, false);
                    TASINIRMALSAYMANLIGI.Name = "TASINIRMALSAYMANLIGI";
                    TASINIRMALSAYMANLIGI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TASINIRMALSAYMANLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TASINIRMALSAYMANLIGI.VertAlign = VerticalAlignmentEnum.vaTop;
                    TASINIRMALSAYMANLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    TASINIRMALSAYMANLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    TASINIRMALSAYMANLIGI.TextFont.Size = 10;
                    TASINIRMALSAYMANLIGI.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 105, 26, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaTop;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Size = 10;
                    BIRLIK.Value = @"";

                    BELGENUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 1, 200, 8, false);
                    BELGENUMARASI.Name = "BELGENUMARASI";
                    BELGENUMARASI.FillStyle = FillStyleConstants.vbFSTransparent;
                    BELGENUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELGENUMARASI.TextFont.Size = 10;
                    BELGENUMARASI.Value = @"";

                    EMIRTARIHSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 19, 199, 26, false);
                    EMIRTARIHSAYISI.Name = "EMIRTARIHSAYISI";
                    EMIRTARIHSAYISI.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRTARIHSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHSAYISI.TextFont.Size = 10;
                    EMIRTARIHSAYISI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 11, 152, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Size = 10;
                    NewField1.Value = @"Dağıtım";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 11, 163, 16, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField2.TextFont.Size = 10;
                    NewField2.Value = @"İade";

                    DAGITIMMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 11, 152, 16, false);
                    DAGITIMMI.Name = "DAGITIMMI";
                    DAGITIMMI.DrawStyle = DrawStyleConstants.vbSolid;
                    DAGITIMMI.FillStyle = FillStyleConstants.vbFSTransparent;
                    DAGITIMMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIMMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAGITIMMI.TextFont.Size = 10;
                    DAGITIMMI.Value = @"";

                    IADEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 11, 169, 16, false);
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
                        if (stockAction is DistributionDocument)
                        {
                            DistributionDocument distributionDocument = (DistributionDocument)stockAction;
                            TASINIRMALSAYMANLIGI.CalcValue = ((MainStoreDefinition)distributionDocument.Store).Accountancy.Name;
                            BIRLIK.CalcValue = stockAction.DestinationStore.Name;
                            DAGITIMMI.CalcValue = "X";
                        }
                        if (stockAction is ReturningDocument)
                        {
                            ReturningDocument returningDocument = (ReturningDocument)stockAction;
                            TASINIRMALSAYMANLIGI.CalcValue = ((MainStoreDefinition)returningDocument.DestinationStore).Accountancy.Name;
                            BIRLIK.CalcValue = stockAction.Store.Name;
                            IADEMI.CalcValue = "X";
                        }
                        EMIRTARIHSAYISI.CalcValue = stockAction.TransactionDate.Value.ToShortDateString() + " / " + stockAction.StockActionID.Value.Value;
                        BELGENUMARASI.CalcValue = stockAction.StockActionID.ToString();
                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
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
                public TTReportField DESCRIPTION;
                public TTReportField NewField11111212;
                public TTReportField NewField121211111;
                public TTReportField TEXTMKYSTESLIM;
                public TTReportField TEXTMKYSTESLIM1;
                public TTReportField MKYSTESLIMALAN;
                public TTReportField MKYSTESLIMEDEN; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 32;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 5, 312, 39, false);
                    NewField1121111.Name = "NewField1121111";
                    NewField1121111.Visible = EvetHayirEnum.ehHayir;
                    NewField1121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121111.TextFont.Bold = true;
                    NewField1121111.Value = @"";

                    NewField11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 5, 407, 39, false);
                    NewField11111211.Name = "NewField11111211";
                    NewField11111211.Visible = EvetHayirEnum.ehHayir;
                    NewField11111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111211.TextFont.Bold = true;
                    NewField11111211.Value = @"";

                    DESCRIPTIONTOPLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 6, 311, 30, false);
                    DESCRIPTIONTOPLEFT.Name = "DESCRIPTIONTOPLEFT";
                    DESCRIPTIONTOPLEFT.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTIONTOPLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONTOPLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOPLEFT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONTOPLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPLEFT.TextFont.Name = "Courier New";
                    DESCRIPTIONTOPLEFT.TextFont.Size = 8;
                    DESCRIPTIONTOPLEFT.Value = @"";

                    DESCRIPTIONTOPRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 6, 406, 30, false);
                    DESCRIPTIONTOPRIGHT.Name = "DESCRIPTIONTOPRIGHT";
                    DESCRIPTIONTOPRIGHT.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTIONTOPRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONTOPRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOPRIGHT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONTOPRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOPRIGHT.TextFont.Name = "Courier New";
                    DESCRIPTIONTOPRIGHT.TextFont.Size = 8;
                    DESCRIPTIONTOPRIGHT.Value = @"";

                    NewField111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 39, 312, 69, false);
                    NewField111211111.Name = "NewField111211111";
                    NewField111211111.Visible = EvetHayirEnum.ehHayir;
                    NewField111211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211111.TextFont.Bold = true;
                    NewField111211111.Value = @"";

                    NewField1111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 39, 407, 69, false);
                    NewField1111112111.Name = "NewField1111112111";
                    NewField1111112111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112111.TextFont.Bold = true;
                    NewField1111112111.Value = @"";

                    DESCRIPTIONBOTTOMLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 40, 311, 56, false);
                    DESCRIPTIONBOTTOMLEFT.Name = "DESCRIPTIONBOTTOMLEFT";
                    DESCRIPTIONBOTTOMLEFT.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTIONBOTTOMLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONBOTTOMLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONBOTTOMLEFT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONBOTTOMLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMLEFT.TextFont.Name = "Courier New";
                    DESCRIPTIONBOTTOMLEFT.TextFont.Size = 8;
                    DESCRIPTIONBOTTOMLEFT.Value = @"";

                    DESCRIPTIONBOTTOMRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 40, 406, 56, false);
                    DESCRIPTIONBOTTOMRIGHT.Name = "DESCRIPTIONBOTTOMRIGHT";
                    DESCRIPTIONBOTTOMRIGHT.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTIONBOTTOMRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTIONBOTTOMRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONBOTTOMRIGHT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONBOTTOMRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTIONBOTTOMRIGHT.TextFont.Name = "Courier New";
                    DESCRIPTIONBOTTOMRIGHT.TextFont.Size = 8;
                    DESCRIPTIONBOTTOMRIGHT.Value = @"";

                    DATETIMETOPLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 32, 311, 38, false);
                    DATETIMETOPLEFT.Name = "DATETIMETOPLEFT";
                    DATETIMETOPLEFT.Visible = EvetHayirEnum.ehHayir;
                    DATETIMETOPLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMETOPLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMETOPLEFT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMETOPLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMETOPLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMETOPLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMETOPLEFT.TextFont.Name = "Courier New";
                    DATETIMETOPLEFT.TextFont.Size = 8;
                    DATETIMETOPLEFT.Value = @"";

                    DATETIMETOPRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 32, 406, 38, false);
                    DATETIMETOPRIGHT.Name = "DATETIMETOPRIGHT";
                    DATETIMETOPRIGHT.Visible = EvetHayirEnum.ehHayir;
                    DATETIMETOPRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMETOPRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMETOPRIGHT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMETOPRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMETOPRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMETOPRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMETOPRIGHT.TextFont.Name = "Courier New";
                    DATETIMETOPRIGHT.TextFont.Size = 8;
                    DATETIMETOPRIGHT.Value = @"";

                    DATETIMEBOTTOMLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 58, 311, 64, false);
                    DATETIMEBOTTOMLEFT.Name = "DATETIMEBOTTOMLEFT";
                    DATETIMEBOTTOMLEFT.Visible = EvetHayirEnum.ehHayir;
                    DATETIMEBOTTOMLEFT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMEBOTTOMLEFT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMEBOTTOMLEFT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMEBOTTOMLEFT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMLEFT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMLEFT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMLEFT.TextFont.Name = "Courier New";
                    DATETIMEBOTTOMLEFT.TextFont.Size = 8;
                    DATETIMEBOTTOMLEFT.Value = @"";

                    DATETIMEBOTTOMRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 58, 406, 64, false);
                    DATETIMEBOTTOMRIGHT.Name = "DATETIMEBOTTOMRIGHT";
                    DATETIMEBOTTOMRIGHT.Visible = EvetHayirEnum.ehHayir;
                    DATETIMEBOTTOMRIGHT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DATETIMEBOTTOMRIGHT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMEBOTTOMRIGHT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATETIMEBOTTOMRIGHT.MultiLine = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMRIGHT.WordBreak = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMRIGHT.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATETIMEBOTTOMRIGHT.TextFont.Name = "Courier New";
                    DATETIMEBOTTOMRIGHT.TextFont.Size = 8;
                    DATETIMEBOTTOMRIGHT.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 200, 12, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 10;
                    DESCRIPTION.TextFont.CharSet = 1;
                    DESCRIPTION.Value = @"";

                    NewField11111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 105, 30, false);
                    NewField11111212.Name = "NewField11111212";
                    NewField11111212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111212.TextFont.Bold = true;
                    NewField11111212.Value = @"";

                    NewField121211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 12, 200, 30, false);
                    NewField121211111.Name = "NewField121211111";
                    NewField121211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121211111.TextFont.Bold = true;
                    NewField121211111.Value = @"";

                    TEXTMKYSTESLIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 47, 19, false);
                    TEXTMKYSTESLIM.Name = "TEXTMKYSTESLIM";
                    TEXTMKYSTESLIM.FillStyle = FillStyleConstants.vbFSTransparent;
                    TEXTMKYSTESLIM.VertAlign = VerticalAlignmentEnum.vaTop;
                    TEXTMKYSTESLIM.MultiLine = EvetHayirEnum.ehEvet;
                    TEXTMKYSTESLIM.WordBreak = EvetHayirEnum.ehEvet;
                    TEXTMKYSTESLIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXTMKYSTESLIM.TextFont.Name = "Courier New";
                    TEXTMKYSTESLIM.TextFont.Size = 8;
                    TEXTMKYSTESLIM.Value = @"TESLİM ALAN";

                    TEXTMKYSTESLIM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 13, 142, 19, false);
                    TEXTMKYSTESLIM1.Name = "TEXTMKYSTESLIM1";
                    TEXTMKYSTESLIM1.FillStyle = FillStyleConstants.vbFSTransparent;
                    TEXTMKYSTESLIM1.VertAlign = VerticalAlignmentEnum.vaTop;
                    TEXTMKYSTESLIM1.MultiLine = EvetHayirEnum.ehEvet;
                    TEXTMKYSTESLIM1.WordBreak = EvetHayirEnum.ehEvet;
                    TEXTMKYSTESLIM1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TEXTMKYSTESLIM1.TextFont.Name = "Courier New";
                    TEXTMKYSTESLIM1.TextFont.Size = 8;
                    TEXTMKYSTESLIM1.Value = @"TESLİM EDEN";

                    MKYSTESLIMALAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 18, 98, 26, false);
                    MKYSTESLIMALAN.Name = "MKYSTESLIMALAN";
                    MKYSTESLIMALAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MKYSTESLIMALAN.VertAlign = VerticalAlignmentEnum.vaTop;
                    MKYSTESLIMALAN.MultiLine = EvetHayirEnum.ehEvet;
                    MKYSTESLIMALAN.WordBreak = EvetHayirEnum.ehEvet;
                    MKYSTESLIMALAN.TextFont.Size = 10;
                    MKYSTESLIMALAN.TextFont.CharSet = 1;
                    MKYSTESLIMALAN.Value = @"";

                    MKYSTESLIMEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 17, 192, 25, false);
                    MKYSTESLIMEDEN.Name = "MKYSTESLIMEDEN";
                    MKYSTESLIMEDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MKYSTESLIMEDEN.VertAlign = VerticalAlignmentEnum.vaTop;
                    MKYSTESLIMEDEN.MultiLine = EvetHayirEnum.ehEvet;
                    MKYSTESLIMEDEN.WordBreak = EvetHayirEnum.ehEvet;
                    MKYSTESLIMEDEN.TextFont.Size = 10;
                    MKYSTESLIMEDEN.TextFont.CharSet = 1;
                    MKYSTESLIMEDEN.Value = @"";

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
                    DESCRIPTION.CalcValue = @"";
                    NewField11111212.CalcValue = NewField11111212.Value;
                    NewField121211111.CalcValue = NewField121211111.Value;
                    TEXTMKYSTESLIM.CalcValue = TEXTMKYSTESLIM.Value;
                    TEXTMKYSTESLIM1.CalcValue = TEXTMKYSTESLIM1.Value;
                    MKYSTESLIMALAN.CalcValue = @"";
                    MKYSTESLIMEDEN.CalcValue = @"";
                    return new TTReportObject[] { NewField1121111,NewField11111211,DESCRIPTIONTOPLEFT,DESCRIPTIONTOPRIGHT,NewField111211111,NewField1111112111,DESCRIPTIONBOTTOMLEFT,DESCRIPTIONBOTTOMRIGHT,DATETIMETOPLEFT,DATETIMETOPRIGHT,DATETIMEBOTTOMLEFT,DATETIMEBOTTOMRIGHT,DESCRIPTION,NewField11111212,NewField121211111,TEXTMKYSTESLIM,TEXTMKYSTESLIM1,MKYSTESLIMALAN,MKYSTESLIMEDEN};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                if (stockAction is DistributionDocument)
                {
                    DistributionDocument distributionDocument = (DistributionDocument)stockAction;
                    DESCRIPTION.CalcValue = "Açıklama :" + distributionDocument.Description;
                }
                if (stockAction is ReturningDocument)
                {
                    ReturningDocument returningDocument = (ReturningDocument)stockAction;
                    DESCRIPTION.CalcValue =  "Açıklama :" + returningDocument.Description;
                }
                
                MKYSTESLIMALAN.CalcValue = stockAction.MKYS_TeslimAlan;
                MKYSTESLIMEDEN.CalcValue = stockAction.MKYS_TeslimEden;
                
                foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                {
                    string signDesc = string.Empty;
                    string vekil = string.Empty;
                    signDesc += "Adı Soyadı     :";
                    if (stockActionSignDetail.SignUser.MilitaryClass != null)
                        signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                    if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
                    {
                        if(stockActionSignDetail.SignUser.StaffOfficer.HasValue && (bool)stockActionSignDetail.SignUser.StaffOfficer)
                            signDesc += "Kurmay " + stockActionSignDetail.SignUser.Rank.ShortName;
                        else
                            signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                    }
                    signDesc += stockActionSignDetail.SignUser.Name;
                    if (stockActionSignDetail.SignUser != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.EmploymentRecordID) == false)
                        signDesc += "\r\n               (" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
                    signDesc += "\r\n\r\nİmzası        :";
                    if (stockActionSignDetail.IsDeputy.HasValue && stockActionSignDetail.IsDeputy.Value == true)
                        vekil += " Vek.";
                    switch (stockActionSignDetail.SignUserType)
                    {
                        case SignUserTypeEnum.HesapSorumlusu:
                            this.DESCRIPTIONTOPLEFT.CalcValue = "Taşınır Mal Hesap Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
                            this.DATETIMETOPLEFT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
                            break;
                        case SignUserTypeEnum.MalSaymani:
                            this.DESCRIPTIONBOTTOMLEFT.CalcValue = "Taşınır Mal Saymanı" + vekil + "\r\n\r\n" + signDesc;
                            this.DATETIMEBOTTOMLEFT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
                            break;
                        case SignUserTypeEnum.MalSorumlusu:
                            if(stockAction is DistributionDocument)
                            {
                                this.DESCRIPTIONTOPRIGHT.CalcValue = "Teslim Eden Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
                                this.DATETIMETOPRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
                            }
                            else
                            {
                                this.DESCRIPTIONBOTTOMRIGHT.CalcValue = "Teslim Alan Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
                                this.DATETIMEBOTTOMRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
                            }
                            break;
                        case SignUserTypeEnum.DepoSorumlusu:
                            if(stockAction is DistributionDocument)
                            {
                                this.DESCRIPTIONBOTTOMRIGHT.CalcValue = "Teslim Alan Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
                                this.DATETIMEBOTTOMRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
                            }
                            else
                            {
                                this.DESCRIPTIONTOPRIGHT.CalcValue = "Teslim Eden Birlik Taşınır Mal Sorumlusu" + vekil + "\r\n\r\n" + signDesc;
                                this.DATETIMETOPRIGHT.CalcValue = stockAction.TransactionDate.Value.ToShortDateString();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public DistributionReturningDocumentReport MyParentReport
            {
                get { return (DistributionReturningDocumentReport)ParentReport; }
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
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
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

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 38, 18, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Tşn. No.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 111, 18, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Taşınır Malın Cins, Özellikleri";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 134, 18, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Size = 10;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.Value = @"
Ölçü
Birimi";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 151, 18, false);
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

                    NewField1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 181, 18, false);
                    NewField1311111.Name = "NewField1311111";
                    NewField1311111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311111.TextFont.Size = 10;
                    NewField1311111.TextFont.Bold = true;
                    NewField1311111.Value = @"
Birim 
Fiyatı";

                    NewField1311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 200, 18, false);
                    NewField1311112.Name = "NewField1311112";
                    NewField1311112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112.TextFont.Size = 10;
                    NewField1311112.TextFont.Bold = true;
                    NewField1311112.Value = @"Açıklamalar";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 123, 18, false);
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

                    NewField1311113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 168, 18, false);
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
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTIONTOTAL;
                public TTReportField GROUPCOUNT; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    DESCRIPTIONTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 199, 5, false);
                    DESCRIPTIONTOTAL.Name = "DESCRIPTIONTOTAL";
                    DESCRIPTIONTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTIONTOTAL.TextFont.Name = "Arial";
                    DESCRIPTIONTOTAL.TextFont.Size = 10;
                    DESCRIPTIONTOTAL.Value = @"";

                    GROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 0, 221, 5, false);
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
                    string closer = "////";
            DESCRIPTIONTOTAL.CalcValue = closer + "Yalnız " + GROUPCOUNT.CalcValue + "(" + TTReportTool.Common.SpellNumber(GROUPCOUNT.CalcValue) + ") kalemdir." + closer;
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DistributionReturningDocumentReport MyParentReport
            {
                get { return (DistributionReturningDocumentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField IPRICE { get {return Body().IPRICE;} }
            public TTReportField STOCKLEVELTYPE { get {return Body().STOCKLEVELTYPE;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField ISTENENIADEEDILECEKMIKTAR { get {return Body().ISTENENIADEEDILECEKMIKTAR;} }
            public TTReportField DPRICE { get {return Body().DPRICE;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DistributionReturningDocumentReport MyParentReport
                {
                    get { return (DistributionReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportShape NewLine121;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField IPRICE;
                public TTReportField STOCKLEVELTYPE;
                public TTReportField STOCKACTIONDETAILOBJECTID;
                public TTReportField DESCRIPTION;
                public TTReportField ISTENENIADEEDILECEKMIKTAR;
                public TTReportField DPRICE;
                public TTReportShape NewLine1121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 17, 8, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.Value = @"{@counter@} ";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 38, 8, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 111, 8, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 8;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 134, 8, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 168, 8, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    IPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 181, 8, false);
                    IPRICE.Name = "IPRICE";
                    IPRICE.Visible = EvetHayirEnum.ehHayir;
                    IPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    IPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    IPRICE.TextFormat = @"#,###.######";
                    IPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    IPRICE.ObjectDefName = "StockActionDetailOut";
                    IPRICE.DataMember = "Price";
                    IPRICE.TextFont.Size = 8;
                    IPRICE.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    STOCKLEVELTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 123, 8, false);
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

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 200, 8, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.Value = @"";

                    ISTENENIADEEDILECEKMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 151, 8, false);
                    ISTENENIADEEDILECEKMIKTAR.Name = "ISTENENIADEEDILECEKMIKTAR";
                    ISTENENIADEEDILECEKMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ISTENENIADEEDILECEKMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTENENIADEEDILECEKMIKTAR.TextFormat = @"#,##0.00";
                    ISTENENIADEEDILECEKMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISTENENIADEEDILECEKMIKTAR.TextFont.Size = 8;
                    ISTENENIADEEDILECEKMIKTAR.Value = @"{#AMOUNT#}";

                    DPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 181, 8, false);
                    DPRICE.Name = "DPRICE";
                    DPRICE.Visible = EvetHayirEnum.ehHayir;
                    DPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    DPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DPRICE.TextFormat = @"#,###.######";
                    DPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DPRICE.ObjectDefName = "StockActionDetailOut";
                    DPRICE.DataMember = "UnitPrice";
                    DPRICE.TextFont.Size = 8;
                    DPRICE.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 5, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    NATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    IPRICE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    IPRICE.PostFieldValueCalculation();
                    STOCKLEVELTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockleveltype) : "");
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    DESCRIPTION.CalcValue = @"";
                    ISTENENIADEEDILECEKMIKTAR.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    DPRICE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    DPRICE.PostFieldValueCalculation();
                    return new TTReportObject[] { ORDERNO,NATOSTOCKNO,MATERIALDESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,IPRICE,STOCKLEVELTYPE,STOCKACTIONDETAILOBJECTID,DESCRIPTION,ISTENENIADEEDILECEKMIKTAR,DPRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                if (stockAction is DistributionDocument)
                {
                    DPRICE.Visible = EvetHayirEnum.ehEvet;
                }
                if (stockAction is ReturningDocument)
                {
                    IPRICE.Visible = EvetHayirEnum.ehEvet;
                }
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

        public DistributionReturningDocumentReport()
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
            Name = "DISTRIBUTIONRETURNINGDOCUMENTREPORT";
            Caption = "Dağıtım / İade Belgesi";
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