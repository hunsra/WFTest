using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTest
{
    public partial class frmMain : Form
    {
        private DataGridViewCellStyle _styleBold;
        private DataGridViewCellStyle _styleRegular;
        private bool _useDataSource = false;
        private bool _useVirtual = false;
        private bool _virtualDelay = false;
        private bool _disabledDuringUpdates = false;
        private bool _boldingInLine = false;
        private bool _disableBolding = false;
        private Random _RNG = new Random((int)DateTime.Now.Ticks);
        private BindingList<GridData> _gridData = new BindingList<GridData>();

        public frmMain()
        {
            InitializeComponent();

            // Set controls to default state
            cbDataSource.Checked = _useDataSource;
            cbVirtual.Checked = _useVirtual;
            cbDelay.Checked = _virtualDelay;
            cbDisable.Checked = _disabledDuringUpdates;
            cbBoldingInLine.Checked = _boldingInLine;
            cbDisableBolding.Checked = _disableBolding;
            EnableControls(true);

            _styleBold = new DataGridViewCellStyle { Font = new Font(dgFiles.Font, FontStyle.Bold) };
            _styleRegular = new DataGridViewCellStyle { Font = new Font(dgFiles.Font, FontStyle.Regular) };

            // Add a handler for important events
            Resize += FrmMain_Resize;
            dgFiles.Scroll += OnScroll;
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            ResizeColumns();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            // For timing
            DateTime start = DateTime.Now;

            if (dgFiles.Columns.Count >= 2)
            {
                dgFiles.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.DisplayedCells);
                dgFiles.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.DisplayedCells);

                // Calculate the width of the first column - all remaining width or width of widest text, whichever is larger
                var current = dgFiles.Columns[0].Width;
                int offset = (dgFiles.ScrollBars & ScrollBars.Vertical) != ScrollBars.None ? System.Windows.Forms.SystemInformation.VerticalScrollBarWidth : 0;
                dgFiles.Columns[0].Width = Math.Max(current, dgFiles.Width - (SystemInformation.SizingBorderWidth * 2) - dgFiles.Columns[1].Width - (dgFiles.Columns[0].DividerWidth == 0 ? 1 : dgFiles.Columns[0].Width) - offset);
            }

            // For timing
            TimeSpan elapsed = DateTime.Now - start;
            lblResizeInfo.Text = $"Resize time: {elapsed.TotalMilliseconds}ms";
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            EnableControls(false);

            // Clear any old handler
            dgFiles.CellValueNeeded -= OnCellValueNeeded;

            Cursor.Current = Cursors.WaitCursor;

            //// This is to maximize the work the datagridview needs to do to load the data
            //var gen = GC.GetGeneration(dgFiles);
            //dgFiles.Rows.Clear();
            //GC.Collect(gen, GCCollectionMode.Forced, true);
            //GC.WaitForFullGCComplete();

            // For timing
            DateTime start = DateTime.Now;

            if (_disabledDuringUpdates == true)
            {
                // Disable the entire control - this prevents visual updates
                dgFiles.Enabled = false;
            }

            if (_useDataSource == false && _useVirtual == false)
            {
                dgFiles.DataSource = null;
                dgFiles.VirtualMode = false;
                dgFiles.Columns.Clear();
                dgFiles.Columns.Add("cName", "Name");
                dgFiles.Columns.Add("cDate", "Date");

                this.BeginInvoke(new Action(() => 
                {
                    // For timing
                    DateTime threadStart = DateTime.Now;

                    // Add 1500 items to the data grid view
                    for (int i = 0; i < 1500; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();

                        // Randomly set bolded font on about 40% of the rows, unless diabled
                        if (_disableBolding == false && _boldingInLine == true)
                        {
                            if (_RNG.Next(1, 10) >= 7)
                            {
                                row.DefaultCellStyle = new DataGridViewCellStyle(_styleBold);
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
                            row.DefaultCellStyle = _RNG.Next(1, 10) >= 7 ? _styleBold : _styleRegular;
                        }
                    }

                    TimeSpan threadElapsed = DateTime.Now - threadStart;
                    lblThread.Text = $"Thread elapsed: {threadElapsed.TotalMilliseconds}ms";
                }));
            }
            else
            {
                if (dgFiles.DataSource == null)
                {
                    dgFiles.Columns.Clear();
                }

                if (_useVirtual == false)
                {
                    dgFiles.VirtualMode = false;
                    dgFiles.DataSource = _gridData;
                }
                else
                {
                    dgFiles.DataSource = null;
                    dgFiles.VirtualMode = true;
                    dgFiles.Columns.Clear();
                    dgFiles.Columns.Add("cName", "Name");
                    dgFiles.Columns.Add("cDate", "Date");
                    dgFiles.CellValueNeeded += OnCellValueNeeded;
                }

                _gridData.Clear();

                this.BeginInvoke(new Action(() =>
                {
                    // For timing
                    DateTime threadStart = DateTime.Now;

                    for (int i = 0; i < 1500; i++)
                    {
                        GridData data = new GridData() { Name = $"C:\\Folder\\Subfolder\\Long_File_Name_{_RNG.Next(1, int.MaxValue)}.pdf", Date = $"{DateTime.Now:G} - {_RNG.Next(1, 1000):0000}" };
                        _gridData.Add(data);

                        // Randomly set bolded font on about 40% of the rows, unless diabled
                        if (_useVirtual == false && _disableBolding == false && _boldingInLine == true)
                        {
                            dgFiles.Rows[dgFiles.Rows.Count - 1].DefaultCellStyle = _RNG.Next(1, 10) >= 7 ? _styleBold : _styleRegular;
                        }
                    }

                    // Randomly set bolded font on about 40% of the rows, unless diabled
                    if (_useVirtual == false && _disableBolding == false && _boldingInLine == false)
                    {
                        foreach (DataGridViewRow row in dgFiles.Rows)
                        {
                            row.DefaultCellStyle = _RNG.Next(1, 10) >= 7 ? _styleBold : _styleRegular;
                        }
                    }

                    if (_useVirtual == true)
                    {
                        dgFiles.RowCount = _gridData.Count;
                    }

                    TimeSpan threadElapsed = DateTime.Now - threadStart;
                    lblThread.Text = $"Thread time: {threadElapsed.TotalMilliseconds}ms";
                }));

            }

            // Force a sort, if present
            if (dgFiles.SortedColumn != null)
            {
                dgFiles.Sort(dgFiles.SortedColumn, dgFiles.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }

            // Force a resize
            this.BeginInvoke(new Action(() =>
            {
                ResizeColumns();
                ResizeColumns();
            }));

            if (_disabledDuringUpdates == true)
            {
                // Re-enable the entire control - this allows a final visual update
                dgFiles.Enabled = true;
            }

            // For timing
            TimeSpan elapsed = DateTime.Now - start;
            lblFillInfo.Text = $"Fill time: {elapsed.TotalMilliseconds}ms";

            EnableControls(true);

            Cursor.Current = Cursors.Default;
        }

        private void OnCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = _gridData[e.RowIndex].Name;

                    // If bolding is enabled...
                    if (_disableBolding == false)
                    {
                        // If the rows doesn't already have a default cell style set (e.g. don't do thismoren than one per row)
                        if (dgFiles.Rows[e.RowIndex].HasDefaultCellStyle == false)
                        {
                            if (_virtualDelay == true)
                            {
                                Thread.Sleep(10);
                            }

                            // Set to bold randomly for about 40% of the rows
                            if (_RNG.Next(1, 10) >= 7)
                            {
                                dgFiles.Rows[e.RowIndex].DefaultCellStyle = new DataGridViewCellStyle(_styleBold);
                            }
                            else
                            {
                                dgFiles.Rows[e.RowIndex].DefaultCellStyle = new DataGridViewCellStyle(_styleRegular);
                            }
                        }
                    }
                    break;

                case 1:
                    e.Value = _gridData[e.RowIndex].Date;
                    break;
            }
        }

        private void EnableControls(bool enable)
        {
            btnFill.Enabled = enable;
            cbDataSource.Enabled = enable && !_useVirtual;
            cbVirtual.Enabled = enable;
            cbDelay.Enabled = enable && _useVirtual;
            cbDisable.Enabled = enable;
            cbBoldingInLine.Enabled = enable && !_disableBolding;
            cbDisableBolding.Enabled = enable;
        }

        private void cbDataSource_CheckedChanged(object sender, EventArgs e)
        {
            _useDataSource = cbDataSource.Checked;
        }

        private void cbVirtual_CheckedChanged(object sender, EventArgs e)
        {
            _useVirtual = cbVirtual.Checked;
            EnableControls(true);
        }

        private void cbDisable_CheckedChanged(object sender, EventArgs e)
        {
            _disabledDuringUpdates = cbDisable.Checked;
        }

        private void cbBoldingInLine_CheckedChanged(object sender, EventArgs e)
        {
            _boldingInLine = cbBoldingInLine.Checked;
        }

        private void cbDisableBolding_CheckedChanged(object sender, EventArgs e)
        {
            _disableBolding = cbDisableBolding.Checked;
            EnableControls(true);
        }

        private void cbDelay_CheckedChanged(object sender, EventArgs e)
        {
            _virtualDelay = cbVirtual.Checked;
        }
    }
}
