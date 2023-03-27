
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
    /// Çift Sıfırlı Kart Durumuna Düşen Kartlar Raporu
    /// </summary>
    public partial class DoubleZeroCardStatus : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MAINCLASSID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DoubleZeroCardStatus MyParentReport
            {
                get { return (DoubleZeroCardStatus)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public DoubleZeroCardStatus MyParentReport
                {
                    get { return (DoubleZeroCardStatus)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 7, 170, 27, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"DEVİR ÇİZELGESİNDE YER ALMAMIŞ ÇİFT SIFIRLI STOK KAYIT VE DEĞİŞ STOK KAYIT KARTLARINDAN SAYMANDAN ALINARAK TEFTİŞ SANDIĞINA KOYULAN KARTLARI / ANA STOK KÜTÜĞÜNDEN (ASK) ATILAN ÇİFT SIFIRLI STOK KAYITLARI KARTLARI / ENVANTERDEN ÇIKARILAN MALZEMELERE AİT STOK KAYIT KARTLARINI GÖSTERİR ÇİZELGE";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"EK-26A";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { REPORTNAME,NewField1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DoubleZeroCardStatus MyParentReport
                {
                    get { return (DoubleZeroCardStatus)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 100, 5, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.Bold = true;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"EK-26A-{@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"EK-26A-" + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public DoubleZeroCardStatus MyParentReport
            {
                get { return (DoubleZeroCardStatus)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField COLUMNNAME1111 { get {return Header().COLUMNNAME1111;} }
            public TTReportField COLUMNNAME112 { get {return Header().COLUMNNAME112;} }
            public TTReportField COLUMNNAME1112 { get {return Header().COLUMNNAME1112;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField TOTAL1 { get {return Footer().TOTAL1;} }
            public TTReportField ACCOUNTANCY { get {return Footer().ACCOUNTANCY;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public DoubleZeroCardStatus MyParentReport
                {
                    get { return (DoubleZeroCardStatus)ParentReport; }
                }
                
                public TTReportField COLUMNNAME11;
                public TTReportField COLUMNNAME111;
                public TTReportShape NewLine1;
                public TTReportField COLUMNNAME1111;
                public TTReportField COLUMNNAME112;
                public TTReportField COLUMNNAME1112;
                public TTReportShape NewLine12;
                public TTReportField NewField1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportShape NewLine121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 63;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 9, 60, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.FontAngle = 900;
                    COLUMNNAME11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME11.TextFont.Name = "Arial";
                    COLUMNNAME11.TextFont.Size = 11;
                    COLUMNNAME11.TextFont.Bold = true;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"  BİR ÖNCEKİ YILIN DEVİR";

                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 14, 60, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.FontAngle = 900;
                    COLUMNNAME111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME111.TextFont.Name = "Arial";
                    COLUMNNAME111.TextFont.Size = 11;
                    COLUMNNAME111.TextFont.Bold = true;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"ÇİZELGESİNDEKİ SIRA NU.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 0, 18, 60, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    COLUMNNAME1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 29, 60, false);
                    COLUMNNAME1111.Name = "COLUMNNAME1111";
                    COLUMNNAME1111.FontAngle = 900;
                    COLUMNNAME1111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME1111.TextFont.Name = "Arial";
                    COLUMNNAME1111.TextFont.Size = 11;
                    COLUMNNAME1111.TextFont.Bold = true;
                    COLUMNNAME1111.TextFont.CharSet = 162;
                    COLUMNNAME1111.Value = @"                SIRA NU.";

                    COLUMNNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 161, 60, false);
                    COLUMNNAME112.Name = "COLUMNNAME112";
                    COLUMNNAME112.FontAngle = 900;
                    COLUMNNAME112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME112.TextFont.Name = "Arial";
                    COLUMNNAME112.TextFont.Size = 11;
                    COLUMNNAME112.TextFont.Bold = true;
                    COLUMNNAME112.TextFont.CharSet = 162;
                    COLUMNNAME112.Value = @"AKORDİYON DURUMDA İSE";

                    COLUMNNAME1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 166, 60, false);
                    COLUMNNAME1112.Name = "COLUMNNAME1112";
                    COLUMNNAME1112.FontAngle = 900;
                    COLUMNNAME1112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COLUMNNAME1112.TextFont.Name = "Arial";
                    COLUMNNAME1112.TextFont.Size = 11;
                    COLUMNNAME1112.TextFont.Bold = true;
                    COLUMNNAME1112.TextFont.CharSet = 162;
                    COLUMNNAME1112.Value = @"                  ADEDİ";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 60, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 152, 60, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"




STOK KAYIT KARTININ AİT OLDUĞU MALIN
STOK NUMARASI VE ADI";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 60, 170, 60, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 60, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    COLUMNNAME1111.CalcValue = COLUMNNAME1111.Value;
                    COLUMNNAME112.CalcValue = COLUMNNAME112.Value;
                    COLUMNNAME1112.CalcValue = COLUMNNAME1112.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { COLUMNNAME11,COLUMNNAME111,COLUMNNAME1111,COLUMNNAME112,COLUMNNAME1112,NewField1};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DoubleZeroCardStatus MyParentReport
                {
                    get { return (DoubleZeroCardStatus)ParentReport; }
                }
                
                public TTReportField TOTAL1;
                public TTReportField ACCOUNTANCY;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField NewField2; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 69;
                    RepeatCount = 0;
                    
                    TOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 171, 21, false);
                    TOTAL1.Name = "TOTAL1";
                    TOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL1.MultiLine = EvetHayirEnum.ehEvet;
                    TOTAL1.WordBreak = EvetHayirEnum.ehEvet;
                    TOTAL1.TextFont.Name = "Arial";
                    TOTAL1.TextFont.CharSet = 162;
                    TOTAL1.Value = @"";

                    ACCOUNTANCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 1, 241, 6, false);
                    ACCOUNTANCY.Name = "ACCOUNTANCY";
                    ACCOUNTANCY.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCY.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCY.DataMember = "ACCOUNTANCY.NAME";
                    ACCOUNTANCY.Value = @"{@TERMID@}";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 6, 241, 11, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUBGROUPCOUNT.Value = @"{@subgroupcount@} != ""-1"" ? {@subgroupcount@} : ""0""";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 21, 171, 30, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @" 2. Envanter kayıtları bilgisayarda tutulan saymanlıkların Ana Stok Kütüğü (ASK)'nden atılan ÇİFT SIFIRLI kayıtlara ilişkin sandığa herhangi bir kart koyulmamaktadır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTAL1.CalcValue = @"";
                    ACCOUNTANCY.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ACCOUNTANCY.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    SUBGROUPCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString() != "-1" ? (ParentGroup.SubGroupCount - 1).ToString() : "0";
                    return new TTReportObject[] { TOTAL1,ACCOUNTANCY,NewField2,SUBGROUPCOUNT};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(((DoubleZeroCardStatus)ParentReport).RuntimeParameters.TERMID.ToString()), typeof(AccountingTerm));
                    TOTAL1.CalcValue = " 1. Yukarıda stok numarası ve cinsi yazılan toplam " + SUBGROUPCOUNT.CalcValue + " kalem " + PARTBGroup.totalAccordionAmount.ToString()
                        + " adet ÇİFT SIFIRLI ve DEĞİŞ stok kayıt kartları " + ACCOUNTANCY.CalcValue + " saymanlığının " + Convert.ToDateTime(term.EndDate).Year.ToString()
                        + " bütçe / takvim yılı teftişinde saymandan alınarak teftiş sandığına koyulmuştur.";
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static int totalAccordionAmount = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DoubleZeroCardStatus MyParentReport
            {
                get { return (DoubleZeroCardStatus)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NEWORDERNO { get {return Body().NEWORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField ACCORDIONAMOUNT { get {return Body().ACCORDIONAMOUNT;} }
            public TTReportField OLDORDERNO { get {return Body().OLDORDERNO;} }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField CARDCOUNT { get {return Body().CARDCOUNT;} }
            public TTReportField MATERIALID { get {return Body().MATERIALID;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
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
                list[0] = new TTReportNqlData<DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class>("GetDoubleZeroCardCensusReportQuery", DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MAINCLASSID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
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
                public DoubleZeroCardStatus MyParentReport
                {
                    get { return (DoubleZeroCardStatus)ParentReport; }
                }
                
                public TTReportField NEWORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField ACCORDIONAMOUNT;
                public TTReportField OLDORDERNO;
                public TTReportField STATUS;
                public TTReportField CARDCOUNT;
                public TTReportField MATERIALID;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    NEWORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 35, 5, false);
                    NEWORDERNO.Name = "NEWORDERNO";
                    NEWORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWORDERNO.TextFont.Name = "Arial";
                    NEWORDERNO.TextFont.CharSet = 162;
                    NEWORDERNO.Value = @"{#CARDORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 152, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#NATOSTOCKNO#} - {#MATERIALNAME#}";

                    ACCORDIONAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 170, 5, false);
                    ACCORDIONAMOUNT.Name = "ACCORDIONAMOUNT";
                    ACCORDIONAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    ACCORDIONAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCORDIONAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ACCORDIONAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCORDIONAMOUNT.TextFont.Name = "Arial";
                    ACCORDIONAMOUNT.TextFont.CharSet = 162;
                    ACCORDIONAMOUNT.Value = @"";

                    OLDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 18, 5, false);
                    OLDORDERNO.Name = "OLDORDERNO";
                    OLDORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDORDERNO.TextFont.Name = "Arial";
                    OLDORDERNO.TextFont.CharSet = 162;
                    OLDORDERNO.Value = @"";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 228, 5, false);
                    STATUS.Name = "STATUS";
                    STATUS.Visible = EvetHayirEnum.ehHayir;
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.Value = @"{#STATUS#}";

                    CARDCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 251, 5, false);
                    CARDCOUNT.Name = "CARDCOUNT";
                    CARDCOUNT.Visible = EvetHayirEnum.ehHayir;
                    CARDCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDCOUNT.Value = @"{#CARDCOUNT#}";

                    MATERIALID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 272, 5, false);
                    MATERIALID.Name = "MATERIALID";
                    MATERIALID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALID.Value = @"{#MATERIALID#}";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class dataset_GetDoubleZeroCardCensusReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DoubleZeroCardEpoch.GetDoubleZeroCardCensusReportQuery_Class>(0);
                    NEWORDERNO.CalcValue = (dataset_GetDoubleZeroCardCensusReportQuery != null ? Globals.ToStringCore(dataset_GetDoubleZeroCardCensusReportQuery.CardOrderNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetDoubleZeroCardCensusReportQuery != null ? Globals.ToStringCore(dataset_GetDoubleZeroCardCensusReportQuery.NATOStockNO) : "") + @" - " + (dataset_GetDoubleZeroCardCensusReportQuery != null ? Globals.ToStringCore(dataset_GetDoubleZeroCardCensusReportQuery.Materialname) : "");
                    ACCORDIONAMOUNT.CalcValue = @"";
                    OLDORDERNO.CalcValue = @"";
                    STATUS.CalcValue = (dataset_GetDoubleZeroCardCensusReportQuery != null ? Globals.ToStringCore(dataset_GetDoubleZeroCardCensusReportQuery.Status) : "");
                    CARDCOUNT.CalcValue = (dataset_GetDoubleZeroCardCensusReportQuery != null ? Globals.ToStringCore(dataset_GetDoubleZeroCardCensusReportQuery.CardCount) : "");
                    MATERIALID.CalcValue = (dataset_GetDoubleZeroCardCensusReportQuery != null ? Globals.ToStringCore(dataset_GetDoubleZeroCardCensusReportQuery.Materialid) : "");
                    return new TTReportObject[] { NEWORDERNO,MATERIALNAME,ACCORDIONAMOUNT,OLDORDERNO,STATUS,CARDCOUNT,MATERIALID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (STATUS.CalcValue == "AccordionCard")
                    {
                        ACCORDIONAMOUNT.CalcValue = CARDCOUNT.CalcValue;
                        PARTBGroup.totalAccordionAmount = PARTBGroup.totalAccordionAmount + Convert.ToInt32(CARDCOUNT.CalcValue);
                    }

                    TTObjectContext ctx = new TTObjectContext(true);
                    string termID = ((DoubleZeroCardStatus)ParentReport).RuntimeParameters.TERMID.ToString();
                    AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
                    if (term != null)
                    {
                        BindingList<DoubleZeroCardEpoch.GetOldOrderNoQuery_Class> orderNOList = DoubleZeroCardEpoch.GetOldOrderNoQuery(ctx, Convert.ToDateTime(term.EndDate).Year, new Guid(MATERIALID.CalcValue));
                        OLDORDERNO.CalcValue = orderNOList[0].CardOrderNO.ToString();
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

        public DoubleZeroCardStatus()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MAINCLASSID", "00000000-0000-0000-0000-000000000000", "Stok Kart Sınıfı Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("b264545a-a5a3-4615-9e64-f45a354ec864");
            reportParameter.ListFilterExpression = "PARENTSTOCKCARDCLASS IS NULL";
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MAINCLASSID"))
                _runtimeParameters.MAINCLASSID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MAINCLASSID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            Name = "DOUBLEZEROCARDSTATUS";
            Caption = "Çift Sıfırlı Kart Durumuna Düşen Kartlar Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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