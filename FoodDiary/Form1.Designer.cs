namespace FoodDiary
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblFood = new System.Windows.Forms.Label();
            this.txtFood = new System.Windows.Forms.TextBox();
            this.lblCal = new System.Windows.Forms.Label();
            this.txtCal = new System.Windows.Forms.TextBox();
            this.lblFat = new System.Windows.Forms.Label();
            this.txtFat = new System.Windows.Forms.TextBox();
            this.lblProtein = new System.Windows.Forms.Label();
            this.txtPro = new System.Windows.Forms.TextBox();
            this.lblNutritionalInfo = new System.Windows.Forms.Label();
            this.dgFoodDict = new System.Windows.Forms.DataGridView();
            this.lblFoodDict = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblUserProfile = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblActivity = new System.Windows.Forms.Label();
            this.lblDietaryInfo = new System.Windows.Forms.Label();
            this.lblCalorieCount = new System.Windows.Forms.Label();
            this.lblFoodDiary = new System.Windows.Forms.Label();
            this.btnAddMeal = new System.Windows.Forms.Button();
            this.btnRemoveMeal = new System.Windows.Forms.Button();
            this.btnInsertFood = new System.Windows.Forms.Button();
            this.btnUpdateFood = new System.Windows.Forms.Button();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCalcDiary = new System.Windows.Forms.Button();
            this.btnClearDiary = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCarb = new System.Windows.Forms.Label();
            this.txtCarb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdProfileEdit = new System.Windows.Forms.Button();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFeet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInches = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cboActivity = new System.Windows.Forms.ComboBox();
            this.cmdProfileAccept = new System.Windows.Forms.Button();
            this.cmdProfileCancel = new System.Windows.Forms.Button();
            this.cmdProfileClear = new System.Windows.Forms.Button();
            this.dgDiary = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgFoodDict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new System.Drawing.Point(44, 86);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(50, 20);
            this.lblFood.TabIndex = 0;
            this.lblFood.Text = "Food:";
            // 
            // txtFood
            // 
            this.txtFood.Location = new System.Drawing.Point(106, 83);
            this.txtFood.MaxLength = 40;
            this.txtFood.Name = "txtFood";
            this.txtFood.ReadOnly = true;
            this.txtFood.Size = new System.Drawing.Size(337, 26);
            this.txtFood.TabIndex = 1;
            // 
            // lblCal
            // 
            this.lblCal.AutoSize = true;
            this.lblCal.Location = new System.Drawing.Point(22, 134);
            this.lblCal.Name = "lblCal";
            this.lblCal.Size = new System.Drawing.Size(70, 20);
            this.lblCal.TabIndex = 2;
            this.lblCal.Text = "Calories:";
            // 
            // txtCal
            // 
            this.txtCal.Location = new System.Drawing.Point(106, 132);
            this.txtCal.MaxLength = 5;
            this.txtCal.Name = "txtCal";
            this.txtCal.ReadOnly = true;
            this.txtCal.Size = new System.Drawing.Size(92, 26);
            this.txtCal.TabIndex = 2;
            // 
            // lblFat
            // 
            this.lblFat.AutoSize = true;
            this.lblFat.Location = new System.Drawing.Point(56, 182);
            this.lblFat.Name = "lblFat";
            this.lblFat.Size = new System.Drawing.Size(37, 20);
            this.lblFat.TabIndex = 4;
            this.lblFat.Text = "Fat:";
            // 
            // txtFat
            // 
            this.txtFat.Location = new System.Drawing.Point(106, 180);
            this.txtFat.MaxLength = 7;
            this.txtFat.Name = "txtFat";
            this.txtFat.ReadOnly = true;
            this.txtFat.Size = new System.Drawing.Size(92, 26);
            this.txtFat.TabIndex = 3;
            // 
            // lblProtein
            // 
            this.lblProtein.AutoSize = true;
            this.lblProtein.Location = new System.Drawing.Point(30, 275);
            this.lblProtein.Name = "lblProtein";
            this.lblProtein.Size = new System.Drawing.Size(63, 20);
            this.lblProtein.TabIndex = 6;
            this.lblProtein.Text = "Protein:";
            // 
            // txtPro
            // 
            this.txtPro.Location = new System.Drawing.Point(104, 275);
            this.txtPro.MaxLength = 7;
            this.txtPro.Name = "txtPro";
            this.txtPro.ReadOnly = true;
            this.txtPro.Size = new System.Drawing.Size(92, 26);
            this.txtPro.TabIndex = 5;
            // 
            // lblNutritionalInfo
            // 
            this.lblNutritionalInfo.AutoSize = true;
            this.lblNutritionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNutritionalInfo.Location = new System.Drawing.Point(30, 35);
            this.lblNutritionalInfo.Name = "lblNutritionalInfo";
            this.lblNutritionalInfo.Size = new System.Drawing.Size(188, 20);
            this.lblNutritionalInfo.TabIndex = 8;
            this.lblNutritionalInfo.Text = "Nutritional Information";
            // 
            // dgFoodDict
            // 
            this.dgFoodDict.AllowUserToAddRows = false;
            this.dgFoodDict.AllowUserToDeleteRows = false;
            this.dgFoodDict.AllowUserToResizeColumns = false;
            this.dgFoodDict.AllowUserToResizeRows = false;
            this.dgFoodDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFoodDict.Location = new System.Drawing.Point(476, 75);
            this.dgFoodDict.MultiSelect = false;
            this.dgFoodDict.Name = "dgFoodDict";
            this.dgFoodDict.ReadOnly = true;
            this.dgFoodDict.RowTemplate.Height = 28;
            this.dgFoodDict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFoodDict.Size = new System.Drawing.Size(598, 289);
            this.dgFoodDict.TabIndex = 0;
            // 
            // lblFoodDict
            // 
            this.lblFoodDict.AutoSize = true;
            this.lblFoodDict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodDict.Location = new System.Drawing.Point(478, 35);
            this.lblFoodDict.Name = "lblFoodDict";
            this.lblFoodDict.Size = new System.Drawing.Size(135, 20);
            this.lblFoodDict.TabIndex = 10;
            this.lblFoodDict.Text = "Food Dictionary";
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.AutoSize = true;
            this.lblUserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserProfile.Location = new System.Drawing.Point(56, 478);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(103, 20);
            this.lblUserProfile.TabIndex = 11;
            this.lblUserProfile.Text = "User Profile";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(106, 534);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(40, 20);
            this.lblSex.TabIndex = 17;
            this.lblSex.Text = "Sex:";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(82, 586);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(63, 20);
            this.lblWeight.TabIndex = 19;
            this.lblWeight.Text = "Weight:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(87, 631);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(60, 20);
            this.lblHeight.TabIndex = 20;
            this.lblHeight.Text = "Height:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(105, 682);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(42, 20);
            this.lblAge.TabIndex = 21;
            this.lblAge.Text = "Age:";
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.Location = new System.Drawing.Point(44, 732);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(103, 20);
            this.lblActivity.TabIndex = 22;
            this.lblActivity.Text = "Activity Level:";
            // 
            // lblDietaryInfo
            // 
            this.lblDietaryInfo.AutoSize = true;
            this.lblDietaryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDietaryInfo.ForeColor = System.Drawing.Color.Black;
            this.lblDietaryInfo.Location = new System.Drawing.Point(472, 838);
            this.lblDietaryInfo.Name = "lblDietaryInfo";
            this.lblDietaryInfo.Size = new System.Drawing.Size(0, 25);
            this.lblDietaryInfo.TabIndex = 24;
            // 
            // lblCalorieCount
            // 
            this.lblCalorieCount.AutoSize = true;
            this.lblCalorieCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalorieCount.ForeColor = System.Drawing.Color.Black;
            this.lblCalorieCount.Location = new System.Drawing.Point(472, 878);
            this.lblCalorieCount.Name = "lblCalorieCount";
            this.lblCalorieCount.Size = new System.Drawing.Size(0, 25);
            this.lblCalorieCount.TabIndex = 25;
            // 
            // lblFoodDiary
            // 
            this.lblFoodDiary.AutoSize = true;
            this.lblFoodDiary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodDiary.Location = new System.Drawing.Point(472, 489);
            this.lblFoodDiary.Name = "lblFoodDiary";
            this.lblFoodDiary.Size = new System.Drawing.Size(96, 20);
            this.lblFoodDiary.TabIndex = 27;
            this.lblFoodDiary.Text = "Food Diary";
            // 
            // btnAddMeal
            // 
            this.btnAddMeal.Enabled = false;
            this.btnAddMeal.Location = new System.Drawing.Point(704, 405);
            this.btnAddMeal.Name = "btnAddMeal";
            this.btnAddMeal.Size = new System.Drawing.Size(182, 35);
            this.btnAddMeal.TabIndex = 28;
            this.btnAddMeal.Text = "Add";
            this.btnAddMeal.UseVisualStyleBackColor = true;
            this.btnAddMeal.Click += new System.EventHandler(this.btnAddMeal_Click);
            // 
            // btnRemoveMeal
            // 
            this.btnRemoveMeal.Enabled = false;
            this.btnRemoveMeal.Location = new System.Drawing.Point(704, 462);
            this.btnRemoveMeal.Name = "btnRemoveMeal";
            this.btnRemoveMeal.Size = new System.Drawing.Size(182, 35);
            this.btnRemoveMeal.TabIndex = 29;
            this.btnRemoveMeal.Text = "Remove";
            this.btnRemoveMeal.UseVisualStyleBackColor = true;
            this.btnRemoveMeal.Click += new System.EventHandler(this.btnRemoveMeal_Click);
            // 
            // btnInsertFood
            // 
            this.btnInsertFood.Location = new System.Drawing.Point(1146, 75);
            this.btnInsertFood.Name = "btnInsertFood";
            this.btnInsertFood.Size = new System.Drawing.Size(182, 35);
            this.btnInsertFood.TabIndex = 30;
            this.btnInsertFood.Text = "Insert Food Item";
            this.btnInsertFood.UseVisualStyleBackColor = true;
            this.btnInsertFood.Click += new System.EventHandler(this.btnInsertFood_Click);
            // 
            // btnUpdateFood
            // 
            this.btnUpdateFood.Enabled = false;
            this.btnUpdateFood.Location = new System.Drawing.Point(1146, 126);
            this.btnUpdateFood.Name = "btnUpdateFood";
            this.btnUpdateFood.Size = new System.Drawing.Size(182, 35);
            this.btnUpdateFood.TabIndex = 31;
            this.btnUpdateFood.Text = "Update Food Item";
            this.btnUpdateFood.UseVisualStyleBackColor = true;
            this.btnUpdateFood.Click += new System.EventHandler(this.btnUpdateFood_Click);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.Enabled = false;
            this.btnDeleteFood.Location = new System.Drawing.Point(1146, 177);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(182, 35);
            this.btnDeleteFood.TabIndex = 32;
            this.btnDeleteFood.Text = "Delete Food Item";
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(22, 329);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 35);
            this.btnAccept.TabIndex = 33;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(296, 329);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 35);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(1023, 625);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 20);
            this.lblInfo.TabIndex = 37;
            // 
            // btnCalcDiary
            // 
            this.btnCalcDiary.Enabled = false;
            this.btnCalcDiary.Location = new System.Drawing.Point(1146, 568);
            this.btnCalcDiary.Name = "btnCalcDiary";
            this.btnCalcDiary.Size = new System.Drawing.Size(182, 35);
            this.btnCalcDiary.TabIndex = 38;
            this.btnCalcDiary.Text = "Calculate";
            this.btnCalcDiary.UseVisualStyleBackColor = true;
            this.btnCalcDiary.Click += new System.EventHandler(this.btnCalcDiary_Click);
            // 
            // btnClearDiary
            // 
            this.btnClearDiary.Enabled = false;
            this.btnClearDiary.Location = new System.Drawing.Point(1146, 523);
            this.btnClearDiary.Name = "btnClearDiary";
            this.btnClearDiary.Size = new System.Drawing.Size(182, 35);
            this.btnClearDiary.TabIndex = 39;
            this.btnClearDiary.Text = "Clear Diary";
            this.btnClearDiary.UseVisualStyleBackColor = true;
            this.btnClearDiary.Click += new System.EventHandler(this.btnClearDiary_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(158, 329);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCarb
            // 
            this.lblCarb.AutoSize = true;
            this.lblCarb.Location = new System.Drawing.Point(46, 231);
            this.lblCarb.Name = "lblCarb";
            this.lblCarb.Size = new System.Drawing.Size(47, 20);
            this.lblCarb.TabIndex = 41;
            this.lblCarb.Text = "Carb:";
            // 
            // txtCarb
            // 
            this.txtCarb.Location = new System.Drawing.Point(104, 228);
            this.txtCarb.MaxLength = 7;
            this.txtCarb.Name = "txtCarb";
            this.txtCarb.ReadOnly = true;
            this.txtCarb.Size = new System.Drawing.Size(92, 26);
            this.txtCarb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "cal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "g";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "g";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "g";
            // 
            // cmdProfileEdit
            // 
            this.cmdProfileEdit.Location = new System.Drawing.Point(165, 472);
            this.cmdProfileEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdProfileEdit.Name = "cmdProfileEdit";
            this.cmdProfileEdit.Size = new System.Drawing.Size(144, 35);
            this.cmdProfileEdit.TabIndex = 47;
            this.cmdProfileEdit.Text = "Edit User Profile";
            this.cmdProfileEdit.UseVisualStyleBackColor = true;
            this.cmdProfileEdit.Click += new System.EventHandler(this.cmdProfileEdit_Click);
            // 
            // cboSex
            // 
            this.cboSex.Enabled = false;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboSex.Location = new System.Drawing.Point(165, 531);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(97, 28);
            this.cboSex.TabIndex = 48;
            // 
            // txtWeight
            // 
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(165, 583);
            this.txtWeight.MaxLength = 3;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(40, 26);
            this.txtWeight.TabIndex = 49;
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 634);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "Feet:";
            // 
            // txtFeet
            // 
            this.txtFeet.Enabled = false;
            this.txtFeet.Location = new System.Drawing.Point(214, 631);
            this.txtFeet.MaxLength = 1;
            this.txtFeet.Name = "txtFeet";
            this.txtFeet.Size = new System.Drawing.Size(22, 26);
            this.txtFeet.TabIndex = 51;
            this.txtFeet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 634);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 52;
            this.label6.Text = "Inches:";
            // 
            // txtInches
            // 
            this.txtInches.Enabled = false;
            this.txtInches.Location = new System.Drawing.Point(314, 631);
            this.txtInches.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInches.MaxLength = 2;
            this.txtInches.Name = "txtInches";
            this.txtInches.Size = new System.Drawing.Size(31, 26);
            this.txtInches.TabIndex = 53;
            this.txtInches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(166, 678);
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(40, 26);
            this.txtAge.TabIndex = 54;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboActivity
            // 
            this.cboActivity.Enabled = false;
            this.cboActivity.FormattingEnabled = true;
            this.cboActivity.Items.AddRange(new object[] {
            "Sedentary",
            "Lightly Active",
            "Moderately Active",
            "Very Active",
            "Extremely Active"});
            this.cboActivity.Location = new System.Drawing.Point(165, 725);
            this.cboActivity.Name = "cboActivity";
            this.cboActivity.Size = new System.Drawing.Size(184, 28);
            this.cboActivity.TabIndex = 55;
            // 
            // cmdProfileAccept
            // 
            this.cmdProfileAccept.Enabled = false;
            this.cmdProfileAccept.Location = new System.Drawing.Point(22, 778);
            this.cmdProfileAccept.Name = "cmdProfileAccept";
            this.cmdProfileAccept.Size = new System.Drawing.Size(112, 35);
            this.cmdProfileAccept.TabIndex = 56;
            this.cmdProfileAccept.Text = "Accept";
            this.cmdProfileAccept.UseVisualStyleBackColor = true;
            this.cmdProfileAccept.Click += new System.EventHandler(this.cmdProfileAccept_Click);
            // 
            // cmdProfileCancel
            // 
            this.cmdProfileCancel.Enabled = false;
            this.cmdProfileCancel.Location = new System.Drawing.Point(158, 778);
            this.cmdProfileCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdProfileCancel.Name = "cmdProfileCancel";
            this.cmdProfileCancel.Size = new System.Drawing.Size(112, 35);
            this.cmdProfileCancel.TabIndex = 57;
            this.cmdProfileCancel.Text = "Cancel";
            this.cmdProfileCancel.UseVisualStyleBackColor = true;
            this.cmdProfileCancel.Click += new System.EventHandler(this.cmdProfileCancel_Click);
            // 
            // cmdProfileClear
            // 
            this.cmdProfileClear.Enabled = false;
            this.cmdProfileClear.Location = new System.Drawing.Point(296, 778);
            this.cmdProfileClear.Name = "cmdProfileClear";
            this.cmdProfileClear.Size = new System.Drawing.Size(112, 35);
            this.cmdProfileClear.TabIndex = 58;
            this.cmdProfileClear.Text = "Clear";
            this.cmdProfileClear.UseVisualStyleBackColor = true;
            this.cmdProfileClear.Click += new System.EventHandler(this.cmdProfileClear_Click);
            // 
            // dgDiary
            // 
            this.dgDiary.AllowUserToAddRows = false;
            this.dgDiary.AllowUserToDeleteRows = false;
            this.dgDiary.AllowUserToResizeColumns = false;
            this.dgDiary.AllowUserToResizeRows = false;
            this.dgDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDiary.Location = new System.Drawing.Point(472, 523);
            this.dgDiary.MultiSelect = false;
            this.dgDiary.Name = "dgDiary";
            this.dgDiary.ReadOnly = true;
            this.dgDiary.RowTemplate.Height = 28;
            this.dgDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDiary.Size = new System.Drawing.Size(602, 289);
            this.dgDiary.TabIndex = 59;
            this.dgDiary.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(729, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 61;
            this.label7.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(801, 31);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(186, 26);
            this.txtSearch.TabIndex = 62;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(994, 28);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(112, 35);
            this.cmdSearch.TabIndex = 63;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1360, 973);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgDiary);
            this.Controls.Add(this.cmdProfileClear);
            this.Controls.Add(this.cmdProfileCancel);
            this.Controls.Add(this.cmdProfileAccept);
            this.Controls.Add(this.cboActivity);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtInches);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFeet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.cboSex);
            this.Controls.Add(this.cmdProfileEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCarb);
            this.Controls.Add(this.lblCarb);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClearDiary);
            this.Controls.Add(this.btnCalcDiary);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.btnUpdateFood);
            this.Controls.Add(this.btnInsertFood);
            this.Controls.Add(this.btnRemoveMeal);
            this.Controls.Add(this.btnAddMeal);
            this.Controls.Add(this.lblFoodDiary);
            this.Controls.Add(this.lblCalorieCount);
            this.Controls.Add(this.lblDietaryInfo);
            this.Controls.Add(this.lblActivity);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblUserProfile);
            this.Controls.Add(this.lblFoodDict);
            this.Controls.Add(this.dgFoodDict);
            this.Controls.Add(this.lblNutritionalInfo);
            this.Controls.Add(this.txtPro);
            this.Controls.Add(this.lblProtein);
            this.Controls.Add(this.txtFat);
            this.Controls.Add(this.lblFat);
            this.Controls.Add(this.txtCal);
            this.Controls.Add(this.lblCal);
            this.Controls.Add(this.txtFood);
            this.Controls.Add(this.lblFood);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Diary Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFoodDict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDiary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.TextBox txtFood;
        private System.Windows.Forms.Label lblCal;
        private System.Windows.Forms.TextBox txtCal;
        private System.Windows.Forms.Label lblFat;
        private System.Windows.Forms.TextBox txtFat;
        private System.Windows.Forms.Label lblProtein;
        private System.Windows.Forms.TextBox txtPro;
        private System.Windows.Forms.Label lblNutritionalInfo;
        private System.Windows.Forms.DataGridView dgFoodDict;
        private System.Windows.Forms.Label lblFoodDict;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lblUserProfile;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label lblDietaryInfo;
        private System.Windows.Forms.Label lblCalorieCount;
        private System.Windows.Forms.Label lblFoodDiary;
        private System.Windows.Forms.Button btnAddMeal;
        private System.Windows.Forms.Button btnRemoveMeal;
        private System.Windows.Forms.Button btnInsertFood;
        private System.Windows.Forms.Button btnUpdateFood;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCalcDiary;
        private System.Windows.Forms.Button btnClearDiary;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCarb;
        private System.Windows.Forms.TextBox txtCarb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdProfileEdit;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFeet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInches;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.ComboBox cboActivity;
        private System.Windows.Forms.Button cmdProfileAccept;
        private System.Windows.Forms.Button cmdProfileCancel;
        private System.Windows.Forms.Button cmdProfileClear;
        private System.Windows.Forms.DataGridView dgDiary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdSearch;
    }

}

