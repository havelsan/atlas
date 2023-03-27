
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
    /// Taş Kırma Raporu
    /// </summary>
    public partial class StoneBreakUpReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public StoneBreakUpReport MyParentReport
            {
                get { return (StoneBreakUpReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportShape NewRect111 { get {return Header().NewRect111;} }
            public TTReportField SIGNATURE { get {return Header().SIGNATURE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLine161 { get {return Header().NewLine161;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField11431 { get {return Header().NewField11431;} }
            public TTReportField NewField11461 { get {return Header().NewField11461;} }
            public TTReportField MASTERRESOURCE { get {return Header().MASTERRESOURCE;} }
            public TTReportField DIAGNOSISFIELD { get {return Header().DIAGNOSISFIELD;} }
            public TTReportField PATIENTENTERPRISEORMILUNIT { get {return Header().PATIENTENTERPRISEORMILUNIT;} }
            public TTReportField MILUNIT { get {return Header().MILUNIT;} }
            public TTReportField REFNO { get {return Header().REFNO;} }
            public TTReportField SOCIALINSURANCE { get {return Header().SOCIALINSURANCE;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField SIGNATURE12 { get {return Footer().SIGNATURE12;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField SIGNATURE1 { get {return Footer().SIGNATURE1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine181 { get {return Footer().NewLine181;} }
            public TTReportShape NewLine191 { get {return Footer().NewLine191;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportShape NewLine171 { get {return Footer().NewLine171;} }
            public TTReportShape NewLine1191 { get {return Footer().NewLine1191;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StoneBreakUpRequest.StoneBreakUpReportNQL_Class>("StoneBreakUpReportNQL", StoneBreakUpRequest.StoneBreakUpReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public StoneBreakUpReport MyParentReport
                {
                    get { return (StoneBreakUpReport)ParentReport; }
                }
                
                public TTReportShape NewRect111;
                public TTReportField SIGNATURE;
                public TTReportField NewField11;
                public TTReportField PatientName;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine161;
                public TTReportField NewField122;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField1161;
                public TTReportField NewField11421;
                public TTReportField NewField11431;
                public TTReportField NewField11461;
                public TTReportField MASTERRESOURCE;
                public TTReportField DIAGNOSISFIELD;
                public TTReportField PATIENTENTERPRISEORMILUNIT;
                public TTReportField MILUNIT;
                public TTReportField REFNO;
                public TTReportField SOCIALINSURANCE;
                public TTReportField EPISODE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 119;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 10, 43, 201, 117, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    SIGNATURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 93, 196, 108, false);
                    SIGNATURE.Name = "SIGNATURE";
                    SIGNATURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNATURE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNATURE.NoClip = EvetHayirEnum.ehEvet;
                    SIGNATURE.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNATURE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNATURE.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 34, 177, 42, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 15;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"TAŞ KIRMA RAPORU";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 46, 102, 51, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#NAME#} {#SURNAME#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 177, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.TextFont.Name = "Courier New";
                    LOGO11.Value = @"LOGO";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 54, 201, 54, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 66, 201, 66, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 86, 201, 86, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 43, 104, 117, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 46, 41, 52, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Hastanın Adı Soyadı";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 67, 44, 72, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Çalıştığı Kurumu/Birliği";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 55, 36, 60, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Sosyal Güvencesi";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 68, 131, 73, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Poliklinik/Klinik";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 46, 131, 50, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"T.C Kimlik No";

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 87, 36, 92, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.TextFont.Bold = true;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"Tanı";

                    NewField11461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 87, 131, 92, false);
                    NewField11461.Name = "NewField11461";
                    NewField11461.TextFont.Bold = true;
                    NewField11461.TextFont.CharSet = 162;
                    NewField11461.Value = @"Hekim Kaşe İmza";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 68, 201, 81, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MASTERRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.NoClip = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                    DIAGNOSISFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 92, 99, 112, false);
                    DIAGNOSISFIELD.Name = "DIAGNOSISFIELD";
                    DIAGNOSISFIELD.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.Value = @"";

                    PATIENTENTERPRISEORMILUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 67, 103, 84, false);
                    PATIENTENTERPRISEORMILUNIT.Name = "PATIENTENTERPRISEORMILUNIT";
                    PATIENTENTERPRISEORMILUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTENTERPRISEORMILUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTENTERPRISEORMILUNIT.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTENTERPRISEORMILUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTENTERPRISEORMILUNIT.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTENTERPRISEORMILUNIT.TextFont.Size = 8;
                    PATIENTENTERPRISEORMILUNIT.TextFont.CharSet = 162;
                    PATIENTENTERPRISEORMILUNIT.Value = @"";

                    MILUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 50, 262, 55, false);
                    MILUNIT.Name = "MILUNIT";
                    MILUNIT.Visible = EvetHayirEnum.ehHayir;
                    MILUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILUNIT.Value = @"";

                    REFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 46, 189, 51, false);
                    REFNO.Name = "REFNO";
                    REFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFNO.TextFont.Size = 9;
                    REFNO.TextFont.CharSet = 162;
                    REFNO.Value = @"{#REFNO#}";

                    SOCIALINSURANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 55, 101, 60, false);
                    SOCIALINSURANCE.Name = "SOCIALINSURANCE";
                    SOCIALINSURANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOCIALINSURANCE.TextFont.Size = 9;
                    SOCIALINSURANCE.TextFont.CharSet = 162;
                    SOCIALINSURANCE.Value = @"";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 64, 262, 69, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EPISODE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StoneBreakUpRequest.StoneBreakUpReportNQL_Class dataset_StoneBreakUpReportNQL = ParentGroup.rsGroup.GetCurrentRecord<StoneBreakUpRequest.StoneBreakUpReportNQL_Class>(0);
                    SIGNATURE.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    PatientName.CalcValue = (dataset_StoneBreakUpReportNQL != null ? Globals.ToStringCore(dataset_StoneBreakUpReportNQL.Name) : "") + @" " + (dataset_StoneBreakUpReportNQL != null ? Globals.ToStringCore(dataset_StoneBreakUpReportNQL.Surname) : "");
                    LOGO11.CalcValue = LOGO11.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField11461.CalcValue = NewField11461.Value;
                    MASTERRESOURCE.CalcValue = (dataset_StoneBreakUpReportNQL != null ? Globals.ToStringCore(dataset_StoneBreakUpReportNQL.Masterresource) : "");
                    DIAGNOSISFIELD.CalcValue = DIAGNOSISFIELD.Value;
                    PATIENTENTERPRISEORMILUNIT.CalcValue = @"";
                    MILUNIT.CalcValue = @"";
                    REFNO.CalcValue = (dataset_StoneBreakUpReportNQL != null ? Globals.ToStringCore(dataset_StoneBreakUpReportNQL.Refno) : "");
                    SOCIALINSURANCE.CalcValue = @"";
                    EPISODE.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { SIGNATURE,NewField11,PatientName,LOGO11,NewField122,NewField1131,NewField1141,NewField1161,NewField11421,NewField11431,NewField11461,MASTERRESOURCE,DIAGNOSISFIELD,PATIENTENTERPRISEORMILUNIT,MILUNIT,REFNO,SOCIALINSURANCE,EPISODE,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    string diagnoseStr= "";
//            
//            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((StoneBreakUpReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            StoneBreakUpRequest p = (StoneBreakUpRequest)context.GetObject(new Guid(sObjectID),"StoneBreakUpRequest");
//            this.EPISODE.CalcValue = p.Episode.ObjectID.ToString();
//            
//            if( this.MILUNIT.CalcValue != "")
//            {
//                this.PATIENTENTERPRISEORMILUNIT.CalcValue= this.MILUNIT.CalcValue;
//            }
//            else
//            {
//                this.PATIENTENTERPRISEORMILUNIT.CalcValue = p.Episode.Patient.Payer.Name.ToString();
//            }
//            
//            if(p.Episode.Relationship != null)
//            {
//                this.PATIENTENTERPRISEORMILUNIT.CalcValue += "(" + p.Episode.Relationship.Relationship + ")";
//            }
//            
//            if(p.Diagnosis.Count>0)// Buradan tanı girişi yapılmadıysa episodedaki kesin  tanılara bakar
//            {
//                foreach( DiagnosisGrid diagnosis in p.Diagnosis)
//                {
//                    diagnoseStr = diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name + "; " + diagnoseStr ;
//                }
//            }
//            else
//            {
//                foreach( DiagnosisGrid diagnosis in p.Episode.Diagnosis)
//                {
//                    diagnoseStr = diagnosis.Diagnose.Code + "-" +  diagnosis.Diagnose.Name + "; " + diagnoseStr ;
//                }
//            }
//            this.DIAGNOSISFIELD.CalcValue= diagnoseStr;
//            
//            if(p.ProcedureDoctor!=null)
//                this.SIGNATURE.CalcValue = p.ProcedureDoctor.SignatureBlock;
//            
//            //SOCIAL INSURANCE
//            SubEpisodeProtocol tempSEP = null;
//            foreach (SubEpisodeProtocol sep in p.SubEpisode.SubEpisodeProtocols)
//            {
//                if (tempSEP == null)
//                    tempSEP = sep;
//                else if (tempSEP.CreationDate.HasValue && sep.CreationDate.HasValue && tempSEP.CreationDate.Value < sep.CreationDate.Value)
//                    tempSEP = sep;
//            }
//
//            if (tempSEP != null && tempSEP.Payer != null && tempSEP.Payer.Type != null)
//                this.SOCIALINSURANCE.CalcValue = tempSEP.Payer.Type.Name;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public StoneBreakUpReport MyParentReport
                {
                    get { return (StoneBreakUpReport)ParentReport; }
                }
                
                public TTReportField SIGNATURE12;
                public TTReportField NewField151;
                public TTReportField SIGNATURE1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine181;
                public TTReportShape NewLine191;
                public TTReportField ONAY;
                public TTReportShape NewLine171;
                public TTReportShape NewLine1191; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 33;
                    RepeatCount = 0;
                    
                    SIGNATURE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 102, 8, false);
                    SIGNATURE12.Name = "SIGNATURE12";
                    SIGNATURE12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE12.TextFont.Bold = true;
                    SIGNATURE12.TextFont.CharSet = 162;
                    SIGNATURE12.Value = @"HEKİM - KAŞE - İMZA";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 3, 201, 8, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"BAŞTABİP - MÜHÜR - İMZA";

                    SIGNATURE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 103, 29, false);
                    SIGNATURE1.Name = "SIGNATURE1";
                    SIGNATURE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNATURE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIGNATURE1.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNATURE1.NoClip = EvetHayirEnum.ehEvet;
                    SIGNATURE1.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNATURE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNATURE1.TextFont.CharSet = 162;
                    SIGNATURE1.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 2, 201, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 2, 103, 30, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 2, 201, 30, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 8, 201, 25, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.NoClip = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"";

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 30, 201, 30, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 2, 9, 30, false);
                    NewLine1191.Name = "NewLine1191";
                    NewLine1191.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StoneBreakUpRequest.StoneBreakUpReportNQL_Class dataset_StoneBreakUpReportNQL = ParentGroup.rsGroup.GetCurrentRecord<StoneBreakUpRequest.StoneBreakUpReportNQL_Class>(0);
                    SIGNATURE12.CalcValue = SIGNATURE12.Value;
                    NewField151.CalcValue = NewField151.Value;
                    SIGNATURE1.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    return new TTReportObject[] { SIGNATURE12,NewField151,SIGNATURE1,ONAY};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    //                                                                            if(this.SICILKULLAN.CalcValue=="TRUE")
//            {
//                this.DIPSICLABEL.CalcValue= "SİCİL NO :";
//                this.DIPSIC.CalcValue=this.SICILNO.CalcValue;
//            }
//            else
//            {
//                this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
//                this.DIPSIC.CalcValue=this.DIPLOMANO.CalcValue;
//            }
//            
//
//            if(this.UNVANKULLAN.CalcValue!="TRUE")
//            {
//                this.SINRUT.CalcValue=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
//            }
//            else
//            {
//                if(this.UNVAN.CalcValue=="")
//                {
//                    this.SINRUT.Value=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
//                }
//                else
//                {
//                    this.SINRUT.CalcValue=this.UNVAN.CalcValue + " " + this.RUTBEONAY.CalcValue;
//                }
//                
//            }
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StoneBreakUpReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            StoneBreakUpRequest p = (StoneBreakUpRequest )context.GetObject(new Guid(sObjectID),"StoneBreakUpRequest");
            if(p.ProcedureDoctor!=null)
                    this.SIGNATURE1.CalcValue =p.ProcedureDoctor.SignatureBlock;
            
            this.ONAY.CalcValue =ResHospital.ApprovalSignatureBlock;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public StoneBreakUpReport MyParentReport
            {
                get { return (StoneBreakUpReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RAPORTARIH { get {return Body().RAPORTARIH;} }
            public TTReportField LBL11 { get {return Body().LBL11;} }
            public TTReportField LBL12 { get {return Body().LBL12;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField LBL13 { get {return Body().LBL13;} }
            public TTReportRTF StoneReport { get {return Body().StoneReport;} }
            public TTReportField LBL111 { get {return Body().LBL111;} }
            public TTReportField LBL1111 { get {return Body().LBL1111;} }
            public TTReportField LBL1112 { get {return Body().LBL1112;} }
            public TTReportField LBL12111 { get {return Body().LBL12111;} }
            public TTReportField LBL111121 { get {return Body().LBL111121;} }
            public TTReportField LBL1121111 { get {return Body().LBL1121111;} }
            public TTReportField LBL131 { get {return Body().LBL131;} }
            public TTReportField RadiologyInfo { get {return Body().RadiologyInfo;} }
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
                public StoneBreakUpReport MyParentReport
                {
                    get { return (StoneBreakUpReport)ParentReport; }
                }
                
                public TTReportField RAPORTARIH;
                public TTReportField LBL11;
                public TTReportField LBL12;
                public TTReportField RAPORNO;
                public TTReportField LBL13;
                public TTReportRTF StoneReport;
                public TTReportField LBL111;
                public TTReportField LBL1111;
                public TTReportField LBL1112;
                public TTReportField LBL12111;
                public TTReportField LBL111121;
                public TTReportField LBL1121111;
                public TTReportField LBL131;
                public TTReportField RadiologyInfo; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 74;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 2, 90, 7, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"Medium Date";
                    RAPORTARIH.TextFont.Size = 9;
                    RAPORTARIH.TextFont.CharSet = 162;
                    RAPORTARIH.Value = @"{#Header.REPORTDATE#}";

                    LBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 50, 7, false);
                    LBL11.Name = "LBL11";
                    LBL11.TextFont.Size = 11;
                    LBL11.TextFont.Bold = true;
                    LBL11.TextFont.CharSet = 162;
                    LBL11.Value = @"Rapor Tarih      :";

                    LBL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 2, 150, 7, false);
                    LBL12.Name = "LBL12";
                    LBL12.TextFont.Size = 11;
                    LBL12.TextFont.Bold = true;
                    LBL12.TextFont.CharSet = 162;
                    LBL12.Value = @"Rapor No:";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 2, 201, 7, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.TextFont.Size = 9;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#Header.REPORTNO#}";

                    LBL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 51, 13, false);
                    LBL13.Name = "LBL13";
                    LBL13.TextFont.Size = 11;
                    LBL13.TextFont.Bold = true;
                    LBL13.TextFont.CharSet = 162;
                    LBL13.Value = @"Rapor            ";

                    StoneReport = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 13, 202, 28, false);
                    StoneReport.Name = "StoneReport";
                    StoneReport.CanExpand = EvetHayirEnum.ehHayir;
                    StoneReport.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    LBL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 47, 74, false);
                    LBL111.Name = "LBL111";
                    LBL111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBL111.TextFont.Size = 11;
                    LBL111.TextFont.Bold = true;
                    LBL111.TextFont.CharSet = 162;
                    LBL111.Value = @"Tarih";

                    LBL1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 69, 95, 74, false);
                    LBL1111.Name = "LBL1111";
                    LBL1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBL1111.TextFont.Size = 11;
                    LBL1111.TextFont.Bold = true;
                    LBL1111.TextFont.CharSet = 162;
                    LBL1111.Value = @"Taş Kırma İşlemi";

                    LBL1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 69, 137, 74, false);
                    LBL1112.Name = "LBL1112";
                    LBL1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBL1112.TextFont.Size = 11;
                    LBL1112.TextFont.Bold = true;
                    LBL1112.TextFont.CharSet = 162;
                    LBL1112.Value = @"Lokalizasyon";

                    LBL12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 69, 152, 74, false);
                    LBL12111.Name = "LBL12111";
                    LBL12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBL12111.TextFont.Size = 11;
                    LBL12111.TextFont.Bold = true;
                    LBL12111.TextFont.CharSet = 162;
                    LBL12111.Value = @"Taş";

                    LBL111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 69, 168, 74, false);
                    LBL111121.Name = "LBL111121";
                    LBL111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBL111121.TextFont.Size = 11;
                    LBL111121.TextFont.Bold = true;
                    LBL111121.TextFont.CharSet = 162;
                    LBL111121.Value = @"Kaçıncı";

                    LBL1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 69, 202, 74, false);
                    LBL1121111.Name = "LBL1121111";
                    LBL1121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBL1121111.TextFont.Size = 11;
                    LBL1121111.TextFont.Bold = true;
                    LBL1121111.TextFont.CharSet = 162;
                    LBL1121111.Value = @"Taraf";

                    LBL131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 51, 36, false);
                    LBL131.Name = "LBL131";
                    LBL131.TextFont.Size = 11;
                    LBL131.TextFont.Bold = true;
                    LBL131.TextFont.CharSet = 162;
                    LBL131.Value = @"Radyoloji Bilgileri         ";

                    RadiologyInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 202, 67, false);
                    RadiologyInfo.Name = "RadiologyInfo";
                    RadiologyInfo.MultiLine = EvetHayirEnum.ehEvet;
                    RadiologyInfo.WordBreak = EvetHayirEnum.ehEvet;
                    RadiologyInfo.TextFont.Size = 9;
                    RadiologyInfo.TextFont.CharSet = 162;
                    RadiologyInfo.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StoneBreakUpRequest.StoneBreakUpReportNQL_Class dataset_StoneBreakUpReportNQL = MyParentReport.Header.rsGroup.GetCurrentRecord<StoneBreakUpRequest.StoneBreakUpReportNQL_Class>(0);
                    RAPORTARIH.CalcValue = (dataset_StoneBreakUpReportNQL != null ? Globals.ToStringCore(dataset_StoneBreakUpReportNQL.ReportDate) : "");
                    LBL11.CalcValue = LBL11.Value;
                    LBL12.CalcValue = LBL12.Value;
                    RAPORNO.CalcValue = (dataset_StoneBreakUpReportNQL != null ? Globals.ToStringCore(dataset_StoneBreakUpReportNQL.ReportNo) : "");
                    LBL13.CalcValue = LBL13.Value;
                    StoneReport.CalcValue = StoneReport.Value;
                    LBL111.CalcValue = LBL111.Value;
                    LBL1111.CalcValue = LBL1111.Value;
                    LBL1112.CalcValue = LBL1112.Value;
                    LBL12111.CalcValue = LBL12111.Value;
                    LBL111121.CalcValue = LBL111121.Value;
                    LBL1121111.CalcValue = LBL1121111.Value;
                    LBL131.CalcValue = LBL131.Value;
                    RadiologyInfo.CalcValue = RadiologyInfo.Value;
                    return new TTReportObject[] { RAPORTARIH,LBL11,LBL12,RAPORNO,LBL13,StoneReport,LBL111,LBL1111,LBL1112,LBL12111,LBL111121,LBL1121111,LBL131,RadiologyInfo};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((StoneBreakUpReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            StoneBreakUpRequest stoneBreakUpRequest = (StoneBreakUpRequest)context.GetObject(new Guid(sObjectID),"StoneBreakUpRequest");
            if(stoneBreakUpRequest.Report!=null)
                this.StoneReport.Value = stoneBreakUpRequest.Report.ToString();  
            
            IList stoneBreakUpRequestList = new List<StoneBreakUpRequest>();
              stoneBreakUpRequestList = StoneBreakUpRequest.GetByEpisode(context,stoneBreakUpRequest.Episode.ObjectID);
              string radiologyInfoStr = "";
              foreach(StoneBreakUpRequest sbur in stoneBreakUpRequestList)
              {
                  if(sbur.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                  {
                      if(sbur.RadiologyInformation != null)
                          radiologyInfoStr += (TTObjectClasses.Common.GetTextOfRTFString(sbur.RadiologyInformation.ToString()) + "\r\n");
                  }
              } 
              this.RadiologyInfo.Value = radiologyInfoStr;
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                   TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((StoneBreakUpReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            StoneBreakUpRequest stoneBreakUpRequest = (StoneBreakUpRequest)context.GetObject(new Guid(sObjectID),"StoneBreakUpRequest");
//            this.Report.CalcValue=stoneBreakUpRequest.Report; 
              
//              TTObjectContext context = new TTObjectContext(true);
//              string sObjectID = ((StoneBreakUpReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//              StoneBreakUpRequest stoneBreakUpRequest = (StoneBreakUpRequest)context.GetObject(new Guid(sObjectID),"StoneBreakUpRequest");
//
//              IList stoneBreakUpRequestList = new List<StoneBreakUpRequest>();
//              stoneBreakUpRequestList = StoneBreakUpRequest.GetByEpisode(context,stoneBreakUpRequest.Episode.ObjectID);
//              foreach(StoneBreakUpRequest sbur in stoneBreakUpRequestList)
//              {
//                  if(sbur.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
//                  {
//                      if(sbur.RadiologyInformation != null)
//                        this.RadiologyInfo.Value += sbur.StoneBreakUpProcedures[0].ProcedureDate.ToString() + "-" + sbur.RadiologyInformation.ToString() + "\n";
//                  }
//              }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ESWLGroup : TTReportGroup
        {
            public StoneBreakUpReport MyParentReport
            {
                get { return (StoneBreakUpReport)ParentReport; }
            }

            new public ESWLGroupBody Body()
            {
                return (ESWLGroupBody)_body;
            }
            public TTReportField PROCEDUREDATE { get {return Body().PROCEDUREDATE;} }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField NUMBEROFPROCEDURE { get {return Body().NUMBEROFPROCEDURE;} }
            public TTReportField ZONEOFSTONE { get {return Body().ZONEOFSTONE;} }
            public TTReportField PARTOFSTONE { get {return Body().PARTOFSTONE;} }
            public TTReportField STONEDIMENSION { get {return Body().STONEDIMENSION;} }
            public ESWLGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ESWLGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StoneBreakUpProcedure.GetByEpisode_Class>("GetByEpisode", StoneBreakUpProcedure.GetByEpisode((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.Header.EPISODE.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ESWLGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ESWLGroupBody : TTReportSection
            {
                public StoneBreakUpReport MyParentReport
                {
                    get { return (StoneBreakUpReport)ParentReport; }
                }
                
                public TTReportField PROCEDUREDATE;
                public TTReportField NO;
                public TTReportField NUMBEROFPROCEDURE;
                public TTReportField ZONEOFSTONE;
                public TTReportField PARTOFSTONE;
                public TTReportField STONEDIMENSION; 
                public ESWLGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    PROCEDUREDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 47, 5, false);
                    PROCEDUREDATE.Name = "PROCEDUREDATE";
                    PROCEDUREDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDATE.TextFormat = @"Medium Date";
                    PROCEDUREDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDUREDATE.TextFont.Size = 9;
                    PROCEDUREDATE.TextFont.CharSet = 162;
                    PROCEDUREDATE.Value = @"{#PROCEDUREDATE#}";

                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 167, 5, false);
                    NO.Name = "NO";
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.TextFormat = @"Medium Date";
                    NO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NO.TextFont.Size = 9;
                    NO.TextFont.CharSet = 162;
                    NO.Value = @"{#NUMBEROFPROCEDURE#}";

                    NUMBEROFPROCEDURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 0, 95, 5, false);
                    NUMBEROFPROCEDURE.Name = "NUMBEROFPROCEDURE";
                    NUMBEROFPROCEDURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBEROFPROCEDURE.TextFormat = @"Medium Date";
                    NUMBEROFPROCEDURE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NUMBEROFPROCEDURE.TextFont.Size = 9;
                    NUMBEROFPROCEDURE.TextFont.CharSet = 162;
                    NUMBEROFPROCEDURE.Value = @"ESWL {#NUMBEROFPROCEDURE#}. Seans";

                    ZONEOFSTONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 202, 5, false);
                    ZONEOFSTONE.Name = "ZONEOFSTONE";
                    ZONEOFSTONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ZONEOFSTONE.TextFormat = @"Medium Date";
                    ZONEOFSTONE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ZONEOFSTONE.ObjectDefName = "ZoneOfStoneEnum";
                    ZONEOFSTONE.DataMember = "DISPLAYTEXT";
                    ZONEOFSTONE.TextFont.Size = 9;
                    ZONEOFSTONE.TextFont.CharSet = 162;
                    ZONEOFSTONE.Value = @"{#ZONEOFSTONE#}";

                    PARTOFSTONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 137, 5, false);
                    PARTOFSTONE.Name = "PARTOFSTONE";
                    PARTOFSTONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARTOFSTONE.TextFormat = @"Medium Date";
                    PARTOFSTONE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARTOFSTONE.TextFont.Size = 9;
                    PARTOFSTONE.TextFont.CharSet = 162;
                    PARTOFSTONE.Value = @"{#PARTOFSTONE#}";

                    STONEDIMENSION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 152, 5, false);
                    STONEDIMENSION.Name = "STONEDIMENSION";
                    STONEDIMENSION.FieldType = ReportFieldTypeEnum.ftVariable;
                    STONEDIMENSION.TextFormat = @"Medium Date";
                    STONEDIMENSION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STONEDIMENSION.TextFont.Size = 9;
                    STONEDIMENSION.TextFont.CharSet = 162;
                    STONEDIMENSION.Value = @"{#STONEDIMENSION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StoneBreakUpProcedure.GetByEpisode_Class dataset_GetByEpisode = ParentGroup.rsGroup.GetCurrentRecord<StoneBreakUpProcedure.GetByEpisode_Class>(0);
                    PROCEDUREDATE.CalcValue = (dataset_GetByEpisode != null ? Globals.ToStringCore(dataset_GetByEpisode.ProcedureDate) : "");
                    NO.CalcValue = (dataset_GetByEpisode != null ? Globals.ToStringCore(dataset_GetByEpisode.NumberOfProcedure) : "");
                    NUMBEROFPROCEDURE.CalcValue = @"ESWL " + (dataset_GetByEpisode != null ? Globals.ToStringCore(dataset_GetByEpisode.NumberOfProcedure) : "") + @". Seans";
                    ZONEOFSTONE.CalcValue = (dataset_GetByEpisode != null ? Globals.ToStringCore(dataset_GetByEpisode.ZoneOfStone) : "");
                    ZONEOFSTONE.PostFieldValueCalculation();
                    PARTOFSTONE.CalcValue = (dataset_GetByEpisode != null ? Globals.ToStringCore(dataset_GetByEpisode.PartOfStone) : "");
                    STONEDIMENSION.CalcValue = (dataset_GetByEpisode != null ? Globals.ToStringCore(dataset_GetByEpisode.StoneDimension) : "");
                    return new TTReportObject[] { PROCEDUREDATE,NO,NUMBEROFPROCEDURE,ZONEOFSTONE,PARTOFSTONE,STONEDIMENSION};
                }
            }

        }

        public ESWLGroup ESWL;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StoneBreakUpReport()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            ESWL = new ESWLGroup(Header,"ESWL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Taş Kırma", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "STONEBREAKUPREPORT";
            Caption = "Taş Kırma Raporu";
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