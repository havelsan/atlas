
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
    /// Medula Takip Sayıları Raporu
    /// </summary>
    public partial class MedulaProvisionCountReport : TTReport
    {
#region Methods
   public List<Brans> bransList = new List<Brans>();
        public int Sayac = 0;
        public int yazdirmaSayac = 0;
        
        public int O1T = 0;
        public int O2T = 0;
        public int O3T = 0;
        public int O4T = 0;
        public int O5T = 0;
        public int O6T = 0;
        public int OTT = 0;
        
        public int I1T = 0;
        public int I2T = 0;
        public int I3T = 0;
        public int I4T = 0;
        public int I5T = 0;
        public int I6T = 0;
        public int ITT = 0;

        public int D1T = 0;
        public int D2T = 0;
        public int D3T = 0;
        public int D4T = 0;
        public int D5T = 0;
        public int D6T = 0;
        public int DTT = 0;
        
        // Branslar (sorgulardan gelen bölümler)
        public class Brans
        {
            public string Name;
            
            public int OT;
            public int O1;
            public int O2;
            public int O3;
            public int O4;
            public int O5;
            public int O6;
            
            public int IT;
            public int I1;
            public int I2;
            public int I3;
            public int I4;
            public int I5;
            public int I6;

            public int DT;
            public int D1;
            public int D2;
            public int D3;
            public int D4;
            public int D5;
            public int D6;
            
            public Brans(string name)
            {
                Name = name;
                
                OT = 0;
                O1 = 0;
                O2 = 0;
                O3 = 0;
                O4 = 0;
                O5 = 0;
                O6 = 0;
                
                IT = 0;
                I1 = 0;
                I2 = 0;
                I3 = 0;
                I4 = 0;
                I5 = 0;
                I6 = 0;
                
                DT = 0;
                D1 = 0;
                D2 = 0;
                D3 = 0;
                D4 = 0;
                D5 = 0;
                D6 = 0;
            }
        }

        public class AscBranchComparer : IComparer<Brans>
        {
            #region IComparer<LotoItem> Members
            public int Compare(Brans x, Brans y)
            {
                return (x.Name.CompareTo(y.Name)); // artan sıra ile sıralayan Compare
            }
            #endregion
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MedulaProvisionCountReport MyParentReport
            {
                get { return (MedulaProvisionCountReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 32, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 63, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
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
#region PARTA HEADER_Script
                    ((MedulaProvisionCountReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((MedulaProvisionCountReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            ((MedulaProvisionCountReport)ParentReport).bransList.Clear();
            ((MedulaProvisionCountReport)ParentReport).Sayac = 0;
            ((MedulaProvisionCountReport)ParentReport).yazdirmaSayac = 0;
            
            ((MedulaProvisionCountReport)ParentReport).O1T = 0;
            ((MedulaProvisionCountReport)ParentReport).O2T = 0;
            ((MedulaProvisionCountReport)ParentReport).O3T = 0;
            ((MedulaProvisionCountReport)ParentReport).O4T = 0;
            ((MedulaProvisionCountReport)ParentReport).O5T = 0;
            ((MedulaProvisionCountReport)ParentReport).O6T = 0;
            ((MedulaProvisionCountReport)ParentReport).OTT = 0;
            
            ((MedulaProvisionCountReport)ParentReport).I1T = 0;
            ((MedulaProvisionCountReport)ParentReport).I2T = 0;
            ((MedulaProvisionCountReport)ParentReport).I3T = 0;
            ((MedulaProvisionCountReport)ParentReport).I4T = 0;
            ((MedulaProvisionCountReport)ParentReport).I5T = 0;
            ((MedulaProvisionCountReport)ParentReport).I6T = 0;
            ((MedulaProvisionCountReport)ParentReport).ITT = 0;

            ((MedulaProvisionCountReport)ParentReport).D1T = 0;
            ((MedulaProvisionCountReport)ParentReport).D2T = 0;
            ((MedulaProvisionCountReport)ParentReport).D3T = 0;
            ((MedulaProvisionCountReport)ParentReport).D4T = 0;
            ((MedulaProvisionCountReport)ParentReport).D5T = 0;
            ((MedulaProvisionCountReport)ParentReport).D6T = 0;
            ((MedulaProvisionCountReport)ParentReport).DTT = 0;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public MedulaProvisionCountReport MyParentReport
            {
                get { return (MedulaProvisionCountReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField MPBRANS { get {return Body().MPBRANS;} }
            public TTReportField SEBRANS { get {return Body().SEBRANS;} }
            public TTReportField MPTEDAVITURU { get {return Body().MPTEDAVITURU;} }
            public TTReportField SETEDAVITURU { get {return Body().SETEDAVITURU;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
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
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                
                public TTReportField MPBRANS;
                public TTReportField SEBRANS;
                public TTReportField MPTEDAVITURU;
                public TTReportField SETEDAVITURU;
                public TTReportField STATUS; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MPBRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 73, 8, false);
                    MPBRANS.Name = "MPBRANS";
                    MPBRANS.Value = @"{#MPBRANS#}";

                    SEBRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 3, 134, 8, false);
                    SEBRANS.Name = "SEBRANS";
                    SEBRANS.Value = @"{#SEBRANS#}";

                    MPTEDAVITURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 3, 164, 8, false);
                    MPTEDAVITURU.Name = "MPTEDAVITURU";
                    MPTEDAVITURU.Value = @"{#MPTEDAVITURU#}";

                    SETEDAVITURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 3, 194, 8, false);
                    SETEDAVITURU.Name = "SETEDAVITURU";
                    SETEDAVITURU.Value = @"{#SETEDAVITURU#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 3, 255, 8, false);
                    STATUS.Name = "STATUS";
                    STATUS.Value = @"{#STATUS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MPBRANS.CalcValue = MPBRANS.Value;
                    SEBRANS.CalcValue = SEBRANS.Value;
                    MPTEDAVITURU.CalcValue = MPTEDAVITURU.Value;
                    SETEDAVITURU.CalcValue = SETEDAVITURU.Value;
                    STATUS.CalcValue = STATUS.Value;
                    return new TTReportObject[] { MPBRANS,SEBRANS,MPTEDAVITURU,SETEDAVITURU,STATUS};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    bool bransFound = false;
            
            // Default Değerler
            string bransName = "Bilinmiyor";
            string tedaviTuru = "A";
            string takipDurumu = "1";
            
            if(!string.IsNullOrEmpty(this.MPBRANS.CalcValue))
                bransName = this.MPBRANS.CalcValue;
            else if(!string.IsNullOrEmpty(this.SEBRANS.CalcValue))
                bransName = this.SEBRANS.CalcValue;
            
            if(!string.IsNullOrEmpty(this.MPTEDAVITURU.CalcValue))
                tedaviTuru = this.MPTEDAVITURU.CalcValue;
            else if(!string.IsNullOrEmpty(this.SETEDAVITURU.CalcValue))
            {
                if(SETEDAVITURU.CalcValue == "Outpatient" || SETEDAVITURU.CalcValue == "0")
                    tedaviTuru = "A";
                else if(SETEDAVITURU.CalcValue == "Daily" || SETEDAVITURU.CalcValue == "3")
                    tedaviTuru = "G";
                else
                    tedaviTuru = "Y";
            }
            
            if(!string.IsNullOrEmpty(this.STATUS.CalcValue))
            {
                switch (this.STATUS.CalcValue)
                {
                    case "ProvisionNoNotExists":
                    case "0":
                    case "ProvisionNoWaiting":
                    case "1":
                        {
                            takipDurumu = "1";       // Takip No Alınmamış
                            break;
                        }
                    case "ProcedureEntryNotCompleted":
                    case "2":
                        {
                            takipDurumu = "2";       // Hizmet Kaydı Tamamlanmamış
                            break;
                        }
                    case "ProcedureEntryWithError":
                    case "3":
                        {
                            takipDurumu = "3";       // Hizmet Kaydı Tamamlanmamış Hatalı
                            break;
                        }
                    case "ProcedureEntryCompleted":
                    case "4":
                    case "InvoiceEntryWaiting":
                    case "5":
                    case "InvoiceReadWaiting":
                    case "8":
                    case "InvoiceRead":
                    case "9":
                    case "InvoiceReadWithError":
                    case "10":
                        {
                            takipDurumu = "4";       // Hizmet Kaydı Tamamlanmış
                            break;
                        }
                    case "InvoiceEntryWithError":
                    case "6":
                        {
                            takipDurumu = "5";       // Fatura Kaydı Hatalı
                            break;
                        }
                    case "Invoiced":
                    case "7":
                        {
                            takipDurumu = "6";       // Fatura Kaydedildi
                            break;
                        }
                }
            }
            
            foreach(Brans brans in ((MedulaProvisionCountReport)ParentReport).bransList)
            {
                if(brans.Name == bransName)
                {
                    if(tedaviTuru == "A")
                    {
                        if(takipDurumu == "1")
                            brans.O1++;
                        else if(takipDurumu == "2")
                            brans.O2++;
                        else if(takipDurumu == "3")
                            brans.O3++;
                        else if(takipDurumu == "4")
                            brans.O4++;
                        else if(takipDurumu == "5")
                            brans.O5++;
                        else if(takipDurumu == "6")
                            brans.O6++;
                        brans.OT++;
                    }
                    else if(tedaviTuru == "Y")
                    {
                        if(takipDurumu == "1")
                            brans.I1++;
                        else if(takipDurumu == "2")
                            brans.I2++;
                        else if(takipDurumu == "3")
                            brans.I3++;
                        else if(takipDurumu == "4")
                            brans.I4++;
                        else if(takipDurumu == "5")
                            brans.I5++;
                        else if(takipDurumu == "6")
                            brans.I6++;
                        brans.IT++;
                    }
                    else if(tedaviTuru == "G")
                    {
                        if(takipDurumu == "1")
                            brans.D1++;
                        else if(takipDurumu == "2")
                            brans.D2++;
                        else if(takipDurumu == "3")
                            brans.D3++;
                        else if(takipDurumu == "4")
                            brans.D4++;
                        else if(takipDurumu == "5")
                            brans.D5++;
                        else if(takipDurumu == "6")
                            brans.D6++;
                        brans.DT++;
                    }
                    bransFound = true;
                    break;
                }
            }
            
            if(!bransFound)
            {
                ((MedulaProvisionCountReport)ParentReport).bransList.Add(new Brans(bransName));
                
                if(tedaviTuru == "A")
                {
                    if(takipDurumu == "1")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].O1++;
                    else if(takipDurumu == "2")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].O2++;
                    else if(takipDurumu == "3")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].O3++;
                    else if(takipDurumu == "4")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].O4++;
                    else if(takipDurumu == "5")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].O5++;
                    else if(takipDurumu == "6")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].O6++;
                    
                    ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].OT++;
                }
                else if(tedaviTuru == "Y")
                {
                    if(takipDurumu == "1")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].I1++;
                    else if(takipDurumu == "2")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].I2++;
                    else if(takipDurumu == "3")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].I3++;
                    else if(takipDurumu == "4")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].I4++;
                    else if(takipDurumu == "5")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].I5++;
                    else if(takipDurumu == "6")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].I6++;
                    
                    ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].IT++;
                }
                else if(tedaviTuru == "G")
                {
                    if(takipDurumu == "1")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].D1++;
                    else if(takipDurumu == "2")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].D2++;
                    else if(takipDurumu == "3")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].D3++;
                    else if(takipDurumu == "4")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].D4++;
                    else  if(takipDurumu == "5")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].D5++;
                    else if(takipDurumu == "6")
                        ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].D6++;
                    
                    ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).Sayac].DT++;
                }
                
                ((MedulaProvisionCountReport)ParentReport).Sayac ++;
            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public MedulaProvisionCountReport MyParentReport
            {
                get { return (MedulaProvisionCountReport)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
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
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTD BODY_Script
                    ((MedulaProvisionCountReport)ParentReport).bransList.Sort(new AscBranchComparer());
            
            ((MedulaProvisionCountReport)ParentReport).MAIN.RepeatCount = ((MedulaProvisionCountReport)ParentReport).Sayac;
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTEGroup : TTReportGroup
        {
            public MedulaProvisionCountReport MyParentReport
            {
                get { return (MedulaProvisionCountReport)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine111111121 { get {return Footer().NewLine111111121;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
            public TTReportShape NewLine1111121 { get {return Footer().NewLine1111121;} }
            public TTReportShape NewLine1111131 { get {return Footer().NewLine1111131;} }
            public TTReportShape NewLine1111141 { get {return Footer().NewLine1111141;} }
            public TTReportShape NewLine1111151 { get {return Footer().NewLine1111151;} }
            public TTReportShape NewLine1111161 { get {return Footer().NewLine1111161;} }
            public TTReportShape NewLine1111171 { get {return Footer().NewLine1111171;} }
            public TTReportShape NewLine1111181 { get {return Footer().NewLine1111181;} }
            public TTReportShape NewLine1111191 { get {return Footer().NewLine1111191;} }
            public TTReportShape NewLine1111201 { get {return Footer().NewLine1111201;} }
            public TTReportShape NewLine1111211 { get {return Footer().NewLine1111211;} }
            public TTReportShape NewLine1111221 { get {return Footer().NewLine1111221;} }
            public TTReportShape NewLine1111231 { get {return Footer().NewLine1111231;} }
            public TTReportShape NewLine11111111 { get {return Footer().NewLine11111111;} }
            public TTReportShape NewLine12111111 { get {return Footer().NewLine12111111;} }
            public TTReportShape NewLine13111111 { get {return Footer().NewLine13111111;} }
            public TTReportShape NewLine14111111 { get {return Footer().NewLine14111111;} }
            public TTReportShape NewLine15111111 { get {return Footer().NewLine15111111;} }
            public TTReportShape NewLine16111111 { get {return Footer().NewLine16111111;} }
            public TTReportShape NewLine11221111 { get {return Footer().NewLine11221111;} }
            public TTReportShape NewLine12221111 { get {return Footer().NewLine12221111;} }
            public TTReportShape NewLine11211113 { get {return Footer().NewLine11211113;} }
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
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111111121;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine1111111;
                public TTReportShape NewLine1111121;
                public TTReportShape NewLine1111131;
                public TTReportShape NewLine1111141;
                public TTReportShape NewLine1111151;
                public TTReportShape NewLine1111161;
                public TTReportShape NewLine1111171;
                public TTReportShape NewLine1111181;
                public TTReportShape NewLine1111191;
                public TTReportShape NewLine1111201;
                public TTReportShape NewLine1111211;
                public TTReportShape NewLine1111221;
                public TTReportShape NewLine1111231;
                public TTReportShape NewLine11111111;
                public TTReportShape NewLine12111111;
                public TTReportShape NewLine13111111;
                public TTReportShape NewLine14111111;
                public TTReportShape NewLine15111111;
                public TTReportShape NewLine16111111;
                public TTReportShape NewLine11221111;
                public TTReportShape NewLine12221111;
                public TTReportShape NewLine11211113; 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 3, 183, 8, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 3, 291, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 39, 8, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    NewLine111111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 291, 1, false);
                    NewLine111111121.Name = "NewLine111111121";
                    NewLine111111121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 63, 0, 63, 1, false);
                    NewLine1111121.Name = "NewLine1111121";
                    NewLine1111121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 96, 0, 96, 1, false);
                    NewLine1111131.Name = "NewLine1111131";
                    NewLine1111131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 118, 0, 118, 1, false);
                    NewLine1111141.Name = "NewLine1111141";
                    NewLine1111141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 0, 131, 1, false);
                    NewLine1111151.Name = "NewLine1111151";
                    NewLine1111151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 0, 154, 1, false);
                    NewLine1111161.Name = "NewLine1111161";
                    NewLine1111161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 165, 0, 165, 1, false);
                    NewLine1111171.Name = "NewLine1111171";
                    NewLine1111171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 0, 187, 1, false);
                    NewLine1111181.Name = "NewLine1111181";
                    NewLine1111181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 0, 198, 1, false);
                    NewLine1111191.Name = "NewLine1111191";
                    NewLine1111191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111201 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 1, false);
                    NewLine1111201.Name = "NewLine1111201";
                    NewLine1111201.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 0, 234, 1, false);
                    NewLine1111211.Name = "NewLine1111211";
                    NewLine1111211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 1, false);
                    NewLine1111221.Name = "NewLine1111221";
                    NewLine1111221.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111231 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 1, false);
                    NewLine1111231.Name = "NewLine1111231";
                    NewLine1111231.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 85, 0, 85, 1, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 107, 1, false);
                    NewLine12111111.Name = "NewLine12111111";
                    NewLine12111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 0, 143, 1, false);
                    NewLine13111111.Name = "NewLine13111111";
                    NewLine13111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 0, 223, 1, false);
                    NewLine14111111.Name = "NewLine14111111";
                    NewLine14111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 0, 176, 1, false);
                    NewLine15111111.Name = "NewLine15111111";
                    NewLine15111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 278, 0, 278, 1, false);
                    NewLine16111111.Name = "NewLine16111111";
                    NewLine16111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11221111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 0, 245, 1, false);
                    NewLine11221111.Name = "NewLine11221111";
                    NewLine11221111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12221111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 267, 0, 267, 1, false);
                    NewLine12221111.Name = "NewLine12221111";
                    NewLine12221111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11211113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 0, 74, 1, false);
                    NewLine11211113.Name = "NewLine11211113";
                    NewLine11211113.DrawStyle = DrawStyleConstants.vbSolid;

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

        public partial class PARTBGroup : TTReportGroup
        {
            public MedulaProvisionCountReport MyParentReport
            {
                get { return (MedulaProvisionCountReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportShape NewLine11111111 { get {return Header().NewLine11111111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportShape NewLine111111111 { get {return Header().NewLine111111111;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportShape NewLine1211 { get {return Header().NewLine1211;} }
            public TTReportShape NewLine113 { get {return Header().NewLine113;} }
            public TTReportShape NewLine12111 { get {return Header().NewLine12111;} }
            public TTReportShape NewLine12112 { get {return Header().NewLine12112;} }
            public TTReportShape NewLine12113 { get {return Header().NewLine12113;} }
            public TTReportShape NewLine12114 { get {return Header().NewLine12114;} }
            public TTReportShape NewLine12115 { get {return Header().NewLine12115;} }
            public TTReportShape NewLine12116 { get {return Header().NewLine12116;} }
            public TTReportShape NewLine12117 { get {return Header().NewLine12117;} }
            public TTReportShape NewLine12118 { get {return Header().NewLine12118;} }
            public TTReportShape NewLine12119 { get {return Header().NewLine12119;} }
            public TTReportShape NewLine12120 { get {return Header().NewLine12120;} }
            public TTReportShape NewLine12121 { get {return Header().NewLine12121;} }
            public TTReportShape NewLine12122 { get {return Header().NewLine12122;} }
            public TTReportShape NewLine12123 { get {return Header().NewLine12123;} }
            public TTReportShape NewLine12124 { get {return Header().NewLine12124;} }
            public TTReportShape NewLine12125 { get {return Header().NewLine12125;} }
            public TTReportShape NewLine12126 { get {return Header().NewLine12126;} }
            public TTReportShape NewLine12127 { get {return Header().NewLine12127;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField163 { get {return Header().NewField163;} }
            public TTReportField NewField164 { get {return Header().NewField164;} }
            public TTReportField NewField165 { get {return Header().NewField165;} }
            public TTReportField NewField166 { get {return Header().NewField166;} }
            public TTReportField NewField167 { get {return Header().NewField167;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField NewField1361 { get {return Header().NewField1361;} }
            public TTReportField NewField1461 { get {return Header().NewField1461;} }
            public TTReportField NewField1561 { get {return Header().NewField1561;} }
            public TTReportField NewField1661 { get {return Header().NewField1661;} }
            public TTReportField NewField168 { get {return Header().NewField168;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField NewField1262 { get {return Header().NewField1262;} }
            public TTReportField NewField1362 { get {return Header().NewField1362;} }
            public TTReportField NewField1462 { get {return Header().NewField1462;} }
            public TTReportField NewField1562 { get {return Header().NewField1562;} }
            public TTReportField NewField1662 { get {return Header().NewField1662;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField OTT { get {return Footer().OTT;} }
            public TTReportField O1T { get {return Footer().O1T;} }
            public TTReportField O2T { get {return Footer().O2T;} }
            public TTReportField O3T { get {return Footer().O3T;} }
            public TTReportField O4T { get {return Footer().O4T;} }
            public TTReportField O5T { get {return Footer().O5T;} }
            public TTReportField O6T { get {return Footer().O6T;} }
            public TTReportField ITT { get {return Footer().ITT;} }
            public TTReportField I1T { get {return Footer().I1T;} }
            public TTReportField I2T { get {return Footer().I2T;} }
            public TTReportField I3T { get {return Footer().I3T;} }
            public TTReportField I4T { get {return Footer().I4T;} }
            public TTReportField I5T { get {return Footer().I5T;} }
            public TTReportField I6T { get {return Footer().I6T;} }
            public TTReportField DTT { get {return Footer().DTT;} }
            public TTReportField D1T { get {return Footer().D1T;} }
            public TTReportField D2T { get {return Footer().D2T;} }
            public TTReportField D3T { get {return Footer().D3T;} }
            public TTReportField D4T { get {return Footer().D4T;} }
            public TTReportField D5T { get {return Footer().D5T;} }
            public TTReportField D6T { get {return Footer().D6T;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportShape NewLine12128 { get {return Footer().NewLine12128;} }
            public TTReportShape NewLine13111 { get {return Footer().NewLine13111;} }
            public TTReportShape NewLine14111 { get {return Footer().NewLine14111;} }
            public TTReportShape NewLine15111 { get {return Footer().NewLine15111;} }
            public TTReportShape NewLine16111 { get {return Footer().NewLine16111;} }
            public TTReportShape NewLine17111 { get {return Footer().NewLine17111;} }
            public TTReportShape NewLine18111 { get {return Footer().NewLine18111;} }
            public TTReportShape NewLine19111 { get {return Footer().NewLine19111;} }
            public TTReportShape NewLine10211 { get {return Footer().NewLine10211;} }
            public TTReportShape NewLine11211 { get {return Footer().NewLine11211;} }
            public TTReportShape NewLine12211 { get {return Footer().NewLine12211;} }
            public TTReportShape NewLine13211 { get {return Footer().NewLine13211;} }
            public TTReportShape NewLine14211 { get {return Footer().NewLine14211;} }
            public TTReportShape NewLine15211 { get {return Footer().NewLine15211;} }
            public TTReportShape NewLine16211 { get {return Footer().NewLine16211;} }
            public TTReportShape NewLine17211 { get {return Footer().NewLine17211;} }
            public TTReportShape NewLine18211 { get {return Footer().NewLine18211;} }
            public TTReportShape NewLine19211 { get {return Footer().NewLine19211;} }
            public TTReportShape NewLine10311 { get {return Footer().NewLine10311;} }
            public TTReportShape NewLine11311 { get {return Footer().NewLine11311;} }
            public TTReportShape NewLine12311 { get {return Footer().NewLine12311;} }
            public TTReportShape NewLine1111111111 { get {return Footer().NewLine1111111111;} }
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
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField151;
                public TTReportShape NewLine11111111;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1112;
                public TTReportField NewField142;
                public TTReportShape NewLine111111111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine113;
                public TTReportShape NewLine12111;
                public TTReportShape NewLine12112;
                public TTReportShape NewLine12113;
                public TTReportShape NewLine12114;
                public TTReportShape NewLine12115;
                public TTReportShape NewLine12116;
                public TTReportShape NewLine12117;
                public TTReportShape NewLine12118;
                public TTReportShape NewLine12119;
                public TTReportShape NewLine12120;
                public TTReportShape NewLine12121;
                public TTReportShape NewLine12122;
                public TTReportShape NewLine12123;
                public TTReportShape NewLine12124;
                public TTReportShape NewLine12125;
                public TTReportShape NewLine12126;
                public TTReportShape NewLine12127;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField162;
                public TTReportField NewField163;
                public TTReportField NewField164;
                public TTReportField NewField165;
                public TTReportField NewField166;
                public TTReportField NewField167;
                public TTReportField NewField1161;
                public TTReportField NewField1261;
                public TTReportField NewField1361;
                public TTReportField NewField1461;
                public TTReportField NewField1561;
                public TTReportField NewField1661;
                public TTReportField NewField168;
                public TTReportField NewField1162;
                public TTReportField NewField1262;
                public TTReportField NewField1362;
                public TTReportField NewField1462;
                public TTReportField NewField1562;
                public TTReportField NewField1662; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 77;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 291, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"MEDULA TAKİP SAYILARI RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 30, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 15, 66, 20, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Bitiş Tarihi :";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 47, 20, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 15, 83, 20, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 22, 130, 27, false);
                    NewField14.Name = "NewField14";
                    NewField14.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"AYAKTAN";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 22, 210, 27, false);
                    NewField15.Name = "NewField15";
                    NewField15.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"YATAN";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 22, 290, 27, false);
                    NewField151.Name = "NewField151";
                    NewField151.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"GÜNÜBİRLİK";

                    NewLine11111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 21, 291, 21, false);
                    NewLine11111111.Name = "NewLine11111111";
                    NewLine11111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 21, 8, 77, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 21, 52, 77, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 63, 27, 63, 77, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 22, 51, 77, false);
                    NewField142.Name = "NewField142";
                    NewField142.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Size = 8;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"BRANŞ";

                    NewLine111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 27, 291, 27, false);
                    NewLine111111111.Name = "NewLine111111111";
                    NewLine111111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 21, 131, 77, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 21, 211, 78, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 21, 291, 78, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 27, 74, 77, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 85, 27, 85, 77, false);
                    NewLine12112.Name = "NewLine12112";
                    NewLine12112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 96, 27, 96, 77, false);
                    NewLine12113.Name = "NewLine12113";
                    NewLine12113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 27, 107, 77, false);
                    NewLine12114.Name = "NewLine12114";
                    NewLine12114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12114.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 118, 27, 118, 77, false);
                    NewLine12115.Name = "NewLine12115";
                    NewLine12115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12115.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 27, 143, 77, false);
                    NewLine12116.Name = "NewLine12116";
                    NewLine12116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12116.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 27, 154, 77, false);
                    NewLine12117.Name = "NewLine12117";
                    NewLine12117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12117.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12118 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 165, 27, 165, 77, false);
                    NewLine12118.Name = "NewLine12118";
                    NewLine12118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12118.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12119 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 27, 176, 77, false);
                    NewLine12119.Name = "NewLine12119";
                    NewLine12119.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12119.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12120 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 27, 187, 77, false);
                    NewLine12120.Name = "NewLine12120";
                    NewLine12120.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12120.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 27, 198, 77, false);
                    NewLine12121.Name = "NewLine12121";
                    NewLine12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 27, 223, 77, false);
                    NewLine12122.Name = "NewLine12122";
                    NewLine12122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12122.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 27, 234, 77, false);
                    NewLine12123.Name = "NewLine12123";
                    NewLine12123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12123.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 27, 245, 77, false);
                    NewLine12124.Name = "NewLine12124";
                    NewLine12124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12124.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12125 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 27, 256, 77, false);
                    NewLine12125.Name = "NewLine12125";
                    NewLine12125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12125.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12126 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 267, 27, 267, 77, false);
                    NewLine12126.Name = "NewLine12126";
                    NewLine12126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12126.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12127 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 278, 27, 278, 77, false);
                    NewLine12127.Name = "NewLine12127";
                    NewLine12127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12127.ExtendTo = ExtendToEnum.extPageHeight;

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 28, 96, 79, false);
                    NewField16.Name = "NewField16";
                    NewField16.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField16.FontAngle = 900;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField16.NoClip = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"HİZ.KAYDI TAMAMLANMAMIŞ HATALI";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 28, 107, 79, false);
                    NewField161.Name = "NewField161";
                    NewField161.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField161.FontAngle = 900;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField161.NoClip = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"HİZMET KAYDI TAMAMLANMIŞ";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 28, 118, 79, false);
                    NewField162.Name = "NewField162";
                    NewField162.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField162.FontAngle = 900;
                    NewField162.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField162.NoClip = EvetHayirEnum.ehEvet;
                    NewField162.TextFont.Size = 8;
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"FATURA KAYDI HATALI";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 28, 130, 79, false);
                    NewField163.Name = "NewField163";
                    NewField163.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField163.FontAngle = 900;
                    NewField163.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField163.NoClip = EvetHayirEnum.ehEvet;
                    NewField163.TextFont.Size = 8;
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"FATURA KAYDEDİLDİ";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 28, 85, 79, false);
                    NewField164.Name = "NewField164";
                    NewField164.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField164.FontAngle = 900;
                    NewField164.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField164.NoClip = EvetHayirEnum.ehEvet;
                    NewField164.TextFont.Size = 8;
                    NewField164.TextFont.Bold = true;
                    NewField164.TextFont.CharSet = 162;
                    NewField164.Value = @"HİZ.KAYDI TAMAMLANMAMIŞ";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 28, 74, 79, false);
                    NewField165.Name = "NewField165";
                    NewField165.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField165.FontAngle = 900;
                    NewField165.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField165.NoClip = EvetHayirEnum.ehEvet;
                    NewField165.TextFont.Size = 8;
                    NewField165.TextFont.Bold = true;
                    NewField165.TextFont.CharSet = 162;
                    NewField165.Value = @"TAKİP NO ALINMAMIŞ";

                    NewField166 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 28, 63, 79, false);
                    NewField166.Name = "NewField166";
                    NewField166.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField166.FontAngle = 900;
                    NewField166.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField166.NoClip = EvetHayirEnum.ehEvet;
                    NewField166.TextFont.Size = 8;
                    NewField166.TextFont.Bold = true;
                    NewField166.TextFont.CharSet = 162;
                    NewField166.Value = @"HEPSİ";

                    NewField167 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 28, 176, 79, false);
                    NewField167.Name = "NewField167";
                    NewField167.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField167.FontAngle = 900;
                    NewField167.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField167.NoClip = EvetHayirEnum.ehEvet;
                    NewField167.TextFont.Size = 8;
                    NewField167.TextFont.Bold = true;
                    NewField167.TextFont.CharSet = 162;
                    NewField167.Value = @"HİZ.KAYDI TAMAMLANMAMIŞ HATALI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 28, 187, 79, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1161.FontAngle = 900;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1161.NoClip = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"HİZMET KAYDI TAMAMLANMIŞ";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 28, 198, 79, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1261.FontAngle = 900;
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1261.NoClip = EvetHayirEnum.ehEvet;
                    NewField1261.TextFont.Size = 8;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @"FATURA KAYDI HATALI";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 28, 210, 79, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1361.FontAngle = 900;
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1361.NoClip = EvetHayirEnum.ehEvet;
                    NewField1361.TextFont.Size = 8;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"FATURA KAYDEDİLDİ";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 28, 165, 79, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1461.FontAngle = 900;
                    NewField1461.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1461.NoClip = EvetHayirEnum.ehEvet;
                    NewField1461.TextFont.Size = 8;
                    NewField1461.TextFont.Bold = true;
                    NewField1461.TextFont.CharSet = 162;
                    NewField1461.Value = @"HİZ.KAYDI TAMAMLANMAMIŞ";

                    NewField1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 28, 154, 79, false);
                    NewField1561.Name = "NewField1561";
                    NewField1561.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1561.FontAngle = 900;
                    NewField1561.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1561.NoClip = EvetHayirEnum.ehEvet;
                    NewField1561.TextFont.Size = 8;
                    NewField1561.TextFont.Bold = true;
                    NewField1561.TextFont.CharSet = 162;
                    NewField1561.Value = @"TAKİP NO ALINMAMIŞ";

                    NewField1661 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 28, 143, 79, false);
                    NewField1661.Name = "NewField1661";
                    NewField1661.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1661.FontAngle = 900;
                    NewField1661.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1661.NoClip = EvetHayirEnum.ehEvet;
                    NewField1661.TextFont.Size = 8;
                    NewField1661.TextFont.Bold = true;
                    NewField1661.TextFont.CharSet = 162;
                    NewField1661.Value = @"HEPSİ";

                    NewField168 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 28, 256, 79, false);
                    NewField168.Name = "NewField168";
                    NewField168.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField168.FontAngle = 900;
                    NewField168.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField168.NoClip = EvetHayirEnum.ehEvet;
                    NewField168.TextFont.Size = 8;
                    NewField168.TextFont.Bold = true;
                    NewField168.TextFont.CharSet = 162;
                    NewField168.Value = @"HİZ.KAYDI TAMAMLANMAMIŞ HATALI";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 28, 267, 79, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1162.FontAngle = 900;
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1162.NoClip = EvetHayirEnum.ehEvet;
                    NewField1162.TextFont.Size = 8;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"HİZMET KAYDI TAMAMLANMIŞ";

                    NewField1262 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 28, 278, 79, false);
                    NewField1262.Name = "NewField1262";
                    NewField1262.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1262.FontAngle = 900;
                    NewField1262.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1262.NoClip = EvetHayirEnum.ehEvet;
                    NewField1262.TextFont.Size = 8;
                    NewField1262.TextFont.Bold = true;
                    NewField1262.TextFont.CharSet = 162;
                    NewField1262.Value = @"FATURA KAYDI HATALI";

                    NewField1362 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 28, 290, 79, false);
                    NewField1362.Name = "NewField1362";
                    NewField1362.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1362.FontAngle = 900;
                    NewField1362.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1362.NoClip = EvetHayirEnum.ehEvet;
                    NewField1362.TextFont.Size = 8;
                    NewField1362.TextFont.Bold = true;
                    NewField1362.TextFont.CharSet = 162;
                    NewField1362.Value = @"FATURA KAYDEDİLDİ";

                    NewField1462 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 28, 245, 79, false);
                    NewField1462.Name = "NewField1462";
                    NewField1462.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1462.FontAngle = 900;
                    NewField1462.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1462.NoClip = EvetHayirEnum.ehEvet;
                    NewField1462.TextFont.Size = 8;
                    NewField1462.TextFont.Bold = true;
                    NewField1462.TextFont.CharSet = 162;
                    NewField1462.Value = @"HİZ.KAYDI TAMAMLANMAMIŞ";

                    NewField1562 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 28, 234, 79, false);
                    NewField1562.Name = "NewField1562";
                    NewField1562.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1562.FontAngle = 900;
                    NewField1562.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1562.NoClip = EvetHayirEnum.ehEvet;
                    NewField1562.TextFont.Size = 8;
                    NewField1562.TextFont.Bold = true;
                    NewField1562.TextFont.CharSet = 162;
                    NewField1562.Value = @"TAKİP NO ALINMAMIŞ";

                    NewField1662 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 28, 223, 79, false);
                    NewField1662.Name = "NewField1662";
                    NewField1662.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1662.FontAngle = 900;
                    NewField1662.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1662.NoClip = EvetHayirEnum.ehEvet;
                    NewField1662.TextFont.Size = 8;
                    NewField1662.TextFont.Bold = true;
                    NewField1662.TextFont.CharSet = 162;
                    NewField1662.Value = @"HEPSİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField165.CalcValue = NewField165.Value;
                    NewField166.CalcValue = NewField166.Value;
                    NewField167.CalcValue = NewField167.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField1561.CalcValue = NewField1561.Value;
                    NewField1661.CalcValue = NewField1661.Value;
                    NewField168.CalcValue = NewField168.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField1262.CalcValue = NewField1262.Value;
                    NewField1362.CalcValue = NewField1362.Value;
                    NewField1462.CalcValue = NewField1462.Value;
                    NewField1562.CalcValue = NewField1562.Value;
                    NewField1662.CalcValue = NewField1662.Value;
                    return new TTReportObject[] { NewField11,NewField1,NewField12,STARTDATE,ENDDATE,NewField14,NewField15,NewField151,NewField142,NewField16,NewField161,NewField162,NewField163,NewField164,NewField165,NewField166,NewField167,NewField1161,NewField1261,NewField1361,NewField1461,NewField1561,NewField1661,NewField168,NewField1162,NewField1262,NewField1362,NewField1462,NewField1562,NewField1662};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                
                public TTReportField TOPLAM;
                public TTReportField OTT;
                public TTReportField O1T;
                public TTReportField O2T;
                public TTReportField O3T;
                public TTReportField O4T;
                public TTReportField O5T;
                public TTReportField O6T;
                public TTReportField ITT;
                public TTReportField I1T;
                public TTReportField I2T;
                public TTReportField I3T;
                public TTReportField I4T;
                public TTReportField I5T;
                public TTReportField I6T;
                public TTReportField DTT;
                public TTReportField D1T;
                public TTReportField D2T;
                public TTReportField D3T;
                public TTReportField D4T;
                public TTReportField D5T;
                public TTReportField D6T;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine12128;
                public TTReportShape NewLine13111;
                public TTReportShape NewLine14111;
                public TTReportShape NewLine15111;
                public TTReportShape NewLine16111;
                public TTReportShape NewLine17111;
                public TTReportShape NewLine18111;
                public TTReportShape NewLine19111;
                public TTReportShape NewLine10211;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine12211;
                public TTReportShape NewLine13211;
                public TTReportShape NewLine14211;
                public TTReportShape NewLine15211;
                public TTReportShape NewLine16211;
                public TTReportShape NewLine17211;
                public TTReportShape NewLine18211;
                public TTReportShape NewLine19211;
                public TTReportShape NewLine10311;
                public TTReportShape NewLine11311;
                public TTReportShape NewLine12311;
                public TTReportShape NewLine1111111111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 51, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FillStyle = FillStyleConstants.vbFSTransparent;
                    TOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.Bold = true;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"TOPLAM";

                    OTT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 63, 5, false);
                    OTT.Name = "OTT";
                    OTT.FillStyle = FillStyleConstants.vbFSTransparent;
                    OTT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OTT.TextFont.Size = 8;
                    OTT.TextFont.CharSet = 162;
                    OTT.Value = @"";

                    O1T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 74, 5, false);
                    O1T.Name = "O1T";
                    O1T.FillStyle = FillStyleConstants.vbFSTransparent;
                    O1T.FieldType = ReportFieldTypeEnum.ftVariable;
                    O1T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O1T.TextFont.Size = 8;
                    O1T.TextFont.CharSet = 162;
                    O1T.Value = @"";

                    O2T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 85, 5, false);
                    O2T.Name = "O2T";
                    O2T.FillStyle = FillStyleConstants.vbFSTransparent;
                    O2T.FieldType = ReportFieldTypeEnum.ftVariable;
                    O2T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O2T.TextFont.Size = 8;
                    O2T.TextFont.CharSet = 162;
                    O2T.Value = @"";

                    O3T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 96, 5, false);
                    O3T.Name = "O3T";
                    O3T.FillStyle = FillStyleConstants.vbFSTransparent;
                    O3T.FieldType = ReportFieldTypeEnum.ftVariable;
                    O3T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O3T.TextFont.Size = 8;
                    O3T.TextFont.CharSet = 162;
                    O3T.Value = @"";

                    O4T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 107, 5, false);
                    O4T.Name = "O4T";
                    O4T.FillStyle = FillStyleConstants.vbFSTransparent;
                    O4T.FieldType = ReportFieldTypeEnum.ftVariable;
                    O4T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O4T.TextFont.Size = 8;
                    O4T.TextFont.CharSet = 162;
                    O4T.Value = @"";

                    O5T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 118, 5, false);
                    O5T.Name = "O5T";
                    O5T.FillStyle = FillStyleConstants.vbFSTransparent;
                    O5T.FieldType = ReportFieldTypeEnum.ftVariable;
                    O5T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O5T.TextFont.Size = 8;
                    O5T.TextFont.CharSet = 162;
                    O5T.Value = @"";

                    O6T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 130, 5, false);
                    O6T.Name = "O6T";
                    O6T.FillStyle = FillStyleConstants.vbFSTransparent;
                    O6T.FieldType = ReportFieldTypeEnum.ftVariable;
                    O6T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O6T.TextFont.Size = 8;
                    O6T.TextFont.CharSet = 162;
                    O6T.Value = @"";

                    ITT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 143, 5, false);
                    ITT.Name = "ITT";
                    ITT.FillStyle = FillStyleConstants.vbFSTransparent;
                    ITT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITT.TextFont.Size = 8;
                    ITT.TextFont.CharSet = 162;
                    ITT.Value = @"";

                    I1T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 154, 5, false);
                    I1T.Name = "I1T";
                    I1T.FillStyle = FillStyleConstants.vbFSTransparent;
                    I1T.FieldType = ReportFieldTypeEnum.ftVariable;
                    I1T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I1T.TextFont.Size = 8;
                    I1T.TextFont.CharSet = 162;
                    I1T.Value = @"";

                    I2T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 165, 5, false);
                    I2T.Name = "I2T";
                    I2T.FillStyle = FillStyleConstants.vbFSTransparent;
                    I2T.FieldType = ReportFieldTypeEnum.ftVariable;
                    I2T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I2T.TextFont.Size = 8;
                    I2T.TextFont.CharSet = 162;
                    I2T.Value = @"";

                    I3T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 176, 5, false);
                    I3T.Name = "I3T";
                    I3T.FillStyle = FillStyleConstants.vbFSTransparent;
                    I3T.FieldType = ReportFieldTypeEnum.ftVariable;
                    I3T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I3T.TextFont.Size = 8;
                    I3T.TextFont.CharSet = 162;
                    I3T.Value = @"";

                    I4T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 187, 5, false);
                    I4T.Name = "I4T";
                    I4T.FillStyle = FillStyleConstants.vbFSTransparent;
                    I4T.FieldType = ReportFieldTypeEnum.ftVariable;
                    I4T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I4T.TextFont.Size = 8;
                    I4T.TextFont.CharSet = 162;
                    I4T.Value = @"";

                    I5T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 198, 5, false);
                    I5T.Name = "I5T";
                    I5T.FillStyle = FillStyleConstants.vbFSTransparent;
                    I5T.FieldType = ReportFieldTypeEnum.ftVariable;
                    I5T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I5T.TextFont.Size = 8;
                    I5T.TextFont.CharSet = 162;
                    I5T.Value = @"";

                    I6T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 210, 5, false);
                    I6T.Name = "I6T";
                    I6T.FillStyle = FillStyleConstants.vbFSTransparent;
                    I6T.FieldType = ReportFieldTypeEnum.ftVariable;
                    I6T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I6T.TextFont.Size = 8;
                    I6T.TextFont.CharSet = 162;
                    I6T.Value = @"";

                    DTT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 223, 5, false);
                    DTT.Name = "DTT";
                    DTT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DTT.TextFont.Size = 8;
                    DTT.TextFont.CharSet = 162;
                    DTT.Value = @"";

                    D1T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 234, 5, false);
                    D1T.Name = "D1T";
                    D1T.FillStyle = FillStyleConstants.vbFSTransparent;
                    D1T.FieldType = ReportFieldTypeEnum.ftVariable;
                    D1T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D1T.TextFont.Size = 8;
                    D1T.TextFont.CharSet = 162;
                    D1T.Value = @"";

                    D2T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 0, 245, 5, false);
                    D2T.Name = "D2T";
                    D2T.FillStyle = FillStyleConstants.vbFSTransparent;
                    D2T.FieldType = ReportFieldTypeEnum.ftVariable;
                    D2T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D2T.TextFont.Size = 8;
                    D2T.TextFont.CharSet = 162;
                    D2T.Value = @"";

                    D3T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 256, 5, false);
                    D3T.Name = "D3T";
                    D3T.FillStyle = FillStyleConstants.vbFSTransparent;
                    D3T.FieldType = ReportFieldTypeEnum.ftVariable;
                    D3T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D3T.TextFont.Size = 8;
                    D3T.TextFont.CharSet = 162;
                    D3T.Value = @"";

                    D4T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 267, 5, false);
                    D4T.Name = "D4T";
                    D4T.FillStyle = FillStyleConstants.vbFSTransparent;
                    D4T.FieldType = ReportFieldTypeEnum.ftVariable;
                    D4T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D4T.TextFont.Size = 8;
                    D4T.TextFont.CharSet = 162;
                    D4T.Value = @"";

                    D5T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 278, 5, false);
                    D5T.Name = "D5T";
                    D5T.FillStyle = FillStyleConstants.vbFSTransparent;
                    D5T.FieldType = ReportFieldTypeEnum.ftVariable;
                    D5T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D5T.TextFont.Size = 8;
                    D5T.TextFont.CharSet = 162;
                    D5T.Value = @"";

                    D6T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 0, 290, 5, false);
                    D6T.Name = "D6T";
                    D6T.FillStyle = FillStyleConstants.vbFSTransparent;
                    D6T.FieldType = ReportFieldTypeEnum.ftVariable;
                    D6T.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D6T.TextFont.Size = 8;
                    D6T.TextFont.CharSet = 162;
                    D6T.Value = @"";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 5, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12128 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 63, 0, 63, 5, false);
                    NewLine12128.Name = "NewLine12128";
                    NewLine12128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12128.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 0, 74, 5, false);
                    NewLine13111.Name = "NewLine13111";
                    NewLine13111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 85, 0, 85, 5, false);
                    NewLine14111.Name = "NewLine14111";
                    NewLine14111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 96, 0, 96, 5, false);
                    NewLine15111.Name = "NewLine15111";
                    NewLine15111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 107, 5, false);
                    NewLine16111.Name = "NewLine16111";
                    NewLine16111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 118, 0, 118, 5, false);
                    NewLine17111.Name = "NewLine17111";
                    NewLine17111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 0, 131, 5, false);
                    NewLine18111.Name = "NewLine18111";
                    NewLine18111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine19111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 0, 143, 5, false);
                    NewLine19111.Name = "NewLine19111";
                    NewLine19111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine10211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 0, 154, 5, false);
                    NewLine10211.Name = "NewLine10211";
                    NewLine10211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine10211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 165, 0, 165, 5, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 0, 176, 5, false);
                    NewLine12211.Name = "NewLine12211";
                    NewLine12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 0, 187, 5, false);
                    NewLine13211.Name = "NewLine13211";
                    NewLine13211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 0, 198, 5, false);
                    NewLine14211.Name = "NewLine14211";
                    NewLine14211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 5, false);
                    NewLine15211.Name = "NewLine15211";
                    NewLine15211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 0, 223, 5, false);
                    NewLine16211.Name = "NewLine16211";
                    NewLine16211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 0, 234, 5, false);
                    NewLine17211.Name = "NewLine17211";
                    NewLine17211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine18211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 0, 245, 5, false);
                    NewLine18211.Name = "NewLine18211";
                    NewLine18211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine19211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 5, false);
                    NewLine19211.Name = "NewLine19211";
                    NewLine19211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine10311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 267, 0, 267, 5, false);
                    NewLine10311.Name = "NewLine10311";
                    NewLine10311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine10311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 278, 0, 278, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 5, false);
                    NewLine12311.Name = "NewLine12311";
                    NewLine12311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 291, 0, false);
                    NewLine1111111111.Name = "NewLine1111111111";
                    NewLine1111111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAM.CalcValue = TOPLAM.Value;
                    OTT.CalcValue = @"";
                    O1T.CalcValue = @"";
                    O2T.CalcValue = @"";
                    O3T.CalcValue = @"";
                    O4T.CalcValue = @"";
                    O5T.CalcValue = @"";
                    O6T.CalcValue = @"";
                    ITT.CalcValue = @"";
                    I1T.CalcValue = @"";
                    I2T.CalcValue = @"";
                    I3T.CalcValue = @"";
                    I4T.CalcValue = @"";
                    I5T.CalcValue = @"";
                    I6T.CalcValue = @"";
                    DTT.CalcValue = @"";
                    D1T.CalcValue = @"";
                    D2T.CalcValue = @"";
                    D3T.CalcValue = @"";
                    D4T.CalcValue = @"";
                    D5T.CalcValue = @"";
                    D6T.CalcValue = @"";
                    return new TTReportObject[] { TOPLAM,OTT,O1T,O2T,O3T,O4T,O5T,O6T,ITT,I1T,I2T,I3T,I4T,I5T,I6T,DTT,D1T,D2T,D3T,D4T,D5T,D6T};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    this.O1T.CalcValue = ((MedulaProvisionCountReport)ParentReport).O1T.ToString();
            this.O2T.CalcValue = ((MedulaProvisionCountReport)ParentReport).O2T.ToString();
            this.O3T.CalcValue = ((MedulaProvisionCountReport)ParentReport).O3T.ToString();
            this.O4T.CalcValue = ((MedulaProvisionCountReport)ParentReport).O4T.ToString();
            this.O5T.CalcValue = ((MedulaProvisionCountReport)ParentReport).O5T.ToString();
            this.O6T.CalcValue = ((MedulaProvisionCountReport)ParentReport).O6T.ToString();
            this.OTT.CalcValue = ((MedulaProvisionCountReport)ParentReport).OTT.ToString();

            this.I1T.CalcValue = ((MedulaProvisionCountReport)ParentReport).I1T.ToString();
            this.I2T.CalcValue = ((MedulaProvisionCountReport)ParentReport).I2T.ToString();
            this.I3T.CalcValue = ((MedulaProvisionCountReport)ParentReport).I3T.ToString();
            this.I4T.CalcValue = ((MedulaProvisionCountReport)ParentReport).I4T.ToString();
            this.I5T.CalcValue = ((MedulaProvisionCountReport)ParentReport).I5T.ToString();
            this.I6T.CalcValue = ((MedulaProvisionCountReport)ParentReport).I6T.ToString();
            this.ITT.CalcValue = ((MedulaProvisionCountReport)ParentReport).ITT.ToString();

            this.D1T.CalcValue = ((MedulaProvisionCountReport)ParentReport).D1T.ToString();
            this.D2T.CalcValue = ((MedulaProvisionCountReport)ParentReport).D2T.ToString();
            this.D3T.CalcValue = ((MedulaProvisionCountReport)ParentReport).D3T.ToString();
            this.D4T.CalcValue = ((MedulaProvisionCountReport)ParentReport).D4T.ToString();
            this.D5T.CalcValue = ((MedulaProvisionCountReport)ParentReport).D5T.ToString();
            this.D6T.CalcValue = ((MedulaProvisionCountReport)ParentReport).D6T.ToString();
            this.DTT.CalcValue = ((MedulaProvisionCountReport)ParentReport).DTT.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MedulaProvisionCountReport MyParentReport
            {
                get { return (MedulaProvisionCountReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BRANS { get {return Body().BRANS;} }
            public TTReportField OT { get {return Body().OT;} }
            public TTReportField O1 { get {return Body().O1;} }
            public TTReportField O2 { get {return Body().O2;} }
            public TTReportField O3 { get {return Body().O3;} }
            public TTReportField O4 { get {return Body().O4;} }
            public TTReportField O5 { get {return Body().O5;} }
            public TTReportField O6 { get {return Body().O6;} }
            public TTReportField IT { get {return Body().IT;} }
            public TTReportField I1 { get {return Body().I1;} }
            public TTReportField I2 { get {return Body().I2;} }
            public TTReportField I3 { get {return Body().I3;} }
            public TTReportField I4 { get {return Body().I4;} }
            public TTReportField I5 { get {return Body().I5;} }
            public TTReportField I6 { get {return Body().I6;} }
            public TTReportField DT { get {return Body().DT;} }
            public TTReportField D1 { get {return Body().D1;} }
            public TTReportField D2 { get {return Body().D2;} }
            public TTReportField D3 { get {return Body().D3;} }
            public TTReportField D4 { get {return Body().D4;} }
            public TTReportField D5 { get {return Body().D5;} }
            public TTReportField D6 { get {return Body().D6;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine1112 { get {return Body().NewLine1112;} }
            public TTReportShape NewLine1113 { get {return Body().NewLine1113;} }
            public TTReportShape NewLine1114 { get {return Body().NewLine1114;} }
            public TTReportShape NewLine1115 { get {return Body().NewLine1115;} }
            public TTReportShape NewLine1116 { get {return Body().NewLine1116;} }
            public TTReportShape NewLine1117 { get {return Body().NewLine1117;} }
            public TTReportShape NewLine1118 { get {return Body().NewLine1118;} }
            public TTReportShape NewLine1119 { get {return Body().NewLine1119;} }
            public TTReportShape NewLine1120 { get {return Body().NewLine1120;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine1122 { get {return Body().NewLine1122;} }
            public TTReportShape NewLine1123 { get {return Body().NewLine1123;} }
            public TTReportShape NewLine1124 { get {return Body().NewLine1124;} }
            public TTReportShape NewLine1125 { get {return Body().NewLine1125;} }
            public TTReportShape NewLine1126 { get {return Body().NewLine1126;} }
            public TTReportShape NewLine1127 { get {return Body().NewLine1127;} }
            public TTReportShape NewLine1128 { get {return Body().NewLine1128;} }
            public TTReportShape NewLine1129 { get {return Body().NewLine1129;} }
            public TTReportShape NewLine1130 { get {return Body().NewLine1130;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public TTReportShape NewLine1132 { get {return Body().NewLine1132;} }
            public TTReportShape NewLine111111111 { get {return Body().NewLine111111111;} }
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
                public MedulaProvisionCountReport MyParentReport
                {
                    get { return (MedulaProvisionCountReport)ParentReport; }
                }
                
                public TTReportField BRANS;
                public TTReportField OT;
                public TTReportField O1;
                public TTReportField O2;
                public TTReportField O3;
                public TTReportField O4;
                public TTReportField O5;
                public TTReportField O6;
                public TTReportField IT;
                public TTReportField I1;
                public TTReportField I2;
                public TTReportField I3;
                public TTReportField I4;
                public TTReportField I5;
                public TTReportField I6;
                public TTReportField DT;
                public TTReportField D1;
                public TTReportField D2;
                public TTReportField D3;
                public TTReportField D4;
                public TTReportField D5;
                public TTReportField D6;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine1113;
                public TTReportShape NewLine1114;
                public TTReportShape NewLine1115;
                public TTReportShape NewLine1116;
                public TTReportShape NewLine1117;
                public TTReportShape NewLine1118;
                public TTReportShape NewLine1119;
                public TTReportShape NewLine1120;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1122;
                public TTReportShape NewLine1123;
                public TTReportShape NewLine1124;
                public TTReportShape NewLine1125;
                public TTReportShape NewLine1126;
                public TTReportShape NewLine1127;
                public TTReportShape NewLine1128;
                public TTReportShape NewLine1129;
                public TTReportShape NewLine1130;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine1132;
                public TTReportShape NewLine111111111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    BRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 51, 5, false);
                    BRANS.Name = "BRANS";
                    BRANS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANS.MultiLine = EvetHayirEnum.ehEvet;
                    BRANS.NoClip = EvetHayirEnum.ehEvet;
                    BRANS.WordBreak = EvetHayirEnum.ehEvet;
                    BRANS.ExpandTabs = EvetHayirEnum.ehEvet;
                    BRANS.TextFont.Size = 8;
                    BRANS.TextFont.CharSet = 162;
                    BRANS.Value = @"";

                    OT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 63, 5, false);
                    OT.Name = "OT";
                    OT.FillStyle = FillStyleConstants.vbFSTransparent;
                    OT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OT.TextFont.Size = 8;
                    OT.TextFont.CharSet = 162;
                    OT.Value = @"";

                    O1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 0, 74, 5, false);
                    O1.Name = "O1";
                    O1.FillStyle = FillStyleConstants.vbFSTransparent;
                    O1.FieldType = ReportFieldTypeEnum.ftVariable;
                    O1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O1.TextFont.Size = 8;
                    O1.TextFont.CharSet = 162;
                    O1.Value = @"";

                    O2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 85, 5, false);
                    O2.Name = "O2";
                    O2.FillStyle = FillStyleConstants.vbFSTransparent;
                    O2.FieldType = ReportFieldTypeEnum.ftVariable;
                    O2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O2.TextFont.Size = 8;
                    O2.TextFont.CharSet = 162;
                    O2.Value = @"";

                    O3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 96, 5, false);
                    O3.Name = "O3";
                    O3.FillStyle = FillStyleConstants.vbFSTransparent;
                    O3.FieldType = ReportFieldTypeEnum.ftVariable;
                    O3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O3.TextFont.Size = 8;
                    O3.TextFont.CharSet = 162;
                    O3.Value = @"";

                    O4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 107, 5, false);
                    O4.Name = "O4";
                    O4.FillStyle = FillStyleConstants.vbFSTransparent;
                    O4.FieldType = ReportFieldTypeEnum.ftVariable;
                    O4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O4.TextFont.Size = 8;
                    O4.TextFont.CharSet = 162;
                    O4.Value = @"";

                    O5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 118, 5, false);
                    O5.Name = "O5";
                    O5.FillStyle = FillStyleConstants.vbFSTransparent;
                    O5.FieldType = ReportFieldTypeEnum.ftVariable;
                    O5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O5.TextFont.Size = 8;
                    O5.TextFont.CharSet = 162;
                    O5.Value = @"";

                    O6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 130, 5, false);
                    O6.Name = "O6";
                    O6.FillStyle = FillStyleConstants.vbFSTransparent;
                    O6.FieldType = ReportFieldTypeEnum.ftVariable;
                    O6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O6.TextFont.Size = 8;
                    O6.TextFont.CharSet = 162;
                    O6.Value = @"";

                    IT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 143, 5, false);
                    IT.Name = "IT";
                    IT.FillStyle = FillStyleConstants.vbFSTransparent;
                    IT.FieldType = ReportFieldTypeEnum.ftVariable;
                    IT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IT.TextFont.Size = 8;
                    IT.TextFont.CharSet = 162;
                    IT.Value = @"";

                    I1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 154, 5, false);
                    I1.Name = "I1";
                    I1.FillStyle = FillStyleConstants.vbFSTransparent;
                    I1.FieldType = ReportFieldTypeEnum.ftVariable;
                    I1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I1.TextFont.Size = 8;
                    I1.TextFont.CharSet = 162;
                    I1.Value = @"";

                    I2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 165, 5, false);
                    I2.Name = "I2";
                    I2.FillStyle = FillStyleConstants.vbFSTransparent;
                    I2.FieldType = ReportFieldTypeEnum.ftVariable;
                    I2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I2.TextFont.Size = 8;
                    I2.TextFont.CharSet = 162;
                    I2.Value = @"";

                    I3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 176, 5, false);
                    I3.Name = "I3";
                    I3.FillStyle = FillStyleConstants.vbFSTransparent;
                    I3.FieldType = ReportFieldTypeEnum.ftVariable;
                    I3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I3.TextFont.Size = 8;
                    I3.TextFont.CharSet = 162;
                    I3.Value = @"";

                    I4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 187, 5, false);
                    I4.Name = "I4";
                    I4.FillStyle = FillStyleConstants.vbFSTransparent;
                    I4.FieldType = ReportFieldTypeEnum.ftVariable;
                    I4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I4.TextFont.Size = 8;
                    I4.TextFont.CharSet = 162;
                    I4.Value = @"";

                    I5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 198, 5, false);
                    I5.Name = "I5";
                    I5.FillStyle = FillStyleConstants.vbFSTransparent;
                    I5.FieldType = ReportFieldTypeEnum.ftVariable;
                    I5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I5.TextFont.Size = 8;
                    I5.TextFont.CharSet = 162;
                    I5.Value = @"";

                    I6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 210, 5, false);
                    I6.Name = "I6";
                    I6.FillStyle = FillStyleConstants.vbFSTransparent;
                    I6.FieldType = ReportFieldTypeEnum.ftVariable;
                    I6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    I6.TextFont.Size = 8;
                    I6.TextFont.CharSet = 162;
                    I6.Value = @"";

                    DT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 223, 5, false);
                    DT.Name = "DT";
                    DT.FillStyle = FillStyleConstants.vbFSTransparent;
                    DT.FieldType = ReportFieldTypeEnum.ftVariable;
                    DT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DT.TextFont.Size = 8;
                    DT.TextFont.CharSet = 162;
                    DT.Value = @"";

                    D1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 234, 5, false);
                    D1.Name = "D1";
                    D1.FillStyle = FillStyleConstants.vbFSTransparent;
                    D1.FieldType = ReportFieldTypeEnum.ftVariable;
                    D1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D1.TextFont.Size = 8;
                    D1.TextFont.CharSet = 162;
                    D1.Value = @"";

                    D2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 0, 245, 5, false);
                    D2.Name = "D2";
                    D2.FillStyle = FillStyleConstants.vbFSTransparent;
                    D2.FieldType = ReportFieldTypeEnum.ftVariable;
                    D2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D2.TextFont.Size = 8;
                    D2.TextFont.CharSet = 162;
                    D2.Value = @"";

                    D3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 256, 5, false);
                    D3.Name = "D3";
                    D3.FillStyle = FillStyleConstants.vbFSTransparent;
                    D3.FieldType = ReportFieldTypeEnum.ftVariable;
                    D3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D3.TextFont.Size = 8;
                    D3.TextFont.CharSet = 162;
                    D3.Value = @"";

                    D4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 267, 5, false);
                    D4.Name = "D4";
                    D4.FillStyle = FillStyleConstants.vbFSTransparent;
                    D4.FieldType = ReportFieldTypeEnum.ftVariable;
                    D4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D4.TextFont.Size = 8;
                    D4.TextFont.CharSet = 162;
                    D4.Value = @"";

                    D5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 278, 5, false);
                    D5.Name = "D5";
                    D5.FillStyle = FillStyleConstants.vbFSTransparent;
                    D5.FieldType = ReportFieldTypeEnum.ftVariable;
                    D5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D5.TextFont.Size = 8;
                    D5.TextFont.CharSet = 162;
                    D5.Value = @"";

                    D6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 279, 0, 290, 5, false);
                    D6.Name = "D6";
                    D6.FillStyle = FillStyleConstants.vbFSTransparent;
                    D6.FieldType = ReportFieldTypeEnum.ftVariable;
                    D6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    D6.TextFont.Size = 8;
                    D6.TextFont.CharSet = 162;
                    D6.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 5, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 63, 0, 63, 5, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 0, 74, 5, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 85, 0, 85, 5, false);
                    NewLine1114.Name = "NewLine1114";
                    NewLine1114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1114.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 96, 0, 96, 5, false);
                    NewLine1115.Name = "NewLine1115";
                    NewLine1115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1115.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 107, 5, false);
                    NewLine1116.Name = "NewLine1116";
                    NewLine1116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1116.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 118, 0, 118, 5, false);
                    NewLine1117.Name = "NewLine1117";
                    NewLine1117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1117.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1118 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 0, 131, 5, false);
                    NewLine1118.Name = "NewLine1118";
                    NewLine1118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1118.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1119 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 0, 143, 5, false);
                    NewLine1119.Name = "NewLine1119";
                    NewLine1119.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1119.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1120 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 0, 154, 5, false);
                    NewLine1120.Name = "NewLine1120";
                    NewLine1120.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1120.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 165, 0, 165, 5, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 0, 176, 5, false);
                    NewLine1122.Name = "NewLine1122";
                    NewLine1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1122.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 0, 187, 5, false);
                    NewLine1123.Name = "NewLine1123";
                    NewLine1123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1123.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 0, 198, 5, false);
                    NewLine1124.Name = "NewLine1124";
                    NewLine1124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1124.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1125 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 0, 211, 5, false);
                    NewLine1125.Name = "NewLine1125";
                    NewLine1125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1125.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1126 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 0, 223, 5, false);
                    NewLine1126.Name = "NewLine1126";
                    NewLine1126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1126.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1127 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 0, 234, 5, false);
                    NewLine1127.Name = "NewLine1127";
                    NewLine1127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1127.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1128 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 0, 245, 5, false);
                    NewLine1128.Name = "NewLine1128";
                    NewLine1128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1128.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1129 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 256, 0, 256, 5, false);
                    NewLine1129.Name = "NewLine1129";
                    NewLine1129.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1129.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1130 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 267, 0, 267, 5, false);
                    NewLine1130.Name = "NewLine1130";
                    NewLine1130.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1130.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 278, 0, 278, 5, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1131.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 291, 0, 291, 5, false);
                    NewLine1132.Name = "NewLine1132";
                    NewLine1132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1132.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 291, 0, false);
                    NewLine111111111.Name = "NewLine111111111";
                    NewLine111111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BRANS.CalcValue = @"";
                    OT.CalcValue = @"";
                    O1.CalcValue = @"";
                    O2.CalcValue = @"";
                    O3.CalcValue = @"";
                    O4.CalcValue = @"";
                    O5.CalcValue = @"";
                    O6.CalcValue = @"";
                    IT.CalcValue = @"";
                    I1.CalcValue = @"";
                    I2.CalcValue = @"";
                    I3.CalcValue = @"";
                    I4.CalcValue = @"";
                    I5.CalcValue = @"";
                    I6.CalcValue = @"";
                    DT.CalcValue = @"";
                    D1.CalcValue = @"";
                    D2.CalcValue = @"";
                    D3.CalcValue = @"";
                    D4.CalcValue = @"";
                    D5.CalcValue = @"";
                    D6.CalcValue = @"";
                    return new TTReportObject[] { BRANS,OT,O1,O2,O3,O4,O5,O6,IT,I1,I2,I3,I4,I5,I6,DT,D1,D2,D3,D4,D5,D6};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(((MedulaProvisionCountReport)ParentReport).Sayac > 0)
            {
                this.BRANS.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].Name;
                
                this.O1.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O1.ToString();
                this.O2.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O2.ToString();
                this.O3.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O3.ToString();
                this.O4.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O4.ToString();
                this.O5.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O5.ToString();
                this.O6.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O6.ToString();
                this.OT.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].OT.ToString();
                
                this.I1.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I1.ToString();
                this.I2.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I2.ToString();
                this.I3.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I3.ToString();
                this.I4.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I4.ToString();
                this.I5.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I5.ToString();
                this.I6.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I6.ToString();
                this.IT.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].IT.ToString();

                this.D1.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D1.ToString();
                this.D2.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D2.ToString();
                this.D3.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D3.ToString();
                this.D4.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D4.ToString();
                this.D5.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D5.ToString();
                this.D6.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D6.ToString();
                this.DT.CalcValue = ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].DT.ToString();
                
                ((MedulaProvisionCountReport)ParentReport).O1T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O1;
                ((MedulaProvisionCountReport)ParentReport).O2T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O2;
                ((MedulaProvisionCountReport)ParentReport).O3T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O3;
                ((MedulaProvisionCountReport)ParentReport).O4T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O4;
                ((MedulaProvisionCountReport)ParentReport).O5T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O5;
                ((MedulaProvisionCountReport)ParentReport).O6T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].O6;
                ((MedulaProvisionCountReport)ParentReport).OTT += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].OT;
                
                ((MedulaProvisionCountReport)ParentReport).I1T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I1;
                ((MedulaProvisionCountReport)ParentReport).I2T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I2;
                ((MedulaProvisionCountReport)ParentReport).I3T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I3;
                ((MedulaProvisionCountReport)ParentReport).I4T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I4;
                ((MedulaProvisionCountReport)ParentReport).I5T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I5;
                ((MedulaProvisionCountReport)ParentReport).I6T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].I6;
                ((MedulaProvisionCountReport)ParentReport).ITT += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].IT;

                ((MedulaProvisionCountReport)ParentReport).D1T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D1;
                ((MedulaProvisionCountReport)ParentReport).D2T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D2;
                ((MedulaProvisionCountReport)ParentReport).D3T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D3;
                ((MedulaProvisionCountReport)ParentReport).D4T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D4;
                ((MedulaProvisionCountReport)ParentReport).D5T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D5;
                ((MedulaProvisionCountReport)ParentReport).D6T += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].D6;
                ((MedulaProvisionCountReport)ParentReport).DTT += ((MedulaProvisionCountReport)ParentReport).bransList[((MedulaProvisionCountReport)ParentReport).yazdirmaSayac].DT;

                ((MedulaProvisionCountReport)ParentReport).yazdirmaSayac ++;
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

        public MedulaProvisionCountReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTD = new PARTDGroup(PARTA,"PARTD");
            PARTE = new PARTEGroup(PARTA,"PARTE");
            PARTB = new PARTBGroup(PARTE,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
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
            Name = "MEDULAPROVISIONCOUNTREPORT";
            Caption = "Medula Takip Sayıları Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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