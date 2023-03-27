
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
    /// Hasta Çağrı İşlem Kabul Rakamları
    /// </summary>
    public partial class CompletedQueueItemsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? QUEUESTARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? QUEUEENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<Guid> QUEUEDEFIDS = new List<Guid>();
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CompletedQueueItemsReport MyParentReport
            {
                get { return (CompletedQueueItemsReport)ParentReport; }
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
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                 
                public PARTBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
                public override void RunPreScript()
                {
#region PARTB BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            
            List<Guid> queueDefs = new List<Guid>();
            foreach(Resource outPatientResource in TTObjectClasses.Common.CurrentResource.OutPatientUserResources)
            {
                BindingList<ExaminationQueueDefinition> qList = ExaminationQueueDefinition.GetQueueByResource(context, outPatientResource.ObjectID.ToString());
                foreach(ExaminationQueueDefinition qd in qList)
                {
                    queueDefs.Add(qd.ObjectID);
                }
            }
            
            //BindingList<ExaminationQueueDefinition> qList = ExaminationQueueDefinition.GetQueueByResource(context, TTObjectClasses.Common.CurrentResource.SelectedOutPatientResource.ObjectID.ToString());
            if (queueDefs.Count > 0)
            {
                this.MyParentReport.RuntimeParameters.QUEUEDEFIDS = new List<Guid>();
                foreach (Guid exObjectID in queueDefs)
                    this.MyParentReport.RuntimeParameters.QUEUEDEFIDS.Add(exObjectID);
            }
            // Sunucuda mesaj kutusu çıkarılamaz 2018.11.01 A.Ş.
            // else
            //    TTVisual.InfoBox.Show("Seçtiğiniz ayaktan hasta birimine ait yetkili olduğunuz herhangi bir kuyruk bulunamadı.");
#endregion PARTB BODY_PreScript
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public CompletedQueueItemsReport MyParentReport
            {
                get { return (CompletedQueueItemsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField LBLDATE { get {return Header().LBLDATE;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField LBLDATE1 { get {return Header().LBLDATE1;} }
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
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField LBLDATE;
                public TTReportField STARTDATE;
                public TTReportField LBLDATE1;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 23, 258, 34, false);
                    HEADER.Name = "HEADER";
                    HEADER.DrawStyle = DrawStyleConstants.vbSolid;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.TextFont.Size = 14;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"HASTA ÇAĞRI MUAYENE/İŞLEM KABUL RAKAMLARI (KUYRUK VE DOKTOR BAZLI)";

                    LBLDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 17, 59, 22, false);
                    LBLDATE.Name = "LBLDATE";
                    LBLDATE.ForeColor = System.Drawing.Color.White;
                    LBLDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLDATE.TextFont.CharSet = 162;
                    LBLDATE.Value = @"Tarih Aralığı : ";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 17, 75, 22, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.ForeColor = System.Drawing.Color.White;
                    STARTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@QUEUESTARTDATE@}";

                    LBLDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 17, 79, 22, false);
                    LBLDATE1.Name = "LBLDATE1";
                    LBLDATE1.ForeColor = System.Drawing.Color.White;
                    LBLDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBLDATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLDATE1.TextFont.CharSet = 162;
                    LBLDATE1.Value = @"-";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 17, 96, 22, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.ForeColor = System.Drawing.Color.White;
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@QUEUEENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER.CalcValue = HEADER.Value;
                    LBLDATE.CalcValue = LBLDATE.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.QUEUESTARTDATE.ToString();
                    LBLDATE1.CalcValue = LBLDATE1.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.QUEUEENDDATE.ToString();
                    return new TTReportObject[] { HEADER,LBLDATE,STARTDATE,LBLDATE1,ENDDATE};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CompletedQueueItemsReport MyParentReport
            {
                get { return (CompletedQueueItemsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COMPLETEDBY { get {return Body().COMPLETEDBY;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField DOCTOR { get {return Body().DOCTOR;} }
            public TTReportField EXAMINATIONQUEUEDEFINITION { get {return Body().EXAMINATIONQUEUEDEFINITION;} }
            public TTReportField QUEUEDATE { get {return Body().QUEUEDATE;} }
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
                list[0] = new TTReportNqlData<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class>("GetCompletedExaminationQueueItemsGroupedByDoctors", ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.QUEUEENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.QUEUESTARTDATE),(List<Guid>) MyParentReport.RuntimeParameters.QUEUEDEFIDS));
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
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                
                public TTReportField COMPLETEDBY;
                public TTReportField COUNT;
                public TTReportField DOCTOR;
                public TTReportField EXAMINATIONQUEUEDEFINITION;
                public TTReportField QUEUEDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    COMPLETEDBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 1, 296, 6, false);
                    COMPLETEDBY.Name = "COMPLETEDBY";
                    COMPLETEDBY.Visible = EvetHayirEnum.ehHayir;
                    COMPLETEDBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPLETEDBY.Value = @"{#COMPLETEDBY#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 258, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.Value = @"{#COUNT#}";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 233, 5, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR.Value = @"";

                    EXAMINATIONQUEUEDEFINITION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 168, 5, false);
                    EXAMINATIONQUEUEDEFINITION.Name = "EXAMINATIONQUEUEDEFINITION";
                    EXAMINATIONQUEUEDEFINITION.DrawStyle = DrawStyleConstants.vbSolid;
                    EXAMINATIONQUEUEDEFINITION.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONQUEUEDEFINITION.ObjectDefName = "ExaminationQueueDefinition";
                    EXAMINATIONQUEUEDEFINITION.DataMember = "NAME";
                    EXAMINATIONQUEUEDEFINITION.TextFont.CharSet = 162;
                    EXAMINATIONQUEUEDEFINITION.Value = @"{#EXAMINATIONQUEUEDEFINITION#}";

                    QUEUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 0, 84, 5, false);
                    QUEUEDATE.Name = "QUEUEDATE";
                    QUEUEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    QUEUEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUEUEDATE.TextFormat = @"dd/MM/yyyy";
                    QUEUEDATE.TextFont.CharSet = 162;
                    QUEUEDATE.Value = @"{#QUEUEDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class dataset_GetCompletedExaminationQueueItemsGroupedByDoctors = ParentGroup.rsGroup.GetCurrentRecord<ExaminationQueueItem.GetCompletedExaminationQueueItemsGroupedByDoctors_Class>(0);
                    COMPLETEDBY.CalcValue = (dataset_GetCompletedExaminationQueueItemsGroupedByDoctors != null ? Globals.ToStringCore(dataset_GetCompletedExaminationQueueItemsGroupedByDoctors.CompletedBy) : "");
                    COUNT.CalcValue = (dataset_GetCompletedExaminationQueueItemsGroupedByDoctors != null ? Globals.ToStringCore(dataset_GetCompletedExaminationQueueItemsGroupedByDoctors.Count) : "");
                    DOCTOR.CalcValue = @"";
                    EXAMINATIONQUEUEDEFINITION.CalcValue = (dataset_GetCompletedExaminationQueueItemsGroupedByDoctors != null ? Globals.ToStringCore(dataset_GetCompletedExaminationQueueItemsGroupedByDoctors.ExaminationQueueDefinition) : "");
                    EXAMINATIONQUEUEDEFINITION.PostFieldValueCalculation();
                    QUEUEDATE.CalcValue = (dataset_GetCompletedExaminationQueueItemsGroupedByDoctors != null ? Globals.ToStringCore(dataset_GetCompletedExaminationQueueItemsGroupedByDoctors.QueueDate) : "");
                    return new TTReportObject[] { COMPLETEDBY,COUNT,DOCTOR,EXAMINATIONQUEUEDEFINITION,QUEUEDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            ResUser user = (ResUser)context.GetObject(new Guid(COMPLETEDBY.CalcValue), typeof(ResUser).Name);
            DOCTOR.CalcValue = user.Person.FullName;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public CompletedQueueItemsReport MyParentReport
            {
                get { return (CompletedQueueItemsReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField HEADER1 { get {return Header().HEADER1;} }
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
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                
                public TTReportField HEADER1; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 3, 258, 14, false);
                    HEADER1.Name = "HEADER1";
                    HEADER1.DrawStyle = DrawStyleConstants.vbSolid;
                    HEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER1.TextFont.Size = 14;
                    HEADER1.TextFont.Bold = true;
                    HEADER1.TextFont.CharSet = 162;
                    HEADER1.Value = @"HASTA ÇAĞRI MUAYENE/İŞLEM KABUL RAKAMLARI (DOKTOR BAZLI)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER1.CalcValue = HEADER1.Value;
                    return new TTReportObject[] { HEADER1};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class MAIN2Group : TTReportGroup
        {
            public CompletedQueueItemsReport MyParentReport
            {
                get { return (CompletedQueueItemsReport)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField COMPLETEDBY1 { get {return Body().COMPLETEDBY1;} }
            public TTReportField COUNT1 { get {return Body().COUNT1;} }
            public TTReportField DOCTOR1 { get {return Body().DOCTOR1;} }
            public TTReportField QUEUEDATE1 { get {return Body().QUEUEDATE1;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class>("GetCompletedItemsGroupedByCompletedByAndDate", ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.QUEUESTARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.QUEUEENDDATE),(List<Guid>) MyParentReport.RuntimeParameters.QUEUEDEFIDS));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public CompletedQueueItemsReport MyParentReport
                {
                    get { return (CompletedQueueItemsReport)ParentReport; }
                }
                
                public TTReportField COMPLETEDBY1;
                public TTReportField COUNT1;
                public TTReportField DOCTOR1;
                public TTReportField QUEUEDATE1; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    COMPLETEDBY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 1, 296, 6, false);
                    COMPLETEDBY1.Name = "COMPLETEDBY1";
                    COMPLETEDBY1.Visible = EvetHayirEnum.ehHayir;
                    COMPLETEDBY1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPLETEDBY1.Value = @"{#COMPLETEDBY#}";

                    COUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 258, 5, false);
                    COUNT1.Name = "COUNT1";
                    COUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1.Value = @"{#COUNT#}";

                    DOCTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 233, 5, false);
                    DOCTOR1.Name = "DOCTOR1";
                    DOCTOR1.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCTOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR1.Value = @"";

                    QUEUEDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 0, 84, 5, false);
                    QUEUEDATE1.Name = "QUEUEDATE1";
                    QUEUEDATE1.DrawStyle = DrawStyleConstants.vbSolid;
                    QUEUEDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUEUEDATE1.TextFormat = @"dd/MM/yyyy";
                    QUEUEDATE1.TextFont.CharSet = 162;
                    QUEUEDATE1.Value = @"{#QUEUEDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class dataset_GetCompletedItemsGroupedByCompletedByAndDate = ParentGroup.rsGroup.GetCurrentRecord<ExaminationQueueItem.GetCompletedItemsGroupedByCompletedByAndDate_Class>(0);
                    COMPLETEDBY1.CalcValue = (dataset_GetCompletedItemsGroupedByCompletedByAndDate != null ? Globals.ToStringCore(dataset_GetCompletedItemsGroupedByCompletedByAndDate.CompletedBy) : "");
                    COUNT1.CalcValue = (dataset_GetCompletedItemsGroupedByCompletedByAndDate != null ? Globals.ToStringCore(dataset_GetCompletedItemsGroupedByCompletedByAndDate.Count) : "");
                    DOCTOR1.CalcValue = @"";
                    QUEUEDATE1.CalcValue = (dataset_GetCompletedItemsGroupedByCompletedByAndDate != null ? Globals.ToStringCore(dataset_GetCompletedItemsGroupedByCompletedByAndDate.QueueDate) : "");
                    return new TTReportObject[] { COMPLETEDBY1,COUNT1,DOCTOR1,QUEUEDATE1};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            ResUser user = (ResUser)context.GetObject(new Guid(COMPLETEDBY1.CalcValue), typeof(ResUser).Name);
            DOCTOR1.CalcValue = user.Person.FullName;
#endregion MAIN2 BODY_Script
                }
            }

        }

        public MAIN2Group MAIN2;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CompletedQueueItemsReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            PARTC = new PARTCGroup(this,"PARTC");
            MAIN2 = new MAIN2Group(PARTC,"MAIN2");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("QUEUESTARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("QUEUEENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("QUEUEDEFIDS", "", "Muayene Kuyruğu", @"", false, false, true, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("a7d3a9f8-105e-424b-babc-be96d854a1a8");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("QUEUESTARTDATE"))
                _runtimeParameters.QUEUESTARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["QUEUESTARTDATE"]);
            if (parameters.ContainsKey("QUEUEENDDATE"))
                _runtimeParameters.QUEUEENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["QUEUEENDDATE"]);
            if (parameters.ContainsKey("QUEUEDEFIDS"))
                _runtimeParameters.QUEUEDEFIDS = (List<Guid>)parameters["QUEUEDEFIDS"];
            Name = "COMPLETEDQUEUEITEMSREPORT";
            Caption = "Hasta Çağrı İşlem Kabul Rakamları";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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