
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
    /// Eczane Faturası
    /// </summary>
    public partial class PharmacyInvoiceReport : TTReport
    {
#region Methods
   public double totalPrices = 0.0;
      
     
      public string InvoiceNumberString ="";
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public bool? IsContributionMargin = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public PharmacyInvoiceReport MyParentReport
            {
                get { return (PharmacyInvoiceReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField IBANNo { get {return Header().IBANNo;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField121112 { get {return Header().NewField121112;} }
            public TTReportField NewField1211121 { get {return Header().NewField1211121;} }
            public TTReportField NewField11211121 { get {return Header().NewField11211121;} }
            public TTReportField NewField1211122 { get {return Header().NewField1211122;} }
            public TTReportField NewField1211123 { get {return Header().NewField1211123;} }
            public TTReportField NewField13211121 { get {return Header().NewField13211121;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField BANKACCOUNT1 { get {return Header().BANKACCOUNT1;} }
            public TTReportField HOSPITALIBANNO1 { get {return Header().HOSPITALIBANNO1;} }
            public TTReportField TAXOFFICEINFO1 { get {return Header().TAXOFFICEINFO1;} }
            public TTReportField PAGENOFOOTER1 { get {return Header().PAGENOFOOTER1;} }
            public TTReportField FATURATARIHI1 { get {return Header().FATURATARIHI1;} }
            public TTReportField FATURATARIHI { get {return Header().FATURATARIHI;} }
            public TTReportField InvoiceNumberField { get {return Header().InvoiceNumberField;} }
            public TTReportField ReviewNumberField { get {return Header().ReviewNumberField;} }
            public TTReportField AccountancyHeader { get {return Header().AccountancyHeader;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportShape NewLine19 { get {return Header().NewLine19;} }
            public TTReportShape NewLine171 { get {return Header().NewLine171;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportShape NewLine132 { get {return Header().NewLine132;} }
            public TTReportShape NewLine181 { get {return Header().NewLine181;} }
            public TTReportShape NewLine191 { get {return Header().NewLine191;} }
            public TTReportShape NewLine1171 { get {return Header().NewLine1171;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField InvoiceNumberField2 { get {return Header().InvoiceNumberField2;} }
            public TTReportShape NewLine1231 { get {return Header().NewLine1231;} }
            public TTReportShape NewLine1181 { get {return Header().NewLine1181;} }
            public TTReportShape NewLine1191 { get {return Header().NewLine1191;} }
            public TTReportShape NewLine11811 { get {return Header().NewLine11811;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine9 { get {return Header().NewLine9;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine20 { get {return Header().NewLine20;} }
            public TTReportField IdariMudur { get {return Header().IdariMudur;} }
            public TTReportField NewField1123 { get {return Header().NewField1123;} }
            public TTReportField BANKACCOUNT11 { get {return Header().BANKACCOUNT11;} }
            public TTReportField TifNo { get {return Header().TifNo;} }
            public TTReportField NewField1213 { get {return Footer().NewField1213;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField NewField13231 { get {return Footer().NewField13231;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField NewField11224 { get {return Footer().NewField11224;} }
            public TTReportField NewField1113 { get {return Footer().NewField1113;} }
            public TTReportField NewField1112212 { get {return Footer().NewField1112212;} }
            public TTReportField NewField111112 { get {return Footer().NewField111112;} }
            public TTReportField NewField111122111 { get {return Footer().NewField111122111;} }
            public TTReportField NewField11111111 { get {return Footer().NewField11111111;} }
            public TTReportField NewField1111221111 { get {return Footer().NewField1111221111;} }
            public TTReportField NewField111111111 { get {return Footer().NewField111111111;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public TTReportField NewField13121 { get {return Footer().NewField13121;} }
            public TTReportField PAGENOFOOTER2 { get {return Footer().PAGENOFOOTER2;} }
            public TTReportField TOTALPRICES { get {return Footer().TOTALPRICES;} }
            public TTReportField SHCEKFIELD { get {return Footer().SHCEKFIELD;} }
            public TTReportField MERKEZPAYFIELD { get {return Footer().MERKEZPAYFIELD;} }
            public TTReportField HAZINEFIELD { get {return Footer().HAZINEFIELD;} }
            public TTReportField SHCEKFIELD2 { get {return Footer().SHCEKFIELD2;} }
            public TTReportField MERKEZPAYFIELD2 { get {return Footer().MERKEZPAYFIELD2;} }
            public TTReportField HAZINEFIELD2 { get {return Footer().HAZINEFIELD2;} }
            public TTReportField SHCEK { get {return Footer().SHCEK;} }
            public TTReportField MERKEZPAYI { get {return Footer().MERKEZPAYI;} }
            public TTReportField HAZINE { get {return Footer().HAZINE;} }
            public TTReportField TOTALPRICESWTIHSMH { get {return Footer().TOTALPRICESWTIHSMH;} }
            public TTReportField Accountancy { get {return Footer().Accountancy;} }
            public TTReportField TOTALPRICESWTIHSMH1 { get {return Footer().TOTALPRICESWTIHSMH1;} }
            public TTReportField ICMALTARIHI { get {return Footer().ICMALTARIHI;} }
            public TTReportField InvoiceNumberField1 { get {return Footer().InvoiceNumberField1;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine4 { get {return Footer().NewLine4;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportShape NewLine5 { get {return Footer().NewLine5;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField111121 { get {return Footer().NewField111121;} }
            public TTReportField InvoiceNumberField12 { get {return Footer().InvoiceNumberField12;} }
            public TTReportShape NewLine11812 { get {return Footer().NewLine11812;} }
            public TTReportShape NewLine11911 { get {return Footer().NewLine11911;} }
            public TTReportShape NewLine111811 { get {return Footer().NewLine111811;} }
            public TTReportShape NewLine111911 { get {return Footer().NewLine111911;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportShape NewLine6 { get {return Footer().NewLine6;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public TTReportShape NewLine10 { get {return Footer().NewLine10;} }
            public TTReportShape NewLine101 { get {return Footer().NewLine101;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public PharmacyInvoiceReport MyParentReport
                {
                    get { return (PharmacyInvoiceReport)ParentReport; }
                }
                
                public TTReportField HOSPITALNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField121;
                public TTReportField IBANNo;
                public TTReportField NewField1121;
                public TTReportField NewField16;
                public TTReportField NewField1122;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField7;
                public TTReportField NewField121112;
                public TTReportField NewField1211121;
                public TTReportField NewField11211121;
                public TTReportField NewField1211122;
                public TTReportField NewField1211123;
                public TTReportField NewField13211121;
                public TTReportField NewField161;
                public TTReportField NewField15;
                public TTReportField BANKACCOUNT1;
                public TTReportField HOSPITALIBANNO1;
                public TTReportField TAXOFFICEINFO1;
                public TTReportField PAGENOFOOTER1;
                public TTReportField FATURATARIHI1;
                public TTReportField FATURATARIHI;
                public TTReportField InvoiceNumberField;
                public TTReportField ReviewNumberField;
                public TTReportField AccountancyHeader;
                public TTReportShape NewLine3;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine17;
                public TTReportShape NewLine13;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine171;
                public TTReportField NewField14;
                public TTReportShape NewLine132;
                public TTReportShape NewLine181;
                public TTReportShape NewLine191;
                public TTReportShape NewLine1171;
                public TTReportField NewField12111;
                public TTReportField InvoiceNumberField2;
                public TTReportShape NewLine1231;
                public TTReportShape NewLine1181;
                public TTReportShape NewLine1191;
                public TTReportShape NewLine11811;
                public TTReportField NewField2;
                public TTReportShape NewLine1;
                public TTReportShape NewLine9;
                public TTReportShape NewLine11;
                public TTReportShape NewLine20;
                public TTReportField IdariMudur;
                public TTReportField NewField1123;
                public TTReportField BANKACCOUNT11;
                public TTReportField TifNo; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 107;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 5, 211, 23, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 9;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 11, 243, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İcmal No:";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 16, 243, 21, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İcmal Tarihi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 24, 211, 47, false);
                    NewField3.Name = "NewField3";
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.NoClip = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Merkezimizde muayene, tetkik ve tedavisi yapılmış olan mensubunuz için tahakkuk eden ücret aşağıda fatura edilmiştir.Fatura muhteviyatının tahsildarımızın müracaatında veya aşağıda yazılı olan hesabınıza faturamızın (B) kısmıyla birlikte ödenmesini saygıularımızla arz ve rica ederim.";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 74, 113, 88, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial Black";
                    NewField4.TextFont.Size = 28;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"A";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 54, 153, 59, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 8;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Hesap No";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 54, 155, 59, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    IBANNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 60, 153, 65, false);
                    IBANNo.Name = "IBANNo";
                    IBANNo.TextFont.Name = "Arial";
                    IBANNo.TextFont.Size = 8;
                    IBANNo.TextFont.Bold = true;
                    IBANNo.TextFont.CharSet = 162;
                    IBANNo.Value = @"IBAN No";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 60, 155, 65, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 66, 153, 71, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Vergi No";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 66, 155, 71, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Size = 8;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @":";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 94, 68, 99, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Fatura Tarihi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 22, 244, 27, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Kurumu";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 94, 28, 99, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 9;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"Fatura No";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 94, 121, 99, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Sayfa No";

                    NewField121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 101, 19, 107, false);
                    NewField121112.Name = "NewField121112";
                    NewField121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121112.TextFont.Name = "Arial";
                    NewField121112.TextFont.Size = 9;
                    NewField121112.TextFont.Bold = true;
                    NewField121112.TextFont.CharSet = 162;
                    NewField121112.Value = @"SIRA NO";

                    NewField1211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 101, 44, 107, false);
                    NewField1211121.Name = "NewField1211121";
                    NewField1211121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211121.TextFont.Name = "Arial";
                    NewField1211121.TextFont.Size = 9;
                    NewField1211121.TextFont.Bold = true;
                    NewField1211121.TextFont.CharSet = 162;
                    NewField1211121.Value = @"BARKOD NO";

                    NewField11211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 101, 151, 107, false);
                    NewField11211121.Name = "NewField11211121";
                    NewField11211121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211121.TextFont.Name = "Arial";
                    NewField11211121.TextFont.Size = 9;
                    NewField11211121.TextFont.Bold = true;
                    NewField11211121.TextFont.CharSet = 162;
                    NewField11211121.Value = @"VERİLAN İLAÇ / MALZEME BİLGİLERİ";

                    NewField1211122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 101, 167, 107, false);
                    NewField1211122.Name = "NewField1211122";
                    NewField1211122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211122.TextFont.Name = "Arial";
                    NewField1211122.TextFont.Size = 9;
                    NewField1211122.TextFont.Bold = true;
                    NewField1211122.TextFont.CharSet = 162;
                    NewField1211122.Value = @"ADET";

                    NewField1211123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 101, 186, 107, false);
                    NewField1211123.Name = "NewField1211123";
                    NewField1211123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211123.TextFont.Name = "Arial";
                    NewField1211123.TextFont.Size = 8;
                    NewField1211123.TextFont.Bold = true;
                    NewField1211123.TextFont.CharSet = 162;
                    NewField1211123.Value = @"BİRİM FİYAT";

                    NewField13211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 101, 211, 107, false);
                    NewField13211121.Name = "NewField13211121";
                    NewField13211121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13211121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13211121.TextFont.Name = "Arial";
                    NewField13211121.TextFont.Size = 9;
                    NewField13211121.TextFont.Bold = true;
                    NewField13211121.TextFont.CharSet = 162;
                    NewField13211121.Value = @"TUTAR";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 81, 198, 86, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"İdari ve Mali İşler Müdürü";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 48, 153, 53, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Banka / Şb.";

                    BANKACCOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 48, 211, 53, false);
                    BANKACCOUNT1.Name = "BANKACCOUNT1";
                    BANKACCOUNT1.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT1.TextFont.Name = "Arial";
                    BANKACCOUNT1.TextFont.Size = 8;
                    BANKACCOUNT1.TextFont.Bold = true;
                    BANKACCOUNT1.TextFont.CharSet = 162;
                    BANKACCOUNT1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKBRANCHNAME"", """")";

                    HOSPITALIBANNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 60, 211, 65, false);
                    HOSPITALIBANNO1.Name = "HOSPITALIBANNO1";
                    HOSPITALIBANNO1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO1.TextFont.Name = "Arial";
                    HOSPITALIBANNO1.TextFont.Size = 8;
                    HOSPITALIBANNO1.TextFont.CharSet = 162;
                    HOSPITALIBANNO1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")";

                    TAXOFFICEINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 66, 211, 71, false);
                    TAXOFFICEINFO1.Name = "TAXOFFICEINFO1";
                    TAXOFFICEINFO1.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXOFFICEINFO1.TextFont.Name = "Arial";
                    TAXOFFICEINFO1.TextFont.Size = 8;
                    TAXOFFICEINFO1.TextFont.Bold = true;
                    TAXOFFICEINFO1.TextFont.CharSet = 162;
                    TAXOFFICEINFO1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    PAGENOFOOTER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 94, 148, 99, false);
                    PAGENOFOOTER1.Name = "PAGENOFOOTER1";
                    PAGENOFOOTER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENOFOOTER1.TextFont.Name = "Arial Narrow";
                    PAGENOFOOTER1.TextFont.Size = 9;
                    PAGENOFOOTER1.TextFont.Bold = true;
                    PAGENOFOOTER1.TextFont.CharSet = 162;
                    PAGENOFOOTER1.Value = @"{@pagenumber@} / {@pagecount@}";

                    FATURATARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 16, 281, 21, false);
                    FATURATARIHI1.Name = "FATURATARIHI1";
                    FATURATARIHI1.Visible = EvetHayirEnum.ehHayir;
                    FATURATARIHI1.TextFont.Name = "Arial Narrow";
                    FATURATARIHI1.Value = @"";

                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 94, 98, 99, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.TextFont.Name = "Arial Narrow";
                    FATURATARIHI.Value = @"";

                    InvoiceNumberField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 94, 43, 99, false);
                    InvoiceNumberField.Name = "InvoiceNumberField";
                    InvoiceNumberField.TextFont.Name = "Arial Narrow";
                    InvoiceNumberField.Value = @"";

                    ReviewNumberField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 11, 281, 16, false);
                    ReviewNumberField.Name = "ReviewNumberField";
                    ReviewNumberField.Visible = EvetHayirEnum.ehHayir;
                    ReviewNumberField.TextFont.Name = "Arial Narrow";
                    ReviewNumberField.Value = @"";

                    AccountancyHeader = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 37, 129, 58, false);
                    AccountancyHeader.Name = "AccountancyHeader";
                    AccountancyHeader.TextFont.Name = "Arial Narrow";
                    AccountancyHeader.TextFont.Size = 9;
                    AccountancyHeader.TextFont.Bold = true;
                    AccountancyHeader.TextFont.CharSet = 162;
                    AccountancyHeader.Value = @"";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 100, 93, 151, 93, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 100, 93, 100, 100, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 100, 100, 151, 100, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 93, 151, 100, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, 93, 99, 93, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, 93, 45, 100, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, 100, 99, 100, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 99, 93, 99, 100, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 93, 211, 100, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 18;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"FATURA";

                    NewLine132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 93, 44, 93, false);
                    NewLine132.Name = "NewLine132";
                    NewLine132.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 93, 5, 100, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 100, 44, 100, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 44, 93, 44, 100, false);
                    NewLine1171.Name = "NewLine1171";
                    NewLine1171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 73, 168, 78, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Size = 9;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"Fatura Seri / No :";

                    InvoiceNumberField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 73, 205, 78, false);
                    InvoiceNumberField2.Name = "InvoiceNumberField2";
                    InvoiceNumberField2.TextFont.Name = "Arial Narrow";
                    InvoiceNumberField2.Value = @"";

                    NewLine1231 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 72, 207, 72, false);
                    NewLine1231.Name = "NewLine1231";
                    NewLine1231.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 72, 141, 79, false);
                    NewLine1181.Name = "NewLine1181";
                    NewLine1181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 79, 207, 79, false);
                    NewLine1191.Name = "NewLine1191";
                    NewLine1191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11811 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 207, 72, 207, 79, false);
                    NewLine11811.Name = "NewLine11811";
                    NewLine11811.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 31, 34, 36, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Sayın ;";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 28, 131, 28, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 28, 5, 65, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 65, 131, 65, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 28, 131, 65, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    IdariMudur = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 87, 198, 92, false);
                    IdariMudur.Name = "IdariMudur";
                    IdariMudur.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IdariMudur.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IdariMudur.TextFont.Name = "Arial Narrow";
                    IdariMudur.TextFont.CharSet = 162;
                    IdariMudur.Value = @"NewField18";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 48, 155, 53, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.TextFont.Name = "Arial";
                    NewField1123.TextFont.Size = 8;
                    NewField1123.TextFont.Bold = true;
                    NewField1123.TextFont.CharSet = 162;
                    NewField1123.Value = @":";

                    BANKACCOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 54, 211, 59, false);
                    BANKACCOUNT11.Name = "BANKACCOUNT11";
                    BANKACCOUNT11.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT11.TextFont.Name = "Arial";
                    BANKACCOUNT11.TextFont.Size = 8;
                    BANKACCOUNT11.TextFont.Bold = true;
                    BANKACCOUNT11.TextFont.CharSet = 162;
                    BANKACCOUNT11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")";

                    TifNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 59, 44, 64, false);
                    TifNo.Name = "TifNo";
                    TifNo.TextFont.Name = "Arial Narrow";
                    TifNo.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField121.CalcValue = NewField121.Value;
                    IBANNo.CalcValue = IBANNo.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField121112.CalcValue = NewField121112.Value;
                    NewField1211121.CalcValue = NewField1211121.Value;
                    NewField11211121.CalcValue = NewField11211121.Value;
                    NewField1211122.CalcValue = NewField1211122.Value;
                    NewField1211123.CalcValue = NewField1211123.Value;
                    NewField13211121.CalcValue = NewField13211121.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField15.CalcValue = NewField15.Value;
                    PAGENOFOOTER1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    FATURATARIHI1.CalcValue = FATURATARIHI1.Value;
                    FATURATARIHI.CalcValue = FATURATARIHI.Value;
                    InvoiceNumberField.CalcValue = InvoiceNumberField.Value;
                    ReviewNumberField.CalcValue = ReviewNumberField.Value;
                    AccountancyHeader.CalcValue = AccountancyHeader.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    InvoiceNumberField2.CalcValue = InvoiceNumberField2.Value;
                    NewField2.CalcValue = NewField2.Value;
                    IdariMudur.CalcValue = IdariMudur.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    TifNo.CalcValue = TifNo.Value;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BANKACCOUNT1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKBRANCHNAME", "");
                    HOSPITALIBANNO1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "");
                    TAXOFFICEINFO1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    BANKACCOUNT11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "");
                    return new TTReportObject[] { NewField1,NewField11,NewField3,NewField4,NewField5,NewField121,IBANNo,NewField1121,NewField16,NewField1122,NewField111,NewField1111,NewField1112,NewField7,NewField121112,NewField1211121,NewField11211121,NewField1211122,NewField1211123,NewField13211121,NewField161,NewField15,PAGENOFOOTER1,FATURATARIHI1,FATURATARIHI,InvoiceNumberField,ReviewNumberField,AccountancyHeader,NewField14,NewField12111,InvoiceNumberField2,NewField2,IdariMudur,NewField1123,TifNo,HOSPITALNAME,BANKACCOUNT1,HOSPITALIBANNO1,TAXOFFICEINFO1,BANKACCOUNT11};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    TTObjectContext context = new TTObjectContext(false);
            StockAction stockAction = (StockAction)context.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), "STOCKACTION");
            if (stockAction is ChattelDocumentOutputWithAccountancy){
                this.MyParentReport.InvoiceNumberString =((ChattelDocumentOutputWithAccountancy)stockAction).InvoiceNumberSec;
                this.ReviewNumberField.CalcValue =  this.MyParentReport.InvoiceNumberString;
                this.InvoiceNumberField.CalcValue =  this.MyParentReport.InvoiceNumberString;
                this.InvoiceNumberField2.CalcValue =  this.MyParentReport.InvoiceNumberString;
                this.AccountancyHeader.CalcValue = ((ChattelDocumentOutputWithAccountancy)stockAction).Accountancy.Name;
                this.FATURATARIHI.CalcValue = ((DateTime)(((ChattelDocumentOutputWithAccountancy)stockAction).TransactionDate)).ToShortDateString();
                this.FATURATARIHI1.CalcValue = ((DateTime)(((ChattelDocumentOutputWithAccountancy)stockAction).TransactionDate)).ToShortDateString();
                this.IdariMudur.CalcValue = SystemParameter.GetParameterValue("IDARIVEMALIISLERMUDURU", "");
            }
            string saha = TTObjectClasses.SystemParameter.GetParameterValue("STOCKSITESNAME", "PURSAKLAR");
            string tifno = "TİF NO : ";
            if (saha == "GAZİLER")
            {
                foreach (DocumentRecordLog drl in stockAction.DocumentRecordLogs.Select(string.Empty))
                {
                    if (drl.BudgeType == MKYS_EButceTurEnum.donerSermaye)
                    {
                        tifno += drl.DocumentRecordLogNumber.ToString();
                    }
                }
                this.TifNo.CalcValue = tifno;
                this.TifNo.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.TifNo.CalcValue = string.Empty;
                this.TifNo.Visible = EvetHayirEnum.ehHayir;
            }
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public PharmacyInvoiceReport MyParentReport
                {
                    get { return (PharmacyInvoiceReport)ParentReport; }
                }
                
                public TTReportField NewField1213;
                public TTReportField NewField9;
                public TTReportField NewField13231;
                public TTReportField NewField10;
                public TTReportField NewField11224;
                public TTReportField NewField1113;
                public TTReportField NewField1112212;
                public TTReportField NewField111112;
                public TTReportField NewField111122111;
                public TTReportField NewField11111111;
                public TTReportField NewField1111221111;
                public TTReportField NewField111111111;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField NewField11111;
                public TTReportField NewField6;
                public TTReportField NewField13121;
                public TTReportField PAGENOFOOTER2;
                public TTReportField TOTALPRICES;
                public TTReportField SHCEKFIELD;
                public TTReportField MERKEZPAYFIELD;
                public TTReportField HAZINEFIELD;
                public TTReportField SHCEKFIELD2;
                public TTReportField MERKEZPAYFIELD2;
                public TTReportField HAZINEFIELD2;
                public TTReportField SHCEK;
                public TTReportField MERKEZPAYI;
                public TTReportField HAZINE;
                public TTReportField TOTALPRICESWTIHSMH;
                public TTReportField Accountancy;
                public TTReportField TOTALPRICESWTIHSMH1;
                public TTReportField ICMALTARIHI;
                public TTReportField InvoiceNumberField1;
                public TTReportField NewField8;
                public TTReportShape NewLine2;
                public TTReportShape NewLine4;
                public TTReportShape NewLine12;
                public TTReportShape NewLine14;
                public TTReportShape NewLine5;
                public TTReportField NewField12;
                public TTReportField NewField111121;
                public TTReportField InvoiceNumberField12;
                public TTReportShape NewLine11812;
                public TTReportShape NewLine11911;
                public TTReportShape NewLine111811;
                public TTReportShape NewLine111911;
                public TTReportField NewField13;
                public TTReportField NewField17;
                public TTReportShape NewLine6;
                public TTReportShape NewLine16;
                public TTReportShape NewLine10;
                public TTReportShape NewLine101; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 105;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 21, 186, 26, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.TextFont.Name = "Arial";
                    NewField1213.TextFont.Size = 9;
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"ÖDENECEK TUTAR";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 29, 16, 34, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Yalnız";

                    NewField13231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 29, 18, 34, false);
                    NewField13231.Name = "NewField13231";
                    NewField13231.TextFont.Name = "Arial";
                    NewField13231.TextFont.Size = 9;
                    NewField13231.TextFont.Bold = true;
                    NewField13231.TextFont.CharSet = 162;
                    NewField13231.Value = @";";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 149, 10, false);
                    NewField10.Name = "NewField10";
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.NoClip = EvetHayirEnum.ehEvet;
                    NewField10.WordBreak = EvetHayirEnum.ehEvet;
                    NewField10.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 8;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"488 No'lu kanunun 8. Maddesine göre Döner Sermayeler, Maliye Bakanlığının 25.05.1965 tarih ve 210 / 20720 No'lu yazısı ile resmi dairelerden sayıldığından damga vergisinden muhaftır.";

                    NewField11224 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 41, 173, 46, false);
                    NewField11224.Name = "NewField11224";
                    NewField11224.TextFont.Name = "Arial";
                    NewField11224.TextFont.Size = 9;
                    NewField11224.TextFont.Bold = true;
                    NewField11224.TextFont.CharSet = 162;
                    NewField11224.Value = @":";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 41, 171, 46, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Size = 9;
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"Fatura No";

                    NewField1112212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 46, 173, 51, false);
                    NewField1112212.Name = "NewField1112212";
                    NewField1112212.TextFont.Name = "Arial";
                    NewField1112212.TextFont.Size = 9;
                    NewField1112212.TextFont.Bold = true;
                    NewField1112212.TextFont.CharSet = 162;
                    NewField1112212.Value = @":";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 46, 171, 51, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.TextFont.Name = "Arial";
                    NewField111112.TextFont.Size = 9;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"Fatura Tarihi";

                    NewField111122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 51, 173, 56, false);
                    NewField111122111.Name = "NewField111122111";
                    NewField111122111.TextFont.Name = "Arial";
                    NewField111122111.TextFont.Size = 9;
                    NewField111122111.TextFont.Bold = true;
                    NewField111122111.TextFont.CharSet = 162;
                    NewField111122111.Value = @":";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 51, 171, 56, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.TextFont.Name = "Arial";
                    NewField11111111.TextFont.Size = 9;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"Sayfa No";

                    NewField1111221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 56, 173, 61, false);
                    NewField1111221111.Name = "NewField1111221111";
                    NewField1111221111.TextFont.Name = "Arial";
                    NewField1111221111.TextFont.Size = 9;
                    NewField1111221111.TextFont.Bold = true;
                    NewField1111221111.TextFont.CharSet = 162;
                    NewField1111221111.Value = @":";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 56, 171, 61, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.TextFont.Name = "Arial";
                    NewField111111111.TextFont.Size = 9;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.TextFont.CharSet = 162;
                    NewField111111111.Value = @"Ödenecek Tutar";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 29, 210, 34, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT(TL,KR)";
                    PRICEWITHLETTERS.TextFont.Name = "Arial";
                    PRICEWITHLETTERS.TextFont.Size = 9;
                    PRICEWITHLETTERS.TextFont.Bold = true;
                    PRICEWITHLETTERS.TextFont.CharSet = 162;
                    PRICEWITHLETTERS.Value = @"";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 41, 31, 46, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Kurum / Adres :";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 48, 29, 67, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial Black";
                    NewField6.TextFont.Size = 36;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"B";

                    NewField13121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 1, 186, 6, false);
                    NewField13121.Name = "NewField13121";
                    NewField13121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13121.TextFont.Name = "Arial";
                    NewField13121.TextFont.Size = 9;
                    NewField13121.TextFont.Bold = true;
                    NewField13121.TextFont.CharSet = 162;
                    NewField13121.Value = @"TUTARI";

                    PAGENOFOOTER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 51, 210, 56, false);
                    PAGENOFOOTER2.Name = "PAGENOFOOTER2";
                    PAGENOFOOTER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENOFOOTER2.TextFont.Name = "Arial";
                    PAGENOFOOTER2.TextFont.Size = 9;
                    PAGENOFOOTER2.TextFont.Bold = true;
                    PAGENOFOOTER2.TextFont.CharSet = 162;
                    PAGENOFOOTER2.Value = @"{@pagenumber@} / {@pagecount@}";

                    TOTALPRICES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 1, 211, 6, false);
                    TOTALPRICES.Name = "TOTALPRICES";
                    TOTALPRICES.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPRICES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICES.TextFormat = @"#,##0.#0";
                    TOTALPRICES.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICES.TextFont.Name = "Arial";
                    TOTALPRICES.TextFont.Size = 9;
                    TOTALPRICES.TextFont.Bold = true;
                    TOTALPRICES.TextFont.CharSet = 162;
                    TOTALPRICES.Value = @"";

                    SHCEKFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 6, 180, 11, false);
                    SHCEKFIELD.Name = "SHCEKFIELD";
                    SHCEKFIELD.DrawStyle = DrawStyleConstants.vbSolid;
                    SHCEKFIELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHCEKFIELD.TextFont.Name = "Arial";
                    SHCEKFIELD.TextFont.Size = 8;
                    SHCEKFIELD.TextFont.Bold = true;
                    SHCEKFIELD.TextFont.CharSet = 162;
                    SHCEKFIELD.Value = @"SHÇEK";

                    MERKEZPAYFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 11, 180, 16, false);
                    MERKEZPAYFIELD.Name = "MERKEZPAYFIELD";
                    MERKEZPAYFIELD.DrawStyle = DrawStyleConstants.vbSolid;
                    MERKEZPAYFIELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MERKEZPAYFIELD.TextFont.Name = "Arial";
                    MERKEZPAYFIELD.TextFont.Size = 8;
                    MERKEZPAYFIELD.TextFont.Bold = true;
                    MERKEZPAYFIELD.TextFont.CharSet = 162;
                    MERKEZPAYFIELD.Value = @"MERKEZ PAYI";

                    HAZINEFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 16, 180, 21, false);
                    HAZINEFIELD.Name = "HAZINEFIELD";
                    HAZINEFIELD.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZINEFIELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HAZINEFIELD.TextFont.Name = "Arial";
                    HAZINEFIELD.TextFont.Size = 8;
                    HAZINEFIELD.TextFont.Bold = true;
                    HAZINEFIELD.TextFont.CharSet = 162;
                    HAZINEFIELD.Value = @"HAZİNE";

                    SHCEKFIELD2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 6, 186, 11, false);
                    SHCEKFIELD2.Name = "SHCEKFIELD2";
                    SHCEKFIELD2.DrawStyle = DrawStyleConstants.vbSolid;
                    SHCEKFIELD2.TextFont.Name = "Arial";
                    SHCEKFIELD2.TextFont.Size = 8;
                    SHCEKFIELD2.TextFont.Bold = true;
                    SHCEKFIELD2.TextFont.CharSet = 162;
                    SHCEKFIELD2.Value = @"%1";

                    MERKEZPAYFIELD2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 11, 186, 16, false);
                    MERKEZPAYFIELD2.Name = "MERKEZPAYFIELD2";
                    MERKEZPAYFIELD2.DrawStyle = DrawStyleConstants.vbSolid;
                    MERKEZPAYFIELD2.TextFont.Name = "Arial";
                    MERKEZPAYFIELD2.TextFont.Size = 8;
                    MERKEZPAYFIELD2.TextFont.Bold = true;
                    MERKEZPAYFIELD2.TextFont.CharSet = 162;
                    MERKEZPAYFIELD2.Value = @"%5";

                    HAZINEFIELD2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 16, 186, 21, false);
                    HAZINEFIELD2.Name = "HAZINEFIELD2";
                    HAZINEFIELD2.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZINEFIELD2.TextFont.Name = "Arial";
                    HAZINEFIELD2.TextFont.Size = 8;
                    HAZINEFIELD2.TextFont.Bold = true;
                    HAZINEFIELD2.TextFont.CharSet = 162;
                    HAZINEFIELD2.Value = @"%1";

                    SHCEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 6, 211, 11, false);
                    SHCEK.Name = "SHCEK";
                    SHCEK.DrawStyle = DrawStyleConstants.vbSolid;
                    SHCEK.TextFormat = @"#,##0.#0";
                    SHCEK.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHCEK.TextFont.Name = "Arial";
                    SHCEK.TextFont.Size = 8;
                    SHCEK.TextFont.Bold = true;
                    SHCEK.TextFont.CharSet = 162;
                    SHCEK.Value = @"";

                    MERKEZPAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 11, 211, 16, false);
                    MERKEZPAYI.Name = "MERKEZPAYI";
                    MERKEZPAYI.DrawStyle = DrawStyleConstants.vbSolid;
                    MERKEZPAYI.TextFormat = @"#,##0.#0";
                    MERKEZPAYI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MERKEZPAYI.TextFont.Name = "Arial";
                    MERKEZPAYI.TextFont.Size = 8;
                    MERKEZPAYI.TextFont.Bold = true;
                    MERKEZPAYI.TextFont.CharSet = 162;
                    MERKEZPAYI.Value = @"";

                    HAZINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 16, 211, 21, false);
                    HAZINE.Name = "HAZINE";
                    HAZINE.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZINE.TextFormat = @"#,##0.#0";
                    HAZINE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HAZINE.TextFont.Name = "Arial";
                    HAZINE.TextFont.Size = 8;
                    HAZINE.TextFont.Bold = true;
                    HAZINE.TextFont.CharSet = 162;
                    HAZINE.Value = @"";

                    TOTALPRICESWTIHSMH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 21, 211, 26, false);
                    TOTALPRICESWTIHSMH.Name = "TOTALPRICESWTIHSMH";
                    TOTALPRICESWTIHSMH.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPRICESWTIHSMH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICESWTIHSMH.TextFormat = @"#,##0.#0";
                    TOTALPRICESWTIHSMH.TextFont.Name = "Arial";
                    TOTALPRICESWTIHSMH.TextFont.Size = 9;
                    TOTALPRICESWTIHSMH.TextFont.Bold = true;
                    TOTALPRICESWTIHSMH.TextFont.CharSet = 162;
                    TOTALPRICESWTIHSMH.Value = @"";

                    Accountancy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 41, 145, 56, false);
                    Accountancy.Name = "Accountancy";
                    Accountancy.TextFont.Name = "Arial Narrow";
                    Accountancy.Value = @"";

                    TOTALPRICESWTIHSMH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 56, 210, 61, false);
                    TOTALPRICESWTIHSMH1.Name = "TOTALPRICESWTIHSMH1";
                    TOTALPRICESWTIHSMH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICESWTIHSMH1.TextFormat = @"#,##0.#0";
                    TOTALPRICESWTIHSMH1.TextFont.Name = "Arial";
                    TOTALPRICESWTIHSMH1.TextFont.Size = 9;
                    TOTALPRICESWTIHSMH1.TextFont.Bold = true;
                    TOTALPRICESWTIHSMH1.TextFont.CharSet = 162;
                    TOTALPRICESWTIHSMH1.Value = @"";

                    ICMALTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 46, 210, 51, false);
                    ICMALTARIHI.Name = "ICMALTARIHI";
                    ICMALTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICMALTARIHI.TextFont.Name = "Arial Narrow";
                    ICMALTARIHI.Value = @"";

                    InvoiceNumberField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 41, 210, 46, false);
                    InvoiceNumberField1.Name = "InvoiceNumberField1";
                    InvoiceNumberField1.TextFont.Name = "Arial Narrow";
                    InvoiceNumberField1.Value = @"";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 22, 148, 27, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"VERGİ USUL KANUNU HÜKÜMLERİNE TABİ DEĞİLDİR.";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 28, 211, 28, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 28, 211, 35, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 35, 211, 35, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 28, 5, 35, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -4, 37, 216, 37, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbDashDot;
                    NewLine5.FillStyle = FillStyleConstants.vbHorizontalLine;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 56, 57, 61, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"AÇIKLAMA";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 75, 34, 80, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.TextFont.Name = "Arial";
                    NewField111121.TextFont.Size = 9;
                    NewField111121.TextFont.Bold = true;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @"Fatura Seri / No :";

                    InvoiceNumberField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 75, 71, 80, false);
                    InvoiceNumberField12.Name = "InvoiceNumberField12";
                    InvoiceNumberField12.TextFont.Name = "Arial Narrow";
                    InvoiceNumberField12.Value = @"";

                    NewLine11812 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 74, 7, 81, false);
                    NewLine11812.Name = "NewLine11812";
                    NewLine11812.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11911 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 81, 73, 81, false);
                    NewLine11911.Name = "NewLine11911";
                    NewLine11911.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111811 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 74, 73, 81, false);
                    NewLine111811.Name = "NewLine111811";
                    NewLine111811.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111911 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 74, 73, 74, false);
                    NewLine111911.Name = "NewLine111911";
                    NewLine111911.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 83, 36, 97, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial Black";
                    NewField13.TextFont.Size = 16;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"DİKKAT";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 83, 209, 97, false);
                    NewField17.Name = "NewField17";
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"MUHASEBEDEN BORÇ KAYDINIZIN SİLİNEBİLMESİ İÇİN, ÖDEMESİNİ YAPTIĞINIZ FATURANIN NUMARASINI ve
 TARİHİNİN TARAFIMIZA BİLGİLENDİRİLMESİ GEREKMAKTEDİR. ÖDEMEYİ YAPTIĞINIZ BANKAYA BU BÖLÜMÜ VERİNİZ.
 LİSTE İLE YAPILAN TOPLU ÖDEMELERDE İSE LİSTEYE FATURA NUMARA ve TARİHLERİ MUTLAKA EKLEYİNİZ.";

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 39, 211, 99, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 39, 5, 99, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 39, 211, 39, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine101 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 99, 211, 99, false);
                    NewLine101.Name = "NewLine101";
                    NewLine101.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1213.CalcValue = NewField1213.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField13231.CalcValue = NewField13231.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11224.CalcValue = NewField11224.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField1112212.CalcValue = NewField1112212.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111122111.CalcValue = NewField111122111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField1111221111.CalcValue = NewField1111221111.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    PRICEWITHLETTERS.CalcValue = @"";
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField13121.CalcValue = NewField13121.Value;
                    PAGENOFOOTER2.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    TOTALPRICES.CalcValue = @"";
                    SHCEKFIELD.CalcValue = SHCEKFIELD.Value;
                    MERKEZPAYFIELD.CalcValue = MERKEZPAYFIELD.Value;
                    HAZINEFIELD.CalcValue = HAZINEFIELD.Value;
                    SHCEKFIELD2.CalcValue = SHCEKFIELD2.Value;
                    MERKEZPAYFIELD2.CalcValue = MERKEZPAYFIELD2.Value;
                    HAZINEFIELD2.CalcValue = HAZINEFIELD2.Value;
                    SHCEK.CalcValue = SHCEK.Value;
                    MERKEZPAYI.CalcValue = MERKEZPAYI.Value;
                    HAZINE.CalcValue = HAZINE.Value;
                    TOTALPRICESWTIHSMH.CalcValue = @"";
                    Accountancy.CalcValue = Accountancy.Value;
                    TOTALPRICESWTIHSMH1.CalcValue = @"";
                    ICMALTARIHI.CalcValue = @"";
                    InvoiceNumberField1.CalcValue = InvoiceNumberField1.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    InvoiceNumberField12.CalcValue = InvoiceNumberField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField17.CalcValue = NewField17.Value;
                    return new TTReportObject[] { NewField1213,NewField9,NewField13231,NewField10,NewField11224,NewField1113,NewField1112212,NewField111112,NewField111122111,NewField11111111,NewField1111221111,NewField111111111,PRICEWITHLETTERS,NewField11111,NewField6,NewField13121,PAGENOFOOTER2,TOTALPRICES,SHCEKFIELD,MERKEZPAYFIELD,HAZINEFIELD,SHCEKFIELD2,MERKEZPAYFIELD2,HAZINEFIELD2,SHCEK,MERKEZPAYI,HAZINE,TOTALPRICESWTIHSMH,Accountancy,TOTALPRICESWTIHSMH1,ICMALTARIHI,InvoiceNumberField1,NewField8,NewField12,NewField111121,InvoiceNumberField12,NewField13,NewField17};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    TTObjectContext context = new TTObjectContext(false);
            StockAction stockAction = (StockAction)context.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), "STOCKACTION");
            if (stockAction is ChattelDocumentOutputWithAccountancy){
                this.Accountancy.CalcValue = ((ChattelDocumentOutputWithAccountancy)stockAction).Accountancy.Name;
                this.ICMALTARIHI.CalcValue = ((DateTime)((ChattelDocumentOutputWithAccountancy)stockAction).TransactionDate).ToShortDateString();
                this.InvoiceNumberField12.CalcValue = this.MyParentReport.InvoiceNumberString;
                this.InvoiceNumberField1.CalcValue = ((DateTime)((ChattelDocumentOutputWithAccountancy)stockAction).TransactionDate).ToShortDateString();
            }
            this.TOTALPRICES.CalcValue =  this.MyParentReport.totalPrices.ToString();
            this.InvoiceNumberField1.CalcValue =  this.MyParentReport.InvoiceNumberString;
            if((bool)MyParentReport.RuntimeParameters.IsContributionMargin)
            {
                double sheck = this.MyParentReport.totalPrices * 1 / 100;
                double merkezPay = this.MyParentReport.totalPrices * 5 / 100;
                double hazine = this.MyParentReport.totalPrices * 1 / 100;
                this.SHCEK.CalcValue =sheck.ToString();
                this.MERKEZPAYI.CalcValue =merkezPay.ToString();
                this.HAZINE.CalcValue =hazine.ToString();
                double allPrices = this.MyParentReport.totalPrices + sheck + merkezPay + hazine;
                this.TOTALPRICESWTIHSMH.CalcValue = allPrices.ToString();
                this.TOTALPRICESWTIHSMH1.CalcValue = allPrices.ToString();
                this.PRICEWITHLETTERS.CalcValue = allPrices.ToString();
            }
            else{
                this.SHCEKFIELD.Visible = EvetHayirEnum.ehHayir;
                this.SHCEKFIELD2.Visible = EvetHayirEnum.ehHayir;
                this.MERKEZPAYFIELD.Visible = EvetHayirEnum.ehHayir;
                this.MERKEZPAYFIELD2.Visible = EvetHayirEnum.ehHayir;
                this.HAZINEFIELD.Visible = EvetHayirEnum.ehHayir;
                this.HAZINEFIELD2.Visible = EvetHayirEnum.ehHayir;
                this.SHCEK.Visible = EvetHayirEnum.ehHayir;
                this.MERKEZPAYI.Visible = EvetHayirEnum.ehHayir;
                this.HAZINE.Visible = EvetHayirEnum.ehHayir;
                this.TOTALPRICESWTIHSMH.CalcValue =this.TOTALPRICES.CalcValue;
                this.TOTALPRICESWTIHSMH1.CalcValue =this.TOTALPRICES.CalcValue;
                this.PRICEWITHLETTERS.CalcValue  =this.TOTALPRICES.CalcValue;
            }
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public PharmacyInvoiceReport MyParentReport
            {
                get { return (PharmacyInvoiceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField BARCODE { get {return Body().BARCODE;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField VATRATE { get {return Body().VATRATE;} }
            public TTReportField UNITPRICE1 { get {return Body().UNITPRICE1;} }
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
                list[0] = new TTReportNqlData<ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class>("ChattelDocOutInvoiceRQ", ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PharmacyInvoiceReport MyParentReport
                {
                    get { return (PharmacyInvoiceReport)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField UNITPRICE;
                public TTReportField AMOUNT;
                public TTReportField BARCODE;
                public TTReportField ORDERNO;
                public TTReportField PRICE;
                public TTReportField VATRATE;
                public TTReportField UNITPRICE1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 151, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.ObjectDefName = "Material";
                    MATERIALNAME.DataMember = "NAME";
                    MATERIALNAME.TextFont.Name = "Arial Narrow";
                    MATERIALNAME.TextFont.Size = 8;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIAL#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 186, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial Narrow";
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 167, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 44, 5, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.DrawStyle = DrawStyleConstants.vbSolid;
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BARCODE.ObjectDefName = "Material";
                    BARCODE.DataMember = "BARCODE";
                    BARCODE.TextFont.Name = "Arial Narrow";
                    BARCODE.TextFont.Size = 8;
                    BARCODE.TextFont.CharSet = 162;
                    BARCODE.Value = @"{#MATERIAL#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 19, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial Narrow";
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 211, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.TextFont.Name = "Arial Narrow";
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    VATRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 1, 232, 6, false);
                    VATRATE.Name = "VATRATE";
                    VATRATE.Visible = EvetHayirEnum.ehHayir;
                    VATRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VATRATE.TextFont.Name = "Arial Narrow";
                    VATRATE.Value = @"{#VATRATE#}";

                    UNITPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 1, 254, 6, false);
                    UNITPRICE1.Name = "UNITPRICE1";
                    UNITPRICE1.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE1.TextFont.Name = "Arial Narrow";
                    UNITPRICE1.TextFont.Size = 8;
                    UNITPRICE1.TextFont.CharSet = 162;
                    UNITPRICE1.Value = @"{#UNITPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class dataset_ChattelDocOutInvoiceRQ = ParentGroup.rsGroup.GetCurrentRecord<ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_ChattelDocOutInvoiceRQ != null ? Globals.ToStringCore(dataset_ChattelDocOutInvoiceRQ.Material) : "");
                    MATERIALNAME.PostFieldValueCalculation();
                    UNITPRICE.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_ChattelDocOutInvoiceRQ != null ? Globals.ToStringCore(dataset_ChattelDocOutInvoiceRQ.Amount) : "");
                    BARCODE.CalcValue = (dataset_ChattelDocOutInvoiceRQ != null ? Globals.ToStringCore(dataset_ChattelDocOutInvoiceRQ.Material) : "");
                    BARCODE.PostFieldValueCalculation();
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    PRICE.CalcValue = PRICE.Value;
                    VATRATE.CalcValue = (dataset_ChattelDocOutInvoiceRQ != null ? Globals.ToStringCore(dataset_ChattelDocOutInvoiceRQ.VatRate) : "");
                    UNITPRICE1.CalcValue = (dataset_ChattelDocOutInvoiceRQ != null ? Globals.ToStringCore(dataset_ChattelDocOutInvoiceRQ.UnitPrice) : "");
                    return new TTReportObject[] { MATERIALNAME,UNITPRICE,AMOUNT,BARCODE,ORDERNO,PRICE,VATRATE,UNITPRICE1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //double unitPrice = double.Parse(this.UNITPRICE1.CalcValue)*double.Parse(this.VATRATE.CalcValue)/100 + double.Parse(this.UNITPRICE1.CalcValue) ; KDV ile çarpılmayacak haline getildi.
            double unitPrice = double.Parse(this.UNITPRICE1.CalcValue);
            this.UNITPRICE.CalcValue = unitPrice.ToString();
            
            double price = double.Parse(this.AMOUNT.CalcValue)*double.Parse(this.UNITPRICE.CalcValue);
            this.PRICE.CalcValue = price.ToString();
            this.MyParentReport.totalPrices += price;
            
            int i =3;
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                return true;
#endregion MAIN_Script
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PharmacyInvoiceReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "StockActionID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("IsContributionMargin", "", "Katkı Payı İçerir", @"", true, true, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("IsContributionMargin"))
                _runtimeParameters.IsContributionMargin = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["IsContributionMargin"]);
            Name = "PHARMACYINVOICEREPORT";
            Caption = "Eczane Faturası";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 216;
            p_PageHeight = 305;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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
            fd.TextFont.Name = "Courier New";
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