
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
    /// Genel Fatura İstatistiği
    /// </summary>
    public partial class GeneralInvoiceStatistic : TTReport
    {
#region Methods
   public class Durumlar
        {
            public int hastaSayisi = 0;
            public double tutar = 0;
            public string isim = "";
            public Durumlar()
            {
                this.hastaSayisi = 0;
                this.tutar = 0;
            }
        }
        
        public class Aylar
        {
            public Durumlar toplamFatura = null;
            public Durumlar faturaEdilen = null;
            public string isim = "";
            public Aylar(string ad)
            {
                this.isim = ad;
                this.toplamFatura = new Durumlar();
                this.faturaEdilen = new Durumlar();
            }
        }
        public BindingList<Aylar> ayList = new BindingList<Aylar>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? YEAR = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public GeneralInvoiceStatistic MyParentReport
            {
                get { return (GeneralInvoiceStatistic)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField YEAR { get {return Header().YEAR;} }
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
                public GeneralInvoiceStatistic MyParentReport
                {
                    get { return (GeneralInvoiceStatistic)ParentReport; }
                }
                
                public TTReportField YEAR; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 31, 6, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFormat = @"dd/MM/yyyy";
                    YEAR.Value = @"{@YEAR@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    YEAR.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    return new TTReportObject[] { YEAR};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    ((GeneralInvoiceStatistic)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime("01.01."+ Convert.ToDateTime(YEAR.FormattedValue).Year + " 00:00:00");
            ((GeneralInvoiceStatistic)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime("31.12."+Convert.ToDateTime(YEAR.FormattedValue).Year + " 23:59:59");
            ((GeneralInvoiceStatistic)ParentReport).ayList.Clear();
            
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("OCAK"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("SUBAT"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("MART"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("NISAN"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("MAYIS"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("HAZIRAN"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("TEMMUZ"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("AGUSTOS"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("EYLUL"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("EKIM"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("KASIM"));
            ((GeneralInvoiceStatistic)ParentReport).ayList.Add(new Aylar("ARALIK"));
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public GeneralInvoiceStatistic MyParentReport
                {
                    get { return (GeneralInvoiceStatistic)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTDGroup : TTReportGroup
        {
            public GeneralInvoiceStatistic MyParentReport
            {
                get { return (GeneralInvoiceStatistic)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField FATURALANAN { get {return Body().FATURALANAN;} }
            public TTReportField TOPLAMFATURA { get {return Body().TOPLAMFATURA;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public GeneralInvoiceStatistic MyParentReport
                {
                    get { return (GeneralInvoiceStatistic)ParentReport; }
                }
                
                public TTReportField TARIH;
                public TTReportField FATURALANAN;
                public TTReportField TOPLAMFATURA;
                public TTReportField STATUS; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 34, 6, false);
                    TARIH.Name = "TARIH";
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.Value = @"{#DATE#}";

                    FATURALANAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 61, 6, false);
                    FATURALANAN.Name = "FATURALANAN";
                    FATURALANAN.Value = @"{#MEDULAPRICE#}";

                    TOPLAMFATURA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 1, 87, 6, false);
                    TOPLAMFATURA.Name = "TOPLAMFATURA";
                    TOPLAMFATURA.Value = @"{#TOTALPRICE#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 1, 113, 6, false);
                    STATUS.Name = "STATUS";
                    STATUS.Value = @"{#STATUS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TARIH.CalcValue = TARIH.Value;
                    FATURALANAN.CalcValue = FATURALANAN.Value;
                    TOPLAMFATURA.CalcValue = TOPLAMFATURA.Value;
                    STATUS.CalcValue = STATUS.Value;
                    return new TTReportObject[] { TARIH,FATURALANAN,TOPLAMFATURA,STATUS};
                }

                public override void RunScript()
                {
#region PARTD BODY_Script
                    ((GeneralInvoiceStatistic)ParentReport).ayList[(Convert.ToDateTime(this.TARIH.CalcValue).Month) -1].toplamFatura.hastaSayisi++;
            ((GeneralInvoiceStatistic)ParentReport).ayList[(Convert.ToDateTime(this.TARIH.CalcValue).Month) - 1].toplamFatura.tutar += Convert.ToDouble(this.TOPLAMFATURA.CalcValue);
            if (this.STATUS.CalcValue == "Invoiced" || this.STATUS.CalcValue == "7")
            {
                ((GeneralInvoiceStatistic)ParentReport).ayList[(Convert.ToDateTime(this.TARIH.CalcValue).Month) - 1].faturaEdilen.hastaSayisi++;
                ((GeneralInvoiceStatistic)ParentReport).ayList[(Convert.ToDateTime(this.TARIH.CalcValue).Month) - 1].faturaEdilen.tutar += Convert.ToDouble(this.FATURALANAN.CalcValue);
            }
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PRATAGroup : TTReportGroup
        {
            public GeneralInvoiceStatistic MyParentReport
            {
                get { return (GeneralInvoiceStatistic)ParentReport; }
            }

            new public PRATAGroupHeader Header()
            {
                return (PRATAGroupHeader)_header;
            }

            new public PRATAGroupFooter Footer()
            {
                return (PRATAGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField YIL { get {return Header().YIL;} }
            public TTReportField YEAR { get {return Header().YEAR;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public PRATAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PRATAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PRATAGroupHeader(this);
                _footer = new PRATAGroupFooter(this);

            }

            public partial class PRATAGroupHeader : TTReportSection
            {
                public GeneralInvoiceStatistic MyParentReport
                {
                    get { return (GeneralInvoiceStatistic)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField YIL;
                public TTReportField YEAR; 
                public PRATAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 32;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 205, 20, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"GENEL FATURA İSTATİSTİĞİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 13, 31, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"YIL";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 14, 31, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @":";

                    YIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 26, 29, 31, false);
                    YIL.Name = "YIL";
                    YIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YIL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    YIL.Value = @"";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 23, 241, 28, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFormat = @"dd/MM/yyyy";
                    YEAR.Value = @"{@YEAR@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    YIL.CalcValue = @"";
                    YEAR.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    return new TTReportObject[] { NewField1111,NewField1,NewField2,YIL,YEAR};
                }

                public override void RunScript()
                {
#region PRATA HEADER_Script
                    this.YIL.CalcValue = (Convert.ToDateTime(YEAR.FormattedValue).Year).ToString();
#endregion PRATA HEADER_Script
                }
            }
            public partial class PRATAGroupFooter : TTReportSection
            {
                public GeneralInvoiceStatistic MyParentReport
                {
                    get { return (GeneralInvoiceStatistic)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PRATAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 2, 137, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 2, 203, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 2, 36, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PRATAGroup PRATA;

        public partial class MAINGroup : TTReportGroup
        {
            public GeneralInvoiceStatistic MyParentReport
            {
                get { return (GeneralInvoiceStatistic)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField1311 { get {return Body().NewField1311;} }
            public TTReportField NewField11131 { get {return Body().NewField11131;} }
            public TTReportField NewField11132 { get {return Body().NewField11132;} }
            public TTReportField NewField113111 { get {return Body().NewField113111;} }
            public TTReportField NewField11133 { get {return Body().NewField11133;} }
            public TTReportField NewField113112 { get {return Body().NewField113112;} }
            public TTReportField NewField11134 { get {return Body().NewField11134;} }
            public TTReportField NewField113113 { get {return Body().NewField113113;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField OCAK_HS1 { get {return Body().OCAK_HS1;} }
            public TTReportField OCAK_T1 { get {return Body().OCAK_T1;} }
            public TTReportField OCAK_HS2 { get {return Body().OCAK_HS2;} }
            public TTReportField OCAK_T2 { get {return Body().OCAK_T2;} }
            public TTReportField OCAK_HS3 { get {return Body().OCAK_HS3;} }
            public TTReportField OCAK_T3 { get {return Body().OCAK_T3;} }
            public TTReportField OCAK_HS4 { get {return Body().OCAK_HS4;} }
            public TTReportField OCAK_T4 { get {return Body().OCAK_T4;} }
            public TTReportField SUBAT_HS1 { get {return Body().SUBAT_HS1;} }
            public TTReportField SUBAT_T1 { get {return Body().SUBAT_T1;} }
            public TTReportField SUBAT_HS2 { get {return Body().SUBAT_HS2;} }
            public TTReportField SUBAT_T2 { get {return Body().SUBAT_T2;} }
            public TTReportField SUBAT_HS3 { get {return Body().SUBAT_HS3;} }
            public TTReportField SUBAT_T3 { get {return Body().SUBAT_T3;} }
            public TTReportField SUBAT_HS4 { get {return Body().SUBAT_HS4;} }
            public TTReportField SUBAT_T4 { get {return Body().SUBAT_T4;} }
            public TTReportField MART_HS1 { get {return Body().MART_HS1;} }
            public TTReportField MART_T1 { get {return Body().MART_T1;} }
            public TTReportField MART_HS2 { get {return Body().MART_HS2;} }
            public TTReportField MART_T2 { get {return Body().MART_T2;} }
            public TTReportField MART_HS3 { get {return Body().MART_HS3;} }
            public TTReportField MART_T3 { get {return Body().MART_T3;} }
            public TTReportField MART_HS4 { get {return Body().MART_HS4;} }
            public TTReportField MART_T4 { get {return Body().MART_T4;} }
            public TTReportField NISAN_HS1 { get {return Body().NISAN_HS1;} }
            public TTReportField NISAN_T1 { get {return Body().NISAN_T1;} }
            public TTReportField NISAN_HS2 { get {return Body().NISAN_HS2;} }
            public TTReportField NISAN_T2 { get {return Body().NISAN_T2;} }
            public TTReportField NISAN_HS3 { get {return Body().NISAN_HS3;} }
            public TTReportField NISAN_T3 { get {return Body().NISAN_T3;} }
            public TTReportField NISAN_HS4 { get {return Body().NISAN_HS4;} }
            public TTReportField NISAN_T4 { get {return Body().NISAN_T4;} }
            public TTReportField MAYIS_HS1 { get {return Body().MAYIS_HS1;} }
            public TTReportField MAYIS_T1 { get {return Body().MAYIS_T1;} }
            public TTReportField MAYIS_HS2 { get {return Body().MAYIS_HS2;} }
            public TTReportField MAYIS_T2 { get {return Body().MAYIS_T2;} }
            public TTReportField MAYIS_HS3 { get {return Body().MAYIS_HS3;} }
            public TTReportField MAYIS_T3 { get {return Body().MAYIS_T3;} }
            public TTReportField MAYIS_HS4 { get {return Body().MAYIS_HS4;} }
            public TTReportField MAYIS_T4 { get {return Body().MAYIS_T4;} }
            public TTReportField HAZIRAN_HS1 { get {return Body().HAZIRAN_HS1;} }
            public TTReportField HAZIRAN_T1 { get {return Body().HAZIRAN_T1;} }
            public TTReportField HAZIRAN_HS2 { get {return Body().HAZIRAN_HS2;} }
            public TTReportField HAZIRAN_T2 { get {return Body().HAZIRAN_T2;} }
            public TTReportField HAZIRAN_HS3 { get {return Body().HAZIRAN_HS3;} }
            public TTReportField HAZIRAN_T3 { get {return Body().HAZIRAN_T3;} }
            public TTReportField HAZIRAN_HS4 { get {return Body().HAZIRAN_HS4;} }
            public TTReportField HAZIRAN_T4 { get {return Body().HAZIRAN_T4;} }
            public TTReportField TEMMUZ_HS1 { get {return Body().TEMMUZ_HS1;} }
            public TTReportField TEMMUZ_T1 { get {return Body().TEMMUZ_T1;} }
            public TTReportField TEMMUZ_HS2 { get {return Body().TEMMUZ_HS2;} }
            public TTReportField TEMMUZ_T2 { get {return Body().TEMMUZ_T2;} }
            public TTReportField TEMMUZ_HS3 { get {return Body().TEMMUZ_HS3;} }
            public TTReportField TEMMUZ_T3 { get {return Body().TEMMUZ_T3;} }
            public TTReportField TEMMUZ_HS4 { get {return Body().TEMMUZ_HS4;} }
            public TTReportField TEMMUZ_T4 { get {return Body().TEMMUZ_T4;} }
            public TTReportField AGUSTOS_HS1 { get {return Body().AGUSTOS_HS1;} }
            public TTReportField AGUSTOS_T1 { get {return Body().AGUSTOS_T1;} }
            public TTReportField AGUSTOS_HS2 { get {return Body().AGUSTOS_HS2;} }
            public TTReportField AGUSTOS_T2 { get {return Body().AGUSTOS_T2;} }
            public TTReportField AGUSTOS_HS3 { get {return Body().AGUSTOS_HS3;} }
            public TTReportField AGUSTOS_T3 { get {return Body().AGUSTOS_T3;} }
            public TTReportField AGUSTOS_HS4 { get {return Body().AGUSTOS_HS4;} }
            public TTReportField AGUSTOS_T4 { get {return Body().AGUSTOS_T4;} }
            public TTReportField EYLUL_HS1 { get {return Body().EYLUL_HS1;} }
            public TTReportField EYLUL_T1 { get {return Body().EYLUL_T1;} }
            public TTReportField EYLUL_HS2 { get {return Body().EYLUL_HS2;} }
            public TTReportField EYLUL_T2 { get {return Body().EYLUL_T2;} }
            public TTReportField EYLUL_HS3 { get {return Body().EYLUL_HS3;} }
            public TTReportField EYLUL_T3 { get {return Body().EYLUL_T3;} }
            public TTReportField EYLUL_HS4 { get {return Body().EYLUL_HS4;} }
            public TTReportField EYLUL_T4 { get {return Body().EYLUL_T4;} }
            public TTReportField EKIM_HS1 { get {return Body().EKIM_HS1;} }
            public TTReportField EKIM_T1 { get {return Body().EKIM_T1;} }
            public TTReportField EKIM_HS2 { get {return Body().EKIM_HS2;} }
            public TTReportField EKIM_T2 { get {return Body().EKIM_T2;} }
            public TTReportField EKIM_HS3 { get {return Body().EKIM_HS3;} }
            public TTReportField EKIM_T3 { get {return Body().EKIM_T3;} }
            public TTReportField EKIM_HS4 { get {return Body().EKIM_HS4;} }
            public TTReportField EKIM_T4 { get {return Body().EKIM_T4;} }
            public TTReportField KASIM_HS1 { get {return Body().KASIM_HS1;} }
            public TTReportField KASIM_T1 { get {return Body().KASIM_T1;} }
            public TTReportField KASIM_HS2 { get {return Body().KASIM_HS2;} }
            public TTReportField KASIM_T2 { get {return Body().KASIM_T2;} }
            public TTReportField KASIM_HS3 { get {return Body().KASIM_HS3;} }
            public TTReportField KASIM_T3 { get {return Body().KASIM_T3;} }
            public TTReportField KASIM_HS4 { get {return Body().KASIM_HS4;} }
            public TTReportField KASIM_T4 { get {return Body().KASIM_T4;} }
            public TTReportField ARALIK_HS1 { get {return Body().ARALIK_HS1;} }
            public TTReportField ARALIK_T1 { get {return Body().ARALIK_T1;} }
            public TTReportField ARALIK_HS2 { get {return Body().ARALIK_HS2;} }
            public TTReportField ARALIK_T2 { get {return Body().ARALIK_T2;} }
            public TTReportField ARALIK_HS3 { get {return Body().ARALIK_HS3;} }
            public TTReportField ARALIK_T3 { get {return Body().ARALIK_T3;} }
            public TTReportField ARALIK_HS4 { get {return Body().ARALIK_HS4;} }
            public TTReportField ARALIK_T4 { get {return Body().ARALIK_T4;} }
            public TTReportField NewField1112121 { get {return Body().NewField1112121;} }
            public TTReportField T_HS1 { get {return Body().T_HS1;} }
            public TTReportField T_T1 { get {return Body().T_T1;} }
            public TTReportField T_HS2 { get {return Body().T_HS2;} }
            public TTReportField T_T2 { get {return Body().T_T2;} }
            public TTReportField T_HS3 { get {return Body().T_HS3;} }
            public TTReportField T_T3 { get {return Body().T_T3;} }
            public TTReportField T_HS4 { get {return Body().T_HS4;} }
            public TTReportField T_T4 { get {return Body().T_T4;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
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
                public GeneralInvoiceStatistic MyParentReport
                {
                    get { return (GeneralInvoiceStatistic)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField113;
                public TTReportField NewField1;
                public TTReportField NewField1311;
                public TTReportField NewField11131;
                public TTReportField NewField11132;
                public TTReportField NewField113111;
                public TTReportField NewField11133;
                public TTReportField NewField113112;
                public TTReportField NewField11134;
                public TTReportField NewField113113;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField121;
                public TTReportField NewField14;
                public TTReportField NewField122;
                public TTReportField NewField131;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField141;
                public TTReportField NewField1221;
                public TTReportField NewField1131;
                public TTReportField OCAK_HS1;
                public TTReportField OCAK_T1;
                public TTReportField OCAK_HS2;
                public TTReportField OCAK_T2;
                public TTReportField OCAK_HS3;
                public TTReportField OCAK_T3;
                public TTReportField OCAK_HS4;
                public TTReportField OCAK_T4;
                public TTReportField SUBAT_HS1;
                public TTReportField SUBAT_T1;
                public TTReportField SUBAT_HS2;
                public TTReportField SUBAT_T2;
                public TTReportField SUBAT_HS3;
                public TTReportField SUBAT_T3;
                public TTReportField SUBAT_HS4;
                public TTReportField SUBAT_T4;
                public TTReportField MART_HS1;
                public TTReportField MART_T1;
                public TTReportField MART_HS2;
                public TTReportField MART_T2;
                public TTReportField MART_HS3;
                public TTReportField MART_T3;
                public TTReportField MART_HS4;
                public TTReportField MART_T4;
                public TTReportField NISAN_HS1;
                public TTReportField NISAN_T1;
                public TTReportField NISAN_HS2;
                public TTReportField NISAN_T2;
                public TTReportField NISAN_HS3;
                public TTReportField NISAN_T3;
                public TTReportField NISAN_HS4;
                public TTReportField NISAN_T4;
                public TTReportField MAYIS_HS1;
                public TTReportField MAYIS_T1;
                public TTReportField MAYIS_HS2;
                public TTReportField MAYIS_T2;
                public TTReportField MAYIS_HS3;
                public TTReportField MAYIS_T3;
                public TTReportField MAYIS_HS4;
                public TTReportField MAYIS_T4;
                public TTReportField HAZIRAN_HS1;
                public TTReportField HAZIRAN_T1;
                public TTReportField HAZIRAN_HS2;
                public TTReportField HAZIRAN_T2;
                public TTReportField HAZIRAN_HS3;
                public TTReportField HAZIRAN_T3;
                public TTReportField HAZIRAN_HS4;
                public TTReportField HAZIRAN_T4;
                public TTReportField TEMMUZ_HS1;
                public TTReportField TEMMUZ_T1;
                public TTReportField TEMMUZ_HS2;
                public TTReportField TEMMUZ_T2;
                public TTReportField TEMMUZ_HS3;
                public TTReportField TEMMUZ_T3;
                public TTReportField TEMMUZ_HS4;
                public TTReportField TEMMUZ_T4;
                public TTReportField AGUSTOS_HS1;
                public TTReportField AGUSTOS_T1;
                public TTReportField AGUSTOS_HS2;
                public TTReportField AGUSTOS_T2;
                public TTReportField AGUSTOS_HS3;
                public TTReportField AGUSTOS_T3;
                public TTReportField AGUSTOS_HS4;
                public TTReportField AGUSTOS_T4;
                public TTReportField EYLUL_HS1;
                public TTReportField EYLUL_T1;
                public TTReportField EYLUL_HS2;
                public TTReportField EYLUL_T2;
                public TTReportField EYLUL_HS3;
                public TTReportField EYLUL_T3;
                public TTReportField EYLUL_HS4;
                public TTReportField EYLUL_T4;
                public TTReportField EKIM_HS1;
                public TTReportField EKIM_T1;
                public TTReportField EKIM_HS2;
                public TTReportField EKIM_T2;
                public TTReportField EKIM_HS3;
                public TTReportField EKIM_T3;
                public TTReportField EKIM_HS4;
                public TTReportField EKIM_T4;
                public TTReportField KASIM_HS1;
                public TTReportField KASIM_T1;
                public TTReportField KASIM_HS2;
                public TTReportField KASIM_T2;
                public TTReportField KASIM_HS3;
                public TTReportField KASIM_T3;
                public TTReportField KASIM_HS4;
                public TTReportField KASIM_T4;
                public TTReportField ARALIK_HS1;
                public TTReportField ARALIK_T1;
                public TTReportField ARALIK_HS2;
                public TTReportField ARALIK_T2;
                public TTReportField ARALIK_HS3;
                public TTReportField ARALIK_T3;
                public TTReportField ARALIK_HS4;
                public TTReportField ARALIK_T4;
                public TTReportField NewField1112121;
                public TTReportField T_HS1;
                public TTReportField T_T1;
                public TTReportField T_HS2;
                public TTReportField T_T2;
                public TTReportField T_HS3;
                public TTReportField T_T3;
                public TTReportField T_HS4;
                public TTReportField T_T4;
                public TTReportField NewField2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 98;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 3, 203, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Fatura Kaybı (%)";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 3, 159, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Fatura Edilmeyen";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 3, 115, 10, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Fatura Edilen";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 3, 71, 10, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Name = "Arial";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"Toplam Fatura";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 17, 27, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"OCAK";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 10, 52, 17, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Name = "Arial";
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @"Takip Sayısı";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 10, 71, 17, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11131.TextFont.Name = "Arial";
                    NewField11131.TextFont.Bold = true;
                    NewField11131.TextFont.CharSet = 162;
                    NewField11131.Value = @"Tutarı";

                    NewField11132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 10, 96, 17, false);
                    NewField11132.Name = "NewField11132";
                    NewField11132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11132.TextFont.Name = "Arial";
                    NewField11132.TextFont.Bold = true;
                    NewField11132.TextFont.CharSet = 162;
                    NewField11132.Value = @"Takip Sayısı";

                    NewField113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 10, 115, 17, false);
                    NewField113111.Name = "NewField113111";
                    NewField113111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111.TextFont.Name = "Arial";
                    NewField113111.TextFont.Bold = true;
                    NewField113111.TextFont.CharSet = 162;
                    NewField113111.Value = @"Tutarı";

                    NewField11133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 10, 140, 17, false);
                    NewField11133.Name = "NewField11133";
                    NewField11133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11133.TextFont.Name = "Arial";
                    NewField11133.TextFont.Bold = true;
                    NewField11133.TextFont.CharSet = 162;
                    NewField11133.Value = @"Takip Sayısı";

                    NewField113112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 10, 159, 17, false);
                    NewField113112.Name = "NewField113112";
                    NewField113112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113112.TextFont.Name = "Arial";
                    NewField113112.TextFont.Bold = true;
                    NewField113112.TextFont.CharSet = 162;
                    NewField113112.Value = @"Tutarı";

                    NewField11134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 10, 184, 17, false);
                    NewField11134.Name = "NewField11134";
                    NewField11134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11134.TextFont.Name = "Arial";
                    NewField11134.TextFont.Bold = true;
                    NewField11134.TextFont.CharSet = 162;
                    NewField11134.Value = @"Takip Sayısı";

                    NewField113113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 10, 203, 17, false);
                    NewField113113.Name = "NewField113113";
                    NewField113113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113113.TextFont.Name = "Arial";
                    NewField113113.TextFont.Bold = true;
                    NewField113113.TextFont.CharSet = 162;
                    NewField113113.Value = @"Tutarı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 22, 27, 27, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"ŞUBAT";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 27, 27, 32, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"MART";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 32, 27, 37, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"NİSAN";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 37, 27, 42, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"MAYIS";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 42, 27, 47, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"HAZİRAN";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 47, 27, 52, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"TEMMUZ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 52, 27, 57, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"AĞUSTOS";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 57, 27, 62, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"EYLÜL";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 62, 27, 67, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"EKİM";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 67, 27, 72, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"KASIM";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 72, 27, 77, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"ARALIK";

                    OCAK_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 17, 52, 22, false);
                    OCAK_HS1.Name = "OCAK_HS1";
                    OCAK_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_HS1.Value = @"";

                    OCAK_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 17, 71, 22, false);
                    OCAK_T1.Name = "OCAK_T1";
                    OCAK_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_T1.TextFormat = @"#,##0.#0";
                    OCAK_T1.Value = @"";

                    OCAK_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 17, 96, 22, false);
                    OCAK_HS2.Name = "OCAK_HS2";
                    OCAK_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_HS2.Value = @"";

                    OCAK_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 17, 115, 22, false);
                    OCAK_T2.Name = "OCAK_T2";
                    OCAK_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_T2.TextFormat = @"#,##0.#0";
                    OCAK_T2.Value = @"";

                    OCAK_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 17, 140, 22, false);
                    OCAK_HS3.Name = "OCAK_HS3";
                    OCAK_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_HS3.Value = @"";

                    OCAK_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 17, 159, 22, false);
                    OCAK_T3.Name = "OCAK_T3";
                    OCAK_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_T3.TextFormat = @"#,##0.#0";
                    OCAK_T3.Value = @"";

                    OCAK_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 17, 184, 22, false);
                    OCAK_HS4.Name = "OCAK_HS4";
                    OCAK_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_HS4.TextFormat = @"#,##0.#0";
                    OCAK_HS4.Value = @"";

                    OCAK_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 17, 203, 22, false);
                    OCAK_T4.Name = "OCAK_T4";
                    OCAK_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    OCAK_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    OCAK_T4.TextFormat = @"#,##0.#0";
                    OCAK_T4.Value = @"";

                    SUBAT_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 22, 52, 27, false);
                    SUBAT_HS1.Name = "SUBAT_HS1";
                    SUBAT_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_HS1.Value = @"";

                    SUBAT_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 22, 71, 27, false);
                    SUBAT_T1.Name = "SUBAT_T1";
                    SUBAT_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_T1.TextFormat = @"#,##0.#0";
                    SUBAT_T1.Value = @"";

                    SUBAT_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 22, 96, 27, false);
                    SUBAT_HS2.Name = "SUBAT_HS2";
                    SUBAT_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_HS2.Value = @"";

                    SUBAT_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 22, 115, 27, false);
                    SUBAT_T2.Name = "SUBAT_T2";
                    SUBAT_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_T2.TextFormat = @"#,##0.#0";
                    SUBAT_T2.Value = @"";

                    SUBAT_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 22, 140, 27, false);
                    SUBAT_HS3.Name = "SUBAT_HS3";
                    SUBAT_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_HS3.Value = @"";

                    SUBAT_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 22, 159, 27, false);
                    SUBAT_T3.Name = "SUBAT_T3";
                    SUBAT_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_T3.TextFormat = @"#,##0.#0";
                    SUBAT_T3.Value = @"";

                    SUBAT_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 22, 184, 27, false);
                    SUBAT_HS4.Name = "SUBAT_HS4";
                    SUBAT_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_HS4.TextFormat = @"#,##0.#0";
                    SUBAT_HS4.Value = @"";

                    SUBAT_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 22, 203, 27, false);
                    SUBAT_T4.Name = "SUBAT_T4";
                    SUBAT_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBAT_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBAT_T4.TextFormat = @"#,##0.#0";
                    SUBAT_T4.Value = @"";

                    MART_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 27, 52, 32, false);
                    MART_HS1.Name = "MART_HS1";
                    MART_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_HS1.Value = @"";

                    MART_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 27, 71, 32, false);
                    MART_T1.Name = "MART_T1";
                    MART_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_T1.TextFormat = @"#,##0.#0";
                    MART_T1.Value = @"";

                    MART_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 27, 96, 32, false);
                    MART_HS2.Name = "MART_HS2";
                    MART_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_HS2.Value = @"";

                    MART_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 27, 115, 32, false);
                    MART_T2.Name = "MART_T2";
                    MART_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_T2.TextFormat = @"#,##0.#0";
                    MART_T2.Value = @"";

                    MART_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 27, 140, 32, false);
                    MART_HS3.Name = "MART_HS3";
                    MART_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_HS3.Value = @"";

                    MART_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 27, 159, 32, false);
                    MART_T3.Name = "MART_T3";
                    MART_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_T3.TextFormat = @"#,##0.#0";
                    MART_T3.Value = @"";

                    MART_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 27, 184, 32, false);
                    MART_HS4.Name = "MART_HS4";
                    MART_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_HS4.TextFormat = @"#,##0.#0";
                    MART_HS4.Value = @"";

                    MART_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 27, 203, 32, false);
                    MART_T4.Name = "MART_T4";
                    MART_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    MART_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    MART_T4.TextFormat = @"#,##0.#0";
                    MART_T4.Value = @"";

                    NISAN_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 32, 52, 37, false);
                    NISAN_HS1.Name = "NISAN_HS1";
                    NISAN_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_HS1.Value = @"";

                    NISAN_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 32, 71, 37, false);
                    NISAN_T1.Name = "NISAN_T1";
                    NISAN_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_T1.TextFormat = @"#,##0.#0";
                    NISAN_T1.Value = @"";

                    NISAN_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 32, 96, 37, false);
                    NISAN_HS2.Name = "NISAN_HS2";
                    NISAN_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_HS2.Value = @"";

                    NISAN_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 32, 115, 37, false);
                    NISAN_T2.Name = "NISAN_T2";
                    NISAN_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_T2.TextFormat = @"#,##0.#0";
                    NISAN_T2.Value = @"";

                    NISAN_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 32, 140, 37, false);
                    NISAN_HS3.Name = "NISAN_HS3";
                    NISAN_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_HS3.Value = @"";

                    NISAN_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 32, 159, 37, false);
                    NISAN_T3.Name = "NISAN_T3";
                    NISAN_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_T3.TextFormat = @"#,##0.#0";
                    NISAN_T3.Value = @"";

                    NISAN_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 32, 184, 37, false);
                    NISAN_HS4.Name = "NISAN_HS4";
                    NISAN_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_HS4.TextFormat = @"#,##0.#0";
                    NISAN_HS4.Value = @"";

                    NISAN_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 32, 203, 37, false);
                    NISAN_T4.Name = "NISAN_T4";
                    NISAN_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    NISAN_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NISAN_T4.TextFormat = @"#,##0.#0";
                    NISAN_T4.Value = @"";

                    MAYIS_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 37, 52, 42, false);
                    MAYIS_HS1.Name = "MAYIS_HS1";
                    MAYIS_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_HS1.Value = @"";

                    MAYIS_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 37, 71, 42, false);
                    MAYIS_T1.Name = "MAYIS_T1";
                    MAYIS_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_T1.TextFormat = @"#,##0.#0";
                    MAYIS_T1.Value = @"";

                    MAYIS_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 37, 96, 42, false);
                    MAYIS_HS2.Name = "MAYIS_HS2";
                    MAYIS_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_HS2.Value = @"";

                    MAYIS_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 37, 115, 42, false);
                    MAYIS_T2.Name = "MAYIS_T2";
                    MAYIS_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_T2.TextFormat = @"#,##0.#0";
                    MAYIS_T2.Value = @"";

                    MAYIS_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 37, 140, 42, false);
                    MAYIS_HS3.Name = "MAYIS_HS3";
                    MAYIS_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_HS3.Value = @"";

                    MAYIS_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 37, 159, 42, false);
                    MAYIS_T3.Name = "MAYIS_T3";
                    MAYIS_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_T3.TextFormat = @"#,##0.#0";
                    MAYIS_T3.Value = @"";

                    MAYIS_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 37, 184, 42, false);
                    MAYIS_HS4.Name = "MAYIS_HS4";
                    MAYIS_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_HS4.TextFormat = @"#,##0.#0";
                    MAYIS_HS4.Value = @"";

                    MAYIS_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 37, 203, 42, false);
                    MAYIS_T4.Name = "MAYIS_T4";
                    MAYIS_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    MAYIS_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAYIS_T4.TextFormat = @"#,##0.#0";
                    MAYIS_T4.Value = @"";

                    HAZIRAN_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 42, 52, 47, false);
                    HAZIRAN_HS1.Name = "HAZIRAN_HS1";
                    HAZIRAN_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_HS1.Value = @"";

                    HAZIRAN_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 42, 71, 47, false);
                    HAZIRAN_T1.Name = "HAZIRAN_T1";
                    HAZIRAN_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_T1.TextFormat = @"#,##0.#0";
                    HAZIRAN_T1.Value = @"";

                    HAZIRAN_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 42, 96, 47, false);
                    HAZIRAN_HS2.Name = "HAZIRAN_HS2";
                    HAZIRAN_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_HS2.Value = @"";

                    HAZIRAN_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 42, 115, 47, false);
                    HAZIRAN_T2.Name = "HAZIRAN_T2";
                    HAZIRAN_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_T2.TextFormat = @"#,##0.#0";
                    HAZIRAN_T2.Value = @"";

                    HAZIRAN_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 42, 140, 47, false);
                    HAZIRAN_HS3.Name = "HAZIRAN_HS3";
                    HAZIRAN_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_HS3.Value = @"";

                    HAZIRAN_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 42, 159, 47, false);
                    HAZIRAN_T3.Name = "HAZIRAN_T3";
                    HAZIRAN_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_T3.TextFormat = @"#,##0.#0";
                    HAZIRAN_T3.Value = @"";

                    HAZIRAN_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 42, 184, 47, false);
                    HAZIRAN_HS4.Name = "HAZIRAN_HS4";
                    HAZIRAN_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_HS4.TextFormat = @"#,##0.#0";
                    HAZIRAN_HS4.Value = @"";

                    HAZIRAN_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 42, 203, 47, false);
                    HAZIRAN_T4.Name = "HAZIRAN_T4";
                    HAZIRAN_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    HAZIRAN_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    HAZIRAN_T4.TextFormat = @"#,##0.#0";
                    HAZIRAN_T4.Value = @"";

                    TEMMUZ_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 47, 52, 52, false);
                    TEMMUZ_HS1.Name = "TEMMUZ_HS1";
                    TEMMUZ_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_HS1.Value = @"";

                    TEMMUZ_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 47, 71, 52, false);
                    TEMMUZ_T1.Name = "TEMMUZ_T1";
                    TEMMUZ_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_T1.TextFormat = @"#,##0.#0";
                    TEMMUZ_T1.Value = @"";

                    TEMMUZ_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 47, 96, 52, false);
                    TEMMUZ_HS2.Name = "TEMMUZ_HS2";
                    TEMMUZ_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_HS2.Value = @"";

                    TEMMUZ_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 47, 115, 52, false);
                    TEMMUZ_T2.Name = "TEMMUZ_T2";
                    TEMMUZ_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_T2.TextFormat = @"#,##0.#0";
                    TEMMUZ_T2.Value = @"";

                    TEMMUZ_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 47, 140, 52, false);
                    TEMMUZ_HS3.Name = "TEMMUZ_HS3";
                    TEMMUZ_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_HS3.Value = @"";

                    TEMMUZ_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 47, 159, 52, false);
                    TEMMUZ_T3.Name = "TEMMUZ_T3";
                    TEMMUZ_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_T3.TextFormat = @"#,##0.#0";
                    TEMMUZ_T3.Value = @"";

                    TEMMUZ_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 47, 184, 52, false);
                    TEMMUZ_HS4.Name = "TEMMUZ_HS4";
                    TEMMUZ_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_HS4.TextFormat = @"#,##0.#0";
                    TEMMUZ_HS4.Value = @"";

                    TEMMUZ_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 47, 203, 52, false);
                    TEMMUZ_T4.Name = "TEMMUZ_T4";
                    TEMMUZ_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMMUZ_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMMUZ_T4.TextFormat = @"#,##0.#0";
                    TEMMUZ_T4.Value = @"";

                    AGUSTOS_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 52, 52, 57, false);
                    AGUSTOS_HS1.Name = "AGUSTOS_HS1";
                    AGUSTOS_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_HS1.Value = @"";

                    AGUSTOS_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 52, 71, 57, false);
                    AGUSTOS_T1.Name = "AGUSTOS_T1";
                    AGUSTOS_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_T1.TextFormat = @"#,##0.#0";
                    AGUSTOS_T1.Value = @"";

                    AGUSTOS_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 52, 96, 57, false);
                    AGUSTOS_HS2.Name = "AGUSTOS_HS2";
                    AGUSTOS_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_HS2.Value = @"";

                    AGUSTOS_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 52, 115, 57, false);
                    AGUSTOS_T2.Name = "AGUSTOS_T2";
                    AGUSTOS_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_T2.TextFormat = @"#,##0.#0";
                    AGUSTOS_T2.Value = @"";

                    AGUSTOS_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 52, 140, 57, false);
                    AGUSTOS_HS3.Name = "AGUSTOS_HS3";
                    AGUSTOS_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_HS3.Value = @"";

                    AGUSTOS_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 52, 159, 57, false);
                    AGUSTOS_T3.Name = "AGUSTOS_T3";
                    AGUSTOS_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_T3.TextFormat = @"#,##0.#0";
                    AGUSTOS_T3.Value = @"";

                    AGUSTOS_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 52, 184, 57, false);
                    AGUSTOS_HS4.Name = "AGUSTOS_HS4";
                    AGUSTOS_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_HS4.TextFormat = @"#,##0.#0";
                    AGUSTOS_HS4.Value = @"";

                    AGUSTOS_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 52, 203, 57, false);
                    AGUSTOS_T4.Name = "AGUSTOS_T4";
                    AGUSTOS_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    AGUSTOS_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGUSTOS_T4.TextFormat = @"#,##0.#0";
                    AGUSTOS_T4.Value = @"";

                    EYLUL_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 57, 52, 62, false);
                    EYLUL_HS1.Name = "EYLUL_HS1";
                    EYLUL_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_HS1.Value = @"";

                    EYLUL_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 57, 71, 62, false);
                    EYLUL_T1.Name = "EYLUL_T1";
                    EYLUL_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_T1.TextFormat = @"#,##0.#0";
                    EYLUL_T1.Value = @"";

                    EYLUL_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 57, 96, 62, false);
                    EYLUL_HS2.Name = "EYLUL_HS2";
                    EYLUL_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_HS2.Value = @"";

                    EYLUL_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 57, 115, 62, false);
                    EYLUL_T2.Name = "EYLUL_T2";
                    EYLUL_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_T2.TextFormat = @"#,##0.#0";
                    EYLUL_T2.Value = @"";

                    EYLUL_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 57, 140, 62, false);
                    EYLUL_HS3.Name = "EYLUL_HS3";
                    EYLUL_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_HS3.Value = @"";

                    EYLUL_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 57, 159, 62, false);
                    EYLUL_T3.Name = "EYLUL_T3";
                    EYLUL_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_T3.TextFormat = @"#,##0.#0";
                    EYLUL_T3.Value = @"";

                    EYLUL_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 57, 184, 62, false);
                    EYLUL_HS4.Name = "EYLUL_HS4";
                    EYLUL_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_HS4.TextFormat = @"#,##0.#0";
                    EYLUL_HS4.Value = @"";

                    EYLUL_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 57, 203, 62, false);
                    EYLUL_T4.Name = "EYLUL_T4";
                    EYLUL_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    EYLUL_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYLUL_T4.TextFormat = @"#,##0.#0";
                    EYLUL_T4.Value = @"";

                    EKIM_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 62, 52, 67, false);
                    EKIM_HS1.Name = "EKIM_HS1";
                    EKIM_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_HS1.Value = @"";

                    EKIM_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 62, 71, 67, false);
                    EKIM_T1.Name = "EKIM_T1";
                    EKIM_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_T1.TextFormat = @"#,##0.#0";
                    EKIM_T1.Value = @"";

                    EKIM_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 62, 96, 67, false);
                    EKIM_HS2.Name = "EKIM_HS2";
                    EKIM_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_HS2.Value = @"";

                    EKIM_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 62, 115, 67, false);
                    EKIM_T2.Name = "EKIM_T2";
                    EKIM_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_T2.TextFormat = @"#,##0.#0";
                    EKIM_T2.Value = @"";

                    EKIM_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 62, 140, 67, false);
                    EKIM_HS3.Name = "EKIM_HS3";
                    EKIM_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_HS3.Value = @"";

                    EKIM_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 62, 159, 67, false);
                    EKIM_T3.Name = "EKIM_T3";
                    EKIM_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_T3.TextFormat = @"#,##0.#0";
                    EKIM_T3.Value = @"";

                    EKIM_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 62, 184, 67, false);
                    EKIM_HS4.Name = "EKIM_HS4";
                    EKIM_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_HS4.TextFormat = @"#,##0.#0";
                    EKIM_HS4.Value = @"";

                    EKIM_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 62, 203, 67, false);
                    EKIM_T4.Name = "EKIM_T4";
                    EKIM_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    EKIM_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EKIM_T4.TextFormat = @"#,##0.#0";
                    EKIM_T4.Value = @"";

                    KASIM_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 67, 52, 72, false);
                    KASIM_HS1.Name = "KASIM_HS1";
                    KASIM_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_HS1.Value = @"";

                    KASIM_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 67, 71, 72, false);
                    KASIM_T1.Name = "KASIM_T1";
                    KASIM_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_T1.TextFormat = @"#,##0.#0";
                    KASIM_T1.Value = @"";

                    KASIM_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 67, 96, 72, false);
                    KASIM_HS2.Name = "KASIM_HS2";
                    KASIM_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_HS2.Value = @"";

                    KASIM_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 67, 115, 72, false);
                    KASIM_T2.Name = "KASIM_T2";
                    KASIM_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_T2.TextFormat = @"#,##0.#0";
                    KASIM_T2.Value = @"";

                    KASIM_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 67, 140, 72, false);
                    KASIM_HS3.Name = "KASIM_HS3";
                    KASIM_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_HS3.Value = @"";

                    KASIM_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 67, 159, 72, false);
                    KASIM_T3.Name = "KASIM_T3";
                    KASIM_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_T3.TextFormat = @"#,##0.#0";
                    KASIM_T3.Value = @"";

                    KASIM_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 67, 184, 72, false);
                    KASIM_HS4.Name = "KASIM_HS4";
                    KASIM_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_HS4.TextFormat = @"#,##0.#0";
                    KASIM_HS4.Value = @"";

                    KASIM_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 67, 203, 72, false);
                    KASIM_T4.Name = "KASIM_T4";
                    KASIM_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    KASIM_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    KASIM_T4.TextFormat = @"#,##0.#0";
                    KASIM_T4.Value = @"";

                    ARALIK_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 72, 52, 77, false);
                    ARALIK_HS1.Name = "ARALIK_HS1";
                    ARALIK_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_HS1.Value = @"";

                    ARALIK_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 72, 71, 77, false);
                    ARALIK_T1.Name = "ARALIK_T1";
                    ARALIK_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_T1.TextFormat = @"#,##0.#0";
                    ARALIK_T1.Value = @"";

                    ARALIK_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 72, 96, 77, false);
                    ARALIK_HS2.Name = "ARALIK_HS2";
                    ARALIK_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_HS2.Value = @"";

                    ARALIK_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 72, 115, 77, false);
                    ARALIK_T2.Name = "ARALIK_T2";
                    ARALIK_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_T2.TextFormat = @"#,##0.#0";
                    ARALIK_T2.Value = @"";

                    ARALIK_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 72, 140, 77, false);
                    ARALIK_HS3.Name = "ARALIK_HS3";
                    ARALIK_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_HS3.Value = @"";

                    ARALIK_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 72, 159, 77, false);
                    ARALIK_T3.Name = "ARALIK_T3";
                    ARALIK_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_T3.TextFormat = @"#,##0.#0";
                    ARALIK_T3.Value = @"";

                    ARALIK_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 72, 184, 77, false);
                    ARALIK_HS4.Name = "ARALIK_HS4";
                    ARALIK_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_HS4.TextFormat = @"#,##0.#0";
                    ARALIK_HS4.Value = @"";

                    ARALIK_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 72, 203, 77, false);
                    ARALIK_T4.Name = "ARALIK_T4";
                    ARALIK_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    ARALIK_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARALIK_T4.TextFormat = @"#,##0.#0";
                    ARALIK_T4.Value = @"";

                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 77, 27, 82, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112121.TextFont.Name = "Arial";
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @"TOPLAM";

                    T_HS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 77, 52, 82, false);
                    T_HS1.Name = "T_HS1";
                    T_HS1.DrawStyle = DrawStyleConstants.vbSolid;
                    T_HS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_HS1.Value = @"";

                    T_T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 77, 71, 82, false);
                    T_T1.Name = "T_T1";
                    T_T1.DrawStyle = DrawStyleConstants.vbSolid;
                    T_T1.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_T1.TextFormat = @"#,##0.#0";
                    T_T1.Value = @"";

                    T_HS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 77, 96, 82, false);
                    T_HS2.Name = "T_HS2";
                    T_HS2.DrawStyle = DrawStyleConstants.vbSolid;
                    T_HS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_HS2.Value = @"";

                    T_T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 77, 115, 82, false);
                    T_T2.Name = "T_T2";
                    T_T2.DrawStyle = DrawStyleConstants.vbSolid;
                    T_T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_T2.TextFormat = @"#,##0.#0";
                    T_T2.Value = @"";

                    T_HS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 77, 140, 82, false);
                    T_HS3.Name = "T_HS3";
                    T_HS3.DrawStyle = DrawStyleConstants.vbSolid;
                    T_HS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_HS3.Value = @"";

                    T_T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 77, 159, 82, false);
                    T_T3.Name = "T_T3";
                    T_T3.DrawStyle = DrawStyleConstants.vbSolid;
                    T_T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_T3.TextFormat = @"#,##0.#0";
                    T_T3.Value = @"";

                    T_HS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 77, 184, 82, false);
                    T_HS4.Name = "T_HS4";
                    T_HS4.DrawStyle = DrawStyleConstants.vbSolid;
                    T_HS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_HS4.Value = @"";

                    T_T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 77, 203, 82, false);
                    T_T4.Name = "T_T4";
                    T_T4.DrawStyle = DrawStyleConstants.vbSolid;
                    T_T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    T_T4.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 86, 203, 97, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.NoClip = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField2.Value = @"      Toplam Fatura Tutar bilgisi XXXXXX'da bulunan fiyatlar üzerinden hesaplanmıştır. Fatura Edilen Tutar bilgisi ise MEDULA'dan gelen fiyatlar üzerinden hesaplanmıştır. Fatura Edilmeyen ve Fatura Kaybı(%) bilgileri Toplam Fatura ve Fatura Edilen Takip Sayısı ve Tutar bilgileri baz alınarak hesaplanmıştır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField11131.CalcValue = NewField11131.Value;
                    NewField11132.CalcValue = NewField11132.Value;
                    NewField113111.CalcValue = NewField113111.Value;
                    NewField11133.CalcValue = NewField11133.Value;
                    NewField113112.CalcValue = NewField113112.Value;
                    NewField11134.CalcValue = NewField11134.Value;
                    NewField113113.CalcValue = NewField113113.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    OCAK_HS1.CalcValue = @"";
                    OCAK_T1.CalcValue = @"";
                    OCAK_HS2.CalcValue = @"";
                    OCAK_T2.CalcValue = @"";
                    OCAK_HS3.CalcValue = @"";
                    OCAK_T3.CalcValue = @"";
                    OCAK_HS4.CalcValue = @"";
                    OCAK_T4.CalcValue = @"";
                    SUBAT_HS1.CalcValue = @"";
                    SUBAT_T1.CalcValue = @"";
                    SUBAT_HS2.CalcValue = @"";
                    SUBAT_T2.CalcValue = @"";
                    SUBAT_HS3.CalcValue = @"";
                    SUBAT_T3.CalcValue = @"";
                    SUBAT_HS4.CalcValue = @"";
                    SUBAT_T4.CalcValue = @"";
                    MART_HS1.CalcValue = @"";
                    MART_T1.CalcValue = @"";
                    MART_HS2.CalcValue = @"";
                    MART_T2.CalcValue = @"";
                    MART_HS3.CalcValue = @"";
                    MART_T3.CalcValue = @"";
                    MART_HS4.CalcValue = @"";
                    MART_T4.CalcValue = @"";
                    NISAN_HS1.CalcValue = @"";
                    NISAN_T1.CalcValue = @"";
                    NISAN_HS2.CalcValue = @"";
                    NISAN_T2.CalcValue = @"";
                    NISAN_HS3.CalcValue = @"";
                    NISAN_T3.CalcValue = @"";
                    NISAN_HS4.CalcValue = @"";
                    NISAN_T4.CalcValue = @"";
                    MAYIS_HS1.CalcValue = @"";
                    MAYIS_T1.CalcValue = @"";
                    MAYIS_HS2.CalcValue = @"";
                    MAYIS_T2.CalcValue = @"";
                    MAYIS_HS3.CalcValue = @"";
                    MAYIS_T3.CalcValue = @"";
                    MAYIS_HS4.CalcValue = @"";
                    MAYIS_T4.CalcValue = @"";
                    HAZIRAN_HS1.CalcValue = @"";
                    HAZIRAN_T1.CalcValue = @"";
                    HAZIRAN_HS2.CalcValue = @"";
                    HAZIRAN_T2.CalcValue = @"";
                    HAZIRAN_HS3.CalcValue = @"";
                    HAZIRAN_T3.CalcValue = @"";
                    HAZIRAN_HS4.CalcValue = @"";
                    HAZIRAN_T4.CalcValue = @"";
                    TEMMUZ_HS1.CalcValue = @"";
                    TEMMUZ_T1.CalcValue = @"";
                    TEMMUZ_HS2.CalcValue = @"";
                    TEMMUZ_T2.CalcValue = @"";
                    TEMMUZ_HS3.CalcValue = @"";
                    TEMMUZ_T3.CalcValue = @"";
                    TEMMUZ_HS4.CalcValue = @"";
                    TEMMUZ_T4.CalcValue = @"";
                    AGUSTOS_HS1.CalcValue = @"";
                    AGUSTOS_T1.CalcValue = @"";
                    AGUSTOS_HS2.CalcValue = @"";
                    AGUSTOS_T2.CalcValue = @"";
                    AGUSTOS_HS3.CalcValue = @"";
                    AGUSTOS_T3.CalcValue = @"";
                    AGUSTOS_HS4.CalcValue = @"";
                    AGUSTOS_T4.CalcValue = @"";
                    EYLUL_HS1.CalcValue = @"";
                    EYLUL_T1.CalcValue = @"";
                    EYLUL_HS2.CalcValue = @"";
                    EYLUL_T2.CalcValue = @"";
                    EYLUL_HS3.CalcValue = @"";
                    EYLUL_T3.CalcValue = @"";
                    EYLUL_HS4.CalcValue = @"";
                    EYLUL_T4.CalcValue = @"";
                    EKIM_HS1.CalcValue = @"";
                    EKIM_T1.CalcValue = @"";
                    EKIM_HS2.CalcValue = @"";
                    EKIM_T2.CalcValue = @"";
                    EKIM_HS3.CalcValue = @"";
                    EKIM_T3.CalcValue = @"";
                    EKIM_HS4.CalcValue = @"";
                    EKIM_T4.CalcValue = @"";
                    KASIM_HS1.CalcValue = @"";
                    KASIM_T1.CalcValue = @"";
                    KASIM_HS2.CalcValue = @"";
                    KASIM_T2.CalcValue = @"";
                    KASIM_HS3.CalcValue = @"";
                    KASIM_T3.CalcValue = @"";
                    KASIM_HS4.CalcValue = @"";
                    KASIM_T4.CalcValue = @"";
                    ARALIK_HS1.CalcValue = @"";
                    ARALIK_T1.CalcValue = @"";
                    ARALIK_HS2.CalcValue = @"";
                    ARALIK_T2.CalcValue = @"";
                    ARALIK_HS3.CalcValue = @"";
                    ARALIK_T3.CalcValue = @"";
                    ARALIK_HS4.CalcValue = @"";
                    ARALIK_T4.CalcValue = @"";
                    NewField1112121.CalcValue = NewField1112121.Value;
                    T_HS1.CalcValue = @"";
                    T_T1.CalcValue = @"";
                    T_HS2.CalcValue = @"";
                    T_T2.CalcValue = @"";
                    T_HS3.CalcValue = @"";
                    T_T3.CalcValue = @"";
                    T_HS4.CalcValue = @"";
                    T_T4.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { NewField11,NewField111,NewField112,NewField113,NewField1,NewField1311,NewField11131,NewField11132,NewField113111,NewField11133,NewField113112,NewField11134,NewField113113,NewField12,NewField13,NewField121,NewField14,NewField122,NewField131,NewField1121,NewField11211,NewField141,NewField1221,NewField1131,OCAK_HS1,OCAK_T1,OCAK_HS2,OCAK_T2,OCAK_HS3,OCAK_T3,OCAK_HS4,OCAK_T4,SUBAT_HS1,SUBAT_T1,SUBAT_HS2,SUBAT_T2,SUBAT_HS3,SUBAT_T3,SUBAT_HS4,SUBAT_T4,MART_HS1,MART_T1,MART_HS2,MART_T2,MART_HS3,MART_T3,MART_HS4,MART_T4,NISAN_HS1,NISAN_T1,NISAN_HS2,NISAN_T2,NISAN_HS3,NISAN_T3,NISAN_HS4,NISAN_T4,MAYIS_HS1,MAYIS_T1,MAYIS_HS2,MAYIS_T2,MAYIS_HS3,MAYIS_T3,MAYIS_HS4,MAYIS_T4,HAZIRAN_HS1,HAZIRAN_T1,HAZIRAN_HS2,HAZIRAN_T2,HAZIRAN_HS3,HAZIRAN_T3,HAZIRAN_HS4,HAZIRAN_T4,TEMMUZ_HS1,TEMMUZ_T1,TEMMUZ_HS2,TEMMUZ_T2,TEMMUZ_HS3,TEMMUZ_T3,TEMMUZ_HS4,TEMMUZ_T4,AGUSTOS_HS1,AGUSTOS_T1,AGUSTOS_HS2,AGUSTOS_T2,AGUSTOS_HS3,AGUSTOS_T3,AGUSTOS_HS4,AGUSTOS_T4,EYLUL_HS1,EYLUL_T1,EYLUL_HS2,EYLUL_T2,EYLUL_HS3,EYLUL_T3,EYLUL_HS4,EYLUL_T4,EKIM_HS1,EKIM_T1,EKIM_HS2,EKIM_T2,EKIM_HS3,EKIM_T3,EKIM_HS4,EKIM_T4,KASIM_HS1,KASIM_T1,KASIM_HS2,KASIM_T2,KASIM_HS3,KASIM_T3,KASIM_HS4,KASIM_T4,ARALIK_HS1,ARALIK_T1,ARALIK_HS2,ARALIK_T2,ARALIK_HS3,ARALIK_T3,ARALIK_HS4,ARALIK_T4,NewField1112121,T_HS1,T_T1,T_HS2,T_T2,T_HS3,T_T3,T_HS4,T_T4,NewField2};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    List<String> Durum = new List<string>();
            Durum.Add("HS");
            Durum.Add("T");
            int toplamHS1 = 0;
            int toplamHS2 = 0;
            int toplamHS3 = 0;
            double toplamT1 = 0;
            double toplamT2 = 0;
            double toplamT3 = 0;
            foreach (Aylar ay in ((GeneralInvoiceStatistic)ParentReport).ayList)
            {
                foreach (string durum in Durum)
                {
                    for (int i = 1; i <= 4; i++)
                    {

                        TTReportField rf = FieldsByName(ay.isim +"_"+ durum + i.ToString());
                        
                        if (durum == "HS")
                        {
                            if (i == 1)
                            {
                                rf.CalcValue = Convert.ToString(ay.toplamFatura.hastaSayisi);
                                toplamHS1 += ay.toplamFatura.hastaSayisi;
                            }
                            else if(i==2)
                            {
                                rf.CalcValue = Convert.ToString(ay.faturaEdilen.hastaSayisi);
                                toplamHS2 += ay.faturaEdilen.hastaSayisi;
                            }
                            else if (i==3)
                            {
                                TTReportField rfToplam = FieldsByName(ay.isim + "_" + durum + "1");
                                TTReportField rfFaturalanan = FieldsByName(ay.isim + "_" + durum + "2");
                                rf.CalcValue = Convert.ToString(Convert.ToInt32(rfToplam.CalcValue) - Convert.ToInt32(rfFaturalanan.CalcValue));
                                toplamHS3 += Convert.ToInt32(rf.CalcValue);
                            }
                            else if (i == 4)
                            {
                                TTReportField rfToplam = FieldsByName(ay.isim + "_" + durum + "1");
                                TTReportField rfFaturalanmayan = FieldsByName(ay.isim + "_" + durum + "3");
                                if(Convert.ToDouble(rfToplam.CalcValue) != 0)
                                    rf.CalcValue = Convert.ToString((Convert.ToDouble(rfFaturalanmayan.CalcValue)/Convert.ToDouble(rfToplam.CalcValue))*100);
                                else
                                    rf.CalcValue = "0";
                            }
                        }
                        if (durum == "T")
                        {
                            if (i == 1)
                            {
                                rf.CalcValue = Convert.ToString(ay.toplamFatura.tutar);
                                toplamT1 += ay.toplamFatura.tutar;
                            }
                            else if (i == 2)
                            {
                                rf.CalcValue = Convert.ToString(ay.faturaEdilen.tutar);
                                toplamT2 += ay.faturaEdilen.tutar;
                            }
                            else if (i == 3)
                            {
                                TTReportField rfToplam = FieldsByName(ay.isim +"_"+ durum + "1");
                                TTReportField rfFaturalanan = FieldsByName(ay.isim + "_" + durum + "2");
                                rf.CalcValue = Convert.ToString(Convert.ToDouble(rfToplam.CalcValue) - Convert.ToDouble(rfFaturalanan.CalcValue));
                                toplamT3 += Convert.ToDouble(rf.CalcValue);
                            }
                            else if (i == 4)
                            {
                                TTReportField rfToplam = FieldsByName(ay.isim + "_" + durum + "1");
                                TTReportField rfFaturalanmayan = FieldsByName(ay.isim + "_" + durum + "3");
                                if(Convert.ToDouble(rfToplam.CalcValue) != 0)
                                    rf.CalcValue = Convert.ToString((Convert.ToDouble(rfFaturalanmayan.CalcValue) / Convert.ToDouble(rfToplam.CalcValue)) * 100);
                                else
                                    rf.CalcValue = "0";
                            }
                        }

                    }
                }
            }
            this.T_HS1.CalcValue = toplamHS1.ToString();
            this.T_HS2.CalcValue = toplamHS2.ToString();
            this.T_HS3.CalcValue = toplamHS3.ToString();
            this.T_T1.CalcValue = toplamT1.ToString();
            this.T_T2.CalcValue = toplamT2.ToString();
            this.T_T3.CalcValue = toplamT3.ToString();
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

        public GeneralInvoiceStatistic()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTD = new PARTDGroup(PARTB,"PARTD");
            PRATA = new PRATAGroup(PARTB,"PRATA");
            MAIN = new MAINGroup(PRATA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("YEAR", "", "Yıl Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["YEAR"]);
            Name = "GENERALINVOICESTATISTIC";
            Caption = "Genel Fatura İstatistiği";
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