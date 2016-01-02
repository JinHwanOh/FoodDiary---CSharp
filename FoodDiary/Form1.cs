using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace FoodDiary
{
    public partial class Form1 : Form
    {

        // data members
	string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string path = (System.IO.Path.GetDirectoryName(executable));
        AppDomain.CurrentDomain.SetData("DataDirectory", path);

        private String CONN_STR = "Data Source=|DataDirectory|\FoodDiary.mdf";
        
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        int indexNum = -1;
        int addedRowDict;
        int addedRowDiary;

        bool insertMode = false;

        //bool isSorted = false; // temp

        // User Profile File
        string path = "user.txt";

        public Form1()
        {
            if (userDataExists())
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("User File Missing or Corrupt. Creating new file with default values", "User File Missing or Corrupt",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                defaultFileLoad();
                InitializeComponent();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //getDataFromCsv(); // temp remove method
            // load data to dgFoodDict
            getData();

            // read user profile
            readUserFile();

            // delegates
            dgFoodDict.Click += dgFoodDict_Click;
            dgFoodDict.RowsAdded += dgFoodDict_RowsAdded;
            //dgFoodDict.Sorted += dgFoodDict_Sorted;
            dgDiary.Click += dgDiary_Click;
            dgDiary.RowsAdded += dgDiary_RowsAdded;

            // disable context menu strip
            txtFood.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            txtCal.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            txtFat.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            txtCarb.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            txtPro.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

            // turn off sorting, so user cannot sort
            for (int i = 0; i < dgFoodDict.Columns.Count; i++)
            {
                dgFoodDict.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // User profile keypress and ContextMenuStrip
            cboActivity.KeyPress += cboActivity_KeyPress;
            cboSex.KeyPress += cboSex_KeyPress;
            txtAge.KeyPress += txtAge_KeyPress;
            txtFeet.KeyPress += txtFeet_KeyPress;
            txtInches.KeyPress += txtInches_KeyPress;
            txtWeight.KeyPress += txtWeight_KeyPress;
            cboActivity.ContextMenuStrip = new ContextMenuStrip();
            cboSex.ContextMenuStrip = new ContextMenuStrip();
            txtAge.ContextMenuStrip = new ContextMenuStrip();
            txtInches.ContextMenuStrip = new ContextMenuStrip();
            txtFeet.ContextMenuStrip = new ContextMenuStrip();
            txtWeight.ContextMenuStrip = new ContextMenuStrip();

            txtFood.KeyPress += txtFood_KeyPress;
            txtCal.KeyPress += txtCal_KeyPress;
            txtCarb.KeyPress += txtCarb_KeyPress;
            txtFat.KeyPress += txtFat_KeyPress;
            txtPro.KeyPress += txtPro_KeyPress;

            updateCalorieBudgetLabel();

            // style ui elements
            dgFoodDict.Width = 420;
            dgFoodDict.Columns[0].Width = 320;
            dgFoodDict.Columns[1].Width = 40;

            dgDiary.Width = 420;
            dgDiary.Columns[0].Width = 320;
            dgDiary.Columns[1].Width = 40;

            // juan: hide dgFoodDict columns - by jin
            dgFoodDict.Columns[2].Visible = false;
            dgFoodDict.Columns[3].Visible = false;
            dgFoodDict.Columns[4].Visible = false;
            dgFoodDict.ClearSelection();

            // hide dgFoodDiary columns
            dgDiary.Columns[2].Visible = false;
            dgDiary.Columns[3].Visible = false;
            dgDiary.Columns[4].Visible = false;

            // sort dgFoodDict on load
            if (dgFoodDict.Rows.Count > 0)
            {
                this.dgFoodDict.Sort(this.dgFoodDict.Columns["name"], ListSortDirection.Ascending);
                dgFoodDict.Rows[0].Selected = true;
                dgFoodDict_Click(dgFoodDict, e);
            }

        }

        // temp method fires if dg is sorted
        //void dgFoodDict_Sorted(object sender, EventArgs e)
        //{
        //    Console.Write("dg was sorted!\n");
        //    isSorted = true;
        //}


        // fires if row added to dg
        void dgFoodDict_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            addedRowDict = e.RowIndex;
            //MessageBox.Show(addedRow.ToString()); // temp
            //Console.Write("Row index added to food dg: " + addedRowDict + "\n"); // temp
        }


        // fires if row added to diary
        void dgDiary_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            addedRowDiary = e.RowIndex;
            //Console.Write("Row index added to diary dg: " + addedRowDiary + "\n"); // temp
        }


        void dgFoodDict_Click(object sender, EventArgs e)
        {
            // check if there are rows in foodDict to click...
            if (dgFoodDict.Rows.Count > 0)
            {
                indexNum = dgFoodDict.CurrentRow.Index;

                // align indexNum with actual index of dataset
                for (int i = 0; i < dataSet.Tables["tFoods"].Rows.Count; i++)
                {
                    if (dataSet.Tables["tFoods"].Rows[i].RowState != DataRowState.Deleted)
                    {
                        // inside data set
                        if (dgFoodDict.CurrentRow.Cells[0].Value.ToString().Equals(dataSet.Tables["tFoods"].Rows[i][0].ToString()))
                        {
                            // item found reset index
                            indexNum = i;
                            break;
                        }
                    }
                }

                // make sure current row selected
                dgFoodDict.CurrentRow.Selected = true;
                txtFood.Text = dgFoodDict.CurrentRow.Cells["name"].Value.ToString();
                txtCal.Text = dgFoodDict.CurrentRow.Cells["calories"].Value.ToString();
                txtFat.Text = dgFoodDict.CurrentRow.Cells["fat"].Value.ToString();
                txtCarb.Text = dgFoodDict.CurrentRow.Cells["carb"].Value.ToString();
                txtPro.Text = dgFoodDict.CurrentRow.Cells["protein"].Value.ToString();

                // set control state to neutral if dg is clicked
                if (cmdProfileAccept.Enabled == true)
                {
                    setControlState("editProfileEscapeDict");
                }
                else
                {
                    setControlState("neutral");
                    btnAddMeal.Enabled = true;
                    btnRemoveMeal.Enabled = false;

                }
                // JUAN: foodDiary selection cleared when clicking on food dict
                dgDiary.ClearSelection();
                
            }
        }


        private void dgDiary_Click(object sender, EventArgs e)
        {
            // dgFoodDict item deselected when dgDiary is clicked
            dgFoodDict.ClearSelection();

            //if something in foodDiary is selected and diary is not empty, btnRemove, btnCalcDiary, btnClearDiary become avaliable
            btnAddMeal.Enabled = false;

            if (dgDiary.CurrentRow == null)
            {
                btnRemoveMeal.Enabled = false;
                btnCalcDiary.Enabled = false;
                btnClearDiary.Enabled = false;
            }
            else
            {
                if (cmdProfileAccept.Enabled == true)
                {
                    setControlState("editProfileEscapeDiary");

                }
                else
                {
                    btnRemoveMeal.Enabled = true;
                    btnCalcDiary.Enabled = true;
                    btnClearDiary.Enabled = true;
                }

                // display nutritional info of clicked item
                dgDiary.CurrentRow.Selected = true;
                txtFood.Text = dgDiary.CurrentRow.Cells["name"].Value.ToString();
                txtCal.Text = dgDiary.CurrentRow.Cells["calories"].Value.ToString();
                txtFat.Text = dgDiary.CurrentRow.Cells["fat"].Value.ToString();
                txtCarb.Text = dgDiary.CurrentRow.Cells["carb"].Value.ToString();
                txtPro.Text = dgDiary.CurrentRow.Cells["protein"].Value.ToString();

                // set control state to dictEmpty if dgDiary is clicked (cannot perform update or delete on dgFoodDict)
                setControlState("dictEmpty");
            }
        }


        // gets data from db
        private void getData()
        {
            try
            {
                // create connection object
                conn = new SqlConnection(CONN_STR);
                // open connection
                conn.Open();
                // sql statement
                string sql = "SELECT * FROM [tFoods]";

                // create data adapter
                adapter = new SqlDataAdapter(sql, conn);

                // create command builder
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                // create dataset
                dataSet = new DataSet();
                adapter.Fill(dataSet, "tFoods");
                conn.Close();

                // check if cols already exist...
                if (dgDiary.Columns.Count == 0)
                {
                    //...if not, create columns for food dairy, add columns to datagrid
                    dgDiary.Columns.Add("name", "name");
                    dgDiary.Columns.Add("calories", "calories");
                    dgDiary.Columns.Add("fat", "fat");
                    dgDiary.Columns.Add("carb", "carb");
                    dgDiary.Columns.Add("protein", "protein");
                }
               
                // bind and display
                bindingSource1.DataSource = dataSet;
                bindingSource1.DataMember = "tFoods";

                dgFoodDict.DataSource = bindingSource1;
                dgFoodDict.ClearSelection();
            }
            catch (SqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message, "Error Reading from Database");
            }
        }


        private void btnInsertFood_Click(object sender, EventArgs e)
        {

            // setBtnState to insert
            insertMode = true;
            setControlState("edit");

            // clear textboxes for new item entry and set focus
            clearTextBoxFood();
            txtFood.Focus();

        }


        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            insertMode = false;
            setControlState("edit");
            txtFood.Focus();
        }


        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            // check if there are rows in the dg before running delete
            if (dgFoodDict.Rows.Count > 0)
            {
                // delete selected
                string foodName = dgFoodDict.CurrentRow.Cells[0].Value.ToString();

                try
                {
                    // create connection object
                    conn = new SqlConnection(CONN_STR);
                    // open connection
                    conn.Open();
                    // sql statement
                    string sql = "DELETE FROM [tFoods] WHERE [name] = '" + foodName + "'";

                    // create data adapter
                    adapter = new SqlDataAdapter(sql, conn);

                    // create command
                    SqlCommand sCMD = new SqlCommand();
                    //set connection
                    sCMD.Connection = conn;
                    //set sql command
                    sCMD.CommandText = sql;
                    //execute query
                    sCMD.ExecuteNonQuery();
                    //close connection
                    conn.Close();
                    //update the database
                    getData();
                }
                catch (SqlException ex)
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    MessageBox.Show(ex.Message, "Error Reading from Database");
                }

                // if last item in dict has been deleted...
                if (dgFoodDict.Rows.Count < 1)
                {
                    clearTextBoxFood();

                    // update or delete not allowed, lock all buttons except insert...
                    setControlState("dictEmpty");

                    return;
                }
                // last item has not been deleted...
                dgFoodDict_Click(dgFoodDict, e);
            }
            else
            {
                // TO DO: no items to delete msg
            }

        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dataGood())
            {
                if (insertMode)
                {

                    if (MessageBox.Show("Are you sure you want to insert this item?", "Confirm Insert Item",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // insert mode...inserted pk must be unique
                        for (int i = 0; i < dgFoodDict.Rows.Count; i++)
                        {
                            if (txtFood.Text.ToLower().Equals(dgFoodDict.Rows[i].Cells[0].Value.ToString().ToLower()))
                            {
                                MessageBox.Show("This food item already exists.  Please enter another.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtFood.Focus();
                                return;
                            }
                        }
                        try
                        {
                            // create connection object
                            conn = new SqlConnection(CONN_STR);
                            // open connection
                            conn.Open();
                            // sql statement
                            string foodName = txtFood.Text;
                            string sql = "INSERT INTO [tFoods]([name] , [calories] , [fat] , [carb] , [protein]) VALUES ('" + txtFood.Text + "'," + Convert.ToInt32(txtCal.Text) + "," + Convert.ToDouble(txtFat.Text) + "," + Convert.ToDouble(txtCarb.Text) + "," + Convert.ToDouble(txtPro.Text) + ")";

                            // create data adapter
                            adapter = new SqlDataAdapter(sql, conn);

                            // create command
                            SqlCommand sCMD = new SqlCommand();
                            //set connection
                            sCMD.Connection = conn;
                            //set sql command
                            sCMD.CommandText = sql;
                            //execute query
                            sCMD.ExecuteNonQuery();
                            //close connection
                            conn.Close();
                            //update the database
                            getData();

                            //go to newly added cell
                            string searchText = txtFood.Text;
                            string currentItem = null;
                            bool searchFlag = false;
                            dgFoodDict.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgFoodDict.ClearSelection();
                            if (searchText.Length != 0)
                            {
                                try
                                {
                                    foreach (DataGridViewRow row in dgFoodDict.Rows)
                                    {
                                        currentItem = row.Cells["name"].Value.ToString();
                                        if (currentItem.Length >= searchText.Length)
                                        {
                                            if (currentItem.Substring(0, searchText.Length).ToLower().Equals(searchText.ToLower()))
                                            {

                                                // Juan: fixed update nutrition info on successful search item
                                                // go to newly added cell
                                                dgFoodDict.CurrentCell = row.Cells[0];
                                                // select newly added row
                                                row.Selected = true;
                                                // call dg click on selected
                                                dgFoodDict_Click(dgFoodDict, e);
                                                searchFlag = true;
                                                break;

                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                if (!searchFlag)
                                {
                                    MessageBox.Show("Cannot find \"" + txtSearch.Text + "\" in food dictionary list", "Food Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                            MessageBox.Show(ex.Message, "Error Reading from Database");
                        }
                    }
                }
                else if (!insertMode)
                {
                    if (MessageBox.Show("Are you sure you want to update this item?", "Confirm Update Item",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // update mode...pk of current row may be edited
                        try
                        {
                            //save old updated food name
                            string origFoodName = Convert.ToString(dgFoodDict.CurrentRow.Cells[0].Value);
                            // create connection object
                            conn = new SqlConnection(CONN_STR);
                            // open connection
                            conn.Open();
                            // sql statement
                            string sql = "UPDATE [tFoods] SET [name] = '" + txtFood.Text + "', [calories] = " + Convert.ToInt32(txtCal.Text) + ", [fat] = " + Convert.ToDouble(txtFat.Text) + ", [carb] = " + Convert.ToDouble(txtCarb.Text) + ", [protein] = " + Convert.ToDouble(txtPro.Text) + "WHERE [Name] = '" + origFoodName + "'";

                            // create data adapter
                            adapter = new SqlDataAdapter(sql, conn);

                            // create command
                            SqlCommand sCMD = new SqlCommand();
                            //set connection
                            sCMD.Connection = conn;
                            //set sql command
                            sCMD.CommandText = sql;
                            //execute query
                            sCMD.ExecuteNonQuery();
                            //close connection
                            conn.Close();
                            //update the database
                            getData();
                            //go to newly added cell
                            string searchText = txtFood.Text;
                            string currentItem = null;
                            bool searchFlag = false;
                            dgFoodDict.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            dgFoodDict.ClearSelection();
                            if (searchText.Length != 0)
                            {
                                try
                                {
                                    foreach (DataGridViewRow row in dgFoodDict.Rows)
                                    {
                                        currentItem = row.Cells["name"].Value.ToString();
                                        if (currentItem.Length >= searchText.Length)
                                        {
                                            if (currentItem.Substring(0, searchText.Length).ToLower().Equals(searchText.ToLower()))
                                            {

                                                // Juan: fixed update nutrition info on successful search item
                                                // go to newly added cell
                                                dgFoodDict.CurrentCell = row.Cells[0];
                                                // select newly added row
                                                row.Selected = true;
                                                // call dg click on selected
                                                dgFoodDict_Click(dgFoodDict, e);
                                                searchFlag = true;
                                                break;

                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                if (!searchFlag)
                                {
                                    MessageBox.Show("Cannot find \"" + txtSearch.Text + "\" in food dictionary list", "Food Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                            MessageBox.Show(ex.Message, "Error Updating Database");
                        }
                    }

                    // set button state
                    setControlState("neutral");
                    // sort
                    this.dgFoodDict.Sort(this.dgFoodDict.Columns["name"], ListSortDirection.Ascending);
                }
            }
        }


        // cancels operation in food module
        private void btnCancel_Click(object sender, EventArgs e)
        {

            // re-display nutritional information of currently selected row...
            if (dgFoodDict.Rows.Count > 0)
            {
                // make sure current row selected
                dgFoodDict.CurrentRow.Selected = true;
                // call dg click on last selected
                dgFoodDict_Click(dgFoodDict, e);

                // set button state
                setControlState("neutral");
            }
            else
            {
                // foodDict empty, set control state...
                setControlState("dictEmpty");
            }

        }


        private bool dataGood()
        {

            // check food empty...
            if (txtFood.Text.Length < 1)
            {
                MessageBox.Show("Please enter food name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFood.Focus();
                return false;
            }
            // check calories empty...
            if (txtCal.Text.Length < 1)
            {
                MessageBox.Show("Please enter number of calories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCal.Focus();
                return false;
            }
            // check fat empty
            if (txtFat.Text.Length < 1)
            {
                MessageBox.Show("Please enter amount of fat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFat.Focus();
                return false;
            }
            // check carb empty...
            if (txtCarb.Text.Length < 1)
            {
                MessageBox.Show("Please enter number of carbs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCarb.Focus();
                return false;
            }
            // check protein empty...
            if (txtPro.Text.Length < 1)
            {
                MessageBox.Show("Please enter amount of protein.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPro.Focus();
                return false;
            }
            return true;

        }

        // clears food module text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to clear text boxes?", "Confirm Clear",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                clearTextBoxFood();
            }

        }


        // sets state of controls to edit or neutral
        private void setControlState(string state)
        {

            if (state.Equals("edit"))
            {
                // unlock buttons
                btnAccept.Enabled = true;
                btnCancel.Enabled = true;
                btnClear.Enabled = true;
                cmdSearch.Enabled = false; //jin
                cmdProfileEdit.Enabled = false;

                btnCalcDiary.Enabled = false;
                btnClearDiary.Enabled = false;

                // unlock text
                txtFood.ReadOnly = false;
                txtCal.ReadOnly = false;
                txtFat.ReadOnly = false;
                txtCarb.ReadOnly = false;
                txtPro.ReadOnly = false;
                txtSearch.ReadOnly = true; // jin

                // lock insert, update, delete
                btnInsertFood.Enabled = false;
                btnUpdateFood.Enabled = false;
                btnDeleteFood.Enabled = false;
            }
            else if (state.Equals("neutral"))
            {
                // lock buttons
                btnAccept.Enabled = false;
                btnCancel.Enabled = false;
                btnClear.Enabled = false;
                cmdSearch.Enabled = true; // jin

                cmdProfileEdit.Enabled = true;

                // lock text
                txtFood.ReadOnly = true;
                txtCal.ReadOnly = true;
                txtFat.ReadOnly = true;
                txtCarb.ReadOnly = true;
                txtPro.ReadOnly = true;
                txtSearch.ReadOnly = false; // jin

                // enable insert, update, delete
                btnInsertFood.Enabled = true;
                btnUpdateFood.Enabled = true;
                btnDeleteFood.Enabled = true;
            }
            else if (state.Equals("dictEmpty"))
            {
                // lock buttons
                btnAccept.Enabled = false;
                btnCancel.Enabled = false;
                btnClear.Enabled = false;
                cmdSearch.Enabled = false; // jin

                cmdProfileEdit.Enabled = true;

                // lock text
                txtFood.ReadOnly = true;
                txtCal.ReadOnly = true;
                txtFat.ReadOnly = true;
                txtCarb.ReadOnly = true;
                txtPro.ReadOnly = true;
                txtSearch.ReadOnly = true; // jin

                // enable insert, update, delete
                btnInsertFood.Enabled = true;
                btnUpdateFood.Enabled = false;
                btnDeleteFood.Enabled = false;

                // disable add meal, dict is empty
                btnAddMeal.Enabled = false;
            }
            else if (state.Equals("editProfileEscapeDict"))
            {
                if (MessageBox.Show("Cannot access dictionary, while in Edit Profile.  Cancel Edit Profile and discard all changes?", "Confirm Cancel",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    // lock buttons
                    btnAccept.Enabled = false;
                    btnCancel.Enabled = false;
                    btnClear.Enabled = false;
                    cmdSearch.Enabled = true;

                    //cmdProfileEdit.Enabled = true;

                    // lock text
                    txtFood.ReadOnly = true;
                    txtCal.ReadOnly = true;
                    txtFat.ReadOnly = true;
                    txtCarb.ReadOnly = true;
                    txtPro.ReadOnly = true;
                    txtSearch.ReadOnly = false; // jin

                    // enable insert, update, delete
                    btnInsertFood.Enabled = true;
                    btnUpdateFood.Enabled = true;
                    btnDeleteFood.Enabled = true;

                    btnAddMeal.Enabled = true;
                    btnRemoveMeal.Enabled = false;
                    setUserControlState("a");
                    readUserFile();
                }
            }
            else if (state.Equals("editProfileEscapeDiary"))
            {
                if (MessageBox.Show("Cannot access the Diary while Edit Profile is open. Cancel Edit Profile and discard all changes?", "Confirm Cancel",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    // lock buttons
                    btnAccept.Enabled = false;
                    btnCancel.Enabled = false;
                    btnClear.Enabled = false;
                    cmdSearch.Enabled = true; 

                    //cmdProfileEdit.Enabled = true;

                    // lock text
                    txtFood.ReadOnly = true;
                    txtCal.ReadOnly = true;
                    txtFat.ReadOnly = true;
                    txtCarb.ReadOnly = true;
                    txtPro.ReadOnly = true;
                    txtSearch.ReadOnly = false;

                    // enable insert, update, delete
                    btnInsertFood.Enabled = true;
                    btnUpdateFood.Enabled = true;
                    btnDeleteFood.Enabled = true;

                    btnAddMeal.Enabled = false;
                    btnRemoveMeal.Enabled = true;
                    setUserControlState("a");
                    readUserFile();
                }

            }

        }


        // clears text boxes of food module
        private void clearTextBoxFood()
        {

            txtFood.Text = "";
            txtCal.Text = "";
            txtFat.Text = "";
            txtCarb.Text = "";
            txtPro.Text = "";

        }


        // ****************************
        // USER PROFILE METHODS SECTION
        // ****************************
        private void readUserFile()
        {

            // File reading
            StreamReader sr = new StreamReader(path);
            string record = sr.ReadLine();
            char[] delim = { ';' };
            string[] tokens = record.Split(delim);
            cboSex.Text = tokens[0];
            txtWeight.Text = tokens[1];
            txtFeet.Text = tokens[2];
            txtInches.Text = tokens[3];
            txtAge.Text = tokens[4];
            cboActivity.Text = tokens[5];
            sr.Close();

        }


        private void defaultFileLoad()
        {

            // Creates and configures a file with default settings
            StreamWriter sw = new StreamWriter(path, false);
            sw.WriteLine("Male" + ";" + "200" + ";" + "5" + ";" + "5" + ";" + "35" + ";" + "Moderately Active");
            sw.Close();

        }


        private void clearUserText()
        {

            cboSex.Text = "Male";
            txtWeight.Text = "";
            txtFeet.Text = "";
            txtInches.Text = "";
            txtAge.Text = "";
            cboActivity.Text = "Moderately Active";
            cboSex.Focus();

        }

        //User profile state control
        private void setUserControlState(string state)
        {

            if (state.Equals("e"))
            {
                cboSex.Enabled = true;
                cboActivity.Enabled = true;
                txtAge.Enabled = true;
                txtFeet.Enabled = true;
                txtInches.Enabled = true;
                txtWeight.Enabled = true;
                txtSearch.Enabled = false;
                cmdProfileAccept.Enabled = true;
                cmdProfileCancel.Enabled = true;
                cmdProfileClear.Enabled = true;
                cmdProfileEdit.Enabled = false;
                cmdSearch.Enabled = false;
                btnAddMeal.Enabled = false;
                btnCalcDiary.Enabled = false;
                btnClearDiary.Enabled = false;
                btnDeleteFood.Enabled = false;
                btnInsertFood.Enabled = false;
                btnRemoveMeal.Enabled = false;
                btnUpdateFood.Enabled = false;
            }
            else if (state.Equals("a"))
            {
                cboSex.Enabled = false;
                cboActivity.Enabled = false;
                txtAge.Enabled = false;
                txtFeet.Enabled = false;
                txtInches.Enabled = false;
                txtWeight.Enabled = false;
                txtSearch.Enabled = true;
                cmdProfileAccept.Enabled = false;
                cmdProfileCancel.Enabled = false;
                cmdProfileClear.Enabled = false;
                cmdProfileEdit.Enabled = true;
                cmdSearch.Enabled = true;
                btnInsertFood.Enabled = true;
                btnUpdateFood.Enabled = true;
            }

        }


        // Diagnostic method for user file
        private bool userDataExists()
        {

            // Check if the file exists
            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                // Checking if file contains correct amount of elements
                StreamReader sr = new StreamReader(path);
                string record = sr.ReadLine();
                char[] delim = { ';' };
                string[] tokens = record.Split(delim);
                int len = tokens.Length;
                sr.Close();
                if (len != 6)
                {
                    return false;
                }
                return true;
            }

        }


        // User Data validation
        private bool userDataGood()
        {

            if (cboSex.Text.Length < 1)
            {
                MessageBox.Show("Must choose male or female!", "Sex Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboSex.Focus();
                return false;
            }
            if (txtWeight.Text.Length < 1)
            {
                MessageBox.Show("Weight required!", "Weight Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWeight.Focus();
                return false;
            }
            if (Convert.ToInt32(txtWeight.Text) > 400)
            {
                MessageBox.Show("Weight number must be 400 or lower!", "Weight Number Too High", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWeight.Focus();
                return false;
            }
            if (Convert.ToInt32(txtWeight.Text) < 85)
            {
                MessageBox.Show("Weight number must be 85 or higher!", "Weight Number Too Low", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWeight.Focus();
                return false;
            }
            
            if (txtFeet.Text.Length < 1)
            {
                MessageBox.Show("Feet required!", "Feet Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFeet.Focus();
                return false;
            }
            if (txtInches.Text.Length < 1)
            {
                MessageBox.Show("Inches required!", "Inches Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInches.Focus();
                return false;
            }
            if (Convert.ToInt32(txtFeet.Text) > 7)
            {
                MessageBox.Show("Number of feet must be 7 or lower!", "Feet Number Too High", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFeet.Focus();
                return false;
            }
            if (Convert.ToInt32(txtFeet.Text) < 3)
            {
                MessageBox.Show("Number of feet must be 3 or higher!", "Feet Number Too Low", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFeet.Focus();
                return false;
            }

            
            if (txtAge.Text.Length < 1)
            {
                MessageBox.Show("Age Required!", "Age Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
                return false;
            }
            if (Convert.ToDouble(txtAge.Text) > 110)
            {
                MessageBox.Show("Age must be 110 or lower!", "Age Number Too High", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
                return false;
            }
            if (Convert.ToDouble(txtAge.Text) < 13)
            {
                MessageBox.Show("Age must be 13 or higher!", "Age Number Too Low", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
                return false;
            }


            if (cboActivity.Text.Length < 1)
            {
                MessageBox.Show("Must choose an activity level!", "Activity Level Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboActivity.Focus();
                return false;
            }
            return true;

        }


        // Keypress validation routines
        void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {

            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            if (c != 8)
            {
                if (c < 48 || c > 57)// not number
                {
                    e.Handled = true;
                }
                else if (len == 0 && c == 48)// first digit 0
                {
                    e.Handled = true;
                }
                else if (((TextBox)sender).SelectionStart == 0 && c == 48)
                {
                    e.Handled = true;
                }

            }

        }


        void txtInches_KeyPress(object sender, KeyPressEventArgs e)
        {

            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            //((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)//not number
                {
                    e.Handled = true;
                }
                else if (len == 0)//
                {
                    e.Handled = false;
                }
                else if (len == 1 && !txtInches.Text.Equals("1"))
                {
                    e.Handled = true;
                }
                else if (len == 1 && txtInches.Text.Equals("1") && c < 48 || c > 49)
                {
                    e.Handled = true;
                    MessageBox.Show("Number of inches must be between 0 and 11!", "Invalid Inches Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInches.Focus();
                }
                else if (((TextBox)sender).SelectionStart == 0 && len == 1 && c == 48)
                {
                    e.Handled = true;
                }
            }

        }


        void txtFeet_KeyPress(object sender, KeyPressEventArgs e)
        {

            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)//not number
                {
                    e.Handled = true;
                }
                
            }

        }


        void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {

            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            if (c != 8)
            {

                if (len == 0 && c == 48)
                {
                    e.Handled = true;
                }
                else if (c < 48 || c > 57)//not number
                {
                    e.Handled = true;
                }
                else if (((TextBox)sender).SelectionStart == 0 && c == 48)
                {
                    e.Handled = true;
                }

            }

        }


        // Disabling input on comboBoxes
        void cboActivity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        void cboSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        // Button click_event methods
        private void cmdProfileAccept_Click(object sender, EventArgs e)
        {

            if (userDataGood())
            {
                if (MessageBox.Show("Are you sure you want to make these changes?", "Confirm Change User Information",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    StreamWriter sw = new StreamWriter(path, false);
                    sw.WriteLine(cboSex.Text + ";" + txtWeight.Text + ";" + txtFeet.Text + ";" + txtInches.Text + ";" + txtAge.Text + ";" + cboActivity.Text);
                    sw.Close();
                    setUserControlState("a");
                    updateCalorieBudgetLabel(); 
                    updateCalorieCalulationLabel();

                }
            }

        }


        private void cmdProfileClear_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to clear all text boxes?", "Confirm Clear",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                clearUserText();
            }

        }


        private void cmdProfileCancel_Click(object sender, EventArgs e)
        {
            readUserFile();
            setUserControlState("a");
            dgFoodDict.Focus();
        }


        private void cmdProfileEdit_Click(object sender, EventArgs e)
        {

            setUserControlState("e");
        }

        private void btnAddMeal_Click(object sender, EventArgs e)
        {

            //create a btn lock in seperate method only allow add from FoodDict
            string tempName = dgFoodDict.CurrentRow.Cells[0].Value.ToString();
            int tempCalories = Convert.ToInt32(dgFoodDict.CurrentRow.Cells[1].Value.ToString());
            double tempFat = Convert.ToDouble(dgFoodDict.CurrentRow.Cells[2].Value.ToString());
            double tempCarbs = Convert.ToDouble(dgFoodDict.CurrentRow.Cells[3].Value.ToString());
            double tempProtein = Convert.ToDouble(dgFoodDict.CurrentRow.Cells[4].Value.ToString());
            dgDiary.Rows.Add(tempName, tempCalories, tempFat, tempCarbs, tempProtein);
            dgFoodDict.ClearSelection();
            dgDiary.ClearSelection();
            btnCalcDiary.Enabled = true;
            btnClearDiary.Enabled = true;

            //TODO turn all AllowUser... options to false, as well as tabStop in design mode for dgDiary
            // JUAN: when item added from the food dict, go to the added row in diary and display nutritional info in txtboxes
            // go to newly added cell
            dgDiary.CurrentCell = dgDiary.Rows[addedRowDiary].Cells[0];
            // select newly added row
            dgDiary.Rows[addedRowDiary].Selected = true;
            // call dg click on last selected
            dgDiary_Click(dgDiary, e);
        }


        private void btnRemoveMeal_Click(object sender, EventArgs e)
        {
            if (dgDiary.CurrentRow != null)
            {
                indexNum = dgDiary.CurrentRow.Index;
                dgDiary.Rows.RemoveAt(indexNum);
                // click next row after delete
                dgDiary_Click(dgDiary, e);
                indexNum = 0;  // JUAN: reason for setting back to zero?

                //if the diary is empty remove button clickablity
                if (dgDiary.CurrentRow == null)
                {
                    btnRemoveMeal.Enabled = false;
                    btnCalcDiary.Enabled = false;
                    btnClearDiary.Enabled = false;
                }

            }

        }


        private void btnClearDiary_Click(object sender, EventArgs e)
        {

            //check if the user wants to clear the dataGrid, if they do clear the rows
            //when the diary is empty remove clickablity of remove, calc, and clear
            if (MessageBox.Show("Are you sure you want to clear the diary?", "Diary Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {

                dgDiary.Rows.Clear();
                dgFoodDict.Focus();

                btnRemoveMeal.Enabled = false;
                btnCalcDiary.Enabled = false;
                btnClearDiary.Enabled = false;

            }

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            string currentItem = null;
            bool searchFlag = false;
            dgFoodDict.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFoodDict.ClearSelection();
            if (searchText.Length != 0)
            {
                try
                {
                    foreach (DataGridViewRow row in dgFoodDict.Rows)
                    {
                        currentItem = row.Cells["name"].Value.ToString();
                        if (currentItem.Length >= searchText.Length)
                        {
                            if (currentItem.Substring(0, searchText.Length).ToLower().Equals(searchText.ToLower()))
                            {

                                // fixed update nutrition info on successful search item
                                // go to newly added cell
                                dgFoodDict.CurrentCell = row.Cells[0];
                                // select newly added row
                                row.Selected = true;
                                // call dg click on selected
                                dgFoodDict_Click(dgFoodDict, e);
                                searchFlag = true;
                                break;

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (!searchFlag)
                {
                    MessageBox.Show("Cannot find \"" + txtSearch.Text + "\" in food dictionary list", "Food Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }

        }


        private void btnCalcDiary_Click(object sender, EventArgs e)
        {
            updateCalorieBudgetLabel();
            updateCalorieCalulationLabel();
        }


        private void updateCalorieCalulationLabel()
        {

            int caloriesBudget = getCaloriesBudget();
            int totalFoodCalories = getFoodCalories();

            if (totalFoodCalories != 0)
            {
                int remainingBudget = caloriesBudget - totalFoodCalories;
                if (remainingBudget < 0)
                {
                    lblCalorieCount.Text = "You exceeded your budget by " + remainingBudget * -1 + " calories!\nCalorie Budget - Total Calorie Intake\n" + caloriesBudget + " cal - " + totalFoodCalories + " cal = " + remainingBudget + " cal";
                }
                else if (remainingBudget > 1)
                {
                    lblCalorieCount.Text = "You have " + remainingBudget + " calories remaining today.\nCalorie Budget - Total Calorie Intake\n" + caloriesBudget + " cal - " + totalFoodCalories + " cal = " + remainingBudget + " cal";
                }
                else
                {
                    lblCalorieCount.Text = "You have no calories remaining today.\nCalorie Budget - Total Calorie Intake\n" + caloriesBudget + " cal - " + totalFoodCalories + " cal = " + remainingBudget + " cal";
                }
            }
        }


        void updateCalorieBudgetLabel()
        {
            int caloriesBudget = getCaloriesBudget();
            lblDietaryInfo.Text = "Based on your profile, your daily calorie budget is " + caloriesBudget + " calories.";
        }


        public int getCaloriesBudget()
        {
            double bmr = 0.0;
            double budget = 0.0;
            int budgetInt = 0;
            switch (cboSex.Text)
            {
                case ("Male"):
                    // 66 + (6.23 x weight in pounds ) + (12.7 x height in inches ) - (6.8 x age).
                    bmr = 66 + (6.23 * Convert.ToDouble(txtWeight.Text)) + (12.7 * (12.0 * Convert.ToDouble(txtFeet.Text) + Convert.ToDouble(txtInches.Text)) - (6.8 * Convert.ToDouble(txtAge.Text)));
                    break;
                case ("Female"):
                    // 655 + (4.35 x weight in pounds ) + (4.7 x height in inches ) - (4.7 x age).
                    bmr = 665 + (4.35 * Convert.ToDouble(txtWeight.Text)) + (4.7 * (12.0 * Convert.ToDouble(txtFeet.Text) + Convert.ToDouble(txtInches.Text)) - (4.7 * Convert.ToDouble(txtAge.Text)));
                    break;

                default:
                    MessageBox.Show("Error calculating BMR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            switch (cboActivity.Text)
            {
                case ("Sedentary"):
                    budget = bmr * 1.2;
                    break;
                case ("Lightly Active"):
                    budget = bmr * 1.375;
                    break;
                case ("Moderately Active"):
                    budget = bmr * 1.55;
                    break;
                case ("Very Active"):
                    budget = bmr * 1.725;
                    break;
                case ("Extremely Active"):
                    budget = bmr * 1.9;
                    break;

                default:
                    MessageBox.Show("Error calculating calories budget", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            budgetInt = Convert.ToInt32(budget);
            return budgetInt;
        }


        public int getFoodCalories()
        {
            int foodCalories = 0;
            try
            {
                foreach (DataGridViewRow row in dgDiary.Rows)
                {
                    foodCalories += Convert.ToInt32(row.Cells["calories"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return foodCalories;
        }


        void txtFood_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;

            if (c != 8)
            {
                // space cannot be first letter
                if (len == 0)
                {
                    if (c == 32)
                    {
                        e.Handled = true;
                    }
                }

                // accepts only letters, numbers, comma(,), period(.), space
                if (c != 32 && c != 44 && c != 46 && (c < 65 || c > 90) && (c < 97 || c > 122) && (c < 48 || c > 57))
                {
                    e.Handled = true;
                }
            }
        }


        void txtPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 0) // first digit must be number
                {
                    if (c < 48 || c > 57)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    // length greater than 0 .. can insert number or a period
                    if (c != 46)
                    {
                        if (c < 48 || c > 57)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        // period entered... check if period already exist
                        if (((TextBox)sender).Text.IndexOf(".") > -1)
                        {
                            e.Handled = true;
                        }
                    }
                }
                // period not found.. max length is 4
                if (((TextBox)sender).Text.IndexOf(".") == -1)
                {
                    if (len == 4)
                    {
                        if (c != 46)
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (((TextBox)sender).Text.IndexOf(".") > -1)
                {
                    // decimal exists
                    if (len == ((TextBox)sender).Text.IndexOf(".") + 3)
                    {
                        // 2 digit after decimal point
                        e.Handled = true;
                    }
                }
            }
        }
        void txtFat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 0) // first digit must be number
                {
                    if (c < 48 || c > 57)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    // length greater than 0 .. can insert number or a period
                    if (c != 46)
                    {
                        if (c < 48 || c > 57)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        // period entered... check if period already exist
                        if (((TextBox)sender).Text.IndexOf(".") > -1)
                        {
                            e.Handled = true;
                        }
                    }
                }
                // period not found.. max length is 4
                if (((TextBox)sender).Text.IndexOf(".") == -1)
                {
                    if (len == 4)
                    {
                        if (c != 46)
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (((TextBox)sender).Text.IndexOf(".") > -1)
                {
                    // decimal exists
                    if (len == ((TextBox)sender).Text.IndexOf(".") + 3)
                    {
                        // 2 digit after decimal point
                        e.Handled = true;
                    }
                }
            }
        }

        void txtCarb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 0) // first digit must be number
                {
                    if (c < 48 || c > 57)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    // length greater than 0 .. can insert number or a period
                    if (c != 46)
                    {
                        if (c < 48 || c > 57)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        // period entered... check if period already exist
                        if (((TextBox)sender).Text.IndexOf(".") > -1)
                        {
                            e.Handled = true;
                        }
                    }
                }
                // period not found.. max length is 4
                if (((TextBox)sender).Text.IndexOf(".") == -1)
                {
                    if (len == 4)
                    {
                        if (c != 46)
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (((TextBox)sender).Text.IndexOf(".") > -1)
                {
                    // decimal exists
                    if (len == ((TextBox)sender).Text.IndexOf(".") + 3)
                    {
                        // 2 digit after decimal point
                        e.Handled = true;
                    }
                }
            }
        }


        void txtCal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            //((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)
                {
                    e.Handled = true;
                }

            }
        }


        // gets CVS data
        private void getDataFromCsv()
        {

            StreamReader sr = new StreamReader("foodlist.csv");
            string records;
            char[] delim = { ';' };
            SqlCommand cmd = new SqlCommand();

            // create connection object
            conn = new SqlConnection(CONN_STR);
            // open connection
            cmd.Connection = conn;
            conn.Open();
            records = sr.ReadLine();
            while (records != null)
            {

                string[] data = records.Split(delim);
                records = sr.ReadLine();

                string sql = "INSERT INTO [tFoods] ([name], [calories], [fat], [carb], [protein]) VALUES ('" +
                  data[0].ToString() + "','" +
                  Convert.ToInt32(data[1]) + "','" +
                  Convert.ToDouble(data[2]) + "','" +
                  Convert.ToDouble(data[3]) + "','" +
                  Convert.ToDouble(data[4]) + "')";
                try
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // Close connection
            if (conn != null)
            {
                conn.Close();
            }

        }

    }

}