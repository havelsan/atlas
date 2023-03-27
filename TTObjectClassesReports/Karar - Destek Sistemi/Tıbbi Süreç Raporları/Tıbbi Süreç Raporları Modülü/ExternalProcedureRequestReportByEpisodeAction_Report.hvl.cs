
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
    /// Dış Hizmet İstemi
    /// </summary>
    public partial class ExternalProcedureRequestReportByEpisodeAction : TTReport
    {
#region Methods
   public string RequestedByUser ;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField1112121 { get {return Header().NewField1112121;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HizmetOzel11 { get {return Footer().HizmetOzel11;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName11 { get {return Footer().UserName11;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                list[0] = new TTReportNqlData<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>("DisTetkikIstemRaporByEpisodeActionNQL", EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField NewField1112121;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 47, 171, 54, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112121.TextFont.Size = 14;
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @"DIŞ HİZMET İSTEMİ";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 6, 171, 46, false);
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

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 40, 29, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class dataset_DisTetkikIstemRaporByEpisodeActionNQL = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>(0);
                    NewField1112121.CalcValue = NewField1112121.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1112121,LOGO,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField HizmetOzel11;
                public TTReportShape NewLine11;
                public TTReportField PrintDate;
                public TTReportField UserName11;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 20;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HizmetOzel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 4, 243, 10, false);
                    HizmetOzel11.Name = "HizmetOzel11";
                    HizmetOzel11.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel11.TextFont.Size = 11;
                    HizmetOzel11.TextFont.Bold = true;
                    HizmetOzel11.TextFont.Underline = true;
                    HizmetOzel11.TextFont.CharSet = 162;
                    HizmetOzel11.Value = @"HİZMETE ÖZEL";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 3, 200, 3, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 34, 9, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    UserName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 4, 122, 9, false);
                    UserName11.Name = "UserName11";
                    UserName11.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName11.TextFont.Size = 8;
                    UserName11.TextFont.CharSet = 162;
                    UserName11.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 4, 200, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class dataset_DisTetkikIstemRaporByEpisodeActionNQL = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>(0);
                    HizmetOzel11.CalcValue = HizmetOzel11.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName11.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { HizmetOzel11,PrintDate,PageNumber,UserName11};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11411 { get {return Body().NewField11411;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField1241 { get {return Body().NewField1241;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField NewField1361 { get {return Body().NewField1361;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField NewField11241 { get {return Body().NewField11241;} }
            public TTReportField NewField112211 { get {return Body().NewField112211;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField AGE1 { get {return Body().AGE1;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField NewField11232 { get {return Body().NewField11232;} }
            public TTReportField NewField114211 { get {return Body().NewField114211;} }
            public TTReportField BirrhDate { get {return Body().BirrhDate;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField NewField1122111 { get {return Body().NewField1122111;} }
            public TTReportField BirthPlace { get {return Body().BirthPlace;} }
            public TTReportField NewField11112211 { get {return Body().NewField11112211;} }
            public TTReportField BIRTHPLACE { get {return Body().BIRTHPLACE;} }
            public TTReportField NewField1111161111 { get {return Body().NewField1111161111;} }
            public TTReportField HASTADURUMU { get {return Body().HASTADURUMU;} }
            public TTReportField NewField11812 { get {return Body().NewField11812;} }
            public TTReportField NewField111222 { get {return Body().NewField111222;} }
            public TTReportField lblICDCode1 { get {return Body().lblICDCode1;} }
            public TTReportField NewField1222111 { get {return Body().NewField1222111;} }
            public TTReportField ICDCode { get {return Body().ICDCode;} }
            public TTReportField MASTERRESCONTACTADDRESS { get {return Body().MASTERRESCONTACTADDRESS;} }
            public TTReportField lblICDCode12 { get {return Body().lblICDCode12;} }
            public TTReportField lblICDCode121 { get {return Body().lblICDCode121;} }
            public TTReportField MASTERRESCONTACTPHONE { get {return Body().MASTERRESCONTACTPHONE;} }
            public TTReportField NewField11212111 { get {return Body().NewField11212111;} }
            public TTReportField NewField11112221 { get {return Body().NewField11112221;} }
            public TTReportField BirrhDate1 { get {return Body().BirrhDate1;} }
            public TTReportField NewField11112212 { get {return Body().NewField11112212;} }
            public TTReportField BirrhDate11 { get {return Body().BirrhDate11;} }
            public TTReportField NewField121221111 { get {return Body().NewField121221111;} }
            public TTReportField MOTHERNAME { get {return Body().MOTHERNAME;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField BirrhDate111 { get {return Body().BirrhDate111;} }
            public TTReportField NewField1111122121 { get {return Body().NewField1111122121;} }
            public TTReportField PATIENTADDRESS { get {return Body().PATIENTADDRESS;} }
            public TTReportField BirrhDate1111 { get {return Body().BirrhDate1111;} }
            public TTReportField PATIENTPHONE { get {return Body().PATIENTPHONE;} }
            public TTReportField NewField11112222 { get {return Body().NewField11112222;} }
            public TTReportField NewField112221111 { get {return Body().NewField112221111;} }
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
                list[0] = new TTReportNqlData<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>("DisTetkikIstemRaporByEpisodeActionNQL", EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField NewField11411;
                public TTReportField NewField121;
                public TTReportField REQUESTDATE;
                public TTReportField NewField151;
                public TTReportField NAME;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField1261;
                public TTReportField NewField1321;
                public TTReportField HASTANO;
                public TTReportField NewField1241;
                public TTReportField FROMRESOURCE;
                public TTReportField NewField1361;
                public TTReportField NewField161;
                public TTReportField NewField11221;
                public TTReportField NewField11231;
                public TTReportField NewField11241;
                public TTReportField NewField112211;
                public TTReportField NewField1161;
                public TTReportField SEX;
                public TTReportField AGE1;
                public TTReportField UNIQUEREFNO;
                public TTReportField NewField11232;
                public TTReportField NewField114211;
                public TTReportField BirrhDate;
                public TTReportField BIRTHDATE;
                public TTReportField NewField1122111;
                public TTReportField BirthPlace;
                public TTReportField NewField11112211;
                public TTReportField BIRTHPLACE;
                public TTReportField NewField1111161111;
                public TTReportField HASTADURUMU;
                public TTReportField NewField11812;
                public TTReportField NewField111222;
                public TTReportField lblICDCode1;
                public TTReportField NewField1222111;
                public TTReportField ICDCode;
                public TTReportField MASTERRESCONTACTADDRESS;
                public TTReportField lblICDCode12;
                public TTReportField lblICDCode121;
                public TTReportField MASTERRESCONTACTPHONE;
                public TTReportField NewField11212111;
                public TTReportField NewField11112221;
                public TTReportField BirrhDate1;
                public TTReportField NewField11112212;
                public TTReportField BirrhDate11;
                public TTReportField NewField121221111;
                public TTReportField MOTHERNAME;
                public TTReportField FATHERNAME;
                public TTReportField BirrhDate111;
                public TTReportField NewField1111122121;
                public TTReportField PATIENTADDRESS;
                public TTReportField BirrhDate1111;
                public TTReportField PATIENTPHONE;
                public TTReportField NewField11112222;
                public TTReportField NewField112221111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 111;
                    RepeatCount = 0;
                    
                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 12, 50, 17, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Cinsiyet / Yaşı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 27, 154, 32, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İstek Tarihi";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 27, 205, 32, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 50, 7, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Hastanın";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 7, 112, 12, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "EpisodeAction";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{@TTOBJECTID@}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 12, 205, 17, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 7, 50, 12, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @"Adı Soyadı";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 12, 154, 17, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 17, 205, 22, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "EpisodeAction";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 17, 154, 22, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Hasta No";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 22, 205, 27, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FROMRESOURCE.TextFont.Size = 9;
                    FROMRESOURCE.TextFont.CharSet = 162;
                    FROMRESOURCE.Value = @"{#FROMRES#}";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 22, 154, 27, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.TextFont.Size = 9;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"İsteyen Bölüm";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 7, 52, 12, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 9;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 22, 156, 27, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 17, 156, 22, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @":";

                    NewField11241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 12, 156, 17, false);
                    NewField11241.Name = "NewField11241";
                    NewField11241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11241.TextFont.Size = 9;
                    NewField11241.TextFont.Bold = true;
                    NewField11241.TextFont.CharSet = 162;
                    NewField11241.Value = @":";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 27, 156, 32, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 12, 52, 17, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 12, 85, 17, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SEX.ObjectDefName = "SKRSCinsiyet";
                    SEX.DataMember = "ADI";
                    SEX.TextFont.Name = "Arial";
                    SEX.TextFont.Size = 9;
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"{#SEX#}";

                    AGE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 12, 112, 17, false);
                    AGE1.Name = "AGE1";
                    AGE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGE1.Value = @"";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 7, 205, 12, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.ObjectDefName = "EpisodeAction";
                    UNIQUEREFNO.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{@TTOBJECTID@}";

                    NewField11232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 7, 154, 12, false);
                    NewField11232.Name = "NewField11232";
                    NewField11232.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11232.TextFont.Size = 9;
                    NewField11232.TextFont.Bold = true;
                    NewField11232.TextFont.CharSet = 162;
                    NewField11232.Value = @"TC Kimlik No";

                    NewField114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 7, 156, 12, false);
                    NewField114211.Name = "NewField114211";
                    NewField114211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114211.TextFont.Size = 9;
                    NewField114211.TextFont.Bold = true;
                    NewField114211.TextFont.CharSet = 162;
                    NewField114211.Value = @":";

                    BirrhDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 22, 50, 27, false);
                    BirrhDate.Name = "BirrhDate";
                    BirrhDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate.TextFont.Size = 9;
                    BirrhDate.TextFont.Bold = true;
                    BirrhDate.TextFont.CharSet = 162;
                    BirrhDate.Value = @"Doğum Tarihi";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 22, 112, 27, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRTHDATE.ObjectDefName = "EpisodeAction";
                    BIRTHDATE.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{@TTOBJECTID@}";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 22, 52, 27, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122111.TextFont.Size = 9;
                    NewField1122111.TextFont.Bold = true;
                    NewField1122111.TextFont.CharSet = 162;
                    NewField1122111.Value = @":";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 17, 50, 22, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirthPlace.TextFont.Size = 9;
                    BirthPlace.TextFont.Bold = true;
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"Doğum Yeri";

                    NewField11112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 17, 52, 22, false);
                    NewField11112211.Name = "NewField11112211";
                    NewField11112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112211.TextFont.Size = 9;
                    NewField11112211.TextFont.Bold = true;
                    NewField11112211.TextFont.CharSet = 162;
                    NewField11112211.Value = @":";

                    BIRTHPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 17, 112, 22, false);
                    BIRTHPLACE.Name = "BIRTHPLACE";
                    BIRTHPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHPLACE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRTHPLACE.TextFont.Size = 9;
                    BIRTHPLACE.TextFont.CharSet = 162;
                    BIRTHPLACE.Value = @"{#BIRTHPLACE#}";

                    NewField1111161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 105, 60, 110, false);
                    NewField1111161111.Name = "NewField1111161111";
                    NewField1111161111.TextFont.Size = 9;
                    NewField1111161111.TextFont.Bold = true;
                    NewField1111161111.TextFont.Underline = true;
                    NewField1111161111.TextFont.CharSet = 162;
                    NewField1111161111.Value = @"İSTENEN TETKİKLER";

                    HASTADURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 32, 205, 37, false);
                    HASTADURUMU.Name = "HASTADURUMU";
                    HASTADURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTADURUMU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTADURUMU.ObjectDefName = "PatientStatusEnum";
                    HASTADURUMU.DataMember = "DISPLAYTEXT";
                    HASTADURUMU.TextFont.Size = 9;
                    HASTADURUMU.TextFont.CharSet = 162;
                    HASTADURUMU.Value = @"{#PATIENTSTATUS#}";

                    NewField11812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 32, 154, 37, false);
                    NewField11812.Name = "NewField11812";
                    NewField11812.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11812.TextFont.Size = 9;
                    NewField11812.TextFont.Bold = true;
                    NewField11812.TextFont.CharSet = 162;
                    NewField11812.Value = @"Hasta Durumu";

                    NewField111222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 32, 156, 37, false);
                    NewField111222.Name = "NewField111222";
                    NewField111222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111222.TextFont.Size = 9;
                    NewField111222.TextFont.Bold = true;
                    NewField111222.TextFont.CharSet = 162;
                    NewField111222.Value = @":";

                    lblICDCode1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 37, 155, 42, false);
                    lblICDCode1.Name = "lblICDCode1";
                    lblICDCode1.TextFont.Size = 9;
                    lblICDCode1.TextFont.Bold = true;
                    lblICDCode1.TextFont.CharSet = 162;
                    lblICDCode1.Value = @"ICD Tanı Kodu";

                    NewField1222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 37, 156, 42, false);
                    NewField1222111.Name = "NewField1222111";
                    NewField1222111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1222111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1222111.TextFont.Size = 9;
                    NewField1222111.TextFont.Bold = true;
                    NewField1222111.TextFont.CharSet = 162;
                    NewField1222111.Value = @":";

                    ICDCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 37, 213, 58, false);
                    ICDCode.Name = "ICDCode";
                    ICDCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICDCode.TextFont.Size = 9;
                    ICDCode.TextFont.CharSet = 162;
                    ICDCode.Value = @"";

                    MASTERRESCONTACTADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 78, 213, 91, false);
                    MASTERRESCONTACTADDRESS.Name = "MASTERRESCONTACTADDRESS";
                    MASTERRESCONTACTADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESCONTACTADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTADDRESS.ObjectDefName = "ResObservationUnit";
                    MASTERRESCONTACTADDRESS.DataMember = "CONTACTADDRESS";
                    MASTERRESCONTACTADDRESS.TextFont.Size = 12;
                    MASTERRESCONTACTADDRESS.TextFont.Bold = true;
                    MASTERRESCONTACTADDRESS.TextFont.CharSet = 162;
                    MASTERRESCONTACTADDRESS.Value = @"{#MASTERRES#}";

                    lblICDCode12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 78, 47, 83, false);
                    lblICDCode12.Name = "lblICDCode12";
                    lblICDCode12.TextFont.Size = 9;
                    lblICDCode12.TextFont.Bold = true;
                    lblICDCode12.TextFont.CharSet = 162;
                    lblICDCode12.Value = @"İrtibat Adresi";

                    lblICDCode121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 92, 47, 97, false);
                    lblICDCode121.Name = "lblICDCode121";
                    lblICDCode121.TextFont.Size = 9;
                    lblICDCode121.TextFont.Bold = true;
                    lblICDCode121.TextFont.CharSet = 162;
                    lblICDCode121.Value = @"İrtibat Telefonu";

                    MASTERRESCONTACTPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 92, 102, 97, false);
                    MASTERRESCONTACTPHONE.Name = "MASTERRESCONTACTPHONE";
                    MASTERRESCONTACTPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESCONTACTPHONE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MASTERRESCONTACTPHONE.MultiLine = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTPHONE.NoClip = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTPHONE.WordBreak = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTPHONE.ExpandTabs = EvetHayirEnum.ehEvet;
                    MASTERRESCONTACTPHONE.ObjectDefName = "ResObservationUnit";
                    MASTERRESCONTACTPHONE.DataMember = "CONTACTPHONE";
                    MASTERRESCONTACTPHONE.TextFont.Size = 12;
                    MASTERRESCONTACTPHONE.TextFont.Bold = true;
                    MASTERRESCONTACTPHONE.TextFont.CharSet = 162;
                    MASTERRESCONTACTPHONE.Value = @"{#MASTERRES#}";

                    NewField11212111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 70, 171, 77, false);
                    NewField11212111.Name = "NewField11212111";
                    NewField11212111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212111.TextFont.Size = 14;
                    NewField11212111.TextFont.Bold = true;
                    NewField11212111.TextFont.CharSet = 162;
                    NewField11212111.Value = @"İSTEM YAPILAN XXXXXX";

                    NewField11112221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 78, 49, 83, false);
                    NewField11112221.Name = "NewField11112221";
                    NewField11112221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112221.TextFont.Size = 9;
                    NewField11112221.TextFont.Bold = true;
                    NewField11112221.TextFont.CharSet = 162;
                    NewField11112221.Value = @":";

                    BirrhDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 27, 50, 32, false);
                    BirrhDate1.Name = "BirrhDate1";
                    BirrhDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate1.TextFont.Size = 9;
                    BirrhDate1.TextFont.Bold = true;
                    BirrhDate1.TextFont.CharSet = 162;
                    BirrhDate1.Value = @"Anne Adı";

                    NewField11112212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 27, 52, 32, false);
                    NewField11112212.Name = "NewField11112212";
                    NewField11112212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112212.TextFont.Size = 9;
                    NewField11112212.TextFont.Bold = true;
                    NewField11112212.TextFont.CharSet = 162;
                    NewField11112212.Value = @":";

                    BirrhDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 32, 50, 37, false);
                    BirrhDate11.Name = "BirrhDate11";
                    BirrhDate11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate11.TextFont.Size = 9;
                    BirrhDate11.TextFont.Bold = true;
                    BirrhDate11.TextFont.CharSet = 162;
                    BirrhDate11.Value = @"Baba Adı";

                    NewField121221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 32, 52, 37, false);
                    NewField121221111.Name = "NewField121221111";
                    NewField121221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221111.TextFont.Size = 9;
                    NewField121221111.TextFont.Bold = true;
                    NewField121221111.TextFont.CharSet = 162;
                    NewField121221111.Value = @":";

                    MOTHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 27, 112, 32, false);
                    MOTHERNAME.Name = "MOTHERNAME";
                    MOTHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MOTHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MOTHERNAME.ObjectDefName = "EpisodeAction";
                    MOTHERNAME.DataMember = "EPISODE.PATIENT.MOTHERNAME";
                    MOTHERNAME.TextFont.Size = 9;
                    MOTHERNAME.TextFont.CharSet = 162;
                    MOTHERNAME.Value = @"{@TTOBJECTID@}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 32, 112, 37, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FATHERNAME.ObjectDefName = "EpisodeAction";
                    FATHERNAME.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    FATHERNAME.TextFont.Size = 9;
                    FATHERNAME.TextFont.CharSet = 162;
                    FATHERNAME.Value = @"{@TTOBJECTID@}";

                    BirrhDate111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 42, 50, 47, false);
                    BirrhDate111.Name = "BirrhDate111";
                    BirrhDate111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate111.TextFont.Size = 9;
                    BirrhDate111.TextFont.Bold = true;
                    BirrhDate111.TextFont.CharSet = 162;
                    BirrhDate111.Value = @"Adres";

                    NewField1111122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 42, 52, 47, false);
                    NewField1111122121.Name = "NewField1111122121";
                    NewField1111122121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111122121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111122121.TextFont.Size = 9;
                    NewField1111122121.TextFont.Bold = true;
                    NewField1111122121.TextFont.CharSet = 162;
                    NewField1111122121.Value = @":";

                    PATIENTADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 42, 112, 58, false);
                    PATIENTADDRESS.Name = "PATIENTADDRESS";
                    PATIENTADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTADDRESS.ObjectDefName = "EpisodeAction";
                    PATIENTADDRESS.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.HOMEADDRESS";
                    PATIENTADDRESS.TextFont.Size = 9;
                    PATIENTADDRESS.TextFont.CharSet = 162;
                    PATIENTADDRESS.Value = @"{@TTOBJECTID@}";

                    BirrhDate1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 37, 50, 42, false);
                    BirrhDate1111.Name = "BirrhDate1111";
                    BirrhDate1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate1111.TextFont.Size = 9;
                    BirrhDate1111.TextFont.Bold = true;
                    BirrhDate1111.TextFont.CharSet = 162;
                    BirrhDate1111.Value = @"Telefon";

                    PATIENTPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 37, 112, 42, false);
                    PATIENTPHONE.Name = "PATIENTPHONE";
                    PATIENTPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTPHONE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTPHONE.ObjectDefName = "EpisodeAction";
                    PATIENTPHONE.DataMember = "EPISODE.PATIENT.PATIENTADDRESS.MOBILEPHONE";
                    PATIENTPHONE.TextFont.Size = 9;
                    PATIENTPHONE.TextFont.CharSet = 162;
                    PATIENTPHONE.Value = @"{@TTOBJECTID@}";

                    NewField11112222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 37, 52, 42, false);
                    NewField11112222.Name = "NewField11112222";
                    NewField11112222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112222.TextFont.Size = 9;
                    NewField11112222.TextFont.Bold = true;
                    NewField11112222.TextFont.CharSet = 162;
                    NewField11112222.Value = @":";

                    NewField112221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 92, 49, 97, false);
                    NewField112221111.Name = "NewField112221111";
                    NewField112221111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112221111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112221111.TextFont.Size = 9;
                    NewField112221111.TextFont.Bold = true;
                    NewField112221111.TextFont.CharSet = 162;
                    NewField112221111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class dataset_DisTetkikIstemRaporByEpisodeActionNQL = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>(0);
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField121.CalcValue = NewField121.Value;
                    REQUESTDATE.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.RequestDate) : "");
                    NewField151.CalcValue = NewField151.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    PROTOKOLNO.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.Protocolno) : "");
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField1241.CalcValue = NewField1241.Value;
                    FROMRESOURCE.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.Fromres) : "");
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField11241.CalcValue = NewField11241.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    SEX.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.Sex) : "");
                    SEX.PostFieldValueCalculation();
                    AGE1.CalcValue = AGE1.Value;
                    UNIQUEREFNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UNIQUEREFNO.PostFieldValueCalculation();
                    NewField11232.CalcValue = NewField11232.Value;
                    NewField114211.CalcValue = NewField114211.Value;
                    BirrhDate.CalcValue = BirrhDate.Value;
                    BIRTHDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BIRTHDATE.PostFieldValueCalculation();
                    NewField1122111.CalcValue = NewField1122111.Value;
                    BirthPlace.CalcValue = BirthPlace.Value;
                    NewField11112211.CalcValue = NewField11112211.Value;
                    BIRTHPLACE.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.BirthPlace) : "");
                    NewField1111161111.CalcValue = NewField1111161111.Value;
                    HASTADURUMU.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.PatientStatus) : "");
                    HASTADURUMU.PostFieldValueCalculation();
                    NewField11812.CalcValue = NewField11812.Value;
                    NewField111222.CalcValue = NewField111222.Value;
                    lblICDCode1.CalcValue = lblICDCode1.Value;
                    NewField1222111.CalcValue = NewField1222111.Value;
                    ICDCode.CalcValue = @"";
                    MASTERRESCONTACTADDRESS.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.Masterres) : "");
                    MASTERRESCONTACTADDRESS.PostFieldValueCalculation();
                    lblICDCode12.CalcValue = lblICDCode12.Value;
                    lblICDCode121.CalcValue = lblICDCode121.Value;
                    MASTERRESCONTACTPHONE.CalcValue = (dataset_DisTetkikIstemRaporByEpisodeActionNQL != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporByEpisodeActionNQL.Masterres) : "");
                    MASTERRESCONTACTPHONE.PostFieldValueCalculation();
                    NewField11212111.CalcValue = NewField11212111.Value;
                    NewField11112221.CalcValue = NewField11112221.Value;
                    BirrhDate1.CalcValue = BirrhDate1.Value;
                    NewField11112212.CalcValue = NewField11112212.Value;
                    BirrhDate11.CalcValue = BirrhDate11.Value;
                    NewField121221111.CalcValue = NewField121221111.Value;
                    MOTHERNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    MOTHERNAME.PostFieldValueCalculation();
                    FATHERNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FATHERNAME.PostFieldValueCalculation();
                    BirrhDate111.CalcValue = BirrhDate111.Value;
                    NewField1111122121.CalcValue = NewField1111122121.Value;
                    PATIENTADDRESS.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTADDRESS.PostFieldValueCalculation();
                    BirrhDate1111.CalcValue = BirrhDate1111.Value;
                    PATIENTPHONE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTPHONE.PostFieldValueCalculation();
                    NewField11112222.CalcValue = NewField11112222.Value;
                    NewField112221111.CalcValue = NewField112221111.Value;
                    return new TTReportObject[] { NewField11411,NewField121,REQUESTDATE,NewField151,NAME,PROTOKOLNO,NewField1261,NewField1321,HASTANO,NewField1241,FROMRESOURCE,NewField1361,NewField161,NewField11221,NewField11231,NewField11241,NewField112211,NewField1161,SEX,AGE1,UNIQUEREFNO,NewField11232,NewField114211,BirrhDate,BIRTHDATE,NewField1122111,BirthPlace,NewField11112211,BIRTHPLACE,NewField1111161111,HASTADURUMU,NewField11812,NewField111222,lblICDCode1,NewField1222111,ICDCode,MASTERRESCONTACTADDRESS,lblICDCode12,lblICDCode121,MASTERRESCONTACTPHONE,NewField11212111,NewField11112221,BirrhDate1,NewField11112212,BirrhDate11,NewField121221111,MOTHERNAME,FATHERNAME,BirrhDate111,NewField1111122121,PATIENTADDRESS,BirrhDate1111,PATIENTPHONE,NewField11112222,NewField112221111};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string eaObjectID = ((ExternalProcedureRequestReportByEpisodeAction)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            
            EpisodeAction ea = (EpisodeAction)context.GetObject(new Guid(eaObjectID),"EpisodeAction");
            Patient patient = ea.Episode.Patient;
            if(patient.CityOfBirth == null && patient.TownOfBirth == null && patient.CountryOfBirth != null)
                this.BIRTHPLACE.CalcValue = patient.CountryOfBirth.ToString();
            if(patient.BirthDate.HasValue)
                this.BIRTHDATE.CalcValue = patient.BirthDate.Value.ToShortDateString();
                
            string diagnosisStr = "";
            foreach(DiagnosisGrid dig in ea.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    diagnosisStr = diagnosisStr + dig.Diagnose.Code.ToString() + " " + dig.Diagnose.Name.ToString() + ", ";
                }
            }
            this.ICDCode.CalcValue = diagnosisStr;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PROCGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public PROCGroupHeader Header()
            {
                return (PROCGroupHeader)_header;
            }

            new public PROCGroupFooter Footer()
            {
                return (PROCGroupFooter)_footer;
            }

            public TTReportField TESTNAME { get {return Header().TESTNAME;} }
            public TTReportField PROCEDUREID { get {return Header().PROCEDUREID;} }
            public TTReportField REQUESTEDBYUSER { get {return Header().REQUESTEDBYUSER;} }
            public PROCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class>("DisTetkikIstemRaporTestsNQL2", SubActionProcedure.DisTetkikIstemRaporTestsNQL2((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PROCGroupHeader(this);
                _footer = new PROCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PROCGroupHeader : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField TESTNAME;
                public TTReportField PROCEDUREID;
                public TTReportField REQUESTEDBYUSER; 
                public PROCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TESTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 178, 7, false);
                    TESTNAME.Name = "TESTNAME";
                    TESTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESTNAME.TextFont.Size = 9;
                    TESTNAME.TextFont.CharSet = 162;
                    TESTNAME.Value = @"{#PCODE#} {#PNAME#}";

                    PROCEDUREID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 1, 264, 6, false);
                    PROCEDUREID.Name = "PROCEDUREID";
                    PROCEDUREID.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREID.Value = @"{#OBJECTID#}";

                    REQUESTEDBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    REQUESTEDBYUSER.Name = "REQUESTEDBYUSER";
                    REQUESTEDBYUSER.Visible = EvetHayirEnum.ehHayir;
                    REQUESTEDBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDBYUSER.Value = @"{#REQUESTEDUSER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class dataset_DisTetkikIstemRaporTestsNQL2 = ParentGroup.rsGroup.GetCurrentRecord<SubActionProcedure.DisTetkikIstemRaporTestsNQL2_Class>(0);
                    TESTNAME.CalcValue = (dataset_DisTetkikIstemRaporTestsNQL2 != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporTestsNQL2.Pcode) : "") + @" " + (dataset_DisTetkikIstemRaporTestsNQL2 != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporTestsNQL2.Pname) : "");
                    PROCEDUREID.CalcValue = (dataset_DisTetkikIstemRaporTestsNQL2 != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporTestsNQL2.ObjectID) : "");
                    REQUESTEDBYUSER.CalcValue = (dataset_DisTetkikIstemRaporTestsNQL2 != null ? Globals.ToStringCore(dataset_DisTetkikIstemRaporTestsNQL2.Requesteduser) : "");
                    return new TTReportObject[] { TESTNAME,PROCEDUREID,REQUESTEDBYUSER};
                }

                public override void RunScript()
                {
#region PROC HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
           
            ResUser reqUser = (ResUser)context.GetObject(new Guid(this.REQUESTEDBYUSER.CalcValue),"ResUser");
            if (reqUser != null )
                 MyParentReport.RequestedByUser  = reqUser.SignatureBlock;
#endregion PROC HEADER_Script
                }
            }
            public partial class PROCGroupFooter : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                 
                public PROCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PROCGroup PROC;

        public partial class TESTGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public TESTGroupBody Body()
            {
                return (TESTGroupBody)_body;
            }
            public TESTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TESTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TESTGroupBody(this);
            }

            public partial class TESTGroupBody : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                 
                public TESTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TESTGroup TEST;

        public partial class DESCHEADERGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public DESCHEADERGroupHeader Header()
            {
                return (DESCHEADERGroupHeader)_header;
            }

            new public DESCHEADERGroupFooter Footer()
            {
                return (DESCHEADERGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public DESCHEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DESCHEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new DESCHEADERGroupHeader(this);
                _footer = new DESCHEADERGroupFooter(this);

            }

            public partial class DESCHEADERGroupHeader : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField NewField111; 
                public DESCHEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 62, 6, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"AÇIKLAMA";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { NewField111};
                }
            }
            public partial class DESCHEADERGroupFooter : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                 
                public DESCHEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public DESCHEADERGroup DESCHEADER;

        public partial class DESCRIPTIONGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public DESCRIPTIONGroupBody Body()
            {
                return (DESCRIPTIONGroupBody)_body;
            }
            public TTReportField GENERALDESCRIPTION { get {return Body().GENERALDESCRIPTION;} }
            public DESCRIPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DESCRIPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestByObjectIDQuery_Class>("RadiologyTestByObjectIDQuery", RadiologyTest.RadiologyTestByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DESCRIPTIONGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DESCRIPTIONGroupBody : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField GENERALDESCRIPTION; 
                public DESCRIPTIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    GENERALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 178, 6, false);
                    GENERALDESCRIPTION.Name = "GENERALDESCRIPTION";
                    GENERALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    GENERALDESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    GENERALDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    GENERALDESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    GENERALDESCRIPTION.TextFont.Size = 9;
                    GENERALDESCRIPTION.TextFont.CharSet = 162;
                    GENERALDESCRIPTION.Value = @"{#GENERALDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestByObjectIDQuery_Class dataset_RadiologyTestByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestByObjectIDQuery_Class>(0);
                    GENERALDESCRIPTION.CalcValue = (dataset_RadiologyTestByObjectIDQuery != null ? Globals.ToStringCore(dataset_RadiologyTestByObjectIDQuery.GeneralDescription) : "");
                    return new TTReportObject[] { GENERALDESCRIPTION};
                }
            }

        }

        public DESCRIPTIONGroup DESCRIPTION;

        public partial class PATHOLOGYDESCGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public PATHOLOGYDESCGroupBody Body()
            {
                return (PATHOLOGYDESCGroupBody)_body;
            }
            public TTReportField PATHOLOGYDESC { get {return Body().PATHOLOGYDESC;} }
            public PATHOLOGYDESCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATHOLOGYDESCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class>("PathologyTestProcedureByObjectIDQuery", PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PATHOLOGYDESCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PATHOLOGYDESCGroupBody : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField PATHOLOGYDESC; 
                public PATHOLOGYDESCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    PATHOLOGYDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 178, 6, false);
                    PATHOLOGYDESC.Name = "PATHOLOGYDESC";
                    PATHOLOGYDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATHOLOGYDESC.MultiLine = EvetHayirEnum.ehEvet;
                    PATHOLOGYDESC.NoClip = EvetHayirEnum.ehEvet;
                    PATHOLOGYDESC.WordBreak = EvetHayirEnum.ehEvet;
                    PATHOLOGYDESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATHOLOGYDESC.TextFont.Size = 9;
                    PATHOLOGYDESC.TextFont.CharSet = 162;
                    PATHOLOGYDESC.Value = @"{#DESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class dataset_PathologyTestProcedureByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<PathologyTestProcedure.PathologyTestProcedureByObjectIDQuery_Class>(0);
                    PATHOLOGYDESC.CalcValue = (dataset_PathologyTestProcedureByObjectIDQuery != null ? Globals.ToStringCore(dataset_PathologyTestProcedureByObjectIDQuery.Description) : "");
                    return new TTReportObject[] { PATHOLOGYDESC};
                }
            }

        }

        public PATHOLOGYDESCGroup PATHOLOGYDESC;

        public partial class APPROVALGroup : TTReportGroup
        {
            public ExternalProcedureRequestReportByEpisodeAction MyParentReport
            {
                get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
            }

            new public APPROVALGroupBody Body()
            {
                return (APPROVALGroupBody)_body;
            }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField PROCEDUREDOCTORSIGNATURE { get {return Body().PROCEDUREDOCTORSIGNATURE;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportShape NewRect11 { get {return Body().NewRect11;} }
            public TTReportShape NewRect12 { get {return Body().NewRect12;} }
            public APPROVALGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public APPROVALGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>("DisTetkikIstemRaporByEpisodeActionNQL", EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new APPROVALGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class APPROVALGroupBody : TTReportSection
            {
                public ExternalProcedureRequestReportByEpisodeAction MyParentReport
                {
                    get { return (ExternalProcedureRequestReportByEpisodeAction)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField PROCEDUREDOCTORSIGNATURE;
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportShape NewRect1;
                public TTReportShape NewRect11;
                public TTReportShape NewRect12; 
                public APPROVALGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 53;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 15, 202, 20, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.Underline = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"İSTEK YAPAN TABİP
";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 20, 202, 25, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"ONAY
";

                    PROCEDUREDOCTORSIGNATURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 25, 202, 51, false);
                    PROCEDUREDOCTORSIGNATURE.Name = "PROCEDUREDOCTORSIGNATURE";
                    PROCEDUREDOCTORSIGNATURE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCEDUREDOCTORSIGNATURE.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREDOCTORSIGNATURE.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDUREDOCTORSIGNATURE.TextFont.Size = 9;
                    PROCEDUREDOCTORSIGNATURE.TextFont.CharSet = 162;
                    PROCEDUREDOCTORSIGNATURE.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 61, 9, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SEVK NEDENİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 101, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"Cihazın Bulunmaması (Acil şartı aranmayacaktır)";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 101, 21, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Cihazın Arızalı Olması";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 22, 101, 27, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"Hasta Yoğunluğu";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 28, 135, 44, false);
                    NewField131.Name = "NewField131";
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.Value = @"nedeniyle ilgili tetkik XXXXXXmizde yapılmamaktadır. Tetkik ve tahlillerin sonucuna göre bu tetkikin acilen yapılması tıbben zorunlu olduğundan; dışarıya sevki uygundur.";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 7, 10, 10, 14, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 7, 16, 10, 20, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 7, 22, 10, 26, false);
                    NewRect12.Name = "NewRect12";
                    NewRect12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class dataset_DisTetkikIstemRaporByEpisodeActionNQL = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>(0);
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    PROCEDUREDOCTORSIGNATURE.CalcValue = PROCEDUREDOCTORSIGNATURE.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { NewField1121,NewField11211,PROCEDUREDOCTORSIGNATURE,NewField11,NewField1,NewField12,NewField13,NewField131};
                }

                public override void RunScript()
                {
#region APPROVAL BODY_Script
                    /*            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ExternalProcedureRequestReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ExternalProcedureRequest eprObject = (ExternalProcedureRequest)context.GetObject(new Guid(sObjectID),"ExternalProcedureRequest");
            if(eprObject.ProcedureDoctor != null)
                this.PROCEDUREDOCTORSIGNATURE.CalcValue = eprObject.ProcedureDoctor.SignatureBlock;
                */
            
           /*                                                                                     
            TTObjectContext context = new TTObjectContext(true);
            string eaObjectID = ((ExternalProcedureRequestReportByEpisodeAction)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction ea = (EpisodeAction)context.GetObject(new Guid(eaObjectID),"EpisodeAction");
            if (ea.ProcedureByUser != null )
                this.PROCEDUREDOCTORSIGNATURE.CalcValue = ea.ProcedureByUser.SignatureBlock;
                */
               
             this.PROCEDUREDOCTORSIGNATURE.CalcValue = MyParentReport.RequestedByUser;
#endregion APPROVAL BODY_Script
                }
            }

        }

        public APPROVALGroup APPROVAL;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ExternalProcedureRequestReportByEpisodeAction()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            PROC = new PROCGroup(HEADER,"PROC");
            TEST = new TESTGroup(PROC,"TEST");
            DESCHEADER = new DESCHEADERGroup(HEADER,"DESCHEADER");
            DESCRIPTION = new DESCRIPTIONGroup(DESCHEADER,"DESCRIPTION");
            PATHOLOGYDESC = new PATHOLOGYDESCGroup(DESCHEADER,"PATHOLOGYDESC");
            APPROVAL = new APPROVALGroup(HEADER,"APPROVAL");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "EXTERNALPROCEDUREREQUESTREPORTBYEPISODEACTION";
            Caption = "Dış Hizmet İstemi";
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