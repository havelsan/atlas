
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
    /// Hata Alınan Toplu Faturaya Hazır Detayları
    /// </summary>
    public partial class ReadyToCollectedInvDetailsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ReadyToCollectedInvDetailsReport MyParentReport
            {
                get { return (ReadyToCollectedInvDetailsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1101 { get {return Header().NewField1101;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField1216111 { get {return Header().NewField1216111;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField1316111 { get {return Header().NewField1316111;} }
            public TTReportField NewField11116131 { get {return Header().NewField11116131;} }
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
                public ReadyToCollectedInvDetailsReport MyParentReport
                {
                    get { return (ReadyToCollectedInvDetailsReport)ParentReport; }
                }
                
                public TTReportField NewField1101;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportShape NewLine1111;
                public TTReportField NewField1216111;
                public TTReportField NewField1191;
                public TTReportField NewField1316111;
                public TTReportField NewField11116131; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 11, 287, 16, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1101.TextFont.Name = "Arial";
                    NewField1101.TextFont.Size = 9;
                    NewField1101.TextFont.Bold = true;
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @"HATA ALINAN TOPLU FATURAYA HAZIR DETAYLARI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 17, 73, 21, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"TC Kimlik No";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 17, 89, 21, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"H.Prot. No";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 22, 287, 22, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewField1216111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 17, 287, 21, false);
                    NewField1216111.Name = "NewField1216111";
                    NewField1216111.TextFont.Name = "Arial";
                    NewField1216111.TextFont.Size = 8;
                    NewField1216111.TextFont.Bold = true;
                    NewField1216111.TextFont.CharSet = 162;
                    NewField1216111.Value = @"Hata Mesajı";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 17, 51, 21, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial";
                    NewField1191.TextFont.Size = 8;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Hasta Adı";

                    NewField1316111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 17, 108, 21, false);
                    NewField1316111.Name = "NewField1316111";
                    NewField1316111.TextFont.Name = "Arial";
                    NewField1316111.TextFont.Size = 8;
                    NewField1316111.TextFont.Bold = true;
                    NewField1316111.TextFont.CharSet = 162;
                    NewField1316111.Value = @"Açılış Tarihi";

                    NewField11116131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 17, 153, 21, false);
                    NewField11116131.Name = "NewField11116131";
                    NewField11116131.TextFont.Name = "Arial";
                    NewField11116131.TextFont.Size = 8;
                    NewField11116131.TextFont.Bold = true;
                    NewField11116131.TextFont.CharSet = 162;
                    NewField11116131.Value = @"Alt Vaka";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1101.CalcValue = NewField1101.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1216111.CalcValue = NewField1216111.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1316111.CalcValue = NewField1316111.Value;
                    NewField11116131.CalcValue = NewField11116131.Value;
                    return new TTReportObject[] { NewField1101,NewField1161,NewField1171,NewField1216111,NewField1191,NewField1316111,NewField11116131};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ReadyToCollectedInvDetailsReport MyParentReport
                {
                    get { return (ReadyToCollectedInvDetailsReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ReadyToCollectedInvDetailsReport MyParentReport
            {
                get { return (ReadyToCollectedInvDetailsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HPROTNO { get {return Body().HPROTNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField ERRORMESSAGE { get {return Body().ERRORMESSAGE;} }
            public TTReportField OPENINGDATE { get {return Body().OPENINGDATE;} }
            public TTReportField SUBEPISODE { get {return Body().SUBEPISODE;} }
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
                list[0] = new TTReportNqlData<ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class>("GetFailedReadyToCollectedInvoiceDetails", ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ReadyToCollectedInvDetailsReport MyParentReport
                {
                    get { return (ReadyToCollectedInvDetailsReport)ParentReport; }
                }
                
                public TTReportField HASTAADI;
                public TTReportField HPROTNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField ERRORMESSAGE;
                public TTReportField OPENINGDATE;
                public TTReportField SUBEPISODE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 51, 5, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HASTAADI.MultiLine = EvetHayirEnum.ehEvet;
                    HASTAADI.NoClip = EvetHayirEnum.ehEvet;
                    HASTAADI.WordBreak = EvetHayirEnum.ehEvet;
                    HASTAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 1, 89, 5, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNO.TextFont.Name = "Arial";
                    HPROTNO.TextFont.Size = 8;
                    HPROTNO.TextFont.CharSet = 162;
                    HPROTNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 1, 73, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    ERRORMESSAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 287, 5, false);
                    ERRORMESSAGE.Name = "ERRORMESSAGE";
                    ERRORMESSAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERRORMESSAGE.MultiLine = EvetHayirEnum.ehEvet;
                    ERRORMESSAGE.NoClip = EvetHayirEnum.ehEvet;
                    ERRORMESSAGE.WordBreak = EvetHayirEnum.ehEvet;
                    ERRORMESSAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ERRORMESSAGE.TextFont.Name = "Arial";
                    ERRORMESSAGE.TextFont.Size = 8;
                    ERRORMESSAGE.TextFont.CharSet = 162;
                    ERRORMESSAGE.Value = @"{#ERRORMESSAGE#}";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 1, 108, 5, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.TextFont.Name = "Arial";
                    OPENINGDATE.TextFont.Size = 8;
                    OPENINGDATE.TextFont.CharSet = 162;
                    OPENINGDATE.Value = @"{#OPENINGDATE#}";

                    SUBEPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 1, 153, 5, false);
                    SUBEPISODE.Name = "SUBEPISODE";
                    SUBEPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBEPISODE.MultiLine = EvetHayirEnum.ehEvet;
                    SUBEPISODE.NoClip = EvetHayirEnum.ehEvet;
                    SUBEPISODE.WordBreak = EvetHayirEnum.ehEvet;
                    SUBEPISODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUBEPISODE.TextFont.Name = "Arial";
                    SUBEPISODE.TextFont.Size = 8;
                    SUBEPISODE.TextFont.CharSet = 162;
                    SUBEPISODE.Value = @"{#SUBEPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class dataset_GetFailedReadyToCollectedInvoiceDetails = ParentGroup.rsGroup.GetCurrentRecord<ReadyToCollectedInvoiceDetail.GetFailedReadyToCollectedInvoiceDetails_Class>(0);
                    HASTAADI.CalcValue = (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.Patientname) : "") + @" " + (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.Patientsurname) : "");
                    HPROTNO.CalcValue = (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.HospitalProtocolNo) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.UniqueRefNo) : "");
                    ERRORMESSAGE.CalcValue = (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.ErrorMessage) : "");
                    OPENINGDATE.CalcValue = (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.OpeningDate) : "");
                    SUBEPISODE.CalcValue = (dataset_GetFailedReadyToCollectedInvoiceDetails != null ? Globals.ToStringCore(dataset_GetFailedReadyToCollectedInvoiceDetails.Subepisode) : "");
                    return new TTReportObject[] { HASTAADI,HPROTNO,TCKIMLIKNO,ERRORMESSAGE,OPENINGDATE,SUBEPISODE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ReadyToCollectedInvDetailsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "READYTOCOLLECTEDINVDETAILSREPORT";
            Caption = "Hata Alınan Toplu Faturaya Hazır Detayları";
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