
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
    /// Sağlık Kurulu İstatistikleri Raporu
    /// </summary>
    public partial class HealthCommitteeStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public SuccessStatusEnum? SUCCESSTATUS = (SuccessStatusEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SuccessStatusEnum"].ConvertValue("");
            public HealthCommitteeTypeEnum? HEALTHCOMITEETYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue("");
            public HealthCommitteeTypeEnum? HCTYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue("");
            public int? HCTYPEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<string> PATIENTGROUP = new List<string>();
            public List<int> PATIENTGROUPINT = new List<int>();
            public int? PATIENTGROUPFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string PATIENTGROUPSTRING = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public HealthCommitteeStatisticsReport MyParentReport
            {
                get { return (HealthCommitteeStatisticsReport)ParentReport; }
            }

            new public PARTBGroupBody Body()
            {
                return (PARTBGroupBody)_body;
            }
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
                _header = null;
                _footer = null;
                _body = new PARTBGroupBody(this);
            }

            public partial class PARTBGroupBody : TTReportSection
            {
                public HealthCommitteeStatisticsReport MyParentReport
                {
                    get { return (HealthCommitteeStatisticsReport)ParentReport; }
                }
                 
                public PARTBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 175;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTB BODY_Script
                    //                                                            
//            if(((HealthCommitteeStatisticsReport)ParentReport).RuntimeParameters.SUCCESSTATUS == SuccessStatusEnum.Unsuccessful)
//                this.Visible = EvetHayirEnum.ehHayir;
//            else
//            {
//                this.Visible = EvetHayirEnum.ehEvet;
//                
//                string sObjectID = this.OBJECTID.CalcValue.ToString();
//                HealthCommittee hc = (HealthCommittee)this.ParentReport.ReportObjectContext.GetObject(new Guid(sObjectID),"HealthCommittee");
//
//                //Karar
//                if(hc.HCDecision != null && hc.HCDecision.ShowOnlyAddDecisionOnReports != true)
//                {
//                    if(hc.HCDecisionTime != null)
//                    {
//                        this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
//                        this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
//                    }
//                    
//                    if(hc.HCDecisionUnitOfTime != null)
//                        this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
//                    
//                    if(hc.HCDecision != null)
//                    {
//                        this.KARAR.CalcValue += hc.HCDecision.Name;
//                        if(hc.Decision != null)
//                            this.KARAR.CalcValue += "\r\n";
//                    }
//                }
//                
//                if (hc.Decision != null)
//                    this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.Decision.ToString()).TrimEnd();
//                
//                //Madde-Dilim-Fıkra
//                BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
//                if (theAnectodes.Count > 0)
//                {
//                    string msa = "[";
//                    foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
//                    {
//                        msa += theAnectode.Madde + "/" + theAnectode.Dilim + "/" + theAnectode.Fikra + "  ";
//                    }
//                    msa = msa.Substring(0, msa.Length - 2);
//                    msa += "]";
//                    
//                    this.KARAR.CalcValue = this.KARAR.CalcValue + "\r\n" + msa;
//                }
//                
//                //Tanı
//                if(hc.Diagnosis.Count > 0)
//                {
//                    IList diagnosisCodeList = new List<string>();
//                    string diagnosis = string.Empty;
//                    int nCount = 1;
//                    
//                    foreach(DiagnosisGrid pGrid in hc.Diagnosis)
//                    {
//                        if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
//                        {
//                            if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
//                            {
//                                diagnosis += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
//                                if (pGrid.FreeDiagnosis != null)
//                                    diagnosis += " (" + pGrid.FreeDiagnosis + ")";
//                                diagnosis += "\r\n";
//                                diagnosisCodeList.Add(pGrid.Diagnose.Code);
//                                nCount++;
//                            }
//                        }
//                    }
//                    
//                    if(diagnosis != string.Empty)
//                        this.KARAR.CalcValue = this.KARAR.CalcValue + "\r\n" + diagnosis;
//                }
//            }
#endregion PARTB BODY_Script
                }
            }

        }

        public PARTBGroup PARTB;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeStatisticsReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SUCCESSTATUS", "", "Başarı Durumu", @"", false, true, false, new Guid("f7f24986-b1e0-4460-89f7-3eebd20d0f0b"));
            reportParameter = Parameters.Add("HEALTHCOMITEETYPE", "", "Sağlık Kurulu Tipi", @"", false, true, false, new Guid("50df466d-66a6-4824-8225-2ba9fb6189dc"));
            reportParameter = Parameters.Add("HCTYPE", "", "Sağlık Kurulu Tipi", @"", false, false, false, new Guid("50df466d-66a6-4824-8225-2ba9fb6189dc"));
            reportParameter = Parameters.Add("HCTYPEFLAG", "", "Sağlık Kurulu Tipi Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTGROUP", "", "Hasta Grubu", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("b80e49d1-883e-4301-8355-8827a6c4b38b");
            reportParameter = Parameters.Add("PATIENTGROUPINT", "", "Hasta Grubu Integer", @"", false, false, true, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTGROUPFLAG", "", "Hasta Grubu Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTGROUPSTRING", "", "Hasta Grubu String", @"", false, false, false, new Guid("0bf6ce17-e764-4aca-9715-722d1b252a6f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SUCCESSTATUS"))
                _runtimeParameters.SUCCESSTATUS = (SuccessStatusEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SuccessStatusEnum"].ConvertValue(parameters["SUCCESSTATUS"]);
            if (parameters.ContainsKey("HEALTHCOMITEETYPE"))
                _runtimeParameters.HEALTHCOMITEETYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue(parameters["HEALTHCOMITEETYPE"]);
            if (parameters.ContainsKey("HCTYPE"))
                _runtimeParameters.HCTYPE = (HealthCommitteeTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["HealthCommitteeTypeEnum"].ConvertValue(parameters["HCTYPE"]);
            if (parameters.ContainsKey("HCTYPEFLAG"))
                _runtimeParameters.HCTYPEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["HCTYPEFLAG"]);
            if (parameters.ContainsKey("PATIENTGROUP"))
                _runtimeParameters.PATIENTGROUP = (List<string>)parameters["PATIENTGROUP"];
            if (parameters.ContainsKey("PATIENTGROUPINT"))
                _runtimeParameters.PATIENTGROUPINT = (List<int>)parameters["PATIENTGROUPINT"];
            if (parameters.ContainsKey("PATIENTGROUPFLAG"))
                _runtimeParameters.PATIENTGROUPFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTGROUPFLAG"]);
            if (parameters.ContainsKey("PATIENTGROUPSTRING"))
                _runtimeParameters.PATIENTGROUPSTRING = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue(parameters["PATIENTGROUPSTRING"]);
            Name = "HEALTHCOMMITTEESTATISTICSREPORT";
            Caption = "Sağlık Kurulu İstatistikleri Raporu";
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