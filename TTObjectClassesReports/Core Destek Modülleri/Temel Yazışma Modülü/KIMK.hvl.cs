
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
    /// Karargah İçi Mütalaa Kağıdı
    /// </summary>
    public partial class KIMK : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART_AGroup : TTReportGroup
        {
            public KIMK MyParentReport
            {
                get { return (KIMK)ParentReport; }
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
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField FROM { get {return Header().FROM;} }
            public TTReportField NewField1152 { get {return Header().NewField1152;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField TO { get {return Header().TO;} }
            public TTReportField NewField1153 { get {return Header().NewField1153;} }
            public TTReportField NewField1163 { get {return Header().NewField1163;} }
            public TTReportField COORDINATOR { get {return Header().COORDINATOR;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                list[0] = new TTReportNqlData<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class>("InternalCorrespondenceKIMKNQL", InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KIMK MyParentReport
                {
                    get { return (KIMK)ParentReport; }
                }
                
                public TTReportField CLASSIFICATIONDEGREE;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField SUBJECT;
                public TTReportField NUMBERLITERAL;
                public TTReportField NewField162;
                public TTReportField NUMBER;
                public TTReportField DOCUMENTDATE;
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
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField FROM;
                public TTReportField NewField1152;
                public TTReportField NewField1162;
                public TTReportField TO;
                public TTReportField NewField1153;
                public TTReportField NewField1163;
                public TTReportField COORDINATOR;
                public TTReportShape NewLine1; 
                public PART_AGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 179;
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

                    REFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 76, 28, 81, false);
                    REFERENCE.Name = "REFERENCE";
                    REFERENCE.TextFont.Size = 11;
                    REFERENCE.Value = @"İLGİ";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 76, 30, 81, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1261.TextFont.Size = 11;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.Value = @":";

                    Reference = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 30, 76, 197, 97, false);
                    Reference.Name = "Reference";
                    Reference.Value = @"";

                    DELIVEREDBYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 143, 197, 148, false);
                    DELIVEREDBYNAME.Name = "DELIVEREDBYNAME";
                    DELIVEREDBYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYNAME.TextFont.Size = 11;
                    DELIVEREDBYNAME.Value = @"";

                    DELIVEREDBYDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 153, 197, 158, false);
                    DELIVEREDBYDUTY.Name = "DELIVEREDBYDUTY";
                    DELIVEREDBYDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYDUTY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYDUTY.TextFont.Size = 11;
                    DELIVEREDBYDUTY.Value = @"";

                    ReportText = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 18, 105, 197, 137, false);
                    ReportText.Name = "ReportText";
                    ReportText.Value = @"";

                    DELIVEREDBYRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 148, 197, 153, false);
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

                    PARAF1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 143, 86, 148, false);
                    PARAF1.Name = "PARAF1";
                    PARAF1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAF1.Value = @"";

                    PARAF2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 152, 86, 157, false);
                    PARAF2.Name = "PARAF2";
                    PARAF2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAF2.Value = @"";

                    PARAF3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 161, 86, 166, false);
                    PARAF3.Name = "PARAF3";
                    PARAF3.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAF3.Value = @"";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 53, 56, 58, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.Value = @"NEREDEN";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 53, 59, 58, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1161.TextFont.Size = 11;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.Value = @":";

                    FROM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 53, 197, 58, false);
                    FROM.Name = "FROM";
                    FROM.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROM.TextFont.Size = 11;
                    FROM.Value = @"{#FROM#}";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 59, 56, 64, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.TextFont.Size = 11;
                    NewField1152.Value = @"NEREYE";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 59, 59, 64, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1162.TextFont.Size = 11;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.Value = @":";

                    TO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 59, 197, 64, false);
                    TO.Name = "TO";
                    TO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TO.TextFont.Size = 11;
                    TO.Value = @"{#TO#}";

                    NewField1153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 65, 56, 70, false);
                    NewField1153.Name = "NewField1153";
                    NewField1153.TextFont.Size = 11;
                    NewField1153.Value = @"KOORDİNATÖR";

                    NewField1163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 65, 59, 70, false);
                    NewField1163.Name = "NewField1163";
                    NewField1163.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1163.TextFont.Size = 11;
                    NewField1163.TextFont.Bold = true;
                    NewField1163.Value = @":";

                    COORDINATOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 65, 197, 70, false);
                    COORDINATOR.Name = "COORDINATOR";
                    COORDINATOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    COORDINATOR.TextFont.Size = 11;
                    COORDINATOR.Value = @"{#COORDINATOR#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 72, 197, 72, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class dataset_InternalCorrespondenceKIMKNQL = ParentGroup.rsGroup.GetCurrentRecord<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class>(0);
                    CLASSIFICATIONDEGREE.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.ClassificationDegree) : "");
                    CLASSIFICATIONDEGREE.PostFieldValueCalculation();
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    SUBJECT.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.Subject) : "");
                    NUMBERLITERAL.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.NumberLiteral) : "");
                    NewField162.CalcValue = NewField162.Value;
                    NUMBER.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.Number) : "");
                    DOCUMENTDATE.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.DocumentDate) : "");
                    REFERENCE.CalcValue = REFERENCE.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    Reference.CalcValue = Reference.Value;
                    DELIVEREDBYNAME.CalcValue = @"";
                    DELIVEREDBYDUTY.CalcValue = @"";
                    ReportText.CalcValue = ReportText.Value;
                    DELIVEREDBYRANK.CalcValue = @"";
                    CAPTION.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.Caption) : "");
                    PARAF1.CalcValue = @"";
                    PARAF2.CalcValue = @"";
                    PARAF3.CalcValue = @"";
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    FROM.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.From) : "");
                    NewField1152.CalcValue = NewField1152.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    TO.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.To) : "");
                    NewField1153.CalcValue = NewField1153.Value;
                    NewField1163.CalcValue = NewField1163.Value;
                    COORDINATOR.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.Coordinator) : "");
                    return new TTReportObject[] { CLASSIFICATIONDEGREE,NewField151,NewField161,SUBJECT,NUMBERLITERAL,NewField162,NUMBER,DOCUMENTDATE,REFERENCE,NewField1261,Reference,DELIVEREDBYNAME,DELIVEREDBYDUTY,ReportText,DELIVEREDBYRANK,CAPTION,PARAF1,PARAF2,PARAF3,NewField1151,NewField1161,FROM,NewField1152,NewField1162,TO,NewField1153,NewField1163,COORDINATOR};
                }
                public override void RunPreScript()
                {
#region PART_A HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((KIMK)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalCorrespondenceKIMK bc = (InternalCorrespondenceKIMK)context.GetObject(new Guid(sObjectID),"InternalCorrespondenceKIMK");
            this.ReportText.Value = bc.ReportText;
            this.Reference.Value = bc.Reference;
#endregion PART_A HEADER_PreScript
                }

                public override void RunScript()
                {
#region PART_A HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((KIMK)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalCorrespondenceKIMK bc = (InternalCorrespondenceKIMK)context.GetObject(new Guid(sObjectID),"InternalCorrespondenceKIMK");
            ResUser ru = bc.ReportSender;
            
            int i = 1;
            foreach(Paraph p in bc.Paraphs)
            {
                TTReportField rf = FieldsByName("PARAF"+i);
                rf.CalcValue = p.ParaphLine;
                i++;
            }
            
            DELIVEREDBYNAME.CalcValue = ru.Name;
            if (ru.Rank != null)
                DELIVEREDBYRANK.CalcValue = ru.Rank.Name;
            
            if (ru.Title != null)
                DELIVEREDBYDUTY.CalcValue = (TTObjectClasses.Common.GetEnumValueDefOfEnumValue((Enum)ru.Title)).DisplayText;
#endregion PART_A HEADER_Script
                }
            }
            public partial class PART_AGroupFooter : TTReportSection
            {
                public KIMK MyParentReport
                {
                    get { return (KIMK)ParentReport; }
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
                    InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class dataset_InternalCorrespondenceKIMKNQL = ParentGroup.rsGroup.GetCurrentRecord<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class>(0);
                    CLASSIFICATIONDEGREE1.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.ClassificationDegree) : "");
                    CLASSIFICATIONDEGREE1.PostFieldValueCalculation();
                    return new TTReportObject[] { CLASSIFICATIONDEGREE1};
                }
            }

        }

        public PART_AGroup PART_A;

        public partial class EKGroup : TTReportGroup
        {
            public KIMK MyParentReport
            {
                get { return (KIMK)ParentReport; }
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
                public KIMK MyParentReport
                {
                    get { return (KIMK)ParentReport; }
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
                    InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class dataset_InternalCorrespondenceKIMKNQL = MyParentReport.PART_A.rsGroup.GetCurrentRecord<InternalCorrespondenceKIMK.InternalCorrespondenceKIMKNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    ADDITIONS.CalcValue = (dataset_InternalCorrespondenceKIMKNQL != null ? Globals.ToStringCore(dataset_InternalCorrespondenceKIMKNQL.Addition) : "");
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { NewField1,ADDITIONS,NewField11};
                }
                public override void RunPreScript()
                {
#region EK BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((KIMK)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalCorrespondenceKIMK bc = (InternalCorrespondenceKIMK)context.GetObject(new Guid(sObjectID),"InternalCorrespondenceKIMK");
            
            if(string.IsNullOrEmpty(bc.Addition))
                this.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            else
                this.Visible = TTReportTool.EvetHayirEnum.ehEvet;
#endregion EK BODY_PreScript
                }
            }

        }

        public EKGroup EK;

        public partial class LISTEGroup : TTReportGroup
        {
            public KIMK MyParentReport
            {
                get { return (KIMK)ParentReport; }
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
                public KIMK MyParentReport
                {
                    get { return (KIMK)ParentReport; }
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
            string sObjectID = ((KIMK)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalCorrespondenceKIMK bc = (InternalCorrespondenceKIMK)context.GetObject(new Guid(sObjectID),"InternalCorrespondenceKIMK");
            this.ListRTF.Value = bc.RelatedList;
#endregion LISTE BODY_PreScript
                }

                public override void RunScript()
                {
#region LISTE BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((KIMK)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            InternalCorrespondenceKIMK bc = (InternalCorrespondenceKIMK)context.GetObject(new Guid(sObjectID),"InternalCorrespondenceKIMK");
            
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

        public KIMK()
        {
            PART_A = new PART_AGroup(this,"PART_A");
            EK = new EKGroup(PART_A,"EK");
            LISTE = new LISTEGroup(PART_A,"LISTE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KIMK";
            Caption = "Karargah İçi Mütalaa Kağıdı";
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