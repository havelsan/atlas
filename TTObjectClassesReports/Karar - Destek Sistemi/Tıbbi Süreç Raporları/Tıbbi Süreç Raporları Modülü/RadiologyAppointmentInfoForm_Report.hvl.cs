
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
    /// Radyoloji Randevu Bilgi Formu
    /// </summary>
    public partial class RadiologyAppointmentInfoForm : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public RadiologyAppointmentInfoForm MyParentReport
            {
                get { return (RadiologyAppointmentInfoForm)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField REPORTHEADER11 { get {return Header().REPORTHEADER11;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField DOCTORNAME { get {return Footer().DOCTORNAME;} }
            public TTReportField NewField11311 { get {return Footer().NewField11311;} }
            public TTReportField GIVENBY { get {return Footer().GIVENBY;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
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
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>("RadiologyTestAppointmentInfoQuery", RadiologyTest.RadiologyTestAppointmentInfoQuery((string)TTObjectDefManager.Instance.DataTypes["String250"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public RadiologyAppointmentInfoForm MyParentReport
                {
                    get { return (RadiologyAppointmentInfoForm)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField REPORTHEADER11;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 8, 194, 41, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 41, 194, 49, false);
                    REPORTHEADER11.Name = "REPORTHEADER11";
                    REPORTHEADER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER11.TextFont.Size = 15;
                    REPORTHEADER11.TextFont.Bold = true;
                    REPORTHEADER11.TextFont.CharSet = 162;
                    REPORTHEADER11.Value = @"RADYOLOJİ RANDEVU BİLGİLENDİRME FORMU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 10, 51, 33, false);
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
                    RadiologyTest.RadiologyTestAppointmentInfoQuery_Class dataset_RadiologyTestAppointmentInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>(0);
                    REPORTHEADER11.CalcValue = REPORTHEADER11.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { REPORTHEADER11,LOGO,XXXXXXBASLIK1};
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
                public RadiologyAppointmentInfoForm MyParentReport
                {
                    get { return (RadiologyAppointmentInfoForm)ParentReport; }
                }
                
                public TTReportField NewField1131;
                public TTReportField DOCTORNAME;
                public TTReportField NewField11311;
                public TTReportField GIVENBY;
                public TTReportShape NewLine111;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 44;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 10, 178, 15, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"İstek Yapan Tabip";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 18, 212, 23, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCTORNAME.TextFont.Size = 9;
                    DOCTORNAME.TextFont.CharSet = 162;
                    DOCTORNAME.Value = @"{#HEADER.REQUESTDOCTOR#}";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 10, 51, 15, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Randevuyu Veren";

                    GIVENBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 18, 85, 23, false);
                    GIVENBY.Name = "GIVENBY";
                    GIVENBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIVENBY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GIVENBY.TextFont.Size = 9;
                    GIVENBY.TextFont.CharSet = 162;
                    GIVENBY.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 30, 204, 30, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 31, 38, 36, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 31, 126, 36, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 31, 204, 36, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestAppointmentInfoQuery_Class dataset_RadiologyTestAppointmentInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>(0);
                    NewField1131.CalcValue = NewField1131.Value;
                    DOCTORNAME.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Requestdoctor) : "");
                    NewField11311.CalcValue = NewField11311.Value;
                    GIVENBY.CalcValue = @"";
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { NewField1131,DOCTORNAME,NewField11311,GIVENBY,PrintDate,PageNumber,UserName};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);              
            string sObjectID = ((RadiologyAppointmentInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest pObject = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            
            if(pObject.CurrentStateDefID == RadiologyTest.States.Appointment)
            {
               SubActionProcedure sp = (SubActionProcedure)pObject;
               if (sp.GetMyNewAppointments() != null)
               {
                   if (sp.GetMyNewAppointments().Count > 0)
                   {
                       if (sp.GetMyNewAppointments()[0].GivenBy != null)
                       {
                            ResUser givenByUser = (ResUser)context.GetObject(sp.GetMyNewAppointments()[0].GivenBy.ObjectID, "ResUser");
                            this.GIVENBY.CalcValue = givenByUser.Name;
                           
                       } 
                   }
               }
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public RadiologyAppointmentInfoForm MyParentReport
            {
                get { return (RadiologyAppointmentInfoForm)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField1761 { get {return Body().NewField1761;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField142 { get {return Body().NewField142;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportField DYERTAR { get {return Body().DYERTAR;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField NewField1421 { get {return Body().NewField1421;} }
            public TTReportField DTARIH { get {return Body().DTARIH;} }
            public TTReportField DYER { get {return Body().DYER;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportField ICDCode { get {return Body().ICDCode;} }
            public TTReportField NewField1216111 { get {return Body().NewField1216111;} }
            public TTReportField NewField121121111 { get {return Body().NewField121121111;} }
            public TTReportField AnamnezVeBulgular { get {return Body().AnamnezVeBulgular;} }
            public TTReportField NewField11116121 { get {return Body().NewField11116121;} }
            public TTReportField NewField1111121121 { get {return Body().NewField1111121121;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField NewField1112321 { get {return Body().NewField1112321;} }
            public TTReportField NewField11142111 { get {return Body().NewField11142111;} }
            public TTReportField ACCESSIONNO { get {return Body().ACCESSIONNO;} }
            public TTReportField NewField1361 { get {return Body().NewField1361;} }
            public TTReportField NewField11222 { get {return Body().NewField11222;} }
            public TTReportField Barcode { get {return Body().Barcode;} }
            public TTReportField ACTIONID1 { get {return Body().ACTIONID1;} }
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
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>("RadiologyTestAppointmentInfoQuery", RadiologyTest.RadiologyTestAppointmentInfoQuery((string)TTObjectDefManager.Instance.DataTypes["String250"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public RadiologyAppointmentInfoForm MyParentReport
                {
                    get { return (RadiologyAppointmentInfoForm)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField REQUESTDATE;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NAME;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField162;
                public TTReportField NewField1761;
                public TTReportField NewField123;
                public TTReportField HASTANO;
                public TTReportField NewField142;
                public TTReportField ACTIONID;
                public TTReportField NewField163;
                public TTReportField DYERTAR;
                public TTReportField NewField16;
                public TTReportField NewField111;
                public TTReportField NewField1221;
                public TTReportField NewField1321;
                public TTReportField NewField1421;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField NewField11221;
                public TTReportField ICDCode;
                public TTReportField NewField1216111;
                public TTReportField NewField121121111;
                public TTReportField AnamnezVeBulgular;
                public TTReportField NewField11116121;
                public TTReportField NewField1111121121;
                public TTReportField UNIQUEREFNO;
                public TTReportField NewField1112321;
                public TTReportField NewField11142111;
                public TTReportField ACCESSIONNO;
                public TTReportField NewField1361;
                public TTReportField NewField11222;
                public TTReportField Barcode;
                public TTReportField ACTIONID1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 66;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 24, 51, 29, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İstek Tarihi";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 24, 126, 29, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#ACTDATE#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 37, 243, 42, false);
                    NewField14.Name = "NewField14";
                    NewField14.Visible = EvetHayirEnum.ehHayir;
                    NewField14.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField14.Value = @"{@TTOBJECTID@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 4, 51, 9, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Hastanın";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 14, 126, 19, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "RadiologyTest";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{@TTOBJECTID@}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 21, 207, 26, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 51, 19, false);
                    NewField162.Name = "NewField162";
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.TextFont.Size = 9;
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"Adı Soyadı";

                    NewField1761 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 19, 51, 24, false);
                    NewField1761.Name = "NewField1761";
                    NewField1761.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1761.TextFont.Size = 9;
                    NewField1761.TextFont.Bold = true;
                    NewField1761.TextFont.CharSet = 162;
                    NewField1761.Value = @"Doğum Tarihi ve Yeri";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 21, 168, 26, false);
                    NewField123.Name = "NewField123";
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Size = 9;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 26, 207, 31, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "RadiologyTest";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 26, 168, 31, false);
                    NewField142.Name = "NewField142";
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Size = 9;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Hasta No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 31, 207, 36, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 31, 168, 36, false);
                    NewField163.Name = "NewField163";
                    NewField163.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField163.TextFont.Size = 9;
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"İşlem No";

                    DYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 19, 126, 24, false);
                    DYERTAR.Name = "DYERTAR";
                    DYERTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DYERTAR.TextFont.Size = 9;
                    DYERTAR.TextFont.CharSet = 162;
                    DYERTAR.Value = @"{%DTARIH%} {%DYER%}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 14, 53, 19, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 19, 53, 24, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 31, 170, 36, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 26, 170, 31, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @":";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 21, 170, 26, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1421.TextFont.Size = 9;
                    NewField1421.TextFont.Bold = true;
                    NewField1421.TextFont.CharSet = 162;
                    NewField1421.Value = @":";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 11, 254, 16, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"dd/MM/yyyy";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.TextFont.CharSet = 162;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 16, 254, 21, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Size = 9;
                    DYER.TextFont.CharSet = 162;
                    DYER.Value = @"{#CITYNAME#}";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 24, 53, 29, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    ICDCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 29, 126, 45, false);
                    ICDCode.Name = "ICDCode";
                    ICDCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICDCode.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICDCode.TextFont.Size = 9;
                    ICDCode.TextFont.CharSet = 162;
                    ICDCode.Value = @"";

                    NewField1216111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 29, 51, 34, false);
                    NewField1216111.Name = "NewField1216111";
                    NewField1216111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1216111.TextFont.Size = 9;
                    NewField1216111.TextFont.Bold = true;
                    NewField1216111.TextFont.CharSet = 162;
                    NewField1216111.Value = @"ICD Tanı Kodu                      ";

                    NewField121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 29, 53, 34, false);
                    NewField121121111.Name = "NewField121121111";
                    NewField121121111.TextFont.Name = "Arial";
                    NewField121121111.TextFont.Size = 9;
                    NewField121121111.TextFont.Bold = true;
                    NewField121121111.TextFont.CharSet = 162;
                    NewField121121111.Value = @":";

                    AnamnezVeBulgular = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 46, 207, 65, false);
                    AnamnezVeBulgular.Name = "AnamnezVeBulgular";
                    AnamnezVeBulgular.FieldType = ReportFieldTypeEnum.ftVariable;
                    AnamnezVeBulgular.MultiLine = EvetHayirEnum.ehEvet;
                    AnamnezVeBulgular.NoClip = EvetHayirEnum.ehEvet;
                    AnamnezVeBulgular.WordBreak = EvetHayirEnum.ehEvet;
                    AnamnezVeBulgular.ExpandTabs = EvetHayirEnum.ehEvet;
                    AnamnezVeBulgular.TextFont.Size = 9;
                    AnamnezVeBulgular.TextFont.CharSet = 162;
                    AnamnezVeBulgular.Value = @"";

                    NewField11116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 46, 51, 51, false);
                    NewField11116121.Name = "NewField11116121";
                    NewField11116121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11116121.TextFont.Size = 9;
                    NewField11116121.TextFont.Bold = true;
                    NewField11116121.TextFont.CharSet = 162;
                    NewField11116121.Value = @"Anamnez ve Bulgular";

                    NewField1111121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 46, 53, 51, false);
                    NewField1111121121.Name = "NewField1111121121";
                    NewField1111121121.TextFont.Name = "Arial";
                    NewField1111121121.TextFont.Size = 9;
                    NewField1111121121.TextFont.Bold = true;
                    NewField1111121121.TextFont.CharSet = 162;
                    NewField1111121121.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 9, 90, 14, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.ObjectDefName = "RadiologyTest";
                    UNIQUEREFNO.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{@TTOBJECTID@}";

                    NewField1112321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 9, 51, 14, false);
                    NewField1112321.Name = "NewField1112321";
                    NewField1112321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112321.TextFont.Size = 9;
                    NewField1112321.TextFont.Bold = true;
                    NewField1112321.TextFont.CharSet = 162;
                    NewField1112321.Value = @"TC Kimlik No";

                    NewField11142111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 9, 53, 14, false);
                    NewField11142111.Name = "NewField11142111";
                    NewField11142111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11142111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11142111.TextFont.Size = 9;
                    NewField11142111.TextFont.Bold = true;
                    NewField11142111.TextFont.CharSet = 162;
                    NewField11142111.Value = @":";

                    ACCESSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 36, 207, 41, false);
                    ACCESSIONNO.Name = "ACCESSIONNO";
                    ACCESSIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCESSIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCESSIONNO.ObjectDefName = "RadiologyTest";
                    ACCESSIONNO.DataMember = "ACCESSIONNO";
                    ACCESSIONNO.TextFont.Size = 9;
                    ACCESSIONNO.TextFont.CharSet = 162;
                    ACCESSIONNO.Value = @"{@TTOBJECTID@}";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 36, 168, 41, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.TextFont.Size = 9;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"Kabul No";

                    NewField11222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 36, 170, 41, false);
                    NewField11222.Name = "NewField11222";
                    NewField11222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11222.TextFont.Size = 9;
                    NewField11222.TextFont.Bold = true;
                    NewField11222.TextFont.CharSet = 162;
                    NewField11222.Value = @":";

                    Barcode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 207, 16, false);
                    Barcode.Name = "Barcode";
                    Barcode.FieldType = ReportFieldTypeEnum.ftVariable;
                    Barcode.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Barcode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Barcode.TextFont.Name = "Code39QuarterInchTT-Regular";
                    Barcode.TextFont.Size = 34;
                    Barcode.TextFont.CharSet = 0;
                    Barcode.Value = @"{#ACTIONID#}";

                    ACTIONID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 16, 207, 20, false);
                    ACTIONID1.Name = "ACTIONID1";
                    ACTIONID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIONID1.TextFont.Size = 6;
                    ACTIONID1.TextFont.CharSet = 162;
                    ACTIONID1.Value = @"{#ACTIONID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestAppointmentInfoQuery_Class dataset_RadiologyTestAppointmentInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    REQUESTDATE.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Actdate) : "");
                    NewField14.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NewField15.CalcValue = NewField15.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    PROTOKOLNO.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Protocolno) : "");
                    NewField162.CalcValue = NewField162.Value;
                    NewField1761.CalcValue = NewField1761.Value;
                    NewField123.CalcValue = NewField123.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField142.CalcValue = NewField142.Value;
                    ACTIONID.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Actionid) : "");
                    NewField163.CalcValue = NewField163.Value;
                    DTARIH.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.BirthDate) : "");
                    DYER.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Cityname) : "");
                    DYERTAR.CalcValue = MyParentReport.MAIN.DTARIH.FormattedValue + @" " + MyParentReport.MAIN.DYER.CalcValue;
                    NewField16.CalcValue = NewField16.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    ICDCode.CalcValue = @"";
                    NewField1216111.CalcValue = NewField1216111.Value;
                    NewField121121111.CalcValue = NewField121121111.Value;
                    AnamnezVeBulgular.CalcValue = @"";
                    NewField11116121.CalcValue = NewField11116121.Value;
                    NewField1111121121.CalcValue = NewField1111121121.Value;
                    UNIQUEREFNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UNIQUEREFNO.PostFieldValueCalculation();
                    NewField1112321.CalcValue = NewField1112321.Value;
                    NewField11142111.CalcValue = NewField11142111.Value;
                    ACCESSIONNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ACCESSIONNO.PostFieldValueCalculation();
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField11222.CalcValue = NewField11222.Value;
                    Barcode.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Actionid) : "");
                    ACTIONID1.CalcValue = (dataset_RadiologyTestAppointmentInfoQuery != null ? Globals.ToStringCore(dataset_RadiologyTestAppointmentInfoQuery.Actionid) : "");
                    return new TTReportObject[] { NewField12,REQUESTDATE,NewField14,NewField15,NAME,PROTOKOLNO,NewField162,NewField1761,NewField123,HASTANO,NewField142,ACTIONID,NewField163,DTARIH,DYER,DYERTAR,NewField16,NewField111,NewField1221,NewField1321,NewField1421,NewField11221,ICDCode,NewField1216111,NewField121121111,AnamnezVeBulgular,NewField11116121,NewField1111121121,UNIQUEREFNO,NewField1112321,NewField11142111,ACCESSIONNO,NewField1361,NewField11222,Barcode,ACTIONID1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyAppointmentInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest pObject = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
                       
            string diagnosisStr = "";
            foreach(DiagnosisGrid dig in pObject.EpisodeAction.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    diagnosisStr = diagnosisStr + dig.Diagnose.Code.ToString() + " " + dig.Diagnose.Name.ToString() + ", ";
                }
            }
            this.ICDCode.CalcValue = diagnosisStr;   
            if (pObject.PreDiagnosis != null)
                this.AnamnezVeBulgular.CalcValue = TTReportTool.TTReport.HTMLtoText(pObject.PreDiagnosis.ToString());
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class RANDEVUGroup : TTReportGroup
        {
            public RadiologyAppointmentInfoForm MyParentReport
            {
                get { return (RadiologyAppointmentInfoForm)ParentReport; }
            }

            new public RANDEVUGroupBody Body()
            {
                return (RANDEVUGroupBody)_body;
            }
            public TTReportField Test { get {return Body().Test;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField1111121111 { get {return Body().NewField1111121111;} }
            public TTReportField NewField1116111 { get {return Body().NewField1116111;} }
            public TTReportField AppointmentInfo { get {return Body().AppointmentInfo;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField APPOINTMENTDATE { get {return Body().APPOINTMENTDATE;} }
            public TTReportField NewField1111121112 { get {return Body().NewField1111121112;} }
            public RANDEVUGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RANDEVUGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RANDEVUGroupBody(this);
            }

            public partial class RANDEVUGroupBody : TTReportSection
            {
                public RadiologyAppointmentInfoForm MyParentReport
                {
                    get { return (RadiologyAppointmentInfoForm)ParentReport; }
                }
                
                public TTReportField Test;
                public TTReportField NewField11116111;
                public TTReportField NewField1111121111;
                public TTReportField NewField1116111;
                public TTReportField AppointmentInfo;
                public TTReportField NewField121;
                public TTReportField APPOINTMENTDATE;
                public TTReportField NewField1111121112; 
                public RANDEVUGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 52;
                    RepeatCount = 0;
                    
                    Test = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 44, 206, 49, false);
                    Test.Name = "Test";
                    Test.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Test.ExpandTabs = EvetHayirEnum.ehEvet;
                    Test.TextFont.Size = 9;
                    Test.TextFont.CharSet = 162;
                    Test.Value = @"";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 51, 6, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11116111.TextFont.Size = 9;
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"Randevu Bilgileri                                       ";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 1, 53, 6, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.TextFont.Name = "Arial";
                    NewField1111121111.TextFont.Size = 9;
                    NewField1111121111.TextFont.Bold = true;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @":";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 37, 51, 42, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116111.TextFont.Size = 9;
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"İstenen Tetkikler                      ";

                    AppointmentInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 1, 207, 28, false);
                    AppointmentInfo.Name = "AppointmentInfo";
                    AppointmentInfo.MultiLine = EvetHayirEnum.ehEvet;
                    AppointmentInfo.NoClip = EvetHayirEnum.ehEvet;
                    AppointmentInfo.WordBreak = EvetHayirEnum.ehEvet;
                    AppointmentInfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    AppointmentInfo.TextFont.Size = 9;
                    AppointmentInfo.TextFont.CharSet = 162;
                    AppointmentInfo.Value = @"AppointmentInfo";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 32, 51, 37, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Randevu Tarihi";

                    APPOINTMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 31, 126, 36, false);
                    APPOINTMENTDATE.Name = "APPOINTMENTDATE";
                    APPOINTMENTDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    APPOINTMENTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    APPOINTMENTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    APPOINTMENTDATE.TextFont.Size = 9;
                    APPOINTMENTDATE.TextFont.CharSet = 162;
                    APPOINTMENTDATE.Value = @"";

                    NewField1111121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 32, 53, 37, false);
                    NewField1111121112.Name = "NewField1111121112";
                    NewField1111121112.TextFont.Name = "Arial";
                    NewField1111121112.TextFont.Size = 9;
                    NewField1111121112.TextFont.Bold = true;
                    NewField1111121112.TextFont.CharSet = 162;
                    NewField1111121112.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Test.CalcValue = Test.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField1116111.CalcValue = NewField1116111.Value;
                    AppointmentInfo.CalcValue = AppointmentInfo.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1111121112.CalcValue = NewField1111121112.Value;
                    APPOINTMENTDATE.CalcValue = @"";
                    return new TTReportObject[] { Test,NewField11116111,NewField1111121111,NewField1116111,AppointmentInfo,NewField121,NewField1111121112,APPOINTMENTDATE};
                }
                public override void RunPreScript()
                {
#region RANDEVU BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyAppointmentInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest radTest = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            this.Test.Value = radTest.ProcedureObject.Name;
#endregion RANDEVU BODY_PreScript
                }

                public override void RunScript()
                {
#region RANDEVU BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyAppointmentInfoForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            RadiologyTest pObject = (RadiologyTest)context.GetObject(new Guid(sObjectID),"RadiologyTest");
            
            if(pObject.CurrentStateDefID == RadiologyTest.States.Appointment)
            {
               this.AppointmentInfo.CalcValue = SubActionProcedure.GetFullAppointmentDescription(pObject);
               SubActionProcedure sp = (SubActionProcedure)pObject;
               if (sp.GetMyNewAppointments() != null)
               {
                   if (sp.GetMyNewAppointments().Count > 0)
                   {
                       if (sp.GetMyNewAppointments()[0].StartTime != null)
                       {
                            DateTime appDate = sp.GetMyNewAppointments()[0].StartTime.Value;
                            this.APPOINTMENTDATE.CalcValue = appDate.ToString();
                       }
                   }
               }
            }
            else if(pObject.CurrentStateDefID == RadiologyTest.States.AdmissionAppointment)
            {
                string injectionStr = "WHERE INITIALOBJECTID = '" + pObject.ObjectID + "'";
                IList appList = Appointment.GetByInjection(context, injectionStr);
                if(appList.Count > 0)
                {
                    this.AppointmentInfo.CalcValue = BaseAction.GetFullAppointmentDescription(((TTObjectClasses.Appointment)appList[0]).Action);
                }
            }
#endregion RANDEVU BODY_Script
                }
            }

        }

        public RANDEVUGroup RANDEVU;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public RadiologyAppointmentInfoForm()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            RANDEVU = new RANDEVUGroup(HEADER,"RANDEVU");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RADIOLOGYAPPOINTMENTINFOFORM";
            Caption = "Radyoloji Randevu Bilgi Formu";
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