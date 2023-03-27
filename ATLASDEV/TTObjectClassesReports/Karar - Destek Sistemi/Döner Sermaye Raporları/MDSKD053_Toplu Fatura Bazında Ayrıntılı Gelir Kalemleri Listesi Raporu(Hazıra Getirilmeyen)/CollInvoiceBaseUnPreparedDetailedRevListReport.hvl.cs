
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
    /// Toplu Fatura Bazında Ayrıntılı Gelir Kalemleri Listesi (Hazıra Getirilmeyen)
    /// </summary>
    public partial class CollInvoiceBaseUnPreparedDetailedRevListReport : TTReport
    {
#region Methods
   public List<GelirKalemi> gelirKalemiList = new List<GelirKalemi>();
       
        public double ToplamKurumGelir = 0;
        public double ToplamKisiGelir = 0;
        public int Sayac = 0;
        public int yazdirmaSayac = 0;
        
        public bool GKBVar = false;              // Gelir Kalemine ulaşılamayan hizmetler için flag
        public double GKBToplamKurumGelir = 0;   // Gelir Kalemine ulaşılamayan hizmetler için toplam kurum tutarı
        public double GKBToplamKisiGelir = 0;    // Gelir Kalemine ulaşılamayan hizmetler için toplam hasta tutarı
        
        public class GelirKalemi
        {
            public string Aciklama;
            public double KurumGelir;
            public double KisiGelir;
            
            public GelirKalemi(string aciklama, double kurumgelir, double kisigelir)
            {
                Aciklama = aciklama;
                KurumGelir = kurumgelir;
                KisiGelir = kisigelir;
            }
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public List<string> ID = new List<string>();
        }

        public partial class PARTFGroup : TTReportGroup
        {
            public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
            {
                get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
            }

            new public PARTFGroupBody Body()
            {
                return (PARTFGroupBody)_body;
            }
            public TTReportField PATIENTPRICE { get {return Body().PATIENTPRICE;} }
            public TTReportField PAYERPRICE { get {return Body().PAYERPRICE;} }
            public TTReportField ISLEM_NO { get {return Body().ISLEM_NO;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class>("CollInvoiceDetailedRevenueListMaterialQuery_NP", AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP((List<string>) MyParentReport.RuntimeParameters.ID));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTFGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTFGroupBody : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                
                public TTReportField PATIENTPRICE;
                public TTReportField PAYERPRICE;
                public TTReportField ISLEM_NO; 
                public PARTFGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATIENTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 2, 187, 7, false);
                    PATIENTPRICE.Name = "PATIENTPRICE";
                    PATIENTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTPRICE.Value = @"{#PATIENTPRICE#}";

                    PAYERPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 2, 150, 7, false);
                    PAYERPRICE.Name = "PAYERPRICE";
                    PAYERPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERPRICE.Value = @"{#PAYERPRICE#}";

                    ISLEM_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 39, 6, false);
                    ISLEM_NO.Name = "ISLEM_NO";
                    ISLEM_NO.Visible = EvetHayirEnum.ehHayir;
                    ISLEM_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEM_NO.Value = @"{@ID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class dataset_CollInvoiceDetailedRevenueListMaterialQuery_NP = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.CollInvoiceDetailedRevenueListMaterialQuery_NP_Class>(0);
                    PATIENTPRICE.CalcValue = (dataset_CollInvoiceDetailedRevenueListMaterialQuery_NP != null ? Globals.ToStringCore(dataset_CollInvoiceDetailedRevenueListMaterialQuery_NP.Patientprice) : "");
                    PAYERPRICE.CalcValue = (dataset_CollInvoiceDetailedRevenueListMaterialQuery_NP != null ? Globals.ToStringCore(dataset_CollInvoiceDetailedRevenueListMaterialQuery_NP.Payerprice) : "");
                    ISLEM_NO.CalcValue = MyParentReport.RuntimeParameters.ID.ToString();
                    return new TTReportObject[] { PATIENTPRICE,PAYERPRICE,ISLEM_NO};
                }

                public override void RunScript()
                {
#region PARTF BODY_Script
                    if (this.PAYERPRICE.CalcValue == "")
                this.PAYERPRICE.CalcValue = "0";
            
            if (this.PATIENTPRICE.CalcValue == "")
                this.PATIENTPRICE.CalcValue = "0";
            
            if(Convert.ToDouble(this.PAYERPRICE.CalcValue) > 0 || Convert.ToDouble(this.PATIENTPRICE.CalcValue) > 0)
            {
                string revenueName = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
                bool GKFound = false;

                foreach (GelirKalemi GK in ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList)
                {
                    if(GK.Aciklama == revenueName)
                    {
                        GK.KurumGelir += Convert.ToDouble(this.PAYERPRICE.CalcValue);
                        GK.KisiGelir += Convert.ToDouble(this.PATIENTPRICE.CalcValue);
                        GKFound = true;
                        break;
                    }
                }
                
                if(!GKFound)
                {
                    ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(revenueName, Convert.ToDouble(this.PAYERPRICE.CalcValue), Convert.ToDouble(this.PATIENTPRICE.CalcValue)));
                    ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).Sayac += 1;
                }
            }
#endregion PARTF BODY_Script
                }
            }

        }

        public PARTFGroup PARTF;

        public partial class MAINGroup : TTReportGroup
        {
            public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
            {
                get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROCEDURE { get {return Body().PROCEDURE;} }
            public TTReportField PATIENTPRICE { get {return Body().PATIENTPRICE;} }
            public TTReportField PAYERPRICE { get {return Body().PAYERPRICE;} }
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
                list[0] = new TTReportNqlData<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class>("CollInvoiceDetailedRevenueListProcedureQuery_NP", AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP((List<string>) MyParentReport.RuntimeParameters.ID));
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
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                
                public TTReportField PROCEDURE;
                public TTReportField PATIENTPRICE;
                public TTReportField PAYERPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROCEDURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 110, 7, false);
                    PROCEDURE.Name = "PROCEDURE";
                    PROCEDURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURE.Value = @"{#PROCEDURE#}";

                    PATIENTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 2, 187, 7, false);
                    PATIENTPRICE.Name = "PATIENTPRICE";
                    PATIENTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTPRICE.Value = @"{#PATIENTPRICE#}";

                    PAYERPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 2, 150, 7, false);
                    PAYERPRICE.Name = "PAYERPRICE";
                    PAYERPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERPRICE.Value = @"{#PAYERPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.CollInvoiceDetailedRevenueListProcedureQuery_NP_Class>(0);
                    PROCEDURE.CalcValue = (dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP != null ? Globals.ToStringCore(dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP.Procedure) : "");
                    PATIENTPRICE.CalcValue = (dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP != null ? Globals.ToStringCore(dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP.Patientprice) : "");
                    PAYERPRICE.CalcValue = (dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP != null ? Globals.ToStringCore(dataset_CollInvoiceDetailedRevenueListProcedureQuery_NP.Payerprice) : "");
                    return new TTReportObject[] { PROCEDURE,PATIENTPRICE,PAYERPRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.PROCEDURE.CalcValue != "")
            {
                TTObjectContext context = new TTObjectContext(true);
                string pObjectID = this.PROCEDURE.CalcValue;
                ProcedureDefinition procedure = (ProcedureDefinition)context.GetObject(new Guid(pObjectID), "ProcedureDefinition");
                
                string revenueName = "";
                
                if(procedure.RevenueSubAccountCode != null)
                    revenueName = procedure.RevenueSubAccountCode.Description;
                else
                {
                    if(procedure.ProcedureTree != null)
                    {
                        ProcedureTreeDefinition procedureTree = procedure.ProcedureTree;
                        while(procedureTree != null && revenueName == "")
                        {
                            if(procedureTree.RevenueSubAccountCode != null)
                                revenueName = procedureTree.RevenueSubAccountCode.Description;
                            
                            procedureTree = procedureTree.ParentID;
                        }
                    }
                }
                
                if(revenueName == "")   // Gelir kalemi bulunamamışsa en son yazmak üzere flag i true yapıp, toplama ekliyor
                {
                    ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).GKBVar = true;
                    ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).GKBToplamKurumGelir += Convert.ToDouble(this.PAYERPRICE.CalcValue);
                    ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).GKBToplamKisiGelir += Convert.ToDouble(this.PATIENTPRICE.CalcValue);
                }
                else  // Gelir kalemine ulaşılmışsa listeye ekleniyor
                {
                    bool GKFound = false;

                    foreach (GelirKalemi GK in ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList)
                    {
                        if(GK.Aciklama == revenueName)
                        {
                            GK.KurumGelir += Convert.ToDouble(this.PAYERPRICE.CalcValue);
                            GK.KisiGelir += Convert.ToDouble(this.PATIENTPRICE.CalcValue);
                            GKFound = true;
                            break;
                        }
                    }
                    
                    if(!GKFound)
                    {
                        ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(revenueName, Convert.ToDouble(this.PAYERPRICE.CalcValue), Convert.ToDouble(this.PATIENTPRICE.CalcValue)));
                        ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).Sayac += 1;
                    }
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
            {
                get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
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
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTA BODY_Script
                    if (((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).GKBVar == true)
            {
                ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList.Add(new GelirKalemi("Gelir Kalemine Ulaşılamayan Hizmetler", ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).GKBToplamKurumGelir, ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).GKBToplamKisiGelir));
                ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).Sayac += 1;
            }

                    ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).PARTC.RepeatCount = ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).Sayac;
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTEGroup : TTReportGroup
        {
            public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
            {
                get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTEGroupHeader(this);
                _footer = new PARTEGroupFooter(this);

            }

            public partial class PARTEGroupHeader : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 20;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 3, 187, 3, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 4, 135, 9, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 4, 187, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 45, 9, false);
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

        public PARTEGroup PARTE;

        public partial class PARTDGroup : TTReportGroup
        {
            public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
            {
                get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField GELIRKALEMI { get {return Header().GELIRKALEMI;} }
            public TTReportField KURUMGELIR { get {return Header().KURUMGELIR;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportField ID { get {return Header().ID;} }
            public TTReportShape NewLine11111111 { get {return Footer().NewLine11111111;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportField KURUMTOPLAM { get {return Footer().KURUMTOPLAM;} }
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
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                
                public TTReportField GELIRKALEMI;
                public TTReportField KURUMGELIR;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField NewField1112211;
                public TTReportShape NewLine1111111;
                public TTReportField ID; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    GELIRKALEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 36, 149, 41, false);
                    GELIRKALEMI.Name = "GELIRKALEMI";
                    GELIRKALEMI.MultiLine = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.NoClip = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.WordBreak = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.TextFont.Bold = true;
                    GELIRKALEMI.TextFont.CharSet = 162;
                    GELIRKALEMI.Value = @"GELİR KALEMİ";

                    KURUMGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 36, 187, 41, false);
                    KURUMGELIR.Name = "KURUMGELIR";
                    KURUMGELIR.TextFormat = @"#,##0.#0";
                    KURUMGELIR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMGELIR.TextFont.Bold = true;
                    KURUMGELIR.TextFont.CharSet = 162;
                    KURUMGELIR.Value = @"GELİR MİKTARI (Kurum)";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 14, 187, 20, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"TOPLU FATURA BAZINDA AYRINTILI GELİR KALEMLERİ LİSTESİ (HAZIRA GETİRİLMEYEN)";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 26, 37, 31, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"İşlem Numarası";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 26, 39, 31, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 42, 187, 42, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    ID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 26, 187, 31, false);
                    ID.Name = "ID";
                    ID.FieldType = ReportFieldTypeEnum.ftExpression;
                    ID.Value = @"{@ID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GELIRKALEMI.CalcValue = GELIRKALEMI.Value;
                    KURUMGELIR.CalcValue = KURUMGELIR.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    ID.CalcValue = MyParentReport.RuntimeParameters.ID.ToString();
                    return new TTReportObject[] { GELIRKALEMI,KURUMGELIR,NewField1111,NewField1121,NewField1112211,ID};
                }

                public override void RunScript()
                {
#region PARTD HEADER_Script
                    string islemNumbers = string.Empty;
                    List<string> islemNoList = MyParentReport.RuntimeParameters.ID;
                    foreach (string islemNo in islemNoList)
                        islemNumbers += islemNo+"  ";
                    ID.CalcValue = islemNumbers;
#endregion PARTD HEADER_Script
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111111;
                public TTReportField GENELTOPLAM;
                public TTReportField KURUMTOPLAM; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 2, 187, 2, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 149, 9, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.Value = @"GENEL TOPLAM";

                    KURUMTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 4, 187, 9, false);
                    KURUMTOPLAM.Name = "KURUMTOPLAM";
                    KURUMTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMTOPLAM.TextFormat = @"#,##0.#0";
                    KURUMTOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMTOPLAM.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GENELTOPLAM.CalcValue = GENELTOPLAM.Value;
                    KURUMTOPLAM.CalcValue = @"";
                    return new TTReportObject[] { GENELTOPLAM,KURUMTOPLAM};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    this.KURUMTOPLAM.CalcValue = ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).ToplamKurumGelir.ToString();
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
            {
                get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField GELIRKALEMI { get {return Body().GELIRKALEMI;} }
            public TTReportField KURUMGELIR { get {return Body().KURUMGELIR;} }
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
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public CollInvoiceBaseUnPreparedDetailedRevListReport MyParentReport
                {
                    get { return (CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport; }
                }
                
                public TTReportField GELIRKALEMI;
                public TTReportField KURUMGELIR; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    GELIRKALEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 149, 6, false);
                    GELIRKALEMI.Name = "GELIRKALEMI";
                    GELIRKALEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELIRKALEMI.MultiLine = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.NoClip = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.WordBreak = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.Value = @"";

                    KURUMGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 187, 6, false);
                    KURUMGELIR.Name = "KURUMGELIR";
                    KURUMGELIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMGELIR.TextFormat = @"#,##0.#0";
                    KURUMGELIR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMGELIR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GELIRKALEMI.CalcValue = @"";
                    KURUMGELIR.CalcValue = @"";
                    return new TTReportObject[] { GELIRKALEMI,KURUMGELIR};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    if (((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).Sayac > 0)
            {
                this.GELIRKALEMI.CalcValue = ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList[((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).yazdirmaSayac].Aciklama;
                this.KURUMGELIR.CalcValue = ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).gelirKalemiList[((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).yazdirmaSayac].KurumGelir.ToString();

                ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).ToplamKurumGelir += Convert.ToDouble(this.KURUMGELIR.FormattedValue);

                ((CollInvoiceBaseUnPreparedDetailedRevListReport)ParentReport).yazdirmaSayac += 1;
            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollInvoiceBaseUnPreparedDetailedRevListReport()
        {
            PARTF = new PARTFGroup(this,"PARTF");
            MAIN = new MAINGroup(this,"MAIN");
            PARTA = new PARTAGroup(this,"PARTA");
            PARTE = new PARTEGroup(this,"PARTE");
            PARTD = new PARTDGroup(PARTE,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ID", "", "İşlem Numarası", @"", true, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ID"))
                _runtimeParameters.ID = (List<string>)parameters["ID"];
            Name = "COLLINVOICEBASEUNPREPAREDDETAILEDREVLISTREPORT";
            Caption = "Toplu Fatura Bazında Ayrıntılı Gelir Kalemleri Listesi (Hazıra Getirilmeyen)";
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


        protected override void RunPreScript()
        {
#region COLLINVOICEBASEUNPREPAREDDETAILEDREVLISTREPORT_PreScript
            gelirKalemiList.Clear();
            
            ToplamKurumGelir = 0;
            ToplamKisiGelir = 0;
            Sayac = 0;
            yazdirmaSayac = 0;
            
            GKBVar = false;              
            GKBToplamKurumGelir = 0;   
            GKBToplamKisiGelir = 0;
#endregion COLLINVOICEBASEUNPREPAREDDETAILEDREVLISTREPORT_PreScript
        }
    }
}