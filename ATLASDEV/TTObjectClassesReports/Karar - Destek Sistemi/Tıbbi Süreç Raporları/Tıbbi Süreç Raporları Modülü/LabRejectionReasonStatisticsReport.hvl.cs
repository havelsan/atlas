
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
    /// Laboratuvar Red Nedeni İstatistik Raporu
    /// </summary>
    public partial class LabRejectionReasonStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public LabRejectionReasonStatisticsReport MyParentReport
            {
                get { return (LabRejectionReasonStatisticsReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField lblHeader1 { get {return Header().lblHeader1;} }
            public TTReportField lblIdentificationCardNo1 { get {return Header().lblIdentificationCardNo1;} }
            public TTReportField lblNameSurname1 { get {return Header().lblNameSurname1;} }
            public TTReportField lblNameSurname11 { get {return Header().lblNameSurname11;} }
            public TTReportField lblNameSurname12 { get {return Header().lblNameSurname12;} }
            public TTReportField lblNameSurname121 { get {return Header().lblNameSurname121;} }
            public TTReportField lblNameSurname111 { get {return Header().lblNameSurname111;} }
            public TTReportField lblNameSurname1111 { get {return Header().lblNameSurname1111;} }
            public TTReportField lblNameSurname11111 { get {return Header().lblNameSurname11111;} }
            public TTReportField lblStartTime { get {return Header().lblStartTime;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField lblEndTime { get {return Header().lblEndTime;} }
            public TTReportField lblNameSurname112 { get {return Header().lblNameSurname112;} }
            public TTReportField lblStartTime1 { get {return Header().lblStartTime1;} }
            public TTReportField lblEndTime1 { get {return Header().lblEndTime1;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public LabRejectionReasonStatisticsReport MyParentReport
                {
                    get { return (LabRejectionReasonStatisticsReport)ParentReport; }
                }
                
                public TTReportField lblHeader1;
                public TTReportField lblIdentificationCardNo1;
                public TTReportField lblNameSurname1;
                public TTReportField lblNameSurname11;
                public TTReportField lblNameSurname12;
                public TTReportField lblNameSurname121;
                public TTReportField lblNameSurname111;
                public TTReportField lblNameSurname1111;
                public TTReportField lblNameSurname11111;
                public TTReportField lblStartTime;
                public TTReportField NewField2;
                public TTReportField lblEndTime;
                public TTReportField lblNameSurname112;
                public TTReportField lblStartTime1;
                public TTReportField lblEndTime1; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblHeader1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 6, 194, 14, false);
                    lblHeader1.Name = "lblHeader1";
                    lblHeader1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblHeader1.TextFont.Name = "Arial";
                    lblHeader1.TextFont.Size = 12;
                    lblHeader1.TextFont.Bold = true;
                    lblHeader1.TextFont.Underline = true;
                    lblHeader1.TextFont.CharSet = 162;
                    lblHeader1.Value = @"LABORATUVAR NUMUNE RED İSTATİSTİK RAPORU";

                    lblIdentificationCardNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 28, 26, 33, false);
                    lblIdentificationCardNo1.Name = "lblIdentificationCardNo1";
                    lblIdentificationCardNo1.TextFont.Size = 9;
                    lblIdentificationCardNo1.TextFont.Bold = true;
                    lblIdentificationCardNo1.TextFont.CharSet = 162;
                    lblIdentificationCardNo1.Value = @"TC Kimlik No";

                    lblNameSurname1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 28, 60, 33, false);
                    lblNameSurname1.Name = "lblNameSurname1";
                    lblNameSurname1.TextFont.Size = 9;
                    lblNameSurname1.TextFont.Bold = true;
                    lblNameSurname1.TextFont.CharSet = 162;
                    lblNameSurname1.Value = @"Hasta Adı Soyadı";

                    lblNameSurname11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 28, 86, 33, false);
                    lblNameSurname11.Name = "lblNameSurname11";
                    lblNameSurname11.TextFont.Size = 9;
                    lblNameSurname11.TextFont.Bold = true;
                    lblNameSurname11.TextFont.CharSet = 162;
                    lblNameSurname11.Value = @"Vaka Açılış Tarihi";

                    lblNameSurname12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 28, 106, 33, false);
                    lblNameSurname12.Name = "lblNameSurname12";
                    lblNameSurname12.TextFont.Size = 9;
                    lblNameSurname12.TextFont.Bold = true;
                    lblNameSurname12.TextFont.CharSet = 162;
                    lblNameSurname12.Value = @"H.Protokol No";

                    lblNameSurname121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 28, 123, 33, false);
                    lblNameSurname121.Name = "lblNameSurname121";
                    lblNameSurname121.TextFont.Size = 9;
                    lblNameSurname121.TextFont.Bold = true;
                    lblNameSurname121.TextFont.CharSet = 162;
                    lblNameSurname121.Value = @"İşlem No";

                    lblNameSurname111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 28, 188, 33, false);
                    lblNameSurname111.Name = "lblNameSurname111";
                    lblNameSurname111.TextFont.Size = 9;
                    lblNameSurname111.TextFont.Bold = true;
                    lblNameSurname111.TextFont.CharSet = 162;
                    lblNameSurname111.Value = @"Tetkik Adı";

                    lblNameSurname1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 28, 247, 33, false);
                    lblNameSurname1111.Name = "lblNameSurname1111";
                    lblNameSurname1111.TextFont.Size = 9;
                    lblNameSurname1111.TextFont.Bold = true;
                    lblNameSurname1111.TextFont.CharSet = 162;
                    lblNameSurname1111.Value = @"Numune Red Sebebi";

                    lblNameSurname11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 28, 289, 33, false);
                    lblNameSurname11111.Name = "lblNameSurname11111";
                    lblNameSurname11111.TextFont.Size = 9;
                    lblNameSurname11111.TextFont.Bold = true;
                    lblNameSurname11111.TextFont.CharSet = 162;
                    lblNameSurname11111.Value = @"Reddeden Kullanıcı";

                    lblStartTime = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 18, 249, 23, false);
                    lblStartTime.Name = "lblStartTime";
                    lblStartTime.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblStartTime.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblStartTime.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblStartTime.TextFont.Size = 8;
                    lblStartTime.TextFont.CharSet = 162;
                    lblStartTime.Value = @"{@STARTTIME@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 18, 254, 23, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"|";

                    lblEndTime = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 18, 280, 23, false);
                    lblEndTime.Name = "lblEndTime";
                    lblEndTime.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblEndTime.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblEndTime.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblEndTime.TextFont.Size = 8;
                    lblEndTime.TextFont.CharSet = 162;
                    lblEndTime.Value = @"{@ENDTIME@}";

                    lblNameSurname112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 28, 150, 33, false);
                    lblNameSurname112.Name = "lblNameSurname112";
                    lblNameSurname112.TextFont.Size = 9;
                    lblNameSurname112.TextFont.Bold = true;
                    lblNameSurname112.TextFont.CharSet = 162;
                    lblNameSurname112.Value = @"Tarih";

                    lblStartTime1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 13, 249, 18, false);
                    lblStartTime1.Name = "lblStartTime1";
                    lblStartTime1.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblStartTime1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblStartTime1.TextFont.Size = 8;
                    lblStartTime1.TextFont.Bold = true;
                    lblStartTime1.TextFont.Underline = true;
                    lblStartTime1.TextFont.CharSet = 162;
                    lblStartTime1.Value = @"Başlangıç Tarihi";

                    lblEndTime1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 13, 280, 18, false);
                    lblEndTime1.Name = "lblEndTime1";
                    lblEndTime1.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblEndTime1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblEndTime1.TextFont.Size = 8;
                    lblEndTime1.TextFont.Bold = true;
                    lblEndTime1.TextFont.Underline = true;
                    lblEndTime1.TextFont.CharSet = 162;
                    lblEndTime1.Value = @"Bitiş Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lblHeader1.CalcValue = lblHeader1.Value;
                    lblIdentificationCardNo1.CalcValue = lblIdentificationCardNo1.Value;
                    lblNameSurname1.CalcValue = lblNameSurname1.Value;
                    lblNameSurname11.CalcValue = lblNameSurname11.Value;
                    lblNameSurname12.CalcValue = lblNameSurname12.Value;
                    lblNameSurname121.CalcValue = lblNameSurname121.Value;
                    lblNameSurname111.CalcValue = lblNameSurname111.Value;
                    lblNameSurname1111.CalcValue = lblNameSurname1111.Value;
                    lblNameSurname11111.CalcValue = lblNameSurname11111.Value;
                    lblStartTime.CalcValue = MyParentReport.RuntimeParameters.STARTTIME.ToString();
                    NewField2.CalcValue = NewField2.Value;
                    lblEndTime.CalcValue = MyParentReport.RuntimeParameters.ENDTIME.ToString();
                    lblNameSurname112.CalcValue = lblNameSurname112.Value;
                    lblStartTime1.CalcValue = lblStartTime1.Value;
                    lblEndTime1.CalcValue = lblEndTime1.Value;
                    return new TTReportObject[] { lblHeader1,lblIdentificationCardNo1,lblNameSurname1,lblNameSurname11,lblNameSurname12,lblNameSurname121,lblNameSurname111,lblNameSurname1111,lblNameSurname11111,lblStartTime,NewField2,lblEndTime,lblNameSurname112,lblStartTime1,lblEndTime1};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public LabRejectionReasonStatisticsReport MyParentReport
                {
                    get { return (LabRejectionReasonStatisticsReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportShape NewLine1; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 4, 289, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.Value = @"{@pagenumber@} / {@pagecount@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 252, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public LabRejectionReasonStatisticsReport MyParentReport
            {
                get { return (LabRejectionReasonStatisticsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblUniquerefNo { get {return Body().lblUniquerefNo;} }
            public TTReportField lblPatientNameSurname { get {return Body().lblPatientNameSurname;} }
            public TTReportField lblEpisodeOpeningDate { get {return Body().lblEpisodeOpeningDate;} }
            public TTReportField lblHospitalProtocolNo { get {return Body().lblHospitalProtocolNo;} }
            public TTReportField lblProcedureID { get {return Body().lblProcedureID;} }
            public TTReportField lblLaboratoryTest { get {return Body().lblLaboratoryTest;} }
            public TTReportField lblSampleRejectionReason { get {return Body().lblSampleRejectionReason;} }
            public TTReportField lblSampleRejectionUser { get {return Body().lblSampleRejectionUser;} }
            public TTReportField lblOBJECTID { get {return Body().lblOBJECTID;} }
            public TTReportField lblWorkListDate { get {return Body().lblWorkListDate;} }
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
                list[0] = new TTReportNqlData<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class>("GetRejectedLaboratoryProceduresByDate", LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTTIME),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDTIME)));
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
                public LabRejectionReasonStatisticsReport MyParentReport
                {
                    get { return (LabRejectionReasonStatisticsReport)ParentReport; }
                }
                
                public TTReportField lblUniquerefNo;
                public TTReportField lblPatientNameSurname;
                public TTReportField lblEpisodeOpeningDate;
                public TTReportField lblHospitalProtocolNo;
                public TTReportField lblProcedureID;
                public TTReportField lblLaboratoryTest;
                public TTReportField lblSampleRejectionReason;
                public TTReportField lblSampleRejectionUser;
                public TTReportField lblOBJECTID;
                public TTReportField lblWorkListDate; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    lblUniquerefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 26, 7, false);
                    lblUniquerefNo.Name = "lblUniquerefNo";
                    lblUniquerefNo.TextFont.Size = 9;
                    lblUniquerefNo.TextFont.CharSet = 162;
                    lblUniquerefNo.Value = @"";

                    lblPatientNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 60, 7, false);
                    lblPatientNameSurname.Name = "lblPatientNameSurname";
                    lblPatientNameSurname.TextFont.Size = 9;
                    lblPatientNameSurname.TextFont.CharSet = 162;
                    lblPatientNameSurname.Value = @"";

                    lblEpisodeOpeningDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 2, 86, 7, false);
                    lblEpisodeOpeningDate.Name = "lblEpisodeOpeningDate";
                    lblEpisodeOpeningDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblEpisodeOpeningDate.TextFont.Size = 9;
                    lblEpisodeOpeningDate.TextFont.CharSet = 162;
                    lblEpisodeOpeningDate.Value = @"";

                    lblHospitalProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 2, 106, 7, false);
                    lblHospitalProtocolNo.Name = "lblHospitalProtocolNo";
                    lblHospitalProtocolNo.TextFont.Size = 9;
                    lblHospitalProtocolNo.TextFont.CharSet = 162;
                    lblHospitalProtocolNo.Value = @"";

                    lblProcedureID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 2, 123, 7, false);
                    lblProcedureID.Name = "lblProcedureID";
                    lblProcedureID.TextFont.Size = 9;
                    lblProcedureID.TextFont.CharSet = 162;
                    lblProcedureID.Value = @"";

                    lblLaboratoryTest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 2, 188, 7, false);
                    lblLaboratoryTest.Name = "lblLaboratoryTest";
                    lblLaboratoryTest.TextFont.Size = 9;
                    lblLaboratoryTest.TextFont.CharSet = 162;
                    lblLaboratoryTest.Value = @"";

                    lblSampleRejectionReason = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 2, 247, 7, false);
                    lblSampleRejectionReason.Name = "lblSampleRejectionReason";
                    lblSampleRejectionReason.TextFont.Size = 9;
                    lblSampleRejectionReason.TextFont.CharSet = 162;
                    lblSampleRejectionReason.Value = @"";

                    lblSampleRejectionUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 2, 289, 7, false);
                    lblSampleRejectionUser.Name = "lblSampleRejectionUser";
                    lblSampleRejectionUser.TextFont.Size = 9;
                    lblSampleRejectionUser.TextFont.CharSet = 162;
                    lblSampleRejectionUser.Value = @"";

                    lblOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 8, 323, 13, false);
                    lblOBJECTID.Name = "lblOBJECTID";
                    lblOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    lblOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    lblOBJECTID.Value = @"{#OBJECTID#}";

                    lblWorkListDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 2, 150, 7, false);
                    lblWorkListDate.Name = "lblWorkListDate";
                    lblWorkListDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    lblWorkListDate.TextFont.Size = 9;
                    lblWorkListDate.TextFont.CharSet = 162;
                    lblWorkListDate.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class dataset_GetRejectedLaboratoryProceduresByDate = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class>(0);
                    lblUniquerefNo.CalcValue = lblUniquerefNo.Value;
                    lblPatientNameSurname.CalcValue = lblPatientNameSurname.Value;
                    lblEpisodeOpeningDate.CalcValue = lblEpisodeOpeningDate.Value;
                    lblHospitalProtocolNo.CalcValue = lblHospitalProtocolNo.Value;
                    lblProcedureID.CalcValue = lblProcedureID.Value;
                    lblLaboratoryTest.CalcValue = lblLaboratoryTest.Value;
                    lblSampleRejectionReason.CalcValue = lblSampleRejectionReason.Value;
                    lblSampleRejectionUser.CalcValue = lblSampleRejectionUser.Value;
                    lblOBJECTID.CalcValue = (dataset_GetRejectedLaboratoryProceduresByDate != null ? Globals.ToStringCore(dataset_GetRejectedLaboratoryProceduresByDate.ObjectID) : "");
                    lblWorkListDate.CalcValue = lblWorkListDate.Value;
                    return new TTReportObject[] { lblUniquerefNo,lblPatientNameSurname,lblEpisodeOpeningDate,lblHospitalProtocolNo,lblProcedureID,lblLaboratoryTest,lblSampleRejectionReason,lblSampleRejectionUser,lblOBJECTID,lblWorkListDate};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.lblOBJECTID.CalcValue;
            
            LaboratoryProcedure labProc = (LaboratoryProcedure)context.GetObject(new Guid(sObjectID),"LaboratoryProcedure");
            this.lblUniquerefNo.CalcValue = labProc.Episode.Patient.UniqueRefNo != null ? labProc.Episode.Patient.UniqueRefNo.ToString() : "";
            this.lblPatientNameSurname.CalcValue = labProc.Episode.Patient.Name + " " + labProc.Episode.Patient.Surname;
            this.lblEpisodeOpeningDate.CalcValue = labProc.Episode.OpeningDate.ToString();
            this.lblHospitalProtocolNo.CalcValue = labProc.Episode.HospitalProtocolNo.Value.ToString();
            this.lblProcedureID.CalcValue = labProc.EpisodeAction.ID.Value.ToString();
            this.lblWorkListDate.CalcValue = labProc.WorkListDate.ToString();
            this.lblLaboratoryTest.CalcValue = labProc.ProcedureObject.Name.ToString();
            this.lblSampleRejectionReason.CalcValue = labProc.SampleRejectionReason != null ? labProc.SampleRejectionReason.Reason.ToString() : "";
            this.lblSampleRejectionUser.CalcValue = labProc.UserOfSampleRejection != null ? labProc.UserOfSampleRejection.Name.ToString() : "";
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

        public LabRejectionReasonStatisticsReport()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTTIME", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDTIME", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTTIME"))
                _runtimeParameters.STARTTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTTIME"]);
            if (parameters.ContainsKey("ENDTIME"))
                _runtimeParameters.ENDTIME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDTIME"]);
            Name = "LABREJECTIONREASONSTATISTICSREPORT";
            Caption = "Laboratuvar Red Nedeni İstatistik Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 4;
            UserMarginTop = 4;
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