
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
    /// Muhasebe Yetkilisi Mutemetliği Gelir Kalemleri Raporu
    /// </summary>
    public partial class SubCashOfficeRevenueReport : TTReport
    {
#region Methods
   public List<GelirKalemi> gelirKalemiList = new List<GelirKalemi>();
        
        public double ToplamGelir = 0;
        public int Sayac = 0;
        public int yazdirmaSayac = 0;
        
        public bool GKBVar = false;                // Gelir Kalemine ulaşılamayan hizmetler için flag
        public double GKBToplamGelir = 0;          // Gelir Kalemine ulaşılamayan hizmetler için toplam tutar
        public string GKBAciklama = string.Empty;  // Gelir Kalemine ulaşılamayan hizmet isimleri
        
        public class GelirKalemi
        {
            public string Aciklama;
            public double Gelir;
            
            public GelirKalemi(string aciklama, double gelir)
            {
                Aciklama = aciklama;
                Gelir = gelir;
            }
        }
        
        public class AscBranchComparer : IComparer<GelirKalemi>
        {
            #region IComparer<LotoItem> Members
            public int Compare(GelirKalemi x, GelirKalemi y)
            {
                return (x.Aciklama.CompareTo(y.Aciklama)); // artan sıra ile sıralayan Compare
            }
            #endregion
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTEGroup : TTReportGroup
        {
            public SubCashOfficeRevenueReport MyParentReport
            {
                get { return (SubCashOfficeRevenueReport)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField CASHIERLOG { get {return Header().CASHIERLOG;} }
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
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportField CASHIERLOG; 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    CASHIERLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 30, 6, false);
                    CASHIERLOG.Name = "CASHIERLOG";
                    CASHIERLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERLOG.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CASHIERLOG.CalcValue = @"";
                    return new TTReportObject[] { CASHIERLOG};
                }

                public override void RunScript()
                {
#region PARTE HEADER_Script
                    ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList.Clear();
            ((SubCashOfficeRevenueReport)ParentReport).ToplamGelir = 0;
            ((SubCashOfficeRevenueReport)ParentReport).Sayac = 0;
            ((SubCashOfficeRevenueReport)ParentReport).yazdirmaSayac = 0;
            ((SubCashOfficeRevenueReport)ParentReport).GKBVar = false;
            ((SubCashOfficeRevenueReport)ParentReport).GKBToplamGelir = 0;
            ((SubCashOfficeRevenueReport)ParentReport).GKBAciklama = string.Empty;
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SubCashOfficeRevenueReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CashOfficeClosing coClosing = (CashOfficeClosing)context.GetObject(new Guid(sObjectID), typeof(CashOfficeClosing));
            
            if(coClosing != null && coClosing.CashierLog != null)
                this.CASHIERLOG.CalcValue = coClosing.CashierLog.ObjectID.ToString();
#endregion PARTE HEADER_Script
                }
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTAGroup : TTReportGroup
        {
            public SubCashOfficeRevenueReport MyParentReport
            {
                get { return (SubCashOfficeRevenueReport)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField MATERIALPRICE { get {return Body().MATERIALPRICE;} }
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
                list[0] = new TTReportNqlData<ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class>("GetMaterialTotalPriceByCashierLog", ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTE.CASHIERLOG.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportField MATERIALPRICE; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MATERIALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 138, 6, false);
                    MATERIALPRICE.Name = "MATERIALPRICE";
                    MATERIALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALPRICE.Value = @"{#TOTALDISCOUNTEDPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class dataset_GetMaterialTotalPriceByCashierLog = ParentGroup.rsGroup.GetCurrentRecord<ReceiptDocumentDetail.GetMaterialTotalPriceByCashierLog_Class>(0);
                    MATERIALPRICE.CalcValue = (dataset_GetMaterialTotalPriceByCashierLog != null ? Globals.ToStringCore(dataset_GetMaterialTotalPriceByCashierLog.Totaldiscountedprice) : "");
                    return new TTReportObject[] { MATERIALPRICE};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    if (string.IsNullOrEmpty(this.MATERIALPRICE.CalcValue))
                this.MATERIALPRICE.CalcValue = "0";
            
            if(Convert.ToDouble(this.MATERIALPRICE.CalcValue) > 0)
            {
                string revenueName = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
                bool GKFound = false;
                
                foreach(GelirKalemi GK in ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList)
                {
                    if(GK.Aciklama == revenueName)
                    {
                        GK.Gelir += Convert.ToDouble(this.MATERIALPRICE.CalcValue);
                        GKFound = true;
                        break;
                    }
                }
                
                if(!GKFound)
                {
                    ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(revenueName, Convert.ToDouble(this.MATERIALPRICE.CalcValue)));
                    ((SubCashOfficeRevenueReport)ParentReport).Sayac ++;
                }
            }
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public SubCashOfficeRevenueReport MyParentReport
            {
                get { return (SubCashOfficeRevenueReport)ParentReport; }
            }

            new public PARTBGroupBody Body()
            {
                return (PARTBGroupBody)_body;
            }
            public TTReportField PROCEDURE { get {return Body().PROCEDURE;} }
            public TTReportField PROCEDUREPRICE { get {return Body().PROCEDUREPRICE;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReceiptDocumentDetail.GetProceduresByCashierLog_Class>("GetProceduresByCashierLog", ReceiptDocumentDetail.GetProceduresByCashierLog((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTE.CASHIERLOG.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTBGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupBody : TTReportSection
            {
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportField PROCEDURE;
                public TTReportField PROCEDUREPRICE; 
                public PARTBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROCEDURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 102, 6, false);
                    PROCEDURE.Name = "PROCEDURE";
                    PROCEDURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURE.Value = @"{#PROCEDURE#}";

                    PROCEDUREPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 138, 6, false);
                    PROCEDUREPRICE.Name = "PROCEDUREPRICE";
                    PROCEDUREPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREPRICE.Value = @"{#TOTALDISCOUNTEDPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReceiptDocumentDetail.GetProceduresByCashierLog_Class dataset_GetProceduresByCashierLog = ParentGroup.rsGroup.GetCurrentRecord<ReceiptDocumentDetail.GetProceduresByCashierLog_Class>(0);
                    PROCEDURE.CalcValue = (dataset_GetProceduresByCashierLog != null ? Globals.ToStringCore(dataset_GetProceduresByCashierLog.Procedure) : "");
                    PROCEDUREPRICE.CalcValue = (dataset_GetProceduresByCashierLog != null ? Globals.ToStringCore(dataset_GetProceduresByCashierLog.Totaldiscountedprice) : "");
                    return new TTReportObject[] { PROCEDURE,PROCEDUREPRICE};
                }

                public override void RunScript()
                {
#region PARTB BODY_Script
                    if(!string.IsNullOrEmpty(this.PROCEDURE.CalcValue))
            {
                TTObjectContext context = new TTObjectContext(true);
                string pObjectID = this.PROCEDURE.CalcValue;
                ProcedureDefinition procedure = (ProcedureDefinition)context.GetObject(new Guid(pObjectID), typeof(ProcedureDefinition));
                
                string revenueName = string.Empty;
                
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
                
                if(string.IsNullOrEmpty(revenueName))   // Gelir kalemi bulunamamışsa en son yazmak üzere flag i true yapıp, toplama ekliyor
                {
                    ((SubCashOfficeRevenueReport)ParentReport).GKBVar = true;
                    ((SubCashOfficeRevenueReport)ParentReport).GKBToplamGelir += Convert.ToDouble(this.PROCEDUREPRICE.CalcValue);
                    ((SubCashOfficeRevenueReport)ParentReport).GKBAciklama += procedure.Code + " " + procedure.Name + ", ";
                }
                else  // Gelir kalemine ulaşılmışsa listeye ekleniyor
                {
                    bool GKFound = false;
                    
                    foreach(GelirKalemi GK in ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList)
                    {
                        if(GK.Aciklama == revenueName)
                        {
                            GK.Gelir += Convert.ToDouble(this.PROCEDUREPRICE.CalcValue);
                            GKFound = true;
                            break;
                        }
                    }
                    
                    if(!GKFound)
                    {
                        ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(revenueName, Convert.ToDouble(this.PROCEDUREPRICE.CalcValue)));
                        ((SubCashOfficeRevenueReport)ParentReport).Sayac ++;
                    }
                }
            }
#endregion PARTB BODY_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTDGroup : TTReportGroup
        {
            public SubCashOfficeRevenueReport MyParentReport
            {
                get { return (SubCashOfficeRevenueReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTD HEADER_Script
                    // Açıklamaya göre sıralar
            ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList.Sort(new AscBranchComparer());
            
            if(((SubCashOfficeRevenueReport)ParentReport).GKBVar == true)
            {
                string aciklama = "Gelir Kalemine Ulaşılamayan Hizmetler";
                if(!string.IsNullOrEmpty(((SubCashOfficeRevenueReport)ParentReport).GKBAciklama))
                {
                    aciklama += "\r\n(" + ((SubCashOfficeRevenueReport)ParentReport).GKBAciklama;
                    aciklama = aciklama.Substring(0, aciklama.Length - 2) + ")";
                }
                
                ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(aciklama, ((SubCashOfficeRevenueReport)ParentReport).GKBToplamGelir));
                ((SubCashOfficeRevenueReport)ParentReport).Sayac ++;
            }
            
            ((SubCashOfficeRevenueReport)ParentReport).MAIN.RepeatCount = ((SubCashOfficeRevenueReport)ParentReport).Sayac;
#endregion PARTD HEADER_Script
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportShape NewLine111111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 197, 3, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 4, 169, 9, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 4, 197, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 42, 9, false);
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

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public SubCashOfficeRevenueReport MyParentReport
            {
                get { return (SubCashOfficeRevenueReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1182 { get {return Header().NewField1182;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField1183 { get {return Header().NewField1183;} }
            public TTReportField CLOSINGDATE { get {return Header().CLOSINGDATE;} }
            public TTReportField CASHIERLOGID { get {return Header().CASHIERLOGID;} }
            public TTReportShape NewLine111111111 { get {return Footer().NewLine111111111;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
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
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportField NewField13;
                public TTReportField OPENINGDATE;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField181;
                public TTReportField NewField1181;
                public TTReportField CASHOFFICE;
                public TTReportField NewField171;
                public TTReportField NewField172;
                public TTReportShape NewLine1;
                public TTReportField NewField161;
                public TTReportField NewField1182;
                public TTReportField NewField162;
                public TTReportField NewField1183;
                public TTReportField CLOSINGDATE;
                public TTReportField CASHIERLOGID; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 197, 19, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"MUHASEBE YETKİLİSİ MUTEMETLİĞİ GELİR KALEMLERİ RAPORU";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 26, 91, 31, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"dd/MM/yyyy";
                    OPENINGDATE.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 26, 48, 31, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Açılış Tarihi";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 36, 48, 41, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Muh. Yetkilisi Mutemetliği";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 26, 51, 31, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 36, 51, 41, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 36, 197, 41, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 45, 158, 50, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Gelir Kalemi";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 45, 197, 50, false);
                    NewField172.Name = "NewField172";
                    NewField172.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField172.TextFont.Bold = true;
                    NewField172.TextFont.CharSet = 162;
                    NewField172.Value = @"Tutar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 51, 197, 51, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 48, 26, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Açılış İz Sürme No";

                    NewField1182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 21, 51, 26, false);
                    NewField1182.Name = "NewField1182";
                    NewField1182.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1182.TextFont.Bold = true;
                    NewField1182.TextFont.CharSet = 162;
                    NewField1182.Value = @":";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 31, 48, 36, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"Kapanış Tarihi";

                    NewField1183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 31, 51, 36, false);
                    NewField1183.Name = "NewField1183";
                    NewField1183.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1183.TextFont.Bold = true;
                    NewField1183.TextFont.CharSet = 162;
                    NewField1183.Value = @":";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 31, 91, 36, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"dd/MM/yyyy";
                    CLOSINGDATE.Value = @"";

                    CASHIERLOGID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 21, 91, 26, false);
                    CASHIERLOGID.Name = "CASHIERLOGID";
                    CASHIERLOGID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERLOGID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13.CalcValue = NewField13.Value;
                    OPENINGDATE.CalcValue = @"";
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    CASHOFFICE.CalcValue = @"";
                    NewField171.CalcValue = NewField171.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1182.CalcValue = NewField1182.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField1183.CalcValue = NewField1183.Value;
                    CLOSINGDATE.CalcValue = @"";
                    CASHIERLOGID.CalcValue = @"";
                    return new TTReportObject[] { NewField13,OPENINGDATE,NewField16,NewField17,NewField181,NewField1181,CASHOFFICE,NewField171,NewField172,NewField161,NewField1182,NewField162,NewField1183,CLOSINGDATE,CASHIERLOGID};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SubCashOfficeRevenueReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CashOfficeClosing coClosing = (CashOfficeClosing)context.GetObject(new Guid(sObjectID), typeof(CashOfficeClosing));
            
            if(coClosing != null && coClosing.CashierLog != null)
            {
                if(coClosing.CashierLog.LogID.Value.HasValue)
                    this.CASHIERLOGID.CalcValue = coClosing.CashierLog.LogID.Value.ToString();
                
                if(coClosing.CashierLog.OpeningDate.HasValue)
                    this.OPENINGDATE.CalcValue = coClosing.CashierLog.OpeningDate.Value.ToString();

                if(coClosing.CashierLog.ClosingDate.HasValue)
                    this.CLOSINGDATE.CalcValue = coClosing.CashierLog.ClosingDate.Value.ToString();
                
                if (coClosing.CashierLog.CashOffice != null)
                    this.CASHOFFICE.CalcValue = coClosing.CashierLog.CashOffice.Qref + " " + coClosing.CashierLog.CashOffice.Name;
                
                if(coClosing.CashierLog.ResUser != null)
                {
                    TTUser ttUser = coClosing.CashierLog.ResUser.GetMyTTUser();
                    if(ttUser != null && !string.IsNullOrEmpty(ttUser.Name))
                        this.CASHOFFICE.CalcValue = this.CASHOFFICE.CalcValue + " - " + ttUser.Name;
                }
            }
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportShape NewLine111111111;
                public TTReportField GENELTOPLAM;
                public TTReportField TOPLAMTUTAR; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 197, 1, false);
                    NewLine111111111.Name = "NewLine111111111";
                    NewLine111111111.DrawStyle = DrawStyleConstants.vbSolid;

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 158, 8, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.TextFont.Bold = true;
                    GENELTOPLAM.TextFont.CharSet = 162;
                    GENELTOPLAM.Value = @"Toplam";

                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 3, 197, 8, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GENELTOPLAM.CalcValue = GENELTOPLAM.Value;
                    TOPLAMTUTAR.CalcValue = @"";
                    return new TTReportObject[] { GENELTOPLAM,TOPLAMTUTAR};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    this.TOPLAMTUTAR.CalcValue = ((SubCashOfficeRevenueReport)ParentReport).ToplamGelir.ToString();
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public SubCashOfficeRevenueReport MyParentReport
            {
                get { return (SubCashOfficeRevenueReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField GELIRKALEMI { get {return Body().GELIRKALEMI;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
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
                public SubCashOfficeRevenueReport MyParentReport
                {
                    get { return (SubCashOfficeRevenueReport)ParentReport; }
                }
                
                public TTReportField GELIRKALEMI;
                public TTReportField TUTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    GELIRKALEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 158, 6, false);
                    GELIRKALEMI.Name = "GELIRKALEMI";
                    GELIRKALEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELIRKALEMI.MultiLine = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.NoClip = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.WordBreak = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.Value = @"";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 197, 6, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GELIRKALEMI.CalcValue = @"";
                    TUTAR.CalcValue = @"";
                    return new TTReportObject[] { GELIRKALEMI,TUTAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(((SubCashOfficeRevenueReport)ParentReport).Sayac > 0)
            {
                this.GELIRKALEMI.CalcValue = ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList[((SubCashOfficeRevenueReport)ParentReport).yazdirmaSayac].Aciklama;
                this.TUTAR.CalcValue = ((SubCashOfficeRevenueReport)ParentReport).gelirKalemiList[((SubCashOfficeRevenueReport)ParentReport).yazdirmaSayac].Gelir.ToString();
                
                ((SubCashOfficeRevenueReport)ParentReport).ToplamGelir += Convert.ToDouble(this.TUTAR.FormattedValue);
                ((SubCashOfficeRevenueReport)ParentReport).yazdirmaSayac ++;
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

        public SubCashOfficeRevenueReport()
        {
            PARTE = new PARTEGroup(this,"PARTE");
            PARTA = new PARTAGroup(PARTE,"PARTA");
            PARTB = new PARTBGroup(PARTE,"PARTB");
            PARTD = new PARTDGroup(this,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SUBCASHOFFICEREVENUEREPORT";
            Caption = "Muhasebe Yetkilisi Mutemetliği Gelir Kalemleri Raporu";
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

    }
}