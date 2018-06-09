using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BaseLibrary;

namespace OperationsFrontEnd.Classes
{
    public static class CheckedListBoxExtensions
    {
        /// <summary>
        /// Returns all checked items as ColumnDetails list.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>List of ColumnDetails</returns>
        /// <remarks>recommended to check the count, if 0 no items checked.</remarks>
        public static List<ColumnDetails> CheckedIColumnDetailsList(this CheckedListBox sender)
        {
            return (from cd in sender.Items.OfType<ColumnDetails>().Where((item, index) => sender.GetItemChecked(index)) select cd).ToList();
        }

    }
}
