
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
    /// Son Muayene Formu (Ek-8.2)
    /// </summary>
    public partial class SonMuayeneFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? KLT_KONT = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MUA_KONT = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Part1Group : TTReportGroup
        {
            public SonMuayeneFormu MyParentReport
            {
                get { return (SonMuayeneFormu)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField MALZEMEADI { get {return Header().MALZEMEADI;} }
            public TTReportField STOKNUMARASI { get {return Header().STOKNUMARASI;} }
            public TTReportField MARKAMODELI { get {return Header().MARKAMODELI;} }
            public TTReportField ISITEKNO { get {return Header().ISITEKNO;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField NewField41 { get {return Header().NewField41;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField ISITEKTARIHI { get {return Header().ISITEKTARIHI;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField Onaylar { get {return Footer().Onaylar;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField KLT_KONT_ASB { get {return Footer().KLT_KONT_ASB;} }
            public TTReportField MUA_KONT_VEKLT_YNT_BL_A { get {return Footer().MUA_KONT_VEKLT_YNT_BL_A;} }
            public TTReportField NewField81 { get {return Footer().NewField81;} }
            public TTReportField Kalite_Kontrol { get {return Footer().Kalite_Kontrol;} }
            public TTReportField Muayene_Kontrol { get {return Footer().Muayene_Kontrol;} }
            public TTReportField KLT_KONT_ASB_ID { get {return Footer().KLT_KONT_ASB_ID;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery2", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public SonMuayeneFormu MyParentReport
                {
                    get { return (SonMuayeneFormu)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField9;
                public TTReportField MALZEMEADI;
                public TTReportField STOKNUMARASI;
                public TTReportField MARKAMODELI;
                public TTReportField ISITEKNO;
                public TTReportField NewField3;
                public TTReportField NewField21;
                public TTReportField NewField31;
                public TTReportField NewField41;
                public TTReportField NewField51;
                public TTReportField ISITEKTARIHI;
                public TTReportField NewField2;
                public TTReportField MILITARYUNIT;
                public TTReportField ORDERNO; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 105;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 7, 171, 12, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"HİZMETE ÖZEL";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 19, 275, 39, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 14;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"SON MUAYENE FORMU";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 42, 48, 54, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @" Malzemenin Adı :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 54, 48, 68, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @" Stok Numarası :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 42, 172, 54, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @" Marke ve Modeli :";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 54, 196, 68, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @" İş İstek ve İş Emri Nu. ve Tarihi :";

                    MALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 42, 139, 54, false);
                    MALZEMEADI.Name = "MALZEMEADI";
                    MALZEMEADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI.TextFont.Name = "Arial";
                    MALZEMEADI.TextFont.Size = 11;
                    MALZEMEADI.TextFont.CharSet = 162;
                    MALZEMEADI.Value = @"{#FIXEDASSETNAME#}";

                    STOKNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 54, 139, 68, false);
                    STOKNUMARASI.Name = "STOKNUMARASI";
                    STOKNUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    STOKNUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNUMARASI.TextFont.Name = "Arial";
                    STOKNUMARASI.TextFont.Size = 11;
                    STOKNUMARASI.TextFont.CharSet = 162;
                    STOKNUMARASI.Value = @"{#NATOSTOCKNO#}";

                    MARKAMODELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 42, 275, 54, false);
                    MARKAMODELI.Name = "MARKAMODELI";
                    MARKAMODELI.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKAMODELI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODELI.TextFont.Name = "Arial";
                    MARKAMODELI.TextFont.Size = 11;
                    MARKAMODELI.TextFont.CharSet = 162;
                    MARKAMODELI.Value = @"{#MARK#} {#MODEL#} {#SERIALNUMBER#}";

                    ISITEKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 54, 228, 68, false);
                    ISITEKNO.Name = "ISITEKNO";
                    ISITEKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ISITEKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISITEKNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ISITEKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISITEKNO.TextFont.Name = "Arial";
                    ISITEKNO.TextFont.Size = 11;
                    ISITEKNO.TextFont.CharSet = 162;
                    ISITEKNO.Value = @"{#REQUESTNO#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 83, 37, 105, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Sıra Nu.";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 83, 104, 105, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Size = 11;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"Yapılan Kontroller";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 83, 191, 105, false);
                    NewField31.Name = "NewField31";
                    NewField31.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField31.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.TextFont.Name = "Arial";
                    NewField31.TextFont.Size = 11;
                    NewField31.TextFont.CharSet = 162;
                    NewField31.Value = @"Açıklama";

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 83, 242, 105, false);
                    NewField41.Name = "NewField41";
                    NewField41.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField41.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField41.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField41.MultiLine = EvetHayirEnum.ehEvet;
                    NewField41.WordBreak = EvetHayirEnum.ehEvet;
                    NewField41.TextFont.Name = "Arial";
                    NewField41.TextFont.Size = 11;
                    NewField41.TextFont.CharSet = 162;
                    NewField41.Value = @"
Bakım Onarımı Yapan 
Personelin İmzası";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 83, 275, 105, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField51.TextFont.Name = "Arial";
                    NewField51.TextFont.Size = 11;
                    NewField51.TextFont.CharSet = 162;
                    NewField51.Value = @"Kontrol Tarihi";

                    ISITEKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 54, 275, 68, false);
                    ISITEKTARIHI.Name = "ISITEKTARIHI";
                    ISITEKTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    ISITEKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISITEKTARIHI.TextFormat = @"Short Date";
                    ISITEKTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISITEKTARIHI.TextFont.Name = "Arial";
                    ISITEKTARIHI.TextFont.Size = 11;
                    ISITEKTARIHI.TextFont.CharSet = 162;
                    ISITEKTARIHI.Value = @"{#REQUESTDATE#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 68, 48, 83, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @" Birlik Adı :";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 68, 139, 83, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.Value = @"{#OWNERMILITARYUNIT#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 68, 275, 83, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 11;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"Sipariş Numarası : {#ORDERNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery2 = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField9.CalcValue = NewField9.Value;
                    MALZEMEADI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.Fixedassetname) : "");
                    STOKNUMARASI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.NATOStockNO) : "");
                    MARKAMODELI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.Mark) : "") + @" " + (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.Model) : "") + @" " + (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.SerialNumber) : "");
                    ISITEKNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.RequestNo) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField31.CalcValue = NewField31.Value;
                    NewField41.CalcValue = NewField41.Value;
                    NewField51.CalcValue = NewField51.Value;
                    ISITEKTARIHI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.RequestDate) : "");
                    NewField2.CalcValue = NewField2.Value;
                    MILITARYUNIT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.Ownermilitaryunit) : "");
                    ORDERNO.CalcValue = @"Sipariş Numarası : " + (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.OrderNO) : "");
                    return new TTReportObject[] { NewField,NewField4,NewField5,NewField6,NewField7,NewField9,MALZEMEADI,STOKNUMARASI,MARKAMODELI,ISITEKNO,NewField3,NewField21,NewField31,NewField41,NewField51,ISITEKTARIHI,NewField2,MILITARYUNIT,ORDERNO};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public SonMuayeneFormu MyParentReport
                {
                    get { return (SonMuayeneFormu)ParentReport; }
                }
                
                public TTReportField Onaylar;
                public TTReportField NewField1;
                public TTReportField KLT_KONT_ASB;
                public TTReportField MUA_KONT_VEKLT_YNT_BL_A;
                public TTReportField NewField81;
                public TTReportField Kalite_Kontrol;
                public TTReportField Muayene_Kontrol;
                public TTReportField KLT_KONT_ASB_ID; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 71;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    Onaylar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 7, 275, 59, false);
                    Onaylar.Name = "Onaylar";
                    Onaylar.DrawStyle = DrawStyleConstants.vbSolid;
                    Onaylar.FieldType = ReportFieldTypeEnum.ftVariable;
                    Onaylar.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onaylar.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onaylar.TextFont.Name = "Arial";
                    Onaylar.TextFont.Size = 11;
                    Onaylar.TextFont.CharSet = 162;
                    Onaylar.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 275, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İLGİLİ ONAYLAR";

                    KLT_KONT_ASB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 26, 75, 46, false);
                    KLT_KONT_ASB.Name = "KLT_KONT_ASB";
                    KLT_KONT_ASB.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLT_KONT_ASB.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLT_KONT_ASB.MultiLine = EvetHayirEnum.ehEvet;
                    KLT_KONT_ASB.TextFont.CharSet = 162;
                    KLT_KONT_ASB.Value = @"";

                    MUA_KONT_VEKLT_YNT_BL_A = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 26, 260, 49, false);
                    MUA_KONT_VEKLT_YNT_BL_A.Name = "MUA_KONT_VEKLT_YNT_BL_A";
                    MUA_KONT_VEKLT_YNT_BL_A.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUA_KONT_VEKLT_YNT_BL_A.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUA_KONT_VEKLT_YNT_BL_A.MultiLine = EvetHayirEnum.ehEvet;
                    MUA_KONT_VEKLT_YNT_BL_A.TextFont.CharSet = 162;
                    MUA_KONT_VEKLT_YNT_BL_A.Value = @"";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 52, 161, 57, false);
                    NewField81.Name = "NewField81";
                    NewField81.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField81.TextFont.Name = "Arial";
                    NewField81.TextFont.Bold = true;
                    NewField81.TextFont.CharSet = 162;
                    NewField81.Value = @"HİZMETE ÖZEL";

                    Kalite_Kontrol = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 17, 62, 22, false);
                    Kalite_Kontrol.Name = "Kalite_Kontrol";
                    Kalite_Kontrol.TextFont.Underline = true;
                    Kalite_Kontrol.TextFont.CharSet = 162;
                    Kalite_Kontrol.Value = @"KLT.KONT.ASB";

                    Muayene_Kontrol = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 15, 257, 20, false);
                    Muayene_Kontrol.Name = "Muayene_Kontrol";
                    Muayene_Kontrol.TextFont.Underline = true;
                    Muayene_Kontrol.TextFont.CharSet = 162;
                    Muayene_Kontrol.Value = @"MUA.KONT.VE.KLT.YNT.BL.A";

                    KLT_KONT_ASB_ID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 318, 8, 338, 14, false);
                    KLT_KONT_ASB_ID.Name = "KLT_KONT_ASB_ID";
                    KLT_KONT_ASB_ID.Visible = EvetHayirEnum.ehHayir;
                    KLT_KONT_ASB_ID.DrawStyle = DrawStyleConstants.vbSolid;
                    KLT_KONT_ASB_ID.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLT_KONT_ASB_ID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLT_KONT_ASB_ID.TextFont.Name = "Arial";
                    KLT_KONT_ASB_ID.TextFont.Size = 11;
                    KLT_KONT_ASB_ID.TextFont.CharSet = 162;
                    KLT_KONT_ASB_ID.Value = @"{@KLT_KONT@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery2 = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    Onaylar.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    KLT_KONT_ASB.CalcValue = @"";
                    MUA_KONT_VEKLT_YNT_BL_A.CalcValue = @"";
                    NewField81.CalcValue = NewField81.Value;
                    Kalite_Kontrol.CalcValue = Kalite_Kontrol.Value;
                    Muayene_Kontrol.CalcValue = Muayene_Kontrol.Value;
                    KLT_KONT_ASB_ID.CalcValue = MyParentReport.RuntimeParameters.KLT_KONT.ToString();
                    return new TTReportObject[] { Onaylar,NewField1,KLT_KONT_ASB,MUA_KONT_VEKLT_YNT_BL_A,NewField81,Kalite_Kontrol,Muayene_Kontrol,KLT_KONT_ASB_ID};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    if (this.MyParentReport.RuntimeParameters.KLT_KONT.HasValue)
                    {
                        ResUser kltKontAsbR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.KLT_KONT.Value, typeof(ResUser));
                        //KLT_KONT_ASB.CalcValue = kltKontAsbR.Name;
                        //MCA
                        KLT_KONT_ASB.CalcValue = "";
                        KLT_KONT_ASB.CalcValue += "\r\n" + kltKontAsbR.Name;
                        KLT_KONT_ASB.CalcValue += (kltKontAsbR.MilitaryClass != null) ? kltKontAsbR.MilitaryClass.ShortName : "";
                        KLT_KONT_ASB.CalcValue += (kltKontAsbR.Rank != null) ? kltKontAsbR.Rank.ShortName : "";
                        
                        KLT_KONT_ASB.CalcValue += (kltKontAsbR.EmploymentRecordID != null) ? "\r\n(" + kltKontAsbR.EmploymentRecordID.ToString() + ")" : "";

                    }
                    if (this.MyParentReport.RuntimeParameters.MUA_KONT.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.MUA_KONT.Value, typeof(ResUser));
                        //MUA_KONT_VEKLT_YNT_BL_A.CalcValue = muaKontR.Name;
                        //mca
                        MUA_KONT_VEKLT_YNT_BL_A.CalcValue = "";
                        MUA_KONT_VEKLT_YNT_BL_A.CalcValue += "\r\n" + muaKontR.Name;
                        MUA_KONT_VEKLT_YNT_BL_A.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        MUA_KONT_VEKLT_YNT_BL_A.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        
                        MUA_KONT_VEKLT_YNT_BL_A.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";

                    }
#endregion PART1 FOOTER_Script
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public SonMuayeneFormu MyParentReport
            {
                get { return (SonMuayeneFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField KONTROL { get {return Body().KONTROL;} }
            public TTReportField MALZEMECINSI { get {return Body().MALZEMECINSI;} }
            public TTReportField PERSONELIMZA { get {return Body().PERSONELIMZA;} }
            public TTReportField KONTROLTARIHI { get {return Body().KONTROLTARIHI;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
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
                public SonMuayeneFormu MyParentReport
                {
                    get { return (SonMuayeneFormu)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField KONTROL;
                public TTReportField MALZEMECINSI;
                public TTReportField PERSONELIMZA;
                public TTReportField KONTROLTARIHI;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 37, 16, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 11;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"";

                    KONTROL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 104, 16, false);
                    KONTROL.Name = "KONTROL";
                    KONTROL.DrawStyle = DrawStyleConstants.vbSolid;
                    KONTROL.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONTROL.MultiLine = EvetHayirEnum.ehEvet;
                    KONTROL.NoClip = EvetHayirEnum.ehEvet;
                    KONTROL.WordBreak = EvetHayirEnum.ehEvet;
                    KONTROL.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONTROL.TextFont.Name = "Arial";
                    KONTROL.TextFont.Size = 11;
                    KONTROL.TextFont.CharSet = 162;
                    KONTROL.Value = @"";

                    MALZEMECINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 191, 16, false);
                    MALZEMECINSI.Name = "MALZEMECINSI";
                    MALZEMECINSI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMECINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMECINSI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.NoClip = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.TextFont.Name = "Arial";
                    MALZEMECINSI.TextFont.Size = 11;
                    MALZEMECINSI.TextFont.CharSet = 162;
                    MALZEMECINSI.Value = @"{#Part1.DESCRIPTIONPART#}";

                    PERSONELIMZA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 0, 242, 16, false);
                    PERSONELIMZA.Name = "PERSONELIMZA";
                    PERSONELIMZA.DrawStyle = DrawStyleConstants.vbSolid;
                    PERSONELIMZA.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONELIMZA.MultiLine = EvetHayirEnum.ehEvet;
                    PERSONELIMZA.NoClip = EvetHayirEnum.ehEvet;
                    PERSONELIMZA.WordBreak = EvetHayirEnum.ehEvet;
                    PERSONELIMZA.ExpandTabs = EvetHayirEnum.ehEvet;
                    PERSONELIMZA.TextFont.Name = "Arial";
                    PERSONELIMZA.TextFont.Size = 11;
                    PERSONELIMZA.TextFont.CharSet = 162;
                    PERSONELIMZA.Value = @"{#Part1.PERSONNEL#}";

                    KONTROLTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 0, 275, 16, false);
                    KONTROLTARIHI.Name = "KONTROLTARIHI";
                    KONTROLTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    KONTROLTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONTROLTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    KONTROLTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    KONTROLTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    KONTROLTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KONTROLTARIHI.TextFont.Name = "Arial";
                    KONTROLTARIHI.TextFont.Size = 11;
                    KONTROLTARIHI.TextFont.CharSet = 162;
                    KONTROLTARIHI.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 0, 17, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 37, 0, 37, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 0, 104, 6, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 191, 0, 191, 6, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 242, 0, 242, 6, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 275, 0, 275, 6, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery2 = MyParentReport.Part1.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    SIRANO.CalcValue = @"";
                    KONTROL.CalcValue = @"";
                    MALZEMECINSI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.DescriptionPart) : "");
                    PERSONELIMZA.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery2.Personnel) : "");
                    KONTROLTARIHI.CalcValue = @"";
                    return new TTReportObject[] { SIRANO,KONTROL,MALZEMECINSI,PERSONELIMZA,KONTROLTARIHI};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SonMuayeneFormu()
        {
            Part1 = new Part1Group(this,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("KLT_KONT", "00000000-0000-0000-0000-000000000000", "KLT.KONT.ASB", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("MUA_KONT", "00000000-0000-0000-0000-000000000000", "MUA.KONT.VE.KLT.YNT.BL.A", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("KLT_KONT"))
                _runtimeParameters.KLT_KONT = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["KLT_KONT"]);
            if (parameters.ContainsKey("MUA_KONT"))
                _runtimeParameters.MUA_KONT = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MUA_KONT"]);
            Name = "SONMUAYENEFORMU";
            Caption = "Son Muayene Formu (Ek-8.2)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 10;
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