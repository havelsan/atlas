
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
    /// Tıbbi Genetik Sonuç Raporu
    /// </summary>
    public partial class GeneticResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public GeneticResultReport MyParentReport
            {
                get { return (GeneticResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField lblPatientName { get {return Header().lblPatientName;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField lblBirthPlaceAndDate { get {return Header().lblBirthPlaceAndDate;} }
            public TTReportField lblPatientClinic { get {return Header().lblPatientClinic;} }
            public TTReportField PatientClinic { get {return Header().PatientClinic;} }
            public TTReportField dotsPatientName { get {return Header().dotsPatientName;} }
            public TTReportField dotsBirthPlaceAndDate { get {return Header().dotsBirthPlaceAndDate;} }
            public TTReportField dotsPatientClinic { get {return Header().dotsPatientClinic;} }
            public TTReportField BirthPlaceAndDate { get {return Header().BirthPlaceAndDate;} }
            public TTReportField lblRequestDoctor { get {return Header().lblRequestDoctor;} }
            public TTReportField RequestDoctor { get {return Header().RequestDoctor;} }
            public TTReportField dotsRequestDoctor { get {return Header().dotsRequestDoctor;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField lblProtocolNo { get {return Header().lblProtocolNo;} }
            public TTReportField ProtocolNo { get {return Header().ProtocolNo;} }
            public TTReportField dotsProtocolNo { get {return Header().dotsProtocolNo;} }
            public TTReportField lblActionId { get {return Header().lblActionId;} }
            public TTReportField ActionId { get {return Header().ActionId;} }
            public TTReportField dotsActionId { get {return Header().dotsActionId;} }
            public TTReportField HizmetOzel1 { get {return Footer().HizmetOzel1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField UserName1 { get {return Footer().UserName1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField Technician { get {return Footer().Technician;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField AnalizedBy { get {return Footer().AnalizedBy;} }
            public TTReportField NewField111111 { get {return Footer().NewField111111;} }
            public TTReportField ApprovedBy { get {return Footer().ApprovedBy;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<Genetic.GeneticReportQuery_Class>("GeneticReportQuery", Genetic.GeneticReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<GeneticTest.GeneticTestReportQuery_Class>("GeneticTestReportQuery", GeneticTest.GeneticTestReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public GeneticResultReport MyParentReport
                {
                    get { return (GeneticResultReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField lblPatientName;
                public TTReportField PatientName;
                public TTReportField lblBirthPlaceAndDate;
                public TTReportField lblPatientClinic;
                public TTReportField PatientClinic;
                public TTReportField dotsPatientName;
                public TTReportField dotsBirthPlaceAndDate;
                public TTReportField dotsPatientClinic;
                public TTReportField BirthPlaceAndDate;
                public TTReportField lblRequestDoctor;
                public TTReportField RequestDoctor;
                public TTReportField dotsRequestDoctor;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField16;
                public TTReportField LOGO1;
                public TTReportField lblProtocolNo;
                public TTReportField ProtocolNo;
                public TTReportField dotsProtocolNo;
                public TTReportField lblActionId;
                public TTReportField ActionId;
                public TTReportField dotsActionId; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 74;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 33, 158, 40, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TIBBI GENETİK SONUÇ RAPORU";

                    lblPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 55, 47, 60, false);
                    lblPatientName.Name = "lblPatientName";
                    lblPatientName.TextFont.Name = "Arial Narrow";
                    lblPatientName.TextFont.Size = 11;
                    lblPatientName.TextFont.Bold = true;
                    lblPatientName.TextFont.CharSet = 162;
                    lblPatientName.Value = @"Hasta Adı";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 55, 105, 60, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 11;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#} {#SURNAME#}";

                    lblBirthPlaceAndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 61, 47, 66, false);
                    lblBirthPlaceAndDate.Name = "lblBirthPlaceAndDate";
                    lblBirthPlaceAndDate.TextFont.Name = "Arial Narrow";
                    lblBirthPlaceAndDate.TextFont.Size = 11;
                    lblBirthPlaceAndDate.TextFont.Bold = true;
                    lblBirthPlaceAndDate.TextFont.CharSet = 162;
                    lblBirthPlaceAndDate.Value = @"Doğum Tarihi / Yaşı";

                    lblPatientClinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 55, 149, 60, false);
                    lblPatientClinic.Name = "lblPatientClinic";
                    lblPatientClinic.TextFont.Name = "Arial Narrow";
                    lblPatientClinic.TextFont.Size = 11;
                    lblPatientClinic.TextFont.Bold = true;
                    lblPatientClinic.TextFont.CharSet = 162;
                    lblPatientClinic.Value = @"İstek Yapan Birim";

                    PatientClinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 55, 208, 60, false);
                    PatientClinic.Name = "PatientClinic";
                    PatientClinic.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientClinic.TextFont.Name = "Arial Narrow";
                    PatientClinic.TextFont.Size = 11;
                    PatientClinic.TextFont.CharSet = 162;
                    PatientClinic.Value = @"{#MASTERRESNAME#}";

                    dotsPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 55, 50, 60, false);
                    dotsPatientName.Name = "dotsPatientName";
                    dotsPatientName.TextFont.Name = "Arial Narrow";
                    dotsPatientName.TextFont.Size = 11;
                    dotsPatientName.TextFont.Bold = true;
                    dotsPatientName.TextFont.CharSet = 162;
                    dotsPatientName.Value = @":";

                    dotsBirthPlaceAndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 61, 50, 66, false);
                    dotsBirthPlaceAndDate.Name = "dotsBirthPlaceAndDate";
                    dotsBirthPlaceAndDate.TextFont.Name = "Arial Narrow";
                    dotsBirthPlaceAndDate.TextFont.Size = 11;
                    dotsBirthPlaceAndDate.TextFont.Bold = true;
                    dotsBirthPlaceAndDate.TextFont.CharSet = 162;
                    dotsBirthPlaceAndDate.Value = @":";

                    dotsPatientClinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 55, 152, 60, false);
                    dotsPatientClinic.Name = "dotsPatientClinic";
                    dotsPatientClinic.TextFont.Name = "Arial Narrow";
                    dotsPatientClinic.TextFont.Size = 11;
                    dotsPatientClinic.TextFont.Bold = true;
                    dotsPatientClinic.TextFont.CharSet = 162;
                    dotsPatientClinic.Value = @":";

                    BirthPlaceAndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 61, 105, 66, false);
                    BirthPlaceAndDate.Name = "BirthPlaceAndDate";
                    BirthPlaceAndDate.TextFont.Name = "Arial Narrow";
                    BirthPlaceAndDate.TextFont.Size = 11;
                    BirthPlaceAndDate.TextFont.CharSet = 162;
                    BirthPlaceAndDate.Value = @"BirthPlaceAndDate";

                    lblRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 61, 149, 66, false);
                    lblRequestDoctor.Name = "lblRequestDoctor";
                    lblRequestDoctor.TextFont.Name = "Arial Narrow";
                    lblRequestDoctor.TextFont.Size = 11;
                    lblRequestDoctor.TextFont.Bold = true;
                    lblRequestDoctor.TextFont.CharSet = 162;
                    lblRequestDoctor.Value = @"İstek Yapan Doktor";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 61, 208, 66, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor.TextFont.Name = "Arial Narrow";
                    RequestDoctor.TextFont.Size = 11;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"{#REQDOCTORNAME#}";

                    dotsRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 61, 152, 66, false);
                    dotsRequestDoctor.Name = "dotsRequestDoctor";
                    dotsRequestDoctor.TextFont.Name = "Arial Narrow";
                    dotsRequestDoctor.TextFont.Size = 11;
                    dotsRequestDoctor.TextFont.Bold = true;
                    dotsRequestDoctor.TextFont.CharSet = 162;
                    dotsRequestDoctor.Value = @":";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 10, 158, 33, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 43, 46, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"HİZMETE ÖZEL";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.Value = @"LOGO";

                    lblProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 49, 47, 54, false);
                    lblProtocolNo.Name = "lblProtocolNo";
                    lblProtocolNo.TextFont.Name = "Arial Narrow";
                    lblProtocolNo.TextFont.Size = 11;
                    lblProtocolNo.TextFont.Bold = true;
                    lblProtocolNo.TextFont.CharSet = 162;
                    lblProtocolNo.Value = @"Protokol No";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 49, 105, 54, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNo.TextFont.Name = "Arial Narrow";
                    ProtocolNo.TextFont.Size = 11;
                    ProtocolNo.TextFont.CharSet = 162;
                    ProtocolNo.Value = @"{#PROTOCOLNO#}";

                    dotsProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 49, 50, 54, false);
                    dotsProtocolNo.Name = "dotsProtocolNo";
                    dotsProtocolNo.TextFont.Name = "Arial Narrow";
                    dotsProtocolNo.TextFont.Size = 11;
                    dotsProtocolNo.TextFont.Bold = true;
                    dotsProtocolNo.TextFont.CharSet = 162;
                    dotsProtocolNo.Value = @":";

                    lblActionId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 49, 149, 54, false);
                    lblActionId.Name = "lblActionId";
                    lblActionId.TextFont.Name = "Arial Narrow";
                    lblActionId.TextFont.Size = 11;
                    lblActionId.TextFont.Bold = true;
                    lblActionId.TextFont.CharSet = 162;
                    lblActionId.Value = @"İşlem Numarası";

                    ActionId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 49, 208, 54, false);
                    ActionId.Name = "ActionId";
                    ActionId.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionId.TextFont.Name = "Arial Narrow";
                    ActionId.TextFont.Size = 11;
                    ActionId.TextFont.CharSet = 162;
                    ActionId.Value = @"{#ID#}";

                    dotsActionId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 49, 152, 54, false);
                    dotsActionId.Name = "dotsActionId";
                    dotsActionId.TextFont.Name = "Arial Narrow";
                    dotsActionId.TextFont.Size = 11;
                    dotsActionId.TextFont.Bold = true;
                    dotsActionId.TextFont.CharSet = 162;
                    dotsActionId.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Genetic.GeneticReportQuery_Class dataset_GeneticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Genetic.GeneticReportQuery_Class>(0);
                    GeneticTest.GeneticTestReportQuery_Class dataset_GeneticTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneticTest.GeneticTestReportQuery_Class>(1);
                    NewField1.CalcValue = NewField1.Value;
                    lblPatientName.CalcValue = lblPatientName.Value;
                    PatientName.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Patientname) : "") + @" " + (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Surname) : "");
                    lblBirthPlaceAndDate.CalcValue = lblBirthPlaceAndDate.Value;
                    lblPatientClinic.CalcValue = lblPatientClinic.Value;
                    PatientClinic.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Masterresname) : "");
                    dotsPatientName.CalcValue = dotsPatientName.Value;
                    dotsBirthPlaceAndDate.CalcValue = dotsBirthPlaceAndDate.Value;
                    dotsPatientClinic.CalcValue = dotsPatientClinic.Value;
                    BirthPlaceAndDate.CalcValue = BirthPlaceAndDate.Value;
                    lblRequestDoctor.CalcValue = lblRequestDoctor.Value;
                    RequestDoctor.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.Reqdoctorname) : "");
                    dotsRequestDoctor.CalcValue = dotsRequestDoctor.Value;
                    NewField16.CalcValue = NewField16.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    lblProtocolNo.CalcValue = lblProtocolNo.Value;
                    ProtocolNo.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.ProtocolNo) : "");
                    dotsProtocolNo.CalcValue = dotsProtocolNo.Value;
                    lblActionId.CalcValue = lblActionId.Value;
                    ActionId.CalcValue = (dataset_GeneticReportQuery != null ? Globals.ToStringCore(dataset_GeneticReportQuery.ID) : "");
                    dotsActionId.CalcValue = dotsActionId.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,lblPatientName,PatientName,lblBirthPlaceAndDate,lblPatientClinic,PatientClinic,dotsPatientName,dotsBirthPlaceAndDate,dotsPatientClinic,BirthPlaceAndDate,lblRequestDoctor,RequestDoctor,dotsRequestDoctor,NewField16,LOGO1,lblProtocolNo,ProtocolNo,dotsProtocolNo,lblActionId,ActionId,dotsActionId,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((GeneticResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Genetic gObject = (Genetic)context.GetObject(new Guid(sObjectID),"Genetic");
            if(gObject.Episode.Patient.BirthDate.HasValue == true)
                this.BirthPlaceAndDate.CalcValue = gObject.Episode.Patient.BirthDate.Value.ToShortDateString() + " / " + gObject.Episode.Patient.Age.ToString();
            
            bool overridePrintRoles = TTObjectClasses.Common.OverridePrintRoles(TTObjectClasses.Common.CurrentUser);
            
            if(gObject.Episode.Patient.SecurePerson == true && overridePrintRoles == false)
            {
                this.ProtocolNo.Visible = this.dotsProtocolNo.Visible = this.lblProtocolNo.Visible = EvetHayirEnum.ehHayir;
                this.PatientName.Visible = this.dotsPatientName.Visible = this.lblPatientName.Visible = EvetHayirEnum.ehHayir;
                this.BirthPlaceAndDate.Visible = this.dotsBirthPlaceAndDate.Visible = this.lblBirthPlaceAndDate.Visible = EvetHayirEnum.ehHayir;
                this.PatientClinic.Visible = this.dotsPatientClinic.Visible = this.lblPatientClinic.Visible = EvetHayirEnum.ehHayir;
                this.RequestDoctor.Visible = this.dotsRequestDoctor.Visible = this.lblRequestDoctor.Visible = EvetHayirEnum.ehHayir;
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public GeneticResultReport MyParentReport
                {
                    get { return (GeneticResultReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel1;
                public TTReportShape NewLine1;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1;
                public TTReportField NewField1111;
                public TTReportField Technician;
                public TTReportField NewField11111;
                public TTReportField AnalizedBy;
                public TTReportField NewField111111;
                public TTReportField ApprovedBy; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 47;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HizmetOzel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 32, 244, 38, false);
                    HizmetOzel1.Name = "HizmetOzel1";
                    HizmetOzel1.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel1.TextFont.Name = "Arial Narrow";
                    HizmetOzel1.TextFont.Size = 11;
                    HizmetOzel1.TextFont.Bold = true;
                    HizmetOzel1.TextFont.Underline = true;
                    HizmetOzel1.TextFont.CharSet = 162;
                    HizmetOzel1.Value = @"HİZMETE ÖZEL";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 34, 207, 34, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 35, 40, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFont.Name = "Arial Narrow";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 35, 118, 40, false);
                    UserName1.Name = "UserName1";
                    UserName1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName1.TextFont.Name = "Arial Narrow";
                    UserName1.TextFont.Size = 8;
                    UserName1.TextFont.CharSet = 162;
                    UserName1.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 35, 207, 40, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.TextFont.Name = "Arial Narrow";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"{@pagenumber@}/{@pagecount@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 47, 8, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Teknisyen";

                    Technician = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 64, 14, false);
                    Technician.Name = "Technician";
                    Technician.MultiLine = EvetHayirEnum.ehEvet;
                    Technician.NoClip = EvetHayirEnum.ehEvet;
                    Technician.WordBreak = EvetHayirEnum.ehEvet;
                    Technician.ExpandTabs = EvetHayirEnum.ehEvet;
                    Technician.TextFont.Name = "Arial Narrow";
                    Technician.TextFont.Size = 11;
                    Technician.TextFont.CharSet = 162;
                    Technician.Value = @"";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 47, 22, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Analiz Yapan";

                    AnalizedBy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 64, 28, false);
                    AnalizedBy.Name = "AnalizedBy";
                    AnalizedBy.MultiLine = EvetHayirEnum.ehEvet;
                    AnalizedBy.NoClip = EvetHayirEnum.ehEvet;
                    AnalizedBy.WordBreak = EvetHayirEnum.ehEvet;
                    AnalizedBy.ExpandTabs = EvetHayirEnum.ehEvet;
                    AnalizedBy.TextFont.Name = "Arial Narrow";
                    AnalizedBy.TextFont.Size = 11;
                    AnalizedBy.TextFont.CharSet = 162;
                    AnalizedBy.Value = @"";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 4, 207, 9, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Onaylayan Uzman Tabip";

                    ApprovedBy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 12, 207, 17, false);
                    ApprovedBy.Name = "ApprovedBy";
                    ApprovedBy.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ApprovedBy.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedBy.NoClip = EvetHayirEnum.ehEvet;
                    ApprovedBy.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedBy.ExpandTabs = EvetHayirEnum.ehEvet;
                    ApprovedBy.TextFont.Name = "Arial Narrow";
                    ApprovedBy.TextFont.Size = 11;
                    ApprovedBy.TextFont.CharSet = 162;
                    ApprovedBy.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Genetic.GeneticReportQuery_Class dataset_GeneticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Genetic.GeneticReportQuery_Class>(0);
                    GeneticTest.GeneticTestReportQuery_Class dataset_GeneticTestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneticTest.GeneticTestReportQuery_Class>(1);
                    HizmetOzel1.CalcValue = HizmetOzel1.Value;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField1111.CalcValue = NewField1111.Value;
                    Technician.CalcValue = Technician.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    AnalizedBy.CalcValue = AnalizedBy.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    ApprovedBy.CalcValue = ApprovedBy.Value;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel1,PrintDate1,PageNumber1,NewField1111,Technician,NewField11111,AnalizedBy,NewField111111,ApprovedBy,UserName1};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((GeneticResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Genetic genetic = (Genetic)context.GetObject(new Guid(sObjectID),"Genetic");
            
            ResUser approvedBy = genetic.ApprovedBy;
            ResUser analizedBy = genetic.AnalizedBy;
            ResUser technician = genetic.Technician;
            ResUser procedureDoctor = genetic.ProcedureDoctor;
            
            string CrLf = "\r\n";
            string TextContext = "";
            string sTitle = "";
            
            //ApprovedBy
            //if(approvedBy != null)
            //{
            //sTitle = !approvedBy.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(approvedBy.Title.Value);
            //TextContext = sTitle + CrLf + approvedBy.Name;
            //this.ApprovedBy.CalcValue = TextContext;
            //}
            
            //ProcedureDoctor
            if(procedureDoctor != null)
            {
                sTitle = !procedureDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(procedureDoctor.Title.Value);
                TextContext = sTitle + CrLf + procedureDoctor.Name;
                this.ApprovedBy.CalcValue = TextContext;
            }
            
            
            //AnalizedBy
            if(analizedBy != null)
            {
            sTitle = !analizedBy.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(analizedBy.Title.Value);
            TextContext = sTitle + " " + analizedBy.Name;
            this.AnalizedBy.CalcValue = TextContext;
            }
            //Technician
            if(technician != null)
            {
            sTitle = !technician.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(technician.Title.Value);
            TextContext = sTitle + " " + technician.Name;
            this.Technician.CalcValue = TextContext;
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public GeneticResultReport MyParentReport
            {
                get { return (GeneticResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportRTF ReportRTF { get {return Body().ReportRTF;} }
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
                public GeneticResultReport MyParentReport
                {
                    get { return (GeneticResultReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportRTF ReportRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 42;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 35, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 7, 207, 38, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\{#REPORT#\}\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    return new TTReportObject[] { NewField1,ReportRTF};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((GeneticResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Genetic genetic = (Genetic)context.GetObject(new Guid(sObjectID),"Genetic");
            this.ReportRTF.Value = genetic.Report.ToString();
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

        public GeneticResultReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GUID", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "GENETICRESULTREPORT";
            Caption = "Tıbbi Genetik Sonuç Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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