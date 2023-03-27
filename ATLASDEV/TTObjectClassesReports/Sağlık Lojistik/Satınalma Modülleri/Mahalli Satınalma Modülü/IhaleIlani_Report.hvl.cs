
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
    /// İhale İlanı
    /// </summary>
    public partial class IhaleIlani : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public IhaleIlani MyParentReport
            {
                get { return (IhaleIlani)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public IhaleIlani MyParentReport
                {
                    get { return (IhaleIlani)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public IhaleIlani MyParentReport
                {
                    get { return (IhaleIlani)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    string objectID = ((IhaleIlani)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public IhaleIlani MyParentReport
            {
                get { return (IhaleIlani)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ReportName { get {return Body().ReportName;} }
            public TTReportField ResponsibleProcurementName { get {return Body().ResponsibleProcurementName;} }
            public TTReportField ActDefine { get {return Body().ActDefine;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField1251 { get {return Body().NewField1251;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField TenderRegisterNO { get {return Body().TenderRegisterNO;} }
            public TTReportField ResponsibleProcurementAddress { get {return Body().ResponsibleProcurementAddress;} }
            public TTReportField ResponsibleProcurementPhone { get {return Body().ResponsibleProcurementPhone;} }
            public TTReportField ResponsibleProcurementEmail { get {return Body().ResponsibleProcurementEmail;} }
            public TTReportField ActAndPurchase { get {return Body().ActAndPurchase;} }
            public TTReportField TenderPlace { get {return Body().TenderPlace;} }
            public TTReportField TenderDate { get {return Body().TenderDate;} }
            public TTReportField Phone { get {return Body().Phone;} }
            public TTReportField Fax { get {return Body().Fax;} }
            public TTReportField ActCount { get {return Body().ActCount;} }
            public TTReportField ActAttribute { get {return Body().ActAttribute;} }
            public TTReportField PurchaseMainType { get {return Body().PurchaseMainType;} }
            public TTReportRTF TenderRTF { get {return Body().TenderRTF;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IhaleIlani MyParentReport
                {
                    get { return (IhaleIlani)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField ResponsibleProcurementName;
                public TTReportField ActDefine;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField151;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField152;
                public TTReportField NewField1151;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField1251;
                public TTReportField NewField3;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField TenderRegisterNO;
                public TTReportField ResponsibleProcurementAddress;
                public TTReportField ResponsibleProcurementPhone;
                public TTReportField ResponsibleProcurementEmail;
                public TTReportField ActAndPurchase;
                public TTReportField TenderPlace;
                public TTReportField TenderDate;
                public TTReportField Phone;
                public TTReportField Fax;
                public TTReportField ActCount;
                public TTReportField ActAttribute;
                public TTReportField PurchaseMainType;
                public TTReportRTF TenderRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 121;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 18, 110, 26, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.NoClip = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"İHALE İLANI";

                    ResponsibleProcurementName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 28, 110, 34, false);
                    ResponsibleProcurementName.Name = "ResponsibleProcurementName";
                    ResponsibleProcurementName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleProcurementName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ResponsibleProcurementName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ResponsibleProcurementName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ResponsibleProcurementName.NoClip = EvetHayirEnum.ehEvet;
                    ResponsibleProcurementName.TextFont.Name = "Arial";
                    ResponsibleProcurementName.TextFont.Size = 11;
                    ResponsibleProcurementName.TextFont.CharSet = 162;
                    ResponsibleProcurementName.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    ActDefine = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 39, 170, 49, false);
                    ActDefine.Name = "ActDefine";
                    ActDefine.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActDefine.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActDefine.MultiLine = EvetHayirEnum.ehEvet;
                    ActDefine.WordBreak = EvetHayirEnum.ehEvet;
                    ActDefine.TextFont.Name = "Arial";
                    ActDefine.TextFont.CharSet = 162;
                    ActDefine.Value = @"     {#ACTDEFINE#} işi açık ihale usulü ile ihale edilecektir.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 49, 54, 54, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 54, 54, 59, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Underline = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İdarenin";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 54, 3, 59, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"1-";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 59, 54, 64, false);
                    NewField14.Name = "NewField14";
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"a) adresi";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 64, 54, 69, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"b) telefon ve faks numarası";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 69, 54, 74, false);
                    NewField151.Name = "NewField151";
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"c) elektronik posta adresi (varsa)";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 74, 54, 79, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Underline = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İhale konusu malın";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 74, 3, 79, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"2-";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 79, 54, 84, false);
                    NewField141.Name = "NewField141";
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"a) niteliği, türü ve miktarı";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 84, 54, 89, false);
                    NewField152.Name = "NewField152";
                    NewField152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152.TextFont.Name = "Arial";
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @"b) teslim yeri/yerleri";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 89, 54, 94, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"c) teslim tarihi/tarihleri";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 94, 54, 99, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Underline = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"İhalenin";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 94, 3, 99, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"3-";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 99, 54, 104, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"a) yapılacağı yer";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 104, 54, 109, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1251.TextFont.Name = "Arial";
                    NewField1251.TextFont.CharSet = 162;
                    NewField1251.Value = @"b) tarihi ve saati";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 49, 55, 54, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 59, 55, 64, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 64, 55, 69, false);
                    NewField17.Name = "NewField17";
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 69, 55, 74, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 79, 55, 84, false);
                    NewField19.Name = "NewField19";
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.Value = @":";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 84, 55, 89, false);
                    NewField20.Name = "NewField20";
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 89, 55, 94, false);
                    NewField21.Name = "NewField21";
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 99, 55, 104, false);
                    NewField22.Name = "NewField22";
                    NewField22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 104, 55, 109, false);
                    NewField23.Name = "NewField23";
                    NewField23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23.Value = @":";

                    TenderRegisterNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 49, 170, 54, false);
                    TenderRegisterNO.Name = "TenderRegisterNO";
                    TenderRegisterNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TenderRegisterNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TenderRegisterNO.TextFont.Name = "Arial";
                    TenderRegisterNO.TextFont.CharSet = 162;
                    TenderRegisterNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    ResponsibleProcurementAddress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 59, 170, 64, false);
                    ResponsibleProcurementAddress.Name = "ResponsibleProcurementAddress";
                    ResponsibleProcurementAddress.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleProcurementAddress.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ResponsibleProcurementAddress.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ResponsibleProcurementAddress.ObjectDefName = "ProcurementUnitDef";
                    ResponsibleProcurementAddress.DataMember = "ADDRESS";
                    ResponsibleProcurementAddress.TextFont.Name = "Arial";
                    ResponsibleProcurementAddress.TextFont.CharSet = 162;
                    ResponsibleProcurementAddress.Value = @"{#RESPONSIBLEPROCUREMENTOBJECTID#}";

                    ResponsibleProcurementPhone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 64, 170, 69, false);
                    ResponsibleProcurementPhone.Name = "ResponsibleProcurementPhone";
                    ResponsibleProcurementPhone.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleProcurementPhone.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ResponsibleProcurementPhone.TextFont.Name = "Arial";
                    ResponsibleProcurementPhone.TextFont.CharSet = 162;
                    ResponsibleProcurementPhone.Value = @"{%Phone%} / {%Fax%}";

                    ResponsibleProcurementEmail = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 69, 170, 74, false);
                    ResponsibleProcurementEmail.Name = "ResponsibleProcurementEmail";
                    ResponsibleProcurementEmail.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleProcurementEmail.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ResponsibleProcurementEmail.ObjectDefName = "ProcurementUnitDef";
                    ResponsibleProcurementEmail.DataMember = "EMAIL";
                    ResponsibleProcurementEmail.TextFont.Name = "Arial";
                    ResponsibleProcurementEmail.TextFont.CharSet = 162;
                    ResponsibleProcurementEmail.Value = @"";

                    ActAndPurchase = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 79, 170, 84, false);
                    ActAndPurchase.Name = "ActAndPurchase";
                    ActAndPurchase.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActAndPurchase.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActAndPurchase.TextFont.Name = "Arial";
                    ActAndPurchase.TextFont.CharSet = 162;
                    ActAndPurchase.Value = @"{%ActAttribute%} / {%PurchaseMainType%} / {%ActCount%}";

                    TenderPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 99, 170, 104, false);
                    TenderPlace.Name = "TenderPlace";
                    TenderPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    TenderPlace.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TenderPlace.TextFont.Name = "Arial";
                    TenderPlace.TextFont.CharSet = 162;
                    TenderPlace.Value = @"";

                    TenderDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 104, 170, 109, false);
                    TenderDate.Name = "TenderDate";
                    TenderDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TenderDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    TenderDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TenderDate.TextFont.Name = "Arial";
                    TenderDate.TextFont.CharSet = 162;
                    TenderDate.Value = @"{#TENDERDATE#}";

                    Phone = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 64, 226, 69, false);
                    Phone.Name = "Phone";
                    Phone.Visible = EvetHayirEnum.ehHayir;
                    Phone.FieldType = ReportFieldTypeEnum.ftVariable;
                    Phone.ObjectDefName = "ProcurementUnitDef";
                    Phone.DataMember = "TELEPHONE";
                    Phone.Value = @"{#RESPONSIBLEPROCUREMENTOBJECTID#}";

                    Fax = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 64, 237, 69, false);
                    Fax.Name = "Fax";
                    Fax.Visible = EvetHayirEnum.ehHayir;
                    Fax.FieldType = ReportFieldTypeEnum.ftVariable;
                    Fax.ObjectDefName = "ProcurementUnitDef";
                    Fax.DataMember = "FAX";
                    Fax.Value = @"{#RESPONSIBLEPROCUREMENTOBJECTID#}";

                    ActCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 76, 242, 81, false);
                    ActCount.Name = "ActCount";
                    ActCount.Visible = EvetHayirEnum.ehHayir;
                    ActCount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActCount.TextFormat = @"#,###";
                    ActCount.Value = @"{#ACTCOUNT#}";

                    ActAttribute = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 70, 242, 75, false);
                    ActAttribute.Name = "ActAttribute";
                    ActAttribute.Visible = EvetHayirEnum.ehHayir;
                    ActAttribute.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActAttribute.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ActAttribute.Value = @"{#ACTATTRIBUTE#}";

                    PurchaseMainType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 82, 242, 87, false);
                    PurchaseMainType.Name = "PurchaseMainType";
                    PurchaseMainType.Visible = EvetHayirEnum.ehHayir;
                    PurchaseMainType.FieldType = ReportFieldTypeEnum.ftVariable;
                    PurchaseMainType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PurchaseMainType.ObjectDefName = "PurchaseMainTypeEnum";
                    PurchaseMainType.DataMember = "DISPLAYTEXT";
                    PurchaseMainType.Value = @"{#PURCHASEMAINTYPE#}";

                    TenderRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 0, 113, 170, 118, false);
                    TenderRTF.Name = "TenderRTF";
                    TenderRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    ReportName.CalcValue = ReportName.Value;
                    ResponsibleProcurementName.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    ActDefine.CalcValue = @"     " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "") + @" işi açık ihale usulü ile ihale edilecektir.";
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    TenderRegisterNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.KIKTenderRegisterNO) : "");
                    ResponsibleProcurementAddress.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementobjectid) : "");
                    ResponsibleProcurementAddress.PostFieldValueCalculation();
                    Phone.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementobjectid) : "");
                    Phone.PostFieldValueCalculation();
                    Fax.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementobjectid) : "");
                    Fax.PostFieldValueCalculation();
                    ResponsibleProcurementPhone.CalcValue = MyParentReport.MAIN.Phone.CalcValue + @" / " + MyParentReport.MAIN.Fax.CalcValue;
                    ResponsibleProcurementEmail.CalcValue = @"";
                    ResponsibleProcurementEmail.PostFieldValueCalculation();
                    ActAttribute.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActAttribute) : "");
                    PurchaseMainType.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PurchaseMainType) : "");
                    PurchaseMainType.PostFieldValueCalculation();
                    ActCount.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActCount) : "");
                    ActAndPurchase.CalcValue = MyParentReport.MAIN.ActAttribute.CalcValue + @" / " + MyParentReport.MAIN.PurchaseMainType.CalcValue + @" / " + MyParentReport.MAIN.ActCount.FormattedValue;
                    TenderPlace.CalcValue = @"";
                    TenderDate.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.TenderDate) : "");
                    TenderRTF.CalcValue = TenderRTF.Value;
                    return new TTReportObject[] { ReportName,ResponsibleProcurementName,ActDefine,NewField2,NewField12,NewField13,NewField14,NewField15,NewField151,NewField121,NewField131,NewField141,NewField152,NewField1151,NewField1121,NewField1131,NewField1141,NewField1251,NewField3,NewField16,NewField17,NewField18,NewField19,NewField20,NewField21,NewField22,NewField23,TenderRegisterNO,ResponsibleProcurementAddress,Phone,Fax,ResponsibleProcurementPhone,ResponsibleProcurementEmail,ActAttribute,PurchaseMainType,ActCount,ActAndPurchase,TenderPlace,TenderDate,TenderRTF};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((IhaleIlani)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            this.TenderRTF.Value = purchaseProject.TenderAnnouncementRTF.ToString();
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

        public IhaleIlani()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "IHALEILANI";
            Caption = "İhale İlanı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
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