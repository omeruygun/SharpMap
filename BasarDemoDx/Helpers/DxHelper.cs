using BasarDemoDx.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Helpers
{
    public class DxHelper
    {
        internal static void FillItems(ComboBoxEdit combo, List<ControlItemModel> lst, string comboboxText, bool addChoose = true)
        {
            try
            {
                combo.Properties.Items.Clear();
                if (lst != null)
                {
                    ControlItemModel secili = new ControlItemModel();
                    int selectedItemIndex = -1;

                    if (addChoose)
                    {
                        string text = "Seçiniz...";

                        ControlItemModel select = new ControlItemModel()
                        {
                            Text = text,
                            Value = "-1"
                        };
                        combo.Properties.Items.Add(select);
                    }

                    if (!string.IsNullOrEmpty(comboboxText) && comboboxText != "-1")
                    {
                        if (lst.Any(a => a.Text != null && (a.Text.Replace("\"", "") == comboboxText || a.Text == comboboxText.Trim())))
                        {
                            secili = lst.FirstOrDefault(a => a.Text != null && (a.Text.Replace("\"", "") == comboboxText || a.Text == comboboxText.Trim()));
                        }
                    }

                    for (int i = 0; i < lst.Count; i++)
                    {
                        combo.Properties.Items.Add(lst[i]);

                        if (selectedItemIndex < 0)
                        {
                            if (secili == lst[i])
                            {
                                selectedItemIndex = addChoose ? i + 1 : i;
                            }
                            else if (comboboxText != null && comboboxText == "-1" && addChoose)
                            {
                                selectedItemIndex = 0;
                            }
                            else
                            {
                                //
                            }
                        }
                    }
                    if (comboboxText != "" && comboboxText != null && selectedItemIndex >= 0)
                    {
                        try
                        {
                            combo.SelectedIndex = selectedItemIndex;

                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            combo.SelectionStart = selectedItemIndex;

                        }
                    }
                    else
                    {
                        try
                        {
                            combo.SelectedIndex = 0;

                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            combo.SelectionStart = 0;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {

                }
            }
        }

        public static ControlItemModel GetSelectedItem(ComboBoxEdit combo)
        {
            if (combo.SelectedIndex > -1)
            {
                if (combo.Text == null || combo.Text == "")
                    return new ControlItemModel("", "-1");
                else if (combo.Text.IndexOf("Seçiniz...") > -1)
                    return new ControlItemModel("", "-1");
                else if (combo.Text.IndexOf("Seçiniz") > -1)
                    return new ControlItemModel("", "-1");
                else if (combo.Text.IndexOf("Choose") > -1)
                    return new ControlItemModel("", "-1");
                else
                    return (ControlItemModel)combo.SelectedItem;
            }
            else
                return new ControlItemModel("", "-1");

        }
        public static void SetSelectedValue(ComboBoxEdit combo, string selectedValue)
        {
            try
            {
                if (combo != null && combo.Properties.Items.Count > 0)
                {
                    int itemCount = combo.Properties.Items.Count;
                    int selectedIndex = -1;
                    for (int i = 0; i < itemCount; i++)
                    {
                        string itemValue = (combo.Properties.Items[i] as ControlItemModel).Value.ToString().Replace("\"", "");
                        if (itemValue == selectedValue)
                        {
                            selectedIndex = i;
                            break;
                        }
                    }
                    if (selectedIndex >= 0)
                    {
                        combo.SelectedIndex = selectedIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Loglama Eklenecek
            }
        }
    }
}
