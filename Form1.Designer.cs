namespace InventoryManagerDb
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		private TextBox txtName;
		private TextBox txtCategory;
		private NumericUpDown numQuantity;
		private NumericUpDown numPrice;
		private Button btnAdd;
		private Button btnUpdate;
		private Button btnDelete;
		private Button btnRefresh;
		private Button btnExit;
		private DataGridView dataGridView1;
		private Label lblStatus;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			txtName = new TextBox();
			txtCategory = new TextBox();
			numQuantity = new NumericUpDown();
			numPrice = new NumericUpDown();
			btnAdd = new Button();
			btnUpdate = new Button();
			btnDelete = new Button();
			btnRefresh = new Button();
			btnExit = new Button();
			dataGridView1 = new DataGridView();
			lblStatus = new Label();

			((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
			((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();

			// txtName
			txtName.Location = new Point(20, 20);
			txtName.Size = new Size(150, 27);
			txtName.Name = "txtName";
			txtName.PlaceholderText = "Product Name";

			// txtCategory
			txtCategory.Location = new Point(180, 20);
			txtCategory.Size = new Size(150, 27);
			txtCategory.Name = "txtCategory";
			txtCategory.PlaceholderText = "Category";

			// numQuantity
			numQuantity.Location = new Point(340, 20);
			numQuantity.Size = new Size(80, 27);
			numQuantity.Name = "numQuantity";

			// numPrice
			numPrice.Location = new Point(430, 20);
			numPrice.Size = new Size(80, 27);
			numPrice.DecimalPlaces = 2;
			numPrice.Name = "numPrice";

			// btnAdd
			btnAdd.Location = new Point(20, 60);
			btnAdd.Size = new Size(80, 30);
			btnAdd.Text = "Add";
			btnAdd.Name = "btnAdd";

			// btnUpdate
			btnUpdate.Location = new Point(110, 60);
			btnUpdate.Size = new Size(80, 30);
			btnUpdate.Text = "Update";
			btnUpdate.Name = "btnUpdate";

			// btnDelete
			btnDelete.Location = new Point(200, 60);
			btnDelete.Size = new Size(80, 30);
			btnDelete.Text = "Delete";
			btnDelete.Name = "btnDelete";

			// btnRefresh
			btnRefresh.Location = new Point(290, 60);
			btnRefresh.Size = new Size(80, 30);
			btnRefresh.Text = "Refresh";
			btnRefresh.Name = "btnRefresh";

			// btnExit
			btnExit.Location = new Point(380, 60);
			btnExit.Size = new Size(80, 30);
			btnExit.Text = "Exit";
			btnExit.Name = "btnExit";

			// dataGridView1
			dataGridView1.Location = new Point(20, 110);
			dataGridView1.Size = new Size(740, 250);
			dataGridView1.Name = "dataGridView1";

			// lblStatus
			lblStatus.Location = new Point(20, 380);
			lblStatus.Size = new Size(500, 25);
			lblStatus.Text = "Status...";
			lblStatus.Name = "lblStatus";

			// Form1
			ClientSize = new Size(800, 420);
			Controls.Add(txtName);
			Controls.Add(txtCategory);
			Controls.Add(numQuantity);
			Controls.Add(numPrice);
			Controls.Add(btnAdd);
			Controls.Add(btnUpdate);
			Controls.Add(btnDelete);
			Controls.Add(btnRefresh);
			Controls.Add(btnExit);
			Controls.Add(dataGridView1);
			Controls.Add(lblStatus);

			Name = "Form1";
			Text = "Inventory Manager";

			((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
			((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}
	}
}