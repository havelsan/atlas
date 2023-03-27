
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
    /// Birim Fiyat Teklif Mektubu
    /// </summary>
    public partial class BirimFiyatTeklifMektubu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string SUPPLIER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Part2Group : TTReportGroup
        {
            public BirimFiyatTeklifMektubu MyParentReport
            {
                get { return (BirimFiyatTeklifMektubu)ParentReport; }
            }

            new public Part2GroupHeader Header()
            {
                return (Part2GroupHeader)_header;
            }

            new public Part2GroupFooter Footer()
            {
                return (Part2GroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField1332 { get {return Header().NewField1332;} }
            public TTReportField NewField11331 { get {return Header().NewField11331;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField PHONENO { get {return Header().PHONENO;} }
            public TTReportField TAXOFFICE { get {return Header().TAXOFFICE;} }
            public TTReportField EMAIL { get {return Header().EMAIL;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public Part2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _body = null;
                _header = new Part2GroupHeader(this);
                _footer = new Part2GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Part2GroupHeader : TTReportSection
            {
                public BirimFiyatTeklifMektubu MyParentReport
                {
                    get { return (BirimFiyatTeklifMektubu)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField HEADER;
                public TTReportField NewField3;
                public TTReportField XXXXXXIL;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField1331;
                public TTReportField NewField134;
                public TTReportField NewField1131;
                public TTReportField NewField1231;
                public TTReportField NewField1332;
                public TTReportField NewField11331;
                public TTReportRTF ReportRTF;
                public TTReportField SUPPLIER;
                public TTReportField ADDRESS;
                public TTReportField PHONENO;
                public TTReportField TAXOFFICE;
                public TTReportField EMAIL; 
                public Part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 112;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 170, 20, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"BİRİM FİYAT TEKLİF MEKTUBU";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 25, 89, 30, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Size = 10;
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 38, 30, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"İhale kayıt Numarası :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 25, 170, 30, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 10;
                    NewField2.Value = @"_ _/_ _/_ _ _ _";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 19, 259, 24, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.Visible = EvetHayirEnum.ehHayir;
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 35, 170, 40, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Size = 12;
                    HEADER.Value = @"{%RESPONSIBLEPROCUREMENTUNITDEF%} + "" BAŞKANLIĞINA""";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 78, 65, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 10;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Teklif Sahibinin";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 50, 170, 55, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIL.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXIL.TextFont.Size = 10;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 65, 78, 70, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"Adı Soyadı/Firma Ünvanı, Uyruğu";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 70, 78, 75, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"Açık Tebligat Adresi";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 75, 78, 80, false);
                    NewField132.Name = "NewField132";
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Size = 10;
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @"Bağlı Olduğu Vergi Dairesi ve Vergi Numarası";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 80, 78, 85, false);
                    NewField133.Name = "NewField133";
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.TextFont.Size = 10;
                    NewField133.TextFont.Bold = true;
                    NewField133.Value = @"Telefon ve Faks Numarası";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 85, 78, 90, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.TextFont.Size = 10;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.Value = @"Elektronik Posta Adresi (varsa)";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 85, 79, 90, false);
                    NewField134.Name = "NewField134";
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.TextFont.Size = 10;
                    NewField134.TextFont.Bold = true;
                    NewField134.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 65, 79, 70, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Size = 10;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 70, 79, 75, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231.TextFont.Size = 10;
                    NewField1231.TextFont.Bold = true;
                    NewField1231.Value = @":";

                    NewField1332 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 75, 79, 80, false);
                    NewField1332.Name = "NewField1332";
                    NewField1332.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1332.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1332.TextFont.Size = 10;
                    NewField1332.TextFont.Bold = true;
                    NewField1332.Value = @":";

                    NewField11331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 80, 79, 85, false);
                    NewField11331.Name = "NewField11331";
                    NewField11331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11331.TextFont.Size = 10;
                    NewField11331.TextFont.Bold = true;
                    NewField11331.Value = @":";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 0, 95, 170, 109, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 65, 170, 70, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.ObjectDefName = "Supplier";
                    SUPPLIER.DataMember = "NAME";
                    SUPPLIER.TextFont.Size = 10;
                    SUPPLIER.Value = @"{@SUPPLIER@}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 70, 170, 75, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.TextFont.Size = 10;
                    ADDRESS.Value = @"";

                    PHONENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 80, 170, 85, false);
                    PHONENO.Name = "PHONENO";
                    PHONENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHONENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PHONENO.TextFont.Size = 10;
                    PHONENO.Value = @"";

                    TAXOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 75, 170, 80, false);
                    TAXOFFICE.Name = "TAXOFFICE";
                    TAXOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXOFFICE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    TAXOFFICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TAXOFFICE.WordBreak = EvetHayirEnum.ehEvet;
                    TAXOFFICE.TextFont.Size = 10;
                    TAXOFFICE.Value = @"";

                    EMAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 85, 170, 90, false);
                    EMAIL.Name = "EMAIL";
                    EMAIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMAIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMAIL.TextFont.Size = 10;
                    EMAIL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.KIKTenderRegisterNO) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1332.CalcValue = NewField1332.Value;
                    NewField11331.CalcValue = NewField11331.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    SUPPLIER.CalcValue = MyParentReport.RuntimeParameters.SUPPLIER.ToString();
                    SUPPLIER.PostFieldValueCalculation();
                    ADDRESS.CalcValue = @"";
                    PHONENO.CalcValue = @"";
                    TAXOFFICE.CalcValue = @"";
                    EMAIL.CalcValue = @"";
                    HEADER.CalcValue = MyParentReport.Part2.RESPONSIBLEPROCUREMENTUNITDEF.CalcValue + " BAŞKANLIĞINA";
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField11,KIKTENDERREGISTERNO,NewField1,NewField2,RESPONSIBLEPROCUREMENTUNITDEF,NewField3,NewField13,NewField131,NewField132,NewField133,NewField1331,NewField134,NewField1131,NewField1231,NewField1332,NewField11331,ReportRTF,SUPPLIER,ADDRESS,PHONENO,TAXOFFICE,EMAIL,HEADER,XXXXXXIL};
                }
                public override void RunPreScript()
                {
#region PART2 HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((BirimFiyatTeklifMektubu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            this.ReportRTF.Value = purchaseProject.UnitPriceProposalLetterText.ToString();
#endregion PART2 HEADER_PreScript
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((BirimFiyatTeklifMektubu)ParentReport).RuntimeParameters.SUPPLIER.ToString();
            Supplier supplier = (Supplier)context.GetObject(new Guid(sObjectID),"Supplier");
            ADDRESS.CalcValue = supplier.Address;
            PHONENO.CalcValue = supplier.Telephone + " - " + supplier.Fax;
            TAXOFFICE.CalcValue = supplier.TaxOfficeName + " - " + supplier.TaxNo.ToString();
            EMAIL.CalcValue = supplier.Email;
#endregion PART2 HEADER_Script
                }
            }
            public partial class Part2GroupFooter : TTReportSection
            {
                public BirimFiyatTeklifMektubu MyParentReport
                {
                    get { return (BirimFiyatTeklifMektubu)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public Part2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
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
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PART2 FOOTER_Script
                    string objectID = ((BirimFiyatTeklifMektubu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PART2 FOOTER_Script
                }
            }

        }

        public Part2Group Part2;

        public partial class Part1Group : TTReportGroup
        {
            public BirimFiyatTeklifMektubu MyParentReport
            {
                get { return (BirimFiyatTeklifMektubu)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField KIKTENDERREGISTERNO1 { get {return Header().KIKTENDERREGISTERNO1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public BirimFiyatTeklifMektubu MyParentReport
                {
                    get { return (BirimFiyatTeklifMektubu)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField KIKTENDERREGISTERNO1;
                public TTReportField NewField11;
                public TTReportField NewField1;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 170, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"BİRİM FİYAT TEKLİF CETVELİ";

                    KIKTENDERREGISTERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 10, 89, 15, false);
                    KIKTENDERREGISTERNO1.Name = "KIKTENDERREGISTERNO1";
                    KIKTENDERREGISTERNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO1.TextFont.Size = 10;
                    KIKTENDERREGISTERNO1.Value = @"{%Part2.KIKTENDERREGISTERNO%}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 37, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"İhale kayıt numarası :";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 8, 30, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Sıra Nu.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 85, 30, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"Mal Kaleminin Adı ve
Kısa Açıklaması";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 20, 105, 30, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"Birimi";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 20, 125, 30, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Miktarı";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 20, 150, 30, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"Teklif Edilen 
Birim Fiyat";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 20, 170, 30, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Tutarı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    KIKTENDERREGISTERNO1.CalcValue = MyParentReport.Part2.KIKTENDERREGISTERNO.CalcValue;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    return new TTReportObject[] { NewField111,KIKTENDERREGISTERNO1,NewField11,NewField1,NewField13,NewField14,NewField15,NewField16,NewField17};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public BirimFiyatTeklifMektubu MyParentReport
                {
                    get { return (BirimFiyatTeklifMektubu)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 24;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 150, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Toplam Tutar (K.D.V Hariç)";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 170, 5, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 10, 170, 20, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.Value = @"Ad SOYAD / Ünvan (Kaşe)
İmza ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { NewField2,NewField3,NewField4};
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public BirimFiyatTeklifMektubu MyParentReport
            {
                get { return (BirimFiyatTeklifMektubu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PURCHASEITEMNAME { get {return Body().PURCHASEITEMNAME;} }
            public TTReportField PURCHASEITEMUNITTYPENAME { get {return Body().PURCHASEITEMUNITTYPENAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
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
                list[0] = new TTReportNqlData<PurchaseProjectDetail.GetProjectDetails_Class>("GetProjectDetails", PurchaseProjectDetail.GetProjectDetails((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public BirimFiyatTeklifMektubu MyParentReport
                {
                    get { return (BirimFiyatTeklifMektubu)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField PURCHASEITEMNAME;
                public TTReportField PURCHASEITEMUNITTYPENAME;
                public TTReportField AMOUNT;
                public TTReportField NewField161;
                public TTReportField NewField171; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 8, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Size = 10;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    PURCHASEITEMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 85, 5, false);
                    PURCHASEITEMNAME.Name = "PURCHASEITEMNAME";
                    PURCHASEITEMNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEITEMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEITEMNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PURCHASEITEMNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEITEMNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PURCHASEITEMNAME.TextFont.Size = 10;
                    PURCHASEITEMNAME.Value = @"{#PURCHASEITEMNAME#}";

                    PURCHASEITEMUNITTYPENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 105, 5, false);
                    PURCHASEITEMUNITTYPENAME.Name = "PURCHASEITEMUNITTYPENAME";
                    PURCHASEITEMUNITTYPENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEITEMUNITTYPENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEITEMUNITTYPENAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PURCHASEITEMUNITTYPENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEITEMUNITTYPENAME.TextFont.Size = 10;
                    PURCHASEITEMUNITTYPENAME.Value = @"{#PURCHASEITEMUNITTYPENAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 125, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Size = 10;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 150, 5, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Size = 10;
                    NewField161.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 170, 5, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Size = 10;
                    NewField171.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectDetail.GetProjectDetails_Class dataset_GetProjectDetails = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectDetail.GetProjectDetails_Class>(0);
                    ORDERNO.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.OrderNO) : "");
                    PURCHASEITEMNAME.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.Purchaseitemname) : "");
                    PURCHASEITEMUNITTYPENAME.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.Purchaseitemunittypename) : "");
                    AMOUNT.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.Amount) : "");
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    return new TTReportObject[] { ORDERNO,PURCHASEITEMNAME,PURCHASEITEMUNITTYPENAME,AMOUNT,NewField161,NewField171};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BirimFiyatTeklifMektubu()
        {
            Part2 = new Part2Group(this,"Part2");
            Part1 = new Part1Group(Part2,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
            reportParameter = Parameters.Add("SUPPLIER", "", "Firma", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("41069fdc-2950-40b8-a40e-072e0d8d670b");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("SUPPLIER"))
                _runtimeParameters.SUPPLIER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["SUPPLIER"]);
            Name = "BIRIMFIYATTEKLIFMEKTUBU";
            Caption = "Birim Fiyat Teklif Mektubu";
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 11;
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