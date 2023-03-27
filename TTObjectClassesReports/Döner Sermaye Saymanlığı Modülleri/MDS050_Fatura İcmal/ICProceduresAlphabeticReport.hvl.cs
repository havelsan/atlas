
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
    public partial class ICProceduresAlphabeticReport : TTReport
    {
#region Methods
   int PageNumber = 1;
        bool IsLastPage;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ICProceduresAlphabeticReport MyParentReport
            {
                get { return (ICProceduresAlphabeticReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PIDOBJECTID { get {return Header().PIDOBJECTID;} }
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
                list[0] = new TTReportNqlData<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class>("ICProceduresAlphabeticReportQuery", InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ICProceduresAlphabeticReport MyParentReport
                {
                    get { return (ICProceduresAlphabeticReport)ParentReport; }
                }
                
                public TTReportField PIDOBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PIDOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 247, 6, false);
                    PIDOBJECTID.Name = "PIDOBJECTID";
                    PIDOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PIDOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PIDOBJECTID.TextFont.Name = "Arial Narrow";
                    PIDOBJECTID.Value = @"{#PIDOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class dataset_ICProceduresAlphabeticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class>(0);
                    PIDOBJECTID.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Pidobjectid) : "");
                    return new TTReportObject[] { PIDOBJECTID};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    MyParentReport.PageNumber = 1;
            MyParentReport.IsLastPage = false;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ICProceduresAlphabeticReport MyParentReport
                {
                    get { return (ICProceduresAlphabeticReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADGroup : TTReportGroup
        {
            public ICProceduresAlphabeticReport MyParentReport
            {
                get { return (ICProceduresAlphabeticReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField FATURATARIHI { get {return Header().FATURATARIHI;} }
            public TTReportField FATURANO { get {return Header().FATURANO;} }
            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField LBL { get {return Header().LBL;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField ADSOYADLBL { get {return Header().ADSOYADLBL;} }
            public TTReportField TCKIMLIKNOLBL { get {return Header().TCKIMLIKNOLBL;} }
            public TTReportField TANILBL { get {return Header().TANILBL;} }
            public TTReportField ADRESTELLBL { get {return Header().ADRESTELLBL;} }
            public TTReportField ISLEMNOLBL { get {return Header().ISLEMNOLBL;} }
            public TTReportField DOKTORLBL { get {return Header().DOKTORLBL;} }
            public TTReportField KURUMLBL { get {return Header().KURUMLBL;} }
            public TTReportField KARNENOLBL { get {return Header().KARNENOLBL;} }
            public TTReportField SICILNOLBL { get {return Header().SICILNOLBL;} }
            public TTReportField MURACAATTARIHLBL { get {return Header().MURACAATTARIHLBL;} }
            public TTReportField DTARIHLBL { get {return Header().DTARIHLBL;} }
            public TTReportField FATURANOLBL { get {return Header().FATURANOLBL;} }
            public TTReportField DOKTORLBL1 { get {return Header().DOKTORLBL1;} }
            public TTReportField PROTOKOLNOLBL { get {return Header().PROTOKOLNOLBL;} }
            public TTReportField PROVIZYONNOLBL { get {return Header().PROVIZYONNOLBL;} }
            public TTReportField FATURATARIHILBL { get {return Header().FATURATARIHILBL;} }
            public TTReportField LBL1 { get {return Header().LBL1;} }
            public TTReportField LBL11 { get {return Header().LBL11;} }
            public TTReportField LBL12 { get {return Header().LBL12;} }
            public TTReportField LBL13 { get {return Header().LBL13;} }
            public TTReportField LBL14 { get {return Header().LBL14;} }
            public TTReportField LBL15 { get {return Header().LBL15;} }
            public TTReportField LBL16 { get {return Header().LBL16;} }
            public TTReportField LBL111 { get {return Header().LBL111;} }
            public TTReportField LBL112 { get {return Header().LBL112;} }
            public TTReportField LBL17 { get {return Header().LBL17;} }
            public TTReportField LBL113 { get {return Header().LBL113;} }
            public TTReportField LBL121 { get {return Header().LBL121;} }
            public TTReportField LBL131 { get {return Header().LBL131;} }
            public TTReportField LBL141 { get {return Header().LBL141;} }
            public TTReportField LBL151 { get {return Header().LBL151;} }
            public TTReportField LBL161 { get {return Header().LBL161;} }
            public TTReportField DOKTOR { get {return Header().DOKTOR;} }
            public TTReportField ADRESTEL { get {return Header().ADRESTEL;} }
            public TTReportField ISLEMNO { get {return Header().ISLEMNO;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField KARNENO { get {return Header().KARNENO;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField MURACAATTARIHI { get {return Header().MURACAATTARIHI;} }
            public TTReportField DOGUMTARIHIYASI { get {return Header().DOGUMTARIHIYASI;} }
            public TTReportField PROVIZYONNO { get {return Header().PROVIZYONNO;} }
            public TTReportField GSSTAKIPNO { get {return Header().GSSTAKIPNO;} }
            public TTReportField SIRANOLBL { get {return Header().SIRANOLBL;} }
            public TTReportField TARIHLBL { get {return Header().TARIHLBL;} }
            public TTReportField ISLEMLBL { get {return Header().ISLEMLBL;} }
            public TTReportField MIKTARLBL { get {return Header().MIKTARLBL;} }
            public TTReportField BIRIMFIYATLBL { get {return Header().BIRIMFIYATLBL;} }
            public TTReportField TUTARLBL { get {return Header().TUTARLBL;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField PIDOBJECTID { get {return Header().PIDOBJECTID;} }
            public TTReportField HOMEADDRESS { get {return Header().HOMEADDRESS;} }
            public TTReportField HOMETOWN { get {return Header().HOMETOWN;} }
            public TTReportField HOMECITY { get {return Header().HOMECITY;} }
            public TTReportField HOMEPHONE { get {return Header().HOMEPHONE;} }
            public TTReportField MOBILEPHONE { get {return Header().MOBILEPHONE;} }
            public TTReportField BUSINESSPHONE { get {return Header().BUSINESSPHONE;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField TOPLAMLBL { get {return Footer().TOPLAMLBL;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public ICProceduresAlphabeticReport MyParentReport
                {
                    get { return (ICProceduresAlphabeticReport)ParentReport; }
                }
                
                public TTReportField KURUM;
                public TTReportField ADSOYAD;
                public TTReportField PROTOKOLNO;
                public TTReportField FATURATARIHI;
                public TTReportField FATURANO;
                public TTReportField TANI;
                public TTReportField PAGENO;
                public TTReportField LBL;
                public TTReportShape NewLine1;
                public TTReportField ADSOYADLBL;
                public TTReportField TCKIMLIKNOLBL;
                public TTReportField TANILBL;
                public TTReportField ADRESTELLBL;
                public TTReportField ISLEMNOLBL;
                public TTReportField DOKTORLBL;
                public TTReportField KURUMLBL;
                public TTReportField KARNENOLBL;
                public TTReportField SICILNOLBL;
                public TTReportField MURACAATTARIHLBL;
                public TTReportField DTARIHLBL;
                public TTReportField FATURANOLBL;
                public TTReportField DOKTORLBL1;
                public TTReportField PROTOKOLNOLBL;
                public TTReportField PROVIZYONNOLBL;
                public TTReportField FATURATARIHILBL;
                public TTReportField LBL1;
                public TTReportField LBL11;
                public TTReportField LBL12;
                public TTReportField LBL13;
                public TTReportField LBL14;
                public TTReportField LBL15;
                public TTReportField LBL16;
                public TTReportField LBL111;
                public TTReportField LBL112;
                public TTReportField LBL17;
                public TTReportField LBL113;
                public TTReportField LBL121;
                public TTReportField LBL131;
                public TTReportField LBL141;
                public TTReportField LBL151;
                public TTReportField LBL161;
                public TTReportField DOKTOR;
                public TTReportField ADRESTEL;
                public TTReportField ISLEMNO;
                public TTReportField SICILNO;
                public TTReportField KARNENO;
                public TTReportField TCKIMLIKNO;
                public TTReportField MURACAATTARIHI;
                public TTReportField DOGUMTARIHIYASI;
                public TTReportField PROVIZYONNO;
                public TTReportField GSSTAKIPNO;
                public TTReportField SIRANOLBL;
                public TTReportField TARIHLBL;
                public TTReportField ISLEMLBL;
                public TTReportField MIKTARLBL;
                public TTReportField BIRIMFIYATLBL;
                public TTReportField TUTARLBL;
                public TTReportShape NewLine11;
                public TTReportField EPISODEOBJECTID;
                public TTReportField PIDOBJECTID;
                public TTReportField HOMEADDRESS;
                public TTReportField HOMETOWN;
                public TTReportField HOMECITY;
                public TTReportField HOMEPHONE;
                public TTReportField MOBILEPHONE;
                public TTReportField BUSINESSPHONE; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 72;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 40, 128, 45, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Name = "Arial Narrow";
                    KURUM.TextFont.Size = 8;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"{#PARTA.PAYERCODE#} {#PARTA.PAYERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 15, 100, 20, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADSOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    ADSOYAD.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    ADSOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 8;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#PARTA.PATIENTNAME#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 40, 202, 45, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 8;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PARTA.EPISODEID#}";

                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 30, 202, 35, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI.TextFormat = @"dd/MM/yyyy";
                    FATURATARIHI.TextFont.Name = "Arial Narrow";
                    FATURATARIHI.TextFont.Size = 8;
                    FATURATARIHI.TextFont.CharSet = 162;
                    FATURATARIHI.Value = @"{#PARTA.INVOICEDATE#}";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 25, 202, 30, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.Name = "Arial Narrow";
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{#PARTA.INVOICENO#}";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 55, 202, 63, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 8;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 7, 202, 12, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENO.TextFont.Name = "Arial Narrow";
                    PAGENO.TextFont.Size = 8;
                    PAGENO.TextFont.CharSet = 162;
                    PAGENO.Value = @"";

                    LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 7, 146, 12, false);
                    LBL.Name = "LBL";
                    LBL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBL.TextFont.Name = "Arial Narrow";
                    LBL.TextFont.Size = 11;
                    LBL.TextFont.Bold = true;
                    LBL.TextFont.CharSet = 162;
                    LBL.Value = @"AÇIKLAMALI HİZMET DETAY BELGESİ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 13, 202, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    ADSOYADLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 15, 33, 20, false);
                    ADSOYADLBL.Name = "ADSOYADLBL";
                    ADSOYADLBL.TextFont.Name = "Arial Narrow";
                    ADSOYADLBL.TextFont.Size = 8;
                    ADSOYADLBL.TextFont.Bold = true;
                    ADSOYADLBL.TextFont.CharSet = 162;
                    ADSOYADLBL.Value = @"ADI SOYADI";

                    TCKIMLIKNOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 20, 33, 25, false);
                    TCKIMLIKNOLBL.Name = "TCKIMLIKNOLBL";
                    TCKIMLIKNOLBL.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNOLBL.TextFont.Size = 8;
                    TCKIMLIKNOLBL.TextFont.Bold = true;
                    TCKIMLIKNOLBL.TextFont.CharSet = 162;
                    TCKIMLIKNOLBL.Value = @"TC KİMLİK NO";

                    TANILBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 55, 33, 60, false);
                    TANILBL.Name = "TANILBL";
                    TANILBL.TextFont.Name = "Arial Narrow";
                    TANILBL.TextFont.Size = 8;
                    TANILBL.TextFont.Bold = true;
                    TANILBL.TextFont.CharSet = 162;
                    TANILBL.Value = @"TANILAR";

                    ADRESTELLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 50, 33, 55, false);
                    ADRESTELLBL.Name = "ADRESTELLBL";
                    ADRESTELLBL.TextFont.Name = "Arial Narrow";
                    ADRESTELLBL.TextFont.Size = 8;
                    ADRESTELLBL.TextFont.Bold = true;
                    ADRESTELLBL.TextFont.CharSet = 162;
                    ADRESTELLBL.Value = @"ADRES / TELF.";

                    ISLEMNOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 25, 33, 30, false);
                    ISLEMNOLBL.Name = "ISLEMNOLBL";
                    ISLEMNOLBL.TextFont.Name = "Arial Narrow";
                    ISLEMNOLBL.TextFont.Size = 8;
                    ISLEMNOLBL.TextFont.Bold = true;
                    ISLEMNOLBL.TextFont.CharSet = 162;
                    ISLEMNOLBL.Value = @"İŞLEM NO";

                    DOKTORLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 45, 33, 50, false);
                    DOKTORLBL.Name = "DOKTORLBL";
                    DOKTORLBL.TextFont.Name = "Arial Narrow";
                    DOKTORLBL.TextFont.Size = 8;
                    DOKTORLBL.TextFont.Bold = true;
                    DOKTORLBL.TextFont.CharSet = 162;
                    DOKTORLBL.Value = @"DOKTOR";

                    KURUMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 40, 33, 45, false);
                    KURUMLBL.Name = "KURUMLBL";
                    KURUMLBL.TextFont.Name = "Arial Narrow";
                    KURUMLBL.TextFont.Size = 8;
                    KURUMLBL.TextFont.Bold = true;
                    KURUMLBL.TextFont.CharSet = 162;
                    KURUMLBL.Value = @"DEVR. KURUMU";

                    KARNENOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 35, 33, 40, false);
                    KARNENOLBL.Name = "KARNENOLBL";
                    KARNENOLBL.TextFont.Name = "Arial Narrow";
                    KARNENOLBL.TextFont.Size = 8;
                    KARNENOLBL.TextFont.Bold = true;
                    KARNENOLBL.TextFont.CharSet = 162;
                    KARNENOLBL.Value = @"KARNE NO";

                    SICILNOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 30, 33, 35, false);
                    SICILNOLBL.Name = "SICILNOLBL";
                    SICILNOLBL.TextFont.Name = "Arial Narrow";
                    SICILNOLBL.TextFont.Size = 8;
                    SICILNOLBL.TextFont.Bold = true;
                    SICILNOLBL.TextFont.CharSet = 162;
                    SICILNOLBL.Value = @"SİCİL NO";

                    MURACAATTARIHLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 15, 152, 20, false);
                    MURACAATTARIHLBL.Name = "MURACAATTARIHLBL";
                    MURACAATTARIHLBL.TextFont.Name = "Arial Narrow";
                    MURACAATTARIHLBL.TextFont.Size = 8;
                    MURACAATTARIHLBL.TextFont.Bold = true;
                    MURACAATTARIHLBL.TextFont.CharSet = 162;
                    MURACAATTARIHLBL.Value = @"MÜRACAAT T.";

                    DTARIHLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 20, 152, 25, false);
                    DTARIHLBL.Name = "DTARIHLBL";
                    DTARIHLBL.TextFont.Name = "Arial Narrow";
                    DTARIHLBL.TextFont.Size = 8;
                    DTARIHLBL.TextFont.Bold = true;
                    DTARIHLBL.TextFont.CharSet = 162;
                    DTARIHLBL.Value = @"D.TARİHİ / YAŞI";

                    FATURANOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 25, 152, 30, false);
                    FATURANOLBL.Name = "FATURANOLBL";
                    FATURANOLBL.TextFont.Name = "Arial Narrow";
                    FATURANOLBL.TextFont.Size = 8;
                    FATURANOLBL.TextFont.Bold = true;
                    FATURANOLBL.TextFont.CharSet = 162;
                    FATURANOLBL.Value = @"FATURA NO";

                    DOKTORLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 45, 152, 50, false);
                    DOKTORLBL1.Name = "DOKTORLBL1";
                    DOKTORLBL1.TextFont.Name = "Arial Narrow";
                    DOKTORLBL1.TextFont.Size = 8;
                    DOKTORLBL1.TextFont.Bold = true;
                    DOKTORLBL1.TextFont.CharSet = 162;
                    DOKTORLBL1.Value = @"GSS TAKİP NO";

                    PROTOKOLNOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 40, 152, 45, false);
                    PROTOKOLNOLBL.Name = "PROTOKOLNOLBL";
                    PROTOKOLNOLBL.TextFont.Name = "Arial Narrow";
                    PROTOKOLNOLBL.TextFont.Size = 8;
                    PROTOKOLNOLBL.TextFont.Bold = true;
                    PROTOKOLNOLBL.TextFont.CharSet = 162;
                    PROTOKOLNOLBL.Value = @"PROTOKOL NO";

                    PROVIZYONNOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 35, 152, 40, false);
                    PROVIZYONNOLBL.Name = "PROVIZYONNOLBL";
                    PROVIZYONNOLBL.TextFont.Name = "Arial Narrow";
                    PROVIZYONNOLBL.TextFont.Size = 8;
                    PROVIZYONNOLBL.TextFont.Bold = true;
                    PROVIZYONNOLBL.TextFont.CharSet = 162;
                    PROVIZYONNOLBL.Value = @"PROVİZYON NO";

                    FATURATARIHILBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 30, 152, 35, false);
                    FATURATARIHILBL.Name = "FATURATARIHILBL";
                    FATURATARIHILBL.TextFont.Name = "Arial Narrow";
                    FATURATARIHILBL.TextFont.Size = 8;
                    FATURATARIHILBL.TextFont.Bold = true;
                    FATURATARIHILBL.TextFont.CharSet = 162;
                    FATURATARIHILBL.Value = @"FATURA TARİHİ";

                    LBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 15, 35, 20, false);
                    LBL1.Name = "LBL1";
                    LBL1.TextFont.Name = "Arial Narrow";
                    LBL1.TextFont.Size = 8;
                    LBL1.TextFont.Bold = true;
                    LBL1.TextFont.CharSet = 162;
                    LBL1.Value = @":";

                    LBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 45, 35, 50, false);
                    LBL11.Name = "LBL11";
                    LBL11.TextFont.Name = "Arial Narrow";
                    LBL11.TextFont.Size = 8;
                    LBL11.TextFont.Bold = true;
                    LBL11.TextFont.CharSet = 162;
                    LBL11.Value = @":";

                    LBL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 40, 35, 45, false);
                    LBL12.Name = "LBL12";
                    LBL12.TextFont.Name = "Arial Narrow";
                    LBL12.TextFont.Size = 8;
                    LBL12.TextFont.Bold = true;
                    LBL12.TextFont.CharSet = 162;
                    LBL12.Value = @":";

                    LBL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 30, 35, 35, false);
                    LBL13.Name = "LBL13";
                    LBL13.TextFont.Name = "Arial Narrow";
                    LBL13.TextFont.Size = 8;
                    LBL13.TextFont.Bold = true;
                    LBL13.TextFont.CharSet = 162;
                    LBL13.Value = @":";

                    LBL14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 35, 35, 40, false);
                    LBL14.Name = "LBL14";
                    LBL14.TextFont.Name = "Arial Narrow";
                    LBL14.TextFont.Size = 8;
                    LBL14.TextFont.Bold = true;
                    LBL14.TextFont.CharSet = 162;
                    LBL14.Value = @":";

                    LBL15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 25, 35, 30, false);
                    LBL15.Name = "LBL15";
                    LBL15.TextFont.Name = "Arial Narrow";
                    LBL15.TextFont.Size = 8;
                    LBL15.TextFont.Bold = true;
                    LBL15.TextFont.CharSet = 162;
                    LBL15.Value = @":";

                    LBL16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 20, 35, 25, false);
                    LBL16.Name = "LBL16";
                    LBL16.TextFont.Name = "Arial Narrow";
                    LBL16.TextFont.Size = 8;
                    LBL16.TextFont.Bold = true;
                    LBL16.TextFont.CharSet = 162;
                    LBL16.Value = @":";

                    LBL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 50, 35, 55, false);
                    LBL111.Name = "LBL111";
                    LBL111.TextFont.Name = "Arial Narrow";
                    LBL111.TextFont.Size = 8;
                    LBL111.TextFont.Bold = true;
                    LBL111.TextFont.CharSet = 162;
                    LBL111.Value = @":";

                    LBL112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 55, 35, 60, false);
                    LBL112.Name = "LBL112";
                    LBL112.TextFont.Name = "Arial Narrow";
                    LBL112.TextFont.Size = 8;
                    LBL112.TextFont.Bold = true;
                    LBL112.TextFont.CharSet = 162;
                    LBL112.Value = @":";

                    LBL17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 15, 154, 20, false);
                    LBL17.Name = "LBL17";
                    LBL17.TextFont.Name = "Arial Narrow";
                    LBL17.TextFont.Size = 8;
                    LBL17.TextFont.Bold = true;
                    LBL17.TextFont.CharSet = 162;
                    LBL17.Value = @":";

                    LBL113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 45, 154, 50, false);
                    LBL113.Name = "LBL113";
                    LBL113.TextFont.Name = "Arial Narrow";
                    LBL113.TextFont.Size = 8;
                    LBL113.TextFont.Bold = true;
                    LBL113.TextFont.CharSet = 162;
                    LBL113.Value = @":";

                    LBL121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 40, 154, 45, false);
                    LBL121.Name = "LBL121";
                    LBL121.TextFont.Name = "Arial Narrow";
                    LBL121.TextFont.Size = 8;
                    LBL121.TextFont.Bold = true;
                    LBL121.TextFont.CharSet = 162;
                    LBL121.Value = @":";

                    LBL131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 30, 154, 35, false);
                    LBL131.Name = "LBL131";
                    LBL131.TextFont.Name = "Arial Narrow";
                    LBL131.TextFont.Size = 8;
                    LBL131.TextFont.Bold = true;
                    LBL131.TextFont.CharSet = 162;
                    LBL131.Value = @":";

                    LBL141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 35, 154, 40, false);
                    LBL141.Name = "LBL141";
                    LBL141.TextFont.Name = "Arial Narrow";
                    LBL141.TextFont.Size = 8;
                    LBL141.TextFont.Bold = true;
                    LBL141.TextFont.CharSet = 162;
                    LBL141.Value = @":";

                    LBL151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 25, 154, 30, false);
                    LBL151.Name = "LBL151";
                    LBL151.TextFont.Name = "Arial Narrow";
                    LBL151.TextFont.Size = 8;
                    LBL151.TextFont.Bold = true;
                    LBL151.TextFont.CharSet = 162;
                    LBL151.Value = @":";

                    LBL161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 20, 154, 25, false);
                    LBL161.Name = "LBL161";
                    LBL161.TextFont.Name = "Arial Narrow";
                    LBL161.TextFont.Size = 8;
                    LBL161.TextFont.Bold = true;
                    LBL161.TextFont.CharSet = 162;
                    LBL161.Value = @":";

                    DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 45, 128, 50, false);
                    DOKTOR.Name = "DOKTOR";
                    DOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTOR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DOKTOR.MultiLine = EvetHayirEnum.ehEvet;
                    DOKTOR.WordBreak = EvetHayirEnum.ehEvet;
                    DOKTOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOKTOR.TextFont.Name = "Arial Narrow";
                    DOKTOR.TextFont.Size = 8;
                    DOKTOR.TextFont.CharSet = 162;
                    DOKTOR.Value = @"";

                    ADRESTEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 50, 128, 55, false);
                    ADRESTEL.Name = "ADRESTEL";
                    ADRESTEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRESTEL.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADRESTEL.MultiLine = EvetHayirEnum.ehEvet;
                    ADRESTEL.WordBreak = EvetHayirEnum.ehEvet;
                    ADRESTEL.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRESTEL.TextFont.Name = "Arial Narrow";
                    ADRESTEL.TextFont.Size = 8;
                    ADRESTEL.TextFont.CharSet = 162;
                    ADRESTEL.Value = @"";

                    ISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 25, 100, 30, false);
                    ISLEMNO.Name = "ISLEMNO";
                    ISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ISLEMNO.MultiLine = EvetHayirEnum.ehEvet;
                    ISLEMNO.NoClip = EvetHayirEnum.ehEvet;
                    ISLEMNO.WordBreak = EvetHayirEnum.ehEvet;
                    ISLEMNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISLEMNO.TextFont.Name = "Arial Narrow";
                    ISLEMNO.TextFont.Size = 8;
                    ISLEMNO.TextFont.CharSet = 162;
                    ISLEMNO.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 30, 100, 35, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.TextFont.CharSet = 162;
                    SICILNO.Value = @"";

                    KARNENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 35, 100, 40, false);
                    KARNENO.Name = "KARNENO";
                    KARNENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARNENO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KARNENO.MultiLine = EvetHayirEnum.ehEvet;
                    KARNENO.NoClip = EvetHayirEnum.ehEvet;
                    KARNENO.WordBreak = EvetHayirEnum.ehEvet;
                    KARNENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARNENO.TextFont.Name = "Arial Narrow";
                    KARNENO.TextFont.Size = 8;
                    KARNENO.TextFont.CharSet = 162;
                    KARNENO.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 20, 100, 25, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.UNIQUEREFNO#}";

                    MURACAATTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 15, 202, 20, false);
                    MURACAATTARIHI.Name = "MURACAATTARIHI";
                    MURACAATTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MURACAATTARIHI.TextFormat = @"dd/MM/yyyy";
                    MURACAATTARIHI.TextFont.Name = "Arial Narrow";
                    MURACAATTARIHI.TextFont.Size = 8;
                    MURACAATTARIHI.TextFont.CharSet = 162;
                    MURACAATTARIHI.Value = @"{#PARTA.OPENINGDATE#}";

                    DOGUMTARIHIYASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 20, 202, 25, false);
                    DOGUMTARIHIYASI.Name = "DOGUMTARIHIYASI";
                    DOGUMTARIHIYASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHIYASI.TextFont.Name = "Arial Narrow";
                    DOGUMTARIHIYASI.TextFont.Size = 8;
                    DOGUMTARIHIYASI.TextFont.CharSet = 162;
                    DOGUMTARIHIYASI.Value = @"";

                    PROVIZYONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 35, 202, 40, false);
                    PROVIZYONNO.Name = "PROVIZYONNO";
                    PROVIZYONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONNO.TextFont.Name = "Arial Narrow";
                    PROVIZYONNO.TextFont.Size = 8;
                    PROVIZYONNO.TextFont.CharSet = 162;
                    PROVIZYONNO.Value = @"";

                    GSSTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 45, 202, 50, false);
                    GSSTAKIPNO.Name = "GSSTAKIPNO";
                    GSSTAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GSSTAKIPNO.TextFont.Name = "Arial Narrow";
                    GSSTAKIPNO.TextFont.Size = 8;
                    GSSTAKIPNO.TextFont.CharSet = 162;
                    GSSTAKIPNO.Value = @"{#PARTA.MEDULATAKIPNO#}";

                    SIRANOLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 65, 24, 70, false);
                    SIRANOLBL.Name = "SIRANOLBL";
                    SIRANOLBL.TextFont.Name = "Arial Narrow";
                    SIRANOLBL.TextFont.Size = 8;
                    SIRANOLBL.TextFont.Bold = true;
                    SIRANOLBL.TextFont.CharSet = 162;
                    SIRANOLBL.Value = @"SIRA NO";

                    TARIHLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 65, 43, 70, false);
                    TARIHLBL.Name = "TARIHLBL";
                    TARIHLBL.TextFont.Name = "Arial Narrow";
                    TARIHLBL.TextFont.Size = 8;
                    TARIHLBL.TextFont.Bold = true;
                    TARIHLBL.TextFont.CharSet = 162;
                    TARIHLBL.Value = @"TARİH";

                    ISLEMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 65, 145, 70, false);
                    ISLEMLBL.Name = "ISLEMLBL";
                    ISLEMLBL.TextFont.Name = "Arial Narrow";
                    ISLEMLBL.TextFont.Size = 8;
                    ISLEMLBL.TextFont.Bold = true;
                    ISLEMLBL.TextFont.CharSet = 162;
                    ISLEMLBL.Value = @"YAPILAN İŞLEM";

                    MIKTARLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 65, 158, 70, false);
                    MIKTARLBL.Name = "MIKTARLBL";
                    MIKTARLBL.TextFont.Name = "Arial Narrow";
                    MIKTARLBL.TextFont.Size = 8;
                    MIKTARLBL.TextFont.Bold = true;
                    MIKTARLBL.TextFont.CharSet = 162;
                    MIKTARLBL.Value = @"MİKTAR";

                    BIRIMFIYATLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 65, 180, 70, false);
                    BIRIMFIYATLBL.Name = "BIRIMFIYATLBL";
                    BIRIMFIYATLBL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYATLBL.TextFont.Name = "Arial Narrow";
                    BIRIMFIYATLBL.TextFont.Size = 8;
                    BIRIMFIYATLBL.TextFont.Bold = true;
                    BIRIMFIYATLBL.TextFont.CharSet = 162;
                    BIRIMFIYATLBL.Value = @"B. FİYAT";

                    TUTARLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 65, 202, 70, false);
                    TUTARLBL.Name = "TUTARLBL";
                    TUTARLBL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTARLBL.TextFont.Name = "Arial Narrow";
                    TUTARLBL.TextFont.Size = 8;
                    TUTARLBL.TextFont.Bold = true;
                    TUTARLBL.TextFont.CharSet = 162;
                    TUTARLBL.Value = @"TUTAR";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 71, 202, 71, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 6, 254, 11, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.Value = @"{#PARTA.EPISODEOBJECTID#}";

                    PIDOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 13, 254, 18, false);
                    PIDOBJECTID.Name = "PIDOBJECTID";
                    PIDOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PIDOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PIDOBJECTID.TextFont.Name = "Arial Narrow";
                    PIDOBJECTID.Value = @"{#PARTA.PIDOBJECTID#}";

                    HOMEADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 22, 254, 27, false);
                    HOMEADDRESS.Name = "HOMEADDRESS";
                    HOMEADDRESS.Visible = EvetHayirEnum.ehHayir;
                    HOMEADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMEADDRESS.TextFont.Name = "Arial Narrow";
                    HOMEADDRESS.Value = @"{#PARTA.HOMEADDRESS#}";

                    HOMETOWN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 28, 254, 33, false);
                    HOMETOWN.Name = "HOMETOWN";
                    HOMETOWN.Visible = EvetHayirEnum.ehHayir;
                    HOMETOWN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMETOWN.TextFont.Name = "Arial Narrow";
                    HOMETOWN.Value = @"{#PARTA.HOMETOWN#}";

                    HOMECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 34, 254, 39, false);
                    HOMECITY.Name = "HOMECITY";
                    HOMECITY.Visible = EvetHayirEnum.ehHayir;
                    HOMECITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMECITY.TextFont.Name = "Arial Narrow";
                    HOMECITY.Value = @"{#PARTA.HOMECITY#}";

                    HOMEPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 22, 290, 27, false);
                    HOMEPHONE.Name = "HOMEPHONE";
                    HOMEPHONE.Visible = EvetHayirEnum.ehHayir;
                    HOMEPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOMEPHONE.TextFont.Name = "Arial Narrow";
                    HOMEPHONE.Value = @"{#PARTA.HOMEPHONE#}";

                    MOBILEPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 28, 290, 33, false);
                    MOBILEPHONE.Name = "MOBILEPHONE";
                    MOBILEPHONE.Visible = EvetHayirEnum.ehHayir;
                    MOBILEPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MOBILEPHONE.TextFont.Name = "Arial Narrow";
                    MOBILEPHONE.Value = @"{#PARTA.MOBILEPHONE#}";

                    BUSINESSPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 34, 290, 39, false);
                    BUSINESSPHONE.Name = "BUSINESSPHONE";
                    BUSINESSPHONE.Visible = EvetHayirEnum.ehHayir;
                    BUSINESSPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUSINESSPHONE.TextFont.Name = "Arial Narrow";
                    BUSINESSPHONE.Value = @"{#PARTA.BUSINESSPHONE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class dataset_ICProceduresAlphabeticReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<InvoiceCollectionDetail.ICProceduresAlphabeticReportQuery_Class>(0);
                    KURUM.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Payercode) : "") + @" " + (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Payername) : "");
                    ADSOYAD.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Patientname) : "");
                    PROTOKOLNO.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Episodeid) : "");
                    FATURATARIHI.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Invoicedate) : "");
                    FATURANO.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Invoiceno) : "");
                    TANI.CalcValue = @"";
                    PAGENO.CalcValue = @"";
                    LBL.CalcValue = LBL.Value;
                    ADSOYADLBL.CalcValue = ADSOYADLBL.Value;
                    TCKIMLIKNOLBL.CalcValue = TCKIMLIKNOLBL.Value;
                    TANILBL.CalcValue = TANILBL.Value;
                    ADRESTELLBL.CalcValue = ADRESTELLBL.Value;
                    ISLEMNOLBL.CalcValue = ISLEMNOLBL.Value;
                    DOKTORLBL.CalcValue = DOKTORLBL.Value;
                    KURUMLBL.CalcValue = KURUMLBL.Value;
                    KARNENOLBL.CalcValue = KARNENOLBL.Value;
                    SICILNOLBL.CalcValue = SICILNOLBL.Value;
                    MURACAATTARIHLBL.CalcValue = MURACAATTARIHLBL.Value;
                    DTARIHLBL.CalcValue = DTARIHLBL.Value;
                    FATURANOLBL.CalcValue = FATURANOLBL.Value;
                    DOKTORLBL1.CalcValue = DOKTORLBL1.Value;
                    PROTOKOLNOLBL.CalcValue = PROTOKOLNOLBL.Value;
                    PROVIZYONNOLBL.CalcValue = PROVIZYONNOLBL.Value;
                    FATURATARIHILBL.CalcValue = FATURATARIHILBL.Value;
                    LBL1.CalcValue = LBL1.Value;
                    LBL11.CalcValue = LBL11.Value;
                    LBL12.CalcValue = LBL12.Value;
                    LBL13.CalcValue = LBL13.Value;
                    LBL14.CalcValue = LBL14.Value;
                    LBL15.CalcValue = LBL15.Value;
                    LBL16.CalcValue = LBL16.Value;
                    LBL111.CalcValue = LBL111.Value;
                    LBL112.CalcValue = LBL112.Value;
                    LBL17.CalcValue = LBL17.Value;
                    LBL113.CalcValue = LBL113.Value;
                    LBL121.CalcValue = LBL121.Value;
                    LBL131.CalcValue = LBL131.Value;
                    LBL141.CalcValue = LBL141.Value;
                    LBL151.CalcValue = LBL151.Value;
                    LBL161.CalcValue = LBL161.Value;
                    DOKTOR.CalcValue = @"";
                    ADRESTEL.CalcValue = @"";
                    ISLEMNO.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    KARNENO.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.UniqueRefNo) : "");
                    MURACAATTARIHI.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.OpeningDate) : "");
                    DOGUMTARIHIYASI.CalcValue = @"";
                    PROVIZYONNO.CalcValue = @"";
                    GSSTAKIPNO.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Medulatakipno) : "");
                    SIRANOLBL.CalcValue = SIRANOLBL.Value;
                    TARIHLBL.CalcValue = TARIHLBL.Value;
                    ISLEMLBL.CalcValue = ISLEMLBL.Value;
                    MIKTARLBL.CalcValue = MIKTARLBL.Value;
                    BIRIMFIYATLBL.CalcValue = BIRIMFIYATLBL.Value;
                    TUTARLBL.CalcValue = TUTARLBL.Value;
                    EPISODEOBJECTID.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Episodeobjectid) : "");
                    PIDOBJECTID.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.Pidobjectid) : "");
                    HOMEADDRESS.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.HomeAddress) : "");
                    HOMETOWN.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.HomeTown) : "");
                    HOMECITY.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.HomeCity) : "");
                    HOMEPHONE.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.HomePhone) : "");
                    MOBILEPHONE.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.MobilePhone) : "");
                    BUSINESSPHONE.CalcValue = (dataset_ICProceduresAlphabeticReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresAlphabeticReportQuery.BusinessPhone) : "");
                    return new TTReportObject[] { KURUM,ADSOYAD,PROTOKOLNO,FATURATARIHI,FATURANO,TANI,PAGENO,LBL,ADSOYADLBL,TCKIMLIKNOLBL,TANILBL,ADRESTELLBL,ISLEMNOLBL,DOKTORLBL,KURUMLBL,KARNENOLBL,SICILNOLBL,MURACAATTARIHLBL,DTARIHLBL,FATURANOLBL,DOKTORLBL1,PROTOKOLNOLBL,PROVIZYONNOLBL,FATURATARIHILBL,LBL1,LBL11,LBL12,LBL13,LBL14,LBL15,LBL16,LBL111,LBL112,LBL17,LBL113,LBL121,LBL131,LBL141,LBL151,LBL161,DOKTOR,ADRESTEL,ISLEMNO,SICILNO,KARNENO,TCKIMLIKNO,MURACAATTARIHI,DOGUMTARIHIYASI,PROVIZYONNO,GSSTAKIPNO,SIRANOLBL,TARIHLBL,ISLEMLBL,MIKTARLBL,BIRIMFIYATLBL,TUTARLBL,EPISODEOBJECTID,PIDOBJECTID,HOMEADDRESS,HOMETOWN,HOMECITY,HOMEPHONE,MOBILEPHONE,BUSINESSPHONE};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    this.PAGENO.CalcValue = MyParentReport.PageNumber + ". SAYFA";
            MyParentReport.PageNumber++;

            Episode episode = (Episode)MyParentReport.ReportObjectContext.GetObject(new Guid(this.EPISODEOBJECTID.CalcValue), TTObjectDefManager.Instance.ObjectDefs[typeof(Episode).Name], false);
            if (episode != null)
            {
                // Doğum Tarihi ve Yaş
                if (episode.Patient.BirthDate.HasValue)
                {
                    this.DOGUMTARIHIYASI.CalcValue = episode.Patient.BirthDate.Value.ToShortDateString();

                    if (!string.IsNullOrEmpty(this.FATURATARIHI.CalcValue))
                    {
                        DateTime invoiceDate = Convert.ToDateTime(this.FATURATARIHI.CalcValue);
                        int age = episode.Patient.AgeBySpecificDate(invoiceDate);
                        if (age >= 0)
                            this.DOGUMTARIHIYASI.CalcValue += " / " + age;
                    }
                }

                // Adres ve Telefon
                if (!string.IsNullOrEmpty(this.HOMEADDRESS.CalcValue))
                    this.ADRESTEL.CalcValue += this.HOMEADDRESS.CalcValue + " ";

                if (!string.IsNullOrEmpty(this.HOMETOWN.CalcValue))
                    this.ADRESTEL.CalcValue += this.HOMETOWN.CalcValue + " ";

                if (!string.IsNullOrEmpty(this.HOMECITY.CalcValue))
                    this.ADRESTEL.CalcValue += this.HOMECITY.CalcValue + " ";

                if (!string.IsNullOrEmpty(this.MOBILEPHONE.CalcValue))
                    this.ADRESTEL.CalcValue += (!string.IsNullOrEmpty(this.ADRESTEL.CalcValue) ? "/ " : "") + this.MOBILEPHONE.CalcValue;
                else if (!string.IsNullOrEmpty(this.HOMEPHONE.CalcValue))
                    this.ADRESTEL.CalcValue += (!string.IsNullOrEmpty(this.ADRESTEL.CalcValue) ? "/ " : "") + this.HOMEPHONE.CalcValue;
                else if (!string.IsNullOrEmpty(this.BUSINESSPHONE.CalcValue))
                    this.ADRESTEL.CalcValue += (!string.IsNullOrEmpty(this.ADRESTEL.CalcValue) ? "/ " : "") + this.BUSINESSPHONE.CalcValue;

                // Tanılar
                string diagnosisStrPrimer = string.Empty;
                string diagnosisStrSeconder = string.Empty;
                IList primerDiagnosisList = new List<string>();
                IList seconderDiagnosisList = new List<string>();

                foreach (DiagnosisGrid dg in episode.Diagnosis)
                {
                    if (dg.DiagnosisType == DiagnosisTypeEnum.Seconder)
                    {
                        if (!seconderDiagnosisList.Contains(dg.DiagnoseCode))
                        {
                            diagnosisStrSeconder += dg.Diagnose + " , ";
                            seconderDiagnosisList.Add(dg.DiagnoseCode);
                        }
                    }
                    else if (dg.DiagnosisType == DiagnosisTypeEnum.Primer && seconderDiagnosisList.Count == 0)
                    {
                        if (!primerDiagnosisList.Contains(dg.DiagnoseCode))
                        {
                            diagnosisStrPrimer += dg.DiagnoseCode + " " + dg.Diagnose + " , ";
                            primerDiagnosisList.Add(dg.DiagnoseCode);
                        }
                    }
                }

                if (seconderDiagnosisList.Count > 0)
                    this.TANI.CalcValue = diagnosisStrSeconder.Substring(0, diagnosisStrSeconder.Length - 3);
                else if (primerDiagnosisList.Count > 0)
                    this.TANI.CalcValue = diagnosisStrPrimer.Substring(0, diagnosisStrPrimer.Length - 3);
            }

            PayerInvoiceDocument pid = (PayerInvoiceDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(this.PIDOBJECTID.CalcValue), TTObjectDefManager.Instance.ObjectDefs[typeof(PayerInvoiceDocument).Name], false);
            if (pid != null)
            {
                // Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
                if (!string.IsNullOrEmpty(pid.DocumentNo))
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (Char ch in pid.DocumentNo)
                        if (Char.IsDigit(ch))
                        sb.Append(ch);

                    this.FATURANO.CalcValue = sb.ToString();
                }
            }
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public ICProceduresAlphabeticReport MyParentReport
                {
                    get { return (ICProceduresAlphabeticReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField TOPLAMLBL;
                public TTReportShape NewLine111; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 4, 202, 9, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Name = "Arial Narrow";
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{@sumof(PRICE)@}";

                    TOPLAMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 4, 180, 9, false);
                    TOPLAMLBL.Name = "TOPLAMLBL";
                    TOPLAMLBL.TextFont.Name = "Arial Narrow";
                    TOPLAMLBL.TextFont.Size = 8;
                    TOPLAMLBL.TextFont.Bold = true;
                    TOPLAMLBL.TextFont.CharSet = 162;
                    TOPLAMLBL.Value = @"TOPLAM :";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 2, 202, 2, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTALPRICE.CalcValue = ParentGroup.FieldSums["PRICE"].Value.ToString();;
                    TOPLAMLBL.CalcValue = TOPLAMLBL.Value;
                    return new TTReportObject[] { TOTALPRICE,TOPLAMLBL};
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public ICProceduresAlphabeticReport MyParentReport
            {
                get { return (ICProceduresAlphabeticReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public TTReportField DAY { get {return Body().DAY;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
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
                list[0] = new TTReportNqlData<PayerInvoiceDocument.ICProceduresReportQuery_Class>("ICProceduresReportQuery", PayerInvoiceDocument.ICProceduresReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTA.PIDOBJECTID.CalcValue)));
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
                public ICProceduresAlphabeticReport MyParentReport
                {
                    get { return (ICProceduresAlphabeticReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField DESCRIPTION;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField TRANSACTIONDATE;
                public TTReportField DAY;
                public TTReportField MONTH;
                public TTReportField YEAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 24, 4, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Name = "Arial Narrow";
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@groupcounter@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 0, 145, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#EXTERNALCODE#} {#DESCRIPTION#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 158, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 0, 180, 4, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Name = "Arial Narrow";
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 202, 4, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Name = "Arial Narrow";
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#TOTALPRICE#}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 43, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFont.Name = "Arial Narrow";
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                    DAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 241, 4, false);
                    DAY.Name = "DAY";
                    DAY.Visible = EvetHayirEnum.ehHayir;
                    DAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAY.TextFont.Size = 8;
                    DAY.TextFont.CharSet = 162;
                    DAY.Value = @"{#DAY#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 260, 4, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.TextFont.Size = 8;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"{#MONTH#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 280, 4, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFont.Size = 8;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"{#YEAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.ICProceduresReportQuery_Class dataset_ICProceduresReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.ICProceduresReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    DESCRIPTION.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.ExternalCode) : "") + @" " + (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.Description) : "");
                    AMOUNT.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.UnitPrice) : "");
                    PRICE.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.Totalprice) : "");
                    TRANSACTIONDATE.CalcValue = @"";
                    DAY.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.Day) : "");
                    MONTH.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.Month) : "");
                    YEAR.CalcValue = (dataset_ICProceduresReportQuery != null ? Globals.ToStringCore(dataset_ICProceduresReportQuery.Year) : "");
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE,DAY,MONTH,YEAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.DAY.CalcValue.Length == 1)
                this.DAY.CalcValue = "0" + this.DAY.CalcValue;
            
            if(this.MONTH.CalcValue.Length == 1)
                this.MONTH.CalcValue = "0" + this.MONTH.CalcValue;
            
            this.TRANSACTIONDATE.CalcValue = this.DAY.CalcValue + "." + this.MONTH.CalcValue + "." + this.YEAR.CalcValue;
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (this.MyParentReport.MAIN.IsLastData())
                    MyParentReport.IsLastPage = true;
                else
                    MyParentReport.IsLastPage = false;
            
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

        public ICProceduresAlphabeticReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEAD = new HEADGroup(PARTA,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ICPROCEDURESALPHABETICREPORT";
            Caption = "Açıklamalı Hizmet Detay Belgesi (Alfabetik)";
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