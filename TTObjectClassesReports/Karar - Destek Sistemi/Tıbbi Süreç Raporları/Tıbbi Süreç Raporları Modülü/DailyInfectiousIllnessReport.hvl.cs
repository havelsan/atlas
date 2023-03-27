
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
    /// Günlük Sürveyans Formu
    /// </summary>
    public partial class DailyInfectiousIllnessReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public DailyInfectiousIllnessReport MyParentReport
            {
                get { return (DailyInfectiousIllnessReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField FVSTARTDATE1 { get {return Header().FVSTARTDATE1;} }
            public TTReportField FVENDDATE1 { get {return Header().FVENDDATE1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField edate { get {return Header().edate;} }
            public TTReportField sdate { get {return Header().sdate;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField11821 { get {return Header().NewField11821;} }
            public TTReportField NewField112821 { get {return Header().NewField112821;} }
            public TTReportField NewField1128211 { get {return Header().NewField1128211;} }
            public TTReportField NewField11812 { get {return Header().NewField11812;} }
            public TTReportField NewField112811 { get {return Header().NewField112811;} }
            public TTReportField NewField11128211 { get {return Header().NewField11128211;} }
            public TTReportField NewField121811 { get {return Header().NewField121811;} }
            public TTReportField NewField1118211 { get {return Header().NewField1118211;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField lblGenelToplam { get {return Footer().lblGenelToplam;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportField A09BUYUK { get {return Footer().A09BUYUK;} }
            public TTReportField R11KUCUK { get {return Footer().R11KUCUK;} }
            public TTReportField R11BUYUK { get {return Footer().R11BUYUK;} }
            public TTReportField K52KUCUK { get {return Footer().K52KUCUK;} }
            public TTReportField K52BUYUK { get {return Footer().K52BUYUK;} }
            public TTReportField A09KUCUK { get {return Footer().A09KUCUK;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public DailyInfectiousIllnessReport MyParentReport
                {
                    get { return (DailyInfectiousIllnessReport)ParentReport; }
                }
                
                public TTReportField FVSTARTDATE1;
                public TTReportField FVENDDATE1;
                public TTReportField NewField13;
                public TTReportField edate;
                public TTReportField sdate;
                public TTReportShape NewLine12;
                public TTReportField NewField1;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1181;
                public TTReportField NewField11821;
                public TTReportField NewField112821;
                public TTReportField NewField1128211;
                public TTReportField NewField11812;
                public TTReportField NewField112811;
                public TTReportField NewField11128211;
                public TTReportField NewField121811;
                public TTReportField NewField1118211; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 63;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FVSTARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 14, 238, 18, false);
                    FVSTARTDATE1.Name = "FVSTARTDATE1";
                    FVSTARTDATE1.Visible = EvetHayirEnum.ehHayir;
                    FVSTARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FVSTARTDATE1.TextFormat = @"yyyy-mm-dd hh:mm";
                    FVSTARTDATE1.TextFont.Name = "Courier New";
                    FVSTARTDATE1.TextFont.CharSet = 162;
                    FVSTARTDATE1.Value = @"{@STARTDATE@}";

                    FVENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 18, 238, 23, false);
                    FVENDDATE1.Name = "FVENDDATE1";
                    FVENDDATE1.Visible = EvetHayirEnum.ehHayir;
                    FVENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FVENDDATE1.TextFormat = @"yyyy-mm-dd hh:mm";
                    FVENDDATE1.TextFont.Name = "Courier New";
                    FVENDDATE1.TextFont.CharSet = 162;
                    FVENDDATE1.Value = @"{@ENDDATE@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 42, 33, 47, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Tarih Aralığı : ";

                    edate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 42, 72, 47, false);
                    edate.Name = "edate";
                    edate.FieldType = ReportFieldTypeEnum.ftVariable;
                    edate.TextFormat = @"dd/MM/yyyy";
                    edate.TextFont.CharSet = 162;
                    edate.Value = @"{@ENDDATE@}";

                    sdate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 42, 49, 47, false);
                    sdate.Name = "sdate";
                    sdate.FieldType = ReportFieldTypeEnum.ftVariable;
                    sdate.TextFormat = @"dd/MM/yyyy";
                    sdate.TextFont.CharSet = 162;
                    sdate.Value = @"{@STARTDATE@}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 50, 45, 54, 45, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 31, 198, 39, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SU VE BESİNLERLE BULAŞAN HASTALIKLAR SÜRVEYANS FORMU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 7, 198, 30, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 56, 88, 62, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"5 Yaş ve Üzeri";

                    NewField11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 56, 64, 62, false);
                    NewField11821.Name = "NewField11821";
                    NewField11821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11821.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11821.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11821.TextFont.Size = 9;
                    NewField11821.TextFont.Bold = true;
                    NewField11821.TextFont.CharSet = 162;
                    NewField11821.Value = @"0-59 Aylık";

                    NewField112821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 88, 56, false);
                    NewField112821.Name = "NewField112821";
                    NewField112821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112821.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112821.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112821.TextFont.Size = 9;
                    NewField112821.TextFont.Bold = true;
                    NewField112821.TextFont.CharSet = 162;
                    NewField112821.Value = @"A09";

                    NewField1128211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 50, 136, 56, false);
                    NewField1128211.Name = "NewField1128211";
                    NewField1128211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1128211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1128211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1128211.TextFont.Size = 9;
                    NewField1128211.TextFont.Bold = true;
                    NewField1128211.TextFont.CharSet = 162;
                    NewField1128211.Value = @"R11";

                    NewField11812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 56, 136, 62, false);
                    NewField11812.Name = "NewField11812";
                    NewField11812.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11812.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11812.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11812.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11812.TextFont.Size = 9;
                    NewField11812.TextFont.Bold = true;
                    NewField11812.TextFont.CharSet = 162;
                    NewField11812.Value = @"5 Yaş ve Üzeri";

                    NewField112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 56, 112, 62, false);
                    NewField112811.Name = "NewField112811";
                    NewField112811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112811.TextFont.Size = 9;
                    NewField112811.TextFont.Bold = true;
                    NewField112811.TextFont.CharSet = 162;
                    NewField112811.Value = @"0-59 Aylık";

                    NewField11128211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 50, 184, 56, false);
                    NewField11128211.Name = "NewField11128211";
                    NewField11128211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11128211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11128211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11128211.TextFont.Size = 9;
                    NewField11128211.TextFont.Bold = true;
                    NewField11128211.TextFont.CharSet = 162;
                    NewField11128211.Value = @"K52";

                    NewField121811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 56, 184, 62, false);
                    NewField121811.Name = "NewField121811";
                    NewField121811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121811.TextFont.Size = 9;
                    NewField121811.TextFont.Bold = true;
                    NewField121811.TextFont.CharSet = 162;
                    NewField121811.Value = @"5 Yaş ve Üzeri";

                    NewField1118211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 56, 160, 62, false);
                    NewField1118211.Name = "NewField1118211";
                    NewField1118211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1118211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1118211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1118211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1118211.TextFont.Size = 9;
                    NewField1118211.TextFont.Bold = true;
                    NewField1118211.TextFont.CharSet = 162;
                    NewField1118211.Value = @"0-59 Aylık";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FVSTARTDATE1.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    FVENDDATE1.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField13.CalcValue = NewField13.Value;
                    edate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    sdate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField11821.CalcValue = NewField11821.Value;
                    NewField112821.CalcValue = NewField112821.Value;
                    NewField1128211.CalcValue = NewField1128211.Value;
                    NewField11812.CalcValue = NewField11812.Value;
                    NewField112811.CalcValue = NewField112811.Value;
                    NewField11128211.CalcValue = NewField11128211.Value;
                    NewField121811.CalcValue = NewField121811.Value;
                    NewField1118211.CalcValue = NewField1118211.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { FVSTARTDATE1,FVENDDATE1,NewField13,edate,sdate,NewField1,NewField1181,NewField11821,NewField112821,NewField1128211,NewField11812,NewField112811,NewField11128211,NewField121811,NewField1118211,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    TTReportTool.TTReportGroup g = ((DailyInfectiousIllnessReport)ParentReport).Groups("HEADER");
            g.Fields("A09KUCUK").Value = "0";
            g.Fields("A09BUYUK").Value = "0";
            g.Fields("R11KUCUK").Value = "0";
            g.Fields("R11BUYUK").Value = "0";
            g.Fields("K52KUCUK").Value = "0";
            g.Fields("K52BUYUK").Value = "0";
#endregion HEADER HEADER_PreScript
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public DailyInfectiousIllnessReport MyParentReport
                {
                    get { return (DailyInfectiousIllnessReport)ParentReport; }
                }
                
                public TTReportField TOPLAM;
                public TTReportField lblGenelToplam;
                public TTReportField GENELTOPLAM;
                public TTReportField A09BUYUK;
                public TTReportField R11KUCUK;
                public TTReportField R11BUYUK;
                public TTReportField K52KUCUK;
                public TTReportField K52BUYUK;
                public TTReportField A09KUCUK; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 40, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.TextFont.Size = 9;
                    TOPLAM.TextFont.Bold = true;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"TOPLAM";

                    lblGenelToplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 5, 40, 10, false);
                    lblGenelToplam.Name = "lblGenelToplam";
                    lblGenelToplam.DrawStyle = DrawStyleConstants.vbSolid;
                    lblGenelToplam.TextFont.Size = 9;
                    lblGenelToplam.TextFont.Bold = true;
                    lblGenelToplam.TextFont.CharSet = 162;
                    lblGenelToplam.Value = @"GENEL TOPLAM";

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 5, 64, 10, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOPLAM.TextFont.Size = 9;
                    GENELTOPLAM.TextFont.Bold = true;
                    GENELTOPLAM.TextFont.CharSet = 162;
                    GENELTOPLAM.Value = @"0";

                    A09BUYUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 88, 5, false);
                    A09BUYUK.Name = "A09BUYUK";
                    A09BUYUK.DrawStyle = DrawStyleConstants.vbSolid;
                    A09BUYUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A09BUYUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A09BUYUK.TextFont.Size = 9;
                    A09BUYUK.TextFont.CharSet = 162;
                    A09BUYUK.Value = @"0";

                    R11KUCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 112, 5, false);
                    R11KUCUK.Name = "R11KUCUK";
                    R11KUCUK.DrawStyle = DrawStyleConstants.vbSolid;
                    R11KUCUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11KUCUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    R11KUCUK.TextFont.Size = 9;
                    R11KUCUK.TextFont.CharSet = 162;
                    R11KUCUK.Value = @"0";

                    R11BUYUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 136, 5, false);
                    R11BUYUK.Name = "R11BUYUK";
                    R11BUYUK.DrawStyle = DrawStyleConstants.vbSolid;
                    R11BUYUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11BUYUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    R11BUYUK.TextFont.Size = 9;
                    R11BUYUK.TextFont.CharSet = 162;
                    R11BUYUK.Value = @"0";

                    K52KUCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 160, 5, false);
                    K52KUCUK.Name = "K52KUCUK";
                    K52KUCUK.DrawStyle = DrawStyleConstants.vbSolid;
                    K52KUCUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K52KUCUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    K52KUCUK.TextFont.Size = 9;
                    K52KUCUK.TextFont.CharSet = 162;
                    K52KUCUK.Value = @"0";

                    K52BUYUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 184, 5, false);
                    K52BUYUK.Name = "K52BUYUK";
                    K52BUYUK.DrawStyle = DrawStyleConstants.vbSolid;
                    K52BUYUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K52BUYUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    K52BUYUK.TextFont.Size = 9;
                    K52BUYUK.TextFont.CharSet = 162;
                    K52BUYUK.Value = @"0";

                    A09KUCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 64, 5, false);
                    A09KUCUK.Name = "A09KUCUK";
                    A09KUCUK.DrawStyle = DrawStyleConstants.vbSolid;
                    A09KUCUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A09KUCUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A09KUCUK.TextFont.Size = 9;
                    A09KUCUK.TextFont.CharSet = 162;
                    A09KUCUK.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAM.CalcValue = TOPLAM.Value;
                    lblGenelToplam.CalcValue = lblGenelToplam.Value;
                    GENELTOPLAM.CalcValue = GENELTOPLAM.Value;
                    A09BUYUK.CalcValue = A09BUYUK.Value;
                    R11KUCUK.CalcValue = R11KUCUK.Value;
                    R11BUYUK.CalcValue = R11BUYUK.Value;
                    K52KUCUK.CalcValue = K52KUCUK.Value;
                    K52BUYUK.CalcValue = K52BUYUK.Value;
                    A09KUCUK.CalcValue = A09KUCUK.Value;
                    return new TTReportObject[] { TOPLAM,lblGenelToplam,GENELTOPLAM,A09BUYUK,R11KUCUK,R11BUYUK,K52KUCUK,K52BUYUK,A09KUCUK};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class SUBAYGroup : TTReportGroup
        {
            public DailyInfectiousIllnessReport MyParentReport
            {
                get { return (DailyInfectiousIllnessReport)ParentReport; }
            }

            new public SUBAYGroupHeader Header()
            {
                return (SUBAYGroupHeader)_header;
            }

            new public SUBAYGroupFooter Footer()
            {
                return (SUBAYGroupFooter)_footer;
            }

            public TTReportField DIAGNOSEDATE { get {return Footer().DIAGNOSEDATE;} }
            public TTReportField A09BUYUK { get {return Footer().A09BUYUK;} }
            public TTReportField R11KUCUK { get {return Footer().R11KUCUK;} }
            public TTReportField R11BUYUK { get {return Footer().R11BUYUK;} }
            public TTReportField K52KUCUK { get {return Footer().K52KUCUK;} }
            public TTReportField K52BUYUK { get {return Footer().K52BUYUK;} }
            public TTReportField A09KUCUK { get {return Footer().A09KUCUK;} }
            public SUBAYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SUBAYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class>("GetInfectiousDiagnosisByDate", DiagnosisGrid.GetInfectiousDiagnosisByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SUBAYGroupHeader(this);
                _footer = new SUBAYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class SUBAYGroupHeader : TTReportSection
            {
                public DailyInfectiousIllnessReport MyParentReport
                {
                    get { return (DailyInfectiousIllnessReport)ParentReport; }
                }
                 
                public SUBAYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
                public override void RunPreScript()
                {
#region SUBAY HEADER_PreScript
                    TTReportTool.TTReportGroup pg = ((DailyInfectiousIllnessReport)ParentReport).Groups("SUBAY");
            pg.Fields("A09KUCUK").Value = "0";
            pg.Fields("A09BUYUK").Value = "0";
            pg.Fields("R11KUCUK").Value = "0";
            pg.Fields("R11BUYUK").Value = "0";
            pg.Fields("K52KUCUK").Value = "0";
            pg.Fields("K52BUYUK").Value = "0";
#endregion SUBAY HEADER_PreScript
                }
            }
            public partial class SUBAYGroupFooter : TTReportSection
            {
                public DailyInfectiousIllnessReport MyParentReport
                {
                    get { return (DailyInfectiousIllnessReport)ParentReport; }
                }
                
                public TTReportField DIAGNOSEDATE;
                public TTReportField A09BUYUK;
                public TTReportField R11KUCUK;
                public TTReportField R11BUYUK;
                public TTReportField K52KUCUK;
                public TTReportField K52BUYUK;
                public TTReportField A09KUCUK; 
                public SUBAYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 40, 5, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.TextFormat = @"dd/MM/yyyy";
                    DIAGNOSEDATE.TextFont.Size = 9;
                    DIAGNOSEDATE.TextFont.Bold = true;
                    DIAGNOSEDATE.TextFont.CharSet = 162;
                    DIAGNOSEDATE.Value = @"{#TANITARIHI#}";

                    A09BUYUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 88, 5, false);
                    A09BUYUK.Name = "A09BUYUK";
                    A09BUYUK.DrawStyle = DrawStyleConstants.vbSolid;
                    A09BUYUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A09BUYUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A09BUYUK.TextFont.Size = 9;
                    A09BUYUK.TextFont.CharSet = 162;
                    A09BUYUK.Value = @"0";

                    R11KUCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 112, 5, false);
                    R11KUCUK.Name = "R11KUCUK";
                    R11KUCUK.DrawStyle = DrawStyleConstants.vbSolid;
                    R11KUCUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11KUCUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    R11KUCUK.TextFont.Size = 9;
                    R11KUCUK.TextFont.CharSet = 162;
                    R11KUCUK.Value = @"0";

                    R11BUYUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 136, 5, false);
                    R11BUYUK.Name = "R11BUYUK";
                    R11BUYUK.DrawStyle = DrawStyleConstants.vbSolid;
                    R11BUYUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    R11BUYUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    R11BUYUK.TextFont.Size = 9;
                    R11BUYUK.TextFont.CharSet = 162;
                    R11BUYUK.Value = @"0";

                    K52KUCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 160, 5, false);
                    K52KUCUK.Name = "K52KUCUK";
                    K52KUCUK.DrawStyle = DrawStyleConstants.vbSolid;
                    K52KUCUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K52KUCUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    K52KUCUK.TextFont.Size = 9;
                    K52KUCUK.TextFont.CharSet = 162;
                    K52KUCUK.Value = @"0";

                    K52BUYUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 184, 5, false);
                    K52BUYUK.Name = "K52BUYUK";
                    K52BUYUK.DrawStyle = DrawStyleConstants.vbSolid;
                    K52BUYUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K52BUYUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    K52BUYUK.TextFont.Size = 9;
                    K52BUYUK.TextFont.CharSet = 162;
                    K52BUYUK.Value = @"0";

                    A09KUCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 64, 5, false);
                    A09KUCUK.Name = "A09KUCUK";
                    A09KUCUK.DrawStyle = DrawStyleConstants.vbSolid;
                    A09KUCUK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A09KUCUK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A09KUCUK.TextFont.Size = 9;
                    A09KUCUK.TextFont.CharSet = 162;
                    A09KUCUK.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetInfectiousDiagnosisByDate_Class dataset_GetInfectiousDiagnosisByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class>(0);
                    DIAGNOSEDATE.CalcValue = (dataset_GetInfectiousDiagnosisByDate != null ? Globals.ToStringCore(dataset_GetInfectiousDiagnosisByDate.Tanitarihi) : "");
                    A09BUYUK.CalcValue = A09BUYUK.Value;
                    R11KUCUK.CalcValue = R11KUCUK.Value;
                    R11BUYUK.CalcValue = R11BUYUK.Value;
                    K52KUCUK.CalcValue = K52KUCUK.Value;
                    K52BUYUK.CalcValue = K52BUYUK.Value;
                    A09KUCUK.CalcValue = A09KUCUK.Value;
                    return new TTReportObject[] { DIAGNOSEDATE,A09BUYUK,R11KUCUK,R11BUYUK,K52KUCUK,K52BUYUK,A09KUCUK};
                }
            }

        }

        public SUBAYGroup SUBAY;

        public partial class MAINGroup : TTReportGroup
        {
            public DailyInfectiousIllnessReport MyParentReport
            {
                get { return (DailyInfectiousIllnessReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField GRP { get {return Body().GRP;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                DiagnosisGrid.GetInfectiousDiagnosisByDate_Class dataSet_GetInfectiousDiagnosisByDate = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class>(0);    
                return new object[] {(dataSet_GetInfectiousDiagnosisByDate==null ? null : dataSet_GetInfectiousDiagnosisByDate.Tanitarihi)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public DailyInfectiousIllnessReport MyParentReport
                {
                    get { return (DailyInfectiousIllnessReport)ParentReport; }
                }
                
                public TTReportField GRP;
                public TTReportField COUNT;
                public TTReportField BIRTHDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    GRP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 57, 6, false);
                    GRP.Name = "GRP";
                    GRP.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRP.TextFont.Name = "Courier New";
                    GRP.TextFont.CharSet = 162;
                    GRP.Value = @"{#SUBAY.CODE#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 1, 92, 6, false);
                    COUNT.Name = "COUNT";
                    COUNT.TextFont.Name = "Courier New";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"1";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 1, 127, 6, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"dd/MM/yyyy";
                    BIRTHDATE.TextFont.Name = "Courier New";
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{#SUBAY.BIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetInfectiousDiagnosisByDate_Class dataset_GetInfectiousDiagnosisByDate = MyParentReport.SUBAY.rsGroup.GetCurrentRecord<DiagnosisGrid.GetInfectiousDiagnosisByDate_Class>(0);
                    GRP.CalcValue = (dataset_GetInfectiousDiagnosisByDate != null ? Globals.ToStringCore(dataset_GetInfectiousDiagnosisByDate.Code) : "");
                    COUNT.CalcValue = COUNT.Value;
                    BIRTHDATE.CalcValue = (dataset_GetInfectiousDiagnosisByDate != null ? Globals.ToStringCore(dataset_GetInfectiousDiagnosisByDate.BirthDate) : "");
                    return new TTReportObject[] { GRP,COUNT,BIRTHDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            TTReportTool.TTReportGroup g = ((DailyInfectiousIllnessReport)ParentReport).Groups("HEADER");
            TTReportTool.TTReportGroup pg = ((DailyInfectiousIllnessReport)ParentReport).Groups("SUBAY");
            int ageMonth;
            DateTime now = TTObjectDefManager.ServerTime;
            if(this.BIRTHDATE.CalcValue != "")
            {
                DateTime birthDate = Convert.ToDateTime(this.BIRTHDATE.CalcValue);
                ageMonth = (int)TTObjectClasses.Common.DateDiff(TTObjectClasses.Common.DateIntervalEnum.Month, now, birthDate);
            }
            else
                ageMonth = 0;
            
            string diagnoseCode = this.GRP.CalcValue;
            switch(diagnoseCode)
            {
                case "A09":
                    {
                        if(ageMonth < 60)
                        {
                            pg.Fields("A09KUCUK").Value = (Convert.ToInt32(pg.Fields("A09KUCUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("A09KUCUK").Value = (Convert.ToInt32(g.Fields("A09KUCUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        }
                        else
                        {
                            pg.Fields("A09BUYUK").Value = (Convert.ToInt32(pg.Fields("A09BUYUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("A09BUYUK").Value = (Convert.ToInt32(g.Fields("A09BUYUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();                        
                        }
                    }
                    break;
                case "R11":
                    {
                        if(ageMonth < 60)
                        {
                            pg.Fields("R11KUCUK").Value = (Convert.ToInt32(pg.Fields("R11KUCUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("R11KUCUK").Value = (Convert.ToInt32(g.Fields("R11KUCUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        }
                        else
                        {
                            pg.Fields("R11BUYUK").Value = (Convert.ToInt32(pg.Fields("R11BUYUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("R11BUYUK").Value = (Convert.ToInt32(g.Fields("R11BUYUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();                        
                        }                        
                    }
                    break;
                case "K52.8":
                case "K52.9":
                    {
                        if(ageMonth < 60)
                        {
                            pg.Fields("K52KUCUK").Value = (Convert.ToInt32(pg.Fields("K52KUCUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("K52KUCUK").Value = (Convert.ToInt32(g.Fields("K52KUCUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        }
                        else
                        {
                            pg.Fields("K52BUYUK").Value = (Convert.ToInt32(pg.Fields("K52BUYUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                            g.Fields("K52BUYUK").Value = (Convert.ToInt32(g.Fields("K52BUYUK").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();                        
                        }
                    }
                    break;
                default:
                    break;
            }
            
            g.Fields("GENELTOPLAM").Value = (Convert.ToInt32(g.Fields("GENELTOPLAM").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
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

        public DailyInfectiousIllnessReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            SUBAY = new SUBAYGroup(HEADER,"SUBAY");
            MAIN = new MAINGroup(SUBAY,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "DAILYINFECTIOUSILLNESSREPORT";
            Caption = "Günlük Sürveyans Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginTop = 10;
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