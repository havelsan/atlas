
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
    /// Karargah Dışı Yazışma
    /// </summary>
    public partial class NonMilitaryCorrespondence : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string TO = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PART_AGroup : TTReportGroup
        {
            public NonMilitaryCorrespondence MyParentReport
            {
                get { return (NonMilitaryCorrespondence)ParentReport; }
            }

            new public PART_AGroupHeader Header()
            {
                return (PART_AGroupHeader)_header;
            }

            new public PART_AGroupFooter Footer()
            {
                return (PART_AGroupFooter)_footer;
            }

            public TTReportField CLASSIFICATIONDEGREE { get {return Header().CLASSIFICATIONDEGREE;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField SUBJECT { get {return Header().SUBJECT;} }
            public TTReportField NUMBERLITERAL { get {return Header().NUMBERLITERAL;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NUMBER { get {return Header().NUMBER;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DOSYA { get {return Header().DOSYA;} }
            public TTReportField TO { get {return Header().TO;} }
            public TTReportField REFERENCE { get {return Header().REFERENCE;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportRTF Reference { get {return Header().Reference;} }
            public TTReportField DELIVEREDBYNAME { get {return Header().DELIVEREDBYNAME;} }
            public TTReportField DELIVEREDBYDUTY { get {return Header().DELIVEREDBYDUTY;} }
            public TTReportRTF ReportText { get {return Header().ReportText;} }
            public TTReportField DELIVEREDBYRANK { get {return Header().DELIVEREDBYRANK;} }
            public TTReportField CAPTION { get {return Header().CAPTION;} }
            public TTReportField PARAF1 { get {return Header().PARAF1;} }
            public TTReportField PARAF2 { get {return Header().PARAF2;} }
            public TTReportField PARAF3 { get {return Header().PARAF3;} }
            public TTReportField CLASSIFICATIONDEGREE1 { get {return Footer().CLASSIFICATIONDEGREE1;} }
            public PART_AGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART_AGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class>("NonMilitaryCorrespondenceNQL", BaseCorrespondence.NonMilitaryCorrespondenceNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART_AGroupHeader(this);
                _footer = new PART_AGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART_AGroupHeader : TTReportSection
            {
                public NonMilitaryCorrespondence MyParentReport
                {
                    get { return (NonMilitaryCorrespondence)ParentReport; }
                }
                
                public TTReportField CLASSIFICATIONDEGREE;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField SUBJECT;
                public TTReportField NUMBERLITERAL;
                public TTReportField NewField162;
                public TTReportField NUMBER;
                public TTReportField DOCUMENTDATE;
                public TTReportField DOSYA;
                public TTReportField TO;
                public TTReportField REFERENCE;
                public TTReportField NewField1261;
                public TTReportRTF Reference;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportRTF ReportText;
                public TTReportField DELIVEREDBYRANK;
                public TTReportField CAPTION;
                public TTReportField PARAF1;
                public TTReportField PARAF2;
                public TTReportField PARAF3; 
                public PART_AGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 175;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    CLASSIFICATIONDEGREE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 12, 65, 17, false);
                    CLASSIFICATIONDEGREE.Name = "CLASSIFICATIONDEGREE";
                    CLASSIFICATIONDEGREE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASSIFICATIONDEGREE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CLASSIFICATIONDEGREE.ObjectDefName = "ClassificationDegreeForDocuments";
                    CLASSIFICATIONDEGREE.DataMember = "DISPLAYTEXT";
                    CLASSIFICATIONDEGREE.TextFont.Bold = true;
                    CLASSIFICATIONDEGREE.TextFont.Underline = true;
                    CLASSIFICATIONDEGREE.Value = @"{#CLASSIFICATIONDEGREE#}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 47, 56, 52, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Size = 11;
                    NewField151.Value = @"KONU";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 47, 59, 52, false);
                    NewField161.Name = "NewField161";
                    NewField161.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.Value = @":";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 47, 197, 52, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBJECT.TextFont.Size = 11;
                    SUBJECT.Value = @"{#SUBJECT#}";

                    NUMBERLITERAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 41, 56, 46, false);
                    NUMBERLITERAL.Name = "NUMBERLITERAL";
                    NUMBERLITERAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBERLITERAL.TextFont.Size = 11;
                    NUMBERLITERAL.Value = @"{#NUMBERLITERAL#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 41, 59, 46, false);
                    NewField162.Name = "NewField162";
                    NewField162.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField162.TextFont.Size = 11;
                    NewField162.TextFont.Bold = true;
                    NewField162.Value = @":";

                    NUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 41, 144, 46, false);
                    NUMBER.Name = "NUMBER";
                    NUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBER.TextFont.Size = 11;
                    NUMBER.Value = @"{#NUMBER#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 41, 197, 46, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DOCUMENTDATE.TextFont.Size = 11;
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DOSYA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 57, 197, 62, false);
                    DOSYA.Name = "DOSYA";
                    DOSYA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOSYA.Value = @"( D O S Y A )";

                    TO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 63, 197, 68, false);
                    TO.Name = "TO";
                    TO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TO.Value = @"{@TO@}";

                    REFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 71, 28, 76, false);
                    REFERENCE.Name = "REFERENCE";
                    REFERENCE.TextFont.Size = 11;
                    REFERENCE.Value = @"İLGİ";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 71, 30, 76, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1261.TextFont.Size = 11;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.Value = @":";

                    Reference = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 30, 71, 197, 92, false);
                    Reference.Name = "Reference";
                    Reference.Value = @"";

                    DELIVEREDBYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 138, 197, 143, false);
                    DELIVEREDBYNAME.Name = "DELIVEREDBYNAME";
                    DELIVEREDBYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYNAME.TextFont.Size = 11;
                    DELIVEREDBYNAME.Value = @"";

                    DELIVEREDBYDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 148, 197, 153, false);
                    DELIVEREDBYDUTY.Name = "DELIVEREDBYDUTY";
                    DELIVEREDBYDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYDUTY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYDUTY.TextFont.Size = 11;
                    DELIVEREDBYDUTY.Value = @"";

                    ReportText = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 18, 100, 197, 132, false);
                    ReportText.Name = "ReportText";
                    ReportText.Value = @"";

                    DELIVEREDBYRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 143, 197, 148, false);
                    DELIVEREDBYRANK.Name = "DELIVEREDBYRANK";
                    DELIVEREDBYRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYRANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYRANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYRANK.TextFont.Size = 11;
                    DELIVEREDBYRANK.Value = @"";

                    CAPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 19, 197, 39, false);
                    CAPTION.Name = "CAPTION";
                    CAPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    CAPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CAPTION.MultiLine = EvetHayirEnum.ehEvet;
                    CAPTION.WordBreak = EvetHayirEnum.ehEvet;
                    CAPTION.TextFont.Size = 11;
                    CAPTION.Value = @"{#CAPTION#}";

                    PARAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 138, 86, 143, false);
                    PARAF1.Name = "PARAF1";
                    PARAF1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAF1.Value = @"";

                    PARAF2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 147, 86, 152, false);
                    PARAF2.Name = "PARAF2";
                    PARAF2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAF2.Value = @"";

                    PARAF3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 156, 86, 161, false);
                    PARAF3.Name = "PARAF3";
                    PARAF3.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAF3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class dataset_NonMilitaryCorrespondenceNQL = ParentGroup.rsGroup.GetCurrentRecord<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class>(0);
                    CLASSIFICATIONDEGREE.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.ClassificationDegree) : "");
                    CLASSIFICATIONDEGREE.PostFieldValueCalculation();
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    SUBJECT.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.Subject) : "");
                    NUMBERLITERAL.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.NumberLiteral) : "");
                    NewField162.CalcValue = NewField162.Value;
                    NUMBER.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.Number) : "");
                    DOCUMENTDATE.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.DocumentDate) : "");
                    DOSYA.CalcValue = DOSYA.Value;
                    TO.CalcValue = MyParentReport.RuntimeParameters.TO.ToString();
                    REFERENCE.CalcValue = REFERENCE.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    Reference.CalcValue = Reference.Value;
                    DELIVEREDBYNAME.CalcValue = @"";
                    DELIVEREDBYDUTY.CalcValue = @"";
                    ReportText.CalcValue = ReportText.Value;
                    DELIVEREDBYRANK.CalcValue = @"";
                    CAPTION.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.Caption) : "");
                    PARAF1.CalcValue = @"";
                    PARAF2.CalcValue = @"";
                    PARAF3.CalcValue = @"";
                    return new TTReportObject[] { CLASSIFICATIONDEGREE,NewField151,NewField161,SUBJECT,NUMBERLITERAL,NewField162,NUMBER,DOCUMENTDATE,DOSYA,TO,REFERENCE,NewField1261,Reference,DELIVEREDBYNAME,DELIVEREDBYDUTY,ReportText,DELIVEREDBYRANK,CAPTION,PARAF1,PARAF2,PARAF3};
                }
                public override void RunPreScript()
                {
#region PART_A HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NonMilitaryCorrespondence)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BaseCorrespondence bc = (BaseCorrespondence)context.GetObject(new Guid(sObjectID),"BaseCorrespondence");
            this.ReportText.Value = bc.ReportText;
            this.Reference.Value = bc.Reference;
#endregion PART_A HEADER_PreScript
                }

                public override void RunScript()
                {
#region PART_A HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NonMilitaryCorrespondence)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BaseCorrespondence bc = (BaseCorrespondence)context.GetObject(new Guid(sObjectID),"BaseCorrespondence");
            ResUser ru = bc.ReportSender;
            
            if(TO.CalcValue == "Dosya")
            {
                DOSYA.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                TO.CalcValue = ((DistributionPlace)bc.DistributionPlaces[0]).DistributionLine;
            }
            else
            {
                DOSYA.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            }
            
            int i = 1;
                foreach(Paraph p in bc.Paraphs)
                {
                    TTReportField rf = FieldsByName("PARAF"+i);
                    rf.CalcValue = p.ParaphLine;
                    i++;
                }
            
            DELIVEREDBYNAME.CalcValue = ru.Name;
            if(ru.Rank != null)
                DELIVEREDBYRANK.CalcValue = ru.Rank.Name;
            
            if (ru.Title != null)
                DELIVEREDBYDUTY.CalcValue = (TTObjectClasses.Common.GetEnumValueDefOfEnumValue((Enum)ru.Title)).DisplayText;
#endregion PART_A HEADER_Script
                }
            }
            public partial class PART_AGroupFooter : TTReportSection
            {
                public NonMilitaryCorrespondence MyParentReport
                {
                    get { return (NonMilitaryCorrespondence)ParentReport; }
                }
                
                public TTReportField CLASSIFICATIONDEGREE1; 
                public PART_AGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CLASSIFICATIONDEGREE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 3, 65, 8, false);
                    CLASSIFICATIONDEGREE1.Name = "CLASSIFICATIONDEGREE1";
                    CLASSIFICATIONDEGREE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASSIFICATIONDEGREE1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CLASSIFICATIONDEGREE1.ObjectDefName = "ClassificationDegreeForDocuments";
                    CLASSIFICATIONDEGREE1.DataMember = "DISPLAYTEXT";
                    CLASSIFICATIONDEGREE1.TextFont.Bold = true;
                    CLASSIFICATIONDEGREE1.TextFont.Underline = true;
                    CLASSIFICATIONDEGREE1.Value = @"{#CLASSIFICATIONDEGREE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class dataset_NonMilitaryCorrespondenceNQL = ParentGroup.rsGroup.GetCurrentRecord<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class>(0);
                    CLASSIFICATIONDEGREE1.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.ClassificationDegree) : "");
                    CLASSIFICATIONDEGREE1.PostFieldValueCalculation();
                    return new TTReportObject[] { CLASSIFICATIONDEGREE1};
                }
            }

        }

        public PART_AGroup PART_A;

        public partial class EKGroup : TTReportGroup
        {
            public NonMilitaryCorrespondence MyParentReport
            {
                get { return (NonMilitaryCorrespondence)ParentReport; }
            }

            new public EKGroupBody Body()
            {
                return (EKGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField ADDITIONS { get {return Body().ADDITIONS;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public EKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public EKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new EKGroupBody(this);
            }

            public partial class EKGroupBody : TTReportSection
            {
                public NonMilitaryCorrespondence MyParentReport
                {
                    get { return (NonMilitaryCorrespondence)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField ADDITIONS;
                public TTReportShape NewLine1;
                public TTReportField NewField11; 
                public EKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 2, 68, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"EKİ                                     ";

                    ADDITIONS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 8, 197, 13, false);
                    ADDITIONS.Name = "ADDITIONS";
                    ADDITIONS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDITIONS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDITIONS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDITIONS.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADDITIONS.Value = @"{#PART_A.ADDITION#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 7, 71, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 2, 71, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class dataset_NonMilitaryCorrespondenceNQL = MyParentReport.PART_A.rsGroup.GetCurrentRecord<BaseCorrespondence.NonMilitaryCorrespondenceNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    ADDITIONS.CalcValue = (dataset_NonMilitaryCorrespondenceNQL != null ? Globals.ToStringCore(dataset_NonMilitaryCorrespondenceNQL.Addition) : "");
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField1,ADDITIONS,NewField11};
                }
                public override void RunPreScript()
                {
#region EK BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NonMilitaryCorrespondence)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BaseCorrespondence bc = (BaseCorrespondence)context.GetObject(new Guid(sObjectID),"BaseCorrespondence");
            
            if(string.IsNullOrEmpty(bc.Addition))
                this.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            else
                this.Visible = TTReportTool.EvetHayirEnum.ehEvet;
#endregion EK BODY_PreScript
                }
            }

        }

        public EKGroup EK;

        public partial class DAGITIMBILGIGroup : TTReportGroup
        {
            public NonMilitaryCorrespondence MyParentReport
            {
                get { return (NonMilitaryCorrespondence)ParentReport; }
            }

            new public DAGITIMBILGIGroupBody Body()
            {
                return (DAGITIMBILGIGroupBody)_body;
            }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField DIST1 { get {return Body().DIST1;} }
            public TTReportField DIST2 { get {return Body().DIST2;} }
            public TTReportField INFO1 { get {return Body().INFO1;} }
            public TTReportField INFO2 { get {return Body().INFO2;} }
            public TTReportField INFO3 { get {return Body().INFO3;} }
            public TTReportField INFO4 { get {return Body().INFO4;} }
            public TTReportField INFO5 { get {return Body().INFO5;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public DAGITIMBILGIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DAGITIMBILGIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DAGITIMBILGIGroupBody(this);
            }

            public partial class DAGITIMBILGIGroupBody : TTReportSection
            {
                public NonMilitaryCorrespondence MyParentReport
                {
                    get { return (NonMilitaryCorrespondence)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField DIST1;
                public TTReportField DIST2;
                public TTReportField INFO1;
                public TTReportField INFO2;
                public TTReportField INFO3;
                public TTReportField INFO4;
                public TTReportField INFO5;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportField NewField122;
                public TTReportShape NewLine3; 
                public DAGITIMBILGIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 49;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 9, 197, 14, false);
                    NewField111.Name = "NewField111";
                    NewField111.Value = @"Bilgi                                                                      :";

                    DIST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 17, 109, 22, false);
                    DIST1.Name = "DIST1";
                    DIST1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIST1.MultiLine = EvetHayirEnum.ehEvet;
                    DIST1.WordBreak = EvetHayirEnum.ehEvet;
                    DIST1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIST1.Value = @"";

                    DIST2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 23, 109, 28, false);
                    DIST2.Name = "DIST2";
                    DIST2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIST2.MultiLine = EvetHayirEnum.ehEvet;
                    DIST2.WordBreak = EvetHayirEnum.ehEvet;
                    DIST2.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIST2.Value = @"";

                    INFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 17, 197, 22, false);
                    INFO1.Name = "INFO1";
                    INFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFO1.MultiLine = EvetHayirEnum.ehEvet;
                    INFO1.WordBreak = EvetHayirEnum.ehEvet;
                    INFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFO1.Value = @"";

                    INFO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 23, 197, 28, false);
                    INFO2.Name = "INFO2";
                    INFO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFO2.MultiLine = EvetHayirEnum.ehEvet;
                    INFO2.WordBreak = EvetHayirEnum.ehEvet;
                    INFO2.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFO2.Value = @"";

                    INFO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 29, 197, 34, false);
                    INFO3.Name = "INFO3";
                    INFO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFO3.MultiLine = EvetHayirEnum.ehEvet;
                    INFO3.WordBreak = EvetHayirEnum.ehEvet;
                    INFO3.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFO3.Value = @"";

                    INFO4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 35, 197, 40, false);
                    INFO4.Name = "INFO4";
                    INFO4.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFO4.MultiLine = EvetHayirEnum.ehEvet;
                    INFO4.WordBreak = EvetHayirEnum.ehEvet;
                    INFO4.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFO4.Value = @"";

                    INFO5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 41, 197, 46, false);
                    INFO5.Name = "INFO5";
                    INFO5.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFO5.MultiLine = EvetHayirEnum.ehEvet;
                    INFO5.WordBreak = EvetHayirEnum.ehEvet;
                    INFO5.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFO5.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 9, 71, 14, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 4, 68, 9, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"DAĞITIM";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 9, 68, 14, false);
                    NewField121.Name = "NewField121";
                    NewField121.Value = @"Gereği";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 9, 71, 9, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 14, 71, 14, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 4, 71, 9, false);
                    NewField122.Name = "NewField122";
                    NewField122.Value = @":";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 115, 14, 197, 14, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    DIST1.CalcValue = @"";
                    DIST2.CalcValue = @"";
                    INFO1.CalcValue = @"";
                    INFO2.CalcValue = @"";
                    INFO3.CalcValue = @"";
                    INFO4.CalcValue = @"";
                    INFO5.CalcValue = @"";
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    return new TTReportObject[] { NewField111,DIST1,DIST2,INFO1,INFO2,INFO3,INFO4,INFO5,NewField12,NewField11,NewField121,NewField122};
                }

                public override void RunScript()
                {
#region DAGITIMBILGI BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NonMilitaryCorrespondence)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BaseCorrespondence bc = (BaseCorrespondence)context.GetObject(new Guid(sObjectID),"BaseCorrespondence");
            
            if(bc.Infos.Count == 0 && bc.DistributionPlaces.Count == 0)
                this.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            else
            {
                this.Visible = TTReportTool.EvetHayirEnum.ehEvet;
                int i = 1;
                foreach(DistributionPlace dp in bc.DistributionPlaces)
                {
                    TTReportField rf = FieldsByName("DIST"+i);
                    rf.CalcValue = dp.DistributionLine;
                    i++;
                }
                i = 1;
                foreach(Info info in bc.Infos)
                {
                    TTReportField rf = FieldsByName("INFO"+i);
                    rf.CalcValue = info.InfoLine;
                    i++;
                }
            }
#endregion DAGITIMBILGI BODY_Script
                }
            }

        }

        public DAGITIMBILGIGroup DAGITIMBILGI;

        public partial class LISTEGroup : TTReportGroup
        {
            public NonMilitaryCorrespondence MyParentReport
            {
                get { return (NonMilitaryCorrespondence)ParentReport; }
            }

            new public LISTEGroupBody Body()
            {
                return (LISTEGroupBody)_body;
            }
            public TTReportRTF ListRTF { get {return Body().ListRTF;} }
            public LISTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LISTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new LISTEGroupBody(this);
            }

            public partial class LISTEGroupBody : TTReportSection
            {
                public NonMilitaryCorrespondence MyParentReport
                {
                    get { return (NonMilitaryCorrespondence)ParentReport; }
                }
                
                public TTReportRTF ListRTF; 
                public LISTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 37;
                    RepeatCount = 0;
                    
                    ListRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 18, 2, 197, 34, false);
                    ListRTF.Name = "ListRTF";
                    ListRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ListRTF.CalcValue = ListRTF.Value;
                    return new TTReportObject[] { ListRTF};
                }
                public override void RunPreScript()
                {
#region LISTE BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NonMilitaryCorrespondence)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BaseCorrespondence bc = (BaseCorrespondence)context.GetObject(new Guid(sObjectID),"BaseCorrespondence");
            this.ListRTF.Value = bc.RelatedList;
#endregion LISTE BODY_PreScript
                }

                public override void RunScript()
                {
#region LISTE BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NonMilitaryCorrespondence)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            BaseCorrespondence bc = (BaseCorrespondence)context.GetObject(new Guid(sObjectID),"BaseCorrespondence");
            
            if(string.IsNullOrEmpty(bc.Addition))
                this.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            else
                this.Visible = TTReportTool.EvetHayirEnum.ehEvet;
#endregion LISTE BODY_Script
                }
            }

        }

        public LISTEGroup LISTE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NonMilitaryCorrespondence()
        {
            PART_A = new PART_AGroup(this,"PART_A");
            EK = new EKGroup(PART_A,"EK");
            DAGITIMBILGI = new DAGITIMBILGIGroup(PART_A,"DAGITIMBILGI");
            LISTE = new LISTEGroup(PART_A,"LISTE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("TO", "", "Kime", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("TO"))
                _runtimeParameters.TO = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TO"]);
            Name = "NONMILITARYCORRESPONDENCE";
            Caption = "Karargah Dışı Yazışma";
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