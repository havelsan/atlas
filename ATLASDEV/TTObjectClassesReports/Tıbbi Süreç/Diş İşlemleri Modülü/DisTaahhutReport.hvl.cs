
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
    /// Diş Taahhüt Formu
    /// </summary>
    public partial class DisTaahhutReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string DentalExamination = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public DisTaahhutReport MyParentReport
            {
                get { return (DisTaahhutReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField Taahhut { get {return Header().Taahhut;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField11311 { get {return Footer().NewField11311;} }
            public TTReportField PATIENTNAME { get {return Footer().PATIENTNAME;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField DOCTORNAME { get {return Footer().DOCTORNAME;} }
            public TTReportField PATIENTTC { get {return Footer().PATIENTTC;} }
            public TTReportField PATIENTADRESS { get {return Footer().PATIENTADRESS;} }
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
                public DisTaahhutReport MyParentReport
                {
                    get { return (DisTaahhutReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO;
                public TTReportField Taahhut;
                public TTReportField NewField151; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 59;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 10, 192, 51, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 19, 42, 42, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    Taahhut = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 52, 133, 57, false);
                    Taahhut.Name = "Taahhut";
                    Taahhut.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Taahhut.TextFont.Name = "Arial";
                    Taahhut.TextFont.Size = 12;
                    Taahhut.TextFont.Bold = true;
                    Taahhut.TextFont.CharSet = 162;
                    Taahhut.Value = @"TAAHHÜTNAME";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 52, 201, 57, false);
                    NewField151.Name = "NewField151";
                    NewField151.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField151.TextFormat = @"dd/MM/yyyy";
                    NewField151.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    Taahhut.CalcValue = Taahhut.Value;
                    NewField151.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,Taahhut,NewField151,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public DisTaahhutReport MyParentReport
                {
                    get { return (DisTaahhutReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField PATIENTNAME;
                public TTReportField NewField5;
                public TTReportField NewField15;
                public TTReportField DOCTORNAME;
                public TTReportField PATIENTTC;
                public TTReportField PATIENTADRESS; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 55;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 44, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Taahhütnameyi Alanın ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 9, 36, 14, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Adı ve Soyadı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 36, 20, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Tarih";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 36, 26, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"İmza";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 3, 154, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Taahhütnameyi Verenin";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 9, 146, 14, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Adı ve Soyadı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 15, 146, 20, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Tarih";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 21, 146, 26, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İmza";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 27, 146, 32, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"T.C. No";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 33, 146, 38, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Adres";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 9, 202, 14, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 15, 64, 20, false);
                    NewField5.Name = "NewField5";
                    NewField5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField5.TextFormat = @"dd/MM/yyyy";
                    NewField5.Value = @"{@printdate@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 15, 173, 20, false);
                    NewField15.Name = "NewField15";
                    NewField15.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField15.TextFormat = @"dd/MM/yyyy";
                    NewField15.Value = @"{@printdate@}";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 9, 103, 14, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.Value = @"";

                    PATIENTTC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 27, 173, 32, false);
                    PATIENTTC.Name = "PATIENTTC";
                    PATIENTTC.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTTC.Value = @"";

                    PATIENTADRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 33, 201, 50, false);
                    PATIENTADRESS.Name = "PATIENTADRESS";
                    PATIENTADRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTADRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTADRESS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    PATIENTNAME.CalcValue = @"";
                    NewField5.CalcValue = DateTime.Now.ToShortDateString();
                    NewField15.CalcValue = DateTime.Now.ToShortDateString();
                    DOCTORNAME.CalcValue = @"";
                    PATIENTTC.CalcValue = @"";
                    PATIENTADRESS.CalcValue = @"";
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField11,NewField12,NewField13,NewField131,NewField1131,NewField11311,PATIENTNAME,NewField5,NewField15,DOCTORNAME,PATIENTTC,PATIENTADRESS};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
                    
                    DentalExamination examination =  (DentalExamination)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.DentalExamination), TTObjectDefManager.Instance.ObjectDefs[typeof(DentalExamination).Name], false);


                    this.DOCTORNAME.CalcValue = examination.ProcedureDoctor.Name;
                    this.PATIENTNAME.CalcValue = examination.Episode.Patient.FullName;
                    this.PATIENTTC.CalcValue = examination.Episode.Patient.UniqueRefNo.ToString();
                       this.PATIENTADRESS.CalcValue = examination.Episode.Patient.PatientAddress.HomeAddress;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public DisTaahhutReport MyParentReport
            {
                get { return (DisTaahhutReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine1141 { get {return Body().NewLine1141;} }
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
                public DisTaahhutReport MyParentReport
                {
                    get { return (DisTaahhutReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportShape NewLine14;
                public TTReportShape NewLine1141; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 51;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 3, 201, 41, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.Value = @"     Aşağıda numarası belirtilen dişime/dişlerime hizasında Sağlık Uygulama Tebliği (SUT) kodu ve adı ile belirtilen sağlık hizmetlerinin yapılması gerektiği hususu ile bu sağlık hizmetlerinin ilgili mevzuat gereğince hizasında belirtilen süre (miad) dolmadan yapılması durumunda bedelinin tarafımca karşılanması gerektiğini, süre (miad) dolduktan sonra yapılması durumunda ise bedelinin yine ilgili mevzuatta belirtildiği şekliyle Sosyal Güvenlik Kurumunca karşılanacağı konusunda bilgi edindim.
     Tedavimi sağlayan sağlık hizmeti sunucusunca yapılmasına gerek görülen ve aşağıda SUT kodu ve adı, diş numarası,miadı yazılı sağlık hizmetlerini bugünden geriye dönük olarak, belirtilen süre içinde bedeli Sosyal Güvenlik Kurumu tarafından karşılanmak suretiyle almadığımı, beyanımın aksi bir durumun (hak etmediğim halde sağlık hizmetini aldığımın) tespiti halinde söz konusu sağlık hizmeti bedelini, kurumun anapara, faiz, ödeme süresi ve ödeme yerini belirleyerek göndereceği tebligatta belirtilen esaslarına göre defaten ödeyeceğimi beyan ve taahhüt ederim. ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 45, 36, 50, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"SUT KODU ve ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 45, 147, 50, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"DİŞ NUMARASI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 45, 174, 50, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"SÜRESİ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 45, 201, 50, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"BEYAN";

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 44, 201, 44, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 50, 201, 50, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField121,NewField1121};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ProceduresGroup : TTReportGroup
        {
            public DisTaahhutReport MyParentReport
            {
                get { return (DisTaahhutReport)ParentReport; }
            }

            new public ProceduresGroupBody Body()
            {
                return (ProceduresGroupBody)_body;
            }
            public TTReportField KODAD { get {return Body().KODAD;} }
            public TTReportField DISNO { get {return Body().DISNO;} }
            public TTReportField SURE { get {return Body().SURE;} }
            public TTReportField Beyan { get {return Body().Beyan;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public ProceduresGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ProceduresGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DentalProcedure.GetDentalProtesisProcedures_Class>("GetDentalProtesisProcedures", DentalProcedure.GetDentalProtesisProcedures((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.DentalExamination)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ProceduresGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ProceduresGroupBody : TTReportSection
            {
                public DisTaahhutReport MyParentReport
                {
                    get { return (DisTaahhutReport)ParentReport; }
                }
                
                public TTReportField KODAD;
                public TTReportField DISNO;
                public TTReportField SURE;
                public TTReportField Beyan;
                public TTReportShape NewLine141; 
                public ProceduresGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    KODAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 117, 6, false);
                    KODAD.Name = "KODAD";
                    KODAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KODAD.MultiLine = EvetHayirEnum.ehEvet;
                    KODAD.NoClip = EvetHayirEnum.ehEvet;
                    KODAD.Value = @"{#CODE#}-{#NAME#}";

                    DISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 147, 6, false);
                    DISNO.Name = "DISNO";
                    DISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISNO.ObjectDefName = "ToothNumberEnum";
                    DISNO.DataMember = "DISPLAYTEXT";
                    DISNO.Value = @"{#TOOTHNUMBER#}";

                    SURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 1, 174, 6, false);
                    SURE.Name = "SURE";
                    SURE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SURE.Value = @"4 Yıl";

                    Beyan = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 1, 201, 6, false);
                    Beyan.Name = "Beyan";
                    Beyan.Value = @"Yaptırmadım";

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 6, 201, 6, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DentalProcedure.GetDentalProtesisProcedures_Class dataset_GetDentalProtesisProcedures = ParentGroup.rsGroup.GetCurrentRecord<DentalProcedure.GetDentalProtesisProcedures_Class>(0);
                    KODAD.CalcValue = (dataset_GetDentalProtesisProcedures != null ? Globals.ToStringCore(dataset_GetDentalProtesisProcedures.Code) : "") + @"-" + (dataset_GetDentalProtesisProcedures != null ? Globals.ToStringCore(dataset_GetDentalProtesisProcedures.Name) : "");
                    DISNO.CalcValue = (dataset_GetDentalProtesisProcedures != null ? Globals.ToStringCore(dataset_GetDentalProtesisProcedures.ToothNumber) : "");
                    DISNO.PostFieldValueCalculation();
                    SURE.CalcValue = SURE.Value;
                    Beyan.CalcValue = Beyan.Value;
                    return new TTReportObject[] { KODAD,DISNO,SURE,Beyan};
                }
            }

        }

        public ProceduresGroup Procedures;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DisTaahhutReport()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            Procedures = new ProceduresGroup(Header,"Procedures");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DentalExamination", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DentalExamination"))
                _runtimeParameters.DentalExamination = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DentalExamination"]);
            Name = "DISTAAHHUTREPORT";
            Caption = "Diş Taahhüt Formu";
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