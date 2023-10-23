using System;

namespace GameName.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        public interface ICollectionProcessor
        {
            Type ItemType { get; }

            string ItemLanguageKeyword { get; }
        }
    }
}
