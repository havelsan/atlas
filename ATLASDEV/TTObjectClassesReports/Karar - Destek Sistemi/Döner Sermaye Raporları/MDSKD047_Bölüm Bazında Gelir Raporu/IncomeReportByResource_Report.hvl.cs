
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
    /// Bölüm Bazında Gelir Raporu
    /// </summary>
    public partial class IncomeReportByResource : TTReport
    {
#region Methods
   public class BolumGeliri
        {
            public string bolumAdi;
            public double kurumGeliri, sivilGeliri, toplamGelir;
            
            public BolumGeliri()
            {
                bolumAdi = "";
                kurumGeliri = 0;
                sivilGeliri = 0;
                toplamGelir = 0;
            }
        }
        
        public int yazdirmaSayac = 0;
        public double toplamKurumGeliri = 0;
        public double toplamSivilGeliri = 0;
        
        public List<BolumGeliri> bolumGeliriBilgisi = new List<BolumGeliri>();

        public class AscBranchComparer : IComparer<BolumGeliri>
        {
            #region IComparer<LotoItem> Members
            public int Compare(BolumGeliri x, BolumGeliri y)
            {
                return (x.bolumAdi.CompareTo(y.bolumAdi)); // artan sıra ile sıralayan Compare
            }
            #endregion
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<Guid> DEPARTMENT = new List<Guid>();
            public int? DEPARTMENTFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public IncomeReportByResource MyParentReport
            {
                get { return (IncomeReportByResource)ParentReport; }
            }

            new public MASTERGroupHeader Header()
            {
                return (MASTERGroupHeader)_header;
            }

            new public MASTERGroupFooter Footer()
            {
                return (MASTERGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public MASTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MASTERGroupHeader(this);
                _footer = new MASTERGroupFooter(this);

            }

            public partial class MASTERGroupHeader : TTReportSection
            {
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 30, 6, false);
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 58, 6, false);
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
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region MASTER HEADER_Script
                    ((IncomeReportByResource)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((IncomeReportByResource)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            if(((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENT == null)
                ((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG = 0;
            else
                ((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG = 1;

            Dictionary<string, BolumGeliri> bolumGeliriBilgisi = new Dictionary<string,BolumGeliri>();
            List<BolumGeliri> bolumGeliriList = new List<BolumGeliri>();
            
            BindingList<AccountTransaction.GetProcedureIncomesByMasterResource_Class> piMasterResourceList = AccountTransaction.GetProcedureIncomesByMasterResource(((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENT, (int)((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG,(DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.ENDDATE);
            BindingList<AccountTransaction.GetProcedureIncomesByRessection_Class> piRessectionList = AccountTransaction.GetProcedureIncomesByRessection(((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENT, (int)((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG,(DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.ENDDATE);
            BindingList<AccountTransaction.GetMaterialIncomesByMasterResource_Class> miMasterResourceList = AccountTransaction.GetMaterialIncomesByMasterResource(((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENT, (int)((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG,(DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.ENDDATE);
            BindingList<AccountTransaction.GetMaterialIncomesByRessection_Class> miRessectionList = AccountTransaction.GetMaterialIncomesByRessection(((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENT, (int)((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG,(DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.ENDDATE);
            BindingList<AccountTransaction.GetDrugIncomesByRessection_Class> diRessectionList = AccountTransaction.GetDrugIncomesByRessection(((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENT, (int)((IncomeReportByResource)ParentReport).RuntimeParameters.DEPARTMENTFLAG,(DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((IncomeReportByResource)ParentReport).RuntimeParameters.ENDDATE);
            
            if(piMasterResourceList.Count > 0)
            {
                foreach(AccountTransaction.GetProcedureIncomesByMasterResource_Class piMasterResource in piMasterResourceList)
                {
                    if(bolumGeliriBilgisi.ContainsKey(piMasterResource.Depobjectid.ToString()))
                    {
                        BolumGeliri bolumGeliri = bolumGeliriBilgisi[piMasterResource.Depobjectid.ToString()];
                        if(piMasterResource.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri += Convert.ToDouble(piMasterResource.Totalprice);
                        else if(piMasterResource.Type == APRTypeEnum.PAYER)// Kurum Payı
                            bolumGeliri.kurumGeliri += Convert.ToDouble(piMasterResource.Totalprice);
                        bolumGeliri.toplamGelir += Convert.ToDouble(piMasterResource.Totalprice);
                    }
                    else
                    {
                        BolumGeliri bolumGeliri = new BolumGeliri();
                        bolumGeliri.bolumAdi = piMasterResource.Department;
                        if(piMasterResource.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri = Convert.ToDouble(piMasterResource.Totalprice);
                        else if(piMasterResource.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri = Convert.ToDouble(piMasterResource.Totalprice);
                        bolumGeliri.toplamGelir = Convert.ToDouble(piMasterResource.Totalprice);
                        bolumGeliriBilgisi.Add(piMasterResource.Depobjectid.ToString(),bolumGeliri);
                    }
                }
            }
            
            if(piRessectionList.Count > 0)
            {
                foreach(AccountTransaction.GetProcedureIncomesByRessection_Class piRessection in piRessectionList)
                {
                    if(bolumGeliriBilgisi.ContainsKey(piRessection.Depobjectid.ToString()))
                    {
                        BolumGeliri bolumGeliri = bolumGeliriBilgisi[piRessection.Depobjectid.ToString()];
                        if(piRessection.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri += Convert.ToDouble(piRessection.Totalprice);
                        else if(piRessection.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri += Convert.ToDouble(piRessection.Totalprice);
                        bolumGeliri.toplamGelir += Convert.ToDouble(piRessection.Totalprice);
                    }
                    else
                    {
                        BolumGeliri bolumGeliri = new BolumGeliri();
                        bolumGeliri.bolumAdi = piRessection.Department;
                        if(piRessection.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri = Convert.ToDouble(piRessection.Totalprice);
                        else if(piRessection.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri = Convert.ToDouble(piRessection.Totalprice);
                        bolumGeliri.toplamGelir = Convert.ToDouble(piRessection.Totalprice);
                        bolumGeliriBilgisi.Add(piRessection.Depobjectid.ToString(),bolumGeliri);
                    }
                }
            }
            
            if(miMasterResourceList.Count > 0)
            {
                foreach(AccountTransaction.GetMaterialIncomesByMasterResource_Class miMasterResource in miMasterResourceList)
                {
                    if(bolumGeliriBilgisi.ContainsKey(miMasterResource.Depobjectid.ToString()))
                    {
                        BolumGeliri bolumGeliri = bolumGeliriBilgisi[miMasterResource.Depobjectid.ToString()];
                        if(miMasterResource.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri += Convert.ToDouble(miMasterResource.Totalprice);
                        else if(miMasterResource.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri += Convert.ToDouble(miMasterResource.Totalprice);
                        bolumGeliri.toplamGelir += Convert.ToDouble(miMasterResource.Totalprice);
                    }
                    else
                    {
                        BolumGeliri bolumGeliri = new BolumGeliri();
                        bolumGeliri.bolumAdi = miMasterResource.Department;
                        if(miMasterResource.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri = Convert.ToDouble(miMasterResource.Totalprice);
                        else if(miMasterResource.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri = Convert.ToDouble(miMasterResource.Totalprice);
                        bolumGeliri.toplamGelir = Convert.ToDouble(miMasterResource.Totalprice);
                        bolumGeliriBilgisi.Add(miMasterResource.Depobjectid.ToString(),bolumGeliri);
                    }
                }
            }
            
            if(miRessectionList.Count > 0)
            {
                foreach(AccountTransaction.GetMaterialIncomesByRessection_Class miRessection in miRessectionList)
                {
                    if(bolumGeliriBilgisi.ContainsKey(miRessection.Depobjectid.ToString()))
                    {
                        BolumGeliri bolumGeliri = bolumGeliriBilgisi[miRessection.Depobjectid.ToString()];
                        if(miRessection.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri += Convert.ToDouble(miRessection.Totalprice);
                        else if(miRessection.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri += Convert.ToDouble(miRessection.Totalprice);
                        bolumGeliri.toplamGelir += Convert.ToDouble(miRessection.Totalprice);
                    }
                    else
                    {
                        BolumGeliri bolumGeliri = new BolumGeliri();
                        bolumGeliri.bolumAdi = miRessection.Department;
                        if(miRessection.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri = Convert.ToDouble(miRessection.Totalprice);
                        else if(miRessection.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri = Convert.ToDouble(miRessection.Totalprice);
                        bolumGeliri.toplamGelir = Convert.ToDouble(miRessection.Totalprice);
                        bolumGeliriBilgisi.Add(miRessection.Depobjectid.ToString(),bolumGeliri);
                    }
                }
            }
            
            if(diRessectionList.Count > 0)
            {
                foreach(AccountTransaction.GetDrugIncomesByRessection_Class diRessection in diRessectionList)
                {
                    if(bolumGeliriBilgisi.ContainsKey(diRessection.Depobjectid.ToString()))
                    {
                        BolumGeliri bolumGeliri = bolumGeliriBilgisi[diRessection.Depobjectid.ToString()];
                        if(diRessection.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri += Convert.ToDouble(diRessection.Totalprice);
                        else if(diRessection.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri += Convert.ToDouble(diRessection.Totalprice);
                        bolumGeliri.toplamGelir += Convert.ToDouble(diRessection.Totalprice);
                    }
                    else
                    {
                        BolumGeliri bolumGeliri = new BolumGeliri();
                        bolumGeliri.bolumAdi = diRessection.Department.ToString();
                        if(diRessection.Type == APRTypeEnum.PATIENT) // Hasta Payı
                            bolumGeliri.sivilGeliri = Convert.ToDouble(diRessection.Totalprice);
                        else if(diRessection.Type == APRTypeEnum.PAYER) // Kurum Payı
                            bolumGeliri.kurumGeliri = Convert.ToDouble(diRessection.Totalprice);
                        bolumGeliri.toplamGelir = Convert.ToDouble(diRessection.Totalprice);
                        bolumGeliriBilgisi.Add(diRessection.Depobjectid.ToString(),bolumGeliri);
                    }
                }
            }
            
            foreach(BolumGeliri bolumGeliri in bolumGeliriBilgisi.Values)
            {
                bolumGeliriList.Add(bolumGeliri);
            }
            ((IncomeReportByResource)ParentReport).bolumGeliriBilgisi = bolumGeliriList;
            ((IncomeReportByResource)ParentReport).bolumGeliriBilgisi.Sort(new AscBranchComparer());
            ((IncomeReportByResource)ParentReport).MAIN.RepeatCount = bolumGeliriList.Count;
#endregion MASTER HEADER_Script
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                 
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MASTERGroup MASTER;

        public partial class PARTAGroup : TTReportGroup
        {
            public IncomeReportByResource MyParentReport
            {
                get { return (IncomeReportByResource)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField RAPORBASLIK { get {return Header().RAPORBASLIK;} }
            public TTReportField NewField12111111 { get {return Header().NewField12111111;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1121111111 { get {return Header().NewField1121111111;} }
            public TTReportField BOLUM1 { get {return Header().BOLUM1;} }
            public TTReportField BOLUM111 { get {return Header().BOLUM111;} }
            public TTReportField BOLUM112 { get {return Header().BOLUM112;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField BOLUM1111 { get {return Header().BOLUM1111;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                
                public TTReportField RAPORBASLIK;
                public TTReportField NewField12111111;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField1121111111;
                public TTReportField BOLUM1;
                public TTReportField BOLUM111;
                public TTReportField BOLUM112;
                public TTReportShape NewLine1;
                public TTReportField BOLUM1111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 203, 13, false);
                    RAPORBASLIK.Name = "RAPORBASLIK";
                    RAPORBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORBASLIK.TextFont.Name = "Arial";
                    RAPORBASLIK.TextFont.Bold = true;
                    RAPORBASLIK.TextFont.CharSet = 162;
                    RAPORBASLIK.Value = @"BÖLÜM BAZINDA GELİR RAPORU";

                    NewField12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 24, 19, false);
                    NewField12111111.Name = "NewField12111111";
                    NewField12111111.TextFont.Bold = true;
                    NewField12111111.TextFont.CharSet = 162;
                    NewField12111111.Value = @"Tarih:";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 14, 41, 19, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Bold = true;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 14, 63, 19, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Bold = true;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField1121111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 14, 46, 19, false);
                    NewField1121111111.Name = "NewField1121111111";
                    NewField1121111111.TextFormat = @"Short Date";
                    NewField1121111111.TextFont.Bold = true;
                    NewField1121111111.TextFont.CharSet = 162;
                    NewField1121111111.Value = @"-";

                    BOLUM1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 83, 27, false);
                    BOLUM1.Name = "BOLUM1";
                    BOLUM1.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM1.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM1.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM1.TextFont.Name = "Arial";
                    BOLUM1.TextFont.Size = 8;
                    BOLUM1.TextFont.Bold = true;
                    BOLUM1.TextFont.CharSet = 162;
                    BOLUM1.Value = @"BÖLÜM";

                    BOLUM111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 22, 166, 27, false);
                    BOLUM111.Name = "BOLUM111";
                    BOLUM111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BOLUM111.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM111.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM111.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM111.TextFont.Name = "Arial";
                    BOLUM111.TextFont.Size = 8;
                    BOLUM111.TextFont.Bold = true;
                    BOLUM111.TextFont.CharSet = 162;
                    BOLUM111.Value = @"SİVİL GELİRİ";

                    BOLUM112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 22, 203, 27, false);
                    BOLUM112.Name = "BOLUM112";
                    BOLUM112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BOLUM112.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM112.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM112.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM112.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM112.TextFont.Name = "Arial";
                    BOLUM112.TextFont.Size = 8;
                    BOLUM112.TextFont.Bold = true;
                    BOLUM112.TextFont.CharSet = 162;
                    BOLUM112.Value = @"TOPLAM";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 29, 203, 29, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    BOLUM1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 22, 125, 27, false);
                    BOLUM1111.Name = "BOLUM1111";
                    BOLUM1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BOLUM1111.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM1111.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM1111.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM1111.TextFont.Name = "Arial";
                    BOLUM1111.TextFont.Size = 8;
                    BOLUM1111.TextFont.Bold = true;
                    BOLUM1111.TextFont.CharSet = 162;
                    BOLUM1111.Value = @"KURUM GELİRİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RAPORBASLIK.CalcValue = RAPORBASLIK.Value;
                    NewField12111111.CalcValue = NewField12111111.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField1121111111.CalcValue = NewField1121111111.Value;
                    BOLUM1.CalcValue = BOLUM1.Value;
                    BOLUM111.CalcValue = BOLUM111.Value;
                    BOLUM112.CalcValue = BOLUM112.Value;
                    BOLUM1111.CalcValue = BOLUM1111.Value;
                    return new TTReportObject[] { RAPORBASLIK,NewField12111111,STARTDATE,ENDDATE,NewField1121111111,BOLUM1,BOLUM111,BOLUM112,BOLUM1111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                
                public TTReportShape NewLine1111111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 203, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 2, 141, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 2, 203, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 41, 7, false);
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

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public IncomeReportByResource MyParentReport
            {
                get { return (IncomeReportByResource)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField GTOPLAM { get {return Footer().GTOPLAM;} }
            public TTReportField KURUMGELIRI { get {return Footer().KURUMGELIRI;} }
            public TTReportField SIVILGELIRI { get {return Footer().SIVILGELIRI;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                
                public TTReportField GTOPLAM;
                public TTReportField KURUMGELIRI;
                public TTReportField SIVILGELIRI;
                public TTReportField TOPLAM;
                public TTReportShape NewLine11; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                    GTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 83, 7, false);
                    GTOPLAM.Name = "GTOPLAM";
                    GTOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    GTOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    GTOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    GTOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    GTOPLAM.TextFont.Name = "Arial";
                    GTOPLAM.TextFont.Size = 8;
                    GTOPLAM.TextFont.Bold = true;
                    GTOPLAM.TextFont.CharSet = 162;
                    GTOPLAM.Value = @"GENEL TOPLAM :";

                    KURUMGELIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 2, 125, 7, false);
                    KURUMGELIRI.Name = "KURUMGELIRI";
                    KURUMGELIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMGELIRI.TextFormat = @"#,##0.#0";
                    KURUMGELIRI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMGELIRI.Value = @"{@sumof(KURUMGELIRI)@}";

                    SIVILGELIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 2, 166, 7, false);
                    SIVILGELIRI.Name = "SIVILGELIRI";
                    SIVILGELIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIVILGELIRI.TextFormat = @"#,##0.#0";
                    SIVILGELIRI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SIVILGELIRI.Value = @"{@sumof(SIVILGELIRI)@}";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 2, 203, 7, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 203, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GTOPLAM.CalcValue = GTOPLAM.Value;
                    KURUMGELIRI.CalcValue = ParentGroup.FieldSums["KURUMGELIRI"].Value.ToString();;
                    SIVILGELIRI.CalcValue = ParentGroup.FieldSums["SIVILGELIRI"].Value.ToString();;
                    TOPLAM.CalcValue = @"";
                    return new TTReportObject[] { GTOPLAM,KURUMGELIRI,SIVILGELIRI,TOPLAM};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    //this.TOPLAM.CalcValue=(Convert.ToDouble(this.KURUMGELIRI.CalcValue) + Convert.ToDouble(this.SIVILGELIRI.CalcValue)).ToString();   
            
            this.KURUMGELIRI.CalcValue = (((IncomeReportByResource)ParentReport).toplamKurumGeliri).ToString();
            this.SIVILGELIRI.CalcValue = (((IncomeReportByResource)ParentReport).toplamSivilGeliri).ToString();
            this.TOPLAM.CalcValue = (Convert.ToDouble(this.KURUMGELIRI.CalcValue) + Convert.ToDouble(this.SIVILGELIRI.CalcValue)).ToString();
            
            ((IncomeReportByResource)ParentReport).toplamKurumGeliri = 0;
            ((IncomeReportByResource)ParentReport).toplamSivilGeliri = 0;
            ((IncomeReportByResource)ParentReport).yazdirmaSayac = 0;
            (((IncomeReportByResource)ParentReport).bolumGeliriBilgisi).Clear();
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public IncomeReportByResource MyParentReport
            {
                get { return (IncomeReportByResource)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BOLUM { get {return Body().BOLUM;} }
            public TTReportField KURUMGELIRI { get {return Body().KURUMGELIRI;} }
            public TTReportField SIVILGELIRI { get {return Body().SIVILGELIRI;} }
            public TTReportField TOPLAM { get {return Body().TOPLAM;} }
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
                public IncomeReportByResource MyParentReport
                {
                    get { return (IncomeReportByResource)ParentReport; }
                }
                
                public TTReportField BOLUM;
                public TTReportField KURUMGELIRI;
                public TTReportField SIVILGELIRI;
                public TTReportField TOPLAM; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 83, 6, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUM.NoClip = EvetHayirEnum.ehEvet;
                    BOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUM.Value = @"";

                    KURUMGELIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 1, 125, 6, false);
                    KURUMGELIRI.Name = "KURUMGELIRI";
                    KURUMGELIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMGELIRI.TextFormat = @"#,##0.#0";
                    KURUMGELIRI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KURUMGELIRI.Value = @"";

                    SIVILGELIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 1, 166, 6, false);
                    SIVILGELIRI.Name = "SIVILGELIRI";
                    SIVILGELIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIVILGELIRI.TextFormat = @"#,##0.#0";
                    SIVILGELIRI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SIVILGELIRI.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 1, 203, 6, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BOLUM.CalcValue = @"";
                    KURUMGELIRI.CalcValue = @"";
                    SIVILGELIRI.CalcValue = @"";
                    TOPLAM.CalcValue = @"";
                    return new TTReportObject[] { BOLUM,KURUMGELIRI,SIVILGELIRI,TOPLAM};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    List<BolumGeliri> bolumGeliriBilgisi = ((IncomeReportByResource)ParentReport).bolumGeliriBilgisi;
            int yazdirmaSayac = ((IncomeReportByResource)ParentReport).yazdirmaSayac;
            if(bolumGeliriBilgisi.Count > 0)
            {
                BolumGeliri bolumGeliri = bolumGeliriBilgisi[yazdirmaSayac];
                this.BOLUM.CalcValue = bolumGeliri.bolumAdi;
                this.KURUMGELIRI.CalcValue = bolumGeliri.kurumGeliri.ToString();
                this.SIVILGELIRI.CalcValue = bolumGeliri.sivilGeliri.ToString();
                this.TOPLAM.CalcValue = bolumGeliri.toplamGelir.ToString();
                
                ((IncomeReportByResource)ParentReport).toplamKurumGeliri += Convert.ToDouble(this.KURUMGELIRI.CalcValue);
                ((IncomeReportByResource)ParentReport).toplamSivilGeliri += Convert.ToDouble(this.SIVILGELIRI.CalcValue);
                ((IncomeReportByResource)ParentReport).yazdirmaSayac++;
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

        public IncomeReportByResource()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            PARTA = new PARTAGroup(MASTER,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DEPARTMENT", "", "Bölüm", @"", false, true, true, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("3cd6cd4d-efd9-44b6-8d88-4251e2e12ce1");
            reportParameter = Parameters.Add("DEPARTMENTFLAG", "", "Bölüm Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DEPARTMENT"))
                _runtimeParameters.DEPARTMENT = (List<Guid>)parameters["DEPARTMENT"];
            if (parameters.ContainsKey("DEPARTMENTFLAG"))
                _runtimeParameters.DEPARTMENTFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["DEPARTMENTFLAG"]);
            Name = "INCOMEREPORTBYRESOURCE";
            Caption = "Bölüm Bazında Gelir Raporu";
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