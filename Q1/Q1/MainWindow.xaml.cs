using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Q1
{
    public partial class MainWindow : Window
    {
        private readonly string _connectionString = "Data Source=WASAYPC;Initial Catalog=Q1;Integrated Security=True;Encrypt=False;";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();

            c1.Items.Add("By Grade A");//1
            c1.Items.Add("By Grade B");//2
            c1.Items.Add("By Grade C");//3
            c1.Items.Add("By Grade D");//4
            c1.Items.Add("By Grade F");//5
            c1.Items.Add("By Subject Biology");//6
            c1.Items.Add("By Subject Chemistry");//7
            c1.Items.Add("By Subject Physics");//8
            c1.Items.Add("None");//9
        }


        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    ProductDataGrid.ItemsSource = table.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(GradeTextBox.Text))
            {
                MessageBox.Show("Any field cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Student (id,Name,Grade,Subject,Marks,percentage) VALUES (@id,@Name,@Grade,@Subject,@Marks,@percentage)", connection);
                    command.Parameters.AddWithValue("@id", idTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Name", NameTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Grade", GradeTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Subject", SubjectTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@Marks", MarksTextBox.Text.Trim());
                    command.Parameters.AddWithValue("@percentage", PercentTextBox.Text.Trim());
                    command.ExecuteNonQuery();
                }

                LoadData();
                MessageBox.Show("Record added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Record: {ex.Message}");
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is DataRowView selectedRow)
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(GradeTextBox.Text))
                {
                    MessageBox.Show("None of the fields can be empty.");
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(
                        "UPDATE Student SET Name = @Name, Grade = @Grade, Subject=@Subject, Marks=@Marks,percentage=@percentage WHERE id = @id", connection);
                        
                        command.Parameters.AddWithValue("@Name", NameTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@Grade", GradeTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@Subject", SubjectTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@Marks", MarksTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@percentage", PercentTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.ExecuteNonQuery();
                    }

                    LoadData();
                    MessageBox.Show("Record updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating Record: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a Record to update.");
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is DataRowView selectedRow)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("DELETE FROM Student WHERE id = @id", connection);
                        command.Parameters.AddWithValue("@id", selectedRow["id"]);
                        command.ExecuteNonQuery();
                    }

                    LoadData();
                    MessageBox.Show("Record deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting Record: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a Record to delete.");
            }
        }

        private void c1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(c1.SelectedIndex == 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Grade='A'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if (c1.SelectedIndex == 1)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Grade='B'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if(c1.SelectedIndex == 2)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Grade='C'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if(c1.SelectedIndex==3)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Grade='D'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if(c1.SelectedIndex==4)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Grade='F'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if(c1.SelectedIndex == 5)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Subject='Biology'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if( c1.SelectedIndex == 6)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Subject='Chemistry'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if(c1.SelectedIndex==7)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE Subject='Physics'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
            else if(c1.SelectedIndex==8)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductDataGrid.ItemsSource = table.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }

            else
            {
                Application.Current.Shutdown();
            }

        }
    }
}
