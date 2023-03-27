
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
    /// Planlı Tıbbi İşlem Sağlık Raporu
    /// </summary>
    public partial class PlannedMedicalActionRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField RAPORTARIH { get {return Header().RAPORTARIH;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField RAPORTIPI { get {return Header().RAPORTIPI;} }
            public TTReportField POLICLINIC { get {return Header().POLICLINIC;} }
            public TTReportField LBLIMZA1 { get {return Footer().LBLIMZA1;} }
            public TTReportField LBLIMZA2 { get {return Footer().LBLIMZA2;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField ADSOYADDOC2 { get {return Footer().ADSOYADDOC2;} }
            public TTReportField UZ2 { get {return Footer().UZ2;} }
            public TTReportField SINRUT2 { get {return Footer().SINRUT2;} }
            public TTReportField ADSOYADDOC3 { get {return Footer().ADSOYADDOC3;} }
            public TTReportField UZ3 { get {return Footer().UZ3;} }
            public TTReportField SINRUT3 { get {return Footer().SINRUT3;} }
            public TTReportField NewField114311 { get {return Footer().NewField114311;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField SICILNO2 { get {return Footer().SICILNO2;} }
            public TTReportField SICILNO3 { get {return Footer().SICILNO3;} }
            public TTReportField DATE111 { get {return Footer().DATE111;} }
            public TTReportField PUBLISHINGDATE11 { get {return Footer().PUBLISHINGDATE11;} }
            public NOTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>("GetPlannedMedicalActionRequest", PlannedMedicalActionRequest.GetPlannedMedicalActionRequest((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTGroupHeader(this);
                _footer = new NOTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NOTGroupHeader : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField NewField19;
                public TTReportField RAPORTARIH;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField RAPORNO;
                public TTReportField RAPORTIPI;
                public TTReportField POLICLINIC; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 5, 168, 27, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial Narrow";
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 44, 41, 48, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Rapor Tarihi";

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 44, 83, 48, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIH.TextFont.Name = "Arial Narrow";
                    RAPORTARIH.Value = @"{#REQUESTDATE#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 44, 43, 48, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 39, 43, 43, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 39, 41, 43, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @"Rapor No";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 39, 83, 43, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.Value = @"{#PROTOCOLNO#}";

                    RAPORTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 33, 168, 37, false);
                    RAPORTIPI.Name = "RAPORTIPI";
                    RAPORTIPI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTIPI.TextFont.Name = "Arial Narrow";
                    RAPORTIPI.TextFont.Bold = true;
                    RAPORTIPI.Value = @"PLANLI TIBBİ İŞLEM SAĞLIK RAPORU";

                    POLICLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 168, 32, false);
                    POLICLINIC.Name = "POLICLINIC";
                    POLICLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    POLICLINIC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    POLICLINIC.TextFont.Name = "Arial Narrow";
                    POLICLINIC.TextFont.Bold = true;
                    POLICLINIC.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class dataset_GetPlannedMedicalActionRequest = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>(0);
                    NewField19.CalcValue = NewField19.Value;
                    RAPORTARIH.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.RequestDate) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    RAPORNO.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.ProtocolNo) : "");
                    RAPORTIPI.CalcValue = RAPORTIPI.Value;
                    POLICLINIC.CalcValue = @"";
                    HEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField19,RAPORTARIH,NewField21,NewField22,NewField23,RAPORNO,RAPORTIPI,POLICLINIC,HEADER};
                }

                public override void RunScript()
                {
#region NOT HEADER_Script
                    //                        
//                    TTObjectContext context = this.ParentReport.ReportObjectContext;
//            string objectID = ((PlannedMedicalActionRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            PlannedMedicalActionRequest plannedMedicalActionRequest = (PlannedMedicalActionRequest)context.GetObject(new Guid(objectID), "PlannedMedicalActionRequest");
//            if(plannedMedicalActionRequest.MasterResource!=null)
//                this.POLICLINIC.CalcValue =  (plannedMedicalActionRequest.MasterResource).ToString();
#endregion NOT HEADER_Script
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportField LBLIMZA1;
                public TTReportField LBLIMZA2;
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField SINRUT;
                public TTReportField ADSOYADDOC2;
                public TTReportField UZ2;
                public TTReportField SINRUT2;
                public TTReportField ADSOYADDOC3;
                public TTReportField UZ3;
                public TTReportField SINRUT3;
                public TTReportField NewField114311;
                public TTReportField SICILNO;
                public TTReportField SICILNO2;
                public TTReportField SICILNO3;
                public TTReportField DATE111;
                public TTReportField PUBLISHINGDATE11; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBLIMZA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 83, 6, false);
                    LBLIMZA1.Name = "LBLIMZA1";
                    LBLIMZA1.TextFont.Name = "Arial Narrow";
                    LBLIMZA1.TextFont.Bold = true;
                    LBLIMZA1.TextFont.Underline = true;
                    LBLIMZA1.Value = @"İMZA";

                    LBLIMZA2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 2, 155, 6, false);
                    LBLIMZA2.Name = "LBLIMZA2";
                    LBLIMZA2.TextFont.Name = "Arial Narrow";
                    LBLIMZA2.TextFont.Bold = true;
                    LBLIMZA2.TextFont.Underline = true;
                    LBLIMZA2.Value = @"İMZA";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 65, 24, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 8;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 65, 12, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 65, 16, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 8;
                    SINRUT.Value = @"";

                    ADSOYADDOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 8, 131, 12, false);
                    ADSOYADDOC2.Name = "ADSOYADDOC2";
                    ADSOYADDOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC2.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC2.TextFont.Size = 8;
                    ADSOYADDOC2.Value = @"";

                    UZ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 20, 131, 24, false);
                    UZ2.Name = "UZ2";
                    UZ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ2.MultiLine = EvetHayirEnum.ehEvet;
                    UZ2.NoClip = EvetHayirEnum.ehEvet;
                    UZ2.WordBreak = EvetHayirEnum.ehEvet;
                    UZ2.TextFont.Name = "Arial Narrow";
                    UZ2.TextFont.Size = 8;
                    UZ2.Value = @"";

                    SINRUT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 12, 131, 16, false);
                    SINRUT2.Name = "SINRUT2";
                    SINRUT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT2.TextFont.Name = "Arial Narrow";
                    SINRUT2.TextFont.Size = 8;
                    SINRUT2.Value = @"";

                    ADSOYADDOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 8, 200, 12, false);
                    ADSOYADDOC3.Name = "ADSOYADDOC3";
                    ADSOYADDOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC3.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC3.TextFont.Size = 8;
                    ADSOYADDOC3.Value = @"";

                    UZ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 20, 200, 24, false);
                    UZ3.Name = "UZ3";
                    UZ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ3.MultiLine = EvetHayirEnum.ehEvet;
                    UZ3.NoClip = EvetHayirEnum.ehEvet;
                    UZ3.WordBreak = EvetHayirEnum.ehEvet;
                    UZ3.TextFont.Name = "Arial Narrow";
                    UZ3.TextFont.Size = 8;
                    UZ3.Value = @"";

                    SINRUT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 12, 200, 16, false);
                    SINRUT3.Name = "SINRUT3";
                    SINRUT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT3.TextFont.Name = "Arial Narrow";
                    SINRUT3.TextFont.Size = 8;
                    SINRUT3.Value = @"";

                    NewField114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 46, 6, false);
                    NewField114311.Name = "NewField114311";
                    NewField114311.TextFont.Name = "Arial Narrow";
                    NewField114311.TextFont.Bold = true;
                    NewField114311.TextFont.Underline = true;
                    NewField114311.Value = @"DÜZENLEYEN TABİP";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 16, 65, 20, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    SICILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 16, 131, 20, false);
                    SICILNO2.Name = "SICILNO2";
                    SICILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO2.TextFont.Name = "Arial Narrow";
                    SICILNO2.TextFont.Size = 8;
                    SICILNO2.Value = @"";

                    SICILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 16, 200, 20, false);
                    SICILNO3.Name = "SICILNO3";
                    SICILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO3.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO3.TextFont.Name = "Arial Narrow";
                    SICILNO3.TextFont.Size = 8;
                    SICILNO3.Value = @"";

                    DATE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 28, 198, 33, false);
                    DATE111.Name = "DATE111";
                    DATE111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE111.TextFormat = @"dd/MM/yyyy";
                    DATE111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE111.TextFont.Name = "Arial Narrow";
                    DATE111.Value = @"{@printdate@}";

                    PUBLISHINGDATE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 28, 176, 33, false);
                    PUBLISHINGDATE11.Name = "PUBLISHINGDATE11";
                    PUBLISHINGDATE11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PUBLISHINGDATE11.TextFont.Name = "Arial Narrow";
                    PUBLISHINGDATE11.TextFont.CharSet = 1;
                    PUBLISHINGDATE11.Value = @"Çıktı Tarihi:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class dataset_GetPlannedMedicalActionRequest = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>(0);
                    LBLIMZA1.CalcValue = LBLIMZA1.Value;
                    LBLIMZA2.CalcValue = LBLIMZA2.Value;
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    ADSOYADDOC2.CalcValue = @"";
                    UZ2.CalcValue = @"";
                    SINRUT2.CalcValue = @"";
                    ADSOYADDOC3.CalcValue = @"";
                    UZ3.CalcValue = @"";
                    SINRUT3.CalcValue = @"";
                    NewField114311.CalcValue = NewField114311.Value;
                    SICILNO.CalcValue = @"";
                    SICILNO2.CalcValue = @"";
                    SICILNO3.CalcValue = @"";
                    DATE111.CalcValue = DateTime.Now.ToShortDateString();
                    PUBLISHINGDATE11.CalcValue = PUBLISHINGDATE11.Value;
                    return new TTReportObject[] { LBLIMZA1,LBLIMZA2,UZ,ADSOYADDOC,SINRUT,ADSOYADDOC2,UZ2,SINRUT2,ADSOYADDOC3,UZ3,SINRUT3,NewField114311,SICILNO,SICILNO2,SICILNO3,DATE111,PUBLISHINGDATE11};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
            string objectID = ((PlannedMedicalActionRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PlannedMedicalActionRequest plannedMedicalActionRequest = (PlannedMedicalActionRequest)context.GetObject(new Guid(objectID), "PlannedMedicalActionRequest");
        
            string sMemberSpeciality = "";
            //Uzmanlar
            this.ADSOYADDOC.CalcValue = plannedMedicalActionRequest.ProcedureDoctor.Name;
            string sForce1 = plannedMedicalActionRequest.ProcedureDoctor.ForcesCommand != null? plannedMedicalActionRequest.ProcedureDoctor.ForcesCommand.Qref : "";
            string sRank1 = plannedMedicalActionRequest.ProcedureDoctor.Rank != null ? plannedMedicalActionRequest.ProcedureDoctor.Rank.ShortName : "";
            string sTitle1 = plannedMedicalActionRequest.ProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(plannedMedicalActionRequest.ProcedureDoctor.Title.Value) : "";
            this.SINRUT.CalcValue = sTitle1 + sForce1 + sRank1;
            if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                this.SICILNO.CalcValue = "(" + plannedMedicalActionRequest.ProcedureDoctor.EmploymentRecordID + ")";
            else
                this.SICILNO.CalcValue = "(" + plannedMedicalActionRequest.ProcedureDoctor.DiplomaRegisterNo + ")";
            if (plannedMedicalActionRequest.ProcedureDoctor.GetSpeciality() != null)
                sMemberSpeciality = plannedMedicalActionRequest.ProcedureDoctor.GetSpeciality().Name + " Uzm.";
            else
                sMemberSpeciality = "";
            
            this.UZ.CalcValue = sMemberSpeciality;
            
//            if(pr.SecondProcedureDoctor != null)
//            {
//                this.ADSOYADDOC2.CalcValue = pr.SecondProcedureDoctor.Name;                
//                string sForce2 = pr.SecondProcedureDoctor.ForcesCommand != null ? pr.SecondProcedureDoctor.ForcesCommand.Qref : "";
//                string sRank2 = pr.SecondProcedureDoctor.Rank != null ? pr.SecondProcedureDoctor.Rank.ShortName : "";
//                string sTitle2 = pr.SecondProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pr.SecondProcedureDoctor.Title.Value) : "";
//                this.SINRUT2.CalcValue = sTitle2 + sForce2 + sRank2;
//                if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
//                    this.SICILNO2.CalcValue = "(" + pr.SecondProcedureDoctor.EmploymentRecordID + ")";
//                else
//                    this.SICILNO2.CalcValue = "(" + pr.SecondProcedureDoctor.DiplomaRegisterNo + ")";
//                if (pr.SecondProcedureDoctor.GetSpeciality() != null)
//                    sMemberSpeciality = pr.SecondProcedureDoctor.GetSpeciality().Name + " Uzm.";
//                else
//                    sMemberSpeciality = "";
//                this.UZ2.CalcValue = sMemberSpeciality;
//            }
//            else
//            {
//                this.LBLIMZA1.Visible = EvetHayirEnum.ehHayir;
//            }
//            
//            if(pr.ThirdProcedureDoctor!= null)
//            {
//                this.ADSOYADDOC3.CalcValue = pr.ThirdProcedureDoctor.Name;
//                string sForce3 = pr.ThirdProcedureDoctor.ForcesCommand != null ? pr.ThirdProcedureDoctor.ForcesCommand.Qref : "";
//                string sRank3 = pr.ThirdProcedureDoctor.Rank != null ? pr.ThirdProcedureDoctor.Rank.ShortName : "";
//                string sTitle3 = pr.ThirdProcedureDoctor.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(pr.ThirdProcedureDoctor.Title.Value) : "";
//                this.SINRUT3.CalcValue = sTitle3 + sForce3 + sRank3;
//                if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
//                    this.SICILNO3.CalcValue = "(" + pr.ThirdProcedureDoctor.EmploymentRecordID + ")";
//                else
//                    this.SICILNO3.CalcValue = "(" + pr.ThirdProcedureDoctor.DiplomaRegisterNo + ")";
//                if (pr.ThirdProcedureDoctor.GetSpeciality() != null)
//                    sMemberSpeciality = pr.ThirdProcedureDoctor.GetSpeciality().Name + " Uzm.";
//                else
//                    sMemberSpeciality = "";
//                this.UZ3.CalcValue = sMemberSpeciality;
//            }
//            else
//            {
//                this.LBLIMZA2.Visible = EvetHayirEnum.ehHayir;
//            }
             this.LBLIMZA1.Visible = EvetHayirEnum.ehHayir;
             this.LBLIMZA2.Visible = EvetHayirEnum.ehHayir;
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class MAINGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField LBLKIMLIK { get {return Body().LBLKIMLIK;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField LBLKIMLIKNO { get {return Body().LBLKIMLIKNO;} }
            public TTReportField LBLKIMLIKNO1 { get {return Body().LBLKIMLIKNO1;} }
            public TTReportField TCNU { get {return Body().TCNU;} }
            public TTReportField HASTATCNU { get {return Body().HASTATCNU;} }
            public TTReportField FKIMLIKNO { get {return Body().FKIMLIKNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
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
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportField LBLKIMLIK;
                public TTReportField ADSOYAD;
                public TTReportField LBLKIMLIKNO;
                public TTReportField LBLKIMLIKNO1;
                public TTReportField TCNU;
                public TTReportField HASTATCNU;
                public TTReportField FKIMLIKNO;
                public TTReportField TCKIMLIKNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 26;
                    RepeatCount = 0;
                    
                    LBLKIMLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 43, 7, false);
                    LBLKIMLIK.Name = "LBLKIMLIK";
                    LBLKIMLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLKIMLIK.TextFont.Name = "Arial Narrow";
                    LBLKIMLIK.TextFont.Bold = true;
                    LBLKIMLIK.Value = @"HASTANIN KİMLİĞİ";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 141, 7, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.CharSet = 1;
                    ADSOYAD.Value = @"{#NOT.PATIENTNAME#} {#NOT.PATIENTSURNAME#}";

                    LBLKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 43, 13, false);
                    LBLKIMLIKNO.Name = "LBLKIMLIKNO";
                    LBLKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLKIMLIKNO.TextFont.Name = "Arial Narrow";
                    LBLKIMLIKNO.TextFont.Bold = true;
                    LBLKIMLIKNO.Value = @"DOĞUM YERİ ve TARİHİ";

                    LBLKIMLIKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 43, 26, false);
                    LBLKIMLIKNO1.Name = "LBLKIMLIKNO1";
                    LBLKIMLIKNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLKIMLIKNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLKIMLIKNO1.MultiLine = EvetHayirEnum.ehEvet;
                    LBLKIMLIKNO1.WordBreak = EvetHayirEnum.ehEvet;
                    LBLKIMLIKNO1.TextFont.Name = "Arial Narrow";
                    LBLKIMLIKNO1.TextFont.Bold = true;
                    LBLKIMLIKNO1.Value = @"ADRESİ / 
GÖNDEREN MAKAM";

                    TCNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 1, 169, 7, false);
                    TCNU.Name = "TCNU";
                    TCNU.DrawStyle = DrawStyleConstants.vbSolid;
                    TCNU.TextFont.Name = "Arial Narrow";
                    TCNU.TextFont.Bold = true;
                    TCNU.Value = @"TC KİMLİK NU";

                    HASTATCNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 1, 200, 7, false);
                    HASTATCNU.Name = "HASTATCNU";
                    HASTATCNU.DrawStyle = DrawStyleConstants.vbSolid;
                    HASTATCNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATCNU.TextFont.Name = "Arial Narrow";
                    HASTATCNU.TextFont.CharSet = 1;
                    HASTATCNU.Value = @"";

                    FKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 11, 240, 16, false);
                    FKIMLIKNO.Name = "FKIMLIKNO";
                    FKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    FKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FKIMLIKNO.TextFont.Name = "Arial Narrow";
                    FKIMLIKNO.TextFont.CharSet = 1;
                    FKIMLIKNO.Value = @"{#NOT.FNO#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 21, 240, 26, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.TextFont.CharSet = 1;
                    TCKIMLIKNO.Value = @"{#NOT.TCNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class dataset_GetPlannedMedicalActionRequest = MyParentReport.NOT.rsGroup.GetCurrentRecord<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>(0);
                    LBLKIMLIK.CalcValue = LBLKIMLIK.Value;
                    ADSOYAD.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.Patientname) : "") + @" " + (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.Patientsurname) : "");
                    LBLKIMLIKNO.CalcValue = LBLKIMLIKNO.Value;
                    LBLKIMLIKNO1.CalcValue = LBLKIMLIKNO1.Value;
                    TCNU.CalcValue = TCNU.Value;
                    HASTATCNU.CalcValue = @"";
                    FKIMLIKNO.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.Fno) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.Tcno) : "");
                    return new TTReportObject[] { LBLKIMLIK,ADSOYAD,LBLKIMLIKNO,LBLKIMLIKNO1,TCNU,HASTATCNU,FKIMLIKNO,TCKIMLIKNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.FKIMLIKNO.CalcValue != null && this.FKIMLIKNO.CalcValue != "")
                    this.HASTATCNU.CalcValue = "(*)" + this.FKIMLIKNO.CalcValue;
            else if(this.TCKIMLIKNO.CalcValue != null)
                    this.HASTATCNU.CalcValue = this.TCKIMLIKNO.CalcValue;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class CLINICBODYGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public CLINICBODYGroupBody Body()
            {
                return (CLINICBODYGroupBody)_body;
            }
            public TTReportField LBLCLINIC { get {return Body().LBLCLINIC;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField CLINICINFO { get {return Body().CLINICINFO;} }
            public TTReportRTF KLINIKBULGULAR { get {return Body().KLINIKBULGULAR;} }
            public TTReportField CLINICINFORTF { get {return Body().CLINICINFORTF;} }
            public CLINICBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CLINICBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new CLINICBODYGroupBody(this);
            }

            public partial class CLINICBODYGroupBody : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportField LBLCLINIC;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine121;
                public TTReportField CLINICINFO;
                public TTReportRTF KLINIKBULGULAR;
                public TTReportField CLINICINFORTF; 
                public CLINICBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    LBLCLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 43, 7, false);
                    LBLCLINIC.Name = "LBLCLINIC";
                    LBLCLINIC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLCLINIC.TextFont.Name = "Arial Narrow";
                    LBLCLINIC.TextFont.Bold = true;
                    LBLCLINIC.Value = @"KLİNİK";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 3, 8, 3, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 7, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 43, 0, 43, 7, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 7, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extSectionHeight;

                    CLINICINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 2, 237, 7, false);
                    CLINICINFO.Name = "CLINICINFO";
                    CLINICINFO.Visible = EvetHayirEnum.ehHayir;
                    CLINICINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICINFO.TextFont.Name = "Arial Narrow";
                    CLINICINFO.TextFont.CharSet = 1;
                    CLINICINFO.Value = @"{#NOT.CLINICINFORMATION#}";

                    KLINIKBULGULAR = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 44, 1, 199, 7, false);
                    KLINIKBULGULAR.Name = "KLINIKBULGULAR";
                    KLINIKBULGULAR.Value = @"";

                    CLINICINFORTF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 2, 266, 7, false);
                    CLINICINFORTF.Name = "CLINICINFORTF";
                    CLINICINFORTF.Visible = EvetHayirEnum.ehHayir;
                    CLINICINFORTF.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICINFORTF.TextFont.Name = "Arial Narrow";
                    CLINICINFORTF.TextFont.CharSet = 1;
                    CLINICINFORTF.Value = @"{#NOT.CLINICINFORMATIONRTF#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class dataset_GetPlannedMedicalActionRequest = MyParentReport.NOT.rsGroup.GetCurrentRecord<PlannedMedicalActionRequest.GetPlannedMedicalActionRequest_Class>(0);
                    LBLCLINIC.CalcValue = LBLCLINIC.Value;
                    CLINICINFO.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.ClinicInformation) : "");
                    KLINIKBULGULAR.CalcValue = KLINIKBULGULAR.Value;
                    CLINICINFORTF.CalcValue = (dataset_GetPlannedMedicalActionRequest != null ? Globals.ToStringCore(dataset_GetPlannedMedicalActionRequest.ClinicInformationRTF) : "");
                    return new TTReportObject[] { LBLCLINIC,CLINICINFO,KLINIKBULGULAR,CLINICINFORTF};
                }
                public override void RunPreScript()
                {
#region CLINICBODY BODY_PreScript
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
            string objectID = ((PlannedMedicalActionRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PlannedMedicalActionRequest plannedMedicalActionRequest = (PlannedMedicalActionRequest)context.GetObject(new Guid(objectID), "PlannedMedicalActionRequest");
            Episode episode = plannedMedicalActionRequest.Episode;

           if(plannedMedicalActionRequest.ClinicInformationRTF != null && plannedMedicalActionRequest.ClinicInformationRTF.ToString() != "")
           {
               this.KLINIKBULGULAR.Value =  plannedMedicalActionRequest.ClinicInformationRTF.ToString(); 
           }
           else
           {
  
                if(plannedMedicalActionRequest.ClinicInformation != null && plannedMedicalActionRequest.ClinicInformation.ToString() !="")
                {
                    this.KLINIKBULGULAR.Value = TTObjectClasses.Common.GetRTFOfTextString(plannedMedicalActionRequest.ClinicInformation);
                }
                else
                {
                   
                    String conResultAndOffers = "";
                    Guid EPISODE = new Guid();
                         EPISODE = plannedMedicalActionRequest.Episode.ObjectID;
                         string CODE = "1800";
                   int consultationCount = 1;                
                   TTObjectContext ctx = new TTObjectContext(true);
                   IBindingList specialityList = SpecialityDefinition.GetSpecialityByCode(ctx,CODE);
                   IBindingList consultationList = ConsultationProcedure.GetConsultationProcedureByEpisode(ctx,EPISODE);
          
                    string klinikBulgular = String.Empty;
                    if(episode.Complaint != null)
                        klinikBulgular += "ŞİKAYETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.Complaint.ToString()) + "\r\n";
                    if(episode.PatientHistory != null)
                        klinikBulgular += "HİKAYESİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PatientHistory.ToString()) + "\r\n";
                    if(episode.PhysicalExamination != null)
                        klinikBulgular += "FİZİK MUAYENE : " + TTObjectClasses.Common.GetTextOfRTFString(episode.PhysicalExamination.ToString())+ "\r\n";
                    if(episode.ExaminationSummary != null)
                        klinikBulgular += "MUAYENE ÖZETİ : " + TTObjectClasses.Common.GetTextOfRTFString(episode.ExaminationSummary.ToString())+ "\r\n";
        
                    
                    foreach(ConsultationProcedure consultation in consultationList)
                    {
                       string scode = "";
                       string speCode = "";
                       if(consultation.Consultation.ConsultationResultAndOffers != null)
                       {
                           conResultAndOffers = Convert.ToString(consultation.Consultation.ConsultationResultAndOffers);
                           if(consultationCount ==1 )
                           {
                                klinikBulgular += "KOSÜLTASYON SONUÇ VE ÖNERİLERİ : ";  
                                consultationCount ++;
                           }
                       
                      
                            foreach (ResourceSpecialityGrid resSpeciality in consultation.Consultation.MasterResource.ResourceSpecialities)
                            {
                           
                                foreach (SpecialityDefinition specialityDef in specialityList)
                                {
                                    if(specialityDef.Name != null)
                                     speCode = (specialityDef.Name).ToString();
                                }
                           
                                if(resSpeciality.Speciality != null)
                                    scode = (resSpeciality.Speciality).ToString();
                                if(speCode.Equals(scode))
                                    klinikBulgular += TTObjectClasses.Common.GetTextOfRTFString(conResultAndOffers)+ "\r\n";
                           
                              }
                       }
                      }
                    if(klinikBulgular != null && klinikBulgular != "")
                        KLINIKBULGULAR.Value =  TTObjectClasses.Common.GetRTFOfTextString(klinikBulgular);
                }
           }
#endregion CLINICBODY BODY_PreScript
                }
            }

        }

        public CLINICBODYGroup CLINICBODY;

        public partial class DIAGNOSISBODYGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public DIAGNOSISBODYGroupBody Body()
            {
                return (DIAGNOSISBODYGroupBody)_body;
            }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportField LBLCLINIC1 { get {return Body().LBLCLINIC1;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine124 { get {return Body().NewLine124;} }
            public TTReportShape NewLine132 { get {return Body().NewLine132;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public DIAGNOSISBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DIAGNOSISBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DIAGNOSISBODYGroupBody(this);
            }

            public partial class DIAGNOSISBODYGroupBody : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportShape NewLine1;
                public TTReportShape NewLine131;
                public TTReportField LBLCLINIC1;
                public TTReportShape NewLine111;
                public TTReportShape NewLine124;
                public TTReportShape NewLine132;
                public TTReportShape NewLine1121; 
                public DIAGNOSISBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 1, 199, 7, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.CharSet = 1;
                    TANI.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 24, 8, 24, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 200, 0, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    LBLCLINIC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 43, 7, false);
                    LBLCLINIC1.Name = "LBLCLINIC1";
                    LBLCLINIC1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLCLINIC1.TextFont.Name = "Arial Narrow";
                    LBLCLINIC1.TextFont.Bold = true;
                    LBLCLINIC1.Value = @"TANI";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 3, 8, 3, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 7, false);
                    NewLine124.Name = "NewLine124";
                    NewLine124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine124.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 43, 0, 43, 7, false);
                    NewLine132.Name = "NewLine132";
                    NewLine132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 7, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TANI.CalcValue = @"";
                    LBLCLINIC1.CalcValue = LBLCLINIC1.Value;
                    return new TTReportObject[] { TANI,LBLCLINIC1};
                }

                public override void RunScript()
                {
#region DIAGNOSISBODY BODY_Script
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
            string objectID = ((PlannedMedicalActionRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PlannedMedicalActionRequest plannedMedicalActionRequest = (PlannedMedicalActionRequest)context.GetObject(new Guid(objectID), "PlannedMedicalActionRequest");
            Episode episode = plannedMedicalActionRequest.Episode;
            string tanilar = String.Empty;
            foreach(DiagnosisGrid dg in episode.Diagnosis)
            {
                if(tanilar.Length>0)tanilar+="/ ";
                if(dg.Diagnose.FtrDiagnoseGroup != null)
                 tanilar += dg.Diagnose.FtrDiagnoseGroup.ToString()+" Grubu- "+ dg.DiagnoseCode + " " + dg.Diagnose.Name;
                else
                  tanilar += dg.DiagnoseCode + " " + dg.Diagnose.Name;  
            }

            this.TANI.CalcValue = tanilar;
#endregion DIAGNOSISBODY BODY_Script
                }
            }

        }

        public DIAGNOSISBODYGroup DIAGNOSISBODY;

        public partial class ORDERBODYGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public ORDERBODYGroupBody Body()
            {
                return (ORDERBODYGroupBody)_body;
            }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportShape NewLine1132 { get {return Body().NewLine1132;} }
            public TTReportField LBLCLINIC1 { get {return Body().LBLCLINIC1;} }
            public TTReportShape NewLine112 { get {return Body().NewLine112;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public ORDERBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORDERBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ORDERBODYGroupBody(this);
            }

            public partial class ORDERBODYGroupBody : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField KARAR;
                public TTReportShape NewLine1132;
                public TTReportField LBLCLINIC1;
                public TTReportShape NewLine112;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine1121; 
                public ORDERBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 215, 32, 215, 32, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 1, 199, 7, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial Narrow";
                    KARAR.TextFont.CharSet = 1;
                    KARAR.Value = @"";

                    NewLine1132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 200, 0, false);
                    NewLine1132.Name = "NewLine1132";
                    NewLine1132.DrawStyle = DrawStyleConstants.vbSolid;

                    LBLCLINIC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 43, 7, false);
                    LBLCLINIC1.Name = "LBLCLINIC1";
                    LBLCLINIC1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLCLINIC1.TextFont.Name = "Arial Narrow";
                    LBLCLINIC1.TextFont.Bold = true;
                    LBLCLINIC1.Value = @"KARAR";

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 3, 8, 3, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 7, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 43, 0, 43, 7, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 7, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KARAR.CalcValue = @"";
                    LBLCLINIC1.CalcValue = LBLCLINIC1.Value;
                    return new TTReportObject[] { KARAR,LBLCLINIC1};
                }

                public override void RunScript()
                {
#region ORDERBODY BODY_Script
                    TTObjectContext context = this.ParentReport.ReportObjectContext;
                        string objectID = ((PlannedMedicalActionRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                        PlannedMedicalActionRequest plannedMedicalActionRequest = (PlannedMedicalActionRequest)context.GetObject(new Guid(objectID), "PlannedMedicalActionRequest");
                        Episode episode = plannedMedicalActionRequest.Episode;
            
                        
                        if(plannedMedicalActionRequest.PlannedMedicalActionOrders.Count>0)
                        {
                            string karar = "Hastaya ";
                            foreach(PlannedMedicalActionOrder pmo in plannedMedicalActionRequest.PlannedMedicalActionOrders)
                            {
                                if(pmo.ApplicationArea != null)
                                    karar += pmo.ApplicationArea.ToString() +" bölgesinde "+ pmo.Amount.ToString() + " seans " + pmo.ProcedureObject.Name + ", ";
                                else
                                    karar += pmo.Amount.ToString() + " seans " + pmo.ProcedureObject.Name + ", ";
            
                            }
                            karar = karar.Substring(0,karar.Length-2);
                            karar += " uygun görülmüştür.";
                            this.KARAR.CalcValue = karar;
                       }
#endregion ORDERBODY BODY_Script
                }
            }

        }

        public ORDERBODYGroup ORDERBODY;

        public partial class ORDERFORMATBODYGroup : TTReportGroup
        {
            public PlannedMedicalActionRequestReport MyParentReport
            {
                get { return (PlannedMedicalActionRequestReport)ParentReport; }
            }

            new public ORDERFORMATBODYGroupBody Body()
            {
                return (ORDERFORMATBODYGroupBody)_body;
            }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public ORDERFORMATBODYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORDERFORMATBODYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ORDERFORMATBODYGroupBody(this);
            }

            public partial class ORDERFORMATBODYGroupBody : TTReportSection
            {
                public PlannedMedicalActionRequestReport MyParentReport
                {
                    get { return (PlannedMedicalActionRequestReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportShape NewLine1131; 
                public ORDERFORMATBODYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 10, 10, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 200, 0, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public ORDERFORMATBODYGroup ORDERFORMATBODY;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PlannedMedicalActionRequestReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            CLINICBODY = new CLINICBODYGroup(NOT,"CLINICBODY");
            DIAGNOSISBODY = new DIAGNOSISBODYGroup(NOT,"DIAGNOSISBODY");
            ORDERBODY = new ORDERBODYGroup(NOT,"ORDERBODY");
            ORDERFORMATBODY = new ORDERFORMATBODYGroup(NOT,"ORDERFORMATBODY");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PLANNEDMEDICALACTIONREQUESTREPORT";
            Caption = "Planlı Tıbbi İşlem Sağlık Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 5;
            UserMarginTop = 10;
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