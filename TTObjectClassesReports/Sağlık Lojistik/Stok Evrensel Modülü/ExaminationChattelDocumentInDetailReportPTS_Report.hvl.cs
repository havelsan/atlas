
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
    /// Muayene ve Kabul Komisyon Tutanağı
    /// </summary>
    public partial class ExaminationChattelDocumentInDetailReportPTS : TTReport
    {
#region Methods
   public double prices=0.0;
    public double inKDVPrices = 0.0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? BUDGETTYPE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ExaminationChattelDocumentInDetailReportPTS MyParentReport
            {
                get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111123 { get {return Header().NewField111123;} }
            public TTReportField NewField1321111 { get {return Header().NewField1321111;} }
            public TTReportField NewField11111231 { get {return Header().NewField11111231;} }
            public TTReportField NewField113211113 { get {return Header().NewField113211113;} }
            public TTReportField NewField1321113 { get {return Header().NewField1321113;} }
            public TTReportField NewField1321114 { get {return Header().NewField1321114;} }
            public TTReportField NewField1321116 { get {return Header().NewField1321116;} }
            public TTReportField DOCUMENTRECORDLOGNUMBER { get {return Header().DOCUMENTRECORDLOGNUMBER;} }
            public TTReportField DOCUMENTDATETIME { get {return Header().DOCUMENTDATETIME;} }
            public TTReportField BASEDATETIMENUMBER { get {return Header().BASEDATETIMENUMBER;} }
            public TTReportField HARCAMABIRIMI { get {return Header().HARCAMABIRIMI;} }
            public TTReportField DEPOSUAMBARI { get {return Header().DEPOSUAMBARI;} }
            public TTReportField HARCAMABIRIMIKODU { get {return Header().HARCAMABIRIMIKODU;} }
            public TTReportField DEPOSUAMBARIKODU { get {return Header().DEPOSUAMBARIKODU;} }
            public TTReportField NewField113211114 { get {return Header().NewField113211114;} }
            public TTReportField NewField16111231 { get {return Header().NewField16111231;} }
            public TTReportField NewField1311112311 { get {return Header().NewField1311112311;} }
            public TTReportField BUTCETURU { get {return Header().BUTCETURU;} }
            public TTReportField SAYISI { get {return Header().SAYISI;} }
            public TTReportField IHALEYONTEMITARIHINO { get {return Header().IHALEYONTEMITARIHINO;} }
            public TTReportField NewField113211111 { get {return Header().NewField113211111;} }
            public TTReportField NewField1111112311 { get {return Header().NewField1111112311;} }
            public TTReportField NewField1321112 { get {return Header().NewField1321112;} }
            public TTReportField NewField1321115 { get {return Header().NewField1321115;} }
            public TTReportField NewField1321117 { get {return Header().NewField1321117;} }
            public TTReportField DOCUMENTTRANSACTIONTYPE { get {return Header().DOCUMENTTRANSACTIONTYPE;} }
            public TTReportField DOCUMENTTRANSACTIONTYPEVALUE { get {return Header().DOCUMENTTRANSACTIONTYPEVALUE;} }
            public TTReportField CONCLUSIONDATETIMENUMBER { get {return Header().CONCLUSIONDATETIMENUMBER;} }
            public TTReportField IDARESI { get {return Header().IDARESI;} }
            public TTReportField TESLIMEDENFIRMA { get {return Header().TESLIMEDENFIRMA;} }
            public TTReportField IDARESIKODU { get {return Header().IDARESIKODU;} }
            public TTReportField TESLIMEDENFIRMAKODU { get {return Header().TESLIMEDENFIRMAKODU;} }
            public TTReportField MUAYENETARIHIVENO { get {return Header().MUAYENETARIHIVENO;} }
            public TTReportField HospitalInfo1111 { get {return Header().HospitalInfo1111;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public TTReportField STOCKACTIONOBJECTID { get {return Header().STOCKACTIONOBJECTID;} }
            public TTReportField DESCRIPTIONTOTAL { get {return Footer().DESCRIPTIONTOTAL;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField1311 { get {return Footer().NewField1311;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField DESCRIPTIONREPORT { get {return Footer().DESCRIPTIONREPORT;} }
            public TTReportField DESK1 { get {return Footer().DESK1;} }
            public TTReportField CHATTELDOCDESC { get {return Footer().CHATTELDOCDESC;} }
            public TTReportField CHATTELDOCTESAL { get {return Footer().CHATTELDOCTESAL;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField11211 { get {return Footer().NewField11211;} }
            public TTReportField NewField11311 { get {return Footer().NewField11311;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField UYE2 { get {return Footer().UYE2;} }
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
                public ExaminationChattelDocumentInDetailReportPTS MyParentReport
                {
                    get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
                }
                
                public TTReportField NewField111123;
                public TTReportField NewField1321111;
                public TTReportField NewField11111231;
                public TTReportField NewField113211113;
                public TTReportField NewField1321113;
                public TTReportField NewField1321114;
                public TTReportField NewField1321116;
                public TTReportField DOCUMENTRECORDLOGNUMBER;
                public TTReportField DOCUMENTDATETIME;
                public TTReportField BASEDATETIMENUMBER;
                public TTReportField HARCAMABIRIMI;
                public TTReportField DEPOSUAMBARI;
                public TTReportField HARCAMABIRIMIKODU;
                public TTReportField DEPOSUAMBARIKODU;
                public TTReportField NewField113211114;
                public TTReportField NewField16111231;
                public TTReportField NewField1311112311;
                public TTReportField BUTCETURU;
                public TTReportField SAYISI;
                public TTReportField IHALEYONTEMITARIHINO;
                public TTReportField NewField113211111;
                public TTReportField NewField1111112311;
                public TTReportField NewField1321112;
                public TTReportField NewField1321115;
                public TTReportField NewField1321117;
                public TTReportField DOCUMENTTRANSACTIONTYPE;
                public TTReportField DOCUMENTTRANSACTIONTYPEVALUE;
                public TTReportField CONCLUSIONDATETIMENUMBER;
                public TTReportField IDARESI;
                public TTReportField TESLIMEDENFIRMA;
                public TTReportField IDARESIKODU;
                public TTReportField TESLIMEDENFIRMAKODU;
                public TTReportField MUAYENETARIHIVENO;
                public TTReportField HospitalInfo1111;
                public TTReportField NewField111;
                public TTReportField LOGO11;
                public TTReportField STOCKACTIONOBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 75;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 61, 46, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111123.TextFont.Size = 10;
                    NewField111123.TextFont.Bold = true;
                    NewField111123.Value = @"TİF No";

                    NewField1321111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 41, 170, 46, false);
                    NewField1321111.Name = "NewField1321111";
                    NewField1321111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1321111.TextFont.Size = 10;
                    NewField1321111.TextFont.Bold = true;
                    NewField1321111.Value = @"Muayene Tarihi";

                    NewField11111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 46, 170, 57, false);
                    NewField11111231.Name = "NewField11111231";
                    NewField11111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111231.TextFont.Size = 10;
                    NewField11111231.TextFont.Bold = true;
                    NewField11111231.Value = @"Kodu";

                    NewField113211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 62, 170, 67, false);
                    NewField113211113.Name = "NewField113211113";
                    NewField113211113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211113.TextFont.Size = 10;
                    NewField113211113.TextFont.Bold = true;
                    NewField113211113.Value = @"Sayısı";

                    NewField1321113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 61, 57, false);
                    NewField1321113.Name = "NewField1321113";
                    NewField1321113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321113.TextFont.Size = 10;
                    NewField1321113.TextFont.Bold = true;
                    NewField1321113.Value = @"Harcama Birimi Adı";

                    NewField1321114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 57, 61, 62, false);
                    NewField1321114.Name = "NewField1321114";
                    NewField1321114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321114.TextFont.Size = 10;
                    NewField1321114.TextFont.Bold = true;
                    NewField1321114.Value = @"Ambarın Adı";

                    NewField1321116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 61, 67, false);
                    NewField1321116.Name = "NewField1321116";
                    NewField1321116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321116.TextFont.Size = 10;
                    NewField1321116.TextFont.Bold = true;
                    NewField1321116.Value = @"Dayanak Belge Tarihi";

                    DOCUMENTRECORDLOGNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 41, 83, 46, false);
                    DOCUMENTRECORDLOGNUMBER.Name = "DOCUMENTRECORDLOGNUMBER";
                    DOCUMENTRECORDLOGNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTRECORDLOGNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTRECORDLOGNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTRECORDLOGNUMBER.ObjectDefName = "DocumentRecordLog";
                    DOCUMENTRECORDLOGNUMBER.DataMember = "DOCUMENTRECORDLOGNUMBER";
                    DOCUMENTRECORDLOGNUMBER.TextFont.Size = 10;
                    DOCUMENTRECORDLOGNUMBER.Value = @"{@TTOBJECTID@}  ";

                    DOCUMENTDATETIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 58, 290, 63, false);
                    DOCUMENTDATETIME.Name = "DOCUMENTDATETIME";
                    DOCUMENTDATETIME.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTDATETIME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTDATETIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATETIME.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATETIME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTDATETIME.ObjectDefName = "DocumentRecordLog";
                    DOCUMENTDATETIME.DataMember = "DOCUMENTDATETIME";
                    DOCUMENTDATETIME.TextFont.Size = 10;
                    DOCUMENTDATETIME.Value = @"{@TTOBJECTID@}  ";

                    BASEDATETIMENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 62, 145, 67, false);
                    BASEDATETIMENUMBER.Name = "BASEDATETIMENUMBER";
                    BASEDATETIMENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    BASEDATETIMENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASEDATETIMENUMBER.TextFont.Size = 10;
                    BASEDATETIMENUMBER.Value = @"";

                    HARCAMABIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 46, 145, 57, false);
                    HARCAMABIRIMI.Name = "HARCAMABIRIMI";
                    HARCAMABIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMI.FieldType = ReportFieldTypeEnum.ftExpression;
                    HARCAMABIRIMI.VertAlign = VerticalAlignmentEnum.vaTop;
                    HARCAMABIRIMI.MultiLine = EvetHayirEnum.ehEvet;
                    HARCAMABIRIMI.WordBreak = EvetHayirEnum.ehEvet;
                    HARCAMABIRIMI.TextFont.Size = 9;
                    HARCAMABIRIMI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    DEPOSUAMBARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 57, 145, 62, false);
                    DEPOSUAMBARI.Name = "DEPOSUAMBARI";
                    DEPOSUAMBARI.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPOSUAMBARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPOSUAMBARI.TextFont.Size = 10;
                    DEPOSUAMBARI.Value = @"";

                    HARCAMABIRIMIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 46, 200, 57, false);
                    HARCAMABIRIMIKODU.Name = "HARCAMABIRIMIKODU";
                    HARCAMABIRIMIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    HARCAMABIRIMIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HARCAMABIRIMIKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HARCAMABIRIMIKODU.TextFont.Size = 10;
                    HARCAMABIRIMIKODU.Value = @"";

                    DEPOSUAMBARIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 57, 200, 62, false);
                    DEPOSUAMBARIKODU.Name = "DEPOSUAMBARIKODU";
                    DEPOSUAMBARIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPOSUAMBARIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPOSUAMBARIKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEPOSUAMBARIKODU.TextFont.Size = 10;
                    DEPOSUAMBARIKODU.Value = @"";

                    NewField113211114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 57, 170, 62, false);
                    NewField113211114.Name = "NewField113211114";
                    NewField113211114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211114.TextFont.Size = 10;
                    NewField113211114.TextFont.Bold = true;
                    NewField113211114.Value = @"Kodu";

                    NewField16111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 61, 76, false);
                    NewField16111231.Name = "NewField16111231";
                    NewField16111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16111231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16111231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16111231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16111231.TextFont.Size = 10;
                    NewField16111231.TextFont.Bold = true;
                    NewField16111231.Value = @"İhale Yönetimi - İhale
 Tarih ve No";

                    NewField1311112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 67, 145, 76, false);
                    NewField1311112311.Name = "NewField1311112311";
                    NewField1311112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112311.TextFont.Size = 10;
                    NewField1311112311.TextFont.Bold = true;
                    NewField1311112311.Value = @"Bütçe Türü";

                    BUTCETURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 67, 200, 76, false);
                    BUTCETURU.Name = "BUTCETURU";
                    BUTCETURU.DrawStyle = DrawStyleConstants.vbSolid;
                    BUTCETURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCETURU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BUTCETURU.TextFont.Size = 10;
                    BUTCETURU.Value = @"";

                    SAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 62, 200, 67, false);
                    SAYISI.Name = "SAYISI";
                    SAYISI.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAYISI.TextFont.Size = 10;
                    SAYISI.Value = @"";

                    IHALEYONTEMITARIHINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 67, 120, 76, false);
                    IHALEYONTEMITARIHINO.Name = "IHALEYONTEMITARIHINO";
                    IHALEYONTEMITARIHINO.DrawStyle = DrawStyleConstants.vbSolid;
                    IHALEYONTEMITARIHINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEYONTEMITARIHINO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IHALEYONTEMITARIHINO.TextFont.Size = 10;
                    IHALEYONTEMITARIHINO.Value = @"";

                    NewField113211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 39, 224, 44, false);
                    NewField113211111.Name = "NewField113211111";
                    NewField113211111.Visible = EvetHayirEnum.ehHayir;
                    NewField113211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211111.TextFont.Bold = true;
                    NewField113211111.Value = @"KODU";

                    NewField1111112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 54, 254, 59, false);
                    NewField1111112311.Name = "NewField1111112311";
                    NewField1111112311.Visible = EvetHayirEnum.ehHayir;
                    NewField1111112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112311.TextFont.Bold = true;
                    NewField1111112311.Value = @"İŞLEM ÇEŞİDİ";

                    NewField1321112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 34, 264, 39, false);
                    NewField1321112.Name = "NewField1321112";
                    NewField1321112.Visible = EvetHayirEnum.ehHayir;
                    NewField1321112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321112.TextFont.Bold = true;
                    NewField1321112.Value = @"İDARESİ";

                    NewField1321115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 29, 264, 34, false);
                    NewField1321115.Name = "NewField1321115";
                    NewField1321115.Visible = EvetHayirEnum.ehHayir;
                    NewField1321115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321115.TextFont.Bold = true;
                    NewField1321115.Value = @"TESLİM EDEN FİRMA";

                    NewField1321117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 44, 306, 49, false);
                    NewField1321117.Name = "NewField1321117";
                    NewField1321117.Visible = EvetHayirEnum.ehHayir;
                    NewField1321117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321117.TextFont.Bold = true;
                    NewField1321117.Value = @"MUAYENE VE KABUL KOMİSYON RAPORU TARİH / SAYI ";

                    DOCUMENTTRANSACTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 59, 254, 64, false);
                    DOCUMENTTRANSACTIONTYPE.Name = "DOCUMENTTRANSACTIONTYPE";
                    DOCUMENTTRANSACTIONTYPE.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTTRANSACTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCUMENTTRANSACTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTTRANSACTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCUMENTTRANSACTIONTYPE.ObjectDefName = "DocumentTransactionTypeEnum";
                    DOCUMENTTRANSACTIONTYPE.DataMember = "DISPLAYTEXT";
                    DOCUMENTTRANSACTIONTYPE.TextFont.Name = "Arial";
                    DOCUMENTTRANSACTIONTYPE.Value = @"{%DOCUMENTTRANSACTIONTYPEVALUE%}";

                    DOCUMENTTRANSACTIONTYPEVALUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 65, 254, 70, false);
                    DOCUMENTTRANSACTIONTYPEVALUE.Name = "DOCUMENTTRANSACTIONTYPEVALUE";
                    DOCUMENTTRANSACTIONTYPEVALUE.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTTRANSACTIONTYPEVALUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTTRANSACTIONTYPEVALUE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DOCUMENTTRANSACTIONTYPEVALUE.ObjectDefName = "DocumentRecordLog";
                    DOCUMENTTRANSACTIONTYPEVALUE.DataMember = "DOCUMENTTRANSACTIONTYPE";
                    DOCUMENTTRANSACTIONTYPEVALUE.TextFont.Name = "Arial";
                    DOCUMENTTRANSACTIONTYPEVALUE.Value = @"{@TTOBJECTID@}  ";

                    CONCLUSIONDATETIMENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 41, 200, 46, false);
                    CONCLUSIONDATETIMENUMBER.Name = "CONCLUSIONDATETIMENUMBER";
                    CONCLUSIONDATETIMENUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    CONCLUSIONDATETIMENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONDATETIMENUMBER.TextFont.Size = 10;
                    CONCLUSIONDATETIMENUMBER.Value = @"";

                    IDARESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 34, 290, 39, false);
                    IDARESI.Name = "IDARESI";
                    IDARESI.Visible = EvetHayirEnum.ehHayir;
                    IDARESI.DrawStyle = DrawStyleConstants.vbSolid;
                    IDARESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDARESI.TextFont.Size = 10;
                    IDARESI.Value = @"";

                    TESLIMEDENFIRMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 29, 296, 34, false);
                    TESLIMEDENFIRMA.Name = "TESLIMEDENFIRMA";
                    TESLIMEDENFIRMA.Visible = EvetHayirEnum.ehHayir;
                    TESLIMEDENFIRMA.DrawStyle = DrawStyleConstants.vbSolid;
                    TESLIMEDENFIRMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDENFIRMA.TextFont.Size = 10;
                    TESLIMEDENFIRMA.Value = @"";

                    IDARESIKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 290, 34, 309, 39, false);
                    IDARESIKODU.Name = "IDARESIKODU";
                    IDARESIKODU.Visible = EvetHayirEnum.ehHayir;
                    IDARESIKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    IDARESIKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDARESIKODU.TextFont.Size = 8;
                    IDARESIKODU.Value = @"";

                    TESLIMEDENFIRMAKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 39, 243, 44, false);
                    TESLIMEDENFIRMAKODU.Name = "TESLIMEDENFIRMAKODU";
                    TESLIMEDENFIRMAKODU.Visible = EvetHayirEnum.ehHayir;
                    TESLIMEDENFIRMAKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    TESLIMEDENFIRMAKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDENFIRMAKODU.TextFont.Size = 8;
                    TESLIMEDENFIRMAKODU.Value = @"";

                    MUAYENETARIHIVENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 51, 307, 56, false);
                    MUAYENETARIHIVENO.Name = "MUAYENETARIHIVENO";
                    MUAYENETARIHIVENO.Visible = EvetHayirEnum.ehHayir;
                    MUAYENETARIHIVENO.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENETARIHIVENO.VertAlign = VerticalAlignmentEnum.vaTop;
                    MUAYENETARIHIVENO.TextFont.Size = 10;
                    MUAYENETARIHIVENO.TextFont.CharSet = 1;
                    MUAYENETARIHIVENO.Value = @"";

                    HospitalInfo1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 200, 27, false);
                    HospitalInfo1111.Name = "HospitalInfo1111";
                    HospitalInfo1111.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo1111.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo1111.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo1111.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo1111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 33, 200, 41, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"MUAYENE VE KABUL KOMİSYON TUTANAĞI
";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 3, 200, 20, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO11.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO11.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO11.DataMember = "EMBLEM";
                    LOGO11.TextFont.Name = "Courier New";
                    LOGO11.TextFont.Size = 10;
                    LOGO11.Value = @"";

                    STOCKACTIONOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 12, 274, 17, false);
                    STOCKACTIONOBJECTID.Name = "STOCKACTIONOBJECTID";
                    STOCKACTIONOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONOBJECTID.VertAlign = VerticalAlignmentEnum.vaTop;
                    STOCKACTIONOBJECTID.TextFont.Size = 10;
                    STOCKACTIONOBJECTID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111123.CalcValue = NewField111123.Value;
                    NewField1321111.CalcValue = NewField1321111.Value;
                    NewField11111231.CalcValue = NewField11111231.Value;
                    NewField113211113.CalcValue = NewField113211113.Value;
                    NewField1321113.CalcValue = NewField1321113.Value;
                    NewField1321114.CalcValue = NewField1321114.Value;
                    NewField1321116.CalcValue = NewField1321116.Value;
                    DOCUMENTRECORDLOGNUMBER.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DOCUMENTRECORDLOGNUMBER.PostFieldValueCalculation();
                    DOCUMENTDATETIME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DOCUMENTDATETIME.PostFieldValueCalculation();
                    BASEDATETIMENUMBER.CalcValue = @"";
                    DEPOSUAMBARI.CalcValue = @"";
                    HARCAMABIRIMIKODU.CalcValue = @"";
                    DEPOSUAMBARIKODU.CalcValue = @"";
                    NewField113211114.CalcValue = NewField113211114.Value;
                    NewField16111231.CalcValue = NewField16111231.Value;
                    NewField1311112311.CalcValue = NewField1311112311.Value;
                    BUTCETURU.CalcValue = @"";
                    SAYISI.CalcValue = @"";
                    IHALEYONTEMITARIHINO.CalcValue = @"";
                    NewField113211111.CalcValue = NewField113211111.Value;
                    NewField1111112311.CalcValue = NewField1111112311.Value;
                    NewField1321112.CalcValue = NewField1321112.Value;
                    NewField1321115.CalcValue = NewField1321115.Value;
                    NewField1321117.CalcValue = NewField1321117.Value;
                    DOCUMENTTRANSACTIONTYPEVALUE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    DOCUMENTTRANSACTIONTYPEVALUE.PostFieldValueCalculation();
                    DOCUMENTTRANSACTIONTYPE.CalcValue = MyParentReport.PARTA.DOCUMENTTRANSACTIONTYPEVALUE.CalcValue;
                    DOCUMENTTRANSACTIONTYPE.PostFieldValueCalculation();
                    CONCLUSIONDATETIMENUMBER.CalcValue = @"";
                    IDARESI.CalcValue = @"";
                    TESLIMEDENFIRMA.CalcValue = @"";
                    IDARESIKODU.CalcValue = @"";
                    TESLIMEDENFIRMAKODU.CalcValue = @"";
                    MUAYENETARIHIVENO.CalcValue = MUAYENETARIHIVENO.Value;
                    NewField111.CalcValue = NewField111.Value;
                    LOGO11.CalcValue = @"";
                    STOCKACTIONOBJECTID.CalcValue = @"";
                    HARCAMABIRIMI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    HospitalInfo1111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField111123,NewField1321111,NewField11111231,NewField113211113,NewField1321113,NewField1321114,NewField1321116,DOCUMENTRECORDLOGNUMBER,DOCUMENTDATETIME,BASEDATETIMENUMBER,DEPOSUAMBARI,HARCAMABIRIMIKODU,DEPOSUAMBARIKODU,NewField113211114,NewField16111231,NewField1311112311,BUTCETURU,SAYISI,IHALEYONTEMITARIHINO,NewField113211111,NewField1111112311,NewField1321112,NewField1321115,NewField1321117,DOCUMENTTRANSACTIONTYPEVALUE,DOCUMENTTRANSACTIONTYPE,CONCLUSIONDATETIMENUMBER,IDARESI,TESLIMEDENFIRMA,IDARESIKODU,TESLIMEDENFIRMAKODU,MUAYENETARIHIVENO,NewField111,LOGO11,STOCKACTIONOBJECTID,HARCAMABIRIMI,HospitalInfo1111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));
                Guid stockActionObjectID = documentRecordLog.StockAction.ObjectID;
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(stockActionObjectID, typeof(StockAction));
                STOCKACTIONOBJECTID.CalcValue = stockActionObjectID.ToString();
                if (stockAction is IBaseChattelDocument)
                {
                    IBaseChattelDocument baseChattelDocument = (IBaseChattelDocument)stockAction;
                    //  BASEDATETIMENUMBER.CalcValue = baseChattelDocument.BaseDateTime.Value.ToString("dd.MM.yyyy") + " / " + baseChattelDocument.BaseNumber;
                }

                if (stockAction is IChattelDocumentWithPurchase)
                {
                    IChattelDocumentWithPurchase chattelDocumentWithPurchase = (IChattelDocumentWithPurchase)stockAction;
                    //CONCLUSIONDATETIMENUMBER.CalcValue = chattelDocumentWithPurchase.ConclusionDateTime.Value.ToString("dd.MM.yyyy") + " / " + chattelDocumentWithPurchase.ConclusionNumber;
                    //CONCLUSIONDATETIMENUMBER.CalcValue = chattelDocumentWithPurchase.GetConclusionDateTime() != null ? chattelDocumentWithPurchase.GetConclusionDateTime().Value.ToString("dd.MM.yyyy") : " " + " / " + chattelDocumentWithPurchase.GetConclusionNumber();
                    CONCLUSIONDATETIMENUMBER.CalcValue = chattelDocumentWithPurchase.GetExaminationReportDate() != null ? chattelDocumentWithPurchase.GetExaminationReportDate().Value.ToString("dd.MM.yyyy") : " " + " / " + chattelDocumentWithPurchase.GetExaminationReportNo();
                    DEPOSUAMBARI.CalcValue = chattelDocumentWithPurchase.GetStore().GetName();
                    DEPOSUAMBARIKODU.CalcValue = chattelDocumentWithPurchase.GetStore().GetQREF();
                    if (chattelDocumentWithPurchase.GetSupplier().GetCode().Value.HasValue)
                        TESLIMEDENFIRMAKODU.CalcValue = chattelDocumentWithPurchase.GetSupplier().GetCode().Value.ToString();
                    
                    SAYISI.CalcValue = chattelDocumentWithPurchase.GetWaybill().ToString();
                    IHALEYONTEMITARIHINO.CalcValue = ((MKYS_EAlimYontemiEnum)stockAction.MKYS_EAlimYontemi).ToString().ToUpper()+ " " + ((DateTime)chattelDocumentWithPurchase.GetAuctionDate()).ToShortDateString()+"-"+chattelDocumentWithPurchase.GetRegistrationAuctionNo().ToString();
                    if(chattelDocumentWithPurchase.GetExaminationReportNo() != null)
                        MUAYENETARIHIVENO.CalcValue = DOCUMENTDATETIME.CalcValue +"/"+ chattelDocumentWithPurchase.GetExaminationReportNo().ToString();
                    else
                        MUAYENETARIHIVENO.CalcValue = DOCUMENTDATETIME.CalcValue;
                    BUTCETURU.CalcValue = stockAction.BudgetTypeDefinition.Name.ToString().ToUpper();
                    BASEDATETIMENUMBER.CalcValue = ((DateTime)chattelDocumentWithPurchase.GetWaybillDate()).ToShortDateString();
                }
                
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ExaminationChattelDocumentInDetailReportPTS MyParentReport
                {
                    get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
                }
                
                public TTReportField DESCRIPTIONTOTAL;
                public TTReportField NewField15;
                public TTReportField NewField121;
                public TTReportField NewField1311;
                public TTReportField NewField13;
                public TTReportField DESCRIPTIONREPORT;
                public TTReportField DESK1;
                public TTReportField CHATTELDOCDESC;
                public TTReportField CHATTELDOCTESAL;
                public TTReportField NewField141;
                public TTReportField NewField11211;
                public TTReportField NewField11311;
                public TTReportField NewField11411;
                public TTReportField BASKAN;
                public TTReportField UYE1;
                public TTReportField UYE2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 124;
                    RepeatCount = 0;
                    
                    DESCRIPTIONTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 31, 201, 40, false);
                    DESCRIPTIONTOTAL.Name = "DESCRIPTIONTOTAL";
                    DESCRIPTIONTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONTOTAL.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONTOTAL.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOTAL.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTIONTOTAL.TextFont.Size = 9;
                    DESCRIPTIONTOTAL.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 25, 201, 30, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 10;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Muayene Komisyonu Başkanlığına;";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 35, 270, 40, false);
                    NewField121.Name = "NewField121";
                    NewField121.Visible = EvetHayirEnum.ehHayir;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121.TextFont.Size = 10;
                    NewField121.TextFont.CharSet = 1;
                    NewField121.Value = @"TESLİM ALAN";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 66, 261, 71, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.Visible = EvetHayirEnum.ehHayir;
                    NewField1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311.TextFont.Size = 9;
                    NewField1311.Value = @"Taşınır Kayıt Kontrol Yetkilisi";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 71, 261, 76, false);
                    NewField13.Name = "NewField13";
                    NewField13.Visible = EvetHayirEnum.ehHayir;
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.TextFormat = @"dd/MM/yyyy";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.CharSet = 1;
                    NewField13.Value = @"{@printdate@}";

                    DESCRIPTIONREPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 201, 66, false);
                    DESCRIPTIONREPORT.Name = "DESCRIPTIONREPORT";
                    DESCRIPTIONREPORT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTIONREPORT.VertAlign = VerticalAlignmentEnum.vaTop;
                    DESCRIPTIONREPORT.TextFont.Size = 10;
                    DESCRIPTIONREPORT.Value = @"";

                    DESK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 28, 11, false);
                    DESK1.Name = "DESK1";
                    DESK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESK1.TextFont.Size = 10;
                    DESK1.Value = @"AÇIKLAMA :";

                    CHATTELDOCDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 3, 201, 22, false);
                    CHATTELDOCDESC.Name = "CHATTELDOCDESC";
                    CHATTELDOCDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHATTELDOCDESC.VertAlign = VerticalAlignmentEnum.vaTop;
                    CHATTELDOCDESC.MultiLine = EvetHayirEnum.ehEvet;
                    CHATTELDOCDESC.WordBreak = EvetHayirEnum.ehEvet;
                    CHATTELDOCDESC.TextFont.Size = 8;
                    CHATTELDOCDESC.Value = @"";

                    CHATTELDOCTESAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 40, 270, 45, false);
                    CHATTELDOCTESAL.Name = "CHATTELDOCTESAL";
                    CHATTELDOCTESAL.Visible = EvetHayirEnum.ehHayir;
                    CHATTELDOCTESAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHATTELDOCTESAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHATTELDOCTESAL.VertAlign = VerticalAlignmentEnum.vaTop;
                    CHATTELDOCTESAL.WordBreak = EvetHayirEnum.ehEvet;
                    CHATTELDOCTESAL.TextFont.Name = "Arial";
                    CHATTELDOCTESAL.TextFont.Size = 9;
                    CHATTELDOCTESAL.Value = @"";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 72, 140, 77, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @"MUAYENE KABUL KOMİSYONU";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 82, 49, 87, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.TextFont.Size = 10;
                    NewField11211.TextFont.CharSet = 1;
                    NewField11211.Value = @"Komisyon Başkanı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 82, 127, 87, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.TextFont.Size = 10;
                    NewField11311.TextFont.CharSet = 1;
                    NewField11311.Value = @"Üye";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 82, 193, 87, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.TextFont.Size = 10;
                    NewField11411.TextFont.CharSet = 1;
                    NewField11411.Value = @"Üye";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 95, 54, 100, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASKAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASKAN.VertAlign = VerticalAlignmentEnum.vaTop;
                    BASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    BASKAN.TextFont.Name = "Arial";
                    BASKAN.TextFont.Size = 9;
                    BASKAN.Value = @"";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 95, 131, 100, false);
                    UYE1.Name = "UYE1";
                    UYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE1.VertAlign = VerticalAlignmentEnum.vaTop;
                    UYE1.WordBreak = EvetHayirEnum.ehEvet;
                    UYE1.TextFont.Name = "Arial";
                    UYE1.TextFont.Size = 9;
                    UYE1.Value = @"";

                    UYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 95, 197, 100, false);
                    UYE2.Name = "UYE2";
                    UYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE2.VertAlign = VerticalAlignmentEnum.vaTop;
                    UYE2.WordBreak = EvetHayirEnum.ehEvet;
                    UYE2.TextFont.Name = "Arial";
                    UYE2.TextFont.Size = 9;
                    UYE2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTIONTOTAL.CalcValue = @"";
                    NewField15.CalcValue = NewField15.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField13.CalcValue = DateTime.Now.ToShortDateString();
                    DESCRIPTIONREPORT.CalcValue = @"";
                    DESK1.CalcValue = DESK1.Value;
                    CHATTELDOCDESC.CalcValue = @"";
                    CHATTELDOCTESAL.CalcValue = @"";
                    NewField141.CalcValue = NewField141.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    BASKAN.CalcValue = @"";
                    UYE1.CalcValue = @"";
                    UYE2.CalcValue = @"";
                    return new TTReportObject[] { DESCRIPTIONTOTAL,NewField15,NewField121,NewField1311,NewField13,DESCRIPTIONREPORT,DESK1,CHATTELDOCDESC,CHATTELDOCTESAL,NewField141,NewField11211,NewField11311,NewField11411,BASKAN,UYE1,UYE2};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));
                Guid stockActionObjectID = documentRecordLog.StockAction.ObjectID;
                StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(stockActionObjectID, typeof(StockAction));
                if (stockAction is IChattelDocumentWithPurchase)
                {
                    string baskan = string.Empty;
                    string uye1 = string.Empty;
                    string uye2 = string.Empty;
                    foreach (StockActionSignDetail stockActionSignDetail in stockAction.StockActionSignDetails)
                    {
                        string signDesc = string.Empty;
                        if(stockActionSignDetail.SignUser != null)
                        {
                            signDesc = stockActionSignDetail.SignUser.Name;
                            if(stockActionSignDetail.SignUserType == SignUserTypeEnum.Baskan)
                            {
                                baskan = signDesc;
                            }
                            else
                            {
                                if(string.IsNullOrEmpty(uye1))
                                    uye1 = signDesc;
                                else
                                    uye2 = signDesc;
                            }
                        }
                    }
                    this.BASKAN.CalcValue = baskan;
                    this.UYE1.CalcValue = uye1;
                    this.UYE2.CalcValue = uye2;
                    
                    IChattelDocumentWithPurchase chattelDocumentWithPurchase = (IChattelDocumentWithPurchase)stockAction;
                    string closer1 = "  Yukarıda ismi geçen firma tarafından depoya getirilen (" + TTReportTool.Common.SpellNumber(documentRecordLog.NumberOfRows.ToString()) + ") kalem (Demirbaş/Tüketim) malzemesinin cinsi ve miktarı yukarıda çıkartılmıştır.Muayenenin yapılmasını arz ederim.";
                    DESCRIPTIONTOTAL.CalcValue = closer1;
                    
                    string closer = " MUAYENE VE KABUL KOMİSYONUMUZ, yüklenici firma; " + chattelDocumentWithPurchase.GetSupplier().GetName().ToString()+" hazır bulunarak"+
                        ((DateTime)chattelDocumentWithPurchase.GetExaminationReportDate()).ToShortDateString() +
                        " tarihinde XXXXXXmiz muayene kabul komisyonu odasında toplanılarak,alınan malzemenin incelemeyi kolaylaştıracak mahiyette "+
                        " düzenli bir şekilde sunulduğu teslim edilen malın şartname ve sözleşmesinde belirtilen evsafa uygun olduğu görülmüştür. ";
                    DESCRIPTIONREPORT.CalcValue = closer;
                    
                    CHATTELDOCDESC.CalcValue = stockAction.Description;
                    CHATTELDOCTESAL.CalcValue = stockAction.MKYS_TeslimAlan;
                }
                
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public ExaminationChattelDocumentInDetailReportPTS MyParentReport
            {
                get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField1311111 { get {return Header().NewField1311111;} }
            public TTReportField NewField1311112 { get {return Header().NewField1311112;} }
            public TTReportField SUMOFPRICE { get {return Footer().SUMOFPRICE;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField KDVSIZTOPLAMFIYAT { get {return Footer().KDVSIZTOPLAMFIYAT;} }
            public TTReportField KDVORANFIYAT { get {return Footer().KDVORANFIYAT;} }
            public TTReportField KDVLITOPLAMFIYAT { get {return Footer().KDVLITOPLAMFIYAT;} }
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
                public ExaminationChattelDocumentInDetailReportPTS MyParentReport
                {
                    get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField111113;
                public TTReportField NewField1311111;
                public TTReportField NewField1311112; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 200, 7, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"T  A  Ş  I  N  I  R  I  N";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 19, 16, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Size = 10;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Sıra No.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 7, 53, 16, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Size = 10;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Taşınır Kodu";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 7, 124, 16, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Size = 10;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"Malzemenin Cinsi (İhale Kalem no su)";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 7, 159, 16, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.TextFont.Size = 10;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.Value = @"Birimi
";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 7, 144, 16, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111113.TextFont.Size = 10;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.Value = @"Miktarı";

                    NewField1311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 7, 178, 16, false);
                    NewField1311111.Name = "NewField1311111";
                    NewField1311111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311111.TextFont.Size = 10;
                    NewField1311111.TextFont.Bold = true;
                    NewField1311111.Value = @"Birim Fiyatı";

                    NewField1311112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 7, 200, 16, false);
                    NewField1311112.Name = "NewField1311112";
                    NewField1311112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1311112.TextFont.Size = 10;
                    NewField1311112.TextFont.Bold = true;
                    NewField1311112.Value = @"Toplam Fiyatı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1311111.CalcValue = NewField1311111.Value;
                    NewField1311112.CalcValue = NewField1311112.Value;
                    return new TTReportObject[] { NewField111,NewField1111,NewField11111,NewField111111,NewField111112,NewField111113,NewField1311111,NewField1311112};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ExaminationChattelDocumentInDetailReportPTS MyParentReport
                {
                    get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
                }
                
                public TTReportField SUMOFPRICE;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField112;
                public TTReportField KDVSIZTOPLAMFIYAT;
                public TTReportField KDVORANFIYAT;
                public TTReportField KDVLITOPLAMFIYAT; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    RepeatCount = 0;
                    
                    SUMOFPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 0, 250, 5, false);
                    SUMOFPRICE.Name = "SUMOFPRICE";
                    SUMOFPRICE.Visible = EvetHayirEnum.ehHayir;
                    SUMOFPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUMOFPRICE.TextFormat = @"#,###.######";
                    SUMOFPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    SUMOFPRICE.TextFont.Size = 10;
                    SUMOFPRICE.TextFont.CharSet = 1;
                    SUMOFPRICE.Value = @"{@sumof(PRICE)@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 178, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"Toplam Fiyat  ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 178, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.CharSet = 1;
                    NewField11.Value = @"KDV  ";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 178, 15, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField112.TextFont.Size = 10;
                    NewField112.TextFont.CharSet = 1;
                    NewField112.Value = @"KDV Dahil Genel Toplam  ";

                    KDVSIZTOPLAMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 0, 200, 5, false);
                    KDVSIZTOPLAMFIYAT.Name = "KDVSIZTOPLAMFIYAT";
                    KDVSIZTOPLAMFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    KDVSIZTOPLAMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    KDVSIZTOPLAMFIYAT.TextFormat = @"#,##0.00";
                    KDVSIZTOPLAMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDVSIZTOPLAMFIYAT.TextFont.Size = 8;
                    KDVSIZTOPLAMFIYAT.Value = @"";

                    KDVORANFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 5, 200, 10, false);
                    KDVORANFIYAT.Name = "KDVORANFIYAT";
                    KDVORANFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    KDVORANFIYAT.TextFormat = @"#,###.######";
                    KDVORANFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDVORANFIYAT.TextFont.Size = 8;
                    KDVORANFIYAT.Value = @"";

                    KDVLITOPLAMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 10, 200, 15, false);
                    KDVLITOPLAMFIYAT.Name = "KDVLITOPLAMFIYAT";
                    KDVLITOPLAMFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    KDVLITOPLAMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    KDVLITOPLAMFIYAT.TextFormat = @"#,##0.00";
                    KDVLITOPLAMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDVLITOPLAMFIYAT.TextFont.Size = 8;
                    KDVLITOPLAMFIYAT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SUMOFPRICE.CalcValue = ParentGroup.FieldSums["PRICE"].Value.ToString();;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField112.CalcValue = NewField112.Value;
                    KDVSIZTOPLAMFIYAT.CalcValue = @"";
                    KDVORANFIYAT.CalcValue = KDVORANFIYAT.Value;
                    KDVLITOPLAMFIYAT.CalcValue = @"";
                    return new TTReportObject[] { SUMOFPRICE,NewField1,NewField11,NewField112,KDVSIZTOPLAMFIYAT,KDVORANFIYAT,KDVLITOPLAMFIYAT};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    //KDVSIZTOPLAMFIYAT.CalcValue = this.MyParentReport.prices.ToString();
            //KDVLITOPLAMFIYAT.CalcValue = this.MyParentReport.inKDVPrices.ToString();
            //KDVORANFIYAT.CalcValue =(double.Parse(KDVLITOPLAMFIYAT.CalcValue) - double.Parse(KDVSIZTOPLAMFIYAT.CalcValue)).ToString();
            
            KDVSIZTOPLAMFIYAT.CalcValue = this.MyParentReport.prices.ToString();
            double toplamFiyat = Math.Round(double.Parse(this.MyParentReport.inKDVPrices.ToString()),2);
            KDVLITOPLAMFIYAT.CalcValue = toplamFiyat.ToString();
            double oranFiyat = Math.Round(double.Parse(KDVLITOPLAMFIYAT.CalcValue) - double.Parse(KDVSIZTOPLAMFIYAT.CalcValue),2);
            KDVORANFIYAT.CalcValue =oranFiyat.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ExaminationChattelDocumentInDetailReportPTS MyParentReport
            {
                get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField PRICECALC { get {return Body().PRICECALC;} }
            public TTReportField UNITPRICENOTKDV { get {return Body().UNITPRICENOTKDV;} }
            public TTReportField VATRATE { get {return Body().VATRATE;} }
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
                list[0] = new TTReportNqlData<StockTransaction.PTSStockTrxRQ_Class>("PTSStockTrxRQ", StockTransaction.PTSStockTrxRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTA.STOCKACTIONOBJECTID.CalcValue),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.BUDGETTYPE)));
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
                public ExaminationChattelDocumentInDetailReportPTS MyParentReport
                {
                    get { return (ExaminationChattelDocumentInDetailReportPTS)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField PRICECALC;
                public TTReportField UNITPRICENOTKDV;
                public TTReportField VATRATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 8, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.Value = @"{@counter@} ";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 53, 8, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.MultiLine = EvetHayirEnum.ehEvet;
                    NATOSTOCKNO.WordBreak = EvetHayirEnum.ehEvet;
                    NATOSTOCKNO.TextFont.Size = 8;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 124, 8, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.Size = 8;
                    MATERIALDESCRIPTION.Value = @"{#MATERIALNAME#} ";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 159, 8, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 144, 8, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 0, 255, 7, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.TextFont.Size = 9;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, -4, 233, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.Visible = EvetHayirEnum.ehHayir;
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#.####";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 9;
                    PRICE.Value = @"";

                    PRICECALC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 0, 200, 8, false);
                    PRICECALC.Name = "PRICECALC";
                    PRICECALC.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICECALC.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICECALC.TextFormat = @"#,##0.00";
                    PRICECALC.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICECALC.TextFont.Size = 8;
                    PRICECALC.Value = @"";

                    UNITPRICENOTKDV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 0, 178, 8, false);
                    UNITPRICENOTKDV.Name = "UNITPRICENOTKDV";
                    UNITPRICENOTKDV.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICENOTKDV.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICENOTKDV.TextFormat = @"#,###.######";
                    UNITPRICENOTKDV.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICENOTKDV.TextFont.Size = 8;
                    UNITPRICENOTKDV.Value = @"";

                    VATRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 2, 282, 7, false);
                    VATRATE.Name = "VATRATE";
                    VATRATE.Visible = EvetHayirEnum.ehHayir;
                    VATRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VATRATE.VertAlign = VerticalAlignmentEnum.vaTop;
                    VATRATE.TextFont.Size = 10;
                    VATRATE.Value = @"{#VATRATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.PTSStockTrxRQ_Class dataset_PTSStockTrxRQ = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.PTSStockTrxRQ_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    NATOSTOCKNO.CalcValue = (dataset_PTSStockTrxRQ != null ? Globals.ToStringCore(dataset_PTSStockTrxRQ.NATOStockNO) : "");
                    MATERIALDESCRIPTION.CalcValue = (dataset_PTSStockTrxRQ != null ? Globals.ToStringCore(dataset_PTSStockTrxRQ.Materialname) : "") + @" ";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_PTSStockTrxRQ != null ? Globals.ToStringCore(dataset_PTSStockTrxRQ.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_PTSStockTrxRQ != null ? Globals.ToStringCore(dataset_PTSStockTrxRQ.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_PTSStockTrxRQ != null ? Globals.ToStringCore(dataset_PTSStockTrxRQ.UnitPrice) : "");
                    PRICE.CalcValue = @"";
                    PRICECALC.CalcValue = @"";
                    UNITPRICENOTKDV.CalcValue = @"";
                    VATRATE.CalcValue = (dataset_PTSStockTrxRQ != null ? Globals.ToStringCore(dataset_PTSStockTrxRQ.VatRate) : "");
                    return new TTReportObject[] { ORDERNO,NATOSTOCKNO,MATERIALDESCRIPTION,DISTRIBUTIONTYPE,AMOUNT,UNITPRICE,PRICE,PRICECALC,UNITPRICENOTKDV,VATRATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    /* DocumentRecordLog documentRecordLog = (DocumentRecordLog)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(DocumentRecordLog));
                    Guid stockActionObjectID = documentRecordLog.StockAction.ObjectID;
                    StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(stockActionObjectID, typeof(StockAction));
                    
                    BigCurrency upricex = 0;
                    BigCurrency pricexx = 0;
                     BigCurrency upricenotkdvxx = 0;

                    foreach (StockActionDetailIn item in stockAction.StockActionDetails.Select(string.Empty))
                    {
                        upricex += (BigCurrency)item.UnitPrice;
                        pricexx += (BigCurrency)item.Price;
                        upricenotkdvxx += (BigCurrency)((IChattelDocumentDetailWithPurchase)item).GetUnitPriceWithOutVat();
                    }*/
            // UNITPRICE.CalcValue = upricex.ToString();
            // 
            //
            
            Double vatRate = Convert.ToDouble(VATRATE.CalcValue) / 100;
            BigCurrency upricex;
            BigCurrency upricenotkdvxx;
            BigCurrency.TryParse(UNITPRICE.CalcValue, out upricex);
            if (vatRate > 0)
                upricenotkdvxx = upricex / (vatRate +1);
            else
                upricenotkdvxx = upricex;
            UNITPRICENOTKDV.CalcValue = upricenotkdvxx.ToString();
            BigCurrency pricexx = upricex * Convert.ToDouble(AMOUNT.CalcValue);

            this.MyParentReport.inKDVPrices += pricexx;
            double pricex = double.Parse(AMOUNT.CalcValue) * double.Parse(UNITPRICENOTKDV.CalcValue);
            PRICECALC.CalcValue = pricex.ToString();
            this.MyParentReport.prices += pricex;
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

        public ExaminationChattelDocumentInDetailReportPTS()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("BUDGETTYPE", "", "Bütçe Türü Seçiniz", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("BUDGETTYPE"))
                _runtimeParameters.BUDGETTYPE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["BUDGETTYPE"]);
            Name = "EXAMINATIONCHATTELDOCUMENTINDETAILREPORTPTS";
            Caption = "PTS Muayene ve Kabul Komisyon Tutanağı";
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
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
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
            fd.TextFont.Size = 11;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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