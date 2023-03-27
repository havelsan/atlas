
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
    public partial class ChattelDocumentConflictReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public ChattelDocumentConflictReport MyParentReport
            {
                get { return (ChattelDocumentConflictReport)ParentReport; }
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
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
                }
                
                public TTReportField NewField11; 
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
                    NewField11.Value = @"UYUŞMAZLIK TESPİT TUTANAĞI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
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
                    
                    NewField11111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 130, 27, false);
                    NewField11111211.Name = "NewField11111211";
                    NewField11111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111211.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField11111211.TextFont.Bold = true;
                    NewField11111211.Value = @"Hazırlayanların Kimlik ve İmzası";

                    NewField111211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 200, 27, false);
                    NewField111211111.Name = "NewField111211111";
                    NewField111211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField111211111.TextFont.Bold = true;
                    NewField111211111.Value = @"Taşınır Mal Saymanının Onayı";

                    DESCRIPTIONBOTTOMLEFT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 128, 23, false);
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

                    DESCRIPTIONBOTTOMRIGHT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 7, 199, 25, false);
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
                        ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy = (ChattelDocumentInputWithAccountancy)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ChattelDocumentInputWithAccountancy));

                        string message = string.Empty;
                        message = "Adı Soyadı : .....................................................\r\n\r\n";
                        message += "Ünvanı     : ....................................................\r\n\r\n";
                        message += "İmzası     : .....................................................";
                        DESCRIPTIONBOTTOMLEFT.CalcValue = message;

                        MainStoreDefinition mainStore = (MainStoreDefinition)chattelDocumentInputWithAccountancy.Store;
                        if (mainStore.GoodsAccountant != null)
                        {
                            message = "Adı Soyadı : " + mainStore.GoodsAccountant.Name + "\r\n";
                            message += "Ünvanı     : ";
                            if (mainStore.GoodsAccountant.MilitaryClass != null)
                                message += mainStore.GoodsAccountant.MilitaryClass.ShortName;
                            if (mainStore.GoodsAccountant.Rank != null && string.IsNullOrEmpty(mainStore.GoodsAccountant.Rank.ShortName) == false)
                                message += mainStore.GoodsAccountant.Rank.ShortName;
                            if (string.IsNullOrEmpty(mainStore.GoodsAccountant.EmploymentRecordID) == false)
                                message += "(" + mainStore.GoodsAccountant.EmploymentRecordID + ")\r\n";
                            message += "İmzası     : ";
                        }
                        else
                        {
                            message = "Adı Soyadı : .............................\r\n\r\n";
                            message += "Ünvanı     : ............................\r\n\r\n";
                            message += "İmzası     : ............................";
                        }
                        DESCRIPTIONBOTTOMRIGHT.CalcValue = message;
                    }
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public ChattelDocumentConflictReport MyParentReport
            {
                get { return (ChattelDocumentConflictReport)ParentReport; }
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
            public TTReportField DUZENLEMETARIHI { get {return Header().DUZENLEMETARIHI;} }
            public TTReportField NewField1321111 { get {return Header().NewField1321111;} }
            public TTReportField ALANBIRLIK { get {return Header().ALANBIRLIK;} }
            public TTReportField NewField1321112 { get {return Header().NewField1321112;} }
            public TTReportField GONDERENBIRLIK { get {return Header().GONDERENBIRLIK;} }
            public TTReportField NewField1321113 { get {return Header().NewField1321113;} }
            public TTReportField GONDERENINTASINIRISLEMBELGESI { get {return Header().GONDERENINTASINIRISLEMBELGESI;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
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
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
                }
                
                public TTReportField NewField111123;
                public TTReportField DUZENLEMETARIHI;
                public TTReportField NewField1321111;
                public TTReportField ALANBIRLIK;
                public TTReportField NewField1321112;
                public TTReportField GONDERENBIRLIK;
                public TTReportField NewField1321113;
                public TTReportField GONDERENINTASINIRISLEMBELGESI; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 32;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 61, 8, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.TextFont.Bold = true;
                    NewField111123.Value = @"Düzenleme Tarihi";

                    DUZENLEMETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 0, 200, 8, false);
                    DUZENLEMETARIHI.Name = "DUZENLEMETARIHI";
                    DUZENLEMETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    DUZENLEMETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUZENLEMETARIHI.ObjectDefName = "StockAction";
                    DUZENLEMETARIHI.DataMember = "TRANSACTIONDATE";
                    DUZENLEMETARIHI.TextFont.Name = "Arial";
                    DUZENLEMETARIHI.Value = @"{@TTOBJECTID@}  ";

                    NewField1321111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 61, 16, false);
                    NewField1321111.Name = "NewField1321111";
                    NewField1321111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321111.TextFont.Bold = true;
                    NewField1321111.Value = @"Alan Birlik";

                    ALANBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 8, 200, 16, false);
                    ALANBIRLIK.Name = "ALANBIRLIK";
                    ALANBIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    ALANBIRLIK.TextFont.Name = "Arial";
                    ALANBIRLIK.Value = @"ALANBIRLIK";

                    NewField1321112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 61, 24, false);
                    NewField1321112.Name = "NewField1321112";
                    NewField1321112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321112.TextFont.Bold = true;
                    NewField1321112.Value = @"Gönderen Birlik";

                    GONDERENBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 16, 200, 24, false);
                    GONDERENBIRLIK.Name = "GONDERENBIRLIK";
                    GONDERENBIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERENBIRLIK.TextFont.Name = "Arial";
                    GONDERENBIRLIK.Value = @"GONDERENBIRLIK";

                    NewField1321113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 94, 32, false);
                    NewField1321113.Name = "NewField1321113";
                    NewField1321113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321113.TextFont.Bold = true;
                    NewField1321113.Value = @"Gönderenin Taşınır İşlem Belge Nu.ve Tarihi";

                    GONDERENINTASINIRISLEMBELGESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 24, 200, 32, false);
                    GONDERENINTASINIRISLEMBELGESI.Name = "GONDERENINTASINIRISLEMBELGESI";
                    GONDERENINTASINIRISLEMBELGESI.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERENINTASINIRISLEMBELGESI.TextFont.Name = "Arial";
                    GONDERENINTASINIRISLEMBELGESI.Value = @"GONDERENINTASINIRISLEMBELGESI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111123.CalcValue = NewField111123.Value;
                    DUZENLEMETARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DUZENLEMETARIHI.PostFieldValueCalculation();
                    NewField1321111.CalcValue = NewField1321111.Value;
                    ALANBIRLIK.CalcValue = ALANBIRLIK.Value;
                    NewField1321112.CalcValue = NewField1321112.Value;
                    GONDERENBIRLIK.CalcValue = GONDERENBIRLIK.Value;
                    NewField1321113.CalcValue = NewField1321113.Value;
                    GONDERENINTASINIRISLEMBELGESI.CalcValue = GONDERENINTASINIRISLEMBELGESI.Value;
                    return new TTReportObject[] { NewField111123,DUZENLEMETARIHI,NewField1321111,ALANBIRLIK,NewField1321112,GONDERENBIRLIK,NewField1321113,GONDERENINTASINIRISLEMBELGESI};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy = (ChattelDocumentInputWithAccountancy)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ChattelDocumentInputWithAccountancy));
                        GONDERENINTASINIRISLEMBELGESI.CalcValue = chattelDocumentInputWithAccountancy.BaseDateTime.Value.ToString("dd.MM.yyyy") + " / " + chattelDocumentInputWithAccountancy.BaseNumber;
                        ALANBIRLIK.CalcValue = chattelDocumentInputWithAccountancy.Accountancy.AccountancyNO + " " + chattelDocumentInputWithAccountancy.Accountancy.Name;
                        GONDERENBIRLIK.CalcValue = chattelDocumentInputWithAccountancy.AccountingTerm.Accountancy.AccountancyNO + " " + chattelDocumentInputWithAccountancy.AccountingTerm.Accountancy.Name;
                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField DESCRIPTION; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 54;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 200, 54, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Açıklamalar";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 192, 53, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FillStyle = FillStyleConstants.vbFSTransparent;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ObjectDefName = "ChattelDocumentInputWithAccountancy";
                    DESCRIPTION.DataMember = "DESCRIPTION";
                    DESCRIPTION.TextFont.Name = "Courier New";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    DESCRIPTION.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DESCRIPTION.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1111,DESCRIPTION};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ChattelDocumentConflictReport MyParentReport
            {
                get { return (ChattelDocumentConflictReport)ParentReport; }
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
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField1311111 { get {return Header().NewField1311111;} }
            public TTReportField NewField1311112 { get {return Header().NewField1311112;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
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
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField111113;
                public TTReportField NewField1311111;
                public TTReportField NewField1311112;
                public TTReportField NewField1112;
                public TTReportField NewField1311113; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 135, 9, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Belge Üzerindeki Bilgiler";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 29, 27, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"
Stok Numarası";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 9, 85, 27, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Cins ve Özellikleri";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 9, 100, 27, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.Value = @"
Ölçü
Birimi";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 9, 119, 27, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.Value = @"
Gönderilen Miktar";

                    NewField1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 9, 154, 27, false);
                    NewField1311111.Name = "NewField1311111";
                    NewField1311111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311111.TextFont.Bold = true;
                    NewField1311111.Value = @"
Uyuşmazlık Miktarı";

                    NewField1311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 9, 200, 27, false);
                    NewField1311112.Name = "NewField1311112";
                    NewField1311112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112.TextFont.Bold = true;
                    NewField1311112.Value = @"Uyuşmazlık Konusu";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 200, 9, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.Value = @"Uyuşmazlıklar";

                    NewField1311113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 9, 135, 27, false);
                    NewField1311113.Name = "NewField1311113";
                    NewField1311113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1311113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311113.TextFont.Bold = true;
                    NewField1311113.Value = @"
Alınan Miktar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1311111.CalcValue = NewField1311111.Value;
                    NewField1311112.CalcValue = NewField1311112.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1311113.CalcValue = NewField1311113.Value;
                    return new TTReportObject[] { NewField111,NewField11111,NewField111111,NewField111112,NewField111113,NewField1311111,NewField1311112,NewField1112,NewField1311113};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
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

                    GROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 239, 5, false);
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
                    string groupCount = GROUPCOUNT.CalcValue;
                    if (string.IsNullOrEmpty(groupCount) == false)
                    {
                        string closer = "/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";
                        DESCRIPTIONTOTAL.CalcValue = closer + "Yalnız " + groupCount + "(" + TTReportTool.Common.SpellNumber(groupCount) + ") kalemdir." + closer;
                    }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ChattelDocumentConflictReport MyParentReport
            {
                get { return (ChattelDocumentConflictReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine122 { get {return Body().NewLine122;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField SENTAMOUNT { get {return Body().SENTAMOUNT;} }
            public TTReportField CONFLICTAMOUNT { get {return Body().CONFLICTAMOUNT;} }
            public TTReportField CONFLICTSUBJECT { get {return Body().CONFLICTSUBJECT;} }
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
                list[0] = new TTReportNqlData<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class>("InputDetailsWithAccountancyRQ", ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ChattelDocumentConflictReport MyParentReport
                {
                    get { return (ChattelDocumentConflictReport)ParentReport; }
                }
                
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField SENTAMOUNT;
                public TTReportField CONFLICTAMOUNT;
                public TTReportField CONFLICTSUBJECT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 5, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extPageHeight;

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 29, 14, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.TextFont.Size = 9;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 85, 14, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 9;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 100, 14, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 135, 14, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    SENTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 119, 14, false);
                    SENTAMOUNT.Name = "SENTAMOUNT";
                    SENTAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    SENTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENTAMOUNT.TextFormat = @"#,##0.00";
                    SENTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SENTAMOUNT.TextFont.Size = 9;
                    SENTAMOUNT.Value = @"{#SENTAMOUNT#}";

                    CONFLICTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 154, 14, false);
                    CONFLICTAMOUNT.Name = "CONFLICTAMOUNT";
                    CONFLICTAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CONFLICTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFLICTAMOUNT.TextFormat = @"#,##0.00";
                    CONFLICTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONFLICTAMOUNT.TextFont.Size = 9;
                    CONFLICTAMOUNT.Value = @"{#CONFLICTAMOUNT#}";

                    CONFLICTSUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 200, 14, false);
                    CONFLICTSUBJECT.Name = "CONFLICTSUBJECT";
                    CONFLICTSUBJECT.DrawStyle = DrawStyleConstants.vbSolid;
                    CONFLICTSUBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFLICTSUBJECT.VertAlign = VerticalAlignmentEnum.vaTop;
                    CONFLICTSUBJECT.MultiLine = EvetHayirEnum.ehEvet;
                    CONFLICTSUBJECT.WordBreak = EvetHayirEnum.ehEvet;
                    CONFLICTSUBJECT.TextFont.Size = 8;
                    CONFLICTSUBJECT.Value = @"{#CONFLICTSUBJECT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class dataset_InputDetailsWithAccountancyRQ = ParentGroup.rsGroup.GetCurrentRecord<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.NATOStockNO) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.Materialname) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.Amount) : "");
                    SENTAMOUNT.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.SentAmount) : "");
                    CONFLICTAMOUNT.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.Conflictamount) : "");
                    CONFLICTSUBJECT.CalcValue = (dataset_InputDetailsWithAccountancyRQ != null ? Globals.ToStringCore(dataset_InputDetailsWithAccountancyRQ.ConflictSubject) : "");
                    return new TTReportObject[] { NATOSTOCKNO,MATERIALDESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,SENTAMOUNT,CONFLICTAMOUNT,CONFLICTSUBJECT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ChattelDocumentConflictReport()
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
            Name = "CHATTELDOCUMENTCONFLICTREPORT";
            Caption = "Uyuşmazlık Tespit Tutanağı";
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