
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
    /// Tıbbi/Tehlikeli Atık Raporu
    /// </summary>
    public partial class MedicalWasteListReport : TTReport
    {
#region Methods
   public int appointmentCount =  0;
  public double materialsum = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string RESOURCEID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string MEDICALWASTETYPEID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public MedicalWasteListReport MyParentReport
            {
                get { return (MedicalWasteListReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField LBL_ADSOYADI { get {return Header().LBL_ADSOYADI;} }
            public TTReportField LBL_TARIH { get {return Header().LBL_TARIH;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField LABELK { get {return Header().LABELK;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField LBL_NOT { get {return Header().LBL_NOT;} }
            public TTReportField LBL_TARIH2 { get {return Header().LBL_TARIH2;} }
            public TTReportField TARIH2 { get {return Header().TARIH2;} }
            public TTReportField BIRIMLBL { get {return Header().BIRIMLBL;} }
            public TTReportField BIRIM { get {return Header().BIRIM;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField182 { get {return Header().NewField182;} }
            public TTReportField BASLTARIH { get {return Header().BASLTARIH;} }
            public TTReportField BTSTARIH { get {return Header().BTSTARIH;} }
            public TTReportField LBL_ADSOYADI1 { get {return Header().LBL_ADSOYADI1;} }
            public TTReportField LBL_ADSOYADI11 { get {return Header().LBL_ADSOYADI11;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField REPORTHEADER1111 { get {return Header().REPORTHEADER1111;} }
            public TTReportField TARIH12 { get {return Header().TARIH12;} }
            public TTReportField NewField1281 { get {return Header().NewField1281;} }
            public TTReportField ATIKTURU { get {return Header().ATIKTURU;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
            public TTReportField SUM { get {return Footer().SUM;} }
            public TTReportField Toplam_Miktar { get {return Footer().Toplam_Miktar;} }
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
                public MedicalWasteListReport MyParentReport
                {
                    get { return (MedicalWasteListReport)ParentReport; }
                }
                
                public TTReportField LBL_ADSOYADI;
                public TTReportField LBL_TARIH;
                public TTReportShape NewLine1;
                public TTReportField LABELK;
                public TTReportField TARIH1;
                public TTReportField NewField18;
                public TTReportField LBL_NOT;
                public TTReportField LBL_TARIH2;
                public TTReportField TARIH2;
                public TTReportField BIRIMLBL;
                public TTReportField BIRIM;
                public TTReportField NewField181;
                public TTReportField NewField182;
                public TTReportField BASLTARIH;
                public TTReportField BTSTARIH;
                public TTReportField LBL_ADSOYADI1;
                public TTReportField LBL_ADSOYADI11;
                public TTReportField LOGO1;
                public TTReportField XXXXXXBASLIK111;
                public TTReportField REPORTHEADER1111;
                public TTReportField TARIH12;
                public TTReportField NewField1281;
                public TTReportField ATIKTURU; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 76;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 69, 135, 73, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI.TextFont.Size = 8;
                    LBL_ADSOYADI.TextFont.Bold = true;
                    LBL_ADSOYADI.Value = @"Ürün Adı";

                    LBL_TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 69, 51, 73, false);
                    LBL_TARIH.Name = "LBL_TARIH";
                    LBL_TARIH.TextFont.Name = "Arial Narrow";
                    LBL_TARIH.TextFont.Size = 8;
                    LBL_TARIH.TextFont.Bold = true;
                    LBL_TARIH.Value = @"İşlem Tarihi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 75, 290, 75, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine1.DrawWidth = 2;

                    LABELK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 69, 88, 73, false);
                    LABELK.Name = "LABELK";
                    LABELK.TextFont.Name = "Arial Narrow";
                    LABELK.TextFont.Size = 8;
                    LABELK.TextFont.Bold = true;
                    LABELK.Value = @"Atık Tipi";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 54, 30, 58, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.TextFont.Name = "Arial Narrow";
                    TARIH1.TextFont.Size = 8;
                    TARIH1.TextFont.Bold = true;
                    TARIH1.Value = @"Başlangıç Tarihi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 54, 33, 58, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 8;
                    NewField18.Value = @":";

                    LBL_NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 69, 289, 73, false);
                    LBL_NOT.Name = "LBL_NOT";
                    LBL_NOT.TextFont.Name = "Arial Narrow";
                    LBL_NOT.TextFont.Size = 8;
                    LBL_NOT.TextFont.Bold = true;
                    LBL_NOT.Value = @"Miktar";

                    LBL_TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 69, 16, 73, false);
                    LBL_TARIH2.Name = "LBL_TARIH2";
                    LBL_TARIH2.TextFont.Name = "Arial Narrow";
                    LBL_TARIH2.TextFont.Size = 8;
                    LBL_TARIH2.TextFont.Bold = true;
                    LBL_TARIH2.Value = @"Sıra";

                    TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 58, 30, 62, false);
                    TARIH2.Name = "TARIH2";
                    TARIH2.TextFont.Name = "Arial Narrow";
                    TARIH2.TextFont.Size = 8;
                    TARIH2.TextFont.Bold = true;
                    TARIH2.Value = @"Bitiş Tarihi";

                    BIRIMLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 50, 30, 54, false);
                    BIRIMLBL.Name = "BIRIMLBL";
                    BIRIMLBL.TextFont.Name = "Arial Narrow";
                    BIRIMLBL.TextFont.Size = 8;
                    BIRIMLBL.TextFont.Bold = true;
                    BIRIMLBL.Value = @"Birim";

                    BIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 50, 112, 54, false);
                    BIRIM.Name = "BIRIM";
                    BIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIM.NoClip = EvetHayirEnum.ehEvet;
                    BIRIM.TextFont.Name = "Arial Narrow";
                    BIRIM.TextFont.Size = 8;
                    BIRIM.Value = @"{@RESOURCEID@}";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 50, 33, 54, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.Size = 8;
                    NewField181.Value = @":";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 58, 33, 62, false);
                    NewField182.Name = "NewField182";
                    NewField182.TextFont.Name = "Arial Narrow";
                    NewField182.TextFont.Size = 8;
                    NewField182.Value = @":";

                    BASLTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 55, 112, 59, false);
                    BASLTARIH.Name = "BASLTARIH";
                    BASLTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLTARIH.NoClip = EvetHayirEnum.ehEvet;
                    BASLTARIH.TextFont.Name = "Arial Narrow";
                    BASLTARIH.TextFont.Size = 8;
                    BASLTARIH.Value = @"{@STARTDATE@}";

                    BTSTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 59, 112, 63, false);
                    BTSTARIH.Name = "BTSTARIH";
                    BTSTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    BTSTARIH.NoClip = EvetHayirEnum.ehEvet;
                    BTSTARIH.TextFont.Name = "Arial Narrow";
                    BTSTARIH.TextFont.Size = 8;
                    BTSTARIH.Value = @"{@ENDDATE@}";

                    LBL_ADSOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 69, 210, 73, false);
                    LBL_ADSOYADI1.Name = "LBL_ADSOYADI1";
                    LBL_ADSOYADI1.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI1.TextFont.Size = 8;
                    LBL_ADSOYADI1.TextFont.Bold = true;
                    LBL_ADSOYADI1.Value = @"Birim Adı";

                    LBL_ADSOYADI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 69, 257, 73, false);
                    LBL_ADSOYADI11.Name = "LBL_ADSOYADI11";
                    LBL_ADSOYADI11.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI11.TextFont.Size = 8;
                    LBL_ADSOYADI11.TextFont.Bold = true;
                    LBL_ADSOYADI11.Value = @"Teslim Tarihi";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 38, 27, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO1.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO1.DataMember = "EMBLEM";
                    LOGO1.Value = @"";

                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 6, 230, 41, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK111.TextFont.Size = 14;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 42, 216, 48, false);
                    REPORTHEADER1111.Name = "REPORTHEADER1111";
                    REPORTHEADER1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1111.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1111.TextFont.Size = 12;
                    REPORTHEADER1111.TextFont.Bold = true;
                    REPORTHEADER1111.Value = @"Atık Listesi";

                    TARIH12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 62, 30, 66, false);
                    TARIH12.Name = "TARIH12";
                    TARIH12.TextFont.Name = "Arial Narrow";
                    TARIH12.TextFont.Size = 8;
                    TARIH12.TextFont.Bold = true;
                    TARIH12.Value = @"Atık Türü";

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 62, 33, 66, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.TextFont.Name = "Arial Narrow";
                    NewField1281.TextFont.Size = 8;
                    NewField1281.Value = @":";

                    ATIKTURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 63, 112, 67, false);
                    ATIKTURU.Name = "ATIKTURU";
                    ATIKTURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATIKTURU.NoClip = EvetHayirEnum.ehEvet;
                    ATIKTURU.TextFont.Name = "Arial Narrow";
                    ATIKTURU.TextFont.Size = 8;
                    ATIKTURU.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_ADSOYADI.CalcValue = LBL_ADSOYADI.Value;
                    LBL_TARIH.CalcValue = LBL_TARIH.Value;
                    LABELK.CalcValue = LABELK.Value;
                    TARIH1.CalcValue = TARIH1.Value;
                    NewField18.CalcValue = NewField18.Value;
                    LBL_NOT.CalcValue = LBL_NOT.Value;
                    LBL_TARIH2.CalcValue = LBL_TARIH2.Value;
                    TARIH2.CalcValue = TARIH2.Value;
                    BIRIMLBL.CalcValue = BIRIMLBL.Value;
                    BIRIM.CalcValue = MyParentReport.RuntimeParameters.RESOURCEID.ToString();
                    NewField181.CalcValue = NewField181.Value;
                    NewField182.CalcValue = NewField182.Value;
                    BASLTARIH.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    BTSTARIH.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    LBL_ADSOYADI1.CalcValue = LBL_ADSOYADI1.Value;
                    LBL_ADSOYADI11.CalcValue = LBL_ADSOYADI11.Value;
                    LOGO1.CalcValue = @"";
                    REPORTHEADER1111.CalcValue = REPORTHEADER1111.Value;
                    TARIH12.CalcValue = TARIH12.Value;
                    NewField1281.CalcValue = NewField1281.Value;
                    ATIKTURU.CalcValue = @"";
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LBL_ADSOYADI,LBL_TARIH,LABELK,TARIH1,NewField18,LBL_NOT,LBL_TARIH2,TARIH2,BIRIMLBL,BIRIM,NewField181,NewField182,BASLTARIH,BTSTARIH,LBL_ADSOYADI1,LBL_ADSOYADI11,LOGO1,REPORTHEADER1111,TARIH12,NewField1281,ATIKTURU,XXXXXXBASLIK111};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    using (var objectContext = new TTObjectContext(true))
                    {
                        if (new Guid(this.MyParentReport.RuntimeParameters.RESOURCEID) != Guid.Empty)
                            this.BIRIM.CalcValue = objectContext.GetObject<ResSection>(new Guid(this.MyParentReport.RuntimeParameters.RESOURCEID)).Name;
                        else
                            this.BIRIM.CalcValue = "Tüm Birimler";

                        if (new Guid(this.MyParentReport.RuntimeParameters.MEDICALWASTETYPEID) != Guid.Empty)
                            this.ATIKTURU.CalcValue = objectContext.GetObject<MedicalWasteTypeDefinition>(new Guid(this.MyParentReport.RuntimeParameters.MEDICALWASTETYPEID)).Name;
                        else
                            this.ATIKTURU.CalcValue = "Tümü";
                    }
                    this.LOGO1.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public MedicalWasteListReport MyParentReport
                {
                    get { return (MedicalWasteListReport)ParentReport; }
                }
                
                public TTReportShape NewLine2;
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER;
                public TTReportField USERNAME;
                public TTReportField SUM;
                public TTReportField Toplam_Miktar; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 290, 1, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine2.DrawWidth = 2;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 145, 6, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.TextFont.Size = 8;
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 7, 289, 11, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.Name = "Arial Narrow";
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 57, 11, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Name = "Arial Narrow";
                    USERNAME.TextFont.Size = 8;
                    USERNAME.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    SUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 2, 289, 6, false);
                    SUM.Name = "SUM";
                    SUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUM.TextFont.Name = "Arial Narrow";
                    SUM.TextFont.Size = 8;
                    SUM.Value = @"MyParentReport.materialsum.ToString()";

                    Toplam_Miktar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 2, 240, 6, false);
                    Toplam_Miktar.Name = "Toplam_Miktar";
                    Toplam_Miktar.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Toplam_Miktar.TextFont.Name = "Arial Narrow";
                    Toplam_Miktar.TextFont.Size = 8;
                    Toplam_Miktar.Value = @"Toplam Miktar : ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    USERNAME.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString() + @" - " + MyParentReport.HEADER.USERNAME.CalcValue;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    Toplam_Miktar.CalcValue = Toplam_Miktar.Value;
                    SUM.CalcValue = MyParentReport.materialsum.ToString();
                    return new TTReportObject[] { USERNAME,PRINTDATE,PAGENUMBER,Toplam_Miktar,SUM};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public MedicalWasteListReport MyParentReport
            {
                get { return (MedicalWasteListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField WASTEPRODUCE { get {return Body().WASTEPRODUCE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField WASTETYPE { get {return Body().WASTETYPE;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField RESSECTION { get {return Body().RESSECTION;} }
            public TTReportField DELIVERYDATE { get {return Body().DELIVERYDATE;} }
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
                list[0] = new TTReportNqlData<MedicalWaste.GetMedicalWasteWithParam_Class>("GetMedicalWasteWithParam", MedicalWaste.GetMedicalWasteWithParam((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.RESOURCEID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MEDICALWASTETYPEID)));
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
                public MedicalWasteListReport MyParentReport
                {
                    get { return (MedicalWasteListReport)ParentReport; }
                }
                
                public TTReportField WASTEPRODUCE;
                public TTReportField AMOUNT;
                public TTReportField COUNT;
                public TTReportField OBJECTID;
                public TTReportField WASTETYPE;
                public TTReportField TARIH;
                public TTReportField RESSECTION;
                public TTReportField DELIVERYDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    WASTEPRODUCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 135, 4, false);
                    WASTEPRODUCE.Name = "WASTEPRODUCE";
                    WASTEPRODUCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WASTEPRODUCE.MultiLine = EvetHayirEnum.ehEvet;
                    WASTEPRODUCE.NoClip = EvetHayirEnum.ehEvet;
                    WASTEPRODUCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    WASTEPRODUCE.TextFont.Name = "Arial Narrow";
                    WASTEPRODUCE.TextFont.Size = 8;
                    WASTEPRODUCE.Value = @"{#MEDICALWASTEPRODUCE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 289, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.NoClip = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 15, 4, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.NoClip = EvetHayirEnum.ehEvet;
                    COUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial Narrow";
                    COUNT.TextFont.Size = 8;
                    COUNT.Value = @"{@counter@}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 331, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID.NoClip = EvetHayirEnum.ehEvet;
                    OBJECTID.ExpandTabs = EvetHayirEnum.ehEvet;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    WASTETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 88, 4, false);
                    WASTETYPE.Name = "WASTETYPE";
                    WASTETYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WASTETYPE.NoClip = EvetHayirEnum.ehEvet;
                    WASTETYPE.TextFont.Name = "Arial Narrow";
                    WASTETYPE.TextFont.Size = 8;
                    WASTETYPE.Value = @"{#MEDICALWASTETYPE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 51, 4, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 8;
                    TARIH.Value = @"{#TRANSACTIONDATE#}";

                    RESSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, -1, 210, 4, false);
                    RESSECTION.Name = "RESSECTION";
                    RESSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESSECTION.TextFont.Name = "Arial Narrow";
                    RESSECTION.TextFont.CharSet = 1;
                    RESSECTION.Value = @"{#RESSECTION#}";

                    DELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, -1, 257, 4, false);
                    DELIVERYDATE.Name = "DELIVERYDATE";
                    DELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERYDATE.TextFont.Name = "Arial Narrow";
                    DELIVERYDATE.TextFont.CharSet = 1;
                    DELIVERYDATE.Value = @"{#DELIVERYDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MedicalWaste.GetMedicalWasteWithParam_Class dataset_GetMedicalWasteWithParam = ParentGroup.rsGroup.GetCurrentRecord<MedicalWaste.GetMedicalWasteWithParam_Class>(0);
                    WASTEPRODUCE.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.Medicalwasteproduce) : "");
                    AMOUNT.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.Amount) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    OBJECTID.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.ObjectID) : "");
                    WASTETYPE.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.Medicalwastetype) : "");
                    TARIH.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.TransactionDate) : "");
                    RESSECTION.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.Ressection) : "");
                    DELIVERYDATE.CalcValue = (dataset_GetMedicalWasteWithParam != null ? Globals.ToStringCore(dataset_GetMedicalWasteWithParam.DeliveryDate) : "");
                    return new TTReportObject[] { WASTEPRODUCE,AMOUNT,COUNT,OBJECTID,WASTETYPE,TARIH,RESSECTION,DELIVERYDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.AMOUNT.CalcValue != "")
                    MyParentReport.materialsum += double.Parse(this.AMOUNT.CalcValue);
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

        public MedicalWasteListReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("RESOURCEID", "", "Birim", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("MEDICALWASTETYPEID", "", "Atık Türü", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("RESOURCEID"))
                _runtimeParameters.RESOURCEID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["RESOURCEID"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("MEDICALWASTETYPEID"))
                _runtimeParameters.MEDICALWASTETYPEID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MEDICALWASTETYPEID"]);
            Name = "MEDICALWASTELISTREPORT";
            Caption = "Tıbbi/Tehlikeli Atık Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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