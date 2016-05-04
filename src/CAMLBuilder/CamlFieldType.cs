#region License
// Copyright (C) 2012 by João Pedro Correia (https://github.com/joaope/camlbuilder)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

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
        URL,
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
