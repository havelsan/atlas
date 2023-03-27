
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
    /// XXXXXXye Kabulü Yapılan Hastaların Listesi (Hasta Grubu ve Bölüm Bazında)
    /// </summary>
    public partial class PatientListByPatientGroupAndDept : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public OutPatientInPatientDailyAllEnum? OUTPATIENTINPATIENTDAILYALL = (OutPatientInPatientDailyAllEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientDailyAllEnum"].ConvertValue("");
            public int? PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public PatientGroupTypeEnum? PATIENTGROUPTYPE = (PatientGroupTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PatientGroupTypeEnum"].ConvertValue("");
            public List<string> PATIENTGROUP = new List<string>();
            public List<int> PATIENTGROUPINT = new List<int>();
            public int? PATIENTGROUPFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? PATIENTSTATUS4 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<string> RESOURCE = new List<string>();
            public string PATIENTGROUPSTRING = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue("");
            public int? INPATIENTSTATUSFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public PatientListByPatientGroupAndDept MyParentReport
            {
                get { return (PatientListByPatientGroupAndDept)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

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
                public PatientListByPatientGroupAndDept MyParentReport
                {
                    get { return (PatientListByPatientGroupAndDept)ParentReport; }
                }
                 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    //                                                                                                
//            List<int> pgdList = new List<int>();
//            pgdList.Add(10000);
//            ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPINT = pgdList;
//            
//            string pgStr = "";
//            
//            if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPTYPE == null && ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUP == null)
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPFLAG = 0;
//            else
//            {
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPFLAG = 1;
//                
//                // SGK veya XXXXXX tipindeki hasta grupları eklenir
//                if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPTYPE != null)
//                {
//                    IList pgDefList = PatientGroupDefinition.GetByPatientGroupType(MyParentReport.ReportObjectContext, (PatientGroupTypeEnum)((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPTYPE);
//                    foreach(PatientGroupDefinition pgDef in pgDefList)
//                    {
//                        if(pgDef.PatientGroupEnum != null)
//                        {
//                            ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPINT.Add(TTObjectClasses.Common.GetEnumValueDefOfEnumValue(pgDef.PatientGroupEnum).Value);
//                            pgStr = pgStr + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(pgDef.PatientGroupEnum).DisplayText.ToString() + " , ";
//                        }
//                    }
//                }
//                
//                // İlave hasta grupları eklenir
//                if(((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUP != null)
//                {
//                    foreach (string objectID in ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUP)
//                    {
//                        //TTObjectContext objectContext = new TTObjectContext(true);
//                        PatientGroupDefinition pgd = (PatientGroupDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID),"PatientGroupDefinition");
//                        
//                        if(pgd.PatientGroupEnum != null)
//                        {
//                            ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPINT.Add(TTObjectClasses.Common.GetEnumValueDefOfEnumValue(pgd.PatientGroupEnum).Value);
//                            pgStr = pgStr + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(pgd.PatientGroupEnum).DisplayText.ToString() + " , ";
//                        }
//                    }
//                }
//            }
//            ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.INPATIENTSTATUSFLAG = 0;
//            if (pgStr != "")
//                pgStr =  pgStr.Substring(0, (pgStr.Length - 3));
//            ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTGROUPSTRING = pgStr;
//            
//            
//            if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.RESOURCE == null)
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.RESOURCEFLAG = 0;
//            else
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.RESOURCEFLAG = 1;
//            
//            
//            if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTDAILYALL == OutPatientInPatientDailyAllEnum.OutPatient)
//            {
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 0;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 0;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS4 = 0;
//            }
//            else if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTDAILYALL == OutPatientInPatientDailyAllEnum.InPatient)
//            {
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.INPATIENTSTATUSFLAG = 1;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 1;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS4 = 2;
//            }
//            else if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTDAILYALL == OutPatientInPatientDailyAllEnum.Daily)
//            {
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 3;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 3;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 3;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS4 = 3;
//            }
//            else if (((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTDAILYALL == OutPatientInPatientDailyAllEnum.All)
//            {
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS1 = 0;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS2 = 1;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS3 = 2;
//                ((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.PATIENTSTATUS4 = 3;
//            }
//            
            //((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            //((PatientListByPatientGroupAndDept)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public PatientListByPatientGroupAndDept MyParentReport
                {
                    get { return (PatientListByPatientGroupAndDept)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientListByPatientGroupAndDept MyParentReport
            {
                get { return (PatientListByPatientGroupAndDept)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public PatientListByPatientGroupAndDept MyParentReport
                {
                    get { return (PatientListByPatientGroupAndDept)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PatientListByPatientGroupAndDept()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTDAILYALL", "", "Hasta Durumu", @"", true, true, false, new Guid("f5e2cb9b-3609-4909-9248-9addc575137e"));
            reportParameter = Parameters.Add("PATIENTSTATUS1", "", "Hasta Durumu 1", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS2", "", "Hasta Durumu 2", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS3", "", "Hasta Durumu 3", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTGROUPTYPE", "", "Hasta Grubu Tipi", @"", false, true, false, new Guid("55353606-9a49-4952-a361-9e46d90e20e1"));
            reportParameter = Parameters.Add("PATIENTGROUP", "", "İlave Hasta Grubu", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("b80e49d1-883e-4301-8355-8827a6c4b38b");
            reportParameter = Parameters.Add("PATIENTGROUPINT", "", "Hasta Grubu Integer", @"", false, false, true, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTGROUPFLAG", "", "Hasta Grubu Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PATIENTSTATUS4", "", "Hasta Durumu 4", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("RESOURCEFLAG", "", "Poliklinik/Klinik Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("RESOURCE", "", "Poliklinik / Klinik", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("1b976b6f-6d6c-473a-8e77-8b3d83b204ff");
            reportParameter = Parameters.Add("PATIENTGROUPSTRING", "", "Hasta Grubu String", @"", false, false, false, new Guid("0bf6ce17-e764-4aca-9715-722d1b252a6f"));
            reportParameter = Parameters.Add("INPATIENTSTATUSFLAG", "", "Yatan Hasta Kontrolü", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTDAILYALL"))
                _runtimeParameters.OUTPATIENTINPATIENTDAILYALL = (OutPatientInPatientDailyAllEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientDailyAllEnum"].ConvertValue(parameters["OUTPATIENTINPATIENTDAILYALL"]);
            if (parameters.ContainsKey("PATIENTSTATUS1"))
                _runtimeParameters.PATIENTSTATUS1 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS1"]);
            if (parameters.ContainsKey("PATIENTSTATUS2"))
                _runtimeParameters.PATIENTSTATUS2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS2"]);
            if (parameters.ContainsKey("PATIENTSTATUS3"))
                _runtimeParameters.PATIENTSTATUS3 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS3"]);
            if (parameters.ContainsKey("PATIENTGROUPTYPE"))
                _runtimeParameters.PATIENTGROUPTYPE = (PatientGroupTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PatientGroupTypeEnum"].ConvertValue(parameters["PATIENTGROUPTYPE"]);
            if (parameters.ContainsKey("PATIENTGROUP"))
                _runtimeParameters.PATIENTGROUP = (List<string>)parameters["PATIENTGROUP"];
            if (parameters.ContainsKey("PATIENTGROUPINT"))
                _runtimeParameters.PATIENTGROUPINT = (List<int>)parameters["PATIENTGROUPINT"];
            if (parameters.ContainsKey("PATIENTGROUPFLAG"))
                _runtimeParameters.PATIENTGROUPFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTGROUPFLAG"]);
            if (parameters.ContainsKey("PATIENTSTATUS4"))
                _runtimeParameters.PATIENTSTATUS4 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS4"]);
            if (parameters.ContainsKey("RESOURCEFLAG"))
                _runtimeParameters.RESOURCEFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESOURCEFLAG"]);
            if (parameters.ContainsKey("RESOURCE"))
                _runtimeParameters.RESOURCE = (List<string>)parameters["RESOURCE"];
            if (parameters.ContainsKey("PATIENTGROUPSTRING"))
                _runtimeParameters.PATIENTGROUPSTRING = (string)TTObjectDefManager.Instance.DataTypes["String1000"].ConvertValue(parameters["PATIENTGROUPSTRING"]);
            if (parameters.ContainsKey("INPATIENTSTATUSFLAG"))
                _runtimeParameters.INPATIENTSTATUSFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["INPATIENTSTATUSFLAG"]);
            Name = "PATIENTLISTBYPATIENTGROUPANDDEPT";
            Caption = "XXXXXXye Kabulü Yapılan Hastaların Listesi (Hasta Grubu ve Bölüm Bazında)";
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