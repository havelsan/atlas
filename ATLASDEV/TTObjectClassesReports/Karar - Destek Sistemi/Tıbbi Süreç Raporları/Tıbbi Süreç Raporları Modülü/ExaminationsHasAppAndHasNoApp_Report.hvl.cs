
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
    /// Randevu Durumuna Göre Günlük Sağlık Faaliyetleri (Ayaktan Hasta)
    /// </summary>
    public partial class ExaminationsHasAppAndHasNoApp : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? SELECTEDRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ExaminationsHasAppAndHasNoApp MyParentReport
            {
                get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
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
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField112811 { get {return Header().NewField112811;} }
            public TTReportField NewField112821 { get {return Header().NewField112821;} }
            public TTReportField NewField1128211 { get {return Header().NewField1128211;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField lblGenelToplam { get {return Footer().lblGenelToplam;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportField RANDEVUSUZ { get {return Footer().RANDEVUSUZ;} }
            public TTReportField RANDEVULU { get {return Footer().RANDEVULU;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
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
                public ExaminationsHasAppAndHasNoApp MyParentReport
                {
                    get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
                }
                
                public TTReportField FVSTARTDATE1;
                public TTReportField FVENDDATE1;
                public TTReportField NewField13;
                public TTReportField edate;
                public TTReportField sdate;
                public TTReportShape NewLine12;
                public TTReportField NewField1;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField112811;
                public TTReportField NewField112821;
                public TTReportField NewField1128211;
                public TTReportField NewField2; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FVSTARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 17, 214, 21, false);
                    FVSTARTDATE1.Name = "FVSTARTDATE1";
                    FVSTARTDATE1.Visible = EvetHayirEnum.ehHayir;
                    FVSTARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FVSTARTDATE1.TextFormat = @"yyyy-mm-dd hh:mm";
                    FVSTARTDATE1.TextFont.Name = "Courier New";
                    FVSTARTDATE1.TextFont.CharSet = 162;
                    FVSTARTDATE1.Value = @"{@STARTDATE@}";

                    FVENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 21, 214, 26, false);
                    FVENDDATE1.Name = "FVENDDATE1";
                    FVENDDATE1.Visible = EvetHayirEnum.ehHayir;
                    FVENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FVENDDATE1.TextFormat = @"yyyy-mm-dd hh:mm";
                    FVENDDATE1.TextFont.Name = "Courier New";
                    FVENDDATE1.TextFont.CharSet = 162;
                    FVENDDATE1.Value = @"{@ENDDATE@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 22, 42, 27, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Tarih Aralığı : ";

                    edate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 22, 96, 27, false);
                    edate.Name = "edate";
                    edate.FieldType = ReportFieldTypeEnum.ftVariable;
                    edate.TextFormat = @"dd/MM/yyyy";
                    edate.TextFont.CharSet = 162;
                    edate.Value = @"{@ENDDATE@}";

                    sdate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 22, 67, 27, false);
                    sdate.Name = "sdate";
                    sdate.FieldType = ReportFieldTypeEnum.ftVariable;
                    sdate.TextFormat = @"dd/MM/yyyy";
                    sdate.TextFont.CharSet = 162;
                    sdate.Value = @"{@STARTDATE@}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 69, 25, 73, 25, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 13, 386, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GÜNLÜK SAĞLIK FAALİYETLERİ
(AYAKTAN HASTA)";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 7, 386, 13, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.TextFont.CharSet = 162;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 9, 194, 15, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 32, 172, 38, false);
                    NewField112811.Name = "NewField112811";
                    NewField112811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112811.TextFont.Size = 9;
                    NewField112811.TextFont.Bold = true;
                    NewField112811.TextFont.CharSet = 162;
                    NewField112811.Value = @"Toplam";

                    NewField112821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 32, 129, 38, false);
                    NewField112821.Name = "NewField112821";
                    NewField112821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112821.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112821.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112821.TextFont.Size = 9;
                    NewField112821.TextFont.Bold = true;
                    NewField112821.TextFont.CharSet = 162;
                    NewField112821.Value = @"RANDEVULU";

                    NewField1128211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 32, 151, 38, false);
                    NewField1128211.Name = "NewField1128211";
                    NewField1128211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1128211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1128211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1128211.TextFont.Size = 9;
                    NewField1128211.TextFont.Bold = true;
                    NewField1128211.TextFont.CharSet = 162;
                    NewField1128211.Value = @"RANDEVUSUZ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 194, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"RANDEVU DURUMUNA GÖRE GÜNLÜK SAĞLIK FAALİYETLERİ (AYAKTAN HASTA)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FVSTARTDATE1.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    FVENDDATE1.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField13.CalcValue = NewField13.Value;
                    edate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    sdate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    NewField112811.CalcValue = NewField112811.Value;
                    NewField112821.CalcValue = NewField112821.Value;
                    NewField1128211.CalcValue = NewField1128211.Value;
                    NewField2.CalcValue = NewField2.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { FVSTARTDATE1,FVENDDATE1,NewField13,edate,sdate,NewField1,NewField112811,NewField112821,NewField1128211,NewField2,XXXXXXIL,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    TTReportTool.TTReportGroup g = ((ExaminationsHasAppAndHasNoApp)ParentReport).Groups("HEADER");
            g.Fields("RANDEVULU").Value = "0";
            g.Fields("RANDEVUSUZ").Value = "0";
#endregion HEADER HEADER_PreScript
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ExaminationsHasAppAndHasNoApp MyParentReport
                {
                    get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
                }
                
                public TTReportField TOPLAM;
                public TTReportField lblGenelToplam;
                public TTReportField GENELTOPLAM;
                public TTReportField RANDEVUSUZ;
                public TTReportField RANDEVULU;
                public TTReportField TOTAL; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 109, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.TextFont.Size = 9;
                    TOPLAM.TextFont.Bold = true;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"TOPLAM";

                    lblGenelToplam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 5, 109, 10, false);
                    lblGenelToplam.Name = "lblGenelToplam";
                    lblGenelToplam.DrawStyle = DrawStyleConstants.vbSolid;
                    lblGenelToplam.TextFont.Size = 9;
                    lblGenelToplam.TextFont.Bold = true;
                    lblGenelToplam.TextFont.CharSet = 162;
                    lblGenelToplam.Value = @"GENEL TOPLAM";

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 5, 172, 10, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOPLAM.FieldType = ReportFieldTypeEnum.ftExpression;
                    GENELTOPLAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENELTOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENELTOPLAM.TextFont.Size = 9;
                    GENELTOPLAM.TextFont.Bold = true;
                    GENELTOPLAM.TextFont.CharSet = 162;
                    GENELTOPLAM.Value = @"(Convert.ToInt32({%RANDEVULU%})+Convert.ToInt32({%RANDEVUSUZ%})).ToString()";

                    RANDEVUSUZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 151, 5, false);
                    RANDEVUSUZ.Name = "RANDEVUSUZ";
                    RANDEVUSUZ.DrawStyle = DrawStyleConstants.vbSolid;
                    RANDEVUSUZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANDEVUSUZ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANDEVUSUZ.TextFont.Size = 9;
                    RANDEVUSUZ.TextFont.CharSet = 162;
                    RANDEVUSUZ.Value = @"0";

                    RANDEVULU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 129, 5, false);
                    RANDEVULU.Name = "RANDEVULU";
                    RANDEVULU.DrawStyle = DrawStyleConstants.vbSolid;
                    RANDEVULU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANDEVULU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANDEVULU.TextFont.Size = 9;
                    RANDEVULU.TextFont.CharSet = 162;
                    RANDEVULU.Value = @"0";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 172, 5, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Size = 9;
                    TOTAL.TextFont.Bold = true;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"(Convert.ToInt32({%RANDEVULU%})+Convert.ToInt32({%RANDEVUSUZ%})).ToString()";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAM.CalcValue = TOPLAM.Value;
                    lblGenelToplam.CalcValue = lblGenelToplam.Value;
                    RANDEVUSUZ.CalcValue = RANDEVUSUZ.Value;
                    RANDEVULU.CalcValue = RANDEVULU.Value;
                    GENELTOPLAM.CalcValue = (Convert.ToInt32(MyParentReport.HEADER.RANDEVULU.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.RANDEVUSUZ.CalcValue)).ToString();
                    TOTAL.CalcValue = (Convert.ToInt32(MyParentReport.HEADER.RANDEVULU.CalcValue)+Convert.ToInt32(MyParentReport.HEADER.RANDEVUSUZ.CalcValue)).ToString();
                    return new TTReportObject[] { TOPLAM,lblGenelToplam,RANDEVUSUZ,RANDEVULU,GENELTOPLAM,TOTAL};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class SUBAYGroup : TTReportGroup
        {
            public ExaminationsHasAppAndHasNoApp MyParentReport
            {
                get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
            }

            new public SUBAYGroupHeader Header()
            {
                return (SUBAYGroupHeader)_header;
            }

            new public SUBAYGroupFooter Footer()
            {
                return (SUBAYGroupFooter)_footer;
            }

            public TTReportField BIRIM { get {return Footer().BIRIM;} }
            public TTReportField RANDEVUSUZ { get {return Footer().RANDEVUSUZ;} }
            public TTReportField RANDEVULU { get {return Footer().RANDEVULU;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
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
                list[0] = new TTReportNqlData<BaseAction.GetAppointmentActions_Class>("GetAppointmentActions", BaseAction.GetAppointmentActions((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SELECTEDRESOURCE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public ExaminationsHasAppAndHasNoApp MyParentReport
                {
                    get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
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
                    TTReportTool.TTReportGroup pg = ((ExaminationsHasAppAndHasNoApp)ParentReport).Groups("SUBAY");
            pg.Fields("RANDEVULU").Value = "0";
            pg.Fields("RANDEVUSUZ").Value = "0";
#endregion SUBAY HEADER_PreScript
                }
            }
            public partial class SUBAYGroupFooter : TTReportSection
            {
                public ExaminationsHasAppAndHasNoApp MyParentReport
                {
                    get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
                }
                
                public TTReportField BIRIM;
                public TTReportField RANDEVUSUZ;
                public TTReportField RANDEVULU;
                public TTReportField TOTAL; 
                public SUBAYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 110, 5, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.TextFont.Size = 8;
                    BIRIM.TextFont.Bold = true;
                    BIRIM.TextFont.CharSet = 162;
                    BIRIM.Value = @"{#MASTERRESOURCENAME#}";

                    RANDEVUSUZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 151, 5, false);
                    RANDEVUSUZ.Name = "RANDEVUSUZ";
                    RANDEVUSUZ.DrawStyle = DrawStyleConstants.vbSolid;
                    RANDEVUSUZ.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANDEVUSUZ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANDEVUSUZ.TextFont.Size = 9;
                    RANDEVUSUZ.TextFont.CharSet = 162;
                    RANDEVUSUZ.Value = @"0";

                    RANDEVULU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 129, 5, false);
                    RANDEVULU.Name = "RANDEVULU";
                    RANDEVULU.DrawStyle = DrawStyleConstants.vbSolid;
                    RANDEVULU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANDEVULU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANDEVULU.TextFont.Size = 9;
                    RANDEVULU.TextFont.CharSet = 162;
                    RANDEVULU.Value = @"0";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 172, 5, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Size = 9;
                    TOTAL.TextFont.Bold = true;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"(Convert.ToInt32({%RANDEVULU%})+Convert.ToInt32({%RANDEVUSUZ%})).ToString()";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseAction.GetAppointmentActions_Class dataset_GetAppointmentActions = ParentGroup.rsGroup.GetCurrentRecord<BaseAction.GetAppointmentActions_Class>(0);
                    BIRIM.CalcValue = (dataset_GetAppointmentActions != null ? Globals.ToStringCore(dataset_GetAppointmentActions.Masterresourcename) : "");
                    RANDEVUSUZ.CalcValue = RANDEVUSUZ.Value;
                    RANDEVULU.CalcValue = RANDEVULU.Value;
                    TOTAL.CalcValue = (Convert.ToInt32(MyParentReport.SUBAY.RANDEVULU.CalcValue)+Convert.ToInt32(MyParentReport.SUBAY.RANDEVUSUZ.CalcValue)).ToString();
                    return new TTReportObject[] { BIRIM,RANDEVUSUZ,RANDEVULU,TOTAL};
                }
            }

        }

        public SUBAYGroup SUBAY;

        public partial class MAINGroup : TTReportGroup
        {
            public ExaminationsHasAppAndHasNoApp MyParentReport
            {
                get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField GRP { get {return Body().GRP;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
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

                BaseAction.GetAppointmentActions_Class dataSet_GetAppointmentActions = ParentGroup.rsGroup.GetCurrentRecord<BaseAction.GetAppointmentActions_Class>(0);    
                return new object[] {(dataSet_GetAppointmentActions==null ? null : dataSet_GetAppointmentActions.MasterResource)};
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
                public ExaminationsHasAppAndHasNoApp MyParentReport
                {
                    get { return (ExaminationsHasAppAndHasNoApp)ParentReport; }
                }
                
                public TTReportField GRP;
                public TTReportField COUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    GRP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 54, 5, false);
                    GRP.Name = "GRP";
                    GRP.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRP.TextFont.Name = "Courier New";
                    GRP.TextFont.CharSet = 162;
                    GRP.Value = @"{#SUBAY.HASAPP#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 88, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.TextFont.Name = "Courier New";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{#SUBAY.SAYI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseAction.GetAppointmentActions_Class dataset_GetAppointmentActions = MyParentReport.SUBAY.rsGroup.GetCurrentRecord<BaseAction.GetAppointmentActions_Class>(0);
                    GRP.CalcValue = (dataset_GetAppointmentActions != null ? Globals.ToStringCore(dataset_GetAppointmentActions.Hasapp) : "");
                    COUNT.CalcValue = (dataset_GetAppointmentActions != null ? Globals.ToStringCore(dataset_GetAppointmentActions.Sayi) : "");
                    return new TTReportObject[] { GRP,COUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            TTReportTool.TTReportGroup g = ((ExaminationsHasAppAndHasNoApp)ParentReport).Groups("HEADER");
            TTReportTool.TTReportGroup pg = ((ExaminationsHasAppAndHasNoApp)ParentReport).Groups("SUBAY");
            string hasApp = this.GRP.CalcValue;
            switch(hasApp)
            {
                case "1": //Randevulu
                    {
                        pg.Fields("RANDEVULU").Value = (Convert.ToInt32(pg.Fields("RANDEVULU").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("RANDEVULU").Value = (Convert.ToInt32(g.Fields("RANDEVULU").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                case "2"://Randevusuz
                    {
                        pg.Fields("RANDEVUSUZ").Value = (Convert.ToInt32(pg.Fields("RANDEVUSUZ").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                        g.Fields("RANDEVUSUZ").Value = (Convert.ToInt32(g.Fields("RANDEVUSUZ").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
                    }
                    break;
                default:
                    break;
            }
            
            //g.Fields("GENELTOPLAM").Value = (Convert.ToInt32(g.Fields("GENELTOPLAM").Value) + Convert.ToInt32(this.COUNT.CalcValue)).ToString();
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

        public ExaminationsHasAppAndHasNoApp()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            SUBAY = new SUBAYGroup(HEADER,"SUBAY");
            MAIN = new MAINGroup(SUBAY,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SELECTEDRESOURCE", "00000000-0000-0000-0000-000000000000", "Bölüm", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cf0f9ec0-906f-4eab-8752-4c8f8e1aec48");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SELECTEDRESOURCE"))
                _runtimeParameters.SELECTEDRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SELECTEDRESOURCE"]);
            Name = "EXAMINATIONSHASAPPANDHASNOAPP";
            Caption = "Randevu Durumuna Göre Günlük Sağlık Faaliyetleri (Ayaktan Hasta)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 10;
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