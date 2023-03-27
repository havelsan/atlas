
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
    /// Ayrıntılı Gelir Kalemleri Listesi
    /// </summary>
    public partial class DetailedRevenueListReport : TTReport
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
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTFGroup : TTReportGroup
        {
            public DetailedRevenueListReport MyParentReport
            {
                get { return (DetailedRevenueListReport)ParentReport; }
            }

            new public PARTFGroupBody Body()
            {
                return (PARTFGroupBody)_body;
            }
            public TTReportField PATIENTPRICE { get {return Body().PATIENTPRICE;} }
            public TTReportField PAYERPRICE { get {return Body().PAYERPRICE;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
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
                list[0] = new TTReportNqlData<AccountTransaction.DetailedRevenueListMaterialQuery_Class>("DetailedRevenueListMaterialQuery2", AccountTransaction.DetailedRevenueListMaterialQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
                }
                
                public TTReportField PATIENTPRICE;
                public TTReportField PAYERPRICE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
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

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 35, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 63, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.DetailedRevenueListMaterialQuery_Class dataset_DetailedRevenueListMaterialQuery2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.DetailedRevenueListMaterialQuery_Class>(0);
                    PATIENTPRICE.CalcValue = (dataset_DetailedRevenueListMaterialQuery2 != null ? Globals.ToStringCore(dataset_DetailedRevenueListMaterialQuery2.Patientprice) : "");
                    PAYERPRICE.CalcValue = (dataset_DetailedRevenueListMaterialQuery2 != null ? Globals.ToStringCore(dataset_DetailedRevenueListMaterialQuery2.Payerprice) : "");
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { PATIENTPRICE,PAYERPRICE,STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTF BODY_Script
                    ((DetailedRevenueListReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((DetailedRevenueListReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            if (this.PAYERPRICE.CalcValue == "")
                this.PAYERPRICE.CalcValue = "0";
            
            if (this.PATIENTPRICE.CalcValue == "")
                this.PATIENTPRICE.CalcValue = "0";
            
            if(Convert.ToDouble(this.PAYERPRICE.CalcValue) > 0 || Convert.ToDouble(this.PATIENTPRICE.CalcValue) > 0)
            {
                string revenueName = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
                bool GKFound = false;
                
                foreach(GelirKalemi GK in ((DetailedRevenueListReport)ParentReport).gelirKalemiList)
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
                    ((DetailedRevenueListReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(revenueName, Convert.ToDouble(this.PAYERPRICE.CalcValue), Convert.ToDouble(this.PATIENTPRICE.CalcValue)));
                    ((DetailedRevenueListReport)ParentReport).Sayac += 1;
                }
            }
#endregion PARTF BODY_Script
                }
            }

        }

        public PARTFGroup PARTF;

        public partial class MAINGroup : TTReportGroup
        {
            public DetailedRevenueListReport MyParentReport
            {
                get { return (DetailedRevenueListReport)ParentReport; }
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
                list[0] = new TTReportNqlData<AccountTransaction.DetailedRevenueListProcedureQuery_Class>("DetailedRevenueListProcedureQuery", AccountTransaction.DetailedRevenueListProcedureQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
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
                    AccountTransaction.DetailedRevenueListProcedureQuery_Class dataset_DetailedRevenueListProcedureQuery = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.DetailedRevenueListProcedureQuery_Class>(0);
                    PROCEDURE.CalcValue = (dataset_DetailedRevenueListProcedureQuery != null ? Globals.ToStringCore(dataset_DetailedRevenueListProcedureQuery.Procedure) : "");
                    PATIENTPRICE.CalcValue = (dataset_DetailedRevenueListProcedureQuery != null ? Globals.ToStringCore(dataset_DetailedRevenueListProcedureQuery.Patientprice) : "");
                    PAYERPRICE.CalcValue = (dataset_DetailedRevenueListProcedureQuery != null ? Globals.ToStringCore(dataset_DetailedRevenueListProcedureQuery.Payerprice) : "");
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
                    ((DetailedRevenueListReport)ParentReport).GKBVar = true;
                    ((DetailedRevenueListReport)ParentReport).GKBToplamKurumGelir += Convert.ToDouble(this.PAYERPRICE.CalcValue);
                    ((DetailedRevenueListReport)ParentReport).GKBToplamKisiGelir += Convert.ToDouble(this.PATIENTPRICE.CalcValue);
                }
                else  // Gelir kalemine ulaşılmışsa listeye ekleniyor
                {
                    bool GKFound = false;
                    
                    foreach(GelirKalemi GK in ((DetailedRevenueListReport)ParentReport).gelirKalemiList)
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
                        ((DetailedRevenueListReport)ParentReport).gelirKalemiList.Add(new GelirKalemi(revenueName, Convert.ToDouble(this.PAYERPRICE.CalcValue), Convert.ToDouble(this.PATIENTPRICE.CalcValue)));
                        ((DetailedRevenueListReport)ParentReport).Sayac += 1;
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
            public DetailedRevenueListReport MyParentReport
            {
                get { return (DetailedRevenueListReport)ParentReport; }
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
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
                    if(((DetailedRevenueListReport)ParentReport).GKBVar == true)
            {
                ((DetailedRevenueListReport)ParentReport).gelirKalemiList.Add(new GelirKalemi("Gelir Kalemine Ulaşılamayan Hizmetler", ((DetailedRevenueListReport)ParentReport).GKBToplamKurumGelir, ((DetailedRevenueListReport)ParentReport).GKBToplamKisiGelir));
                ((DetailedRevenueListReport)ParentReport).Sayac += 1;
            }
            
            ((DetailedRevenueListReport)ParentReport).PARTC.RepeatCount = ((DetailedRevenueListReport)ParentReport).Sayac;
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTEGroup : TTReportGroup
        {
            public DetailedRevenueListReport MyParentReport
            {
                get { return (DetailedRevenueListReport)ParentReport; }
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
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
            public DetailedRevenueListReport MyParentReport
            {
                get { return (DetailedRevenueListReport)ParentReport; }
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
            public TTReportField KISIGELIR { get {return Header().KISIGELIR;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportShape NewLine11111111 { get {return Footer().NewLine11111111;} }
            public TTReportField GENELTOPLAM { get {return Footer().GENELTOPLAM;} }
            public TTReportField KURUMTOPLAM { get {return Footer().KURUMTOPLAM;} }
            public TTReportField KISITOPLAM { get {return Footer().KISITOPLAM;} }
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
                }
                
                public TTReportField GELIRKALEMI;
                public TTReportField KURUMGELIR;
                public TTReportField KISIGELIR;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField STARTDATE;
                public TTReportField NewField11211;
                public TTReportField ENDDATE;
                public TTReportField NewField112211;
                public TTReportField NewField1112211;
                public TTReportShape NewLine1111111; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    GELIRKALEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 36, 110, 41, false);
                    GELIRKALEMI.Name = "GELIRKALEMI";
                    GELIRKALEMI.MultiLine = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.NoClip = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.WordBreak = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.TextFont.Bold = true;
                    GELIRKALEMI.TextFont.CharSet = 162;
                    GELIRKALEMI.Value = @"GELİR KALEMİ";

                    KURUMGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 36, 150, 41, false);
                    KURUMGELIR.Name = "KURUMGELIR";
                    KURUMGELIR.TextFormat = @"#,##0.#0";
                    KURUMGELIR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMGELIR.TextFont.Bold = true;
                    KURUMGELIR.TextFont.CharSet = 162;
                    KURUMGELIR.Value = @"GELİR MİKTARI (Kurum)";

                    KISIGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 36, 187, 41, false);
                    KISIGELIR.Name = "KISIGELIR";
                    KISIGELIR.TextFormat = @"#,##0.#0";
                    KISIGELIR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KISIGELIR.TextFont.Bold = true;
                    KISIGELIR.TextFont.CharSet = 162;
                    KISIGELIR.Value = @"GELİR MİKTARI (Kişi)";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 14, 187, 20, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"AYRINTILI GELİR KALEMLERİ LİSTESİ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 23, 38, 28, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 23, 77, 28, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 28, 38, 33, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 28, 77, 33, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 40, 33, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 23, 40, 28, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 42, 187, 42, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GELIRKALEMI.CalcValue = GELIRKALEMI.Value;
                    KURUMGELIR.CalcValue = KURUMGELIR.Value;
                    KISIGELIR.CalcValue = KISIGELIR.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11211.CalcValue = NewField11211.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    return new TTReportObject[] { GELIRKALEMI,KURUMGELIR,KISIGELIR,NewField1111,NewField1121,STARTDATE,NewField11211,ENDDATE,NewField112211,NewField1112211};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111111;
                public TTReportField GENELTOPLAM;
                public TTReportField KURUMTOPLAM;
                public TTReportField KISITOPLAM; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 2, 187, 2, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 110, 9, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.Value = @"GENEL TOPLAM";

                    KURUMTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 4, 150, 9, false);
                    KURUMTOPLAM.Name = "KURUMTOPLAM";
                    KURUMTOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMTOPLAM.TextFormat = @"#,##0.#0";
                    KURUMTOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMTOPLAM.Value = @"";

                    KISITOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 4, 187, 9, false);
                    KISITOPLAM.Name = "KISITOPLAM";
                    KISITOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KISITOPLAM.TextFormat = @"#,##0.#0";
                    KISITOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KISITOPLAM.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GENELTOPLAM.CalcValue = GENELTOPLAM.Value;
                    KURUMTOPLAM.CalcValue = @"";
                    KISITOPLAM.CalcValue = @"";
                    return new TTReportObject[] { GENELTOPLAM,KURUMTOPLAM,KISITOPLAM};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    this.KURUMTOPLAM.CalcValue = ((DetailedRevenueListReport)ParentReport).ToplamKurumGelir.ToString();
            this.KISITOPLAM.CalcValue = ((DetailedRevenueListReport)ParentReport).ToplamKisiGelir.ToString();
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public DetailedRevenueListReport MyParentReport
            {
                get { return (DetailedRevenueListReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField GELIRKALEMI { get {return Body().GELIRKALEMI;} }
            public TTReportField KURUMGELIR { get {return Body().KURUMGELIR;} }
            public TTReportField KISIGELIR { get {return Body().KISIGELIR;} }
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
                public DetailedRevenueListReport MyParentReport
                {
                    get { return (DetailedRevenueListReport)ParentReport; }
                }
                
                public TTReportField GELIRKALEMI;
                public TTReportField KURUMGELIR;
                public TTReportField KISIGELIR; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    GELIRKALEMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 110, 6, false);
                    GELIRKALEMI.Name = "GELIRKALEMI";
                    GELIRKALEMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELIRKALEMI.MultiLine = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.NoClip = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.WordBreak = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    GELIRKALEMI.Value = @"";

                    KURUMGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 150, 6, false);
                    KURUMGELIR.Name = "KURUMGELIR";
                    KURUMGELIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMGELIR.TextFormat = @"#,##0.#0";
                    KURUMGELIR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMGELIR.Value = @"";

                    KISIGELIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 1, 187, 6, false);
                    KISIGELIR.Name = "KISIGELIR";
                    KISIGELIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KISIGELIR.TextFormat = @"#,##0.#0";
                    KISIGELIR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KISIGELIR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GELIRKALEMI.CalcValue = @"";
                    KURUMGELIR.CalcValue = @"";
                    KISIGELIR.CalcValue = @"";
                    return new TTReportObject[] { GELIRKALEMI,KURUMGELIR,KISIGELIR};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    if(((DetailedRevenueListReport)ParentReport).Sayac > 0)
            {
                this.GELIRKALEMI.CalcValue = ((DetailedRevenueListReport)ParentReport).gelirKalemiList[((DetailedRevenueListReport)ParentReport).yazdirmaSayac].Aciklama;
                this.KURUMGELIR.CalcValue = ((DetailedRevenueListReport)ParentReport).gelirKalemiList[((DetailedRevenueListReport)ParentReport).yazdirmaSayac].KurumGelir.ToString();
                this.KISIGELIR.CalcValue = ((DetailedRevenueListReport)ParentReport).gelirKalemiList[((DetailedRevenueListReport)ParentReport).yazdirmaSayac].KisiGelir.ToString();
               
                ((DetailedRevenueListReport)ParentReport).ToplamKurumGelir += Convert.ToDouble(this.KURUMGELIR.FormattedValue);
                ((DetailedRevenueListReport)ParentReport).ToplamKisiGelir += Convert.ToDouble(this.KISIGELIR.FormattedValue);

                ((DetailedRevenueListReport)ParentReport).yazdirmaSayac += 1;
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

        public DetailedRevenueListReport()
        {
            PARTF = new PARTFGroup(this,"PARTF");
            MAIN = new MAINGroup(this,"MAIN");
            PARTA = new PARTAGroup(this,"PARTA");
            PARTE = new PARTEGroup(this,"PARTE");
            PARTD = new PARTDGroup(PARTE,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "DETAILEDREVENUELISTREPORT";
            Caption = "Ayrıntılı Gelir Kalemleri Listesi";
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
#region DETAILEDREVENUELISTREPORT_PreScript
            gelirKalemiList.Clear();
            
            ToplamKurumGelir = 0;
            ToplamKisiGelir = 0;
            Sayac = 0;
            yazdirmaSayac = 0;
            
            GKBVar = false;              
            GKBToplamKurumGelir = 0;   
            GKBToplamKisiGelir = 0;
#endregion DETAILEDREVENUELISTREPORT_PreScript
        }
    }
}