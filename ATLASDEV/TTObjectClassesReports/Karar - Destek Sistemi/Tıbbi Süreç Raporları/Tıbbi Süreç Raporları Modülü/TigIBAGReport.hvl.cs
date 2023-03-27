
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
    /// Tig Modülü İşlem Bazlı Ayaktan Gruplar Raporu
    /// </summary>
    public partial class TigIBAGReport : TTReport
    {
#region Methods
   public class ProcedureWithCounts {
            public string procedureName;
            public string procedureIbagCode;
            public int sgkCount;
            public int paidCount;
            public int otherCount;
            
            public ProcedureWithCounts(string procedureName,string procedureIbagCode, int sgkCount
                                        ,int paidCount,int otherCount){
                this.procedureName = procedureName;
                this.procedureIbagCode = procedureIbagCode;
                this.sgkCount = sgkCount;
                this.paidCount = paidCount;
                this.otherCount = otherCount;
            }
        }
        public int rowCounter=0;
        List<ProcedureWithCounts> IbagList = new List<ProcedureWithCounts>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? ExaminationDateBegin = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ExaminationDateEnd = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class queryGroup : TTReportGroup
        {
            public TigIBAGReport MyParentReport
            {
                get { return (TigIBAGReport)ParentReport; }
            }

            new public queryGroupHeader Header()
            {
                return (queryGroupHeader)_header;
            }

            new public queryGroupFooter Footer()
            {
                return (queryGroupFooter)_footer;
            }

            public queryGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public queryGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new queryGroupHeader(this);
                _footer = new queryGroupFooter(this);

            }

            public partial class queryGroupHeader : TTReportSection
            {
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                 
                public queryGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region QUERY HEADER_Script
                    BindingList<SubEpisodeProtocol.GetTigIBAG_Class> IbagQueryList = SubEpisodeProtocol.GetTigIBAG(MyParentReport.RuntimeParameters.ExaminationDateBegin.Value, MyParentReport.RuntimeParameters.ExaminationDateEnd.Value);
                    string procedureCode = String.Empty, procedureType = String.Empty;
                    procedureCode = IbagQueryList[0].Externalcode.ToString();
                    int rowCount = 0;
                    int sgk = 0, paid = 0, other = 0;
                    for (int i = 0; i < IbagQueryList.Count; i++)
                    {
                        SubEpisodeProtocol.GetTigIBAG_Class ibagItem = IbagQueryList[i];
                        bool rowCheck = true;
                        if (ibagItem.Externalcode.ToString() == "P915030" )
                        {
                            procedureType = "Fizik Tedavi ve Rehabilitasyon D Grubu";
                        }
                        else if (ibagItem.Externalcode.ToString() == "P915031")
                        {
                            procedureType = "Fizik Tedavi ve Rehabilitasyon C Grubu";
                        }
                        else if (ibagItem.Externalcode.ToString() == "P915032")
                        {
                            procedureType = "Fizik Tedavi ve Rehabilitasyon B Grubu";
                        }
                        else if (ibagItem.Externalcode.ToString() == "P915033")
                        {
                            procedureType = "Fizik Tedavi ve Rehabilitasyon A Grubu";
                        }
                        else if (ibagItem.Externalcode.ToString() == "704210" || ibagItem.Externalcode.ToString() == "704230" || ibagItem.Externalcode.ToString() == "704233" || ibagItem.Externalcode.ToString() == "704234")
                        {
                            procedureType = "Hemodiyaliz";
                        }
                        else if (ibagItem.Externalcode.ToString() == "800060" || ibagItem.Externalcode.ToString() == "800330" || ibagItem.Externalcode.ToString() == "800340" || ibagItem.Externalcode.ToString() == "800350"
                          || ibagItem.Externalcode.ToString() == "800360" || ibagItem.Externalcode.ToString() == "800370" || ibagItem.Externalcode.ToString() == "800380" || ibagItem.Externalcode.ToString() == "800390"
                          || ibagItem.Externalcode.ToString() == "800400" || ibagItem.Externalcode.ToString() == "800410" || ibagItem.Externalcode.ToString() == "800420" || ibagItem.Externalcode.ToString() == "800430" || ibagItem.Externalcode.ToString() == "800440")
                        {
                            procedureType = "Radyoterapi";
                        }
                        else if (ibagItem.Externalcode.ToString() == "704692" || ibagItem.Externalcode.ToString() == "704693" || ibagItem.Externalcode.ToString() == "704700" || ibagItem.Externalcode.ToString() == "604155")
                        {
                            procedureType = "Kemoterapi";
                        }
                        else if (ibagItem.Externalcode.ToString() == "800160")
                        {
                            procedureType = "Tomoterapi";
                        }
                        else if (ibagItem.Externalcode.ToString() == "618640" || ibagItem.Externalcode.ToString() == "618641" || ibagItem.Externalcode.ToString() == "618642")
                        {
                            procedureType = "ESWL";
                        }
                        else if (ibagItem.Externalcode.ToString() == "621071")
                        {
                            procedureType = "Sünnet";
                        }
                        else if (ibagItem.Externalcode.ToString() == "P702679")
                        {
                            procedureType = "Toplum Ruh Sağlığı Hizmetleri";
                        }
                        else if (ibagItem.Externalcode.ToString() == "evdesaglik")
                        {
                            procedureType = "Evde Sağlık";
                        }
                        int payerType = Convert.ToInt16(IbagQueryList[i].Payertype);
                        if (payerType == 0)
                        {
                            bool found = false;
                            for (int j = 0; j < MyParentReport.IbagList.Count; j++)
                            {
                                if (MyParentReport.IbagList[j].procedureName == procedureType)
                                {
                                    var tmp = new ProcedureWithCounts("", "", Convert.ToInt16(IbagQueryList[i].Procedurecount), 0, 0);
                                    MyParentReport.IbagList[j].sgkCount += tmp.sgkCount;
                                    MyParentReport.IbagList[j].paidCount += tmp.paidCount;
                                    MyParentReport.IbagList[j].otherCount += tmp.otherCount;
                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                MyParentReport.IbagList.Add(new ProcedureWithCounts(procedureType, "", Convert.ToInt16(IbagQueryList[i].Procedurecount), 0, 0));
                            }

                        }
                        else if (payerType == 1)
                        {
                            bool found = false;
                            for (int j = 0; j < MyParentReport.IbagList.Count; j++)
                            {
                                if (MyParentReport.IbagList[j].procedureName == procedureType)
                                {
                                    var tmp = new ProcedureWithCounts("", "", 0, Convert.ToInt16(IbagQueryList[i].Procedurecount), 0);
                                    MyParentReport.IbagList[j].sgkCount += tmp.sgkCount;
                                    MyParentReport.IbagList[j].paidCount += tmp.paidCount;
                                    MyParentReport.IbagList[j].otherCount += tmp.otherCount;
                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                MyParentReport.IbagList.Add(new ProcedureWithCounts(procedureType, "", 0, Convert.ToInt16(IbagQueryList[i].Procedurecount), 0));
                            }
                        }
                        else
                        {
                            bool found = false;
                            for (int j = 0; j < MyParentReport.IbagList.Count; j++)
                            {
                                if (MyParentReport.IbagList[j].procedureName == procedureType)
                                {
                                    var tmp = new ProcedureWithCounts("", "", 0, 0, Convert.ToInt16(IbagQueryList[i].Procedurecount));
                                    MyParentReport.IbagList[j].sgkCount += tmp.sgkCount;
                                    MyParentReport.IbagList[j].paidCount += tmp.paidCount;
                                    MyParentReport.IbagList[j].otherCount += tmp.otherCount;
                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                MyParentReport.IbagList.Add(new ProcedureWithCounts(procedureType, "", 0, 0, Convert.ToInt16(IbagQueryList[i].Procedurecount)));
                            }
                        }
                        
                        
                    }
                    
                    for (int i = 0; i < MyParentReport.IbagList.Count(); i++)
                    {
                        var temp = MyParentReport.IbagList[i];
                        if (temp.sgkCount == 0 && temp.paidCount == 0 && temp.otherCount == 0)
                        {
                            MyParentReport.IbagList.Remove(MyParentReport.IbagList[i]);
                        }
                    }
                    MyParentReport.MAIN.RepeatCount = MyParentReport.IbagList.Count() ;
#endregion QUERY HEADER_Script
                }
            }
            public partial class queryGroupFooter : TTReportSection
            {
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                 
                public queryGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public queryGroup query;

        public partial class FirstGroup : TTReportGroup
        {
            public TigIBAGReport MyParentReport
            {
                get { return (TigIBAGReport)ParentReport; }
            }

            new public FirstGroupHeader Header()
            {
                return (FirstGroupHeader)_header;
            }

            new public FirstGroupFooter Footer()
            {
                return (FirstGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public FirstGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FirstGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FirstGroupHeader(this);
                _footer = new FirstGroupFooter(this);

            }

            public partial class FirstGroupHeader : TTReportSection
            {
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField3;
                public TTReportField NewField13; 
                public FirstGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 53;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 7, 182, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TANIYA İLİŞKİN GRUPLAR";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 16, 182, 24, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İŞLEM BAZLI AYAKTAN GRUPLAR";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 39, 34, 44, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Başlangıç Tarihi     :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 45, 34, 50, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Bitiş Tarihi              :";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 39, 66, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.Value = @"{@ExaminationDateBegin@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 45, 66, 50, false);
                    NewField13.Name = "NewField13";
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.Value = @"{@ExaminationDateEnd@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField3.CalcValue = MyParentReport.RuntimeParameters.ExaminationDateBegin.ToString();
                    NewField13.CalcValue = MyParentReport.RuntimeParameters.ExaminationDateEnd.ToString();
                    return new TTReportObject[] { NewField1,NewField11,NewField2,NewField12,NewField3,NewField13};
                }
            }
            public partial class FirstGroupFooter : TTReportSection
            {
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                 
                public FirstGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public FirstGroup First;

        public partial class ReportGroup : TTReportGroup
        {
            public TigIBAGReport MyParentReport
            {
                get { return (TigIBAGReport)ParentReport; }
            }

            new public ReportGroupHeader Header()
            {
                return (ReportGroupHeader)_header;
            }

            new public ReportGroupFooter Footer()
            {
                return (ReportGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public ReportGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ReportGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ReportGroupHeader(this);
                _footer = new ReportGroupFooter(this);

            }

            public partial class ReportGroupHeader : TTReportSection
            {
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15; 
                public ReportGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 17, 72, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İşlem";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 17, 104, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"IBAG Kodu";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 17, 135, 25, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"SGK Mensubu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 17, 157, 25, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Ücretli Hasta";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 17, 180, 25, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Diğer
";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 17, 203, 25, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Toplam";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14,NewField15};
                }
            }
            public partial class ReportGroupFooter : TTReportSection
            {
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                 
                public ReportGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ReportGroup Report;

        public partial class MAINGroup : TTReportGroup
        {
            public TigIBAGReport MyParentReport
            {
                get { return (TigIBAGReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Procedure { get {return Body().Procedure;} }
            public TTReportField IBAGCode { get {return Body().IBAGCode;} }
            public TTReportField SGKCount { get {return Body().SGKCount;} }
            public TTReportField PaidCount { get {return Body().PaidCount;} }
            public TTReportField OtherCount { get {return Body().OtherCount;} }
            public TTReportField SumOfProcedure { get {return Body().SumOfProcedure;} }
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
                public TigIBAGReport MyParentReport
                {
                    get { return (TigIBAGReport)ParentReport; }
                }
                
                public TTReportField Procedure;
                public TTReportField IBAGCode;
                public TTReportField SGKCount;
                public TTReportField PaidCount;
                public TTReportField OtherCount;
                public TTReportField SumOfProcedure; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    Procedure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 72, 10, false);
                    Procedure.Name = "Procedure";
                    Procedure.DrawStyle = DrawStyleConstants.vbSolid;
                    Procedure.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Procedure.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Procedure.TextFont.Name = "Arial";
                    Procedure.TextFont.CharSet = 162;
                    Procedure.Value = @"";

                    IBAGCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 0, 104, 10, false);
                    IBAGCode.Name = "IBAGCode";
                    IBAGCode.DrawStyle = DrawStyleConstants.vbSolid;
                    IBAGCode.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IBAGCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IBAGCode.TextFont.Name = "Arial";
                    IBAGCode.TextFont.CharSet = 162;
                    IBAGCode.Value = @"";

                    SGKCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 135, 10, false);
                    SGKCount.Name = "SGKCount";
                    SGKCount.DrawStyle = DrawStyleConstants.vbSolid;
                    SGKCount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SGKCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SGKCount.TextFont.Name = "Arial";
                    SGKCount.TextFont.CharSet = 162;
                    SGKCount.Value = @"";

                    PaidCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 157, 10, false);
                    PaidCount.Name = "PaidCount";
                    PaidCount.DrawStyle = DrawStyleConstants.vbSolid;
                    PaidCount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PaidCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PaidCount.TextFont.Name = "Arial";
                    PaidCount.TextFont.CharSet = 162;
                    PaidCount.Value = @"";

                    OtherCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 180, 10, false);
                    OtherCount.Name = "OtherCount";
                    OtherCount.DrawStyle = DrawStyleConstants.vbSolid;
                    OtherCount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OtherCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OtherCount.TextFont.Name = "Arial";
                    OtherCount.TextFont.CharSet = 162;
                    OtherCount.Value = @"";

                    SumOfProcedure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 203, 10, false);
                    SumOfProcedure.Name = "SumOfProcedure";
                    SumOfProcedure.DrawStyle = DrawStyleConstants.vbSolid;
                    SumOfProcedure.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SumOfProcedure.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SumOfProcedure.TextFont.Name = "Arial";
                    SumOfProcedure.TextFont.CharSet = 162;
                    SumOfProcedure.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Procedure.CalcValue = Procedure.Value;
                    IBAGCode.CalcValue = IBAGCode.Value;
                    SGKCount.CalcValue = SGKCount.Value;
                    PaidCount.CalcValue = PaidCount.Value;
                    OtherCount.CalcValue = OtherCount.Value;
                    SumOfProcedure.CalcValue = SumOfProcedure.Value;
                    return new TTReportObject[] { Procedure,IBAGCode,SGKCount,PaidCount,OtherCount,SumOfProcedure};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(MyParentReport.IbagList.Count()>0){
                ProcedureWithCounts obj = MyParentReport.IbagList[MyParentReport.rowCounter];
                    this.Procedure.CalcValue = obj.procedureName;
                    this.IBAGCode.CalcValue = obj.procedureIbagCode;
                    this.SGKCount.CalcValue = obj.sgkCount.ToString();
                    this.PaidCount.CalcValue = obj.paidCount.ToString();
                    this.OtherCount.CalcValue = obj.otherCount.ToString();
                    this.SumOfProcedure.CalcValue = (obj.sgkCount + obj.paidCount + obj.otherCount).ToString();
                    MyParentReport.rowCounter += 1;
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

        public TigIBAGReport()
        {
            query = new queryGroup(this,"query");
            First = new FirstGroup(query,"First");
            Report = new ReportGroup(First,"Report");
            MAIN = new MAINGroup(Report,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ExaminationDateBegin", "", "Muayene Tarihi Başlangıç", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ExaminationDateEnd", "", "Muayene Tarihi Bitiş", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ExaminationDateBegin"))
                _runtimeParameters.ExaminationDateBegin = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ExaminationDateBegin"]);
            if (parameters.ContainsKey("ExaminationDateEnd"))
                _runtimeParameters.ExaminationDateEnd = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ExaminationDateEnd"]);
            Name = "TIGIBAGREPORT";
            Caption = "Tig Modülü İşlem Bazlı Ayaktan Gruplar Raporu";
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