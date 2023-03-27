
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
    /// Fonksiyon Muayenesi
    /// </summary>
    public partial class FonksiyonMuayenesi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public FonksiyonMuayenesi MyParentReport
            {
                get { return (FonksiyonMuayenesi)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseExamination.GetByObjcetID_Class>("GetByObjcetID", PurchaseExamination.GetByObjcetID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1;
                public TTReportRTF ReportRTF;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 125;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 190, 48, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 12;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 190, 40, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\nMUAYENE KOMİSYONU BAŞKANLIĞI""";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 41, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.Value = @"HİZMETE ÖZEL";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 52, 190, 107, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 121, 20, 126, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 121, 135, 126, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.Value = @"MUAYENESİ YAPILACAK MALZEME";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 121, 161, 126, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.Value = @"MİKTARI";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 121, 190, 126, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.Value = @"F.MADDELERİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\nMUAYENE KOMİSYONU BAŞKANLIĞI";
                    return new TTReportObject[] { NewField1,ReportRTF,NewField2,NewField12,NewField121,NewField1121,XXXXXXIL,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region PART1 HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((FonksiyonMuayenesi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination purchaseExamination = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            this.ReportRTF.Value = purchaseExamination.FunctionInspectionRequestTxt;
#endregion PART1 HEADER_PreScript
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportField NewField11; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 41, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField11};
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public FonksiyonMuayenesi MyParentReport
            {
                get { return (FonksiyonMuayenesi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField CNT { get {return Body().CNT;} }
            public TTReportField CLAUSES { get {return Body().CLAUSES;} }
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
                list[0] = new TTReportNqlData<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class>("ExaminationDetailReportNQL", PurchaseExaminationDetail.ExaminationDetailReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField MATERIALNAME;
                public TTReportField CNT;
                public TTReportField CLAUSES; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 161, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 135, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    CNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 20, 5, false);
                    CNT.Name = "CNT";
                    CNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CNT.Value = @"{@counter@}";

                    CLAUSES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 190, 5, false);
                    CLAUSES.Name = "CLAUSES";
                    CLAUSES.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSES.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLAUSES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSES.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSES.WordBreak = EvetHayirEnum.ehEvet;
                    CLAUSES.ExpandTabs = EvetHayirEnum.ehEvet;
                    CLAUSES.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExaminationDetail.ExaminationDetailReportNQL_Class dataset_ExaminationDetailReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExaminationDetail.ExaminationDetailReportNQL_Class>(0);
                    AMOUNT.CalcValue = (dataset_ExaminationDetailReportNQL != null ? Globals.ToStringCore(dataset_ExaminationDetailReportNQL.Amount) : "");
                    MATERIALNAME.CalcValue = (dataset_ExaminationDetailReportNQL != null ? Globals.ToStringCore(dataset_ExaminationDetailReportNQL.Materialname) : "");
                    CNT.CalcValue = ParentGroup.Counter.ToString();
                    CLAUSES.CalcValue = @"";
                    return new TTReportObject[] { AMOUNT,MATERIALNAME,CNT,CLAUSES};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class FUNCTIONTESTGroup : TTReportGroup
        {
            public FonksiyonMuayenesi MyParentReport
            {
                get { return (FonksiyonMuayenesi)ParentReport; }
            }

            new public FUNCTIONTESTGroupHeader Header()
            {
                return (FUNCTIONTESTGroupHeader)_header;
            }

            new public FUNCTIONTESTGroupFooter Footer()
            {
                return (FUNCTIONTESTGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField CLAUSENO1 { get {return Header().CLAUSENO1;} }
            public TTReportField EXAMINATIONVALUE1 { get {return Header().EXAMINATIONVALUE1;} }
            public TTReportField UYGUNMU1 { get {return Header().UYGUNMU1;} }
            public TTReportField CLAUSE1 { get {return Header().CLAUSE1;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public FUNCTIONTESTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FUNCTIONTESTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FUNCTIONTESTGroupHeader(this);
                _footer = new FUNCTIONTESTGroupFooter(this);

            }

            public partial class FUNCTIONTESTGroupHeader : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportRTF ReportRTF;
                public TTReportField CLAUSENO1;
                public TTReportField EXAMINATIONVALUE1;
                public TTReportField UYGUNMU1;
                public TTReportField CLAUSE1; 
                public FUNCTIONTESTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 92;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 41, 11, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.Value = @"HİZMETE ÖZEL";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 16, 190, 71, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                    CLAUSENO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 78, 35, 93, false);
                    CLAUSENO1.Name = "CLAUSENO1";
                    CLAUSENO1.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSENO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSENO1.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSENO1.WordBreak = EvetHayirEnum.ehEvet;
                    CLAUSENO1.Value = @"TEKNİK 
ŞARTNAME
MADDE NO";

                    EXAMINATIONVALUE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 78, 165, 93, false);
                    EXAMINATIONVALUE1.Name = "EXAMINATIONVALUE1";
                    EXAMINATIONVALUE1.DrawStyle = DrawStyleConstants.vbSolid;
                    EXAMINATIONVALUE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXAMINATIONVALUE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXAMINATIONVALUE1.Value = @"BULUNAN DEĞERLER";

                    UYGUNMU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 78, 190, 93, false);
                    UYGUNMU1.Name = "UYGUNMU1";
                    UYGUNMU1.DrawStyle = DrawStyleConstants.vbSolid;
                    UYGUNMU1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYGUNMU1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYGUNMU1.Value = @"SONUÇ";

                    CLAUSE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 78, 96, 93, false);
                    CLAUSE1.Name = "CLAUSE1";
                    CLAUSE1.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLAUSE1.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSE1.WordBreak = EvetHayirEnum.ehEvet;
                    CLAUSE1.Value = @"MUAYENE EDİLEN
ÖZELLİKLER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    CLAUSENO1.CalcValue = CLAUSENO1.Value;
                    EXAMINATIONVALUE1.CalcValue = EXAMINATIONVALUE1.Value;
                    UYGUNMU1.CalcValue = UYGUNMU1.Value;
                    CLAUSE1.CalcValue = CLAUSE1.Value;
                    return new TTReportObject[] { NewField111,ReportRTF,CLAUSENO1,EXAMINATIONVALUE1,UYGUNMU1,CLAUSE1};
                }
                public override void RunPreScript()
                {
#region FUNCTIONTEST HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((FonksiyonMuayenesi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination purchaseExamination = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            this.ReportRTF.Value = purchaseExamination.FunctionTestReportHeaderTxt;
#endregion FUNCTIONTEST HEADER_PreScript
                }
            }
            public partial class FUNCTIONTESTGroupFooter : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportField NewField112; 
                public FUNCTIONTESTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 42, 9, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.Underline = true;
                    NewField112.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112.CalcValue = NewField112.Value;
                    return new TTReportObject[] { NewField112};
                }
            }

        }

        public FUNCTIONTESTGroup FUNCTIONTEST;

        public partial class LINEGroup : TTReportGroup
        {
            public FonksiyonMuayenesi MyParentReport
            {
                get { return (FonksiyonMuayenesi)ParentReport; }
            }

            new public LINEGroupHeader Header()
            {
                return (LINEGroupHeader)_header;
            }

            new public LINEGroupFooter Footer()
            {
                return (LINEGroupFooter)_footer;
            }

            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public LINEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LINEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ExaminationDetail.FunctionTestReportNQL_Class>("FunctionTestReportNQL", ExaminationDetail.FunctionTestReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LINEGroupHeader(this);
                _footer = new LINEGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class LINEGroupHeader : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportShape NewLine2; 
                public LINEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, -2, 190, -2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 190, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationDetail.FunctionTestReportNQL_Class dataset_FunctionTestReportNQL = ParentGroup.rsGroup.GetCurrentRecord<ExaminationDetail.FunctionTestReportNQL_Class>(0);
                    return new TTReportObject[] { };
                }
            }
            public partial class LINEGroupFooter : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportShape NewLine11; 
                public LINEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 190, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationDetail.FunctionTestReportNQL_Class dataset_FunctionTestReportNQL = ParentGroup.rsGroup.GetCurrentRecord<ExaminationDetail.FunctionTestReportNQL_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public LINEGroup LINE;

        public partial class MAINBGroup : TTReportGroup
        {
            public FonksiyonMuayenesi MyParentReport
            {
                get { return (FonksiyonMuayenesi)ParentReport; }
            }

            new public MAINBGroupBody Body()
            {
                return (MAINBGroupBody)_body;
            }
            public TTReportField CLAUSENO { get {return Body().CLAUSENO;} }
            public TTReportField CONFIRMED { get {return Body().CONFIRMED;} }
            public TTReportField EXAMINATIONVALUE { get {return Body().EXAMINATIONVALUE;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField ELIGABLE { get {return Body().ELIGABLE;} }
            public TTReportRTF CLAUSERTF { get {return Body().CLAUSERTF;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public MAINBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINBGroupBody(this);
            }

            public partial class MAINBGroupBody : TTReportSection
            {
                public FonksiyonMuayenesi MyParentReport
                {
                    get { return (FonksiyonMuayenesi)ParentReport; }
                }
                
                public TTReportField CLAUSENO;
                public TTReportField CONFIRMED;
                public TTReportField EXAMINATIONVALUE;
                public TTReportField OBJECTID;
                public TTReportField ELIGABLE;
                public TTReportRTF CLAUSERTF;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14; 
                public MAINBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    CLAUSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 35, 6, false);
                    CLAUSENO.Name = "CLAUSENO";
                    CLAUSENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLAUSENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSENO.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    CLAUSENO.Value = @"{#LINE.CLAUSENO#}";

                    CONFIRMED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 1, 261, 6, false);
                    CONFIRMED.Name = "CONFIRMED";
                    CONFIRMED.Visible = EvetHayirEnum.ehHayir;
                    CONFIRMED.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMED.Value = @"{#LINE.CONFIRMED#}";

                    EXAMINATIONVALUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 165, 6, false);
                    EXAMINATIONVALUE.Name = "EXAMINATIONVALUE";
                    EXAMINATIONVALUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONVALUE.MultiLine = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE.WordBreak = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE.ExpandTabs = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE.Value = @"{#LINE.EXAMINATIONVALUE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 236, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#LINE.OBJECTID#}";

                    ELIGABLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 1, 190, 6, false);
                    ELIGABLE.Name = "ELIGABLE";
                    ELIGABLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ELIGABLE.NoClip = EvetHayirEnum.ehEvet;
                    ELIGABLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ELIGABLE.Value = @"";

                    CLAUSERTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 36, 1, 96, 6, false);
                    CLAUSERTF.Name = "CLAUSERTF";
                    CLAUSERTF.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 10, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 35, 1, 35, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 96, 1, 96, 6, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 165, 1, 165, 6, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 190, 1, 190, 6, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationDetail.FunctionTestReportNQL_Class dataset_FunctionTestReportNQL = MyParentReport.LINE.rsGroup.GetCurrentRecord<ExaminationDetail.FunctionTestReportNQL_Class>(0);
                    CLAUSENO.CalcValue = (dataset_FunctionTestReportNQL != null ? Globals.ToStringCore(dataset_FunctionTestReportNQL.ClauseNo) : "");
                    CONFIRMED.CalcValue = (dataset_FunctionTestReportNQL != null ? Globals.ToStringCore(dataset_FunctionTestReportNQL.Confirmed) : "");
                    EXAMINATIONVALUE.CalcValue = (dataset_FunctionTestReportNQL != null ? Globals.ToStringCore(dataset_FunctionTestReportNQL.ExaminationValue) : "");
                    OBJECTID.CalcValue = (dataset_FunctionTestReportNQL != null ? Globals.ToStringCore(dataset_FunctionTestReportNQL.ObjectID) : "");
                    ELIGABLE.CalcValue = @"";
                    CLAUSERTF.CalcValue = CLAUSERTF.Value;
                    return new TTReportObject[] { CLAUSENO,CONFIRMED,EXAMINATIONVALUE,OBJECTID,ELIGABLE,CLAUSERTF};
                }

                public override void RunScript()
                {
#region MAINB BODY_Script
                    if(CONFIRMED.CalcValue == "True")
                ELIGABLE.CalcValue = "UYGUNDUR";
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = OBJECTID.CalcValue.ToString();
            ExaminationDetail examinationDetail = (ExaminationDetail)context.GetObject(new Guid(sObjectID),"ExaminationDetail");
            CLAUSERTF.Value = examinationDetail.Clause;
#endregion MAINB BODY_Script
                }
            }

        }

        public MAINBGroup MAINB;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FonksiyonMuayenesi()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            FUNCTIONTEST = new FUNCTIONTESTGroup(this,"FUNCTIONTEST");
            LINE = new LINEGroup(FUNCTIONTEST,"LINE");
            MAINB = new MAINBGroup(LINE,"MAINB");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9b2306a7-2381-4099-8a37-63dbae04c00e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FONKSIYONMUAYENESI";
            Caption = "Fonksiyon Muayenesi";
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
            fd.TextFont.Name = "Arial";
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