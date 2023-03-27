
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
    /// Kısım İhtiyaç Belgesi Raporu
    /// </summary>
    public partial class SectionRequirementReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public SectionRequirementReport MyParentReport
            {
                get { return (SectionRequirementReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField CHIEF { get {return Footer().CHIEF;} }
            public TTReportField NewField20 { get {return Footer().NewField20;} }
            public TTReportField NewField21 { get {return Footer().NewField21;} }
            public TTReportField DEPOCU { get {return Footer().DEPOCU;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField MATERIALUSER { get {return Footer().MATERIALUSER;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField SECTIONCHIEF { get {return Footer().SECTIONCHIEF;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public SectionRequirementReport MyParentReport
                {
                    get { return (SectionRequirementReport)ParentReport; }
                }
                
                public TTReportField NewField3; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 14, 231, 24, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 15;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"KISIM İHTİYAÇ BELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField3};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SectionRequirementReport MyParentReport
                {
                    get { return (SectionRequirementReport)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField CHIEF;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField DEPOCU;
                public TTReportField ACCOUNTANT;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField MATERIALUSER;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField SECTIONCHIEF;
                public TTReportShape NewLine11;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 175, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.ForeColor = System.Drawing.Color.Gray;
                    NewField12.DrawStyle = DrawStyleConstants.vbDot;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BÖLÜM AMİRİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 14, 175, 25, false);
                    NewField13.Name = "NewField13";
                    NewField13.ForeColor = System.Drawing.Color.Gray;
                    NewField13.DrawStyle = DrawStyleConstants.vbDot;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 228, 5, false);
                    NewField16.Name = "NewField16";
                    NewField16.ForeColor = System.Drawing.Color.Gray;
                    NewField16.DrawStyle = DrawStyleConstants.vbDot;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"DEPOCU";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 14, 228, 25, false);
                    NewField17.Name = "NewField17";
                    NewField17.ForeColor = System.Drawing.Color.Gray;
                    NewField17.DrawStyle = DrawStyleConstants.vbDot;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.Value = @"";

                    CHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 5, 175, 14, false);
                    CHIEF.Name = "CHIEF";
                    CHIEF.ForeColor = System.Drawing.Color.Gray;
                    CHIEF.DrawStyle = DrawStyleConstants.vbDot;
                    CHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    CHIEF.WordBreak = EvetHayirEnum.ehEvet;
                    CHIEF.Value = @"";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 281, 5, false);
                    NewField20.Name = "NewField20";
                    NewField20.ForeColor = System.Drawing.Color.Gray;
                    NewField20.DrawStyle = DrawStyleConstants.vbDot;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"SAYMAN";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 14, 281, 25, false);
                    NewField21.Name = "NewField21";
                    NewField21.ForeColor = System.Drawing.Color.Gray;
                    NewField21.DrawStyle = DrawStyleConstants.vbDot;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.Value = @"";

                    DEPOCU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 5, 228, 14, false);
                    DEPOCU.Name = "DEPOCU";
                    DEPOCU.ForeColor = System.Drawing.Color.Gray;
                    DEPOCU.DrawStyle = DrawStyleConstants.vbDot;
                    DEPOCU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPOCU.MultiLine = EvetHayirEnum.ehEvet;
                    DEPOCU.WordBreak = EvetHayirEnum.ehEvet;
                    DEPOCU.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 5, 281, 14, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.ForeColor = System.Drawing.Color.Gray;
                    ACCOUNTANT.DrawStyle = DrawStyleConstants.vbDot;
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 69, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.ForeColor = System.Drawing.Color.Gray;
                    NewField121.DrawStyle = DrawStyleConstants.vbDot;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"MALZEMEYİ KULLANAN";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 14, 69, 25, false);
                    NewField131.Name = "NewField131";
                    NewField131.ForeColor = System.Drawing.Color.Gray;
                    NewField131.DrawStyle = DrawStyleConstants.vbDot;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.Value = @"";

                    MATERIALUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 5, 69, 14, false);
                    MATERIALUSER.Name = "MATERIALUSER";
                    MATERIALUSER.ForeColor = System.Drawing.Color.Gray;
                    MATERIALUSER.DrawStyle = DrawStyleConstants.vbDot;
                    MATERIALUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALUSER.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALUSER.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALUSER.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 122, 5, false);
                    NewField122.Name = "NewField122";
                    NewField122.ForeColor = System.Drawing.Color.Gray;
                    NewField122.DrawStyle = DrawStyleConstants.vbDot;
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"KISIM AMİRİ (TESLİM ALAN)";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 14, 122, 25, false);
                    NewField132.Name = "NewField132";
                    NewField132.ForeColor = System.Drawing.Color.Gray;
                    NewField132.DrawStyle = DrawStyleConstants.vbDot;
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.Value = @"";

                    SECTIONCHIEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 5, 122, 14, false);
                    SECTIONCHIEF.Name = "SECTIONCHIEF";
                    SECTIONCHIEF.ForeColor = System.Drawing.Color.Gray;
                    SECTIONCHIEF.DrawStyle = DrawStyleConstants.vbDot;
                    SECTIONCHIEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTIONCHIEF.MultiLine = EvetHayirEnum.ehEvet;
                    SECTIONCHIEF.WordBreak = EvetHayirEnum.ehEvet;
                    SECTIONCHIEF.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 25, 281, 25, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 0, 17, 25, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 281, 0, 281, 25, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 0, 281, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    CHIEF.CalcValue = @"";
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    DEPOCU.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    MATERIALUSER.CalcValue = @"";
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    SECTIONCHIEF.CalcValue = @"";
                    return new TTReportObject[] { NewField12,NewField13,NewField16,NewField17,CHIEF,NewField20,NewField21,DEPOCU,ACCOUNTANT,NewField121,NewField131,MATERIALUSER,NewField122,NewField132,SECTIONCHIEF};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    SectionRequirement sectionReq = (SectionRequirement)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), typeof(SectionRequirement));
            if(sectionReq.StockActionSignDetails.Count > 0)
            {                
                string signDesc;
                foreach(StockActionSignDetail signDetail in sectionReq.StockActionSignDetails)
                {
                    signDesc = string.Empty;
                    if (signDetail.IsDeputy.HasValue && signDetail.IsDeputy.Value == true)
                        signDesc += " Vek.";
                    
                    if(signDetail.SignUser != null)
                    {
                        signDesc += " " + signDetail.SignUser.Name + "\r\n ";
                        
                        if(signDetail.SignUser.MilitaryClass != null)
                            signDesc += signDetail.SignUser.MilitaryClass.ShortName;
                        
                        if(signDetail.SignUser.Rank != null)
                            signDesc += signDetail.SignUser.Rank.ShortName;
                        
                        signDesc += "(" + signDetail.SignUser.EmploymentRecordID + ")";
                        
                        switch (signDetail.SignUserType.Value)
                        {
                            case SignUserTypeEnum.MalzemeyiKullanan:
                                MATERIALUSER.CalcValue = signDesc;
                                break;
                                
                            case SignUserTypeEnum.KısımAmiri:
                                SECTIONCHIEF.CalcValue = signDesc;
                                break;
                                
                            case SignUserTypeEnum.BölümAmiri:
                                CHIEF.CalcValue = signDesc;
                                break;
                                
                            case SignUserTypeEnum.MalSorumlusu:
                                DEPOCU.CalcValue = signDesc;
                                break;
                                
                            case SignUserTypeEnum.MalSaymani:
                                ACCOUNTANT.CalcValue = signDesc;
                                break;
                        }
                    }
                }
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public SectionRequirementReport MyParentReport
            {
                get { return (SectionRequirementReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField NewField28 { get {return Header().NewField28;} }
            public TTReportField NewField30 { get {return Header().NewField30;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField PAGECOUNT { get {return Header().PAGECOUNT;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField ORDERNAME { get {return Header().ORDERNAME;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField ORDERAMOUNT { get {return Header().ORDERAMOUNT;} }
            public TTReportField NewField163 { get {return Header().NewField163;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportField DESTINATIONSTORE { get {return Header().DESTINATIONSTORE;} }
            public TTReportField REGISTRATIONNUMBER { get {return Header().REGISTRATIONNUMBER;} }
            public TTReportField TRANSACTIONDATE { get {return Header().TRANSACTIONDATE;} }
            public TTReportField REGISTRATIONNUMBER1 { get {return Header().REGISTRATIONNUMBER1;} }
            public TTReportField SEQUENCENUMBER1 { get {return Header().SEQUENCENUMBER1;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField103 { get {return Header().NewField103;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField115 { get {return Header().NewField115;} }
            public TTReportField NewField116 { get {return Header().NewField116;} }
            public TTReportField NewField117 { get {return Header().NewField117;} }
            public TTReportField ITEMCOUNT { get {return Footer().ITEMCOUNT;} }
            public TTReportField ITEM { get {return Footer().ITEM;} }
            public TTReportField ITEMTEXT { get {return Footer().ITEMTEXT;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
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
                public SectionRequirementReport MyParentReport
                {
                    get { return (SectionRequirementReport)ParentReport; }
                }
                
                public TTReportField NewField24;
                public TTReportField REQUESTNO;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportField NewField30;
                public TTReportField NewField31;
                public TTReportField PAGECOUNT;
                public TTReportField NewField142;
                public TTReportField ORDERNAME;
                public TTReportField NewField162;
                public TTReportField NewField143;
                public TTReportField ORDERAMOUNT;
                public TTReportField NewField163;
                public TTReportField NewField144;
                public TTReportField DESTINATIONSTORE;
                public TTReportField REGISTRATIONNUMBER;
                public TTReportField TRANSACTIONDATE;
                public TTReportField REGISTRATIONNUMBER1;
                public TTReportField SEQUENCENUMBER1;
                public TTReportField NewField113;
                public TTReportField NewField103;
                public TTReportField NewField114;
                public TTReportField NewField115;
                public TTReportField NewField116;
                public TTReportField NewField117; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 69, 6, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.TextFont.Size = 11;
                    NewField24.TextFont.Bold = true;
                    NewField24.TextFont.CharSet = 162;
                    NewField24.Value = @"Sipariş Nu.";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 193, 6, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.ObjectDefName = "SectionRequirement";
                    REQUESTNO.DataMember = "CMRACTION.REQUESTNO";
                    REQUESTNO.TextFont.Size = 11;
                    REQUESTNO.TextFont.Bold = true;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{@TTOBJECTID@}";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 24, 32, 34, false);
                    NewField27.Name = "NewField27";
                    NewField27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField27.MultiLine = EvetHayirEnum.ehEvet;
                    NewField27.TextFont.Size = 11;
                    NewField27.TextFont.Bold = true;
                    NewField27.TextFont.CharSet = 162;
                    NewField27.Value = @"Belge
Kayıt Nu.";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 24, 144, 34, false);
                    NewField28.Name = "NewField28";
                    NewField28.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField28.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField28.TextFont.Size = 11;
                    NewField28.TextFont.Bold = true;
                    NewField28.TextFont.CharSet = 162;
                    NewField28.Value = @"Stok Nu. - Malın İsmi";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 24, 158, 34, false);
                    NewField30.Name = "NewField30";
                    NewField30.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField30.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField30.TextFont.Size = 11;
                    NewField30.TextFont.Bold = true;
                    NewField30.TextFont.CharSet = 162;
                    NewField30.Value = @"Birim";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 24, 178, 34, false);
                    NewField31.Name = "NewField31";
                    NewField31.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField31.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.MultiLine = EvetHayirEnum.ehEvet;
                    NewField31.TextFont.Size = 11;
                    NewField31.TextFont.Bold = true;
                    NewField31.TextFont.CharSet = 162;
                    NewField31.Value = @"İstenen
Miktar";

                    PAGECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 0, 281, 6, false);
                    PAGECOUNT.Name = "PAGECOUNT";
                    PAGECOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGECOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGECOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGECOUNT.TextFont.Size = 11;
                    PAGECOUNT.TextFont.Bold = true;
                    PAGECOUNT.TextFont.CharSet = 162;
                    PAGECOUNT.Value = @"Sayfa Nu. : {@pagenumber@}/{@pagecount@}";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 6, 69, 12, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Size = 11;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Siparişin Adı";

                    ORDERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 6, 193, 12, false);
                    ORDERNAME.Name = "ORDERNAME";
                    ORDERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME.ObjectDefName = "SectionRequirement";
                    ORDERNAME.DataMember = "ORDERNAME";
                    ORDERNAME.TextFont.Size = 11;
                    ORDERNAME.TextFont.Bold = true;
                    ORDERNAME.TextFont.CharSet = 162;
                    ORDERNAME.Value = @"{@TTOBJECTID@}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 6, 223, 12, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.TextFont.Size = 11;
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"Belge Kayıt Nu.";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 12, 69, 18, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField143.TextFont.Size = 11;
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Siparişin Miktarı";

                    ORDERAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 12, 193, 18, false);
                    ORDERAMOUNT.Name = "ORDERAMOUNT";
                    ORDERAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERAMOUNT.ObjectDefName = "SectionRequirement";
                    ORDERAMOUNT.DataMember = "ORDERAMOUNT";
                    ORDERAMOUNT.TextFont.Size = 11;
                    ORDERAMOUNT.TextFont.Bold = true;
                    ORDERAMOUNT.TextFont.CharSet = 162;
                    ORDERAMOUNT.Value = @"{@TTOBJECTID@}";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 12, 223, 18, false);
                    NewField163.Name = "NewField163";
                    NewField163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField163.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField163.TextFont.Size = 11;
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"İstek Tarihi";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 18, 69, 24, false);
                    NewField144.Name = "NewField144";
                    NewField144.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField144.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField144.TextFont.Size = 11;
                    NewField144.TextFont.Bold = true;
                    NewField144.TextFont.CharSet = 162;
                    NewField144.Value = @"Malzemeyi Kullanacak Kısım";

                    DESTINATIONSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 18, 281, 24, false);
                    DESTINATIONSTORE.Name = "DESTINATIONSTORE";
                    DESTINATIONSTORE.DrawStyle = DrawStyleConstants.vbSolid;
                    DESTINATIONSTORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESTINATIONSTORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESTINATIONSTORE.ObjectDefName = "SectionRequirement";
                    DESTINATIONSTORE.DataMember = "DESTINATIONSTORE.NAME";
                    DESTINATIONSTORE.TextFont.Size = 11;
                    DESTINATIONSTORE.TextFont.Bold = true;
                    DESTINATIONSTORE.TextFont.CharSet = 162;
                    DESTINATIONSTORE.Value = @"{@TTOBJECTID@}";

                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 6, 281, 12, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.TextFont.Size = 11;
                    REGISTRATIONNUMBER.TextFont.Bold = true;
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"{%REGISTRATIONNUMBER1%} - {%SEQUENCENUMBER1%}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 12, 281, 18, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    TRANSACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDATE.ObjectDefName = "SectionRequirement";
                    TRANSACTIONDATE.DataMember = "TRANSACTIONDATE";
                    TRANSACTIONDATE.TextFont.Size = 11;
                    TRANSACTIONDATE.TextFont.Bold = true;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{@TTOBJECTID@}";

                    REGISTRATIONNUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 5, 324, 10, false);
                    REGISTRATIONNUMBER1.Name = "REGISTRATIONNUMBER1";
                    REGISTRATIONNUMBER1.Visible = EvetHayirEnum.ehHayir;
                    REGISTRATIONNUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER1.ObjectDefName = "SectionRequirement";
                    REGISTRATIONNUMBER1.DataMember = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER1.Value = @"{@TTOBJECTID@}";

                    SEQUENCENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 14, 324, 19, false);
                    SEQUENCENUMBER1.Name = "SEQUENCENUMBER1";
                    SEQUENCENUMBER1.Visible = EvetHayirEnum.ehHayir;
                    SEQUENCENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEQUENCENUMBER1.ObjectDefName = "SectionRequirement";
                    SEQUENCENUMBER1.DataMember = "SEQUENCENUMBER";
                    SEQUENCENUMBER1.Value = @"{@TTOBJECTID@}";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 24, 198, 34, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Size = 11;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"Verilen
Miktar";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 24, 213, 34, false);
                    NewField103.Name = "NewField103";
                    NewField103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField103.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField103.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField103.TextFont.Size = 11;
                    NewField103.TextFont.Bold = true;
                    NewField103.TextFont.CharSet = 162;
                    NewField103.Value = @"S.G.";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 24, 230, 34, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114.TextFont.Size = 11;
                    NewField114.TextFont.Bold = true;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"Stk. Kart
İşlendi";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 24, 247, 34, false);
                    NewField115.Name = "NewField115";
                    NewField115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115.MultiLine = EvetHayirEnum.ehEvet;
                    NewField115.TextFont.Size = 11;
                    NewField115.TextFont.Bold = true;
                    NewField115.TextFont.CharSet = 162;
                    NewField115.Value = @"Ambar
Göz Nu.";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 24, 264, 34, false);
                    NewField116.Name = "NewField116";
                    NewField116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField116.MultiLine = EvetHayirEnum.ehEvet;
                    NewField116.TextFont.Size = 11;
                    NewField116.TextFont.Bold = true;
                    NewField116.TextFont.CharSet = 162;
                    NewField116.Value = @"Birim
Fiyatı";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 24, 281, 34, false);
                    NewField117.Name = "NewField117";
                    NewField117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117.TextFont.Size = 11;
                    NewField117.TextFont.Bold = true;
                    NewField117.TextFont.CharSet = 162;
                    NewField117.Value = @"İzleme
Numarası";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField24.CalcValue = NewField24.Value;
                    REQUESTNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    REQUESTNO.PostFieldValueCalculation();
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField31.CalcValue = NewField31.Value;
                    PAGECOUNT.CalcValue = @"Sayfa Nu. : " + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField142.CalcValue = NewField142.Value;
                    ORDERNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ORDERNAME.PostFieldValueCalculation();
                    NewField162.CalcValue = NewField162.Value;
                    NewField143.CalcValue = NewField143.Value;
                    ORDERAMOUNT.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ORDERAMOUNT.PostFieldValueCalculation();
                    NewField163.CalcValue = NewField163.Value;
                    NewField144.CalcValue = NewField144.Value;
                    DESTINATIONSTORE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DESTINATIONSTORE.PostFieldValueCalculation();
                    REGISTRATIONNUMBER1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    REGISTRATIONNUMBER1.PostFieldValueCalculation();
                    SEQUENCENUMBER1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SEQUENCENUMBER1.PostFieldValueCalculation();
                    REGISTRATIONNUMBER.CalcValue = MyParentReport.PARTB.REGISTRATIONNUMBER1.CalcValue + @" - " + MyParentReport.PARTB.SEQUENCENUMBER1.CalcValue;
                    TRANSACTIONDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TRANSACTIONDATE.PostFieldValueCalculation();
                    NewField113.CalcValue = NewField113.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField116.CalcValue = NewField116.Value;
                    NewField117.CalcValue = NewField117.Value;
                    return new TTReportObject[] { NewField24,REQUESTNO,NewField27,NewField28,NewField30,NewField31,PAGECOUNT,NewField142,ORDERNAME,NewField162,NewField143,ORDERAMOUNT,NewField163,NewField144,DESTINATIONSTORE,REGISTRATIONNUMBER1,SEQUENCENUMBER1,REGISTRATIONNUMBER,TRANSACTIONDATE,NewField113,NewField103,NewField114,NewField115,NewField116,NewField117};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SectionRequirementReport MyParentReport
                {
                    get { return (SectionRequirementReport)ParentReport; }
                }
                
                public TTReportField ITEMCOUNT;
                public TTReportField ITEM;
                public TTReportField ITEMTEXT;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportField DESCRIPTION; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 20;
                    RepeatCount = 0;
                    
                    ITEMCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 281, 6, false);
                    ITEMCOUNT.Name = "ITEMCOUNT";
                    ITEMCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMCOUNT.Value = @"/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Yalnız {%ITEM%} ({%ITEMTEXT%}) kalemdir./////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";

                    ITEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 323, 6, false);
                    ITEM.Name = "ITEM";
                    ITEM.Visible = EvetHayirEnum.ehHayir;
                    ITEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEM.Value = @"{@subgroupcount@}";

                    ITEMTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 6, 323, 11, false);
                    ITEMTEXT.Name = "ITEMTEXT";
                    ITEMTEXT.Visible = EvetHayirEnum.ehHayir;
                    ITEMTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMTEXT.TextFormat = @"NUMBERTEXT";
                    ITEMTEXT.Value = @"{%ITEM%}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 0, 17, 21, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 281, 0, 281, 21, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 279, 21, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ObjectDefName = "SectionRequirement";
                    DESCRIPTION.DataMember = "DESCRIPTION";
                    DESCRIPTION.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ITEM.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    ITEMTEXT.CalcValue = MyParentReport.PARTB.ITEM.CalcValue;
                    ITEMCOUNT.CalcValue = @"/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Yalnız " + MyParentReport.PARTB.ITEM.CalcValue + @" (" + MyParentReport.PARTB.ITEMTEXT.FormattedValue + @") kalemdir./////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////";
                    DESCRIPTION.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DESCRIPTION.PostFieldValueCalculation();
                    return new TTReportObject[] { ITEM,ITEMTEXT,ITEMCOUNT,DESCRIPTION};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public SectionRequirementReport MyParentReport
            {
                get { return (SectionRequirementReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField REGNUM { get {return Body().REGNUM;} }
            public TTReportField PACKUNIT1 { get {return Body().PACKUNIT1;} }
            public TTReportField MATERIALDESCRIPTION { get {return Body().MATERIALDESCRIPTION;} }
            public TTReportField EXTERNALCODE1 { get {return Body().EXTERNALCODE1;} }
            public TTReportField STOCKNO1 { get {return Body().STOCKNO1;} }
            public TTReportField ORDERNO1 { get {return Body().ORDERNO1;} }
            public TTReportField MAINCLASSID1 { get {return Body().MAINCLASSID1;} }
            public TTReportField PACKUNIT11 { get {return Body().PACKUNIT11;} }
            public TTReportField PACKUNIT12 { get {return Body().PACKUNIT12;} }
            public TTReportField PACKUNIT13 { get {return Body().PACKUNIT13;} }
            public TTReportField PACKUNIT14 { get {return Body().PACKUNIT14;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField ACCEPTEDAMOUNT { get {return Body().ACCEPTEDAMOUNT;} }
            public TTReportField STOCKACTIONDETAILOBJECTID { get {return Body().STOCKACTIONDETAILOBJECTID;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionOutDetailsReportQuery_Class>("StockActionOutDetailsReportQuery1", StockAction.StockActionOutDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SectionRequirementReport MyParentReport
                {
                    get { return (SectionRequirementReport)ParentReport; }
                }
                
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField REGNUM;
                public TTReportField PACKUNIT1;
                public TTReportField MATERIALDESCRIPTION;
                public TTReportField EXTERNALCODE1;
                public TTReportField STOCKNO1;
                public TTReportField ORDERNO1;
                public TTReportField MAINCLASSID1;
                public TTReportField PACKUNIT11;
                public TTReportField PACKUNIT12;
                public TTReportField PACKUNIT13;
                public TTReportField PACKUNIT14;
                public TTReportField AMOUNT;
                public TTReportField ACCEPTEDAMOUNT;
                public TTReportField STOCKACTIONDETAILOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 158, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    REGNUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 32, 5, false);
                    REGNUM.Name = "REGNUM";
                    REGNUM.DrawStyle = DrawStyleConstants.vbSolid;
                    REGNUM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    REGNUM.TextFont.CharSet = 162;
                    REGNUM.Value = @"";

                    PACKUNIT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 281, 5, false);
                    PACKUNIT1.Name = "PACKUNIT1";
                    PACKUNIT1.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKUNIT1.TextFont.CharSet = 162;
                    PACKUNIT1.Value = @"";

                    MATERIALDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 144, 5, false);
                    MATERIALDESCRIPTION.Name = "MATERIALDESCRIPTION";
                    MATERIALDESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALDESCRIPTION.TextFont.CharSet = 162;
                    MATERIALDESCRIPTION.Value = @"{#NATOSTOCKNO#} - {#MATERIALNAME#}";

                    EXTERNALCODE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 347, 10, 399, 15, false);
                    EXTERNALCODE1.Name = "EXTERNALCODE1";
                    EXTERNALCODE1.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALCODE1.TextFont.CharSet = 162;
                    EXTERNALCODE1.Value = @"SELECT EXTERNALCODE FROM MATERIAL WHERE ID={#MATERIALID#}";

                    STOCKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 348, 15, 400, 20, false);
                    STOCKNO1.Name = "STOCKNO1";
                    STOCKNO1.Visible = EvetHayirEnum.ehHayir;
                    STOCKNO1.TextFont.CharSet = 162;
                    STOCKNO1.Value = @"SELECT STOCKNO FROM STOCKCARD WHERE ID={#STOCKCARDID#}";

                    ORDERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 10, 452, 15, false);
                    ORDERNO1.Name = "ORDERNO1";
                    ORDERNO1.Visible = EvetHayirEnum.ehHayir;
                    ORDERNO1.TextFont.CharSet = 162;
                    ORDERNO1.Value = @"SELECT ORDERNO FROM STOCKCARD WHERE ID={#STOCKCARDID#}";

                    MAINCLASSID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 400, 15, 452, 20, false);
                    MAINCLASSID1.Name = "MAINCLASSID1";
                    MAINCLASSID1.Visible = EvetHayirEnum.ehHayir;
                    MAINCLASSID1.TextFont.CharSet = 162;
                    MAINCLASSID1.Value = @"SELECT MAINCLASSID FROM STOCKCARD WHERE ID={#STOCKCARDID#}";

                    PACKUNIT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 0, 230, 5, false);
                    PACKUNIT11.Name = "PACKUNIT11";
                    PACKUNIT11.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKUNIT11.TextFont.CharSet = 162;
                    PACKUNIT11.Value = @"";

                    PACKUNIT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 247, 5, false);
                    PACKUNIT12.Name = "PACKUNIT12";
                    PACKUNIT12.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKUNIT12.TextFont.CharSet = 162;
                    PACKUNIT12.Value = @"";

                    PACKUNIT13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 264, 5, false);
                    PACKUNIT13.Name = "PACKUNIT13";
                    PACKUNIT13.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKUNIT13.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PACKUNIT13.TextFont.CharSet = 162;
                    PACKUNIT13.Value = @"";

                    PACKUNIT14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 0, 213, 5, false);
                    PACKUNIT14.Name = "PACKUNIT14";
                    PACKUNIT14.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKUNIT14.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PACKUNIT14.TextFont.CharSet = 162;
                    PACKUNIT14.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 0, 198, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    ACCEPTEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 178, 5, false);
                    ACCEPTEDAMOUNT.Name = "ACCEPTEDAMOUNT";
                    ACCEPTEDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    ACCEPTEDAMOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCEPTEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ACCEPTEDAMOUNT.TextFont.CharSet = 162;
                    ACCEPTEDAMOUNT.Value = @"";

                    STOCKACTIONDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 325, 5, false);
                    STOCKACTIONDETAILOBJECTID.Name = "STOCKACTIONDETAILOBJECTID";
                    STOCKACTIONDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONDETAILOBJECTID.Value = @"{#STOCKACTIONDETAILOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionOutDetailsReportQuery_Class dataset_StockActionOutDetailsReportQuery1 = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionOutDetailsReportQuery_Class>(0);
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionOutDetailsReportQuery1 != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery1.DistributionType) : "");
                    REGNUM.CalcValue = REGNUM.Value;
                    PACKUNIT1.CalcValue = PACKUNIT1.Value;
                    MATERIALDESCRIPTION.CalcValue = (dataset_StockActionOutDetailsReportQuery1 != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery1.NATOStockNO) : "") + @" - " + (dataset_StockActionOutDetailsReportQuery1 != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery1.Materialname) : "");
                    EXTERNALCODE1.CalcValue = EXTERNALCODE1.Value;
                    STOCKNO1.CalcValue = STOCKNO1.Value;
                    ORDERNO1.CalcValue = ORDERNO1.Value;
                    MAINCLASSID1.CalcValue = MAINCLASSID1.Value;
                    PACKUNIT11.CalcValue = PACKUNIT11.Value;
                    PACKUNIT12.CalcValue = PACKUNIT12.Value;
                    PACKUNIT13.CalcValue = PACKUNIT13.Value;
                    PACKUNIT14.CalcValue = PACKUNIT14.Value;
                    AMOUNT.CalcValue = (dataset_StockActionOutDetailsReportQuery1 != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery1.Amount) : "");
                    STOCKACTIONDETAILOBJECTID.CalcValue = (dataset_StockActionOutDetailsReportQuery1 != null ? Globals.ToStringCore(dataset_StockActionOutDetailsReportQuery1.Stockactiondetailobjectid) : "");
                    ACCEPTEDAMOUNT.CalcValue = @"";
                    return new TTReportObject[] { DISTRIBUTIONTYPE,REGNUM,PACKUNIT1,MATERIALDESCRIPTION,EXTERNALCODE1,STOCKNO1,ORDERNO1,MAINCLASSID1,PACKUNIT11,PACKUNIT12,PACKUNIT13,PACKUNIT14,AMOUNT,STOCKACTIONDETAILOBJECTID,ACCEPTEDAMOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID =  (Convert.ToString(this.STOCKACTIONDETAILOBJECTID.CalcValue));
            SectionRequirementMaterial sectionRequirementMaterial = (SectionRequirementMaterial)objectContext.GetObject(new Guid(objectID),"SectionRequirementMaterial");
            this.ACCEPTEDAMOUNT.CalcValue = sectionRequirementMaterial.AcceptedAmount.ToString();
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

        public SectionRequirementReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Kısım İhtiyaç Belgesi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SECTIONREQUIREMENTREPORT";
            Caption = "Kısım İhtiyaç Belgesi Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 256;
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