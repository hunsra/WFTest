using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTest
{
    public partial class frmMain : Form
    {
        private bool _useDataSource = false;
        private bool _disabledDuringUpdates = false;
        private bool _boldingInLine = false;
        private bool _disableBolding = false;
        private Random _RNG = new Random((int)DateTime.Now.Ticks);
        private BindingList<GridData> _gridData = new BindingList<GridData>();

        public frmMain()
        {
            InitializeComponent();

            // Set controls to default state
            dgFiles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgFiles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cbDisable.Checked = _useDataSource;
            cbDisable.Checked = _disabledDuringUpdates;
            cbDisableBolding.Checked = _disableBolding;
            
            // Add a handler for important events
            Resize += FrmMain_Resize;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            // For timing
            DateTime start = DateTime.Now;

            dgFiles.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            dgFiles.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);

            // Calculate the width of the first column - all remaining width or width of widest text, whichever is larger
            var current = dgFiles.Columns[0].Width;
            int offset = (dgFiles.ScrollBars & ScrollBars.Vertical) != ScrollBars.None ? System.Windows.Forms.SystemInformation.VerticalScrollBarWidth : 0;
            dgFiles.Columns[0].Width = Math.Max(current, dgFiles.Width - (SystemInformation.SizingBorderWidth * 2) - dgFiles.Columns[1].Width - (dgFiles.Columns[0].DividerWidth == 0 ? 1 : dgFiles.Columns[0].Width) - offset);

            // For timing
            TimeSpan elapsed = DateTime.Now - start;
            lblResizeInfo.Text = $"Resize time: {elapsed.TotalMilliseconds}ms";
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            var styleBold = new DataGridViewCellStyle { Font = new Font(dgFiles.Font, FontStyle.Bold) };
            var styleRegular = new DataGridViewCellStyle { Font = new Font(dgFiles.Font, FontStyle.Regular) };

            cbDataSource.Enabled = false;
            cbDisable.Enabled = false;
            cbBoldingInLine.Enabled = false;
            cbDisableBolding.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;

            // This is to maximize the work the datagridview needs to do to load the data
            var gen = GC.GetGeneration(dgFiles);
            dgFiles.Rows.Clear();
            GC.Collect(gen, GCCollectionMode.Forced, true, true);
            GC.WaitForFullGCComplete();

            // For timing
            DateTime start = DateTime.Now;
            
            if (_disabledDuringUpdates == true)
            {
                // Disable the entire control - this prevents visual updates
                dgFiles.Enabled = false;
            }

            if (_useDataSource == false)
            {
                dgFiles.DataSource = null;
                dgFiles.Columns.Clear();
                dgFiles.Columns.Add("cName", "Name");
                dgFiles.Columns.Add("cDate", "Date");

                // Add 1500 items to the data grid view
                for (int i = 0; i < 1500; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    // Randomly set bolded font on about 40% of the rows, unless diabled
                    if (_disableBolding == false && _boldingInLine == true)
                    {
                        if (_RNG.Next(1, 10) >= 7)
                        {
                            row.DefaultCellStyle = new DataGridViewCellStyle(styleBold);
                        }
                    }

                    row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells[0].Value = $"C:\\Folder\\Subfolder\\Long_File_Name_{_RNG.Next(1, int.MaxValue)}.pdf";
                    row.Cells[1].Value = $"{DateTime.Now:G} - {_RNG.Next(1, 1000):0000}";

                    dgFiles.Rows.Add(row);
                }

                if (_disableBolding == false && _boldingInLine == false)
                {
                    foreach (DataGridViewRow row in dgFiles.Rows)
                    {
                        row.DefaultCellStyle = _RNG.Next(1, 10) >= 7 ? styleBold : styleRegular;
                    }
                }
            }
            else
            {
                if (dgFiles.DataSource == null)
                {
                    dgFiles.Columns.Clear();
                }

                dgFiles.DataSource = _gridData;
                _gridData.Clear();

                for (int i = 0; i < 1500; i++)
                {
                    GridData data = new GridData() { Name = $"C:\\Folder\\Subfolder\\Long_File_Name_{_RNG.Next(1, int.MaxValue)}.pdf", Date = $"{DateTime.Now:G} - {_RNG.Next(1, 1000):0000}" };
                    _gridData.Add(data);

                    // Randomly set bolded font on about 40% of the rows, unless diabled
                    if (_disableBolding == false && _boldingInLine == true)
                    {
                        dgFiles.Rows[dgFiles.Rows.Count - 1].DefaultCellStyle = _RNG.Next(1, 10) >= 7 ? styleBold : styleRegular;
                    }
                }


                // Randomly set bolded font on about 40% of the rows, unless diabled
                if (_disableBolding == false && _boldingInLine == false)
                {
                    foreach (DataGridViewRow row in dgFiles.Rows)
                    {
                        row.DefaultCellStyle = _RNG.Next(1, 10) >= 7 ? styleBold : styleRegular;
                    }
                }
            }

            // Force a sort, if present
            if (dgFiles.SortedColumn != null)
            {
                dgFiles.Sort(dgFiles.SortedColumn, dgFiles.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }

            // Force a resize
            ResizeColumns();

            if (_disabledDuringUpdates == true)
            {
                // Re-enable the entire control - this allows a final visual update
                dgFiles.Enabled = true;
            }
            
            // For timing
            TimeSpan elapsed = DateTime.Now - start;
            lblFillInfo.Text = $"Fill time: {elapsed.TotalMilliseconds}ms";

            cbDataSource.Enabled = true;
            cbDisable.Enabled = true;
            cbBoldingInLine.Enabled = true;
            cbDisableBolding.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        private void cbDisable_CheckedChanged(object sender, EventArgs e)
        {
            _disabledDuringUpdates = cbDisable.Checked;
        }

        private void cbDisableBolding_CheckedChanged(object sender, EventArgs e)
        {
            _disableBolding = cbDisableBolding.Checked;
        }

        private void cbDataSource_CheckedChanged(object sender, EventArgs e)
        {
            _useDataSource = cbDataSource.Checked;
        }

        private void cbBoldingInLine_CheckedChanged(object sender, EventArgs e)
        {
            _boldingInLine = cbBoldingInLine.Checked;
        }
    }
}
