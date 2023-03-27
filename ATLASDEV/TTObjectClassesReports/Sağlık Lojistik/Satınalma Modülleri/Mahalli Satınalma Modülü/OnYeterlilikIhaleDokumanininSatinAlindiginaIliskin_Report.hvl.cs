
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
    /// Ön Yeterlik / İhale Dökümanının Satın Alındığına İlişkin Form_KİK005.0/M
    /// </summary>
    public partial class OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin MyParentReport
            {
                get { return (OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField YETERLIKLABEL1 { get {return Header().YETERLIKLABEL1;} }
            public TTReportField TENDERDATE { get {return Header().TENDERDATE;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField LOGO1111 { get {return Header().LOGO1111;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField SUPPLIERADDRESS { get {return Header().SUPPLIERADDRESS;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField SALEDATE { get {return Header().SALEDATE;} }
            public TTReportField SALERECEIPNO { get {return Header().SALERECEIPNO;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField ANNEX { get {return Header().ANNEX;} }
            public TTReportField PURCHASETYPEDEFINITIONOBJECTID { get {return Header().PURCHASETYPEDEFINITIONOBJECTID;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField TIME { get {return Header().TIME;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField PURCHASER { get {return Footer().PURCHASER;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
            public TTReportField SELLERNAME { get {return Footer().SELLERNAME;} }
            public TTReportField SELLERTITLE { get {return Footer().SELLERTITLE;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>("GetDocumentSoldFirmsByProjectObjectID", DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin MyParentReport
                {
                    get { return (OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField15;
                public TTReportField ACTDEFINE;
                public TTReportField YETERLIKLABEL1;
                public TTReportField TENDERDATE;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField101;
                public TTReportField LOGO1111;
                public TTReportField NewField14;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField SUPPLIERADDRESS;
                public TTReportField NewField111;
                public TTReportField SUPPLIER;
                public TTReportField SALEDATE;
                public TTReportField SALERECEIPNO;
                public TTReportField DESCRIPTION;
                public TTReportField ANNEX;
                public TTReportField PURCHASETYPEDEFINITIONOBJECTID;
                public TTReportField XXXXXXBASLIK;
                public TTReportField DATE;
                public TTReportField TIME; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 134;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"İhale Kayıt Numarası";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 170, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField15.Name = "NewField15";
                    NewField15.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"İşin Adı";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 170, 50, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    YETERLIKLABEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    YETERLIKLABEL1.Name = "YETERLIKLABEL1";
                    YETERLIKLABEL1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YETERLIKLABEL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETERLIKLABEL1.MultiLine = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL1.WordBreak = EvetHayirEnum.ehEvet;
                    YETERLIKLABEL1.TextFont.Name = "Arial";
                    YETERLIKLABEL1.TextFont.Bold = true;
                    YETERLIKLABEL1.Value = @"İhale Tarih ve saati";

                    TENDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    TENDERDATE.Name = "TENDERDATE";
                    TENDERDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    TENDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TENDERDATE.TextFont.Name = "Arial";
                    TENDERDATE.Value = @"DATE.FormattedValue + "" günü, saat "" + TIME.FormattedValue";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField17.Name = "NewField17";
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @":";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField101.Name = "NewField101";
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @":";

                    LOGO1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO1111.Name = "LOGO1111";
                    LOGO1111.Visible = EvetHayirEnum.ehHayir;
                    LOGO1111.TextFont.CharSet = 1;
                    LOGO1111.Value = @"LOGO";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 63, 67, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.Value = @"[İstekli/Aday]ın Ticaret Ünvanı                        ";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 67, 63, 74, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.Value = @"Adresi                     ";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 74, 63, 81, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.Value = @"Dökümanın Satın Alındığı Tarih ve Saat                      ";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 81, 63, 91, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.MultiLine = EvetHayirEnum.ehEvet;
                    NewField20.WordBreak = EvetHayirEnum.ehEvet;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.Value = @"Döküman Bedelinin Tahsil Edildiğine İlişkin Belgenin Tarihi ve No'su                        ";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 91, 63, 98, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.Value = @"Açıklama              ";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 98, 63, 105, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.TextFont.Name = "Arial";
                    NewField22.Value = @"Zeyilname          ";

                    SUPPLIERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 67, 170, 74, false);
                    SUPPLIERADDRESS.Name = "SUPPLIERADDRESS";
                    SUPPLIERADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SUPPLIERADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIERADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIERADDRESS.TextFont.Name = "Arial";
                    SUPPLIERADDRESS.Value = @"{#SUPPLIERADDRESS#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 110, 170, 131, false);
                    NewField111.Name = "NewField111";
                    NewField111.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.Value = @"""     "" + {%ACTDEFINE%} + "" işine ilişkin olarak ihale dokümanını oluşturan belgelerin aslına uygunluğu ve belgelerin tamam olup olmadığı aday  tarafından kontrol edilmiş ve  tamamı aslına uygun olarak, içeriğindeki  belgeleri  gösteren  bir  dizi  pusulasıyla  birlikte   teslim edilmiştir.\n\n İhale Dökümanı;""";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 60, 170, 67, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    SALEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 74, 170, 81, false);
                    SALEDATE.Name = "SALEDATE";
                    SALEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    SALEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SALEDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    SALEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SALEDATE.TextFont.Name = "Arial";
                    SALEDATE.Value = @"{#SALEDATE#}";

                    SALERECEIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 81, 170, 91, false);
                    SALERECEIPNO.Name = "SALERECEIPNO";
                    SALERECEIPNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SALERECEIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SALERECEIPNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SALERECEIPNO.TextFont.Name = "Arial";
                    SALERECEIPNO.Value = @"{#SALERECEIPNO#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 91, 170, 98, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    ANNEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 98, 170, 105, false);
                    ANNEX.Name = "ANNEX";
                    ANNEX.DrawStyle = DrawStyleConstants.vbSolid;
                    ANNEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANNEX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ANNEX.WordBreak = EvetHayirEnum.ehEvet;
                    ANNEX.TextFont.Name = "Arial";
                    ANNEX.Value = @"{#ANNEX#}";

                    PURCHASETYPEDEFINITIONOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 109, 241, 114, false);
                    PURCHASETYPEDEFINITIONOBJECTID.Name = "PURCHASETYPEDEFINITIONOBJECTID";
                    PURCHASETYPEDEFINITIONOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PURCHASETYPEDEFINITIONOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASETYPEDEFINITIONOBJECTID.Value = @"{#PURCHASETYPEDEFINITIONOBJECTID#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 170, 38, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 26, 242, 31, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Long Date";
                    DATE.TextFont.Name = "Arial Narrow";
                    DATE.TextFont.CharSet = 1;
                    DATE.Value = @"{#TENDERDATE#}";

                    TIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 34, 242, 39, false);
                    TIME.Name = "TIME";
                    TIME.Visible = EvetHayirEnum.ehHayir;
                    TIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIME.TextFormat = @"Short Time";
                    TIME.TextFont.Name = "Arial Narrow";
                    TIME.TextFont.CharSet = 1;
                    TIME.Value = @"{#TENDERDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    NewField12.CalcValue = NewField12.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.KIKTenderRegisterNO) : "");
                    NewField15.CalcValue = NewField15.Value;
                    ACTDEFINE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.ActDefine) : "");
                    YETERLIKLABEL1.CalcValue = YETERLIKLABEL1.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField101.CalcValue = NewField101.Value;
                    LOGO1111.CalcValue = LOGO1111.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    SUPPLIERADDRESS.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Supplieraddress) : "");
                    SUPPLIER.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Supplier) : "");
                    SALEDATE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.SaleDate) : "");
                    SALERECEIPNO.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.SaleReceipNo) : "");
                    DESCRIPTION.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Description) : "");
                    ANNEX.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Annex) : "");
                    PURCHASETYPEDEFINITIONOBJECTID.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Purchasetypedefinitionobjectid) : "");
                    DATE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.TenderDate) : "");
                    TIME.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.TenderDate) : "");
                    TENDERDATE.CalcValue = DATE.FormattedValue + " günü, saat " + TIME.FormattedValue;
                    NewField111.CalcValue = "     " + MyParentReport.PARTB.ACTDEFINE.CalcValue + " işine ilişkin olarak ihale dokümanını oluşturan belgelerin aslına uygunluğu ve belgelerin tamam olup olmadığı aday  tarafından kontrol edilmiş ve  tamamı aslına uygun olarak, içeriğindeki  belgeleri  gösteren  bir  dizi  pusulasıyla  birlikte   teslim edilmiştir.\n\n İhale Dökümanı;";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField12,KIKTENDERREGISTERNO,NewField15,ACTDEFINE,YETERLIKLABEL1,NewField16,NewField17,NewField101,LOGO1111,NewField14,NewField18,NewField19,NewField20,NewField21,NewField22,SUPPLIERADDRESS,SUPPLIER,SALEDATE,SALERECEIPNO,DESCRIPTION,ANNEX,PURCHASETYPEDEFINITIONOBJECTID,DATE,TIME,TENDERDATE,NewField111,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin MyParentReport
                {
                    get { return (OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField PURCHASER;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField SELLERNAME;
                public TTReportField SELLERTITLE;
                public TTReportField NewField112;
                public TTReportField PROJECTNO; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 58;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 67, 10, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.Value = @"Dökümanı Satın Alan";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 5, 170, 10, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.Value = @"Teslim Eden";

                    PURCHASER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 67, 15, false);
                    PURCHASER.Name = "PURCHASER";
                    PURCHASER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASER.CaseFormat = CaseFormatEnum.fcNameSurname;
                    PURCHASER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURCHASER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASER.NoClip = EvetHayirEnum.ehEvet;
                    PURCHASER.TextFont.Name = "Arial";
                    PURCHASER.Value = @"{#PURCHASER#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 10, 170, 15, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.Value = @"İdare Yetkilisi";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 67, 20, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.Value = @"İmza";

                    SELLERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 15, 170, 20, false);
                    SELLERNAME.Name = "SELLERNAME";
                    SELLERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SELLERNAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    SELLERNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SELLERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SELLERNAME.NoClip = EvetHayirEnum.ehEvet;
                    SELLERNAME.TextFont.Name = "Arial";
                    SELLERNAME.Value = @"{#SELLERNAME#}";

                    SELLERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 20, 170, 25, false);
                    SELLERTITLE.Name = "SELLERTITLE";
                    SELLERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SELLERTITLE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SELLERTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SELLERTITLE.NoClip = EvetHayirEnum.ehEvet;
                    SELLERTITLE.ObjectDefName = "UserTitleEnum";
                    SELLERTITLE.DataMember = "DISPLAYTEXT";
                    SELLERTITLE.TextFont.Name = "Arial";
                    SELLERTITLE.Value = @"{#SELLERTITLE#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 25, 170, 30, false);
                    NewField112.Name = "NewField112";
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.Value = @"İmza";

                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 48, 25, 53, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class dataset_GetDocumentSoldFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    PURCHASER.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Purchaser) : "");
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    SELLERNAME.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Sellername) : "");
                    SELLERTITLE.CalcValue = (dataset_GetDocumentSoldFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetDocumentSoldFirmsByProjectObjectID.Sellertitle) : "");
                    SELLERTITLE.PostFieldValueCalculation();
                    NewField112.CalcValue = NewField112.Value;
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { NewField121,NewField131,PURCHASER,NewField151,NewField161,SELLERNAME,SELLERTITLE,NewField112,PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin MyParentReport
            {
                get { return (OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MANDATORY { get {return Body().MANDATORY;} }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField MANDATORYTEXT { get {return Body().MANDATORYTEXT;} }
            public TTReportField DOCUMENTNAME { get {return Body().DOCUMENTNAME;} }
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
                list[0] = new TTReportNqlData<FirmDocument.GetNeededProjectDocuments_Class>("GetNeededProjectDocuments", FirmDocument.GetNeededProjectDocuments((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTB.PURCHASETYPEDEFINITIONOBJECTID.CalcValue)));
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
                public OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin MyParentReport
                {
                    get { return (OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin)ParentReport; }
                }
                
                public TTReportField MANDATORY;
                public TTReportField COUNTER;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField MANDATORYTEXT;
                public TTReportField DOCUMENTNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    MANDATORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 197, 5, false);
                    MANDATORY.Name = "MANDATORY";
                    MANDATORY.Visible = EvetHayirEnum.ehHayir;
                    MANDATORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    MANDATORY.TextFont.Name = "Arial";
                    MANDATORY.TextFont.Size = 11;
                    MANDATORY.Value = @"{#MANDATORY#}";

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 4, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.Name = "Arial";
                    COUNTER.Value = @"{@groupcounter@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 7, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.Value = @")";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 73, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.Visible = EvetHayirEnum.ehHayir;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.Value = @"-";

                    MANDATORYTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 120, 5, false);
                    MANDATORYTEXT.Name = "MANDATORYTEXT";
                    MANDATORYTEXT.Visible = EvetHayirEnum.ehHayir;
                    MANDATORYTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MANDATORYTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MANDATORYTEXT.TextFont.Name = "Arial";
                    MANDATORYTEXT.Value = @"";

                    DOCUMENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 57, 5, false);
                    DOCUMENTNAME.Name = "DOCUMENTNAME";
                    DOCUMENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    DOCUMENTNAME.TextFont.Name = "Arial";
                    DOCUMENTNAME.Value = @"{#DOCUMENTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FirmDocument.GetNeededProjectDocuments_Class dataset_GetNeededProjectDocuments = ParentGroup.rsGroup.GetCurrentRecord<FirmDocument.GetNeededProjectDocuments_Class>(0);
                    MANDATORY.CalcValue = (dataset_GetNeededProjectDocuments != null ? Globals.ToStringCore(dataset_GetNeededProjectDocuments.Mandatory) : "");
                    COUNTER.CalcValue = ParentGroup.GroupCounter.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    MANDATORYTEXT.CalcValue = @"";
                    DOCUMENTNAME.CalcValue = (dataset_GetNeededProjectDocuments != null ? Globals.ToStringCore(dataset_GetNeededProjectDocuments.DocumentName) : "");
                    return new TTReportObject[] { MANDATORY,COUNTER,NewField1,NewField2,MANDATORYTEXT,DOCUMENTNAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MANDATORY.CalcValue == "TRUE")
                MANDATORYTEXT.CalcValue = "Zorunlu";
            else
                MANDATORYTEXT.CalcValue = "Zorunlu Değil";
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

        public OnYeterlilikIhaleDokumanininSatinAlindiginaIliskin()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ONYETERLILIKIHALEDOKUMANININSATINALINDIGINAILISKIN";
            Caption = "Ön Yeterlik / İhale Dökümanının Satın Alındığına İlişkin Form_KİK005.0/M";
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