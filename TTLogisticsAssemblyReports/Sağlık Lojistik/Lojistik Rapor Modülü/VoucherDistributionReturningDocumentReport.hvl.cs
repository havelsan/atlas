
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
    public partial class VoucherDistributionReturningDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public VoucherDistributionReturningDocumentReport MyParentReport
            {
                get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
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
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 16, 200, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"TAŞINIR MAL TESLİM TESELLÜM BELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
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
            public VoucherDistributionReturningDocumentReport MyParentReport
            {
                get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1321115 { get {return Header().NewField1321115;} }
            public TTReportField NewField1321111 { get {return Header().NewField1321111;} }
            public TTReportField NewField15111231 { get {return Header().NewField15111231;} }
            public TTReportField TASINIRMALSAYMANLIGI { get {return Header().TASINIRMALSAYMANLIGI;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField DAGITIMMI { get {return Header().DAGITIMMI;} }
            public TTReportField IADEMI { get {return Header().IADEMI;} }
            public TTReportField NewField1311111 { get {return Footer().NewField1311111;} }
            public TTReportField NewField11111131 { get {return Footer().NewField11111131;} }
            public TTReportField NewField11111132 { get {return Footer().NewField11111132;} }
            public TTReportField NewField123111111 { get {return Footer().NewField123111111;} }
            public TTReportField NewField1111111321 { get {return Footer().NewField1111111321;} }
            public TTReportField NewField11231111111 { get {return Footer().NewField11231111111;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField Deliverer { get {return Footer().Deliverer;} }
            public TTReportField DelivererRank { get {return Footer().DelivererRank;} }
            public TTReportField ReceiverOfGoods { get {return Footer().ReceiverOfGoods;} }
            public TTReportField ReceiverOfGoodsRank { get {return Footer().ReceiverOfGoodsRank;} }
            public TTReportField GROUPCOUNT { get {return Footer().GROUPCOUNT;} }
            public TTReportField DESCRIPTIONTOTAL { get {return Footer().DESCRIPTIONTOTAL;} }
            public TTReportField DelivererUserType { get {return Footer().DelivererUserType;} }
            public TTReportField ReceiverOfGoodsUserType { get {return Footer().ReceiverOfGoodsUserType;} }
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
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField1321115;
                public TTReportField NewField1321111;
                public TTReportField NewField15111231;
                public TTReportField TASINIRMALSAYMANLIGI;
                public TTReportField BIRLIK;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField DAGITIMMI;
                public TTReportField IADEMI; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1321115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 200, 7, false);
                    NewField1321115.Name = "NewField1321115";
                    NewField1321115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321115.TextFont.Bold = true;
                    NewField1321115.Value = @"Taşınır Malın Birliği";

                    NewField1321111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 200, 24, false);
                    NewField1321111.Name = "NewField1321111";
                    NewField1321111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321111.TextFont.Bold = true;
                    NewField1321111.Value = @"İşlemin Cinsi :";

                    NewField15111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 7, 200, 15, false);
                    NewField15111231.Name = "NewField15111231";
                    NewField15111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15111231.TextFont.Bold = true;
                    NewField15111231.Value = @"Teslim Alan Kısım / Birim";

                    TASINIRMALSAYMANLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 200, 7, false);
                    TASINIRMALSAYMANLIGI.Name = "TASINIRMALSAYMANLIGI";
                    TASINIRMALSAYMANLIGI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TASINIRMALSAYMANLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TASINIRMALSAYMANLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    TASINIRMALSAYMANLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    TASINIRMALSAYMANLIGI.TextFont.Size = 10;
                    TASINIRMALSAYMANLIGI.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 8, 200, 15, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Size = 10;
                    BIRLIK.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 17, 56, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Size = 10;
                    NewField1.Value = @"Dağıtım";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 17, 81, 22, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField2.TextFont.Size = 10;
                    NewField2.Value = @"İade";

                    DAGITIMMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 17, 56, 22, false);
                    DAGITIMMI.Name = "DAGITIMMI";
                    DAGITIMMI.DrawStyle = DrawStyleConstants.vbSolid;
                    DAGITIMMI.FillStyle = FillStyleConstants.vbFSTransparent;
                    DAGITIMMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAGITIMMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAGITIMMI.TextFont.Size = 10;
                    DAGITIMMI.Value = @"";

                    IADEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 17, 87, 22, false);
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
                    NewField1321115.CalcValue = NewField1321115.Value;
                    NewField1321111.CalcValue = NewField1321111.Value;
                    NewField15111231.CalcValue = NewField15111231.Value;
                    TASINIRMALSAYMANLIGI.CalcValue = @"";
                    BIRLIK.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    DAGITIMMI.CalcValue = @"";
                    IADEMI.CalcValue = @"";
                    return new TTReportObject[] { NewField1321115,NewField1321111,NewField15111231,TASINIRMALSAYMANLIGI,BIRLIK,NewField1,NewField2,DAGITIMMI,IADEMI};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
                    {
                        StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));
                        //TRANSACTIONDATE.CalcValue = stockAction.TransactionDate.ToString();  
                        if (stockAction is VoucherDistributingDocument)
                        {
                            VoucherDistributingDocument distributionDocument = (VoucherDistributingDocument)stockAction;
                            TASINIRMALSAYMANLIGI.CalcValue = distributionDocument.Store.Name;
                            BIRLIK.CalcValue = stockAction.DestinationStore.Name;
                            DAGITIMMI.CalcValue = "X";
                        }
                        if (stockAction is VoucherReturnDocument)
                        {
                            VoucherReturnDocument returningDocument = (VoucherReturnDocument)stockAction;
                            TASINIRMALSAYMANLIGI.CalcValue = returningDocument.DestinationStore.Name;
                            BIRLIK.CalcValue = stockAction.Store.Name;
                            IADEMI.CalcValue = "X";
                        }

                    }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField1311111;
                public TTReportField NewField11111131;
                public TTReportField NewField11111132;
                public TTReportField NewField123111111;
                public TTReportField NewField1111111321;
                public TTReportField NewField11231111111;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField Deliverer;
                public TTReportField DelivererRank;
                public TTReportField ReceiverOfGoods;
                public TTReportField ReceiverOfGoodsRank;
                public TTReportField GROUPCOUNT;
                public TTReportField DESCRIPTIONTOTAL;
                public TTReportField DelivererUserType;
                public TTReportField ReceiverOfGoodsUserType; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 48;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 14, 125, 20, false);
                    NewField1311111.Name = "NewField1311111";
                    NewField1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311111.TextFont.Bold = true;
                    NewField1311111.TextFont.Underline = true;
                    NewField1311111.Value = @"Teslim Eden";

                    NewField11111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 14, 200, 20, false);
                    NewField11111131.Name = "NewField11111131";
                    NewField11111131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111131.TextFont.Bold = true;
                    NewField11111131.TextFont.Underline = true;
                    NewField11111131.Value = @"Teslim Alan";

                    NewField11111132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 23, 50, 29, false);
                    NewField11111132.Name = "NewField11111132";
                    NewField11111132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111132.TextFont.Bold = true;
                    NewField11111132.Value = @"İmza";

                    NewField123111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 29, 50, 35, false);
                    NewField123111111.Name = "NewField123111111";
                    NewField123111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField123111111.TextFont.Bold = true;
                    NewField123111111.Value = @"Adı ve Soyadı";

                    NewField1111111321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 35, 50, 41, false);
                    NewField1111111321.Name = "NewField1111111321";
                    NewField1111111321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111321.TextFont.Bold = true;
                    NewField1111111321.Value = @"Rütbesi";

                    NewField11231111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 41, 50, 47, false);
                    NewField11231111111.Name = "NewField11231111111";
                    NewField11231111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11231111111.TextFont.Bold = true;
                    NewField11231111111.Value = @"Görevi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 23, 51, 29, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 29, 51, 35, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 35, 51, 41, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 41, 51, 47, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    Deliverer = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 29, 125, 35, false);
                    Deliverer.Name = "Deliverer";
                    Deliverer.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Deliverer.WordBreak = EvetHayirEnum.ehEvet;
                    Deliverer.Value = @"";

                    DelivererRank = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 35, 125, 41, false);
                    DelivererRank.Name = "DelivererRank";
                    DelivererRank.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DelivererRank.WordBreak = EvetHayirEnum.ehEvet;
                    DelivererRank.Value = @"";

                    ReceiverOfGoods = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 29, 200, 35, false);
                    ReceiverOfGoods.Name = "ReceiverOfGoods";
                    ReceiverOfGoods.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReceiverOfGoods.WordBreak = EvetHayirEnum.ehEvet;
                    ReceiverOfGoods.Value = @"";

                    ReceiverOfGoodsRank = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 35, 200, 41, false);
                    ReceiverOfGoodsRank.Name = "ReceiverOfGoodsRank";
                    ReceiverOfGoodsRank.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReceiverOfGoodsRank.WordBreak = EvetHayirEnum.ehEvet;
                    ReceiverOfGoodsRank.Value = @"";

                    GROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 5, 209, 10, false);
                    GROUPCOUNT.Name = "GROUPCOUNT";
                    GROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    GROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUPCOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    GROUPCOUNT.TextFont.Size = 10;
                    GROUPCOUNT.TextFont.CharSet = 1;
                    GROUPCOUNT.Value = @"{@subgroupcount@}";

                    DESCRIPTIONTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 200, 10, false);
                    DESCRIPTIONTOTAL.Name = "DESCRIPTIONTOTAL";
                    DESCRIPTIONTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTIONTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOTAL.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOTAL.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOTAL.Value = @"";

                    DelivererUserType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 41, 125, 47, false);
                    DelivererUserType.Name = "DelivererUserType";
                    DelivererUserType.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DelivererUserType.WordBreak = EvetHayirEnum.ehEvet;
                    DelivererUserType.Value = @"";

                    ReceiverOfGoodsUserType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 41, 200, 47, false);
                    ReceiverOfGoodsUserType.Name = "ReceiverOfGoodsUserType";
                    ReceiverOfGoodsUserType.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReceiverOfGoodsUserType.WordBreak = EvetHayirEnum.ehEvet;
                    ReceiverOfGoodsUserType.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1311111.CalcValue = NewField1311111.Value;
                    NewField11111131.CalcValue = NewField11111131.Value;
                    NewField11111132.CalcValue = NewField11111132.Value;
                    NewField123111111.CalcValue = NewField123111111.Value;
                    NewField1111111321.CalcValue = NewField1111111321.Value;
                    NewField11231111111.CalcValue = NewField11231111111.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    Deliverer.CalcValue = Deliverer.Value;
                    DelivererRank.CalcValue = DelivererRank.Value;
                    ReceiverOfGoods.CalcValue = ReceiverOfGoods.Value;
                    ReceiverOfGoodsRank.CalcValue = ReceiverOfGoodsRank.Value;
                    GROUPCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    DESCRIPTIONTOTAL.CalcValue = @"";
                    DelivererUserType.CalcValue = DelivererUserType.Value;
                    ReceiverOfGoodsUserType.CalcValue = ReceiverOfGoodsUserType.Value;
                    return new TTReportObject[] { NewField1311111,NewField11111131,NewField11111132,NewField123111111,NewField1111111321,NewField11231111111,NewField3,NewField13,NewField14,NewField15,Deliverer,DelivererRank,ReceiverOfGoods,ReceiverOfGoodsRank,GROUPCOUNT,DESCRIPTIONTOTAL,DelivererUserType,ReceiverOfGoodsUserType};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(StockAction));

                foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                {
                    string signDesc = string.Empty;
                    string vekil = string.Empty;
                    if (stockActionSignDetail.SignUserType == SignUserTypeEnum.TeslimEden)
                    {
                        this.Deliverer.CalcValue = stockActionSignDetail.SignUser.Name;
                        if(stockActionSignDetail.SignUser.UserType.HasValue)
                            this.DelivererUserType.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(stockActionSignDetail.SignUser.UserType.Value);
                        if (stockActionSignDetail.SignUser.MilitaryClass != null)
                            signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                        if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
                            signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                        this.DelivererRank.CalcValue = signDesc;

                    }
                    if (stockActionSignDetail.SignUserType == SignUserTypeEnum.TeslimAlan)
                    {
                        this.ReceiverOfGoods.CalcValue = stockActionSignDetail.SignUser.Name;
                        if(stockActionSignDetail.SignUser.UserType.HasValue)
                            this.ReceiverOfGoodsUserType.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(stockActionSignDetail.SignUser.UserType.Value);
                        if (stockActionSignDetail.SignUser.MilitaryClass != null)
                            signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                        if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
                            signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                        this.ReceiverOfGoodsRank.CalcValue = signDesc;

                    }
                }
                
                DESCRIPTIONTOTAL.CalcValue =  "Yukarıda cinsi ve miktarı belirtilen " + stockAction.StockActionDetails.Count.ToString() + " kalem taşınır mal karşılarında belirtilen durumlarına uygun olarak teslim edilmiş ve teslim alınmıştır. " + ((DateTime)stockAction.TransactionDate).ToShortDateString() ;
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public VoucherDistributionReturningDocumentReport MyParentReport
            {
                get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
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
            public TTReportField NewField1311112 { get {return Header().NewField1311112;} }
            public TTReportField NewField1211111 { get {return Header().NewField1211111;} }
            public TTReportField NewField1311113 { get {return Header().NewField1311113;} }
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
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField111113;
                public TTReportField NewField1311112;
                public TTReportField NewField1211111;
                public TTReportField NewField1311113; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 18;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 18, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"
S. Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 48, 18, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Stok Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 112, 18, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Cins ve Özellikleri";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 6, 159, 18, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.Value = @"Ölçü
Birimi";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 200, 6, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.Value = @"Mevcut";

                    NewField1311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 6, 200, 18, false);
                    NewField1311112.Name = "NewField1311112";
                    NewField1311112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112.TextFont.Bold = true;
                    NewField1311112.Value = @"Açıklamalar";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 6, 177, 18, false);
                    NewField1211111.Name = "NewField1211111";
                    NewField1211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211111.TextFont.Bold = true;
                    NewField1211111.Value = @"Malın
Durumu";

                    NewField1311113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 6, 142, 18, false);
                    NewField1311113.Name = "NewField1311113";
                    NewField1311113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311113.TextFont.Bold = true;
                    NewField1311113.Value = @"Miktarı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1311112.CalcValue = NewField1311112.Value;
                    NewField1211111.CalcValue = NewField1211111.Value;
                    NewField1311113.CalcValue = NewField1311113.Value;
                    return new TTReportObject[] { NewField1111,NewField11111,NewField111111,NewField111112,NewField111113,NewField1311112,NewField1211111,NewField1311113};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public VoucherDistributionReturningDocumentReport MyParentReport
            {
                get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
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
                public VoucherDistributionReturningDocumentReport MyParentReport
                {
                    get { return (VoucherDistributionReturningDocumentReport)ParentReport; }
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
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 7, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.Value = @"{@counter@} ";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 8, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 1, 200, 8, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.ExtendTo = ExtendToEnum.extPageHeight;

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 48, 7, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 112, 7, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 9;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 159, 7, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 142, 7, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    STOCKLEVELTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 0, 177, 7, false);
                    STOCKLEVELTYPE.Name = "STOCKLEVELTYPE";
                    STOCKLEVELTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKLEVELTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKLEVELTYPE.TextFont.Size = 9;
                    STOCKLEVELTYPE.Value = @"{#STOCKLEVELTYPE#}";

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 1, 244, 6, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.VertAlign = VerticalAlignmentEnum.vaTop;
                    STOCKACTIONDETAILOBJECTID.TextFont.Size = 10;
                    STOCKACTIONDETAILOBJECTID.TextFont.CharSet = 1;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 200, 7, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.TextFont.Size = 9;
                    DESCRIPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    NATOSTOCKNO.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.NATOStockNO) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Materialname) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Amount) : "");
                    STOCKLEVELTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockleveltype) : "");
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery.Stockactiondetailobjectid) : "");
                    DESCRIPTION.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO,NATOSTOCKNO,MATERIALDESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,STOCKLEVELTYPE,STOCKACTIONDETAILOBJECTID,DESCRIPTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    // TODO :
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

        public VoucherDistributionReturningDocumentReport()
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
            Name = "VOUCHERDISTRIBUTIONRETURNINGDOCUMENTREPORT";
            Caption = "Teslim Tesellüm Belgesi (El Senedi)";
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