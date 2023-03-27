
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
    /// Hasar ve Durum Tespit Raporu
    /// </summary>
    public partial class HasarveDurumTespitRaporu1 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? KISIM_AMIRI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? BKMM_BASKANI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HasarveDurumTespitRaporu1 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu1)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField Klinik { get {return Body().Klinik;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField115 { get {return Body().NewField115;} }
            public TTReportField MISSEDMATERIALS { get {return Body().MISSEDMATERIALS;} }
            public TTReportField CHANGEDMATERIALS { get {return Body().CHANGEDMATERIALS;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField DAMAGEDMATERIALS { get {return Body().DAMAGEDMATERIALS;} }
            public TTReportField NewField156 { get {return Body().NewField156;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField MARKAMODEL { get {return Body().MARKAMODEL;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportField TEKNISYEN { get {return Body().TEKNISYEN;} }
            public TTReportField KISIMAMIRI { get {return Body().KISIMAMIRI;} }
            public TTReportField BKMMBASKANI { get {return Body().BKMMBASKANI;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField SERINU { get {return Body().SERINU;} }
            public TTReportField REQUESTDATE1 { get {return Body().REQUESTDATE1;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportField TEKNISYENSEC { get {return Body().TEKNISYENSEC;} }
            public TTReportField KISIMAMIRISEC { get {return Body().KISIMAMIRISEC;} }
            public TTReportField BASKANSEC { get {return Body().BASKANSEC;} }
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
                public HasarveDurumTespitRaporu1 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu1)ParentReport; }
                }
                
                public TTReportField NewField9;
                public TTReportField NewField4;
                public TTReportField REQUESTDATE;
                public TTReportField Klinik;
                public TTReportField NewField2;
                public TTReportField NewField111;
                public TTReportField NewField101;
                public TTReportField NewField19;
                public TTReportField NewField18;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField151;
                public TTReportField NewField115;
                public TTReportField MISSEDMATERIALS;
                public TTReportField CHANGEDMATERIALS;
                public TTReportField NewField125;
                public TTReportField DAMAGEDMATERIALS;
                public TTReportField NewField156;
                public TTReportField NewField112;
                public TTReportField MATERIALNAME;
                public TTReportField MILITARYUNIT;
                public TTReportField MARKAMODEL;
                public TTReportField NATOSTOCKNO;
                public TTReportField ORDERNO;
                public TTReportField REPORTDATE;
                public TTReportField NewField13;
                public TTReportField NewField121;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine7;
                public TTReportField KLINIK;
                public TTReportShape NewLine9;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportField TEKNISYEN;
                public TTReportField KISIMAMIRI;
                public TTReportField BKMMBASKANI;
                public TTReportField NewField6;
                public TTReportField SERINU;
                public TTReportField REQUESTDATE1;
                public TTReportField REQUESTNO;
                public TTReportField NewField3;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportField TEKNISYENSEC;
                public TTReportField KISIMAMIRISEC;
                public TTReportField BASKANSEC; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 59, 130, 69, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField9.TextFont.Size = 10;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"Seri Nu.:";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 220, 195, 271, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 10;
                    NewField4.TextFont.CharSet = 1;
                    NewField4.Value = @"";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 92, 93, 102, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE.TextFont.Size = 10;
                    REQUESTDATE.TextFont.Bold = true;
                    REQUESTDATE.Value = @"Bakım, Onarım ve Kalib. İstek Formu Tarihi:";

                    Klinik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 69, 92, 80, false);
                    Klinik.Name = "Klinik";
                    Klinik.DrawStyle = DrawStyleConstants.vbInvisible;
                    Klinik.TextFont.Size = 10;
                    Klinik.TextFont.Bold = true;
                    Klinik.Value = @"Kliniği:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 37, 195, 49, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 12;
                    NewField2.Value = @" CİHAZ / MALZEMENİN";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 91, 305, 102, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @" Gönderen Birlik :";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 49, 155, 59, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Size = 10;
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @"Stok Nu. :";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 59, 92, 69, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Size = 10;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Marka ve Modeli : ";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 49, 92, 59, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 10;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Adı :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 10, 120, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"HİZMETE ÖZEL";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 27, 195, 37, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @" HASAR VE DURUM TESPİT RAPORU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 65, 271, 75, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @" Sipariş Nu. :";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 102, 105, 108, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.TextFont.Size = 10;
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @"Eksik Malzemeler";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 102, 195, 108, false);
                    NewField115.Name = "NewField115";
                    NewField115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115.TextFont.Size = 10;
                    NewField115.TextFont.Bold = true;
                    NewField115.Value = @"Değişik Malzemeler";

                    MISSEDMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 108, 105, 154, false);
                    MISSEDMATERIALS.Name = "MISSEDMATERIALS";
                    MISSEDMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MISSEDMATERIALS.MultiLine = EvetHayirEnum.ehEvet;
                    MISSEDMATERIALS.WordBreak = EvetHayirEnum.ehEvet;
                    MISSEDMATERIALS.TextFont.Size = 10;
                    MISSEDMATERIALS.Value = @"";

                    CHANGEDMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 108, 195, 154, false);
                    CHANGEDMATERIALS.Name = "CHANGEDMATERIALS";
                    CHANGEDMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHANGEDMATERIALS.MultiLine = EvetHayirEnum.ehEvet;
                    CHANGEDMATERIALS.WordBreak = EvetHayirEnum.ehEvet;
                    CHANGEDMATERIALS.TextFont.Size = 10;
                    CHANGEDMATERIALS.Value = @"";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 154, 195, 160, false);
                    NewField125.Name = "NewField125";
                    NewField125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125.TextFont.Size = 10;
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @"Hasarlı Malzemeler ve Görülen Aksaklıklar";

                    DAMAGEDMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 160, 195, 220, false);
                    DAMAGEDMATERIALS.Name = "DAMAGEDMATERIALS";
                    DAMAGEDMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAMAGEDMATERIALS.MultiLine = EvetHayirEnum.ehEvet;
                    DAMAGEDMATERIALS.WordBreak = EvetHayirEnum.ehEvet;
                    DAMAGEDMATERIALS.TextFont.Size = 10;
                    DAMAGEDMATERIALS.Value = @"";

                    NewField156 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 180, 305, 190, false);
                    NewField156.Name = "NewField156";
                    NewField156.Visible = EvetHayirEnum.ehHayir;
                    NewField156.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField156.TextFont.Size = 10;
                    NewField156.TextFont.Bold = true;
                    NewField156.Value = @"Kalite Güvence Müdürlüğü İlgili Personeli";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 92, 155, 102, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Size = 10;
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"Rapor Tarihi :";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 49, 130, 59, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.Value = @"{%MATERIALNAME%}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 92, 304, 101, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.Visible = EvetHayirEnum.ehHayir;
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbInvisible;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Size = 10;
                    MILITARYUNIT.Value = @"";

                    MARKAMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 59, 130, 69, false);
                    MARKAMODEL.Name = "MARKAMODEL";
                    MARKAMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODEL.TextFont.Size = 10;
                    MARKAMODEL.Value = @"{%MARKAMODEL%}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 49, 195, 59, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"{%NATOSTOCKNO%}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 67, 271, 73, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.Visible = EvetHayirEnum.ehHayir;
                    ORDERNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Size = 10;
                    ORDERNO.Value = @"";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 92, 195, 102, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.TextFont.Size = 10;
                    REPORTDATE.Value = @"{@printdate@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 279, 120, 284, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"HİZMETE ÖZEL";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 80, 92, 92, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 10;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Bakım, Onarım ve Kalib. İstek Formu Nu.: ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 27, 195, 27, false);
                    NewLine1.Name = "NewLine1";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 27, 195, 110, false);
                    NewLine2.Name = "NewLine2";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 27, 15, 110, false);
                    NewLine3.Name = "NewLine3";

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 37, 195, 37, false);
                    NewLine4.Name = "NewLine4";

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 130, 69, 195, 69, false);
                    NewLine7.Name = "NewLine7";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 69, 195, 80, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.TextFont.Size = 10;
                    KLINIK.Value = @"{%KLINIK%}";

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 180, 15, 180, false);
                    NewLine9.Name = "NewLine9";

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 179, 15, 271, false);
                    NewLine10.Name = "NewLine10";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 271, 195, 271, false);
                    NewLine11.Name = "NewLine11";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 180, 195, 271, false);
                    NewLine12.Name = "NewLine12";

                    TEKNISYEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 222, 47, 227, false);
                    TEKNISYEN.Name = "TEKNISYEN";
                    TEKNISYEN.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNISYEN.VertAlign = VerticalAlignmentEnum.vaTop;
                    TEKNISYEN.TextFont.Size = 10;
                    TEKNISYEN.TextFont.Bold = true;
                    TEKNISYEN.Value = @"TEKNİSYEN";

                    KISIMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 222, 121, 227, false);
                    KISIMAMIRI.Name = "KISIMAMIRI";
                    KISIMAMIRI.DrawStyle = DrawStyleConstants.vbInvisible;
                    KISIMAMIRI.VertAlign = VerticalAlignmentEnum.vaTop;
                    KISIMAMIRI.TextFont.Size = 10;
                    KISIMAMIRI.TextFont.Bold = true;
                    KISIMAMIRI.Value = @"KISIM AMİRİ";

                    BKMMBASKANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 222, 185, 227, false);
                    BKMMBASKANI.Name = "BKMMBASKANI";
                    BKMMBASKANI.DrawStyle = DrawStyleConstants.vbInvisible;
                    BKMMBASKANI.VertAlign = VerticalAlignmentEnum.vaTop;
                    BKMMBASKANI.TextFont.Size = 10;
                    BKMMBASKANI.TextFont.Bold = true;
                    BKMMBASKANI.Value = @"BKMM BAŞKANI";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 264, 119, 269, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.TextFont.Size = 10;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"(l)";

                    SERINU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 59, 195, 69, false);
                    SERINU.Name = "SERINU";
                    SERINU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERINU.TextFont.Size = 10;
                    SERINU.Value = @"{%SERINU%}";

                    REQUESTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 92, 130, 102, false);
                    REQUESTDATE1.Name = "REQUESTDATE1";
                    REQUESTDATE1.ForeColor = System.Drawing.Color.White;
                    REQUESTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE1.TextFont.Size = 10;
                    REQUESTDATE1.Value = @"{%REQUESTDATE%}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 80, 195, 92, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.Value = @"{%REQUESTNO%}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 59, 155, 69, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 10;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Seri Nu. :";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 92, 92, 102, false);
                    NewLine5.Name = "NewLine5";

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 92, 102, 131, 102, false);
                    NewLine6.Name = "NewLine6";

                    TEKNISYENSEC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 231, 46, 236, false);
                    TEKNISYENSEC.Name = "TEKNISYENSEC";
                    TEKNISYENSEC.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNISYENSEC.VertAlign = VerticalAlignmentEnum.vaTop;
                    TEKNISYENSEC.TextFont.Name = "Arial Narrow";
                    TEKNISYENSEC.TextFont.Size = 10;
                    TEKNISYENSEC.TextFont.CharSet = 1;
                    TEKNISYENSEC.Value = @"";

                    KISIMAMIRISEC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 232, 119, 237, false);
                    KISIMAMIRISEC.Name = "KISIMAMIRISEC";
                    KISIMAMIRISEC.DrawStyle = DrawStyleConstants.vbInvisible;
                    KISIMAMIRISEC.VertAlign = VerticalAlignmentEnum.vaTop;
                    KISIMAMIRISEC.TextFont.Name = "Arial Narrow";
                    KISIMAMIRISEC.TextFont.Size = 10;
                    KISIMAMIRISEC.TextFont.CharSet = 1;
                    KISIMAMIRISEC.Value = @"";

                    BASKANSEC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 232, 180, 237, false);
                    BASKANSEC.Name = "BASKANSEC";
                    BASKANSEC.DrawStyle = DrawStyleConstants.vbInvisible;
                    BASKANSEC.VertAlign = VerticalAlignmentEnum.vaTop;
                    BASKANSEC.TextFont.Name = "Arial Narrow";
                    BASKANSEC.TextFont.Size = 10;
                    BASKANSEC.TextFont.CharSet = 1;
                    BASKANSEC.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField9.CalcValue = NewField9.Value;
                    NewField4.CalcValue = NewField4.Value;
                    REQUESTDATE.CalcValue = REQUESTDATE.Value;
                    Klinik.CalcValue = Klinik.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField115.CalcValue = NewField115.Value;
                    MISSEDMATERIALS.CalcValue = @"";
                    CHANGEDMATERIALS.CalcValue = @"";
                    NewField125.CalcValue = NewField125.Value;
                    DAMAGEDMATERIALS.CalcValue = @"";
                    NewField156.CalcValue = NewField156.Value;
                    NewField112.CalcValue = NewField112.Value;
                    MATERIALNAME.CalcValue = MyParentReport.MAIN.MATERIALNAME.CalcValue;
                    MILITARYUNIT.CalcValue = @"";
                    MARKAMODEL.CalcValue = MyParentReport.MAIN.MARKAMODEL.CalcValue;
                    NATOSTOCKNO.CalcValue = MyParentReport.MAIN.NATOSTOCKNO.CalcValue;
                    ORDERNO.CalcValue = @"";
                    REPORTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField13.CalcValue = NewField13.Value;
                    NewField121.CalcValue = NewField121.Value;
                    KLINIK.CalcValue = MyParentReport.MAIN.KLINIK.CalcValue;
                    TEKNISYEN.CalcValue = TEKNISYEN.Value;
                    KISIMAMIRI.CalcValue = KISIMAMIRI.Value;
                    BKMMBASKANI.CalcValue = BKMMBASKANI.Value;
                    NewField6.CalcValue = NewField6.Value;
                    SERINU.CalcValue = MyParentReport.MAIN.SERINU.CalcValue;
                    REQUESTDATE1.CalcValue = MyParentReport.MAIN.REQUESTDATE.CalcValue;
                    REQUESTNO.CalcValue = MyParentReport.MAIN.REQUESTNO.CalcValue;
                    NewField3.CalcValue = NewField3.Value;
                    TEKNISYENSEC.CalcValue = TEKNISYENSEC.Value;
                    KISIMAMIRISEC.CalcValue = KISIMAMIRISEC.Value;
                    BASKANSEC.CalcValue = BASKANSEC.Value;
                    return new TTReportObject[] { NewField9,NewField4,REQUESTDATE,Klinik,NewField2,NewField111,NewField101,NewField19,NewField18,NewField1,NewField12,NewField11,NewField151,NewField115,MISSEDMATERIALS,CHANGEDMATERIALS,NewField125,DAMAGEDMATERIALS,NewField156,NewField112,MATERIALNAME,MILITARYUNIT,MARKAMODEL,NATOSTOCKNO,ORDERNO,REPORTDATE,NewField13,NewField121,KLINIK,TEKNISYEN,KISIMAMIRI,BKMMBASKANI,NewField6,SERINU,REQUESTDATE1,REQUESTNO,NewField3,TEKNISYENSEC,KISIMAMIRISEC,BASKANSEC};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataSet_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    if (dataSet_GetMaintenanceOrderByObjectIDQuery != null && dataSet_GetMaintenanceOrderByObjectIDQuery.Responsibleworkshopuser != null)
                        {
                            Guid teknisyenId = new Guid(Globals.ToStringCore(dataSet_GetMaintenanceOrderByObjectIDQuery.Responsibleworkshopuser));

                            ResUser wsResUser = (ResUser)this.ParentReport.ReportObjectContext.GetObject(teknisyenId, typeof(ResUser));
                            this.TEKNISYENSEC.CalcValue = wsResUser.Name;
                            this.TEKNISYENSEC.CalcValue += "\r\n" + wsResUser.Title.Value.ToString();
                        }                    
                        else
                        {
                            this.TEKNISYENSEC.CalcValue = "";
                        }
            
                    
            
                        
                        
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
                   
                    if (cmrAction is Repair)
                    {
                        Repair repair = (Repair)cmrAction;
                        MATERIALNAME.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                        NATOSTOCKNO.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO;
                        MILITARYUNIT.CalcValue = repair.OwnerMilitaryUnit.Name;
                        REQUESTNO.CalcValue = repair.RequestNo.ToString();
                        REQUESTDATE.CalcValue = repair.RequestDate.ToString();
                        KLINIK.CalcValue = repair.SenderSection.Name;
                        SERINU.CalcValue = repair.FixedAssetMaterialDefinition.SerialNumber;

                        if (repair.FixedAssetMaterialDefinition.Mark != "")
                            MARKAMODEL.CalcValue = repair.FixedAssetMaterialDefinition.Mark;
                        else
                            MARKAMODEL.CalcValue = "---";

                        if (repair.FixedAssetMaterialDefinition.Model != "")
                            MARKAMODEL.CalcValue = MARKAMODEL.CalcValue + "/" + repair.FixedAssetMaterialDefinition.Model;
                        else
                            MARKAMODEL.CalcValue = MARKAMODEL.CalcValue + "/" + "---";

                      
                        
                        if(repair.Repair_ItemEquipments.Count > 0)
                        {
                            foreach(Repair_ItemEquipment repairItem in repair.Repair_ItemEquipments)
                            {
                                if(repairItem.IsChanged.Value)
                                    CHANGEDMATERIALS.CalcValue += " _ " + repairItem.Amount.ToString() + " " + repairItem.DistributionType.DistributionType + " " + repairItem.ItemName + "\n";
                                else if(repairItem.IsDamaged.Value)
                                    DAMAGEDMATERIALS.CalcValue += " _ " + repairItem.Amount.ToString() + " " + repairItem.DistributionType.DistributionType + " " + repairItem.ItemName + "\n";
                                else if(repairItem.IsMissing.Value)
                                    MISSEDMATERIALS.CalcValue += " _ " + repairItem.Amount.ToString() + " " + repairItem.DistributionType.DistributionType + " " + repairItem.ItemName + "\n";
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

        public HasarveDurumTespitRaporu1()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("KISIM_AMIRI", "00000000-0000-0000-0000-000000000000", "Kısım Amiri", @"", true, false, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("BKMM_BASKANI", "00000000-0000-0000-0000-000000000000", "BKMM Başkanı", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("KISIM_AMIRI"))
                _runtimeParameters.KISIM_AMIRI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["KISIM_AMIRI"]);
            if (parameters.ContainsKey("BKMM_BASKANI"))
                _runtimeParameters.BKMM_BASKANI = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["BKMM_BASKANI"]);
            Name = "HASARVEDURUMTESPITRAPORU1";
            Caption = "Hasar ve Durum Tespit Raporu";
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
            fd.DrawStyle = DrawStyleConstants.vbSolid;
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
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