using System;
using System.Data;
using System.Data.SQLite;

namespace InventoryManagerDb
{
	public static class Db
	{
		private const string ConnStr = "Data Source=Inventory.db;Version=3;";

		// CREATE TABLE
		public static void EnsureCreated()
		{
			using var conn = new SQLiteConnection(ConnStr);
			conn.Open();

			string sql = @"CREATE TABLE IF NOT EXISTS Products (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Category TEXT NOT NULL,
                Quantity INTEGER NOT NULL CHECK(Quantity >= 0),
                Price REAL NOT NULL CHECK(Price >= 0)
            );";

			using var cmd = new SQLiteCommand(sql, conn);
			cmd.ExecuteNonQuery();
		}

		// GET ALL PRODUCTS
		public static DataTable GetAll()
		{
			using var conn = new SQLiteConnection(ConnStr);
			conn.Open();

			var adapter = new SQLiteDataAdapter("SELECT * FROM Products", conn);
			var table = new DataTable();
			adapter.Fill(table);

			return table;
		}

		// SEARCH PRODUCTS
		public static DataTable Search(string? nameLike, string? categoryLike)
		{
			using var conn = new SQLiteConnection(ConnStr);
			conn.Open();

			string sql = "SELECT * FROM Products WHERE 1=1 ";
			using var cmd = new SQLiteCommand(conn);

			if (!string.IsNullOrWhiteSpace(nameLike))
			{
				sql += "AND Name LIKE @name ";
				cmd.Parameters.AddWithValue("@name", "%" + nameLike + "%");
			}

			if (!string.IsNullOrWhiteSpace(categoryLike))
			{
				sql += "AND Category LIKE @category ";
				cmd.Parameters.AddWithValue("@category", "%" + categoryLike + "%");
			}

			sql += "ORDER BY Name;";
			cmd.CommandText = sql;

			var table = new DataTable();
			using var adapter = new SQLiteDataAdapter(cmd);
			adapter.Fill(table);

			return table;
		}

		// INSERT PRODUCT
		public static void Insert(Product p)
		{
			using var conn = new SQLiteConnection(ConnStr);
			conn.Open();

			string sql = "INSERT INTO Products (Name, Category, Quantity, Price) VALUES (@n, @c, @q, @p)";
			using var cmd = new SQLiteCommand(sql, conn);

			cmd.Parameters.AddWithValue("@n", p.Name);
			cmd.Parameters.AddWithValue("@c", p.Category);
			cmd.Parameters.AddWithValue("@q", p.Quantity);
			cmd.Parameters.AddWithValue("@p", p.Price);

			cmd.ExecuteNonQuery();
		}

		// UPDATE PRODUCT
		public static void Update(Product p)
		{
			if (p.Id <= 0) throw new ArgumentException("Valid Id required to update.");

			using var conn = new SQLiteConnection(ConnStr);
			conn.Open();

			string sql = "UPDATE Products SET Name=@n, Category=@c, Quantity=@q, Price=@p WHERE Id=@id";
			using var cmd = new SQLiteCommand(sql, conn);

			cmd.Parameters.AddWithValue("@n", p.Name);
			cmd.Parameters.AddWithValue("@c", p.Category);
			cmd.Parameters.AddWithValue("@q", p.Quantity);
			cmd.Parameters.AddWithValue("@p", p.Price);
			cmd.Parameters.AddWithValue("@id", p.Id);

			cmd.ExecuteNonQuery();
		}

		// DELETE PRODUCT
		public static void Delete(long id)
		{
			using var conn = new SQLiteConnection(ConnStr);
			conn.Open();

			using var cmd = new SQLiteCommand("DELETE FROM Products WHERE Id=@id;", conn);
			cmd.Parameters.AddWithValue("@id", id);

			cmd.ExecuteNonQuery();
		}
	}
}