
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
    /// Hizmet İşleri Kabul Tutanağı
    /// </summary>
    public partial class HizmetIsleriKabulTutagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HizmetIsleriKabulTutagi MyParentReport
            {
                get { return (HizmetIsleriKabulTutagi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField124 { get {return Body().NewField124;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField NewField126 { get {return Body().NewField126;} }
            public TTReportField NewField127 { get {return Body().NewField127;} }
            public TTReportRTF ReportRTF { get {return Body().ReportRTF;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField CONTRACTDATE { get {return Body().CONTRACTDATE;} }
            public TTReportField TOTALCONTRACTVALUE { get {return Body().TOTALCONTRACTVALUE;} }
            public TTReportField DELIVERYTIME { get {return Body().DELIVERYTIME;} }
            public TTReportField JOBENDDATE { get {return Body().JOBENDDATE;} }
            public TTReportField EXTENDTIME { get {return Body().EXTENDTIME;} }
            public TTReportField EXTENDEDENDDATE { get {return Body().EXTENDEDENDDATE;} }
            public TTReportField ACTUALJOBENDDATE { get {return Body().ACTUALJOBENDDATE;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
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
                list[0] = new TTReportNqlData<ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class>("HizmetIsleriKabulTutanagiNQL2", ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HizmetIsleriKabulTutagi MyParentReport
                {
                    get { return (HizmetIsleriKabulTutagi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField NewField124;
                public TTReportField NewField125;
                public TTReportField NewField126;
                public TTReportField NewField127;
                public TTReportRTF ReportRTF;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField131;
                public TTReportField NewField15;
                public TTReportField NewField132;
                public TTReportField NewField141;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField ACTDEFINE;
                public TTReportField SUPPLIER;
                public TTReportField CONTRACTDATE;
                public TTReportField TOTALCONTRACTVALUE;
                public TTReportField DELIVERYTIME;
                public TTReportField JOBENDDATE;
                public TTReportField EXTENDTIME;
                public TTReportField EXTENDEDENDDATE;
                public TTReportField ACTUALJOBENDDATE;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 188, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"HİZMET İŞLERİ KABUL TUTANAĞI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 90, 29, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İşin Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 90, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Yüklenicinin adı/ticari ünvanı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 90, 41, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Sözleşme Tarihi";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 90, 47, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Sözleşme Bedeli";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 90, 53, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @"Sözleşmeye göre işin süresi(takvim günü)";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 54, 90, 59, false);
                    NewField124.Name = "NewField124";
                    NewField124.TextFont.Bold = true;
                    NewField124.Value = @"Sözleşmeye göre işin bitirilmesi gereken tarih";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 90, 65, false);
                    NewField125.Name = "NewField125";
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @"Varsa süre uzatımları";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 90, 71, false);
                    NewField126.Name = "NewField126";
                    NewField126.TextFont.Bold = true;
                    NewField126.Value = @"Süre uzatımı dahil işin bitirilmesi gereken tarih";

                    NewField127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 72, 90, 77, false);
                    NewField127.Name = "NewField127";
                    NewField127.TextFont.Bold = true;
                    NewField127.Value = @"İşin bitirildiği tarih";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 83, 188, 289, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 24, 92, 29, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 30, 92, 35, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 36, 92, 41, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 42, 92, 47, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 48, 92, 53, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 54, 92, 59, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 60, 92, 65, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 66, 92, 71, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 72, 92, 77, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @":";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 24, 188, 29, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 30, 188, 35, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.ObjectDefName = "Supplier";
                    SUPPLIER.DataMember = "NAME";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    CONTRACTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 36, 188, 41, false);
                    CONTRACTDATE.Name = "CONTRACTDATE";
                    CONTRACTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTRACTDATE.TextFormat = @"Short Date";
                    CONTRACTDATE.Value = @"{#CONTRACTDATE#}";

                    TOTALCONTRACTVALUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 42, 188, 47, false);
                    TOTALCONTRACTVALUE.Name = "TOTALCONTRACTVALUE";
                    TOTALCONTRACTVALUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCONTRACTVALUE.Value = @"{#TOTALCONTRACTVALUE#}";

                    DELIVERYTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 48, 188, 53, false);
                    DELIVERYTIME.Name = "DELIVERYTIME";
                    DELIVERYTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERYTIME.TextFormat = @"Short Date";
                    DELIVERYTIME.Value = @"{#DELIVERYTIME#}";

                    JOBENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 54, 188, 59, false);
                    JOBENDDATE.Name = "JOBENDDATE";
                    JOBENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    JOBENDDATE.TextFormat = @"Short Date";
                    JOBENDDATE.Value = @"{#JOBENDDATE#}";

                    EXTENDTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 60, 188, 65, false);
                    EXTENDTIME.Name = "EXTENDTIME";
                    EXTENDTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTENDTIME.Value = @"{#EXTENDTIME#}";

                    EXTENDEDENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 66, 188, 71, false);
                    EXTENDEDENDDATE.Name = "EXTENDEDENDDATE";
                    EXTENDEDENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTENDEDENDDATE.TextFormat = @"Short Date";
                    EXTENDEDENDDATE.Value = @"{#EXTENDEDENDDATE#}";

                    ACTUALJOBENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 72, 188, 77, false);
                    ACTUALJOBENDDATE.Name = "ACTUALJOBENDDATE";
                    ACTUALJOBENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTUALJOBENDDATE.TextFormat = @"Short Date";
                    ACTUALJOBENDDATE.Value = @"{#ACTUALJOBENDDATE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 52, 246, 57, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class dataset_HizmetIsleriKabulTutanagiNQL2 = ParentGroup.rsGroup.GetCurrentRecord<ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField126.CalcValue = NewField126.Value;
                    NewField127.CalcValue = NewField127.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    ACTDEFINE.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.ActDefine) : "");
                    SUPPLIER.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.Supplier) : "");
                    SUPPLIER.PostFieldValueCalculation();
                    CONTRACTDATE.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.ContractDate) : "");
                    TOTALCONTRACTVALUE.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.TotalContractValue) : "");
                    DELIVERYTIME.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.DeliveryTime) : "");
                    JOBENDDATE.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.JobEndDate) : "");
                    EXTENDTIME.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.ExtendTime) : "");
                    EXTENDEDENDDATE.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.ExtendedEndDate) : "");
                    ACTUALJOBENDDATE.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.ActualJobEndDate) : "");
                    OBJECTID.CalcValue = (dataset_HizmetIsleriKabulTutanagiNQL2 != null ? Globals.ToStringCore(dataset_HizmetIsleriKabulTutanagiNQL2.ObjectID) : "");
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField121,NewField122,NewField123,NewField124,NewField125,NewField126,NewField127,ReportRTF,NewField3,NewField13,NewField14,NewField131,NewField15,NewField132,NewField141,NewField1131,NewField11311,ACTDEFINE,SUPPLIER,CONTRACTDATE,TOTALCONTRACTVALUE,DELIVERYTIME,JOBENDDATE,EXTENDTIME,EXTENDEDENDDATE,ACTUALJOBENDDATE,OBJECTID};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HizmetIsleriKabulTutagi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ProcedureWorksAcceptNotice procedureWorksAcceptNotice = (ProcedureWorksAcceptNotice)context.GetObject(new Guid(sObjectID),"ProcedureWorksAcceptNotice");
            this.ReportRTF.Value = procedureWorksAcceptNotice.ReportText;
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HizmetIsleriKabulTutagi()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HIZMETISLERIKABULTUTAGI";
            Caption = "Hizmet İşleri Kabul Tutanağı";
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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