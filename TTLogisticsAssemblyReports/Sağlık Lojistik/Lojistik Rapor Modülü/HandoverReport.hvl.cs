
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
    public partial class HandoverReport : TTReport
    {
#region Methods
   internal HandoverDocument HandoverObject;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HandoverReport MyParentReport
            {
                get { return (HandoverReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField NewField99 { get {return Header().NewField99;} }
            public TTReportField NewField13111231 { get {return Header().NewField13111231;} }
            public TTReportField HARCAMABIRIMI { get {return Header().HARCAMABIRIMI;} }
            public TTReportField HARCAMABIRIMIKODU { get {return Header().HARCAMABIRIMIKODU;} }
            public TTReportField NewField113211131 { get {return Header().NewField113211131;} }
            public TTReportField SAYMANLIK { get {return Header().SAYMANLIK;} }
            public TTReportField NewField199 { get {return Header().NewField199;} }
            public TTReportField SAYMANLIKKODU { get {return Header().SAYMANLIKKODU;} }
            public TTReportField NewField1131112311 { get {return Header().NewField1131112311;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField1991 { get {return Header().NewField1991;} }
            public TTReportField BIRLIKKODU { get {return Header().BIRLIKKODU;} }
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
                public HandoverReport MyParentReport
                {
                    get { return (HandoverReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField NewField99;
                public TTReportField NewField13111231;
                public TTReportField HARCAMABIRIMI;
                public TTReportField HARCAMABIRIMIKODU;
                public TTReportField NewField113211131;
                public TTReportField SAYMANLIK;
                public TTReportField NewField199;
                public TTReportField SAYMANLIKKODU;
                public TTReportField NewField1131112311;
                public TTReportField BIRLIK;
                public TTReportField NewField1991;
                public TTReportField BIRLIKKODU; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 270, 7, false);
                    ReportName.Name = "ReportName";
                    ReportName.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 11;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"TAŞINIR MAL SORUMLUSU VE TAŞINIR MAL HESAP SORUMLULARI DEVİR VE TESLİM BELGESİ";

                    NewField99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 7, 245, 14, false);
                    NewField99.Name = "NewField99";
                    NewField99.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField99.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField99.TextFont.Size = 11;
                    NewField99.TextFont.Bold = true;
                    NewField99.TextFont.CharSet = 162;
                    NewField99.Value = @"KODU";

                    NewField13111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 7, 72, 14, false);
                    NewField13111231.Name = "NewField13111231";
                    NewField13111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13111231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13111231.TextFont.Bold = true;
                    NewField13111231.TextFont.CharSet = 162;
                    NewField13111231.Value = @"Harcama Birimi Birlik/Kurumun Adı";

                    HARCAMABIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 7, 234, 14, false);
                    HARCAMABIRIMI.Name = "HARCAMABIRIMI";
                    HARCAMABIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMABIRIMI.TextFont.CharSet = 162;
                    HARCAMABIRIMI.Value = @"";

                    HARCAMABIRIMIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 7, 270, 14, false);
                    HARCAMABIRIMIKODU.Name = "HARCAMABIRIMIKODU";
                    HARCAMABIRIMIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMIKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMABIRIMIKODU.TextFont.Size = 8;
                    HARCAMABIRIMIKODU.TextFont.CharSet = 162;
                    HARCAMABIRIMIKODU.Value = @"";

                    NewField113211131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 14, 72, 21, false);
                    NewField113211131.Name = "NewField113211131";
                    NewField113211131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113211131.TextFont.Bold = true;
                    NewField113211131.TextFont.CharSet = 162;
                    NewField113211131.Value = @"Taşınır Mal Saymanlığının Adı";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 14, 234, 21, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"";

                    NewField199 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 14, 245, 21, false);
                    NewField199.Name = "NewField199";
                    NewField199.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField199.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField199.TextFont.Size = 11;
                    NewField199.TextFont.Bold = true;
                    NewField199.TextFont.CharSet = 162;
                    NewField199.Value = @"KODU";

                    SAYMANLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 14, 270, 21, false);
                    SAYMANLIKKODU.Name = "SAYMANLIKKODU";
                    SAYMANLIKKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIKKODU.TextFont.Size = 8;
                    SAYMANLIKKODU.TextFont.CharSet = 162;
                    SAYMANLIKKODU.Value = @"";

                    NewField1131112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 21, 72, 28, false);
                    NewField1131112311.Name = "NewField1131112311";
                    NewField1131112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131112311.TextFont.Bold = true;
                    NewField1131112311.TextFont.CharSet = 162;
                    NewField1131112311.Value = @"Depo/Birliğin/Kurumun Adı";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 21, 234, 28, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    NewField1991 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 21, 245, 28, false);
                    NewField1991.Name = "NewField1991";
                    NewField1991.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1991.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1991.TextFont.Size = 11;
                    NewField1991.TextFont.Bold = true;
                    NewField1991.TextFont.CharSet = 162;
                    NewField1991.Value = @"KODU";

                    BIRLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 21, 270, 28, false);
                    BIRLIKKODU.Name = "BIRLIKKODU";
                    BIRLIKKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIKKODU.TextFont.Size = 8;
                    BIRLIKKODU.TextFont.CharSet = 162;
                    BIRLIKKODU.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    NewField99.CalcValue = NewField99.Value;
                    NewField13111231.CalcValue = NewField13111231.Value;
                    HARCAMABIRIMI.CalcValue = HARCAMABIRIMI.Value;
                    HARCAMABIRIMIKODU.CalcValue = HARCAMABIRIMIKODU.Value;
                    NewField113211131.CalcValue = NewField113211131.Value;
                    SAYMANLIK.CalcValue = SAYMANLIK.Value;
                    NewField199.CalcValue = NewField199.Value;
                    SAYMANLIKKODU.CalcValue = SAYMANLIKKODU.Value;
                    NewField1131112311.CalcValue = NewField1131112311.Value;
                    BIRLIK.CalcValue = BIRLIK.Value;
                    NewField1991.CalcValue = NewField1991.Value;
                    BIRLIKKODU.CalcValue = BIRLIKKODU.Value;
                    return new TTReportObject[] { ReportName,NewField99,NewField13111231,HARCAMABIRIMI,HARCAMABIRIMIKODU,NewField113211131,SAYMANLIK,NewField199,SAYMANLIKKODU,NewField1131112311,BIRLIK,NewField1991,BIRLIKKODU};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if (MyParentReport.HandoverObject != null)
                    {
                        BIRLIK.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        BIRLIKKODU.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code.ToString();

                        SAYMANLIK.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.Name;
                        SAYMANLIKKODU.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.AccountancyNO;
                    }
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HandoverReport MyParentReport
                {
                    get { return (HandoverReport)ParentReport; }
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

        public partial class PARTBGroup : TTReportGroup
        {
            public HandoverReport MyParentReport
            {
                get { return (HandoverReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField11721 { get {return Header().NewField11721;} }
            public TTReportField NewField112711 { get {return Header().NewField112711;} }
            public TTReportField NewField1117211 { get {return Header().NewField1117211;} }
            public TTReportField NewField11723 { get {return Header().NewField11723;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField NewField111411 { get {return Footer().NewField111411;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField UYE2 { get {return Footer().UYE2;} }
            public TTReportField TESLIMEDEN { get {return Footer().TESLIMEDEN;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
            public TTReportField NewField1114111 { get {return Footer().NewField1114111;} }
            public TTReportField TESLIMALAN { get {return Footer().TESLIMALAN;} }
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
                public HandoverReport MyParentReport
                {
                    get { return (HandoverReport)ParentReport; }
                }
                
                public TTReportField NewField7;
                public TTReportField NewField17;
                public TTReportField NewField171;
                public TTReportField NewField172;
                public TTReportField NewField1271;
                public TTReportField NewField11721;
                public TTReportField NewField112711;
                public TTReportField NewField1117211;
                public TTReportField NewField11723; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 10, 10, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"S.
Nu.";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 40, 10, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Stok Numarası";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 136, 10, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Cins ve Özellikleri";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 156, 10, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField172.TextFont.Bold = true;
                    NewField172.TextFont.CharSet = 162;
                    NewField172.Value = @"Ölçü Birimi";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 218, 10, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1271.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1271.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.TextFont.CharSet = 162;
                    NewField1271.Value = @"Kayıtlardaki Miktar";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 185, 10, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11721.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11721.TextFont.Bold = true;
                    NewField11721.TextFont.CharSet = 162;
                    NewField11721.Value = @"Sayımda Bulunan
Miktar";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 5, 244, 10, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"Fazla Miktar";

                    NewField1117211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 5, 270, 10, false);
                    NewField1117211.Name = "NewField1117211";
                    NewField1117211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1117211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1117211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1117211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1117211.TextFont.Bold = true;
                    NewField1117211.TextFont.CharSet = 162;
                    NewField1117211.Value = @"Noksan Miktar";

                    NewField11723 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 270, 5, false);
                    NewField11723.Name = "NewField11723";
                    NewField11723.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11723.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11723.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11723.TextFont.Bold = true;
                    NewField11723.TextFont.CharSet = 162;
                    NewField11723.Value = @"Sayım Sounucuna Göre";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField7.CalcValue = NewField7.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField112711.CalcValue = NewField112711.Value;
                    NewField1117211.CalcValue = NewField1117211.Value;
                    NewField11723.CalcValue = NewField11723.Value;
                    return new TTReportObject[] { NewField7,NewField17,NewField171,NewField172,NewField1271,NewField11721,NewField112711,NewField1117211,NewField11723};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HandoverReport MyParentReport
                {
                    get { return (HandoverReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField121;
                public TTReportField NewField1111;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField BASKAN;
                public TTReportField UYE1;
                public TTReportField UYE2;
                public TTReportField TESLIMEDEN;
                public TTReportField NewField1121;
                public TTReportField NewField1114111;
                public TTReportField TESLIMALAN; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 47;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 7, 270, 47, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 165, 7, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"D E V İ R  V E  T E S L İ M  K U R U L U";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 7, 165, 47, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"

Görevi:
Rütbesi/Ünvanı Sicil Nu.:
Adı Soyadı:

İmzası:
Tarih:
";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 8, 75, 15, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Başkan";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 8, 111, 15, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Üye";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 8, 147, 15, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Üye";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 8, 206, 15, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Teslim Eden";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 18, 74, 40, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    BASKAN.Value = @"";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 18, 114, 40, false);
                    UYE1.Name = "UYE1";
                    UYE1.MultiLine = EvetHayirEnum.ehEvet;
                    UYE1.Value = @"";

                    UYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 18, 154, 40, false);
                    UYE2.Name = "UYE2";
                    UYE2.MultiLine = EvetHayirEnum.ehEvet;
                    UYE2.Value = @"";

                    TESLIMEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 18, 211, 40, false);
                    TESLIMEDEN.Name = "TESLIMEDEN";
                    TESLIMEDEN.MultiLine = EvetHayirEnum.ehEvet;
                    TESLIMEDEN.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 270, 7, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"D E V İ R  V E  T E S L İ M  K U R U L U";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 9, 261, 16, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114111.TextFont.Bold = true;
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @"Teslim Alan";

                    TESLIMALAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 18, 262, 40, false);
                    TESLIMALAN.Name = "TESLIMALAN";
                    TESLIMALAN.MultiLine = EvetHayirEnum.ehEvet;
                    TESLIMALAN.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    BASKAN.CalcValue = BASKAN.Value;
                    UYE1.CalcValue = UYE1.Value;
                    UYE2.CalcValue = UYE2.Value;
                    TESLIMEDEN.CalcValue = TESLIMEDEN.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    TESLIMALAN.CalcValue = TESLIMALAN.Value;
                    return new TTReportObject[] { NewField11111,NewField121,NewField1111,NewField141,NewField1141,NewField11411,NewField111411,BASKAN,UYE1,UYE2,TESLIMEDEN,NewField1121,NewField1114111,TESLIMALAN};
                }
                public override void RunPreScript()
                {
#region PARTB FOOTER_PreScript
                    if (MyParentReport.HandoverObject != null)
                    {

                        foreach (StockActionSignDetail stockActionSignDetail in MyParentReport.HandoverObject.StockActionSignDetails)
                        {
                            string signDesc = string.Empty;
                            signDesc += stockActionSignDetail.SignUser.Name;
                            if (stockActionSignDetail.SignUser.MilitaryClass != null)
                                signDesc += "\r\n" + stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                            else
                                signDesc += "\r\n";
                            if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
                                signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                            if (stockActionSignDetail.SignUser != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.EmploymentRecordID) == false)
                                signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
                            signDesc += "\r\n\r\n";
                            if (MyParentReport.HandoverObject.TransactionDate.HasValue)
                                signDesc += "\r\n" + MyParentReport.HandoverObject.TransactionDate.Value.ToShortDateString();

                            switch (stockActionSignDetail.SignUserType)
                            {
                                case SignUserTypeEnum.TeslimAlan:
                                    this.TESLIMALAN.Value = signDesc;
                                    break;
                                case SignUserTypeEnum.TeslimEden:
                                    this.TESLIMEDEN.Value = signDesc;
                                    break;
                                 case SignUserTypeEnum.Baskan:
                                    this.BASKAN.Value = signDesc;
                                    break;
                                case SignUserTypeEnum.Uye:
                                    if (string.IsNullOrEmpty(this.UYE1.Value))
                                        this.UYE1.Value = signDesc;
                                    else
                                        this.UYE2.Value = signDesc;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
#endregion PARTB FOOTER_PreScript
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HandoverReport MyParentReport
            {
                get { return (HandoverReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OrderNO { get {return Body().OrderNO;} }
            public TTReportField NATOStockNO { get {return Body().NATOStockNO;} }
            public TTReportField StockCardName { get {return Body().StockCardName;} }
            public TTReportField DistributionType { get {return Body().DistributionType;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField BULUNANMIKTAR { get {return Body().BULUNANMIKTAR;} }
            public TTReportField FAZLAMIKTAR { get {return Body().FAZLAMIKTAR;} }
            public TTReportField NOKSANMIKTAR { get {return Body().NOKSANMIKTAR;} }
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
                list[0] = new TTReportNqlData<HandoverDocument.GetHandoverDocumentReportQuery_Class>("GetHandoverDocumentReportQuery", HandoverDocument.GetHandoverDocumentReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HandoverReport MyParentReport
                {
                    get { return (HandoverReport)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField NATOStockNO;
                public TTReportField StockCardName;
                public TTReportField DistributionType;
                public TTReportField Amount;
                public TTReportField BULUNANMIKTAR;
                public TTReportField FAZLAMIKTAR;
                public TTReportField NOKSANMIKTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 10, 5, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.Value = @"{@counter@}";

                    NATOStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 40, 5, false);
                    NATOStockNO.Name = "NATOStockNO";
                    NATOStockNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NATOStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO.TextFont.Size = 9;
                    NATOStockNO.TextFont.CharSet = 162;
                    NATOStockNO.Value = @"{#NATOSTOCKNO#}";

                    StockCardName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 136, 5, false);
                    StockCardName.Name = "StockCardName";
                    StockCardName.DrawStyle = DrawStyleConstants.vbSolid;
                    StockCardName.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockCardName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    StockCardName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StockCardName.TextFont.Size = 9;
                    StockCardName.TextFont.CharSet = 162;
                    StockCardName.Value = @"{#CARDNAME#}";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 156, 5, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.DrawStyle = DrawStyleConstants.vbSolid;
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.TextFont.Size = 9;
                    DistributionType.TextFont.CharSet = 162;
                    DistributionType.Value = @"{#DISTRIBUTIONTYPE#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 218, 5, false);
                    Amount.Name = "Amount";
                    Amount.DrawStyle = DrawStyleConstants.vbSolid;
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.TextFormat = @"#,##0";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"{#CENSUSINHELD#}";

                    BULUNANMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 185, 5, false);
                    BULUNANMIKTAR.Name = "BULUNANMIKTAR";
                    BULUNANMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    BULUNANMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BULUNANMIKTAR.TextFormat = @"#,##0";
                    BULUNANMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BULUNANMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BULUNANMIKTAR.Value = @"{#INHELD#}";

                    FAZLAMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 244, 5, false);
                    FAZLAMIKTAR.Name = "FAZLAMIKTAR";
                    FAZLAMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    FAZLAMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAZLAMIKTAR.TextFormat = @"#,##0";
                    FAZLAMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FAZLAMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FAZLAMIKTAR.Value = @"{#REMNANT#}";

                    NOKSANMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 0, 270, 5, false);
                    NOKSANMIKTAR.Name = "NOKSANMIKTAR";
                    NOKSANMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    NOKSANMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOKSANMIKTAR.TextFormat = @"#,##0";
                    NOKSANMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NOKSANMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOKSANMIKTAR.Value = @"{#ABSENT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HandoverDocument.GetHandoverDocumentReportQuery_Class dataset_GetHandoverDocumentReportQuery = ParentGroup.rsGroup.GetCurrentRecord<HandoverDocument.GetHandoverDocumentReportQuery_Class>(0);
                    OrderNO.CalcValue = ParentGroup.Counter.ToString();
                    NATOStockNO.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.NATOStockNO) : "");
                    StockCardName.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.Cardname) : "");
                    DistributionType.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.DistributionType) : "");
                    Amount.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.CensusInheld) : "");
                    BULUNANMIKTAR.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.Inheld) : "");
                    FAZLAMIKTAR.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.Remnant) : "");
                    NOKSANMIKTAR.CalcValue = (dataset_GetHandoverDocumentReportQuery != null ? Globals.ToStringCore(dataset_GetHandoverDocumentReportQuery.Absent) : "");
                    return new TTReportObject[] { OrderNO,NATOStockNO,StockCardName,DistributionType,Amount,BULUNANMIKTAR,FAZLAMIKTAR,NOKSANMIKTAR};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HandoverReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Sayım Emri", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HANDOVERREPORT";
            Caption = "Devir ve Teslim Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
            UserMarginTop = 15;
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


        protected override void RunPreScript()
        {
#region HANDOVERREPORT_PreScript
            base.RunPreScript();

            if (this.RuntimeParameters.TTOBJECTID.HasValue)
                HandoverObject = (HandoverDocument)this.ReportObjectContext.GetObject(this.RuntimeParameters.TTOBJECTID.Value, typeof(HandoverDocument));
#endregion HANDOVERREPORT_PreScript
        }
    }
}