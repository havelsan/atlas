
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
    /// Teknik Rapor (Ek-8.5)
    /// </summary>
    public partial class TeknikRapor : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TeknikRapor MyParentReport
            {
                get { return (TeknikRapor)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField MALZEMENINKULLANILDIGIBIRLIK { get {return Header().MALZEMENINKULLANILDIGIBIRLIK;} }
            public TTReportField YAZITARIHVESAYISI { get {return Header().YAZITARIHVESAYISI;} }
            public TTReportField RAPORUTANZIMEDEN { get {return Header().RAPORUTANZIMEDEN;} }
            public TTReportField RAPORTANZIMTARIHI { get {return Header().RAPORTANZIMTARIHI;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField71 { get {return Header().NewField71;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField NewField41_ { get {return Footer().NewField41_;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField NewField21_1 { get {return Footer().NewField21_1;} }
            public TTReportField NewField22_1 { get {return Footer().NewField22_1;} }
            public TTReportField NewField23_1 { get {return Footer().NewField23_1;} }
            public TTReportField NAMESURNAME { get {return Footer().NAMESURNAME;} }
            public TTReportField KALITEKONTROLKISMI1 { get {return Footer().KALITEKONTROLKISMI1;} }
            public TTReportField HEADDOCTORNAME { get {return Footer().HEADDOCTORNAME;} }
            public TTReportField TITLE { get {return Footer().TITLE;} }
            public TTReportField HEADDOCTORTITLE { get {return Footer().HEADDOCTORTITLE;} }
            public TTReportRTF DESCRIPTIONRTF { get {return Footer().DESCRIPTIONRTF;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CMRAction.GetCMRActionQuery_Class>("GetCMRActionQuery", CMRAction.GetCMRActionQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public TeknikRapor MyParentReport
                {
                    get { return (TeknikRapor)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField MALZEMENINKULLANILDIGIBIRLIK;
                public TTReportField YAZITARIHVESAYISI;
                public TTReportField RAPORUTANZIMEDEN;
                public TTReportField RAPORTANZIMTARIHI;
                public TTReportField NewField21;
                public TTReportField NewField15;
                public TTReportField NewField51;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField71;
                public TTReportField REQUESTDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 72;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 200, 15, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"TEKNİK RAPOR";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 86, 26, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"MALZEMENİN KULLANILDIĞI BİRLİK/SERVİS";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 20, 87, 26, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 86, 33, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"YAZI TARİH VE SAYISI";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 27, 87, 33, false);
                    NewField7.Name = "NewField7";
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 86, 40, false);
                    NewField8.Name = "NewField8";
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"RAPORU TANZİM EDEN";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 34, 87, 40, false);
                    NewField9.Name = "NewField9";
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 86, 47, false);
                    NewField10.Name = "NewField10";
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"RAPOR TANZİM TARİHİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 41, 87, 47, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 86, 54, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"RAPOR NUMARASI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 48, 87, 54, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    MALZEMENINKULLANILDIGIBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 20, 200, 26, false);
                    MALZEMENINKULLANILDIGIBIRLIK.Name = "MALZEMENINKULLANILDIGIBIRLIK";
                    MALZEMENINKULLANILDIGIBIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMENINKULLANILDIGIBIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMENINKULLANILDIGIBIRLIK.TextFont.Name = "Arial";
                    MALZEMENINKULLANILDIGIBIRLIK.TextFont.CharSet = 162;
                    MALZEMENINKULLANILDIGIBIRLIK.Value = @"{#OWNERMILITARYUNIT#}";

                    YAZITARIHVESAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 27, 200, 33, false);
                    YAZITARIHVESAYISI.Name = "YAZITARIHVESAYISI";
                    YAZITARIHVESAYISI.FieldType = ReportFieldTypeEnum.ftExpression;
                    YAZITARIHVESAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YAZITARIHVESAYISI.TextFont.Name = "Arial";
                    YAZITARIHVESAYISI.TextFont.CharSet = 162;
                    YAZITARIHVESAYISI.Value = @""" gün ve "" + {#REQUESTNO#} + "" nu.lı İş İstek Belgesi""";

                    RAPORUTANZIMEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 34, 200, 40, false);
                    RAPORUTANZIMEDEN.Name = "RAPORUTANZIMEDEN";
                    RAPORUTANZIMEDEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORUTANZIMEDEN.TextFont.Name = "Arial";
                    RAPORUTANZIMEDEN.TextFont.CharSet = 162;
                    RAPORUTANZIMEDEN.Value = @"Aşağıda İmzası Bulunanlar";

                    RAPORTANZIMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 41, 200, 47, false);
                    RAPORTANZIMTARIHI.Name = "RAPORTANZIMTARIHI";
                    RAPORTANZIMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTANZIMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTANZIMTARIHI.TextFont.Name = "Arial";
                    RAPORTANZIMTARIHI.TextFont.CharSet = 162;
                    RAPORTANZIMTARIHI.Value = @"{@printdate@}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 21, 70, false);
                    NewField21.Name = "NewField21";
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.Underline = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"S.NU.";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 60, 56, 70, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.Underline = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"STOK NU.";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 60, 113, 70, false);
                    NewField51.Name = "NewField51";
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField51.TextFont.Name = "Arial";
                    NewField51.TextFont.Bold = true;
                    NewField51.TextFont.Underline = true;
                    NewField51.TextFont.CharSet = 162;
                    NewField51.Value = @"MALZEMENİN CİNSİ";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 60, 160, 70, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"MARKA / MODEL / SERİ NU.";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 60, 180, 70, false);
                    NewField17.Name = "NewField17";
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.Underline = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"İMAL YILI";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 60, 200, 70, false);
                    NewField71.Name = "NewField71";
                    NewField71.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField71.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField71.TextFont.Name = "Arial";
                    NewField71.TextFont.Bold = true;
                    NewField71.TextFont.Underline = true;
                    NewField71.TextFont.CharSet = 162;
                    NewField71.Value = @"MİKTAR";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 27, 105, 33, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Name = "Arial";
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetCMRActionQuery_Class dataset_GetCMRActionQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    MALZEMENINKULLANILDIGIBIRLIK.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Ownermilitaryunit) : "");
                    RAPORUTANZIMEDEN.CalcValue = RAPORUTANZIMEDEN.Value;
                    RAPORTANZIMTARIHI.CalcValue = DateTime.Now.ToShortDateString();
                    NewField21.CalcValue = NewField21.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField51.CalcValue = NewField51.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField71.CalcValue = NewField71.Value;
                    REQUESTDATE.CalcValue = @"";
                    YAZITARIHVESAYISI.CalcValue = " gün ve " + (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.RequestNo) : "") + " nu.lı İş İstek Belgesi";
                    return new TTReportObject[] { REPORTNAME,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,NewField11,NewField12,NewField13,MALZEMENINKULLANILDIGIBIRLIK,RAPORUTANZIMEDEN,RAPORTANZIMTARIHI,NewField21,NewField15,NewField51,NewField16,NewField17,NewField71,REQUESTDATE,YAZITARIHVESAYISI};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            if(cmrAction is Repair)
            {
                Repair repair = (Repair)cmrAction;
                REQUESTDATE.CalcValue = repair.RequestDate.ToString();
            }
            else if(cmrAction is MaintenanceOrder)
            {
                MaintenanceOrder mo = (MaintenanceOrder)cmrAction;
                REQUESTDATE.CalcValue = mo.RequestDate.ToString();
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TeknikRapor MyParentReport
                {
                    get { return (TeknikRapor)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField NewField41_;
                public TTReportField COUNTTEXT;
                public TTReportField NewField21_1;
                public TTReportField NewField22_1;
                public TTReportField NewField23_1;
                public TTReportField NAMESURNAME;
                public TTReportField KALITEKONTROLKISMI1;
                public TTReportField HEADDOCTORNAME;
                public TTReportField TITLE;
                public TTReportField HEADDOCTORTITLE;
                public TTReportRTF DESCRIPTIONRTF; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 129;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 200, 10, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"""******************** Yalnız "" + COUNTTEXT.CalcValue + "" ("" + COUNTTEXT.FormattedValue + "") Kalem "" + ""1"" + "" (Bir) Adettir. ********************""";

                    NewField41_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 32, 20, false);
                    NewField41_.Name = "NewField41_";
                    NewField41_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField41_.TextFont.Name = "Arial";
                    NewField41_.TextFont.Bold = true;
                    NewField41_.TextFont.Underline = true;
                    NewField41_.TextFont.CharSet = 162;
                    NewField41_.Value = @"AÇIKLAMA :";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 5, 246, 10, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.TextFormat = @"NUMBERTEXT";
                    COUNTTEXT.Value = @"{@subgroupcount@}";

                    NewField21_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 81, 85, 87, false);
                    NewField21_1.Name = "NewField21_1";
                    NewField21_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_1.TextFont.Name = "Arial";
                    NewField21_1.TextFont.Size = 11;
                    NewField21_1.TextFont.Bold = true;
                    NewField21_1.TextFont.CharSet = 162;
                    NewField21_1.Value = @"İlgili Kısım/Bölüm Amiri";

                    NewField22_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 81, 195, 87, false);
                    NewField22_1.Name = "NewField22_1";
                    NewField22_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22_1.TextFont.Name = "Arial";
                    NewField22_1.TextFont.Size = 11;
                    NewField22_1.TextFont.Bold = true;
                    NewField22_1.TextFont.CharSet = 162;
                    NewField22_1.Value = @"Kalite Kontrol Kısmı";

                    NewField23_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 106, 140, 112, false);
                    NewField23_1.Name = "NewField23_1";
                    NewField23_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23_1.TextFont.Name = "Arial";
                    NewField23_1.TextFont.Size = 11;
                    NewField23_1.TextFont.Bold = true;
                    NewField23_1.TextFont.CharSet = 162;
                    NewField23_1.Value = @"ONAY";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 87, 85, 92, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.Size = 11;
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"";

                    KALITEKONTROLKISMI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 87, 195, 97, false);
                    KALITEKONTROLKISMI1.Name = "KALITEKONTROLKISMI1";
                    KALITEKONTROLKISMI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALITEKONTROLKISMI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KALITEKONTROLKISMI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KALITEKONTROLKISMI1.MultiLine = EvetHayirEnum.ehEvet;
                    KALITEKONTROLKISMI1.WordBreak = EvetHayirEnum.ehEvet;
                    KALITEKONTROLKISMI1.TextFont.Name = "Arial";
                    KALITEKONTROLKISMI1.TextFont.Size = 11;
                    KALITEKONTROLKISMI1.TextFont.CharSet = 162;
                    KALITEKONTROLKISMI1.Value = @"";

                    HEADDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 112, 140, 117, false);
                    HEADDOCTORNAME.Name = "HEADDOCTORNAME";
                    HEADDOCTORNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTORNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    HEADDOCTORNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADDOCTORNAME.TextFont.Name = "Arial";
                    HEADDOCTORNAME.TextFont.Size = 11;
                    HEADDOCTORNAME.TextFont.CharSet = 162;
                    HEADDOCTORNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"", """")";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 92, 85, 97, false);
                    TITLE.Name = "TITLE";
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TITLE.TextFont.Name = "Arial";
                    TITLE.TextFont.Size = 11;
                    TITLE.TextFont.CharSet = 162;
                    TITLE.Value = @"";

                    HEADDOCTORTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 117, 140, 122, false);
                    HEADDOCTORTITLE.Name = "HEADDOCTORTITLE";
                    HEADDOCTORTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTORTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADDOCTORTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADDOCTORTITLE.TextFont.Name = "Arial";
                    HEADDOCTORTITLE.TextFont.Size = 11;
                    HEADDOCTORTITLE.TextFont.CharSet = 162;
                    HEADDOCTORTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTORTITAL"", """")";

                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 32, 16, 200, 21, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetCMRActionQuery_Class dataset_GetCMRActionQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);
                    NewField41_.CalcValue = NewField41_.Value;
                    COUNTTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    NewField21_1.CalcValue = NewField21_1.Value;
                    NewField22_1.CalcValue = NewField22_1.Value;
                    NewField23_1.CalcValue = NewField23_1.Value;
                    NAMESURNAME.CalcValue = @"";
                    KALITEKONTROLKISMI1.CalcValue = @"";
                    TITLE.CalcValue = @"";
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    TOTAL.CalcValue = "******************** Yalnız " + COUNTTEXT.CalcValue + " (" + COUNTTEXT.FormattedValue + ") Kalem " + "1" + " (Bir) Adettir. ********************";
                    HEADDOCTORNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "");
                    HEADDOCTORTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL", "");
                    return new TTReportObject[] { NewField41_,COUNTTEXT,NewField21_1,NewField22_1,NewField23_1,NAMESURNAME,KALITEKONTROLKISMI1,TITLE,DESCRIPTIONRTF,TOTAL,HEADDOCTORNAME,HEADDOCTORTITLE};
                }
                public override void RunPreScript()
                {
#region PARTA FOOTER_PreScript
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            if(cmrAction is Repair)
            {
                Repair repair = (Repair)cmrAction;
                DESCRIPTIONRTF.Value = repair.HEKReportDescription;
            }
            else if(cmrAction is MaintenanceOrder)
            {
                MaintenanceOrder mo = (MaintenanceOrder)cmrAction;
                DESCRIPTIONRTF.Value = mo.Description;
            }
#endregion PARTA FOOTER_PreScript
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    //            string objectID = ((TeknikRapor)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            TTObjectContext ctx = new TTObjectContext(true);
//            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
//            ResUser user = (ResUser)mo.GetState("DivisionSectionApproval", true).User.UserObject;
//            NAMESURNAME.CalcValue = user.Name.ToString();
//            TITLE.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(user.Title).DisplayText.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public TeknikRapor MyParentReport
            {
                get { return (TeknikRapor)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField STOKNO { get {return Body().STOKNO;} }
            public TTReportField MALZEMECINSI { get {return Body().MALZEMECINSI;} }
            public TTReportField MARKAMODELSERINO { get {return Body().MARKAMODELSERINO;} }
            public TTReportField IMALYILI { get {return Body().IMALYILI;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
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

                CMRAction.GetCMRActionQuery_Class dataSet_GetCMRActionQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);    
                return new object[] {(dataSet_GetCMRActionQuery==null ? null : dataSet_GetCMRActionQuery.ObjectID)};
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
                public TeknikRapor MyParentReport
                {
                    get { return (TeknikRapor)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField STOKNO;
                public TTReportField MALZEMECINSI;
                public TTReportField MARKAMODELSERINO;
                public TTReportField IMALYILI;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField SERIALNO;
                public TTReportField DISTRIBUTIONTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 21, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@counter@}";

                    STOKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 56, 5, false);
                    STOKNO.Name = "STOKNO";
                    STOKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNO.TextFont.Name = "Arial";
                    STOKNO.TextFont.CharSet = 162;
                    STOKNO.Value = @"{#PARTA.NATOSTOCKNO#}";

                    MALZEMECINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 113, 5, false);
                    MALZEMECINSI.Name = "MALZEMECINSI";
                    MALZEMECINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMECINSI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALZEMECINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMECINSI.TextFont.Name = "Arial";
                    MALZEMECINSI.TextFont.CharSet = 162;
                    MALZEMECINSI.Value = @"{#PARTA.FIXEDASSETNAME#}";

                    MARKAMODELSERINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 160, 5, false);
                    MARKAMODELSERINO.Name = "MARKAMODELSERINO";
                    MARKAMODELSERINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODELSERINO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKAMODELSERINO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODELSERINO.TextFont.Name = "Arial";
                    MARKAMODELSERINO.TextFont.CharSet = 162;
                    MARKAMODELSERINO.Value = @"";

                    IMALYILI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 180, 5, false);
                    IMALYILI.Name = "IMALYILI";
                    IMALYILI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IMALYILI.TextFormat = @"dd/MM/yyyy";
                    IMALYILI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMALYILI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMALYILI.TextFont.Name = "Arial";
                    IMALYILI.TextFont.CharSet = 162;
                    IMALYILI.Value = @"{#PARTA.PRODUCTIONDATE#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 227, 6, false);
                    MARK.Name = "MARK";
                    MARK.Visible = EvetHayirEnum.ehHayir;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.Value = @"{#PARTA.MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 1, 239, 6, false);
                    MODEL.Name = "MODEL";
                    MODEL.Visible = EvetHayirEnum.ehHayir;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.Value = @"{#PARTA.MODEL#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 1, 254, 6, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.Visible = EvetHayirEnum.ehHayir;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.Value = @"{#PARTA.SERIALNUMBER#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 200, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"1 {#PARTA.DISTRIBUTIONTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRAction.GetCMRActionQuery_Class dataset_GetCMRActionQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<CMRAction.GetCMRActionQuery_Class>(0);
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    STOKNO.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.NATOStockNO) : "");
                    MALZEMECINSI.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Fixedassetname) : "");
                    MARKAMODELSERINO.CalcValue = @"";
                    IMALYILI.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.ProductionDate) : "");
                    MARK.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Mark) : "");
                    MODEL.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.Model) : "");
                    SERIALNO.CalcValue = (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.SerialNumber) : "");
                    DISTRIBUTIONTYPE.CalcValue = @"1 " + (dataset_GetCMRActionQuery != null ? Globals.ToStringCore(dataset_GetCMRActionQuery.DistributionType) : "");
                    return new TTReportObject[] { SIRANO,STOKNO,MALZEMECINSI,MARKAMODELSERINO,IMALYILI,MARK,MODEL,SERIALNO,DISTRIBUTIONTYPE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(MARK.CalcValue == "")
                MARK.CalcValue = "---";
            
            if(MODEL.CalcValue == "")
                MODEL.CalcValue = "---";
            
            if(SERIALNO.CalcValue == "")
                SERIALNO.CalcValue = "---";
            
            MARKAMODELSERINO.CalcValue = MARK.CalcValue + " / " + MODEL.CalcValue + " / " + SERIALNO.CalcValue;
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

        public TeknikRapor()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TEKNIKRAPOR";
            Caption = "Teknik Rapor (Ek-8.5)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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