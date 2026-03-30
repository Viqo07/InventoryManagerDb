using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventoryManagerDb
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Hook up events (NO Properties window needed)
			btnAdd.Click += btnAdd_Click;
			btnUpdate.Click += btnUpdate_Click;
			btnDelete.Click += btnDelete_Click;
			btnRefresh.Click += btnRefresh_Click;
			btnExit.Click += btnExit_Click;

			dataGridView1.CellClick += dataGridView1_CellClick;
			this.Load += Form1_Load;
		}

		// FORM LOAD
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				Db.EnsureCreated();
				LoadData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// LOAD DATA
		private void LoadData()
		{
			try
			{
				dataGridView1.DataSource = Db.GetAll();
				lblStatus.Text = "Products loaded.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// ADD PRODUCT
		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				var p = new Product(
					txtName.Text,
					txtCategory.Text,
					(int)numQuantity.Value,
					(double)numPrice.Value
				);

				Db.Insert(p);
				LoadData();
				ClearInputs();

				lblStatus.Text = "Product added.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// UPDATE PRODUCT
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView1.CurrentRow == null)
				{
					MessageBox.Show("Select a row first.");
					return;
				}

				long id = Convert.ToInt64(dataGridView1.CurrentRow.Cells["Id"].Value);

				var p = new Product(
					txtName.Text,
					txtCategory.Text,
					(int)numQuantity.Value,
					(double)numPrice.Value,
					id
				);

				Db.Update(p);
				LoadData();
				ClearInputs();

				lblStatus.Text = "Product updated.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// DELETE PRODUCT
		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView1.CurrentRow == null)
				{
					MessageBox.Show("Select a row first.");
					return;
				}

				var confirm = MessageBox.Show(
					"Are you sure you want to delete?",
					"Confirm",
					MessageBoxButtons.YesNo
				);

				if (confirm == DialogResult.No) return;

				long id = Convert.ToInt64(dataGridView1.CurrentRow.Cells["Id"].Value);

				Db.Delete(id);
				LoadData();
				ClearInputs();

				lblStatus.Text = "Product deleted.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// REFRESH
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
			lblStatus.Text = "Refreshed.";
		}

		// EXIT
		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// CLICK GRID → LOAD INTO INPUTS
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (dataGridView1.CurrentRow == null) return;

				txtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
				txtCategory.Text = dataGridView1.CurrentRow.Cells["Category"].Value.ToString();
				numQuantity.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Quantity"].Value);
				numPrice.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Price"].Value);
			}
			catch { }
		}

		// CLEAR INPUTS
		private void ClearInputs()
		{
			txtName.Clear();
			txtCategory.Clear();
			numQuantity.Value = 0;
			numPrice.Value = 0;
		}
	}
}