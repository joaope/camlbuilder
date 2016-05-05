namespace CamlBuilder
{
    /// <summary>
    /// Specifies types of reference for a field in a list.
    /// </summary>
    public enum CamlFieldType
    {
        /// <summary>
        /// Indicates a Text field type
        /// </summary>
        [CamlText("Text")]
        Text,

        /// <summary>
        /// Indicates a DateTime field type
        /// </summary>
        [CamlText("DateTime")]
        DateTime,

        /// <summary>
        /// Indicates a Integer field type
        /// </summary>
        [CamlText("Integer")]
        Integer,

        /// <summary>
        /// Indicates a Note field type
        /// </summary>
        [CamlText("Note")]
        Note,

        /// <summary>
        /// Indicates a Choice field type
        /// </summary>
        [CamlText("Choice")]
        Choice,

        /// <summary>
        /// Indicates a Number field type
        /// </summary>
        [CamlText("Number")]
        Number,

        /// <summary>
        /// Indicates a Guid field type
        /// </summary>
        [CamlText("Guid")]
        Guid,

        /// <summary>
        /// Indicates a Boolean field type
        /// </summary>
        [CamlText("Boolean")]
        Boolean,

        /// <summary>
        /// Indicates a Counter field type
        /// </summary>
        [CamlText("Counter")]
        Counter,

        /// <summary>
        /// Indicates a Currency field type
        /// </summary>
        [CamlText("Currency")]
        Currency,

        /// <summary>
        /// Indicates an URL field type
        /// </summary>
        [CamlText("URL")]
        Url,
        /// <summary>
        /// Indicates a Computed field type
        /// </summary>
        [CamlText("Computed")]
        Computed,

        /// <summary>
        /// Indicates a Lookup field type
        /// </summary>
        [CamlText("Lookup")]
        Lookup,

        /// <summary>
        /// Indicates a File field type
        /// </summary>
        [CamlText("File")]
        File,

        /// <summary>
        /// Indicates an User field type
        /// </summary>
        [CamlText("User")]
        User,

        /// <summary>
        /// Indicates an Attachments field type
        /// </summary>
        [CamlText("Attachments")]
        Attachments,

        /// <summary>
        /// Indicates a MultiChoice field type
        /// </summary>
        [CamlText("MultiChoice")]
        MultiChoice,

        /// <summary>
        /// Indicates a GridChoice field type
        /// </summary>
        [CamlText("GridChoice")]
        GridChoice,

        /// <summary>
        /// Indicates a Threading field type
        /// </summary>
        [CamlText("Threading")]
        Threading,

        /// <summary>
        /// Indicates a CrossProjectLink field type
        /// </summary>
        [CamlText("CrossProjectLink")]
        CrossProjectLink,

        /// <summary>
        /// Indicates a Recurrence field type
        /// </summary>
        [CamlText("Recurrence")]
        Recurrence,

        /// <summary>
        /// Indicates a ModStat field type
        /// </summary>
        [CamlText("ModStat")]
        ModStat,

        /// <summary>
        /// Indicates a ContentTypeId field type
        /// </summary>
        [CamlText("ContentTypeId")]
        ContentTypeId,

        /// <summary>
        /// Indicates a WorkflowStatus field type
        /// </summary>
        [CamlText("WorkflowStatus")]
        WorkflowStatus,

        /// <summary>
        /// Indicates a AllDayEvent field type
        /// </summary>
        [CamlText("AllDayEvent")]
        AllDayEvent,

        /// <summary>
        /// Indicates an Error field type
        /// </summary>
        [CamlText("Error")]
        Error,

        /// <summary>
        /// Indicates a WorkflowEventType field type
        /// </summary>
        [CamlText("WorkflowEventType")]
        WorkflowEventType
    }
}
