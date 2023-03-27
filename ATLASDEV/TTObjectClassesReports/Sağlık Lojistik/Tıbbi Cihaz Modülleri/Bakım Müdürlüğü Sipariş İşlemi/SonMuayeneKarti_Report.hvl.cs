
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
    /// Son Muayene Kartı (Ek-8.3)
    /// </summary>
    public partial class SonMuayeneKarti : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? TEKNISYEN = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? KISIMAMIRI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MUA_KLT_KONT_ASB = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MUA_BOLUMAMIRI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public SonMuayeneKarti MyParentReport
            {
                get { return (SonMuayeneKarti)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Onaylar { get {return Body().Onaylar;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField BIRLIGI { get {return Body().BIRLIGI;} }
            public TTReportField ISISTEKTARIHI { get {return Body().ISISTEKTARIHI;} }
            public TTReportField ISTEKNOVETARIHI { get {return Body().ISTEKNOVETARIHI;} }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField MALZEMEADI { get {return Body().MALZEMEADI;} }
            public TTReportField STOKNUMARASI { get {return Body().STOKNUMARASI;} }
            public TTReportField MARKAMODELI { get {return Body().MARKAMODELI;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField MUAYENETARIHI { get {return Body().MUAYENETARIHI;} }
            public TTReportField NewField81 { get {return Body().NewField81;} }
            public TTReportField BKM_ONR { get {return Body().BKM_ONR;} }
            public TTReportField MUA_KONT { get {return Body().MUA_KONT;} }
            public TTReportField BakimOnarimTeknisyen { get {return Body().BakimOnarimTeknisyen;} }
            public TTReportField BakimOnarimKismiAmir { get {return Body().BakimOnarimKismiAmir;} }
            public TTReportField MUA_KONT_KLT_ASB { get {return Body().MUA_KONT_KLT_ASB;} }
            public TTReportField MUA_KONT_KLT_BOLUM_AMIRI { get {return Body().MUA_KONT_KLT_BOLUM_AMIRI;} }
            public TTReportField TEKNISYEN { get {return Body().TEKNISYEN;} }
            public TTReportField KISIMAMIRI { get {return Body().KISIMAMIRI;} }
            public TTReportField KLT_KONT_ASB { get {return Body().KLT_KONT_ASB;} }
            public TTReportField BOLUMAMIRI { get {return Body().BOLUMAMIRI;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SonMuayeneKarti MyParentReport
                {
                    get { return (SonMuayeneKarti)ParentReport; }
                }
                
                public TTReportField Onaylar;
                public TTReportField NewField9;
                public TTReportField BIRLIGI;
                public TTReportField ISISTEKTARIHI;
                public TTReportField ISTEKNOVETARIHI;
                public TTReportField NewField;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField1;
                public TTReportField MALZEMEADI;
                public TTReportField STOKNUMARASI;
                public TTReportField MARKAMODELI;
                public TTReportField NewField10;
                public TTReportField NewField3;
                public TTReportField MUAYENETARIHI;
                public TTReportField NewField81;
                public TTReportField BKM_ONR;
                public TTReportField MUA_KONT;
                public TTReportField BakimOnarimTeknisyen;
                public TTReportField BakimOnarimKismiAmir;
                public TTReportField MUA_KONT_KLT_ASB;
                public TTReportField MUA_KONT_KLT_BOLUM_AMIRI;
                public TTReportField TEKNISYEN;
                public TTReportField KISIMAMIRI;
                public TTReportField KLT_KONT_ASB;
                public TTReportField BOLUMAMIRI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    Onaylar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 140, 275, 197, false);
                    Onaylar.Name = "Onaylar";
                    Onaylar.DrawStyle = DrawStyleConstants.vbSolid;
                    Onaylar.FieldType = ReportFieldTypeEnum.ftVariable;
                    Onaylar.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onaylar.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onaylar.TextFont.Name = "Arial";
                    Onaylar.TextFont.Size = 11;
                    Onaylar.TextFont.CharSet = 162;
                    Onaylar.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 93, 100, 103, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @" İş İstek ve İş Emri Nu. ve Tarihi";

                    BIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 83, 275, 93, false);
                    BIRLIGI.Name = "BIRLIGI";
                    BIRLIGI.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIGI.TextFont.Name = "Arial";
                    BIRLIGI.TextFont.Size = 8;
                    BIRLIGI.TextFont.CharSet = 162;
                    BIRLIGI.Value = @"{#ACCOUNTANCYMILITARYUNIT#}";

                    ISISTEKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 83, 354, 93, false);
                    ISISTEKTARIHI.Name = "ISISTEKTARIHI";
                    ISISTEKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    ISISTEKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISISTEKTARIHI.TextFormat = @"Short Date";
                    ISISTEKTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISISTEKTARIHI.TextFont.Name = "Arial";
                    ISISTEKTARIHI.TextFont.Size = 11;
                    ISISTEKTARIHI.TextFont.CharSet = 162;
                    ISISTEKTARIHI.Value = @"{#REQUESTDATE#}";

                    ISTEKNOVETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 93, 275, 103, false);
                    ISTEKNOVETARIHI.Name = "ISTEKNOVETARIHI";
                    ISTEKNOVETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    ISTEKNOVETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKNOVETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKNOVETARIHI.TextFont.Name = "Arial";
                    ISTEKNOVETARIHI.TextFont.Size = 11;
                    ISTEKNOVETARIHI.TextFont.CharSet = 162;
                    ISTEKNOVETARIHI.Value = @"{#REQUESTNO#} - {%ISISTEKTARIHI%}";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 10, 171, 15, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 11;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"HİZMETE ÖZEL";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 38, 275, 53, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 14;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"SON MUAYENE KARTI";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 53, 100, 63, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @" Malzemenin Adı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 63, 100, 73, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @" Stok Numarası";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 73, 100, 83, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @" Marke ve Modeli";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 83, 100, 93, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @" Birliği";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 113, 275, 133, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Gerekli işlemleri yapılmış ve FAAL kabul edilmiştir.";

                    MALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 53, 275, 63, false);
                    MALZEMEADI.Name = "MALZEMEADI";
                    MALZEMEADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MALZEMEADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMEADI.TextFont.Name = "Arial";
                    MALZEMEADI.TextFont.Size = 11;
                    MALZEMEADI.TextFont.CharSet = 162;
                    MALZEMEADI.Value = @"{#FIXEDASSETNAME#}";

                    STOKNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 63, 275, 73, false);
                    STOKNUMARASI.Name = "STOKNUMARASI";
                    STOKNUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    STOKNUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNUMARASI.TextFont.Name = "Arial";
                    STOKNUMARASI.TextFont.Size = 11;
                    STOKNUMARASI.TextFont.CharSet = 162;
                    STOKNUMARASI.Value = @"{#NATOSTOCKNO#}";

                    MARKAMODELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 73, 275, 83, false);
                    MARKAMODELI.Name = "MARKAMODELI";
                    MARKAMODELI.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKAMODELI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODELI.TextFont.Name = "Arial";
                    MARKAMODELI.TextFont.Size = 11;
                    MARKAMODELI.TextFont.CharSet = 162;
                    MARKAMODELI.Value = @"{#MARK#} {#MODEL#} {#SERIALNUMBER#}";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 103, 100, 113, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 11;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @" Muayene Tarihi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 133, 275, 140, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İLGİLİ ONAYLAR";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 103, 275, 113, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENETARIHI.TextFont.Name = "Arial";
                    MUAYENETARIHI.TextFont.Size = 11;
                    MUAYENETARIHI.TextFont.CharSet = 162;
                    MUAYENETARIHI.Value = @"{#CHECKDATE#}";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 188, 161, 193, false);
                    NewField81.Name = "NewField81";
                    NewField81.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField81.TextFont.Name = "Arial";
                    NewField81.TextFont.Size = 11;
                    NewField81.TextFont.Bold = true;
                    NewField81.TextFont.CharSet = 162;
                    NewField81.Value = @"HİZMETE ÖZEL";

                    BKM_ONR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 148, 79, 153, false);
                    BKM_ONR.Name = "BKM_ONR";
                    BKM_ONR.TextFont.Underline = true;
                    BKM_ONR.TextFont.CharSet = 162;
                    BKM_ONR.Value = @"BAKIM ONARIM KISMI";

                    MUA_KONT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 148, 243, 153, false);
                    MUA_KONT.Name = "MUA_KONT";
                    MUA_KONT.TextFont.Underline = true;
                    MUA_KONT.TextFont.CharSet = 162;
                    MUA_KONT.Value = @"MUA. KONT. VE KLT. YNT. BL. A.";

                    BakimOnarimTeknisyen = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 166, 60, 179, false);
                    BakimOnarimTeknisyen.Name = "BakimOnarimTeknisyen";
                    BakimOnarimTeknisyen.FieldType = ReportFieldTypeEnum.ftVariable;
                    BakimOnarimTeknisyen.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BakimOnarimTeknisyen.MultiLine = EvetHayirEnum.ehEvet;
                    BakimOnarimTeknisyen.Value = @"";

                    BakimOnarimKismiAmir = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 166, 100, 180, false);
                    BakimOnarimKismiAmir.Name = "BakimOnarimKismiAmir";
                    BakimOnarimKismiAmir.FieldType = ReportFieldTypeEnum.ftVariable;
                    BakimOnarimKismiAmir.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BakimOnarimKismiAmir.MultiLine = EvetHayirEnum.ehEvet;
                    BakimOnarimKismiAmir.Value = @"";

                    MUA_KONT_KLT_ASB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 165, 205, 179, false);
                    MUA_KONT_KLT_ASB.Name = "MUA_KONT_KLT_ASB";
                    MUA_KONT_KLT_ASB.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUA_KONT_KLT_ASB.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUA_KONT_KLT_ASB.MultiLine = EvetHayirEnum.ehEvet;
                    MUA_KONT_KLT_ASB.Value = @"";

                    MUA_KONT_KLT_BOLUM_AMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 165, 262, 182, false);
                    MUA_KONT_KLT_BOLUM_AMIRI.Name = "MUA_KONT_KLT_BOLUM_AMIRI";
                    MUA_KONT_KLT_BOLUM_AMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUA_KONT_KLT_BOLUM_AMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUA_KONT_KLT_BOLUM_AMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    MUA_KONT_KLT_BOLUM_AMIRI.Value = @"";

                    TEKNISYEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 158, 55, 163, false);
                    TEKNISYEN.Name = "TEKNISYEN";
                    TEKNISYEN.TextFont.Underline = true;
                    TEKNISYEN.TextFont.CharSet = 162;
                    TEKNISYEN.Value = @"TEKNISYEN";

                    KISIMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 158, 98, 163, false);
                    KISIMAMIRI.Name = "KISIMAMIRI";
                    KISIMAMIRI.TextFont.Underline = true;
                    KISIMAMIRI.TextFont.CharSet = 162;
                    KISIMAMIRI.Value = @"KISIM AMİRİ";

                    KLT_KONT_ASB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 156, 202, 161, false);
                    KLT_KONT_ASB.Name = "KLT_KONT_ASB";
                    KLT_KONT_ASB.TextFont.Underline = true;
                    KLT_KONT_ASB.TextFont.CharSet = 162;
                    KLT_KONT_ASB.Value = @"KLT. KONT. ASB.";

                    BOLUMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 156, 255, 161, false);
                    BOLUMAMIRI.Name = "BOLUMAMIRI";
                    BOLUMAMIRI.TextFont.Underline = true;
                    BOLUMAMIRI.TextFont.CharSet = 162;
                    BOLUMAMIRI.Value = @"BÖLÜM AMİRİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    Onaylar.CalcValue = @"";
                    NewField9.CalcValue = NewField9.Value;
                    BIRLIGI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Accountancymilitaryunit) : "");
                    ISISTEKTARIHI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestDate) : "");
                    ISTEKNOVETARIHI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "") + @" - " + MyParentReport.MAIN.ISISTEKTARIHI.FormattedValue;
                    NewField.CalcValue = NewField.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField1.CalcValue = NewField1.Value;
                    MALZEMEADI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    STOKNUMARASI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    MARKAMODELI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "") + @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "") + @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    NewField10.CalcValue = NewField10.Value;
                    NewField3.CalcValue = NewField3.Value;
                    MUAYENETARIHI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.CheckDate) : "");
                    NewField81.CalcValue = NewField81.Value;
                    BKM_ONR.CalcValue = BKM_ONR.Value;
                    MUA_KONT.CalcValue = MUA_KONT.Value;
                    BakimOnarimTeknisyen.CalcValue = @"";
                    BakimOnarimKismiAmir.CalcValue = @"";
                    MUA_KONT_KLT_ASB.CalcValue = @"";
                    MUA_KONT_KLT_BOLUM_AMIRI.CalcValue = @"";
                    TEKNISYEN.CalcValue = TEKNISYEN.Value;
                    KISIMAMIRI.CalcValue = KISIMAMIRI.Value;
                    KLT_KONT_ASB.CalcValue = KLT_KONT_ASB.Value;
                    BOLUMAMIRI.CalcValue = BOLUMAMIRI.Value;
                    return new TTReportObject[] { Onaylar,NewField9,BIRLIGI,ISISTEKTARIHI,ISTEKNOVETARIHI,NewField,NewField4,NewField5,NewField6,NewField7,NewField8,NewField1,MALZEMEADI,STOKNUMARASI,MARKAMODELI,NewField10,NewField3,MUAYENETARIHI,NewField81,BKM_ONR,MUA_KONT,BakimOnarimTeknisyen,BakimOnarimKismiAmir,MUA_KONT_KLT_ASB,MUA_KONT_KLT_BOLUM_AMIRI,TEKNISYEN,KISIMAMIRI,KLT_KONT_ASB,BOLUMAMIRI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.MyParentReport.RuntimeParameters.KISIMAMIRI.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.KISIMAMIRI.Value, typeof(ResUser));
                        //BakimOnarimKismiAmir.CalcValue =  muaKontR.Name;
                        BakimOnarimKismiAmir.CalcValue = "";
                        BakimOnarimKismiAmir.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        BakimOnarimKismiAmir.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        BakimOnarimKismiAmir.CalcValue += "\r\n" + muaKontR.Name;
                        BakimOnarimKismiAmir.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" +muaKontR.EmploymentRecordID.ToString() + ")" : "";
                    }

                    if (this.MyParentReport.RuntimeParameters.MUA_BOLUMAMIRI.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.MUA_BOLUMAMIRI.Value, typeof(ResUser));
                        //MUA_KONT_KLT_BOLUM_AMIRI.CalcValue =  muaKontR.Name;  // MCA
                        MUA_KONT_KLT_BOLUM_AMIRI.CalcValue = "";
                        MUA_KONT_KLT_BOLUM_AMIRI.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        MUA_KONT_KLT_BOLUM_AMIRI.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        MUA_KONT_KLT_BOLUM_AMIRI.CalcValue += "\r\n" + muaKontR.Name;
                        MUA_KONT_KLT_BOLUM_AMIRI.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";
                    }

                    if (this.MyParentReport.RuntimeParameters.MUA_KLT_KONT_ASB.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.MUA_KLT_KONT_ASB.Value, typeof(ResUser));
                        //MUA_KONT_KLT_ASB.CalcValue =  muaKontR.Name;  // MCA

                        MUA_KONT_KLT_ASB.CalcValue = "";
                        MUA_KONT_KLT_ASB.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        MUA_KONT_KLT_ASB.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        MUA_KONT_KLT_ASB.CalcValue += "\r\n" + muaKontR.Name;
                        MUA_KONT_KLT_ASB.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";
                    }

                    if (this.MyParentReport.RuntimeParameters.TEKNISYEN.HasValue)
                    {
                        ResUser muaKontR = (ResUser)this.ParentReport.ReportObjectContext.GetObject(this.MyParentReport.RuntimeParameters.TEKNISYEN.Value, typeof(ResUser));
                        //BakimOnarimTeknisyen.CalcValue =  muaKontR.Name; // MCA

                        BakimOnarimTeknisyen.CalcValue = "";
                        BakimOnarimTeknisyen.CalcValue += (muaKontR.MilitaryClass != null) ? muaKontR.MilitaryClass.ShortName : "";
                        BakimOnarimTeknisyen.CalcValue += (muaKontR.Rank != null) ? muaKontR.Rank.ShortName : "";
                        BakimOnarimTeknisyen.CalcValue += "\r\n" + muaKontR.Name;
                        BakimOnarimTeknisyen.CalcValue += (muaKontR.EmploymentRecordID != null) ? "\r\n(" + muaKontR.EmploymentRecordID.ToString() + ")" : "";
                    }
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

        public SonMuayeneKarti()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("TEKNISYEN", "00000000-0000-0000-0000-000000000000", "Bakım Onarım Teknisyeni", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("KISIMAMIRI", "00000000-0000-0000-0000-000000000000", "Bakım Onarım Kısım Amiri", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("MUA_KLT_KONT_ASB", "00000000-0000-0000-0000-000000000000", "Mua. Klt. Kontrol ASB", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("MUA_BOLUMAMIRI", "00000000-0000-0000-0000-000000000000", "MUA.KONT. KLT. Bölüm Amiri", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("TEKNISYEN"))
                _runtimeParameters.TEKNISYEN = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TEKNISYEN"]);
            if (parameters.ContainsKey("KISIMAMIRI"))
                _runtimeParameters.KISIMAMIRI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["KISIMAMIRI"]);
            if (parameters.ContainsKey("MUA_KLT_KONT_ASB"))
                _runtimeParameters.MUA_KLT_KONT_ASB = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MUA_KLT_KONT_ASB"]);
            if (parameters.ContainsKey("MUA_BOLUMAMIRI"))
                _runtimeParameters.MUA_BOLUMAMIRI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MUA_BOLUMAMIRI"]);
            Name = "SONMUAYENEKARTI";
            Caption = "Son Muayene Kartı (Ek-8.3)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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