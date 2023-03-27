
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
    /// Ek-8 Form
    /// </summary>
    public partial class EK8Report : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class EK8Group : TTReportGroup
        {
            public EK8Report MyParentReport
            {
                get { return (EK8Report)ParentReport; }
            }

            new public EK8GroupHeader Header()
            {
                return (EK8GroupHeader)_header;
            }

            new public EK8GroupFooter Footer()
            {
                return (EK8GroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField Date1 { get {return Footer().Date1;} }
            public TTReportField Date2 { get {return Footer().Date2;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public EK8Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public EK8Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new EK8GroupHeader(this);
                _footer = new EK8GroupFooter(this);

            }

            public partial class EK8GroupHeader : TTReportSection
            {
                public EK8Report MyParentReport
                {
                    get { return (EK8Report)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK1;
                public TTReportField LOGO;
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public EK8GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 8, 182, 31, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 11, 43, 31, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 35, 182, 43, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"HASTA BİLGİLENDİRME FORMU";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 44, 122, 49, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.Value = @"(Ek-8)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField1,NewField2,XXXXXXBASLIK1};
                }

                public override void RunScript()
                {
#region EK8 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion EK8 HEADER_Script
                }
            }
            public partial class EK8GroupFooter : TTReportSection
            {
                public EK8Report MyParentReport
                {
                    get { return (EK8Report)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField Date1;
                public TTReportField Date2;
                public TTReportField NewField4; 
                public EK8GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 47;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 8, 65, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.Value = @"Tebliğ Eden (kurum kaşesi)";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 8, 192, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.NoClip = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.Value = @"Hasta/Hasta Yakını
Adı/Soyadı/İmza:";

                    Date1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 51, 7, false);
                    Date1.Name = "Date1";
                    Date1.Value = @"";

                    Date2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 2, 177, 7, false);
                    Date2.Name = "Date2";
                    Date2.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 13, 57, 18, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.Value = @"imza/kaşe";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    Date1.CalcValue = Date1.Value;
                    Date2.CalcValue = Date2.Value;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { NewField3,NewField13,Date1,Date2,NewField4};
                }

                public override void RunScript()
                {
#region EK8 FOOTER_Script
                    this.Date1.CalcValue = DateTime.Now.ToShortDateString();
            this.Date2.CalcValue = DateTime.Now.ToShortDateString();
#endregion EK8 FOOTER_Script
                }
            }

        }

        public EK8Group EK8;

        public partial class MAINGroup : TTReportGroup
        {
            public EK8Report MyParentReport
            {
                get { return (EK8Report)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField pName { get {return Body().pName;} }
            public TTReportField pSurname { get {return Body().pSurname;} }
            public TTReportField pTc { get {return Body().pTc;} }
            public TTReportField pFather { get {return Body().pFather;} }
            public TTReportField pMother { get {return Body().pMother;} }
            public TTReportField pBirthPlace { get {return Body().pBirthPlace;} }
            public TTReportField pBirthDate { get {return Body().pBirthDate;} }
            public TTReportField pHomePhone { get {return Body().pHomePhone;} }
            public TTReportField pCellPhone { get {return Body().pCellPhone;} }
            public TTReportField pHomeAdress { get {return Body().pHomeAdress;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField27 { get {return Body().NewField27;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField172 { get {return Body().NewField172;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportField NewField173 { get {return Body().NewField173;} }
            public TTReportField lblKabulNo1 { get {return Body().lblKabulNo1;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField chk_SGK { get {return Body().chk_SGK;} }
            public TTReportField chk_YesilKart { get {return Body().chk_YesilKart;} }
            public TTReportField chk_Kamu { get {return Body().chk_Kamu;} }
            public TTReportField chk_Ucretli { get {return Body().chk_Ucretli;} }
            public TTReportField chk_Diger { get {return Body().chk_Diger;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField28 { get {return Body().NewField28;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportField NewField31 { get {return Body().NewField31;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField PayerType { get {return Body().PayerType;} }
            public TTReportField PayerCode { get {return Body().PayerCode;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
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
                list[0] = new TTReportNqlData<PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class>("GetPAdmissionEK8InformationByObjectID", PatientAdmission.GetPAdmissionEK8InformationByObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public EK8Report MyParentReport
                {
                    get { return (EK8Report)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField pName;
                public TTReportField pSurname;
                public TTReportField pTc;
                public TTReportField pFather;
                public TTReportField pMother;
                public TTReportField pBirthPlace;
                public TTReportField pBirthDate;
                public TTReportField pHomePhone;
                public TTReportField pCellPhone;
                public TTReportField pHomeAdress;
                public TTReportField NewField5;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField162;
                public TTReportField NewField172;
                public TTReportField NewField163;
                public TTReportField NewField173;
                public TTReportField lblKabulNo1;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField6;
                public TTReportField chk_SGK;
                public TTReportField chk_YesilKart;
                public TTReportField chk_Kamu;
                public TTReportField chk_Ucretli;
                public TTReportField chk_Diger;
                public TTReportField NewField7;
                public TTReportField NewField28;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportField NewField31;
                public TTReportField NewField8;
                public TTReportField PayerType;
                public TTReportField PayerCode;
                public TTReportField NewField9;
                public TTReportField NewField10; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 148;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 18, 52, 26, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"BİLGİLER";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 18, 124, 26, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"HASTA";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 18, 196, 26, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"YAKINI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 25, 52, 30, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.Value = @"Adı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 31, 52, 36, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.Value = @"Soyadı";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 37, 52, 42, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.Value = @"TC Kimlik No";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 43, 52, 48, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.Value = @"Baba Adı";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 49, 52, 54, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.Value = @"Anne Adı";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 55, 52, 60, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.Value = @"Doğum Yeri";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 61, 52, 66, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.Value = @"Doğum Tarihi";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 67, 52, 72, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.Value = @"Ev Telefonu";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 73, 52, 78, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.Value = @"Cep Telefonu";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 79, 52, 89, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.Value = @"Adresi";

                    pName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 25, 124, 30, false);
                    pName.Name = "pName";
                    pName.DrawStyle = DrawStyleConstants.vbSolid;
                    pName.FieldType = ReportFieldTypeEnum.ftVariable;
                    pName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pName.Value = @"{#NAME#}";

                    pSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 31, 124, 36, false);
                    pSurname.Name = "pSurname";
                    pSurname.DrawStyle = DrawStyleConstants.vbSolid;
                    pSurname.FieldType = ReportFieldTypeEnum.ftVariable;
                    pSurname.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pSurname.Value = @"{#SURNAME#}";

                    pTc = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 37, 124, 42, false);
                    pTc.Name = "pTc";
                    pTc.DrawStyle = DrawStyleConstants.vbSolid;
                    pTc.FieldType = ReportFieldTypeEnum.ftVariable;
                    pTc.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pTc.Value = @"{#UNIQUEREFNO#}";

                    pFather = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 43, 124, 48, false);
                    pFather.Name = "pFather";
                    pFather.DrawStyle = DrawStyleConstants.vbSolid;
                    pFather.FieldType = ReportFieldTypeEnum.ftVariable;
                    pFather.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pFather.Value = @"{#FATHERNAME#}";

                    pMother = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 49, 124, 54, false);
                    pMother.Name = "pMother";
                    pMother.DrawStyle = DrawStyleConstants.vbSolid;
                    pMother.FieldType = ReportFieldTypeEnum.ftVariable;
                    pMother.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pMother.Value = @"{#MOTHERNAME#}";

                    pBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 55, 124, 60, false);
                    pBirthPlace.Name = "pBirthPlace";
                    pBirthPlace.DrawStyle = DrawStyleConstants.vbSolid;
                    pBirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    pBirthPlace.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pBirthPlace.Value = @"{#BIRTHPLACE#}";

                    pBirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 61, 124, 66, false);
                    pBirthDate.Name = "pBirthDate";
                    pBirthDate.DrawStyle = DrawStyleConstants.vbSolid;
                    pBirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    pBirthDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pBirthDate.Value = @"{#BIRTHPLACE#}";

                    pHomePhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 67, 124, 72, false);
                    pHomePhone.Name = "pHomePhone";
                    pHomePhone.DrawStyle = DrawStyleConstants.vbSolid;
                    pHomePhone.FieldType = ReportFieldTypeEnum.ftVariable;
                    pHomePhone.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pHomePhone.Value = @"";

                    pCellPhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 73, 124, 78, false);
                    pCellPhone.Name = "pCellPhone";
                    pCellPhone.DrawStyle = DrawStyleConstants.vbSolid;
                    pCellPhone.FieldType = ReportFieldTypeEnum.ftVariable;
                    pCellPhone.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    pCellPhone.Value = @"{#CEPTELEFONU#}";

                    pHomeAdress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 79, 124, 89, false);
                    pHomeAdress.Name = "pHomeAdress";
                    pHomeAdress.DrawStyle = DrawStyleConstants.vbSolid;
                    pHomeAdress.FieldType = ReportFieldTypeEnum.ftVariable;
                    pHomeAdress.Value = @"{#EVADRESI#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 25, 196, 30, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.Value = @"{#YAKINADI#}";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 31, 196, 36, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23.Value = @"";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 37, 196, 42, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.Value = @"";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 43, 196, 48, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField25.Value = @"";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 49, 196, 54, false);
                    NewField26.Name = "NewField26";
                    NewField26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField26.Value = @"";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 55, 196, 60, false);
                    NewField27.Name = "NewField27";
                    NewField27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField27.Value = @"";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 61, 196, 66, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 67, 196, 72, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField172.Value = @"";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 73, 196, 78, false);
                    NewField163.Name = "NewField163";
                    NewField163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField163.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField163.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField163.Value = @"{#YAKINCEPNUMARASI#}";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 79, 196, 89, false);
                    NewField173.Name = "NewField173";
                    NewField173.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField173.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField173.Value = @"{#YAKINEVADRESI#}";

                    lblKabulNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 168, 6, false);
                    lblKabulNo1.Name = "lblKabulNo1";
                    lblKabulNo1.TextFont.Name = "Arial";
                    lblKabulNo1.TextFont.Bold = true;
                    lblKabulNo1.Value = @"Kabul No:";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 8, 168, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"Hasta No:";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 1, 195, 6, false);
                    NewField141.Name = "NewField141";
                    NewField141.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField141.TextFont.Size = 12;
                    NewField141.Value = @"{#PROTOCOLNO#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 8, 195, 13, false);
                    NewField151.Name = "NewField151";
                    NewField151.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField151.TextFont.Size = 12;
                    NewField151.Value = @"{#ID#}";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 91, 59, 96, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"SOSYAL GÜVENCESİ";

                    chk_SGK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 98, 27, 103, false);
                    chk_SGK.Name = "chk_SGK";
                    chk_SGK.DrawStyle = DrawStyleConstants.vbSolid;
                    chk_SGK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    chk_SGK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    chk_SGK.Value = @"";

                    chk_YesilKart = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 104, 27, 109, false);
                    chk_YesilKart.Name = "chk_YesilKart";
                    chk_YesilKart.DrawStyle = DrawStyleConstants.vbSolid;
                    chk_YesilKart.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    chk_YesilKart.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    chk_YesilKart.Value = @"";

                    chk_Kamu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 110, 27, 115, false);
                    chk_Kamu.Name = "chk_Kamu";
                    chk_Kamu.DrawStyle = DrawStyleConstants.vbSolid;
                    chk_Kamu.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    chk_Kamu.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    chk_Kamu.Value = @"";

                    chk_Ucretli = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 116, 27, 121, false);
                    chk_Ucretli.Name = "chk_Ucretli";
                    chk_Ucretli.DrawStyle = DrawStyleConstants.vbSolid;
                    chk_Ucretli.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    chk_Ucretli.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    chk_Ucretli.Value = @"";

                    chk_Diger = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 122, 27, 127, false);
                    chk_Diger.Name = "chk_Diger";
                    chk_Diger.DrawStyle = DrawStyleConstants.vbSolid;
                    chk_Diger.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    chk_Diger.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    chk_Diger.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 98, 66, 103, false);
                    NewField7.Name = "NewField7";
                    NewField7.Value = @"SGK(Bağkur-E.S.-S.S.K.)";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 104, 66, 109, false);
                    NewField28.Name = "NewField28";
                    NewField28.Value = @"Yeşilkart";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 110, 93, 115, false);
                    NewField29.Name = "NewField29";
                    NewField29.Value = @"Kamu Çalışanı(Aktif Çalışan ve Aile Fertleri)";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 116, 66, 121, false);
                    NewField30.Name = "NewField30";
                    NewField30.Value = @"Ücretli";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 122, 93, 127, false);
                    NewField31.Name = "NewField31";
                    NewField31.Value = @"Diğer............................................";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 133, 170, 138, false);
                    NewField8.Name = "NewField8";
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.NoClip = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField8.Value = @"     Herhangi bir sosyal güvencemin olmaması ve/veya resmi evraklarımın yanımda olmaması ya da müstehaklık alınamaması nedeni ile XXXXXXnizden adıma ve/veya yakınıma yapılacak tedavi kaydının ücretli olarak yapıldığı bu form ile şahsıma bildirilmiştir.";

                    PayerType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 101, 246, 106, false);
                    PayerType.Name = "PayerType";
                    PayerType.Visible = EvetHayirEnum.ehHayir;
                    PayerType.FieldType = ReportFieldTypeEnum.ftVariable;
                    PayerType.Value = @"{#PAYERTYPE#}";

                    PayerCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 49, 249, 54, false);
                    PayerCode.Name = "PayerCode";
                    PayerCode.Visible = EvetHayirEnum.ehHayir;
                    PayerCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    PayerCode.Value = @"{#CODE#}";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 96, 192, 101, false);
                    NewField9.Name = "NewField9";
                    NewField9.MultiLine = EvetHayirEnum.ehEvet;
                    NewField9.NoClip = EvetHayirEnum.ehEvet;
                    NewField9.WordBreak = EvetHayirEnum.ehEvet;
                    NewField9.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField9.TextFont.Size = 9;
                    NewField9.Value = @"İş Kazalarında: Kaza Raporu düzenlenerek ve kaza tarihi vizite kağıdının iş kazasi bölümleri dodurulup imzalanarak ve kaşelenerek,
Adli Vakalarda; Karakol Tutanağı,
Trafik Kazalarında;Araç Plakası,
Hafta içi mesai saatleri içerisinde(08:00-16:00)
Poliklinikler katında, ALACAK TAKİP servisine getirilecektir.";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 91, 150, 96, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"ÖNEMLİ NOT:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class dataset_GetPAdmissionEK8InformationByObjectID = ParentGroup.rsGroup.GetCurrentRecord<PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    pName.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Name) : "");
                    pSurname.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Surname) : "");
                    pTc.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.UniqueRefNo) : "");
                    pFather.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.FatherName) : "");
                    pMother.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.MotherName) : "");
                    pBirthPlace.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.BirthPlace) : "");
                    pBirthDate.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.BirthPlace) : "");
                    pHomePhone.CalcValue = @"";
                    pCellPhone.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Ceptelefonu) : "");
                    pHomeAdress.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Evadresi) : "");
                    NewField5.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Yakinadi) : "");
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField163.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Yakincepnumarasi) : "");
                    NewField173.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Yakinevadresi) : "");
                    lblKabulNo1.CalcValue = lblKabulNo1.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.ProtocolNo) : "");
                    NewField151.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.ID) : "");
                    NewField6.CalcValue = NewField6.Value;
                    chk_SGK.CalcValue = chk_SGK.Value;
                    chk_YesilKart.CalcValue = chk_YesilKart.Value;
                    chk_Kamu.CalcValue = chk_Kamu.Value;
                    chk_Ucretli.CalcValue = chk_Ucretli.Value;
                    chk_Diger.CalcValue = chk_Diger.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField31.CalcValue = NewField31.Value;
                    NewField8.CalcValue = NewField8.Value;
                    PayerType.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.PayerType) : "");
                    PayerCode.CalcValue = (dataset_GetPAdmissionEK8InformationByObjectID != null ? Globals.ToStringCore(dataset_GetPAdmissionEK8InformationByObjectID.Code) : "");
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField14,NewField15,NewField16,NewField17,NewField18,NewField19,NewField20,NewField21,NewField22,pName,pSurname,pTc,pFather,pMother,pBirthPlace,pBirthDate,pHomePhone,pCellPhone,pHomeAdress,NewField5,NewField23,NewField24,NewField25,NewField26,NewField27,NewField162,NewField172,NewField163,NewField173,lblKabulNo1,NewField131,NewField141,NewField151,NewField6,chk_SGK,chk_YesilKart,chk_Kamu,chk_Ucretli,chk_Diger,NewField7,NewField28,NewField29,NewField30,NewField31,NewField8,PayerType,PayerCode,NewField9,NewField10};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.PayerType.CalcValue == "Paid" || this.PayerType.CalcValue == "PAİD")
                this.chk_Ucretli.CalcValue = "X";
            else if (this.PayerType.CalcValue == "SGK")
            {
                if (this.PayerCode.CalcValue == "1" || this.PayerCode.CalcValue == "2" || this.PayerCode.CalcValue == "3")
                {
                    this.chk_SGK.CalcValue = "X";
                }
                else if (this.PayerCode.CalcValue == "4")
                {
                    this.chk_YesilKart.CalcValue = "X";
                }
                else
                {
                    this.chk_Diger.CalcValue = "X";
                }
            }
            else
            {
                this.chk_Diger.CalcValue = "X";
            }
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

        public EK8Report()
        {
            EK8 = new EK8Group(this,"EK8");
            MAIN = new MAINGroup(EK8,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "EK8REPORT";
            Caption = "Ek-8 Form";
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