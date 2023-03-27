
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
    /// Tig Modülü Branş Bazlı Ayaktan Gruplar Raporu
    /// </summary>
    public partial class TigBBAGReport : TTReport
    {
#region Methods
   public class SpecialityWithCounts {
            public string specialityName;
            public string specialityBbagCode;
            public int sgkCount;
            public int paidCount;
            public int otherCount;
            
            public SpecialityWithCounts(string specialityName,string specialityBbagCode, int sgkCount
                                        ,int paidCount=0,int otherCount=0){
                this.specialityName = specialityName;
                this.specialityBbagCode = specialityBbagCode;
                this.sgkCount = sgkCount;
                this.paidCount = paidCount;
                this.otherCount = otherCount;
            }
        }
        public int rowCounter=0;
        List<SpecialityWithCounts> BbagList = new List<SpecialityWithCounts>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? ExaminationDateBegin = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ExaminationDateEnd = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class queryGroup : TTReportGroup
        {
            public TigBBAGReport MyParentReport
            {
                get { return (TigBBAGReport)ParentReport; }
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
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
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
                    BindingList<SubEpisodeProtocol.GetTigBBAG_Class> BbagQueryList = SubEpisodeProtocol.GetTigBBAG(MyParentReport.RuntimeParameters.ExaminationDateBegin.Value, MyParentReport.RuntimeParameters.ExaminationDateEnd.Value);
                    string specialityName, specialityCode = String.Empty;
                    specialityName = BbagQueryList[0].Name;

                    int sgk = 0, paid = 0, other = 0;
                    for (int i = 0; i < BbagQueryList.Count; i++)
                    {
                        int payerType = Convert.ToInt16(BbagQueryList[i].Payertype);
                        if (payerType == 0)
                        {
                            bool found = false;
                            for (int j = 0; j < MyParentReport.BbagList.Count; j++)
                            {
                                if (MyParentReport.BbagList[j].specialityName == BbagQueryList[i].Name)
                                {
                                    var tmp = new SpecialityWithCounts(BbagQueryList[i].Name, "", Convert.ToInt16(BbagQueryList[i].Nqlcolumn), 0, 0);
                                    MyParentReport.BbagList[j].sgkCount += tmp.sgkCount;
                                    MyParentReport.BbagList[j].paidCount += tmp.paidCount;
                                    MyParentReport.BbagList[j].otherCount += tmp.otherCount;
                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                MyParentReport.BbagList.Add(new SpecialityWithCounts(BbagQueryList[i].Name, "BBAG-" + BbagQueryList[i].Code, Convert.ToInt16(BbagQueryList[i].Nqlcolumn), 0, 0));
                            }

                        }
                        else if (payerType == 1)
                        {
                            bool found = false;
                            for (int j = 0; j < MyParentReport.BbagList.Count; j++)
                            {
                                if (MyParentReport.BbagList[j].specialityName == BbagQueryList[i].Name)
                                {
                                    var tmp = new SpecialityWithCounts(BbagQueryList[i].Name, "", 0, Convert.ToInt16(BbagQueryList[i].Nqlcolumn), 0);
                                    MyParentReport.BbagList[j].sgkCount += tmp.sgkCount;
                                    MyParentReport.BbagList[j].paidCount += tmp.paidCount;
                                    MyParentReport.BbagList[j].otherCount += tmp.otherCount;
                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                MyParentReport.BbagList.Add(new SpecialityWithCounts(BbagQueryList[i].Name, "BBAG-"+BbagQueryList[i].Code, 0, Convert.ToInt16(BbagQueryList[i].Nqlcolumn), 0));
                            }
                        }
                        else
                        {
                            bool found = false;
                            for (int j = 0; j < MyParentReport.BbagList.Count; j++)
                            {
                                if (MyParentReport.BbagList[j].specialityName == BbagQueryList[i].Name)
                                {
                                    var tmp = new SpecialityWithCounts(BbagQueryList[i].Name, "", 0, 0, Convert.ToInt16(BbagQueryList[i].Nqlcolumn));
                                    MyParentReport.BbagList[j].sgkCount += tmp.sgkCount;
                                    MyParentReport.BbagList[j].paidCount += tmp.paidCount;
                                    MyParentReport.BbagList[j].otherCount += tmp.otherCount;
                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                MyParentReport.BbagList.Add(new SpecialityWithCounts(BbagQueryList[i].Name, "BBAG-" + BbagQueryList[i].Code, 0, 0, Convert.ToInt16(BbagQueryList[i].Nqlcolumn)));
                            }
                        }
                    }
                    MyParentReport.MAIN.RepeatCount = MyParentReport.BbagList.Count();
#endregion QUERY HEADER_Script
                }
            }
            public partial class queryGroupFooter : TTReportSection
            {
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
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
            public TigBBAGReport MyParentReport
            {
                get { return (TigBBAGReport)ParentReport; }
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
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
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
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 7, 184, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TANIYA İLİŞKİN GRUPLAR";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 184, 24, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"BRANŞ BAZLI AYAKTAN GRUPLAR";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 39, 39, 44, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Başlangıç Tarihi     :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 45, 39, 50, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Bitiş Tarihi              :";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 39, 71, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.TextFormat = @"dd/MM/yyyy";
                    NewField3.Value = @"{@ExaminationDateBegin@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 71, 50, false);
                    NewField13.Name = "NewField13";
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.TextFormat = @"dd/MM/yyyy";
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
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
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
            public TigBBAGReport MyParentReport
            {
                get { return (TigBBAGReport)ParentReport; }
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
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
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
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 17, 68, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Branş";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 17, 100, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"BBAG Kodu";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 17, 131, 25, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"SGK Mensubu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 17, 153, 25, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Ücretli Hasta";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 17, 176, 25, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Diğer
";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 17, 199, 25, false);
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
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
                }
                 
                public ReportGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ReportGroup Report;

        public partial class MAINGroup : TTReportGroup
        {
            public TigBBAGReport MyParentReport
            {
                get { return (TigBBAGReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Speciality { get {return Body().Speciality;} }
            public TTReportField BBAGCode { get {return Body().BBAGCode;} }
            public TTReportField SGKCount { get {return Body().SGKCount;} }
            public TTReportField PaidCount { get {return Body().PaidCount;} }
            public TTReportField OtherCount { get {return Body().OtherCount;} }
            public TTReportField SumOfSpeciality { get {return Body().SumOfSpeciality;} }
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
                public TigBBAGReport MyParentReport
                {
                    get { return (TigBBAGReport)ParentReport; }
                }
                
                public TTReportField Speciality;
                public TTReportField BBAGCode;
                public TTReportField SGKCount;
                public TTReportField PaidCount;
                public TTReportField OtherCount;
                public TTReportField SumOfSpeciality; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    Speciality = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 68, 10, false);
                    Speciality.Name = "Speciality";
                    Speciality.DrawStyle = DrawStyleConstants.vbSolid;
                    Speciality.FieldType = ReportFieldTypeEnum.ftVariable;
                    Speciality.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Speciality.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Speciality.NoClip = EvetHayirEnum.ehEvet;
                    Speciality.TextFont.Name = "Arial";
                    Speciality.TextFont.CharSet = 162;
                    Speciality.Value = @"";

                    BBAGCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 0, 100, 10, false);
                    BBAGCode.Name = "BBAGCode";
                    BBAGCode.DrawStyle = DrawStyleConstants.vbSolid;
                    BBAGCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    BBAGCode.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BBAGCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BBAGCode.NoClip = EvetHayirEnum.ehEvet;
                    BBAGCode.TextFont.Name = "Arial";
                    BBAGCode.TextFont.CharSet = 162;
                    BBAGCode.Value = @"";

                    SGKCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 131, 10, false);
                    SGKCount.Name = "SGKCount";
                    SGKCount.DrawStyle = DrawStyleConstants.vbSolid;
                    SGKCount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SGKCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SGKCount.NoClip = EvetHayirEnum.ehEvet;
                    SGKCount.TextFont.Name = "Arial";
                    SGKCount.TextFont.CharSet = 162;
                    SGKCount.Value = @"";

                    PaidCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 153, 10, false);
                    PaidCount.Name = "PaidCount";
                    PaidCount.DrawStyle = DrawStyleConstants.vbSolid;
                    PaidCount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PaidCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PaidCount.NoClip = EvetHayirEnum.ehEvet;
                    PaidCount.TextFont.Name = "Arial";
                    PaidCount.TextFont.CharSet = 162;
                    PaidCount.Value = @"";

                    OtherCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 176, 10, false);
                    OtherCount.Name = "OtherCount";
                    OtherCount.DrawStyle = DrawStyleConstants.vbSolid;
                    OtherCount.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OtherCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OtherCount.NoClip = EvetHayirEnum.ehEvet;
                    OtherCount.TextFont.Name = "Arial";
                    OtherCount.TextFont.CharSet = 162;
                    OtherCount.Value = @"";

                    SumOfSpeciality = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 199, 10, false);
                    SumOfSpeciality.Name = "SumOfSpeciality";
                    SumOfSpeciality.DrawStyle = DrawStyleConstants.vbSolid;
                    SumOfSpeciality.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SumOfSpeciality.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SumOfSpeciality.NoClip = EvetHayirEnum.ehEvet;
                    SumOfSpeciality.TextFont.Bold = true;
                    SumOfSpeciality.TextFont.CharSet = 162;
                    SumOfSpeciality.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Speciality.CalcValue = @"";
                    BBAGCode.CalcValue = @"";
                    SGKCount.CalcValue = SGKCount.Value;
                    PaidCount.CalcValue = PaidCount.Value;
                    OtherCount.CalcValue = OtherCount.Value;
                    SumOfSpeciality.CalcValue = SumOfSpeciality.Value;
                    return new TTReportObject[] { Speciality,BBAGCode,SGKCount,PaidCount,OtherCount,SumOfSpeciality};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    SpecialityWithCounts obj = MyParentReport.BbagList[MyParentReport.rowCounter];
                    this.Speciality.CalcValue = obj.specialityName;
                    this.BBAGCode.CalcValue = obj.specialityBbagCode;
                    this.SGKCount.CalcValue = obj.sgkCount.ToString();
                    this.PaidCount.CalcValue = obj.paidCount.ToString();
                    this.OtherCount.CalcValue = obj.otherCount.ToString();
                    this.SumOfSpeciality.CalcValue = (obj.sgkCount + obj.paidCount + obj.otherCount).ToString();
                    MyParentReport.rowCounter += 1;
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

        public TigBBAGReport()
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
            Name = "TIGBBAGREPORT";
            Caption = "Tig Modülü Branş Bazlı Ayaktan Gruplar Raporu";
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