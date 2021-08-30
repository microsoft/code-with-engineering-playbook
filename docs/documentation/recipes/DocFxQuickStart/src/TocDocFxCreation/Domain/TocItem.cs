// Licensed to ZF and contributors under one or more agreements.
// ZF and contributors licenses this file to you under the MIT license.

namespace TocDocFxCreation.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// A TOC item.
    /// </summary>
    public class TocItem
    {
        private ICollection<TocItem> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="TocItem"/> class.
        /// </summary>
        public TocItem()
        {
            this.Sequence = int.MaxValue;
        }

        /// <summary>
        /// Gets or sets the sequence number for ordering with .order file.
        /// </summary>
        /// <value>Default is int.MaxValue, to make sure lower values are in front of the rest.</value>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets the file name. This is just used for processing.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the sortable name of the item.
        /// </summary>
        /// <value>Generated simplified title that is used for sorting.</value>
        public string SortableTitle { get; set; }

        /// <summary>
        /// Gets or sets title of the item.
        /// </summary>
        /// <value>Title of the item.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets link to the item.
        /// </summary>
        /// <value>Link to the item, relative where possible.</value>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the items attached to this item (nodes).
        /// </summary>
        /// <value>Child items of the current item.</value>
        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "We need it to be writeable for sort.")]
        public ICollection<TocItem> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        /// <summary>
        /// Add an item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="insertTop">Insert at top of list.</param>
        public void AddItem(TocItem item, bool insertTop = false)
        {
            if (item == null)
            {
                return;
            }

            if (this.items == null)
            {
                this.items = new Collection<TocItem>();
            }

            item.SortableTitle = item.Title.ToUpperInvariant();

            if (this.items.Any() && insertTop)
            {
                ((Collection<TocItem>)this.items).Insert(0, item);
            }
            else
            {
                this.items.Add(item);
            }
        }
    }
}
