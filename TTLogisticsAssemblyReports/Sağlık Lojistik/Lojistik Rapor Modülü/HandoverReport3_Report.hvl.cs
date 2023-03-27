
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
    public partial class HandoverReport3 : TTReport
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
            public HandoverReport3 MyParentReport
            {
                get { return (HandoverReport3)ParentReport; }
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
                public HandoverReport3 MyParentReport
                {
                    get { return (HandoverReport3)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField BIRLIKKODU; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 58;
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
                    ReportName.Value = @"İLİŞİKSİZLİK BELGESİ";

                    BIRLIKKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 30, 183, 37, false);
                    BIRLIKKODU.Name = "BIRLIKKODU";
                    BIRLIKKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRLIKKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIKKODU.TextFont.Size = 11;
                    BIRLIKKODU.TextFont.Bold = true;
                    BIRLIKKODU.TextFont.CharSet = 162;
                    BIRLIKKODU.Value = @"TARİH";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    BIRLIKKODU.CalcValue = BIRLIKKODU.Value;
                    return new TTReportObject[] { ReportName,BIRLIKKODU};
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
                public HandoverReport3 MyParentReport
                {
                    get { return (HandoverReport3)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
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
            public HandoverReport3 MyParentReport
            {
                get { return (HandoverReport3)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField NewField1114111 { get {return Footer().NewField1114111;} }
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
                public HandoverReport3 MyParentReport
                {
                    get { return (HandoverReport3)ParentReport; }
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
                public HandoverReport3 MyParentReport
                {
                    get { return (HandoverReport3)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1114111;
                public TTReportField NewField11711; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 66;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 5, 200, 37, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"

İmzası:
Adı Soyadı:
Ünvanı:
";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, -2, 200, 5, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114111.TextFont.Bold = true;
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @"Teslim Alan ";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 38, 200, 66, false);
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

      Harcama Yetkilisi/Birlik XXXXXXı
                     
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    return new TTReportObject[] { NewField1111,NewField1114111,NewField11711};
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
            public HandoverReport3 MyParentReport
            {
                get { return (HandoverReport3)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
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
                public HandoverReport3 MyParentReport
                {
                    get { return (HandoverReport3)ParentReport; }
                }
                
                public TTReportField NewField1171; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 117;
                    RepeatCount = 0;
                    
                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 19, 200, 86, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1171.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1171.TextFont.Size = 11;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"İLGİ  :	(a) ..........................................................................................................

      		     (b) ..........................................................................................................


	             İlgi (a) gereğince ........................ görevinden ayrılan ..........................................ile ilgi (b) gereğince .......................tarihinde devir teslime başlanmış ve  ...................... tarihinde bitirilmiştir.

	            Yapılan devir teslime istinaden ........ sayfadan ibaret belge devir teslim çizelgesi ile  ................................. kalem belge; ........  sayfadan ibaret malzeme devir teslim belgesi ile  ................................. kalem taşınır mal, tamamen sayılmak, tartılmak ve ölçülmek suretiyle aramızda devir teslim edilmiştir. Söz konusu taşınır mallar ile belgeleri eksiksiz olarak teslim aldım. Hiçbir itirazım yoktur. Ayrılan ............................................................................. borçsuzdur.
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1171.CalcValue = NewField1171.Value;
                    return new TTReportObject[] { NewField1171};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HandoverReport3()
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
            Name = "HANDOVERREPORT3";
            Caption = "İlişiksizlik Belgesi";
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
#region HANDOVERREPORT3_PreScript
            //                        base.RunPreScript();
//
//            if (this.RuntimeParameters.TTOBJECTID.HasValue)
//                HandoverObject = (HandoverDocument)this.ReportObjectContext.GetObject(this.RuntimeParameters.TTOBJECTID.Value, typeof(HandoverDocument));
#endregion HANDOVERREPORT3_PreScript
        }
    }
}