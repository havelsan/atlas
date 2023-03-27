
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
    public partial class CensusRecordReport : TTReport
    {
#region Methods
   internal CensusOrder CensusOrderObject;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CensusRecordReport MyParentReport
            {
                get { return (CensusRecordReport)ParentReport; }
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
                public CensusRecordReport MyParentReport
                {
                    get { return (CensusRecordReport)ParentReport; }
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
                    
                    Height = 43;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 187, 9, false);
                    ReportName.Name = "ReportName";
                    ReportName.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 11;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"SAYIM TUTANAĞI";

                    NewField99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 9, 168, 19, false);
                    NewField99.Name = "NewField99";
                    NewField99.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField99.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField99.TextFont.Bold = true;
                    NewField99.TextFont.CharSet = 162;
                    NewField99.Value = @"Kodu";

                    NewField13111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 9, 51, 19, false);
                    NewField13111231.Name = "NewField13111231";
                    NewField13111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13111231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13111231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13111231.TextFont.Bold = true;
                    NewField13111231.TextFont.CharSet = 162;
                    NewField13111231.Value = @"Harcama Birimi
Birlik/Kurum Adı";

                    HARCAMABIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 9, 157, 19, false);
                    HARCAMABIRIMI.Name = "HARCAMABIRIMI";
                    HARCAMABIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMI.FieldType = ReportFieldTypeEnum.ftExpression;
                    HARCAMABIRIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMABIRIMI.ObjectDefName = "ResHospital";
                    HARCAMABIRIMI.DataMember = "NAME";
                    HARCAMABIRIMI.TextFont.Size = 8;
                    HARCAMABIRIMI.TextFont.CharSet = 162;
                    HARCAMABIRIMI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITAL"", """") ";

                    HARCAMABIRIMIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 9, 187, 19, false);
                    HARCAMABIRIMIKODU.Name = "HARCAMABIRIMIKODU";
                    HARCAMABIRIMIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMIKODU.FieldType = ReportFieldTypeEnum.ftExpression;
                    HARCAMABIRIMIKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HARCAMABIRIMIKODU.ObjectDefName = "ResHospital";
                    HARCAMABIRIMIKODU.DataMember = "QREF";
                    HARCAMABIRIMIKODU.TextFont.Size = 8;
                    HARCAMABIRIMIKODU.TextFont.CharSet = 162;
                    HARCAMABIRIMIKODU.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITAL"", """") ";

                    NewField113211131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 51, 29, false);
                    NewField113211131.Name = "NewField113211131";
                    NewField113211131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113211131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113211131.TextFont.Bold = true;
                    NewField113211131.TextFont.CharSet = 162;
                    NewField113211131.Value = @"Taşınır Mal
Saymanlığının Adı";

                    SAYMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 19, 157, 29, false);
                    SAYMANLIK.Name = "SAYMANLIK";
                    SAYMANLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIK.TextFont.Size = 8;
                    SAYMANLIK.TextFont.CharSet = 162;
                    SAYMANLIK.Value = @"";

                    NewField199 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 19, 168, 29, false);
                    NewField199.Name = "NewField199";
                    NewField199.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField199.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField199.TextFont.Bold = true;
                    NewField199.TextFont.CharSet = 162;
                    NewField199.Value = @"Kodu";

                    SAYMANLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 19, 187, 29, false);
                    SAYMANLIKKODU.Name = "SAYMANLIKKODU";
                    SAYMANLIKKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIKKODU.TextFont.Size = 8;
                    SAYMANLIKKODU.TextFont.CharSet = 162;
                    SAYMANLIKKODU.Value = @"";

                    NewField1131112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 51, 43, false);
                    NewField1131112311.Name = "NewField1131112311";
                    NewField1131112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131112311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131112311.TextFont.Bold = true;
                    NewField1131112311.TextFont.CharSet = 162;
                    NewField1131112311.Value = @"Sayımın Yapıldığı
Depo/Ambarın
Birlik/Kurum Adı";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 29, 157, 43, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"";

                    NewField1991 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 29, 168, 43, false);
                    NewField1991.Name = "NewField1991";
                    NewField1991.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1991.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1991.TextFont.Bold = true;
                    NewField1991.TextFont.CharSet = 162;
                    NewField1991.Value = @"Kodu";

                    BIRLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 29, 187, 43, false);
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
                    NewField113211131.CalcValue = NewField113211131.Value;
                    SAYMANLIK.CalcValue = SAYMANLIK.Value;
                    NewField199.CalcValue = NewField199.Value;
                    SAYMANLIKKODU.CalcValue = SAYMANLIKKODU.Value;
                    NewField1131112311.CalcValue = NewField1131112311.Value;
                    BIRLIK.CalcValue = BIRLIK.Value;
                    NewField1991.CalcValue = NewField1991.Value;
                    BIRLIKKODU.CalcValue = BIRLIKKODU.Value;
                    HARCAMABIRIMI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", "") ;
                    HARCAMABIRIMI.PostFieldValueCalculation();
                    HARCAMABIRIMIKODU.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", "") ;
                    HARCAMABIRIMIKODU.PostFieldValueCalculation();
                    return new TTReportObject[] { ReportName,NewField99,NewField13111231,NewField113211131,SAYMANLIK,NewField199,SAYMANLIKKODU,NewField1131112311,BIRLIK,NewField1991,BIRLIKKODU,HARCAMABIRIMI,HARCAMABIRIMIKODU};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if (MyParentReport.CensusOrderObject != null)
                    {
                        BIRLIK.Value = MyParentReport.CensusOrderObject.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
                        BIRLIKKODU.Value = MyParentReport.CensusOrderObject.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code.ToString();

                        SAYMANLIK.Value = MyParentReport.CensusOrderObject.AccountingTerm.Accountancy.Name;
                        SAYMANLIKKODU.Value = MyParentReport.CensusOrderObject.AccountingTerm.Accountancy.AccountancyNO;
                    }
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CensusRecordReport MyParentReport
                {
                    get { return (CensusRecordReport)ParentReport; }
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
            public CensusRecordReport MyParentReport
            {
                get { return (CensusRecordReport)ParentReport; }
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
            public TTReportField NewField11127111 { get {return Header().NewField11127111;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField NewField111411 { get {return Footer().NewField111411;} }
            public TTReportField MALSAYMANI { get {return Footer().MALSAYMANI;} }
            public TTReportField HESAPSORUMLUSU { get {return Footer().HESAPSORUMLUSU;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField UYE2 { get {return Footer().UYE2;} }
            public TTReportField MALSORUMLUSU { get {return Footer().MALSORUMLUSU;} }
            public TTReportField Description1 { get {return Footer().Description1;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine3 { get {return Footer().NewLine3;} }
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
                public CensusRecordReport MyParentReport
                {
                    get { return (CensusRecordReport)ParentReport; }
                }
                
                public TTReportField NewField7;
                public TTReportField NewField17;
                public TTReportField NewField171;
                public TTReportField NewField172;
                public TTReportField NewField1271;
                public TTReportField NewField11721;
                public TTReportField NewField112711;
                public TTReportField NewField1117211;
                public TTReportField NewField11127111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 7, 14, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"
S.
Nu.";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 34, 14, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"
Stok
Numarası";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 89, 14, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"
Taşınır Malın
Cins ve Özellikleri";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 105, 14, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField172.MultiLine = EvetHayirEnum.ehEvet;
                    NewField172.TextFont.Bold = true;
                    NewField172.TextFont.CharSet = 162;
                    NewField172.Value = @"
Ölçü
Birimi";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 122, 14, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1271.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1271.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1271.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.TextFont.CharSet = 162;
                    NewField1271.Value = @"
Kayıtlı
Miktar";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 137, 14, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11721.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11721.TextFont.Bold = true;
                    NewField11721.TextFont.CharSet = 162;
                    NewField11721.Value = @"Sayımda
Bulunan
Miktar";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 152, 14, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"
Fazla
Miktar";

                    NewField1117211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 165, 14, false);
                    NewField1117211.Name = "NewField1117211";
                    NewField1117211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1117211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1117211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1117211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1117211.TextFont.Bold = true;
                    NewField1117211.TextFont.CharSet = 162;
                    NewField1117211.Value = @"
Noksan
Miktar";

                    NewField11127111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 187, 14, false);
                    NewField11127111.Name = "NewField11127111";
                    NewField11127111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11127111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11127111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11127111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11127111.TextFont.Bold = true;
                    NewField11127111.TextFont.CharSet = 162;
                    NewField11127111.Value = @"
Açıklama
";

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
                    NewField11127111.CalcValue = NewField11127111.Value;
                    return new TTReportObject[] { NewField7,NewField17,NewField171,NewField172,NewField1271,NewField11721,NewField112711,NewField1117211,NewField11127111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CensusRecordReport MyParentReport
                {
                    get { return (CensusRecordReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField1111;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField MALSAYMANI;
                public TTReportField HESAPSORUMLUSU;
                public TTReportField BASKAN;
                public TTReportField UYE1;
                public TTReportField UYE2;
                public TTReportField MALSORUMLUSU;
                public TTReportField Description1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 182;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 187, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.Value = @"Kayıtlı miktar bölümünde yazılı miktarlar tarafımızdan verilmiştir.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 7, 187, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"				Taşınır Mal Saymanı		    Taşınır Mal Hesap Sorumlusu";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 14, 187, 42, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"
Adı Soyadı:
Rütbesi/Ünvanı Sicil Nu.:

İmzası:
Tarih:
";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 42, 187, 49, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sayım Kurulu";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 49, 187, 56, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.Value = @"Nezaretimde sayım yapılmıştır.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 56, 187, 89, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"

Rütbesi/Ünvanı Scl Nu.:
Adı Soyadı:

İmzası:
Tarih:
";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 57, 75, 64, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Başkan";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 57, 111, 64, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Üye";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 57, 147, 64, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Üye";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 57, 183, 64, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Tşr Mal Sorumlusu";

                    MALSAYMANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 18, 82, 40, false);
                    MALSAYMANI.Name = "MALSAYMANI";
                    MALSAYMANI.MultiLine = EvetHayirEnum.ehEvet;
                    MALSAYMANI.Value = @"";

                    HESAPSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 18, 131, 40, false);
                    HESAPSORUMLUSU.Name = "HESAPSORUMLUSU";
                    HESAPSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.Value = @"";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 64, 73, 86, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    BASKAN.TextFont.Size = 8;
                    BASKAN.TextFont.CharSet = 162;
                    BASKAN.Value = @"";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 64, 110, 86, false);
                    UYE1.Name = "UYE1";
                    UYE1.MultiLine = EvetHayirEnum.ehEvet;
                    UYE1.TextFont.Size = 8;
                    UYE1.TextFont.CharSet = 162;
                    UYE1.Value = @"";

                    UYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 64, 147, 86, false);
                    UYE2.Name = "UYE2";
                    UYE2.MultiLine = EvetHayirEnum.ehEvet;
                    UYE2.TextFont.Size = 8;
                    UYE2.TextFont.CharSet = 162;
                    UYE2.Value = @"";

                    MALSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 64, 185, 86, false);
                    MALSORUMLUSU.Name = "MALSORUMLUSU";
                    MALSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    MALSORUMLUSU.TextFont.Size = 8;
                    MALSORUMLUSU.TextFont.CharSet = 162;
                    MALSORUMLUSU.Value = @"";

                    Description1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 103, 187, 176, false);
                    Description1.Name = "Description1";
                    Description1.MultiLine = EvetHayirEnum.ehEvet;
                    Description1.WordBreak = EvetHayirEnum.ehEvet;
                    Description1.Value = @"""           Saymanlıklar yılda en az 2 kez kendi depolarının ve klinik depolarının sayımlarını emirle yaptırmaları gerekmektedir. 
            Söz konusu sayım, yönergeye göre yukarıda örneği olan sayım tutanağı tanzim edilerek yapılmaktadır.Sayım tutanağını saymanlık hazırlayıp kayıtlardaki miktarları yazıp sayım kuruluna teslim eder. 
            Sayım kurulu sayım esnasında saydığı malları """"sayımda bulunan miktar"""" hanesine elle yazar. Bu işlem XXXXXX sisteminde olmadığı için önce Depo mevcudu raporu alınıp excele aktarılıp kopyala yapıştır yöntemi ile hazırlanmaktadır. Bu yöntem 5 malzeme masası ve 30 klinik olarak düşünüldüğünde 150-200 adet farklı çizelge hazırlanmasını gerektirmektedir. 
            Bu süreç uzun zaman almakta olup hatalara sebebiyet vermektedir. Bu çizelgenin XXXXXX sistemine entegre edilmesi ile söz konusu hata ve zaman kayıplarının ortadan kalkacağı, klinik ve depo sayımlarının yönergeye uygun olacağı, teftiş ve denetlemelerde sürekli olarak aranan Sayım hususunun problem ve sıkıntı sahası olmasının ortadan kaldıracağı değerlendirilmektedir.
            Çizelge(MSY 59-2 A EK-M)nin alt bölümündeki Sayman, Hs. sor ve Sayım kurulunun isim bloğu, her sayfanın altında değilde; örneğin bir kliniğin bir masasının tamamını çizelgeye attıktan sonra son sayfada olmasının uygun olacağı değerlendirilmektedir. 
            Çizelge 3 suret hazırlanacağından, 30 kliniğin tüm malzemeleri de değerlendirildiğinde 800-1000 sayfa arasında çıktı olacaktır. Bu yüzden çizelgenin sütun ve satır genişlikleri ve yazı boyutu, teftişe de ibraz edildiğinden okunabilir olmalıdır. Her iki husuta göz önünde bulundurulmalıdır.
            Söz konusu Sayım tutanağı ,XXXXXX sisteminde """"DEPO SAYIM TUTANAĞI"""" adı altında olmasının uygun olacağı değerlendirilmektedir.""								
";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 94, 187, 103, false);
                    NewField12.Name = "NewField12";
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"1. MSY 59-2(A) DÖRDÜNCÜ BÖLÜM ""SAYIM VE DEVİR İŞLEMLERİ"" 								
""TAŞINIR MALLARIN SAYIMLARI YIL SONUNA KADAR MUTLAKA YAPILIR "" HÜKMÜNE AMİRDİR.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 89, 187, 94, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"ÖNEMLİ AÇIKLAMA		
";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 88, 187, 176, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 176, 187, 176, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 89, 0, 176, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    MALSAYMANI.CalcValue = MALSAYMANI.Value;
                    HESAPSORUMLUSU.CalcValue = HESAPSORUMLUSU.Value;
                    BASKAN.CalcValue = BASKAN.Value;
                    UYE1.CalcValue = UYE1.Value;
                    UYE2.CalcValue = UYE2.Value;
                    MALSORUMLUSU.CalcValue = MALSORUMLUSU.Value;
                    Description1.CalcValue = Description1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField121,NewField131,NewField1111,NewField141,NewField1141,NewField11411,NewField111411,MALSAYMANI,HESAPSORUMLUSU,BASKAN,UYE1,UYE2,MALSORUMLUSU,Description1,NewField12,NewField13};
                }
                public override void RunPreScript()
                {
#region PARTB FOOTER_PreScript
                    if (MyParentReport.CensusOrderObject != null)
                    {

                        foreach (StockActionSignDetail stockActionSignDetail in MyParentReport.CensusOrderObject.StockActionSignDetails)
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
                            if (MyParentReport.CensusOrderObject.TransactionDate.HasValue)
                                signDesc += "\r\n" + MyParentReport.CensusOrderObject.TransactionDate.Value.ToShortDateString();

                            switch (stockActionSignDetail.SignUserType)
                            {
                                case SignUserTypeEnum.MalSaymani:
                                    this.MALSAYMANI.Value = signDesc;
                                    break;
                                case SignUserTypeEnum.HesapSorumlusu:
                                    this.HESAPSORUMLUSU.Value = signDesc;
                                    break;
                                case SignUserTypeEnum.MalSorumlusu:
                                    this.MALSORUMLUSU.Value = signDesc;
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
            public CensusRecordReport MyParentReport
            {
                get { return (CensusRecordReport)ParentReport; }
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
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
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
                list[0] = new TTReportNqlData<CensusOrder.CensusRecordReportRQ_Class>("CensusRecordReportRQ", CensusOrder.CensusRecordReportRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public CensusRecordReport MyParentReport
                {
                    get { return (CensusRecordReport)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField NATOStockNO;
                public TTReportField StockCardName;
                public TTReportField DistributionType;
                public TTReportField Amount;
                public TTReportField BULUNANMIKTAR;
                public TTReportField FAZLAMIKTAR;
                public TTReportField NOKSANMIKTAR;
                public TTReportField ACIKLAMA; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 7, 5, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.Value = @"{@counter@}";

                    NATOStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 34, 5, false);
                    NATOStockNO.Name = "NATOStockNO";
                    NATOStockNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO.TextFont.Size = 9;
                    NATOStockNO.TextFont.CharSet = 162;
                    NATOStockNO.Value = @"{#NATOSTOCKNO#}";

                    StockCardName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 89, 5, false);
                    StockCardName.Name = "StockCardName";
                    StockCardName.DrawStyle = DrawStyleConstants.vbSolid;
                    StockCardName.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockCardName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    StockCardName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StockCardName.TextFont.Size = 9;
                    StockCardName.TextFont.CharSet = 162;
                    StockCardName.Value = @"{#CARDNAME#}";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 105, 5, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.DrawStyle = DrawStyleConstants.vbSolid;
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.TextFont.Size = 9;
                    DistributionType.TextFont.CharSet = 162;
                    DistributionType.Value = @"{#DISTRIBUTIONTYPE#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 122, 5, false);
                    Amount.Name = "Amount";
                    Amount.DrawStyle = DrawStyleConstants.vbSolid;
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.TextFormat = @"#,##0";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"{#INHELDNEW#}";

                    BULUNANMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 137, 5, false);
                    BULUNANMIKTAR.Name = "BULUNANMIKTAR";
                    BULUNANMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    BULUNANMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BULUNANMIKTAR.TextFormat = @"#,##0";
                    BULUNANMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BULUNANMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BULUNANMIKTAR.Value = @"";

                    FAZLAMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 152, 5, false);
                    FAZLAMIKTAR.Name = "FAZLAMIKTAR";
                    FAZLAMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    FAZLAMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAZLAMIKTAR.TextFormat = @"#,##0";
                    FAZLAMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FAZLAMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FAZLAMIKTAR.Value = @"";

                    NOKSANMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 165, 5, false);
                    NOKSANMIKTAR.Name = "NOKSANMIKTAR";
                    NOKSANMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    NOKSANMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOKSANMIKTAR.TextFormat = @"#,##0";
                    NOKSANMIKTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NOKSANMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NOKSANMIKTAR.Value = @"";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 187, 5, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFormat = @"#,##0";
                    ACIKLAMA.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ACIKLAMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CensusOrder.CensusRecordReportRQ_Class dataset_CensusRecordReportRQ = ParentGroup.rsGroup.GetCurrentRecord<CensusOrder.CensusRecordReportRQ_Class>(0);
                    OrderNO.CalcValue = ParentGroup.Counter.ToString();
                    NATOStockNO.CalcValue = (dataset_CensusRecordReportRQ != null ? Globals.ToStringCore(dataset_CensusRecordReportRQ.NATOStockNO) : "");
                    StockCardName.CalcValue = (dataset_CensusRecordReportRQ != null ? Globals.ToStringCore(dataset_CensusRecordReportRQ.Cardname) : "");
                    DistributionType.CalcValue = (dataset_CensusRecordReportRQ != null ? Globals.ToStringCore(dataset_CensusRecordReportRQ.DistributionType) : "");
                    Amount.CalcValue = (dataset_CensusRecordReportRQ != null ? Globals.ToStringCore(dataset_CensusRecordReportRQ.Inheldnew) : "");
                    BULUNANMIKTAR.CalcValue = @"";
                    FAZLAMIKTAR.CalcValue = @"";
                    NOKSANMIKTAR.CalcValue = @"";
                    ACIKLAMA.CalcValue = @"";
                    return new TTReportObject[] { OrderNO,NATOStockNO,StockCardName,DistributionType,Amount,BULUNANMIKTAR,FAZLAMIKTAR,NOKSANMIKTAR,ACIKLAMA};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //  int fazla, noksan;
                   // int censusInheld = 0;
//               censusAmount = 0;
//            if(BULUNANMIKTAR.CalcValue != null && Amount.CalcValue !=null )
//            {
//                censusInheld = Convert.ToInt32(BULUNANMIKTAR.CalcValue.ToString());
//                censusAmount = Convert.ToInt32(Amount.CalcValue);
//
//                if(censusInheld > censusAmount)
//                {
//                    fazla = censusInheld - censusAmount;
//                    FAZLAMIKTAR.CalcValue = fazla.ToString();
//                    
//                }
//                else if(censusInheld < censusAmount)
//                {
//                    noksan = censusAmount - censusInheld;
//                    NOKSANMIKTAR.CalcValue = noksan.ToString();
//                    
//                }
//    
//            }
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

        public CensusRecordReport()
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
            Name = "CENSUSRECORDREPORT";
            Caption = "Sayım Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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
#region CENSUSRECORDREPORT_PreScript
            base.RunPreScript();

            if (this.RuntimeParameters.TTOBJECTID.HasValue)
                CensusOrderObject = (CensusOrder)this.ReportObjectContext.GetObject(this.RuntimeParameters.TTOBJECTID.Value, typeof(CensusOrder));
#endregion CENSUSRECORDREPORT_PreScript
        }
    }
}