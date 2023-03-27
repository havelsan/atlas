
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
    /// Tertip Emri
    /// </summary>
    public partial class TertipEmri : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public TertipEmri MyParentReport
            {
                get { return (TertipEmri)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField MSGORDER { get {return Header().MSGORDER;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField GROUPFRONTADDITION { get {return Header().GROUPFRONTADDITION;} }
            public TTReportField NewField124 { get {return Header().NewField124;} }
            public TTReportField NewField125 { get {return Header().NewField125;} }
            public TTReportField NewField126 { get {return Header().NewField126;} }
            public TTReportField NewField127 { get {return Header().NewField127;} }
            public TTReportField NewField1621 { get {return Header().NewField1621;} }
            public TTReportField NewField1622 { get {return Header().NewField1622;} }
            public TTReportField NEED { get {return Header().NEED;} }
            public TTReportField INFO { get {return Header().INFO;} }
            public TTReportField DATETIMEGROUP { get {return Header().DATETIMEGROUP;} }
            public TTReportField PRIVACYLEVEL { get {return Header().PRIVACYLEVEL;} }
            public TTReportField FILENO { get {return Header().FILENO;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1421 { get {return Footer().NewField1421;} }
            public TTReportField NewField1623 { get {return Footer().NewField1623;} }
            public TTReportField NewField1721 { get {return Footer().NewField1721;} }
            public TTReportField NewField11262 { get {return Footer().NewField11262;} }
            public TTReportField NewField12262 { get {return Footer().NewField12262;} }
            public TTReportField NewField116211 { get {return Footer().NewField116211;} }
            public TTReportField NewField116222 { get {return Footer().NewField116222;} }
            public TTReportField PAGENO { get {return Footer().PAGENO;} }
            public TTReportField NewField126211 { get {return Footer().NewField126211;} }
            public TTReportField NewField126221 { get {return Footer().NewField126221;} }
            public TTReportField NewField1112621 { get {return Footer().NewField1112621;} }
            public TTReportField NewField1112622 { get {return Footer().NewField1112622;} }
            public TTReportField NewField1122621 { get {return Footer().NewField1122621;} }
            public TTReportField NewField11262111 { get {return Footer().NewField11262111;} }
            public TTReportField NewField13261 { get {return Footer().NewField13261;} }
            public TTReportField NewField111226111 { get {return Footer().NewField111226111;} }
            public TTReportField NewField116231 { get {return Footer().NewField116231;} }
            public TTReportField NewField1111622111 { get {return Footer().NewField1111622111;} }
            public TTReportField NewField1132611 { get {return Footer().NewField1132611;} }
            public TTReportField WRITER { get {return Footer().WRITER;} }
            public TTReportField ITOBJECTID { get {return Footer().ITOBJECTID;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ItemTransfer.TertipEmriNQL_Class>("TertipEmriNQL", ItemTransfer.TertipEmriNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public TertipEmri MyParentReport
                {
                    get { return (TertipEmri)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField MSGORDER;
                public TTReportField NewField122;
                public TTReportField GROUPFRONTADDITION;
                public TTReportField NewField124;
                public TTReportField NewField125;
                public TTReportField NewField126;
                public TTReportField NewField127;
                public TTReportField NewField1621;
                public TTReportField NewField1622;
                public TTReportField NEED;
                public TTReportField INFO;
                public TTReportField DATETIMEGROUP;
                public TTReportField PRIVACYLEVEL;
                public TTReportField FILENO;
                public TTReportRTF ReportRTF;
                public TTReportField OBJECTID;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 94;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 10, 203, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.Value = @"MESAJ FORMU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 15, 203, 28, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 28, 44, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.Value = @"Mesaj Talimatı";

                    MSGORDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 28, 106, 33, false);
                    MSGORDER.Name = "MSGORDER";
                    MSGORDER.DrawStyle = DrawStyleConstants.vbSolid;
                    MSGORDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    MSGORDER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MSGORDER.Value = @"{#MSGORDER#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 28, 137, 33, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.Value = @"Grup-Ön Ek";

                    GROUPFRONTADDITION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 28, 203, 33, false);
                    GROUPFRONTADDITION.Name = "GROUPFRONTADDITION";
                    GROUPFRONTADDITION.DrawStyle = DrawStyleConstants.vbSolid;
                    GROUPFRONTADDITION.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUPFRONTADDITION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GROUPFRONTADDITION.Value = @"{#GROUPFRONTADDITION#}";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 33, 75, 38, false);
                    NewField124.Name = "NewField124";
                    NewField124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField124.Value = @"Öncelik Derecesi";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 33, 106, 38, false);
                    NewField125.Name = "NewField125";
                    NewField125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125.Value = @"Tarih Saat Grubu";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 33, 137, 38, false);
                    NewField126.Name = "NewField126";
                    NewField126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField126.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField126.Value = @"Gizlilik Derecesi";

                    NewField127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 33, 203, 38, false);
                    NewField127.Name = "NewField127";
                    NewField127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField127.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField127.Value = @"Dosya Numarası";

                    NewField1621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 38, 44, 43, false);
                    NewField1621.Name = "NewField1621";
                    NewField1621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1621.Value = @"Gereği";

                    NewField1622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 38, 75, 43, false);
                    NewField1622.Name = "NewField1622";
                    NewField1622.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1622.Value = @"Bilgi";

                    NEED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 43, 44, 48, false);
                    NEED.Name = "NEED";
                    NEED.DrawStyle = DrawStyleConstants.vbSolid;
                    NEED.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEED.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEED.Value = @"{#NEED#}";

                    INFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 43, 75, 48, false);
                    INFO.Name = "INFO";
                    INFO.DrawStyle = DrawStyleConstants.vbSolid;
                    INFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    INFO.Value = @"{#INFO#}";

                    DATETIMEGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 38, 106, 48, false);
                    DATETIMEGROUP.Name = "DATETIMEGROUP";
                    DATETIMEGROUP.DrawStyle = DrawStyleConstants.vbSolid;
                    DATETIMEGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATETIMEGROUP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATETIMEGROUP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATETIMEGROUP.Value = @"{#DATETIMEGROUP#}";

                    PRIVACYLEVEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 38, 137, 48, false);
                    PRIVACYLEVEL.Name = "PRIVACYLEVEL";
                    PRIVACYLEVEL.DrawStyle = DrawStyleConstants.vbSolid;
                    PRIVACYLEVEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRIVACYLEVEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRIVACYLEVEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRIVACYLEVEL.Value = @"{#PRIVACYLEVEL#}";

                    FILENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 38, 203, 48, false);
                    FILENO.Name = "FILENO";
                    FILENO.DrawStyle = DrawStyleConstants.vbSolid;
                    FILENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FILENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FILENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FILENO.Value = @"{#FILENO#}";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 19, 50, 201, 94, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 67, 235, 72, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.CharSet = 1;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 48, 17, 95, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 48, 203, 95, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ItemTransfer.TertipEmriNQL_Class dataset_TertipEmriNQL = ParentGroup.rsGroup.GetCurrentRecord<ItemTransfer.TertipEmriNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    MSGORDER.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.MsgOrder) : "");
                    NewField122.CalcValue = NewField122.Value;
                    GROUPFRONTADDITION.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.GroupFrontAddition) : "");
                    NewField124.CalcValue = NewField124.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField126.CalcValue = NewField126.Value;
                    NewField127.CalcValue = NewField127.Value;
                    NewField1621.CalcValue = NewField1621.Value;
                    NewField1622.CalcValue = NewField1622.Value;
                    NEED.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.Need) : "");
                    INFO.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.Info) : "");
                    DATETIMEGROUP.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.DateTimeGroup) : "");
                    PRIVACYLEVEL.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.PrivacyLevel) : "");
                    FILENO.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.FileNo) : "");
                    ReportRTF.CalcValue = ReportRTF.Value;
                    OBJECTID.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.ObjectID) : "");
                    return new TTReportObject[] { NewField1,NewField11,NewField12,MSGORDER,NewField122,GROUPFRONTADDITION,NewField124,NewField125,NewField126,NewField127,NewField1621,NewField1622,NEED,INFO,DATETIMEGROUP,PRIVACYLEVEL,FILENO,ReportRTF,OBJECTID};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    if(OBJECTID.CalcValue != "")
            {
                ItemTransfer itemTransfer = (ItemTransfer)MyParentReport.ReportObjectContext.GetObject(new Guid(OBJECTID.CalcValue), typeof(ItemTransfer));
                ReportRTF.Value = itemTransfer.ReportParagraph;
            }
#endregion HEADER HEADER_PreScript
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public TertipEmri MyParentReport
                {
                    get { return (TertipEmri)ParentReport; }
                }
                
                public TTReportField NewField1421;
                public TTReportField NewField1623;
                public TTReportField NewField1721;
                public TTReportField NewField11262;
                public TTReportField NewField12262;
                public TTReportField NewField116211;
                public TTReportField NewField116222;
                public TTReportField PAGENO;
                public TTReportField NewField126211;
                public TTReportField NewField126221;
                public TTReportField NewField1112621;
                public TTReportField NewField1112622;
                public TTReportField NewField1122621;
                public TTReportField NewField11262111;
                public TTReportField NewField13261;
                public TTReportField NewField111226111;
                public TTReportField NewField116231;
                public TTReportField NewField1111622111;
                public TTReportField NewField1132611;
                public TTReportField WRITER;
                public TTReportField ITOBJECTID;
                public TTReportField PROJECTNO; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 67;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 33, 109, 38, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1421.Value = @"Mesajın Geldiği";

                    NewField1623 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 33, 46, 38, false);
                    NewField1623.Name = "NewField1623";
                    NewField1623.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1623.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1623.Value = @"Sayfa";

                    NewField1721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 33, 203, 38, false);
                    NewField1721.Name = "NewField1721";
                    NewField1721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1721.Value = @"Mesajın Çekildiği";

                    NewField11262 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 38, 75, 43, false);
                    NewField11262.Name = "NewField11262";
                    NewField11262.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11262.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11262.Value = @"TSG";

                    NewField12262 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 38, 109, 43, false);
                    NewField12262.Name = "NewField12262";
                    NewField12262.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12262.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12262.Value = @"İşletmen";

                    NewField116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 43, 75, 53, false);
                    NewField116211.Name = "NewField116211";
                    NewField116211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116211.Value = @"";

                    NewField116222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 43, 109, 53, false);
                    NewField116222.Name = "NewField116222";
                    NewField116222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116222.Value = @"";

                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 38, 46, 53, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.DrawStyle = DrawStyleConstants.vbSolid;
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENO.Value = @"{@pagenumber@}";

                    NewField126211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 38, 135, 43, false);
                    NewField126211.Name = "NewField126211";
                    NewField126211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField126211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField126211.Value = @"TSG";

                    NewField126221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 38, 203, 43, false);
                    NewField126221.Name = "NewField126221";
                    NewField126221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField126221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField126221.Value = @"İşletmen";

                    NewField1112621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 38, 166, 43, false);
                    NewField1112621.Name = "NewField1112621";
                    NewField1112621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112621.Value = @"Sistem";

                    NewField1112622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 43, 135, 53, false);
                    NewField1112622.Name = "NewField1112622";
                    NewField1112622.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112622.Value = @"";

                    NewField1122621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 43, 203, 53, false);
                    NewField1122621.Name = "NewField1122621";
                    NewField1122621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122621.Value = @"";

                    NewField11262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 43, 166, 53, false);
                    NewField11262111.Name = "NewField11262111";
                    NewField11262111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11262111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11262111.Value = @"";

                    NewField13261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 109, 10, false);
                    NewField13261.Name = "NewField13261";
                    NewField13261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13261.Value = @"Parafe/Koordine";

                    NewField111226111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 10, 109, 33, false);
                    NewField111226111.Name = "NewField111226111";
                    NewField111226111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111226111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111226111.Value = @"";

                    NewField116231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 203, 10, false);
                    NewField116231.Name = "NewField116231";
                    NewField116231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField116231.Value = @"Kaleme Alanın 
İmza Bloku";

                    NewField1111622111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 10, 203, 33, false);
                    NewField1111622111.Name = "NewField1111622111";
                    NewField1111622111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111622111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111622111.Value = @"";

                    NewField1132611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 160, 10, false);
                    NewField1132611.Name = "NewField1132611";
                    NewField1132611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1132611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1132611.Value = @"Kaleme Alanın 
İmza Bloku";

                    WRITER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 10, 160, 33, false);
                    WRITER.Name = "WRITER";
                    WRITER.DrawStyle = DrawStyleConstants.vbSolid;
                    WRITER.FieldType = ReportFieldTypeEnum.ftVariable;
                    WRITER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WRITER.MultiLine = EvetHayirEnum.ehEvet;
                    WRITER.WordBreak = EvetHayirEnum.ehEvet;
                    WRITER.Value = @"";

                    ITOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 8, 243, 13, false);
                    ITOBJECTID.Name = "ITOBJECTID";
                    ITOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ITOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITOBJECTID.TextFont.Name = "Arial Narrow";
                    ITOBJECTID.TextFont.CharSet = 1;
                    ITOBJECTID.Value = @"{#OBJECTID#}";

                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 59, 42, 64, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ItemTransfer.TertipEmriNQL_Class dataset_TertipEmriNQL = ParentGroup.rsGroup.GetCurrentRecord<ItemTransfer.TertipEmriNQL_Class>(0);
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField1623.CalcValue = NewField1623.Value;
                    NewField1721.CalcValue = NewField1721.Value;
                    NewField11262.CalcValue = NewField11262.Value;
                    NewField12262.CalcValue = NewField12262.Value;
                    NewField116211.CalcValue = NewField116211.Value;
                    NewField116222.CalcValue = NewField116222.Value;
                    PAGENO.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField126211.CalcValue = NewField126211.Value;
                    NewField126221.CalcValue = NewField126221.Value;
                    NewField1112621.CalcValue = NewField1112621.Value;
                    NewField1112622.CalcValue = NewField1112622.Value;
                    NewField1122621.CalcValue = NewField1122621.Value;
                    NewField11262111.CalcValue = NewField11262111.Value;
                    NewField13261.CalcValue = NewField13261.Value;
                    NewField111226111.CalcValue = NewField111226111.Value;
                    NewField116231.CalcValue = NewField116231.Value;
                    NewField1111622111.CalcValue = NewField1111622111.Value;
                    NewField1132611.CalcValue = NewField1132611.Value;
                    WRITER.CalcValue = @"";
                    ITOBJECTID.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.ObjectID) : "");
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { NewField1421,NewField1623,NewField1721,NewField11262,NewField12262,NewField116211,NewField116222,PAGENO,NewField126211,NewField126221,NewField1112621,NewField1112622,NewField1122621,NewField11262111,NewField13261,NewField111226111,NewField116231,NewField1111622111,NewField1132611,WRITER,ITOBJECTID,PROJECTNO};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    ItemTransfer itemTransfer = (ItemTransfer)MyParentReport.ReportObjectContext.GetObject(new Guid(ITOBJECTID.CalcValue), typeof(ItemTransfer));
            if (itemTransfer.Writer != null)
            {
                WRITER.CalcValue += itemTransfer.Writer.Name;
                if(itemTransfer.Writer.MilitaryClass != null)
                    WRITER.CalcValue += "\n" + itemTransfer.Writer.MilitaryClass.ShortName;
                if(itemTransfer.Writer.Rank != null)
                    WRITER.CalcValue += "\n" + itemTransfer.Writer.Rank.ShortName;
            }            
            
            string objectID = ((TertipEmri)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class BASLIKGroup : TTReportGroup
        {
            public TertipEmri MyParentReport
            {
                get { return (TertipEmri)ParentReport; }
            }

            new public BASLIKGroupBody Body()
            {
                return (BASLIKGroupBody)_body;
            }
            public TTReportField NewField114126111 { get {return Body().NewField114126111;} }
            public TTReportField NewField1111621411 { get {return Body().NewField1111621411;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField114126112 { get {return Body().NewField114126112;} }
            public TTReportField NewField11141 { get {return Body().NewField11141;} }
            public TTReportField NewField114111 { get {return Body().NewField114111;} }
            public TTReportField NewField1111411 { get {return Body().NewField1111411;} }
            public TTReportField NewField1111412 { get {return Body().NewField1111412;} }
            public BASLIKGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BASLIKGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BASLIKGroupBody(this);
            }

            public partial class BASLIKGroupBody : TTReportSection
            {
                public TertipEmri MyParentReport
                {
                    get { return (TertipEmri)ParentReport; }
                }
                
                public TTReportField NewField114126111;
                public TTReportField NewField1111621411;
                public TTReportShape NewLine1;
                public TTReportField NewField114126112;
                public TTReportField NewField11141;
                public TTReportField NewField114111;
                public TTReportField NewField1111411;
                public TTReportField NewField1111412; 
                public BASLIKGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    NewField114126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 201, 6, false);
                    NewField114126111.Name = "NewField114126111";
                    NewField114126111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114126111.Value = @"TERTİBİ YAPILAN MALZEME LİSTESİ";

                    NewField1111621411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 8, 201, 13, false);
                    NewField1111621411.Name = "NewField1111621411";
                    NewField1111621411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111621411.Value = @"( BEŞ SÜTUN HALİNDE OKUYUNUZ )";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 7, 201, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField114126112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 14, 28, 19, false);
                    NewField114126112.Name = "NewField114126112";
                    NewField114126112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114126112.TextFont.Underline = true;
                    NewField114126112.Value = @"S.N";

                    NewField11141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 14, 104, 19, false);
                    NewField11141.Name = "NewField11141";
                    NewField11141.TextFont.Underline = true;
                    NewField11141.Value = @"MALZEMENİN ADI";

                    NewField114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 14, 126, 19, false);
                    NewField114111.Name = "NewField114111";
                    NewField114111.TextFont.Underline = true;
                    NewField114111.Value = @"MİADI";

                    NewField1111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 14, 142, 19, false);
                    NewField1111411.Name = "NewField1111411";
                    NewField1111411.TextFont.Underline = true;
                    NewField1111411.Value = @"MİKTARI";

                    NewField1111412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 14, 201, 19, false);
                    NewField1111412.Name = "NewField1111412";
                    NewField1111412.TextFont.Underline = true;
                    NewField1111412.Value = @"GÖNDERECEK BİRLİK/KURUM";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField114126111.CalcValue = NewField114126111.Value;
                    NewField1111621411.CalcValue = NewField1111621411.Value;
                    NewField114126112.CalcValue = NewField114126112.Value;
                    NewField11141.CalcValue = NewField11141.Value;
                    NewField114111.CalcValue = NewField114111.Value;
                    NewField1111411.CalcValue = NewField1111411.Value;
                    NewField1111412.CalcValue = NewField1111412.Value;
                    return new TTReportObject[] { NewField114126111,NewField1111621411,NewField114126112,NewField11141,NewField114111,NewField1111411,NewField1111412};
                }
            }

        }

        public BASLIKGroup BASLIK;

        public partial class MAINGroup : TTReportGroup
        {
            public TertipEmri MyParentReport
            {
                get { return (TertipEmri)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField EXPIRATION { get {return Body().EXPIRATION;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TARGETMILITARYUNIT { get {return Body().TARGETMILITARYUNIT;} }
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
                list[0] = new TTReportNqlData<ItemTransferDetail.TertipEmriNQL_Class>("TertipEmriNQL", ItemTransferDetail.TertipEmriNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.HEADER.OBJECTID.CalcValue)));
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
                public TertipEmri MyParentReport
                {
                    get { return (TertipEmri)ParentReport; }
                }
                
                public TTReportField SNO;
                public TTReportField MATERIAL;
                public TTReportField EXPIRATION;
                public TTReportField AMOUNT;
                public TTReportField TARGETMILITARYUNIT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 28, 5, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SNO.Value = @"{@groupcounter@}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 104, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.Value = @"{#PURCHASEITEMDEF#}";

                    EXPIRATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 126, 5, false);
                    EXPIRATION.Name = "EXPIRATION";
                    EXPIRATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPIRATION.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 142, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.NoClip = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.Value = @"{#AMOUNT#} + "" "" + {#PURCHASEITEMUNITTYPE#}";

                    TARGETMILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 201, 5, false);
                    TARGETMILITARYUNIT.Name = "TARGETMILITARYUNIT";
                    TARGETMILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARGETMILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    TARGETMILITARYUNIT.NoClip = EvetHayirEnum.ehEvet;
                    TARGETMILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    TARGETMILITARYUNIT.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARGETMILITARYUNIT.Value = @"{#TARGETMILITARYUNIT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ItemTransferDetail.TertipEmriNQL_Class dataset_TertipEmriNQL = ParentGroup.rsGroup.GetCurrentRecord<ItemTransferDetail.TertipEmriNQL_Class>(0);
                    SNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    MATERIAL.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.Purchaseitemdef) : "");
                    EXPIRATION.CalcValue = @"";
                    TARGETMILITARYUNIT.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.Targetmilitaryunit) : "");
                    AMOUNT.CalcValue = (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.Amount) : "") + " " + (dataset_TertipEmriNQL != null ? Globals.ToStringCore(dataset_TertipEmriNQL.Purchaseitemunittype) : "");
                    return new TTReportObject[] { SNO,MATERIAL,EXPIRATION,TARGETMILITARYUNIT,AMOUNT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TertipEmri()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            BASLIK = new BASLIKGroup(HEADER,"BASLIK");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TERTIPEMRI";
            Caption = "Tertip Emri";
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