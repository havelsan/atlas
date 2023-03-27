
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
    /// Sağlık Kurulu Rapor Onayı Yazısı (XXXXXX)
    /// </summary>
    public partial class HealthCommitteeApprovalReports1 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public int? COUNTER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PART3Group : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public PART3GroupBody Body()
            {
                return (PART3GroupBody)_body;
            }
            public PART3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PART3GroupBody(this);
            }

            public partial class PART3GroupBody : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                 
                public PART3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PART3 BODY_Script
                    ((HealthCommitteeApprovalReports1)ParentReport).RuntimeParameters.COUNTER = 0;
#endregion PART3 BODY_Script
                }
            }

        }

        public PART3Group PART3;

        public partial class PART2Group : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public PART2GroupBody Body()
            {
                return (PART2GroupBody)_body;
            }
            public PART2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>("GetApprovalHCsByDate", HealthCommittee.GetXXXXXXApprovalHCsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PART2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART2GroupBody : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                 
                public PART2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PART2 BODY_Script
                    ((HealthCommitteeApprovalReports1)ParentReport).RuntimeParameters.COUNTER = ((HealthCommitteeApprovalReports1)ParentReport).RuntimeParameters.COUNTER + 1;
#endregion PART2 BODY_Script
                }
            }

        }

        public PART2Group PART2;

        public partial class PART1Group : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField1291 { get {return Header().NewField1291;} }
            public TTReportField NewField11921 { get {return Header().NewField11921;} }
            public TTReportField DOSYANO { get {return Header().DOSYANO;} }
            public TTReportField NewField12911 { get {return Header().NewField12911;} }
            public TTReportField NewField13911 { get {return Header().NewField13911;} }
            public TTReportField NewField14911 { get {return Header().NewField14911;} }
            public TTReportField ACIKLAMA { get {return Header().ACIKLAMA;} }
            public TTReportField ONAY { get {return Header().ONAY;} }
            public TTReportField ONAYTITLE { get {return Header().ONAYTITLE;} }
            public TTReportField BASTABIP11 { get {return Header().BASTABIP11;} }
            public TTReportField EK { get {return Header().EK;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField TARIH;
                public TTReportField NewField191;
                public TTReportField NewField1191;
                public TTReportField NewField1291;
                public TTReportField NewField11921;
                public TTReportField DOSYANO;
                public TTReportField NewField12911;
                public TTReportField NewField13911;
                public TTReportField NewField14911;
                public TTReportField ACIKLAMA;
                public TTReportField ONAY;
                public TTReportField ONAYTITLE;
                public TTReportField BASTABIP11;
                public TTReportField EK;
                public TTReportField NewField11;
                public TTReportField NewField111; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 298;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 17, 186, 40, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 42, 186, 48, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TARIH.TextFont.Size = 11;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{@printdate@}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 37, 48, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Size = 11;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"SAĞLIK KURULU";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 37, 54, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Size = 11;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"KONU";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 48, 39, 54, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.TextFont.Size = 11;
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @":";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 42, 39, 48, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.TextFont.Size = 11;
                    NewField11921.TextFont.CharSet = 162;
                    NewField11921.Value = @":";

                    DOSYANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 42, 150, 48, false);
                    DOSYANO.Name = "DOSYANO";
                    DOSYANO.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOSYANO.TextFont.Size = 11;
                    DOSYANO.TextFont.CharSet = 162;
                    DOSYANO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HCAPPROVALREPORTXXXXXXREPORTNO"","""")";

                    NewField12911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 48, 90, 54, false);
                    NewField12911.Name = "NewField12911";
                    NewField12911.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12911.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12911.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12911.TextFont.Size = 11;
                    NewField12911.TextFont.CharSet = 162;
                    NewField12911.Value = @"Rapor Onayı";

                    NewField13911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 71, 151, 77, false);
                    NewField13911.Name = "NewField13911";
                    NewField13911.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField13911.TextFont.Size = 11;
                    NewField13911.TextFont.CharSet = 162;
                    NewField13911.Value = @"XXXXXX SAĞLIK HİZMETLERİ DAİRE RAPOR ŞUBE MÜDÜRLÜĞÜNE";

                    NewField14911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 78, 151, 84, false);
                    NewField14911.Name = "NewField14911";
                    NewField14911.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField14911.TextFont.Size = 11;
                    NewField14911.TextFont.CharSet = 162;
                    NewField14911.Value = @"XXXXXX";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 90, 186, 104, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Size = 11;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"Aşağıda rapor numaraları yazılı ({@COUNTER@}) şahsa ait raporlar onaylanmak üzere ekte gönderilmiştir.";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 120, 185, 125, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftExpression;
                    ONAY.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Courier New";
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"","""")";

                    ONAYTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 125, 185, 130, false);
                    ONAYTITLE.Name = "ONAYTITLE";
                    ONAYTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ONAYTITLE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ONAYTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYTITLE.TextFont.Name = "Courier New";
                    ONAYTITLE.TextFont.CharSet = 162;
                    ONAYTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTORTITAL"","""")";

                    BASTABIP11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 130, 185, 135, false);
                    BASTABIP11.Name = "BASTABIP11";
                    BASTABIP11.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASTABIP11.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP11.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP11.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASTABIP11.TextFont.Name = "Courier New";
                    BASTABIP11.TextFont.CharSet = 162;
                    BASTABIP11.Value = @"BAŞTABİP";

                    EK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 201, 62, 211, false);
                    EK.Name = "EK";
                    EK.FieldType = ReportFieldTypeEnum.ftVariable;
                    EK.MultiLine = EvetHayirEnum.ehEvet;
                    EK.NoClip = EvetHayirEnum.ehEvet;
                    EK.WordBreak = EvetHayirEnum.ehEvet;
                    EK.ExpandTabs = EvetHayirEnum.ehEvet;
                    EK.Value = @"EKİ     :
({@COUNTER@} Adet Sağlık Raporu)";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 35, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"HİZMETE ÖZEL";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 285, 35, 290, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TARIH.CalcValue = DateTime.Now.ToShortDateString();
                    NewField191.CalcValue = NewField191.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField11921.CalcValue = NewField11921.Value;
                    NewField12911.CalcValue = NewField12911.Value;
                    NewField13911.CalcValue = NewField13911.Value;
                    NewField14911.CalcValue = NewField14911.Value;
                    ACIKLAMA.CalcValue = @"Aşağıda rapor numaraları yazılı (" + MyParentReport.RuntimeParameters.COUNTER.ToString() + @") şahsa ait raporlar onaylanmak üzere ekte gönderilmiştir.";
                    BASTABIP11.CalcValue = BASTABIP11.Value;
                    EK.CalcValue = @"EKİ     :
(" + MyParentReport.RuntimeParameters.COUNTER.ToString() + @" Adet Sağlık Raporu)";
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    DOSYANO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HCAPPROVALREPORTXXXXXXREPORTNO","");
                    ONAY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","");
                    ONAYTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL","");
                    return new TTReportObject[] { TARIH,NewField191,NewField1191,NewField1291,NewField11921,NewField12911,NewField13911,NewField14911,ACIKLAMA,BASTABIP11,EK,NewField11,NewField111,XXXXXXBASLIK,DOSYANO,ONAY,ONAYTITLE};
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PART1Group PART1;

        public partial class PARTCGroup : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

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
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
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
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField HASTAADI111 { get {return Header().HASTAADI111;} }
            public TTReportField RAPORNO111 { get {return Header().RAPORNO111;} }
            public TTReportField TCKIMLIKNO111 { get {return Header().TCKIMLIKNO111;} }
            public TTReportField RAPORTARIHI111 { get {return Header().RAPORTARIHI111;} }
            public TTReportField HASTAADI1111 { get {return Header().HASTAADI1111;} }
            public TTReportField HASTAADI1211 { get {return Header().HASTAADI1211;} }
            public TTReportField HASTAADI1311 { get {return Header().HASTAADI1311;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1211 { get {return Footer().NewField1211;} }
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
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField HASTAADI111;
                public TTReportField RAPORNO111;
                public TTReportField TCKIMLIKNO111;
                public TTReportField RAPORTARIHI111;
                public TTReportField HASTAADI1111;
                public TTReportField HASTAADI1211;
                public TTReportField HASTAADI1311;
                public TTReportField NewField1111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 24, 205, 24, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    HASTAADI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 18, 100, 23, false);
                    HASTAADI111.Name = "HASTAADI111";
                    HASTAADI111.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI111.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI111.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI111.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI111.TextFont.Bold = true;
                    HASTAADI111.TextFont.CharSet = 162;
                    HASTAADI111.Value = @"Adı Soyadı";

                    RAPORNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 18, 180, 23, false);
                    RAPORNO111.Name = "RAPORNO111";
                    RAPORNO111.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO111.NoClip = EvetHayirEnum.ehEvet;
                    RAPORNO111.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO111.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO111.TextFont.Bold = true;
                    RAPORNO111.TextFont.CharSet = 162;
                    RAPORNO111.Value = @"Rapor Nu";

                    TCKIMLIKNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 18, 128, 23, false);
                    TCKIMLIKNO111.Name = "TCKIMLIKNO111";
                    TCKIMLIKNO111.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO111.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO111.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO111.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO111.TextFont.Bold = true;
                    TCKIMLIKNO111.TextFont.CharSet = 162;
                    TCKIMLIKNO111.Value = @"TC Kimlik Nu";

                    RAPORTARIHI111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 18, 205, 23, false);
                    RAPORTARIHI111.Name = "RAPORTARIHI111";
                    RAPORTARIHI111.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI111.NoClip = EvetHayirEnum.ehEvet;
                    RAPORTARIHI111.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI111.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORTARIHI111.TextFont.Bold = true;
                    RAPORTARIHI111.TextFont.CharSet = 162;
                    RAPORTARIHI111.Value = @"Rapor Tarihi";

                    HASTAADI1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 26, 23, false);
                    HASTAADI1111.Name = "HASTAADI1111";
                    HASTAADI1111.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI1111.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI1111.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI1111.TextFont.Bold = true;
                    HASTAADI1111.TextFont.CharSet = 162;
                    HASTAADI1111.Value = @"Sıra No";

                    HASTAADI1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 18, 59, 23, false);
                    HASTAADI1211.Name = "HASTAADI1211";
                    HASTAADI1211.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI1211.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI1211.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI1211.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI1211.TextFont.Bold = true;
                    HASTAADI1211.TextFont.CharSet = 162;
                    HASTAADI1211.Value = @"Sınıf Rütbe";

                    HASTAADI1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 18, 154, 23, false);
                    HASTAADI1311.Name = "HASTAADI1311";
                    HASTAADI1311.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI1311.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI1311.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI1311.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI1311.TextFont.Bold = true;
                    HASTAADI1311.TextFont.CharSet = 162;
                    HASTAADI1311.Value = @"Baba Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 35, 15, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.Underline = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HASTAADI111.CalcValue = HASTAADI111.Value;
                    RAPORNO111.CalcValue = RAPORNO111.Value;
                    TCKIMLIKNO111.CalcValue = TCKIMLIKNO111.Value;
                    RAPORTARIHI111.CalcValue = RAPORTARIHI111.Value;
                    HASTAADI1111.CalcValue = HASTAADI1111.Value;
                    HASTAADI1211.CalcValue = HASTAADI1211.Value;
                    HASTAADI1311.CalcValue = HASTAADI1311.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    return new TTReportObject[] { HASTAADI111,RAPORNO111,TCKIMLIKNO111,RAPORTARIHI111,HASTAADI1111,HASTAADI1211,HASTAADI1311,NewField1111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                
                public TTReportField NewField1211; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 35, 6, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.Underline = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1211.CalcValue = NewField1211.Value;
                    return new TTReportObject[] { NewField1211};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeApprovalReports1 MyParentReport
            {
                get { return (HealthCommitteeApprovalReports1)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField SINIFRUT { get {return Body().SINIFRUT;} }
            public TTReportField TITLE { get {return Body().TITLE;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public TTReportField CLASS { get {return Body().CLASS;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField PATIENTGROUP { get {return Body().PATIENTGROUP;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>("GetXXXXXXApprovalHCsByDate", HealthCommittee.GetXXXXXXApprovalHCsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public HealthCommitteeApprovalReports1 MyParentReport
                {
                    get { return (HealthCommitteeApprovalReports1)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportField SINIFRUT;
                public TTReportField TITLE;
                public TTReportField RANK;
                public TTReportField CLASS;
                public TTReportField HASTAADI;
                public TTReportField RAPORNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField RAPORTARIHI;
                public TTReportField SIRANO;
                public TTReportField SINIFRUTBE;
                public TTReportField BABAADI;
                public TTReportField TTOBJECTID;
                public TTReportField PATIENTGROUP; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 22;
                    RepeatCount = 0;
                    
                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 243, 6, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.Visible = EvetHayirEnum.ehHayir;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"";

                    SINIFRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 5, 243, 9, false);
                    SINIFRUT.Name = "SINIFRUT";
                    SINIFRUT.Visible = EvetHayirEnum.ehHayir;
                    SINIFRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUT.TextFont.Size = 9;
                    SINIFRUT.TextFont.CharSet = 162;
                    SINIFRUT.Value = @"";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 9, 243, 13, false);
                    TITLE.Name = "TITLE";
                    TITLE.Visible = EvetHayirEnum.ehHayir;
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.TextFont.Size = 9;
                    TITLE.TextFont.CharSet = 162;
                    TITLE.Value = @"";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 1, 263, 6, false);
                    RANK.Name = "RANK";
                    RANK.Visible = EvetHayirEnum.ehHayir;
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.Value = @"";

                    CLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 1, 281, 6, false);
                    CLASS.Name = "CLASS";
                    CLASS.Visible = EvetHayirEnum.ehHayir;
                    CLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASS.Value = @"";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 1, 100, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 1, 180, 6, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.NoClip = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 128, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 205, 6, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.CharSet = 162;
                    RAPORTARIHI.Value = @"{#REPORTDATE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 26, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 59, 6, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.NoClip = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.CharSet = 162;
                    SINIFRUTBE.Value = @"";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 1, 154, 6, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.MultiLine = EvetHayirEnum.ehEvet;
                    BABAADI.NoClip = EvetHayirEnum.ehEvet;
                    BABAADI.WordBreak = EvetHayirEnum.ehEvet;
                    BABAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BABAADI.TextFont.CharSet = 162;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 1, 335, 6, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.Value = @"{#TTOBJECTID#}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 59, 6, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.Visible = EvetHayirEnum.ehHayir;
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP.Value = @"{#PATIENTGROUP#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetXXXXXXApprovalHCsByDate_Class dataset_GetXXXXXXApprovalHCsByDate = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetXXXXXXApprovalHCsByDate_Class>(0);
                    ADSOYAD.CalcValue = @"";
                    SINIFRUT.CalcValue = @"";
                    TITLE.CalcValue = @"";
                    RANK.CalcValue = @"";
                    CLASS.CalcValue = @"";
                    HASTAADI.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.Patientname) : "");
                    RAPORNO.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.ReportNo) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.UniqueRefNo) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.ReportDate) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    SINIFRUTBE.CalcValue = @"";
                    BABAADI.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.FatherName) : "");
                    TTOBJECTID.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.Ttobjectid) : "");
                    PATIENTGROUP.CalcValue = (dataset_GetXXXXXXApprovalHCsByDate != null ? Globals.ToStringCore(dataset_GetXXXXXXApprovalHCsByDate.Patientgroup) : "");
                    PATIENTGROUP.PostFieldValueCalculation();
                    return new TTReportObject[] { ADSOYAD,SINIFRUT,TITLE,RANK,CLASS,HASTAADI,RAPORNO,TCKIMLIKNO,RAPORTARIHI,SIRANO,SINIFRUTBE,BABAADI,TTOBJECTID,PATIENTGROUP};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    /*
            string sHeadID = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");
            TTObjectContext context = new TTObjectContext(true);
            ResUser head = (ResUser)context.GetObject(new Guid(sHeadID), "ResUser");
            
            this.ADSOYAD.CalcValue = head.Name;
            string sClassRank = head.MilitaryClass != null ? head.MilitaryClass.Name : "";
            sClassRank += " " + head.Rank != null ? head.Rank.Name : "";
            this.SINIFRUT.CalcValue = sClassRank;
            this.TITLE.CalcValue = head.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(head.Title.Value) : "";
             */
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = this.TTOBJECTID.CalcValue;
//            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
//            if(string.IsNullOrEmpty(this.RANK.CalcValue) && string.IsNullOrEmpty(this.CLASS.CalcValue)){
//                this.SINIFRUTBE.Visible = EvetHayirEnum.ehHayir;
//                this.PATIENTGROUP.Visible = EvetHayirEnum.ehEvet;
//            }
//            else
//            {
//                this.SINIFRUTBE.CalcValue = this.CLASS.CalcValue + " " + this.RANK.CalcValue;
//                this.SINIFRUTBE.Visible = EvetHayirEnum.ehEvet;
//                this.PATIENTGROUP.Visible = EvetHayirEnum.ehHayir;
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

        public HealthCommitteeApprovalReports1()
        {
            PART3 = new PART3Group(this,"PART3");
            PART2 = new PART2Group(this,"PART2");
            PART1 = new PART1Group(this,"PART1");
            PARTC = new PARTCGroup(PART1,"PARTC");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            PARTB = new PARTBGroup(PART1,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("COUNTER", "", "Sayaç", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("COUNTER"))
                _runtimeParameters.COUNTER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["COUNTER"]);
            Name = "HEALTHCOMMITTEEAPPROVALREPORTS1";
            Caption = "Sağlık Kurulu Rapor Onayı Yazısı (XXXXXX)";
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