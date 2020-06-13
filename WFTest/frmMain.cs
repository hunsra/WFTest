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
        private bool _disabledDuringUpdates = false;
        private Random _RNG = new Random((int)DateTime.Now.Ticks);

        public frmMain()
        {
            InitializeComponent();

            // Set controls to default state
            dgFiles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgFiles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cbDisable.Checked = _disabledDuringUpdates;
            
            // Add a handler for important events
            Resize += FrmMain_Resize;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            bool reenable = false;

            // For timing
            DateTime start = DateTime.Now;

            if (dgFiles.Enabled == true && _disabledDuringUpdates == true)
            {
                dgFiles.Enabled = false;
            }

            dgFiles.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            dgFiles.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);

            // Calculate the width of the first column - all remaining width or width of widest text, whichever is larger
            var current = dgFiles.Columns[0].Width;
            int offset = (dgFiles.ScrollBars & ScrollBars.Vertical) != ScrollBars.None ? System.Windows.Forms.SystemInformation.VerticalScrollBarWidth : 0;
            dgFiles.Columns[0].Width = Math.Max(current, dgFiles.Width - (SystemInformation.SizingBorderWidth * 2) - dgFiles.Columns[1].Width - (dgFiles.Columns[0].DividerWidth == 0 ? 1 : dgFiles.Columns[0].Width) - offset);

            if (reenable == true)
            {
                dgFiles.Enabled = true;
            }

            // For timing
            TimeSpan elapsed = DateTime.Now - start;
            lblResizeInfo.Text = $"Resize time: {elapsed.TotalMilliseconds}ms";
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
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
            
            // Add 1500 items to the data grid view
            for (int i = 0; i < 1500; i++)
            {
                // Randomly set bolded font on about 30% of the rows
                DataGridViewRow row = new DataGridViewRow();
                var rn = _RNG.Next(1, 10);
                if (rn >= 7)
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle() { Font = new Font(DefaultFont, FontStyle.Bold) };
                }
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = $"Name {i:0000} - {rn}";
                row.Cells[1].Value = $"{DateTime.Now:G} - {rn}";
                dgFiles.Rows.Add(row);
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

            Cursor.Current = Cursors.Default;
        }

        private void cbDisable_CheckedChanged(object sender, EventArgs e)
        {
            _disabledDuringUpdates = cbDisable.Checked;
        }
    }
}
