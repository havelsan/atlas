
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
    /// Radyoloji Tetkik Açıklama Raporu
    /// </summary>
    public partial class RadiologyRequestDescription : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public RadiologyRequestDescription MyParentReport
            {
                get { return (RadiologyRequestDescription)ParentReport; }
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
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField HizmetOzel11 { get {return Footer().HizmetOzel11;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField PrintDate11 { get {return Footer().PrintDate11;} }
            public TTReportField UserName11 { get {return Footer().UserName11;} }
            public TTReportField PageNumber11 { get {return Footer().PageNumber11;} }
            public TTReportField WARNING1 { get {return Footer().WARNING1;} }
            public TTReportField NewField111 { get {return Footer().NewField111;} }
            public TTReportField ContactAddress { get {return Footer().ContactAddress;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField ContactPhone { get {return Footer().ContactPhone;} }
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
                public RadiologyRequestDescription MyParentReport
                {
                    get { return (RadiologyRequestDescription)ParentReport; }
                }
                
                public TTReportField NewField1112121;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField1161;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 27, 171, 34, false);
                    NewField1112121.Name = "NewField1112121";
                    NewField1112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112121.TextFont.Size = 14;
                    NewField1112121.TextFont.Bold = true;
                    NewField1112121.TextFont.CharSet = 162;
                    NewField1112121.Value = @"RADYOLOJİ TETKİK AÇIKLAMA RAPORU";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 4, 191, 27, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 32, 45, 38, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 11;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.Underline = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 6, 46, 29, false);
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
                    NewField1112121.CalcValue = NewField1112121.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1112121,NewField1161,LOGO,XXXXXXBASLIK1};
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
                public RadiologyRequestDescription MyParentReport
                {
                    get { return (RadiologyRequestDescription)ParentReport; }
                }
                
                public TTReportField HizmetOzel11;
                public TTReportShape NewLine11;
                public TTReportField PrintDate11;
                public TTReportField UserName11;
                public TTReportField PageNumber11;
                public TTReportField WARNING1;
                public TTReportField NewField111;
                public TTReportField ContactAddress;
                public TTReportField NewField1111;
                public TTReportField ContactPhone; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
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

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 22, 203, 22, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 23, 37, 28, false);
                    PrintDate11.Name = "PrintDate11";
                    PrintDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate11.TextFont.Size = 8;
                    PrintDate11.TextFont.CharSet = 162;
                    PrintDate11.Value = @"{@printdatetime@}";

                    UserName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 23, 125, 28, false);
                    UserName11.Name = "UserName11";
                    UserName11.TextFont.Size = 8;
                    UserName11.TextFont.CharSet = 162;
                    UserName11.Value = @"UserName";

                    PageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 23, 203, 28, false);
                    PageNumber11.Name = "PageNumber11";
                    PageNumber11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11.TextFont.Size = 8;
                    PageNumber11.TextFont.CharSet = 162;
                    PageNumber11.Value = @"{@pagenumber@}/{@pagecount@}";

                    WARNING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 15, 203, 20, false);
                    WARNING1.Name = "WARNING1";
                    WARNING1.TextFont.Bold = true;
                    WARNING1.TextFont.CharSet = 162;
                    WARNING1.Value = @"Cihaz arızası gibi olağan dışı durumlarda verilen randevu saatinde gecikmeler olabilir.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 36, 7, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İrtibat Adresi :";

                    ContactAddress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 138, 14, false);
                    ContactAddress.Name = "ContactAddress";
                    ContactAddress.MultiLine = EvetHayirEnum.ehEvet;
                    ContactAddress.WordBreak = EvetHayirEnum.ehEvet;
                    ContactAddress.ExpandTabs = EvetHayirEnum.ehEvet;
                    ContactAddress.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 2, 168, 7, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.Underline = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İrtibat Telefonu :";

                    ContactPhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 2, 203, 7, false);
                    ContactPhone.Name = "ContactPhone";
                    ContactPhone.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel11.CalcValue = HizmetOzel11.Value;
                    PrintDate11.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    UserName11.CalcValue = UserName11.Value;
                    PageNumber11.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    WARNING1.CalcValue = WARNING1.Value;
                    NewField111.CalcValue = NewField111.Value;
                    ContactAddress.CalcValue = ContactAddress.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    ContactPhone.CalcValue = ContactPhone.Value;
                    return new TTReportObject[] { HizmetOzel11,PrintDate11,UserName11,PageNumber11,WARNING1,NewField111,ContactAddress,NewField1111,ContactPhone};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyRequestDescription)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Radiology radiology = (Radiology)context.GetObject(new Guid(sObjectID),"Radiology");
            
            if(radiology.MasterResource != null)
            {
                if(!String.IsNullOrEmpty(radiology.MasterResource.ContactAddress))
                {
                    this.ContactAddress.CalcValue = radiology.MasterResource.ContactAddress.Trim();
                }
                if(!String.IsNullOrEmpty(radiology.MasterResource.ContactPhone))
                {
                    this.ContactPhone.CalcValue = radiology.MasterResource.ContactPhone.Trim();
                }
                
                
            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public RadiologyRequestDescription MyParentReport
            {
                get { return (RadiologyRequestDescription)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField NewField11411 { get {return Body().NewField11411;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField REQDOCTORNAME { get {return Body().REQDOCTORNAME;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField NewField121611 { get {return Body().NewField121611;} }
            public TTReportField PREDIAGNOSIS { get {return Body().PREDIAGNOSIS;} }
            public TTReportField NewField11116111 { get {return Body().NewField11116111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
            public TTReportField KABULSEBEBI { get {return Body().KABULSEBEBI;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField1271 { get {return Body().NewField1271;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField HASTANO { get {return Body().HASTANO;} }
            public TTReportField NewField1241 { get {return Body().NewField1241;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField NewField1361 { get {return Body().NewField1361;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField1122 { get {return Body().NewField1122;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportField NewField11231 { get {return Body().NewField11231;} }
            public TTReportField NewField11241 { get {return Body().NewField11241;} }
            public TTReportField NewField112211 { get {return Body().NewField112211;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField SEX { get {return Body().SEX;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportField NewField111221 { get {return Body().NewField111221;} }
            public TTReportField NewField1112211 { get {return Body().NewField1112211;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField NewField11232 { get {return Body().NewField11232;} }
            public TTReportField NewField114211 { get {return Body().NewField114211;} }
            public TTReportField BirrhDate { get {return Body().BirrhDate;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField NewField1122111 { get {return Body().NewField1122111;} }
            public TTReportField UniquerefNoBarcode { get {return Body().UniquerefNoBarcode;} }
            public TTReportField UniquerefNoBarcodeInfo { get {return Body().UniquerefNoBarcodeInfo;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
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
                list[0] = new TTReportNqlData<Radiology.RadiologyRequestPatientInfoReportQuery_Class>("RadiologyRequestPatientInfoReportQuery", Radiology.RadiologyRequestPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public RadiologyRequestDescription MyParentReport
                {
                    get { return (RadiologyRequestDescription)ParentReport; }
                }
                
                public TTReportField NewField11311;
                public TTReportField NewField11411;
                public TTReportField NewField11611;
                public TTReportField REQDOCTORNAME;
                public TTReportField FROMRESOURCE;
                public TTReportField NewField121611;
                public TTReportField PREDIAGNOSIS;
                public TTReportField NewField11116111;
                public TTReportField NewField11112111;
                public TTReportField NewField121;
                public TTReportField REQUESTDATE;
                public TTReportField NewField151;
                public TTReportField NAME;
                public TTReportField RUTBE;
                public TTReportField KABULSEBEBI;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField1261;
                public TTReportField NewField1271;
                public TTReportField NewField1181;
                public TTReportField NewField1321;
                public TTReportField HASTANO;
                public TTReportField NewField1241;
                public TTReportField ACTIONID;
                public TTReportField NewField1361;
                public TTReportField NewField161;
                public TTReportField NewField1122;
                public TTReportField NewField12211;
                public TTReportField NewField11221;
                public TTReportField NewField11231;
                public TTReportField NewField11241;
                public TTReportField NewField112211;
                public TTReportField NewField1161;
                public TTReportField SEX;
                public TTReportField AGE;
                public TTReportField NewField111221;
                public TTReportField NewField1112211;
                public TTReportField NewField111121111;
                public TTReportField UNIQUEREFNO;
                public TTReportField NewField11232;
                public TTReportField NewField114211;
                public TTReportField BirrhDate;
                public TTReportField BIRTHDATE;
                public TTReportField NewField1122111;
                public TTReportField UniquerefNoBarcode;
                public TTReportField UniquerefNoBarcodeInfo;
                public TTReportField NewField1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 94;
                    RepeatCount = 0;
                    
                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 43, 50, 48, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Doktor Adı";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 23, 50, 28, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Cinsiyet / Yaşı";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 43, 152, 48, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Çalışılacak Bölüm";

                    REQDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 43, 112, 48, false);
                    REQDOCTORNAME.Name = "REQDOCTORNAME";
                    REQDOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQDOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQDOCTORNAME.TextFont.Size = 9;
                    REQDOCTORNAME.TextFont.CharSet = 162;
                    REQDOCTORNAME.Value = @"{#REQUESTDOCTOR#}";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 43, 203, 48, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FROMRESOURCE.TextFont.Size = 9;
                    FROMRESOURCE.TextFont.CharSet = 162;
                    FROMRESOURCE.Value = @"{#FROMRES#}";

                    NewField121611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 51, 61, 56, false);
                    NewField121611.Name = "NewField121611";
                    NewField121611.TextFont.Size = 9;
                    NewField121611.TextFont.Bold = true;
                    NewField121611.TextFont.Underline = true;
                    NewField121611.TextFont.CharSet = 162;
                    NewField121611.Value = @"KLİNİK VE ANAMNEZ BULGULAR";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 58, 203, 85, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.Value = @"{#PREDIAGNOSIS#}";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 88, 60, 93, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.TextFont.Size = 9;
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.Underline = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"İSTENEN TETKİKLER";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 51, 63, 56, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Size = 9;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 38, 152, 43, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İstek Tarihi";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 38, 203, 43, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 50, 13, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Hastanın";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 18, 112, 23, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME.ObjectDefName = "Radiology";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Size = 9;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{@TTOBJECTID@}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 33, 112, 38, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RUTBE.TextFont.Size = 9;
                    RUTBE.TextFont.CharSet = 162;
                    RUTBE.Value = @"";

                    KABULSEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 38, 112, 43, false);
                    KABULSEBEBI.Name = "KABULSEBEBI";
                    KABULSEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KABULSEBEBI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KABULSEBEBI.TextFont.Size = 9;
                    KABULSEBEBI.TextFont.CharSet = 162;
                    KABULSEBEBI.Value = @"{#REASONFORADM#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 23, 203, 28, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 18, 50, 23, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @"Adı Soyadı";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 33, 50, 38, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.TextFont.CharSet = 162;
                    NewField1271.Value = @"Rütbesi";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 38, 50, 43, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"Kabul Sebebi";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 23, 152, 28, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 28, 203, 33, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "Radiology";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 28, 152, 33, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Hasta No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 33, 203, 38, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 33, 152, 38, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.TextFont.Size = 9;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"İşlem No";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 18, 52, 23, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 9;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 33, 52, 38, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.Size = 9;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @":";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 38, 52, 43, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.TextFont.Size = 9;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 33, 154, 38, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 28, 154, 33, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @":";

                    NewField11241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 23, 154, 28, false);
                    NewField11241.Name = "NewField11241";
                    NewField11241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11241.TextFont.Size = 9;
                    NewField11241.TextFont.Bold = true;
                    NewField11241.TextFont.CharSet = 162;
                    NewField11241.Value = @":";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 38, 154, 43, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 23, 52, 28, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 23, 72, 28, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SEX.ObjectDefName = "SexEnum";
                    SEX.DataMember = "DISPLAYTEXT";
                    SEX.TextFont.Name = "Arial";
                    SEX.TextFont.Size = 9;
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"{#SEX#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 23, 105, 28, false);
                    AGE.Name = "AGE";
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGE.Value = @"";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 43, 52, 48, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Size = 9;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @":";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 43, 154, 48, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112211.TextFont.Size = 9;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 88, 63, 93, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Size = 9;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 13, 101, 18, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIQUEREFNO.ObjectDefName = "Radiology";
                    UNIQUEREFNO.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{@TTOBJECTID@}";

                    NewField11232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 13, 50, 18, false);
                    NewField11232.Name = "NewField11232";
                    NewField11232.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11232.TextFont.Size = 9;
                    NewField11232.TextFont.Bold = true;
                    NewField11232.TextFont.CharSet = 162;
                    NewField11232.Value = @"TC Kimlik Numarası";

                    NewField114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 13, 52, 18, false);
                    NewField114211.Name = "NewField114211";
                    NewField114211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114211.TextFont.Size = 9;
                    NewField114211.TextFont.Bold = true;
                    NewField114211.TextFont.CharSet = 162;
                    NewField114211.Value = @":";

                    BirrhDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 28, 50, 33, false);
                    BirrhDate.Name = "BirrhDate";
                    BirrhDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BirrhDate.TextFont.Size = 9;
                    BirrhDate.TextFont.Bold = true;
                    BirrhDate.TextFont.CharSet = 162;
                    BirrhDate.Value = @"Doğum Tarihi";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 28, 112, 33, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRTHDATE.ObjectDefName = "Radiology";
                    BIRTHDATE.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    BIRTHDATE.TextFont.Size = 9;
                    BIRTHDATE.TextFont.CharSet = 162;
                    BIRTHDATE.Value = @"{@TTOBJECTID@}";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 28, 52, 33, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122111.TextFont.Size = 9;
                    NewField1122111.TextFont.Bold = true;
                    NewField1122111.TextFont.CharSet = 162;
                    NewField1122111.Value = @":";

                    UniquerefNoBarcode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 1, 203, 18, false);
                    UniquerefNoBarcode.Name = "UniquerefNoBarcode";
                    UniquerefNoBarcode.FieldType = ReportFieldTypeEnum.ftVariable;
                    UniquerefNoBarcode.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UniquerefNoBarcode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UniquerefNoBarcode.ObjectDefName = "Radiology";
                    UniquerefNoBarcode.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UniquerefNoBarcode.TextFont.Name = "Code39HalfInchTT-Regular";
                    UniquerefNoBarcode.TextFont.Size = 36;
                    UniquerefNoBarcode.TextFont.CharSet = 0;
                    UniquerefNoBarcode.Value = @"{@TTOBJECTID@}";

                    UniquerefNoBarcodeInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 18, 203, 21, false);
                    UniquerefNoBarcodeInfo.Name = "UniquerefNoBarcodeInfo";
                    UniquerefNoBarcodeInfo.FieldType = ReportFieldTypeEnum.ftVariable;
                    UniquerefNoBarcodeInfo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UniquerefNoBarcodeInfo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UniquerefNoBarcodeInfo.ObjectDefName = "Radiology";
                    UniquerefNoBarcodeInfo.DataMember = "EPISODE.PATIENT.UNIQUEREFNO";
                    UniquerefNoBarcodeInfo.TextFont.Size = 7;
                    UniquerefNoBarcodeInfo.TextFont.CharSet = 162;
                    UniquerefNoBarcodeInfo.Value = @"{@TTOBJECTID@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 23, 79, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.Value = @"/";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Radiology.RadiologyRequestPatientInfoReportQuery_Class dataset_RadiologyRequestPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Radiology.RadiologyRequestPatientInfoReportQuery_Class>(0);
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    REQDOCTORNAME.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Requestdoctor) : "");
                    FROMRESOURCE.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Fromres) : "");
                    NewField121611.CalcValue = NewField121611.Value;
                    PREDIAGNOSIS.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.PreDiagnosis) : "");
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    REQUESTDATE.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.RequestDate) : "");
                    NewField151.CalcValue = NewField151.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RUTBE.CalcValue = @"";
                    KABULSEBEBI.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Reasonforadm) : "");
                    PROTOKOLNO.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Protocolno) : "");
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField1241.CalcValue = NewField1241.Value;
                    ACTIONID.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Actionid) : "");
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField11241.CalcValue = NewField11241.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    SEX.CalcValue = (dataset_RadiologyRequestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyRequestPatientInfoReportQuery.Sex) : "");
                    SEX.PostFieldValueCalculation();
                    AGE.CalcValue = @"";
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    UNIQUEREFNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UNIQUEREFNO.PostFieldValueCalculation();
                    NewField11232.CalcValue = NewField11232.Value;
                    NewField114211.CalcValue = NewField114211.Value;
                    BirrhDate.CalcValue = BirrhDate.Value;
                    BIRTHDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BIRTHDATE.PostFieldValueCalculation();
                    NewField1122111.CalcValue = NewField1122111.Value;
                    UniquerefNoBarcode.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UniquerefNoBarcode.PostFieldValueCalculation();
                    UniquerefNoBarcodeInfo.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    UniquerefNoBarcodeInfo.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField11311,NewField11411,NewField11611,REQDOCTORNAME,FROMRESOURCE,NewField121611,PREDIAGNOSIS,NewField11116111,NewField11112111,NewField121,REQUESTDATE,NewField151,NAME,RUTBE,KABULSEBEBI,PROTOKOLNO,NewField1261,NewField1271,NewField1181,NewField1321,HASTANO,NewField1241,ACTIONID,NewField1361,NewField161,NewField1122,NewField12211,NewField11221,NewField11231,NewField11241,NewField112211,NewField1161,SEX,AGE,NewField111221,NewField1112211,NewField111121111,UNIQUEREFNO,NewField11232,NewField114211,BirrhDate,BIRTHDATE,NewField1122111,UniquerefNoBarcode,UniquerefNoBarcodeInfo,NewField1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((RadiologyRequestDescription)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Radiology radiology = (Radiology)context.GetObject(new Guid(sObjectID),"Radiology");
            this.AGE.CalcValue = radiology.Episode.Patient.Age.Value.ToString();
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PROCGroup : TTReportGroup
        {
            public RadiologyRequestDescription MyParentReport
            {
                get { return (RadiologyRequestDescription)ParentReport; }
            }

            new public PROCGroupHeader Header()
            {
                return (PROCGroupHeader)_header;
            }

            new public PROCGroupFooter Footer()
            {
                return (PROCGroupFooter)_footer;
            }

            public TTReportField RADIOLOGYTESTNAME1 { get {return Header().RADIOLOGYTESTNAME1;} }
            public TTReportField NewField1116121 { get {return Header().NewField1116121;} }
            public TTReportField PROCEDUREID { get {return Header().PROCEDUREID;} }
            public TTReportField ACCESSIONNO { get {return Header().ACCESSIONNO;} }
            public TTReportField lblKabulNo1 { get {return Header().lblKabulNo1;} }
            public TTReportField NewField1212211 { get {return Header().NewField1212211;} }
            public TTReportField NewField111161111 { get {return Header().NewField111161111;} }
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
                list[0] = new TTReportNqlData<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class>("RadiologyTestPatientInfoReportQuery", RadiologyTest.RadiologyTestPatientInfoReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public RadiologyRequestDescription MyParentReport
                {
                    get { return (RadiologyRequestDescription)ParentReport; }
                }
                
                public TTReportField RADIOLOGYTESTNAME1;
                public TTReportField NewField1116121;
                public TTReportField PROCEDUREID;
                public TTReportField ACCESSIONNO;
                public TTReportField lblKabulNo1;
                public TTReportField NewField1212211;
                public TTReportField NewField111161111; 
                public PROCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatCount = 0;
                    
                    RADIOLOGYTESTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 2, 145, 7, false);
                    RADIOLOGYTESTNAME1.Name = "RADIOLOGYTESTNAME1";
                    RADIOLOGYTESTNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RADIOLOGYTESTNAME1.ExpandTabs = EvetHayirEnum.ehEvet;
                    RADIOLOGYTESTNAME1.TextFont.Size = 9;
                    RADIOLOGYTESTNAME1.TextFont.CharSet = 162;
                    RADIOLOGYTESTNAME1.Value = @"{#NAME#}";

                    NewField1116121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 9, 61, 14, false);
                    NewField1116121.Name = "NewField1116121";
                    NewField1116121.TextFont.Size = 9;
                    NewField1116121.TextFont.Bold = true;
                    NewField1116121.TextFont.Underline = true;
                    NewField1116121.TextFont.CharSet = 162;
                    NewField1116121.Value = @"AÇIKLAMALAR";

                    PROCEDUREID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 9, 151, 14, false);
                    PROCEDUREID.Name = "PROCEDUREID";
                    PROCEDUREID.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREID.Value = @"{#PROCEDUREID#}";

                    ACCESSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 2, 203, 7, false);
                    ACCESSIONNO.Name = "ACCESSIONNO";
                    ACCESSIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCESSIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCESSIONNO.ObjectDefName = "RadiologyTest";
                    ACCESSIONNO.DataMember = "ACCESSIONNO";
                    ACCESSIONNO.TextFont.Size = 9;
                    ACCESSIONNO.TextFont.CharSet = 162;
                    ACCESSIONNO.Value = @"{#OBJECTID#}";

                    lblKabulNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 2, 165, 7, false);
                    lblKabulNo1.Name = "lblKabulNo1";
                    lblKabulNo1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblKabulNo1.TextFont.Size = 9;
                    lblKabulNo1.TextFont.Bold = true;
                    lblKabulNo1.TextFont.CharSet = 162;
                    lblKabulNo1.Value = @"Kabul No";

                    NewField1212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 2, 168, 7, false);
                    NewField1212211.Name = "NewField1212211";
                    NewField1212211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212211.TextFont.Size = 9;
                    NewField1212211.TextFont.Bold = true;
                    NewField1212211.TextFont.CharSet = 162;
                    NewField1212211.Value = @":";

                    NewField111161111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 31, 7, false);
                    NewField111161111.Name = "NewField111161111";
                    NewField111161111.TextFont.Size = 9;
                    NewField111161111.TextFont.Bold = true;
                    NewField111161111.TextFont.Underline = true;
                    NewField111161111.TextFont.CharSet = 162;
                    NewField111161111.Value = @"TETKİK ADI :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTest.RadiologyTestPatientInfoReportQuery_Class dataset_RadiologyTestPatientInfoReportQuery = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class>(0);
                    RADIOLOGYTESTNAME1.CalcValue = (dataset_RadiologyTestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyTestPatientInfoReportQuery.Name) : "");
                    NewField1116121.CalcValue = NewField1116121.Value;
                    PROCEDUREID.CalcValue = (dataset_RadiologyTestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyTestPatientInfoReportQuery.Procedureid) : "");
                    ACCESSIONNO.CalcValue = (dataset_RadiologyTestPatientInfoReportQuery != null ? Globals.ToStringCore(dataset_RadiologyTestPatientInfoReportQuery.ObjectID) : "");
                    ACCESSIONNO.PostFieldValueCalculation();
                    lblKabulNo1.CalcValue = lblKabulNo1.Value;
                    NewField1212211.CalcValue = NewField1212211.Value;
                    NewField111161111.CalcValue = NewField111161111.Value;
                    return new TTReportObject[] { RADIOLOGYTESTNAME1,NewField1116121,PROCEDUREID,ACCESSIONNO,lblKabulNo1,NewField1212211,NewField111161111};
                }
            }
            public partial class PROCGroupFooter : TTReportSection
            {
                public RadiologyRequestDescription MyParentReport
                {
                    get { return (RadiologyRequestDescription)ParentReport; }
                }
                 
                public PROCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PROCGroup PROC;

        public partial class TESTGroup : TTReportGroup
        {
            public RadiologyRequestDescription MyParentReport
            {
                get { return (RadiologyRequestDescription)ParentReport; }
            }

            new public TESTGroupBody Body()
            {
                return (TESTGroupBody)_body;
            }
            public TTReportField TESTDESCRIPTION { get {return Body().TESTDESCRIPTION;} }
            public TESTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TESTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class>("GetRadiologyTestDescriptionReportNQL", RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.PROC.PROCEDUREID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TESTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TESTGroupBody : TTReportSection
            {
                public RadiologyRequestDescription MyParentReport
                {
                    get { return (RadiologyRequestDescription)ParentReport; }
                }
                
                public TTReportField TESTDESCRIPTION; 
                public TESTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    TESTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 3, 203, 8, false);
                    TESTDESCRIPTION.Name = "TESTDESCRIPTION";
                    TESTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTDESCRIPTION.Value = @"{#TESTDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class dataset_GetRadiologyTestDescriptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<RadiologyTestDefinition.GetRadiologyTestDescriptionReportNQL_Class>(0);
                    TESTDESCRIPTION.CalcValue = (dataset_GetRadiologyTestDescriptionReportNQL != null ? Globals.ToStringCore(dataset_GetRadiologyTestDescriptionReportNQL.Testdescription) : "");
                    return new TTReportObject[] { TESTDESCRIPTION};
                }
            }

        }

        public TESTGroup TEST;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public RadiologyRequestDescription()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            PROC = new PROCGroup(HEADER,"PROC");
            TEST = new TESTGroup(PROC,"TEST");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RADIOLOGYREQUESTDESCRIPTION";
            Caption = "Radyoloji Tetkik Açıklama Raporu";
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