
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
    public partial class HandoverReport2 : TTReport
    {
#region Methods
   //internal HandoverDocument HandoverObject;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HandoverReport2 MyParentReport
            {
                get { return (HandoverReport2)ParentReport; }
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
            public TTReportField SAYMANLIKKODU { get {return Header().SAYMANLIKKODU;} }
            public TTReportField BIRLIKKODU { get {return Header().BIRLIKKODU;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField111711 { get {return Footer().NewField111711;} }
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
                public HandoverReport2 MyParentReport
                {
                    get { return (HandoverReport2)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField SAYMANLIKKODU;
                public TTReportField BIRLIKKODU;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 60;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 16, 200, 23, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 11;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"TAŞINIR MAL SAYMANLARI DEVİR VE TESLİM BELGESİ";

                    SAYMANLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 31, 131, 38, false);
                    SAYMANLIKKODU.Name = "SAYMANLIKKODU";
                    SAYMANLIKKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAYMANLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIKKODU.TextFont.Size = 11;
                    SAYMANLIKKODU.TextFont.Bold = true;
                    SAYMANLIKKODU.TextFont.CharSet = 162;
                    SAYMANLIKKODU.Value = @"YER";

                    BIRLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 31, 183, 38, false);
                    BIRLIKKODU.Name = "BIRLIKKODU";
                    BIRLIKKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIKKODU.TextFont.Size = 11;
                    BIRLIKKODU.TextFont.Bold = true;
                    BIRLIKKODU.TextFont.CharSet = 162;
                    BIRLIKKODU.Value = @"TARİH";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 85, 38, 134, 38, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 139, 38, 187, 38, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    SAYMANLIKKODU.CalcValue = SAYMANLIKKODU.Value;
                    BIRLIKKODU.CalcValue = BIRLIKKODU.Value;
                    return new TTReportObject[] { ReportName,SAYMANLIKKODU,BIRLIKKODU};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    //                    if (MyParentReport.HandoverObject != null)
//                    {
//                        BIRLIK.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Name;
//                        BIRLIKKODU.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.AccountancyMilitaryUnit.Code.ToString();
//
//                        SAYMANLIK.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.Name;
//                        SAYMANLIKKODU.Value = MyParentReport.HandoverObject.AccountingTerm.Accountancy.AccountancyNO;
//                    }
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HandoverReport2 MyParentReport
                {
                    get { return (HandoverReport2)ParentReport; }
                }
                
                public TTReportField NewField111711; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 28;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 89, 28, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111711.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111711.TextFont.Size = 11;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.TextFont.CharSet = 162;
                    NewField111711.Value = @"EKLER             	:
EK-A ( ..... Adet Taşınır Mal Hesap Sorumlusu 
          Devir ve Teslim Tutanağı)
EK-B ( ..... Adet Taşınır Mal Sorumlusu Devir 
           ve Teslim Tutanağı)	
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111711.CalcValue = NewField111711.Value;
                    return new TTReportObject[] { NewField111711};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HandoverReport2 MyParentReport
            {
                get { return (HandoverReport2)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11711 { get {return Footer().NewField11711;} }
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
                public HandoverReport2 MyParentReport
                {
                    get { return (HandoverReport2)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HandoverReport2 MyParentReport
                {
                    get { return (HandoverReport2)ParentReport; }
                }
                
                public TTReportField NewField11711; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 50;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 181, 48, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11711.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11711.TextFont.Size = 11;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"O N A Y
(Tarih)

      Birlik XXXXXXı / Kurum Amiri
                     İsim İmza
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11711.CalcValue = NewField11711.Value;
                    return new TTReportObject[] { NewField11711};
                }
                public override void RunPreScript()
                {
#region PARTB FOOTER_PreScript
                    //                    if (MyParentReport.HandoverObject != null)
//                    {
//
//                        foreach (StockActionSignDetail stockActionSignDetail in MyParentReport.HandoverObject.StockActionSignDetails)
//                        {
//                            string signDesc = string.Empty;
//                            signDesc += stockActionSignDetail.SignUser.Name;
//                            if (stockActionSignDetail.SignUser.MilitaryClass != null)
//                                signDesc += "\r\n" + stockActionSignDetail.SignUser.MilitaryClass.ShortName;
//                            else
//                                signDesc += "\r\n";
//                            if (stockActionSignDetail.SignUser.Rank != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.Rank.ShortName) == false)
//                                signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
//                            if (stockActionSignDetail.SignUser != null && string.IsNullOrEmpty(stockActionSignDetail.SignUser.EmploymentRecordID) == false)
//                                signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")";
//                            signDesc += "\r\n\r\n";
//                            if (MyParentReport.HandoverObject.TransactionDate.HasValue)
//                                signDesc += "\r\n" + MyParentReport.HandoverObject.TransactionDate.Value.ToShortDateString();
//
//                            switch (stockActionSignDetail.SignUserType)
//                            {
//                                case SignUserTypeEnum.TeslimAlan:
//                                    this.TESLIMALAN.Value = signDesc;
//                                    break;
//                                case SignUserTypeEnum.TeslimEden:
//                                    this.TESLIMEDEN.Value = signDesc;
//                                    break;
//                                 case SignUserTypeEnum.Baskan:
//                                    this.BASKAN.Value = signDesc;
//                                    break;
//                                case SignUserTypeEnum.Uye:
//                                    if (string.IsNullOrEmpty(this.UYE1.Value))
//                                        this.UYE1.Value = signDesc;
//                                    else
//                                        this.UYE2.Value = signDesc;
//                                    break;
//                                default:
//                                    break;
//                            }
//                        }
//                    }
#endregion PARTB FOOTER_PreScript
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HandoverReport2 MyParentReport
            {
                get { return (HandoverReport2)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField NewField121111 { get {return Body().NewField121111;} }
            public TTReportField NewField12114111 { get {return Body().NewField12114111;} }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField NewField11114111 { get {return Body().NewField11114111;} }
            public TTReportField NewField11711 { get {return Body().NewField11711;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HandoverReport2 MyParentReport
                {
                    get { return (HandoverReport2)ParentReport; }
                }
                
                public TTReportField NewField1171;
                public TTReportField NewField121111;
                public TTReportField NewField12114111;
                public TTReportField NewField11111;
                public TTReportField NewField11114111;
                public TTReportField NewField11711; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 153;
                    RepeatCount = 0;
                    
                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 25, 200, 47, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1171.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1171.TextFont.Size = 11;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"                    Bugün, Taşınır Mal Saymanı bulunduğum taşınır malları ............................. K.lığının ............ tarihli ve .......................................................sayılı emri gereğince taşınır mal hesap sorumlularının ve taşınır mal sorumlularının imzaları bulunan ek listelerde cins ve miktarları yazılı taşınır mallarla belgeler tarafımdan yeni Taşınır Mal Saymanı .......................................... ne teslim edilmiştir. ";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 47, 200, 79, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"

Rütbesi/Ünvanı Sicil Nu.:
Adı Soyadı:

İmzası:
Tarih:
";

                    NewField12114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 47, 200, 54, false);
                    NewField12114111.Name = "NewField12114111";
                    NewField12114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12114111.TextFont.Bold = true;
                    NewField12114111.TextFont.CharSet = 162;
                    NewField12114111.Value = @"Teslim Eden Taşınır Mal Saymanı ";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 103, 200, 135, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"

Rütbesi/Ünvanı Sicil Nu.:
Adı Soyadı:

İmzası:
Tarih:
";

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 102, 200, 109, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114111.TextFont.Bold = true;
                    NewField11114111.TextFont.CharSet = 162;
                    NewField11114111.Value = @"Teslim Alan Taşınır Mal Saymanı ";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 90, 200, 103, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11711.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11711.TextFont.Size = 11;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"             Taşınır mal  hesap sorumlularının ve taşınır mal sorumlularının imzaları bulunan ek listelerde cins ve miktarları yazılı taşınır mallarla belgeler, tarafımdan teslim alınmıştır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField121111.CalcValue = NewField121111.Value;
                    NewField12114111.CalcValue = NewField12114111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11114111.CalcValue = NewField11114111.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    return new TTReportObject[] { NewField1171,NewField121111,NewField12114111,NewField11111,NewField11114111,NewField11711};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HandoverReport2()
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
            Name = "HANDOVERREPORT2";
            Caption = "Taşınır Mal Saymanları Devir ve Teslim Belgesi";
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
#region HANDOVERREPORT2_PreScript
            //                        base.RunPreScript();
//
//            if (this.RuntimeParameters.TTOBJECTID.HasValue)
//                HandoverObject = (HandoverDocument)this.ReportObjectContext.GetObject(this.RuntimeParameters.TTOBJECTID.Value, typeof(HandoverDocument));
#endregion HANDOVERREPORT2_PreScript
        }
    }
}