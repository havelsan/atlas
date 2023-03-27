
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
    /// Hasar ve Durum Tespit Raporu (Ek-4.5)
    /// </summary>
    public partial class HasarveDurumTespitRaporu_2 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HasarveDurumTespitRaporu_2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_2)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
            public TTReportField NewField117 { get {return Footer().NewField117;} }
            public TTReportField NewField118 { get {return Footer().NewField118;} }
            public TTReportField GRANDTOTALLABORCOST { get {return Footer().GRANDTOTALLABORCOST;} }
            public TTReportField GRANDTOTALMATERIALCOST { get {return Footer().GRANDTOTALMATERIALCOST;} }
            public TTReportField GRANDTOTAL { get {return Footer().GRANDTOTAL;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField YAPILANIS114 { get {return Footer().YAPILANIS114;} }
            public TTReportField GRANDTOTALCOST { get {return Footer().GRANDTOTALCOST;} }
            public TTReportField GRANDTOTALCOST1 { get {return Footer().GRANDTOTALCOST1;} }
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
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 152, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HİZMETE ÖZEL";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 267, 23, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"HASAR VE DURUM TESPİT RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { NewField1,NewField12};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField NewField161;
                public TTReportField NewField117;
                public TTReportField NewField118;
                public TTReportField GRANDTOTALLABORCOST;
                public TTReportField GRANDTOTALMATERIALCOST;
                public TTReportField GRANDTOTAL;
                public TTReportField NewField17;
                public TTReportField YAPILANIS114;
                public TTReportField GRANDTOTALCOST;
                public TTReportField GRANDTOTALCOST1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 65;
                    RepeatCount = 0;
                    
                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 63, 10, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @" Direk İşçilik Gideri";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 63, 20, false);
                    NewField117.Name = "NewField117";
                    NewField117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117.TextFont.Name = "Arial";
                    NewField117.TextFont.Bold = true;
                    NewField117.TextFont.CharSet = 162;
                    NewField117.Value = @" Direk Malzeme Gideri";

                    NewField118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 63, 30, false);
                    NewField118.Name = "NewField118";
                    NewField118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField118.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField118.TextFont.Name = "Arial";
                    NewField118.TextFont.Bold = true;
                    NewField118.TextFont.CharSet = 162;
                    NewField118.Value = @" Toplam Ödetme Maliyeti";

                    GRANDTOTALLABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 0, 93, 10, false);
                    GRANDTOTALLABORCOST.Name = "GRANDTOTALLABORCOST";
                    GRANDTOTALLABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTALLABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALLABORCOST.TextFormat = @"#,##0.#0";
                    GRANDTOTALLABORCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTALLABORCOST.TextFont.Name = "Arial";
                    GRANDTOTALLABORCOST.TextFont.Size = 9;
                    GRANDTOTALLABORCOST.TextFont.CharSet = 162;
                    GRANDTOTALLABORCOST.Value = @"{@sumof(TOTALLABORCOST)@}";

                    GRANDTOTALMATERIALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 10, 93, 20, false);
                    GRANDTOTALMATERIALCOST.Name = "GRANDTOTALMATERIALCOST";
                    GRANDTOTALMATERIALCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTALMATERIALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALMATERIALCOST.TextFormat = @"#,##0.#0";
                    GRANDTOTALMATERIALCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTALMATERIALCOST.TextFont.Name = "Arial";
                    GRANDTOTALMATERIALCOST.TextFont.Size = 9;
                    GRANDTOTALMATERIALCOST.TextFont.CharSet = 162;
                    GRANDTOTALMATERIALCOST.Value = @"";

                    GRANDTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 20, 93, 30, false);
                    GRANDTOTAL.Name = "GRANDTOTAL";
                    GRANDTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL.TextFormat = @"#,##0.#0";
                    GRANDTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL.TextFont.Name = "Arial";
                    GRANDTOTAL.TextFont.Size = 9;
                    GRANDTOTAL.TextFont.CharSet = 162;
                    GRANDTOTAL.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 267, 10, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"İş Hzl. Ks. A.                                                                                                    Bakım Müdürü";

                    YAPILANIS114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 10, 267, 30, false);
                    YAPILANIS114.Name = "YAPILANIS114";
                    YAPILANIS114.DrawStyle = DrawStyleConstants.vbSolid;
                    YAPILANIS114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YAPILANIS114.TextFont.Name = "Arial";
                    YAPILANIS114.TextFont.Size = 9;
                    YAPILANIS114.TextFont.CharSet = 162;
                    YAPILANIS114.Value = @"";

                    GRANDTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 10, 328, 15, false);
                    GRANDTOTALCOST.Name = "GRANDTOTALCOST";
                    GRANDTOTALCOST.Visible = EvetHayirEnum.ehHayir;
                    GRANDTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALCOST.Value = @"{@sumof(TOTALCOST)@}";

                    GRANDTOTALCOST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 331, 9, 356, 14, false);
                    GRANDTOTALCOST1.Name = "GRANDTOTALCOST1";
                    GRANDTOTALCOST1.Visible = EvetHayirEnum.ehHayir;
                    GRANDTOTALCOST1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALCOST1.Value = @"{@sumof(TOTALCOST1)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField161.CalcValue = NewField161.Value;
                    NewField117.CalcValue = NewField117.Value;
                    NewField118.CalcValue = NewField118.Value;
                    GRANDTOTALLABORCOST.CalcValue = ParentGroup.FieldSums["TOTALLABORCOST"].Value.ToString();;
                    GRANDTOTALMATERIALCOST.CalcValue = @"";
                    GRANDTOTAL.CalcValue = @"";
                    NewField17.CalcValue = NewField17.Value;
                    YAPILANIS114.CalcValue = YAPILANIS114.Value;
                    GRANDTOTALCOST.CalcValue = ParentGroup.FieldSums["TOTALCOST"].Value.ToString();;
                    GRANDTOTALCOST1.CalcValue = ParentGroup.FieldSums["TOTALCOST1"].Value.ToString();;
                    return new TTReportObject[] { NewField161,NewField117,NewField118,GRANDTOTALLABORCOST,GRANDTOTALMATERIALCOST,GRANDTOTAL,NewField17,YAPILANIS114,GRANDTOTALCOST,GRANDTOTALCOST1};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    GRANDTOTALMATERIALCOST.CalcValue = (Convert.ToDouble(GRANDTOTALCOST.CalcValue) + Convert.ToDouble(GRANDTOTALCOST1.CalcValue)).ToString();
            GRANDTOTAL.CalcValue = (Convert.ToDouble(GRANDTOTALLABORCOST.CalcValue) + Convert.ToDouble(GRANDTOTALMATERIALCOST.CalcValue)).ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HasarveDurumTespitRaporu_2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_2)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField115 { get {return Header().NewField115;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField125 { get {return Header().NewField125;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField NewField135 { get {return Header().NewField135;} }
            public TTReportField NewField154 { get {return Footer().NewField154;} }
            public TTReportField TOTALLABORCOST { get {return Footer().TOTALLABORCOST;} }
            public TTReportField TOTALTIME { get {return Footer().TOTALTIME;} }
            public TTReportField NewField1451 { get {return Footer().NewField1451;} }
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
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField NewField151;
                public TTReportField NewField115;
                public TTReportField NewField152;
                public TTReportField NewField125;
                public TTReportField NewField153;
                public TTReportField NewField135; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 267, 8, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"DİREKT İŞÇİLİK GİDERİ";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 93, 18, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Yapılan İş";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 8, 133, 18, false);
                    NewField115.Name = "NewField115";
                    NewField115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115.TextFont.Name = "Arial";
                    NewField115.TextFont.Bold = true;
                    NewField115.TextFont.CharSet = 162;
                    NewField115.Value = @"Kısım";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 8, 161, 18, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152.TextFont.Name = "Arial";
                    NewField152.TextFont.Bold = true;
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @"Ay";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 8, 195, 18, false);
                    NewField125.Name = "NewField125";
                    NewField125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField125.MultiLine = EvetHayirEnum.ehEvet;
                    NewField125.WordBreak = EvetHayirEnum.ehEvet;
                    NewField125.TextFont.Name = "Arial";
                    NewField125.TextFont.Bold = true;
                    NewField125.TextFont.CharSet = 162;
                    NewField125.Value = @"Net Direk
İşçilik Saati";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 8, 240, 18, false);
                    NewField153.Name = "NewField153";
                    NewField153.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField153.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField153.MultiLine = EvetHayirEnum.ehEvet;
                    NewField153.WordBreak = EvetHayirEnum.ehEvet;
                    NewField153.TextFont.Name = "Arial";
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @"Ortalama Direk
İşçilik Gideri";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 8, 267, 18, false);
                    NewField135.Name = "NewField135";
                    NewField135.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField135.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField135.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField135.MultiLine = EvetHayirEnum.ehEvet;
                    NewField135.WordBreak = EvetHayirEnum.ehEvet;
                    NewField135.TextFont.Name = "Arial";
                    NewField135.TextFont.Bold = true;
                    NewField135.TextFont.CharSet = 162;
                    NewField135.Value = @"İşçilik
Gideri";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13.CalcValue = NewField13.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField135.CalcValue = NewField135.Value;
                    return new TTReportObject[] { NewField13,NewField151,NewField115,NewField152,NewField125,NewField153,NewField135};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField NewField154;
                public TTReportField TOTALLABORCOST;
                public TTReportField TOTALTIME;
                public TTReportField NewField1451; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 161, 10, false);
                    NewField154.Name = "NewField154";
                    NewField154.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField154.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField154.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField154.TextFont.Name = "Arial";
                    NewField154.TextFont.Bold = true;
                    NewField154.TextFont.CharSet = 162;
                    NewField154.Value = @"TOPLAM ";

                    TOTALLABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 267, 10, false);
                    TOTALLABORCOST.Name = "TOTALLABORCOST";
                    TOTALLABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALLABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALLABORCOST.TextFormat = @"#,##0.#0";
                    TOTALLABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALLABORCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALLABORCOST.TextFont.Name = "Arial";
                    TOTALLABORCOST.TextFont.Size = 9;
                    TOTALLABORCOST.TextFont.CharSet = 162;
                    TOTALLABORCOST.Value = @"{@sumof(LABORCOST)@}";

                    TOTALTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 195, 10, false);
                    TOTALTIME.Name = "TOTALTIME";
                    TOTALTIME.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALTIME.TextFormat = @"#,###";
                    TOTALTIME.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALTIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALTIME.TextFont.Name = "Arial";
                    TOTALTIME.TextFont.Size = 9;
                    TOTALTIME.TextFont.CharSet = 162;
                    TOTALTIME.Value = @"{@sumof(SHARPDIRECTLABORTIME)@}";

                    NewField1451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 240, 10, false);
                    NewField1451.Name = "NewField1451";
                    NewField1451.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1451.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1451.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1451.TextFont.Name = "Arial";
                    NewField1451.TextFont.Bold = true;
                    NewField1451.TextFont.CharSet = 162;
                    NewField1451.Value = @"TOPLAM ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField154.CalcValue = NewField154.Value;
                    TOTALLABORCOST.CalcValue = ParentGroup.FieldSums["LABORCOST"].Value.ToString();;
                    TOTALTIME.CalcValue = ParentGroup.FieldSums["SHARPDIRECTLABORTIME"].Value.ToString();;
                    NewField1451.CalcValue = NewField1451.Value;
                    return new TTReportObject[] { NewField154,TOTALLABORCOST,TOTALTIME,NewField1451};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAIN1Group : TTReportGroup
        {
            public HasarveDurumTespitRaporu_2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_2)ParentReport; }
            }

            new public MAIN1GroupBody Body()
            {
                return (MAIN1GroupBody)_body;
            }
            public TTReportField ORDERNAME { get {return Body().ORDERNAME;} }
            public TTReportField WORKSHOP { get {return Body().WORKSHOP;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField SHARPDIRECTLABORTIME { get {return Body().SHARPDIRECTLABORTIME;} }
            public TTReportField AVARAGEDIRECTLABORCOST { get {return Body().AVARAGEDIRECTLABORCOST;} }
            public TTReportField LABORCOST { get {return Body().LABORCOST;} }
            public MAIN1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>("GetMaintenanceOrderCostByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN1GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN1GroupBody : TTReportSection
            {
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField ORDERNAME;
                public TTReportField WORKSHOP;
                public TTReportField MONTH;
                public TTReportField SHARPDIRECTLABORTIME;
                public TTReportField AVARAGEDIRECTLABORCOST;
                public TTReportField LABORCOST; 
                public MAIN1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    ORDERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 93, 5, false);
                    ORDERNAME.Name = "ORDERNAME";
                    ORDERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME.TextFont.Name = "Arial";
                    ORDERNAME.TextFont.Size = 9;
                    ORDERNAME.TextFont.CharSet = 162;
                    ORDERNAME.Value = @"{#ORDERNAME#}";

                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 133, 5, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.Size = 9;
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @"{#WORKSHOP#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 161, 5, false);
                    MONTH.Name = "MONTH";
                    MONTH.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH.TextFont.Name = "Arial";
                    MONTH.TextFont.Size = 9;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"";

                    SHARPDIRECTLABORTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 195, 5, false);
                    SHARPDIRECTLABORTIME.Name = "SHARPDIRECTLABORTIME";
                    SHARPDIRECTLABORTIME.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME.Value = @"{#SHARPDIRECTLABORTIME#}";

                    AVARAGEDIRECTLABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 240, 5, false);
                    AVARAGEDIRECTLABORCOST.Name = "AVARAGEDIRECTLABORCOST";
                    AVARAGEDIRECTLABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST.Value = @"{#AVARAGEDIRECTLABORCOST#}";

                    LABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 267, 5, false);
                    LABORCOST.Name = "LABORCOST";
                    LABORCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST.TextFormat = @"#,##0.#0";
                    LABORCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST.TextFont.Name = "Arial";
                    LABORCOST.TextFont.Size = 9;
                    LABORCOST.TextFont.CharSet = 162;
                    LABORCOST.Value = @"{#LABORCOST#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class dataset_GetMaintenanceOrderCostByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(0);
                    ORDERNAME.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.OrderName) : "");
                    WORKSHOP.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Workshop) : "");
                    MONTH.CalcValue = @"";
                    SHARPDIRECTLABORTIME.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Sharpdirectlabortime) : "");
                    AVARAGEDIRECTLABORCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Avaragedirectlaborcost) : "");
                    LABORCOST.CalcValue = (dataset_GetMaintenanceOrderCostByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderCostByObjectIDQuery.Laborcost) : "");
                    return new TTReportObject[] { ORDERNAME,WORKSHOP,MONTH,SHARPDIRECTLABORTIME,AVARAGEDIRECTLABORCOST,LABORCOST};
                }

                public override void RunScript()
                {
#region MAIN1 BODY_Script
                    switch(DateTime.Now.Month)
            {
                case 1:
                    MONTH.CalcValue = "OCAK";
                    break;
                case 2:
                    MONTH.CalcValue = "ŞUBAT";
                    break;
                case 3:
                    MONTH.CalcValue = "MART";
                    break;
                case 4:
                    MONTH.CalcValue = "NİSAN";
                    break;
                case 5:
                    MONTH.CalcValue = "MAYIS";
                    break;
                case 6:
                    MONTH.CalcValue = "HAZİRAN";
                    break;
                case 7:
                    MONTH.CalcValue = "TEMMUZ";
                    break;
                case 8:
                    MONTH.CalcValue = "AĞUSTOS";
                    break;
                case 9:
                    MONTH.CalcValue = "EYLÜL";
                    break;
                case 10:
                    MONTH.CalcValue = "EKİM";
                    break;
                case 11:
                    MONTH.CalcValue = "KASIM";
                    break;
                case 12:
                    MONTH.CalcValue = "ARALIK";
                    break;
            }
#endregion MAIN1 BODY_Script
                }
            }

        }

        public MAIN1Group MAIN1;

        public partial class PARTCGroup : TTReportGroup
        {
            public HasarveDurumTespitRaporu_2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_2)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField116 { get {return Header().NewField116;} }
            public TTReportField NewField154 { get {return Header().NewField154;} }
            public TTReportField NewField126 { get {return Header().NewField126;} }
            public TTReportField NewField155 { get {return Header().NewField155;} }
            public TTReportField NewField136 { get {return Header().NewField136;} }
            public TTReportField NewField156 { get {return Header().NewField156;} }
            public TTReportField NewField157 { get {return Header().NewField157;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField TOTALMATERIALCOST { get {return Footer().TOTALMATERIALCOST;} }
            public TTReportField TOTALCOST { get {return Footer().TOTALCOST;} }
            public TTReportField TOTALCOST1 { get {return Footer().TOTALCOST1;} }
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
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportField NewField116;
                public TTReportField NewField154;
                public TTReportField NewField126;
                public TTReportField NewField155;
                public TTReportField NewField136;
                public TTReportField NewField156;
                public TTReportField NewField157; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 267, 8, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"DİREKT MALZEME GİDERİ";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 82, 18, false);
                    NewField116.Name = "NewField116";
                    NewField116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField116.TextFont.Name = "Arial";
                    NewField116.TextFont.Bold = true;
                    NewField116.TextFont.CharSet = 162;
                    NewField116.Value = @"Malzemenin Cinsi";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 8, 133, 18, false);
                    NewField154.Name = "NewField154";
                    NewField154.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField154.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField154.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField154.TextFont.Name = "Arial";
                    NewField154.TextFont.Bold = true;
                    NewField154.TextFont.CharSet = 162;
                    NewField154.Value = @"Yeni Fiyatı";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 8, 161, 18, false);
                    NewField126.Name = "NewField126";
                    NewField126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField126.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField126.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField126.TextFont.Name = "Arial";
                    NewField126.TextFont.Bold = true;
                    NewField126.TextFont.CharSet = 162;
                    NewField126.Value = @"Eskime Fiyatı";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 8, 195, 18, false);
                    NewField155.Name = "NewField155";
                    NewField155.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField155.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField155.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField155.TextFont.Name = "Arial";
                    NewField155.TextFont.Bold = true;
                    NewField155.TextFont.CharSet = 162;
                    NewField155.Value = @"Hurda Fiyatı";

                    NewField136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 8, 224, 18, false);
                    NewField136.Name = "NewField136";
                    NewField136.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField136.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField136.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField136.TextFont.Name = "Arial";
                    NewField136.TextFont.Bold = true;
                    NewField136.TextFont.CharSet = 162;
                    NewField136.Value = @"Ödenti Fiyatı";

                    NewField156 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 8, 267, 18, false);
                    NewField156.Name = "NewField156";
                    NewField156.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField156.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField156.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField156.TextFont.Name = "Arial";
                    NewField156.TextFont.Bold = true;
                    NewField156.TextFont.CharSet = 162;
                    NewField156.Value = @"Malzeme Gideri";

                    NewField157 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 8, 106, 18, false);
                    NewField157.Name = "NewField157";
                    NewField157.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField157.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField157.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField157.TextFont.Name = "Arial";
                    NewField157.TextFont.Bold = true;
                    NewField157.TextFont.CharSet = 162;
                    NewField157.Value = @"Miktar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField14.CalcValue = NewField14.Value;
                    NewField116.CalcValue = NewField116.Value;
                    NewField154.CalcValue = NewField154.Value;
                    NewField126.CalcValue = NewField126.Value;
                    NewField155.CalcValue = NewField155.Value;
                    NewField136.CalcValue = NewField136.Value;
                    NewField156.CalcValue = NewField156.Value;
                    NewField157.CalcValue = NewField157.Value;
                    return new TTReportObject[] { NewField14,NewField116,NewField154,NewField126,NewField155,NewField136,NewField156,NewField157};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField TOTALMATERIALCOST;
                public TTReportField TOTALCOST;
                public TTReportField TOTALCOST1; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 224, 10, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"TOPLAM ";

                    TOTALMATERIALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 267, 10, false);
                    TOTALMATERIALCOST.Name = "TOTALMATERIALCOST";
                    TOTALMATERIALCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMATERIALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIALCOST.TextFormat = @"#,##0.#0";
                    TOTALMATERIALCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALMATERIALCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALMATERIALCOST.TextFont.Name = "Arial";
                    TOTALMATERIALCOST.TextFont.Size = 9;
                    TOTALMATERIALCOST.TextFont.CharSet = 162;
                    TOTALMATERIALCOST.Value = @"";

                    TOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 3, 327, 8, false);
                    TOTALCOST.Name = "TOTALCOST";
                    TOTALCOST.Visible = EvetHayirEnum.ehHayir;
                    TOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOST.Value = @"{@sumof(MATERIALCOST)@}";

                    TOTALCOST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 330, 2, 355, 7, false);
                    TOTALCOST1.Name = "TOTALCOST1";
                    TOTALCOST1.Visible = EvetHayirEnum.ehHayir;
                    TOTALCOST1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCOST1.Value = @"{@sumof(MATERIALCOST1)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField15.CalcValue = NewField15.Value;
                    TOTALMATERIALCOST.CalcValue = @"";
                    TOTALCOST.CalcValue = ParentGroup.FieldSums["MATERIALCOST"].Value.ToString();;
                    TOTALCOST1.CalcValue = ParentGroup.FieldSums["MATERIALCOST1"].Value.ToString();;
                    return new TTReportObject[] { NewField15,TOTALMATERIALCOST,TOTALCOST,TOTALCOST1};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    TOTALMATERIALCOST.CalcValue = (Convert.ToDouble(TOTALCOST.CalcValue) + Convert.ToDouble(TOTALCOST1.CalcValue)).ToString();
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAIN2Group : TTReportGroup
        {
            public HasarveDurumTespitRaporu_2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_2)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NEWPRICE { get {return Body().NEWPRICE;} }
            public TTReportField OLDPRICE { get {return Body().OLDPRICE;} }
            public TTReportField DEADPRICE { get {return Body().DEADPRICE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField MATERIALCOST { get {return Body().MATERIALCOST;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaintenanceOrder.GetDirectMaterialCostsQuery_Class>("GetDirectMaterialCostsQuery", MaintenanceOrder.GetDirectMaterialCostsQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField NEWPRICE;
                public TTReportField OLDPRICE;
                public TTReportField DEADPRICE;
                public TTReportField UNITPRICE;
                public TTReportField MATERIALCOST;
                public TTReportField AMOUNT; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 82, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 9;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    NEWPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 0, 133, 5, false);
                    NEWPRICE.Name = "NEWPRICE";
                    NEWPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE.TextFont.Name = "Arial";
                    NEWPRICE.TextFont.Size = 9;
                    NEWPRICE.TextFont.CharSet = 162;
                    NEWPRICE.Value = @"";

                    OLDPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 161, 5, false);
                    OLDPRICE.Name = "OLDPRICE";
                    OLDPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE.TextFont.Name = "Arial";
                    OLDPRICE.TextFont.Size = 9;
                    OLDPRICE.TextFont.CharSet = 162;
                    OLDPRICE.Value = @"";

                    DEADPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 195, 5, false);
                    DEADPRICE.Name = "DEADPRICE";
                    DEADPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE.TextFont.Name = "Arial";
                    DEADPRICE.TextFont.Size = 9;
                    DEADPRICE.TextFont.CharSet = 162;
                    DEADPRICE.Value = @"";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 224, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.Size = 9;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    MATERIALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 267, 5, false);
                    MATERIALCOST.Name = "MATERIALCOST";
                    MATERIALCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST.TextFormat = @"#,##0.#0";
                    MATERIALCOST.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST.TextFont.Name = "Arial";
                    MATERIALCOST.TextFont.Size = 9;
                    MATERIALCOST.TextFont.CharSet = 162;
                    MATERIALCOST.Value = @"{#MATERIALCOST#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 106, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#} {#DISTRIBUTIONTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetDirectMaterialCostsQuery_Class dataset_GetDirectMaterialCostsQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetDirectMaterialCostsQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_GetDirectMaterialCostsQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsQuery.Materialname) : "");
                    NEWPRICE.CalcValue = @"";
                    OLDPRICE.CalcValue = @"";
                    DEADPRICE.CalcValue = @"";
                    UNITPRICE.CalcValue = (dataset_GetDirectMaterialCostsQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsQuery.UnitPrice) : "");
                    MATERIALCOST.CalcValue = (dataset_GetDirectMaterialCostsQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsQuery.Materialcost) : "");
                    AMOUNT.CalcValue = (dataset_GetDirectMaterialCostsQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsQuery.Amount) : "") + @" " + (dataset_GetDirectMaterialCostsQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsQuery.DistributionType) : "");
                    return new TTReportObject[] { MATERIALNAME,NEWPRICE,OLDPRICE,DEADPRICE,UNITPRICE,MATERIALCOST,AMOUNT};
                }
            }

        }

        public MAIN2Group MAIN2;

        public partial class MAIN3Group : TTReportGroup
        {
            public HasarveDurumTespitRaporu_2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu_2)ParentReport; }
            }

            new public MAIN3GroupBody Body()
            {
                return (MAIN3GroupBody)_body;
            }
            public TTReportField MATERIALNAME1 { get {return Body().MATERIALNAME1;} }
            public TTReportField NEWPRICE1 { get {return Body().NEWPRICE1;} }
            public TTReportField OLDPRICE1 { get {return Body().OLDPRICE1;} }
            public TTReportField DEADPRICE1 { get {return Body().DEADPRICE1;} }
            public TTReportField UNITPRICE1 { get {return Body().UNITPRICE1;} }
            public TTReportField MATERIALCOST1 { get {return Body().MATERIALCOST1;} }
            public TTReportField AMOUNT1 { get {return Body().AMOUNT1;} }
            public MAIN3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class>("GetDirectMaterialCostsForWorkStepQuery", MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN3GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN3GroupBody : TTReportSection
            {
                public HasarveDurumTespitRaporu_2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu_2)ParentReport; }
                }
                
                public TTReportField MATERIALNAME1;
                public TTReportField NEWPRICE1;
                public TTReportField OLDPRICE1;
                public TTReportField DEADPRICE1;
                public TTReportField UNITPRICE1;
                public TTReportField MATERIALCOST1;
                public TTReportField AMOUNT1; 
                public MAIN3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    MATERIALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 82, 5, false);
                    MATERIALNAME1.Name = "MATERIALNAME1";
                    MATERIALNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME1.TextFont.Name = "Arial";
                    MATERIALNAME1.TextFont.Size = 9;
                    MATERIALNAME1.TextFont.CharSet = 162;
                    MATERIALNAME1.Value = @"{#MATERIALNAME#}";

                    NEWPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 0, 133, 5, false);
                    NEWPRICE1.Name = "NEWPRICE1";
                    NEWPRICE1.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE1.TextFormat = @"#,##0.#0";
                    NEWPRICE1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE1.TextFont.Name = "Arial";
                    NEWPRICE1.TextFont.Size = 9;
                    NEWPRICE1.TextFont.CharSet = 162;
                    NEWPRICE1.Value = @"";

                    OLDPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 161, 5, false);
                    OLDPRICE1.Name = "OLDPRICE1";
                    OLDPRICE1.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE1.TextFormat = @"#,##0.#0";
                    OLDPRICE1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE1.TextFont.Name = "Arial";
                    OLDPRICE1.TextFont.Size = 9;
                    OLDPRICE1.TextFont.CharSet = 162;
                    OLDPRICE1.Value = @"";

                    DEADPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 195, 5, false);
                    DEADPRICE1.Name = "DEADPRICE1";
                    DEADPRICE1.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE1.TextFormat = @"#,##0.#0";
                    DEADPRICE1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE1.TextFont.Name = "Arial";
                    DEADPRICE1.TextFont.Size = 9;
                    DEADPRICE1.TextFont.CharSet = 162;
                    DEADPRICE1.Value = @"";

                    UNITPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 0, 224, 5, false);
                    UNITPRICE1.Name = "UNITPRICE1";
                    UNITPRICE1.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE1.TextFormat = @"#,##0.#0";
                    UNITPRICE1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE1.TextFont.Name = "Arial";
                    UNITPRICE1.TextFont.Size = 9;
                    UNITPRICE1.TextFont.CharSet = 162;
                    UNITPRICE1.Value = @"{#UNITPRICE#}";

                    MATERIALCOST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 267, 5, false);
                    MATERIALCOST1.Name = "MATERIALCOST1";
                    MATERIALCOST1.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST1.TextFormat = @"#,##0.#0";
                    MATERIALCOST1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST1.TextFont.Name = "Arial";
                    MATERIALCOST1.TextFont.Size = 9;
                    MATERIALCOST1.TextFont.CharSet = 162;
                    MATERIALCOST1.Value = @"{#MATERIALCOST#}";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 106, 5, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1.TextFont.Name = "Arial";
                    AMOUNT1.TextFont.Size = 9;
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"{#AMOUNT#} {#DISTRIBUTIONTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class dataset_GetDirectMaterialCostsForWorkStepQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class>(0);
                    MATERIALNAME1.CalcValue = (dataset_GetDirectMaterialCostsForWorkStepQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsForWorkStepQuery.Materialname) : "");
                    NEWPRICE1.CalcValue = @"";
                    OLDPRICE1.CalcValue = @"";
                    DEADPRICE1.CalcValue = @"";
                    UNITPRICE1.CalcValue = (dataset_GetDirectMaterialCostsForWorkStepQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsForWorkStepQuery.UnitPrice) : "");
                    MATERIALCOST1.CalcValue = (dataset_GetDirectMaterialCostsForWorkStepQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsForWorkStepQuery.Materialcost) : "");
                    AMOUNT1.CalcValue = (dataset_GetDirectMaterialCostsForWorkStepQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsForWorkStepQuery.Amount) : "") + @" " + (dataset_GetDirectMaterialCostsForWorkStepQuery != null ? Globals.ToStringCore(dataset_GetDirectMaterialCostsForWorkStepQuery.DistributionType) : "");
                    return new TTReportObject[] { MATERIALNAME1,NEWPRICE1,OLDPRICE1,DEADPRICE1,UNITPRICE1,MATERIALCOST1,AMOUNT1};
                }
            }

        }

        public MAIN3Group MAIN3;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HasarveDurumTespitRaporu_2()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN1 = new MAIN1Group(PARTB,"MAIN1");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            MAIN2 = new MAIN2Group(PARTC,"MAIN2");
            MAIN3 = new MAIN3Group(PARTC,"MAIN3");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HASARVEDURUMTESPITRAPORU_2";
            Caption = "Hasar ve Durum Tespit Raporu (Ek-4.5)";
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

    }
}