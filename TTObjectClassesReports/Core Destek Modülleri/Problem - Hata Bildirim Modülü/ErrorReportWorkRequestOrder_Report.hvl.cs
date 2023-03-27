
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
    /// İş İstek Emri (Hata Bildirimi)
    /// </summary>
    public partial class ErrorReportWorkRequestOrder : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public ErrorReportWorkRequestOrder MyParentReport
            {
                get { return (ErrorReportWorkRequestOrder)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewRect3 { get {return Body().NewRect3;} }
            public TTReportShape NewRect2 { get {return Body().NewRect2;} }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField KIMDEN { get {return Body().KIMDEN;} }
            public TTReportField KIME { get {return Body().KIME;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField BSL_KIMDEN { get {return Body().BSL_KIMDEN;} }
            public TTReportField BSL_KIMDEN1 { get {return Body().BSL_KIMDEN1;} }
            public TTReportField BSL_KIMDEN2 { get {return Body().BSL_KIMDEN2;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField112211 { get {return Body().NewField112211;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField ISTENILEN_IS { get {return Body().ISTENILEN_IS;} }
            public TTReportField ISTENILEN_ISIN_GEREKCESI { get {return Body().ISTENILEN_ISIN_GEREKCESI;} }
            public TTReportField TELEFONNO { get {return Body().TELEFONNO;} }
            public TTReportField BINANO { get {return Body().BINANO;} }
            public TTReportField KAYITNO { get {return Body().KAYITNO;} }
            public TTReportField ALINDIGITARIH { get {return Body().ALINDIGITARIH;} }
            public TTReportField ONCELIK { get {return Body().ONCELIK;} }
            public TTReportField TAMAMLANANISISTEKEMRI { get {return Body().TAMAMLANANISISTEKEMRI;} }
            public TTReportField IDARIISLEM { get {return Body().IDARIISLEM;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField ISTEKYAPAN { get {return Body().ISTEKYAPAN;} }
            public TTReportField ISIYAPACAKBIRIMPERSONEL { get {return Body().ISIYAPACAKBIRIMPERSONEL;} }
            public TTReportField MALZEME_MALIYETI { get {return Body().MALZEME_MALIYETI;} }
            public TTReportField TOPLAM_IS_SAATI { get {return Body().TOPLAM_IS_SAATI;} }
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
                list[0] = new TTReportNqlData<ErrorReportAction.GetErrorReportAction_Class>("GetErrorReportAction", ErrorReportAction.GetErrorReportAction((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ErrorReportWorkRequestOrder MyParentReport
                {
                    get { return (ErrorReportWorkRequestOrder)ParentReport; }
                }
                
                public TTReportShape NewRect3;
                public TTReportShape NewRect2;
                public TTReportShape NewRect1;
                public TTReportField BASLIK;
                public TTReportField KIMDEN;
                public TTReportField KIME;
                public TTReportField TARIH;
                public TTReportField BSL_KIMDEN;
                public TTReportField BSL_KIMDEN1;
                public TTReportField BSL_KIMDEN2;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField111;
                public TTReportField NewField123;
                public TTReportField NewField1121;
                public TTReportField NewField1221;
                public TTReportField NewField112;
                public TTReportField NewField11211;
                public TTReportField NewField11221;
                public TTReportField NewField111211;
                public TTReportField NewField112211;
                public TTReportField NewField1111;
                public TTReportField ISTENILEN_IS;
                public TTReportField ISTENILEN_ISIN_GEREKCESI;
                public TTReportField TELEFONNO;
                public TTReportField BINANO;
                public TTReportField KAYITNO;
                public TTReportField ALINDIGITARIH;
                public TTReportField ONCELIK;
                public TTReportField TAMAMLANANISISTEKEMRI;
                public TTReportField IDARIISLEM;
                public TTReportField ACIKLAMA;
                public TTReportField ISTEKYAPAN;
                public TTReportField ISIYAPACAKBIRIMPERSONEL;
                public TTReportField MALZEME_MALIYETI;
                public TTReportField TOPLAM_IS_SAATI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 278;
                    RepeatCount = 0;
                    
                    NewRect3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 157, 20, 194, 38, false);
                    NewRect3.Name = "NewRect3";
                    NewRect3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 78, 20, 157, 38, false);
                    NewRect2.Name = "NewRect2";
                    NewRect2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 1, 20, 78, 38, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 4, 194, 20, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.TextFont.Name = "Arial";
                    BASLIK.TextFont.Size = 16;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"İŞ İSTEK EMRİ";

                    KIMDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 26, 77, 37, false);
                    KIMDEN.Name = "KIMDEN";
                    KIMDEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMDEN.MultiLine = EvetHayirEnum.ehEvet;
                    KIMDEN.WordBreak = EvetHayirEnum.ehEvet;
                    KIMDEN.TextFont.Size = 11;
                    KIMDEN.TextFont.CharSet = 162;
                    KIMDEN.Value = @"";

                    KIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 26, 156, 37, false);
                    KIME.Name = "KIME";
                    KIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIME.MultiLine = EvetHayirEnum.ehEvet;
                    KIME.WordBreak = EvetHayirEnum.ehEvet;
                    KIME.TextFont.Size = 11;
                    KIME.TextFont.CharSet = 162;
                    KIME.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 26, 193, 37, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Size = 11;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#ACTIONDATE#}";

                    BSL_KIMDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 21, 27, 26, false);
                    BSL_KIMDEN.Name = "BSL_KIMDEN";
                    BSL_KIMDEN.TextFont.Size = 11;
                    BSL_KIMDEN.TextFont.Bold = true;
                    BSL_KIMDEN.TextFont.Underline = true;
                    BSL_KIMDEN.TextFont.CharSet = 162;
                    BSL_KIMDEN.Value = @"Kimden:";

                    BSL_KIMDEN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 21, 104, 26, false);
                    BSL_KIMDEN1.Name = "BSL_KIMDEN1";
                    BSL_KIMDEN1.TextFont.Size = 11;
                    BSL_KIMDEN1.TextFont.Bold = true;
                    BSL_KIMDEN1.TextFont.Underline = true;
                    BSL_KIMDEN1.TextFont.CharSet = 162;
                    BSL_KIMDEN1.Value = @"Kime:";

                    BSL_KIMDEN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 21, 183, 26, false);
                    BSL_KIMDEN2.Name = "BSL_KIMDEN2";
                    BSL_KIMDEN2.TextFont.Size = 11;
                    BSL_KIMDEN2.TextFont.Bold = true;
                    BSL_KIMDEN2.TextFont.Underline = true;
                    BSL_KIMDEN2.TextFont.CharSet = 162;
                    BSL_KIMDEN2.Value = @"Tarih:";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 38, 194, 81, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"1.İstenilen iş aşağıda açıklanmıştır:";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 81, 194, 109, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"2.İstenilen işin gerekçesi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 109, 101, 129, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"3. İstek Yapanın Rütbesi, Adı ve Soyadı, İmza:";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 109, 151, 129, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"4. Telefon Numarası:";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 109, 194, 129, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"5. Bina No:";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 129, 194, 157, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"6. İstek Yapan Birlik K./Kurum A./Rütbesi, Adı ve Soyadı, İmza:";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 157, 68, 177, false);
                    NewField123.Name = "NewField123";
                    NewField123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123.TextFont.Size = 11;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"7. Kayıt No:";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 157, 134, 177, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.TextFont.Size = 11;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"8. Alındığı Tarih:";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 157, 194, 177, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.TextFont.Size = 11;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"9. Öncelik:";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 177, 194, 205, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.TextFont.Size = 11;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"10. İŞLEM:                                                                          UYGUN:                                                   UYGUN DEĞİL: (Açıklamaya Bak)";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 205, 97, 233, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.TextFont.Size = 11;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"11. Tamamlanan İş İstek Emri";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 205, 194, 233, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221.TextFont.Size = 11;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"12. İDARİ İŞLEM :";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 261, 97, 276, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.TextFont.Size = 11;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"13. Malzeme Maliyeti:";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 261, 194, 276, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112211.TextFont.Size = 11;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"14. Toplam İş Saati: ";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 233, 194, 261, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"AÇIKLAMA:";

                    ISTENILEN_IS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 44, 192, 80, false);
                    ISTENILEN_IS.Name = "ISTENILEN_IS";
                    ISTENILEN_IS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTENILEN_IS.MultiLine = EvetHayirEnum.ehEvet;
                    ISTENILEN_IS.WordBreak = EvetHayirEnum.ehEvet;
                    ISTENILEN_IS.TextFont.Size = 11;
                    ISTENILEN_IS.TextFont.CharSet = 162;
                    ISTENILEN_IS.Value = @"{#DESCRIPTION#}";

                    ISTENILEN_ISIN_GEREKCESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 87, 193, 108, false);
                    ISTENILEN_ISIN_GEREKCESI.Name = "ISTENILEN_ISIN_GEREKCESI";
                    ISTENILEN_ISIN_GEREKCESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTENILEN_ISIN_GEREKCESI.MultiLine = EvetHayirEnum.ehEvet;
                    ISTENILEN_ISIN_GEREKCESI.WordBreak = EvetHayirEnum.ehEvet;
                    ISTENILEN_ISIN_GEREKCESI.TextFont.Size = 11;
                    ISTENILEN_ISIN_GEREKCESI.TextFont.CharSet = 162;
                    ISTENILEN_ISIN_GEREKCESI.Value = @"{#NAME#}";

                    TELEFONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 116, 150, 127, false);
                    TELEFONNO.Name = "TELEFONNO";
                    TELEFONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEFONNO.MultiLine = EvetHayirEnum.ehEvet;
                    TELEFONNO.WordBreak = EvetHayirEnum.ehEvet;
                    TELEFONNO.TextFont.Size = 11;
                    TELEFONNO.TextFont.CharSet = 162;
                    TELEFONNO.Value = @"{#FROMTELEPHONE#}";

                    BINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 116, 193, 127, false);
                    BINANO.Name = "BINANO";
                    BINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BINANO.MultiLine = EvetHayirEnum.ehEvet;
                    BINANO.WordBreak = EvetHayirEnum.ehEvet;
                    BINANO.TextFont.Size = 11;
                    BINANO.TextFont.CharSet = 162;
                    BINANO.Value = @"{#SOLUTIONBUILDING#}";

                    KAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 164, 67, 175, false);
                    KAYITNO.Name = "KAYITNO";
                    KAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAYITNO.MultiLine = EvetHayirEnum.ehEvet;
                    KAYITNO.WordBreak = EvetHayirEnum.ehEvet;
                    KAYITNO.TextFont.Size = 11;
                    KAYITNO.TextFont.CharSet = 162;
                    KAYITNO.Value = @"{#ERRORREPORTNO#}";

                    ALINDIGITARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 164, 132, 175, false);
                    ALINDIGITARIH.Name = "ALINDIGITARIH";
                    ALINDIGITARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALINDIGITARIH.MultiLine = EvetHayirEnum.ehEvet;
                    ALINDIGITARIH.WordBreak = EvetHayirEnum.ehEvet;
                    ALINDIGITARIH.TextFont.Size = 11;
                    ALINDIGITARIH.TextFont.CharSet = 162;
                    ALINDIGITARIH.Value = @"{#ACTIONDATE#}";

                    ONCELIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 164, 193, 175, false);
                    ONCELIK.Name = "ONCELIK";
                    ONCELIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONCELIK.MultiLine = EvetHayirEnum.ehEvet;
                    ONCELIK.WordBreak = EvetHayirEnum.ehEvet;
                    ONCELIK.TextFont.Size = 11;
                    ONCELIK.TextFont.CharSet = 162;
                    ONCELIK.Value = @"{#ERRORPRIORITY#}";

                    TAMAMLANANISISTEKEMRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 211, 96, 232, false);
                    TAMAMLANANISISTEKEMRI.Name = "TAMAMLANANISISTEKEMRI";
                    TAMAMLANANISISTEKEMRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAMAMLANANISISTEKEMRI.MultiLine = EvetHayirEnum.ehEvet;
                    TAMAMLANANISISTEKEMRI.WordBreak = EvetHayirEnum.ehEvet;
                    TAMAMLANANISISTEKEMRI.TextFont.Size = 11;
                    TAMAMLANANISISTEKEMRI.TextFont.CharSet = 162;
                    TAMAMLANANISISTEKEMRI.Value = @"{#SOLUTIONENDDATETIME#}";

                    IDARIISLEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 211, 193, 232, false);
                    IDARIISLEM.Name = "IDARIISLEM";
                    IDARIISLEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDARIISLEM.MultiLine = EvetHayirEnum.ehEvet;
                    IDARIISLEM.WordBreak = EvetHayirEnum.ehEvet;
                    IDARIISLEM.TextFont.Size = 11;
                    IDARIISLEM.TextFont.CharSet = 162;
                    IDARIISLEM.Value = @"";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 239, 192, 259, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Size = 11;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#SOLUTIONDESCRIPTION#}";

                    ISTEKYAPAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 116, 99, 127, false);
                    ISTEKYAPAN.Name = "ISTEKYAPAN";
                    ISTEKYAPAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPAN.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKYAPAN.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKYAPAN.TextFont.Size = 11;
                    ISTEKYAPAN.TextFont.CharSet = 162;
                    ISTEKYAPAN.Value = @"";

                    ISIYAPACAKBIRIMPERSONEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 183, 193, 203, false);
                    ISIYAPACAKBIRIMPERSONEL.Name = "ISIYAPACAKBIRIMPERSONEL";
                    ISIYAPACAKBIRIMPERSONEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISIYAPACAKBIRIMPERSONEL.MultiLine = EvetHayirEnum.ehEvet;
                    ISIYAPACAKBIRIMPERSONEL.WordBreak = EvetHayirEnum.ehEvet;
                    ISIYAPACAKBIRIMPERSONEL.TextFont.Size = 11;
                    ISIYAPACAKBIRIMPERSONEL.TextFont.CharSet = 162;
                    ISIYAPACAKBIRIMPERSONEL.Value = @"";

                    MALZEME_MALIYETI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 267, 96, 275, false);
                    MALZEME_MALIYETI.Name = "MALZEME_MALIYETI";
                    MALZEME_MALIYETI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEME_MALIYETI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEME_MALIYETI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEME_MALIYETI.TextFont.Size = 11;
                    MALZEME_MALIYETI.TextFont.CharSet = 162;
                    MALZEME_MALIYETI.Value = @"{#SOLUTIONMATERIALCOST#}";

                    TOPLAM_IS_SAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 267, 193, 275, false);
                    TOPLAM_IS_SAATI.Name = "TOPLAM_IS_SAATI";
                    TOPLAM_IS_SAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM_IS_SAATI.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAM_IS_SAATI.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAM_IS_SAATI.TextFont.Size = 11;
                    TOPLAM_IS_SAATI.TextFont.CharSet = 162;
                    TOPLAM_IS_SAATI.Value = @"{#SOLUTIONWORKHOURS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ErrorReportAction.GetErrorReportAction_Class dataset_GetErrorReportAction = ParentGroup.rsGroup.GetCurrentRecord<ErrorReportAction.GetErrorReportAction_Class>(0);
                    BASLIK.CalcValue = BASLIK.Value;
                    KIMDEN.CalcValue = @"";
                    KIME.CalcValue = @"";
                    TARIH.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.ActionDate) : "");
                    BSL_KIMDEN.CalcValue = BSL_KIMDEN.Value;
                    BSL_KIMDEN1.CalcValue = BSL_KIMDEN1.Value;
                    BSL_KIMDEN2.CalcValue = BSL_KIMDEN2.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    ISTENILEN_IS.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.Description) : "");
                    ISTENILEN_ISIN_GEREKCESI.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.Name) : "");
                    TELEFONNO.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.FromTelephone) : "");
                    BINANO.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.SolutionBuilding) : "");
                    KAYITNO.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.ErrorReportNO) : "");
                    ALINDIGITARIH.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.ActionDate) : "");
                    ONCELIK.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.ErrorPriority) : "");
                    TAMAMLANANISISTEKEMRI.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.SolutionEndDateTime) : "");
                    IDARIISLEM.CalcValue = @"";
                    ACIKLAMA.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.SolutionDescription) : "");
                    ISTEKYAPAN.CalcValue = @"";
                    ISIYAPACAKBIRIMPERSONEL.CalcValue = @"";
                    MALZEME_MALIYETI.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.SolutionMaterialCost) : "");
                    TOPLAM_IS_SAATI.CalcValue = (dataset_GetErrorReportAction != null ? Globals.ToStringCore(dataset_GetErrorReportAction.SolutionWorkHours) : "");
                    return new TTReportObject[] { BASLIK,KIMDEN,KIME,TARIH,BSL_KIMDEN,BSL_KIMDEN1,BSL_KIMDEN2,NewField1,NewField11,NewField12,NewField121,NewField122,NewField111,NewField123,NewField1121,NewField1221,NewField112,NewField11211,NewField11221,NewField111211,NewField112211,NewField1111,ISTENILEN_IS,ISTENILEN_ISIN_GEREKCESI,TELEFONNO,BINANO,KAYITNO,ALINDIGITARIH,ONCELIK,TAMAMLANANISISTEKEMRI,IDARIISLEM,ACIKLAMA,ISTEKYAPAN,ISIYAPACAKBIRIMPERSONEL,MALZEME_MALIYETI,TOPLAM_IS_SAATI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //Get object ErrorReportAction
                    TTObjectContext tto = new TTObjectContext(true);
                    ErrorReportAction errrep = (ErrorReportAction)tto.GetObject(this.MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ErrorReportAction));
                    //set report fields
                    this.KIMDEN.CalcValue = errrep.FromResource.Name.ToString();
                    this.KIME.CalcValue = errrep.ToResource.Name.ToString();
                    
                    this.ISTEKYAPAN.CalcValue = "";
                    this.ISTEKYAPAN.CalcValue += (errrep.FromResource.Name != null ? errrep.FromResource.Name.ToString() + "\r\n" : "");
                    this.ISTEKYAPAN.CalcValue += (errrep.FromUser.Rank != null ? errrep.FromUser.Rank.ToString() + " " : "");
                    this.ISTEKYAPAN.CalcValue += (errrep.FromUser.Title != null ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(errrep.FromUser.Title.Value).ToString() + " " : "");
                    this.ISTEKYAPAN.CalcValue += (errrep.FromUser.Name != null ? errrep.FromUser.Name.ToString() : "");                 

                    this.ISTENILEN_IS.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(errrep.Description.ToString());

                    this.ONCELIK.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(errrep.ErrorPriority.Value).ToString();

                    this.ISIYAPACAKBIRIMPERSONEL.CalcValue = "";
                    this.ISIYAPACAKBIRIMPERSONEL.CalcValue += (errrep.OwnerResource.Name != null ? errrep.OwnerResource.Name.ToString() + "\r\n" : "");
                    this.ISIYAPACAKBIRIMPERSONEL.CalcValue += (errrep.OwnerUser.Rank != null ? errrep.OwnerUser.Rank.ToString() + " " : "");
                    this.ISIYAPACAKBIRIMPERSONEL.CalcValue += (errrep.OwnerUser.Title != null ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(errrep.OwnerUser.Title.Value).ToString() + " " : "");
                    this.ISIYAPACAKBIRIMPERSONEL.CalcValue += (errrep.OwnerUser.Name != null ? errrep.OwnerUser.Name.ToString() : "");
                    
                    this.TAMAMLANANISISTEKEMRI.CalcValue = errrep.SolutionEndDateTime.HasValue ? errrep.SolutionEndDateTime.Value.ToString() : "";

                    this.ACIKLAMA.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(errrep.SolutionDescription.ToString());

                    //onay kısmı için görevlendirme state ine geçişi yapan userın seçilmesi
                    ResUser onaylayan=new ResUser(); 
                    this.IDARIISLEM.CalcValue = "";
                    foreach (TTObjectState st in errrep.GetStateHistory())
                    {
                        if (st.StateDefID == ErrorReportAction.States.Approved)
                        {
                            if (st.User != null)
                            {
                                onaylayan = (ResUser)tto.GetObject(st.User.TTObjectID.Value, typeof(ResUser));
                                this.IDARIISLEM.CalcValue += (errrep.ToResource.Name != null ? errrep.ToResource.Name.ToString() + "\r\n" : "");
                                this.IDARIISLEM.CalcValue += (onaylayan.Rank != null ? onaylayan.Rank.ToString() + " " : "");
                                this.IDARIISLEM.CalcValue += (onaylayan.Title != null ? TTObjectClasses.Common.GetEnumValueDefOfEnumValue(onaylayan.Title.Value).ToString() + " " : "");
                                this.IDARIISLEM.CalcValue += (onaylayan.Name != null ? onaylayan.Name.ToString() : "");
                            }
                        }
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

        public ErrorReportWorkRequestOrder()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ERRORREPORTWORKREQUESTORDER";
            Caption = "İş İstek Emri (Hata Bildirimi)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 10;
            UserMarginTop = 5;
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