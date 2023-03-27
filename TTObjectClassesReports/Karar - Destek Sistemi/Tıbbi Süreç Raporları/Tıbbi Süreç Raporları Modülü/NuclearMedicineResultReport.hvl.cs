
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
    /// Nükleer Tıp Sonuç Raporu
    /// </summary>
    public partial class NuclearMedicineResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class LastSectionGroup : TTReportGroup
        {
            public NuclearMedicineResultReport MyParentReport
            {
                get { return (NuclearMedicineResultReport)ParentReport; }
            }

            new public LastSectionGroupHeader Header()
            {
                return (LastSectionGroupHeader)_header;
            }

            new public LastSectionGroupFooter Footer()
            {
                return (LastSectionGroupFooter)_footer;
            }

            public TTReportField PrintDate11 { get {return Footer().PrintDate11;} }
            public TTReportField UserName11 { get {return Footer().UserName11;} }
            public TTReportField PageNumber11 { get {return Footer().PageNumber11;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public LastSectionGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LastSectionGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LastSectionGroupHeader(this);
                _footer = new LastSectionGroupFooter(this);

            }

            public partial class LastSectionGroupHeader : TTReportSection
            {
                public NuclearMedicineResultReport MyParentReport
                {
                    get { return (NuclearMedicineResultReport)ParentReport; }
                }
                 
                public LastSectionGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class LastSectionGroupFooter : TTReportSection
            {
                public NuclearMedicineResultReport MyParentReport
                {
                    get { return (NuclearMedicineResultReport)ParentReport; }
                }
                
                public TTReportField PrintDate11;
                public TTReportField UserName11;
                public TTReportField PageNumber11;
                public TTReportField NewField1;
                public TTReportShape NewLine11111; 
                public LastSectionGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 32, 10, false);
                    PrintDate11.Name = "PrintDate11";
                    PrintDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate11.TextFont.Name = "Arial Narrow";
                    PrintDate11.TextFont.Size = 8;
                    PrintDate11.TextFont.CharSet = 162;
                    PrintDate11.Value = @"{@printdatetime@}";

                    UserName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 5, 117, 10, false);
                    UserName11.Name = "UserName11";
                    UserName11.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName11.TextFont.Name = "Arial Narrow";
                    UserName11.TextFont.Size = 8;
                    UserName11.TextFont.CharSet = 162;
                    UserName11.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 5, 196, 10, false);
                    PageNumber11.Name = "PageNumber11";
                    PageNumber11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11.TextFont.Name = "Arial Narrow";
                    PageNumber11.TextFont.Size = 8;
                    PageNumber11.TextFont.CharSet = 162;
                    PageNumber11.Value = @"{@pagenumber@} / {@pagecount@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 196, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 4, 196, 4, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate11.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber11.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    NewField1.CalcValue = NewField1.Value;
                    UserName11.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate11,PageNumber11,NewField1,UserName11};
                }
            }

        }

        public LastSectionGroup LastSection;

        public partial class HEADERGroup : TTReportGroup
        {
            public NuclearMedicineResultReport MyParentReport
            {
                get { return (NuclearMedicineResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField XXXXXXBASLIK11 { get {return Header().XXXXXXBASLIK11;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField REPORTEDBY { get {return Footer().REPORTEDBY;} }
            public TTReportField APPROVEDBY { get {return Footer().APPROVEDBY;} }
            public TTReportShape NewLine11112 { get {return Footer().NewLine11112;} }
            public TTReportField LabelContact { get {return Footer().LabelContact;} }
            public TTReportField RadiologyUnitInfo { get {return Footer().RadiologyUnitInfo;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NuclearMedicine.NuclearMedicineReportNQL_Class>("NuclearMedicineReportNQL", NuclearMedicine.NuclearMedicineReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public NuclearMedicineResultReport MyParentReport
                {
                    get { return (NuclearMedicineResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK11; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 56;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 48, 185, 54, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"NÜKLEER TIP SONUÇ RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 6, 43, 29, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.Value = @"";

                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 6, 185, 46, false);
                    XXXXXXBASLIK11.Name = "XXXXXXBASLIK11";
                    XXXXXXBASLIK11.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK11.TextFont.Size = 11;
                    XXXXXXBASLIK11.TextFont.Bold = true;
                    XXXXXXBASLIK11.TextFont.CharSet = 162;
                    XXXXXXBASLIK11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NuclearMedicine.NuclearMedicineReportNQL_Class dataset_NuclearMedicineReportNQL = ParentGroup.rsGroup.GetCurrentRecord<NuclearMedicine.NuclearMedicineReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,LOGO,XXXXXXBASLIK11};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NuclearMedicineResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NuclearMedicine nuclearMedicine = (NuclearMedicine)context.GetObject(new Guid(sObjectID),"NuclearMedicine");
            
            foreach (TTObjectState objectState in nuclearMedicine.GetStateHistory())
            {
               // if (objectState.StateDefID == NuclearMedicine.States.Doctor)
               // {
               //     this.ReportDate.CalcValue = objectState.BranchDate.ToString();
               // }
            }
            
            //this.RequestDate.CalcValue = nuclearMedicine.RequestDate.ToString();
            
            if(nuclearMedicine.Episode.Patient.SecurePerson == true)
            {
                /*
                this.ProtocolNo.Visible = this.dotsProtocolNo.Visible = this.lblProtocolNo.Visible = EvetHayirEnum.ehHayir;
                this.PatientName.Visible = this.dotsPatientName.Visible = this.lblPatientName.Visible = EvetHayirEnum.ehHayir;
                this.BirthPlaceAndDate.Visible = this.dotsBirthPlaceAndDate.Visible = this.lblBirthPlaceAndDate.Visible = EvetHayirEnum.ehHayir;
                this.PatientClinic.Visible = this.dotsPatientClinic.Visible = this.lblPatientClinic.Visible = EvetHayirEnum.ehHayir;
                this.RequestDoctor.Visible = this.dotsRequestDoctor.Visible = this.lblRequestDoctor.Visible = EvetHayirEnum.ehHayir;
                */
            }
            
            
            //string preDiagnosis = null;
           // this.PreDiagnosis.CalcValue = preDiagnosis;
            
            
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NuclearMedicineResultReport MyParentReport
                {
                    get { return (NuclearMedicineResultReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField REPORTEDBY;
                public TTReportField APPROVEDBY;
                public TTReportShape NewLine11112;
                public TTReportField LabelContact;
                public TTReportField RadiologyUnitInfo; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 48;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 3, 181, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SORUMLU DOKTOR";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 3, 64, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"RAPOR YAZAN";

                    REPORTEDBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 9, 72, 28, false);
                    REPORTEDBY.Name = "REPORTEDBY";
                    REPORTEDBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTEDBY.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTEDBY.TextFont.Name = "Arial Narrow";
                    REPORTEDBY.TextFont.Size = 9;
                    REPORTEDBY.TextFont.CharSet = 162;
                    REPORTEDBY.Value = @"{#HEADER.REPORTEDBY#}";

                    APPROVEDBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 9, 188, 28, false);
                    APPROVEDBY.Name = "APPROVEDBY";
                    APPROVEDBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPROVEDBY.MultiLine = EvetHayirEnum.ehEvet;
                    APPROVEDBY.TextFont.Name = "Arial Narrow";
                    APPROVEDBY.TextFont.Size = 9;
                    APPROVEDBY.TextFont.CharSet = 162;
                    APPROVEDBY.Value = @"{#HEADER.APPROVEDBY#}";

                    NewLine11112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 196, 1, false);
                    NewLine11112.Name = "NewLine11112";
                    NewLine11112.DrawStyle = DrawStyleConstants.vbSolid;

                    LabelContact = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 32, 43, 36, false);
                    LabelContact.Name = "LabelContact";
                    LabelContact.TextFont.Name = "Arial";
                    LabelContact.TextFont.Size = 8;
                    LabelContact.TextFont.Bold = true;
                    LabelContact.TextFont.CharSet = 162;
                    LabelContact.Value = @"İletişim Bilgileri:";

                    RadiologyUnitInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 33, 189, 47, false);
                    RadiologyUnitInfo.Name = "RadiologyUnitInfo";
                    RadiologyUnitInfo.MultiLine = EvetHayirEnum.ehEvet;
                    RadiologyUnitInfo.WordBreak = EvetHayirEnum.ehEvet;
                    RadiologyUnitInfo.TextFont.Name = "Arial Narrow";
                    RadiologyUnitInfo.TextFont.Size = 8;
                    RadiologyUnitInfo.TextFont.CharSet = 162;
                    RadiologyUnitInfo.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NuclearMedicine.NuclearMedicineReportNQL_Class dataset_NuclearMedicineReportNQL = ParentGroup.rsGroup.GetCurrentRecord<NuclearMedicine.NuclearMedicineReportNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    REPORTEDBY.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Reportedby) : "");
                    APPROVEDBY.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Approvedby) : "");
                    LabelContact.CalcValue = LabelContact.Value;
                    RadiologyUnitInfo.CalcValue = RadiologyUnitInfo.Value;
                    return new TTReportObject[] { NewField1,NewField11,REPORTEDBY,APPROVEDBY,LabelContact,RadiologyUnitInfo};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NuclearMedicineResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NuclearMedicine nuclearMedicine = (NuclearMedicine)context.GetObject(new Guid(sObjectID),"NuclearMedicine");
            
            ResUser approvedBy = nuclearMedicine.ResponsibleDoctor;
            ResUser reportedBy = nuclearMedicine.ProcedureDoctor;
            
            string CrLf = "\r\n";
            string TextContext = "";
            string Title = "";
            string Sicil = "";
            string Rank = "";
            
            
              //Approved By
            if(approvedBy != null)
                this.APPROVEDBY.CalcValue = approvedBy.SignatureBlock;
            
            //Reported By
            if(reportedBy != null)
                this.REPORTEDBY.CalcValue = reportedBy.SignatureBlock;
            
            this.RadiologyUnitInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RadiologyUnitAddressInfo", "");
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NuclearMedicineResultReport MyParentReport
            {
                get { return (NuclearMedicineResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField lblPatientName1 { get {return Body().lblPatientName1;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField lblBirthPlaceAndDate1 { get {return Body().lblBirthPlaceAndDate1;} }
            public TTReportField lblPatientClinic1 { get {return Body().lblPatientClinic1;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField dotsPatientName1 { get {return Body().dotsPatientName1;} }
            public TTReportField dotsBirthPlaceAndDate1 { get {return Body().dotsBirthPlaceAndDate1;} }
            public TTReportField dotsPatientClinic1 { get {return Body().dotsPatientClinic1;} }
            public TTReportField DYERTAR { get {return Body().DYERTAR;} }
            public TTReportField lblRequestDoctor1 { get {return Body().lblRequestDoctor1;} }
            public TTReportField DOCTORNAME { get {return Body().DOCTORNAME;} }
            public TTReportField dotsRequestDoctor1 { get {return Body().dotsRequestDoctor1;} }
            public TTReportField lblProtocolNo1 { get {return Body().lblProtocolNo1;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField dotsProtocolNo1 { get {return Body().dotsProtocolNo1;} }
            public TTReportField lblReportDate1 { get {return Body().lblReportDate1;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public TTReportField NewField1118111 { get {return Body().NewField1118111;} }
            public TTReportField lblActionId1 { get {return Body().lblActionId1;} }
            public TTReportField ACCESSIONNO { get {return Body().ACCESSIONNO;} }
            public TTReportField dotsActionId1 { get {return Body().dotsActionId1;} }
            public TTReportField lblPatientUniqurefNo1 { get {return Body().lblPatientUniqurefNo1;} }
            public TTReportField dotsPatientName11 { get {return Body().dotsPatientName11;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField lblReportDate11 { get {return Body().lblReportDate11;} }
            public TTReportField NewField11118111 { get {return Body().NewField11118111;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField lblICDCode11 { get {return Body().lblICDCode11;} }
            public TTReportField ICDCode { get {return Body().ICDCode;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField lblHASTANO1 { get {return Body().lblHASTANO1;} }
            public TTReportField lblReportDate111 { get {return Body().lblReportDate111;} }
            public TTReportField NewField111181111 { get {return Body().NewField111181111;} }
            public TTReportField FARMOSATIKTARIHI { get {return Body().FARMOSATIKTARIHI;} }
            public TTReportField lblPROCEDUREBRANCHDATE1 { get {return Body().lblPROCEDUREBRANCHDATE1;} }
            public TTReportField PROCEDUREBRANCHDATE { get {return Body().PROCEDUREBRANCHDATE;} }
            public TTReportField NewField11118112 { get {return Body().NewField11118112;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField dotsProtocolNo11 { get {return Body().dotsProtocolNo11;} }
            public TTReportField dotsPatientClinic11 { get {return Body().dotsPatientClinic11;} }
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
                list[0] = new TTReportNqlData<NuclearMedicine.NuclearMedicineReportNQL_Class>("NuclearMedicineReportNQL", NuclearMedicine.NuclearMedicineReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NuclearMedicineResultReport MyParentReport
                {
                    get { return (NuclearMedicineResultReport)ParentReport; }
                }
                
                public TTReportField lblPatientName1;
                public TTReportField NAME;
                public TTReportField lblBirthPlaceAndDate1;
                public TTReportField lblPatientClinic1;
                public TTReportField FROMRESOURCE;
                public TTReportField dotsPatientName1;
                public TTReportField dotsBirthPlaceAndDate1;
                public TTReportField dotsPatientClinic1;
                public TTReportField DYERTAR;
                public TTReportField lblRequestDoctor1;
                public TTReportField DOCTORNAME;
                public TTReportField dotsRequestDoctor1;
                public TTReportField lblProtocolNo1;
                public TTReportField PROTOKOLNO;
                public TTReportField dotsProtocolNo1;
                public TTReportField lblReportDate1;
                public TTReportField REPORTDATE;
                public TTReportField NewField1118111;
                public TTReportField lblActionId1;
                public TTReportField ACCESSIONNO;
                public TTReportField dotsActionId1;
                public TTReportField lblPatientUniqurefNo1;
                public TTReportField dotsPatientName11;
                public TTReportField UNIQUEREFNO;
                public TTReportField lblReportDate11;
                public TTReportField NewField11118111;
                public TTReportField REQUESTDATE;
                public TTReportField NewField1151;
                public TTReportField lblICDCode11;
                public TTReportField ICDCode;
                public TTReportField HASTANO;
                public TTReportField lblHASTANO1;
                public TTReportField lblReportDate111;
                public TTReportField NewField111181111;
                public TTReportField FARMOSATIKTARIHI;
                public TTReportField lblPROCEDUREBRANCHDATE1;
                public TTReportField PROCEDUREBRANCHDATE;
                public TTReportField NewField11118112;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField dotsProtocolNo11;
                public TTReportField dotsPatientClinic11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 53;
                    RepeatCount = 0;
                    
                    lblPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 43, 19, false);
                    lblPatientName1.Name = "lblPatientName1";
                    lblPatientName1.TextFont.Name = "Arial Narrow";
                    lblPatientName1.TextFont.Size = 9;
                    lblPatientName1.TextFont.Bold = true;
                    lblPatientName1.TextFont.CharSet = 162;
                    lblPatientName1.Value = @"Adı Soyadı";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 14, 110, 19, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#HEADER.PATIENTNAME#} {#HEADER.SURNAME#}";

                    lblBirthPlaceAndDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 19, 43, 24, false);
                    lblBirthPlaceAndDate1.Name = "lblBirthPlaceAndDate1";
                    lblBirthPlaceAndDate1.TextFont.Name = "Arial Narrow";
                    lblBirthPlaceAndDate1.TextFont.Size = 9;
                    lblBirthPlaceAndDate1.TextFont.Bold = true;
                    lblBirthPlaceAndDate1.TextFont.CharSet = 162;
                    lblBirthPlaceAndDate1.Value = @"Doğum Tarihi ve Yeri";

                    lblPatientClinic1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 29, 43, 34, false);
                    lblPatientClinic1.Name = "lblPatientClinic1";
                    lblPatientClinic1.TextFont.Name = "Arial Narrow";
                    lblPatientClinic1.TextFont.Size = 9;
                    lblPatientClinic1.TextFont.Bold = true;
                    lblPatientClinic1.TextFont.CharSet = 162;
                    lblPatientClinic1.Value = @"İsteyen Bölüm";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 29, 110, 34, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.TextFont.Name = "Arial Narrow";
                    FROMRESOURCE.TextFont.Size = 9;
                    FROMRESOURCE.TextFont.CharSet = 162;
                    FROMRESOURCE.Value = @"{#HEADER.FROMRESOURCENAME#}";

                    dotsPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 14, 46, 19, false);
                    dotsPatientName1.Name = "dotsPatientName1";
                    dotsPatientName1.TextFont.Name = "Arial Narrow";
                    dotsPatientName1.TextFont.Size = 9;
                    dotsPatientName1.TextFont.Bold = true;
                    dotsPatientName1.TextFont.CharSet = 162;
                    dotsPatientName1.Value = @":";

                    dotsBirthPlaceAndDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 19, 46, 24, false);
                    dotsBirthPlaceAndDate1.Name = "dotsBirthPlaceAndDate1";
                    dotsBirthPlaceAndDate1.TextFont.Name = "Arial Narrow";
                    dotsBirthPlaceAndDate1.TextFont.Size = 9;
                    dotsBirthPlaceAndDate1.TextFont.Bold = true;
                    dotsBirthPlaceAndDate1.TextFont.CharSet = 162;
                    dotsBirthPlaceAndDate1.Value = @":";

                    dotsPatientClinic1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 29, 46, 34, false);
                    dotsPatientClinic1.Name = "dotsPatientClinic1";
                    dotsPatientClinic1.TextFont.Name = "Arial Narrow";
                    dotsPatientClinic1.TextFont.Size = 9;
                    dotsPatientClinic1.TextFont.Bold = true;
                    dotsPatientClinic1.TextFont.CharSet = 162;
                    dotsPatientClinic1.Value = @":";

                    DYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 19, 110, 24, false);
                    DYERTAR.Name = "DYERTAR";
                    DYERTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTAR.TextFont.Name = "Arial Narrow";
                    DYERTAR.TextFont.Size = 9;
                    DYERTAR.TextFont.CharSet = 162;
                    DYERTAR.Value = @"{%DTARIH%} {%DYER%}";

                    lblRequestDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 24, 43, 29, false);
                    lblRequestDoctor1.Name = "lblRequestDoctor1";
                    lblRequestDoctor1.TextFont.Name = "Arial Narrow";
                    lblRequestDoctor1.TextFont.Size = 9;
                    lblRequestDoctor1.TextFont.Bold = true;
                    lblRequestDoctor1.TextFont.CharSet = 162;
                    lblRequestDoctor1.Value = @"Doktor Adı";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 24, 110, 29, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.TextFont.Name = "Arial Narrow";
                    DOCTORNAME.TextFont.Size = 9;
                    DOCTORNAME.TextFont.CharSet = 162;
                    DOCTORNAME.Value = @"{#HEADER.REQDOCTORNAME#}";

                    dotsRequestDoctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 24, 46, 29, false);
                    dotsRequestDoctor1.Name = "dotsRequestDoctor1";
                    dotsRequestDoctor1.TextFont.Name = "Arial Narrow";
                    dotsRequestDoctor1.TextFont.Size = 9;
                    dotsRequestDoctor1.TextFont.Bold = true;
                    dotsRequestDoctor1.TextFont.CharSet = 162;
                    dotsRequestDoctor1.Value = @":";

                    lblProtocolNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 9, 154, 14, false);
                    lblProtocolNo1.Name = "lblProtocolNo1";
                    lblProtocolNo1.TextFont.Name = "Arial Narrow";
                    lblProtocolNo1.TextFont.Size = 9;
                    lblProtocolNo1.TextFont.Bold = true;
                    lblProtocolNo1.TextFont.CharSet = 162;
                    lblProtocolNo1.Value = @"Protokol No";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 9, 200, 14, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#HEADER.PROTOCOLNO#}";

                    dotsProtocolNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 9, 155, 14, false);
                    dotsProtocolNo1.Name = "dotsProtocolNo1";
                    dotsProtocolNo1.TextFont.Name = "Arial Narrow";
                    dotsProtocolNo1.TextFont.Size = 9;
                    dotsProtocolNo1.TextFont.Bold = true;
                    dotsProtocolNo1.TextFont.CharSet = 162;
                    dotsProtocolNo1.Value = @":";

                    lblReportDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 39, 154, 44, false);
                    lblReportDate1.Name = "lblReportDate1";
                    lblReportDate1.TextFont.Name = "Arial Narrow";
                    lblReportDate1.TextFont.Size = 9;
                    lblReportDate1.TextFont.Bold = true;
                    lblReportDate1.TextFont.CharSet = 162;
                    lblReportDate1.Value = @"Rapor Tarihi";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 39, 200, 44, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    REPORTDATE.TextFont.Name = "Arial Narrow";
                    REPORTDATE.TextFont.Size = 9;
                    REPORTDATE.TextFont.CharSet = 162;
                    REPORTDATE.Value = @"{#HEADER.REPORTDATE#}";

                    NewField1118111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 39, 155, 44, false);
                    NewField1118111.Name = "NewField1118111";
                    NewField1118111.TextFont.Name = "Arial Narrow";
                    NewField1118111.TextFont.Size = 9;
                    NewField1118111.TextFont.Bold = true;
                    NewField1118111.TextFont.CharSet = 162;
                    NewField1118111.Value = @":";

                    lblActionId1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 19, 154, 24, false);
                    lblActionId1.Name = "lblActionId1";
                    lblActionId1.TextFont.Name = "Arial Narrow";
                    lblActionId1.TextFont.Size = 9;
                    lblActionId1.TextFont.Bold = true;
                    lblActionId1.TextFont.CharSet = 162;
                    lblActionId1.Value = @"Accession No";

                    ACCESSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 19, 200, 24, false);
                    ACCESSIONNO.Name = "ACCESSIONNO";
                    ACCESSIONNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCESSIONNO.TextFont.Name = "Arial Narrow";
                    ACCESSIONNO.TextFont.Size = 9;
                    ACCESSIONNO.TextFont.CharSet = 162;
                    ACCESSIONNO.Value = @"";

                    dotsActionId1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 19, 155, 24, false);
                    dotsActionId1.Name = "dotsActionId1";
                    dotsActionId1.TextFont.Name = "Arial Narrow";
                    dotsActionId1.TextFont.Size = 9;
                    dotsActionId1.TextFont.Bold = true;
                    dotsActionId1.TextFont.CharSet = 162;
                    dotsActionId1.Value = @":";

                    lblPatientUniqurefNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 43, 14, false);
                    lblPatientUniqurefNo1.Name = "lblPatientUniqurefNo1";
                    lblPatientUniqurefNo1.TextFont.Name = "Arial Narrow";
                    lblPatientUniqurefNo1.TextFont.Size = 9;
                    lblPatientUniqurefNo1.TextFont.Bold = true;
                    lblPatientUniqurefNo1.TextFont.CharSet = 162;
                    lblPatientUniqurefNo1.Value = @"TC Kimlik No";

                    dotsPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 9, 46, 14, false);
                    dotsPatientName11.Name = "dotsPatientName11";
                    dotsPatientName11.TextFont.Name = "Arial Narrow";
                    dotsPatientName11.TextFont.Size = 9;
                    dotsPatientName11.TextFont.Bold = true;
                    dotsPatientName11.TextFont.CharSet = 162;
                    dotsPatientName11.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 9, 110, 14, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#HEADER.UNIQUEREFNO#}";

                    lblReportDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 24, 154, 29, false);
                    lblReportDate11.Name = "lblReportDate11";
                    lblReportDate11.TextFont.Name = "Arial Narrow";
                    lblReportDate11.TextFont.Size = 9;
                    lblReportDate11.TextFont.Bold = true;
                    lblReportDate11.TextFont.CharSet = 162;
                    lblReportDate11.Value = @"İstek Tarihi";

                    NewField11118111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 24, 155, 29, false);
                    NewField11118111.Name = "NewField11118111";
                    NewField11118111.TextFont.Name = "Arial Narrow";
                    NewField11118111.TextFont.Size = 9;
                    NewField11118111.TextFont.Bold = true;
                    NewField11118111.TextFont.CharSet = 162;
                    NewField11118111.Value = @":";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 24, 200, 29, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#HEADER.REQUESTDATE#}";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 4, 44, 9, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Name = "Arial Narrow";
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Hasta";

                    lblICDCode11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 34, 44, 39, false);
                    lblICDCode11.Name = "lblICDCode11";
                    lblICDCode11.TextFont.Name = "Arial Narrow";
                    lblICDCode11.TextFont.Size = 9;
                    lblICDCode11.TextFont.Bold = true;
                    lblICDCode11.TextFont.CharSet = 162;
                    lblICDCode11.Value = @"ICD Tanı Kodu";

                    ICDCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 34, 119, 45, false);
                    ICDCode.Name = "ICDCode";
                    ICDCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICDCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ICDCode.TextFont.Name = "Arial Narrow";
                    ICDCode.TextFont.Size = 9;
                    ICDCode.TextFont.CharSet = 162;
                    ICDCode.Value = @"";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 14, 200, 19, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{#HEADER.PATIENTID#}";

                    lblHASTANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 14, 153, 19, false);
                    lblHASTANO1.Name = "lblHASTANO1";
                    lblHASTANO1.TextFont.Name = "Arial Narrow";
                    lblHASTANO1.TextFont.Size = 9;
                    lblHASTANO1.TextFont.Bold = true;
                    lblHASTANO1.TextFont.CharSet = 162;
                    lblHASTANO1.Value = @"Hasta No";

                    lblReportDate111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 29, 154, 34, false);
                    lblReportDate111.Name = "lblReportDate111";
                    lblReportDate111.TextFont.Name = "Arial Narrow";
                    lblReportDate111.TextFont.Size = 9;
                    lblReportDate111.TextFont.Bold = true;
                    lblReportDate111.TextFont.CharSet = 162;
                    lblReportDate111.Value = @"Farmasotik Hzrl.Tarihi";

                    NewField111181111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 29, 155, 34, false);
                    NewField111181111.Name = "NewField111181111";
                    NewField111181111.TextFont.Name = "Arial Narrow";
                    NewField111181111.TextFont.Size = 9;
                    NewField111181111.TextFont.Bold = true;
                    NewField111181111.TextFont.CharSet = 162;
                    NewField111181111.Value = @":";

                    FARMOSATIKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 29, 200, 34, false);
                    FARMOSATIKTARIHI.Name = "FARMOSATIKTARIHI";
                    FARMOSATIKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FARMOSATIKTARIHI.TextFormat = @"dd/MM/yyyy HH:mm";
                    FARMOSATIKTARIHI.TextFont.Name = "Arial Narrow";
                    FARMOSATIKTARIHI.TextFont.Size = 9;
                    FARMOSATIKTARIHI.TextFont.CharSet = 162;
                    FARMOSATIKTARIHI.Value = @"{#HEADER.PHARMACEUTICALPREPDATE#}";

                    lblPROCEDUREBRANCHDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 34, 154, 39, false);
                    lblPROCEDUREBRANCHDATE1.Name = "lblPROCEDUREBRANCHDATE1";
                    lblPROCEDUREBRANCHDATE1.TextFont.Name = "Arial Narrow";
                    lblPROCEDUREBRANCHDATE1.TextFont.Size = 9;
                    lblPROCEDUREBRANCHDATE1.TextFont.Bold = true;
                    lblPROCEDUREBRANCHDATE1.TextFont.CharSet = 162;
                    lblPROCEDUREBRANCHDATE1.Value = @"Çekim Tarihi";

                    PROCEDUREBRANCHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 34, 200, 39, false);
                    PROCEDUREBRANCHDATE.Name = "PROCEDUREBRANCHDATE";
                    PROCEDUREBRANCHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBRANCHDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    PROCEDUREBRANCHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDUREBRANCHDATE.TextFont.Name = "Arial Narrow";
                    PROCEDUREBRANCHDATE.TextFont.Size = 9;
                    PROCEDUREBRANCHDATE.TextFont.CharSet = 162;
                    PROCEDUREBRANCHDATE.Value = @"";

                    NewField11118112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 33, 155, 38, false);
                    NewField11118112.Name = "NewField11118112";
                    NewField11118112.TextFont.Name = "Arial Narrow";
                    NewField11118112.TextFont.Size = 9;
                    NewField11118112.TextFont.Bold = true;
                    NewField11118112.TextFont.CharSet = 162;
                    NewField11118112.Value = @":";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 10, 275, 15, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.TextFont.CharSet = 162;
                    DTARIH.Value = @"{#HEADER.BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 16, 275, 21, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.TextFont.CharSet = 162;
                    DYER.Value = @"{#HEADER.TOWNNAME#}";

                    dotsProtocolNo11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 14, 155, 19, false);
                    dotsProtocolNo11.Name = "dotsProtocolNo11";
                    dotsProtocolNo11.TextFont.Name = "Arial Narrow";
                    dotsProtocolNo11.TextFont.Size = 9;
                    dotsProtocolNo11.TextFont.Bold = true;
                    dotsProtocolNo11.TextFont.CharSet = 162;
                    dotsProtocolNo11.Value = @":";

                    dotsPatientClinic11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 34, 46, 39, false);
                    dotsPatientClinic11.Name = "dotsPatientClinic11";
                    dotsPatientClinic11.TextFont.Name = "Arial Narrow";
                    dotsPatientClinic11.TextFont.Size = 9;
                    dotsPatientClinic11.TextFont.Bold = true;
                    dotsPatientClinic11.TextFont.CharSet = 162;
                    dotsPatientClinic11.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NuclearMedicine.NuclearMedicineReportNQL_Class dataset_NuclearMedicineReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<NuclearMedicine.NuclearMedicineReportNQL_Class>(0);
                    lblPatientName1.CalcValue = lblPatientName1.Value;
                    NAME.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Patientname) : "") + @" " + (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Surname) : "");
                    lblBirthPlaceAndDate1.CalcValue = lblBirthPlaceAndDate1.Value;
                    lblPatientClinic1.CalcValue = lblPatientClinic1.Value;
                    FROMRESOURCE.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Fromresourcename) : "");
                    dotsPatientName1.CalcValue = dotsPatientName1.Value;
                    dotsBirthPlaceAndDate1.CalcValue = dotsBirthPlaceAndDate1.Value;
                    dotsPatientClinic1.CalcValue = dotsPatientClinic1.Value;
                    DTARIH.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.BirthDate) : "");
                    DYER.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Townname) : "");
                    DYERTAR.CalcValue = MyParentReport.MAIN.DTARIH.FormattedValue + @" " + MyParentReport.MAIN.DYER.CalcValue;
                    lblRequestDoctor1.CalcValue = lblRequestDoctor1.Value;
                    DOCTORNAME.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Reqdoctorname) : "");
                    dotsRequestDoctor1.CalcValue = dotsRequestDoctor1.Value;
                    lblProtocolNo1.CalcValue = lblProtocolNo1.Value;
                    PROTOKOLNO.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Protocolno) : "");
                    dotsProtocolNo1.CalcValue = dotsProtocolNo1.Value;
                    lblReportDate1.CalcValue = lblReportDate1.Value;
                    REPORTDATE.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.ReportDate) : "");
                    NewField1118111.CalcValue = NewField1118111.Value;
                    lblActionId1.CalcValue = lblActionId1.Value;
                    dotsActionId1.CalcValue = dotsActionId1.Value;
                    lblPatientUniqurefNo1.CalcValue = lblPatientUniqurefNo1.Value;
                    dotsPatientName11.CalcValue = dotsPatientName11.Value;
                    UNIQUEREFNO.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.UniqueRefNo) : "");
                    lblReportDate11.CalcValue = lblReportDate11.Value;
                    NewField11118111.CalcValue = NewField11118111.Value;
                    REQUESTDATE.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.RequestDate) : "");
                    NewField1151.CalcValue = NewField1151.Value;
                    lblICDCode11.CalcValue = lblICDCode11.Value;
                    ICDCode.CalcValue = @"";
                    HASTANO.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.Patientid) : "");
                    lblHASTANO1.CalcValue = lblHASTANO1.Value;
                    lblReportDate111.CalcValue = lblReportDate111.Value;
                    NewField111181111.CalcValue = NewField111181111.Value;
                    FARMOSATIKTARIHI.CalcValue = (dataset_NuclearMedicineReportNQL != null ? Globals.ToStringCore(dataset_NuclearMedicineReportNQL.PharmaceuticalPrepDate) : "");
                    lblPROCEDUREBRANCHDATE1.CalcValue = lblPROCEDUREBRANCHDATE1.Value;
                    PROCEDUREBRANCHDATE.CalcValue = @"";
                    NewField11118112.CalcValue = NewField11118112.Value;
                    dotsProtocolNo11.CalcValue = dotsProtocolNo11.Value;
                    dotsPatientClinic11.CalcValue = dotsPatientClinic11.Value;
                    ACCESSIONNO.CalcValue = @"";
                    return new TTReportObject[] { lblPatientName1,NAME,lblBirthPlaceAndDate1,lblPatientClinic1,FROMRESOURCE,dotsPatientName1,dotsBirthPlaceAndDate1,dotsPatientClinic1,DTARIH,DYER,DYERTAR,lblRequestDoctor1,DOCTORNAME,dotsRequestDoctor1,lblProtocolNo1,PROTOKOLNO,dotsProtocolNo1,lblReportDate1,REPORTDATE,NewField1118111,lblActionId1,dotsActionId1,lblPatientUniqurefNo1,dotsPatientName11,UNIQUEREFNO,lblReportDate11,NewField11118111,REQUESTDATE,NewField1151,lblICDCode11,ICDCode,HASTANO,lblHASTANO1,lblReportDate111,NewField111181111,FARMOSATIKTARIHI,lblPROCEDUREBRANCHDATE1,PROCEDUREBRANCHDATE,NewField11118112,dotsProtocolNo11,dotsPatientClinic11,ACCESSIONNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NuclearMedicineResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NuclearMedicine nuclearMedicine = (NuclearMedicine)context.GetObject(new Guid(sObjectID),"NuclearMedicine");

            string diagnosisStr = "";
            foreach(DiagnosisGrid dig in nuclearMedicine.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Seconder)
                    diagnosisStr = diagnosisStr + dig.Diagnose.Code.ToString() + " " + dig.Diagnose.Name.ToString() + ", ";
            }
            this.ICDCode.CalcValue = diagnosisStr;  
            
            foreach(NuclearMedicineTest nTest in nuclearMedicine.NuclearMedicineTests)
            {
                //Çekim tarihi
                foreach(TTObjectState objectState in nTest.GetStateHistory())
                {
                    if(objectState.StateDefID == NuclearMedicineTest.States.Completed)
                        this.PROCEDUREBRANCHDATE.CalcValue = objectState.BranchDate.ToString();
                }
                
                if(nTest.AccessionNo != null)
                    this.ACCESSIONNO.CalcValue = nTest.AccessionNo.ToString();
                else
                     this.ACCESSIONNO.CalcValue = "";
                
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class TETKIKGroup : TTReportGroup
        {
            public NuclearMedicineResultReport MyParentReport
            {
                get { return (NuclearMedicineResultReport)ParentReport; }
            }

            new public TETKIKGroupBody Body()
            {
                return (TETKIKGroupBody)_body;
            }
            public TTReportField ReportRTF { get {return Body().ReportRTF;} }
            public TTReportField NewField111611 { get {return Body().NewField111611;} }
            public TTReportField NuclearMedicineTestName { get {return Body().NuclearMedicineTestName;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TETKIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TETKIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NuclearMedicineTest.NuclearMedicineTestReportQuery_Class>("NuclearMedicineTestReportQuery", NuclearMedicineTest.NuclearMedicineTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TETKIKGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TETKIKGroupBody : TTReportSection
            {
                public NuclearMedicineResultReport MyParentReport
                {
                    get { return (NuclearMedicineResultReport)ParentReport; }
                }
                
                public TTReportField ReportRTF;
                public TTReportField NewField111611;
                public TTReportField NuclearMedicineTestName;
                public TTReportField NewField1116111; 
                public TETKIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 58;
                    RepeatCount = 0;
                    
                    ReportRTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 198, 56, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.MultiLine = EvetHayirEnum.ehEvet;
                    ReportRTF.NoClip = EvetHayirEnum.ehEvet;
                    ReportRTF.WordBreak = EvetHayirEnum.ehEvet;
                    ReportRTF.ExpandTabs = EvetHayirEnum.ehEvet;
                    ReportRTF.TextFont.Name = "Arial Unicode MS";
                    ReportRTF.TextFont.Size = 8;
                    ReportRTF.TextFont.CharSet = 162;
                    ReportRTF.Value = @"";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 56, 8, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.TextFont.Name = "Arial Narrow";
                    NewField111611.TextFont.Size = 9;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"İSTENEN TETKİK                              ";

                    NuclearMedicineTestName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 157, 14, false);
                    NuclearMedicineTestName.Name = "NuclearMedicineTestName";
                    NuclearMedicineTestName.FieldType = ReportFieldTypeEnum.ftVariable;
                    NuclearMedicineTestName.TextFont.Name = "Arial Narrow";
                    NuclearMedicineTestName.TextFont.Size = 9;
                    NuclearMedicineTestName.TextFont.CharSet = 162;
                    NuclearMedicineTestName.Value = @"{#PROCEDURENAME#}";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 18, 55, 25, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.TextFont.Name = "Arial Narrow";
                    NewField1116111.TextFont.Size = 9;
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"RAPOR                                               ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NuclearMedicineTest.NuclearMedicineTestReportQuery_Class dataset_NuclearMedicineTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<NuclearMedicineTest.NuclearMedicineTestReportQuery_Class>(0);
                    ReportRTF.CalcValue = ReportRTF.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NuclearMedicineTestName.CalcValue = (dataset_NuclearMedicineTestReportQuery != null ? Globals.ToStringCore(dataset_NuclearMedicineTestReportQuery.Procedurename) : "");
                    NewField1116111.CalcValue = NewField1116111.Value;
                    return new TTReportObject[] { ReportRTF,NewField111611,NuclearMedicineTestName,NewField1116111};
                }
                public override void RunPreScript()
                {
#region TETKIK BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NuclearMedicineResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NuclearMedicine nuclearMedicine = (NuclearMedicine)context.GetObject(new Guid(sObjectID),"NuclearMedicine");
            
            if(nuclearMedicine.Report != null)
                this.ReportRTF.Value = TTReportTool.TTReport.HTMLtoText(nuclearMedicine.Report.ToString());
#endregion TETKIK BODY_PreScript
                }
            }

        }

        public TETKIKGroup TETKIK;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NuclearMedicineResultReport()
        {
            LastSection = new LastSectionGroup(this,"LastSection");
            HEADER = new HEADERGroup(LastSection,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            TETKIK = new TETKIKGroup(HEADER,"TETKIK");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protokol No", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("458e9a61-c56f-4285-88d4-a27473fb9964");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NUCLEARMEDICINERESULTREPORT";
            Caption = "Nükleer Tıp Sonuç Raporu";
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
            fd.TextFont.Name = "Courier New";
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